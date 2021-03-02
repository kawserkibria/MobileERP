namespace JA.Modulecontrolar.UI.Master.Accounts
{
    partial class frmCostCenterMain
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
            this.btnRptCostCenterWise = new ColorButton.ColorButton();
            this.btnRptCostCategoryWise = new ColorButton.ColorButton();
            this.btnRptLedgerWise = new ColorButton.ColorButton();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(135, 8);
            this.frmLabel.Size = new System.Drawing.Size(153, 33);
            this.frmLabel.Text = "Cost Center";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnRptCostCenterWise);
            this.pnlMain.Controls.Add(this.btnRptCostCategoryWise);
            this.pnlMain.Controls.Add(this.btnRptLedgerWise);
            this.pnlMain.Location = new System.Drawing.Point(0, -91);
            this.pnlMain.Size = new System.Drawing.Size(450, 258);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(450, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(93, 129);
            this.btnEdit.Size = new System.Drawing.Size(12, 20);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(77, 130);
            this.btnSave.Size = new System.Drawing.Size(10, 20);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(111, 130);
            this.btnDelete.Size = new System.Drawing.Size(10, 16);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(12, 130);
            this.btnNew.Size = new System.Drawing.Size(10, 13);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(61, 130);
            this.btnClose.Size = new System.Drawing.Size(10, 19);
            this.btnClose.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(135, 129);
            this.btnPrint.Size = new System.Drawing.Size(10, 15);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 170);
            this.groupBox1.Size = new System.Drawing.Size(450, 25);
            // 
            // btnRptCostCenterWise
            // 
            this.btnRptCostCenterWise.Active = true;
            this.btnRptCostCenterWise.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnRptCostCenterWise.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRptCostCenterWise.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnRptCostCenterWise.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnRptCostCenterWise.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnRptCostCenterWise.HoverColorB = System.Drawing.Color.White;
            this.btnRptCostCenterWise.Location = new System.Drawing.Point(227, 154);
            this.btnRptCostCenterWise.Name = "btnRptCostCenterWise";
            this.btnRptCostCenterWise.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnRptCostCenterWise.NormalColorA = System.Drawing.Color.White;
            this.btnRptCostCenterWise.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnRptCostCenterWise.Size = new System.Drawing.Size(218, 40);
            this.btnRptCostCenterWise.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnRptCostCenterWise.TabIndex = 10;
            this.btnRptCostCenterWise.Text = "Cost Center Wise";
            this.btnRptCostCenterWise.Click += new System.EventHandler(this.btnRptCostCenterWise_Click);
            // 
            // btnRptCostCategoryWise
            // 
            this.btnRptCostCategoryWise.Active = true;
            this.btnRptCostCategoryWise.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnRptCostCategoryWise.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRptCostCategoryWise.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnRptCostCategoryWise.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnRptCostCategoryWise.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnRptCostCategoryWise.HoverColorB = System.Drawing.Color.White;
            this.btnRptCostCategoryWise.Location = new System.Drawing.Point(6, 194);
            this.btnRptCostCategoryWise.Name = "btnRptCostCategoryWise";
            this.btnRptCostCategoryWise.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnRptCostCategoryWise.NormalColorA = System.Drawing.Color.White;
            this.btnRptCostCategoryWise.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnRptCostCategoryWise.Size = new System.Drawing.Size(218, 40);
            this.btnRptCostCategoryWise.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnRptCostCategoryWise.TabIndex = 9;
            this.btnRptCostCategoryWise.Text = "Cost Category Wise";
            this.btnRptCostCategoryWise.Click += new System.EventHandler(this.btnRptCostCategoryWise_Click);
            // 
            // btnRptLedgerWise
            // 
            this.btnRptLedgerWise.Active = true;
            this.btnRptLedgerWise.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnRptLedgerWise.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRptLedgerWise.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnRptLedgerWise.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnRptLedgerWise.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnRptLedgerWise.HoverColorB = System.Drawing.Color.White;
            this.btnRptLedgerWise.Location = new System.Drawing.Point(6, 154);
            this.btnRptLedgerWise.Name = "btnRptLedgerWise";
            this.btnRptLedgerWise.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnRptLedgerWise.NormalColorA = System.Drawing.Color.White;
            this.btnRptLedgerWise.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnRptLedgerWise.Size = new System.Drawing.Size(218, 40);
            this.btnRptLedgerWise.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnRptLedgerWise.TabIndex = 8;
            this.btnRptLedgerWise.Text = "Ledger Wise";
            this.btnRptLedgerWise.Click += new System.EventHandler(this.btnRptLedgerWise_Click);
            // 
            // frmCostCenterMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(450, 195);
            this.isEnterTabAllow = true;
            this.MinimizeBox = false;
            this.Name = "frmCostCenterMain";
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ColorButton.ColorButton btnRptCostCenterWise;
        private ColorButton.ColorButton btnRptCostCategoryWise;
        private ColorButton.ColorButton btnRptLedgerWise;
    }
}
