using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace dBrowser
{
    public partial class frmDatabaseSettings : Form
    {
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDatabaseSettings));
            this.labelCompanyName = new System.Windows.Forms.Label();
            this.textBoxCompanyName = new System.Windows.Forms.TextBox();
            this.labelSQLServerName = new System.Windows.Forms.Label();
            this.textBoxSQLServerName = new System.Windows.Forms.TextBox();
            this.labelUserName = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelDatabaseName = new System.Windows.Forms.Label();
            this.checkBoxConnectionPooling = new System.Windows.Forms.CheckBox();
            this.numericMaxPoolSize = new System.Windows.Forms.NumericUpDown();
            this.numericMinPoolSize = new System.Windows.Forms.NumericUpDown();
            this.numericConnectionTimeout = new System.Windows.Forms.NumericUpDown();
            this.buttonSave = new System.Windows.Forms.Button();
            this.ComboDatabaseName = new System.Windows.Forms.ComboBox();
            this.btnTestconnection = new System.Windows.Forms.Button();
            this.txtpasskey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnArchieve = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxPoolSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinPoolSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericConnectionTimeout)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelCompanyName
            // 
            this.labelCompanyName.Location = new System.Drawing.Point(336, 60);
            this.labelCompanyName.Name = "labelCompanyName";
            this.labelCompanyName.Size = new System.Drawing.Size(100, 23);
            this.labelCompanyName.TabIndex = 0;
            this.labelCompanyName.Text = "Company Name";
            // 
            // textBoxCompanyName
            // 
            this.textBoxCompanyName.Location = new System.Drawing.Point(486, 60);
            this.textBoxCompanyName.Name = "textBoxCompanyName";
            this.textBoxCompanyName.Size = new System.Drawing.Size(250, 30);
            this.textBoxCompanyName.TabIndex = 1;
            // 
            // labelSQLServerName
            // 
            this.labelSQLServerName.Location = new System.Drawing.Point(336, 110);
            this.labelSQLServerName.Name = "labelSQLServerName";
            this.labelSQLServerName.Size = new System.Drawing.Size(100, 23);
            this.labelSQLServerName.TabIndex = 2;
            this.labelSQLServerName.Text = "SQL Server Name";
            // 
            // textBoxSQLServerName
            // 
            this.textBoxSQLServerName.Location = new System.Drawing.Point(486, 110);
            this.textBoxSQLServerName.Name = "textBoxSQLServerName";
            this.textBoxSQLServerName.Size = new System.Drawing.Size(250, 30);
            this.textBoxSQLServerName.TabIndex = 3;
            // 
            // labelUserName
            // 
            this.labelUserName.Location = new System.Drawing.Point(336, 160);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(100, 23);
            this.labelUserName.TabIndex = 4;
            this.labelUserName.Text = "User Name";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(486, 160);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(250, 30);
            this.textBoxUserName.TabIndex = 5;
            // 
            // labelPassword
            // 
            this.labelPassword.Location = new System.Drawing.Point(336, 210);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(100, 23);
            this.labelPassword.TabIndex = 6;
            this.labelPassword.Text = "Password";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(486, 210);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '•';
            this.textBoxPassword.Size = new System.Drawing.Size(250, 30);
            this.textBoxPassword.TabIndex = 7;
            // 
            // labelDatabaseName
            // 
            this.labelDatabaseName.Location = new System.Drawing.Point(336, 288);
            this.labelDatabaseName.Name = "labelDatabaseName";
            this.labelDatabaseName.Size = new System.Drawing.Size(100, 23);
            this.labelDatabaseName.TabIndex = 8;
            this.labelDatabaseName.Text = "Database Name";
            // 
            // checkBoxConnectionPooling
            // 
            this.checkBoxConnectionPooling.Checked = true;
            this.checkBoxConnectionPooling.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxConnectionPooling.Location = new System.Drawing.Point(340, 378);
            this.checkBoxConnectionPooling.Name = "checkBoxConnectionPooling";
            this.checkBoxConnectionPooling.Size = new System.Drawing.Size(104, 24);
            this.checkBoxConnectionPooling.TabIndex = 10;
            this.checkBoxConnectionPooling.Text = "Enable Connection Pooling";
            // 
            // numericMaxPoolSize
            // 
            this.numericMaxPoolSize.Location = new System.Drawing.Point(486, 378);
            this.numericMaxPoolSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericMaxPoolSize.Name = "numericMaxPoolSize";
            this.numericMaxPoolSize.Size = new System.Drawing.Size(80, 30);
            this.numericMaxPoolSize.TabIndex = 11;
            // 
            // numericMinPoolSize
            // 
            this.numericMinPoolSize.Location = new System.Drawing.Point(0, 0);
            this.numericMinPoolSize.Name = "numericMinPoolSize";
            this.numericMinPoolSize.Size = new System.Drawing.Size(120, 22);
            this.numericMinPoolSize.TabIndex = 0;
            // 
            // numericConnectionTimeout
            // 
            this.numericConnectionTimeout.Location = new System.Drawing.Point(0, 0);
            this.numericConnectionTimeout.Name = "numericConnectionTimeout";
            this.numericConnectionTimeout.Size = new System.Drawing.Size(120, 22);
            this.numericConnectionTimeout.TabIndex = 0;
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.buttonSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(636, 369);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 40);
            this.buttonSave.TabIndex = 12;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // ComboDatabaseName
            // 
            this.ComboDatabaseName.FormattingEnabled = true;
            this.ComboDatabaseName.Location = new System.Drawing.Point(486, 285);
            this.ComboDatabaseName.Name = "ComboDatabaseName";
            this.ComboDatabaseName.Size = new System.Drawing.Size(250, 31);
            this.ComboDatabaseName.TabIndex = 13;
            // 
            // btnTestconnection
            // 
            this.btnTestconnection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnTestconnection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTestconnection.FlatAppearance.BorderSize = 0;
            this.btnTestconnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestconnection.ForeColor = System.Drawing.Color.White;
            this.btnTestconnection.Location = new System.Drawing.Point(650, 246);
            this.btnTestconnection.Name = "btnTestconnection";
            this.btnTestconnection.Size = new System.Drawing.Size(86, 33);
            this.btnTestconnection.TabIndex = 14;
            this.btnTestconnection.Text = "Test";
            this.btnTestconnection.UseVisualStyleBackColor = false;
            this.btnTestconnection.Click += new System.EventHandler(this.btnTestconnection_Click_1);
            // 
            // txtpasskey
            // 
            this.txtpasskey.Location = new System.Drawing.Point(486, 327);
            this.txtpasskey.Name = "txtpasskey";
            this.txtpasskey.PasswordChar = '•';
            this.txtpasskey.Size = new System.Drawing.Size(250, 30);
            this.txtpasskey.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(336, 334);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 23);
            this.label1.TabIndex = 16;
            this.label1.Text = "PassKey";
            // 
            // btnArchieve
            // 
            this.btnArchieve.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnArchieve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArchieve.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArchieve.ForeColor = System.Drawing.Color.White;
            this.btnArchieve.Location = new System.Drawing.Point(3, 3);
            this.btnArchieve.Name = "btnArchieve";
            this.btnArchieve.Size = new System.Drawing.Size(221, 77);
            this.btnArchieve.TabIndex = 17;
            this.btnArchieve.Text = "Database Archieve";
            this.btnArchieve.UseVisualStyleBackColor = true;
            this.btnArchieve.Click += new System.EventHandler(this.btnArchieve_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.flowLayoutPanel1.Controls.Add(this.btnArchieve);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1, -1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(224, 492);
            this.flowLayoutPanel1.TabIndex = 18;
            // 
            // frmDatabaseSettings
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(908, 490);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtpasskey);
            this.Controls.Add(this.btnTestconnection);
            this.Controls.Add(this.ComboDatabaseName);
            this.Controls.Add(this.labelCompanyName);
            this.Controls.Add(this.textBoxCompanyName);
            this.Controls.Add(this.labelSQLServerName);
            this.Controls.Add(this.textBoxSQLServerName);
            this.Controls.Add(this.labelUserName);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelDatabaseName);
            this.Controls.Add(this.checkBoxConnectionPooling);
            this.Controls.Add(this.numericMaxPoolSize);
            this.Controls.Add(this.buttonSave);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDatabaseSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database Settings";
            this.Load += new System.EventHandler(this.frmDatabaseSettings_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxPoolSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinPoolSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericConnectionTimeout)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private Label labelCompanyName;
        private TextBox textBoxCompanyName;
        private Label labelSQLServerName;
        private TextBox textBoxSQLServerName;
        private Label labelUserName;
        private TextBox textBoxUserName;
        private Label labelPassword;
        private TextBox textBoxPassword;
        private Label labelDatabaseName;
        private CheckBox checkBoxConnectionPooling;
        private NumericUpDown numericMaxPoolSize;
        private Button buttonSave;
        private NumericUpDown numericConnectionTimeout;
        private NumericUpDown numericMinPoolSize;
        private ComboBox ComboDatabaseName;
        private Button btnTestconnection;
        private TextBox txtpasskey;
        private Label label1;
        private Button btnArchieve;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
