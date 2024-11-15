using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace dBrowser
{
    public partial class frmMain : Form
    {
        private string connectionString;
        private string excelFilePath;
        private string excelFilePath2;

        public string SQLservername { get; private set; }
        public string SQLUsername { get; private set; }
        public string SQLPassword { get; private set; }
        public string SQLDatabase { get; private set; }

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadConnectionSettings();
            cmbShema.Items.Add("Table");
            cmbShema.Items.Add("View");
            cmbShema.SelectedIndexChanged += cmbShema_SelectedIndexChanged;

            cmboperator.Items.AddRange(new string[] { "=", "<", ">", "<=", ">=", "LIKE", "<>" });
        }

        private void cmbShema_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSchema = cmbShema.SelectedItem.ToString();
            cmbtableorview.Items.Clear();
            PopulateTableOrViewCombo(selectedSchema);
            cmbFilterColumn.Items.Clear();
        }

        private void cmbtableorview_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateFilterColumnCombo(cmbtableorview.SelectedItem.ToString());
        }

        private void PopulateTableOrViewCombo(string schemaType)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = schemaType == "Table"
                    ? "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'"
                    : "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.VIEWS";

                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        cmbtableorview.Items.Add(reader["TABLE_NAME"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void PopulateFilterColumnCombo(string tableName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'";

                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    cmbFilterColumn.Items.Clear();
                    while (reader.Read())
                    {
                        cmbFilterColumn.Items.Add(reader["COLUMN_NAME"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void btnViewtable1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            string DISTINCT = CheckUniqueRows.Checked ? "DISTINCT" : "";
            string NoLock = CheckBoxNoLock.Checked ? " WITH(NOLOCK)" : "";
            string numberofrows = !string.IsNullOrEmpty(txtNumberofRow.Text) && int.TryParse(txtNumberofRow.Text, out int _)
                ? " TOP " + txtNumberofRow.Text
                : "";

            try
            {
                if (cmbtableorview.SelectedItem != null)
                {
                    string selectedTable = cmbtableorview.SelectedItem.ToString();
                    string whereClause = "";

                    if (dataGridView2.Rows.Count > 1)
                    {
                        var filters = dataGridView2.Rows.Cast<DataGridViewRow>()
                            .Where(row => !row.IsNewRow && row.Cells["ColumnName"].Value != null && row.Cells["OperatorValue"].Value != null)
                            .Select(row => $"[{selectedTable}].[{row.Cells["ColumnName"].Value}] {row.Cells["OperatorValue"].Value} @param{row.Index}")
                            .ToList();

                        if (filters.Count > 0)
                        {
                            whereClause = "WHERE " + string.Join(" AND ", filters);
                        }
                    }
                    else if (!string.IsNullOrWhiteSpace(txtFiltervalue.Text) &&
                             cmbFilterColumn.SelectedItem != null &&
                             cmboperator.SelectedItem != null)
                    {
                        whereClause = $"WHERE [{selectedTable}].[{cmbFilterColumn.SelectedItem}] {cmboperator.SelectedItem} @singleParam";
                    }
                    if (!CheckFilterConfition.Checked)
                    {
                        whereClause = "";
                    }
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = $"SELECT {DISTINCT} {numberofrows} * FROM {selectedTable} {NoLock} {whereClause}";
                        rtbSQLInput.Text = query;

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            foreach (DataGridViewRow row in dataGridView2.Rows)
                            {
                                if (!row.IsNewRow && row.Cells["Values"].Value != null)
                                {
                                    command.Parameters.AddWithValue($"@param{row.Index}", row.Cells["Values"].Value.ToString());
                                }
                            }

                            if (!string.IsNullOrWhiteSpace(txtFiltervalue.Text))
                            {
                                command.Parameters.AddWithValue("@singleParam", txtFiltervalue.Text);
                            }
                            rtbSQLInput.Text = command.CommandText + Environment.NewLine +
                                               string.Join(Environment.NewLine, command.Parameters.Cast<SqlParameter>()
                                                   .Select(p => p.ParameterName + " = " + p.Value));

                            SqlDataAdapter adapter = new SqlDataAdapter(command);
                            DataSet dataSet = new DataSet();
                            adapter.Fill(dataSet);

                            lblRowcount.Text = "Number of rows: " + dataSet.Tables[0].Rows.Count;
                            FormatSQLText(rtbSQLInput);

                            if (dataSet.Tables[0].Rows.Count == 0)
                            {
                                MessageBox.Show("The query returned no results.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                dataGridView1.Columns.Clear();
                                dataGridView1.DataSource = dataSet.Tables[0];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }



        private void LoadConnectionSettings()
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "settings.xml");

            if (File.Exists(filePath))
            {
                XElement settingsXml = XElement.Load(filePath);
                SQLservername = settingsXml.Element("SQLServerName")?.Value ?? string.Empty;
                SQLDatabase = settingsXml.Element("DatabaseName")?.Value ?? string.Empty;
                SQLUsername = settingsXml.Element("UserName")?.Value ?? string.Empty;
                SQLPassword = settingsXml.Element("Password")?.Value ?? string.Empty;
                lblDatabaseName.Text =   $"Database : {SQLDatabase}";
            }
            else
            {
                MessageBox.Show("Connection settings not found. Please configure settings.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = SQLservername,
                InitialCatalog = SQLDatabase,
                UserID = SQLUsername,
                Password = SQLPassword
            };

            connectionString = builder.ConnectionString;
        }

        private void btnFilterSQL_Click(object sender, EventArgs e)
        {
            if (cmbFilterColumn.SelectedItem != null && cmboperator.SelectedItem != null && !string.IsNullOrEmpty(txtFiltervalue.Text))
            {
                dataGridView2.Rows.Add(cmbFilterColumn.SelectedItem.ToString(), cmboperator.SelectedItem.ToString(), txtFiltervalue.Text);
                txtFiltervalue.Text = "";
                cmbFilterColumn.Text = "";
                cmboperator.Text = "";
            }
            else
            {
                MessageBox.Show("Please make sure to select values and enter text before adding the filter.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveFilter_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    dataGridView2.Rows.Remove(row);
                }
            }
        }

        private void FormatSQLText(RichTextBox rtb)
        {
            string[] keywords = { "SELECT", "FROM", "DISTINCT", "WHERE", "INSERT", "UPDATE", "DELETE", "JOIN", "INNER", "LEFT", "RIGHT", "ON", "AND", "OR", "TOP", "WITH", "NOLOCK", "TABLE", "ALTER", "SET", "COLUMN" };
            int selStart = rtb.SelectionStart;
            int selLength = rtb.SelectionLength;

            rtb.SelectAll();
            rtb.SelectionColor = Color.Black;

            foreach (string keyword in keywords)
            {
                int startIndex = 0;
                while (startIndex < rtb.TextLength)
                {
                    int wordStartIndex = rtb.Find(keyword, startIndex, RichTextBoxFinds.WholeWord | RichTextBoxFinds.MatchCase);
                    if (wordStartIndex != -1)
                    {
                        rtb.Select(wordStartIndex, keyword.Length);
                        rtb.SelectionColor = Color.Blue;
                        startIndex = wordStartIndex + keyword.Length;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            rtb.Select(selStart, selLength);
            rtb.SelectionColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = rtbSQLInput.Text;
                    rtbSQLInput.Text = query;
                    FormatSQLText(rtbSQLInput);

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);

                        if (dataSet.Tables[0].Rows.Count == 0)
                        {
                            MessageBox.Show("The query returned no results.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            dataGridView1.DataSource = dataSet.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rtbSQLInput_TextChanged(object sender, EventArgs e)
        {
            FormatSQLText(rtbSQLInput);
        }

        private void Cmbtableorview_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            PopulateFilterColumnCombo(cmbtableorview.SelectedItem.ToString());
        }

        private void btnCreatletable_Click(object sender, EventArgs e)
        {

            cmbSELECTsheet.Visible = true;
            cmbSELECTsheet.Text = "";
            txtSQLtablename.Text = "";
            lblSELECTWORKSHEET.Visible = true;

            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Filter = "Excel Files|*.xlsx;*.xls",
                Title = "Select an Excel File"
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK && File.Exists(openFileDialog1.FileName))
            {
                Microsoft.Office.Interop.Excel.Application xlApp = null;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook = null;

                try
                {
                    xlApp = new Microsoft.Office.Interop.Excel.Application();
                    xlWorkBook = xlApp.Workbooks.Open(openFileDialog1.FileName);
                    cmbSELECTsheet.Items.Clear();

                    foreach (Microsoft.Office.Interop.Excel.Worksheet xlSheet in xlWorkBook.Sheets)
                    {
                        cmbSELECTsheet.Items.Add(xlSheet.Name);
                    }

                    excelFilePath = openFileDialog1.FileName;
                    excelFilePath2 = openFileDialog1.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    xlWorkBook?.Close();
                    xlApp?.Quit();
                    ReleaseObject(xlApp);
                }
            }
            else
            {

                MessageBox.Show("An error occurred: " + "The selected file was not found. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            btnImport.Visible = true;
            btnDataType.Visible = true;
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            try
            {
                if (string.IsNullOrWhiteSpace(txtSQLtablename.Text))
                {


                    MessageBox.Show("An error occurred: " + "Please Enter Table name before import", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cmbSELECTsheet.SelectedItem == null || string.IsNullOrWhiteSpace(cmbSELECTsheet.SelectedItem.ToString()))
                {
                    MessageBox.Show("Please select a sheet before importing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string selectedSheet = cmbSELECTsheet.SelectedItem.ToString();
                string excelConnectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={excelFilePath};Extended Properties='Excel 12.0 Xml;HDR=YES;'";

                using (var excelConnection = new System.Data.OleDb.OleDbConnection(excelConnectionString))
                {
                    excelConnection.Open();
                    DataTable dt = new DataTable();
                    string query = $"SELECT * FROM [{selectedSheet}$]";

                    using (var adapter = new System.Data.OleDb.OleDbDataAdapter(query, excelConnection))
                    {
                        adapter.FillSchema(dt, SchemaType.Source);
                    }

                    dataGridView1.Columns.Add("ColumnName", "Column Name");
                    var comboBoxColumn = new DataGridViewComboBoxColumn
                    {
                        HeaderText = "Data Type",
                        Name = "DataTypeColumn"
                    };
                    comboBoxColumn.Items.AddRange("NVARCHAR(MAX)", "INT", "FLOAT", "BIT", "DATETIME2", "DECIMAL(18,6)", "CHAR(10)", "VARCHAR(255)", "SMALLINT", "BIGINT", "DATE", "TIME");
                    dataGridView1.Columns.Add(comboBoxColumn);

                    foreach (DataColumn column in dt.Columns)
                    {
                        dataGridView1.Rows.Add(column.ColumnName);
                    }
                }

                btnImport.Visible = false;
                txtSQLtablename.Visible = false;

                lblSELECTWORKSHEET.Visible = false;
                cmbSELECTsheet.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbSELECTsheet_SelectedIndexChanged(object sender, EventArgs e)
        {

            btnImport.Visible = true;
            txtSQLtablename.Visible = true;

            lblSELECTWORKSHEET.Visible = true;
            cmbSELECTsheet.Visible = true;
        }

        private void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private void btnImport_Click_1(object sender, EventArgs e)
        {
            btnImport.Visible = true;
            btnDataType.Visible = true;
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            try
            {
                if (string.IsNullOrWhiteSpace(txtSQLtablename.Text))
                {


                    MessageBox.Show("An error occurred: " + "Please Enter Table name before import", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cmbSELECTsheet.SelectedItem == null || string.IsNullOrWhiteSpace(cmbSELECTsheet.SelectedItem.ToString()))
                {
                    MessageBox.Show("Please select a sheet before importing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string selectedSheet = cmbSELECTsheet.SelectedItem.ToString();
                string excelConnectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={excelFilePath};Extended Properties='Excel 12.0 Xml;HDR=YES;'";

                using (var excelConnection = new System.Data.OleDb.OleDbConnection(excelConnectionString))
                {
                    excelConnection.Open();
                    DataTable dt = new DataTable();
                    string query = $"SELECT * FROM [{selectedSheet}$]";

                    using (var adapter = new System.Data.OleDb.OleDbDataAdapter(query, excelConnection))
                    {
                        adapter.FillSchema(dt, SchemaType.Source);
                    }

                    dataGridView1.Columns.Add("ColumnName", "Column Name");
                    var comboBoxColumn = new DataGridViewComboBoxColumn
                    {
                        HeaderText = "Data Type",
                        Name = "DataTypeColumn"
                    };
                    comboBoxColumn.Items.AddRange("NVARCHAR(MAX)", "INT", "FLOAT", "BIT", "DATETIME2", "DECIMAL(18,6)", "CHAR(10)", "VARCHAR(255)", "SMALLINT", "BIGINT", "DATE", "TIME");
                    dataGridView1.Columns.Add(comboBoxColumn);

                    foreach (DataColumn column in dt.Columns)
                    {
                        dataGridView1.Rows.Add(column.ColumnName);
                    }
                }

                btnImport.Visible = false;
                txtSQLtablename.Visible = false;

                lblSELECTWORKSHEET.Visible = false;
                cmbSELECTsheet.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDataType_Click(object sender, EventArgs e)
        {
            string tablename = txtSQLtablename.Text;

            if (cmbSELECTsheet.SelectedItem == null || string.IsNullOrWhiteSpace(txtSQLtablename.Text))
            {
                MessageBox.Show("Please select a sheet and specify a SQL table name before importing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(excelFilePath))
            {
                MessageBox.Show("Please select an Excel file first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string excelConnectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={excelFilePath};Extended Properties='Excel 12.0 Xml;HDR=YES;'";
            string selectedSheet = cmbSELECTsheet.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedSheet))
            {
                MessageBox.Show("Please select a sheet before importing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            progressBar1.Visible = true;
            progressBar1.Minimum = 0;

            DataTable dt = new DataTable();
            using (var excelConnection = new System.Data.OleDb.OleDbConnection(excelConnectionString))
            {
                excelConnection.Open();
                string query = $"SELECT * FROM [{selectedSheet}$]";
                using (var adapter = new System.Data.OleDb.OleDbDataAdapter(query, excelConnection))
                {
                    adapter.Fill(dt);

                    if (dt == null || dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No data found in the selected sheet.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        progressBar1.Visible = false;
                        return;
                    }

                    progressBar1.Maximum = dt.Rows.Count;
                }
            }

            var createTableQuery = new System.Text.StringBuilder($"CREATE TABLE [{tablename}] (");
            int columnsAdded = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow && row.Cells.Count >= 2)
                {
                    string columnName = row.Cells[0].Value?.ToString();
                    string dataType = row.Cells[1].Value?.ToString();

                    if (!string.IsNullOrWhiteSpace(columnName))
                    {
                        if (string.IsNullOrWhiteSpace(dataType))
                        {
                            dataType = "nvarchar(max)";
                        }

                        createTableQuery.Append($" [{columnName.Replace(" ", "_")}] {dataType},");
                        columnsAdded++;
                    }
                }
            }

            if (columnsAdded > 0)
            {
                createTableQuery.Remove(createTableQuery.Length - 1, 1); 
            }

            createTableQuery.Append(")");
            rtbSQLInput.Text = createTableQuery.ToString();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    using (SqlTransaction transaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand createTableCommand = new SqlCommand(createTableQuery.ToString(), sqlConnection, transaction))
                        {
                            createTableCommand.ExecuteNonQuery();
                        }

                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlConnection, SqlBulkCopyOptions.Default, transaction))
                        {
                            bulkCopy.DestinationTableName = tablename;
                            bulkCopy.SqlRowsCopied += (senderObj, eventArgs) =>
                            {
                                progressBar1.Value = (int)eventArgs.RowsCopied;
                            };
                            bulkCopy.WriteToServer(dt);
                        }

                        transaction.Commit();
                        MessageBox.Show($"Data imported successfully. Table name: [{tablename}].", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Error executing database operations: " + sqlEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                progressBar1.Visible = false;
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
            }
        }


        private void btnExportData_Click_1(object sender, EventArgs e)
        {
            string[] fileFormats = {
        "CSV (Comma-Separated Values)",
        "Excel File (XLS/XLSX)",
        "Text File (TXT)",
        "XML (Extensible Markup Language)",
        "JSON (JavaScript Object Notation)",
        "PDF (Portable Document Format)",
        "HTML (HyperText Markup Language)"
    };

            comboBoxFileFormats.Items.AddRange(fileFormats);
            cmbSELECTsheet.Visible = false;

        }

        // ExportDataToPdf(dataGridView1, progressBar1);
        private void ExportDataToPdf(DataGridView dataGridView, ProgressBar progressBar)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Files (*.pdf)|*.pdf|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            progressBar.Visible = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        var pdfWriter = new iText.Kernel.Pdf.PdfWriter(stream);
                        var pdfDocument = new iText.Kernel.Pdf.PdfDocument(pdfWriter);
                        var document = new iText.Layout.Document(pdfDocument);

                        var table = new iText.Layout.Element.Table(dataGridView.Columns.Count);

                        foreach (DataGridViewColumn column in dataGridView.Columns)
                        {
                            table.AddHeaderCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(column.HeaderText)));
                        }

                        progressBar.Maximum = dataGridView.Rows.Count;

                        for (int row = 0; row < dataGridView.Rows.Count; row++)
                        {
                            progressBar.Value = row + 1;

                            for (int col = 0; col < dataGridView.Columns.Count; col++)
                            {
                                string cellValue = dataGridView.Rows[row].Cells[col].Value?.ToString() ?? "";
                                table.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(cellValue)));
                            }
                        }

                        document.Add(table);
                        document.Close();
                    }

                    MessageBox.Show("Data exported successfully to PDF.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error exporting data to PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    progressBar.Visible = false;
                }
            }
        }

        //  ExportDataToJson(dataGridView1, progressBar1);
        private void ExportDataToJson(DataGridView dataGridView, ProgressBar progressBar)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "JSON Files (*.json)|*.json|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            progressBar.Visible = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var rows = new List<Dictionary<string, object>>();

                    progressBar.Maximum = dataGridView.Rows.Count;

                    for (int row = 0; row < dataGridView.Rows.Count; row++)
                    {
                        progressBar.Value = row + 1;

                        var rowData = new Dictionary<string, object>();
                        for (int col = 0; col < dataGridView.Columns.Count; col++)
                        {
                            string columnName = dataGridView.Columns[col].HeaderText;
                            object value = dataGridView.Rows[row].Cells[col].Value ?? "";
                            rowData[columnName] = value;
                        }
                        rows.Add(rowData);
                    }

                    string json = System.Text.Json.JsonSerializer.Serialize(rows, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(saveFileDialog.FileName, json);

                    MessageBox.Show("Data exported successfully to JSON.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error exporting data to JSON: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    progressBar.Visible = false;
                }
            }
        }


        // ExportDataToXml(dataGridView1, progressBar1);
        private void ExportDataToXml(DataGridView dataGridView, ProgressBar progressBar)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "XML Files (*.xml)|*.xml|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            progressBar.Visible = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (XmlWriter writer = XmlWriter.Create(saveFileDialog.FileName, new XmlWriterSettings { Indent = true }))
                    {
                        writer.WriteStartDocument();
                        writer.WriteStartElement("Rows");

                        progressBar.Maximum = dataGridView.Rows.Count;

                        for (int row = 0; row < dataGridView.Rows.Count; row++)
                        {
                            progressBar.Value = row + 1;

                            writer.WriteStartElement("Row");

                            for (int col = 0; col < dataGridView.Columns.Count; col++)
                            {
                                string columnName = dataGridView.Columns[col].HeaderText;
                                string value = dataGridView.Rows[row].Cells[col].Value?.ToString() ?? "";

                                writer.WriteElementString(columnName, value); 
                            }

                            writer.WriteEndElement();
                        }

                        writer.WriteEndElement(); 
                        writer.WriteEndDocument();
                    }

                    MessageBox.Show("Data exported successfully to XML.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error exporting data to XML: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    progressBar.Visible = false;
                }
            }
        }


        //  ExportDataToTxt(dataGridView1, progressBar1, "\t");
        private void ExportDataToTxt(DataGridView dataGridView, ProgressBar progressBar, string delimiter = "\t")
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            progressBar.Visible = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        for (int col = 0; col < dataGridView.Columns.Count; col++)
                        {
                            writer.Write(dataGridView.Columns[col].HeaderText);
                            if (col < dataGridView.Columns.Count - 1)
                                writer.Write(delimiter); 
                        }
                        writer.WriteLine(); 

                        progressBar.Maximum = dataGridView.Rows.Count;

                        for (int row = 0; row < dataGridView.Rows.Count; row++)
                        {
                            progressBar.Value = row + 1;

                            for (int col = 0; col < dataGridView.Columns.Count; col++)
                            {
                                var value = dataGridView.Rows[row].Cells[col].Value?.ToString() ?? "";
                                writer.Write(value);

                                if (col < dataGridView.Columns.Count - 1)
                                    writer.Write(delimiter); 
                            }
                            writer.WriteLine();
                        }

                        MessageBox.Show("Data exported successfully to Text File.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error exporting data to Text File: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    progressBar.Visible = false;
                }
            }
        }

        private void ExportDataToCsv(DataGridView dataGridView, ProgressBar progressBar)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            progressBar.Visible = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {

                        for (int col = 0; col < dataGridView.Columns.Count; col++)
                        {
                            writer.Write(dataGridView.Columns[col].HeaderText);
                            if (col < dataGridView.Columns.Count - 1)
                                writer.Write(","); 
                        }
                        writer.WriteLine(); 

                        progressBar.Maximum = dataGridView.Rows.Count;

                        for (int row = 0; row < dataGridView.Rows.Count; row++)
                        {
                            progressBar.Value = row + 1;

                            for (int col = 0; col < dataGridView.Columns.Count; col++)
                            {
                                var value = dataGridView.Rows[row].Cells[col].Value?.ToString() ?? "";
                                writer.Write(value);

                                if (col < dataGridView.Columns.Count - 1)
                                    writer.Write(","); 
                            }
                            writer.WriteLine();
                        }

                        MessageBox.Show("Data exported successfully to CSV.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error exporting data to CSV: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    progressBar.Visible = false;
                }
            }
        }

        private void ExportDataToExcel(DataGridView dataGridView, ProgressBar progressBar)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            progressBar.Visible = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var package = new OfficeOpenXml.ExcelPackage())
                    {
                        var worksheet = package.Workbook.Worksheets.Add("ExportedData");

                        for (int col = 0; col < dataGridView.Columns.Count; col++)
                        {
                            worksheet.Cells[1, col + 1].Value = dataGridView.Columns[col].HeaderText;
                        }

                        progressBar.Maximum = dataGridView.Rows.Count;

                        for (int row = 0; row < dataGridView.Rows.Count; row++)
                        {
                            progressBar.Value = row + 1;

                            for (int col = 0; col < dataGridView.Columns.Count; col++)
                            {
                                worksheet.Cells[row + 2, col + 1].Value = dataGridView.Rows[row].Cells[col].Value?.ToString() ?? "";
                            }
                        }

                        FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
                        package.SaveAs(fileInfo);
                        MessageBox.Show("Data exported successfully to Excel.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error exporting data to Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    progressBar.Visible = false;
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }


        private void btnExistingTable_Click(object sender, EventArgs e)
        {
            ComboImportTotables.Visible = true;
            string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ComboImportTotables.Items.Clear();

                        while (reader.Read())
                        {
                            ComboImportTotables.Items.Add(reader["TABLE_NAME"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void btnMapColumns_Click(object sender, EventArgs e)
        {
            ComboSQLTabelColumn.Visible = true;
            comboExcelColumns.Visible = true;
            dataGridView3.Visible = true;

            dataGridView3.Rows.Clear();
            comboExcelColumns.Items.Clear();
            ComboSQLTabelColumn.Items.Clear();

            PopulateSQLColumns();
            PopulateExcelColumns();
        }

        private void PopulateSQLColumns()
        {
            if (ComboImportTotables.SelectedItem == null)
            {
                MessageBox.Show("Please select a table.");
                return;
            }

            string tableName = ComboImportTotables.SelectedItem.ToString();
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                string query = $"SELECT COLUMN_NAME, COLUMNPROPERTY(OBJECT_ID('{tableName}'), COLUMN_NAME, 'IsIdentity') AS IsIdentity FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ComboSQLTabelColumn.Items.Clear();
                        while (reader.Read())
                        {
                            int isIdentity = reader.GetInt32(reader.GetOrdinal("IsIdentity"));
                            if (isIdentity == 0)
                            {
                                ComboSQLTabelColumn.Items.Add(reader["COLUMN_NAME"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while fetching SQL columns: " + ex.Message);
                }
            }

            ComboImportTotables.Sorted = true;
        }

        private void PopulateExcelColumns()
        {
            if (string.IsNullOrEmpty(excelFilePath2) || cmbSELECTsheet.SelectedItem == null)
            {
                MessageBox.Show("Excel file path or selected sheet is not defined.");
                return;
            }

            string selectedSheet = cmbSELECTsheet.SelectedItem.ToString();
            string excelConnectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={excelFilePath2};Extended Properties='Excel 12.0 Xml;HDR=YES;'";

            using (OleDbConnection excelConnection = new OleDbConnection(excelConnectionString))
            {
                try
                {
                    excelConnection.Open();
                    DataTable dt = new DataTable();
                    string query = $"SELECT * FROM [{selectedSheet}$]";

                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, excelConnection))
                    {
                        adapter.FillSchema(dt, SchemaType.Source);
                    }

                    comboExcelColumns.Items.Clear();
                    foreach (DataColumn column in dt.Columns)
                    {
                        comboExcelColumns.Items.Add(column.ColumnName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while fetching Excel columns: " + ex.Message);
                }
            }
        }

        private void btnImportExistingTable_Click(object sender, EventArgs e)
        {
            InsertDataFromExcelToSQL();
        }

        private void AddSelectedItemToDataGridViewAndRemoveFromComboBox()
        {
            if (comboExcelColumns.SelectedItem == null || ComboSQLTabelColumn.SelectedItem == null)
            {
                MessageBox.Show("Please select an item from both combo boxes.");
                return;
            }

            string selectedExcelItem = comboExcelColumns.SelectedItem.ToString();
            string selectedSQLItem = ComboSQLTabelColumn.SelectedItem.ToString();
            dataGridView3.Rows.Add(selectedExcelItem, selectedSQLItem);
            comboExcelColumns.Items.Remove(selectedExcelItem);
            ComboSQLTabelColumn.Items.Remove(selectedSQLItem);
        }



        private void InsertDataFromExcelToSQL()
        {
            if (cmbSELECTsheet.SelectedItem == null || ComboImportTotables.SelectedItem == null)
            {
                MessageBox.Show("Please select both an Excel sheet and an SQL table.");
                return;
            }

            string selectedSheet = cmbSELECTsheet.SelectedItem.ToString();
            string excelConnectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={excelFilePath2};Extended Properties='Excel 12.0 Xml;HDR=YES;'";
            string tableName = ComboImportTotables.SelectedItem.ToString();

            using (OleDbConnection excelConnection = new OleDbConnection(excelConnectionString))
            {
                try
                {
                    excelConnection.Open();

                    List<string> sqlColumns = new List<string>();
                    List<string> excelColumns = new List<string>();

                    foreach (DataGridViewRow row in dataGridView3.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            string excelColumn = row.Cells[0].Value?.ToString() ?? string.Empty;
                            string sqlColumn = row.Cells[1].Value?.ToString() ?? string.Empty;

                            if (!string.IsNullOrEmpty(excelColumn) && !string.IsNullOrEmpty(sqlColumn))
                            {
                                excelColumns.Add($"[{excelColumn}]");
                                sqlColumns.Add($"[{sqlColumn}]");
                            }
                        }
                    }

                    if (excelColumns.Count == 0 || sqlColumns.Count == 0)
                    {
                        throw new Exception("No columns specified for import.");
                    }

                    string selectQuery = $"SELECT {string.Join(",", excelColumns)} FROM [{selectedSheet}$]";
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(selectQuery, excelConnection))
                    {
                        DataTable excelTable = new DataTable();
                        adapter.Fill(excelTable);

                        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                        {
                            sqlConnection.Open();

                            foreach (DataRow excelRow in excelTable.Rows)
                            {
                                List<string> values = new List<string>();

                                foreach (string excelColumn in excelColumns)
                                {
                                    string cleanColumn = excelColumn.Trim('[', ']');
                                    values.Add($"'{excelRow[cleanColumn].ToString().Replace("'", "''")}'");
                                }

                                string insertQuery = $"INSERT INTO [{tableName}] ({string.Join(",", sqlColumns)}) VALUES ({string.Join(",", values)})";

                                using (SqlCommand command = new SqlCommand(insertQuery, sqlConnection))
                                {
                                    command.ExecuteNonQuery();
                                }
                            }

                            MessageBox.Show("Data imported successfully!");
                        }
                    }
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show($"Excel connection or query error: {ex.Message}");
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show($"SQL Server connection or query error: {sqlEx.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred during data import: " + ex.Message);
                }
            }
        }


        private void btnAddSelectedItemToImport_Click(object sender, EventArgs e)
        {
            AddSelectedItemToDataGridViewAndRemoveFromComboBox();
        }

        private void btnSuggestColumns_Click(object sender, EventArgs e)
        {
            List<string> excelItemsToRemove = new List<string>();
            List<string> sqlItemsToRemove = new List<string>();
            List<string> unmatchedExcelItems = new List<string>();

            foreach (string excelItem in comboExcelColumns.Items)
            {
                if (!string.IsNullOrEmpty(excelItem) && ComboSQLTabelColumn.Items.Contains(excelItem))
                {
                    dataGridView3.Rows.Add(excelItem, excelItem);
                    excelItemsToRemove.Add(excelItem);
                    sqlItemsToRemove.Add(excelItem);
                }
                else
                {
                    unmatchedExcelItems.Add(excelItem);
                }
            }

            foreach (string item in excelItemsToRemove)
            {
                comboExcelColumns.Items.Remove(item);
            }
            foreach (string item in sqlItemsToRemove)
            {
                ComboSQLTabelColumn.Items.Remove(item);
            }

            foreach (string excelItem in unmatchedExcelItems)
            {
                string matchedSqlItem = excelItem.Replace(" ", "_");
                if (ComboSQLTabelColumn.Items.Contains(matchedSqlItem))
                {
                    dataGridView3.Rows.Add(excelItem, matchedSqlItem);
                    comboExcelColumns.Items.Remove(excelItem);
                    ComboSQLTabelColumn.Items.Remove(matchedSqlItem);
                }
            }

            comboExcelColumns.Refresh();
            ComboSQLTabelColumn.Refresh();
        }

        private void btnImportdata_Click(object sender, EventArgs e)
        {
            InsertDataFromExcelToSQL();
        }

        private void comboExcelColumns_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnRemovefromGrid3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView3.SelectedRows)
            {
                if (!row.IsNewRow && row.Cells.Count >= 2)
                {
                    string excelItem = row.Cells[0].Value?.ToString() ?? string.Empty;
                    string sqlItem = row.Cells[1].Value?.ToString() ?? string.Empty;

                    comboExcelColumns.Items.Add(excelItem);
                    ComboSQLTabelColumn.Items.Add(sqlItem);
                }
            }

            if (dataGridView3.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView3.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        dataGridView3.Rows.Remove(row);
                    }
                }
            }
        }


        private void ExportDataBasedOnSelectedFormat(DataGridView dataGridView, ProgressBar progressBar, ComboBox comboBox)
        {
            string[] fileFormats = {
        "CSV (Comma-Separated Values)",
        "Excel File (XLS/XLSX)",
        "Text File (TXT)",
        "XML (Extensible Markup Language)",
        "JSON (JavaScript Object Notation)",
        "PDF (Portable Document Format)",
        "HTML (HyperText Markup Language)"
    };

            if (comboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a file format to export.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedFormat = comboBox.SelectedItem.ToString();

            switch (selectedFormat)
            {
                case "CSV (Comma-Separated Values)":
                    ExportDataToCsv(dataGridView, progressBar);
                    break;

                case "Excel File (XLS/XLSX)":
                    ExportDataToExcel(dataGridView, progressBar);
                    break;

                case "Text File (TXT)":
                    ExportDataToTxt(dataGridView, progressBar);
                    break;

                case "XML (Extensible Markup Language)":
                    ExportDataToXml(dataGridView, progressBar);
                    break;

                case "JSON (JavaScript Object Notation)":
                    ExportDataToJson(dataGridView, progressBar);
                    break;

                case "PDF (Portable Document Format)":
                    ExportDataToPdf(dataGridView, progressBar);
                    break;

                case "HTML (HyperText Markup Language)":
                    ExportDataToHtml(dataGridView, progressBar);
                    break;

                default:
                    MessageBox.Show("Unsupported file format selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }


        private void ExportDataToHtml(DataGridView dataGridView, ProgressBar progressBar)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "HTML Files (*.html)|*.html|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            progressBar.Visible = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        writer.WriteLine("<html>");
                        writer.WriteLine("<body>");
                        writer.WriteLine("<table border='1'>");

                        // Write column headers
                        writer.WriteLine("<tr>");
                        foreach (DataGridViewColumn column in dataGridView.Columns)
                        {
                            writer.WriteLine($"<th>{column.HeaderText}</th>");
                        }
                        writer.WriteLine("</tr>");

                        // Write rows
                        progressBar.Maximum = dataGridView.Rows.Count;

                        for (int row = 0; row < dataGridView.Rows.Count; row++)
                        {
                            progressBar.Value = row + 1;

                            writer.WriteLine("<tr>");
                            foreach (DataGridViewCell cell in dataGridView.Rows[row].Cells)
                            {
                                writer.WriteLine($"<td>{cell.Value?.ToString() ?? ""}</td>");
                            }
                            writer.WriteLine("</tr>");
                        }

                        writer.WriteLine("</table>");
                        writer.WriteLine("</body>");
                        writer.WriteLine("</html>");
                    }

                    MessageBox.Show("Data exported successfully to HTML.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error exporting data to HTML: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    progressBar.Visible = false;
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ExportDataBasedOnSelectedFormat(dataGridView1, progressBar1, comboBoxFileFormats);
        }
    }
}

