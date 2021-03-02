namespace JA.Modulecontrolar.UI.Accms.Forms
{
    partial class frmDepreciationAdjustment
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
            this.uctxtBranch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uctxtVoucherNo = new System.Windows.Forms.TextBox();
            this.lblLedgerName = new System.Windows.Forms.Label();
            this.uctxtLedger = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.uctxtAmount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DG = new System.Windows.Forms.DataGridView();
            this.dteEffectiveDate = new System.Windows.Forms.DateTimePicker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).BeginInit();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(200, 8);
            this.frmLabel.Size = new System.Drawing.Size(307, 33);
            this.frmLabel.Text = "Depreciation Adjustment";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.textBox1);
            this.pnlMain.Controls.Add(this.dteEffectiveDate);
            this.pnlMain.Controls.Add(this.DG);
            this.pnlMain.Controls.Add(this.uctxtAmount);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.uctxtLedger);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.uctxtBranch);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.uctxtVoucherNo);
            this.pnlMain.Controls.Add(this.lblLedgerName);
            this.pnlMain.Size = new System.Drawing.Size(667, 564);
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(674, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(6, 3);
            this.btnEdit.Size = new System.Drawing.Size(25, 14);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(445, 479);
            this.btnSave.Visible = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(444, 3);
            this.btnDelete.Size = new System.Drawing.Size(10, 14);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(332, 479);
            this.btnNew.Visible = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(559, 479);
            this.btnClose.Visible = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(555, 3);
            this.btnPrint.Size = new System.Drawing.Size(13, 14);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 518);
            this.groupBox1.Size = new System.Drawing.Size(674, 25);
            // 
            // uctxtBranch
            // 
            this.uctxtBranch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtBranch.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtBranch.Location = new System.Drawing.Point(222, 213);
            this.uctxtBranch.Name = "uctxtBranch";
            this.uctxtBranch.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtBranch.Size = new System.Drawing.Size(323, 22);
            this.uctxtBranch.TabIndex = 63;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(154, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 16);
            this.label3.TabIndex = 62;
            this.label3.Text = "Branch:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(168, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 60;
            this.label1.Text = "Date:";
            // 
            // uctxtVoucherNo
            // 
            this.uctxtVoucherNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtVoucherNo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtVoucherNo.Location = new System.Drawing.Point(222, 162);
            this.uctxtVoucherNo.Name = "uctxtVoucherNo";
            this.uctxtVoucherNo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtVoucherNo.Size = new System.Drawing.Size(137, 22);
            this.uctxtVoucherNo.TabIndex = 59;
            // 
            // lblLedgerName
            // 
            this.lblLedgerName.AutoSize = true;
            this.lblLedgerName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLedgerName.Location = new System.Drawing.Point(123, 164);
            this.lblLedgerName.Name = "lblLedgerName";
            this.lblLedgerName.Size = new System.Drawing.Size(89, 16);
            this.lblLedgerName.TabIndex = 58;
            this.lblLedgerName.Text = "Voucher No:";
            // 
            // uctxtLedger
            // 
            this.uctxtLedger.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtLedger.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtLedger.Location = new System.Drawing.Point(222, 238);
            this.uctxtLedger.Name = "uctxtLedger";
            this.uctxtLedger.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtLedger.Size = new System.Drawing.Size(323, 22);
            this.uctxtLedger.TabIndex = 65;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(155, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 16);
            this.label4.TabIndex = 64;
            this.label4.Text = "Ledger:";
            // 
            // uctxtAmount
            // 
            this.uctxtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtAmount.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtAmount.Location = new System.Drawing.Point(222, 263);
            this.uctxtAmount.Name = "uctxtAmount";
            this.uctxtAmount.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtAmount.Size = new System.Drawing.Size(137, 22);
            this.uctxtAmount.TabIndex = 67;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(149, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 66;
            this.label5.Text = "Amount:";
            // 
            // DG
            // 
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG.Location = new System.Drawing.Point(5, 291);
            this.DG.Name = "DG";
            this.DG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DG.Size = new System.Drawing.Size(657, 266);
            this.DG.TabIndex = 68;
            this.DG.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellClick);
            this.DG.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellContentClick);
            // 
            // dteEffectiveDate
            // 
            this.dteEffectiveDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteEffectiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteEffectiveDate.Location = new System.Drawing.Point(222, 187);
            this.dteEffectiveDate.Name = "dteEffectiveDate";
            this.dteEffectiveDate.Size = new System.Drawing.Size(139, 23);
            this.dteEffectiveDate.TabIndex = 69;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(499, 158);
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(137, 22);
            this.textBox1.TabIndex = 70;
            this.textBox1.Visible = false;
            // 
            // frmDepreciationAdjustment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(674, 543);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmDepreciationAdjustment";
            this.Load += new System.EventHandler(this.frmDepreciationAdjustment_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox uctxtBranch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uctxtVoucherNo;
        private System.Windows.Forms.Label lblLedgerName;
        private System.Windows.Forms.TextBox uctxtAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox uctxtLedger;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView DG;
        private System.Windows.Forms.DateTimePicker dteEffectiveDate;
        private System.Windows.Forms.TextBox textBox1;
    }
}
