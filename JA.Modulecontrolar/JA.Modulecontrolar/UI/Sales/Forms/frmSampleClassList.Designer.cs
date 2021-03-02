namespace JA.Modulecontrolar.UI.Sales.Forms
{
    partial class frmSampleClassList
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
            this.lblCount = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).BeginInit();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(179, 9);
            this.frmLabel.Size = new System.Drawing.Size(218, 33);
            this.frmLabel.Text = "Sample Class List";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.DG);
            this.pnlMain.Location = new System.Drawing.Point(0, 57);
            this.pnlMain.Size = new System.Drawing.Size(607, 448);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(607, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(268, 64);
            this.btnEdit.Size = new System.Drawing.Size(10, 15);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(28, 64);
            this.btnSave.Size = new System.Drawing.Size(10, 15);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(379, 64);
            this.btnDelete.Size = new System.Drawing.Size(10, 15);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(44, 64);
            this.btnNew.Size = new System.Drawing.Size(13, 15);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(490, 64);
            this.btnClose.Size = new System.Drawing.Size(10, 15);
            this.btnClose.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(6, 64);
            this.btnPrint.Size = new System.Drawing.Size(16, 15);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCount);
            this.groupBox1.Location = new System.Drawing.Point(0, 509);
            this.groupBox1.Size = new System.Drawing.Size(607, 25);
            this.groupBox1.Controls.SetChildIndex(this.lblCount, 0);
            // 
            // DG
            // 
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG.Location = new System.Drawing.Point(0, -1);
            this.DG.Name = "DG";
            this.DG.Size = new System.Drawing.Size(606, 448);
            this.DG.TabIndex = 0;
            this.DG.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellContentClick);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.ForeColor = System.Drawing.Color.Fuchsia;
            this.lblCount.Location = new System.Drawing.Point(473, 5);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(16, 14);
            this.lblCount.TabIndex = 20;
            this.lblCount.Text = "0";
            // 
            // frmSampleClassList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(607, 534);
            this.isEnterTabAllow = true;
            this.MinimizeBox = false;
            this.Name = "frmSampleClassList";
            this.Load += new System.EventHandler(this.frmListSampleClass_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MayhediDataGridView DG;
        private System.Windows.Forms.Label lblCount;
    }
}
