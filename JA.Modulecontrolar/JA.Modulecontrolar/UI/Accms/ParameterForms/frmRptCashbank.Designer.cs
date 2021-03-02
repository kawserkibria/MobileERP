namespace JA.Modulecontrolar.UI.DReport.Accms.ParameterForms
{
    partial class frmRptCashbank
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
            this.chkRunning = new System.Windows.Forms.CheckBox();
            this.radBankAccounts = new System.Windows.Forms.RadioButton();
            this.radCashInHand = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dteToDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dteFromDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkNarration = new System.Windows.Forms.CheckBox();
            this.radSummary = new System.Windows.Forms.RadioButton();
            this.radDetails = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.uctxtLedgerName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.uctxtBranchName = new System.Windows.Forms.TextBox();
            this.chkSignatory = new System.Windows.Forms.CheckBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(173, 0);
            this.frmLabel.Size = new System.Drawing.Size(164, 33);
            this.frmLabel.Text = "Cash && Bank";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.chkSignatory);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.uctxtBranchName);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.uctxtLedgerName);
            this.pnlMain.Controls.Add(this.groupBox4);
            this.pnlMain.Controls.Add(this.groupBox6);
            this.pnlMain.Controls.Add(this.groupBox2);
            this.pnlMain.Location = new System.Drawing.Point(0, -86);
            this.pnlMain.Size = new System.Drawing.Size(484, 417);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(487, 46);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(123, 333);
            this.btnEdit.Size = new System.Drawing.Size(13, 10);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(64, 337);
            this.btnSave.Size = new System.Drawing.Size(10, 10);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(26, 333);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(7, 333);
            this.btnNew.Size = new System.Drawing.Size(10, 10);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(358, 333);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(221, 333);
            this.btnPrint.Size = new System.Drawing.Size(134, 39);
            this.btnPrint.Text = "Preview";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 373);
            this.groupBox1.Size = new System.Drawing.Size(487, 25);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkRunning);
            this.groupBox2.Controls.Add(this.radBankAccounts);
            this.groupBox2.Controls.Add(this.radCashInHand);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(11, 164);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(307, 105);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selection";
            // 
            // chkRunning
            // 
            this.chkRunning.AutoSize = true;
            this.chkRunning.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkRunning.Location = new System.Drawing.Point(29, 79);
            this.chkRunning.Name = "chkRunning";
            this.chkRunning.Size = new System.Drawing.Size(127, 18);
            this.chkRunning.TabIndex = 7;
            this.chkRunning.Text = "Running Balance";
            this.chkRunning.UseVisualStyleBackColor = true;
            // 
            // radBankAccounts
            // 
            this.radBankAccounts.AutoSize = true;
            this.radBankAccounts.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radBankAccounts.Location = new System.Drawing.Point(28, 54);
            this.radBankAccounts.Name = "radBankAccounts";
            this.radBankAccounts.Size = new System.Drawing.Size(116, 18);
            this.radBankAccounts.TabIndex = 3;
            this.radBankAccounts.Text = "Bank Accounts";
            this.radBankAccounts.UseVisualStyleBackColor = true;
            this.radBankAccounts.CheckedChanged += new System.EventHandler(this.radIndividual_CheckedChanged);
            this.radBankAccounts.Click += new System.EventHandler(this.radBankAccounts_Click);
            // 
            // radCashInHand
            // 
            this.radCashInHand.AutoSize = true;
            this.radCashInHand.Checked = true;
            this.radCashInHand.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radCashInHand.Location = new System.Drawing.Point(28, 27);
            this.radCashInHand.Name = "radCashInHand";
            this.radCashInHand.Size = new System.Drawing.Size(111, 18);
            this.radCashInHand.TabIndex = 2;
            this.radCashInHand.TabStop = true;
            this.radCashInHand.Text = "Cash In Hand";
            this.radCashInHand.UseVisualStyleBackColor = true;
            this.radCashInHand.Click += new System.EventHandler(this.radCashInHand_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.dteToDate);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.dteFromDate);
            this.groupBox6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(6, 311);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(229, 97);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Period Seletion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(37, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "To:";
            // 
            // dteToDate
            // 
            this.dteToDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteToDate.Location = new System.Drawing.Point(87, 66);
            this.dteToDate.Name = "dteToDate";
            this.dteToDate.Size = new System.Drawing.Size(124, 22);
            this.dteToDate.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(16, 35);
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
            this.dteFromDate.Location = new System.Drawing.Point(88, 29);
            this.dteFromDate.Name = "dteFromDate";
            this.dteFromDate.Size = new System.Drawing.Size(124, 22);
            this.dteFromDate.TabIndex = 20;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkNarration);
            this.groupBox4.Controls.Add(this.radSummary);
            this.groupBox4.Controls.Add(this.radDetails);
            this.groupBox4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(317, 164);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(148, 103);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Seletion";
            // 
            // chkNarration
            // 
            this.chkNarration.AutoSize = true;
            this.chkNarration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkNarration.Location = new System.Drawing.Point(27, 55);
            this.chkNarration.Name = "chkNarration";
            this.chkNarration.Size = new System.Drawing.Size(82, 18);
            this.chkNarration.TabIndex = 6;
            this.chkNarration.Text = "Narration";
            this.chkNarration.UseVisualStyleBackColor = true;
            // 
            // radSummary
            // 
            this.radSummary.AutoSize = true;
            this.radSummary.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSummary.Location = new System.Drawing.Point(12, 74);
            this.radSummary.Name = "radSummary";
            this.radSummary.Size = new System.Drawing.Size(83, 18);
            this.radSummary.TabIndex = 5;
            this.radSummary.Text = "Summary";
            this.radSummary.UseVisualStyleBackColor = true;
            // 
            // radDetails
            // 
            this.radDetails.AutoSize = true;
            this.radDetails.Checked = true;
            this.radDetails.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radDetails.Location = new System.Drawing.Point(10, 35);
            this.radDetails.Name = "radDetails";
            this.radDetails.Size = new System.Drawing.Size(68, 18);
            this.radDetails.TabIndex = 3;
            this.radDetails.TabStop = true;
            this.radDetails.Text = "Details";
            this.radDetails.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(52, 285);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 14);
            this.label3.TabIndex = 15;
            this.label3.Text = "Name:";
            // 
            // uctxtLedgerName
            // 
            this.uctxtLedgerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtLedgerName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtLedgerName.Location = new System.Drawing.Point(106, 282);
            this.uctxtLedgerName.Name = "uctxtLedgerName";
            this.uctxtLedgerName.Size = new System.Drawing.Size(320, 23);
            this.uctxtLedgerName.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 14);
            this.label4.TabIndex = 17;
            this.label4.Text = "Branch Name:";
            // 
            // uctxtBranchName
            // 
            this.uctxtBranchName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtBranchName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtBranchName.Location = new System.Drawing.Point(106, 136);
            this.uctxtBranchName.Name = "uctxtBranchName";
            this.uctxtBranchName.Size = new System.Drawing.Size(320, 23);
            this.uctxtBranchName.TabIndex = 16;
            // 
            // chkSignatory
            // 
            this.chkSignatory.AutoSize = true;
            this.chkSignatory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSignatory.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSignatory.Location = new System.Drawing.Point(277, 346);
            this.chkSignatory.Name = "chkSignatory";
            this.chkSignatory.Size = new System.Drawing.Size(188, 18);
            this.chkSignatory.TabIndex = 18;
            this.chkSignatory.Text = "Checked by/Authorized by";
            this.chkSignatory.UseVisualStyleBackColor = true;
            // 
            // frmRptCashbank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(487, 398);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmRptCashbank";
            this.Load += new System.EventHandler(this.frmRptStoreLedger_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radBankAccounts;
        private System.Windows.Forms.RadioButton radCashInHand;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dteToDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dteFromDate;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkNarration;
        private System.Windows.Forms.RadioButton radSummary;
        private System.Windows.Forms.RadioButton radDetails;
        private System.Windows.Forms.CheckBox chkRunning;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uctxtLedgerName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox uctxtBranchName;
        private System.Windows.Forms.CheckBox chkSignatory;
    }
}
