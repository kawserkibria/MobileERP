namespace JA.Modulecontrolar.UI.Sales.Forms
{
    partial class frmTransportList
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
            this.frmLabel.Location = new System.Drawing.Point(179, 9);
            this.frmLabel.Size = new System.Drawing.Size(179, 33);
            this.frmLabel.Text = "Transport List";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.DG);
            this.pnlMain.Location = new System.Drawing.Point(0, 57);
            this.pnlMain.Size = new System.Drawing.Size(553, 444);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(553, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(219, 64);
            this.btnEdit.Size = new System.Drawing.Size(13, 10);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(28, 64);
            this.btnSave.Size = new System.Drawing.Size(10, 17);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(330, 64);
            this.btnDelete.Size = new System.Drawing.Size(15, 11);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(44, 64);
            this.btnNew.Size = new System.Drawing.Size(17, 10);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(441, 64);
            this.btnClose.Size = new System.Drawing.Size(15, 10);
            this.btnClose.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(6, 64);
            this.btnPrint.Size = new System.Drawing.Size(16, 11);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 505);
            this.groupBox1.Size = new System.Drawing.Size(553, 25);
            // 
            // DG
            // 
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG.Location = new System.Drawing.Point(0, -1);
            this.DG.Name = "DG";
            this.DG.Size = new System.Drawing.Size(551, 441);
            this.DG.TabIndex = 0;
            this.DG.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellContentClick);
            // 
            // frmTransportList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(553, 530);
            this.isEnterTabAllow = true;
            this.MinimizeBox = false;
            this.Name = "frmTransportList";
            this.Load += new System.EventHandler(this.frmListTransport_Load);
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
