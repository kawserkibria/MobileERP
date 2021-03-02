namespace JA.Modulecontrolar.UI.DReport.Purchase.ParameterForms
{
    partial class frmRptPurchaseRegister
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
            this.label8 = new System.Windows.Forms.Label();
            this.tetReportHader = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.uctxtMrName = new System.Windows.Forms.TextBox();
            this.uctxtTerritoryCode = new System.Windows.Forms.TextBox();
            this.DGMr = new MayhediControlLibrary.StandardDataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uctxtTeritorryName = new System.Windows.Forms.TextBox();
            this.chkboxSummary = new System.Windows.Forms.CheckBox();
            this.ChkboxNarr = new System.Windows.Forms.CheckBox();
            this.rbtnIndividualParty = new System.Windows.Forms.RadioButton();
            this.rbtnAll = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dteFromDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dteToDate = new System.Windows.Forms.DateTimePicker();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGMr)).BeginInit();
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
            this.pnlMain.Controls.Add(this.panel2);
            this.pnlMain.Controls.Add(this.label8);
            this.pnlMain.Controls.Add(this.tetReportHader);
            this.pnlMain.Location = new System.Drawing.Point(0, -86);
            this.pnlMain.Size = new System.Drawing.Size(555, 524);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.label9);
            this.pnlTop.Size = new System.Drawing.Size(555, 58);
            this.pnlTop.Controls.SetChildIndex(this.frmLabel, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnTopClose, 0);
            this.pnlTop.Controls.SetChildIndex(this.label9, 0);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(37, 315);
            this.btnEdit.Size = new System.Drawing.Size(10, 16);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(27, 315);
            this.btnSave.Size = new System.Drawing.Size(10, 18);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(47, 315);
            this.btnDelete.Size = new System.Drawing.Size(10, 16);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(21, 315);
            this.btnNew.Size = new System.Drawing.Size(10, 16);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(407, 443);
            this.btnClose.Size = new System.Drawing.Size(141, 38);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(258, 443);
            this.btnPrint.Size = new System.Drawing.Size(143, 39);
            this.btnPrint.Text = "Preview";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 486);
            this.groupBox1.Size = new System.Drawing.Size(555, 25);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 10F);
            this.label8.Location = new System.Drawing.Point(23, 157);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 17);
            this.label8.TabIndex = 23;
            this.label8.Text = "Report Header :";
            this.label8.Visible = false;
            // 
            // tetReportHader
            // 
            this.tetReportHader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tetReportHader.Location = new System.Drawing.Point(160, 157);
            this.tetReportHader.Name = "tetReportHader";
            this.tetReportHader.Size = new System.Drawing.Size(365, 23);
            this.tetReportHader.TabIndex = 22;
            this.tetReportHader.Visible = false;
            this.tetReportHader.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tetReportHader_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 20F);
            this.label9.Location = new System.Drawing.Point(143, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(258, 32);
            this.label9.TabIndex = 17;
            this.label9.Text = "Purchase Register";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.uctxtMrName);
            this.panel2.Controls.Add(this.uctxtTerritoryCode);
            this.panel2.Controls.Add(this.DGMr);
            this.panel2.Controls.Add(this.uctxtTeritorryName);
            this.panel2.Controls.Add(this.chkboxSummary);
            this.panel2.Controls.Add(this.ChkboxNarr);
            this.panel2.Controls.Add(this.rbtnIndividualParty);
            this.panel2.Controls.Add(this.rbtnAll);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dteFromDate);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dteToDate);
            this.panel2.Location = new System.Drawing.Point(11, 157);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(539, 362);
            this.panel2.TabIndex = 24;
            // 
            // uctxtMrName
            // 
            this.uctxtMrName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtMrName.Location = new System.Drawing.Point(15, 133);
            this.uctxtMrName.Name = "uctxtMrName";
            this.uctxtMrName.Size = new System.Drawing.Size(499, 22);
            this.uctxtMrName.TabIndex = 220;
            // 
            // uctxtTerritoryCode
            // 
            this.uctxtTerritoryCode.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtTerritoryCode.Location = new System.Drawing.Point(15, 206);
            this.uctxtTerritoryCode.Name = "uctxtTerritoryCode";
            this.uctxtTerritoryCode.Size = new System.Drawing.Size(10, 22);
            this.uctxtTerritoryCode.TabIndex = 221;
            this.uctxtTerritoryCode.Visible = false;
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
            this.DGMr.Location = new System.Drawing.Point(15, 161);
            this.DGMr.MultiSelect = false;
            this.DGMr.Name = "DGMr";
            this.DGMr.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            this.DGMr.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DGMr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGMr.Size = new System.Drawing.Size(499, 23);
            this.DGMr.TabIndex = 223;
            this.DGMr.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn6.HeaderText = "T.C";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // dataGridViewTextBoxColumn13
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn13.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn13.HeaderText = "MPO Name";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 275;
            // 
            // dataGridViewTextBoxColumn14
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn14.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn14.HeaderText = "T.Name";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 150;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.HeaderText = "String";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Visible = false;
            // 
            // uctxtTeritorryName
            // 
            this.uctxtTeritorryName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtTeritorryName.Location = new System.Drawing.Point(9, 215);
            this.uctxtTeritorryName.Name = "uctxtTeritorryName";
            this.uctxtTeritorryName.Size = new System.Drawing.Size(10, 22);
            this.uctxtTeritorryName.TabIndex = 222;
            this.uctxtTeritorryName.Visible = false;
            // 
            // chkboxSummary
            // 
            this.chkboxSummary.AutoSize = true;
            this.chkboxSummary.Font = new System.Drawing.Font("Verdana", 10F);
            this.chkboxSummary.Location = new System.Drawing.Point(329, 106);
            this.chkboxSummary.Name = "chkboxSummary";
            this.chkboxSummary.Size = new System.Drawing.Size(94, 21);
            this.chkboxSummary.TabIndex = 35;
            this.chkboxSummary.Text = "Summary";
            this.chkboxSummary.UseVisualStyleBackColor = true;
            // 
            // ChkboxNarr
            // 
            this.ChkboxNarr.AutoSize = true;
            this.ChkboxNarr.Font = new System.Drawing.Font("Verdana", 10F);
            this.ChkboxNarr.Location = new System.Drawing.Point(15, 78);
            this.ChkboxNarr.Name = "ChkboxNarr";
            this.ChkboxNarr.Size = new System.Drawing.Size(92, 21);
            this.ChkboxNarr.TabIndex = 34;
            this.ChkboxNarr.Text = "Narration";
            this.ChkboxNarr.UseVisualStyleBackColor = true;
            this.ChkboxNarr.Visible = false;
            // 
            // rbtnIndividualParty
            // 
            this.rbtnIndividualParty.AutoSize = true;
            this.rbtnIndividualParty.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnIndividualParty.Location = new System.Drawing.Point(156, 106);
            this.rbtnIndividualParty.Name = "rbtnIndividualParty";
            this.rbtnIndividualParty.Size = new System.Drawing.Size(133, 21);
            this.rbtnIndividualParty.TabIndex = 33;
            this.rbtnIndividualParty.Text = "Individual Party";
            this.rbtnIndividualParty.UseVisualStyleBackColor = true;
            this.rbtnIndividualParty.Click += new System.EventHandler(this.rbtnIndividualParty_Click);
            // 
            // rbtnAll
            // 
            this.rbtnAll.AutoSize = true;
            this.rbtnAll.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnAll.Location = new System.Drawing.Point(156, 78);
            this.rbtnAll.Name = "rbtnAll";
            this.rbtnAll.Size = new System.Drawing.Size(42, 21);
            this.rbtnAll.TabIndex = 3;
            this.rbtnAll.Text = "All";
            this.rbtnAll.UseVisualStyleBackColor = true;
            this.rbtnAll.Click += new System.EventHandler(this.rbtnAll_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 10F);
            this.label1.Location = new System.Drawing.Point(114, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 31;
            this.label1.Text = "From Date :";
            // 
            // dteFromDate
            // 
            this.dteFromDate.Font = new System.Drawing.Font("Verdana", 11F);
            this.dteFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteFromDate.Location = new System.Drawing.Point(223, 15);
            this.dteFromDate.Name = "dteFromDate";
            this.dteFromDate.Size = new System.Drawing.Size(200, 25);
            this.dteFromDate.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 10F);
            this.label4.Location = new System.Drawing.Point(12, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 17);
            this.label4.TabIndex = 29;
            this.label4.Text = "Party Name :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 10F);
            this.label3.Location = new System.Drawing.Point(134, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 27;
            this.label3.Text = "To Date :";
            // 
            // dteToDate
            // 
            this.dteToDate.Font = new System.Drawing.Font("Verdana", 11F);
            this.dteToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteToDate.Location = new System.Drawing.Point(223, 46);
            this.dteToDate.Name = "dteToDate";
            this.dteToDate.Size = new System.Drawing.Size(200, 25);
            this.dteToDate.TabIndex = 2;
            // 
            // frmRptPurchaseRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(555, 511);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmRptPurchaseRegister";
            this.Load += new System.EventHandler(this.frmRptStoreLedger_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGMr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tetReportHader;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkboxSummary;
        private System.Windows.Forms.CheckBox ChkboxNarr;
        private System.Windows.Forms.RadioButton rbtnIndividualParty;
        private System.Windows.Forms.RadioButton rbtnAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dteFromDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dteToDate;
        private System.Windows.Forms.TextBox uctxtMrName;
        private System.Windows.Forms.TextBox uctxtTerritoryCode;
        private MayhediControlLibrary.StandardDataGridView DGMr;
        private System.Windows.Forms.TextBox uctxtTeritorryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;

    }
}
