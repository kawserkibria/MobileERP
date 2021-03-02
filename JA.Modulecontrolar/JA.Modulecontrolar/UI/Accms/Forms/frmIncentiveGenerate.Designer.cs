namespace JA.Modulecontrolar.UI.Accms.Forms
{
    partial class frmIncentiveGenerate
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblName = new System.Windows.Forms.Label();
            this.dteImportDate = new System.Windows.Forms.DateTimePicker();
            this.txtLedgerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radMonthly = new System.Windows.Forms.RadioButton();
            this.radYearly = new System.Windows.Forms.RadioButton();
            this.radYearlyExtra = new System.Windows.Forms.RadioButton();
            this.label21 = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnIncentiveConfig = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmLabel.Location = new System.Drawing.Point(147, 7);
            this.frmLabel.Size = new System.Drawing.Size(210, 23);
            this.frmLabel.Text = "Incentive Generation";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnIncentiveConfig);
            this.pnlMain.Controls.Add(this.button1);
            this.pnlMain.Controls.Add(this.label21);
            this.pnlMain.Controls.Add(this.cboType);
            this.pnlMain.Controls.Add(this.radYearlyExtra);
            this.pnlMain.Controls.Add(this.radYearly);
            this.pnlMain.Controls.Add(this.radMonthly);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.txtLedgerName);
            this.pnlMain.Controls.Add(this.progressBar1);
            this.pnlMain.Controls.Add(this.lblName);
            this.pnlMain.Controls.Add(this.dteImportDate);
            this.pnlMain.Size = new System.Drawing.Size(501, 402);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(503, 42);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(246, 318);
            this.btnEdit.Size = new System.Drawing.Size(128, 40);
            this.btnEdit.Text = "Generate";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(6, 318);
            this.btnSave.Size = new System.Drawing.Size(121, 41);
            this.btnSave.Text = "List All";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(109, 5);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(61, 6);
            this.btnNew.Size = new System.Drawing.Size(10, 10);
            this.btnNew.Text = "Generate";
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(376, 319);
            this.btnClose.Size = new System.Drawing.Size(123, 40);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(103, 15);
            this.btnPrint.Size = new System.Drawing.Size(10, 10);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 359);
            this.groupBox1.Size = new System.Drawing.Size(503, 25);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(19, 315);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(461, 23);
            this.progressBar1.TabIndex = 10;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(142, 167);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(42, 14);
            this.lblName.TabIndex = 9;
            this.lblName.Text = "Date:";
            // 
            // dteImportDate
            // 
            this.dteImportDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteImportDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteImportDate.Location = new System.Drawing.Point(190, 163);
            this.dteImportDate.Name = "dteImportDate";
            this.dteImportDate.Size = new System.Drawing.Size(173, 22);
            this.dteImportDate.TabIndex = 8;
            // 
            // txtLedgerName
            // 
            this.txtLedgerName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLedgerName.Location = new System.Drawing.Point(116, 232);
            this.txtLedgerName.Name = "txtLedgerName";
            this.txtLedgerName.Size = new System.Drawing.Size(364, 22);
            this.txtLedgerName.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 235);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 14);
            this.label1.TabIndex = 14;
            this.label1.Text = "MPO Name:";
            // 
            // radMonthly
            // 
            this.radMonthly.AutoSize = true;
            this.radMonthly.Checked = true;
            this.radMonthly.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radMonthly.Location = new System.Drawing.Point(16, 146);
            this.radMonthly.Name = "radMonthly";
            this.radMonthly.Size = new System.Drawing.Size(69, 17);
            this.radMonthly.TabIndex = 15;
            this.radMonthly.TabStop = true;
            this.radMonthly.Text = "Monthly";
            this.radMonthly.UseVisualStyleBackColor = true;
            // 
            // radYearly
            // 
            this.radYearly.AutoSize = true;
            this.radYearly.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radYearly.Location = new System.Drawing.Point(16, 169);
            this.radYearly.Name = "radYearly";
            this.radYearly.Size = new System.Drawing.Size(60, 17);
            this.radYearly.TabIndex = 16;
            this.radYearly.Text = "Yearly";
            this.radYearly.UseVisualStyleBackColor = true;
            // 
            // radYearlyExtra
            // 
            this.radYearlyExtra.AutoSize = true;
            this.radYearlyExtra.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radYearlyExtra.Location = new System.Drawing.Point(16, 192);
            this.radYearlyExtra.Name = "radYearlyExtra";
            this.radYearlyExtra.Size = new System.Drawing.Size(94, 17);
            this.radYearlyExtra.TabIndex = 17;
            this.radYearlyExtra.Text = "Yearly Extra";
            this.radYearlyExtra.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(138, 139);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(46, 16);
            this.label21.TabIndex = 19;
            this.label21.Text = "Type:";
            // 
            // cboType
            // 
            this.cboType.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboType.FormattingEnabled = true;
            this.cboType.Items.AddRange(new object[] {
            "MPO",
            "AH",
            "DH"});
            this.cboType.Location = new System.Drawing.Point(190, 139);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(226, 22);
            this.cboType.TabIndex = 18;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnIncentiveConfig
            // 
            this.btnIncentiveConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnIncentiveConfig.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncentiveConfig.Location = new System.Drawing.Point(416, 138);
            this.btnIncentiveConfig.Name = "btnIncentiveConfig";
            this.btnIncentiveConfig.Size = new System.Drawing.Size(27, 24);
            this.btnIncentiveConfig.TabIndex = 21;
            this.btnIncentiveConfig.Text = "&C";
            this.btnIncentiveConfig.UseVisualStyleBackColor = false;
            this.btnIncentiveConfig.Click += new System.EventHandler(this.btnIncentiveConfig_Click);
            // 
            // frmIncentiveGenerate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(503, 384);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmIncentiveGenerate";
            this.Load += new System.EventHandler(this.frmIncentiveGenerate_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.DateTimePicker dteImportDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLedgerName;
        private System.Windows.Forms.RadioButton radYearlyExtra;
        private System.Windows.Forms.RadioButton radYearly;
        private System.Windows.Forms.RadioButton radMonthly;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Button btnIncentiveConfig;
        private System.Windows.Forms.Button button1;

    }
}
