namespace JA.Modulecontrolar.UI.DReport.Accms.ParameterForms
{
    partial class frmRptAccountsLedger
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radMonthlySummary = new System.Windows.Forms.RadioButton();
            this.radsummary = new System.Windows.Forms.RadioButton();
            this.radDetails = new System.Windows.Forms.RadioButton();
            this.uctxtLedgerName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkChequeNo = new System.Windows.Forms.CheckBox();
            this.chkNarration = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.uctxtTerritoryCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.uctxtTeritorryName = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.chkSignatory = new System.Windows.Forms.CheckBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.chkboxVoucherW = new System.Windows.Forms.CheckBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(172, 9);
            this.frmLabel.Size = new System.Drawing.Size(184, 33);
            this.frmLabel.Text = "Ledger Report";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.chkboxVoucherW);
            this.pnlMain.Controls.Add(this.chkActive);
            this.pnlMain.Controls.Add(this.chkSignatory);
            this.pnlMain.Controls.Add(this.textBox1);
            this.pnlMain.Controls.Add(this.label6);
            this.pnlMain.Controls.Add(this.uctxtTeritorryName);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.uctxtTerritoryCode);
            this.pnlMain.Controls.Add(this.chkNarration);
            this.pnlMain.Controls.Add(this.chkChequeNo);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.uctxtLedgerName);
            this.pnlMain.Controls.Add(this.groupBox2);
            this.pnlMain.Controls.Add(this.groupBox6);
            this.pnlMain.Location = new System.Drawing.Point(0, -86);
            this.pnlMain.Size = new System.Drawing.Size(562, 387);
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(562, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(179, 303);
            this.btnEdit.Size = new System.Drawing.Size(17, 21);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(55, 308);
            this.btnSave.Size = new System.Drawing.Size(10, 17);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(109, 303);
            this.btnDelete.Size = new System.Drawing.Size(10, 21);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(6, 308);
            this.btnNew.Size = new System.Drawing.Size(10, 16);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(452, 304);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(319, 304);
            this.btnPrint.Size = new System.Drawing.Size(130, 39);
            this.btnPrint.Text = "Preview";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 348);
            this.groupBox1.Size = new System.Drawing.Size(562, 25);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.dteToDate);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.dteFromDate);
            this.groupBox6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(11, 245);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(226, 110);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Period Seletion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(40, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "To:";
            // 
            // dteToDate
            // 
            this.dteToDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteToDate.Location = new System.Drawing.Point(81, 68);
            this.dteToDate.Name = "dteToDate";
            this.dteToDate.Size = new System.Drawing.Size(123, 22);
            this.dteToDate.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(19, 35);
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
            this.dteFromDate.Location = new System.Drawing.Point(81, 31);
            this.dteFromDate.Name = "dteFromDate";
            this.dteFromDate.Size = new System.Drawing.Size(123, 22);
            this.dteFromDate.TabIndex = 20;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radMonthlySummary);
            this.groupBox2.Controls.Add(this.radsummary);
            this.groupBox2.Controls.Add(this.radDetails);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(353, 243);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 110);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selection";
            // 
            // radMonthlySummary
            // 
            this.radMonthlySummary.AutoSize = true;
            this.radMonthlySummary.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radMonthlySummary.Location = new System.Drawing.Point(29, 87);
            this.radMonthlySummary.Name = "radMonthlySummary";
            this.radMonthlySummary.Size = new System.Drawing.Size(136, 18);
            this.radMonthlySummary.TabIndex = 4;
            this.radMonthlySummary.Text = "Monthly Summary";
            this.radMonthlySummary.UseVisualStyleBackColor = true;
            this.radMonthlySummary.Click += new System.EventHandler(this.radMonthlySummary_Click);
            // 
            // radsummary
            // 
            this.radsummary.AutoSize = true;
            this.radsummary.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radsummary.Location = new System.Drawing.Point(28, 61);
            this.radsummary.Name = "radsummary";
            this.radsummary.Size = new System.Drawing.Size(83, 18);
            this.radsummary.TabIndex = 3;
            this.radsummary.Text = "Summary";
            this.radsummary.UseVisualStyleBackColor = true;
            this.radsummary.Click += new System.EventHandler(this.radsummary_Click);
            // 
            // radDetails
            // 
            this.radDetails.AutoSize = true;
            this.radDetails.Checked = true;
            this.radDetails.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radDetails.Location = new System.Drawing.Point(28, 34);
            this.radDetails.Name = "radDetails";
            this.radDetails.Size = new System.Drawing.Size(68, 18);
            this.radDetails.TabIndex = 2;
            this.radDetails.TabStop = true;
            this.radDetails.Text = "Details";
            this.radDetails.UseVisualStyleBackColor = true;
            this.radDetails.Click += new System.EventHandler(this.radDetails_Click);
            // 
            // uctxtLedgerName
            // 
            this.uctxtLedgerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtLedgerName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtLedgerName.Location = new System.Drawing.Point(122, 156);
            this.uctxtLedgerName.Name = "uctxtLedgerName";
            this.uctxtLedgerName.Size = new System.Drawing.Size(427, 23);
            this.uctxtLedgerName.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(67, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "Name:";
            // 
            // chkChequeNo
            // 
            this.chkChequeNo.AutoSize = true;
            this.chkChequeNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkChequeNo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkChequeNo.Location = new System.Drawing.Point(195, 359);
            this.chkChequeNo.Name = "chkChequeNo";
            this.chkChequeNo.Size = new System.Drawing.Size(126, 18);
            this.chkChequeNo.TabIndex = 9;
            this.chkChequeNo.Text = "With Cheque No";
            this.chkChequeNo.UseVisualStyleBackColor = true;
            this.chkChequeNo.Visible = false;
            // 
            // chkNarration
            // 
            this.chkNarration.AutoSize = true;
            this.chkNarration.Checked = true;
            this.chkNarration.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNarration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkNarration.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNarration.Location = new System.Drawing.Point(93, 360);
            this.chkNarration.Name = "chkNarration";
            this.chkNarration.Size = new System.Drawing.Size(82, 18);
            this.chkNarration.TabIndex = 10;
            this.chkNarration.Text = "Narration";
            this.chkNarration.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(350, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 14);
            this.label4.TabIndex = 12;
            this.label4.Text = "Teritorry Code:";
            this.label4.Visible = false;
            // 
            // uctxtTerritoryCode
            // 
            this.uctxtTerritoryCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtTerritoryCode.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtTerritoryCode.Location = new System.Drawing.Point(63, 180);
            this.uctxtTerritoryCode.Name = "uctxtTerritoryCode";
            this.uctxtTerritoryCode.ReadOnly = true;
            this.uctxtTerritoryCode.Size = new System.Drawing.Size(10, 23);
            this.uctxtTerritoryCode.TabIndex = 11;
            this.uctxtTerritoryCode.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(379, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 14);
            this.label6.TabIndex = 14;
            this.label6.Text = "Teritorry Name:";
            this.label6.Visible = false;
            // 
            // uctxtTeritorryName
            // 
            this.uctxtTeritorryName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtTeritorryName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtTeritorryName.Location = new System.Drawing.Point(45, 185);
            this.uctxtTeritorryName.Name = "uctxtTeritorryName";
            this.uctxtTeritorryName.ReadOnly = true;
            this.uctxtTeritorryName.Size = new System.Drawing.Size(10, 23);
            this.uctxtTeritorryName.TabIndex = 13;
            this.uctxtTeritorryName.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(471, 185);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(60, 23);
            this.textBox1.TabIndex = 15;
            this.textBox1.Visible = false;
            // 
            // chkSignatory
            // 
            this.chkSignatory.AutoSize = true;
            this.chkSignatory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSignatory.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSignatory.Location = new System.Drawing.Point(332, 359);
            this.chkSignatory.Name = "chkSignatory";
            this.chkSignatory.Size = new System.Drawing.Size(188, 18);
            this.chkSignatory.TabIndex = 16;
            this.chkSignatory.Text = "Checked by/Authorized by";
            this.chkSignatory.UseVisualStyleBackColor = true;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkActive.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActive.Location = new System.Drawing.Point(11, 188);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(70, 20);
            this.chkActive.TabIndex = 17;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            this.chkActive.Click += new System.EventHandler(this.chkActive_Click);
            // 
            // chkboxVoucherW
            // 
            this.chkboxVoucherW.AutoSize = true;
            this.chkboxVoucherW.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkboxVoucherW.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkboxVoucherW.Location = new System.Drawing.Point(124, 189);
            this.chkboxVoucherW.Name = "chkboxVoucherW";
            this.chkboxVoucherW.Size = new System.Drawing.Size(162, 20);
            this.chkboxVoucherW.TabIndex = 19;
            this.chkboxVoucherW.Text = "Voucher Type Wise";
            this.chkboxVoucherW.UseVisualStyleBackColor = true;
            // 
            // frmRptAccountsLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(562, 373);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmRptAccountsLedger";
            this.Load += new System.EventHandler(this.frmRptAccountsLedger_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dteToDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dteFromDate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radsummary;
        private System.Windows.Forms.RadioButton radDetails;
        private System.Windows.Forms.RadioButton radMonthlySummary;
        private System.Windows.Forms.CheckBox chkNarration;
        private System.Windows.Forms.CheckBox chkChequeNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uctxtLedgerName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox uctxtTeritorryName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox uctxtTerritoryCode;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox chkSignatory;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.CheckBox chkboxVoucherW;
    }
}
