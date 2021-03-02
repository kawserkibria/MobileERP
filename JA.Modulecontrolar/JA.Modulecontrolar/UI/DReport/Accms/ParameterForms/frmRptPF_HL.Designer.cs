namespace JA.Modulecontrolar.UI.DReport.Accms.ParameterForms
{
    partial class frmRptPF_HL
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dteToDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dteFromDate = new System.Windows.Forms.DateTimePicker();
            this.uctxtBranch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radIndividual = new System.Windows.Forms.RadioButton();
            this.radAll = new System.Windows.Forms.RadioButton();
            this.uctxtLedgerConfig = new System.Windows.Forms.TextBox();
            this.uctxtTerritoryCode = new System.Windows.Forms.TextBox();
            this.uctxtTeritorryName = new System.Windows.Forms.TextBox();
            this.DGMr = new MayhediControlLibrary.StandardDataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.chkboxClosing = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.optAll = new System.Windows.Forms.RadioButton();
            this.radInactive = new System.Windows.Forms.RadioButton();
            this.radActive = new System.Windows.Forms.RadioButton();
            this.chkboxDetails = new System.Windows.Forms.CheckBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGMr)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(177, 1);
            this.frmLabel.Size = new System.Drawing.Size(258, 33);
            this.frmLabel.Text = "HL && PF Information";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.chkboxDetails);
            this.pnlMain.Controls.Add(this.groupBox2);
            this.pnlMain.Controls.Add(this.chkboxClosing);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.uctxtLedgerConfig);
            this.pnlMain.Controls.Add(this.DGMr);
            this.pnlMain.Controls.Add(this.uctxtTeritorryName);
            this.pnlMain.Controls.Add(this.uctxtTerritoryCode);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.uctxtBranch);
            this.pnlMain.Controls.Add(this.groupBox6);
            this.pnlMain.Controls.Add(this.groupBox3);
            this.pnlMain.Location = new System.Drawing.Point(0, -86);
            this.pnlMain.Size = new System.Drawing.Size(559, 508);
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(560, 47);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(123, 271);
            this.btnEdit.Size = new System.Drawing.Size(14, 19);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(10, 271);
            this.btnSave.Size = new System.Drawing.Size(10, 10);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(166, 218);
            this.btnDelete.Size = new System.Drawing.Size(10, 14);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(39, 270);
            this.btnNew.Size = new System.Drawing.Size(10, 10);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(431, 428);
            this.btnClose.Size = new System.Drawing.Size(128, 39);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(297, 428);
            this.btnPrint.Size = new System.Drawing.Size(128, 39);
            this.btnPrint.Text = "Preview";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 473);
            this.groupBox1.Size = new System.Drawing.Size(560, 25);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.dteToDate);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.dteFromDate);
            this.groupBox6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(219, 417);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(321, 76);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Period Seletion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(105, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "To:";
            // 
            // dteToDate
            // 
            this.dteToDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteToDate.Location = new System.Drawing.Point(161, 49);
            this.dteToDate.Name = "dteToDate";
            this.dteToDate.Size = new System.Drawing.Size(129, 22);
            this.dteToDate.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(91, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "From:";
            // 
            // dteFromDate
            // 
            this.dteFromDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteFromDate.Location = new System.Drawing.Point(161, 21);
            this.dteFromDate.Name = "dteFromDate";
            this.dteFromDate.Size = new System.Drawing.Size(129, 22);
            this.dteFromDate.TabIndex = 20;
            // 
            // uctxtBranch
            // 
            this.uctxtBranch.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtBranch.Location = new System.Drawing.Point(147, 139);
            this.uctxtBranch.Name = "uctxtBranch";
            this.uctxtBranch.Size = new System.Drawing.Size(317, 22);
            this.uctxtBranch.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(47, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "Branch Name:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radIndividual);
            this.groupBox3.Controls.Add(this.radAll);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(16, 164);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(356, 46);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Selection";
            // 
            // radIndividual
            // 
            this.radIndividual.AutoSize = true;
            this.radIndividual.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radIndividual.Location = new System.Drawing.Point(229, 16);
            this.radIndividual.Name = "radIndividual";
            this.radIndividual.Size = new System.Drawing.Size(86, 18);
            this.radIndividual.TabIndex = 2;
            this.radIndividual.Text = "Individual";
            this.radIndividual.UseVisualStyleBackColor = true;
            this.radIndividual.Click += new System.EventHandler(this.radIndividual_Click);
            // 
            // radAll
            // 
            this.radAll.AutoSize = true;
            this.radAll.Checked = true;
            this.radAll.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAll.Location = new System.Drawing.Point(131, 16);
            this.radAll.Name = "radAll";
            this.radAll.Size = new System.Drawing.Size(43, 18);
            this.radAll.TabIndex = 1;
            this.radAll.TabStop = true;
            this.radAll.Text = "All ";
            this.radAll.UseVisualStyleBackColor = true;
            this.radAll.Click += new System.EventHandler(this.radAll_Click);
            // 
            // uctxtLedgerConfig
            // 
            this.uctxtLedgerConfig.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtLedgerConfig.Location = new System.Drawing.Point(16, 274);
            this.uctxtLedgerConfig.Name = "uctxtLedgerConfig";
            this.uctxtLedgerConfig.Size = new System.Drawing.Size(522, 25);
            this.uctxtLedgerConfig.TabIndex = 0;
            // 
            // uctxtTerritoryCode
            // 
            this.uctxtTerritoryCode.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtTerritoryCode.Location = new System.Drawing.Point(48, 322);
            this.uctxtTerritoryCode.Name = "uctxtTerritoryCode";
            this.uctxtTerritoryCode.Size = new System.Drawing.Size(10, 22);
            this.uctxtTerritoryCode.TabIndex = 207;
            this.uctxtTerritoryCode.Visible = false;
            // 
            // uctxtTeritorryName
            // 
            this.uctxtTeritorryName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtTeritorryName.Location = new System.Drawing.Point(64, 316);
            this.uctxtTeritorryName.Name = "uctxtTeritorryName";
            this.uctxtTeritorryName.Size = new System.Drawing.Size(10, 22);
            this.uctxtTeritorryName.TabIndex = 208;
            this.uctxtTeritorryName.Visible = false;
            // 
            // DGMr
            // 
            this.DGMr.AllowUserToAddRows = false;
            this.DGMr.AllowUserToDeleteRows = false;
            this.DGMr.AllowUserToOrderColumns = true;
            this.DGMr.AllowUserToResizeColumns = false;
            this.DGMr.AllowUserToResizeRows = false;
            this.DGMr.BackgroundColor = System.Drawing.Color.White;
            this.DGMr.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGMr.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGMr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGMr.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGMr.DefaultCellStyle = dataGridViewCellStyle5;
            this.DGMr.Location = new System.Drawing.Point(16, 305);
            this.DGMr.MultiSelect = false;
            this.DGMr.Name = "DGMr";
            this.DGMr.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            this.DGMr.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DGMr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGMr.Size = new System.Drawing.Size(522, 23);
            this.DGMr.TabIndex = 209;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn6.HeaderText = "Teritorry Code";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn13.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn13.HeaderText = "Teritorry name";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 130;
            // 
            // dataGridViewTextBoxColumn14
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn14.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn14.HeaderText = "MPO Name";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 500;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.HeaderText = "String";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 257);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 14);
            this.label4.TabIndex = 210;
            this.label4.Text = "MPO Name:";
            // 
            // chkboxClosing
            // 
            this.chkboxClosing.AutoSize = true;
            this.chkboxClosing.Font = new System.Drawing.Font("Verdana", 9F);
            this.chkboxClosing.Location = new System.Drawing.Point(382, 170);
            this.chkboxClosing.Name = "chkboxClosing";
            this.chkboxClosing.Size = new System.Drawing.Size(160, 18);
            this.chkboxClosing.TabIndex = 211;
            this.chkboxClosing.Text = "MPO Final Settlement";
            this.chkboxClosing.UseVisualStyleBackColor = true;
            this.chkboxClosing.Click += new System.EventHandler(this.chkboxClosing_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.optAll);
            this.groupBox2.Controls.Add(this.radInactive);
            this.groupBox2.Controls.Add(this.radActive);
            this.groupBox2.Location = new System.Drawing.Point(16, 215);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(522, 39);
            this.groupBox2.TabIndex = 215;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // optAll
            // 
            this.optAll.AutoSize = true;
            this.optAll.Checked = true;
            this.optAll.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optAll.Location = new System.Drawing.Point(131, 15);
            this.optAll.Name = "optAll";
            this.optAll.Size = new System.Drawing.Size(39, 18);
            this.optAll.TabIndex = 2;
            this.optAll.TabStop = true;
            this.optAll.Text = "All";
            this.optAll.UseVisualStyleBackColor = true;
            this.optAll.Click += new System.EventHandler(this.optAll_Click);
            // 
            // radInactive
            // 
            this.radInactive.AutoSize = true;
            this.radInactive.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radInactive.Location = new System.Drawing.Point(285, 15);
            this.radInactive.Name = "radInactive";
            this.radInactive.Size = new System.Drawing.Size(75, 18);
            this.radInactive.TabIndex = 1;
            this.radInactive.Text = "Inactive";
            this.radInactive.UseVisualStyleBackColor = true;
            this.radInactive.Click += new System.EventHandler(this.radInactive_Click);
            // 
            // radActive
            // 
            this.radActive.AutoSize = true;
            this.radActive.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radActive.Location = new System.Drawing.Point(204, 15);
            this.radActive.Name = "radActive";
            this.radActive.Size = new System.Drawing.Size(62, 18);
            this.radActive.TabIndex = 0;
            this.radActive.Text = "Active";
            this.radActive.UseVisualStyleBackColor = true;
            this.radActive.Click += new System.EventHandler(this.radActive_Click);
            // 
            // chkboxDetails
            // 
            this.chkboxDetails.AutoSize = true;
            this.chkboxDetails.Font = new System.Drawing.Font("Verdana", 9F);
            this.chkboxDetails.Location = new System.Drawing.Point(382, 194);
            this.chkboxDetails.Name = "chkboxDetails";
            this.chkboxDetails.Size = new System.Drawing.Size(69, 18);
            this.chkboxDetails.TabIndex = 216;
            this.chkboxDetails.Text = "Details";
            this.chkboxDetails.UseVisualStyleBackColor = true;
            // 
            // frmRptPF_HL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(560, 498);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmRptPF_HL";
            this.Load += new System.EventHandler(this.frmRptStoreLedger_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGMr)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dteToDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dteFromDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uctxtBranch;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radIndividual;
        private System.Windows.Forms.RadioButton radAll;
        private System.Windows.Forms.TextBox uctxtLedgerConfig;
        private System.Windows.Forms.TextBox uctxtTeritorryName;
        private System.Windows.Forms.TextBox uctxtTerritoryCode;
        private MayhediControlLibrary.StandardDataGridView DGMr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkboxClosing;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton optAll;
        private System.Windows.Forms.RadioButton radInactive;
        private System.Windows.Forms.RadioButton radActive;
        private System.Windows.Forms.CheckBox chkboxDetails;
    }
}
