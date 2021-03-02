namespace JA.Modulecontrolar.UI.Inventory
{
    partial class frmStockEstimationMain
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
            this.btnMonthlyConsumption = new ColorButton.ColorButton();
            this.btnConsumption = new ColorButton.ColorButton();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(136, 9);
            this.frmLabel.Size = new System.Drawing.Size(199, 33);
            this.frmLabel.Text = "Cost Estimation";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnMonthlyConsumption);
            this.pnlMain.Controls.Add(this.btnConsumption);
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
            // btnMonthlyConsumption
            // 
            this.btnMonthlyConsumption.Active = true;
            this.btnMonthlyConsumption.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnMonthlyConsumption.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMonthlyConsumption.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnMonthlyConsumption.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnMonthlyConsumption.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnMonthlyConsumption.HoverColorB = System.Drawing.Color.White;
            this.btnMonthlyConsumption.Location = new System.Drawing.Point(98, 214);
            this.btnMonthlyConsumption.Name = "btnMonthlyConsumption";
            this.btnMonthlyConsumption.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnMonthlyConsumption.NormalColorA = System.Drawing.Color.White;
            this.btnMonthlyConsumption.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnMonthlyConsumption.Size = new System.Drawing.Size(287, 40);
            this.btnMonthlyConsumption.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnMonthlyConsumption.TabIndex = 12;
            this.btnMonthlyConsumption.Text = "Monthly Cost Estimation";
            this.btnMonthlyConsumption.Click += new System.EventHandler(this.btnMonthlyConsumption_Click);
            // 
            // btnConsumption
            // 
            this.btnConsumption.Active = true;
            this.btnConsumption.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnConsumption.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsumption.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnConsumption.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnConsumption.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnConsumption.HoverColorB = System.Drawing.Color.White;
            this.btnConsumption.Location = new System.Drawing.Point(98, 172);
            this.btnConsumption.Name = "btnConsumption";
            this.btnConsumption.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnConsumption.NormalColorA = System.Drawing.Color.White;
            this.btnConsumption.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnConsumption.Size = new System.Drawing.Size(287, 40);
            this.btnConsumption.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnConsumption.TabIndex = 11;
            this.btnConsumption.Text = "FG Item Cost Estimation";
            this.btnConsumption.Click += new System.EventHandler(this.btnConsumption_Click);
            // 
            // frmStockEstimationMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(464, 213);
            this.isEnterTabAllow = true;
            this.MinimizeBox = false;
            this.Name = "frmStockEstimationMain";
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ColorButton.ColorButton btnMonthlyConsumption;
        private ColorButton.ColorButton btnConsumption;

    }
}
