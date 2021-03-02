namespace JA.Modulecontrolar.UI.Master.Accounts
{
    partial class frmVoucherTypes
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
            this.label1 = new System.Windows.Forms.Label();
            this.uctxtTypeOfVoucher = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.uctxtVoucher = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.uctxtNumeringMethod = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.uctxtStartingMethod = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.uctxtNuemricalPart = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.uctxtPrefix = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.uctxtSuffix = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.uctxtPrintAfterSavingVoucher = new System.Windows.Forms.TextBox();
            this.chkTotallVoucher = new System.Windows.Forms.CheckBox();
            this.chkBkash = new System.Windows.Forms.CheckBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(267, 7);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.chkBkash);
            this.pnlMain.Controls.Add(this.chkTotallVoucher);
            this.pnlMain.Controls.Add(this.label10);
            this.pnlMain.Controls.Add(this.uctxtPrintAfterSavingVoucher);
            this.pnlMain.Controls.Add(this.label9);
            this.pnlMain.Controls.Add(this.uctxtSuffix);
            this.pnlMain.Controls.Add(this.label8);
            this.pnlMain.Controls.Add(this.uctxtPrefix);
            this.pnlMain.Controls.Add(this.label6);
            this.pnlMain.Controls.Add(this.uctxtNuemricalPart);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.uctxtStartingMethod);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.uctxtNumeringMethod);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.uctxtVoucher);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.uctxtTypeOfVoucher);
            this.pnlMain.Size = new System.Drawing.Size(728, 442);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(732, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(6, 42);
            this.btnEdit.Size = new System.Drawing.Size(10, 39);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(509, 359);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(498, 20);
            this.btnDelete.Size = new System.Drawing.Size(10, 16);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(3, 359);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(620, 359);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(609, 20);
            this.btnPrint.Size = new System.Drawing.Size(10, 16);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 408);
            this.groupBox1.Size = new System.Drawing.Size(732, 25);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(133, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Type of Voucher:";
            // 
            // uctxtTypeOfVoucher
            // 
            this.uctxtTypeOfVoucher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtTypeOfVoucher.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtTypeOfVoucher.Location = new System.Drawing.Point(276, 175);
            this.uctxtTypeOfVoucher.Name = "uctxtTypeOfVoucher";
            this.uctxtTypeOfVoucher.ReadOnly = true;
            this.uctxtTypeOfVoucher.Size = new System.Drawing.Size(435, 22);
            this.uctxtTypeOfVoucher.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(148, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Voucher Name:";
            // 
            // uctxtVoucher
            // 
            this.uctxtVoucher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtVoucher.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtVoucher.Location = new System.Drawing.Point(276, 199);
            this.uctxtVoucher.Name = "uctxtVoucher";
            this.uctxtVoucher.ReadOnly = true;
            this.uctxtVoucher.Size = new System.Drawing.Size(435, 22);
            this.uctxtVoucher.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(62, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(194, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Voucher Numbering Method:";
            // 
            // uctxtNumeringMethod
            // 
            this.uctxtNumeringMethod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtNumeringMethod.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtNumeringMethod.Location = new System.Drawing.Point(276, 223);
            this.uctxtNumeringMethod.Name = "uctxtNumeringMethod";
            this.uctxtNumeringMethod.Size = new System.Drawing.Size(204, 22);
            this.uctxtNumeringMethod.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(168, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Starting No:";
            // 
            // uctxtStartingMethod
            // 
            this.uctxtStartingMethod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtStartingMethod.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtStartingMethod.Location = new System.Drawing.Point(276, 247);
            this.uctxtStartingMethod.Name = "uctxtStartingMethod";
            this.uctxtStartingMethod.Size = new System.Drawing.Size(204, 22);
            this.uctxtStartingMethod.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(87, 271);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Width of Numerical Part:";
            // 
            // uctxtNuemricalPart
            // 
            this.uctxtNuemricalPart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtNuemricalPart.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtNuemricalPart.Location = new System.Drawing.Point(276, 271);
            this.uctxtNuemricalPart.Name = "uctxtNuemricalPart";
            this.uctxtNuemricalPart.Size = new System.Drawing.Size(204, 22);
            this.uctxtNuemricalPart.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(207, 296);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 16);
            this.label8.TabIndex = 13;
            this.label8.Text = "Prefix:";
            // 
            // uctxtPrefix
            // 
            this.uctxtPrefix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtPrefix.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtPrefix.Location = new System.Drawing.Point(276, 294);
            this.uctxtPrefix.MaxLength = 3;
            this.uctxtPrefix.Name = "uctxtPrefix";
            this.uctxtPrefix.Size = new System.Drawing.Size(204, 22);
            this.uctxtPrefix.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(206, 320);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 16);
            this.label9.TabIndex = 15;
            this.label9.Text = "Suffix:";
            // 
            // uctxtSuffix
            // 
            this.uctxtSuffix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtSuffix.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtSuffix.Location = new System.Drawing.Point(276, 318);
            this.uctxtSuffix.MaxLength = 3;
            this.uctxtSuffix.Name = "uctxtSuffix";
            this.uctxtSuffix.Size = new System.Drawing.Size(204, 22);
            this.uctxtSuffix.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(67, 343);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(189, 16);
            this.label10.TabIndex = 17;
            this.label10.Text = "Print After Saving Voucher:";
            // 
            // uctxtPrintAfterSavingVoucher
            // 
            this.uctxtPrintAfterSavingVoucher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtPrintAfterSavingVoucher.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtPrintAfterSavingVoucher.Location = new System.Drawing.Point(276, 342);
            this.uctxtPrintAfterSavingVoucher.Name = "uctxtPrintAfterSavingVoucher";
            this.uctxtPrintAfterSavingVoucher.Size = new System.Drawing.Size(204, 22);
            this.uctxtPrintAfterSavingVoucher.TabIndex = 16;
            // 
            // chkTotallVoucher
            // 
            this.chkTotallVoucher.AutoSize = true;
            this.chkTotallVoucher.Location = new System.Drawing.Point(272, 389);
            this.chkTotallVoucher.Name = "chkTotallVoucher";
            this.chkTotallVoucher.Size = new System.Drawing.Size(93, 17);
            this.chkTotallVoucher.TabIndex = 18;
            this.chkTotallVoucher.Text = "Total Voucher";
            this.chkTotallVoucher.UseVisualStyleBackColor = true;
            // 
            // chkBkash
            // 
            this.chkBkash.AutoSize = true;
            this.chkBkash.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBkash.Location = new System.Drawing.Point(17, 403);
            this.chkBkash.Name = "chkBkash";
            this.chkBkash.Size = new System.Drawing.Size(153, 18);
            this.chkBkash.TabIndex = 19;
            this.chkBkash.Text = "Effect Bkash Charge";
            this.chkBkash.UseVisualStyleBackColor = true;
            this.chkBkash.Visible = false;
            // 
            // frmVoucherTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(732, 433);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmVoucherTypes";
            this.Load += new System.EventHandler(this.frmVoucherTypes_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uctxtTypeOfVoucher;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox uctxtPrintAfterSavingVoucher;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox uctxtSuffix;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox uctxtPrefix;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox uctxtNuemricalPart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox uctxtStartingMethod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox uctxtNumeringMethod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uctxtVoucher;
        private System.Windows.Forms.CheckBox chkTotallVoucher;
        private System.Windows.Forms.CheckBox chkBkash;
    }
}
