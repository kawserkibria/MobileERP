namespace JA.Modulecontrolar.UI.DReport.Purchase.ParameterForms
{
    partial class frmRptBranchWiseReport
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
            this.btnVoucherReport = new ColorButton.ColorButton();
            this.btnPayables = new ColorButton.ColorButton();
            this.btnPurchaseRegister = new ColorButton.ColorButton();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(173, 9);
            this.frmLabel.Size = new System.Drawing.Size(0, 33);
            this.frmLabel.Text = "";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnPurchaseRegister);
            this.pnlMain.Controls.Add(this.btnPayables);
            this.pnlMain.Controls.Add(this.btnVoucherReport);
            this.pnlMain.Location = new System.Drawing.Point(0, -86);
            this.pnlMain.Size = new System.Drawing.Size(308, 318);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(311, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(-42, 182);
            this.btnEdit.Size = new System.Drawing.Size(10, 39);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(-58, 182);
            this.btnSave.Size = new System.Drawing.Size(10, 39);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(-26, 182);
            this.btnDelete.Size = new System.Drawing.Size(10, 39);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(-10, 182);
            this.btnNew.Size = new System.Drawing.Size(10, 39);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(36, 182);
            this.btnClose.Size = new System.Drawing.Size(10, 15);
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(6, 182);
            this.btnPrint.Size = new System.Drawing.Size(10, 15);
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 238);
            this.groupBox1.Size = new System.Drawing.Size(311, 25);
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnVoucherReport
            // 
            this.btnVoucherReport.Active = true;
            this.btnVoucherReport.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnVoucherReport.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnVoucherReport.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnVoucherReport.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnVoucherReport.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnVoucherReport.HoverColorB = System.Drawing.Color.White;
            this.btnVoucherReport.Location = new System.Drawing.Point(41, 160);
            this.btnVoucherReport.Name = "btnVoucherReport";
            this.btnVoucherReport.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnVoucherReport.NormalColorA = System.Drawing.Color.White;
            this.btnVoucherReport.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnVoucherReport.Size = new System.Drawing.Size(218, 40);
            this.btnVoucherReport.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnVoucherReport.TabIndex = 6;
            this.btnVoucherReport.Text = "Voucher Report";
            this.btnVoucherReport.Click += new System.EventHandler(this.btnVoucherReport_Click);
            // 
            // btnPayables
            // 
            this.btnPayables.Active = true;
            this.btnPayables.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnPayables.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnPayables.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnPayables.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnPayables.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnPayables.HoverColorB = System.Drawing.Color.White;
            this.btnPayables.Location = new System.Drawing.Point(41, 200);
            this.btnPayables.Name = "btnPayables";
            this.btnPayables.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnPayables.NormalColorA = System.Drawing.Color.White;
            this.btnPayables.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnPayables.Size = new System.Drawing.Size(218, 40);
            this.btnPayables.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnPayables.TabIndex = 7;
            this.btnPayables.Text = "Payables";
            this.btnPayables.Click += new System.EventHandler(this.btnPayables_Click);
            // 
            // btnPurchaseRegister
            // 
            this.btnPurchaseRegister.Active = true;
            this.btnPurchaseRegister.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnPurchaseRegister.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnPurchaseRegister.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnPurchaseRegister.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnPurchaseRegister.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnPurchaseRegister.HoverColorB = System.Drawing.Color.White;
            this.btnPurchaseRegister.Location = new System.Drawing.Point(41, 240);
            this.btnPurchaseRegister.Name = "btnPurchaseRegister";
            this.btnPurchaseRegister.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnPurchaseRegister.NormalColorA = System.Drawing.Color.White;
            this.btnPurchaseRegister.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnPurchaseRegister.Size = new System.Drawing.Size(218, 40);
            this.btnPurchaseRegister.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnPurchaseRegister.TabIndex = 8;
            this.btnPurchaseRegister.Text = "Purchase Register";
            this.btnPurchaseRegister.Click += new System.EventHandler(this.btnPurchaseRegister_Click);
            // 
            // frmRptBranchWiseReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(311, 263);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmRptBranchWiseReport";
            this.Load += new System.EventHandler(this.frmRptStoreLedger_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ColorButton.ColorButton btnPurchaseRegister;
        private ColorButton.ColorButton btnPayables;
        private ColorButton.ColorButton btnVoucherReport;

    }
}
