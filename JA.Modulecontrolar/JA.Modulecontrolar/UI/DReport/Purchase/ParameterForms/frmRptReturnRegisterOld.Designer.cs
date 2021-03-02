namespace JA.Modulecontrolar.UI.DReport.Purchase.ParameterForms
{
    partial class frmRptReturnRegisterOld
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
            this.label8 = new System.Windows.Forms.Label();
            this.tetReportHader = new System.Windows.Forms.TextBox();
            this.dteToDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.uctxtMedicalRep = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dteFromDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtnAll = new System.Windows.Forms.RadioButton();
            this.rbtnIndividualParty = new System.Windows.Forms.RadioButton();
            this.ChkboxNarr = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkboxSummary = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.pnlMain.Controls.Add(this.label8);
            this.pnlMain.Controls.Add(this.tetReportHader);
            this.pnlMain.Controls.Add(this.groupBox2);
            this.pnlMain.Location = new System.Drawing.Point(0, -86);
            this.pnlMain.Size = new System.Drawing.Size(555, 454);
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
            this.btnEdit.Size = new System.Drawing.Size(10, 39);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(27, 315);
            this.btnSave.Size = new System.Drawing.Size(10, 39);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(47, 315);
            this.btnDelete.Size = new System.Drawing.Size(10, 39);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(21, 315);
            this.btnNew.Size = new System.Drawing.Size(10, 39);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(275, 315);
            this.btnClose.Size = new System.Drawing.Size(153, 38);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(118, 315);
            this.btnPrint.Size = new System.Drawing.Size(155, 38);
            this.btnPrint.Text = "Preview";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 369);
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
            // 
            // tetReportHader
            // 
            this.tetReportHader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tetReportHader.Location = new System.Drawing.Point(160, 157);
            this.tetReportHader.Name = "tetReportHader";
            this.tetReportHader.Size = new System.Drawing.Size(365, 23);
            this.tetReportHader.TabIndex = 22;
            // 
            // dteToDate
            // 
            this.dteToDate.Font = new System.Drawing.Font("Verdana", 11F);
            this.dteToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteToDate.Location = new System.Drawing.Point(155, 50);
            this.dteToDate.Name = "dteToDate";
            this.dteToDate.Size = new System.Drawing.Size(200, 25);
            this.dteToDate.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 10F);
            this.label3.Location = new System.Drawing.Point(66, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "To Date :";
            // 
            // uctxtMedicalRep
            // 
            this.uctxtMedicalRep.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtMedicalRep.Location = new System.Drawing.Point(155, 172);
            this.uctxtMedicalRep.Name = "uctxtMedicalRep";
            this.uctxtMedicalRep.Size = new System.Drawing.Size(365, 23);
            this.uctxtMedicalRep.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 10F);
            this.label4.Location = new System.Drawing.Point(40, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "Party Name :";
            // 
            // dteFromDate
            // 
            this.dteFromDate.Font = new System.Drawing.Font("Verdana", 11F);
            this.dteFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteFromDate.Location = new System.Drawing.Point(155, 19);
            this.dteFromDate.Name = "dteFromDate";
            this.dteFromDate.Size = new System.Drawing.Size(200, 25);
            this.dteFromDate.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 10F);
            this.label1.Location = new System.Drawing.Point(46, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "From Date :";
            // 
            // rbtnAll
            // 
            this.rbtnAll.AutoSize = true;
            this.rbtnAll.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnAll.Location = new System.Drawing.Point(155, 90);
            this.rbtnAll.Name = "rbtnAll";
            this.rbtnAll.Size = new System.Drawing.Size(42, 21);
            this.rbtnAll.TabIndex = 21;
            this.rbtnAll.Text = "All";
            this.rbtnAll.UseVisualStyleBackColor = true;
            this.rbtnAll.Click += new System.EventHandler(this.rbtnAll_Click);
            // 
            // rbtnIndividualParty
            // 
            this.rbtnIndividualParty.AutoSize = true;
            this.rbtnIndividualParty.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnIndividualParty.Location = new System.Drawing.Point(155, 118);
            this.rbtnIndividualParty.Name = "rbtnIndividualParty";
            this.rbtnIndividualParty.Size = new System.Drawing.Size(133, 21);
            this.rbtnIndividualParty.TabIndex = 22;
            this.rbtnIndividualParty.Text = "Individual Party";
            this.rbtnIndividualParty.UseVisualStyleBackColor = true;
            this.rbtnIndividualParty.Click += new System.EventHandler(this.rbtnIndividualParty_Click);
            // 
            // ChkboxNarr
            // 
            this.ChkboxNarr.AutoSize = true;
            this.ChkboxNarr.Font = new System.Drawing.Font("Verdana", 10F);
            this.ChkboxNarr.Location = new System.Drawing.Point(155, 145);
            this.ChkboxNarr.Name = "ChkboxNarr";
            this.ChkboxNarr.Size = new System.Drawing.Size(92, 21);
            this.ChkboxNarr.TabIndex = 24;
            this.ChkboxNarr.Text = "Narration";
            this.ChkboxNarr.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkboxSummary);
            this.groupBox2.Controls.Add(this.ChkboxNarr);
            this.groupBox2.Controls.Add(this.rbtnIndividualParty);
            this.groupBox2.Controls.Add(this.rbtnAll);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dteFromDate);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.uctxtMedicalRep);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dteToDate);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(5, 177);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(545, 206);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            // 
            // chkboxSummary
            // 
            this.chkboxSummary.AutoSize = true;
            this.chkboxSummary.Font = new System.Drawing.Font("Verdana", 10F);
            this.chkboxSummary.Location = new System.Drawing.Point(328, 118);
            this.chkboxSummary.Name = "chkboxSummary";
            this.chkboxSummary.Size = new System.Drawing.Size(94, 21);
            this.chkboxSummary.TabIndex = 25;
            this.chkboxSummary.Text = "Summary";
            this.chkboxSummary.UseVisualStyleBackColor = true;
            this.chkboxSummary.Click += new System.EventHandler(this.chkboxSummary_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 14F);
            this.label9.Location = new System.Drawing.Point(203, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(158, 23);
            this.label9.TabIndex = 17;
            this.label9.Text = "Return Register";
            // 
            // frmRptReturnRegisterOld
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(555, 394);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmRptReturnRegisterOld";
            this.Load += new System.EventHandler(this.frmRptStoreLedger_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tetReportHader;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkboxSummary;
        private System.Windows.Forms.CheckBox ChkboxNarr;
        private System.Windows.Forms.RadioButton rbtnIndividualParty;
        private System.Windows.Forms.RadioButton rbtnAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dteFromDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox uctxtMedicalRep;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dteToDate;
        private System.Windows.Forms.Label label9;

    }
}
