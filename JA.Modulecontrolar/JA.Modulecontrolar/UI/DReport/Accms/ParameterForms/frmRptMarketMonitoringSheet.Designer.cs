namespace JA.Modulecontrolar.UI.DReport.Accms.ParameterForms
{
    partial class frmRptMarketMonitoringSheet
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
            this.uctxtBranch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grpBox = new System.Windows.Forms.GroupBox();
            this.rbtnZone = new System.Windows.Forms.RadioButton();
            this.rbtnDivision = new System.Windows.Forms.RadioButton();
            this.rbtnArea = new System.Windows.Forms.RadioButton();
            this.radMpo = new System.Windows.Forms.RadioButton();
            this.radAll = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radAllStatus = new System.Windows.Forms.RadioButton();
            this.radInactive = new System.Windows.Forms.RadioButton();
            this.radActive = new System.Windows.Forms.RadioButton();
            this.chkBaseTarget = new System.Windows.Forms.CheckBox();
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
            this.chkboxSpecial = new System.Windows.Forms.CheckBox();
            this.chkboxDetails = new System.Windows.Forms.CheckBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.grpBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(160, 1);
            this.frmLabel.Size = new System.Drawing.Size(306, 33);
            this.frmLabel.Text = "Market Monitoring Sheet";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.chkboxDetails);
            this.pnlMain.Controls.Add(this.chkboxSpecial);
            this.pnlMain.Controls.Add(this.groupSelection);
            this.pnlMain.Controls.Add(this.chkBaseTarget);
            this.pnlMain.Controls.Add(this.groupBox2);
            this.pnlMain.Controls.Add(this.dateTimePicker1);
            this.pnlMain.Controls.Add(this.label8);
            this.pnlMain.Controls.Add(this.grpBox);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.uctxtBranch);
            this.pnlMain.Controls.Add(this.groupBox6);
            this.pnlMain.Location = new System.Drawing.Point(0, -86);
            this.pnlMain.Size = new System.Drawing.Size(615, 597);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(616, 47);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(123, 312);
            this.btnEdit.Size = new System.Drawing.Size(14, 19);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(10, 312);
            this.btnSave.Size = new System.Drawing.Size(23, 19);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(166, 312);
            this.btnDelete.Size = new System.Drawing.Size(10, 14);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(39, 311);
            this.btnNew.Size = new System.Drawing.Size(36, 13);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(488, 514);
            this.btnClose.Size = new System.Drawing.Size(128, 39);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(354, 514);
            this.btnPrint.Size = new System.Drawing.Size(128, 39);
            this.btnPrint.Text = "Preview";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 553);
            this.groupBox1.Size = new System.Drawing.Size(616, 25);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.dteToDate);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.dteFromDate);
            this.groupBox6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(232, 505);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(321, 76);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Period Seletion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(105, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "To:";
            // 
            // dteToDate
            // 
            this.dteToDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteToDate.Location = new System.Drawing.Point(161, 49);
            this.dteToDate.Name = "dteToDate";
            this.dteToDate.Size = new System.Drawing.Size(129, 22);
            this.dteToDate.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(91, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "From:";
            // 
            // dteFromDate
            // 
            this.dteFromDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteFromDate.Location = new System.Drawing.Point(161, 21);
            this.dteFromDate.Name = "dteFromDate";
            this.dteFromDate.Size = new System.Drawing.Size(129, 22);
            this.dteFromDate.TabIndex = 20;
            // 
            // uctxtBranch
            // 
            this.uctxtBranch.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtBranch.Location = new System.Drawing.Point(125, 139);
            this.uctxtBranch.Name = "uctxtBranch";
            this.uctxtBranch.Size = new System.Drawing.Size(375, 22);
            this.uctxtBranch.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "Branch Name:";
            // 
            // grpBox
            // 
            this.grpBox.Controls.Add(this.rbtnZone);
            this.grpBox.Controls.Add(this.rbtnDivision);
            this.grpBox.Controls.Add(this.rbtnArea);
            this.grpBox.Controls.Add(this.radMpo);
            this.grpBox.Controls.Add(this.radAll);
            this.grpBox.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBox.Location = new System.Drawing.Point(18, 219);
            this.grpBox.Name = "grpBox";
            this.grpBox.Size = new System.Drawing.Size(482, 46);
            this.grpBox.TabIndex = 13;
            this.grpBox.TabStop = false;
            this.grpBox.Text = "Option";
            // 
            // rbtnZone
            // 
            this.rbtnZone.AutoSize = true;
            this.rbtnZone.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnZone.Location = new System.Drawing.Point(407, 18);
            this.rbtnZone.Name = "rbtnZone";
            this.rbtnZone.Size = new System.Drawing.Size(57, 18);
            this.rbtnZone.TabIndex = 5;
            this.rbtnZone.Text = "Zone";
            this.rbtnZone.UseVisualStyleBackColor = true;
            this.rbtnZone.CheckedChanged += new System.EventHandler(this.rbtnZone_CheckedChanged);
            this.rbtnZone.Click += new System.EventHandler(this.rbtnZone_Click);
            // 
            // rbtnDivision
            // 
            this.rbtnDivision.AutoSize = true;
            this.rbtnDivision.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnDivision.Location = new System.Drawing.Point(301, 18);
            this.rbtnDivision.Name = "rbtnDivision";
            this.rbtnDivision.Size = new System.Drawing.Size(73, 18);
            this.rbtnDivision.TabIndex = 4;
            this.rbtnDivision.Text = "Division";
            this.rbtnDivision.UseVisualStyleBackColor = true;
            this.rbtnDivision.Click += new System.EventHandler(this.rbtnDivision_Click);
            // 
            // rbtnArea
            // 
            this.rbtnArea.AutoSize = true;
            this.rbtnArea.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnArea.Location = new System.Drawing.Point(215, 18);
            this.rbtnArea.Name = "rbtnArea";
            this.rbtnArea.Size = new System.Drawing.Size(54, 18);
            this.rbtnArea.TabIndex = 3;
            this.rbtnArea.Text = "Area";
            this.rbtnArea.UseVisualStyleBackColor = true;
            this.rbtnArea.Click += new System.EventHandler(this.rbtnArea_Click);
            // 
            // radMpo
            // 
            this.radMpo.AutoSize = true;
            this.radMpo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radMpo.Location = new System.Drawing.Point(113, 18);
            this.radMpo.Name = "radMpo";
            this.radMpo.Size = new System.Drawing.Size(53, 18);
            this.radMpo.TabIndex = 2;
            this.radMpo.Text = "MPO";
            this.radMpo.UseVisualStyleBackColor = true;
            this.radMpo.Click += new System.EventHandler(this.radMpo_Click);
            // 
            // radAll
            // 
            this.radAll.AutoSize = true;
            this.radAll.Checked = true;
            this.radAll.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAll.Location = new System.Drawing.Point(35, 18);
            this.radAll.Name = "radAll";
            this.radAll.Size = new System.Drawing.Size(39, 18);
            this.radAll.TabIndex = 1;
            this.radAll.TabStop = true;
            this.radAll.Text = "All";
            this.radAll.UseVisualStyleBackColor = true;
            this.radAll.Click += new System.EventHandler(this.radAll_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(539, 238);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 14);
            this.label8.TabIndex = 217;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(28, 294);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(10, 22);
            this.dateTimePicker1.TabIndex = 221;
            this.dateTimePicker1.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radAllStatus);
            this.groupBox2.Controls.Add(this.radInactive);
            this.groupBox2.Controls.Add(this.radActive);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(18, 167);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(482, 46);
            this.groupBox2.TabIndex = 222;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Option";
            // 
            // radAllStatus
            // 
            this.radAllStatus.AutoSize = true;
            this.radAllStatus.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAllStatus.Location = new System.Drawing.Point(349, 15);
            this.radAllStatus.Name = "radAllStatus";
            this.radAllStatus.Size = new System.Drawing.Size(39, 17);
            this.radAllStatus.TabIndex = 214;
            this.radAllStatus.Text = "All";
            this.radAllStatus.UseVisualStyleBackColor = true;
            this.radAllStatus.Click += new System.EventHandler(this.radAllStatus_Click);
            // 
            // radInactive
            // 
            this.radInactive.AutoSize = true;
            this.radInactive.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radInactive.Location = new System.Drawing.Point(199, 15);
            this.radInactive.Name = "radInactive";
            this.radInactive.Size = new System.Drawing.Size(71, 17);
            this.radInactive.TabIndex = 213;
            this.radInactive.Text = "Inactive";
            this.radInactive.UseVisualStyleBackColor = true;
            this.radInactive.Click += new System.EventHandler(this.radInactive_Click);
            // 
            // radActive
            // 
            this.radActive.AutoSize = true;
            this.radActive.Checked = true;
            this.radActive.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radActive.Location = new System.Drawing.Point(82, 15);
            this.radActive.Name = "radActive";
            this.radActive.Size = new System.Drawing.Size(60, 17);
            this.radActive.TabIndex = 212;
            this.radActive.TabStop = true;
            this.radActive.Text = "Active";
            this.radActive.UseVisualStyleBackColor = true;
            this.radActive.Click += new System.EventHandler(this.radActive_Click);
            // 
            // chkBaseTarget
            // 
            this.chkBaseTarget.AutoSize = true;
            this.chkBaseTarget.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBaseTarget.Location = new System.Drawing.Point(9, 505);
            this.chkBaseTarget.Name = "chkBaseTarget";
            this.chkBaseTarget.Size = new System.Drawing.Size(104, 17);
            this.chkBaseTarget.TabIndex = 223;
            this.chkBaseTarget.Text = "Base Target";
            this.chkBaseTarget.UseVisualStyleBackColor = true;
            this.chkBaseTarget.Click += new System.EventHandler(this.chkBaseTarget_Click);
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
            this.groupSelection.Location = new System.Drawing.Point(9, 271);
            this.groupSelection.Name = "groupSelection";
            this.groupSelection.Size = new System.Drawing.Size(597, 224);
            this.groupSelection.TabIndex = 224;
            this.groupSelection.TabStop = false;
            this.groupSelection.Text = "Selection";
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
            this.txtSearch.Location = new System.Drawing.Point(6, 17);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(269, 22);
            this.txtSearch.TabIndex = 0;
            // 
            // btnLeftAll
            // 
            this.btnLeftAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLeftAll.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftAll.Location = new System.Drawing.Point(277, 129);
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
            this.btnLeftSingle.Location = new System.Drawing.Point(277, 104);
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
            this.btnRightAll.Location = new System.Drawing.Point(277, 79);
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
            this.btnRightSingle.Location = new System.Drawing.Point(277, 54);
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
            this.lstRight.Location = new System.Drawing.Point(318, 41);
            this.lstRight.Name = "lstRight";
            this.lstRight.Size = new System.Drawing.Size(272, 170);
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
            this.lstLeft.Size = new System.Drawing.Size(270, 170);
            this.lstLeft.TabIndex = 0;
            // 
            // chkboxSpecial
            // 
            this.chkboxSpecial.AutoSize = true;
            this.chkboxSpecial.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkboxSpecial.Location = new System.Drawing.Point(9, 532);
            this.chkboxSpecial.Name = "chkboxSpecial";
            this.chkboxSpecial.Size = new System.Drawing.Size(126, 17);
            this.chkboxSpecial.TabIndex = 225;
            this.chkboxSpecial.Text = "Special Monitor";
            this.chkboxSpecial.UseVisualStyleBackColor = true;
            this.chkboxSpecial.Click += new System.EventHandler(this.chkboxSpecial_Click);
            // 
            // chkboxDetails
            // 
            this.chkboxDetails.AutoSize = true;
            this.chkboxDetails.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkboxDetails.Location = new System.Drawing.Point(506, 239);
            this.chkboxDetails.Name = "chkboxDetails";
            this.chkboxDetails.Size = new System.Drawing.Size(71, 17);
            this.chkboxDetails.TabIndex = 226;
            this.chkboxDetails.Text = "Details";
            this.chkboxDetails.UseVisualStyleBackColor = true;
            // 
            // frmRptMarketMonitoringSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(616, 578);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmRptMarketMonitoringSheet";
            this.Load += new System.EventHandler(this.frmRptMarketMonitoringSheet_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.grpBox.ResumeLayout(false);
            this.grpBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupSelection.ResumeLayout(false);
            this.groupSelection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dteToDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dteFromDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uctxtBranch;
        private System.Windows.Forms.GroupBox grpBox;
        private System.Windows.Forms.RadioButton radMpo;
        private System.Windows.Forms.RadioButton radAll;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radAllStatus;
        private System.Windows.Forms.RadioButton radInactive;
        private System.Windows.Forms.RadioButton radActive;
        private System.Windows.Forms.RadioButton rbtnZone;
        private System.Windows.Forms.RadioButton rbtnDivision;
        private System.Windows.Forms.RadioButton rbtnArea;
        private System.Windows.Forms.CheckBox chkBaseTarget;
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
        private System.Windows.Forms.CheckBox chkboxSpecial;
        private System.Windows.Forms.CheckBox chkboxDetails;
    }
}
