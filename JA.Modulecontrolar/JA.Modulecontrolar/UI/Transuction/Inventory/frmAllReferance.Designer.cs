namespace JA.Modulecontrolar.UI.Transuction.Inventory
{
    partial class frmAllReferance
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
            this.lblName = new System.Windows.Forms.Label();
            this.uctxtRefNo = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).BeginInit();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(148, 8);
            this.frmLabel.Size = new System.Drawing.Size(230, 33);
            this.frmLabel.Text = "Batch Information";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.DG);
            this.pnlMain.Controls.Add(this.lblName);
            this.pnlMain.Controls.Add(this.uctxtRefNo);
            this.pnlMain.Size = new System.Drawing.Size(533, 558);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(539, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(146, 93);
            this.btnEdit.Size = new System.Drawing.Size(10, 10);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(37, 93);
            this.btnSave.Size = new System.Drawing.Size(10, 7);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(146, 54);
            this.btnDelete.Size = new System.Drawing.Size(10, 7);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(12, 93);
            this.btnNew.Size = new System.Drawing.Size(10, 7);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(93, 88);
            this.btnClose.Size = new System.Drawing.Size(10, 7);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(82, 88);
            this.btnPrint.Size = new System.Drawing.Size(10, 7);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 472);
            this.groupBox1.Size = new System.Drawing.Size(539, 25);
            // 
            // DG
            // 
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG.Location = new System.Drawing.Point(3, 179);
            this.DG.Name = "DG";
            this.DG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DG.Size = new System.Drawing.Size(525, 372);
            this.DG.TabIndex = 57;
            this.DG.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellContentClick);
            this.DG.DoubleClick += new System.EventHandler(this.DG_DoubleClick);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(8, 149);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(59, 18);
            this.lblName.TabIndex = 56;
            this.lblName.Text = "Name:";
            // 
            // uctxtRefNo
            // 
            this.uctxtRefNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtRefNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtRefNo.Location = new System.Drawing.Point(71, 150);
            this.uctxtRefNo.Name = "uctxtRefNo";
            this.uctxtRefNo.Size = new System.Drawing.Size(434, 23);
            this.uctxtRefNo.TabIndex = 0;
            // 
            // frmAllReferance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(539, 497);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmAllReferance";
            this.Load += new System.EventHandler(this.frmAllReferance_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MayhediDataGridView DG;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox uctxtRefNo;
    }
}
