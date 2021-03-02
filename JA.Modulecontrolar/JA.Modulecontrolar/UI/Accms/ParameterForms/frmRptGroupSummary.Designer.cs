namespace JA.Modulecontrolar.UI.DReport.Accms.ParameterForms
{
    partial class frmRptGroupSummary
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
            this.chkClosing = new System.Windows.Forms.CheckBox();
            this.chkTransaction = new System.Windows.Forms.CheckBox();
            this.chkOpening = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radLedgerWise = new System.Windows.Forms.RadioButton();
            this.radGroupWise = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.uctxtLedgerName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.uctxtTeritorryName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.uctxtTerritoryCode = new System.Windows.Forms.TextBox();
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
            this.frmLabel.Size = new System.Drawing.Size(152, 33);
            this.frmLabel.Text = "Group Wise";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.label6);
            this.pnlMain.Controls.Add(this.uctxtTeritorryName);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.uctxtTerritoryCode);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.uctxtLedgerName);
            this.pnlMain.Controls.Add(this.groupBox6);
            this.pnlMain.Controls.Add(this.groupBox3);
            this.pnlMain.Controls.Add(this.groupBox2);
            this.pnlMain.Location = new System.Drawing.Point(0, -86);
            this.pnlMain.Size = new System.Drawing.Size(484, 478);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(487, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(123, 398);
            this.btnEdit.Size = new System.Drawing.Size(17, 10);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(10, 412);
            this.btnSave.Size = new System.Drawing.Size(10, 23);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(115, 412);
            this.btnDelete.Size = new System.Drawing.Size(10, 22);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(7, 398);
            this.btnNew.Size = new System.Drawing.Size(16, 17);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(358, 398);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(236, 398);
            this.btnPrint.Size = new System.Drawing.Size(119, 39);
            this.btnPrint.Text = "Preview";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 446);
            this.groupBox1.Size = new System.Drawing.Size(487, 25);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.dteToDate);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.dteFromDate);
            this.groupBox6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(9, 377);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(237, 95);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Period Seletion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(64, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "To:";
            // 
            // dteToDate
            // 
            this.dteToDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteToDate.Location = new System.Drawing.Point(103, 66);
            this.dteToDate.Name = "dteToDate";
            this.dteToDate.Size = new System.Drawing.Size(109, 22);
            this.dteToDate.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(43, 33);
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
            this.dteFromDate.Location = new System.Drawing.Point(103, 29);
            this.dteFromDate.Name = "dteFromDate";
            this.dteFromDate.Size = new System.Drawing.Size(109, 22);
            this.dteFromDate.TabIndex = 20;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkClosing);
            this.groupBox2.Controls.Add(this.chkTransaction);
            this.groupBox2.Controls.Add(this.chkOpening);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(11, 257);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(434, 62);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selection";
            // 
            // chkClosing
            // 
            this.chkClosing.AutoSize = true;
            this.chkClosing.Checked = true;
            this.chkClosing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClosing.Location = new System.Drawing.Point(333, 29);
            this.chkClosing.Name = "chkClosing";
            this.chkClosing.Size = new System.Drawing.Size(72, 18);
            this.chkClosing.TabIndex = 7;
            this.chkClosing.Text = "Closing";
            this.chkClosing.UseVisualStyleBackColor = true;
            // 
            // chkTransaction
            // 
            this.chkTransaction.AutoSize = true;
            this.chkTransaction.Checked = true;
            this.chkTransaction.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTransaction.Location = new System.Drawing.Point(191, 29);
            this.chkTransaction.Name = "chkTransaction";
            this.chkTransaction.Size = new System.Drawing.Size(98, 18);
            this.chkTransaction.TabIndex = 6;
            this.chkTransaction.Text = "Transaction";
            this.chkTransaction.UseVisualStyleBackColor = true;
            // 
            // chkOpening
            // 
            this.chkOpening.AutoSize = true;
            this.chkOpening.Checked = true;
            this.chkOpening.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOpening.Location = new System.Drawing.Point(62, 29);
            this.chkOpening.Name = "chkOpening";
            this.chkOpening.Size = new System.Drawing.Size(79, 18);
            this.chkOpening.TabIndex = 5;
            this.chkOpening.Text = "Opening";
            this.chkOpening.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radLedgerWise);
            this.groupBox3.Controls.Add(this.radGroupWise);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(10, 320);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(434, 51);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Selection";
            // 
            // radLedgerWise
            // 
            this.radLedgerWise.AutoSize = true;
            this.radLedgerWise.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLedgerWise.Location = new System.Drawing.Point(225, 20);
            this.radLedgerWise.Name = "radLedgerWise";
            this.radLedgerWise.Size = new System.Drawing.Size(104, 18);
            this.radLedgerWise.TabIndex = 3;
            this.radLedgerWise.Text = "Ledger Wise";
            this.radLedgerWise.UseVisualStyleBackColor = true;
            this.radLedgerWise.Click += new System.EventHandler(this.radLedgerWise_Click);
            // 
            // radGroupWise
            // 
            this.radGroupWise.AutoSize = true;
            this.radGroupWise.Checked = true;
            this.radGroupWise.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupWise.Location = new System.Drawing.Point(114, 20);
            this.radGroupWise.Name = "radGroupWise";
            this.radGroupWise.Size = new System.Drawing.Size(98, 18);
            this.radGroupWise.TabIndex = 2;
            this.radGroupWise.TabStop = true;
            this.radGroupWise.Text = "Group Wise";
            this.radGroupWise.UseVisualStyleBackColor = true;
            this.radGroupWise.Click += new System.EventHandler(this.radGroupWise_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 14);
            this.label3.TabIndex = 10;
            this.label3.Text = "Name:";
            // 
            // uctxtLedgerName
            // 
            this.uctxtLedgerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtLedgerName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtLedgerName.Location = new System.Drawing.Point(12, 174);
            this.uctxtLedgerName.Name = "uctxtLedgerName";
            this.uctxtLedgerName.Size = new System.Drawing.Size(462, 23);
            this.uctxtLedgerName.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 14);
            this.label6.TabIndex = 18;
            this.label6.Text = "Teritorry Name:";
            this.label6.Visible = false;
            // 
            // uctxtTeritorryName
            // 
            this.uctxtTeritorryName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtTeritorryName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtTeritorryName.Location = new System.Drawing.Point(130, 229);
            this.uctxtTeritorryName.Name = "uctxtTeritorryName";
            this.uctxtTeritorryName.ReadOnly = true;
            this.uctxtTeritorryName.Size = new System.Drawing.Size(10, 23);
            this.uctxtTeritorryName.TabIndex = 17;
            this.uctxtTeritorryName.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 14);
            this.label4.TabIndex = 16;
            this.label4.Text = "Teritorry Code:";
            this.label4.Visible = false;
            // 
            // uctxtTerritoryCode
            // 
            this.uctxtTerritoryCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtTerritoryCode.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtTerritoryCode.Location = new System.Drawing.Point(130, 205);
            this.uctxtTerritoryCode.Name = "uctxtTerritoryCode";
            this.uctxtTerritoryCode.ReadOnly = true;
            this.uctxtTerritoryCode.Size = new System.Drawing.Size(10, 23);
            this.uctxtTerritoryCode.TabIndex = 15;
            this.uctxtTerritoryCode.Visible = false;
            // 
            // frmRptGroupSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(487, 471);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmRptGroupSummary";
            this.Load += new System.EventHandler(this.frmRptGroupSummary_Load);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dteToDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dteFromDate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radLedgerWise;
        private System.Windows.Forms.RadioButton radGroupWise;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uctxtLedgerName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox uctxtTeritorryName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox uctxtTerritoryCode;
        private System.Windows.Forms.CheckBox chkClosing;
        private System.Windows.Forms.CheckBox chkTransaction;
        private System.Windows.Forms.CheckBox chkOpening;
    }
}
