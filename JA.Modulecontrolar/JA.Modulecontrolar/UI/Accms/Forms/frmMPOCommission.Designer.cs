namespace JA.Modulecontrolar.UI.Accms.Forms
{
    partial class frmMPOCommission
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
            this.btnCollectionMonth = new ColorButton.ColorButton();
            this.btnLedgerConfiguration = new ColorButton.ColorButton();
            this.btnAddCommssionBill = new ColorButton.ColorButton();
            this.btnIncentiveConfiguration = new ColorButton.ColorButton();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmLabel.Location = new System.Drawing.Point(134, 7);
            this.frmLabel.Size = new System.Drawing.Size(176, 23);
            this.frmLabel.Text = "MPO Commission";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnIncentiveConfiguration);
            this.pnlMain.Controls.Add(this.btnAddCommssionBill);
            this.pnlMain.Controls.Add(this.btnCollectionMonth);
            this.pnlMain.Controls.Add(this.btnLedgerConfiguration);
            this.pnlMain.Size = new System.Drawing.Size(450, 315);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(454, 42);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(23, 153);
            this.btnEdit.Size = new System.Drawing.Size(10, 10);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(57, 162);
            this.btnSave.Size = new System.Drawing.Size(6, 5);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(12, 151);
            this.btnDelete.Size = new System.Drawing.Size(0, 7);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(7, 162);
            this.btnNew.Size = new System.Drawing.Size(10, 20);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(432, 151);
            this.btnClose.Size = new System.Drawing.Size(10, 10);
            this.btnClose.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(140, 165);
            this.btnPrint.Size = new System.Drawing.Size(0, 10);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 229);
            this.groupBox1.Size = new System.Drawing.Size(454, 25);
            // 
            // btnCollectionMonth
            // 
            this.btnCollectionMonth.Active = true;
            this.btnCollectionMonth.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnCollectionMonth.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCollectionMonth.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnCollectionMonth.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnCollectionMonth.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnCollectionMonth.HoverColorB = System.Drawing.Color.White;
            this.btnCollectionMonth.Location = new System.Drawing.Point(81, 132);
            this.btnCollectionMonth.Name = "btnCollectionMonth";
            this.btnCollectionMonth.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnCollectionMonth.NormalColorA = System.Drawing.Color.White;
            this.btnCollectionMonth.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnCollectionMonth.Size = new System.Drawing.Size(269, 40);
            this.btnCollectionMonth.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnCollectionMonth.TabIndex = 44;
            this.btnCollectionMonth.Text = "Collection Month";
            this.btnCollectionMonth.Click += new System.EventHandler(this.btnCollectionMonth_Click);
            // 
            // btnLedgerConfiguration
            // 
            this.btnLedgerConfiguration.Active = true;
            this.btnLedgerConfiguration.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnLedgerConfiguration.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLedgerConfiguration.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnLedgerConfiguration.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnLedgerConfiguration.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnLedgerConfiguration.HoverColorB = System.Drawing.Color.White;
            this.btnLedgerConfiguration.Location = new System.Drawing.Point(81, 174);
            this.btnLedgerConfiguration.Name = "btnLedgerConfiguration";
            this.btnLedgerConfiguration.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnLedgerConfiguration.NormalColorA = System.Drawing.Color.White;
            this.btnLedgerConfiguration.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnLedgerConfiguration.Size = new System.Drawing.Size(269, 40);
            this.btnLedgerConfiguration.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnLedgerConfiguration.TabIndex = 43;
            this.btnLedgerConfiguration.Text = "Ledger Configuration";
            this.btnLedgerConfiguration.Click += new System.EventHandler(this.btnLedgerConfiguration_Click);
            // 
            // btnAddCommssionBill
            // 
            this.btnAddCommssionBill.Active = true;
            this.btnAddCommssionBill.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnAddCommssionBill.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCommssionBill.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnAddCommssionBill.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnAddCommssionBill.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnAddCommssionBill.HoverColorB = System.Drawing.Color.White;
            this.btnAddCommssionBill.Location = new System.Drawing.Point(81, 256);
            this.btnAddCommssionBill.Name = "btnAddCommssionBill";
            this.btnAddCommssionBill.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnAddCommssionBill.NormalColorA = System.Drawing.Color.White;
            this.btnAddCommssionBill.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnAddCommssionBill.Size = new System.Drawing.Size(269, 40);
            this.btnAddCommssionBill.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnAddCommssionBill.TabIndex = 45;
            this.btnAddCommssionBill.Text = "Draft MPO Commission ";
            this.btnAddCommssionBill.Click += new System.EventHandler(this.btnAddCommssionBill_Click);
            // 
            // btnIncentiveConfiguration
            // 
            this.btnIncentiveConfiguration.Active = true;
            this.btnIncentiveConfiguration.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnIncentiveConfiguration.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncentiveConfiguration.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnIncentiveConfiguration.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnIncentiveConfiguration.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnIncentiveConfiguration.HoverColorB = System.Drawing.Color.White;
            this.btnIncentiveConfiguration.Location = new System.Drawing.Point(81, 215);
            this.btnIncentiveConfiguration.Name = "btnIncentiveConfiguration";
            this.btnIncentiveConfiguration.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnIncentiveConfiguration.NormalColorA = System.Drawing.Color.White;
            this.btnIncentiveConfiguration.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnIncentiveConfiguration.Size = new System.Drawing.Size(269, 40);
            this.btnIncentiveConfiguration.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnIncentiveConfiguration.TabIndex = 46;
            this.btnIncentiveConfiguration.Text = "Incentive Configuration";
            this.btnIncentiveConfiguration.Click += new System.EventHandler(this.btnIncentiveConfiguration_Click);
            // 
            // frmMPOCommission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(454, 254);
            this.isEnterTabAllow = true;
            this.MinimizeBox = false;
            this.Name = "frmMPOCommission";
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ColorButton.ColorButton btnCollectionMonth;
        private ColorButton.ColorButton btnLedgerConfiguration;
        private ColorButton.ColorButton btnAddCommssionBill;
        private ColorButton.ColorButton btnIncentiveConfiguration;

    }
}
