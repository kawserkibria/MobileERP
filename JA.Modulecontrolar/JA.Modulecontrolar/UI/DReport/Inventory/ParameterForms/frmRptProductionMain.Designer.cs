namespace JA.Modulecontrolar.UI.DReport.Inventory.ParameterForms
{
    partial class frmRptProductionMain
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
            this.btnRptMonthlyProduction = new ColorButton.ColorButton();
            this.btnLocationWiseConsumtion = new ColorButton.ColorButton();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(73, 9);
            this.frmLabel.Size = new System.Drawing.Size(291, 33);
            this.frmLabel.Text = "Production Information";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnLocationWiseConsumtion);
            this.pnlMain.Controls.Add(this.btnRptMonthlyProduction);
            this.pnlMain.Location = new System.Drawing.Point(0, -86);
            this.pnlMain.Size = new System.Drawing.Size(455, 242);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(455, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(114, 141);
            this.btnEdit.Size = new System.Drawing.Size(9, 0);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(-2, 133);
            this.btnSave.Size = new System.Drawing.Size(0, 10);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(36, 141);
            this.btnDelete.Size = new System.Drawing.Size(10, 0);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(30, 129);
            this.btnNew.Size = new System.Drawing.Size(10, 0);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(319, 135);
            this.btnClose.Size = new System.Drawing.Size(10, 1);
            this.btnClose.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(183, 133);
            this.btnPrint.Size = new System.Drawing.Size(9, 0);
            this.btnPrint.Text = "Preview";
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 157);
            this.groupBox1.Size = new System.Drawing.Size(455, 25);
            // 
            // btnRptMonthlyProduction
            // 
            this.btnRptMonthlyProduction.Active = true;
            this.btnRptMonthlyProduction.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnRptMonthlyProduction.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRptMonthlyProduction.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnRptMonthlyProduction.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnRptMonthlyProduction.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnRptMonthlyProduction.HoverColorB = System.Drawing.Color.White;
            this.btnRptMonthlyProduction.Location = new System.Drawing.Point(60, 151);
            this.btnRptMonthlyProduction.Name = "btnRptMonthlyProduction";
            this.btnRptMonthlyProduction.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnRptMonthlyProduction.NormalColorA = System.Drawing.Color.White;
            this.btnRptMonthlyProduction.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnRptMonthlyProduction.Size = new System.Drawing.Size(306, 38);
            this.btnRptMonthlyProduction.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnRptMonthlyProduction.TabIndex = 1;
            this.btnRptMonthlyProduction.Text = "Production Statement";
            this.btnRptMonthlyProduction.Click += new System.EventHandler(this.btnRptMonthlyProduction_Click);
            // 
            // btnLocationWiseConsumtion
            // 
            this.btnLocationWiseConsumtion.Active = true;
            this.btnLocationWiseConsumtion.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnLocationWiseConsumtion.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocationWiseConsumtion.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnLocationWiseConsumtion.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnLocationWiseConsumtion.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnLocationWiseConsumtion.HoverColorB = System.Drawing.Color.White;
            this.btnLocationWiseConsumtion.Location = new System.Drawing.Point(62, 190);
            this.btnLocationWiseConsumtion.Name = "btnLocationWiseConsumtion";
            this.btnLocationWiseConsumtion.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnLocationWiseConsumtion.NormalColorA = System.Drawing.Color.White;
            this.btnLocationWiseConsumtion.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnLocationWiseConsumtion.Size = new System.Drawing.Size(304, 40);
            this.btnLocationWiseConsumtion.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnLocationWiseConsumtion.TabIndex = 9;
            this.btnLocationWiseConsumtion.Text = "Location Wise Consumption";
            this.btnLocationWiseConsumtion.Click += new System.EventHandler(this.btnLocationWiseConsumtion_Click);
            // 
            // frmRptProductionMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(455, 182);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmRptProductionMain";
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ColorButton.ColorButton btnRptMonthlyProduction;
        private ColorButton.ColorButton btnLocationWiseConsumtion;


    }
}
