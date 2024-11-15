
using System;
using System.Windows.Forms;

namespace dBrowser
{
    partial class frmArchive
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmArchive));
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Timestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRunbackup = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkdiffsver = new System.Windows.Forms.CheckBox();
            this.txtArcServer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtArcUsername = new System.Windows.Forms.TextBox();
            this.txtArcPassword = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnTestArcConn = new System.Windows.Forms.Button();
            this.groupServer = new System.Windows.Forms.GroupBox();
            this.ntttt = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupServer.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(510, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "DATABASE ARCHIVE";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Timestamp,
            this.Message});
            this.dataGridView1.Location = new System.Drawing.Point(12, 271);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1140, 409);
            this.dataGridView1.TabIndex = 1;
            // 
            // Timestamp
            // 
            this.Timestamp.HeaderText = "Timestamp";
            this.Timestamp.MinimumWidth = 6;
            this.Timestamp.Name = "Timestamp";
            // 
            // Message
            // 
            this.Message.HeaderText = "Message";
            this.Message.MinimumWidth = 6;
            this.Message.Name = "Message";
            // 
            // btnRunbackup
            // 
            this.btnRunbackup.Location = new System.Drawing.Point(1058, 227);
            this.btnRunbackup.Name = "btnRunbackup";
            this.btnRunbackup.Size = new System.Drawing.Size(94, 38);
            this.btnRunbackup.TabIndex = 2;
            this.btnRunbackup.Text = "ARCHIEVE";
            this.btnRunbackup.Click += new System.EventHandler(this.btnRunbackup_Click_1);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.CalendarForeColor = System.Drawing.Color.Black;
            this.dateTimePicker1.CalendarMonthBackground = System.Drawing.SystemColors.Info;
            this.dateTimePicker1.CalendarTitleBackColor = System.Drawing.Color.Firebrick;
            this.dateTimePicker1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateTimePicker1.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(52, 111);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(283, 22);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.CalendarForeColor = System.Drawing.Color.Black;
            this.dateTimePicker2.CalendarMonthBackground = System.Drawing.SystemColors.Info;
            this.dateTimePicker2.CalendarTitleBackColor = System.Drawing.Color.Firebrick;
            this.dateTimePicker2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateTimePicker2.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Location = new System.Drawing.Point(52, 72);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(279, 22);
            this.dateTimePicker2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Archieve Date Range";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "From";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "To";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(24, 82);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(117, 21);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Full Database";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkdiffsver
            // 
            this.checkdiffsver.AutoSize = true;
            this.checkdiffsver.Location = new System.Drawing.Point(24, 109);
            this.checkdiffsver.Name = "checkdiffsver";
            this.checkdiffsver.Size = new System.Drawing.Size(131, 21);
            this.checkdiffsver.TabIndex = 9;
            this.checkdiffsver.Text = "Deferent Server";
            this.checkdiffsver.UseVisualStyleBackColor = true;
            this.checkdiffsver.CheckedChanged += new System.EventHandler(this.checkdiffsver_CheckedChanged);
            // 
            // txtArcServer
            // 
            this.txtArcServer.Location = new System.Drawing.Point(119, 36);
            this.txtArcServer.Name = "txtArcServer";
            this.txtArcServer.Size = new System.Drawing.Size(283, 22);
            this.txtArcServer.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Server";
            // 
            // txtArcUsername
            // 
            this.txtArcUsername.Location = new System.Drawing.Point(119, 72);
            this.txtArcUsername.Name = "txtArcUsername";
            this.txtArcUsername.Size = new System.Drawing.Size(283, 22);
            this.txtArcUsername.TabIndex = 12;
            // 
            // txtArcPassword
            // 
            this.txtArcPassword.Location = new System.Drawing.Point(119, 110);
            this.txtArcPassword.Name = "txtArcPassword";
            this.txtArcPassword.Size = new System.Drawing.Size(283, 22);
            this.txtArcPassword.TabIndex = 13;
            this.txtArcPassword.UseSystemPasswordChar = true;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(40, 75);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(73, 17);
            this.lblUsername.TabIndex = 14;
            this.lblUsername.Text = "Username";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Password";
            // 
            // btnTestArcConn
            // 
            this.btnTestArcConn.Location = new System.Drawing.Point(316, 155);
            this.btnTestArcConn.Name = "btnTestArcConn";
            this.btnTestArcConn.Size = new System.Drawing.Size(86, 31);
            this.btnTestArcConn.TabIndex = 16;
            this.btnTestArcConn.Text = "Test";
            this.btnTestArcConn.UseVisualStyleBackColor = true;
            this.btnTestArcConn.Click += new System.EventHandler(this.btnTestArcConn_Click);
            // 
            // groupServer
            // 
            this.groupServer.Controls.Add(this.btnTestArcConn);
            this.groupServer.Controls.Add(this.label5);
            this.groupServer.Controls.Add(this.label6);
            this.groupServer.Controls.Add(this.txtArcServer);
            this.groupServer.Controls.Add(this.lblUsername);
            this.groupServer.Controls.Add(this.txtArcUsername);
            this.groupServer.Controls.Add(this.txtArcPassword);
            this.groupServer.Location = new System.Drawing.Point(614, 73);
            this.groupServer.Name = "groupServer";
            this.groupServer.Size = new System.Drawing.Size(426, 192);
            this.groupServer.TabIndex = 17;
            this.groupServer.TabStop = false;
            this.groupServer.Text = "Server";
            // 
            // ntttt
            // 
            this.ntttt.AutoSize = true;
            this.ntttt.Location = new System.Drawing.Point(24, 136);
            this.ntttt.Name = "ntttt";
            this.ntttt.Size = new System.Drawing.Size(172, 21);
            this.ntttt.TabIndex = 18;
            this.ntttt.Text = "Delete Archieved Data";
            this.ntttt.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.dateTimePicker2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(225, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(383, 192);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Date Range";
            // 
            // frmArchive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 683);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ntttt);
            this.Controls.Add(this.checkdiffsver);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnRunbackup);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupServer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmArchive";
            this.Text = "Database Archieve";
            this.Load += new System.EventHandler(this.frmArchive_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupServer.ResumeLayout(false);
            this.groupServer.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnRunbackup;
        private System.Windows.Forms.DataGridViewTextBoxColumn Timestamp;
        private DataGridViewTextBoxColumn Message;
        private EventHandler frmArchieve_Load_1;
        private EventHandler btnRunbackup_Click;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label label2;
        private Label label3;
        private Label label4;
        private CheckBox checkBox1;
        private CheckBox checkdiffsver;
        private TextBox txtArcServer;
        private Label label5;
        private TextBox txtArcUsername;
        private TextBox txtArcPassword;
        private Label lblUsername;
        private Label label6;
        private Button btnTestArcConn;
        private GroupBox groupServer;
        private CheckBox ntttt;
        private GroupBox groupBox2;
    }
}