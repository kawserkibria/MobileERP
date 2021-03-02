namespace JA.Modulecontrolar.UI.DReport.Accms.ParameterForms
{
    partial class frmRptTargetAchievment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle43 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle47 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle48 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle44 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle45 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle46 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dteToDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dteFromDate = new System.Windows.Forms.DateTimePicker();
            this.uctxtBranch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radLedgerW = new System.Windows.Forms.RadioButton();
            this.radGroupwise = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radIndividual = new System.Windows.Forms.RadioButton();
            this.radAll = new System.Windows.Forms.RadioButton();
            this.uctxtLedgerConfig = new System.Windows.Forms.TextBox();
            this.chkStatus = new System.Windows.Forms.CheckBox();
            this.uctxtTerritoryCode = new System.Windows.Forms.TextBox();
            this.uctxtTeritorryName = new System.Windows.Forms.TextBox();
            this.DGMr = new MayhediControlLibrary.StandardDataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbxSelection = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGMr)).BeginInit();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(140, 1);
            this.frmLabel.Size = new System.Drawing.Size(322, 33);
            this.frmLabel.Text = "Sales && Collection Achieve";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.cbxSelection);
            this.pnlMain.Controls.Add(this.uctxtLedgerConfig);
            this.pnlMain.Controls.Add(this.DGMr);
            this.pnlMain.Controls.Add(this.uctxtTeritorryName);
            this.pnlMain.Controls.Add(this.uctxtTerritoryCode);
            this.pnlMain.Controls.Add(this.chkStatus);
            this.pnlMain.Controls.Add(this.groupBox2);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.uctxtBranch);
            this.pnlMain.Controls.Add(this.groupBox6);
            this.pnlMain.Controls.Add(this.groupBox3);
            this.pnlMain.Location = new System.Drawing.Point(0, -86);
            this.pnlMain.Size = new System.Drawing.Size(559, 519);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(564, 47);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(123, 410);
            this.btnEdit.Size = new System.Drawing.Size(14, 19);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(10, 410);
            this.btnSave.Size = new System.Drawing.Size(23, 19);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(166, 410);
            this.btnDelete.Size = new System.Drawing.Size(10, 14);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(39, 409);
            this.btnNew.Size = new System.Drawing.Size(36, 13);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(412, 441);
            this.btnClose.Size = new System.Drawing.Size(128, 39);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(278, 441);
            this.btnPrint.Size = new System.Drawing.Size(128, 39);
            this.btnPrint.Text = "Preview";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 490);
            this.groupBox1.Size = new System.Drawing.Size(564, 25);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.dteToDate);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.dteFromDate);
            this.groupBox6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(219, 403);
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
            this.uctxtBranch.Size = new System.Drawing.Size(389, 22);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radLedgerW);
            this.groupBox2.Controls.Add(this.radGroupwise);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(16, 166);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(522, 56);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Option";
            // 
            // radLedgerW
            // 
            this.radLedgerW.AutoSize = true;
            this.radLedgerW.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLedgerW.Location = new System.Drawing.Point(314, 21);
            this.radLedgerW.Name = "radLedgerW";
            this.radLedgerW.Size = new System.Drawing.Size(88, 18);
            this.radLedgerW.TabIndex = 2;
            this.radLedgerW.Text = "MPO Wise";
            this.radLedgerW.UseVisualStyleBackColor = true;
            this.radLedgerW.Click += new System.EventHandler(this.radLedgerW_Click);
            // 
            // radGroupwise
            // 
            this.radGroupwise.AutoSize = true;
            this.radGroupwise.Checked = true;
            this.radGroupwise.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupwise.Location = new System.Drawing.Point(82, 21);
            this.radGroupwise.Name = "radGroupwise";
            this.radGroupwise.Size = new System.Drawing.Size(98, 18);
            this.radGroupwise.TabIndex = 1;
            this.radGroupwise.TabStop = true;
            this.radGroupwise.Text = "Group Wise";
            this.radGroupwise.UseVisualStyleBackColor = true;
            this.radGroupwise.Click += new System.EventHandler(this.radGroupwise_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radIndividual);
            this.groupBox3.Controls.Add(this.radAll);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(16, 225);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(520, 62);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Selection";
            // 
            // radIndividual
            // 
            this.radIndividual.AutoSize = true;
            this.radIndividual.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radIndividual.Location = new System.Drawing.Point(314, 31);
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
            this.radAll.Location = new System.Drawing.Point(82, 31);
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
            this.uctxtLedgerConfig.Location = new System.Drawing.Point(18, 292);
            this.uctxtLedgerConfig.Name = "uctxtLedgerConfig";
            this.uctxtLedgerConfig.Size = new System.Drawing.Size(522, 25);
            this.uctxtLedgerConfig.TabIndex = 0;
            // 
            // chkStatus
            // 
            this.chkStatus.AutoSize = true;
            this.chkStatus.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkStatus.Location = new System.Drawing.Point(18, 416);
            this.chkStatus.Name = "chkStatus";
            this.chkStatus.Size = new System.Drawing.Size(76, 18);
            this.chkStatus.TabIndex = 15;
            this.chkStatus.Text = "Inactive";
            this.chkStatus.UseVisualStyleBackColor = true;
            // 
            // uctxtTerritoryCode
            // 
            this.uctxtTerritoryCode.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtTerritoryCode.Location = new System.Drawing.Point(46, 482);
            this.uctxtTerritoryCode.Name = "uctxtTerritoryCode";
            this.uctxtTerritoryCode.Size = new System.Drawing.Size(110, 22);
            this.uctxtTerritoryCode.TabIndex = 207;
            this.uctxtTerritoryCode.Visible = false;
            // 
            // uctxtTeritorryName
            // 
            this.uctxtTeritorryName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtTeritorryName.Location = new System.Drawing.Point(165, 482);
            this.uctxtTeritorryName.Name = "uctxtTeritorryName";
            this.uctxtTeritorryName.Size = new System.Drawing.Size(94, 22);
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
            dataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle43.BackColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle43.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle43.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle43.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGMr.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle43;
            this.DGMr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGMr.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15});
            dataGridViewCellStyle47.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle47.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle47.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle47.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle47.SelectionBackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle47.SelectionForeColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle47.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGMr.DefaultCellStyle = dataGridViewCellStyle47;
            this.DGMr.Location = new System.Drawing.Point(18, 323);
            this.DGMr.MultiSelect = false;
            this.DGMr.Name = "DGMr";
            this.DGMr.RowHeadersVisible = false;
            dataGridViewCellStyle48.BackColor = System.Drawing.Color.White;
            this.DGMr.RowsDefaultCellStyle = dataGridViewCellStyle48;
            this.DGMr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGMr.Size = new System.Drawing.Size(522, 23);
            this.DGMr.TabIndex = 209;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewCellStyle44.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle44;
            this.dataGridViewTextBoxColumn6.HeaderText = "Teritorry Code";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            dataGridViewCellStyle45.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn13.DefaultCellStyle = dataGridViewCellStyle45;
            this.dataGridViewTextBoxColumn13.HeaderText = "Teritorry name";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 130;
            // 
            // dataGridViewTextBoxColumn14
            // 
            dataGridViewCellStyle46.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn14.DefaultCellStyle = dataGridViewCellStyle46;
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
            // cbxSelection
            // 
            this.cbxSelection.Font = new System.Drawing.Font("Verdana", 9F);
            this.cbxSelection.FormattingEnabled = true;
            this.cbxSelection.Items.AddRange(new object[] {
            "ZONE",
            "DIVISION",
            "AREA",
            "MPO"});
            this.cbxSelection.Location = new System.Drawing.Point(157, 372);
            this.cbxSelection.Name = "cbxSelection";
            this.cbxSelection.Size = new System.Drawing.Size(163, 22);
            this.cbxSelection.TabIndex = 210;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 374);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 14);
            this.label4.TabIndex = 211;
            this.label4.Text = "Groupwise Summary:";
            // 
            // frmRptTargetAchievment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(564, 515);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmRptTargetAchievment";
            this.Load += new System.EventHandler(this.frmRptStoreLedger_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.DGMr)).EndInit();
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
        private System.Windows.Forms.CheckBox chkStatus;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radIndividual;
        private System.Windows.Forms.RadioButton radAll;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radLedgerW;
        private System.Windows.Forms.RadioButton radGroupwise;
        private System.Windows.Forms.TextBox uctxtLedgerConfig;
        private System.Windows.Forms.TextBox uctxtTeritorryName;
        private System.Windows.Forms.TextBox uctxtTerritoryCode;
        private MayhediControlLibrary.StandardDataGridView DGMr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxSelection;
    }
}
