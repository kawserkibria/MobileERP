namespace JA.Modulecontrolar.UI.DReport.Inventory.ParameterForms
{
    partial class frmRptStockSummarry
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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dteToDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dteFromDate = new System.Windows.Forms.DateTimePicker();
            this.uctxtBranchName = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.cboGroupName = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnLeftAll = new System.Windows.Forms.Button();
            this.btnLeftSingle = new System.Windows.Forms.Button();
            this.btnRightAll = new System.Windows.Forms.Button();
            this.btnRightSingle = new System.Windows.Forms.Button();
            this.lstRight = new System.Windows.Forms.ListBox();
            this.lstLeft = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radAlias = new System.Windows.Forms.RadioButton();
            this.radItem = new System.Windows.Forms.RadioButton();
            this.grpSelction = new System.Windows.Forms.GroupBox();
            this.radPowerWise = new System.Windows.Forms.RadioButton();
            this.radPackSize = new System.Windows.Forms.RadioButton();
            this.radProductWise = new System.Windows.Forms.RadioButton();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpSelction.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(154, 5);
            this.frmLabel.Size = new System.Drawing.Size(375, 33);
            this.frmLabel.Text = "Stock Summarry Inward  Price";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grpSelction);
            this.pnlMain.Controls.Add(this.groupBox2);
            this.pnlMain.Controls.Add(this.groupBox7);
            this.pnlMain.Controls.Add(this.uctxtBranchName);
            this.pnlMain.Controls.Add(this.lblCategory);
            this.pnlMain.Controls.Add(this.groupBox6);
            this.pnlMain.Location = new System.Drawing.Point(-8, -87);
            this.pnlMain.Size = new System.Drawing.Size(648, 559);
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(643, 54);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(132, 183);
            this.btnEdit.Size = new System.Drawing.Size(10, 10);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(19, 183);
            this.btnSave.Size = new System.Drawing.Size(10, 10);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(175, 183);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(48, 182);
            this.btnNew.Size = new System.Drawing.Size(10, 10);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(505, 473);
            this.btnClose.Size = new System.Drawing.Size(133, 39);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(357, 473);
            this.btnPrint.Size = new System.Drawing.Size(142, 39);
            this.btnPrint.Text = "Preview";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 512);
            this.groupBox1.Size = new System.Drawing.Size(643, 20);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.dteToDate);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.dteFromDate);
            this.groupBox6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(76, 222);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(440, 80);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Period Seletion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(113, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "To:";
            // 
            // dteToDate
            // 
            this.dteToDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteToDate.Location = new System.Drawing.Point(169, 54);
            this.dteToDate.Name = "dteToDate";
            this.dteToDate.Size = new System.Drawing.Size(129, 22);
            this.dteToDate.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(94, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "From:";
            // 
            // dteFromDate
            // 
            this.dteFromDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteFromDate.Location = new System.Drawing.Point(169, 23);
            this.dteFromDate.Name = "dteFromDate";
            this.dteFromDate.Size = new System.Drawing.Size(129, 22);
            this.dteFromDate.TabIndex = 20;
            // 
            // uctxtBranchName
            // 
            this.uctxtBranchName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtBranchName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtBranchName.Location = new System.Drawing.Point(139, 146);
            this.uctxtBranchName.Name = "uctxtBranchName";
            this.uctxtBranchName.Size = new System.Drawing.Size(350, 23);
            this.uctxtBranchName.TabIndex = 56;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(86, 149);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(48, 14);
            this.lblCategory.TabIndex = 57;
            this.lblCategory.Text = "Name:";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.cboGroupName);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.txtSearch);
            this.groupBox7.Controls.Add(this.btnLeftAll);
            this.groupBox7.Controls.Add(this.btnLeftSingle);
            this.groupBox7.Controls.Add(this.btnRightAll);
            this.groupBox7.Controls.Add(this.btnRightSingle);
            this.groupBox7.Controls.Add(this.lstRight);
            this.groupBox7.Controls.Add(this.lstLeft);
            this.groupBox7.Location = new System.Drawing.Point(2, 299);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(635, 205);
            this.groupBox7.TabIndex = 58;
            this.groupBox7.TabStop = false;
            // 
            // cboGroupName
            // 
            this.cboGroupName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGroupName.ForeColor = System.Drawing.Color.Blue;
            this.cboGroupName.FormattingEnabled = true;
            this.cboGroupName.Location = new System.Drawing.Point(360, 15);
            this.cboGroupName.Name = "cboGroupName";
            this.cboGroupName.Size = new System.Drawing.Size(220, 22);
            this.cboGroupName.TabIndex = 27;
            this.cboGroupName.SelectedIndexChanged += new System.EventHandler(this.cboGroupName_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(362, -2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(168, 16);
            this.label6.TabIndex = 26;
            this.label6.Text = "Selection Group Name";
            this.label6.Visible = false;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(7, 18);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(299, 22);
            this.txtSearch.TabIndex = 6;
            // 
            // btnLeftAll
            // 
            this.btnLeftAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLeftAll.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftAll.Location = new System.Drawing.Point(316, 152);
            this.btnLeftAll.Name = "btnLeftAll";
            this.btnLeftAll.Size = new System.Drawing.Size(36, 30);
            this.btnLeftAll.TabIndex = 5;
            this.btnLeftAll.Text = "<<";
            this.btnLeftAll.UseVisualStyleBackColor = false;
            this.btnLeftAll.Click += new System.EventHandler(this.btnLeftAll_Click);
            // 
            // btnLeftSingle
            // 
            this.btnLeftSingle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLeftSingle.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftSingle.Location = new System.Drawing.Point(316, 124);
            this.btnLeftSingle.Name = "btnLeftSingle";
            this.btnLeftSingle.Size = new System.Drawing.Size(36, 29);
            this.btnLeftSingle.TabIndex = 4;
            this.btnLeftSingle.Text = "<";
            this.btnLeftSingle.UseVisualStyleBackColor = false;
            this.btnLeftSingle.Click += new System.EventHandler(this.btnLeftSingle_Click);
            // 
            // btnRightAll
            // 
            this.btnRightAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRightAll.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRightAll.Location = new System.Drawing.Point(316, 82);
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
            this.btnRightSingle.Location = new System.Drawing.Point(316, 57);
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
            this.lstRight.Size = new System.Drawing.Size(269, 156);
            this.lstRight.TabIndex = 1;
            // 
            // lstLeft
            // 
            this.lstLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstLeft.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLeft.FormattingEnabled = true;
            this.lstLeft.ItemHeight = 14;
            this.lstLeft.Location = new System.Drawing.Point(8, 44);
            this.lstLeft.Name = "lstLeft";
            this.lstLeft.Size = new System.Drawing.Size(301, 156);
            this.lstLeft.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radAlias);
            this.groupBox2.Controls.Add(this.radItem);
            this.groupBox2.Location = new System.Drawing.Point(14, 509);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(297, 45);
            this.groupBox2.TabIndex = 59;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sort Order";
            // 
            // radAlias
            // 
            this.radAlias.AutoSize = true;
            this.radAlias.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAlias.Location = new System.Drawing.Point(197, 19);
            this.radAlias.Name = "radAlias";
            this.radAlias.Size = new System.Drawing.Size(91, 18);
            this.radAlias.TabIndex = 1;
            this.radAlias.Text = "Item Code";
            this.radAlias.UseVisualStyleBackColor = true;
            // 
            // radItem
            // 
            this.radItem.AutoSize = true;
            this.radItem.Checked = true;
            this.radItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radItem.Location = new System.Drawing.Point(76, 19);
            this.radItem.Name = "radItem";
            this.radItem.Size = new System.Drawing.Size(94, 18);
            this.radItem.TabIndex = 0;
            this.radItem.TabStop = true;
            this.radItem.Text = "Item Name";
            this.radItem.UseVisualStyleBackColor = true;
            // 
            // grpSelction
            // 
            this.grpSelction.Controls.Add(this.radPowerWise);
            this.grpSelction.Controls.Add(this.radPackSize);
            this.grpSelction.Controls.Add(this.radProductWise);
            this.grpSelction.Location = new System.Drawing.Point(26, 171);
            this.grpSelction.Name = "grpSelction";
            this.grpSelction.Size = new System.Drawing.Size(583, 45);
            this.grpSelction.TabIndex = 60;
            this.grpSelction.TabStop = false;
            this.grpSelction.Visible = false;
            // 
            // radPowerWise
            // 
            this.radPowerWise.AutoSize = true;
            this.radPowerWise.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPowerWise.Location = new System.Drawing.Point(379, 17);
            this.radPowerWise.Name = "radPowerWise";
            this.radPowerWise.Size = new System.Drawing.Size(184, 18);
            this.radPowerWise.TabIndex = 2;
            this.radPowerWise.Text = "Power Class Wise Summ.";
            this.radPowerWise.UseVisualStyleBackColor = true;
            // 
            // radPackSize
            // 
            this.radPackSize.AutoSize = true;
            this.radPackSize.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPackSize.Location = new System.Drawing.Point(203, 18);
            this.radPackSize.Name = "radPackSize";
            this.radPackSize.Size = new System.Drawing.Size(165, 18);
            this.radPackSize.TabIndex = 1;
            this.radPackSize.Text = "Pack Size Wise Summ.";
            this.radPackSize.UseVisualStyleBackColor = true;
            // 
            // radProductWise
            // 
            this.radProductWise.AutoSize = true;
            this.radProductWise.Checked = true;
            this.radProductWise.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radProductWise.Location = new System.Drawing.Point(46, 18);
            this.radProductWise.Name = "radProductWise";
            this.radProductWise.Size = new System.Drawing.Size(119, 18);
            this.radProductWise.TabIndex = 0;
            this.radProductWise.TabStop = true;
            this.radProductWise.Text = "Product Summ.";
            this.radProductWise.UseVisualStyleBackColor = true;
            // 
            // frmRptStockSummarry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(643, 532);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmRptStockSummarry";
            this.Load += new System.EventHandler(this.frmRptStoreLedger_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpSelction.ResumeLayout(false);
            this.grpSelction.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dteToDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dteFromDate;
        private System.Windows.Forms.TextBox uctxtBranchName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radAlias;
        private System.Windows.Forms.RadioButton radItem;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnLeftAll;
        private System.Windows.Forms.Button btnLeftSingle;
        private System.Windows.Forms.Button btnRightAll;
        private System.Windows.Forms.Button btnRightSingle;
        private System.Windows.Forms.ListBox lstRight;
        private System.Windows.Forms.ListBox lstLeft;
        private System.Windows.Forms.GroupBox grpSelction;
        private System.Windows.Forms.RadioButton radPowerWise;
        private System.Windows.Forms.RadioButton radPackSize;
        private System.Windows.Forms.RadioButton radProductWise;
        private System.Windows.Forms.ComboBox cboGroupName;
        private System.Windows.Forms.Label label6;
    }
}
