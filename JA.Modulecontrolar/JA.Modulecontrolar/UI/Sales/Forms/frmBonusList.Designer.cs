namespace JA.Modulecontrolar.UI.Sales.Forms
{
    partial class frmBonusList
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
            this.DG = new MayhediDataGridView();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).BeginInit();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(382, 9);
            this.frmLabel.Size = new System.Drawing.Size(0, 33);
            this.frmLabel.Text = "";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.DG);
            this.pnlMain.Size = new System.Drawing.Size(863, 590);
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(412, 63);
            this.btnEdit.Size = new System.Drawing.Size(10, 7);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(299, 63);
            this.btnSave.Size = new System.Drawing.Size(10, 7);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(525, 63);
            this.btnDelete.Size = new System.Drawing.Size(10, 7);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(186, 63);
            this.btnNew.Size = new System.Drawing.Size(10, 7);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(747, 63);
            this.btnClose.Size = new System.Drawing.Size(10, 7);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(636, 63);
            this.btnPrint.Size = new System.Drawing.Size(10, 7);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 505);
            // 
            // DG
            // 
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG.Location = new System.Drawing.Point(4, 149);
            this.DG.Name = "DG";
            this.DG.Size = new System.Drawing.Size(852, 436);
            this.DG.TabIndex = 59;
            this.DG.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellClick);
            this.DG.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellContentClick);
            this.DG.DoubleClick += new System.EventHandler(this.DG_DoubleClick);
            // 
            // frmBonusList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(864, 530);
            this.isEnterTabAllow = true;
            this.MinimizeBox = false;
            this.Name = "frmBonusList";
            this.Load += new System.EventHandler(this.frmBonusList_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MayhediDataGridView DG;
    }
}
