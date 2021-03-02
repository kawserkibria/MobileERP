namespace JA.Modulecontrolar.UI.Projection.Reports.RProjection.ParameterForms
{
    partial class frmRptPerfoemance
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
            this.txtLedgerType = new System.Windows.Forms.TextBox();
            this.groupSelection = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnLeftAll = new System.Windows.Forms.Button();
            this.btnLeftSingle = new System.Windows.Forms.Button();
            this.btnRightAll = new System.Windows.Forms.Button();
            this.btnRightSingle = new System.Windows.Forms.Button();
            this.lstRight = new System.Windows.Forms.ListBox();
            this.lstLeft = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.chkBaseTarget = new System.Windows.Forms.CheckBox();
            this.cboCompanyID = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radAllStatus = new System.Windows.Forms.RadioButton();
            this.radInactive = new System.Windows.Forms.RadioButton();
            this.radActive = new System.Windows.Forms.RadioButton();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupSelection.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(262, 9);
            this.frmLabel.Size = new System.Drawing.Size(235, 33);
            this.frmLabel.Text = "Sales Performance";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.panel2);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.cboCompanyID);
            this.pnlMain.Controls.Add(this.chkBaseTarget);
            this.pnlMain.Controls.Add(this.progressBar2);
            this.pnlMain.Controls.Add(this.progressBar1);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.groupSelection);
            this.pnlMain.Controls.Add(this.txtLedgerType);
            this.pnlMain.Controls.Add(this.groupBox6);
            this.pnlMain.Size = new System.Drawing.Size(748, 601);
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(751, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(57, 62);
            this.btnEdit.Size = new System.Drawing.Size(10, 10);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(219, 35);
            this.btnSave.Size = new System.Drawing.Size(10, 10);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(90, 35);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(106, 35);
            this.btnNew.Size = new System.Drawing.Size(10, 10);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(638, 518);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(505, 518);
            this.btnPrint.Size = new System.Drawing.Size(130, 39);
            this.btnPrint.Text = "Preview";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 560);
            this.groupBox1.Size = new System.Drawing.Size(751, 25);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.dteToDate);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.dteFromDate);
            this.groupBox6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(459, 521);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(274, 74);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Period Seletion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(51, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "To Date :";
            // 
            // dteToDate
            // 
            this.dteToDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteToDate.Location = new System.Drawing.Point(127, 46);
            this.dteToDate.Name = "dteToDate";
            this.dteToDate.Size = new System.Drawing.Size(129, 22);
            this.dteToDate.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(35, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "From Date :";
            // 
            // dteFromDate
            // 
            this.dteFromDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteFromDate.Location = new System.Drawing.Point(127, 18);
            this.dteFromDate.Name = "dteFromDate";
            this.dteFromDate.Size = new System.Drawing.Size(129, 22);
            this.dteFromDate.TabIndex = 20;
            // 
            // txtLedgerType
            // 
            this.txtLedgerType.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLedgerType.Location = new System.Drawing.Point(234, 158);
            this.txtLedgerType.Name = "txtLedgerType";
            this.txtLedgerType.Size = new System.Drawing.Size(281, 25);
            this.txtLedgerType.TabIndex = 214;
            // 
            // groupSelection
            // 
            this.groupSelection.Controls.Add(this.textBox3);
            this.groupSelection.Controls.Add(this.textBox2);
            this.groupSelection.Controls.Add(this.textBox1);
            this.groupSelection.Controls.Add(this.txtSearch);
            this.groupSelection.Controls.Add(this.btnLeftAll);
            this.groupSelection.Controls.Add(this.btnLeftSingle);
            this.groupSelection.Controls.Add(this.btnRightAll);
            this.groupSelection.Controls.Add(this.btnRightSingle);
            this.groupSelection.Controls.Add(this.lstRight);
            this.groupSelection.Controls.Add(this.lstLeft);
            this.groupSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupSelection.Location = new System.Drawing.Point(11, 234);
            this.groupSelection.Name = "groupSelection";
            this.groupSelection.Size = new System.Drawing.Size(727, 286);
            this.groupSelection.TabIndex = 215;
            this.groupSelection.TabStop = false;
            this.groupSelection.Text = "Selection";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(493, 15);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(25, 20);
            this.textBox3.TabIndex = 32;
            this.textBox3.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(472, 15);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(10, 20);
            this.textBox2.TabIndex = 30;
            this.textBox2.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(472, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(10, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.Visible = false;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(6, 19);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(275, 22);
            this.txtSearch.TabIndex = 0;
            // 
            // btnLeftAll
            // 
            this.btnLeftAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLeftAll.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftAll.Location = new System.Drawing.Point(340, 183);
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
            this.btnLeftSingle.Location = new System.Drawing.Point(340, 158);
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
            this.btnRightAll.Location = new System.Drawing.Point(340, 133);
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
            this.btnRightSingle.Location = new System.Drawing.Point(340, 108);
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
            this.lstRight.Location = new System.Drawing.Point(382, 41);
            this.lstRight.Name = "lstRight";
            this.lstRight.Size = new System.Drawing.Size(337, 240);
            this.lstRight.TabIndex = 1;
            this.lstRight.DoubleClick += new System.EventHandler(this.lstRight_DoubleClick);
            // 
            // lstLeft
            // 
            this.lstLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstLeft.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLeft.FormattingEnabled = true;
            this.lstLeft.ItemHeight = 14;
            this.lstLeft.Location = new System.Drawing.Point(5, 43);
            this.lstLeft.Name = "lstLeft";
            this.lstLeft.Size = new System.Drawing.Size(323, 240);
            this.lstLeft.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(133, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 16);
            this.label3.TabIndex = 24;
            this.label3.Text = "Ledger Type:";
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.Wheat;
            this.progressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.progressBar1.Location = new System.Drawing.Point(17, 569);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(436, 23);
            this.progressBar1.TabIndex = 216;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(17, 539);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(436, 23);
            this.progressBar2.TabIndex = 217;
            // 
            // chkBaseTarget
            // 
            this.chkBaseTarget.AutoSize = true;
            this.chkBaseTarget.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBaseTarget.Location = new System.Drawing.Point(633, 192);
            this.chkBaseTarget.Name = "chkBaseTarget";
            this.chkBaseTarget.Size = new System.Drawing.Size(104, 17);
            this.chkBaseTarget.TabIndex = 218;
            this.chkBaseTarget.Text = "Base Target";
            this.chkBaseTarget.UseVisualStyleBackColor = true;
            // 
            // cboCompanyID
            // 
            this.cboCompanyID.Font = new System.Drawing.Font("Verdana", 11F);
            this.cboCompanyID.FormattingEnabled = true;
            this.cboCompanyID.Items.AddRange(new object[] {
            "0001",
            "0002",
            "0003",
            "0004",
            "0005",
            "0006",
            "0007",
            "0008",
            "0009",
            "0010"});
            this.cboCompanyID.Location = new System.Drawing.Point(619, 158);
            this.cboCompanyID.Name = "cboCompanyID";
            this.cboCompanyID.Size = new System.Drawing.Size(111, 26);
            this.cboCompanyID.TabIndex = 219;
            this.cboCompanyID.Text = "0003";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(521, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 16);
            this.label4.TabIndex = 220;
            this.label4.Text = "Company ID:";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.radAllStatus);
            this.panel2.Controls.Add(this.radInactive);
            this.panel2.Controls.Add(this.radActive);
            this.panel2.Location = new System.Drawing.Point(105, 189);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(461, 41);
            this.panel2.TabIndex = 234;
            // 
            // radAllStatus
            // 
            this.radAllStatus.AutoSize = true;
            this.radAllStatus.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAllStatus.Location = new System.Drawing.Point(92, 11);
            this.radAllStatus.Name = "radAllStatus";
            this.radAllStatus.Size = new System.Drawing.Size(39, 17);
            this.radAllStatus.TabIndex = 234;
            this.radAllStatus.Text = "All";
            this.radAllStatus.UseVisualStyleBackColor = true;
            this.radAllStatus.Click += new System.EventHandler(this.radAllStatus_Click);
            // 
            // radInactive
            // 
            this.radInactive.AutoSize = true;
            this.radInactive.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radInactive.Location = new System.Drawing.Point(341, 11);
            this.radInactive.Name = "radInactive";
            this.radInactive.Size = new System.Drawing.Size(71, 17);
            this.radInactive.TabIndex = 233;
            this.radInactive.Text = "Inactive";
            this.radInactive.UseVisualStyleBackColor = true;
            this.radInactive.Click += new System.EventHandler(this.radInactive_Click);
            // 
            // radActive
            // 
            this.radActive.AutoSize = true;
            this.radActive.Checked = true;
            this.radActive.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radActive.Location = new System.Drawing.Point(203, 11);
            this.radActive.Name = "radActive";
            this.radActive.Size = new System.Drawing.Size(60, 17);
            this.radActive.TabIndex = 232;
            this.radActive.TabStop = true;
            this.radActive.Text = "Active";
            this.radActive.UseVisualStyleBackColor = true;
            this.radActive.Click += new System.EventHandler(this.radActive_Click);
            // 
            // frmRptPerfoemance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(751, 585);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmRptPerfoemance";
            this.Load += new System.EventHandler(this.frmRptPerfoemance_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupSelection.ResumeLayout(false);
            this.groupSelection.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dteToDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dteFromDate;
        private System.Windows.Forms.TextBox txtLedgerType;
        private System.Windows.Forms.GroupBox groupSelection;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnLeftAll;
        private System.Windows.Forms.Button btnLeftSingle;
        private System.Windows.Forms.Button btnRightAll;
        private System.Windows.Forms.Button btnRightSingle;
        private System.Windows.Forms.ListBox lstRight;
        private System.Windows.Forms.ListBox lstLeft;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.CheckBox chkBaseTarget;
        private System.Windows.Forms.ComboBox cboCompanyID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radAllStatus;
        private System.Windows.Forms.RadioButton radInactive;
        private System.Windows.Forms.RadioButton radActive;
    }
}
