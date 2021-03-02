namespace JA.Modulecontrolar.UI.Inventory
{
    partial class frmMFGVoucherList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DGMFGVoucherList = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.PanelSearch = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTodate = new System.Windows.Forms.Label();
            this.lblfromDate = new System.Windows.Forms.Label();
            this.uctxtToDate = new System.Windows.Forms.TextBox();
            this.uctxtFromDate = new System.Windows.Forms.TextBox();
            this.uctxtExpression = new System.Windows.Forms.TextBox();
            this.lblExpression = new System.Windows.Forms.Label();
            this.uctxtFindWhat = new System.Windows.Forms.TextBox();
            this.lblFindwhat = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.btnApproved = new System.Windows.Forms.Button();
            this.btnNotApproved = new System.Windows.Forms.Button();
            this.btnListApp = new System.Windows.Forms.Button();
            this.DgRm = new System.Windows.Forms.DataGridView();
            this.DgPm = new System.Windows.Forms.DataGridView();
            this.DgWastageRm = new System.Windows.Forms.DataGridView();
            this.dgWastagePm = new System.Windows.Forms.DataGridView();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGMFGVoucherList)).BeginInit();
            this.PanelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgRm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgPm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgWastageRm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgWastagePm)).BeginInit();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(179, 9);
            this.frmLabel.Size = new System.Drawing.Size(488, 33);
            this.frmLabel.Text = "Manufacturing Voucher List(Batch Wise)";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.dgWastagePm);
            this.pnlMain.Controls.Add(this.DgWastageRm);
            this.pnlMain.Controls.Add(this.DgPm);
            this.pnlMain.Controls.Add(this.DgRm);
            this.pnlMain.Controls.Add(this.PanelSearch);
            this.pnlMain.Controls.Add(this.DGMFGVoucherList);
            this.pnlMain.Size = new System.Drawing.Size(928, 578);
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.btnListApp);
            this.pnlTop.Controls.Add(this.btnNotApproved);
            this.pnlTop.Controls.Add(this.btnApproved);
            this.pnlTop.Controls.Add(this.chkSelectAll);
            this.pnlTop.Controls.Add(this.btnSearch);
            this.pnlTop.Size = new System.Drawing.Size(930, 58);
            this.pnlTop.Controls.SetChildIndex(this.frmLabel, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnTopClose, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnSearch, 0);
            this.pnlTop.Controls.SetChildIndex(this.chkSelectAll, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnApproved, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnNotApproved, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnListApp, 0);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(412, 64);
            this.btnEdit.Size = new System.Drawing.Size(10, 10);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(299, 64);
            this.btnSave.Size = new System.Drawing.Size(10, 10);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(525, 64);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(186, 64);
            this.btnNew.Size = new System.Drawing.Size(10, 10);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(845, 64);
            this.btnClose.Size = new System.Drawing.Size(10, 10);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(636, 64);
            this.btnPrint.Size = new System.Drawing.Size(10, 10);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCount);
            this.groupBox1.Location = new System.Drawing.Point(0, 492);
            this.groupBox1.Size = new System.Drawing.Size(930, 25);
            this.groupBox1.Controls.SetChildIndex(this.lblCount, 0);
            // 
            // DGMFGVoucherList
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGMFGVoucherList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGMFGVoucherList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGMFGVoucherList.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGMFGVoucherList.Location = new System.Drawing.Point(3, 147);
            this.DGMFGVoucherList.Name = "DGMFGVoucherList";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGMFGVoucherList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGMFGVoucherList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGMFGVoucherList.Size = new System.Drawing.Size(921, 426);
            this.DGMFGVoucherList.TabIndex = 74;
            this.DGMFGVoucherList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGMFGVoucherList_CellContentClick);
            this.DGMFGVoucherList.DoubleClick += new System.EventHandler(this.DGMFGVoucherList_DoubleClick);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(12, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(129, 37);
            this.btnSearch.TabIndex = 17;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // PanelSearch
            // 
            this.PanelSearch.Controls.Add(this.button1);
            this.PanelSearch.Controls.Add(this.btnCancel);
            this.PanelSearch.Controls.Add(this.lblTodate);
            this.PanelSearch.Controls.Add(this.lblfromDate);
            this.PanelSearch.Controls.Add(this.uctxtToDate);
            this.PanelSearch.Controls.Add(this.uctxtFromDate);
            this.PanelSearch.Controls.Add(this.uctxtExpression);
            this.PanelSearch.Controls.Add(this.lblExpression);
            this.PanelSearch.Controls.Add(this.uctxtFindWhat);
            this.PanelSearch.Controls.Add(this.lblFindwhat);
            this.PanelSearch.Location = new System.Drawing.Point(269, 255);
            this.PanelSearch.Name = "PanelSearch";
            this.PanelSearch.Size = new System.Drawing.Size(364, 195);
            this.PanelSearch.TabIndex = 76;
            this.PanelSearch.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(363, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(5, 167);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(356, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblTodate
            // 
            this.lblTodate.AutoSize = true;
            this.lblTodate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTodate.Location = new System.Drawing.Point(32, 108);
            this.lblTodate.Name = "lblTodate";
            this.lblTodate.Size = new System.Drawing.Size(60, 14);
            this.lblTodate.TabIndex = 11;
            this.lblTodate.Text = "To Date:";
            this.lblTodate.Visible = false;
            // 
            // lblfromDate
            // 
            this.lblfromDate.AutoSize = true;
            this.lblfromDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfromDate.Location = new System.Drawing.Point(15, 85);
            this.lblfromDate.Name = "lblfromDate";
            this.lblfromDate.Size = new System.Drawing.Size(77, 14);
            this.lblfromDate.TabIndex = 10;
            this.lblfromDate.Text = "From Date:";
            this.lblfromDate.Visible = false;
            // 
            // uctxtToDate
            // 
            this.uctxtToDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtToDate.Location = new System.Drawing.Point(95, 104);
            this.uctxtToDate.Name = "uctxtToDate";
            this.uctxtToDate.Size = new System.Drawing.Size(245, 22);
            this.uctxtToDate.TabIndex = 9;
            this.uctxtToDate.Visible = false;
            // 
            // uctxtFromDate
            // 
            this.uctxtFromDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtFromDate.Location = new System.Drawing.Point(95, 81);
            this.uctxtFromDate.Name = "uctxtFromDate";
            this.uctxtFromDate.Size = new System.Drawing.Size(245, 22);
            this.uctxtFromDate.TabIndex = 8;
            this.uctxtFromDate.Visible = false;
            // 
            // uctxtExpression
            // 
            this.uctxtExpression.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtExpression.Location = new System.Drawing.Point(95, 57);
            this.uctxtExpression.Name = "uctxtExpression";
            this.uctxtExpression.Size = new System.Drawing.Size(245, 22);
            this.uctxtExpression.TabIndex = 7;
            // 
            // lblExpression
            // 
            this.lblExpression.AutoSize = true;
            this.lblExpression.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpression.Location = new System.Drawing.Point(11, 60);
            this.lblExpression.Name = "lblExpression";
            this.lblExpression.Size = new System.Drawing.Size(81, 14);
            this.lblExpression.TabIndex = 6;
            this.lblExpression.Text = "Expression:";
            // 
            // uctxtFindWhat
            // 
            this.uctxtFindWhat.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtFindWhat.Location = new System.Drawing.Point(95, 26);
            this.uctxtFindWhat.Name = "uctxtFindWhat";
            this.uctxtFindWhat.Size = new System.Drawing.Size(245, 22);
            this.uctxtFindWhat.TabIndex = 5;
            // 
            // lblFindwhat
            // 
            this.lblFindwhat.AutoSize = true;
            this.lblFindwhat.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFindwhat.Location = new System.Drawing.Point(16, 32);
            this.lblFindwhat.Name = "lblFindwhat";
            this.lblFindwhat.Size = new System.Drawing.Size(76, 14);
            this.lblFindwhat.TabIndex = 4;
            this.lblFindwhat.Text = "Find What:";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.ForeColor = System.Drawing.Color.Fuchsia;
            this.lblCount.Location = new System.Drawing.Point(712, 8);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(16, 14);
            this.lblCount.TabIndex = 21;
            this.lblCount.Text = "0";
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSelectAll.ForeColor = System.Drawing.Color.Fuchsia;
            this.chkSelectAll.Location = new System.Drawing.Point(801, 2);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(72, 20);
            this.chkSelectAll.TabIndex = 18;
            this.chkSelectAll.Text = "Select";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.Visible = false;
            this.chkSelectAll.Click += new System.EventHandler(this.chkSelectAll_Click);
            // 
            // btnApproved
            // 
            this.btnApproved.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnApproved.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApproved.Location = new System.Drawing.Point(770, 25);
            this.btnApproved.Name = "btnApproved";
            this.btnApproved.Size = new System.Drawing.Size(77, 24);
            this.btnApproved.TabIndex = 19;
            this.btnApproved.Text = "Approved";
            this.btnApproved.UseVisualStyleBackColor = false;
            this.btnApproved.Visible = false;
            this.btnApproved.Click += new System.EventHandler(this.btnApproved_Click);
            // 
            // btnNotApproved
            // 
            this.btnNotApproved.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnNotApproved.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNotApproved.Location = new System.Drawing.Point(850, 25);
            this.btnNotApproved.Name = "btnNotApproved";
            this.btnNotApproved.Size = new System.Drawing.Size(75, 24);
            this.btnNotApproved.TabIndex = 20;
            this.btnNotApproved.Text = "Not Appr.";
            this.btnNotApproved.UseVisualStyleBackColor = false;
            this.btnNotApproved.Visible = false;
            this.btnNotApproved.Click += new System.EventHandler(this.btnNotApproved_Click);
            // 
            // btnListApp
            // 
            this.btnListApp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnListApp.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListApp.Location = new System.Drawing.Point(689, 25);
            this.btnListApp.Name = "btnListApp";
            this.btnListApp.Size = new System.Drawing.Size(77, 24);
            this.btnListApp.TabIndex = 21;
            this.btnListApp.Text = "List App.";
            this.btnListApp.UseVisualStyleBackColor = false;
            this.btnListApp.Visible = false;
            this.btnListApp.Click += new System.EventHandler(this.btnListApp_Click);
            // 
            // DgRm
            // 
            this.DgRm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgRm.Location = new System.Drawing.Point(46, 215);
            this.DgRm.Name = "DgRm";
            this.DgRm.Size = new System.Drawing.Size(31, 20);
            this.DgRm.TabIndex = 77;
            this.DgRm.Visible = false;
            // 
            // DgPm
            // 
            this.DgPm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgPm.Location = new System.Drawing.Point(46, 241);
            this.DgPm.Name = "DgPm";
            this.DgPm.Size = new System.Drawing.Size(31, 20);
            this.DgPm.TabIndex = 78;
            this.DgPm.Visible = false;
            // 
            // DgWastageRm
            // 
            this.DgWastageRm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgWastageRm.Location = new System.Drawing.Point(46, 281);
            this.DgWastageRm.Name = "DgWastageRm";
            this.DgWastageRm.Size = new System.Drawing.Size(31, 20);
            this.DgWastageRm.TabIndex = 79;
            this.DgWastageRm.Visible = false;
            // 
            // dgWastagePm
            // 
            this.dgWastagePm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgWastagePm.Location = new System.Drawing.Point(30, 334);
            this.dgWastagePm.Name = "dgWastagePm";
            this.dgWastagePm.Size = new System.Drawing.Size(31, 20);
            this.dgWastagePm.TabIndex = 80;
            this.dgWastagePm.Visible = false;
            // 
            // frmMFGVoucherList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(930, 517);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmMFGVoucherList";
            this.Load += new System.EventHandler(this.frmMFGVoucherList_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGMFGVoucherList)).EndInit();
            this.PanelSearch.ResumeLayout(false);
            this.PanelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgRm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgPm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgWastageRm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgWastagePm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGMFGVoucherList;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel PanelSearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTodate;
        private System.Windows.Forms.Label lblfromDate;
        private System.Windows.Forms.TextBox uctxtToDate;
        private System.Windows.Forms.TextBox uctxtFromDate;
        private System.Windows.Forms.TextBox uctxtExpression;
        private System.Windows.Forms.Label lblExpression;
        private System.Windows.Forms.TextBox uctxtFindWhat;
        private System.Windows.Forms.Label lblFindwhat;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.Button btnNotApproved;
        private System.Windows.Forms.Button btnApproved;
        private System.Windows.Forms.Button btnListApp;
        private System.Windows.Forms.DataGridView DgRm;
        private System.Windows.Forms.DataGridView dgWastagePm;
        private System.Windows.Forms.DataGridView DgWastageRm;
        private System.Windows.Forms.DataGridView DgPm;
    }
}
