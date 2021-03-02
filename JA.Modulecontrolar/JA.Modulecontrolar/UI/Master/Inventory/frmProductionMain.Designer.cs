namespace JA.Modulecontrolar.UI.Inventory
{
    partial class frmProductionMain
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
            this.btnConsumption = new ColorButton.ColorButton();
            this.frmMFGVoucherProcess = new ColorButton.ColorButton();
            this.btnConversionFG = new ColorButton.ColorButton();
            this.btnstockConsumtion = new ColorButton.ColorButton();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(140, 9);
            this.frmLabel.Size = new System.Drawing.Size(206, 33);
            this.frmLabel.Text = "Production Main";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnstockConsumtion);
            this.pnlMain.Controls.Add(this.btnConversionFG);
            this.pnlMain.Controls.Add(this.frmMFGVoucherProcess);
            this.pnlMain.Controls.Add(this.btnConsumption);
            this.pnlMain.Size = new System.Drawing.Size(463, 348);
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
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
            this.groupBox1.Location = new System.Drawing.Point(0, 261);
            this.groupBox1.Size = new System.Drawing.Size(464, 25);
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
            this.btnConsumption.Location = new System.Drawing.Point(88, 208);
            this.btnConsumption.Name = "btnConsumption";
            this.btnConsumption.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnConsumption.NormalColorA = System.Drawing.Color.White;
            this.btnConsumption.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnConsumption.Size = new System.Drawing.Size(307, 38);
            this.btnConsumption.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnConsumption.TabIndex = 1;
            this.btnConsumption.Text = "MFG Voucher";
            this.btnConsumption.Click += new System.EventHandler(this.btnConsumption_Click);
            // 
            // frmMFGVoucherProcess
            // 
            this.frmMFGVoucherProcess.Active = true;
            this.frmMFGVoucherProcess.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.frmMFGVoucherProcess.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmMFGVoucherProcess.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.frmMFGVoucherProcess.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.frmMFGVoucherProcess.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.frmMFGVoucherProcess.HoverColorB = System.Drawing.Color.White;
            this.frmMFGVoucherProcess.Location = new System.Drawing.Point(88, 248);
            this.frmMFGVoucherProcess.Name = "frmMFGVoucherProcess";
            this.frmMFGVoucherProcess.NormalBorderColor = System.Drawing.Color.Aqua;
            this.frmMFGVoucherProcess.NormalColorA = System.Drawing.Color.White;
            this.frmMFGVoucherProcess.NormalColorB = System.Drawing.Color.Honeydew;
            this.frmMFGVoucherProcess.Size = new System.Drawing.Size(307, 38);
            this.frmMFGVoucherProcess.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.frmMFGVoucherProcess.TabIndex = 2;
            this.frmMFGVoucherProcess.Text = "MFG Voucher (Batch Wise)";
            this.frmMFGVoucherProcess.Click += new System.EventHandler(this.frmMFGVoucherProcess_Click);
            // 
            // btnConversionFG
            // 
            this.btnConversionFG.Active = true;
            this.btnConversionFG.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnConversionFG.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConversionFG.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnConversionFG.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnConversionFG.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnConversionFG.HoverColorB = System.Drawing.Color.White;
            this.btnConversionFG.Location = new System.Drawing.Point(88, 288);
            this.btnConversionFG.Name = "btnConversionFG";
            this.btnConversionFG.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnConversionFG.NormalColorA = System.Drawing.Color.White;
            this.btnConversionFG.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnConversionFG.Size = new System.Drawing.Size(307, 38);
            this.btnConversionFG.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnConversionFG.TabIndex = 3;
            this.btnConversionFG.Text = "Conversion FG";
            this.btnConversionFG.Click += new System.EventHandler(this.btnConversionFG_Click);
            // 
            // btnstockConsumtion
            // 
            this.btnstockConsumtion.Active = true;
            this.btnstockConsumtion.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnstockConsumtion.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnstockConsumtion.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnstockConsumtion.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnstockConsumtion.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnstockConsumtion.HoverColorB = System.Drawing.Color.White;
            this.btnstockConsumtion.Location = new System.Drawing.Point(88, 168);
            this.btnstockConsumtion.Name = "btnstockConsumtion";
            this.btnstockConsumtion.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnstockConsumtion.NormalColorA = System.Drawing.Color.White;
            this.btnstockConsumtion.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnstockConsumtion.Size = new System.Drawing.Size(307, 38);
            this.btnstockConsumtion.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnstockConsumtion.TabIndex = 4;
            this.btnstockConsumtion.Text = "Stock Consumption";
            this.btnstockConsumtion.Click += new System.EventHandler(this.btnstockConsumtion_Click);
            // 
            // frmProductionMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(464, 286);
            this.isEnterTabAllow = true;
            this.MinimizeBox = false;
            this.Name = "frmProductionMain";
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ColorButton.ColorButton frmMFGVoucherProcess;
        private ColorButton.ColorButton btnConsumption;
        private ColorButton.ColorButton btnConversionFG;
        private ColorButton.ColorButton btnstockConsumtion;
    }
}
