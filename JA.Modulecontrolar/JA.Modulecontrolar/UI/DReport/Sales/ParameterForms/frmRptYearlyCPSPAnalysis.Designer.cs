namespace JA.Modulecontrolar.UI.DReport.Sales.ParameterForms
{
    partial class frmRptYearlyCPSPAnalysis
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
            this.label8 = new System.Windows.Forms.Label();
            this.groupSelection = new System.Windows.Forms.GroupBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnLeftAll = new System.Windows.Forms.Button();
            this.btnLeftSingle = new System.Windows.Forms.Button();
            this.btnRightAll = new System.Windows.Forms.Button();
            this.btnRightSingle = new System.Windows.Forms.Button();
            this.lstRight = new System.Windows.Forms.ListBox();
            this.lstLeft = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbtnAll = new System.Windows.Forms.RadioButton();
            this.rbtnZONE = new System.Windows.Forms.RadioButton();
            this.rbtnDSMRSM = new System.Windows.Forms.RadioButton();
            this.rbtnAMFM = new System.Windows.Forms.RadioButton();
            this.rbtnMPO = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.dteTCurrentYear = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dteFCurrentYear = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dteTPreviousYear = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dteFPreviousYear = new System.Windows.Forms.DateTimePicker();
            this.txtOldcomID = new System.Windows.Forms.TextBox();
            this.uctxtBranch = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.groupSelection.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(243, 3);
            this.frmLabel.Size = new System.Drawing.Size(269, 33);
            this.frmLabel.Text = "Yearly CP/SP Analysis";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.uctxtBranch);
            this.pnlMain.Controls.Add(this.label6);
            this.pnlMain.Controls.Add(this.txtOldcomID);
            this.pnlMain.Controls.Add(this.groupBox3);
            this.pnlMain.Controls.Add(this.groupBox2);
            this.pnlMain.Controls.Add(this.panel3);
            this.pnlMain.Controls.Add(this.groupSelection);
            this.pnlMain.Controls.Add(this.label8);
            this.pnlMain.Location = new System.Drawing.Point(0, 2);
            this.pnlMain.Size = new System.Drawing.Size(746, 435);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(747, 47);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(117, 320);
            this.btnEdit.Size = new System.Drawing.Size(10, 10);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(4, 313);
            this.btnSave.Size = new System.Drawing.Size(10, 10);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(128, 320);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(33, 319);
            this.btnNew.Size = new System.Drawing.Size(10, 10);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(613, 440);
            this.btnClose.Size = new System.Drawing.Size(128, 39);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(479, 440);
            this.btnPrint.Size = new System.Drawing.Size(128, 39);
            this.btnPrint.Text = "Preview";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 480);
            this.groupBox1.Size = new System.Drawing.Size(747, 25);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(539, 326);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 14);
            this.label8.TabIndex = 217;
            // 
            // groupSelection
            // 
            this.groupSelection.Controls.Add(this.txtSearch);
            this.groupSelection.Controls.Add(this.btnLeftAll);
            this.groupSelection.Controls.Add(this.btnLeftSingle);
            this.groupSelection.Controls.Add(this.btnRightAll);
            this.groupSelection.Controls.Add(this.btnRightSingle);
            this.groupSelection.Controls.Add(this.lstRight);
            this.groupSelection.Controls.Add(this.lstLeft);
            this.groupSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupSelection.Location = new System.Drawing.Point(133, 109);
            this.groupSelection.Name = "groupSelection";
            this.groupSelection.Size = new System.Drawing.Size(603, 216);
            this.groupSelection.TabIndex = 222;
            this.groupSelection.TabStop = false;
            this.groupSelection.Text = "Selection";
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(6, 17);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(275, 22);
            this.txtSearch.TabIndex = 0;
            // 
            // btnLeftAll
            // 
            this.btnLeftAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLeftAll.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftAll.Location = new System.Drawing.Point(285, 131);
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
            this.btnLeftSingle.Location = new System.Drawing.Point(285, 106);
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
            this.btnRightAll.Location = new System.Drawing.Point(285, 81);
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
            this.btnRightSingle.Location = new System.Drawing.Point(285, 56);
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
            this.lstRight.Location = new System.Drawing.Point(328, 41);
            this.lstRight.Name = "lstRight";
            this.lstRight.Size = new System.Drawing.Size(270, 170);
            this.lstRight.TabIndex = 1;
            // 
            // lstLeft
            // 
            this.lstLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstLeft.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLeft.FormattingEnabled = true;
            this.lstLeft.ItemHeight = 14;
            this.lstLeft.Location = new System.Drawing.Point(5, 41);
            this.lstLeft.Name = "lstLeft";
            this.lstLeft.Size = new System.Drawing.Size(276, 170);
            this.lstLeft.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.rbtnAll);
            this.panel3.Controls.Add(this.rbtnZONE);
            this.panel3.Controls.Add(this.rbtnDSMRSM);
            this.panel3.Controls.Add(this.rbtnAMFM);
            this.panel3.Controls.Add(this.rbtnMPO);
            this.panel3.Location = new System.Drawing.Point(11, 60);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(113, 171);
            this.panel3.TabIndex = 225;
            // 
            // rbtnAll
            // 
            this.rbtnAll.AutoSize = true;
            this.rbtnAll.Checked = true;
            this.rbtnAll.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnAll.Location = new System.Drawing.Point(19, 12);
            this.rbtnAll.Name = "rbtnAll";
            this.rbtnAll.Size = new System.Drawing.Size(39, 18);
            this.rbtnAll.TabIndex = 12;
            this.rbtnAll.TabStop = true;
            this.rbtnAll.Text = "All";
            this.rbtnAll.UseVisualStyleBackColor = true;
            this.rbtnAll.Click += new System.EventHandler(this.rbtnAll_Click);
            // 
            // rbtnZONE
            // 
            this.rbtnZONE.AutoSize = true;
            this.rbtnZONE.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnZONE.Location = new System.Drawing.Point(19, 110);
            this.rbtnZONE.Name = "rbtnZONE";
            this.rbtnZONE.Size = new System.Drawing.Size(60, 18);
            this.rbtnZONE.TabIndex = 11;
            this.rbtnZONE.Text = "ZONE";
            this.rbtnZONE.UseVisualStyleBackColor = true;
            this.rbtnZONE.Click += new System.EventHandler(this.rbtnZONE_Click);
            // 
            // rbtnDSMRSM
            // 
            this.rbtnDSMRSM.AutoSize = true;
            this.rbtnDSMRSM.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnDSMRSM.Location = new System.Drawing.Point(19, 86);
            this.rbtnDSMRSM.Name = "rbtnDSMRSM";
            this.rbtnDSMRSM.Size = new System.Drawing.Size(83, 18);
            this.rbtnDSMRSM.TabIndex = 10;
            this.rbtnDSMRSM.Text = "DSM/RSM";
            this.rbtnDSMRSM.UseVisualStyleBackColor = true;
            this.rbtnDSMRSM.Click += new System.EventHandler(this.rbtnDSMRSM_Click);
            // 
            // rbtnAMFM
            // 
            this.rbtnAMFM.AutoSize = true;
            this.rbtnAMFM.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnAMFM.Location = new System.Drawing.Point(19, 60);
            this.rbtnAMFM.Name = "rbtnAMFM";
            this.rbtnAMFM.Size = new System.Drawing.Size(65, 18);
            this.rbtnAMFM.TabIndex = 9;
            this.rbtnAMFM.Text = "AM/FM";
            this.rbtnAMFM.UseVisualStyleBackColor = true;
            this.rbtnAMFM.Click += new System.EventHandler(this.rbtnAMFM_Click);
            // 
            // rbtnMPO
            // 
            this.rbtnMPO.AutoSize = true;
            this.rbtnMPO.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnMPO.Location = new System.Drawing.Point(19, 36);
            this.rbtnMPO.Name = "rbtnMPO";
            this.rbtnMPO.Size = new System.Drawing.Size(53, 18);
            this.rbtnMPO.TabIndex = 8;
            this.rbtnMPO.Text = "MPO";
            this.rbtnMPO.UseVisualStyleBackColor = true;
            this.rbtnMPO.Click += new System.EventHandler(this.rbtnMPO_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel4);
            this.groupBox3.Location = new System.Drawing.Point(445, 331);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(288, 94);
            this.groupBox3.TabIndex = 231;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Current Year";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.dteTCurrentYear);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.dteFCurrentYear);
            this.panel4.Location = new System.Drawing.Point(6, 24);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(225, 62);
            this.panel4.TabIndex = 228;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(33, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 25;
            this.label3.Text = "To Date:";
            // 
            // dteTCurrentYear
            // 
            this.dteTCurrentYear.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteTCurrentYear.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteTCurrentYear.Location = new System.Drawing.Point(103, 32);
            this.dteTCurrentYear.Name = "dteTCurrentYear";
            this.dteTCurrentYear.Size = new System.Drawing.Size(109, 22);
            this.dteTCurrentYear.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(17, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 16);
            this.label4.TabIndex = 23;
            this.label4.Text = "From Date:";
            // 
            // dteFCurrentYear
            // 
            this.dteFCurrentYear.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteFCurrentYear.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteFCurrentYear.Location = new System.Drawing.Point(103, 7);
            this.dteFCurrentYear.Name = "dteFCurrentYear";
            this.dteFCurrentYear.Size = new System.Drawing.Size(109, 22);
            this.dteFCurrentYear.TabIndex = 22;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Location = new System.Drawing.Point(137, 331);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(277, 92);
            this.groupBox2.TabIndex = 230;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Previous Year";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dteTPreviousYear);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.dteFPreviousYear);
            this.panel2.Location = new System.Drawing.Point(10, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(251, 61);
            this.panel2.TabIndex = 228;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(33, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 25;
            this.label1.Text = "To Date:";
            // 
            // dteTPreviousYear
            // 
            this.dteTPreviousYear.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteTPreviousYear.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteTPreviousYear.Location = new System.Drawing.Point(104, 32);
            this.dteTPreviousYear.Name = "dteTPreviousYear";
            this.dteTPreviousYear.Size = new System.Drawing.Size(115, 22);
            this.dteTPreviousYear.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(17, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 16);
            this.label5.TabIndex = 23;
            this.label5.Text = "From Date:";
            // 
            // dteFPreviousYear
            // 
            this.dteFPreviousYear.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteFPreviousYear.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteFPreviousYear.Location = new System.Drawing.Point(104, 7);
            this.dteFPreviousYear.Name = "dteFPreviousYear";
            this.dteFPreviousYear.Size = new System.Drawing.Size(115, 22);
            this.dteFPreviousYear.TabIndex = 22;
            // 
            // txtOldcomID
            // 
            this.txtOldcomID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOldcomID.Location = new System.Drawing.Point(12, 235);
            this.txtOldcomID.Name = "txtOldcomID";
            this.txtOldcomID.Size = new System.Drawing.Size(100, 20);
            this.txtOldcomID.TabIndex = 232;
            this.txtOldcomID.Text = "0002";
            // 
            // uctxtBranch
            // 
            this.uctxtBranch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtBranch.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtBranch.Location = new System.Drawing.Point(237, 60);
            this.uctxtBranch.Name = "uctxtBranch";
            this.uctxtBranch.Size = new System.Drawing.Size(494, 22);
            this.uctxtBranch.TabIndex = 234;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(136, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 14);
            this.label6.TabIndex = 233;
            this.label6.Text = "Branch Name:";
            // 
            // frmRptYearlyCPSPAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(747, 505);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmRptYearlyCPSPAnalysis";
            this.Load += new System.EventHandler(this.frmRptYearlyCPSPAnalysis_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.groupSelection.ResumeLayout(false);
            this.groupSelection.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupSelection;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnLeftAll;
        private System.Windows.Forms.Button btnLeftSingle;
        private System.Windows.Forms.Button btnRightAll;
        private System.Windows.Forms.Button btnRightSingle;
        private System.Windows.Forms.ListBox lstRight;
        private System.Windows.Forms.ListBox lstLeft;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rbtnZONE;
        private System.Windows.Forms.RadioButton rbtnDSMRSM;
        private System.Windows.Forms.RadioButton rbtnAMFM;
        private System.Windows.Forms.RadioButton rbtnMPO;
        private System.Windows.Forms.RadioButton rbtnAll;
        private System.Windows.Forms.TextBox txtOldcomID;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dteTCurrentYear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dteFCurrentYear;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dteTPreviousYear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dteFPreviousYear;
        private System.Windows.Forms.TextBox uctxtBranch;
        private System.Windows.Forms.Label label6;
    }
}
