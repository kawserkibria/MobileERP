namespace JA.Modulecontrolar.UI.Accms.Forms
{
    partial class frmFinalAccounts
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
            this.btnBalanceSheet = new ColorButton.ColorButton();
            this.btnProfitLoss = new ColorButton.ColorButton();
            this.btnTrading = new ColorButton.ColorButton();
            this.btnCashFlow = new ColorButton.ColorButton();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmLabel.Location = new System.Drawing.Point(174, 9);
            this.frmLabel.Size = new System.Drawing.Size(126, 18);
            this.frmLabel.Text = "Final Accounts";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnBalanceSheet);
            this.pnlMain.Controls.Add(this.btnProfitLoss);
            this.pnlMain.Controls.Add(this.btnTrading);
            this.pnlMain.Controls.Add(this.btnCashFlow);
            this.pnlMain.Size = new System.Drawing.Size(454, 244);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(461, 45);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(57, 129);
            this.btnEdit.Size = new System.Drawing.Size(18, 10);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(34, 129);
            this.btnSave.Size = new System.Drawing.Size(17, 10);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(81, 129);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(12, 129);
            this.btnNew.Size = new System.Drawing.Size(16, 10);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(118, 120);
            this.btnClose.Size = new System.Drawing.Size(18, 19);
            this.btnClose.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(97, 126);
            this.btnPrint.Size = new System.Drawing.Size(15, 13);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 158);
            this.groupBox1.Size = new System.Drawing.Size(461, 25);
            // 
            // btnBalanceSheet
            // 
            this.btnBalanceSheet.Active = true;
            this.btnBalanceSheet.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnBalanceSheet.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnBalanceSheet.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnBalanceSheet.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnBalanceSheet.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnBalanceSheet.HoverColorB = System.Drawing.Color.White;
            this.btnBalanceSheet.Location = new System.Drawing.Point(230, 185);
            this.btnBalanceSheet.Name = "btnBalanceSheet";
            this.btnBalanceSheet.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnBalanceSheet.NormalColorA = System.Drawing.Color.White;
            this.btnBalanceSheet.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnBalanceSheet.Size = new System.Drawing.Size(218, 40);
            this.btnBalanceSheet.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnBalanceSheet.TabIndex = 13;
            this.btnBalanceSheet.Text = "Balance Sheet";
            this.btnBalanceSheet.Click += new System.EventHandler(this.btnBalanceSheet_Click);
            // 
            // btnProfitLoss
            // 
            this.btnProfitLoss.Active = true;
            this.btnProfitLoss.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnProfitLoss.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnProfitLoss.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnProfitLoss.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnProfitLoss.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnProfitLoss.HoverColorB = System.Drawing.Color.White;
            this.btnProfitLoss.Location = new System.Drawing.Point(230, 145);
            this.btnProfitLoss.Name = "btnProfitLoss";
            this.btnProfitLoss.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnProfitLoss.NormalColorA = System.Drawing.Color.White;
            this.btnProfitLoss.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnProfitLoss.Size = new System.Drawing.Size(218, 40);
            this.btnProfitLoss.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnProfitLoss.TabIndex = 12;
            this.btnProfitLoss.Text = "Profit & Loss";
            this.btnProfitLoss.Click += new System.EventHandler(this.btnProfitLoss_Click);
            // 
            // btnTrading
            // 
            this.btnTrading.Active = true;
            this.btnTrading.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnTrading.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnTrading.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnTrading.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnTrading.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnTrading.HoverColorB = System.Drawing.Color.White;
            this.btnTrading.Location = new System.Drawing.Point(9, 185);
            this.btnTrading.Name = "btnTrading";
            this.btnTrading.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnTrading.NormalColorA = System.Drawing.Color.White;
            this.btnTrading.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnTrading.Size = new System.Drawing.Size(218, 40);
            this.btnTrading.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnTrading.TabIndex = 11;
            this.btnTrading.Text = "Trading";
            this.btnTrading.Click += new System.EventHandler(this.btnTrading_Click);
            // 
            // btnCashFlow
            // 
            this.btnCashFlow.Active = true;
            this.btnCashFlow.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnCashFlow.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnCashFlow.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnCashFlow.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnCashFlow.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnCashFlow.HoverColorB = System.Drawing.Color.White;
            this.btnCashFlow.Location = new System.Drawing.Point(9, 144);
            this.btnCashFlow.Name = "btnCashFlow";
            this.btnCashFlow.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnCashFlow.NormalColorA = System.Drawing.Color.White;
            this.btnCashFlow.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnCashFlow.Size = new System.Drawing.Size(218, 40);
            this.btnCashFlow.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnCashFlow.TabIndex = 10;
            this.btnCashFlow.Text = "Cash Flow";
            this.btnCashFlow.Click += new System.EventHandler(this.btnCashFlow_Click);
            // 
            // frmFinalAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(461, 183);
            this.isEnterTabAllow = true;
            this.MinimizeBox = false;
            this.Name = "frmFinalAccounts";
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ColorButton.ColorButton btnBalanceSheet;
        private ColorButton.ColorButton btnProfitLoss;
        private ColorButton.ColorButton btnTrading;
        private ColorButton.ColorButton btnCashFlow;
    }
}
