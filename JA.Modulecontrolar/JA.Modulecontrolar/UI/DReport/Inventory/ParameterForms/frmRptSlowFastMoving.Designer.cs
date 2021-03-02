namespace JA.Modulecontrolar.UI.DReport.Inventory.ParameterForms
{
    partial class frmRptSlowFastMoving
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radSelection = new System.Windows.Forms.RadioButton();
            this.radAllItem = new System.Windows.Forms.RadioButton();
            this.grpReportOption = new System.Windows.Forms.GroupBox();
            this.radCategory = new System.Windows.Forms.RadioButton();
            this.radItemWise = new System.Windows.Forms.RadioButton();
            this.radGroupwise = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dteToDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dteFromDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnLeftAll = new System.Windows.Forms.Button();
            this.btnLeftSingle = new System.Windows.Forms.Button();
            this.btnRightAll = new System.Windows.Forms.Button();
            this.btnRightSingle = new System.Windows.Forms.Button();
            this.lstRight = new System.Windows.Forms.ListBox();
            this.lstLeft = new System.Windows.Forms.ListBox();
            this.grpOption = new System.Windows.Forms.GroupBox();
            this.radZeroMoving = new System.Windows.Forms.RadioButton();
            this.radFastMoving = new System.Windows.Forms.RadioButton();
            this.radSlowMoving = new System.Windows.Forms.RadioButton();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpReportOption.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Size = new System.Drawing.Size(221, 33);
            this.frmLabel.Text = "Slow Fast Moving";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.groupBox7);
            this.pnlMain.Controls.Add(this.groupBox6);
            this.pnlMain.Controls.Add(this.grpReportOption);
            this.pnlMain.Controls.Add(this.grpOption);
            this.pnlMain.Controls.Add(this.groupBox2);
            this.pnlMain.Size = new System.Drawing.Size(863, 548);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(447, 430);
            this.btnEdit.Size = new System.Drawing.Size(10, 12);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(334, 430);
            this.btnSave.Size = new System.Drawing.Size(10, 10);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(560, 430);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(221, 430);
            this.btnNew.Size = new System.Drawing.Size(10, 17);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(752, 463);
            this.btnClose.Visible = true;
            // 
            // btnPrint
            // 
            this.btnPrint.ImageIndex = -1;
            this.btnPrint.ImageKey = "print.png";
            this.btnPrint.Location = new System.Drawing.Point(627, 463);
            this.btnPrint.Size = new System.Drawing.Size(124, 39);
            this.btnPrint.Text = "Preview";
            this.btnPrint.Visible = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 502);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radSelection);
            this.groupBox2.Controls.Add(this.radAllItem);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(11, 151);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 70);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selection Option";
            // 
            // radSelection
            // 
            this.radSelection.AutoSize = true;
            this.radSelection.Location = new System.Drawing.Point(22, 48);
            this.radSelection.Name = "radSelection";
            this.radSelection.Size = new System.Drawing.Size(82, 18);
            this.radSelection.TabIndex = 2;
            this.radSelection.Text = "Selection";
            this.radSelection.UseVisualStyleBackColor = true;
            this.radSelection.Click += new System.EventHandler(this.radSelection_Click);
            // 
            // radAllItem
            // 
            this.radAllItem.AutoSize = true;
            this.radAllItem.Checked = true;
            this.radAllItem.Location = new System.Drawing.Point(22, 24);
            this.radAllItem.Name = "radAllItem";
            this.radAllItem.Size = new System.Drawing.Size(43, 18);
            this.radAllItem.TabIndex = 1;
            this.radAllItem.TabStop = true;
            this.radAllItem.Text = "All ";
            this.radAllItem.UseVisualStyleBackColor = true;
            this.radAllItem.CheckedChanged += new System.EventHandler(this.radAllItem_CheckedChanged);
            this.radAllItem.Click += new System.EventHandler(this.radAllItem_Click);
            // 
            // grpReportOption
            // 
            this.grpReportOption.Controls.Add(this.radCategory);
            this.grpReportOption.Controls.Add(this.radItemWise);
            this.grpReportOption.Controls.Add(this.radGroupwise);
            this.grpReportOption.Enabled = false;
            this.grpReportOption.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpReportOption.Location = new System.Drawing.Point(677, 150);
            this.grpReportOption.Name = "grpReportOption";
            this.grpReportOption.Size = new System.Drawing.Size(173, 109);
            this.grpReportOption.TabIndex = 2;
            this.grpReportOption.TabStop = false;
            this.grpReportOption.Text = "Report Option";
            // 
            // radCategory
            // 
            this.radCategory.AutoSize = true;
            this.radCategory.Location = new System.Drawing.Point(33, 86);
            this.radCategory.Name = "radCategory";
            this.radCategory.Size = new System.Drawing.Size(118, 18);
            this.radCategory.TabIndex = 3;
            this.radCategory.Text = "Category Wise";
            this.radCategory.UseVisualStyleBackColor = true;
            this.radCategory.Click += new System.EventHandler(this.radCategory_Click);
            // 
            // radItemWise
            // 
            this.radItemWise.AutoSize = true;
            this.radItemWise.Location = new System.Drawing.Point(33, 58);
            this.radItemWise.Name = "radItemWise";
            this.radItemWise.Size = new System.Drawing.Size(89, 18);
            this.radItemWise.TabIndex = 2;
            this.radItemWise.Text = "Item Wise";
            this.radItemWise.UseVisualStyleBackColor = true;
            this.radItemWise.Click += new System.EventHandler(this.radItemWise_Click);
            // 
            // radGroupwise
            // 
            this.radGroupwise.AutoSize = true;
            this.radGroupwise.Checked = true;
            this.radGroupwise.Location = new System.Drawing.Point(33, 29);
            this.radGroupwise.Name = "radGroupwise";
            this.radGroupwise.Size = new System.Drawing.Size(98, 18);
            this.radGroupwise.TabIndex = 1;
            this.radGroupwise.TabStop = true;
            this.radGroupwise.Text = "Group Wise";
            this.radGroupwise.UseVisualStyleBackColor = true;
            this.radGroupwise.CheckedChanged += new System.EventHandler(this.radGroupwise_CheckedChanged);
            this.radGroupwise.Click += new System.EventHandler(this.radGroupwise_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.dteToDate);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.dteFromDate);
            this.groupBox6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(11, 463);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(198, 81);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Period Seletion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(10, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "To:";
            // 
            // dteToDate
            // 
            this.dteToDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteToDate.Location = new System.Drawing.Point(62, 55);
            this.dteToDate.Name = "dteToDate";
            this.dteToDate.Size = new System.Drawing.Size(126, 22);
            this.dteToDate.TabIndex = 22;
            this.dteToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dteToDate_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(10, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "From:";
            // 
            // dteFromDate
            // 
            this.dteFromDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteFromDate.Location = new System.Drawing.Point(62, 27);
            this.dteFromDate.Name = "dteFromDate";
            this.dteFromDate.Size = new System.Drawing.Size(126, 22);
            this.dteFromDate.TabIndex = 20;
            this.dteFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dteFromDate_KeyPress);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtSearch);
            this.groupBox7.Controls.Add(this.btnLeftAll);
            this.groupBox7.Controls.Add(this.btnLeftSingle);
            this.groupBox7.Controls.Add(this.btnRightAll);
            this.groupBox7.Controls.Add(this.btnRightSingle);
            this.groupBox7.Controls.Add(this.lstRight);
            this.groupBox7.Controls.Add(this.lstLeft);
            this.groupBox7.Location = new System.Drawing.Point(12, 220);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(665, 242);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(7, 18);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(299, 22);
            this.txtSearch.TabIndex = 6;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // btnLeftAll
            // 
            this.btnLeftAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLeftAll.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftAll.Location = new System.Drawing.Point(316, 184);
            this.btnLeftAll.Name = "btnLeftAll";
            this.btnLeftAll.Size = new System.Drawing.Size(36, 23);
            this.btnLeftAll.TabIndex = 5;
            this.btnLeftAll.Text = "<<";
            this.btnLeftAll.UseVisualStyleBackColor = false;
            this.btnLeftAll.Click += new System.EventHandler(this.btnLeftAll_Click);
            // 
            // btnLeftSingle
            // 
            this.btnLeftSingle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLeftSingle.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftSingle.Location = new System.Drawing.Point(316, 159);
            this.btnLeftSingle.Name = "btnLeftSingle";
            this.btnLeftSingle.Size = new System.Drawing.Size(36, 23);
            this.btnLeftSingle.TabIndex = 4;
            this.btnLeftSingle.Text = "<";
            this.btnLeftSingle.UseVisualStyleBackColor = false;
            this.btnLeftSingle.Click += new System.EventHandler(this.btnLeftSingle_Click);
            // 
            // btnRightAll
            // 
            this.btnRightAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRightAll.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRightAll.Location = new System.Drawing.Point(316, 134);
            this.btnRightAll.Name = "btnRightAll";
            this.btnRightAll.Size = new System.Drawing.Size(36, 23);
            this.btnRightAll.TabIndex = 3;
            this.btnRightAll.Text = ">>";
            this.btnRightAll.UseVisualStyleBackColor = false;
            this.btnRightAll.Click += new System.EventHandler(this.btnRightAll_Click);
            // 
            // btnRightSingle
            // 
            this.btnRightSingle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRightSingle.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRightSingle.Location = new System.Drawing.Point(316, 109);
            this.btnRightSingle.Name = "btnRightSingle";
            this.btnRightSingle.Size = new System.Drawing.Size(36, 23);
            this.btnRightSingle.TabIndex = 2;
            this.btnRightSingle.Text = ">";
            this.btnRightSingle.UseVisualStyleBackColor = false;
            this.btnRightSingle.Click += new System.EventHandler(this.btnRightSingle_Click);
            // 
            // lstRight
            // 
            this.lstRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstRight.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstRight.FormattingEnabled = true;
            this.lstRight.ItemHeight = 14;
            this.lstRight.Location = new System.Drawing.Point(360, 39);
            this.lstRight.Name = "lstRight";
            this.lstRight.Size = new System.Drawing.Size(301, 198);
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
            this.lstLeft.Size = new System.Drawing.Size(301, 198);
            this.lstLeft.TabIndex = 0;
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.radZeroMoving);
            this.grpOption.Controls.Add(this.radFastMoving);
            this.grpOption.Controls.Add(this.radSlowMoving);
            this.grpOption.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpOption.Location = new System.Drawing.Point(211, 151);
            this.grpOption.Name = "grpOption";
            this.grpOption.Size = new System.Drawing.Size(466, 70);
            this.grpOption.TabIndex = 1;
            this.grpOption.TabStop = false;
            this.grpOption.Text = "Option";
            // 
            // radZeroMoving
            // 
            this.radZeroMoving.AutoSize = true;
            this.radZeroMoving.Location = new System.Drawing.Point(325, 28);
            this.radZeroMoving.Name = "radZeroMoving";
            this.radZeroMoving.Size = new System.Drawing.Size(102, 18);
            this.radZeroMoving.TabIndex = 5;
            this.radZeroMoving.Text = "Zero Moving";
            this.radZeroMoving.UseVisualStyleBackColor = true;
            // 
            // radFastMoving
            // 
            this.radFastMoving.AutoSize = true;
            this.radFastMoving.Location = new System.Drawing.Point(163, 28);
            this.radFastMoving.Name = "radFastMoving";
            this.radFastMoving.Size = new System.Drawing.Size(99, 18);
            this.radFastMoving.TabIndex = 4;
            this.radFastMoving.Text = "Fast Moving";
            this.radFastMoving.UseVisualStyleBackColor = true;
            // 
            // radSlowMoving
            // 
            this.radSlowMoving.AutoSize = true;
            this.radSlowMoving.Checked = true;
            this.radSlowMoving.Location = new System.Drawing.Point(24, 28);
            this.radSlowMoving.Name = "radSlowMoving";
            this.radSlowMoving.Size = new System.Drawing.Size(103, 18);
            this.radSlowMoving.TabIndex = 3;
            this.radSlowMoving.TabStop = true;
            this.radSlowMoving.Text = "Slow Moving";
            this.radSlowMoving.UseVisualStyleBackColor = true;
            // 
            // frmRptSlowFastMoving
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(864, 527);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmRptSlowFastMoving";
            this.Load += new System.EventHandler(this.frmRptStockInformation_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpReportOption.ResumeLayout(false);
            this.grpReportOption.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpReportOption;
        private System.Windows.Forms.RadioButton radCategory;
        private System.Windows.Forms.RadioButton radItemWise;
        private System.Windows.Forms.RadioButton radGroupwise;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radSelection;
        private System.Windows.Forms.RadioButton radAllItem;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnLeftAll;
        private System.Windows.Forms.Button btnLeftSingle;
        private System.Windows.Forms.Button btnRightAll;
        private System.Windows.Forms.Button btnRightSingle;
        private System.Windows.Forms.ListBox lstRight;
        private System.Windows.Forms.ListBox lstLeft;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dteToDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dteFromDate;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.GroupBox grpOption;
        private System.Windows.Forms.RadioButton radZeroMoving;
        private System.Windows.Forms.RadioButton radFastMoving;
        private System.Windows.Forms.RadioButton radSlowMoving;
    }
}
