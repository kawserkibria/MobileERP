namespace JA.Modulecontrolar.UI.DReport.Accms.ParameterForms
{
    partial class frmRptBudget
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
            this.label6 = new System.Windows.Forms.Label();
            this.radAllLedger = new System.Windows.Forms.RadioButton();
            this.radbIndividualLedger = new System.Windows.Forms.RadioButton();
            this.uctxtLedgerConfig = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(154, 9);
            this.frmLabel.Size = new System.Drawing.Size(187, 33);
            this.frmLabel.Text = "Budget Report";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.uctxtLedgerConfig);
            this.pnlMain.Controls.Add(this.radbIndividualLedger);
            this.pnlMain.Controls.Add(this.radAllLedger);
            this.pnlMain.Controls.Add(this.label6);
            this.pnlMain.Controls.Add(this.groupBox6);
            this.pnlMain.Location = new System.Drawing.Point(0, -86);
            this.pnlMain.Size = new System.Drawing.Size(484, 387);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(487, 58);
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
            this.btnClose.Location = new System.Drawing.Point(376, 308);
        
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(243, 308);
            this.btnPrint.Size = new System.Drawing.Size(130, 39);
            this.btnPrint.Text = "Preview";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 348);
            this.groupBox1.Size = new System.Drawing.Size(487, 25);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.dteToDate);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.dteFromDate);
            this.groupBox6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(248, 280);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(226, 86);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Period Seletion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(40, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "To:";
            // 
            // dteToDate
            // 
            this.dteToDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteToDate.Location = new System.Drawing.Point(81, 52);
            this.dteToDate.Name = "dteToDate";
            this.dteToDate.Size = new System.Drawing.Size(123, 22);
            this.dteToDate.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(19, 26);
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
            this.dteFromDate.Location = new System.Drawing.Point(81, 22);
            this.dteFromDate.Name = "dteFromDate";
            this.dteFromDate.Size = new System.Drawing.Size(123, 22);
            this.dteFromDate.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 14);
            this.label6.TabIndex = 14;
            this.label6.Text = "Ledger Name:";
            this.label6.Visible = false;
            // 
            // radAllLedger
            // 
            this.radAllLedger.AutoSize = true;
            this.radAllLedger.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAllLedger.Location = new System.Drawing.Point(93, 162);
            this.radAllLedger.Name = "radAllLedger";
            this.radAllLedger.Size = new System.Drawing.Size(90, 21);
            this.radAllLedger.TabIndex = 15;
            this.radAllLedger.TabStop = true;
            this.radAllLedger.Text = "&All Ledger";
            this.radAllLedger.UseVisualStyleBackColor = true;
            this.radAllLedger.Click += new System.EventHandler(this.radAllLedger_Click);
            // 
            // radbIndividualLedger
            // 
            this.radbIndividualLedger.AutoSize = true;
            this.radbIndividualLedger.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radbIndividualLedger.Location = new System.Drawing.Point(291, 162);
            this.radbIndividualLedger.Name = "radbIndividualLedger";
            this.radbIndividualLedger.Size = new System.Drawing.Size(134, 21);
            this.radbIndividualLedger.TabIndex = 16;
            this.radbIndividualLedger.TabStop = true;
            this.radbIndividualLedger.Text = "Individual Ledger";
            this.radbIndividualLedger.UseVisualStyleBackColor = true;
            this.radbIndividualLedger.Click += new System.EventHandler(this.radbIndividualLedger_Click);
            // 
            // uctxtLedgerConfig
            // 
            this.uctxtLedgerConfig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtLedgerConfig.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtLedgerConfig.Location = new System.Drawing.Point(15, 208);
            this.uctxtLedgerConfig.Name = "uctxtLedgerConfig";
            this.uctxtLedgerConfig.Size = new System.Drawing.Size(459, 23);
            this.uctxtLedgerConfig.TabIndex = 17;
            // 
            // frmRptBudget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(487, 373);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmRptBudget";
            this.Load += new System.EventHandler(this.frmRptAccountsLedger_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dteToDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dteFromDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radbIndividualLedger;
        private System.Windows.Forms.RadioButton radAllLedger;
        private System.Windows.Forms.TextBox uctxtLedgerConfig;
    }
}
