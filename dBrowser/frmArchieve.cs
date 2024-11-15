using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace dBrowser
{
    public partial class frmArchive : Form
    {
        private string sourceConnectionString;
        private string archiveConnectionString;
        private string SQLservername;
        private string SQLDatabase;
        private string SQLUsername;
        private string SQLPassword;

        public frmArchive()
        {
            InitializeComponent();
        }

        private void frmArchive_Load(object sender, EventArgs e)
        {
            LoadConnectionSettings();
            InitializeDataGridView();
            groupServer.Visible = false;
        }

        private void LoadConnectionSettings()
        {
            try
            {
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "settings.xml");

                if (File.Exists(filePath))
                {
                    XElement settingsXml = XElement.Load(filePath);

                    SQLservername = settingsXml.Element("SQLServerName")?.Value ?? throw new Exception("SQLServerName not found in settings.");
                    SQLDatabase = settingsXml.Element("DatabaseName")?.Value ?? throw new Exception("DatabaseName not found in settings.");
                    SQLUsername = settingsXml.Element("UserName")?.Value ?? throw new Exception("UserName not found in settings.");
                    SQLPassword = settingsXml.Element("Password")?.Value ?? throw new Exception("Password not found in settings.");

                    var builder = new SqlConnectionStringBuilder
                    {
                        DataSource = SQLservername,
                        InitialCatalog = SQLDatabase,
                        UserID = SQLUsername,
                        Password = SQLPassword
                    };

                    sourceConnectionString = builder.ConnectionString;
                    archiveConnectionString = builder.ConnectionString.Replace(SQLDatabase, SQLDatabase + "_ARCHIVE");
                }
                else
                {
                    MessageBox.Show("Connection settings file not found. Please configure settings.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading connection settings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeDataGridView()
        {
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("Timestamp", "Timestamp");
                dataGridView1.Columns.Add("Message", "Message");
            }
            dataGridView1.Rows.Clear();
        }

        private void StartArchiveProcess()
        {
            if (string.IsNullOrEmpty(sourceConnectionString) || string.IsNullOrEmpty(archiveConnectionString))
            {
                MessageBox.Show("Connection strings are not initialized. Please check your settings.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CreateArchiveDatabase(SQLDatabase + "_ARCHIVE");
            TransferTablesToArchive();
        }


        private void CreateArchiveDatabase(string archiveDbName)
        {
            using (var connection = new SqlConnection(sourceConnectionString))
            {
                try
                {
                    connection.Open();
                    string createDbQuery = $"IF DB_ID('{archiveDbName}') IS NULL CREATE DATABASE [{archiveDbName}]";

                    using (var cmd = new SqlCommand(createDbQuery, connection))
                    {
                        cmd.ExecuteNonQuery();
                        LogProgress($"Archive database '{archiveDbName}' created successfully.");
                    }
                }
                catch (Exception ex)
                {
                    LogError($"Error creating archive database '{archiveDbName}': {ex.Message}");
                }
            }
        }

        private void TransferTablesToArchive()
        {
            using (var sourceConn = new SqlConnection(sourceConnectionString))
            {
                try
                {
                    sourceConn.Open();
                    string getTablesQuery = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";

                    using (var cmd = new SqlCommand(getTablesQuery, sourceConn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string tableName = reader.GetString(0);
                            TransferTableData(tableName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogError($"Error transferring tables: {ex.Message}");
                }
            }
        }

        private void TransferTableData(string tableName)
        {
            using (var sourceConn = new SqlConnection(sourceConnectionString))
            using (var archiveConn = new SqlConnection(archiveConnectionString))
            {
                try
                {
                    sourceConn.Open();
                    archiveConn.Open();

                    // Get column definitions only once per table for better performance
                    var columnDefinitions = GetColumnDefinitions(tableName, sourceConn);

                    string createTableQuery = GenerateCreateTableQuery(tableName, columnDefinitions);
                    using (var createTableCmd = new SqlCommand(createTableQuery, archiveConn))
                    {
                        createTableCmd.ExecuteNonQuery();
                        LogProgress($"Table '{tableName}' structure created in archive database.");
                        TransferTableDataWithoutIdentity(tableName, sourceConn, archiveConn);
                    }
                }
                catch (Exception ex)
                {
                    LogError($"Error archiving table '{tableName}': {ex.Message}");
                }
            }
        }

        private List<string> GetColumnDefinitions(string tableName, SqlConnection connection)
        {
            var columnDefinitions = new List<string>();
            string columnDefinitionQuery = @"
                SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH,
                       COLUMNPROPERTY(OBJECT_ID(@TableName), COLUMN_NAME, 'IsIdentity') AS IsIdentity
                FROM INFORMATION_SCHEMA.COLUMNS
                WHERE TABLE_NAME = @TableName";

            using (var columnCmd = new SqlCommand(columnDefinitionQuery, connection))
            {
                columnCmd.Parameters.AddWithValue("@TableName", tableName);

                using (var reader = columnCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string columnName = reader["COLUMN_NAME"].ToString();
                        string dataType = reader["DATA_TYPE"].ToString();
                        int? maxLength = reader["CHARACTER_MAXIMUM_LENGTH"] as int?;
                        bool isIdentity = reader["IsIdentity"] != DBNull.Value && (int)reader["IsIdentity"] == 1;

                        string columnDef = $"[{columnName}] {dataType}";
                        if ((dataType == "nvarchar" || dataType == "varchar") && maxLength.HasValue)
                        {
                            columnDef += maxLength > 0 ? $"({maxLength})" : "(MAX)";
                        }
                        if (isIdentity)
                        {
                            columnDef += " IDENTITY(1,1)";
                        }

                        columnDefinitions.Add(columnDef);
                    }
                }
            }
            return columnDefinitions;
        }

        private string GenerateCreateTableQuery(string tableName, List<string> columnDefinitions)
        {
            return $@"
                IF OBJECT_ID('{tableName}_ARCHIVE', 'U') IS NULL
                CREATE TABLE [{tableName}_ARCHIVE] (
                    {string.Join(", ", columnDefinitions)}
                )";
        }

        private bool TableHasIdentityColumn(string tableName, SqlConnection connection)
        {
            string query = $@"
        SELECT COUNT(*)
        FROM sys.columns
        WHERE object_id = OBJECT_ID('{tableName}')
        AND is_identity = 1;";

            using (var cmd = new SqlCommand(query, connection))
            {
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private void TransferTableDataWithoutIdentity(string tableName, SqlConnection sourceConn, SqlConnection archiveConn)
        {
            string safeTableName = $"{tableName}_ARCHIVE";
            List<string> columnDefinitions = GetColumnDefinitions(tableName, sourceConn);
            List<string> columnNames = new List<string>();

            // Check if the destination table has an identity column
            bool hasIdentity = TableHasIdentityColumn(safeTableName, archiveConn);

            foreach (var columnDef in columnDefinitions)
            {
                // Exclude the identity column from the insert if the archive table has one
                if (!(hasIdentity && columnDef.Contains("IDENTITY")))
                {
                    string columnName = columnDef.Split(' ')[0].Trim('[', ']');
                    columnNames.Add($"[{columnName}]");
                }
            }

            // Construct the insert query without the identity column
            string insertDataQuery = $@"
    INSERT INTO {safeTableName} ({string.Join(", ", columnNames)})
    SELECT {string.Join(", ", columnNames)}
    FROM {sourceConn.Database}.dbo.{tableName};";

            using (var insertCmd = new SqlCommand(insertDataQuery, archiveConn))
            {
                try
                {
                    int rowsAffected = insertCmd.ExecuteNonQuery();
                    LogProgress($"Transferred {rowsAffected} rows from '{tableName}' to archive.");
                }
                catch (Exception ex)
                {
                    LogError($"Error transferring data from '{tableName}': {ex.Message}");
                }
            }
        }


        private void LogProgress(string message)
        {
            dataGridView1.Rows.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), message);
        }

        private void LogError(string errorMessage)
        {
            dataGridView1.Rows.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), $"ERROR: {errorMessage}");
        }

        private void frmArchive_Load_1(object sender, EventArgs e)
        {
            LoadConnectionSettings();
            InitializeDataGridView();
        }

        private void btnRunbackup_Click_1(object sender, EventArgs e)
        {
            StartArchiveProcess();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnTestArcConn_Click(object sender, EventArgs e)
        {
            TestConnection();
        }



        private void TestConnection()
        {
            string connectionString = $"Data Source={txtArcServer.Text};User ID={txtArcUsername.Text};Password={txtArcPassword.Text};Initial Catalog=master";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Connection successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Connection failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void checkdiffsver_CheckedChanged(object sender, EventArgs e)
        {
            groupServer.Visible = checkdiffsver.Checked; // Set visibility based on the checkbox state
        }
    }
}
