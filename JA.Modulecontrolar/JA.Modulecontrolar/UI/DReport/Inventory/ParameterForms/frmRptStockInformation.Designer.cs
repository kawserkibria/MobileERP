﻿namespace JA.Modulecontrolar.UI.DReport.Inventory.ParameterForms
{
    partial class frmRptStockInformation
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
            this.radAll = new System.Windows.Forms.RadioButton();
            this.grpOption = new System.Windows.Forms.GroupBox();
            this.cboxClosing = new System.Windows.Forms.CheckBox();
            this.cboxOutward = new System.Windows.Forms.CheckBox();
            this.cboxbInward = new System.Windows.Forms.CheckBox();
            this.cboxOpening = new System.Windows.Forms.CheckBox();
            this.grpReportOption = new System.Windows.Forms.GroupBox();
            this.radLocationGroup = new System.Windows.Forms.RadioButton();
            this.radLocationwise = new System.Windows.Forms.RadioButton();
            this.radCategory = new System.Windows.Forms.RadioButton();
            this.radItemWise = new System.Windows.Forms.RadioButton();
            this.radGroupwise = new System.Windows.Forms.RadioButton();
            this.grpSuppressSelection = new System.Windows.Forms.GroupBox();
            this.radValueSupp = new System.Windows.Forms.RadioButton();
            this.radSuppressZero = new System.Windows.Forms.RadioButton();
            this.radNoSuppress = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dteToDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dteFromDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.cboGroupName = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnLeftAll = new System.Windows.Forms.Button();
            this.btnLeftSingle = new System.Windows.Forms.Button();
            this.btnRightAll = new System.Windows.Forms.Button();
            this.btnRightSingle = new System.Windows.Forms.Button();
            this.lstRight = new System.Windows.Forms.ListBox();
            this.lstLeft = new System.Windows.Forms.ListBox();
            this.grpGroup = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSerchGroup = new System.Windows.Forms.TextBox();
            this.btnLeftAllNew = new System.Windows.Forms.Button();
            this.btnLeftNew = new System.Windows.Forms.Button();
            this.btnRightAllNew = new System.Windows.Forms.Button();
            this.btnRightNew = new System.Windows.Forms.Button();
            this.lstRightNew = new System.Windows.Forms.ListBox();
            this.lstLeftNew = new System.Windows.Forms.ListBox();
            this.Selection = new System.Windows.Forms.GroupBox();
            this.chkbHorizontal = new System.Windows.Forms.CheckBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.grpReportOption.SuspendLayout();
            this.grpSuppressSelection.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.grpGroup.SuspendLayout();
            this.Selection.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Size = new System.Drawing.Size(228, 33);
            this.frmLabel.Text = "Stock Information";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.Selection);
            this.pnlMain.Controls.Add(this.grpGroup);
            this.pnlMain.Controls.Add(this.groupBox7);
            this.pnlMain.Controls.Add(this.groupBox6);
            this.pnlMain.Controls.Add(this.grpSuppressSelection);
            this.pnlMain.Controls.Add(this.grpReportOption);
            this.pnlMain.Controls.Add(this.grpOption);
            this.pnlMain.Controls.Add(this.groupBox2);
            this.pnlMain.Size = new System.Drawing.Size(863, 547);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(865, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(470, 478);
            this.btnEdit.Size = new System.Drawing.Size(10, 14);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(357, 478);
            this.btnSave.Size = new System.Drawing.Size(10, 14);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(583, 478);
            this.btnDelete.Size = new System.Drawing.Size(10, 14);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(244, 478);
            this.btnNew.Size = new System.Drawing.Size(10, 14);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(753, 461);
            this.btnClose.Visible = true;
            // 
            // btnPrint
            // 
            this.btnPrint.ImageIndex = -1;
            this.btnPrint.ImageKey = "print.png";
            this.btnPrint.Location = new System.Drawing.Point(628, 461);
            this.btnPrint.Size = new System.Drawing.Size(124, 39);
            this.btnPrint.Text = "Preview";
            this.btnPrint.Visible = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 500);
            this.groupBox1.Size = new System.Drawing.Size(865, 25);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radSelection);
            this.groupBox2.Controls.Add(this.radAllItem);
            this.groupBox2.Controls.Add(this.radAll);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(11, 142);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(122, 74);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selection Option";
            // 
            // radSelection
            // 
            this.radSelection.AutoSize = true;
            this.radSelection.Location = new System.Drawing.Point(20, 49);
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
            this.radAllItem.Location = new System.Drawing.Point(20, 25);
            this.radAllItem.Name = "radAllItem";
            this.radAllItem.Size = new System.Drawing.Size(43, 18);
            this.radAllItem.TabIndex = 1;
            this.radAllItem.TabStop = true;
            this.radAllItem.Text = "All ";
            this.radAllItem.UseVisualStyleBackColor = true;
            this.radAllItem.CheckedChanged += new System.EventHandler(this.radAllItem_CheckedChanged);
            this.radAllItem.Click += new System.EventHandler(this.radAllItem_Click);
            // 
            // radAll
            // 
            this.radAll.AutoSize = true;
            this.radAll.Location = new System.Drawing.Point(66, 25);
            this.radAll.Name = "radAll";
            this.radAll.Size = new System.Drawing.Size(39, 18);
            this.radAll.TabIndex = 0;
            this.radAll.Text = "All";
            this.radAll.UseVisualStyleBackColor = true;
            this.radAll.Visible = false;
            this.radAll.CheckedChanged += new System.EventHandler(this.radAll_CheckedChanged);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.cboxClosing);
            this.grpOption.Controls.Add(this.cboxOutward);
            this.grpOption.Controls.Add(this.cboxbInward);
            this.grpOption.Controls.Add(this.cboxOpening);
            this.grpOption.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpOption.Location = new System.Drawing.Point(10, 222);
            this.grpOption.Name = "grpOption";
            this.grpOption.Size = new System.Drawing.Size(126, 154);
            this.grpOption.TabIndex = 1;
            this.grpOption.TabStop = false;
            this.grpOption.Text = "Option";
            // 
            // cboxClosing
            // 
            this.cboxClosing.AutoSize = true;
            this.cboxClosing.Checked = true;
            this.cboxClosing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxClosing.Location = new System.Drawing.Point(20, 117);
            this.cboxClosing.Name = "cboxClosing";
            this.cboxClosing.Size = new System.Drawing.Size(72, 18);
            this.cboxClosing.TabIndex = 8;
            this.cboxClosing.Text = "Closing";
            this.cboxClosing.UseVisualStyleBackColor = true;
            // 
            // cboxOutward
            // 
            this.cboxOutward.AutoSize = true;
            this.cboxOutward.Checked = true;
            this.cboxOutward.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxOutward.Location = new System.Drawing.Point(20, 88);
            this.cboxOutward.Name = "cboxOutward";
            this.cboxOutward.Size = new System.Drawing.Size(81, 18);
            this.cboxOutward.TabIndex = 7;
            this.cboxOutward.Text = "Outward";
            this.cboxOutward.UseVisualStyleBackColor = true;
            // 
            // cboxbInward
            // 
            this.cboxbInward.AutoSize = true;
            this.cboxbInward.Checked = true;
            this.cboxbInward.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxbInward.Location = new System.Drawing.Point(20, 59);
            this.cboxbInward.Name = "cboxbInward";
            this.cboxbInward.Size = new System.Drawing.Size(71, 18);
            this.cboxbInward.TabIndex = 6;
            this.cboxbInward.Text = "Inward";
            this.cboxbInward.UseVisualStyleBackColor = true;
            // 
            // cboxOpening
            // 
            this.cboxOpening.AutoSize = true;
            this.cboxOpening.Checked = true;
            this.cboxOpening.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxOpening.Location = new System.Drawing.Point(20, 28);
            this.cboxOpening.Name = "cboxOpening";
            this.cboxOpening.Size = new System.Drawing.Size(79, 18);
            this.cboxOpening.TabIndex = 5;
            this.cboxOpening.Text = "Opening";
            this.cboxOpening.UseVisualStyleBackColor = true;
            // 
            // grpReportOption
            // 
            this.grpReportOption.Controls.Add(this.radLocationGroup);
            this.grpReportOption.Controls.Add(this.radLocationwise);
            this.grpReportOption.Controls.Add(this.radCategory);
            this.grpReportOption.Controls.Add(this.radItemWise);
            this.grpReportOption.Controls.Add(this.radGroupwise);
            this.grpReportOption.Enabled = false;
            this.grpReportOption.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpReportOption.Location = new System.Drawing.Point(674, 142);
            this.grpReportOption.Name = "grpReportOption";
            this.grpReportOption.Size = new System.Drawing.Size(179, 170);
            this.grpReportOption.TabIndex = 2;
            this.grpReportOption.TabStop = false;
            this.grpReportOption.Text = "Report Option";
            // 
            // radLocationGroup
            // 
            this.radLocationGroup.AutoSize = true;
            this.radLocationGroup.Location = new System.Drawing.Point(11, 130);
            this.radLocationGroup.Name = "radLocationGroup";
            this.radLocationGroup.Size = new System.Drawing.Size(168, 18);
            this.radLocationGroup.TabIndex = 5;
            this.radLocationGroup.Text = "Location && Group Wise";
            this.radLocationGroup.UseVisualStyleBackColor = true;
            this.radLocationGroup.CheckedChanged += new System.EventHandler(this.radLocationGroup_CheckedChanged);
            this.radLocationGroup.Click += new System.EventHandler(this.radLocationGroup_Click);
            // 
            // radLocationwise
            // 
            this.radLocationwise.AutoSize = true;
            this.radLocationwise.Location = new System.Drawing.Point(11, 106);
            this.radLocationwise.Name = "radLocationwise";
            this.radLocationwise.Size = new System.Drawing.Size(113, 18);
            this.radLocationwise.TabIndex = 4;
            this.radLocationwise.Text = "Location Wise";
            this.radLocationwise.UseVisualStyleBackColor = true;
            this.radLocationwise.CheckedChanged += new System.EventHandler(this.radLocationwise_CheckedChanged);
            this.radLocationwise.Click += new System.EventHandler(this.radLocationwise_Click);
            // 
            // radCategory
            // 
            this.radCategory.AutoSize = true;
            this.radCategory.Location = new System.Drawing.Point(11, 83);
            this.radCategory.Name = "radCategory";
            this.radCategory.Size = new System.Drawing.Size(119, 18);
            this.radCategory.TabIndex = 3;
            this.radCategory.Text = "Pack Size Wise";
            this.radCategory.UseVisualStyleBackColor = true;
            this.radCategory.CheckedChanged += new System.EventHandler(this.radCategory_CheckedChanged);
            this.radCategory.Click += new System.EventHandler(this.radCategory_Click);
            // 
            // radItemWise
            // 
            this.radItemWise.AutoSize = true;
            this.radItemWise.Location = new System.Drawing.Point(11, 60);
            this.radItemWise.Name = "radItemWise";
            this.radItemWise.Size = new System.Drawing.Size(89, 18);
            this.radItemWise.TabIndex = 2;
            this.radItemWise.Text = "Item Wise";
            this.radItemWise.UseVisualStyleBackColor = true;
            this.radItemWise.CheckedChanged += new System.EventHandler(this.radItemWise_CheckedChanged);
            this.radItemWise.Click += new System.EventHandler(this.radItemWise_Click);
            // 
            // radGroupwise
            // 
            this.radGroupwise.AutoSize = true;
            this.radGroupwise.Checked = true;
            this.radGroupwise.Location = new System.Drawing.Point(11, 37);
            this.radGroupwise.Name = "radGroupwise";
            this.radGroupwise.Size = new System.Drawing.Size(98, 18);
            this.radGroupwise.TabIndex = 1;
            this.radGroupwise.TabStop = true;
            this.radGroupwise.Text = "Group Wise";
            this.radGroupwise.UseVisualStyleBackColor = true;
            this.radGroupwise.CheckedChanged += new System.EventHandler(this.radGroupwise_CheckedChanged);
            this.radGroupwise.Click += new System.EventHandler(this.radGroupwise_Click);
            // 
            // grpSuppressSelection
            // 
            this.grpSuppressSelection.Controls.Add(this.radValueSupp);
            this.grpSuppressSelection.Controls.Add(this.radSuppressZero);
            this.grpSuppressSelection.Controls.Add(this.radNoSuppress);
            this.grpSuppressSelection.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSuppressSelection.Location = new System.Drawing.Point(674, 305);
            this.grpSuppressSelection.Name = "grpSuppressSelection";
            this.grpSuppressSelection.Size = new System.Drawing.Size(179, 149);
            this.grpSuppressSelection.TabIndex = 3;
            this.grpSuppressSelection.TabStop = false;
            this.grpSuppressSelection.Text = "Suppress";
            // 
            // radValueSupp
            // 
            this.radValueSupp.AutoSize = true;
            this.radValueSupp.Location = new System.Drawing.Point(11, 88);
            this.radValueSupp.Name = "radValueSupp";
            this.radValueSupp.Size = new System.Drawing.Size(122, 18);
            this.radValueSupp.TabIndex = 8;
            this.radValueSupp.Text = "Value Suppress";
            this.radValueSupp.UseVisualStyleBackColor = true;
            this.radValueSupp.Click += new System.EventHandler(this.radValueSupp_Click);
            // 
            // radSuppressZero
            // 
            this.radSuppressZero.AutoSize = true;
            this.radSuppressZero.Location = new System.Drawing.Point(11, 55);
            this.radSuppressZero.Name = "radSuppressZero";
            this.radSuppressZero.Size = new System.Drawing.Size(121, 18);
            this.radSuppressZero.TabIndex = 7;
            this.radSuppressZero.Text = "Zero Suppress ";
            this.radSuppressZero.UseVisualStyleBackColor = true;
            this.radSuppressZero.Click += new System.EventHandler(this.radSuppressZero_Click);
            // 
            // radNoSuppress
            // 
            this.radNoSuppress.AutoSize = true;
            this.radNoSuppress.Checked = true;
            this.radNoSuppress.Location = new System.Drawing.Point(11, 27);
            this.radNoSuppress.Name = "radNoSuppress";
            this.radNoSuppress.Size = new System.Drawing.Size(105, 18);
            this.radNoSuppress.TabIndex = 6;
            this.radNoSuppress.TabStop = true;
            this.radNoSuppress.Text = "No Suppress";
            this.radNoSuppress.UseVisualStyleBackColor = true;
            this.radNoSuppress.Click += new System.EventHandler(this.radNoSuppress_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.dteToDate);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.dteFromDate);
            this.groupBox6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(8, 382);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(128, 138);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Period Selection";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(8, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "To:";
            // 
            // dteToDate
            // 
            this.dteToDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteToDate.Location = new System.Drawing.Point(6, 94);
            this.dteToDate.Name = "dteToDate";
            this.dteToDate.Size = new System.Drawing.Size(115, 22);
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
            this.dteFromDate.Location = new System.Drawing.Point(5, 46);
            this.dteFromDate.Name = "dteFromDate";
            this.dteFromDate.Size = new System.Drawing.Size(115, 22);
            this.dteFromDate.TabIndex = 20;
            this.dteFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dteFromDate_KeyPress);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.cboGroupName);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.txtSearch);
            this.groupBox7.Controls.Add(this.btnLeftAll);
            this.groupBox7.Controls.Add(this.btnLeftSingle);
            this.groupBox7.Controls.Add(this.btnRightAll);
            this.groupBox7.Controls.Add(this.btnRightSingle);
            this.groupBox7.Controls.Add(this.lstRight);
            this.groupBox7.Controls.Add(this.lstLeft);
            this.groupBox7.Location = new System.Drawing.Point(138, 143);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(534, 227);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            // 
            // cboGroupName
            // 
            this.cboGroupName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGroupName.ForeColor = System.Drawing.Color.Blue;
            this.cboGroupName.FormattingEnabled = true;
            this.cboGroupName.Location = new System.Drawing.Point(308, 28);
            this.cboGroupName.Name = "cboGroupName";
            this.cboGroupName.Size = new System.Drawing.Size(220, 22);
            this.cboGroupName.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(308, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(168, 16);
            this.label6.TabIndex = 24;
            this.label6.Text = "Selection Group Name";
            this.label6.Visible = false;
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
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(6, 30);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(252, 22);
            this.txtSearch.TabIndex = 6;
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
            // lstRight
            // 
            this.lstRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstRight.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstRight.FormattingEnabled = true;
            this.lstRight.ItemHeight = 14;
            this.lstRight.Location = new System.Drawing.Point(308, 52);
            this.lstRight.Name = "lstRight";
            this.lstRight.Size = new System.Drawing.Size(221, 170);
            this.lstRight.TabIndex = 1;
            // 
            // lstLeft
            // 
            this.lstLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstLeft.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLeft.FormattingEnabled = true;
            this.lstLeft.ItemHeight = 14;
            this.lstLeft.Location = new System.Drawing.Point(6, 53);
            this.lstLeft.Name = "lstLeft";
            this.lstLeft.Size = new System.Drawing.Size(254, 170);
            this.lstLeft.TabIndex = 0;
            // 
            // grpGroup
            // 
            this.grpGroup.Controls.Add(this.label4);
            this.grpGroup.Controls.Add(this.txtSerchGroup);
            this.grpGroup.Controls.Add(this.btnLeftAllNew);
            this.grpGroup.Controls.Add(this.btnLeftNew);
            this.grpGroup.Controls.Add(this.btnRightAllNew);
            this.grpGroup.Controls.Add(this.btnRightNew);
            this.grpGroup.Controls.Add(this.lstRightNew);
            this.grpGroup.Controls.Add(this.lstLeftNew);
            this.grpGroup.Location = new System.Drawing.Point(138, 371);
            this.grpGroup.Name = "grpGroup";
            this.grpGroup.Size = new System.Drawing.Size(534, 169);
            this.grpGroup.TabIndex = 6;
            this.grpGroup.TabStop = false;
            this.grpGroup.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(6, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 16);
            this.label4.TabIndex = 22;
            this.label4.Text = "Search";
            // 
            // txtSerchGroup
            // 
            this.txtSerchGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSerchGroup.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerchGroup.Location = new System.Drawing.Point(6, 30);
            this.txtSerchGroup.Name = "txtSerchGroup";
            this.txtSerchGroup.Size = new System.Drawing.Size(252, 22);
            this.txtSerchGroup.TabIndex = 6;
            // 
            // btnLeftAllNew
            // 
            this.btnLeftAllNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLeftAllNew.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftAllNew.Location = new System.Drawing.Point(268, 139);
            this.btnLeftAllNew.Name = "btnLeftAllNew";
            this.btnLeftAllNew.Size = new System.Drawing.Size(36, 23);
            this.btnLeftAllNew.TabIndex = 5;
            this.btnLeftAllNew.Text = "<<";
            this.btnLeftAllNew.UseVisualStyleBackColor = false;
            this.btnLeftAllNew.Click += new System.EventHandler(this.btnLeftAllNew_Click);
            // 
            // btnLeftNew
            // 
            this.btnLeftNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLeftNew.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftNew.Location = new System.Drawing.Point(268, 114);
            this.btnLeftNew.Name = "btnLeftNew";
            this.btnLeftNew.Size = new System.Drawing.Size(36, 23);
            this.btnLeftNew.TabIndex = 4;
            this.btnLeftNew.Text = "<";
            this.btnLeftNew.UseVisualStyleBackColor = false;
            this.btnLeftNew.Click += new System.EventHandler(this.btnLeftNew_Click);
            // 
            // btnRightAllNew
            // 
            this.btnRightAllNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRightAllNew.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRightAllNew.Location = new System.Drawing.Point(268, 89);
            this.btnRightAllNew.Name = "btnRightAllNew";
            this.btnRightAllNew.Size = new System.Drawing.Size(36, 23);
            this.btnRightAllNew.TabIndex = 3;
            this.btnRightAllNew.Text = ">>";
            this.btnRightAllNew.UseVisualStyleBackColor = false;
            this.btnRightAllNew.Click += new System.EventHandler(this.btnRightAllNew_Click);
            // 
            // btnRightNew
            // 
            this.btnRightNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRightNew.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRightNew.Location = new System.Drawing.Point(268, 64);
            this.btnRightNew.Name = "btnRightNew";
            this.btnRightNew.Size = new System.Drawing.Size(36, 23);
            this.btnRightNew.TabIndex = 2;
            this.btnRightNew.Text = ">";
            this.btnRightNew.UseVisualStyleBackColor = false;
            this.btnRightNew.Click += new System.EventHandler(this.btnRightNew_Click);
            // 
            // lstRightNew
            // 
            this.lstRightNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstRightNew.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstRightNew.FormattingEnabled = true;
            this.lstRightNew.ItemHeight = 14;
            this.lstRightNew.Location = new System.Drawing.Point(308, 52);
            this.lstRightNew.Name = "lstRightNew";
            this.lstRightNew.Size = new System.Drawing.Size(221, 114);
            this.lstRightNew.TabIndex = 1;
            // 
            // lstLeftNew
            // 
            this.lstLeftNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstLeftNew.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLeftNew.FormattingEnabled = true;
            this.lstLeftNew.ItemHeight = 14;
            this.lstLeftNew.Location = new System.Drawing.Point(6, 53);
            this.lstLeftNew.Name = "lstLeftNew";
            this.lstLeftNew.Size = new System.Drawing.Size(254, 114);
            this.lstLeftNew.TabIndex = 0;
            // 
            // Selection
            // 
            this.Selection.Controls.Add(this.chkbHorizontal);
            this.Selection.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Selection.Location = new System.Drawing.Point(674, 456);
            this.Selection.Name = "Selection";
            this.Selection.Size = new System.Drawing.Size(179, 70);
            this.Selection.TabIndex = 7;
            this.Selection.TabStop = false;
            this.Selection.Text = "Selection";
            // 
            // chkbHorizontal
            // 
            this.chkbHorizontal.AutoSize = true;
            this.chkbHorizontal.Location = new System.Drawing.Point(11, 31);
            this.chkbHorizontal.Name = "chkbHorizontal";
            this.chkbHorizontal.Size = new System.Drawing.Size(90, 18);
            this.chkbHorizontal.TabIndex = 8;
            this.chkbHorizontal.Text = "Horizontal";
            this.chkbHorizontal.UseVisualStyleBackColor = true;
            // 
            // frmRptStockInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(865, 525);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmRptStockInformation";
            this.Load += new System.EventHandler(this.frmRptStockInformation_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.grpReportOption.ResumeLayout(false);
            this.grpReportOption.PerformLayout();
            this.grpSuppressSelection.ResumeLayout(false);
            this.grpSuppressSelection.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.grpGroup.ResumeLayout(false);
            this.grpGroup.PerformLayout();
            this.Selection.ResumeLayout(false);
            this.Selection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSuppressSelection;
        private System.Windows.Forms.RadioButton radSuppressZero;
        private System.Windows.Forms.RadioButton radNoSuppress;
        private System.Windows.Forms.GroupBox grpReportOption;
        private System.Windows.Forms.RadioButton radLocationwise;
        private System.Windows.Forms.RadioButton radCategory;
        private System.Windows.Forms.RadioButton radItemWise;
        private System.Windows.Forms.RadioButton radGroupwise;
        private System.Windows.Forms.GroupBox grpOption;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radSelection;
        private System.Windows.Forms.RadioButton radAllItem;
        private System.Windows.Forms.RadioButton radAll;
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
        private System.Windows.Forms.CheckBox cboxClosing;
        private System.Windows.Forms.CheckBox cboxOutward;
        private System.Windows.Forms.CheckBox cboxbInward;
        private System.Windows.Forms.CheckBox cboxOpening;
        private System.Windows.Forms.RadioButton radValueSupp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radLocationGroup;
        private System.Windows.Forms.GroupBox grpGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSerchGroup;
        private System.Windows.Forms.Button btnLeftAllNew;
        private System.Windows.Forms.Button btnLeftNew;
        private System.Windows.Forms.Button btnRightAllNew;
        private System.Windows.Forms.Button btnRightNew;
        private System.Windows.Forms.ListBox lstRightNew;
        private System.Windows.Forms.ListBox lstLeftNew;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboGroupName;
        private System.Windows.Forms.GroupBox Selection;
        private System.Windows.Forms.CheckBox chkbHorizontal;
    }
}
