using System;
using System.Data.SqlClient;
using System.IO;
using System.ServiceProcess;
using System.Windows.Forms;
using System.Xml.Linq;

namespace dBrowser
{
    public partial class frmLogIn : Form
    {
        private string SQLservername;
        private string SQLDatabase;
        private string SQLUsername;
        private string SQLPassword;
        private string SQLCompany;
        public frmLogIn()
        {
            InitializeComponent();
            LoadConnectionSettings();
            this.AcceptButton = button1;
        }

        private void btnCloseApplication_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
            frmpasskey passkeyForm = new frmpasskey();
            passkeyForm.Show();
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
                SQLCompany = settingsXml.Element("CompanyName")?.Value ?? string.Empty;

                txtusername.Text = SQLUsername;
                txtpassword.Text = SQLPassword;
                lblCompany.Text = SQLCompany;

            }
            else
            {
                MessageBox.Show("Connection settings not found. Please configure settings.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text;
            string password = txtpassword.Text;

            if (AuthenticateUser(username, password))
            {
                this.Visible = false;
                frmMain page1 = new frmMain();
                page1.Show();
                ;
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = SQLservername,
                InitialCatalog = SQLDatabase,
                UserID = SQLUsername,
                Password = SQLPassword
            };

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                if (username == SQLUsername && password == SQLPassword)
                {
                    return true; // Grant access
                }
                using (SqlCommand command = new SqlCommand("SELECT Active FROM Users WHERE LogInName = @Username", connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result == null || result == DBNull.Value)
                        {
                            MessageBox.Show("Invalid username.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                        bool isActive = Convert.ToInt32(result) == 1;

                        if (!isActive)
                        {
                            MessageBox.Show("Your account is deactivated. Please contact the administrator.", "Account Deactivated", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }


        public void CheckAndStartSQLServices()
        {
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("ServiceName", "Service Name");
                dataGridView1.Columns.Add("StatusMessage", "Status Message");
            }

            string[] sqlServices = { "MSSQLSERVER", "SQLSERVERAGENT" }; // Add more service names if needed

            dataGridView1.Rows.Clear();

            foreach (string serviceName in sqlServices)
            {
                try
                {
                    ServiceController service = new ServiceController(serviceName);
                    string statusMessage = $"Service: {serviceName} - Status: {service.Status}";

                    if (service.Status != ServiceControllerStatus.Running)
                    {
                        try
                        {
                            service.Start();
                            service.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(10));
                            statusMessage = $"Service: {serviceName} - Status: Started Successfully";
                        }
                        catch (Exception startEx)
                        {
                            statusMessage = $"Service: {serviceName} - Failed to Start. Error: {startEx.Message}";
                        }
                    }
                    else
                    {
                        statusMessage = $"Service: {serviceName} - Already Running";
                    }

                    dataGridView1.Rows.Add(serviceName, statusMessage);
                }
                catch (Exception ex)
                {
                    dataGridView1.Rows.Add(serviceName, $"Error: {ex.Message}");
                }
            }
        }


        private void frmLogIn_Load(object sender, EventArgs e)
        {
            CheckAndStartSQLServices();
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick(); 
                e.Handled = true;
                e.SuppressKeyPress = true; 
            }
        }
    }
}
