namespace JA.Modulecontrolar.UI.Tools.Forms
{
    partial class frmAudit
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
            this.radAll = new System.Windows.Forms.RadioButton();
            this.radPurchase = new System.Windows.Forms.RadioButton();
            this.radStock = new System.Windows.Forms.RadioButton();
            this.radSales = new System.Windows.Forms.RadioButton();
            this.radAccounts = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbtnEntryDate = new System.Windows.Forms.RadioButton();
            this.rbtnVoucher = new System.Windows.Forms.RadioButton();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(241, 9);
            this.frmLabel.Size = new System.Drawing.Size(76, 33);
            this.frmLabel.Text = "Audit";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.groupBox3);
            this.pnlMain.Controls.Add(this.txtUserName);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.dtpToDate);
            this.pnlMain.Controls.Add(this.dtpFromDate);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.label6);
            this.pnlMain.Controls.Add(this.groupBox2);
            this.pnlMain.Size = new System.Drawing.Size(528, 421);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(537, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(29, 340);
            this.btnEdit.Size = new System.Drawing.Size(10, 10);
            this.btnEdit.Text = "List All";
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(288, 340);
            this.btnSave.Size = new System.Drawing.Size(126, 39);
            this.btnSave.Text = "Preview";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(172, 340);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(204, 340);
            this.btnNew.Size = new System.Drawing.Size(10, 10);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(420, 340);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(188, 340);
            this.btnPrint.Size = new System.Drawing.Size(10, 10);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 380);
            this.groupBox1.Size = new System.Drawing.Size(537, 36);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radAll);
            this.groupBox2.Controls.Add(this.radPurchase);
            this.groupBox2.Controls.Add(this.radStock);
            this.groupBox2.Controls.Add(this.radSales);
            this.groupBox2.Controls.Add(this.radAccounts);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(11, 191);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(498, 86);
            this.groupBox2.TabIndex = 70;
            this.groupBox2.TabStop = false;
            // 
            // radAll
            // 
            this.radAll.AutoSize = true;
            this.radAll.Checked = true;
            this.radAll.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAll.Location = new System.Drawing.Point(28, 34);
            this.radAll.Name = "radAll";
            this.radAll.Size = new System.Drawing.Size(42, 22);
            this.radAll.TabIndex = 75;
            this.radAll.TabStop = true;
            this.radAll.Text = "All";
            this.radAll.UseVisualStyleBackColor = true;
            // 
            // radPurchase
            // 
            this.radPurchase.AutoSize = true;
            this.radPurchase.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPurchase.Location = new System.Drawing.Point(322, 55);
            this.radPurchase.Name = "radPurchase";
            this.radPurchase.Size = new System.Drawing.Size(93, 22);
            this.radPurchase.TabIndex = 73;
            this.radPurchase.Text = "Purchase";
            this.radPurchase.UseVisualStyleBackColor = true;
            // 
            // radStock
            // 
            this.radStock.AutoSize = true;
            this.radStock.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radStock.Location = new System.Drawing.Point(149, 55);
            this.radStock.Name = "radStock";
            this.radStock.Size = new System.Drawing.Size(69, 22);
            this.radStock.TabIndex = 72;
            this.radStock.Text = "Stock";
            this.radStock.UseVisualStyleBackColor = true;
            // 
            // radSales
            // 
            this.radSales.AutoSize = true;
            this.radSales.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSales.Location = new System.Drawing.Point(322, 19);
            this.radSales.Name = "radSales";
            this.radSales.Size = new System.Drawing.Size(65, 22);
            this.radSales.TabIndex = 71;
            this.radSales.Text = "Sales";
            this.radSales.UseVisualStyleBackColor = true;
            // 
            // radAccounts
            // 
            this.radAccounts.AutoSize = true;
            this.radAccounts.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAccounts.Location = new System.Drawing.Point(149, 19);
            this.radAccounts.Name = "radAccounts";
            this.radAccounts.Size = new System.Drawing.Size(94, 22);
            this.radAccounts.TabIndex = 70;
            this.radAccounts.Text = "Accounts";
            this.radAccounts.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(136, 367);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 18);
            this.label6.TabIndex = 81;
            this.label6.Text = "ToDate :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(108, 339);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 18);
            this.label1.TabIndex = 83;
            this.label1.Text = "From Date :";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(225, 339);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(150, 24);
            this.dtpFromDate.TabIndex = 84;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(225, 367);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(150, 24);
            this.dtpToDate.TabIndex = 85;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(116, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 18);
            this.label3.TabIndex = 86;
            this.label3.Text = "User Name :";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(218, 161);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(291, 26);
            this.txtUserName.TabIndex = 87;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbtnEntryDate);
            this.groupBox3.Controls.Add(this.rbtnVoucher);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(93, 277);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(366, 54);
            this.groupBox3.TabIndex = 76;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Option";
            // 
            // rbtnEntryDate
            // 
            this.rbtnEntryDate.AutoSize = true;
            this.rbtnEntryDate.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnEntryDate.Location = new System.Drawing.Point(240, 22);
            this.rbtnEntryDate.Name = "rbtnEntryDate";
            this.rbtnEntryDate.Size = new System.Drawing.Size(105, 22);
            this.rbtnEntryDate.TabIndex = 71;
            this.rbtnEntryDate.Text = "Entry Date";
            this.rbtnEntryDate.UseVisualStyleBackColor = true;
            // 
            // rbtnVoucher
            // 
            this.rbtnVoucher.AutoSize = true;
            this.rbtnVoucher.Checked = true;
            this.rbtnVoucher.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnVoucher.Location = new System.Drawing.Point(67, 22);
            this.rbtnVoucher.Name = "rbtnVoucher";
            this.rbtnVoucher.Size = new System.Drawing.Size(126, 22);
            this.rbtnVoucher.TabIndex = 70;
            this.rbtnVoucher.TabStop = true;
            this.rbtnVoucher.Text = "Voucher Date";
            this.rbtnVoucher.UseVisualStyleBackColor = true;
            // 
            // frmAudit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(537, 416);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmAudit";
            this.Load += new System.EventHandler(this.frmAudit_Load);
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
        private System.Windows.Forms.RadioButton radPurchase;
        private System.Windows.Forms.RadioButton radStock;
        private System.Windows.Forms.RadioButton radSales;
        private System.Windows.Forms.RadioButton radAccounts;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radAll;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbtnEntryDate;
        private System.Windows.Forms.RadioButton rbtnVoucher;
    }
}
