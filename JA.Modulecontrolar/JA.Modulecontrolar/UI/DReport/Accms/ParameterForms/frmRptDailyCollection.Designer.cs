namespace JA.Modulecontrolar.UI.DReport.Accms.ParameterForms
{
    partial class frmRptDailyCollection
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dteToDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dteFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblBranchname = new System.Windows.Forms.Label();
            this.uctxtBranchName = new System.Windows.Forms.TextBox();
            this.frmSelection = new System.Windows.Forms.GroupBox();
            this.chkStatus = new System.Windows.Forms.CheckBox();
            this.radIndividual = new System.Windows.Forms.RadioButton();
            this.radAll = new System.Windows.Forms.RadioButton();
            this.lblIndividualVoucher = new System.Windows.Forms.Label();
            this.uctxtLedgerConfig = new System.Windows.Forms.TextBox();
            this.DGMr = new MayhediControlLibrary.StandardDataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uctxtTeritorryName = new System.Windows.Forms.TextBox();
            this.uctxtTerritoryCode = new System.Windows.Forms.TextBox();
            this.cboxOnlyAccounts = new System.Windows.Forms.CheckBox();
            this.chkBkash = new System.Windows.Forms.CheckBox();
            this.chkboxcommition = new System.Windows.Forms.CheckBox();
            this.txtCommition = new MayhediControlLibrary.StandardNumericTextBox();
            this.chkbDailyCollection = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.frmSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGMr)).BeginInit();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(173, 9);
            this.frmLabel.Size = new System.Drawing.Size(0, 33);
            this.frmLabel.Text = "";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.progressBar1);
            this.pnlMain.Controls.Add(this.chkbDailyCollection);
            this.pnlMain.Controls.Add(this.txtCommition);
            this.pnlMain.Controls.Add(this.chkboxcommition);
            this.pnlMain.Controls.Add(this.chkBkash);
            this.pnlMain.Controls.Add(this.cboxOnlyAccounts);
            this.pnlMain.Controls.Add(this.uctxtTeritorryName);
            this.pnlMain.Controls.Add(this.uctxtTerritoryCode);
            this.pnlMain.Controls.Add(this.DGMr);
            this.pnlMain.Controls.Add(this.lblIndividualVoucher);
            this.pnlMain.Controls.Add(this.uctxtLedgerConfig);
            this.pnlMain.Controls.Add(this.frmSelection);
            this.pnlMain.Controls.Add(this.lblBranchname);
            this.pnlMain.Controls.Add(this.uctxtBranchName);
            this.pnlMain.Controls.Add(this.groupBox6);
            this.pnlMain.Location = new System.Drawing.Point(0, -84);
            this.pnlMain.Size = new System.Drawing.Size(534, 450);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(538, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(56, 378);
            this.btnEdit.Size = new System.Drawing.Size(15, 20);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(56, 371);
            this.btnSave.Size = new System.Drawing.Size(10, 23);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(102, 381);
            this.btnDelete.Size = new System.Drawing.Size(10, 17);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(9, 381);
            this.btnNew.Size = new System.Drawing.Size(32, 17);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(417, 370);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(283, 370);
            this.btnPrint.Size = new System.Drawing.Size(131, 39);
            this.btnPrint.Text = "Preview";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 418);
            this.groupBox1.Size = new System.Drawing.Size(538, 25);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.dteToDate);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.dteFromDate);
            this.groupBox6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(282, 341);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(228, 88);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Period Seletion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(27, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "To:";
            // 
            // dteToDate
            // 
            this.dteToDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteToDate.Location = new System.Drawing.Point(67, 54);
            this.dteToDate.Name = "dteToDate";
            this.dteToDate.Size = new System.Drawing.Size(124, 22);
            this.dteToDate.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(6, 29);
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
            this.dteFromDate.Location = new System.Drawing.Point(67, 28);
            this.dteFromDate.Name = "dteFromDate";
            this.dteFromDate.Size = new System.Drawing.Size(124, 22);
            this.dteFromDate.TabIndex = 1;
            // 
            // lblBranchname
            // 
            this.lblBranchname.AutoSize = true;
            this.lblBranchname.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBranchname.Location = new System.Drawing.Point(37, 159);
            this.lblBranchname.Name = "lblBranchname";
            this.lblBranchname.Size = new System.Drawing.Size(95, 14);
            this.lblBranchname.TabIndex = 19;
            this.lblBranchname.Text = "Branch Name:";
            // 
            // uctxtBranchName
            // 
            this.uctxtBranchName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtBranchName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtBranchName.Location = new System.Drawing.Point(138, 155);
            this.uctxtBranchName.Name = "uctxtBranchName";
            this.uctxtBranchName.Size = new System.Drawing.Size(372, 22);
            this.uctxtBranchName.TabIndex = 0;
            // 
            // frmSelection
            // 
            this.frmSelection.Controls.Add(this.chkStatus);
            this.frmSelection.Controls.Add(this.radIndividual);
            this.frmSelection.Controls.Add(this.radAll);
            this.frmSelection.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmSelection.Location = new System.Drawing.Point(5, 311);
            this.frmSelection.Name = "frmSelection";
            this.frmSelection.Size = new System.Drawing.Size(132, 129);
            this.frmSelection.TabIndex = 17;
            this.frmSelection.TabStop = false;
            this.frmSelection.Text = "Seletion";
            this.frmSelection.Visible = false;
            // 
            // chkStatus
            // 
            this.chkStatus.AutoSize = true;
            this.chkStatus.Enabled = false;
            this.chkStatus.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkStatus.Location = new System.Drawing.Point(25, 101);
            this.chkStatus.Name = "chkStatus";
            this.chkStatus.Size = new System.Drawing.Size(76, 18);
            this.chkStatus.TabIndex = 16;
            this.chkStatus.Text = "Inactive";
            this.chkStatus.UseVisualStyleBackColor = true;
            this.chkStatus.Click += new System.EventHandler(this.chkStatus_Click);
            // 
            // radIndividual
            // 
            this.radIndividual.AutoSize = true;
            this.radIndividual.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radIndividual.Location = new System.Drawing.Point(6, 69);
            this.radIndividual.Name = "radIndividual";
            this.radIndividual.Size = new System.Drawing.Size(118, 18);
            this.radIndividual.TabIndex = 5;
            this.radIndividual.Text = "Individual MPO";
            this.radIndividual.UseVisualStyleBackColor = true;
            this.radIndividual.CheckedChanged += new System.EventHandler(this.radIndividual_CheckedChanged);
            this.radIndividual.Click += new System.EventHandler(this.radIndividual_Click);
            // 
            // radAll
            // 
            this.radAll.AutoSize = true;
            this.radAll.Checked = true;
            this.radAll.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAll.Location = new System.Drawing.Point(8, 33);
            this.radAll.Name = "radAll";
            this.radAll.Size = new System.Drawing.Size(71, 18);
            this.radAll.TabIndex = 3;
            this.radAll.TabStop = true;
            this.radAll.Text = "All MPO";
            this.radAll.UseVisualStyleBackColor = true;
            this.radAll.Click += new System.EventHandler(this.radAll_Click_1);
            // 
            // lblIndividualVoucher
            // 
            this.lblIndividualVoucher.AutoSize = true;
            this.lblIndividualVoucher.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndividualVoucher.Location = new System.Drawing.Point(11, 220);
            this.lblIndividualVoucher.Name = "lblIndividualVoucher";
            this.lblIndividualVoucher.Size = new System.Drawing.Size(75, 14);
            this.lblIndividualVoucher.TabIndex = 21;
            this.lblIndividualVoucher.Text = "MPO Name";
            this.lblIndividualVoucher.Visible = false;
            // 
            // uctxtLedgerConfig
            // 
            this.uctxtLedgerConfig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtLedgerConfig.Enabled = false;
            this.uctxtLedgerConfig.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtLedgerConfig.Location = new System.Drawing.Point(11, 237);
            this.uctxtLedgerConfig.Name = "uctxtLedgerConfig";
            this.uctxtLedgerConfig.Size = new System.Drawing.Size(513, 22);
            this.uctxtLedgerConfig.TabIndex = 20;
            this.uctxtLedgerConfig.Visible = false;
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
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGMr.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DGMr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGMr.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGMr.DefaultCellStyle = dataGridViewCellStyle11;
            this.DGMr.Location = new System.Drawing.Point(11, 264);
            this.DGMr.MultiSelect = false;
            this.DGMr.Name = "DGMr";
            this.DGMr.RowHeadersVisible = false;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            this.DGMr.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.DGMr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGMr.Size = new System.Drawing.Size(511, 23);
            this.DGMr.TabIndex = 210;
            this.DGMr.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn6.HeaderText = "Teritorry Code";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn13.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn13.HeaderText = "Teritorry name";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 130;
            // 
            // dataGridViewTextBoxColumn14
            // 
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn14.DefaultCellStyle = dataGridViewCellStyle10;
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
            // uctxtTeritorryName
            // 
            this.uctxtTeritorryName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtTeritorryName.Location = new System.Drawing.Point(282, 293);
            this.uctxtTeritorryName.Name = "uctxtTeritorryName";
            this.uctxtTeritorryName.Size = new System.Drawing.Size(94, 22);
            this.uctxtTeritorryName.TabIndex = 212;
            this.uctxtTeritorryName.Visible = false;
            // 
            // uctxtTerritoryCode
            // 
            this.uctxtTerritoryCode.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtTerritoryCode.Location = new System.Drawing.Point(163, 293);
            this.uctxtTerritoryCode.Name = "uctxtTerritoryCode";
            this.uctxtTerritoryCode.Size = new System.Drawing.Size(110, 22);
            this.uctxtTerritoryCode.TabIndex = 211;
            this.uctxtTerritoryCode.Visible = false;
            // 
            // cboxOnlyAccounts
            // 
            this.cboxOnlyAccounts.AutoSize = true;
            this.cboxOnlyAccounts.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxOnlyAccounts.Location = new System.Drawing.Point(11, 195);
            this.cboxOnlyAccounts.Name = "cboxOnlyAccounts";
            this.cboxOnlyAccounts.Size = new System.Drawing.Size(85, 18);
            this.cboxOnlyAccounts.TabIndex = 213;
            this.cboxOnlyAccounts.Text = "Suppress";
            this.cboxOnlyAccounts.UseVisualStyleBackColor = true;
            // 
            // chkBkash
            // 
            this.chkBkash.AutoSize = true;
            this.chkBkash.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBkash.Location = new System.Drawing.Point(332, 192);
            this.chkBkash.Name = "chkBkash";
            this.chkBkash.Size = new System.Drawing.Size(178, 18);
            this.chkBkash.TabIndex = 214;
            this.chkBkash.Text = "As Per Bkash Statement";
            this.chkBkash.UseVisualStyleBackColor = true;
            this.chkBkash.Visible = false;
            // 
            // chkboxcommition
            // 
            this.chkboxcommition.AutoSize = true;
            this.chkboxcommition.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkboxcommition.Location = new System.Drawing.Point(112, 195);
            this.chkboxcommition.Name = "chkboxcommition";
            this.chkboxcommition.Size = new System.Drawing.Size(98, 18);
            this.chkboxcommition.TabIndex = 215;
            this.chkboxcommition.Text = "Percentage";
            this.chkboxcommition.UseVisualStyleBackColor = true;
            // 
            // txtCommition
            // 
            this.txtCommition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCommition.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommition.Location = new System.Drawing.Point(209, 192);
            this.txtCommition.Name = "txtCommition";
            this.txtCommition.Size = new System.Drawing.Size(64, 24);
            this.txtCommition.TabIndex = 217;
            // 
            // chkbDailyCollection
            // 
            this.chkbDailyCollection.AutoSize = true;
            this.chkbDailyCollection.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbDailyCollection.Location = new System.Drawing.Point(332, 213);
            this.chkbDailyCollection.Name = "chkbDailyCollection";
            this.chkbDailyCollection.Size = new System.Drawing.Size(121, 18);
            this.chkbDailyCollection.TabIndex = 219;
            this.chkbDailyCollection.Text = "Daily Collection";
            this.chkbDailyCollection.UseVisualStyleBackColor = true;
            this.chkbDailyCollection.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(144, 416);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(132, 23);
            this.progressBar1.TabIndex = 220;
            this.progressBar1.Visible = false;
            // 
            // frmRptDailyCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(538, 443);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmRptDailyCollection";
            this.Load += new System.EventHandler(this.frmRptStoreLedger_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.frmSelection.ResumeLayout(false);
            this.frmSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGMr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dteToDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dteFromDate;
        private System.Windows.Forms.Label lblBranchname;
        private System.Windows.Forms.TextBox uctxtBranchName;
        private System.Windows.Forms.GroupBox frmSelection;
        private System.Windows.Forms.RadioButton radIndividual;
        private System.Windows.Forms.RadioButton radAll;
        private System.Windows.Forms.Label lblIndividualVoucher;
        private System.Windows.Forms.TextBox uctxtLedgerConfig;
        private MayhediControlLibrary.StandardDataGridView DGMr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.TextBox uctxtTeritorryName;
        private System.Windows.Forms.TextBox uctxtTerritoryCode;
        private System.Windows.Forms.CheckBox chkStatus;
        private System.Windows.Forms.CheckBox cboxOnlyAccounts;
        private System.Windows.Forms.CheckBox chkBkash;
        private System.Windows.Forms.CheckBox chkboxcommition;
        private MayhediControlLibrary.StandardNumericTextBox txtCommition;
        private System.Windows.Forms.CheckBox chkbDailyCollection;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
