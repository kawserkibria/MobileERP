namespace JA.Modulecontrolar.UI.DReport.Sales.ParameterForms
{
    partial class frmRptSalesOrder
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
            this.uctxtBranch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.uctxtTerritoryCode = new System.Windows.Forms.TextBox();
            this.uctxtTeritorryName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dteFromDate = new System.Windows.Forms.DateTimePicker();
            this.dteToDate = new System.Windows.Forms.DateTimePicker();
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbtnAll = new System.Windows.Forms.RadioButton();
            this.rbtnZONE = new System.Windows.Forms.RadioButton();
            this.rbtnDSMRSM = new System.Windows.Forms.RadioButton();
            this.rbtnAMFM = new System.Windows.Forms.RadioButton();
            this.rbtnMPO = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpTDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFDate = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbtnOrderPendingList = new System.Windows.Forms.RadioButton();
            this.rbtnZMNotAprove = new System.Windows.Forms.RadioButton();
            this.rbtnDetails = new System.Windows.Forms.RadioButton();
            this.rbtnSummary = new System.Windows.Forms.RadioButton();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.groupSelection.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(210, 0);
            this.frmLabel.Size = new System.Drawing.Size(152, 33);
            this.frmLabel.Text = "Sales Order";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.panel2);
            this.pnlMain.Controls.Add(this.groupBox6);
            this.pnlMain.Controls.Add(this.panel3);
            this.pnlMain.Controls.Add(this.groupSelection);
            this.pnlMain.Controls.Add(this.dteToDate);
            this.pnlMain.Controls.Add(this.dteFromDate);
            this.pnlMain.Controls.Add(this.label8);
            this.pnlMain.Controls.Add(this.uctxtTeritorryName);
            this.pnlMain.Controls.Add(this.uctxtTerritoryCode);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.uctxtBranch);
            this.pnlMain.Location = new System.Drawing.Point(0, 2);
            this.pnlMain.Size = new System.Drawing.Size(579, 508);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(584, 47);
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
            this.btnClose.Location = new System.Drawing.Point(451, 517);
            this.btnClose.Size = new System.Drawing.Size(128, 39);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(317, 517);
            this.btnPrint.Size = new System.Drawing.Size(128, 39);
            this.btnPrint.Text = "Preview";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 561);
            this.groupBox1.Size = new System.Drawing.Size(584, 25);
            // 
            // uctxtBranch
            // 
            this.uctxtBranch.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtBranch.Location = new System.Drawing.Point(132, 65);
            this.uctxtBranch.Name = "uctxtBranch";
            this.uctxtBranch.Size = new System.Drawing.Size(375, 22);
            this.uctxtBranch.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(34, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "Branch Name:";
            // 
            // uctxtTerritoryCode
            // 
            this.uctxtTerritoryCode.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtTerritoryCode.Location = new System.Drawing.Point(21, 288);
            this.uctxtTerritoryCode.Name = "uctxtTerritoryCode";
            this.uctxtTerritoryCode.Size = new System.Drawing.Size(110, 22);
            this.uctxtTerritoryCode.TabIndex = 207;
            this.uctxtTerritoryCode.Visible = false;
            // 
            // uctxtTeritorryName
            // 
            this.uctxtTeritorryName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtTeritorryName.Location = new System.Drawing.Point(140, 288);
            this.uctxtTeritorryName.Name = "uctxtTeritorryName";
            this.uctxtTeritorryName.Size = new System.Drawing.Size(94, 22);
            this.uctxtTeritorryName.TabIndex = 208;
            this.uctxtTeritorryName.Visible = false;
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
            // dteFromDate
            // 
            this.dteFromDate.Enabled = false;
            this.dteFromDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteFromDate.Location = new System.Drawing.Point(23, 275);
            this.dteFromDate.Name = "dteFromDate";
            this.dteFromDate.Size = new System.Drawing.Size(163, 22);
            this.dteFromDate.TabIndex = 220;
            this.dteFromDate.Visible = false;
            // 
            // dteToDate
            // 
            this.dteToDate.Enabled = false;
            this.dteToDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteToDate.Location = new System.Drawing.Point(37, 302);
            this.dteToDate.Name = "dteToDate";
            this.dteToDate.Size = new System.Drawing.Size(161, 22);
            this.dteToDate.TabIndex = 221;
            this.dteToDate.Visible = false;
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
            this.groupSelection.Location = new System.Drawing.Point(18, 187);
            this.groupSelection.Name = "groupSelection";
            this.groupSelection.Size = new System.Drawing.Size(545, 224);
            this.groupSelection.TabIndex = 222;
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
            this.txtSearch.Size = new System.Drawing.Size(247, 22);
            this.txtSearch.TabIndex = 0;
            // 
            // btnLeftAll
            // 
            this.btnLeftAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLeftAll.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftAll.Location = new System.Drawing.Point(256, 129);
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
            this.btnLeftSingle.Location = new System.Drawing.Point(256, 104);
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
            this.btnRightAll.Location = new System.Drawing.Point(256, 79);
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
            this.btnRightSingle.Location = new System.Drawing.Point(256, 54);
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
            this.lstRight.Location = new System.Drawing.Point(296, 41);
            this.lstRight.Name = "lstRight";
            this.lstRight.Size = new System.Drawing.Size(241, 170);
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
            this.lstLeft.Size = new System.Drawing.Size(248, 170);
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
            this.panel3.Location = new System.Drawing.Point(52, 93);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(487, 41);
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
            this.rbtnZONE.Location = new System.Drawing.Point(390, 12);
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
            this.rbtnDSMRSM.Location = new System.Drawing.Point(258, 12);
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
            this.rbtnAMFM.Location = new System.Drawing.Point(160, 12);
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
            this.rbtnMPO.Location = new System.Drawing.Point(86, 12);
            this.rbtnMPO.Name = "rbtnMPO";
            this.rbtnMPO.Size = new System.Drawing.Size(53, 18);
            this.rbtnMPO.TabIndex = 8;
            this.rbtnMPO.Text = "MPO";
            this.rbtnMPO.UseVisualStyleBackColor = true;
            this.rbtnMPO.Click += new System.EventHandler(this.rbtnMPO_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.dtpTDate);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.dtpFDate);
            this.groupBox6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(319, 414);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(244, 83);
            this.groupBox6.TabIndex = 226;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Period Seletion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(38, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "To:";
            // 
            // dtpTDate
            // 
            this.dtpTDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTDate.Location = new System.Drawing.Point(100, 49);
            this.dtpTDate.Name = "dtpTDate";
            this.dtpTDate.Size = new System.Drawing.Size(129, 22);
            this.dtpTDate.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(22, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "From:";
            // 
            // dtpFDate
            // 
            this.dtpFDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFDate.Location = new System.Drawing.Point(100, 21);
            this.dtpFDate.Name = "dtpFDate";
            this.dtpFDate.Size = new System.Drawing.Size(129, 22);
            this.dtpFDate.TabIndex = 20;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rbtnOrderPendingList);
            this.panel2.Controls.Add(this.rbtnZMNotAprove);
            this.panel2.Controls.Add(this.rbtnDetails);
            this.panel2.Controls.Add(this.rbtnSummary);
            this.panel2.Location = new System.Drawing.Point(52, 143);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(487, 41);
            this.panel2.TabIndex = 227;
            // 
            // rbtnOrderPendingList
            // 
            this.rbtnOrderPendingList.AutoSize = true;
            this.rbtnOrderPendingList.Checked = true;
            this.rbtnOrderPendingList.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnOrderPendingList.Location = new System.Drawing.Point(220, 11);
            this.rbtnOrderPendingList.Name = "rbtnOrderPendingList";
            this.rbtnOrderPendingList.Size = new System.Drawing.Size(116, 18);
            this.rbtnOrderPendingList.TabIndex = 14;
            this.rbtnOrderPendingList.TabStop = true;
            this.rbtnOrderPendingList.Text = "Pending Order";
            this.rbtnOrderPendingList.UseVisualStyleBackColor = true;
            this.rbtnOrderPendingList.Click += new System.EventHandler(this.btnRightSingle_Click);
            // 
            // rbtnZMNotAprove
            // 
            this.rbtnZMNotAprove.AutoSize = true;
            this.rbtnZMNotAprove.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnZMNotAprove.Location = new System.Drawing.Point(350, 11);
            this.rbtnZMNotAprove.Name = "rbtnZMNotAprove";
            this.rbtnZMNotAprove.Size = new System.Drawing.Size(124, 18);
            this.rbtnZMNotAprove.TabIndex = 13;
            this.rbtnZMNotAprove.Text = "ZH Not Approve";
            this.rbtnZMNotAprove.UseVisualStyleBackColor = true;
            this.rbtnZMNotAprove.Click += new System.EventHandler(this.rbtnZMNotAprove_Click);
            // 
            // rbtnDetails
            // 
            this.rbtnDetails.AutoSize = true;
            this.rbtnDetails.Checked = true;
            this.rbtnDetails.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnDetails.Location = new System.Drawing.Point(19, 11);
            this.rbtnDetails.Name = "rbtnDetails";
            this.rbtnDetails.Size = new System.Drawing.Size(68, 18);
            this.rbtnDetails.TabIndex = 12;
            this.rbtnDetails.TabStop = true;
            this.rbtnDetails.Text = "Details";
            this.rbtnDetails.UseVisualStyleBackColor = true;
            // 
            // rbtnSummary
            // 
            this.rbtnSummary.AutoSize = true;
            this.rbtnSummary.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnSummary.Location = new System.Drawing.Point(112, 11);
            this.rbtnSummary.Name = "rbtnSummary";
            this.rbtnSummary.Size = new System.Drawing.Size(83, 18);
            this.rbtnSummary.TabIndex = 8;
            this.rbtnSummary.Text = "Summary";
            this.rbtnSummary.UseVisualStyleBackColor = true;
            // 
            // frmRptSalesOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(584, 586);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmRptSalesOrder";
            this.Load += new System.EventHandler(this.frmRptSalesOrder_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.groupSelection.ResumeLayout(false);
            this.groupSelection.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uctxtBranch;
        private System.Windows.Forms.TextBox uctxtTeritorryName;
        private System.Windows.Forms.TextBox uctxtTerritoryCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dteFromDate;
        private System.Windows.Forms.DateTimePicker dteToDate;
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
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rbtnZONE;
        private System.Windows.Forms.RadioButton rbtnDSMRSM;
        private System.Windows.Forms.RadioButton rbtnAMFM;
        private System.Windows.Forms.RadioButton rbtnMPO;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFDate;
        private System.Windows.Forms.RadioButton rbtnAll;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbtnDetails;
        private System.Windows.Forms.RadioButton rbtnSummary;
        private System.Windows.Forms.RadioButton rbtnOrderPendingList;
        private System.Windows.Forms.RadioButton rbtnZMNotAprove;
    }
}
