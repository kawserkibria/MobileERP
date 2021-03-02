namespace JA.Modulecontrolar.UI.DReport.Sales.ParameterForms
{
    partial class frmRptSpecialPartyReport
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
            this.btnSalesStatementAmount = new ColorButton.ColorButton();
            this.btnSalesStatementProduct = new ColorButton.ColorButton();
            this.btnFinalStatement = new ColorButton.ColorButton();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(119, 9);
            this.frmLabel.Size = new System.Drawing.Size(0, 33);
            this.frmLabel.Text = "";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnFinalStatement);
            this.pnlMain.Controls.Add(this.btnSalesStatementProduct);
            this.pnlMain.Controls.Add(this.btnSalesStatementAmount);
            this.pnlMain.Location = new System.Drawing.Point(0, -86);
            this.pnlMain.Size = new System.Drawing.Size(485, 436);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(487, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(54, 350);
            this.btnEdit.Size = new System.Drawing.Size(10, 10);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 350);
            this.btnSave.Size = new System.Drawing.Size(10, 10);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.ImageIndex = -1;
            this.btnDelete.ImageKey = "(none)";
            this.btnDelete.Location = new System.Drawing.Point(136, 349);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            this.btnDelete.Text = "";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(96, 350);
            this.btnNew.Size = new System.Drawing.Size(10, 10);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.ImageIndex = -1;
            this.btnClose.ImageKey = "(none)";
            this.btnClose.Location = new System.Drawing.Point(209, 349);
            this.btnClose.Size = new System.Drawing.Size(10, 10);
            this.btnClose.Text = "";
            this.btnClose.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.ImageIndex = -1;
            this.btnPrint.Location = new System.Drawing.Point(193, 349);
            this.btnPrint.Size = new System.Drawing.Size(10, 10);
            this.btnPrint.Text = "";
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 361);
            this.groupBox1.Size = new System.Drawing.Size(487, 25);
            // 
            // btnSalesStatementAmount
            // 
            this.btnSalesStatementAmount.Active = true;
            this.btnSalesStatementAmount.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnSalesStatementAmount.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalesStatementAmount.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnSalesStatementAmount.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnSalesStatementAmount.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnSalesStatementAmount.HoverColorB = System.Drawing.Color.White;
            this.btnSalesStatementAmount.Location = new System.Drawing.Point(106, 186);
            this.btnSalesStatementAmount.Name = "btnSalesStatementAmount";
            this.btnSalesStatementAmount.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnSalesStatementAmount.NormalColorA = System.Drawing.Color.White;
            this.btnSalesStatementAmount.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnSalesStatementAmount.Size = new System.Drawing.Size(262, 40);
            this.btnSalesStatementAmount.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnSalesStatementAmount.TabIndex = 29;
            this.btnSalesStatementAmount.Text = "Sales Statement (Amount)";
            this.btnSalesStatementAmount.Click += new System.EventHandler(this.btnSalesStatementAmount_Click);
            // 
            // btnSalesStatementProduct
            // 
            this.btnSalesStatementProduct.Active = true;
            this.btnSalesStatementProduct.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnSalesStatementProduct.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalesStatementProduct.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnSalesStatementProduct.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnSalesStatementProduct.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnSalesStatementProduct.HoverColorB = System.Drawing.Color.White;
            this.btnSalesStatementProduct.Location = new System.Drawing.Point(106, 232);
            this.btnSalesStatementProduct.Name = "btnSalesStatementProduct";
            this.btnSalesStatementProduct.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnSalesStatementProduct.NormalColorA = System.Drawing.Color.White;
            this.btnSalesStatementProduct.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnSalesStatementProduct.Size = new System.Drawing.Size(262, 40);
            this.btnSalesStatementProduct.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnSalesStatementProduct.TabIndex = 30;
            this.btnSalesStatementProduct.Text = "Sales Statement (Product)";
            this.btnSalesStatementProduct.Click += new System.EventHandler(this.btnSalesStatementProduct_Click);
            // 
            // btnFinalStatement
            // 
            this.btnFinalStatement.Active = true;
            this.btnFinalStatement.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnFinalStatement.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalStatement.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnFinalStatement.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnFinalStatement.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnFinalStatement.HoverColorB = System.Drawing.Color.White;
            this.btnFinalStatement.Location = new System.Drawing.Point(106, 279);
            this.btnFinalStatement.Name = "btnFinalStatement";
            this.btnFinalStatement.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnFinalStatement.NormalColorA = System.Drawing.Color.White;
            this.btnFinalStatement.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnFinalStatement.Size = new System.Drawing.Size(262, 40);
            this.btnFinalStatement.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnFinalStatement.TabIndex = 31;
            this.btnFinalStatement.Text = "Final Statement";
            this.btnFinalStatement.Click += new System.EventHandler(this.btnFinalStatement_Click);
            // 
            // frmRptSpecialPartyReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(487, 386);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmRptSpecialPartyReport";
            this.Load += new System.EventHandler(this.frmRptSpecialPartyReport_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ColorButton.ColorButton btnFinalStatement;
        private ColorButton.ColorButton btnSalesStatementProduct;
        private ColorButton.ColorButton btnSalesStatementAmount;


    }
}
