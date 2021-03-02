namespace JA.Modulecontrolar.UI.Inventory
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
            this.label4 = new System.Windows.Forms.Label();
            this.uctxtGroupName = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).BeginInit();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(148, 8);
            this.frmLabel.Size = new System.Drawing.Size(191, 33);
            this.frmLabel.Text = "Stock Item List";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.uctxtGroupName);
            this.pnlMain.Controls.Add(this.DG);
            this.pnlMain.Controls.Add(this.lblName);
            this.pnlMain.Controls.Add(this.uctxtRefNo);
            this.pnlMain.Size = new System.Drawing.Size(627, 685);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(630, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(146, 553);
            this.btnEdit.Size = new System.Drawing.Size(10, 3);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(37, 553);
            this.btnSave.Size = new System.Drawing.Size(10, 3);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(146, 553);
            this.btnDelete.Size = new System.Drawing.Size(10, 3);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(12, 553);
            this.btnNew.Size = new System.Drawing.Size(10, 3);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(93, 548);
            this.btnClose.Size = new System.Drawing.Size(10, 3);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(82, 548);
            this.btnPrint.Size = new System.Drawing.Size(10, 3);
            // 
            // groupBox1
            // 
            this.groupBox1.Size = new System.Drawing.Size(630, 25);
            // 
            // DG
            // 
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG.Location = new System.Drawing.Point(3, 206);
            this.DG.Name = "DG";
            this.DG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DG.Size = new System.Drawing.Size(614, 474);
            this.DG.TabIndex = 57;
          
            this.DG.DoubleClick += new System.EventHandler(this.DG_DoubleClick);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(229, 156);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(92, 18);
            this.lblName.TabIndex = 56;
            this.lblName.Text = "Item Name";
            // 
            // uctxtRefNo
            // 
            this.uctxtRefNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtRefNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtRefNo.Location = new System.Drawing.Point(229, 177);
            this.uctxtRefNo.Name = "uctxtRefNo";
            this.uctxtRefNo.Size = new System.Drawing.Size(295, 23);
            this.uctxtRefNo.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.label4.Location = new System.Drawing.Point(14, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 18);
            this.label4.TabIndex = 137;
            this.label4.Tag = "";
            this.label4.Text = "Group Name";
            // 
            // uctxtGroupName
            // 
            this.uctxtGroupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtGroupName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtGroupName.Location = new System.Drawing.Point(14, 177);
            this.uctxtGroupName.Name = "uctxtGroupName";
            this.uctxtGroupName.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtGroupName.Size = new System.Drawing.Size(212, 22);
            this.uctxtGroupName.TabIndex = 136;
            this.uctxtGroupName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmAllReferance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(630, 623);
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox uctxtGroupName;
    }
}
