namespace JA.Modulecontrolar.UI.DReport.Sales.ParameterForms
{
    partial class frmRptProductShortMultiple
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
            this.btnProductShortStatement = new ColorButton.ColorButton();
            this.btnProductShortDetails = new ColorButton.ColorButton();
            this.btnProductShortReport = new ColorButton.ColorButton();
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
            this.pnlMain.Controls.Add(this.btnProductShortReport);
            this.pnlMain.Controls.Add(this.btnProductShortDetails);
            this.pnlMain.Controls.Add(this.btnProductShortStatement);
            this.pnlMain.Location = new System.Drawing.Point(0, -86);
            this.pnlMain.Size = new System.Drawing.Size(485, 387);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(487, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(54, 292);
            this.btnEdit.Size = new System.Drawing.Size(10, 10);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 292);
            this.btnSave.Size = new System.Drawing.Size(10, 10);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.ImageIndex = -1;
            this.btnDelete.ImageKey = "(none)";
            this.btnDelete.Location = new System.Drawing.Point(136, 291);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            this.btnDelete.Text = "";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(96, 292);
            this.btnNew.Size = new System.Drawing.Size(10, 10);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.ImageIndex = -1;
            this.btnClose.ImageKey = "(none)";
            this.btnClose.Location = new System.Drawing.Point(209, 291);
            this.btnClose.Size = new System.Drawing.Size(10, 10);
            this.btnClose.Text = "";
            this.btnClose.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.ImageIndex = -1;
            this.btnPrint.Location = new System.Drawing.Point(193, 291);
            this.btnPrint.Size = new System.Drawing.Size(10, 10);
            this.btnPrint.Text = "";
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 304);
            this.groupBox1.Size = new System.Drawing.Size(487, 25);
            // 
            // btnProductShortStatement
            // 
            this.btnProductShortStatement.Active = true;
            this.btnProductShortStatement.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnProductShortStatement.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductShortStatement.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnProductShortStatement.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnProductShortStatement.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnProductShortStatement.HoverColorB = System.Drawing.Color.White;
            this.btnProductShortStatement.Location = new System.Drawing.Point(66, 186);
            this.btnProductShortStatement.Name = "btnProductShortStatement";
            this.btnProductShortStatement.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnProductShortStatement.NormalColorA = System.Drawing.Color.White;
            this.btnProductShortStatement.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnProductShortStatement.Size = new System.Drawing.Size(340, 40);
            this.btnProductShortStatement.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnProductShortStatement.TabIndex = 29;
            this.btnProductShortStatement.Text = "Product Short Summ.";
            this.btnProductShortStatement.Click += new System.EventHandler(this.btnSalesTarget_Click);
            // 
            // btnProductShortDetails
            // 
            this.btnProductShortDetails.Active = true;
            this.btnProductShortDetails.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnProductShortDetails.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductShortDetails.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnProductShortDetails.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnProductShortDetails.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnProductShortDetails.HoverColorB = System.Drawing.Color.White;
            this.btnProductShortDetails.Location = new System.Drawing.Point(66, 230);
            this.btnProductShortDetails.Name = "btnProductShortDetails";
            this.btnProductShortDetails.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnProductShortDetails.NormalColorA = System.Drawing.Color.White;
            this.btnProductShortDetails.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnProductShortDetails.Size = new System.Drawing.Size(340, 40);
            this.btnProductShortDetails.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnProductShortDetails.TabIndex = 30;
            this.btnProductShortDetails.Text = "Product Short Details.";
            this.btnProductShortDetails.Click += new System.EventHandler(this.btnProductSales_Click);
            // 
            // btnProductShortReport
            // 
            this.btnProductShortReport.Active = true;
            this.btnProductShortReport.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnProductShortReport.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductShortReport.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnProductShortReport.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnProductShortReport.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnProductShortReport.HoverColorB = System.Drawing.Color.White;
            this.btnProductShortReport.Location = new System.Drawing.Point(66, 273);
            this.btnProductShortReport.Name = "btnProductShortReport";
            this.btnProductShortReport.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnProductShortReport.NormalColorA = System.Drawing.Color.White;
            this.btnProductShortReport.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnProductShortReport.Size = new System.Drawing.Size(340, 40);
            this.btnProductShortReport.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnProductShortReport.TabIndex = 31;
            this.btnProductShortReport.Text = "Product Short Report";
            this.btnProductShortReport.Click += new System.EventHandler(this.btnProduct12Month_Click);
            // 
            // frmRptProductShortMultiple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(487, 329);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmRptProductShortMultiple";
            this.Load += new System.EventHandler(this.frmRptProductShortMultiple_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ColorButton.ColorButton btnProductShortReport;
        private ColorButton.ColorButton btnProductShortDetails;
        private ColorButton.ColorButton btnProductShortStatement;


    }
}
