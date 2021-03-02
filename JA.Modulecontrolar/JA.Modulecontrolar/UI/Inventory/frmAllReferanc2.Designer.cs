namespace JA.Modulecontrolar.UI.Inventory
{
    partial class frmAllReferanc2
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node4");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Node6");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Node8");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Node7", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("M", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("N");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("R");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAllReferanc2));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(148, 8);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.treeView1);
            this.pnlMain.Size = new System.Drawing.Size(533, 685);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(539, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(146, 553);
            this.btnEdit.Size = new System.Drawing.Size(10, 39);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(37, 553);
            this.btnSave.Size = new System.Drawing.Size(10, 39);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(146, 553);
            this.btnDelete.Size = new System.Drawing.Size(10, 39);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(12, 553);
            this.btnNew.Size = new System.Drawing.Size(10, 39);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(93, 548);
            this.btnClose.Size = new System.Drawing.Size(10, 39);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(82, 548);
            this.btnPrint.Size = new System.Drawing.Size(10, 39);
            // 
            // groupBox1
            // 
            this.groupBox1.Size = new System.Drawing.Size(539, 25);
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.White;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(2, 140);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "frmCompanyInstallmentNew";
            treeNode1.Text = "Node4";
            treeNode2.Name = "Node6";
            treeNode2.Text = "Node6";
            treeNode3.Name = "Node8";
            treeNode3.Text = "Node8";
            treeNode4.Name = "Node7";
            treeNode4.Text = "Node7";
            treeNode5.ImageIndex = -2;
            treeNode5.Name = "M";
            treeNode5.Text = "M";
            treeNode6.Name = "N";
            treeNode6.Text = "N";
            treeNode7.Name = "R";
            treeNode7.Text = "R";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7});
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(277, 514);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Camera.png");
            // 
            // frmAllReferanc2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(539, 623);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmAllReferanc2";
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imageList1;

    }
}
