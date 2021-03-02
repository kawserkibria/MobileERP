namespace JA.Modulecontrolar.UI.DReport.Accms.ParameterForms
{
    partial class frmRptPostDatedCheque
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radChequeGivenTo = new System.Windows.Forms.RadioButton();
            this.radChequeRecFrom = new System.Windows.Forms.RadioButton();
            this.radVoucherDate = new System.Windows.Forms.RadioButton();
            this.radChequeDate = new System.Windows.Forms.RadioButton();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.pnlMain.Controls.Add(this.groupBox3);
            this.pnlMain.Controls.Add(this.groupBox2);
            this.pnlMain.Controls.Add(this.groupBox6);
            this.pnlMain.Location = new System.Drawing.Point(0, -86);
            this.pnlMain.Size = new System.Drawing.Size(463, 413);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(465, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(57, 335);
            this.btnEdit.Size = new System.Drawing.Size(15, 20);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(57, 331);
            this.btnSave.Size = new System.Drawing.Size(10, 23);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(103, 338);
            this.btnDelete.Size = new System.Drawing.Size(10, 22);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(10, 338);
            this.btnNew.Size = new System.Drawing.Size(32, 17);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(355, 333);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(222, 333);
            this.btnPrint.Size = new System.Drawing.Size(130, 39);
            this.btnPrint.Text = "Preview";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 379);
            this.groupBox1.Size = new System.Drawing.Size(465, 25);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.dteToDate);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.dteFromDate);
            this.groupBox6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(18, 308);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(434, 94);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Period Seletion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(132, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "To:";
            // 
            // dteToDate
            // 
            this.dteToDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteToDate.Location = new System.Drawing.Point(172, 60);
            this.dteToDate.Name = "dteToDate";
            this.dteToDate.Size = new System.Drawing.Size(224, 22);
            this.dteToDate.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(111, 22);
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
            this.dteFromDate.Location = new System.Drawing.Point(172, 21);
            this.dteFromDate.Name = "dteFromDate";
            this.dteFromDate.Size = new System.Drawing.Size(224, 22);
            this.dteFromDate.TabIndex = 20;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radChequeDate);
            this.groupBox2.Controls.Add(this.radVoucherDate);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(18, 230);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(434, 72);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radChequeRecFrom);
            this.groupBox3.Controls.Add(this.radChequeGivenTo);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(18, 152);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(434, 72);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            // 
            // radChequeGivenTo
            // 
            this.radChequeGivenTo.AutoSize = true;
            this.radChequeGivenTo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radChequeGivenTo.Location = new System.Drawing.Point(164, 45);
            this.radChequeGivenTo.Name = "radChequeGivenTo";
            this.radChequeGivenTo.Size = new System.Drawing.Size(131, 18);
            this.radChequeGivenTo.TabIndex = 26;
            this.radChequeGivenTo.TabStop = true;
            this.radChequeGivenTo.Text = "Cheque Given To";
            this.radChequeGivenTo.UseVisualStyleBackColor = true;
            // 
            // radChequeRecFrom
            // 
            this.radChequeRecFrom.AutoSize = true;
            this.radChequeRecFrom.Location = new System.Drawing.Point(164, 21);
            this.radChequeRecFrom.Name = "radChequeRecFrom";
            this.radChequeRecFrom.Size = new System.Drawing.Size(169, 18);
            this.radChequeRecFrom.TabIndex = 27;
            this.radChequeRecFrom.TabStop = true;
            this.radChequeRecFrom.Text = "Cheque Received From";
            this.radChequeRecFrom.UseVisualStyleBackColor = true;
            // 
            // radVoucherDate
            // 
            this.radVoucherDate.AutoSize = true;
            this.radVoucherDate.Location = new System.Drawing.Point(166, 22);
            this.radVoucherDate.Name = "radVoucherDate";
            this.radVoucherDate.Size = new System.Drawing.Size(109, 18);
            this.radVoucherDate.TabIndex = 26;
            this.radVoucherDate.TabStop = true;
            this.radVoucherDate.Text = "Voucher Date";
            this.radVoucherDate.UseVisualStyleBackColor = true;
            // 
            // radChequeDate
            // 
            this.radChequeDate.AutoSize = true;
            this.radChequeDate.Location = new System.Drawing.Point(166, 48);
            this.radChequeDate.Name = "radChequeDate";
            this.radChequeDate.Size = new System.Drawing.Size(108, 18);
            this.radChequeDate.TabIndex = 27;
            this.radChequeDate.TabStop = true;
            this.radChequeDate.Text = "Cheque Date";
            this.radChequeDate.UseVisualStyleBackColor = true;
            // 
            // frmRptPostDatedCheque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(465, 404);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmRptPostDatedCheque";
            this.Load += new System.EventHandler(this.frmRptStoreLedger_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dteToDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dteFromDate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radChequeRecFrom;
        private System.Windows.Forms.RadioButton radChequeGivenTo;
        private System.Windows.Forms.RadioButton radChequeDate;
        private System.Windows.Forms.RadioButton radVoucherDate;
    }
}
