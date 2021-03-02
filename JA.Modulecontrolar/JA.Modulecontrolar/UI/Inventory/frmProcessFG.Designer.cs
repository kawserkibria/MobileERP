namespace JA.Modulecontrolar.UI.Inventory
{
    partial class frmProcessFG
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcessFG));
            this.label5 = new System.Windows.Forms.Label();
            this.uctxtProcessName = new System.Windows.Forms.TextBox();
            this.grpSelction = new System.Windows.Forms.GroupBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnLeftAll = new System.Windows.Forms.Button();
            this.btnLeftSingle = new System.Windows.Forms.Button();
            this.btnRightAll = new System.Windows.Forms.Button();
            this.btnRightSingle = new System.Windows.Forms.Button();
            this.lstRight = new System.Windows.Forms.ListBox();
            this.lstLeft = new System.Windows.Forms.ListBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtFGQty = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.uctxtFGItem = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnSerach1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.uctxtLocation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.uctxtBranchName = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpSelction.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(215, 0);
            this.frmLabel.Size = new System.Drawing.Size(254, 33);
            this.frmLabel.Text = "FG Process Mapping";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.uctxtBranchName);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.uctxtLocation);
            this.pnlMain.Controls.Add(this.btnSerach1);
            this.pnlMain.Controls.Add(this.label19);
            this.pnlMain.Controls.Add(this.txtFGQty);
            this.pnlMain.Controls.Add(this.label20);
            this.pnlMain.Controls.Add(this.uctxtFGItem);
            this.pnlMain.Controls.Add(this.grpSelction);
            this.pnlMain.Controls.Add(this.uctxtProcessName);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Size = new System.Drawing.Size(649, 568);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(655, 51);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(11, 482);
            this.btnEdit.Size = new System.Drawing.Size(124, 35);
            this.btnEdit.Text = "List All";
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(427, 482);
            this.btnSave.Size = new System.Drawing.Size(108, 35);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(331, 489);
            this.btnDelete.Size = new System.Drawing.Size(10, 8);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(470, 491);
            this.btnNew.Size = new System.Drawing.Size(10, 10);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(540, 482);
            this.btnClose.Size = new System.Drawing.Size(108, 35);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(442, 489);
            this.btnPrint.Size = new System.Drawing.Size(10, 10);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 517);
            this.groupBox1.Size = new System.Drawing.Size(655, 25);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(84, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 18);
            this.label5.TabIndex = 50;
            this.label5.Text = "Process Name:";
            // 
            // uctxtProcessName
            // 
            this.uctxtProcessName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtProcessName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtProcessName.Location = new System.Drawing.Point(211, 143);
            this.uctxtProcessName.MaxLength = 50;
            this.uctxtProcessName.Name = "uctxtProcessName";
            this.uctxtProcessName.Size = new System.Drawing.Size(377, 23);
            this.uctxtProcessName.TabIndex = 49;
            // 
            // grpSelction
            // 
            this.grpSelction.Controls.Add(this.txtSearch);
            this.grpSelction.Controls.Add(this.btnLeftAll);
            this.grpSelction.Controls.Add(this.btnLeftSingle);
            this.grpSelction.Controls.Add(this.btnRightAll);
            this.grpSelction.Controls.Add(this.btnRightSingle);
            this.grpSelction.Controls.Add(this.lstRight);
            this.grpSelction.Controls.Add(this.lstLeft);
            this.grpSelction.Location = new System.Drawing.Point(13, 282);
            this.grpSelction.Name = "grpSelction";
            this.grpSelction.Size = new System.Drawing.Size(623, 275);
            this.grpSelction.TabIndex = 51;
            this.grpSelction.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(8, 18);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(277, 22);
            this.txtSearch.TabIndex = 7;
            // 
            // btnLeftAll
            // 
            this.btnLeftAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLeftAll.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftAll.Location = new System.Drawing.Point(287, 110);
            this.btnLeftAll.Name = "btnLeftAll";
            this.btnLeftAll.Size = new System.Drawing.Size(36, 23);
            this.btnLeftAll.TabIndex = 5;
            this.btnLeftAll.Text = "<<";
            this.btnLeftAll.UseVisualStyleBackColor = false;
            this.btnLeftAll.Visible = false;
            // 
            // btnLeftSingle
            // 
            this.btnLeftSingle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLeftSingle.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftSingle.Location = new System.Drawing.Point(287, 85);
            this.btnLeftSingle.Name = "btnLeftSingle";
            this.btnLeftSingle.Size = new System.Drawing.Size(36, 23);
            this.btnLeftSingle.TabIndex = 4;
            this.btnLeftSingle.Text = "<";
            this.btnLeftSingle.UseVisualStyleBackColor = false;
            // 
            // btnRightAll
            // 
            this.btnRightAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRightAll.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRightAll.Location = new System.Drawing.Point(287, 60);
            this.btnRightAll.Name = "btnRightAll";
            this.btnRightAll.Size = new System.Drawing.Size(36, 23);
            this.btnRightAll.TabIndex = 3;
            this.btnRightAll.Text = ">>";
            this.btnRightAll.UseVisualStyleBackColor = false;
            this.btnRightAll.Visible = false;
            this.btnRightAll.Click += new System.EventHandler(this.btnRightAll_Click_1);
            // 
            // btnRightSingle
            // 
            this.btnRightSingle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRightSingle.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRightSingle.Location = new System.Drawing.Point(287, 35);
            this.btnRightSingle.Name = "btnRightSingle";
            this.btnRightSingle.Size = new System.Drawing.Size(36, 23);
            this.btnRightSingle.TabIndex = 2;
            this.btnRightSingle.Text = ">";
            this.btnRightSingle.UseVisualStyleBackColor = false;
            this.btnRightSingle.Click += new System.EventHandler(this.btnRightSingle_Click_1);
            // 
            // lstRight
            // 
            this.lstRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstRight.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstRight.FormattingEnabled = true;
            this.lstRight.ItemHeight = 14;
            this.lstRight.Location = new System.Drawing.Point(327, 13);
            this.lstRight.Name = "lstRight";
            this.lstRight.Size = new System.Drawing.Size(280, 254);
            this.lstRight.TabIndex = 1;
            // 
            // lstLeft
            // 
            this.lstLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstLeft.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLeft.FormattingEnabled = true;
            this.lstLeft.ItemHeight = 14;
            this.lstLeft.Location = new System.Drawing.Point(6, 41);
            this.lstLeft.Name = "lstLeft";
            this.lstLeft.Size = new System.Drawing.Size(280, 226);
            this.lstLeft.TabIndex = 0;
            this.lstLeft.DoubleClick += new System.EventHandler(this.lstLeft_DoubleClick);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(164, 194);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(42, 16);
            this.label19.TabIndex = 112;
            this.label19.Text = "Qty.:";
            // 
            // txtFGQty
            // 
            this.txtFGQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFGQty.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFGQty.Location = new System.Drawing.Point(211, 192);
            this.txtFGQty.Name = "txtFGQty";
            this.txtFGQty.Size = new System.Drawing.Size(120, 23);
            this.txtFGQty.TabIndex = 111;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(59, 170);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(147, 16);
            this.label20.TabIndex = 110;
            this.label20.Text = "Finished Goods Item:";
            // 
            // uctxtFGItem
            // 
            this.uctxtFGItem.BackColor = System.Drawing.Color.White;
            this.uctxtFGItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtFGItem.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtFGItem.Location = new System.Drawing.Point(211, 168);
            this.uctxtFGItem.Name = "uctxtFGItem";
            this.uctxtFGItem.ReadOnly = true;
            this.uctxtFGItem.Size = new System.Drawing.Size(238, 23);
            this.uctxtFGItem.TabIndex = 109;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-search-48.png");
            // 
            // btnSerach1
            // 
            this.btnSerach1.BackColor = System.Drawing.Color.White;
            this.btnSerach1.ForeColor = System.Drawing.Color.Teal;
            this.btnSerach1.ImageIndex = 0;
            this.btnSerach1.ImageList = this.imageList1;
            this.btnSerach1.Location = new System.Drawing.Point(446, 167);
            this.btnSerach1.Name = "btnSerach1";
            this.btnSerach1.Size = new System.Drawing.Size(30, 25);
            this.btnSerach1.TabIndex = 113;
            this.btnSerach1.UseVisualStyleBackColor = false;
            this.btnSerach1.Click += new System.EventHandler(this.btnSerach1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(95, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 16);
            this.label4.TabIndex = 115;
            this.label4.Text = "Location Name:";
            // 
            // uctxtLocation
            // 
            this.uctxtLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtLocation.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtLocation.Location = new System.Drawing.Point(211, 242);
            this.uctxtLocation.Name = "uctxtLocation";
            this.uctxtLocation.Size = new System.Drawing.Size(377, 23);
            this.uctxtLocation.TabIndex = 114;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(106, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 117;
            this.label3.Text = "Branch Name:";
            // 
            // uctxtBranchName
            // 
            this.uctxtBranchName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtBranchName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtBranchName.Location = new System.Drawing.Point(211, 217);
            this.uctxtBranchName.Name = "uctxtBranchName";
            this.uctxtBranchName.Size = new System.Drawing.Size(377, 23);
            this.uctxtBranchName.TabIndex = 116;
            // 
            // frmProcessFG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(655, 542);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmProcessFG";
            this.Load += new System.EventHandler(this.frmProcessFG_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.grpSelction.ResumeLayout(false);
            this.grpSelction.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox uctxtProcessName;
        private System.Windows.Forms.GroupBox grpSelction;
        private System.Windows.Forms.Button btnLeftAll;
        private System.Windows.Forms.Button btnLeftSingle;
        private System.Windows.Forms.Button btnRightAll;
        private System.Windows.Forms.Button btnRightSingle;
        private System.Windows.Forms.ListBox lstRight;
        private System.Windows.Forms.ListBox lstLeft;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtFGQty;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox uctxtFGItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnSerach1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox uctxtLocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uctxtBranchName;
        private System.Windows.Forms.TextBox txtSearch;
    }
}
