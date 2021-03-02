﻿namespace JA.Modulecontrolar.UI.DReport.Accms.ParameterForms
{
    partial class frmRptAccountsVoucher
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
            this.radSp = new System.Windows.Forms.RadioButton();
            this.radContra = new System.Windows.Forms.RadioButton();
            this.radReceipt = new System.Windows.Forms.RadioButton();
            this.radJournal = new System.Windows.Forms.RadioButton();
            this.radPayment = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radIndividual = new System.Windows.Forms.RadioButton();
            this.radAll = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkNarration = new System.Windows.Forms.CheckBox();
            this.radSummary = new System.Windows.Forms.RadioButton();
            this.radDetails = new System.Windows.Forms.RadioButton();
            this.lblBranchname = new System.Windows.Forms.Label();
            this.uctxtVoucherNo = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmLabel.Location = new System.Drawing.Point(173, 13);
            this.frmLabel.Size = new System.Drawing.Size(126, 19);
            this.frmLabel.Text = "Voucher Reports";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.textBox1);
            this.pnlMain.Controls.Add(this.lblBranchname);
            this.pnlMain.Controls.Add(this.uctxtVoucherNo);
            this.pnlMain.Controls.Add(this.groupBox4);
            this.pnlMain.Controls.Add(this.groupBox3);
            this.pnlMain.Controls.Add(this.groupBox2);
            this.pnlMain.Controls.Add(this.groupBox6);
            this.pnlMain.Location = new System.Drawing.Point(0, -86);
            this.pnlMain.Size = new System.Drawing.Size(484, 453);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(487, 48);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(165, 347);
            this.btnEdit.Size = new System.Drawing.Size(12, 15);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(51, 346);
            this.btnSave.Size = new System.Drawing.Size(10, 12);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(95, 346);
            this.btnDelete.Size = new System.Drawing.Size(10, 13);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(13, 345);
            this.btnNew.Size = new System.Drawing.Size(10, 12);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(366, 369);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(234, 369);
            this.btnPrint.Size = new System.Drawing.Size(129, 39);
            this.btnPrint.Text = "Preview";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 413);
            this.groupBox1.Size = new System.Drawing.Size(487, 25);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.dteToDate);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.dteFromDate);
            this.groupBox6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(11, 209);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(219, 106);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Period Seletion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(32, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "To:";
            // 
            // dteToDate
            // 
            this.dteToDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteToDate.Location = new System.Drawing.Point(83, 67);
            this.dteToDate.Name = "dteToDate";
            this.dteToDate.Size = new System.Drawing.Size(120, 22);
            this.dteToDate.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(11, 36);
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
            this.dteFromDate.Location = new System.Drawing.Point(83, 30);
            this.dteFromDate.Name = "dteFromDate";
            this.dteFromDate.Size = new System.Drawing.Size(120, 22);
            this.dteFromDate.TabIndex = 20;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radSp);
            this.groupBox2.Controls.Add(this.radContra);
            this.groupBox2.Controls.Add(this.radReceipt);
            this.groupBox2.Controls.Add(this.radJournal);
            this.groupBox2.Controls.Add(this.radPayment);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(11, 140);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(461, 66);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selection";
            // 
            // radSp
            // 
            this.radSp.AutoSize = true;
            this.radSp.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSp.Location = new System.Drawing.Point(313, 30);
            this.radSp.Name = "radSp";
            this.radSp.Size = new System.Drawing.Size(143, 18);
            this.radSp.TabIndex = 6;
            this.radSp.Text = "MPO Commmission";
            this.radSp.UseVisualStyleBackColor = true;
            this.radSp.Click += new System.EventHandler(this.radSp_Click);
            // 
            // radContra
            // 
            this.radContra.AutoSize = true;
            this.radContra.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radContra.Location = new System.Drawing.Point(242, 30);
            this.radContra.Name = "radContra";
            this.radContra.Size = new System.Drawing.Size(68, 18);
            this.radContra.TabIndex = 5;
            this.radContra.Text = "Contra";
            this.radContra.UseVisualStyleBackColor = true;
            this.radContra.Click += new System.EventHandler(this.radContra_Click);
            // 
            // radReceipt
            // 
            this.radReceipt.AutoSize = true;
            this.radReceipt.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radReceipt.Location = new System.Drawing.Point(94, 30);
            this.radReceipt.Name = "radReceipt";
            this.radReceipt.Size = new System.Drawing.Size(71, 18);
            this.radReceipt.TabIndex = 4;
            this.radReceipt.Text = "Receipt";
            this.radReceipt.UseVisualStyleBackColor = true;
            this.radReceipt.Click += new System.EventHandler(this.radReceipt_Click);
            // 
            // radJournal
            // 
            this.radJournal.AutoSize = true;
            this.radJournal.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radJournal.Location = new System.Drawing.Point(168, 30);
            this.radJournal.Name = "radJournal";
            this.radJournal.Size = new System.Drawing.Size(70, 18);
            this.radJournal.TabIndex = 3;
            this.radJournal.Text = "Journal";
            this.radJournal.UseVisualStyleBackColor = true;
            this.radJournal.Click += new System.EventHandler(this.radJournal_Click);
            // 
            // radPayment
            // 
            this.radPayment.AutoSize = true;
            this.radPayment.Checked = true;
            this.radPayment.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPayment.Location = new System.Drawing.Point(11, 30);
            this.radPayment.Name = "radPayment";
            this.radPayment.Size = new System.Drawing.Size(80, 18);
            this.radPayment.TabIndex = 2;
            this.radPayment.TabStop = true;
            this.radPayment.Text = "Payment";
            this.radPayment.UseVisualStyleBackColor = true;
            this.radPayment.Click += new System.EventHandler(this.radPayment_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radIndividual);
            this.groupBox3.Controls.Add(this.radAll);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(233, 209);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(118, 105);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Seletion";
            // 
            // radIndividual
            // 
            this.radIndividual.AutoSize = true;
            this.radIndividual.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radIndividual.Location = new System.Drawing.Point(12, 72);
            this.radIndividual.Name = "radIndividual";
            this.radIndividual.Size = new System.Drawing.Size(86, 18);
            this.radIndividual.TabIndex = 5;
            this.radIndividual.Text = "Individual";
            this.radIndividual.UseVisualStyleBackColor = true;
            this.radIndividual.Click += new System.EventHandler(this.radIndividual_Click);
            // 
            // radAll
            // 
            this.radAll.AutoSize = true;
            this.radAll.Checked = true;
            this.radAll.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAll.Location = new System.Drawing.Point(10, 36);
            this.radAll.Name = "radAll";
            this.radAll.Size = new System.Drawing.Size(39, 18);
            this.radAll.TabIndex = 3;
            this.radAll.TabStop = true;
            this.radAll.Text = "All";
            this.radAll.UseVisualStyleBackColor = true;
            this.radAll.Click += new System.EventHandler(this.radAll_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkNarration);
            this.groupBox4.Controls.Add(this.radSummary);
            this.groupBox4.Controls.Add(this.radDetails);
            this.groupBox4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(354, 209);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(118, 105);
            this.groupBox4.TabIndex = 8;
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
            this.radSummary.Click += new System.EventHandler(this.radSummary_Click);
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
            this.radDetails.Click += new System.EventHandler(this.radDetails_Click);
            // 
            // lblBranchname
            // 
            this.lblBranchname.AutoSize = true;
            this.lblBranchname.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBranchname.Location = new System.Drawing.Point(48, 322);
            this.lblBranchname.Name = "lblBranchname";
            this.lblBranchname.Size = new System.Drawing.Size(83, 14);
            this.lblBranchname.TabIndex = 21;
            this.lblBranchname.Text = "Voucher No:";
            // 
            // uctxtVoucherNo
            // 
            this.uctxtVoucherNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtVoucherNo.Enabled = false;
            this.uctxtVoucherNo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtVoucherNo.Location = new System.Drawing.Point(138, 318);
            this.uctxtVoucherNo.Name = "uctxtVoucherNo";
            this.uctxtVoucherNo.Size = new System.Drawing.Size(292, 22);
            this.uctxtVoucherNo.TabIndex = 20;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(15, 373);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(116, 22);
            this.textBox1.TabIndex = 22;
            this.textBox1.Visible = false;
            // 
            // frmRptAccountsVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(487, 438);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmRptAccountsVoucher";
            this.Load += new System.EventHandler(this.frmRptStoreLedger_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dteToDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dteFromDate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radJournal;
        private System.Windows.Forms.RadioButton radPayment;
        private System.Windows.Forms.RadioButton radContra;
        private System.Windows.Forms.RadioButton radReceipt;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkNarration;
        private System.Windows.Forms.RadioButton radSummary;
        private System.Windows.Forms.RadioButton radDetails;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radIndividual;
        private System.Windows.Forms.RadioButton radAll;
        private System.Windows.Forms.Label lblBranchname;
        private System.Windows.Forms.TextBox uctxtVoucherNo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton radSp;
    }
}
