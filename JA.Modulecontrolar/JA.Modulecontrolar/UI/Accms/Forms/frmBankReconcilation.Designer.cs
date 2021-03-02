namespace JA.Modulecontrolar.UI.Accms.Forms
{
    partial class frmBankReconcilation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBankReconcilation));
            this.smartLabel1 = new MayhediControlLibrary.StandardLabel();
            this.smartLabel2 = new MayhediControlLibrary.StandardLabel();
            this.smartLabel3 = new MayhediControlLibrary.StandardLabel();
            this.dteFromDate = new System.Windows.Forms.DateTimePicker();
            this.dteToDate = new System.Windows.Forms.DateTimePicker();
            this.DG = new System.Windows.Forms.DataGridView();
            this.smartLabel4 = new MayhediControlLibrary.StandardLabel();
            this.uctxtDebitTotal = new MayhediControlLibrary.StandardLabel();
            this.uctxtCreditTotal = new MayhediControlLibrary.StandardLabel();
            this.uctxtNotBankDebit = new MayhediControlLibrary.StandardLabel();
            this.uctxtNotBankCredit = new MayhediControlLibrary.StandardLabel();
            this.smartLabel5 = new MayhediControlLibrary.StandardLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblBankCharge = new System.Windows.Forms.Label();
            this.chkPosted = new System.Windows.Forms.CheckBox();
            this.uctxtLedgerName = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(539, 9);
            this.frmLabel.Size = new System.Drawing.Size(237, 33);
            this.frmLabel.Text = "Bank Reconcilation";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.uctxtLedgerName);
            this.pnlMain.Controls.Add(this.chkPosted);
            this.pnlMain.Controls.Add(this.lblBankCharge);
            this.pnlMain.Controls.Add(this.groupBox5);
            this.pnlMain.Controls.Add(this.groupBox2);
            this.pnlMain.Controls.Add(this.smartLabel5);
            this.pnlMain.Controls.Add(this.uctxtNotBankCredit);
            this.pnlMain.Controls.Add(this.uctxtNotBankDebit);
            this.pnlMain.Controls.Add(this.uctxtCreditTotal);
            this.pnlMain.Controls.Add(this.uctxtDebitTotal);
            this.pnlMain.Controls.Add(this.smartLabel4);
            this.pnlMain.Controls.Add(this.DG);
            this.pnlMain.Controls.Add(this.dteToDate);
            this.pnlMain.Controls.Add(this.dteFromDate);
            this.pnlMain.Controls.Add(this.smartLabel3);
            this.pnlMain.Controls.Add(this.smartLabel2);
            this.pnlMain.Controls.Add(this.smartLabel1);
            this.pnlMain.Size = new System.Drawing.Size(1367, 757);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(1371, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(286, 677);
            this.btnEdit.Size = new System.Drawing.Size(10, 22);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1143, 675);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(399, 677);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(146, 670);
            this.btnNew.Size = new System.Drawing.Size(10, 19);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1253, 675);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(934, 674);
            this.btnPrint.Text = "View";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 716);
            this.groupBox1.Size = new System.Drawing.Size(1371, 25);
            // 
            // smartLabel1
            // 
            this.smartLabel1.AutoSize = true;
            this.smartLabel1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.smartLabel1.Location = new System.Drawing.Point(345, 162);
            this.smartLabel1.Name = "smartLabel1";
            this.smartLabel1.Size = new System.Drawing.Size(109, 16);
            this.smartLabel1.TabIndex = 0;
            this.smartLabel1.Text = "Ledger Name:";
            // 
            // smartLabel2
            // 
            this.smartLabel2.AutoSize = true;
            this.smartLabel2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.smartLabel2.Location = new System.Drawing.Point(361, 188);
            this.smartLabel2.Name = "smartLabel2";
            this.smartLabel2.Size = new System.Drawing.Size(93, 16);
            this.smartLabel2.TabIndex = 1;
            this.smartLabel2.Text = "From  Date:";
            // 
            // smartLabel3
            // 
            this.smartLabel3.AutoSize = true;
            this.smartLabel3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.smartLabel3.Location = new System.Drawing.Point(386, 214);
            this.smartLabel3.Name = "smartLabel3";
            this.smartLabel3.Size = new System.Drawing.Size(68, 16);
            this.smartLabel3.TabIndex = 2;
            this.smartLabel3.Text = "To Date:";
            // 
            // dteFromDate
            // 
            this.dteFromDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteFromDate.Location = new System.Drawing.Point(465, 186);
            this.dteFromDate.Name = "dteFromDate";
            this.dteFromDate.Size = new System.Drawing.Size(200, 22);
            this.dteFromDate.TabIndex = 4;
            // 
            // dteToDate
            // 
            this.dteToDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteToDate.Location = new System.Drawing.Point(465, 211);
            this.dteToDate.Name = "dteToDate";
            this.dteToDate.Size = new System.Drawing.Size(200, 22);
            this.dteToDate.TabIndex = 5;
            // 
            // DG
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DG.DefaultCellStyle = dataGridViewCellStyle2;
            this.DG.Location = new System.Drawing.Point(6, 238);
            this.DG.Name = "DG";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DG.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DG.Size = new System.Drawing.Size(1355, 432);
            this.DG.TabIndex = 6;
            this.DG.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellEndEdit);
            // 
            // smartLabel4
            // 
            this.smartLabel4.AutoSize = true;
            this.smartLabel4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.smartLabel4.ForeColor = System.Drawing.Color.Blue;
            this.smartLabel4.Location = new System.Drawing.Point(315, 715);
            this.smartLabel4.Name = "smartLabel4";
            this.smartLabel4.Size = new System.Drawing.Size(228, 16);
            this.smartLabel4.TabIndex = 8;
            this.smartLabel4.Text = "Amount Not Reflected in Bank:";
            // 
            // uctxtDebitTotal
            // 
            this.uctxtDebitTotal.AutoSize = true;
            this.uctxtDebitTotal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtDebitTotal.ForeColor = System.Drawing.Color.Fuchsia;
            this.uctxtDebitTotal.Location = new System.Drawing.Point(845, 674);
            this.uctxtDebitTotal.Name = "uctxtDebitTotal";
            this.uctxtDebitTotal.Size = new System.Drawing.Size(15, 13);
            this.uctxtDebitTotal.TabIndex = 9;
            this.uctxtDebitTotal.Text = "0";
            // 
            // uctxtCreditTotal
            // 
            this.uctxtCreditTotal.AutoSize = true;
            this.uctxtCreditTotal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtCreditTotal.ForeColor = System.Drawing.Color.Fuchsia;
            this.uctxtCreditTotal.Location = new System.Drawing.Point(984, 674);
            this.uctxtCreditTotal.Name = "uctxtCreditTotal";
            this.uctxtCreditTotal.Size = new System.Drawing.Size(15, 13);
            this.uctxtCreditTotal.TabIndex = 10;
            this.uctxtCreditTotal.Text = "0";
            // 
            // uctxtNotBankDebit
            // 
            this.uctxtNotBankDebit.AutoSize = true;
            this.uctxtNotBankDebit.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtNotBankDebit.Location = new System.Drawing.Point(845, 716);
            this.uctxtNotBankDebit.Name = "uctxtNotBankDebit";
            this.uctxtNotBankDebit.Size = new System.Drawing.Size(15, 13);
            this.uctxtNotBankDebit.TabIndex = 11;
            this.uctxtNotBankDebit.Text = "0";
            // 
            // uctxtNotBankCredit
            // 
            this.uctxtNotBankCredit.AutoSize = true;
            this.uctxtNotBankCredit.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtNotBankCredit.Location = new System.Drawing.Point(984, 716);
            this.uctxtNotBankCredit.Name = "uctxtNotBankCredit";
            this.uctxtNotBankCredit.Size = new System.Drawing.Size(15, 13);
            this.uctxtNotBankCredit.TabIndex = 12;
            this.uctxtNotBankCredit.Text = "0";
            // 
            // smartLabel5
            // 
            this.smartLabel5.AutoSize = true;
            this.smartLabel5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.smartLabel5.ForeColor = System.Drawing.Color.Blue;
            this.smartLabel5.Location = new System.Drawing.Point(302, 674);
            this.smartLabel5.Name = "smartLabel5";
            this.smartLabel5.Size = new System.Drawing.Size(241, 16);
            this.smartLabel5.TabIndex = 15;
            this.smartLabel5.Text = "Balance as per Company Books:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.Location = new System.Drawing.Point(5, 692);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1353, 8);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox3.Location = new System.Drawing.Point(0, 38);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(907, 8);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox4.Location = new System.Drawing.Point(0, 35);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(907, 8);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.groupBox5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox5.Location = new System.Drawing.Point(5, 742);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1353, 8);
            this.groupBox5.TabIndex = 18;
            this.groupBox5.TabStop = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnRefresh.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnRefresh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(1042, 673);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(101, 43);
            this.btnRefresh.TabIndex = 47;
            this.btnRefresh.Text = "   Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblBankCharge
            // 
            this.lblBankCharge.AutoSize = true;
            this.lblBankCharge.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBankCharge.ForeColor = System.Drawing.Color.Blue;
            this.lblBankCharge.Location = new System.Drawing.Point(1247, 673);
            this.lblBankCharge.Name = "lblBankCharge";
            this.lblBankCharge.Size = new System.Drawing.Size(15, 13);
            this.lblBankCharge.TabIndex = 19;
            this.lblBankCharge.Text = "0";
            // 
            // chkPosted
            // 
            this.chkPosted.AutoSize = true;
            this.chkPosted.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPosted.ForeColor = System.Drawing.Color.Blue;
            this.chkPosted.Location = new System.Drawing.Point(1276, 212);
            this.chkPosted.Name = "chkPosted";
            this.chkPosted.Size = new System.Drawing.Size(78, 20);
            this.chkPosted.TabIndex = 20;
            this.chkPosted.Text = "Locked";
            this.chkPosted.UseVisualStyleBackColor = true;
            // 
            // uctxtLedgerName
            // 
            this.uctxtLedgerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtLedgerName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtLedgerName.Location = new System.Drawing.Point(465, 161);
            this.uctxtLedgerName.Name = "uctxtLedgerName";
            this.uctxtLedgerName.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtLedgerName.Size = new System.Drawing.Size(446, 22);
            this.uctxtLedgerName.TabIndex = 53;
            // 
            // frmBankReconcilation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1371, 741);
            this.Controls.Add(this.btnRefresh);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmBankReconcilation";
            this.Load += new System.EventHandler(this.frmBankReconcilation_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.pnlMain, 0);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.Controls.SetChildIndex(this.btnRefresh, 0);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MayhediControlLibrary.StandardLabel smartLabel1;
        private System.Windows.Forms.DataGridView DG;
        private System.Windows.Forms.DateTimePicker dteToDate;
        private System.Windows.Forms.DateTimePicker dteFromDate;
        private MayhediControlLibrary.StandardLabel smartLabel3;
        private MayhediControlLibrary.StandardLabel smartLabel2;
        private MayhediControlLibrary.StandardLabel uctxtNotBankCredit;
        private MayhediControlLibrary.StandardLabel uctxtNotBankDebit;
        private MayhediControlLibrary.StandardLabel uctxtCreditTotal;
        private MayhediControlLibrary.StandardLabel uctxtDebitTotal;
        private MayhediControlLibrary.StandardLabel smartLabel4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private MayhediControlLibrary.StandardLabel smartLabel5;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblBankCharge;
        private System.Windows.Forms.CheckBox chkPosted;
        private System.Windows.Forms.TextBox uctxtLedgerName;
    }
}
