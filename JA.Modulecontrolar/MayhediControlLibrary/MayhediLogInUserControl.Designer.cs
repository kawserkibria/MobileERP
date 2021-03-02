namespace MayhediControlLibrary
{
    partial class MayhediLogInUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MayhediLogInUserControl));
            this.btnLogIn = new System.Windows.Forms.Button();
            this.logInImg = new System.Windows.Forms.ImageList(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnTpClose = new System.Windows.Forms.Button();
            this.btnTopClose = new System.Windows.Forms.Button();
            this.frmLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lnkResetPassword = new System.Windows.Forms.LinkLabel();
            this.txtModuleName = new System.Windows.Forms.TextBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblMismatch = new MayhediControlLibrary.StandardLabel();
            this.cboUserTypes = new MayhediControlLibrary.StandardComboBox();
            this.StandardTextBox1 = new MayhediControlLibrary.StandardTextBox();
            this.StandardLabel4 = new MayhediControlLibrary.StandardLabel();
            this.StandardLabel1 = new MayhediControlLibrary.StandardLabel();
            this.StandardLabel2 = new MayhediControlLibrary.StandardLabel();
            this.StandardLabel5 = new MayhediControlLibrary.StandardLabel();
            this.StandardLabel3 = new MayhediControlLibrary.StandardLabel();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogIn
            // 
            this.btnLogIn.BackColor = System.Drawing.Color.SeaGreen;
            this.btnLogIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogIn.Font = new System.Drawing.Font("Maiandra GD", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogIn.ForeColor = System.Drawing.Color.Honeydew;
            this.btnLogIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogIn.ImageKey = "Login.png";
            this.btnLogIn.Location = new System.Drawing.Point(138, 15);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(288, 50);
            this.btnLogIn.TabIndex = 16;
            this.btnLogIn.Text = "LogIn";
            this.toolTip1.SetToolTip(this.btnLogIn, "Press to LogIn");
            this.btnLogIn.UseVisualStyleBackColor = false;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // logInImg
            // 
            this.logInImg.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("logInImg.ImageStream")));
            this.logInImg.TransparentColor = System.Drawing.Color.Transparent;
            this.logInImg.Images.SetKeyName(0, "close.png");
            this.logInImg.Images.SetKeyName(1, "logIn-icon.png");
            this.logInImg.Images.SetKeyName(2, "Login.png");
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Coral;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Maiandra GD", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Honeydew;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.ImageIndex = 0;
            this.btnClose.Location = new System.Drawing.Point(451, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(160, 50);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "Close";
            this.toolTip1.SetToolTip(this.btnClose, "Press to Close");
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnlTop.Controls.Add(this.pictureBox1);
            this.pnlTop.Controls.Add(this.btnTpClose);
            this.pnlTop.Controls.Add(this.btnTopClose);
            this.pnlTop.Controls.Add(this.frmLabel);
            this.pnlTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTop.Location = new System.Drawing.Point(-10, -1);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(504, 119);
            this.pnlTop.TabIndex = 21;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MayhediControlLibrary.Properties.Resources.user_icon;
            this.pictureBox1.Location = new System.Drawing.Point(60, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(106, 108);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // btnTpClose
            // 
            this.btnTpClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnTpClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTpClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTpClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTpClose.Font = new System.Drawing.Font("Imprint MT Shadow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTpClose.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnTpClose.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnTpClose.Location = new System.Drawing.Point(431, 2);
            this.btnTpClose.Name = "btnTpClose";
            this.btnTpClose.Size = new System.Drawing.Size(13, 18);
            this.btnTpClose.TabIndex = 14;
            this.btnTpClose.Text = "X";
            this.btnTpClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btnTpClose, "Press to Close");
            this.btnTpClose.UseVisualStyleBackColor = false;
            this.btnTpClose.Visible = false;
            this.btnTpClose.Click += new System.EventHandler(this.btnTpClose_Click);
            // 
            // btnTopClose
            // 
            this.btnTopClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnTopClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTopClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTopClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTopClose.Font = new System.Drawing.Font("Imprint MT Shadow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTopClose.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnTopClose.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnTopClose.Location = new System.Drawing.Point(785, 3);
            this.btnTopClose.Name = "btnTopClose";
            this.btnTopClose.Size = new System.Drawing.Size(51, 42);
            this.btnTopClose.TabIndex = 13;
            this.btnTopClose.Text = "X";
            this.btnTopClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTopClose.UseVisualStyleBackColor = false;
            // 
            // frmLabel
            // 
            this.frmLabel.AutoSize = true;
            this.frmLabel.BackColor = System.Drawing.Color.Transparent;
            this.frmLabel.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmLabel.ForeColor = System.Drawing.Color.White;
            this.frmLabel.Location = new System.Drawing.Point(182, 37);
            this.frmLabel.Name = "frmLabel";
            this.frmLabel.Size = new System.Drawing.Size(195, 43);
            this.frmLabel.TabIndex = 0;
            this.frmLabel.Text = "User Login";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.lnkResetPassword);
            this.panel1.Controls.Add(this.lblMismatch);
            this.panel1.Controls.Add(this.cboUserTypes);
            this.panel1.Controls.Add(this.StandardTextBox1);
            this.panel1.Controls.Add(this.StandardLabel4);
            this.panel1.Controls.Add(this.txtModuleName);
            this.panel1.Controls.Add(this.StandardLabel1);
            this.panel1.Controls.Add(this.txtUserID);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.StandardLabel2);
            this.panel1.Controls.Add(this.StandardLabel5);
            this.panel1.Controls.Add(this.StandardLabel3);
            this.panel1.Location = new System.Drawing.Point(0, 117);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(491, 271);
            this.panel1.TabIndex = 22;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel5.Controls.Add(this.pictureBox4);
            this.panel5.Location = new System.Drawing.Point(374, 176);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(43, 36);
            this.panel5.TabIndex = 29;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::MayhediControlLibrary.Properties.Resources.kwikdisk;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Location = new System.Drawing.Point(4, 3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(36, 31);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 26;
            this.pictureBox4.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel4.Controls.Add(this.pictureBox3);
            this.panel4.Location = new System.Drawing.Point(374, 105);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(43, 36);
            this.panel4.TabIndex = 28;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::MayhediControlLibrary.Properties.Resources.key_fill_128;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(4, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(36, 31);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 26;
            this.pictureBox3.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Location = new System.Drawing.Point(374, 35);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(43, 36);
            this.panel3.TabIndex = 27;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::MayhediControlLibrary.Properties.Resources.user_alt_128;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(4, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(36, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 26;
            this.pictureBox2.TabStop = false;
            // 
            // lnkResetPassword
            // 
            this.lnkResetPassword.AutoSize = true;
            this.lnkResetPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkResetPassword.Location = new System.Drawing.Point(375, 243);
            this.lnkResetPassword.Name = "lnkResetPassword";
            this.lnkResetPassword.Size = new System.Drawing.Size(117, 16);
            this.lnkResetPassword.TabIndex = 25;
            this.lnkResetPassword.TabStop = true;
            this.lnkResetPassword.Text = "Forgot Password?";
            // 
            // txtModuleName
            // 
            this.txtModuleName.BackColor = System.Drawing.Color.White;
            this.txtModuleName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtModuleName.Enabled = false;
            this.txtModuleName.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModuleName.Location = new System.Drawing.Point(87, 176);
            this.txtModuleName.Name = "txtModuleName";
            this.txtModuleName.Size = new System.Drawing.Size(287, 36);
            this.txtModuleName.TabIndex = 22;
            // 
            // txtUserID
            // 
            this.txtUserID.BackColor = System.Drawing.Color.White;
            this.txtUserID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUserID.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserID.Location = new System.Drawing.Point(86, 35);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(288, 36);
            this.txtUserID.TabIndex = 11;
            this.txtUserID.TextChanged += new System.EventHandler(this.txtUserID_TextChanged);
            this.txtUserID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserID_KeyDown);
            this.txtUserID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserID_KeyPress);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtPassword.Location = new System.Drawing.Point(87, 105);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(287, 36);
            this.txtPassword.TabIndex = 12;
            this.txtPassword.Text = "123";
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Maiandra GD", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(133, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Powered by: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Maiandra GD", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gainsboro;
            this.label7.Location = new System.Drawing.Point(221, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(256, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "IT Dept, Citygroup ; All rights reserved.";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnLogIn);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Location = new System.Drawing.Point(-130, 388);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(621, 102);
            this.panel2.TabIndex = 24;
            // 
            // lblMismatch
            // 
            this.lblMismatch.AutoSize = true;
            this.lblMismatch.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMismatch.ForeColor = System.Drawing.Color.Crimson;
            this.lblMismatch.Location = new System.Drawing.Point(24, 235);
            this.lblMismatch.Name = "lblMismatch";
            this.lblMismatch.Size = new System.Drawing.Size(0, 22);
            this.lblMismatch.TabIndex = 24;
            // 
            // cboUserTypes
            // 
            this.cboUserTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUserTypes.Font = new System.Drawing.Font("ArialMJ", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUserTypes.ForeColor = System.Drawing.Color.Blue;
            this.cboUserTypes.FormattingEnabled = true;
            this.cboUserTypes.Location = new System.Drawing.Point(452, 41);
            this.cboUserTypes.Name = "cboUserTypes";
            this.cboUserTypes.Size = new System.Drawing.Size(36, 26);
            this.cboUserTypes.TabIndex = 14;
            this.cboUserTypes.Visible = false;
            // 
            // StandardTextBox1
            // 
            this.StandardTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StandardTextBox1.Enabled = false;
            this.StandardTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StandardTextBox1.Location = new System.Drawing.Point(455, 11);
            this.StandardTextBox1.Name = "StandardTextBox1";
            this.StandardTextBox1.Size = new System.Drawing.Size(26, 24);
            this.StandardTextBox1.TabIndex = 17;
            this.StandardTextBox1.Visible = false;
            // 
            // StandardLabel4
            // 
            this.StandardLabel4.AutoSize = true;
            this.StandardLabel4.BackColor = System.Drawing.Color.Transparent;
            this.StandardLabel4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.StandardLabel4.ForeColor = System.Drawing.Color.DimGray;
            this.StandardLabel4.Location = new System.Drawing.Point(87, 151);
            this.StandardLabel4.Name = "StandardLabel4";
            this.StandardLabel4.Size = new System.Drawing.Size(151, 21);
            this.StandardLabel4.TabIndex = 21;
            this.StandardLabel4.Text = "Module Name        :";
            // 
            // StandardLabel1
            // 
            this.StandardLabel1.AutoSize = true;
            this.StandardLabel1.BackColor = System.Drawing.Color.Transparent;
            this.StandardLabel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.StandardLabel1.ForeColor = System.Drawing.Color.DimGray;
            this.StandardLabel1.Location = new System.Drawing.Point(87, 12);
            this.StandardLabel1.Name = "StandardLabel1";
            this.StandardLabel1.Size = new System.Drawing.Size(147, 21);
            this.StandardLabel1.TabIndex = 13;
            this.StandardLabel1.Text = "User Id                    :";
            // 
            // StandardLabel2
            // 
            this.StandardLabel2.AutoSize = true;
            this.StandardLabel2.BackColor = System.Drawing.Color.Transparent;
            this.StandardLabel2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.StandardLabel2.ForeColor = System.Drawing.Color.Black;
            this.StandardLabel2.Location = new System.Drawing.Point(363, -6);
            this.StandardLabel2.Name = "StandardLabel2";
            this.StandardLabel2.Size = new System.Drawing.Size(118, 18);
            this.StandardLabel2.TabIndex = 15;
            this.StandardLabel2.Text = "User Name             :";
            this.StandardLabel2.Visible = false;
            // 
            // StandardLabel5
            // 
            this.StandardLabel5.AutoSize = true;
            this.StandardLabel5.BackColor = System.Drawing.Color.Transparent;
            this.StandardLabel5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.StandardLabel5.ForeColor = System.Drawing.Color.DimGray;
            this.StandardLabel5.Location = new System.Drawing.Point(87, 82);
            this.StandardLabel5.Name = "StandardLabel5";
            this.StandardLabel5.Size = new System.Drawing.Size(145, 21);
            this.StandardLabel5.TabIndex = 20;
            this.StandardLabel5.Text = "User Password      :";
            // 
            // StandardLabel3
            // 
            this.StandardLabel3.AutoSize = true;
            this.StandardLabel3.BackColor = System.Drawing.Color.Transparent;
            this.StandardLabel3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.StandardLabel3.ForeColor = System.Drawing.Color.Black;
            this.StandardLabel3.Location = new System.Drawing.Point(208, -9);
            this.StandardLabel3.Name = "StandardLabel3";
            this.StandardLabel3.Size = new System.Drawing.Size(119, 18);
            this.StandardLabel3.TabIndex = 18;
            this.StandardLabel3.Text = "Log In as                  :";
            this.StandardLabel3.Visible = false;
            // 
            // AtiqsLogInUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.panel2);
            this.Name = "AtiqsLogInUserControl";
            this.Size = new System.Drawing.Size(491, 492);
            this.Load += new System.EventHandler(this.AtiqsLogInUserControl_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.Button btnClose;
        private StandardLabel StandardLabel5;
        private StandardLabel StandardLabel3;
        private StandardComboBox cboUserTypes;
        private StandardTextBox StandardTextBox1;
        private StandardLabel StandardLabel2;
        private StandardLabel StandardLabel1;
        public System.Windows.Forms.Panel pnlTop;
        public System.Windows.Forms.Button btnTopClose;
        public System.Windows.Forms.Label frmLabel;
        public System.Windows.Forms.Button btnTpClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private StandardLabel StandardLabel4;
        private System.Windows.Forms.ImageList logInImg;
        private System.Windows.Forms.ToolTip toolTip1;
        public StandardLabel lblMismatch;
        public System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.LinkLabel lnkResetPassword;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.TextBox txtModuleName;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel3;
    }
    }

