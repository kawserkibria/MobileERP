namespace JA.Modulecontrolar.UI.Master.Accounts
{
    partial class frmMPOCommissionTran
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
            this.btnReceiptDoctor = new ColorButton.ColorButton();
            this.btnMpoCommission = new ColorButton.ColorButton();
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
            this.pnlMain.Controls.Add(this.btnReceiptDoctor);
            this.pnlMain.Controls.Add(this.btnMpoCommission);
            this.pnlMain.Size = new System.Drawing.Size(450, 279);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(454, 42);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(92, 153);
            this.btnEdit.Size = new System.Drawing.Size(10, 10);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(57, 162);
            this.btnSave.Size = new System.Drawing.Size(10, 20);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(109, 157);
            this.btnDelete.Size = new System.Drawing.Size(14, 20);
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
            this.btnClose.Location = new System.Drawing.Point(195, 151);
            this.btnClose.Size = new System.Drawing.Size(15, 20);
            this.btnClose.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(140, 165);
            this.btnPrint.Size = new System.Drawing.Size(19, 10);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 192);
            this.groupBox1.Size = new System.Drawing.Size(454, 25);
            // 
            // btnReceiptDoctor
            // 
            this.btnReceiptDoctor.Active = true;
            this.btnReceiptDoctor.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnReceiptDoctor.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceiptDoctor.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnReceiptDoctor.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnReceiptDoctor.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnReceiptDoctor.HoverColorB = System.Drawing.Color.White;
            this.btnReceiptDoctor.Location = new System.Drawing.Point(127, 193);
            this.btnReceiptDoctor.Name = "btnReceiptDoctor";
            this.btnReceiptDoctor.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnReceiptDoctor.NormalColorA = System.Drawing.Color.White;
            this.btnReceiptDoctor.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnReceiptDoctor.Size = new System.Drawing.Size(200, 40);
            this.btnReceiptDoctor.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnReceiptDoctor.TabIndex = 10;
            this.btnReceiptDoctor.Text = "MPO Collection";
            this.btnReceiptDoctor.Click += new System.EventHandler(this.btnReceiptDoctor_Click);
            // 
            // btnMpoCommission
            // 
            this.btnMpoCommission.Active = true;
            this.btnMpoCommission.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnMpoCommission.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMpoCommission.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnMpoCommission.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnMpoCommission.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnMpoCommission.HoverColorB = System.Drawing.Color.White;
            this.btnMpoCommission.Location = new System.Drawing.Point(127, 151);
            this.btnMpoCommission.Name = "btnMpoCommission";
            this.btnMpoCommission.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnMpoCommission.NormalColorA = System.Drawing.Color.White;
            this.btnMpoCommission.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnMpoCommission.Size = new System.Drawing.Size(200, 40);
            this.btnMpoCommission.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnMpoCommission.TabIndex = 9;
            this.btnMpoCommission.Text = "MPO Commission";
            this.btnMpoCommission.Click += new System.EventHandler(this.btnMpoCommission_Click);
            // 
            // frmMPOCommissionTran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(454, 217);
            this.isEnterTabAllow = true;
            this.MinimizeBox = false;
            this.Name = "frmMPOCommissionTran";
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ColorButton.ColorButton btnReceiptDoctor;
        private ColorButton.ColorButton btnMpoCommission;


    }
}
