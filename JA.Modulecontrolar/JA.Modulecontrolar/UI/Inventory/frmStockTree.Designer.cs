namespace JA.Modulecontrolar.UI.Inventory
{
    partial class frmStockTree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStockTree));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tvwGroup = new System.Windows.Forms.TreeView();
            this.btnExpandAll = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(199, 4);
            this.frmLabel.Text = "Stock Tree View";
            this.frmLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.tvwGroup);
            this.pnlMain.Size = new System.Drawing.Size(652, 575);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(655, 47);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(302, 489);
            this.btnEdit.Size = new System.Drawing.Size(122, 36);
            this.btnEdit.Text = "Export";
            this.btnEdit.Visible = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(191, 436);
            this.btnSave.Size = new System.Drawing.Size(10, 16);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(302, 436);
            this.btnDelete.Size = new System.Drawing.Size(10, 16);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(77, 436);
            this.btnNew.Size = new System.Drawing.Size(10, 16);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(540, 489);
            this.btnClose.Size = new System.Drawing.Size(108, 36);
            this.btnClose.Visible = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(429, 489);
            this.btnPrint.Size = new System.Drawing.Size(108, 36);
            this.btnPrint.Visible = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 525);
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
            // tvwGroup
            // 
            this.tvwGroup.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tvwGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tvwGroup.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvwGroup.ImageIndex = 0;
            this.tvwGroup.ImageList = this.imageList1;
            this.tvwGroup.Location = new System.Drawing.Point(3, 140);
            this.tvwGroup.Name = "tvwGroup";
            this.tvwGroup.SelectedImageIndex = 0;
            this.tvwGroup.Size = new System.Drawing.Size(644, 431);
            this.tvwGroup.TabIndex = 15;
            // 
            // btnExpandAll
            // 
            this.btnExpandAll.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpandAll.Location = new System.Drawing.Point(12, 496);
            this.btnExpandAll.Name = "btnExpandAll";
            this.btnExpandAll.Size = new System.Drawing.Size(105, 28);
            this.btnExpandAll.TabIndex = 15;
            this.btnExpandAll.Text = "E&xpand All";
            this.btnExpandAll.UseVisualStyleBackColor = true;
            this.btnExpandAll.Click += new System.EventHandler(this.btnExpandAll_Click);
            // 
            // frmStockTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(655, 550);
            this.Controls.Add(this.btnExpandAll);
            this.isEnterTabAllow = true;
            this.MinimizeBox = false;
            this.Name = "frmStockTree";
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
        private System.Windows.Forms.TreeView tvwGroup;
        private System.Windows.Forms.Button btnExpandAll;
    }
}
