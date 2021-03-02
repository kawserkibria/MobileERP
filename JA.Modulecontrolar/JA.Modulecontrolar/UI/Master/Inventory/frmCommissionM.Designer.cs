namespace JA.Modulecontrolar.UI.Master
{
    partial class frmCommissionM
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
            this.btnGroupConfiguration = new ColorButton.ColorButton();
            this.btnCommissionConfig = new ColorButton.ColorButton();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(128, 8);
            this.frmLabel.Size = new System.Drawing.Size(234, 33);
            this.frmLabel.Text = "Commission Setup";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnCommissionConfig);
            this.pnlMain.Controls.Add(this.btnGroupConfiguration);
            this.pnlMain.Size = new System.Drawing.Size(450, 272);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(452, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(39, 108);
            this.btnEdit.Size = new System.Drawing.Size(10, 10);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(23, 140);
            this.btnSave.Size = new System.Drawing.Size(10, 10);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(39, 124);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(5, 140);
            this.btnNew.Size = new System.Drawing.Size(10, 10);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(39, 92);
            this.btnClose.Size = new System.Drawing.Size(10, 10);
            this.btnClose.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(39, 140);
            this.btnPrint.Size = new System.Drawing.Size(10, 10);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 187);
            this.groupBox1.Size = new System.Drawing.Size(452, 25);
            // 
            // btnGroupConfiguration
            // 
            this.btnGroupConfiguration.Active = true;
            this.btnGroupConfiguration.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnGroupConfiguration.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGroupConfiguration.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnGroupConfiguration.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnGroupConfiguration.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnGroupConfiguration.HoverColorB = System.Drawing.Color.White;
            this.btnGroupConfiguration.Location = new System.Drawing.Point(99, 166);
            this.btnGroupConfiguration.Name = "btnGroupConfiguration";
            this.btnGroupConfiguration.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnGroupConfiguration.NormalColorA = System.Drawing.Color.White;
            this.btnGroupConfiguration.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnGroupConfiguration.Size = new System.Drawing.Size(266, 36);
            this.btnGroupConfiguration.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnGroupConfiguration.TabIndex = 1;
            this.btnGroupConfiguration.Text = "Commission Group";
            this.btnGroupConfiguration.Click += new System.EventHandler(this.btnGroupConfiguration_Click);
            // 
            // btnCommissionConfig
            // 
            this.btnCommissionConfig.Active = true;
            this.btnCommissionConfig.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnCommissionConfig.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCommissionConfig.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnCommissionConfig.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnCommissionConfig.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnCommissionConfig.HoverColorB = System.Drawing.Color.White;
            this.btnCommissionConfig.Location = new System.Drawing.Point(99, 205);
            this.btnCommissionConfig.Name = "btnCommissionConfig";
            this.btnCommissionConfig.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnCommissionConfig.NormalColorA = System.Drawing.Color.White;
            this.btnCommissionConfig.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnCommissionConfig.Size = new System.Drawing.Size(266, 34);
            this.btnCommissionConfig.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnCommissionConfig.TabIndex = 5;
            this.btnCommissionConfig.Text = "Commission Config.";
            this.btnCommissionConfig.Click += new System.EventHandler(this.btnCommissionConfig_Click);
            // 
            // frmCommissionM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(452, 212);
            this.isEnterTabAllow = true;
            this.MinimizeBox = false;
            this.Name = "frmCommissionM";
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ColorButton.ColorButton btnGroupConfiguration;
        private ColorButton.ColorButton btnCommissionConfig;
    }
}
