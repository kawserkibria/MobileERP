namespace JA.Modulecontrolar.UI.DReport.Accms.ParameterForms
{
    partial class frmRptStatistics
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
            this.chkboxWfactory = new System.Windows.Forms.CheckBox();
            this.groupSelection = new System.Windows.Forms.GroupBox();
            this.textMrName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnLeftAll = new System.Windows.Forms.Button();
            this.btnLeftSingle = new System.Windows.Forms.Button();
            this.btnRightAll = new System.Windows.Forms.Button();
            this.btnRightSingle = new System.Windows.Forms.Button();
            this.lstRight = new System.Windows.Forms.ListBox();
            this.lstLeft = new System.Windows.Forms.ListBox();
            this.pnlYearMonth = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkboxCoulamAutoGenaret = new System.Windows.Forms.CheckBox();
            this.chkSorting = new System.Windows.Forms.CheckBox();
            this.pnlSummDet = new System.Windows.Forms.Panel();
            this.rbtMonthly = new System.Windows.Forms.RadioButton();
            this.rbtYearly = new System.Windows.Forms.RadioButton();
            this.radSumm = new System.Windows.Forms.RadioButton();
            this.radDetails = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dteToDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dteFromDate = new System.Windows.Forms.DateTimePicker();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupSelection.SuspendLayout();
            this.pnlYearMonth.SuspendLayout();
            this.pnlSummDet.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(231, 9);
            this.frmLabel.Size = new System.Drawing.Size(239, 33);
            this.frmLabel.Text = "Payment Summary";
            this.frmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.groupBox6);
            this.pnlMain.Location = new System.Drawing.Point(0, -86);
            this.pnlMain.Size = new System.Drawing.Size(679, 502);
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(682, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(82, 362);
            this.btnEdit.Size = new System.Drawing.Size(5, 9);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(61, 422);
            this.btnSave.Size = new System.Drawing.Size(8, 9);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(128, 365);
            this.btnDelete.Size = new System.Drawing.Size(6, 10);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(35, 365);
            this.btnNew.Size = new System.Drawing.Size(8, 10);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(571, 419);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(438, 419);
            this.btnPrint.Size = new System.Drawing.Size(130, 39);
            this.btnPrint.Text = "Preview";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 462);
            this.groupBox1.Size = new System.Drawing.Size(682, 25);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.chkboxWfactory);
            this.groupBox6.Controls.Add(this.groupSelection);
            this.groupBox6.Controls.Add(this.pnlYearMonth);
            this.groupBox6.Controls.Add(this.chkboxCoulamAutoGenaret);
            this.groupBox6.Controls.Add(this.chkSorting);
            this.groupBox6.Controls.Add(this.pnlSummDet);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.dteToDate);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.dteFromDate);
            this.groupBox6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(5, 150);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(667, 347);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Period Seletion";
            // 
            // chkboxWfactory
            // 
            this.chkboxWfactory.AutoSize = true;
            this.chkboxWfactory.Checked = true;
            this.chkboxWfactory.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkboxWfactory.Location = new System.Drawing.Point(536, 309);
            this.chkboxWfactory.Name = "chkboxWfactory";
            this.chkboxWfactory.Size = new System.Drawing.Size(125, 18);
            this.chkboxWfactory.TabIndex = 32;
            this.chkboxWfactory.Text = "Without Factory";
            this.chkboxWfactory.UseVisualStyleBackColor = true;
            this.chkboxWfactory.Visible = false;
            // 
            // groupSelection
            // 
            this.groupSelection.Controls.Add(this.textMrName);
            this.groupSelection.Controls.Add(this.label6);
            this.groupSelection.Controls.Add(this.txtSearch);
            this.groupSelection.Controls.Add(this.btnLeftAll);
            this.groupSelection.Controls.Add(this.btnLeftSingle);
            this.groupSelection.Controls.Add(this.btnRightAll);
            this.groupSelection.Controls.Add(this.btnRightSingle);
            this.groupSelection.Controls.Add(this.lstRight);
            this.groupSelection.Controls.Add(this.lstLeft);
            this.groupSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupSelection.Location = new System.Drawing.Point(4, 67);
            this.groupSelection.Name = "groupSelection";
            this.groupSelection.Size = new System.Drawing.Size(660, 219);
            this.groupSelection.TabIndex = 29;
            this.groupSelection.TabStop = false;
            this.groupSelection.Text = "Selection";
            this.groupSelection.Visible = false;
            // 
            // textMrName
            // 
            this.textMrName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textMrName.Location = new System.Drawing.Point(148, 250);
            this.textMrName.Name = "textMrName";
            this.textMrName.Size = new System.Drawing.Size(300, 22);
            this.textMrName.TabIndex = 0;
            this.textMrName.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(47, 250);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 14);
            this.label6.TabIndex = 13;
            this.label6.Text = "Invoice Wise :";
            this.label6.Visible = false;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(8, 19);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(306, 22);
            this.txtSearch.TabIndex = 0;
            // 
            // btnLeftAll
            // 
            this.btnLeftAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLeftAll.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftAll.Location = new System.Drawing.Point(318, 142);
            this.btnLeftAll.Name = "btnLeftAll";
            this.btnLeftAll.Size = new System.Drawing.Size(36, 23);
            this.btnLeftAll.TabIndex = 5;
            this.btnLeftAll.Text = "<<";
            this.btnLeftAll.UseVisualStyleBackColor = false;
            // 
            // btnLeftSingle
            // 
            this.btnLeftSingle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLeftSingle.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftSingle.Location = new System.Drawing.Point(318, 119);
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
            this.btnRightAll.Location = new System.Drawing.Point(318, 87);
            this.btnRightAll.Name = "btnRightAll";
            this.btnRightAll.Size = new System.Drawing.Size(36, 23);
            this.btnRightAll.TabIndex = 3;
            this.btnRightAll.Text = ">>";
            this.btnRightAll.UseVisualStyleBackColor = false;
            // 
            // btnRightSingle
            // 
            this.btnRightSingle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRightSingle.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRightSingle.Location = new System.Drawing.Point(318, 64);
            this.btnRightSingle.Name = "btnRightSingle";
            this.btnRightSingle.Size = new System.Drawing.Size(36, 23);
            this.btnRightSingle.TabIndex = 2;
            this.btnRightSingle.Text = ">";
            this.btnRightSingle.UseVisualStyleBackColor = false;
            // 
            // lstRight
            // 
            this.lstRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstRight.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstRight.FormattingEnabled = true;
            this.lstRight.ItemHeight = 14;
            this.lstRight.Location = new System.Drawing.Point(358, 41);
            this.lstRight.Name = "lstRight";
            this.lstRight.Size = new System.Drawing.Size(296, 156);
            this.lstRight.TabIndex = 1;
            // 
            // lstLeft
            // 
            this.lstLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstLeft.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLeft.FormattingEnabled = true;
            this.lstLeft.ItemHeight = 14;
            this.lstLeft.Location = new System.Drawing.Point(8, 41);
            this.lstLeft.Name = "lstLeft";
            this.lstLeft.Size = new System.Drawing.Size(306, 156);
            this.lstLeft.TabIndex = 0;
            // 
            // pnlYearMonth
            // 
            this.pnlYearMonth.Controls.Add(this.dateTimePicker1);
            this.pnlYearMonth.Controls.Add(this.comboBox1);
            this.pnlYearMonth.Controls.Add(this.label4);
            this.pnlYearMonth.Location = new System.Drawing.Point(187, 11);
            this.pnlYearMonth.Name = "pnlYearMonth";
            this.pnlYearMonth.Size = new System.Drawing.Size(376, 50);
            this.pnlYearMonth.TabIndex = 30;
            this.pnlYearMonth.Visible = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "";
            this.dateTimePicker1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(19, 70);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(10, 22);
            this.dateTimePicker1.TabIndex = 27;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030",
            "2031",
            "2032",
            "2033",
            "2034",
            "2035",
            "2036",
            "2037",
            "2038",
            "2039",
            "2040"});
            this.comboBox1.Location = new System.Drawing.Point(121, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 22);
            this.comboBox1.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(72, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 16);
            this.label4.TabIndex = 25;
            this.label4.Text = "Year:";
            // 
            // chkboxCoulamAutoGenaret
            // 
            this.chkboxCoulamAutoGenaret.AutoSize = true;
            this.chkboxCoulamAutoGenaret.Location = new System.Drawing.Point(314, 40);
            this.chkboxCoulamAutoGenaret.Name = "chkboxCoulamAutoGenaret";
            this.chkboxCoulamAutoGenaret.Size = new System.Drawing.Size(169, 18);
            this.chkboxCoulamAutoGenaret.TabIndex = 26;
            this.chkboxCoulamAutoGenaret.Text = "Auto Generate Column";
            this.chkboxCoulamAutoGenaret.UseVisualStyleBackColor = true;
            this.chkboxCoulamAutoGenaret.Visible = false;
            // 
            // chkSorting
            // 
            this.chkSorting.AutoSize = true;
            this.chkSorting.Location = new System.Drawing.Point(83, 40);
            this.chkSorting.Name = "chkSorting";
            this.chkSorting.Size = new System.Drawing.Size(168, 18);
            this.chkSorting.TabIndex = 25;
            this.chkSorting.Text = "Sorting  by Cheque No";
            this.chkSorting.UseVisualStyleBackColor = true;
            this.chkSorting.Visible = false;
            // 
            // pnlSummDet
            // 
            this.pnlSummDet.Controls.Add(this.rbtMonthly);
            this.pnlSummDet.Controls.Add(this.rbtYearly);
            this.pnlSummDet.Controls.Add(this.radSumm);
            this.pnlSummDet.Controls.Add(this.radDetails);
            this.pnlSummDet.Location = new System.Drawing.Point(7, 295);
            this.pnlSummDet.Name = "pnlSummDet";
            this.pnlSummDet.Size = new System.Drawing.Size(494, 45);
            this.pnlSummDet.TabIndex = 24;
            this.pnlSummDet.Visible = false;
            // 
            // rbtMonthly
            // 
            this.rbtMonthly.AutoSize = true;
            this.rbtMonthly.Location = new System.Drawing.Point(395, 12);
            this.rbtMonthly.Name = "rbtMonthly";
            this.rbtMonthly.Size = new System.Drawing.Size(74, 18);
            this.rbtMonthly.TabIndex = 5;
            this.rbtMonthly.Text = "Monthly";
            this.rbtMonthly.UseVisualStyleBackColor = true;
           
            // 
            // rbtYearly
            // 
            this.rbtYearly.AutoSize = true;
            this.rbtYearly.Location = new System.Drawing.Point(298, 13);
            this.rbtYearly.Name = "rbtYearly";
            this.rbtYearly.Size = new System.Drawing.Size(62, 18);
            this.rbtYearly.TabIndex = 4;
            this.rbtYearly.Text = "Yearly";
            this.rbtYearly.UseVisualStyleBackColor = true;
            // 
            // radSumm
            // 
            this.radSumm.AutoSize = true;
            this.radSumm.Location = new System.Drawing.Point(193, 12);
            this.radSumm.Name = "radSumm";
            this.radSumm.Size = new System.Drawing.Size(83, 18);
            this.radSumm.TabIndex = 1;
            this.radSumm.Text = "Summary";
            this.radSumm.UseVisualStyleBackColor = true;
            // 
            // radDetails
            // 
            this.radDetails.AutoSize = true;
            this.radDetails.Checked = true;
            this.radDetails.Location = new System.Drawing.Point(64, 13);
            this.radDetails.Name = "radDetails";
            this.radDetails.Size = new System.Drawing.Size(68, 18);
            this.radDetails.TabIndex = 0;
            this.radDetails.TabStop = true;
            this.radDetails.Text = "Details";
            this.radDetails.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(185, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "To:";
            // 
            // dteToDate
            // 
            this.dteToDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteToDate.Location = new System.Drawing.Point(225, 102);
            this.dteToDate.Name = "dteToDate";
            this.dteToDate.Size = new System.Drawing.Size(224, 22);
            this.dteToDate.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(164, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "From:";
            // 
            // dteFromDate
            // 
            this.dteFromDate.CustomFormat = "";
            this.dteFromDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteFromDate.Location = new System.Drawing.Point(225, 69);
            this.dteFromDate.Name = "dteFromDate";
            this.dteFromDate.Size = new System.Drawing.Size(224, 22);
            this.dteFromDate.TabIndex = 20;
            // 
            // frmRptStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(682, 487);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmRptStatistics";
            this.Load += new System.EventHandler(this.frmRptStatistics_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupSelection.ResumeLayout(false);
            this.groupSelection.PerformLayout();
            this.pnlYearMonth.ResumeLayout(false);
            this.pnlYearMonth.PerformLayout();
            this.pnlSummDet.ResumeLayout(false);
            this.pnlSummDet.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dteToDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dteFromDate;
        private System.Windows.Forms.Panel pnlSummDet;
        private System.Windows.Forms.RadioButton radSumm;
        private System.Windows.Forms.RadioButton radDetails;
        private System.Windows.Forms.CheckBox chkSorting;
        private System.Windows.Forms.CheckBox chkboxCoulamAutoGenaret;
        private System.Windows.Forms.GroupBox groupSelection;
        private System.Windows.Forms.TextBox textMrName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnLeftAll;
        private System.Windows.Forms.Button btnLeftSingle;
        private System.Windows.Forms.Button btnRightAll;
        private System.Windows.Forms.Button btnRightSingle;
        private System.Windows.Forms.ListBox lstRight;
        private System.Windows.Forms.ListBox lstLeft;
        private System.Windows.Forms.RadioButton rbtMonthly;
        private System.Windows.Forms.RadioButton rbtYearly;
        private System.Windows.Forms.Panel pnlYearMonth;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkboxWfactory;
    }
}
