namespace JA.Modulecontrolar.UI.DReport.Sales.ParameterForms
{
    partial class frmRptProductAnalysis
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
            this.btnProductWiseAnalysis = new ColorButton.ColorButton();
            this.btnProductSalesAnalysis = new ColorButton.ColorButton();
            this.btnYearlyProductSales = new ColorButton.ColorButton();
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
            this.pnlMain.Controls.Add(this.btnYearlyProductSales);
            this.pnlMain.Controls.Add(this.btnProductSalesAnalysis);
            this.pnlMain.Controls.Add(this.btnProductWiseAnalysis);
            this.pnlMain.Location = new System.Drawing.Point(0, -86);
            this.pnlMain.Size = new System.Drawing.Size(485, 338);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(487, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(54, 227);
            this.btnEdit.Size = new System.Drawing.Size(10, 10);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 227);
            this.btnSave.Size = new System.Drawing.Size(10, 10);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.ImageIndex = -1;
            this.btnDelete.ImageKey = "(none)";
            this.btnDelete.Location = new System.Drawing.Point(136, 226);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            this.btnDelete.Text = "";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(96, 227);
            this.btnNew.Size = new System.Drawing.Size(10, 10);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.ImageIndex = -1;
            this.btnClose.ImageKey = "(none)";
            this.btnClose.Location = new System.Drawing.Point(209, 226);
            this.btnClose.Size = new System.Drawing.Size(10, 10);
            this.btnClose.Text = "";
            this.btnClose.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.ImageIndex = -1;
            this.btnPrint.Location = new System.Drawing.Point(193, 226);
            this.btnPrint.Size = new System.Drawing.Size(10, 10);
            this.btnPrint.Text = "";
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 256);
            this.groupBox1.Size = new System.Drawing.Size(487, 25);
            // 
            // btnProductWiseAnalysis
            // 
            this.btnProductWiseAnalysis.Active = true;
            this.btnProductWiseAnalysis.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnProductWiseAnalysis.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductWiseAnalysis.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnProductWiseAnalysis.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnProductWiseAnalysis.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnProductWiseAnalysis.HoverColorB = System.Drawing.Color.White;
            this.btnProductWiseAnalysis.Location = new System.Drawing.Point(69, 161);
            this.btnProductWiseAnalysis.Name = "btnProductWiseAnalysis";
            this.btnProductWiseAnalysis.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnProductWiseAnalysis.NormalColorA = System.Drawing.Color.White;
            this.btnProductWiseAnalysis.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnProductWiseAnalysis.Size = new System.Drawing.Size(340, 40);
            this.btnProductWiseAnalysis.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnProductWiseAnalysis.TabIndex = 29;
            this.btnProductWiseAnalysis.Text = "Product  Wise Analysis";
            this.btnProductWiseAnalysis.Click += new System.EventHandler(this.btnSalesTarget_Click);
            // 
            // btnProductSalesAnalysis
            // 
            this.btnProductSalesAnalysis.Active = true;
            this.btnProductSalesAnalysis.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnProductSalesAnalysis.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductSalesAnalysis.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnProductSalesAnalysis.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnProductSalesAnalysis.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnProductSalesAnalysis.HoverColorB = System.Drawing.Color.White;
            this.btnProductSalesAnalysis.Location = new System.Drawing.Point(69, 204);
            this.btnProductSalesAnalysis.Name = "btnProductSalesAnalysis";
            this.btnProductSalesAnalysis.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnProductSalesAnalysis.NormalColorA = System.Drawing.Color.White;
            this.btnProductSalesAnalysis.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnProductSalesAnalysis.Size = new System.Drawing.Size(340, 40);
            this.btnProductSalesAnalysis.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnProductSalesAnalysis.TabIndex = 30;
            this.btnProductSalesAnalysis.Text = "Product Sales Analysis";
            this.btnProductSalesAnalysis.Click += new System.EventHandler(this.btnProductSalesAnalysis_Click);
            // 
            // btnYearlyProductSales
            // 
            this.btnYearlyProductSales.Active = true;
            this.btnYearlyProductSales.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnYearlyProductSales.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYearlyProductSales.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnYearlyProductSales.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnYearlyProductSales.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnYearlyProductSales.HoverColorB = System.Drawing.Color.White;
            this.btnYearlyProductSales.Location = new System.Drawing.Point(69, 246);
            this.btnYearlyProductSales.Name = "btnYearlyProductSales";
            this.btnYearlyProductSales.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnYearlyProductSales.NormalColorA = System.Drawing.Color.White;
            this.btnYearlyProductSales.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnYearlyProductSales.Size = new System.Drawing.Size(340, 40);
            this.btnYearlyProductSales.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnYearlyProductSales.TabIndex = 31;
            this.btnYearlyProductSales.Text = "Yearly Product Sales";
            this.btnYearlyProductSales.Click += new System.EventHandler(this.btnYearlyProductSales_Click);
            // 
            // frmRptProductAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(487, 281);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmRptProductAnalysis";
            this.Load += new System.EventHandler(this.frmRptProductAnalysis_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ColorButton.ColorButton btnProductSalesAnalysis;
        private ColorButton.ColorButton btnProductWiseAnalysis;
        private ColorButton.ColorButton btnYearlyProductSales;


    }
}
