namespace JA.Modulecontrolar.UI.Master
{
    partial class frmProcessM
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
            this.btnProcessInformation = new ColorButton.ColorButton();
            this.btnFgtoFg = new ColorButton.ColorButton();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(128, 8);
            this.frmLabel.Size = new System.Drawing.Size(181, 33);
            this.frmLabel.Text = "Process Setup";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnFgtoFg);
            this.pnlMain.Controls.Add(this.btnProcessInformation);
            this.pnlMain.Size = new System.Drawing.Size(450, 272);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(452, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(39, 108);
            this.btnEdit.Size = new System.Drawing.Size(10, 10);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(23, 140);
            this.btnSave.Size = new System.Drawing.Size(10, 10);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(39, 124);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(5, 140);
            this.btnNew.Size = new System.Drawing.Size(10, 10);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(39, 92);
            this.btnClose.Size = new System.Drawing.Size(10, 10);
            this.btnClose.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(39, 140);
            this.btnPrint.Size = new System.Drawing.Size(10, 10);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 187);
            this.groupBox1.Size = new System.Drawing.Size(452, 25);
            // 
            // btnProcessInformation
            // 
            this.btnProcessInformation.Active = true;
            this.btnProcessInformation.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnProcessInformation.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcessInformation.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnProcessInformation.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnProcessInformation.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnProcessInformation.HoverColorB = System.Drawing.Color.White;
            this.btnProcessInformation.Location = new System.Drawing.Point(99, 166);
            this.btnProcessInformation.Name = "btnProcessInformation";
            this.btnProcessInformation.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnProcessInformation.NormalColorA = System.Drawing.Color.White;
            this.btnProcessInformation.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnProcessInformation.Size = new System.Drawing.Size(266, 36);
            this.btnProcessInformation.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnProcessInformation.TabIndex = 1;
            this.btnProcessInformation.Text = "MFG Process Entry";
            this.btnProcessInformation.Click += new System.EventHandler(this.btnProcessInformation_Click);
            // 
            // btnFgtoFg
            // 
            this.btnFgtoFg.Active = true;
            this.btnFgtoFg.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnFgtoFg.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFgtoFg.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnFgtoFg.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnFgtoFg.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnFgtoFg.HoverColorB = System.Drawing.Color.White;
            this.btnFgtoFg.Location = new System.Drawing.Point(99, 205);
            this.btnFgtoFg.Name = "btnFgtoFg";
            this.btnFgtoFg.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnFgtoFg.NormalColorA = System.Drawing.Color.White;
            this.btnFgtoFg.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnFgtoFg.Size = new System.Drawing.Size(266, 34);
            this.btnFgtoFg.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnFgtoFg.TabIndex = 5;
            this.btnFgtoFg.Text = "FG to FG Process Entry";
            this.btnFgtoFg.Click += new System.EventHandler(this.btnFgtoFg_Click);
            // 
            // frmProcessM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(452, 212);
            this.isEnterTabAllow = true;
            this.MinimizeBox = false;
            this.Name = "frmProcessM";
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ColorButton.ColorButton btnProcessInformation;
        private ColorButton.ColorButton btnFgtoFg;
    }
}
