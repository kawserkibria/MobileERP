namespace JA.Modulecontrolar.UI.Inventory
{
    partial class frmStockGroupMapping
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
            this.gboxInwardPurchase = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radAlias = new System.Windows.Forms.RadioButton();
            this.radItem = new System.Windows.Forms.RadioButton();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.rbtnHerbs = new System.Windows.Forms.RadioButton();
            this.rbtnPacking = new System.Windows.Forms.RadioButton();
            this.rbtnChemical = new System.Windows.Forms.RadioButton();
            this.lstLeft = new System.Windows.Forms.ListBox();
            this.lstRight = new System.Windows.Forms.ListBox();
            this.btnRightSingle = new System.Windows.Forms.Button();
            this.btnRightAll = new System.Windows.Forms.Button();
            this.btnLeftSingle = new System.Windows.Forms.Button();
            this.btnLeftAll = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.uctxtBranchName = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.gboxInwardPurchase.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.frmLabel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmLabel.Location = new System.Drawing.Point(110, 9);
            this.frmLabel.Size = new System.Drawing.Size(368, 23);
            this.frmLabel.Text = "Stock Group Mapping For Stock Estimetion";
            this.frmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.frmLabel.Click += new System.EventHandler(this.frmLabel_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.uctxtBranchName);
            this.pnlMain.Controls.Add(this.lblCategory);
            this.pnlMain.Controls.Add(this.groupBox7);
            this.pnlMain.Controls.Add(this.groupBox9);
            this.pnlMain.Controls.Add(this.gboxInwardPurchase);
            this.pnlMain.Size = new System.Drawing.Size(570, 425);
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(575, 51);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(346, 290);
            this.btnEdit.Size = new System.Drawing.Size(10, 14);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(342, 344);
            this.btnSave.Size = new System.Drawing.Size(119, 35);
            this.btnSave.Visible = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(459, 290);
            this.btnDelete.Size = new System.Drawing.Size(10, 14);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(120, 290);
            this.btnNew.Size = new System.Drawing.Size(10, 14);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(462, 344);
            this.btnClose.Size = new System.Drawing.Size(108, 35);
            this.btnClose.Visible = true;
            // 
            // btnPrint
            // 
            this.btnPrint.ImageIndex = -1;
            this.btnPrint.ImageKey = "print.png";
            this.btnPrint.Location = new System.Drawing.Point(332, 297);
            this.btnPrint.Size = new System.Drawing.Size(10, 11);
            this.btnPrint.Text = "Preview";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 380);
            this.groupBox1.Size = new System.Drawing.Size(575, 25);
            // 
            // gboxInwardPurchase
            // 
            this.gboxInwardPurchase.Controls.Add(this.groupBox3);
            this.gboxInwardPurchase.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gboxInwardPurchase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gboxInwardPurchase.Location = new System.Drawing.Point(6, 484);
            this.gboxInwardPurchase.Name = "gboxInwardPurchase";
            this.gboxInwardPurchase.Size = new System.Drawing.Size(10, 11);
            this.gboxInwardPurchase.TabIndex = 62;
            this.gboxInwardPurchase.TabStop = false;
            this.gboxInwardPurchase.Text = "Invoice/Purchase Price Option";
            this.gboxInwardPurchase.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radAlias);
            this.groupBox3.Controls.Add(this.radItem);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(6, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(320, 35);
            this.groupBox3.TabIndex = 61;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sort Order";
            // 
            // radAlias
            // 
            this.radAlias.AutoSize = true;
            this.radAlias.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAlias.ForeColor = System.Drawing.Color.Black;
            this.radAlias.Location = new System.Drawing.Point(206, 9);
            this.radAlias.Name = "radAlias";
            this.radAlias.Size = new System.Drawing.Size(54, 18);
            this.radAlias.TabIndex = 1;
            this.radAlias.Text = "Alias";
            this.radAlias.UseVisualStyleBackColor = true;
            // 
            // radItem
            // 
            this.radItem.AutoSize = true;
            this.radItem.Checked = true;
            this.radItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radItem.ForeColor = System.Drawing.Color.Black;
            this.radItem.Location = new System.Drawing.Point(85, 9);
            this.radItem.Name = "radItem";
            this.radItem.Size = new System.Drawing.Size(94, 18);
            this.radItem.TabIndex = 0;
            this.radItem.TabStop = true;
            this.radItem.Text = "Item Name";
            this.radItem.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.rbtnHerbs);
            this.groupBox9.Controls.Add(this.rbtnPacking);
            this.groupBox9.Controls.Add(this.rbtnChemical);
            this.groupBox9.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox9.ForeColor = System.Drawing.Color.Black;
            this.groupBox9.Location = new System.Drawing.Point(62, 139);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(437, 47);
            this.groupBox9.TabIndex = 66;
            this.groupBox9.TabStop = false;
            // 
            // rbtnHerbs
            // 
            this.rbtnHerbs.AutoSize = true;
            this.rbtnHerbs.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnHerbs.ForeColor = System.Drawing.Color.Black;
            this.rbtnHerbs.Location = new System.Drawing.Point(194, 19);
            this.rbtnHerbs.Name = "rbtnHerbs";
            this.rbtnHerbs.Size = new System.Drawing.Size(69, 22);
            this.rbtnHerbs.TabIndex = 3;
            this.rbtnHerbs.Text = "Herbs";
            this.rbtnHerbs.UseVisualStyleBackColor = true;
            this.rbtnHerbs.Click += new System.EventHandler(this.rbtnHerbs_Click);
            // 
            // rbtnPacking
            // 
            this.rbtnPacking.AutoSize = true;
            this.rbtnPacking.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPacking.ForeColor = System.Drawing.Color.Black;
            this.rbtnPacking.Location = new System.Drawing.Point(313, 19);
            this.rbtnPacking.Name = "rbtnPacking";
            this.rbtnPacking.Size = new System.Drawing.Size(82, 22);
            this.rbtnPacking.TabIndex = 1;
            this.rbtnPacking.Text = "Packing";
            this.rbtnPacking.UseVisualStyleBackColor = true;
            this.rbtnPacking.Click += new System.EventHandler(this.rbtnPacking_Click);
            // 
            // rbtnChemical
            // 
            this.rbtnChemical.AutoSize = true;
            this.rbtnChemical.Checked = true;
            this.rbtnChemical.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnChemical.ForeColor = System.Drawing.Color.Black;
            this.rbtnChemical.Location = new System.Drawing.Point(41, 19);
            this.rbtnChemical.Name = "rbtnChemical";
            this.rbtnChemical.Size = new System.Drawing.Size(101, 22);
            this.rbtnChemical.TabIndex = 0;
            this.rbtnChemical.TabStop = true;
            this.rbtnChemical.Text = "Chemicals";
            this.rbtnChemical.UseVisualStyleBackColor = true;
            this.rbtnChemical.CheckedChanged += new System.EventHandler(this.rbtnChemical_CheckedChanged);
            this.rbtnChemical.Click += new System.EventHandler(this.rbtnChemical_Click);
            // 
            // lstLeft
            // 
            this.lstLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstLeft.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLeft.FormattingEnabled = true;
            this.lstLeft.ItemHeight = 14;
            this.lstLeft.Location = new System.Drawing.Point(6, 53);
            this.lstLeft.Name = "lstLeft";
            this.lstLeft.Size = new System.Drawing.Size(254, 128);
            this.lstLeft.TabIndex = 0;
            // 
            // lstRight
            // 
            this.lstRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstRight.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstRight.FormattingEnabled = true;
            this.lstRight.ItemHeight = 14;
            this.lstRight.Location = new System.Drawing.Point(308, 52);
            this.lstRight.Name = "lstRight";
            this.lstRight.Size = new System.Drawing.Size(221, 128);
            this.lstRight.TabIndex = 1;
            // 
            // btnRightSingle
            // 
            this.btnRightSingle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRightSingle.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRightSingle.Location = new System.Drawing.Point(268, 64);
            this.btnRightSingle.Name = "btnRightSingle";
            this.btnRightSingle.Size = new System.Drawing.Size(36, 23);
            this.btnRightSingle.TabIndex = 2;
            this.btnRightSingle.Text = ">";
            this.btnRightSingle.UseVisualStyleBackColor = false;
            this.btnRightSingle.Click += new System.EventHandler(this.btnRightSingle_Click);
            // 
            // btnRightAll
            // 
            this.btnRightAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRightAll.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRightAll.Location = new System.Drawing.Point(268, 89);
            this.btnRightAll.Name = "btnRightAll";
            this.btnRightAll.Size = new System.Drawing.Size(36, 23);
            this.btnRightAll.TabIndex = 3;
            this.btnRightAll.Text = ">>";
            this.btnRightAll.UseVisualStyleBackColor = false;
            this.btnRightAll.Click += new System.EventHandler(this.btnRightAll_Click);
            // 
            // btnLeftSingle
            // 
            this.btnLeftSingle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLeftSingle.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftSingle.Location = new System.Drawing.Point(268, 114);
            this.btnLeftSingle.Name = "btnLeftSingle";
            this.btnLeftSingle.Size = new System.Drawing.Size(36, 23);
            this.btnLeftSingle.TabIndex = 4;
            this.btnLeftSingle.Text = "<";
            this.btnLeftSingle.UseVisualStyleBackColor = false;
            this.btnLeftSingle.Click += new System.EventHandler(this.btnLeftSingle_Click);
            // 
            // btnLeftAll
            // 
            this.btnLeftAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLeftAll.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftAll.Location = new System.Drawing.Point(268, 139);
            this.btnLeftAll.Name = "btnLeftAll";
            this.btnLeftAll.Size = new System.Drawing.Size(36, 23);
            this.btnLeftAll.TabIndex = 5;
            this.btnLeftAll.Text = "<<";
            this.btnLeftAll.UseVisualStyleBackColor = false;
            this.btnLeftAll.Click += new System.EventHandler(this.btnLeftAll_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(6, 30);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(254, 22);
            this.txtSearch.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(6, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "Search";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.txtSearch);
            this.groupBox7.Controls.Add(this.btnLeftAll);
            this.groupBox7.Controls.Add(this.btnLeftSingle);
            this.groupBox7.Controls.Add(this.btnRightAll);
            this.groupBox7.Controls.Add(this.btnRightSingle);
            this.groupBox7.Controls.Add(this.lstRight);
            this.groupBox7.Controls.Add(this.lstLeft);
            this.groupBox7.Location = new System.Drawing.Point(24, 227);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(534, 190);
            this.groupBox7.TabIndex = 72;
            this.groupBox7.TabStop = false;
            // 
            // uctxtBranchName
            // 
            this.uctxtBranchName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtBranchName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtBranchName.Location = new System.Drawing.Point(158, 200);
            this.uctxtBranchName.Name = "uctxtBranchName";
            this.uctxtBranchName.Size = new System.Drawing.Size(350, 23);
            this.uctxtBranchName.TabIndex = 73;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(60, 203);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(95, 14);
            this.lblCategory.TabIndex = 74;
            this.lblCategory.Text = "Branch Name:";
            // 
            // frmStockGroupMapping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(575, 405);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmStockGroupMapping";
            this.Load += new System.EventHandler(this.frmStockGroupMapping_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.gboxInwardPurchase.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxInwardPurchase;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radAlias;
        private System.Windows.Forms.RadioButton radItem;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.RadioButton rbtnHerbs;
        private System.Windows.Forms.RadioButton rbtnPacking;
        private System.Windows.Forms.RadioButton rbtnChemical;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnLeftAll;
        private System.Windows.Forms.Button btnLeftSingle;
        private System.Windows.Forms.Button btnRightAll;
        private System.Windows.Forms.Button btnRightSingle;
        private System.Windows.Forms.ListBox lstRight;
        private System.Windows.Forms.ListBox lstLeft;
        private System.Windows.Forms.TextBox uctxtBranchName;
        private System.Windows.Forms.Label lblCategory;
    }
}
