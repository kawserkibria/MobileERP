namespace JA.Modulecontrolar.UI.DReport.Accms.ParameterForms
{
    partial class frmRptCostCenter
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
            this.frmSelection = new System.Windows.Forms.GroupBox();
            this.radIndividual = new System.Windows.Forms.RadioButton();
            this.radAll = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dteToDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dteFromDate = new System.Windows.Forms.DateTimePicker();
            this.uctxtReportHeading = new System.Windows.Forms.TextBox();
            this.lblVoucherName = new System.Windows.Forms.Label();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.radSummary = new System.Windows.Forms.RadioButton();
            this.radDetails = new System.Windows.Forms.RadioButton();
            this.uctxtBranchName = new System.Windows.Forms.TextBox();
            this.lblBranchname = new System.Windows.Forms.Label();
            this.uctxtCostCenterName = new System.Windows.Forms.TextBox();
            this.lblCostCenterName = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.frmSelection.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.grpDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmLabel.Location = new System.Drawing.Point(157, 5);
            this.frmLabel.Size = new System.Drawing.Size(166, 18);
            this.frmLabel.Text = "Cost Center Ledger";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.lblCostCenterName);
            this.pnlMain.Controls.Add(this.uctxtCostCenterName);
            this.pnlMain.Controls.Add(this.lblBranchname);
            this.pnlMain.Controls.Add(this.uctxtBranchName);
            this.pnlMain.Controls.Add(this.grpDetails);
            this.pnlMain.Controls.Add(this.lblVoucherName);
            this.pnlMain.Controls.Add(this.uctxtReportHeading);
            this.pnlMain.Controls.Add(this.frmSelection);
            this.pnlMain.Controls.Add(this.groupBox6);
            this.pnlMain.Location = new System.Drawing.Point(0, -86);
            this.pnlMain.Size = new System.Drawing.Size(484, 359);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(487, 35);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(137, 279);
            this.btnEdit.Size = new System.Drawing.Size(12, 10);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(24, 293);
            this.btnSave.Size = new System.Drawing.Size(10, 23);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(129, 293);
            this.btnDelete.Size = new System.Drawing.Size(10, 13);
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(21, 279);
            this.btnNew.Size = new System.Drawing.Size(10, 10);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(372, 279);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(243, 279);
            this.btnPrint.Size = new System.Drawing.Size(126, 39);
            this.btnPrint.Text = "Preview";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 324);
            this.groupBox1.Size = new System.Drawing.Size(487, 25);
            // 
            // frmSelection
            // 
            this.frmSelection.Controls.Add(this.radIndividual);
            this.frmSelection.Controls.Add(this.radAll);
            this.frmSelection.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmSelection.Location = new System.Drawing.Point(16, 156);
            this.frmSelection.Name = "frmSelection";
            this.frmSelection.Size = new System.Drawing.Size(256, 44);
            this.frmSelection.TabIndex = 10;
            this.frmSelection.TabStop = false;
            this.frmSelection.Text = "Seletion";
            this.frmSelection.Visible = false;
            // 
            // radIndividual
            // 
            this.radIndividual.AutoSize = true;
            this.radIndividual.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radIndividual.Location = new System.Drawing.Point(144, 20);
            this.radIndividual.Name = "radIndividual";
            this.radIndividual.Size = new System.Drawing.Size(86, 18);
            this.radIndividual.TabIndex = 5;
            this.radIndividual.Text = "Individual";
            this.radIndividual.UseVisualStyleBackColor = true;
            this.radIndividual.Click += new System.EventHandler(this.radIndividual_Click);
            // 
            // radAll
            // 
            this.radAll.AutoSize = true;
            this.radAll.Checked = true;
            this.radAll.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAll.Location = new System.Drawing.Point(49, 20);
            this.radAll.Name = "radAll";
            this.radAll.Size = new System.Drawing.Size(43, 18);
            this.radAll.TabIndex = 3;
            this.radAll.TabStop = true;
            this.radAll.Text = "All ";
            this.radAll.UseVisualStyleBackColor = true;
            this.radAll.CheckedChanged += new System.EventHandler(this.radAll_CheckedChanged);
            this.radAll.Click += new System.EventHandler(this.radAll_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.dteToDate);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.dteFromDate);
            this.groupBox6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(11, 255);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(234, 81);
            this.groupBox6.TabIndex = 9;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Period Seletion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(38, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "To:";
            // 
            // dteToDate
            // 
            this.dteToDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteToDate.Location = new System.Drawing.Point(75, 53);
            this.dteToDate.Name = "dteToDate";
            this.dteToDate.Size = new System.Drawing.Size(120, 22);
            this.dteToDate.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(18, 30);
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
            this.dteFromDate.Location = new System.Drawing.Point(75, 30);
            this.dteFromDate.Name = "dteFromDate";
            this.dteFromDate.Size = new System.Drawing.Size(120, 22);
            this.dteFromDate.TabIndex = 20;
            // 
            // uctxtReportHeading
            // 
            this.uctxtReportHeading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtReportHeading.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtReportHeading.Location = new System.Drawing.Point(11, 222);
            this.uctxtReportHeading.Name = "uctxtReportHeading";
            this.uctxtReportHeading.Size = new System.Drawing.Size(234, 22);
            this.uctxtReportHeading.TabIndex = 12;
            // 
            // lblVoucherName
            // 
            this.lblVoucherName.AutoSize = true;
            this.lblVoucherName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVoucherName.Location = new System.Drawing.Point(20, 205);
            this.lblVoucherName.Name = "lblVoucherName";
            this.lblVoucherName.Size = new System.Drawing.Size(100, 13);
            this.lblVoucherName.TabIndex = 13;
            this.lblVoucherName.Text = "Report Heading:";
            // 
            // grpDetails
            // 
            this.grpDetails.Controls.Add(this.radSummary);
            this.grpDetails.Controls.Add(this.radDetails);
            this.grpDetails.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDetails.Location = new System.Drawing.Point(272, 156);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(207, 45);
            this.grpDetails.TabIndex = 14;
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "Seletion";
            this.grpDetails.Visible = false;
            // 
            // radSummary
            // 
            this.radSummary.AutoSize = true;
            this.radSummary.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSummary.Location = new System.Drawing.Point(116, 20);
            this.radSummary.Name = "radSummary";
            this.radSummary.Size = new System.Drawing.Size(83, 18);
            this.radSummary.TabIndex = 5;
            this.radSummary.Text = "Summary";
            this.radSummary.UseVisualStyleBackColor = true;
            // 
            // radDetails
            // 
            this.radDetails.AutoSize = true;
            this.radDetails.Checked = true;
            this.radDetails.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radDetails.Location = new System.Drawing.Point(20, 20);
            this.radDetails.Name = "radDetails";
            this.radDetails.Size = new System.Drawing.Size(68, 18);
            this.radDetails.TabIndex = 3;
            this.radDetails.TabStop = true;
            this.radDetails.Text = "Details";
            this.radDetails.UseVisualStyleBackColor = true;
            // 
            // uctxtBranchName
            // 
            this.uctxtBranchName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtBranchName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtBranchName.Location = new System.Drawing.Point(123, 126);
            this.uctxtBranchName.Name = "uctxtBranchName";
            this.uctxtBranchName.Size = new System.Drawing.Size(292, 22);
            this.uctxtBranchName.TabIndex = 15;
            // 
            // lblBranchname
            // 
            this.lblBranchname.AutoSize = true;
            this.lblBranchname.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBranchname.Location = new System.Drawing.Point(28, 130);
            this.lblBranchname.Name = "lblBranchname";
            this.lblBranchname.Size = new System.Drawing.Size(89, 13);
            this.lblBranchname.TabIndex = 16;
            this.lblBranchname.Text = "Branch Name:";
            // 
            // uctxtCostCenterName
            // 
            this.uctxtCostCenterName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtCostCenterName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtCostCenterName.Location = new System.Drawing.Point(254, 222);
            this.uctxtCostCenterName.Name = "uctxtCostCenterName";
            this.uctxtCostCenterName.Size = new System.Drawing.Size(222, 22);
            this.uctxtCostCenterName.TabIndex = 17;
            this.uctxtCostCenterName.Visible = false;
            // 
            // lblCostCenterName
            // 
            this.lblCostCenterName.AutoSize = true;
            this.lblCostCenterName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostCenterName.Location = new System.Drawing.Point(258, 203);
            this.lblCostCenterName.Name = "lblCostCenterName";
            this.lblCostCenterName.Size = new System.Drawing.Size(40, 13);
            this.lblCostCenterName.TabIndex = 18;
            this.lblCostCenterName.Text = "Name";
            this.lblCostCenterName.Visible = false;
            // 
            // frmRptCostCenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(487, 349);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmRptCostCenter";
            this.Load += new System.EventHandler(this.frmRptStoreLedger_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.frmSelection.ResumeLayout(false);
            this.frmSelection.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblVoucherName;
        private System.Windows.Forms.TextBox uctxtReportHeading;
        private System.Windows.Forms.GroupBox frmSelection;
        private System.Windows.Forms.RadioButton radIndividual;
        private System.Windows.Forms.RadioButton radAll;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dteToDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dteFromDate;
        private System.Windows.Forms.Label lblCostCenterName;
        private System.Windows.Forms.TextBox uctxtCostCenterName;
        private System.Windows.Forms.Label lblBranchname;
        private System.Windows.Forms.TextBox uctxtBranchName;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.RadioButton radSummary;
        private System.Windows.Forms.RadioButton radDetails;

    }
}
