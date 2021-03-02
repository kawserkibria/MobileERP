namespace JA.Modulecontrolar
{
    partial class frmLogIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogIn));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnExit = new ColorButton.ColorButton();
            this.btnLogon = new ColorButton.ColorButton();
            this.btnCompany = new ColorButton.ColorButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uctxtPassword = new System.Windows.Forms.TextBox();
            this.uctxtLogIn = new System.Windows.Forms.TextBox();
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
            // btnExit
            // 
            this.btnExit.Active = true;
            this.btnExit.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnExit.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnExit.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnExit.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnExit.HoverColorA = System.Drawing.Color.MediumVioletRed;
            this.btnExit.HoverColorB = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(339, 241);
            this.btnExit.Name = "btnExit";
            this.btnExit.NormalBorderColor = System.Drawing.Color.LightBlue;
            this.btnExit.NormalColorA = System.Drawing.Color.Azure;
            this.btnExit.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnExit.Size = new System.Drawing.Size(224, 40);
            this.btnExit.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnExit.TabIndex = 19;
            this.btnExit.Text = "Exit";
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
            this.btnLogon.Location = new System.Drawing.Point(339, 195);
            this.btnLogon.Name = "btnLogon";
            this.btnLogon.NormalBorderColor = System.Drawing.Color.LightBlue;
            this.btnLogon.NormalColorA = System.Drawing.Color.Azure;
            this.btnLogon.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnLogon.Size = new System.Drawing.Size(224, 40);
            this.btnLogon.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnLogon.TabIndex = 13;
            this.btnLogon.Text = "Sign In";
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
            this.btnCompany.Location = new System.Drawing.Point(321, 173);
            this.btnCompany.Name = "btnCompany";
            this.btnCompany.NormalBorderColor = System.Drawing.Color.LightBlue;
            this.btnCompany.NormalColorA = System.Drawing.Color.Azure;
            this.btnCompany.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnCompany.Size = new System.Drawing.Size(13, 12);
            this.btnCompany.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnCompany.TabIndex = 18;
            this.btnCompany.Text = "Company";
            this.btnCompany.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(400, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(411, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "Log In:";
            // 
            // uctxtPassword
            // 
            this.uctxtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtPassword.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtPassword.Location = new System.Drawing.Point(339, 146);
            this.uctxtPassword.Name = "uctxtPassword";
            this.uctxtPassword.PasswordChar = '*';
            this.uctxtPassword.Size = new System.Drawing.Size(224, 23);
            this.uctxtPassword.TabIndex = 12;
            this.uctxtPassword.Text = "Deeplaid@420";
            // 
            // uctxtLogIn
            // 
            this.uctxtLogIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtLogIn.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtLogIn.Location = new System.Drawing.Point(339, 87);
            this.uctxtLogIn.Name = "uctxtLogIn";
            this.uctxtLogIn.Size = new System.Drawing.Size(224, 23);
            this.uctxtLogIn.TabIndex = 11;
            // 
            // frmLogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::JA.Modulecontrolar.Properties.Resources.login_page_final1;
            this.ClientSize = new System.Drawing.Size(588, 313);
            this.ControlBox = false;
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLogon);
            this.Controls.Add(this.btnCompany);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uctxtPassword);
            this.Controls.Add(this.uctxtLogIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmLogIn_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmLogIn_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private ColorButton.ColorButton btnExit;
        private ColorButton.ColorButton btnLogon;
        private ColorButton.ColorButton btnCompany;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uctxtPassword;
        private System.Windows.Forms.TextBox uctxtLogIn;

    }
}