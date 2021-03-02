namespace JA.Modulecontrolar.UI.Tools.Forms
{
    partial class frmBackup
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
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.uctxtBackupPath1 = new System.Windows.Forms.TextBox();
            this.uctxtBackupPath2 = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnPath1 = new System.Windows.Forms.Button();
            this.btnPath2 = new System.Windows.Forms.Button();
            this.chkAllCompany = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnBackup
            // 
            this.btnBackup.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackup.Location = new System.Drawing.Point(321, 188);
            this.btnBackup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(100, 44);
            this.btnBackup.TabIndex = 1;
            this.btnBackup.Text = "BackUp";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(420, 188);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 44);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(28, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "Backup Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(28, 119);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "Another Path";
            // 
            // uctxtBackupPath1
            // 
            this.uctxtBackupPath1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtBackupPath1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtBackupPath1.Location = new System.Drawing.Point(28, 75);
            this.uctxtBackupPath1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uctxtBackupPath1.Multiline = true;
            this.uctxtBackupPath1.Name = "uctxtBackupPath1";
            this.uctxtBackupPath1.Size = new System.Drawing.Size(435, 40);
            this.uctxtBackupPath1.TabIndex = 7;
            // 
            // uctxtBackupPath2
            // 
            this.uctxtBackupPath2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtBackupPath2.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtBackupPath2.Location = new System.Drawing.Point(28, 137);
            this.uctxtBackupPath2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uctxtBackupPath2.Multiline = true;
            this.uctxtBackupPath2.Name = "uctxtBackupPath2";
            this.uctxtBackupPath2.Size = new System.Drawing.Size(435, 40);
            this.uctxtBackupPath2.TabIndex = 8;
            // 
            // btnPath1
            // 
            this.btnPath1.Location = new System.Drawing.Point(463, 75);
            this.btnPath1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnPath1.Name = "btnPath1";
            this.btnPath1.Size = new System.Drawing.Size(56, 40);
            this.btnPath1.TabIndex = 9;
            this.btnPath1.Text = "...";
            this.btnPath1.UseVisualStyleBackColor = true;
            this.btnPath1.Click += new System.EventHandler(this.btnPath1_Click);
            // 
            // btnPath2
            // 
            this.btnPath2.Location = new System.Drawing.Point(463, 136);
            this.btnPath2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnPath2.Name = "btnPath2";
            this.btnPath2.Size = new System.Drawing.Size(56, 40);
            this.btnPath2.TabIndex = 10;
            this.btnPath2.Text = "...";
            this.btnPath2.UseVisualStyleBackColor = true;
            this.btnPath2.Click += new System.EventHandler(this.btnPath2_Click);
            // 
            // chkAllCompany
            // 
            this.chkAllCompany.AutoSize = true;
            this.chkAllCompany.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllCompany.ForeColor = System.Drawing.Color.White;
            this.chkAllCompany.Location = new System.Drawing.Point(32, 201);
            this.chkAllCompany.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkAllCompany.Name = "chkAllCompany";
            this.chkAllCompany.Size = new System.Drawing.Size(107, 20);
            this.chkAllCompany.TabIndex = 11;
            this.chkAllCompany.Text = "All Company";
            this.chkAllCompany.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(25, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 14);
            this.label3.TabIndex = 12;
            this.label3.Text = "Company Name:";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompanyName.Location = new System.Drawing.Point(28, 27);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.ReadOnly = true;
            this.txtCompanyName.Size = new System.Drawing.Size(491, 23);
            this.txtCompanyName.TabIndex = 13;
            // 
            // frmBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(548, 242);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkAllCompany);
            this.Controls.Add(this.btnPath2);
            this.Controls.Add(this.btnPath1);
            this.Controls.Add(this.uctxtBackupPath2);
            this.Controls.Add(this.uctxtBackupPath1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBackup);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBackup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Company";
            this.Load += new System.EventHandler(this.frmBackup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox uctxtBackupPath1;
        private System.Windows.Forms.TextBox uctxtBackupPath2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnPath1;
        private System.Windows.Forms.Button btnPath2;
        private System.Windows.Forms.CheckBox chkAllCompany;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCompanyName;
    }
}