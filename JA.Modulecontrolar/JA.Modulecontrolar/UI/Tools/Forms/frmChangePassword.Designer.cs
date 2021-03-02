namespace JA.Modulecontrolar.UI.Tools.Forms
{
    partial class frmChangePassword
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
            this.uctxtOldPassWord = new System.Windows.Forms.TextBox();
            this.uctxtNewPassWord = new System.Windows.Forms.TextBox();
            this.uctxtRetypePsaaword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.uctxtLogInName = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(125, 9);
            this.frmLabel.Size = new System.Drawing.Size(225, 33);
            this.frmLabel.Text = "Change Password";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.uctxtLogInName);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.uctxtOldPassWord);
            this.pnlMain.Controls.Add(this.uctxtRetypePsaaword);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.uctxtNewPassWord);
            this.pnlMain.Size = new System.Drawing.Size(494, 295);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(498, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(22, 214);
            this.btnEdit.Size = new System.Drawing.Size(10, 10);
            this.btnEdit.Text = "List All";
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(248, 214);
            this.btnSave.Size = new System.Drawing.Size(126, 39);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(6, 214);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(38, 214);
            this.btnNew.Size = new System.Drawing.Size(10, 10);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(380, 214);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(22, 214);
            this.btnPrint.Size = new System.Drawing.Size(10, 10);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 258);
            this.groupBox1.Size = new System.Drawing.Size(498, 36);
            // 
            // uctxtOldPassWord
            // 
            this.uctxtOldPassWord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtOldPassWord.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtOldPassWord.Location = new System.Drawing.Point(225, 175);
            this.uctxtOldPassWord.Name = "uctxtOldPassWord";
            this.uctxtOldPassWord.PasswordChar = '*';
            this.uctxtOldPassWord.Size = new System.Drawing.Size(172, 23);
            this.uctxtOldPassWord.TabIndex = 0;
            // 
            // uctxtNewPassWord
            // 
            this.uctxtNewPassWord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtNewPassWord.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtNewPassWord.Location = new System.Drawing.Point(225, 204);
            this.uctxtNewPassWord.Name = "uctxtNewPassWord";
            this.uctxtNewPassWord.PasswordChar = '*';
            this.uctxtNewPassWord.Size = new System.Drawing.Size(172, 23);
            this.uctxtNewPassWord.TabIndex = 1;
            // 
            // uctxtRetypePsaaword
            // 
            this.uctxtRetypePsaaword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtRetypePsaaword.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtRetypePsaaword.Location = new System.Drawing.Point(225, 233);
            this.uctxtRetypePsaaword.Name = "uctxtRetypePsaaword";
            this.uctxtRetypePsaaword.PasswordChar = '*';
            this.uctxtRetypePsaaword.Size = new System.Drawing.Size(172, 23);
            this.uctxtRetypePsaaword.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(98, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 18);
            this.label1.TabIndex = 78;
            this.label1.Text = "Old Password :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(89, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 18);
            this.label3.TabIndex = 79;
            this.label3.Text = "New Password :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(32, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 18);
            this.label4.TabIndex = 80;
            this.label4.Text = "Retype New Password :";
            // 
            // uctxtLogInName
            // 
            this.uctxtLogInName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtLogInName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtLogInName.Location = new System.Drawing.Point(11, 148);
            this.uctxtLogInName.Name = "uctxtLogInName";
            this.uctxtLogInName.PasswordChar = '*';
            this.uctxtLogInName.Size = new System.Drawing.Size(172, 23);
            this.uctxtLogInName.TabIndex = 81;
            // 
            // frmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(498, 294);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmChangePassword";
            this.Load += new System.EventHandler(this.frmChangePassword_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox uctxtOldPassWord;
        private System.Windows.Forms.TextBox uctxtNewPassWord;
        private System.Windows.Forms.TextBox uctxtRetypePsaaword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uctxtLogInName;
    }
}
