using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace dBrowser
{
    public partial class frmDatabaseSettings : Form
    {
        public frmDatabaseSettings()
        {
            InitializeComponent();
            this.FormClosing += frmDatabaseSettings_FormClosing;
        }

        private void frmDatabaseSettings_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void SaveSettings()
        {
            string companyName = textBoxCompanyName.Text;
            string sqlServerName = textBoxSQLServerName.Text;
            string userName = textBoxUserName.Text;
            string password = textBoxPassword.Text;
            string databaseName = ComboDatabaseName.Text;
            bool connectionPoolingEnabled = checkBoxConnectionPooling.Checked;
            int maxPoolSize = (int)numericMaxPoolSize.Value;
            string passkey = txtpasskey.Text;

            XElement settingsXml = new XElement("Settings",
                new XElement("CompanyName", companyName),
                new XElement("SQLServerName", sqlServerName),
                new XElement("UserName", userName),
                new XElement("Password", password),
                new XElement("DatabaseName", databaseName),
                new XElement("ConnectionPoolingEnabled", connectionPoolingEnabled),
                new XElement("MaxPoolSize", maxPoolSize),
                new XElement("Passkey", passkey)
            );

            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "settings.xml");

            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath) ?? string.Empty);
                settingsXml.Save(filePath);
                MessageBox.Show("Settings saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Restart the application
                DialogResult result = MessageBox.Show("Settings have been saved. The application will now restart.", "Restart Application", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    Application.Restart();
                    Environment.Exit(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving settings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSettings()
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "settings.xml");

            if (File.Exists(filePath))
            {
                XElement settingsXml = XElement.Load(filePath);
                textBoxCompanyName.Text = settingsXml.Element("CompanyName")?.Value ?? string.Empty;
                textBoxSQLServerName.Text = settingsXml.Element("SQLServerName")?.Value ?? string.Empty;
                textBoxUserName.Text = settingsXml.Element("UserName")?.Value ?? string.Empty;
                textBoxPassword.Text = settingsXml.Element("Password")?.Value ?? string.Empty;
                ComboDatabaseName.Text = settingsXml.Element("DatabaseName")?.Value ?? string.Empty;
                checkBoxConnectionPooling.Checked = bool.TryParse(settingsXml.Element("ConnectionPoolingEnabled")?.Value, out bool pooling) && pooling;
                numericMaxPoolSize.Value = int.TryParse(settingsXml.Element("MaxPoolSize")?.Value, out int maxPool) ? maxPool : numericMaxPoolSize.Minimum;
                txtpasskey.Text = settingsXml.Element("Passkey")?.Value ?? string.Empty;
            }
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            TestConnection();
        }

        private void TestConnection()
        {
            string connectionString = $"Data Source={textBoxSQLServerName.Text};User ID={textBoxUserName.Text};Password={textBoxPassword.Text};Initial Catalog=master";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Connection successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SqlCommand command = new SqlCommand("SELECT name FROM sys.databases WHERE name NOT IN ('master', 'tempdb', 'model', 'msdb');", connection);
                    SqlDataReader reader = command.ExecuteReader();

                    ComboDatabaseName.Items.Clear();
                    while (reader.Read())
                    {
                        ComboDatabaseName.Items.Add(reader["name"].ToString());
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Connection failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            frmArchive archive = new frmArchive();
            archive.Show();
        }

        private void frmDatabaseSettings_Load_1(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void btnTestconnection_Click_1(object sender, EventArgs e)
        {
            TestConnection();
        }

        private void btnArchieve_Click(object sender, EventArgs e)
        {
            frmArchive archive = new frmArchive();
            archive.Show();
        }

        private void frmDatabaseSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); 
        }
    }
}
