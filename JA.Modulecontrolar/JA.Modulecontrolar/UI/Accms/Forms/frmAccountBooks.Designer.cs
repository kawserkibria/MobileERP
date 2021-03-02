namespace JA.Modulecontrolar.UI.Accms.Forms
{
    partial class frmAccountBooks
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
            this.btnVoucherReports = new ColorButton.ColorButton();
            this.btnLedger = new ColorButton.ColorButton();
            this.btnDayBook = new ColorButton.ColorButton();
            this.btnCashBankBook = new ColorButton.ColorButton();
            this.btnGroupSummary = new ColorButton.ColorButton();
            this.btnRptHLPFStatement = new ColorButton.ColorButton();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmLabel.Location = new System.Drawing.Point(148, 7);
            this.frmLabel.Size = new System.Drawing.Size(151, 23);
            this.frmLabel.Text = "Account Books";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnRptHLPFStatement);
            this.pnlMain.Controls.Add(this.btnGroupSummary);
            this.pnlMain.Controls.Add(this.btnCashBankBook);
            this.pnlMain.Controls.Add(this.btnDayBook);
            this.pnlMain.Controls.Add(this.btnLedger);
            this.pnlMain.Controls.Add(this.btnVoucherReports);
            this.pnlMain.Size = new System.Drawing.Size(451, 279);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(454, 42);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(92, 183);
            this.btnEdit.Size = new System.Drawing.Size(10, 0);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(57, 192);
            this.btnSave.Size = new System.Drawing.Size(10, 0);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(109, 178);
            this.btnDelete.Size = new System.Drawing.Size(0, 10);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(7, 162);
            this.btnNew.Size = new System.Drawing.Size(10, 5);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(195, 176);
            this.btnClose.Size = new System.Drawing.Size(3, 12);
            this.btnClose.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(140, 186);
            this.btnPrint.Size = new System.Drawing.Size(1, 0);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 192);
            this.groupBox1.Size = new System.Drawing.Size(454, 25);
            // 
            // btnVoucherReports
            // 
            this.btnVoucherReports.Active = true;
            this.btnVoucherReports.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnVoucherReports.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoucherReports.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnVoucherReports.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnVoucherReports.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnVoucherReports.HoverColorB = System.Drawing.Color.White;
            this.btnVoucherReports.Location = new System.Drawing.Point(7, 140);
            this.btnVoucherReports.Name = "btnVoucherReports";
            this.btnVoucherReports.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnVoucherReports.NormalColorA = System.Drawing.Color.White;
            this.btnVoucherReports.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnVoucherReports.Size = new System.Drawing.Size(218, 40);
            this.btnVoucherReports.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnVoucherReports.TabIndex = 5;
            this.btnVoucherReports.Text = "Voucher Reports";
            this.btnVoucherReports.Click += new System.EventHandler(this.btnVoucherReports_Click);
            // 
            // btnLedger
            // 
            this.btnLedger.Active = true;
            this.btnLedger.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnLedger.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLedger.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnLedger.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnLedger.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnLedger.HoverColorB = System.Drawing.Color.White;
            this.btnLedger.Location = new System.Drawing.Point(7, 181);
            this.btnLedger.Name = "btnLedger";
            this.btnLedger.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnLedger.NormalColorA = System.Drawing.Color.White;
            this.btnLedger.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnLedger.Size = new System.Drawing.Size(218, 40);
            this.btnLedger.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnLedger.TabIndex = 6;
            this.btnLedger.Text = "Ledger";
            this.btnLedger.Click += new System.EventHandler(this.btnLedger_Click);
            // 
            // btnDayBook
            // 
            this.btnDayBook.Active = true;
            this.btnDayBook.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnDayBook.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDayBook.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnDayBook.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnDayBook.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnDayBook.HoverColorB = System.Drawing.Color.White;
            this.btnDayBook.Location = new System.Drawing.Point(7, 221);
            this.btnDayBook.Name = "btnDayBook";
            this.btnDayBook.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnDayBook.NormalColorA = System.Drawing.Color.White;
            this.btnDayBook.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnDayBook.Size = new System.Drawing.Size(218, 40);
            this.btnDayBook.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnDayBook.TabIndex = 7;
            this.btnDayBook.Text = "Day Book";
            this.btnDayBook.Click += new System.EventHandler(this.btnDayBook_Click);
            // 
            // btnCashBankBook
            // 
            this.btnCashBankBook.Active = true;
            this.btnCashBankBook.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnCashBankBook.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCashBankBook.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnCashBankBook.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnCashBankBook.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnCashBankBook.HoverColorB = System.Drawing.Color.White;
            this.btnCashBankBook.Location = new System.Drawing.Point(227, 140);
            this.btnCashBankBook.Name = "btnCashBankBook";
            this.btnCashBankBook.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnCashBankBook.NormalColorA = System.Drawing.Color.White;
            this.btnCashBankBook.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnCashBankBook.Size = new System.Drawing.Size(218, 40);
            this.btnCashBankBook.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnCashBankBook.TabIndex = 8;
            this.btnCashBankBook.Text = "Cash & Bank Book";
            this.btnCashBankBook.Click += new System.EventHandler(this.btnCashBankBook_Click);
            // 
            // btnGroupSummary
            // 
            this.btnGroupSummary.Active = true;
            this.btnGroupSummary.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnGroupSummary.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGroupSummary.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnGroupSummary.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnGroupSummary.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnGroupSummary.HoverColorB = System.Drawing.Color.White;
            this.btnGroupSummary.Location = new System.Drawing.Point(227, 181);
            this.btnGroupSummary.Name = "btnGroupSummary";
            this.btnGroupSummary.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnGroupSummary.NormalColorA = System.Drawing.Color.White;
            this.btnGroupSummary.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnGroupSummary.Size = new System.Drawing.Size(218, 40);
            this.btnGroupSummary.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnGroupSummary.TabIndex = 9;
            this.btnGroupSummary.Text = "Group Summary";
            this.btnGroupSummary.Click += new System.EventHandler(this.btnGroupSummary_Click);
            // 
            // btnRptHLPFStatement
            // 
            this.btnRptHLPFStatement.Active = true;
            this.btnRptHLPFStatement.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnRptHLPFStatement.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRptHLPFStatement.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnRptHLPFStatement.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnRptHLPFStatement.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnRptHLPFStatement.HoverColorB = System.Drawing.Color.White;
            this.btnRptHLPFStatement.Location = new System.Drawing.Point(228, 221);
            this.btnRptHLPFStatement.Name = "btnRptHLPFStatement";
            this.btnRptHLPFStatement.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnRptHLPFStatement.NormalColorA = System.Drawing.Color.White;
            this.btnRptHLPFStatement.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnRptHLPFStatement.Size = new System.Drawing.Size(218, 40);
            this.btnRptHLPFStatement.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnRptHLPFStatement.TabIndex = 10;
            this.btnRptHLPFStatement.Text = "HL/PF Statement";
            this.btnRptHLPFStatement.Click += new System.EventHandler(this.btnRptHLPFStatement_Click);
            // 
            // frmAccountBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(454, 217);
            this.isEnterTabAllow = true;
            this.MinimizeBox = false;
            this.Name = "frmAccountBooks";
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ColorButton.ColorButton btnDayBook;
        private ColorButton.ColorButton btnLedger;
        private ColorButton.ColorButton btnVoucherReports;
        private ColorButton.ColorButton btnGroupSummary;
        private ColorButton.ColorButton btnCashBankBook;
        private ColorButton.ColorButton btnRptHLPFStatement;
    }
}
