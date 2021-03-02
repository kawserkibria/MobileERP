namespace ExtraReports
{
    partial class frmELogIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmELogIn));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.uctxtLogIn = new System.Windows.Forms.TextBox();
            this.uctxtPassword = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCompany = new ColorButton.ColorButton();
            this.btnLogon = new ColorButton.ColorButton();
            this.btnExit = new ColorButton.ColorButton();
            this.customPanel1 = new CSharpCustomPanelControl.CustomPanel();
            this.lblComName = new System.Windows.Forms.Label();
            this.customPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "key_fill-128.png");
            this.imageList1.Images.SetKeyName(1, "kwikdisk.png");
            this.imageList1.Images.SetKeyName(2, "Other-Power-Switch-User-Metro-icon.png");
            this.imageList1.Images.SetKeyName(3, "user-alt-128.png");
            this.imageList1.Images.SetKeyName(4, "user-icon.png");
            // 
            // uctxtLogIn
            // 
            this.uctxtLogIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtLogIn.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtLogIn.Location = new System.Drawing.Point(128, 78);
            this.uctxtLogIn.Name = "uctxtLogIn";
            this.uctxtLogIn.Size = new System.Drawing.Size(206, 23);
            this.uctxtLogIn.TabIndex = 0;
            // 
            // uctxtPassword
            // 
            this.uctxtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtPassword.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtPassword.Location = new System.Drawing.Point(128, 108);
            this.uctxtPassword.Name = "uctxtPassword";
            this.uctxtPassword.PasswordChar = '*';
            this.uctxtPassword.Size = new System.Drawing.Size(206, 23);
            this.uctxtPassword.TabIndex = 1;
            this.uctxtPassword.Text = "DeepLaid";
            // 
            // button1
            // 
            this.button1.ImageIndex = 3;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(335, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 26);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.ImageIndex = 0;
            this.button2.ImageList = this.imageList1;
            this.button2.Location = new System.Drawing.Point(335, 107);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(37, 26);
            this.button2.TabIndex = 5;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(63, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Log In:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Password:";
            // 
            // btnCompany
            // 
            this.btnCompany.Active = true;
            this.btnCompany.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnCompany.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnCompany.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnCompany.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnCompany.HoverColorA = System.Drawing.Color.MediumVioletRed;
            this.btnCompany.HoverColorB = System.Drawing.Color.White;
            this.btnCompany.Location = new System.Drawing.Point(76, 148);
            this.btnCompany.Name = "btnCompany";
            this.btnCompany.NormalBorderColor = System.Drawing.Color.LightBlue;
            this.btnCompany.NormalColorA = System.Drawing.Color.Azure;
            this.btnCompany.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnCompany.Size = new System.Drawing.Size(113, 40);
            this.btnCompany.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnCompany.TabIndex = 8;
            this.btnCompany.Text = "Company";
            this.btnCompany.Click += new System.EventHandler(this.btnCompany_Click);
            // 
            // btnLogon
            // 
            this.btnLogon.Active = true;
            this.btnLogon.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnLogon.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogon.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnLogon.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnLogon.HoverColorA = System.Drawing.Color.MediumVioletRed;
            this.btnLogon.HoverColorB = System.Drawing.Color.White;
            this.btnLogon.Location = new System.Drawing.Point(189, 148);
            this.btnLogon.Name = "btnLogon";
            this.btnLogon.NormalBorderColor = System.Drawing.Color.LightBlue;
            this.btnLogon.NormalColorA = System.Drawing.Color.Azure;
            this.btnLogon.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnLogon.Size = new System.Drawing.Size(78, 40);
            this.btnLogon.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnLogon.TabIndex = 2;
            this.btnLogon.Text = "Log In";
            this.btnLogon.Click += new System.EventHandler(this.btnLogon_Click_1);
            // 
            // btnExit
            // 
            this.btnExit.Active = true;
            this.btnExit.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnExit.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnExit.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnExit.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnExit.HoverColorA = System.Drawing.Color.MediumVioletRed;
            this.btnExit.HoverColorB = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(266, 148);
            this.btnExit.Name = "btnExit";
            this.btnExit.NormalBorderColor = System.Drawing.Color.LightBlue;
            this.btnExit.NormalColorA = System.Drawing.Color.Azure;
            this.btnExit.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnExit.Size = new System.Drawing.Size(81, 40);
            this.btnExit.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
            // 
            // customPanel1
            // 
            this.customPanel1.AutoScroll = true;
            this.customPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.customPanel1.BackColor2 = System.Drawing.Color.LightGoldenrodYellow;
            this.customPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.customPanel1.BorderColor = System.Drawing.Color.Silver;
            this.customPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel1.BorderWidth = 7;
            this.customPanel1.Controls.Add(this.lblComName);
            this.customPanel1.Controls.Add(this.btnExit);
            this.customPanel1.Controls.Add(this.btnLogon);
            this.customPanel1.Controls.Add(this.btnCompany);
            this.customPanel1.Controls.Add(this.label2);
            this.customPanel1.Controls.Add(this.label1);
            this.customPanel1.Controls.Add(this.button2);
            this.customPanel1.Controls.Add(this.button1);
            this.customPanel1.Controls.Add(this.uctxtPassword);
            this.customPanel1.Controls.Add(this.uctxtLogIn);
            this.customPanel1.Curvature = 40;
            this.customPanel1.Location = new System.Drawing.Point(2, 1);
            this.customPanel1.Name = "customPanel1";
            this.customPanel1.Size = new System.Drawing.Size(433, 197);
            this.customPanel1.TabIndex = 1;
            this.customPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.customPanel1_Paint);
            // 
            // lblComName
            // 
            this.lblComName.AutoSize = true;
            this.lblComName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblComName.Location = new System.Drawing.Point(18, 32);
            this.lblComName.Name = "lblComName";
            this.lblComName.Size = new System.Drawing.Size(0, 16);
            this.lblComName.TabIndex = 11;
            // 
            // frmELogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(436, 197);
            this.Controls.Add(this.customPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmELogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Extra Featrure";
            this.Load += new System.EventHandler(this.frmLogIn_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmLogIn_Paint);
            this.customPanel1.ResumeLayout(false);
            this.customPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox uctxtLogIn;
        private System.Windows.Forms.TextBox uctxtPassword;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ColorButton.ColorButton btnCompany;
        private ColorButton.ColorButton btnLogon;
        private ColorButton.ColorButton btnExit;
        private CSharpCustomPanelControl.CustomPanel customPanel1;
        private System.Windows.Forms.Label lblComName;

    }
}