﻿namespace JA.Modulecontrolar.UI.DReport.Inventory.ParameterForms
{
    partial class frmRptConjumptionMonthly
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
            this.label10 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbtnSumm = new System.Windows.Forms.RadioButton();
            this.rbtnconsumption = new System.Windows.Forms.RadioButton();
            this.rbtnProductionCosting = new System.Windows.Forms.RadioButton();
            this.rbtnPackSizePower = new System.Windows.Forms.RadioButton();
            this.radRMPM = new System.Windows.Forms.RadioButton();
            this.radFG = new System.Windows.Forms.RadioButton();
            this.grpOption = new System.Windows.Forms.GroupBox();
            this.cboxClosing = new System.Windows.Forms.CheckBox();
            this.cboxOutward = new System.Windows.Forms.CheckBox();
            this.cboxbInward = new System.Windows.Forms.CheckBox();
            this.cboxOpening = new System.Windows.Forms.CheckBox();
            this.grpReportOption = new System.Windows.Forms.GroupBox();
            this.radLocationwise = new System.Windows.Forms.RadioButton();
            this.radCategory = new System.Windows.Forms.RadioButton();
            this.radItemWise = new System.Windows.Forms.RadioButton();
            this.radGroupwise = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radSuppressZero = new System.Windows.Forms.RadioButton();
            this.radNoSuppress = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dteToDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dteFromDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnLeftAll = new System.Windows.Forms.Button();
            this.btnLeftSingle = new System.Windows.Forms.Button();
            this.btnRightAll = new System.Windows.Forms.Button();
            this.btnRightSingle = new System.Windows.Forms.Button();
            this.lstRight = new System.Windows.Forms.ListBox();
            this.lstLeft = new System.Windows.Forms.ListBox();
            this.grpGroup = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboGroupName = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSerchGroup = new System.Windows.Forms.TextBox();
            this.btnLeftAllNew = new System.Windows.Forms.Button();
            this.btnLeftNew = new System.Windows.Forms.Button();
            this.btnRightAllNew = new System.Windows.Forms.Button();
            this.btnRightNew = new System.Windows.Forms.Button();
            this.lstRightNew = new System.Windows.Forms.ListBox();
            this.lstLeftNew = new System.Windows.Forms.ListBox();
            this.uctxtBranchName = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.radAllItem = new System.Windows.Forms.RadioButton();
            this.btnMapping = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.grpReportOption.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.grpGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(214, 9);
            this.frmLabel.Size = new System.Drawing.Size(301, 33);
            this.frmLabel.Text = "Monthly Cost Estimation";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.uctxtBranchName);
            this.pnlMain.Controls.Add(this.lblCategory);
            this.pnlMain.Controls.Add(this.grpGroup);
            this.pnlMain.Controls.Add(this.groupBox7);
            this.pnlMain.Controls.Add(this.groupBox6);
            this.pnlMain.Controls.Add(this.groupBox5);
            this.pnlMain.Controls.Add(this.grpReportOption);
            this.pnlMain.Controls.Add(this.groupBox2);
            this.pnlMain.Size = new System.Drawing.Size(774, 604);
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.radAllItem);
            this.pnlTop.Size = new System.Drawing.Size(776, 58);
            this.pnlTop.Controls.SetChildIndex(this.frmLabel, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnTopClose, 0);
            this.pnlTop.Controls.SetChildIndex(this.radAllItem, 0);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(329, 480);
            this.btnEdit.Size = new System.Drawing.Size(22, 10);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(216, 480);
            this.btnSave.Size = new System.Drawing.Size(10, 10);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(393, 492);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            // 
            // btnNew
            // 
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnNew.Location = new System.Drawing.Point(5, 519);
            this.btnNew.Size = new System.Drawing.Size(10, 10);
            this.btnNew.Text = "";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(666, 523);
            this.btnClose.Visible = true;
            // 
            // btnPrint
            // 
            this.btnPrint.ImageIndex = -1;
            this.btnPrint.ImageKey = "print.png";
            this.btnPrint.Location = new System.Drawing.Point(541, 523);
            this.btnPrint.Size = new System.Drawing.Size(124, 39);
            this.btnPrint.Text = "Preview";
            this.btnPrint.Visible = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 563);
            this.groupBox1.Size = new System.Drawing.Size(776, 25);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.rbtnSumm);
            this.groupBox2.Controls.Add(this.rbtnconsumption);
            this.groupBox2.Controls.Add(this.rbtnProductionCosting);
            this.groupBox2.Controls.Add(this.rbtnPackSizePower);
            this.groupBox2.Controls.Add(this.radRMPM);
            this.groupBox2.Controls.Add(this.radFG);
            this.groupBox2.Controls.Add(this.grpOption);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(7, 148);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(179, 260);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selection Option";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(7, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 16);
            this.label10.TabIndex = 22;
            this.label10.Text = "FG Production";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel3.Location = new System.Drawing.Point(6, 18);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(176, 5);
            this.panel3.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel2.Location = new System.Drawing.Point(4, 134);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(176, 5);
            this.panel2.TabIndex = 8;
            // 
            // rbtnSumm
            // 
            this.rbtnSumm.AutoSize = true;
            this.rbtnSumm.Location = new System.Drawing.Point(7, 202);
            this.rbtnSumm.Name = "rbtnSumm";
            this.rbtnSumm.Size = new System.Drawing.Size(106, 18);
            this.rbtnSumm.TabIndex = 7;
            this.rbtnSumm.Text = "Cost Percent";
            this.rbtnSumm.UseVisualStyleBackColor = true;
            this.rbtnSumm.Click += new System.EventHandler(this.rbtnSumm_Click);
            // 
            // rbtnconsumption
            // 
            this.rbtnconsumption.AutoSize = true;
            this.rbtnconsumption.Location = new System.Drawing.Point(7, 179);
            this.rbtnconsumption.Name = "rbtnconsumption";
            this.rbtnconsumption.Size = new System.Drawing.Size(137, 18);
            this.rbtnconsumption.TabIndex = 6;
            this.rbtnconsumption.Text = "RM/PM Cost Value";
            this.rbtnconsumption.UseVisualStyleBackColor = true;
            this.rbtnconsumption.Click += new System.EventHandler(this.rbtnconsumption_Click);
            // 
            // rbtnProductionCosting
            // 
            this.rbtnProductionCosting.AutoSize = true;
            this.rbtnProductionCosting.Location = new System.Drawing.Point(7, 53);
            this.rbtnProductionCosting.Name = "rbtnProductionCosting";
            this.rbtnProductionCosting.Size = new System.Drawing.Size(98, 18);
            this.rbtnProductionCosting.TabIndex = 5;
            this.rbtnProductionCosting.Text = "Group Wise";
            this.rbtnProductionCosting.UseVisualStyleBackColor = true;
            this.rbtnProductionCosting.Click += new System.EventHandler(this.rbtnProductionCosting_Click);
            // 
            // rbtnPackSizePower
            // 
            this.rbtnPackSizePower.AutoSize = true;
            this.rbtnPackSizePower.Location = new System.Drawing.Point(7, 102);
            this.rbtnPackSizePower.Name = "rbtnPackSizePower";
            this.rbtnPackSizePower.Size = new System.Drawing.Size(167, 18);
            this.rbtnPackSizePower.TabIndex = 4;
            this.rbtnPackSizePower.Text = "Pack Size/Power Class";
            this.rbtnPackSizePower.UseVisualStyleBackColor = true;
            this.rbtnPackSizePower.Click += new System.EventHandler(this.rbtnPackSizePower_Click);
            // 
            // radRMPM
            // 
            this.radRMPM.AutoSize = true;
            this.radRMPM.Checked = true;
            this.radRMPM.Location = new System.Drawing.Point(7, 156);
            this.radRMPM.Name = "radRMPM";
            this.radRMPM.Size = new System.Drawing.Size(153, 18);
            this.radRMPM.TabIndex = 3;
            this.radRMPM.TabStop = true;
            this.radRMPM.Text = "RM/PM Consumption";
            this.radRMPM.UseVisualStyleBackColor = true;
            this.radRMPM.Click += new System.EventHandler(this.radRMPM_Click);
            // 
            // radFG
            // 
            this.radFG.AutoSize = true;
            this.radFG.Location = new System.Drawing.Point(7, 78);
            this.radFG.Name = "radFG";
            this.radFG.Size = new System.Drawing.Size(93, 18);
            this.radFG.TabIndex = 2;
            this.radFG.Text = "Item Wise ";
            this.radFG.UseVisualStyleBackColor = true;
            this.radFG.CheckedChanged += new System.EventHandler(this.radFG_CheckedChanged);
            this.radFG.Click += new System.EventHandler(this.radFG_Click);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.cboxClosing);
            this.grpOption.Controls.Add(this.cboxOutward);
            this.grpOption.Controls.Add(this.cboxbInward);
            this.grpOption.Controls.Add(this.cboxOpening);
            this.grpOption.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpOption.Location = new System.Drawing.Point(6, 126);
            this.grpOption.Name = "grpOption";
            this.grpOption.Size = new System.Drawing.Size(10, 10);
            this.grpOption.TabIndex = 1;
            this.grpOption.TabStop = false;
            this.grpOption.Text = "Option";
            this.grpOption.Visible = false;
            // 
            // cboxClosing
            // 
            this.cboxClosing.AutoSize = true;
            this.cboxClosing.Checked = true;
            this.cboxClosing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxClosing.Location = new System.Drawing.Point(14, 131);
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
            this.cboxOutward.Location = new System.Drawing.Point(13, 101);
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
            this.cboxbInward.Location = new System.Drawing.Point(14, 73);
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
            this.cboxOpening.Location = new System.Drawing.Point(13, 43);
            this.cboxOpening.Name = "cboxOpening";
            this.cboxOpening.Size = new System.Drawing.Size(79, 18);
            this.cboxOpening.TabIndex = 5;
            this.cboxOpening.Text = "Opening";
            this.cboxOpening.UseVisualStyleBackColor = true;
            // 
            // grpReportOption
            // 
            this.grpReportOption.Controls.Add(this.radLocationwise);
            this.grpReportOption.Controls.Add(this.radCategory);
            this.grpReportOption.Controls.Add(this.radItemWise);
            this.grpReportOption.Controls.Add(this.radGroupwise);
            this.grpReportOption.Enabled = false;
            this.grpReportOption.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpReportOption.Location = new System.Drawing.Point(618, 183);
            this.grpReportOption.Name = "grpReportOption";
            this.grpReportOption.Size = new System.Drawing.Size(31, 10);
            this.grpReportOption.TabIndex = 2;
            this.grpReportOption.TabStop = false;
            this.grpReportOption.Text = "Report Option";
            this.grpReportOption.Visible = false;
            // 
            // radLocationwise
            // 
            this.radLocationwise.AutoSize = true;
            this.radLocationwise.Location = new System.Drawing.Point(33, 106);
            this.radLocationwise.Name = "radLocationwise";
            this.radLocationwise.Size = new System.Drawing.Size(113, 18);
            this.radLocationwise.TabIndex = 4;
            this.radLocationwise.Text = "Location Wise";
            this.radLocationwise.UseVisualStyleBackColor = true;
            this.radLocationwise.Visible = false;
            this.radLocationwise.CheckedChanged += new System.EventHandler(this.radLocationwise_CheckedChanged);
            this.radLocationwise.Click += new System.EventHandler(this.radLocationwise_Click);
            // 
            // radCategory
            // 
            this.radCategory.AutoSize = true;
            this.radCategory.Location = new System.Drawing.Point(33, 83);
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
            this.radItemWise.Location = new System.Drawing.Point(33, 60);
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
            this.radGroupwise.Location = new System.Drawing.Point(33, 37);
            this.radGroupwise.Name = "radGroupwise";
            this.radGroupwise.Size = new System.Drawing.Size(98, 18);
            this.radGroupwise.TabIndex = 1;
            this.radGroupwise.TabStop = true;
            this.radGroupwise.Text = "Group Wise";
            this.radGroupwise.UseVisualStyleBackColor = true;
            this.radGroupwise.CheckedChanged += new System.EventHandler(this.radGroupwise_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radSuppressZero);
            this.groupBox5.Controls.Add(this.radNoSuppress);
            this.groupBox5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(618, 148);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(10, 10);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Visible = false;
            // 
            // radSuppressZero
            // 
            this.radSuppressZero.AutoSize = true;
            this.radSuppressZero.Location = new System.Drawing.Point(32, 55);
            this.radSuppressZero.Name = "radSuppressZero";
            this.radSuppressZero.Size = new System.Drawing.Size(117, 18);
            this.radSuppressZero.TabIndex = 7;
            this.radSuppressZero.Text = "Suppress Zero";
            this.radSuppressZero.UseVisualStyleBackColor = true;
            // 
            // radNoSuppress
            // 
            this.radNoSuppress.AutoSize = true;
            this.radNoSuppress.Checked = true;
            this.radNoSuppress.Location = new System.Drawing.Point(32, 27);
            this.radNoSuppress.Name = "radNoSuppress";
            this.radNoSuppress.Size = new System.Drawing.Size(105, 18);
            this.radNoSuppress.TabIndex = 6;
            this.radNoSuppress.TabStop = true;
            this.radNoSuppress.Text = "No Suppress";
            this.radNoSuppress.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.dteToDate);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.dteFromDate);
            this.groupBox6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(4, 454);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(198, 83);
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
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.txtSearch);
            this.groupBox7.Controls.Add(this.btnLeftAll);
            this.groupBox7.Controls.Add(this.btnLeftSingle);
            this.groupBox7.Controls.Add(this.btnRightAll);
            this.groupBox7.Controls.Add(this.btnRightSingle);
            this.groupBox7.Controls.Add(this.lstRight);
            this.groupBox7.Controls.Add(this.lstLeft);
            this.groupBox7.Location = new System.Drawing.Point(198, 195);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(566, 213);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(192, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 16);
            this.label9.TabIndex = 28;
            this.label9.Text = "Search";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(8, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 27;
            this.label3.Text = "Location";
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(6, 29);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(246, 22);
            this.txtSearch.TabIndex = 6;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnLeftAll
            // 
            this.btnLeftAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLeftAll.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftAll.Location = new System.Drawing.Point(258, 161);
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
            this.btnLeftSingle.Location = new System.Drawing.Point(258, 136);
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
            this.btnRightAll.Location = new System.Drawing.Point(258, 111);
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
            this.btnRightSingle.Location = new System.Drawing.Point(258, 86);
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
            this.lstRight.Location = new System.Drawing.Point(299, 52);
            this.lstRight.Name = "lstRight";
            this.lstRight.Size = new System.Drawing.Size(258, 156);
            this.lstRight.TabIndex = 1;
            // 
            // lstLeft
            // 
            this.lstLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstLeft.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLeft.FormattingEnabled = true;
            this.lstLeft.ItemHeight = 14;
            this.lstLeft.Location = new System.Drawing.Point(6, 52);
            this.lstLeft.Name = "lstLeft";
            this.lstLeft.Size = new System.Drawing.Size(248, 156);
            this.lstLeft.TabIndex = 0;
            // 
            // grpGroup
            // 
            this.grpGroup.Controls.Add(this.label8);
            this.grpGroup.Controls.Add(this.cboGroupName);
            this.grpGroup.Controls.Add(this.label6);
            this.grpGroup.Controls.Add(this.label4);
            this.grpGroup.Controls.Add(this.txtSerchGroup);
            this.grpGroup.Controls.Add(this.btnLeftAllNew);
            this.grpGroup.Controls.Add(this.btnLeftNew);
            this.grpGroup.Controls.Add(this.btnRightAllNew);
            this.grpGroup.Controls.Add(this.btnRightNew);
            this.grpGroup.Controls.Add(this.lstRightNew);
            this.grpGroup.Controls.Add(this.lstLeftNew);
            this.grpGroup.Location = new System.Drawing.Point(197, 405);
            this.grpGroup.Name = "grpGroup";
            this.grpGroup.Size = new System.Drawing.Size(567, 192);
            this.grpGroup.TabIndex = 7;
            this.grpGroup.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(9, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 16);
            this.label8.TabIndex = 28;
            this.label8.Text = "Stock Group";
            // 
            // cboGroupName
            // 
            this.cboGroupName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGroupName.ForeColor = System.Drawing.Color.Blue;
            this.cboGroupName.FormattingEnabled = true;
            this.cboGroupName.Location = new System.Drawing.Point(308, 29);
            this.cboGroupName.Name = "cboGroupName";
            this.cboGroupName.Size = new System.Drawing.Size(250, 22);
            this.cboGroupName.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(308, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 16);
            this.label6.TabIndex = 26;
            this.label6.Text = "Stock Group Select";
            this.label6.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(200, 11);
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
            this.lstRightNew.Size = new System.Drawing.Size(250, 128);
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
            this.lstLeftNew.Size = new System.Drawing.Size(254, 128);
            this.lstLeftNew.TabIndex = 0;
            // 
            // uctxtBranchName
            // 
            this.uctxtBranchName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtBranchName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtBranchName.Location = new System.Drawing.Point(299, 154);
            this.uctxtBranchName.Name = "uctxtBranchName";
            this.uctxtBranchName.Size = new System.Drawing.Size(350, 23);
            this.uctxtBranchName.TabIndex = 60;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(201, 157);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(95, 14);
            this.lblCategory.TabIndex = 61;
            this.lblCategory.Text = "Branch Name:";
            // 
            // radAllItem
            // 
            this.radAllItem.AutoSize = true;
            this.radAllItem.Location = new System.Drawing.Point(57, 12);
            this.radAllItem.Name = "radAllItem";
            this.radAllItem.Size = new System.Drawing.Size(43, 17);
            this.radAllItem.TabIndex = 15;
            this.radAllItem.Text = "All ";
            this.radAllItem.UseVisualStyleBackColor = true;
            this.radAllItem.Visible = false;
            // 
            // btnMapping
            // 
            this.btnMapping.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnMapping.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMapping.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnMapping.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMapping.Location = new System.Drawing.Point(5, 519);
            this.btnMapping.Name = "btnMapping";
            this.btnMapping.Size = new System.Drawing.Size(465, 43);
            this.btnMapping.TabIndex = 15;
            this.btnMapping.Text = "Stock Group Mapping (RM/PM Cost Value && Cost Percent Report)";
            this.btnMapping.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMapping.UseVisualStyleBackColor = false;
            this.btnMapping.Click += new System.EventHandler(this.btnMapping_Click);
            // 
            // frmRptConjumptionMonthly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(776, 588);
            this.Controls.Add(this.btnMapping);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmRptConjumptionMonthly";
            this.Load += new System.EventHandler(this.frmRptConjumptionMonthly_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.pnlMain, 0);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.Controls.SetChildIndex(this.btnMapping, 0);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.grpReportOption.ResumeLayout(false);
            this.grpReportOption.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.grpGroup.ResumeLayout(false);
            this.grpGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton radSuppressZero;
        private System.Windows.Forms.RadioButton radNoSuppress;
        private System.Windows.Forms.GroupBox grpReportOption;
        private System.Windows.Forms.RadioButton radLocationwise;
        private System.Windows.Forms.RadioButton radCategory;
        private System.Windows.Forms.RadioButton radItemWise;
        private System.Windows.Forms.RadioButton radGroupwise;
        private System.Windows.Forms.GroupBox grpOption;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radFG;
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
        private System.Windows.Forms.RadioButton radRMPM;
        private System.Windows.Forms.GroupBox grpGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSerchGroup;
        private System.Windows.Forms.Button btnLeftAllNew;
        private System.Windows.Forms.Button btnLeftNew;
        private System.Windows.Forms.Button btnRightAllNew;
        private System.Windows.Forms.Button btnRightNew;
        private System.Windows.Forms.ListBox lstRightNew;
        private System.Windows.Forms.ListBox lstLeftNew;
        private System.Windows.Forms.ComboBox cboGroupName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rbtnPackSizePower;
        private System.Windows.Forms.RadioButton rbtnProductionCosting;
        private System.Windows.Forms.RadioButton rbtnSumm;
        private System.Windows.Forms.RadioButton rbtnconsumption;
        private System.Windows.Forms.TextBox uctxtBranchName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radAllItem;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnMapping;
    }
}
