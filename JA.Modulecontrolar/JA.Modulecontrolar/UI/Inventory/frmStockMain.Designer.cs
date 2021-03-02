namespace JA.Modulecontrolar.UI.Inventory
{
    partial class frmStockMain
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
            this.btnStockStatementSumm = new ColorButton.ColorButton();
            this.btnStockStatement = new ColorButton.ColorButton();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(136, 9);
            this.frmLabel.Size = new System.Drawing.Size(209, 33);
            this.frmLabel.Text = "Stock Statement";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnStockStatementSumm);
            this.pnlMain.Controls.Add(this.btnStockStatement);
            this.pnlMain.Size = new System.Drawing.Size(463, 275);
          
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(464, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(41, 64);
            this.btnEdit.Size = new System.Drawing.Size(10, 10);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(57, 64);
            this.btnSave.Size = new System.Drawing.Size(10, 10);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(89, 64);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(73, 64);
            this.btnNew.Size = new System.Drawing.Size(10, 10);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(89, 64);
            this.btnClose.Size = new System.Drawing.Size(10, 10);
            this.btnClose.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(89, 64);
            this.btnPrint.Size = new System.Drawing.Size(10, 10);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 188);
            this.groupBox1.Size = new System.Drawing.Size(464, 25);
            // 
            // btnStockStatementSumm
            // 
            this.btnStockStatementSumm.Active = true;
            this.btnStockStatementSumm.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnStockStatementSumm.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStockStatementSumm.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnStockStatementSumm.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnStockStatementSumm.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnStockStatementSumm.HoverColorB = System.Drawing.Color.White;
            this.btnStockStatementSumm.Location = new System.Drawing.Point(98, 214);
            this.btnStockStatementSumm.Name = "btnStockStatementSumm";
            this.btnStockStatementSumm.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnStockStatementSumm.NormalColorA = System.Drawing.Color.White;
            this.btnStockStatementSumm.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnStockStatementSumm.Size = new System.Drawing.Size(257, 40);
            this.btnStockStatementSumm.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnStockStatementSumm.TabIndex = 12;
            this.btnStockStatementSumm.Text = "Stock Statement Summ.";
            this.btnStockStatementSumm.Click += new System.EventHandler(this.btnStockStatementSumm_Click);
            // 
            // btnStockStatement
            // 
            this.btnStockStatement.Active = true;
            this.btnStockStatement.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnStockStatement.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStockStatement.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnStockStatement.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnStockStatement.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnStockStatement.HoverColorB = System.Drawing.Color.White;
            this.btnStockStatement.Location = new System.Drawing.Point(98, 172);
            this.btnStockStatement.Name = "btnStockStatement";
            this.btnStockStatement.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnStockStatement.NormalColorA = System.Drawing.Color.White;
            this.btnStockStatement.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnStockStatement.Size = new System.Drawing.Size(257, 40);
            this.btnStockStatement.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnStockStatement.TabIndex = 11;
            this.btnStockStatement.Text = "Stock Statement";
            this.btnStockStatement.Click += new System.EventHandler(this.btnStockStatement_Click);
            // 
            // frmStockMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(464, 213);
            this.isEnterTabAllow = true;
            this.MinimizeBox = false;
            this.Name = "frmStockMain";
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ColorButton.ColorButton btnStockStatementSumm;
        private ColorButton.ColorButton btnStockStatement;

    }
}
