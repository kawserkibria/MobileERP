namespace JA.Modulecontrolar.UI.Sales.Forms
{
    partial class frmCreditLimitMaster
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
            this.btnGraceMonth = new ColorButton.ColorButton();
            this.btnCreditLimitNew = new ColorButton.ColorButton();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmLabel.Location = new System.Drawing.Point(134, 7);
            this.frmLabel.Size = new System.Drawing.Size(192, 23);
            this.frmLabel.Text = "Credit Limit Master";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnGraceMonth);
            this.pnlMain.Controls.Add(this.btnCreditLimitNew);
            this.pnlMain.Size = new System.Drawing.Size(450, 246);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(454, 42);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(92, 134);
            this.btnEdit.Size = new System.Drawing.Size(10, 10);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(57, 131);
            this.btnSave.Size = new System.Drawing.Size(10, 10);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(109, 126);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(7, 131);
            this.btnNew.Size = new System.Drawing.Size(10, 10);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(195, 133);
            this.btnClose.Size = new System.Drawing.Size(10, 10);
            this.btnClose.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(140, 134);
            this.btnPrint.Size = new System.Drawing.Size(10, 10);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 161);
            this.groupBox1.Size = new System.Drawing.Size(454, 25);
            // 
            // btnGraceMonth
            // 
            this.btnGraceMonth.Active = true;
            this.btnGraceMonth.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnGraceMonth.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGraceMonth.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnGraceMonth.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnGraceMonth.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnGraceMonth.HoverColorB = System.Drawing.Color.White;
            this.btnGraceMonth.Location = new System.Drawing.Point(6, 134);
            this.btnGraceMonth.Name = "btnGraceMonth";
            this.btnGraceMonth.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnGraceMonth.NormalColorA = System.Drawing.Color.White;
            this.btnGraceMonth.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnGraceMonth.Size = new System.Drawing.Size(20, 19);
            this.btnGraceMonth.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnGraceMonth.TabIndex = 44;
            this.btnGraceMonth.Text = "Grace Month";
            this.btnGraceMonth.Visible = false;
            this.btnGraceMonth.Click += new System.EventHandler(this.btnCollectionMonth_Click);
            // 
            // btnCreditLimitNew
            // 
            this.btnCreditLimitNew.Active = true;
            this.btnCreditLimitNew.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnCreditLimitNew.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreditLimitNew.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnCreditLimitNew.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnCreditLimitNew.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnCreditLimitNew.HoverColorB = System.Drawing.Color.White;
            this.btnCreditLimitNew.Location = new System.Drawing.Point(91, 154);
            this.btnCreditLimitNew.Name = "btnCreditLimitNew";
            this.btnCreditLimitNew.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnCreditLimitNew.NormalColorA = System.Drawing.Color.White;
            this.btnCreditLimitNew.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnCreditLimitNew.Size = new System.Drawing.Size(269, 40);
            this.btnCreditLimitNew.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnCreditLimitNew.TabIndex = 43;
            this.btnCreditLimitNew.Text = "Credit Limit";
            this.btnCreditLimitNew.Click += new System.EventHandler(this.btnLedgerConfiguration_Click);
            // 
            // frmCreditLimitMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(454, 186);
            this.isEnterTabAllow = true;
            this.MinimizeBox = false;
            this.Name = "frmCreditLimitMaster";
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ColorButton.ColorButton btnGraceMonth;
        private ColorButton.ColorButton btnCreditLimitNew;

    }
}
