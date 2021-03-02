namespace JA.Modulecontrolar.UI.DReport.Sales.ParameterForms
{
    partial class frmRptYearCompare
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
            this.btnRptCPSPYearCompare = new ColorButton.ColorButton();
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
            this.pnlMain.Controls.Add(this.btnRptCPSPYearCompare);
            this.pnlMain.Location = new System.Drawing.Point(0, -86);
            this.pnlMain.Size = new System.Drawing.Size(485, 254);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(487, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(54, 150);
            this.btnEdit.Size = new System.Drawing.Size(10, 10);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 150);
            this.btnSave.Size = new System.Drawing.Size(10, 10);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.ImageIndex = -1;
            this.btnDelete.ImageKey = "(none)";
            this.btnDelete.Location = new System.Drawing.Point(136, 149);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            this.btnDelete.Text = "";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(96, 150);
            this.btnNew.Size = new System.Drawing.Size(10, 10);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.ImageIndex = -1;
            this.btnClose.ImageKey = "(none)";
            this.btnClose.Location = new System.Drawing.Point(209, 149);
            this.btnClose.Size = new System.Drawing.Size(10, 10);
            this.btnClose.Text = "";
            this.btnClose.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.ImageIndex = -1;
            this.btnPrint.Location = new System.Drawing.Point(193, 149);
            this.btnPrint.Size = new System.Drawing.Size(10, 10);
            this.btnPrint.Text = "";
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 179);
            this.groupBox1.Size = new System.Drawing.Size(487, 25);
            // 
            // btnRptCPSPYearCompare
            // 
            this.btnRptCPSPYearCompare.Active = true;
            this.btnRptCPSPYearCompare.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnRptCPSPYearCompare.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRptCPSPYearCompare.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnRptCPSPYearCompare.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnRptCPSPYearCompare.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnRptCPSPYearCompare.HoverColorB = System.Drawing.Color.White;
            this.btnRptCPSPYearCompare.Location = new System.Drawing.Point(69, 161);
            this.btnRptCPSPYearCompare.Name = "btnRptCPSPYearCompare";
            this.btnRptCPSPYearCompare.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnRptCPSPYearCompare.NormalColorA = System.Drawing.Color.White;
            this.btnRptCPSPYearCompare.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnRptCPSPYearCompare.Size = new System.Drawing.Size(340, 40);
            this.btnRptCPSPYearCompare.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnRptCPSPYearCompare.TabIndex = 29;
            this.btnRptCPSPYearCompare.Text = "Yearly CP/SP Analysis";
            this.btnRptCPSPYearCompare.Click += new System.EventHandler(this.btnRptCPSPYearCompare_Click);
            // 
            // frmRptYearCompare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(487, 204);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmRptYearCompare";
            this.Load += new System.EventHandler(this.frmRptYearCompare_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ColorButton.ColorButton btnRptCPSPYearCompare;


    }
}
