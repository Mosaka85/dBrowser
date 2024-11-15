
using System.Windows.Forms;

namespace dBrowser
{
    partial class frmMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cmbShema = new System.Windows.Forms.ComboBox();
            this.lblTableorView = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbtableorview = new System.Windows.Forms.ComboBox();
            this.cmbFilterColumn = new System.Windows.Forms.ComboBox();
            this.cmboperator = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFiltervalue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnViewtable1 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperatorValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Values = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckUniqueRows = new System.Windows.Forms.CheckBox();
            this.CheckBoxNoLock = new System.Windows.Forms.CheckBox();
            this.txtNumberofRow = new System.Windows.Forms.TextBox();
            this.CheckFilterConfition = new System.Windows.Forms.CheckBox();
            this.rtbSQLInput = new System.Windows.Forms.RichTextBox();
            this.lblRowcount = new System.Windows.Forms.Label();
            this.btnFilterSQL = new System.Windows.Forms.Button();
            this.btnRemoveFilter = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCreatletable = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.cmbSELECTsheet = new System.Windows.Forms.ComboBox();
            this.txtSQLtablename = new System.Windows.Forms.TextBox();
            this.lblSELECTWORKSHEET = new System.Windows.Forms.Label();
            this.btnDataType = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnExportData = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnExistingTable = new System.Windows.Forms.Button();
            this.ComboImportTotables = new System.Windows.Forms.ComboBox();
            this.btnMapColumns = new System.Windows.Forms.Button();
            this.ComboSQLTabelColumn = new System.Windows.Forms.ComboBox();
            this.comboExcelColumns = new System.Windows.Forms.ComboBox();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.ExcelColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SQLColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddSelectedItemToImport = new System.Windows.Forms.Button();
            this.btnSuggestColumns = new System.Windows.Forms.Button();
            this.btnImportdata = new System.Windows.Forms.Button();
            this.lblExcelColumns = new System.Windows.Forms.Label();
            this.lblSQLTabelColumn = new System.Windows.Forms.Label();
            this.btnRemovefromGrid3 = new System.Windows.Forms.Button();
            this.lblDatabaseName = new System.Windows.Forms.Label();
            this.comboBoxFileFormats = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.NullValue = "NULL";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.GridColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(308, 194);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1586, 558);
            this.dataGridView1.TabIndex = 0;
            // 
            // cmbShema
            // 
            this.cmbShema.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmbShema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbShema.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbShema.FormattingEnabled = true;
            this.cmbShema.Location = new System.Drawing.Point(17, 84);
            this.cmbShema.Name = "cmbShema";
            this.cmbShema.Size = new System.Drawing.Size(233, 28);
            this.cmbShema.TabIndex = 1;
            // 
            // lblTableorView
            // 
            this.lblTableorView.AutoSize = true;
            this.lblTableorView.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTableorView.ForeColor = System.Drawing.Color.Black;
            this.lblTableorView.Location = new System.Drawing.Point(17, 115);
            this.lblTableorView.Name = "lblTableorView";
            this.lblTableorView.Size = new System.Drawing.Size(87, 20);
            this.lblTableorView.TabIndex = 2;
            this.lblTableorView.Text = "Table/View";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(17, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select";
            // 
            // cmbtableorview
            // 
            this.cmbtableorview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmbtableorview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbtableorview.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbtableorview.FormattingEnabled = true;
            this.cmbtableorview.Location = new System.Drawing.Point(17, 135);
            this.cmbtableorview.Name = "cmbtableorview";
            this.cmbtableorview.Size = new System.Drawing.Size(227, 28);
            this.cmbtableorview.Sorted = true;
            this.cmbtableorview.TabIndex = 4;
            this.cmbtableorview.SelectedIndexChanged += new System.EventHandler(this.Cmbtableorview_SelectedIndexChanged_1);
            // 
            // cmbFilterColumn
            // 
            this.cmbFilterColumn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmbFilterColumn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFilterColumn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilterColumn.FormattingEnabled = true;
            this.cmbFilterColumn.Location = new System.Drawing.Point(5, 42);
            this.cmbFilterColumn.Name = "cmbFilterColumn";
            this.cmbFilterColumn.Size = new System.Drawing.Size(146, 28);
            this.cmbFilterColumn.Sorted = true;
            this.cmbFilterColumn.TabIndex = 6;
            // 
            // cmboperator
            // 
            this.cmboperator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmboperator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmboperator.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboperator.FormattingEnabled = true;
            this.cmboperator.Location = new System.Drawing.Point(157, 41);
            this.cmboperator.Name = "cmboperator";
            this.cmboperator.Size = new System.Drawing.Size(112, 28);
            this.cmboperator.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Operator";
            // 
            // txtFiltervalue
            // 
            this.txtFiltervalue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtFiltervalue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiltervalue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFiltervalue.Location = new System.Drawing.Point(9, 96);
            this.txtFiltervalue.Name = "txtFiltervalue";
            this.txtFiltervalue.Size = new System.Drawing.Size(255, 27);
            this.txtFiltervalue.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Value";
            // 
            // btnViewtable1
            // 
            this.btnViewtable1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewtable1.Location = new System.Drawing.Point(17, 524);
            this.btnViewtable1.Name = "btnViewtable1";
            this.btnViewtable1.Size = new System.Drawing.Size(82, 32);
            this.btnViewtable1.TabIndex = 11;
            this.btnViewtable1.Text = "View";
            this.btnViewtable1.UseVisualStyleBackColor = true;
            this.btnViewtable1.Click += new System.EventHandler(this.btnViewtable1_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.OperatorValue,
            this.Values});
            this.dataGridView2.Location = new System.Drawing.Point(13, 359);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(289, 159);
            this.dataGridView2.TabIndex = 12;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Column Name";
            this.ColumnName.MinimumWidth = 6;
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.Width = 125;
            // 
            // OperatorValue
            // 
            this.OperatorValue.HeaderText = "OperatorValue";
            this.OperatorValue.MinimumWidth = 6;
            this.OperatorValue.Name = "OperatorValue";
            this.OperatorValue.Width = 125;
            // 
            // Values
            // 
            this.Values.HeaderText = "Values";
            this.Values.MinimumWidth = 6;
            this.Values.Name = "Values";
            this.Values.Width = 125;
            // 
            // CheckUniqueRows
            // 
            this.CheckUniqueRows.AutoSize = true;
            this.CheckUniqueRows.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CheckUniqueRows.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckUniqueRows.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CheckUniqueRows.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckUniqueRows.ForeColor = System.Drawing.Color.Black;
            this.CheckUniqueRows.Location = new System.Drawing.Point(261, 92);
            this.CheckUniqueRows.Name = "CheckUniqueRows";
            this.CheckUniqueRows.Size = new System.Drawing.Size(90, 20);
            this.CheckUniqueRows.TabIndex = 13;
            this.CheckUniqueRows.Text = "DISTINCT";
            this.CheckUniqueRows.UseVisualStyleBackColor = false;
            // 
            // CheckBoxNoLock
            // 
            this.CheckBoxNoLock.AutoSize = true;
            this.CheckBoxNoLock.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CheckBoxNoLock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckBoxNoLock.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CheckBoxNoLock.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxNoLock.ForeColor = System.Drawing.Color.Black;
            this.CheckBoxNoLock.Location = new System.Drawing.Point(261, 115);
            this.CheckBoxNoLock.Name = "CheckBoxNoLock";
            this.CheckBoxNoLock.Size = new System.Drawing.Size(91, 20);
            this.CheckBoxNoLock.TabIndex = 14;
            this.CheckBoxNoLock.Text = "NO LOCK";
            this.CheckBoxNoLock.UseVisualStyleBackColor = false;
            // 
            // txtNumberofRow
            // 
            this.txtNumberofRow.Location = new System.Drawing.Point(1815, 166);
            this.txtNumberofRow.Name = "txtNumberofRow";
            this.txtNumberofRow.Size = new System.Drawing.Size(88, 22);
            this.txtNumberofRow.TabIndex = 15;
            // 
            // CheckFilterConfition
            // 
            this.CheckFilterConfition.AutoSize = true;
            this.CheckFilterConfition.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CheckFilterConfition.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckFilterConfition.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CheckFilterConfition.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckFilterConfition.ForeColor = System.Drawing.Color.Black;
            this.CheckFilterConfition.Location = new System.Drawing.Point(261, 139);
            this.CheckFilterConfition.Name = "CheckFilterConfition";
            this.CheckFilterConfition.Size = new System.Drawing.Size(64, 20);
            this.CheckFilterConfition.TabIndex = 16;
            this.CheckFilterConfition.Text = "Filter";
            this.CheckFilterConfition.UseVisualStyleBackColor = false;
            // 
            // rtbSQLInput
            // 
            this.rtbSQLInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rtbSQLInput.ForeColor = System.Drawing.Color.White;
            this.rtbSQLInput.Location = new System.Drawing.Point(522, 6);
            this.rtbSQLInput.Name = "rtbSQLInput";
            this.rtbSQLInput.Size = new System.Drawing.Size(559, 182);
            this.rtbSQLInput.TabIndex = 17;
            this.rtbSQLInput.Text = "";
            this.rtbSQLInput.TextChanged += new System.EventHandler(this.rtbSQLInput_TextChanged);
            // 
            // lblRowcount
            // 
            this.lblRowcount.AutoSize = true;
            this.lblRowcount.Location = new System.Drawing.Point(1545, 759);
            this.lblRowcount.Name = "lblRowcount";
            this.lblRowcount.Size = new System.Drawing.Size(84, 16);
            this.lblRowcount.TabIndex = 18;
            this.lblRowcount.Text = "lblRowcount";
            // 
            // btnFilterSQL
            // 
            this.btnFilterSQL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterSQL.Location = new System.Drawing.Point(105, 524);
            this.btnFilterSQL.Name = "btnFilterSQL";
            this.btnFilterSQL.Size = new System.Drawing.Size(74, 32);
            this.btnFilterSQL.TabIndex = 19;
            this.btnFilterSQL.Text = "Add";
            this.btnFilterSQL.UseVisualStyleBackColor = true;
            this.btnFilterSQL.Click += new System.EventHandler(this.btnFilterSQL_Click);
            // 
            // btnRemoveFilter
            // 
            this.btnRemoveFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveFilter.Location = new System.Drawing.Point(185, 524);
            this.btnRemoveFilter.Name = "btnRemoveFilter";
            this.btnRemoveFilter.Size = new System.Drawing.Size(76, 32);
            this.btnRemoveFilter.TabIndex = 20;
            this.btnRemoveFilter.Text = "Remove";
            this.btnRemoveFilter.UseVisualStyleBackColor = true;
            this.btnRemoveFilter.Click += new System.EventHandler(this.btnRemoveFilter_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1695, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "Number Of Rows";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.cmbFilterColumn);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmboperator);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtFiltervalue);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(17, 172);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 170);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1087, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 40);
            this.button1.TabIndex = 23;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCreatletable
            // 
            this.btnCreatletable.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCreatletable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreatletable.ForeColor = System.Drawing.Color.Black;
            this.btnCreatletable.Location = new System.Drawing.Point(4, 976);
            this.btnCreatletable.Name = "btnCreatletable";
            this.btnCreatletable.Size = new System.Drawing.Size(84, 91);
            this.btnCreatletable.TabIndex = 24;
            this.btnCreatletable.Text = "Import Excel to SQLTable";
            this.btnCreatletable.UseVisualStyleBackColor = false;
            this.btnCreatletable.Click += new System.EventHandler(this.btnCreatletable_Click);
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.White;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.ForeColor = System.Drawing.Color.Black;
            this.btnImport.Location = new System.Drawing.Point(343, 1025);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(95, 45);
            this.btnImport.TabIndex = 25;
            this.btnImport.Text = "Define Columns";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click_1);
            // 
            // cmbSELECTsheet
            // 
            this.cmbSELECTsheet.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.cmbSELECTsheet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSELECTsheet.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSELECTsheet.FormattingEnabled = true;
            this.cmbSELECTsheet.Location = new System.Drawing.Point(87, 990);
            this.cmbSELECTsheet.Name = "cmbSELECTsheet";
            this.cmbSELECTsheet.Size = new System.Drawing.Size(250, 31);
            this.cmbSELECTsheet.TabIndex = 26;
            // 
            // txtSQLtablename
            // 
            this.txtSQLtablename.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSQLtablename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSQLtablename.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSQLtablename.Location = new System.Drawing.Point(87, 1037);
            this.txtSQLtablename.Name = "txtSQLtablename";
            this.txtSQLtablename.Size = new System.Drawing.Size(250, 30);
            this.txtSQLtablename.TabIndex = 27;
            // 
            // lblSELECTWORKSHEET
            // 
            this.lblSELECTWORKSHEET.AutoSize = true;
            this.lblSELECTWORKSHEET.ForeColor = System.Drawing.Color.Black;
            this.lblSELECTWORKSHEET.Location = new System.Drawing.Point(91, 971);
            this.lblSELECTWORKSHEET.Name = "lblSELECTWORKSHEET";
            this.lblSELECTWORKSHEET.Size = new System.Drawing.Size(154, 16);
            this.lblSELECTWORKSHEET.TabIndex = 28;
            this.lblSELECTWORKSHEET.Text = "SELECT WORKSHEET";
            // 
            // btnDataType
            // 
            this.btnDataType.BackColor = System.Drawing.Color.White;
            this.btnDataType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDataType.ForeColor = System.Drawing.Color.Black;
            this.btnDataType.Location = new System.Drawing.Point(502, 759);
            this.btnDataType.Name = "btnDataType";
            this.btnDataType.Size = new System.Drawing.Size(81, 31);
            this.btnDataType.TabIndex = 29;
            this.btnDataType.Text = "import";
            this.btnDataType.UseVisualStyleBackColor = false;
            this.btnDataType.Click += new System.EventHandler(this.btnDataType_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(326, 759);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(160, 23);
            this.progressBar1.TabIndex = 30;
            // 
            // btnExportData
            // 
            this.btnExportData.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnExportData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportData.ForeColor = System.Drawing.Color.Black;
            this.btnExportData.Location = new System.Drawing.Point(4, 896);
            this.btnExportData.Name = "btnExportData";
            this.btnExportData.Size = new System.Drawing.Size(84, 69);
            this.btnExportData.TabIndex = 31;
            this.btnExportData.Text = "Export";
            this.btnExportData.UseVisualStyleBackColor = false;
            this.btnExportData.Click += new System.EventHandler(this.btnExportData_Click_1);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(1827, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(76, 40);
            this.button2.TabIndex = 32;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(94, 1021);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 16);
            this.label5.TabIndex = 33;
            this.label5.Text = "Table Name";
            // 
            // btnExistingTable
            // 
            this.btnExistingTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExistingTable.ForeColor = System.Drawing.Color.Black;
            this.btnExistingTable.Location = new System.Drawing.Point(343, 954);
            this.btnExistingTable.Name = "btnExistingTable";
            this.btnExistingTable.Size = new System.Drawing.Size(95, 60);
            this.btnExistingTable.TabIndex = 34;
            this.btnExistingTable.Text = "Import to existing Table";
            this.btnExistingTable.UseVisualStyleBackColor = true;
            this.btnExistingTable.Click += new System.EventHandler(this.btnExistingTable_Click);
            // 
            // ComboImportTotables
            // 
            this.ComboImportTotables.FormattingEnabled = true;
            this.ComboImportTotables.Location = new System.Drawing.Point(444, 954);
            this.ComboImportTotables.Name = "ComboImportTotables";
            this.ComboImportTotables.Size = new System.Drawing.Size(204, 24);
            this.ComboImportTotables.TabIndex = 35;
            // 
            // btnMapColumns
            // 
            this.btnMapColumns.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMapColumns.Location = new System.Drawing.Point(444, 989);
            this.btnMapColumns.Name = "btnMapColumns";
            this.btnMapColumns.Size = new System.Drawing.Size(131, 29);
            this.btnMapColumns.TabIndex = 36;
            this.btnMapColumns.Text = "Map Columns";
            this.btnMapColumns.UseVisualStyleBackColor = true;
            this.btnMapColumns.Click += new System.EventHandler(this.btnMapColumns_Click);
            // 
            // ComboSQLTabelColumn
            // 
            this.ComboSQLTabelColumn.FormattingEnabled = true;
            this.ComboSQLTabelColumn.Location = new System.Drawing.Point(890, 833);
            this.ComboSQLTabelColumn.Name = "ComboSQLTabelColumn";
            this.ComboSQLTabelColumn.Size = new System.Drawing.Size(196, 24);
            this.ComboSQLTabelColumn.Sorted = true;
            this.ComboSQLTabelColumn.TabIndex = 37;
            // 
            // comboExcelColumns
            // 
            this.comboExcelColumns.FormattingEnabled = true;
            this.comboExcelColumns.Location = new System.Drawing.Point(659, 833);
            this.comboExcelColumns.Name = "comboExcelColumns";
            this.comboExcelColumns.Size = new System.Drawing.Size(206, 24);
            this.comboExcelColumns.Sorted = true;
            this.comboExcelColumns.TabIndex = 38;
            this.comboExcelColumns.SelectedIndexChanged += new System.EventHandler(this.comboExcelColumns_SelectedIndexChanged);
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ExcelColumn,
            this.SQLColumn});
            this.dataGridView3.Location = new System.Drawing.Point(659, 863);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersWidth = 51;
            this.dataGridView3.RowTemplate.Height = 24;
            this.dataGridView3.Size = new System.Drawing.Size(427, 213);
            this.dataGridView3.TabIndex = 39;
            // 
            // ExcelColumn
            // 
            this.ExcelColumn.HeaderText = "Excel Column";
            this.ExcelColumn.MinimumWidth = 6;
            this.ExcelColumn.Name = "ExcelColumn";
            this.ExcelColumn.Width = 125;
            // 
            // SQLColumn
            // 
            this.SQLColumn.HeaderText = "SQL Column";
            this.SQLColumn.MinimumWidth = 6;
            this.SQLColumn.Name = "SQLColumn";
            this.SQLColumn.Width = 125;
            // 
            // btnAddSelectedItemToImport
            // 
            this.btnAddSelectedItemToImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSelectedItemToImport.Location = new System.Drawing.Point(1092, 846);
            this.btnAddSelectedItemToImport.Name = "btnAddSelectedItemToImport";
            this.btnAddSelectedItemToImport.Size = new System.Drawing.Size(75, 40);
            this.btnAddSelectedItemToImport.TabIndex = 40;
            this.btnAddSelectedItemToImport.Text = "Add";
            this.btnAddSelectedItemToImport.UseVisualStyleBackColor = true;
            this.btnAddSelectedItemToImport.Click += new System.EventHandler(this.btnAddSelectedItemToImport_Click);
            // 
            // btnSuggestColumns
            // 
            this.btnSuggestColumns.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuggestColumns.Location = new System.Drawing.Point(1092, 954);
            this.btnSuggestColumns.Name = "btnSuggestColumns";
            this.btnSuggestColumns.Size = new System.Drawing.Size(75, 44);
            this.btnSuggestColumns.TabIndex = 41;
            this.btnSuggestColumns.Text = "Auto Map";
            this.btnSuggestColumns.UseVisualStyleBackColor = true;
            this.btnSuggestColumns.Click += new System.EventHandler(this.btnSuggestColumns_Click);
            // 
            // btnImportdata
            // 
            this.btnImportdata.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportdata.Location = new System.Drawing.Point(1092, 1004);
            this.btnImportdata.Name = "btnImportdata";
            this.btnImportdata.Size = new System.Drawing.Size(75, 45);
            this.btnImportdata.TabIndex = 42;
            this.btnImportdata.Text = "Import";
            this.btnImportdata.UseVisualStyleBackColor = true;
            this.btnImportdata.Click += new System.EventHandler(this.btnImportdata_Click);
            // 
            // lblExcelColumns
            // 
            this.lblExcelColumns.AutoSize = true;
            this.lblExcelColumns.Location = new System.Drawing.Point(659, 811);
            this.lblExcelColumns.Name = "lblExcelColumns";
            this.lblExcelColumns.Size = new System.Drawing.Size(100, 16);
            this.lblExcelColumns.TabIndex = 43;
            this.lblExcelColumns.Text = "Excel Columns";
            // 
            // lblSQLTabelColumn
            // 
            this.lblSQLTabelColumn.AutoSize = true;
            this.lblSQLTabelColumn.Location = new System.Drawing.Point(887, 811);
            this.lblSQLTabelColumn.Name = "lblSQLTabelColumn";
            this.lblSQLTabelColumn.Size = new System.Drawing.Size(125, 16);
            this.lblSQLTabelColumn.TabIndex = 44;
            this.lblSQLTabelColumn.Text = "SQL Table Column";
            this.lblSQLTabelColumn.Click += new System.EventHandler(this.label6_Click);
            // 
            // btnRemovefromGrid3
            // 
            this.btnRemovefromGrid3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemovefromGrid3.Location = new System.Drawing.Point(1092, 892);
            this.btnRemovefromGrid3.Name = "btnRemovefromGrid3";
            this.btnRemovefromGrid3.Size = new System.Drawing.Size(75, 46);
            this.btnRemovefromGrid3.TabIndex = 45;
            this.btnRemovefromGrid3.Text = "Remove";
            this.btnRemovefromGrid3.UseVisualStyleBackColor = true;
            this.btnRemovefromGrid3.Click += new System.EventHandler(this.btnRemovefromGrid3_Click);
            // 
            // lblDatabaseName
            // 
            this.lblDatabaseName.AutoSize = true;
            this.lblDatabaseName.Location = new System.Drawing.Point(19, 30);
            this.lblDatabaseName.Name = "lblDatabaseName";
            this.lblDatabaseName.Size = new System.Drawing.Size(69, 16);
            this.lblDatabaseName.TabIndex = 46;
            this.lblDatabaseName.Text = "Database";
            // 
            // comboBoxFileFormats
            // 
            this.comboBoxFileFormats.Font = new System.Drawing.Font("Arial", 12F);
            this.comboBoxFileFormats.FormattingEnabled = true;
            this.comboBoxFileFormats.Location = new System.Drawing.Point(94, 896);
            this.comboBoxFileFormats.Name = "comboBoxFileFormats";
            this.comboBoxFileFormats.Size = new System.Drawing.Size(250, 31);
            this.comboBoxFileFormats.TabIndex = 47;
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(231, 930);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(106, 35);
            this.button3.TabIndex = 48;
            this.button3.Text = "Export to file";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1915, 1095);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.comboBoxFileFormats);
            this.Controls.Add(this.lblDatabaseName);
            this.Controls.Add(this.btnRemovefromGrid3);
            this.Controls.Add(this.lblSQLTabelColumn);
            this.Controls.Add(this.lblExcelColumns);
            this.Controls.Add(this.btnImportdata);
            this.Controls.Add(this.btnSuggestColumns);
            this.Controls.Add(this.btnAddSelectedItemToImport);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.comboExcelColumns);
            this.Controls.Add(this.ComboSQLTabelColumn);
            this.Controls.Add(this.btnMapColumns);
            this.Controls.Add(this.ComboImportTotables);
            this.Controls.Add(this.btnExistingTable);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnExportData);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnDataType);
            this.Controls.Add(this.lblSELECTWORKSHEET);
            this.Controls.Add(this.txtSQLtablename);
            this.Controls.Add(this.cmbSELECTsheet);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnCreatletable);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnRemoveFilter);
            this.Controls.Add(this.btnFilterSQL);
            this.Controls.Add(this.lblRowcount);
            this.Controls.Add(this.CheckFilterConfition);
            this.Controls.Add(this.rtbSQLInput);
            this.Controls.Add(this.txtNumberofRow);
            this.Controls.Add(this.CheckBoxNoLock);
            this.Controls.Add(this.CheckUniqueRows);
            this.Controls.Add(this.btnViewtable1);
            this.Controls.Add(this.cmbtableorview);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTableorView);
            this.Controls.Add(this.cmbShema);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dataGridView2);
            this.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Form2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbShema;
        private System.Windows.Forms.Label lblTableorView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbtableorview;
        private System.Windows.Forms.ComboBox cmbFilterColumn;
        private System.Windows.Forms.ComboBox cmboperator;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFiltervalue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnViewtable1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.CheckBox CheckUniqueRows;
        private System.Windows.Forms.CheckBox CheckBoxNoLock;
        private System.Windows.Forms.TextBox txtNumberofRow;
        private System.Windows.Forms.CheckBox CheckFilterConfition;
        private System.Windows.Forms.RichTextBox rtbSQLInput;
        private System.Windows.Forms.Label lblRowcount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperatorValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Values;
        private System.Windows.Forms.Button btnFilterSQL;
        private System.Windows.Forms.Button btnRemoveFilter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCreatletable;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.ComboBox cmbSELECTsheet;
        private System.Windows.Forms.TextBox txtSQLtablename;
        private System.Windows.Forms.Label lblSELECTWORKSHEET;
        private System.Windows.Forms.Button btnDataType;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnExportData;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnExistingTable;
        private ComboBox ComboImportTotables;
        private Button btnMapColumns;
        private ComboBox ComboSQLTabelColumn;
        private ComboBox comboExcelColumns;
        private DataGridView dataGridView3;
        private Button btnAddSelectedItemToImport;
        private Button btnSuggestColumns;
        private Button btnImportdata;
        private DataGridViewTextBoxColumn ExcelColumn;
        private DataGridViewTextBoxColumn SQLColumn;
        private Label lblExcelColumns;
        private Label lblSQLTabelColumn;
        private Button btnRemovefromGrid3;
        private Label lblDatabaseName;
        private ComboBox comboBoxFileFormats;
        private Button button3;
    }
}