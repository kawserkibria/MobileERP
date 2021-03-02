
using System;
using System.Reflection;
namespace JA.Modulecontrolar.UI.Inventory
{
    partial class frmMain
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node7");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Node4", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Master", new System.Windows.Forms.TreeNode[] {
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Node8");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Transuction", new System.Windows.Forms.TreeNode[] {
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Node9");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Report", new System.Windows.Forms.TreeNode[] {
            treeNode6});
            this.treeView1 = new System.Windows.Forms.TreeView();
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
            this.treeView1.Location = new System.Drawing.Point(-1, 148);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "frmMaterialType";
            treeNode1.Text = "Node7";
            treeNode2.Name = "frmAllReferance";
            treeNode2.Text = "Node4";
            treeNode3.Name = "Master";
            treeNode3.Text = "Master";
            treeNode4.Name = "Node8";
            treeNode4.Text = "Node8";
            treeNode5.Name = "Transuction";
            treeNode5.Text = "Transuction";
            treeNode6.Name = "Node9";
            treeNode6.Text = "Node9";
            treeNode7.Name = "Report";
            treeNode7.Text = "Report";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode5,
            treeNode7});
            this.treeView1.Size = new System.Drawing.Size(156, 458);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.Click += new System.EventHandler(this.treeView1_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(539, 623);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;

    }
}
