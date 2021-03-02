namespace JA.Modulecontrolar.UI.DReport.Accms.ParameterForms
{
    partial class frmRptStatistics
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
            this.chkSorting = new System.Windows.Forms.CheckBox();
            this.pnlSummDet = new System.Windows.Forms.Panel();
            this.radSumm = new System.Windows.Forms.RadioButton();
            this.radDetails = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dteToDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dteFromDate = new System.Windows.Forms.DateTimePicker();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.pnlSummDet.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(136, 9);
            this.frmLabel.Size = new System.Drawing.Size(0, 33);
            this.frmLabel.Text = "";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.groupBox6);
            this.pnlMain.Location = new System.Drawing.Point(0, -86);
            this.pnlMain.Size = new System.Drawing.Size(456, 359);
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(459, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(53, 280);
            this.btnEdit.Size = new System.Drawing.Size(15, 20);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(53, 276);
            this.btnSave.Size = new System.Drawing.Size(10, 23);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(99, 283);
            this.btnDelete.Size = new System.Drawing.Size(10, 22);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(6, 283);
            this.btnNew.Size = new System.Drawing.Size(32, 17);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(346, 278);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(213, 278);
            this.btnPrint.Size = new System.Drawing.Size(130, 39);
            this.btnPrint.Text = "Preview";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 327);
            this.groupBox1.Size = new System.Drawing.Size(459, 25);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.chkSorting);
            this.groupBox6.Controls.Add(this.pnlSummDet);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.dteToDate);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.dteFromDate);
            this.groupBox6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(5, 150);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(441, 200);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Period Seletion";
            // 
            // chkSorting
            // 
            this.chkSorting.AutoSize = true;
            this.chkSorting.Location = new System.Drawing.Point(13, 40);
            this.chkSorting.Name = "chkSorting";
            this.chkSorting.Size = new System.Drawing.Size(168, 18);
            this.chkSorting.TabIndex = 25;
            this.chkSorting.Text = "Sorting  by Cheque No";
            this.chkSorting.UseVisualStyleBackColor = true;
            this.chkSorting.Visible = false;
            // 
            // pnlSummDet
            // 
            this.pnlSummDet.Controls.Add(this.radSumm);
            this.pnlSummDet.Controls.Add(this.radDetails);
            this.pnlSummDet.Location = new System.Drawing.Point(81, 140);
            this.pnlSummDet.Name = "pnlSummDet";
            this.pnlSummDet.Size = new System.Drawing.Size(354, 45);
            this.pnlSummDet.TabIndex = 24;
            this.pnlSummDet.Visible = false;
            // 
            // radSumm
            // 
            this.radSumm.AutoSize = true;
            this.radSumm.Location = new System.Drawing.Point(217, 12);
            this.radSumm.Name = "radSumm";
            this.radSumm.Size = new System.Drawing.Size(83, 18);
            this.radSumm.TabIndex = 1;
            this.radSumm.Text = "Summary";
            this.radSumm.UseVisualStyleBackColor = true;
            // 
            // radDetails
            // 
            this.radDetails.AutoSize = true;
            this.radDetails.Checked = true;
            this.radDetails.Location = new System.Drawing.Point(88, 13);
            this.radDetails.Name = "radDetails";
            this.radDetails.Size = new System.Drawing.Size(68, 18);
            this.radDetails.TabIndex = 0;
            this.radDetails.TabStop = true;
            this.radDetails.Text = "Details";
            this.radDetails.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(128, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "To:";
            // 
            // dteToDate
            // 
            this.dteToDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteToDate.Location = new System.Drawing.Point(168, 102);
            this.dteToDate.Name = "dteToDate";
            this.dteToDate.Size = new System.Drawing.Size(224, 22);
            this.dteToDate.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(107, 70);
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
            this.dteFromDate.Location = new System.Drawing.Point(168, 69);
            this.dteFromDate.Name = "dteFromDate";
            this.dteFromDate.Size = new System.Drawing.Size(224, 22);
            this.dteFromDate.TabIndex = 20;
            // 
            // frmRptStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(459, 352);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmRptStatistics";
            this.Load += new System.EventHandler(this.frmRptStatistics_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.pnlSummDet.ResumeLayout(false);
            this.pnlSummDet.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dteToDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dteFromDate;
        private System.Windows.Forms.Panel pnlSummDet;
        private System.Windows.Forms.RadioButton radSumm;
        private System.Windows.Forms.RadioButton radDetails;
        private System.Windows.Forms.CheckBox chkSorting;
    }
}
