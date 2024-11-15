
namespace dBrowser
{
    partial class frmpasskey
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmpasskey));
            this.label1 = new System.Windows.Forms.Label();
            this.txtpasskey = new System.Windows.Forms.TextBox();
            this.btnpasskey = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(110, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "PassKey";
            // 
            // txtpasskey
            // 
            this.txtpasskey.BackColor = System.Drawing.SystemColors.Control;
            this.txtpasskey.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtpasskey.Location = new System.Drawing.Point(115, 106);
            this.txtpasskey.Name = "txtpasskey";
            this.txtpasskey.Size = new System.Drawing.Size(471, 34);
            this.txtpasskey.TabIndex = 1;
            this.txtpasskey.UseSystemPasswordChar = true;
            // 
            // btnpasskey
            // 
            this.btnpasskey.BackColor = System.Drawing.Color.Gainsboro;
            this.btnpasskey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnpasskey.Location = new System.Drawing.Point(489, 146);
            this.btnpasskey.Name = "btnpasskey";
            this.btnpasskey.Size = new System.Drawing.Size(97, 37);
            this.btnpasskey.TabIndex = 2;
            this.btnpasskey.Text = "passkey";
            this.btnpasskey.UseVisualStyleBackColor = false;
            this.btnpasskey.Click += new System.EventHandler(this.btnpasskey_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Location = new System.Drawing.Point(675, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(42, 37);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmpasskey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(720, 242);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnpasskey);
            this.Controls.Add(this.txtpasskey);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmpasskey";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtpasskey;
        private System.Windows.Forms.Button btnpasskey;
        private System.Windows.Forms.Button btnClose;
    }
}