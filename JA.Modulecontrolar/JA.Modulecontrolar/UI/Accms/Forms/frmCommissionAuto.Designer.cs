namespace JA.Modulecontrolar.UI.Accms.Forms
{
    partial class frmCommissionAuto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label6 = new System.Windows.Forms.Label();
            this.uctxtMedicalRep = new MayhediControlLibrary.StandardTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDrCr = new MayhediControlLibrary.StandardTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.uctxtBranch = new System.Windows.Forms.TextBox();
            this.DGMr = new MayhediControlLibrary.StandardDataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uctxtMonthID = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.uctxtAmount = new System.Windows.Forms.TextBox();
            this.uctxtOldNo = new System.Windows.Forms.TextBox();
            this.txtNarr = new MayhediControlLibrary.StandardTextBox();
            this.chkStatus = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DG = new System.Windows.Forms.DataGridView();
            this.txtFTotal = new MayhediControlLibrary.StandardTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.DGCC = new MayhediDataGridView();
            this.txtCollComit = new MayhediControlLibrary.StandardTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtVoucherColl = new MayhediControlLibrary.StandardTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txttotalAmt = new MayhediControlLibrary.StandardTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCashCollection = new MayhediControlLibrary.StandardTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dteToDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dteFDate = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.uctxtTeritorryName = new System.Windows.Forms.TextBox();
            this.uctxtTerritoryCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dteVoucherDate = new System.Windows.Forms.DateTimePicker();
            this.uctxtVoucherNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGMr)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGCC)).BeginInit();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Font = new System.Drawing.Font("Tahoma", 20.25F);
            this.frmLabel.Location = new System.Drawing.Point(185, -1);
            this.frmLabel.Size = new System.Drawing.Size(389, 33);
            this.frmLabel.Text = "MPO Commission Auto Voucher";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.progressBar1);
            this.pnlMain.Controls.Add(this.chkStatus);
            this.pnlMain.Controls.Add(this.txtNarr);
            this.pnlMain.Controls.Add(this.label16);
            this.pnlMain.Controls.Add(this.uctxtMonthID);
            this.pnlMain.Controls.Add(this.DGMr);
            this.pnlMain.Controls.Add(this.uctxtBranch);
            this.pnlMain.Controls.Add(this.label15);
            this.pnlMain.Controls.Add(this.txtDrCr);
            this.pnlMain.Controls.Add(this.uctxtMedicalRep);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.label6);
            this.pnlMain.Controls.Add(this.dteVoucherDate);
            this.pnlMain.Size = new System.Drawing.Size(679, 462);
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.uctxtOldNo);
            this.pnlTop.Controls.Add(this.uctxtAmount);
            this.pnlTop.Size = new System.Drawing.Size(683, 42);
            this.pnlTop.Controls.SetChildIndex(this.frmLabel, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnTopClose, 0);
            this.pnlTop.Controls.SetChildIndex(this.uctxtAmount, 0);
            this.pnlTop.Controls.SetChildIndex(this.uctxtOldNo, 0);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(301, 376);
            this.btnEdit.Size = new System.Drawing.Size(20, 16);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(438, 381);
            this.btnSave.Size = new System.Drawing.Size(105, 38);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(493, 387);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(5, 376);
            this.btnNew.Size = new System.Drawing.Size(11, 15);
            this.btnNew.Text = "List All";
            this.btnNew.Visible = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(550, 381);
            this.btnClose.Size = new System.Drawing.Size(129, 38);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(348, 376);
            this.btnPrint.Size = new System.Drawing.Size(28, 16);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 419);
            this.groupBox1.Size = new System.Drawing.Size(683, 24);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(37, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 16);
            this.label6.TabIndex = 77;
            this.label6.Text = "Branch Name:";
            // 
            // uctxtMedicalRep
            // 
            this.uctxtMedicalRep.BackColor = System.Drawing.Color.White;
            this.uctxtMedicalRep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtMedicalRep.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtMedicalRep.Location = new System.Drawing.Point(143, 215);
            this.uctxtMedicalRep.Name = "uctxtMedicalRep";
            this.uctxtMedicalRep.Size = new System.Drawing.Size(502, 24);
            this.uctxtMedicalRep.TabIndex = 80;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(53, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 16);
            this.label4.TabIndex = 79;
            this.label4.Text = "MPO Name:";
            // 
            // txtDrCr
            // 
            this.txtDrCr.BackColor = System.Drawing.Color.White;
            this.txtDrCr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDrCr.Enabled = false;
            this.txtDrCr.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDrCr.Location = new System.Drawing.Point(645, 214);
            this.txtDrCr.Name = "txtDrCr";
            this.txtDrCr.ReadOnly = true;
            this.txtDrCr.Size = new System.Drawing.Size(25, 24);
            this.txtDrCr.TabIndex = 81;
            this.txtDrCr.Text = "Cr.";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(62, 277);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 17);
            this.label15.TabIndex = 99;
            this.label15.Text = "Narration :";
            // 
            // uctxtBranch
            // 
            this.uctxtBranch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtBranch.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtBranch.Location = new System.Drawing.Point(143, 168);
            this.uctxtBranch.Name = "uctxtBranch";
            this.uctxtBranch.Size = new System.Drawing.Size(502, 22);
            this.uctxtBranch.TabIndex = 2;
            // 
            // DGMr
            // 
            this.DGMr.AllowUserToAddRows = false;
            this.DGMr.AllowUserToDeleteRows = false;
            this.DGMr.AllowUserToOrderColumns = true;
            this.DGMr.AllowUserToResizeColumns = false;
            this.DGMr.AllowUserToResizeRows = false;
            this.DGMr.BackgroundColor = System.Drawing.Color.White;
            this.DGMr.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGMr.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.DGMr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGMr.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGMr.DefaultCellStyle = dataGridViewCellStyle12;
            this.DGMr.Location = new System.Drawing.Point(144, 244);
            this.DGMr.MultiSelect = false;
            this.DGMr.Name = "DGMr";
            this.DGMr.RowHeadersVisible = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            this.DGMr.RowsDefaultCellStyle = dataGridViewCellStyle13;
            this.DGMr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGMr.Size = new System.Drawing.Size(505, 23);
            this.DGMr.TabIndex = 210;
            this.DGMr.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn6.HeaderText = "Teritorry Code";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn13.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn13.HeaderText = "Teritorry name";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 130;
            // 
            // dataGridViewTextBoxColumn14
            // 
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn14.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn14.HeaderText = "MPO Name";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 270;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.HeaderText = "String";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Visible = false;
            // 
            // uctxtMonthID
            // 
            this.uctxtMonthID.BackColor = System.Drawing.Color.White;
            this.uctxtMonthID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtMonthID.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtMonthID.Location = new System.Drawing.Point(143, 136);
            this.uctxtMonthID.Name = "uctxtMonthID";
            this.uctxtMonthID.ReadOnly = true;
            this.uctxtMonthID.Size = new System.Drawing.Size(176, 23);
            this.uctxtMonthID.TabIndex = 15;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(21, 136);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(116, 17);
            this.label16.TabIndex = 211;
            this.label16.Text = "Collection Month:";
            // 
            // uctxtAmount
            // 
            this.uctxtAmount.BackColor = System.Drawing.Color.White;
            this.uctxtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtAmount.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtAmount.Location = new System.Drawing.Point(122, 12);
            this.uctxtAmount.Name = "uctxtAmount";
            this.uctxtAmount.Size = new System.Drawing.Size(16, 23);
            this.uctxtAmount.TabIndex = 16;
            this.uctxtAmount.Visible = false;
            // 
            // uctxtOldNo
            // 
            this.uctxtOldNo.BackColor = System.Drawing.Color.White;
            this.uctxtOldNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtOldNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtOldNo.Location = new System.Drawing.Point(41, 3);
            this.uctxtOldNo.Name = "uctxtOldNo";
            this.uctxtOldNo.Size = new System.Drawing.Size(68, 23);
            this.uctxtOldNo.TabIndex = 17;
            this.uctxtOldNo.Visible = false;
            // 
            // txtNarr
            // 
            this.txtNarr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNarr.BackColor = System.Drawing.Color.White;
            this.txtNarr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNarr.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNarr.Location = new System.Drawing.Point(143, 273);
            this.txtNarr.Name = "txtNarr";
            this.txtNarr.Size = new System.Drawing.Size(502, 24);
            this.txtNarr.TabIndex = 216;
            // 
            // chkStatus
            // 
            this.chkStatus.AutoSize = true;
            this.chkStatus.Checked = true;
            this.chkStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStatus.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkStatus.Location = new System.Drawing.Point(144, 194);
            this.chkStatus.Name = "chkStatus";
            this.chkStatus.Size = new System.Drawing.Size(63, 18);
            this.chkStatus.TabIndex = 217;
            this.chkStatus.Text = "Active";
            this.chkStatus.UseVisualStyleBackColor = true;
            this.chkStatus.CheckedChanged += new System.EventHandler(this.chkStatus_CheckedChanged);
            this.chkStatus.Click += new System.EventHandler(this.chkStatus_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.DG);
            this.panel2.Controls.Add(this.txtFTotal);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.DGCC);
            this.panel2.Controls.Add(this.txtCollComit);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.txtVoucherColl);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txttotalAmt);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtCashCollection);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.dateTimePicker1);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.dteToDate);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.dteFDate);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.uctxtTeritorryName);
            this.panel2.Controls.Add(this.uctxtTerritoryCode);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.uctxtVoucherNo);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(158, 381);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(11, 17);
            this.panel2.TabIndex = 218;
            // 
            // DG
            // 
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG.Location = new System.Drawing.Point(47, 67);
            this.DG.Name = "DG";
            this.DG.Size = new System.Drawing.Size(16, 16);
            this.DG.TabIndex = 236;
            // 
            // txtFTotal
            // 
            this.txtFTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFTotal.BackColor = System.Drawing.Color.White;
            this.txtFTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFTotal.Enabled = false;
            this.txtFTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFTotal.Location = new System.Drawing.Point(98, 130);
            this.txtFTotal.Name = "txtFTotal";
            this.txtFTotal.Size = new System.Drawing.Size(0, 24);
            this.txtFTotal.TabIndex = 235;
            this.txtFTotal.Text = "0";
            this.txtFTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(47, 134);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 17);
            this.label13.TabIndex = 234;
            this.label13.Text = "Total :";
            // 
            // DGCC
            // 
            this.DGCC.AllowUserToDeleteRows = false;
            this.DGCC.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DGCC.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGCC.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.DGCC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGCC.EnableHeadersVisualStyles = false;
            this.DGCC.Location = new System.Drawing.Point(341, 42);
            this.DGCC.Name = "DGCC";
            this.DGCC.RowHeadersWidth = 15;
            this.DGCC.Size = new System.Drawing.Size(17, 31);
            this.DGCC.TabIndex = 233;
            // 
            // txtCollComit
            // 
            this.txtCollComit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCollComit.BackColor = System.Drawing.Color.White;
            this.txtCollComit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCollComit.Enabled = false;
            this.txtCollComit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCollComit.Location = new System.Drawing.Point(437, 49);
            this.txtCollComit.Name = "txtCollComit";
            this.txtCollComit.Size = new System.Drawing.Size(0, 24);
            this.txtCollComit.TabIndex = 232;
            this.txtCollComit.Text = "0";
            this.txtCollComit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCollComit.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(401, 49);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 17);
            this.label14.TabIndex = 231;
            this.label14.Text = "Total :";
            this.label14.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(372, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(131, 16);
            this.label12.TabIndex = 230;
            this.label12.Text = "Collection Target";
            // 
            // txtVoucherColl
            // 
            this.txtVoucherColl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVoucherColl.BackColor = System.Drawing.Color.White;
            this.txtVoucherColl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVoucherColl.Enabled = false;
            this.txtVoucherColl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVoucherColl.Location = new System.Drawing.Point(246, 109);
            this.txtVoucherColl.Name = "txtVoucherColl";
            this.txtVoucherColl.Size = new System.Drawing.Size(0, 24);
            this.txtVoucherColl.TabIndex = 229;
            this.txtVoucherColl.Text = "0";
            this.txtVoucherColl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(196, 90);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(126, 17);
            this.label11.TabIndex = 228;
            this.label11.Text = "Voucher Collection";
            // 
            // txttotalAmt
            // 
            this.txttotalAmt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txttotalAmt.BackColor = System.Drawing.Color.White;
            this.txttotalAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttotalAmt.Enabled = false;
            this.txttotalAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttotalAmt.Location = new System.Drawing.Point(246, 153);
            this.txttotalAmt.Name = "txttotalAmt";
            this.txttotalAmt.Size = new System.Drawing.Size(0, 24);
            this.txttotalAmt.TabIndex = 227;
            this.txttotalAmt.Text = "0";
            this.txttotalAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(191, 134);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 17);
            this.label9.TabIndex = 226;
            this.label9.Text = "Total Amount";
            // 
            // txtCashCollection
            // 
            this.txtCashCollection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCashCollection.BackColor = System.Drawing.Color.White;
            this.txtCashCollection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCashCollection.Enabled = false;
            this.txtCashCollection.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCashCollection.Location = new System.Drawing.Point(175, 92);
            this.txtCashCollection.Name = "txtCashCollection";
            this.txtCashCollection.Size = new System.Drawing.Size(0, 24);
            this.txtCashCollection.TabIndex = 225;
            this.txtCashCollection.Text = "0";
            this.txtCashCollection.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(206, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 17);
            this.label10.TabIndex = 224;
            this.label10.Text = "Cash Collection";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(243, 9);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(67, 17);
            this.label19.TabIndex = 223;
            this.label19.Text = "To Date :";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarMonthBackground = System.Drawing.Color.Gainsboro;
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(246, 28);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(77, 22);
            this.dateTimePicker1.TabIndex = 222;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(82, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 17);
            this.label8.TabIndex = 221;
            this.label8.Text = "To Date :";
            // 
            // dteToDate
            // 
            this.dteToDate.CalendarMonthBackground = System.Drawing.Color.Gainsboro;
            this.dteToDate.Enabled = false;
            this.dteToDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteToDate.Location = new System.Drawing.Point(85, 94);
            this.dteToDate.Name = "dteToDate";
            this.dteToDate.Size = new System.Drawing.Size(10, 22);
            this.dteToDate.TabIndex = 220;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(145, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 17);
            this.label5.TabIndex = 219;
            this.label5.Text = "From Date :";
            // 
            // dteFDate
            // 
            this.dteFDate.CalendarMonthBackground = System.Drawing.Color.Gainsboro;
            this.dteFDate.Enabled = false;
            this.dteFDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteFDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteFDate.Location = new System.Drawing.Point(145, 50);
            this.dteFDate.Name = "dteFDate";
            this.dteFDate.Size = new System.Drawing.Size(16, 22);
            this.dteFDate.TabIndex = 218;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(12, 109);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(111, 16);
            this.label18.TabIndex = 217;
            this.label18.Text = "Teritorry Name:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(10, 56);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(108, 16);
            this.label17.TabIndex = 216;
            this.label17.Text = "Teritorry Code:";
            // 
            // uctxtTeritorryName
            // 
            this.uctxtTeritorryName.BackColor = System.Drawing.Color.White;
            this.uctxtTeritorryName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtTeritorryName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtTeritorryName.Location = new System.Drawing.Point(15, 128);
            this.uctxtTeritorryName.Name = "uctxtTeritorryName";
            this.uctxtTeritorryName.ReadOnly = true;
            this.uctxtTeritorryName.Size = new System.Drawing.Size(10, 22);
            this.uctxtTeritorryName.TabIndex = 215;
            // 
            // uctxtTerritoryCode
            // 
            this.uctxtTerritoryCode.BackColor = System.Drawing.Color.White;
            this.uctxtTerritoryCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtTerritoryCode.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtTerritoryCode.Location = new System.Drawing.Point(10, 74);
            this.uctxtTerritoryCode.Name = "uctxtTerritoryCode";
            this.uctxtTerritoryCode.ReadOnly = true;
            this.uctxtTerritoryCode.Size = new System.Drawing.Size(17, 22);
            this.uctxtTerritoryCode.TabIndex = 214;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(109, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 17);
            this.label3.TabIndex = 78;
            this.label3.Text = "Voucher Date :";
            // 
            // dteVoucherDate
            // 
            this.dteVoucherDate.CalendarMonthBackground = System.Drawing.Color.Gainsboro;
            this.dteVoucherDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteVoucherDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteVoucherDate.Location = new System.Drawing.Point(325, 136);
            this.dteVoucherDate.Name = "dteVoucherDate";
            this.dteVoucherDate.Size = new System.Drawing.Size(129, 22);
            this.dteVoucherDate.TabIndex = 77;
            // 
            // uctxtVoucherNo
            // 
            this.uctxtVoucherNo.BackColor = System.Drawing.Color.White;
            this.uctxtVoucherNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtVoucherNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtVoucherNo.Location = new System.Drawing.Point(17, 24);
            this.uctxtVoucherNo.Name = "uctxtVoucherNo";
            this.uctxtVoucherNo.Size = new System.Drawing.Size(10, 23);
            this.uctxtVoucherNo.TabIndex = 74;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 75;
            this.label1.Text = "Voucher No :";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(143, 335);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(506, 23);
            this.progressBar1.TabIndex = 219;
            // 
            // frmCommissionAuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(683, 443);
            this.Controls.Add(this.panel2);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmCommissionAuto";
            this.Load += new System.EventHandler(this.frmCommissionAuto_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.pnlMain, 0);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGMr)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGCC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private MayhediControlLibrary.StandardTextBox uctxtMedicalRep;
        private System.Windows.Forms.Label label4;
        private MayhediControlLibrary.StandardTextBox txtDrCr;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox uctxtBranch;
        private MayhediControlLibrary.StandardDataGridView DGMr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox uctxtMonthID;
        private System.Windows.Forms.TextBox uctxtAmount;
        private System.Windows.Forms.TextBox uctxtOldNo;
        private MayhediControlLibrary.StandardTextBox txtNarr;
        private System.Windows.Forms.CheckBox chkStatus;
        private System.Windows.Forms.Panel panel2;
        private MayhediDataGridView DGCC;
        private MayhediControlLibrary.StandardTextBox txtCollComit;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private MayhediControlLibrary.StandardTextBox txtVoucherColl;
        private System.Windows.Forms.Label label11;
        private MayhediControlLibrary.StandardTextBox txttotalAmt;
        private System.Windows.Forms.Label label9;
        private MayhediControlLibrary.StandardTextBox txtCashCollection;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dteToDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dteFDate;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox uctxtTeritorryName;
        private System.Windows.Forms.TextBox uctxtTerritoryCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dteVoucherDate;
        private System.Windows.Forms.TextBox uctxtVoucherNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private MayhediControlLibrary.StandardTextBox txtFTotal;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView DG;

    }
}
