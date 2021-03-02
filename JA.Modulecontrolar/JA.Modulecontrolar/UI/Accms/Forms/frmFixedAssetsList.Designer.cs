namespace JA.Modulecontrolar.UI.Accms.Forms
{
    partial class frmFixedAssetsList
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
            this.DG = new System.Windows.Forms.DataGridView();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).BeginInit();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(328, 8);
            this.frmLabel.Size = new System.Drawing.Size(208, 33);
            this.frmLabel.Text = "Fixed Assets List";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.DG);
            this.pnlMain.Size = new System.Drawing.Size(863, 574);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(412, 454);
            this.btnEdit.Size = new System.Drawing.Size(10, 12);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(299, 454);
            this.btnSave.Size = new System.Drawing.Size(10, 12);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(525, 454);
            this.btnDelete.Size = new System.Drawing.Size(10, 15);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(186, 454);
            this.btnNew.Size = new System.Drawing.Size(10, 15);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(747, 454);
            this.btnClose.Size = new System.Drawing.Size(10, 11);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(636, 454);
            this.btnPrint.Size = new System.Drawing.Size(10, 16);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 487);
            // 
            // DG
            // 
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG.Location = new System.Drawing.Point(3, 150);
            this.DG.Name = "DG";
            this.DG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DG.Size = new System.Drawing.Size(856, 420);
            this.DG.TabIndex = 1;
            this.DG.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellContentClick);
            // 
            // frmFixedAssetsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(864, 512);
            this.isEnterTabAllow = true;
            this.MinimizeBox = false;
            this.Name = "frmFixedAssetsList";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFixedAssetsList_FormClosing);
            this.Load += new System.EventHandler(this.frmFixedAssetsList_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DG;
    }
}
