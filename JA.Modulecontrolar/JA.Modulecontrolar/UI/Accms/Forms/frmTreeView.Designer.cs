namespace JA.Modulecontrolar.UI.Forms
{
    partial class frmTreeView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTreeView));
            this.tvwGroup = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.uctxtSeacrh = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExpandAll = new System.Windows.Forms.Button();
            this.radActive = new System.Windows.Forms.RadioButton();
            this.radInactive = new System.Windows.Forms.RadioButton();
            this.radAll = new System.Windows.Forms.RadioButton();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmLabel.Location = new System.Drawing.Point(131, 4);
            this.frmLabel.Size = new System.Drawing.Size(144, 32);
            this.frmLabel.Text = "Tree view";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.tvwGroup);
            this.pnlMain.Size = new System.Drawing.Size(639, 545);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(641, 48);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(304, 461);
            this.btnEdit.Size = new System.Drawing.Size(111, 39);
            this.btnEdit.Text = "Export";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(410, 448);
            this.btnSave.Size = new System.Drawing.Size(10, 5);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(407, 81);
            this.btnDelete.Size = new System.Drawing.Size(10, 5);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(524, 81);
            this.btnNew.Size = new System.Drawing.Size(10, 5);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(528, 461);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(417, 461);
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 501);
            this.groupBox1.Size = new System.Drawing.Size(641, 25);
            // 
            // tvwGroup
            // 
            this.tvwGroup.BackColor = System.Drawing.Color.White;
            this.tvwGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tvwGroup.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvwGroup.ImageIndex = 0;
            this.tvwGroup.ImageList = this.imageList1;
            this.tvwGroup.Location = new System.Drawing.Point(3, 138);
            this.tvwGroup.Name = "tvwGroup";
            this.tvwGroup.SelectedImageIndex = 0;
            this.tvwGroup.Size = new System.Drawing.Size(632, 403);
            this.tvwGroup.TabIndex = 14;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "FOLDRS01.ICO");
            this.imageList1.Images.SetKeyName(1, "DATA16.ICO");
            this.imageList1.Images.SetKeyName(2, "Text.ico");
            // 
            // uctxtSeacrh
            // 
            this.uctxtSeacrh.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtSeacrh.Location = new System.Drawing.Point(213, 118);
            this.uctxtSeacrh.Name = "uctxtSeacrh";
            this.uctxtSeacrh.Size = new System.Drawing.Size(18, 23);
            this.uctxtSeacrh.TabIndex = 15;
            this.uctxtSeacrh.Visible = false;
            this.uctxtSeacrh.TextChanged += new System.EventHandler(this.uctxtSeacrh_TextChanged);
            this.uctxtSeacrh.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uctxtSeacrh_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(166, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Search";
            this.label3.Visible = false;
            // 
            // btnExpandAll
            // 
            this.btnExpandAll.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpandAll.Location = new System.Drawing.Point(5, 462);
            this.btnExpandAll.Name = "btnExpandAll";
            this.btnExpandAll.Size = new System.Drawing.Size(95, 28);
            this.btnExpandAll.TabIndex = 0;
            this.btnExpandAll.Text = "E&xpand All";
            this.btnExpandAll.UseVisualStyleBackColor = true;
            this.btnExpandAll.Click += new System.EventHandler(this.btnExpandAll_Click);
            // 
            // radActive
            // 
            this.radActive.AutoSize = true;
            this.radActive.Checked = true;
            this.radActive.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radActive.Location = new System.Drawing.Point(107, 467);
            this.radActive.Name = "radActive";
            this.radActive.Size = new System.Drawing.Size(62, 18);
            this.radActive.TabIndex = 17;
            this.radActive.TabStop = true;
            this.radActive.Text = "Active";
            this.radActive.UseVisualStyleBackColor = true;
            // 
            // radInactive
            // 
            this.radInactive.AutoSize = true;
            this.radInactive.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radInactive.Location = new System.Drawing.Point(172, 467);
            this.radInactive.Name = "radInactive";
            this.radInactive.Size = new System.Drawing.Size(75, 18);
            this.radInactive.TabIndex = 18;
            this.radInactive.Text = "Inactive";
            this.radInactive.UseVisualStyleBackColor = true;
            // 
            // radAll
            // 
            this.radAll.AutoSize = true;
            this.radAll.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAll.Location = new System.Drawing.Point(253, 467);
            this.radAll.Name = "radAll";
            this.radAll.Size = new System.Drawing.Size(39, 18);
            this.radAll.TabIndex = 19;
            this.radAll.Text = "All";
            this.radAll.UseVisualStyleBackColor = true;
            // 
            // frmTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(641, 526);
            this.Controls.Add(this.radAll);
            this.Controls.Add(this.radInactive);
            this.Controls.Add(this.radActive);
            this.Controls.Add(this.btnExpandAll);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.uctxtSeacrh);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmTreeView";
            this.Load += new System.EventHandler(this.frmTreeView_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.pnlMain, 0);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.Controls.SetChildIndex(this.uctxtSeacrh, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.btnExpandAll, 0);
            this.Controls.SetChildIndex(this.radActive, 0);
            this.Controls.SetChildIndex(this.radInactive, 0);
            this.Controls.SetChildIndex(this.radAll, 0);
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvwGroup;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uctxtSeacrh;
        private System.Windows.Forms.Button btnExpandAll;
        private System.Windows.Forms.RadioButton radActive;
        private System.Windows.Forms.RadioButton radInactive;
        private System.Windows.Forms.RadioButton radAll;
    }
}
