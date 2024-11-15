using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace dBrowser
{
    public partial class frmpasskey : Form
    {
        public frmpasskey()
        {
            InitializeComponent();
            this.AcceptButton = btnpasskey;
        }

        private void btnpasskey_Click(object sender, EventArgs e)
        {
            
            string passkey = "";
            string databasepassword = "";
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "settings.xml");

            if (File.Exists(filePath))
            {
                XElement settingsXml = XElement.Load(filePath);
                passkey = settingsXml.Element("Passkey")?.Value ?? string.Empty;
                databasepassword = settingsXml.Element("Password")?.Value ?? string.Empty; 
            }

            if (txtpasskey.Text == passkey || txtpasskey.Text == databasepassword)
            {
                this.Visible = false;
                frmDatabaseSettings formDatabaseSettings = new frmDatabaseSettings();
                formDatabaseSettings.Show();
            }
            else
            {
                MessageBox.Show("Invalid passkey. Please try again.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtpasskey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnpasskey.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
