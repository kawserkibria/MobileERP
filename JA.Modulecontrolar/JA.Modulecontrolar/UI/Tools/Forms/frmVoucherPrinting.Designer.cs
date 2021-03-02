namespace JA.Modulecontrolar.UI.Tools.Forms
{
    partial class frmVoucherPrinting
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
            this.radAccounts = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radContraVoucher = new System.Windows.Forms.RadioButton();
            this.radJournalVoucher = new System.Windows.Forms.RadioButton();
            this.radReceiptVoucher = new System.Windows.Forms.RadioButton();
            this.radPaymentVoucher = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtVoucherH5 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtVoucherH1 = new System.Windows.Forms.TextBox();
            this.txtVoucherH2 = new System.Windows.Forms.TextBox();
            this.txtVoucherH3 = new System.Windows.Forms.TextBox();
            this.txtVoucherH4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboxPaperSize = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(173, 9);
            this.frmLabel.Size = new System.Drawing.Size(211, 33);
            this.frmLabel.Text = "Voucher Printing";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.cboxPaperSize);
            this.pnlMain.Controls.Add(this.label6);
            this.pnlMain.Controls.Add(this.groupBox3);
            this.pnlMain.Controls.Add(this.groupBox2);
            this.pnlMain.Controls.Add(this.radAccounts);
            this.pnlMain.Size = new System.Drawing.Size(545, 472);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(555, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(20, 391);
            this.btnEdit.Size = new System.Drawing.Size(10, 10);
            this.btnEdit.Text = "List All";
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(305, 391);
            this.btnSave.Size = new System.Drawing.Size(126, 39);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(163, 391);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(195, 391);
            this.btnNew.Size = new System.Drawing.Size(10, 10);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(437, 391);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(179, 391);
            this.btnPrint.Size = new System.Drawing.Size(10, 10);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 431);
            this.groupBox1.Size = new System.Drawing.Size(555, 36);
            // 
            // radAccounts
            // 
            this.radAccounts.AutoSize = true;
            this.radAccounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAccounts.Location = new System.Drawing.Point(215, 150);
            this.radAccounts.Name = "radAccounts";
            this.radAccounts.Size = new System.Drawing.Size(92, 21);
            this.radAccounts.TabIndex = 69;
            this.radAccounts.TabStop = true;
            this.radAccounts.Text = "Accounts";
            this.radAccounts.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radContraVoucher);
            this.groupBox2.Controls.Add(this.radJournalVoucher);
            this.groupBox2.Controls.Add(this.radReceiptVoucher);
            this.groupBox2.Controls.Add(this.radPaymentVoucher);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(37, 177);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(468, 116);
            this.groupBox2.TabIndex = 70;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Accounts";
            // 
            // radContraVoucher
            // 
            this.radContraVoucher.AutoSize = true;
            this.radContraVoucher.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radContraVoucher.Location = new System.Drawing.Point(281, 75);
            this.radContraVoucher.Name = "radContraVoucher";
            this.radContraVoucher.Size = new System.Drawing.Size(125, 21);
            this.radContraVoucher.TabIndex = 73;
            this.radContraVoucher.Text = "Contra Voucher";
            this.radContraVoucher.UseVisualStyleBackColor = true;
            this.radContraVoucher.Click += new System.EventHandler(this.radContraVoucher_Click);
            // 
            // radJournalVoucher
            // 
            this.radJournalVoucher.AutoSize = true;
            this.radJournalVoucher.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radJournalVoucher.Location = new System.Drawing.Point(54, 75);
            this.radJournalVoucher.Name = "radJournalVoucher";
            this.radJournalVoucher.Size = new System.Drawing.Size(130, 21);
            this.radJournalVoucher.TabIndex = 72;
            this.radJournalVoucher.Text = "Journal Voucher";
            this.radJournalVoucher.UseVisualStyleBackColor = true;
            this.radJournalVoucher.Click += new System.EventHandler(this.radJournalVoucher_Click);
            // 
            // radReceiptVoucher
            // 
            this.radReceiptVoucher.AutoSize = true;
            this.radReceiptVoucher.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radReceiptVoucher.Location = new System.Drawing.Point(281, 33);
            this.radReceiptVoucher.Name = "radReceiptVoucher";
            this.radReceiptVoucher.Size = new System.Drawing.Size(131, 21);
            this.radReceiptVoucher.TabIndex = 71;
            this.radReceiptVoucher.Text = "Receipt Voucher";
            this.radReceiptVoucher.UseVisualStyleBackColor = true;
            this.radReceiptVoucher.Click += new System.EventHandler(this.radReceiptVoucher_Click);
            // 
            // radPaymentVoucher
            // 
            this.radPaymentVoucher.AutoSize = true;
            this.radPaymentVoucher.Checked = true;
            this.radPaymentVoucher.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPaymentVoucher.Location = new System.Drawing.Point(54, 33);
            this.radPaymentVoucher.Name = "radPaymentVoucher";
            this.radPaymentVoucher.Size = new System.Drawing.Size(138, 21);
            this.radPaymentVoucher.TabIndex = 70;
            this.radPaymentVoucher.TabStop = true;
            this.radPaymentVoucher.Text = "Payment Voucher";
            this.radPaymentVoucher.UseVisualStyleBackColor = true;
            this.radPaymentVoucher.Click += new System.EventHandler(this.radPaymentVoucher_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtVoucherH5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtVoucherH1);
            this.groupBox3.Controls.Add(this.txtVoucherH2);
            this.groupBox3.Controls.Add(this.txtVoucherH3);
            this.groupBox3.Controls.Add(this.txtVoucherH4);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(19, 299);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(518, 120);
            this.groupBox3.TabIndex = 74;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Accounts Report Footer";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(144, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 18);
            this.label8.TabIndex = 83;
            this.label8.Text = "5:";
            // 
            // txtVoucherH5
            // 
            this.txtVoucherH5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVoucherH5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVoucherH5.Location = new System.Drawing.Point(196, 85);
            this.txtVoucherH5.Name = "txtVoucherH5";
            this.txtVoucherH5.Size = new System.Drawing.Size(172, 23);
            this.txtVoucherH5.TabIndex = 82;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(263, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 18);
            this.label4.TabIndex = 81;
            this.label4.Text = "4:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(263, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 18);
            this.label5.TabIndex = 80;
            this.label5.Text = "3:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 18);
            this.label3.TabIndex = 79;
            this.label3.Text = "2:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 18);
            this.label1.TabIndex = 78;
            this.label1.Text = "1:";
            // 
            // txtVoucherH1
            // 
            this.txtVoucherH1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVoucherH1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVoucherH1.Location = new System.Drawing.Point(72, 27);
            this.txtVoucherH1.Name = "txtVoucherH1";
            this.txtVoucherH1.Size = new System.Drawing.Size(172, 23);
            this.txtVoucherH1.TabIndex = 77;
            // 
            // txtVoucherH2
            // 
            this.txtVoucherH2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVoucherH2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVoucherH2.Location = new System.Drawing.Point(72, 56);
            this.txtVoucherH2.Name = "txtVoucherH2";
            this.txtVoucherH2.Size = new System.Drawing.Size(172, 23);
            this.txtVoucherH2.TabIndex = 76;
            // 
            // txtVoucherH3
            // 
            this.txtVoucherH3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVoucherH3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVoucherH3.Location = new System.Drawing.Point(314, 27);
            this.txtVoucherH3.Name = "txtVoucherH3";
            this.txtVoucherH3.Size = new System.Drawing.Size(172, 23);
            this.txtVoucherH3.TabIndex = 75;
            // 
            // txtVoucherH4
            // 
            this.txtVoucherH4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVoucherH4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVoucherH4.Location = new System.Drawing.Point(314, 57);
            this.txtVoucherH4.Name = "txtVoucherH4";
            this.txtVoucherH4.Size = new System.Drawing.Size(172, 23);
            this.txtVoucherH4.TabIndex = 74;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(88, 422);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 18);
            this.label6.TabIndex = 81;
            this.label6.Text = "Paper Size :";
            // 
            // cboxPaperSize
            // 
            this.cboxPaperSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxPaperSize.FormattingEnabled = true;
            this.cboxPaperSize.Items.AddRange(new object[] {
            "Full",
            "Half"});
            this.cboxPaperSize.Location = new System.Drawing.Point(215, 425);
            this.cboxPaperSize.Name = "cboxPaperSize";
            this.cboxPaperSize.Size = new System.Drawing.Size(172, 24);
            this.cboxPaperSize.TabIndex = 82;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(18, 85);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(19, 23);
            this.textBox1.TabIndex = 84;
            this.textBox1.Visible = false;
            // 
            // frmVoucherPrinting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(555, 467);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmVoucherPrinting";
            this.Load += new System.EventHandler(this.frmVoucherPrinting_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radContraVoucher;
        private System.Windows.Forms.RadioButton radJournalVoucher;
        private System.Windows.Forms.RadioButton radReceiptVoucher;
        private System.Windows.Forms.RadioButton radPaymentVoucher;
        private System.Windows.Forms.RadioButton radAccounts;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtVoucherH1;
        private System.Windows.Forms.TextBox txtVoucherH2;
        private System.Windows.Forms.TextBox txtVoucherH3;
        private System.Windows.Forms.TextBox txtVoucherH4;
        private System.Windows.Forms.ComboBox cboxPaperSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtVoucherH5;
        private System.Windows.Forms.TextBox textBox1;
    }
}
