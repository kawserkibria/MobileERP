namespace JA.Modulecontrolar.UI.Accms.Forms
{
    partial class frmAccountsOtherMaster
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
            this.btnOverHead = new ColorButton.ColorButton();
            this.btnAutoPFHL = new ColorButton.ColorButton();
            this.btnBankReconcilation = new ColorButton.ColorButton();
            this.btnInterestCharge = new ColorButton.ColorButton();
            this.cmdIncentiveGeneration = new ColorButton.ColorButton();
            this.btnMpoCommissionAuto = new ColorButton.ColorButton();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmLabel.Location = new System.Drawing.Point(148, 7);
            this.frmLabel.Size = new System.Drawing.Size(189, 23);
            this.frmLabel.Text = "Others Transaction";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnMpoCommissionAuto);
            this.pnlMain.Controls.Add(this.cmdIncentiveGeneration);
            this.pnlMain.Controls.Add(this.btnOverHead);
            this.pnlMain.Controls.Add(this.btnAutoPFHL);
            this.pnlMain.Controls.Add(this.btnBankReconcilation);
            this.pnlMain.Controls.Add(this.btnInterestCharge);
            this.pnlMain.Size = new System.Drawing.Size(451, 412);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(454, 49);
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
            this.btnClose.Location = new System.Drawing.Point(195, 176);
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
            this.groupBox1.Location = new System.Drawing.Point(0, 332);
            this.groupBox1.Size = new System.Drawing.Size(454, 25);
            // 
            // btnOverHead
            // 
            this.btnOverHead.Active = true;
            this.btnOverHead.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnOverHead.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOverHead.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnOverHead.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnOverHead.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnOverHead.HoverColorB = System.Drawing.Color.White;
            this.btnOverHead.Location = new System.Drawing.Point(85, 267);
            this.btnOverHead.Name = "btnOverHead";
            this.btnOverHead.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnOverHead.NormalColorA = System.Drawing.Color.White;
            this.btnOverHead.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnOverHead.Size = new System.Drawing.Size(307, 40);
            this.btnOverHead.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnOverHead.TabIndex = 16;
            this.btnOverHead.Text = "Overhead";
            this.btnOverHead.Click += new System.EventHandler(this.btnOverHead_Click_1);
            // 
            // btnAutoPFHL
            // 
            this.btnAutoPFHL.Active = true;
            this.btnAutoPFHL.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnAutoPFHL.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoPFHL.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnAutoPFHL.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnAutoPFHL.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnAutoPFHL.HoverColorB = System.Drawing.Color.White;
            this.btnAutoPFHL.Location = new System.Drawing.Point(85, 225);
            this.btnAutoPFHL.Name = "btnAutoPFHL";
            this.btnAutoPFHL.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnAutoPFHL.NormalColorA = System.Drawing.Color.White;
            this.btnAutoPFHL.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnAutoPFHL.Size = new System.Drawing.Size(307, 40);
            this.btnAutoPFHL.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnAutoPFHL.TabIndex = 15;
            this.btnAutoPFHL.Text = "Auto PF/HL";
            // 
            // btnBankReconcilation
            // 
            this.btnBankReconcilation.Active = true;
            this.btnBankReconcilation.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnBankReconcilation.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBankReconcilation.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnBankReconcilation.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnBankReconcilation.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnBankReconcilation.HoverColorB = System.Drawing.Color.White;
            this.btnBankReconcilation.Location = new System.Drawing.Point(85, 141);
            this.btnBankReconcilation.Name = "btnBankReconcilation";
            this.btnBankReconcilation.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnBankReconcilation.NormalColorA = System.Drawing.Color.White;
            this.btnBankReconcilation.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnBankReconcilation.Size = new System.Drawing.Size(307, 40);
            this.btnBankReconcilation.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnBankReconcilation.TabIndex = 14;
            this.btnBankReconcilation.Text = "Bank Reconcilation";
            // 
            // btnInterestCharge
            // 
            this.btnInterestCharge.Active = true;
            this.btnInterestCharge.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnInterestCharge.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInterestCharge.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnInterestCharge.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnInterestCharge.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnInterestCharge.HoverColorB = System.Drawing.Color.White;
            this.btnInterestCharge.Location = new System.Drawing.Point(85, 183);
            this.btnInterestCharge.Name = "btnInterestCharge";
            this.btnInterestCharge.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnInterestCharge.NormalColorA = System.Drawing.Color.White;
            this.btnInterestCharge.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnInterestCharge.Size = new System.Drawing.Size(307, 40);
            this.btnInterestCharge.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnInterestCharge.TabIndex = 13;
            this.btnInterestCharge.Text = "Interest Charge";
            this.btnInterestCharge.Click += new System.EventHandler(this.btnInterestCharge_Click);
            // 
            // cmdIncentiveGeneration
            // 
            this.cmdIncentiveGeneration.Active = true;
            this.cmdIncentiveGeneration.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.cmdIncentiveGeneration.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdIncentiveGeneration.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.cmdIncentiveGeneration.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.cmdIncentiveGeneration.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.cmdIncentiveGeneration.HoverColorB = System.Drawing.Color.White;
            this.cmdIncentiveGeneration.Location = new System.Drawing.Point(85, 310);
            this.cmdIncentiveGeneration.Name = "cmdIncentiveGeneration";
            this.cmdIncentiveGeneration.NormalBorderColor = System.Drawing.Color.Aqua;
            this.cmdIncentiveGeneration.NormalColorA = System.Drawing.Color.White;
            this.cmdIncentiveGeneration.NormalColorB = System.Drawing.Color.Honeydew;
            this.cmdIncentiveGeneration.Size = new System.Drawing.Size(307, 40);
            this.cmdIncentiveGeneration.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.cmdIncentiveGeneration.TabIndex = 17;
            this.cmdIncentiveGeneration.Text = "Incentive Generation";
            this.cmdIncentiveGeneration.Click += new System.EventHandler(this.cmdIncentiveGeneration_Click);
            // 
            // btnMpoCommissionAuto
            // 
            this.btnMpoCommissionAuto.Active = true;
            this.btnMpoCommissionAuto.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnMpoCommissionAuto.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMpoCommissionAuto.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnMpoCommissionAuto.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnMpoCommissionAuto.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnMpoCommissionAuto.HoverColorB = System.Drawing.Color.White;
            this.btnMpoCommissionAuto.Location = new System.Drawing.Point(85, 354);
            this.btnMpoCommissionAuto.Name = "btnMpoCommissionAuto";
            this.btnMpoCommissionAuto.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnMpoCommissionAuto.NormalColorA = System.Drawing.Color.White;
            this.btnMpoCommissionAuto.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnMpoCommissionAuto.Size = new System.Drawing.Size(307, 40);
            this.btnMpoCommissionAuto.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnMpoCommissionAuto.TabIndex = 18;
            this.btnMpoCommissionAuto.Text = "MPO Commission Generation";
            this.btnMpoCommissionAuto.Click += new System.EventHandler(this.btnMpoCommissionAuto_Click);
            // 
            // frmAccountsOtherMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(454, 357);
            this.isEnterTabAllow = true;
            this.MinimizeBox = false;
            this.Name = "frmAccountsOtherMaster";
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ColorButton.ColorButton btnOverHead;
        private ColorButton.ColorButton btnAutoPFHL;
        private ColorButton.ColorButton btnBankReconcilation;
        private ColorButton.ColorButton btnInterestCharge;
        private ColorButton.ColorButton cmdIncentiveGeneration;
        private ColorButton.ColorButton btnMpoCommissionAuto;

    }
}
