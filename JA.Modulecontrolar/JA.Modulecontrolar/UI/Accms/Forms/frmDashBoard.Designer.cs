namespace JA.Modulecontrolar.UI.Accms.Forms
{
    partial class frmDashBoard
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtCurrentTime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCurrentDate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtBranch = new System.Windows.Forms.TextBox();
            this.pnlBranch = new System.Windows.Forms.Panel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtBankOD = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtFTCashatBank = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtFTCashInHand = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtRecAmt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpToRDW = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpFromRDW = new System.Windows.Forms.DateTimePicker();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtSalesAmt = new System.Windows.Forms.TextBox();
            this.dteSDRWToDate = new System.Windows.Forms.DateTimePicker();
            this.dteSDRWformDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtToDayInvNo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtToDayInvAmt = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textNoOfInvoice = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtinAmount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlBranch.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.ForeColor = System.Drawing.Color.Blue;
            this.frmLabel.Location = new System.Drawing.Point(19, 19);
            this.frmLabel.Size = new System.Drawing.Size(368, 33);
            this.frmLabel.Text = "Top Management Dash Board";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlBranch);
            this.pnlMain.Location = new System.Drawing.Point(-10, -97);
            this.pnlMain.Size = new System.Drawing.Size(796, 609);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.panel2);
            this.pnlTop.Size = new System.Drawing.Size(789, 84);
            this.pnlTop.Controls.SetChildIndex(this.frmLabel, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnTopClose, 0);
            this.pnlTop.Controls.SetChildIndex(this.panel2, 0);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(39, 481);
            this.btnEdit.Size = new System.Drawing.Size(11, 20);
            this.btnEdit.Text = "List All";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 481);
            this.btnSave.Size = new System.Drawing.Size(21, 18);
            this.btnSave.Text = "Apply";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(5, -2);
            this.btnDelete.Size = new System.Drawing.Size(11, 10);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(81, 481);
            this.btnNew.Size = new System.Drawing.Size(10, 20);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(650, 468);
            this.btnClose.Size = new System.Drawing.Size(128, 39);
            this.btnClose.Visible = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(116, -2);
            this.btnPrint.Size = new System.Drawing.Size(10, 16);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 525);
            this.groupBox1.Size = new System.Drawing.Size(789, 27);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtCurrentTime);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtCurrentDate);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(496, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(294, 70);
            this.panel2.TabIndex = 75;
            // 
            // txtCurrentTime
            // 
            this.txtCurrentTime.BackColor = System.Drawing.Color.White;
            this.txtCurrentTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCurrentTime.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentTime.Location = new System.Drawing.Point(117, 32);
            this.txtCurrentTime.Multiline = true;
            this.txtCurrentTime.Name = "txtCurrentTime";
            this.txtCurrentTime.ReadOnly = true;
            this.txtCurrentTime.Size = new System.Drawing.Size(163, 26);
            this.txtCurrentTime.TabIndex = 77;
            this.txtCurrentTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(6, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 16);
            this.label5.TabIndex = 76;
            this.label5.Text = "Current Time :";
            // 
            // txtCurrentDate
            // 
            this.txtCurrentDate.BackColor = System.Drawing.Color.White;
            this.txtCurrentDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCurrentDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentDate.Location = new System.Drawing.Point(117, 6);
            this.txtCurrentDate.Multiline = true;
            this.txtCurrentDate.Name = "txtCurrentDate";
            this.txtCurrentDate.ReadOnly = true;
            this.txtCurrentDate.Size = new System.Drawing.Size(163, 24);
            this.txtCurrentDate.TabIndex = 75;
            this.txtCurrentDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(7, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 16);
            this.label4.TabIndex = 74;
            this.label4.Text = "Current Date :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(7, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 17);
            this.label8.TabIndex = 74;
            this.label8.Text = "Branch Name :";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(586, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(160, 26);
            this.btnRefresh.TabIndex = 78;
            this.btnRefresh.Text = "Refresh ";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtBranch
            // 
            this.txtBranch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBranch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBranch.Location = new System.Drawing.Point(118, 5);
            this.txtBranch.MaxLength = 50;
            this.txtBranch.Name = "txtBranch";
            this.txtBranch.Size = new System.Drawing.Size(464, 23);
            this.txtBranch.TabIndex = 79;
            this.txtBranch.Text = "All";
            // 
            // pnlBranch
            // 
            this.pnlBranch.BackColor = System.Drawing.Color.Beige;
            this.pnlBranch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBranch.Controls.Add(this.groupBox6);
            this.pnlBranch.Controls.Add(this.groupBox5);
            this.pnlBranch.Controls.Add(this.groupBox4);
            this.pnlBranch.Controls.Add(this.groupBox3);
            this.pnlBranch.Controls.Add(this.groupBox2);
            this.pnlBranch.Controls.Add(this.txtBranch);
            this.pnlBranch.Controls.Add(this.btnRefresh);
            this.pnlBranch.Controls.Add(this.label8);
            this.pnlBranch.Location = new System.Drawing.Point(11, 182);
            this.pnlBranch.Name = "pnlBranch";
            this.pnlBranch.Size = new System.Drawing.Size(782, 426);
            this.pnlBranch.TabIndex = 78;
            this.pnlBranch.Tag = "";
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox6.Controls.Add(this.txtBankOD);
            this.groupBox6.Controls.Add(this.label19);
            this.groupBox6.Controls.Add(this.txtFTCashatBank);
            this.groupBox6.Controls.Add(this.label17);
            this.groupBox6.Controls.Add(this.txtFTCashInHand);
            this.groupBox6.Controls.Add(this.label18);
            this.groupBox6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.ForeColor = System.Drawing.Color.Black;
            this.groupBox6.Location = new System.Drawing.Point(149, 304);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(463, 118);
            this.groupBox6.TabIndex = 88;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Financial Transaction";
            // 
            // txtBankOD
            // 
            this.txtBankOD.BackColor = System.Drawing.Color.White;
            this.txtBankOD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBankOD.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBankOD.Location = new System.Drawing.Point(174, 83);
            this.txtBankOD.Multiline = true;
            this.txtBankOD.Name = "txtBankOD";
            this.txtBankOD.ReadOnly = true;
            this.txtBankOD.Size = new System.Drawing.Size(264, 28);
            this.txtBankOD.TabIndex = 81;
            this.txtBankOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label19.Location = new System.Drawing.Point(68, 83);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(96, 17);
            this.label19.TabIndex = 80;
            this.label19.Text = "Bank O/D :";
            // 
            // txtFTCashatBank
            // 
            this.txtFTCashatBank.BackColor = System.Drawing.Color.White;
            this.txtFTCashatBank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFTCashatBank.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFTCashatBank.Location = new System.Drawing.Point(174, 55);
            this.txtFTCashatBank.Multiline = true;
            this.txtFTCashatBank.Name = "txtFTCashatBank";
            this.txtFTCashatBank.ReadOnly = true;
            this.txtFTCashatBank.Size = new System.Drawing.Size(264, 27);
            this.txtFTCashatBank.TabIndex = 79;
            this.txtFTCashatBank.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label17.Location = new System.Drawing.Point(44, 57);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(121, 17);
            this.label17.TabIndex = 78;
            this.label17.Text = "Cash at Bank :";
            // 
            // txtFTCashInHand
            // 
            this.txtFTCashInHand.BackColor = System.Drawing.Color.White;
            this.txtFTCashInHand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFTCashInHand.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFTCashInHand.Location = new System.Drawing.Point(174, 28);
            this.txtFTCashInHand.Multiline = true;
            this.txtFTCashInHand.Name = "txtFTCashInHand";
            this.txtFTCashInHand.ReadOnly = true;
            this.txtFTCashInHand.Size = new System.Drawing.Size(264, 25);
            this.txtFTCashInHand.TabIndex = 78;
            this.txtFTCashInHand.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label18.Location = new System.Drawing.Point(43, 29);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(121, 17);
            this.label18.TabIndex = 77;
            this.label18.Text = "Cash in Hand :";
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.txtRecAmt);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.dtpToRDW);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.dtpFromRDW);
            this.groupBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.Color.Black;
            this.groupBox5.Location = new System.Drawing.Point(391, 142);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(384, 161);
            this.groupBox5.TabIndex = 87;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Receipt - Date Range Wise";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label16.Location = new System.Drawing.Point(3, 132);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(142, 17);
            this.label16.TabIndex = 83;
            this.label16.Text = "Receipt Amount :";
            // 
            // txtRecAmt
            // 
            this.txtRecAmt.BackColor = System.Drawing.Color.White;
            this.txtRecAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRecAmt.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecAmt.Location = new System.Drawing.Point(146, 128);
            this.txtRecAmt.Multiline = true;
            this.txtRecAmt.Name = "txtRecAmt";
            this.txtRecAmt.ReadOnly = true;
            this.txtRecAmt.Size = new System.Drawing.Size(234, 28);
            this.txtRecAmt.TabIndex = 81;
            this.txtRecAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(38, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 17);
            this.label9.TabIndex = 82;
            this.label9.Text = "To Date :";
            // 
            // dtpToRDW
            // 
            this.dtpToRDW.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToRDW.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToRDW.Location = new System.Drawing.Point(43, 98);
            this.dtpToRDW.Name = "dtpToRDW";
            this.dtpToRDW.Size = new System.Drawing.Size(264, 24);
            this.dtpToRDW.TabIndex = 82;
            this.dtpToRDW.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpToRDW_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label14.Location = new System.Drawing.Point(37, 25);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(99, 17);
            this.label14.TabIndex = 81;
            this.label14.Text = "From Date :";
            // 
            // dtpFromRDW
            // 
            this.dtpFromRDW.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromRDW.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromRDW.Location = new System.Drawing.Point(43, 45);
            this.dtpFromRDW.Name = "dtpFromRDW";
            this.dtpFromRDW.Size = new System.Drawing.Size(264, 24);
            this.dtpFromRDW.TabIndex = 81;
            this.dtpFromRDW.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpFromRDW_KeyPress);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.txtSalesAmt);
            this.groupBox4.Controls.Add(this.dteSDRWToDate);
            this.groupBox4.Controls.Add(this.dteSDRWformDate);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.Black;
            this.groupBox4.Location = new System.Drawing.Point(4, 142);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(387, 161);
            this.groupBox4.TabIndex = 86;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Sales - Date Range Wise";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label15.Location = new System.Drawing.Point(1, 132);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(143, 17);
            this.label15.TabIndex = 81;
            this.label15.Text = "Invoice Amount :";
            // 
            // txtSalesAmt
            // 
            this.txtSalesAmt.BackColor = System.Drawing.Color.White;
            this.txtSalesAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSalesAmt.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesAmt.Location = new System.Drawing.Point(145, 129);
            this.txtSalesAmt.Multiline = true;
            this.txtSalesAmt.Name = "txtSalesAmt";
            this.txtSalesAmt.ReadOnly = true;
            this.txtSalesAmt.Size = new System.Drawing.Size(235, 24);
            this.txtSalesAmt.TabIndex = 80;
            this.txtSalesAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dteSDRWToDate
            // 
            this.dteSDRWToDate.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteSDRWToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteSDRWToDate.Location = new System.Drawing.Point(39, 98);
            this.dteSDRWToDate.Name = "dteSDRWToDate";
            this.dteSDRWToDate.Size = new System.Drawing.Size(264, 24);
            this.dteSDRWToDate.TabIndex = 80;
            this.dteSDRWToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dteSDRWToDate_KeyPress);
            // 
            // dteSDRWformDate
            // 
            this.dteSDRWformDate.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteSDRWformDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteSDRWformDate.Location = new System.Drawing.Point(39, 45);
            this.dteSDRWformDate.Name = "dteSDRWformDate";
            this.dteSDRWformDate.Size = new System.Drawing.Size(264, 24);
            this.dteSDRWformDate.TabIndex = 79;
            this.dteSDRWformDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dteSDRWformDate_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(37, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 78;
            this.label1.Text = "To Date :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(36, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 17);
            this.label3.TabIndex = 77;
            this.label3.Text = "From Date :";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox3.Controls.Add(this.txtToDayInvNo);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txtToDayInvAmt);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(393, 31);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(384, 108);
            this.groupBox3.TabIndex = 85;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sales - To Day";
            // 
            // txtToDayInvNo
            // 
            this.txtToDayInvNo.BackColor = System.Drawing.Color.White;
            this.txtToDayInvNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtToDayInvNo.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToDayInvNo.Location = new System.Drawing.Point(43, 74);
            this.txtToDayInvNo.Multiline = true;
            this.txtToDayInvNo.Name = "txtToDayInvNo";
            this.txtToDayInvNo.ReadOnly = true;
            this.txtToDayInvNo.Size = new System.Drawing.Size(264, 30);
            this.txtToDayInvNo.TabIndex = 83;
            this.txtToDayInvNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(105, 54);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 17);
            this.label12.TabIndex = 81;
            this.label12.Text = "No of Invoice";
            // 
            // txtToDayInvAmt
            // 
            this.txtToDayInvAmt.BackColor = System.Drawing.Color.White;
            this.txtToDayInvAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtToDayInvAmt.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToDayInvAmt.Location = new System.Drawing.Point(144, 21);
            this.txtToDayInvAmt.Multiline = true;
            this.txtToDayInvAmt.Name = "txtToDayInvAmt";
            this.txtToDayInvAmt.ReadOnly = true;
            this.txtToDayInvAmt.Size = new System.Drawing.Size(234, 30);
            this.txtToDayInvAmt.TabIndex = 82;
            this.txtToDayInvAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(138, 17);
            this.label13.TabIndex = 80;
            this.label13.Text = "Invoice Amount:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox2.Controls.Add(this.textNoOfInvoice);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtinAmount);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(3, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(390, 109);
            this.groupBox2.TabIndex = 84;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sales - Current Year";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // textNoOfInvoice
            // 
            this.textNoOfInvoice.BackColor = System.Drawing.Color.White;
            this.textNoOfInvoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textNoOfInvoice.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textNoOfInvoice.Location = new System.Drawing.Point(33, 74);
            this.textNoOfInvoice.Multiline = true;
            this.textNoOfInvoice.Name = "textNoOfInvoice";
            this.textNoOfInvoice.ReadOnly = true;
            this.textNoOfInvoice.Size = new System.Drawing.Size(264, 26);
            this.textNoOfInvoice.TabIndex = 79;
            this.textNoOfInvoice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(107, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 17);
            this.label11.TabIndex = 78;
            this.label11.Text = "No of Invoice";
            // 
            // txtinAmount
            // 
            this.txtinAmount.BackColor = System.Drawing.Color.White;
            this.txtinAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtinAmount.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtinAmount.Location = new System.Drawing.Point(146, 22);
            this.txtinAmount.Multiline = true;
            this.txtinAmount.Name = "txtinAmount";
            this.txtinAmount.ReadOnly = true;
            this.txtinAmount.Size = new System.Drawing.Size(235, 25);
            this.txtinAmount.TabIndex = 78;
            this.txtinAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(138, 17);
            this.label10.TabIndex = 77;
            this.label10.Text = "Invoice Amount:";
            // 
            // frmDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(789, 552);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmDashBoard";
            this.Load += new System.EventHandler(this.frmDashBoard_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlBranch.ResumeLayout(false);
            this.pnlBranch.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtCurrentTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCurrentDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlBranch;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtBankOD;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtFTCashatBank;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtFTCashInHand;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtRecAmt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpToRDW;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtpFromRDW;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtSalesAmt;
        private System.Windows.Forms.DateTimePicker dteSDRWToDate;
        private System.Windows.Forms.DateTimePicker dteSDRWformDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtToDayInvNo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtToDayInvAmt;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textNoOfInvoice;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtinAmount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBranch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label8;
    }
}
