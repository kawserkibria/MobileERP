namespace JA.Modulecontrolar.UI.Inventory
{
    partial class frmBatchTree
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBatchTree));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tvNode = new System.Windows.Forms.TreeView();
            this.btnExpandAll = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(57, 4);
            this.frmLabel.Size = new System.Drawing.Size(0, 33);
            this.frmLabel.Text = "";
            this.frmLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.tvNode);
            this.pnlMain.Size = new System.Drawing.Size(652, 664);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(655, 49);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(306, 583);
            this.btnEdit.Size = new System.Drawing.Size(122, 39);
            this.btnEdit.Text = "Export";
            this.btnEdit.Visible = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(191, 312);
            this.btnSave.Size = new System.Drawing.Size(5, 10);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(302, 312);
            this.btnDelete.Size = new System.Drawing.Size(5, 10);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(77, 312);
            this.btnNew.Size = new System.Drawing.Size(8, 10);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(544, 583);
            this.btnClose.Visible = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(433, 583);
            this.btnPrint.Visible = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 624);
            this.groupBox1.Size = new System.Drawing.Size(655, 25);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "FOLDRS01.ICO");
            this.imageList1.Images.SetKeyName(1, "DATA16.ICO");
            this.imageList1.Images.SetKeyName(2, "Text.ico");
            // 
            // tvNode
            // 
            this.tvNode.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tvNode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tvNode.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvNode.ImageIndex = 0;
            this.tvNode.ImageList = this.imageList1;
            this.tvNode.Location = new System.Drawing.Point(3, 140);
            this.tvNode.Name = "tvNode";
            this.tvNode.SelectedImageIndex = 0;
            this.tvNode.Size = new System.Drawing.Size(644, 518);
            this.tvNode.TabIndex = 15;
            // 
            // btnExpandAll
            // 
            this.btnExpandAll.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpandAll.Location = new System.Drawing.Point(6, 583);
            this.btnExpandAll.Name = "btnExpandAll";
            this.btnExpandAll.Size = new System.Drawing.Size(95, 28);
            this.btnExpandAll.TabIndex = 15;
            this.btnExpandAll.Text = "E&xpand All";
            this.btnExpandAll.UseVisualStyleBackColor = true;
            this.btnExpandAll.Click += new System.EventHandler(this.btnExpandAll_Click);
            // 
            // frmBatchTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(655, 649);
            this.Controls.Add(this.btnExpandAll);
            this.isEnterTabAllow = true;
            this.MinimizeBox = false;
            this.Name = "frmBatchTree";
            this.Load += new System.EventHandler(this.frmStockTree_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.pnlMain, 0);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.Controls.SetChildIndex(this.btnExpandAll, 0);
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TreeView tvNode;
        private System.Windows.Forms.Button btnExpandAll;
    }
}
