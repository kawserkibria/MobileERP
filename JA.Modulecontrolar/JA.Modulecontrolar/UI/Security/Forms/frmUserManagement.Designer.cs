namespace JA.Modulecontrolar.UI.Security.Forms
{
    partial class frmUserManagement
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserManagement));
            this.uctxtLogInName = new System.Windows.Forms.TextBox();
            this.lblLedgerName = new System.Windows.Forms.Label();
            this.uctxtFullName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uctxtPasswoed = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.uctxtcomments = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.uctxtDepartment = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.uctxtDesignation = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnUploadImage = new System.Windows.Forms.Button();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.imagelst = new System.Windows.Forms.ImageList(this.components);
            this.txtOldUserName = new System.Windows.Forms.TextBox();
            this.btnFormConfig = new System.Windows.Forms.Button();
            this.cboAccessLevel = new System.Windows.Forms.ComboBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.btnLogInCompouter = new System.Windows.Forms.Button();
            this.btnOnlineOrder = new System.Windows.Forms.Button();
            this.txtOldPassWord = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(326, 7);
            this.frmLabel.Size = new System.Drawing.Size(218, 33);
            this.frmLabel.Text = "User Information";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.label10);
            this.pnlMain.Controls.Add(this.txtOldPassWord);
            this.pnlMain.Controls.Add(this.cboStatus);
            this.pnlMain.Controls.Add(this.cboAccessLevel);
            this.pnlMain.Controls.Add(this.groupBox2);
            this.pnlMain.Controls.Add(this.uctxtDesignation);
            this.pnlMain.Controls.Add(this.label9);
            this.pnlMain.Controls.Add(this.uctxtDepartment);
            this.pnlMain.Controls.Add(this.label8);
            this.pnlMain.Controls.Add(this.uctxtcomments);
            this.pnlMain.Controls.Add(this.label6);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.uctxtPasswoed);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.uctxtFullName);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.uctxtLogInName);
            this.pnlMain.Controls.Add(this.lblLedgerName);
            this.pnlMain.Size = new System.Drawing.Size(863, 419);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.txtOldUserName);
            this.pnlTop.Controls.SetChildIndex(this.frmLabel, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnTopClose, 0);
            this.pnlTop.Controls.SetChildIndex(this.txtOldUserName, 0);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(6, 336);
            this.btnEdit.Size = new System.Drawing.Size(117, 39);
            this.btnEdit.Text = "List All";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(641, 336);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(520, 361);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(125, 336);
            this.btnNew.Size = new System.Drawing.Size(168, 39);
            this.btnNew.Text = "Access Control";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(755, 336);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(688, 391);
            this.btnPrint.Size = new System.Drawing.Size(10, 10);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 407);
            // 
            // uctxtLogInName
            // 
            this.uctxtLogInName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtLogInName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtLogInName.Location = new System.Drawing.Point(211, 183);
            this.uctxtLogInName.Name = "uctxtLogInName";
            this.uctxtLogInName.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtLogInName.Size = new System.Drawing.Size(290, 22);
            this.uctxtLogInName.TabIndex = 72;
            // 
            // lblLedgerName
            // 
            this.lblLedgerName.AutoSize = true;
            this.lblLedgerName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLedgerName.Location = new System.Drawing.Point(116, 183);
            this.lblLedgerName.Name = "lblLedgerName";
            this.lblLedgerName.Size = new System.Drawing.Size(89, 16);
            this.lblLedgerName.TabIndex = 71;
            this.lblLedgerName.Text = "Login Name:";
            // 
            // uctxtFullName
            // 
            this.uctxtFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtFullName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtFullName.Location = new System.Drawing.Point(211, 206);
            this.uctxtFullName.Name = "uctxtFullName";
            this.uctxtFullName.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtFullName.Size = new System.Drawing.Size(290, 22);
            this.uctxtFullName.TabIndex = 74;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(128, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 73;
            this.label1.Text = "Full Name:";
            // 
            // uctxtPasswoed
            // 
            this.uctxtPasswoed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtPasswoed.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtPasswoed.Location = new System.Drawing.Point(211, 302);
            this.uctxtPasswoed.Name = "uctxtPasswoed";
            this.uctxtPasswoed.PasswordChar = '*';
            this.uctxtPasswoed.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtPasswoed.Size = new System.Drawing.Size(290, 26);
            this.uctxtPasswoed.TabIndex = 76;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(96, 306);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 16);
            this.label3.TabIndex = 75;
            this.label3.Text = "New Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(105, 334);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 77;
            this.label4.Text = "Access Level:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(147, 363);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 16);
            this.label5.TabIndex = 79;
            this.label5.Text = "Status:";
            // 
            // uctxtcomments
            // 
            this.uctxtcomments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtcomments.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtcomments.Location = new System.Drawing.Point(211, 380);
            this.uctxtcomments.Name = "uctxtcomments";
            this.uctxtcomments.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtcomments.Size = new System.Drawing.Size(290, 22);
            this.uctxtcomments.TabIndex = 82;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(123, 385);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 16);
            this.label6.TabIndex = 81;
            this.label6.Text = "Comments:";
            // 
            // uctxtDepartment
            // 
            this.uctxtDepartment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtDepartment.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtDepartment.Location = new System.Drawing.Point(211, 229);
            this.uctxtDepartment.Name = "uctxtDepartment";
            this.uctxtDepartment.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtDepartment.Size = new System.Drawing.Size(290, 22);
            this.uctxtDepartment.TabIndex = 86;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(114, 230);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 16);
            this.label8.TabIndex = 85;
            this.label8.Text = "Department:";
            // 
            // uctxtDesignation
            // 
            this.uctxtDesignation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtDesignation.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtDesignation.Location = new System.Drawing.Point(211, 252);
            this.uctxtDesignation.Name = "uctxtDesignation";
            this.uctxtDesignation.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtDesignation.Size = new System.Drawing.Size(290, 22);
            this.uctxtDesignation.TabIndex = 88;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(115, 255);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 16);
            this.label9.TabIndex = 87;
            this.label9.Text = "Designation:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnUploadImage);
            this.groupBox2.Controls.Add(this.pbImage);
            this.groupBox2.Location = new System.Drawing.Point(569, 159);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(247, 240);
            this.groupBox2.TabIndex = 89;
            this.groupBox2.TabStop = false;
            // 
            // btnUploadImage
            // 
            this.btnUploadImage.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnUploadImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadImage.ForeColor = System.Drawing.Color.White;
            this.btnUploadImage.Location = new System.Drawing.Point(44, 203);
            this.btnUploadImage.Name = "btnUploadImage";
            this.btnUploadImage.Size = new System.Drawing.Size(155, 31);
            this.btnUploadImage.TabIndex = 20;
            this.btnUploadImage.Text = "Upload Image";
            this.btnUploadImage.UseVisualStyleBackColor = false;
            this.btnUploadImage.Click += new System.EventHandler(this.btnUploadImage_Click);
            // 
            // pbImage
            // 
            this.pbImage.BackColor = System.Drawing.Color.Transparent;
            this.pbImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbImage.BackgroundImage")));
            this.pbImage.Location = new System.Drawing.Point(19, 26);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(208, 172);
            this.pbImage.TabIndex = 0;
            this.pbImage.TabStop = false;
            // 
            // imagelst
            // 
            this.imagelst.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagelst.ImageStream")));
            this.imagelst.TransparentColor = System.Drawing.Color.Transparent;
            this.imagelst.Images.SetKeyName(0, "comingSoon.jpg.png");
            // 
            // txtOldUserName
            // 
            this.txtOldUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOldUserName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldUserName.Location = new System.Drawing.Point(75, 12);
            this.txtOldUserName.Name = "txtOldUserName";
            this.txtOldUserName.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOldUserName.Size = new System.Drawing.Size(63, 22);
            this.txtOldUserName.TabIndex = 90;
            this.txtOldUserName.Visible = false;
            // 
            // btnFormConfig
            // 
            this.btnFormConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnFormConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFormConfig.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFormConfig.ForeColor = System.Drawing.Color.Navy;
            this.btnFormConfig.Location = new System.Drawing.Point(411, 335);
            this.btnFormConfig.Name = "btnFormConfig";
            this.btnFormConfig.Size = new System.Drawing.Size(104, 57);
            this.btnFormConfig.TabIndex = 15;
            this.btnFormConfig.Text = "Setup";
            this.btnFormConfig.UseVisualStyleBackColor = false;
            this.btnFormConfig.Click += new System.EventHandler(this.btnFormConfig_Click);
            // 
            // cboAccessLevel
            // 
            this.cboAccessLevel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAccessLevel.FormattingEnabled = true;
            this.cboAccessLevel.Items.AddRange(new object[] {
            "Administrator",
            "User"});
            this.cboAccessLevel.Location = new System.Drawing.Point(211, 329);
            this.cboAccessLevel.Name = "cboAccessLevel";
            this.cboAccessLevel.Size = new System.Drawing.Size(224, 24);
            this.cboAccessLevel.TabIndex = 90;
            this.cboAccessLevel.Text = "User";
            // 
            // cboStatus
            // 
            this.cboStatus.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "Active",
            "Suspend"});
            this.cboStatus.Location = new System.Drawing.Point(211, 355);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(224, 24);
            this.cboStatus.TabIndex = 91;
            this.cboStatus.Text = "Active";
            // 
            // btnLogInCompouter
            // 
            this.btnLogInCompouter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnLogInCompouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogInCompouter.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogInCompouter.ForeColor = System.Drawing.Color.Navy;
            this.btnLogInCompouter.Location = new System.Drawing.Point(516, 335);
            this.btnLogInCompouter.Name = "btnLogInCompouter";
            this.btnLogInCompouter.Size = new System.Drawing.Size(107, 57);
            this.btnLogInCompouter.TabIndex = 16;
            this.btnLogInCompouter.Text = "Activate User";
            this.btnLogInCompouter.UseVisualStyleBackColor = false;
            this.btnLogInCompouter.Click += new System.EventHandler(this.btnLogInCompouter_Click);
            // 
            // btnOnlineOrder
            // 
            this.btnOnlineOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnOnlineOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOnlineOrder.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOnlineOrder.ForeColor = System.Drawing.Color.Navy;
            this.btnOnlineOrder.Location = new System.Drawing.Point(319, 335);
            this.btnOnlineOrder.Name = "btnOnlineOrder";
            this.btnOnlineOrder.Size = new System.Drawing.Size(91, 57);
            this.btnOnlineOrder.TabIndex = 17;
            this.btnOnlineOrder.Text = "Online Order";
            this.btnOnlineOrder.UseVisualStyleBackColor = false;
            this.btnOnlineOrder.Click += new System.EventHandler(this.btnOnlineOrder_Click);
            // 
            // txtOldPassWord
            // 
            this.txtOldPassWord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOldPassWord.Enabled = false;
            this.txtOldPassWord.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldPassWord.Location = new System.Drawing.Point(211, 275);
            this.txtOldPassWord.Name = "txtOldPassWord";
            this.txtOldPassWord.PasswordChar = '*';
            this.txtOldPassWord.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOldPassWord.Size = new System.Drawing.Size(290, 26);
            this.txtOldPassWord.TabIndex = 92;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(103, 279);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 16);
            this.label10.TabIndex = 93;
            this.label10.Text = "Old Password:";
            // 
            // frmUserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(864, 432);
            this.Controls.Add(this.btnOnlineOrder);
            this.Controls.Add(this.btnLogInCompouter);
            this.Controls.Add(this.btnFormConfig);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmUserManagement";
            this.Load += new System.EventHandler(this.frmUserManagement_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.pnlMain, 0);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.Controls.SetChildIndex(this.btnFormConfig, 0);
            this.Controls.SetChildIndex(this.btnLogInCompouter, 0);
            this.Controls.SetChildIndex(this.btnOnlineOrder, 0);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox uctxtLogInName;
        private System.Windows.Forms.Label lblLedgerName;
        private System.Windows.Forms.TextBox uctxtcomments;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox uctxtPasswoed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uctxtFullName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnUploadImage;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.TextBox uctxtDesignation;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox uctxtDepartment;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ImageList imagelst;
        private System.Windows.Forms.TextBox txtOldUserName;
        private System.Windows.Forms.Button btnFormConfig;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.ComboBox cboAccessLevel;
        private System.Windows.Forms.Button btnLogInCompouter;
        private System.Windows.Forms.Button btnOnlineOrder;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtOldPassWord;
    }
}
