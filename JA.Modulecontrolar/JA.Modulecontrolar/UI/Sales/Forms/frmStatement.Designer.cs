namespace JA.Modulecontrolar.UI.Sales.Forms
{
    partial class frmStatement
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
            this.btnRptSalesStatement = new ColorButton.ColorButton();
            this.btnCollectionStatement = new ColorButton.ColorButton();
            this.btnrptCollectionStat = new ColorButton.ColorButton();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmLabel.Location = new System.Drawing.Point(166, 7);
            this.frmLabel.Size = new System.Drawing.Size(107, 23);
            this.frmLabel.Text = "Statement";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnrptCollectionStat);
            this.pnlMain.Controls.Add(this.btnCollectionStatement);
            this.pnlMain.Controls.Add(this.btnRptSalesStatement);
            this.pnlMain.Size = new System.Drawing.Size(451, 282);
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
            this.btnClose.Location = new System.Drawing.Point(195, 146);
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
            this.groupBox1.Location = new System.Drawing.Point(0, 195);
            this.groupBox1.Size = new System.Drawing.Size(454, 25);
            // 
            // btnRptSalesStatement
            // 
            this.btnRptSalesStatement.Active = true;
            this.btnRptSalesStatement.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnRptSalesStatement.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRptSalesStatement.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnRptSalesStatement.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnRptSalesStatement.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnRptSalesStatement.HoverColorB = System.Drawing.Color.White;
            this.btnRptSalesStatement.Location = new System.Drawing.Point(29, 142);
            this.btnRptSalesStatement.Name = "btnRptSalesStatement";
            this.btnRptSalesStatement.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnRptSalesStatement.NormalColorA = System.Drawing.Color.White;
            this.btnRptSalesStatement.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnRptSalesStatement.Size = new System.Drawing.Size(375, 40);
            this.btnRptSalesStatement.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnRptSalesStatement.TabIndex = 5;
            this.btnRptSalesStatement.Text = "Sales Statement";
            this.btnRptSalesStatement.Click += new System.EventHandler(this.btnRptSalesStatement_Click);
            // 
            // btnCollectionStatement
            // 
            this.btnCollectionStatement.Active = true;
            this.btnCollectionStatement.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnCollectionStatement.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCollectionStatement.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnCollectionStatement.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnCollectionStatement.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnCollectionStatement.HoverColorB = System.Drawing.Color.White;
            this.btnCollectionStatement.Location = new System.Drawing.Point(29, 183);
            this.btnCollectionStatement.Name = "btnCollectionStatement";
            this.btnCollectionStatement.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnCollectionStatement.NormalColorA = System.Drawing.Color.White;
            this.btnCollectionStatement.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnCollectionStatement.Size = new System.Drawing.Size(375, 40);
            this.btnCollectionStatement.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnCollectionStatement.TabIndex = 6;
            this.btnCollectionStatement.Text = "Collection Statement";
            this.btnCollectionStatement.Click += new System.EventHandler(this.btnCollectionStatement_Click);
            // 
            // btnrptCollectionStat
            // 
            this.btnrptCollectionStat.Active = true;
            this.btnrptCollectionStat.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnrptCollectionStat.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrptCollectionStat.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnrptCollectionStat.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnrptCollectionStat.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnrptCollectionStat.HoverColorB = System.Drawing.Color.White;
            this.btnrptCollectionStat.Location = new System.Drawing.Point(29, 225);
            this.btnrptCollectionStat.Name = "btnrptCollectionStat";
            this.btnrptCollectionStat.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnrptCollectionStat.NormalColorA = System.Drawing.Color.White;
            this.btnrptCollectionStat.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnrptCollectionStat.Size = new System.Drawing.Size(375, 40);
            this.btnrptCollectionStat.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnrptCollectionStat.TabIndex = 7;
            this.btnrptCollectionStat.Text = "TC Wise Sales/Collection Statement";
            this.btnrptCollectionStat.Click += new System.EventHandler(this.btnrptCollectionStat_Click);
            // 
            // frmStatement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(454, 220);
            this.isEnterTabAllow = true;
            this.MinimizeBox = false;
            this.Name = "frmStatement";
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ColorButton.ColorButton btnCollectionStatement;
        private ColorButton.ColorButton btnRptSalesStatement;
        private ColorButton.ColorButton btnrptCollectionStat;
    }
}
