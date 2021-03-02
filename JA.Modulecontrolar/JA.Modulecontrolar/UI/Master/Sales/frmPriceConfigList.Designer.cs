namespace JA.Modulecontrolar.UI.Master.Inventory
{
    partial class frmPriceConfigList
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
            this.frmLabel.Location = new System.Drawing.Point(266, 9);
            this.frmLabel.Size = new System.Drawing.Size(357, 33);
            this.frmLabel.Text = "Sales Price Configuration List";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.DG);
            this.pnlMain.Size = new System.Drawing.Size(863, 578);
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(412, 455);
            this.btnEdit.Size = new System.Drawing.Size(10, 8);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(299, 455);
            this.btnSave.Size = new System.Drawing.Size(10, 8);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(525, 455);
            this.btnDelete.Size = new System.Drawing.Size(10, 8);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(186, 455);
            this.btnNew.Size = new System.Drawing.Size(10, 8);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(747, 455);
            this.btnClose.Size = new System.Drawing.Size(10, 8);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(636, 455);
            this.btnPrint.Size = new System.Drawing.Size(10, 8);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 491);
            // 
            // DG
            // 
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG.Location = new System.Drawing.Point(4, 149);
            this.DG.Name = "DG";
            this.DG.Size = new System.Drawing.Size(852, 425);
            this.DG.TabIndex = 59;
            this.DG.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellClick);
            this.DG.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellContentClick);
            this.DG.DoubleClick += new System.EventHandler(this.DG_DoubleClick);
            // 
            // frmPriceConfigList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(864, 516);
            this.isEnterTabAllow = true;
            this.MinimizeBox = false;
            this.Name = "frmPriceConfigList";
            this.Load += new System.EventHandler(this.frmPriceConfigList_Load);
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
