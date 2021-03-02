namespace JA.Modulecontrolar.UI.DReport.Accms.ParameterForms
{
    partial class frmRptAccounts
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
            this.chkSqpCls = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dteToDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dteFromDate = new System.Windows.Forms.DateTimePicker();
            this.grpHorVer = new System.Windows.Forms.GroupBox();
            this.radVertical = new System.Windows.Forms.RadioButton();
            this.radHor = new System.Windows.Forms.RadioButton();
            this.frmSelection = new System.Windows.Forms.GroupBox();
            this.radDetails = new System.Windows.Forms.RadioButton();
            this.radSumm = new System.Windows.Forms.RadioButton();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.grpHorVer.SuspendLayout();
            this.frmSelection.SuspendLayout();
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
            this.pnlMain.Controls.Add(this.frmSelection);
            this.pnlMain.Controls.Add(this.grpHorVer);
            this.pnlMain.Controls.Add(this.groupBox6);
            this.pnlMain.Location = new System.Drawing.Point(0, -86);
            this.pnlMain.Size = new System.Drawing.Size(465, 417);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(469, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(123, 333);
            this.btnEdit.Size = new System.Drawing.Size(10, 10);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(10, 347);
            this.btnSave.Size = new System.Drawing.Size(10, 10);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(115, 347);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(7, 333);
            this.btnNew.Size = new System.Drawing.Size(10, 10);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(358, 333);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(229, 333);
            this.btnPrint.Size = new System.Drawing.Size(126, 39);
            this.btnPrint.Text = "Preview";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 373);
            this.groupBox1.Size = new System.Drawing.Size(469, 25);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.chkSqpCls);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.dteToDate);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.dteFromDate);
            this.groupBox6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(14, 201);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(434, 118);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Period Seletion";
            // 
            // chkSqpCls
            // 
            this.chkSqpCls.AutoSize = true;
            this.chkSqpCls.Checked = true;
            this.chkSqpCls.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSqpCls.Location = new System.Drawing.Point(264, 95);
            this.chkSqpCls.Name = "chkSqpCls";
            this.chkSqpCls.Size = new System.Drawing.Size(148, 18);
            this.chkSqpCls.TabIndex = 24;
            this.chkSqpCls.Text = "Swap Closing stock";
            this.chkSqpCls.UseVisualStyleBackColor = true;
            this.chkSqpCls.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(62, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "To:";
            // 
            // dteToDate
            // 
            this.dteToDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteToDate.Location = new System.Drawing.Point(113, 66);
            this.dteToDate.Name = "dteToDate";
            this.dteToDate.Size = new System.Drawing.Size(224, 22);
            this.dteToDate.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(41, 35);
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
            this.dteFromDate.Location = new System.Drawing.Point(113, 29);
            this.dteFromDate.Name = "dteFromDate";
            this.dteFromDate.Size = new System.Drawing.Size(224, 22);
            this.dteFromDate.TabIndex = 20;
            // 
            // grpHorVer
            // 
            this.grpHorVer.Controls.Add(this.radVertical);
            this.grpHorVer.Controls.Add(this.radHor);
            this.grpHorVer.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpHorVer.Location = new System.Drawing.Point(14, 321);
            this.grpHorVer.Name = "grpHorVer";
            this.grpHorVer.Size = new System.Drawing.Size(149, 89);
            this.grpHorVer.TabIndex = 6;
            this.grpHorVer.TabStop = false;
            this.grpHorVer.Text = "Selection";
            this.grpHorVer.Visible = false;
            // 
            // radVertical
            // 
            this.radVertical.AutoSize = true;
            this.radVertical.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radVertical.Location = new System.Drawing.Point(28, 67);
            this.radVertical.Name = "radVertical";
            this.radVertical.Size = new System.Drawing.Size(70, 18);
            this.radVertical.TabIndex = 3;
            this.radVertical.Text = "Vertical";
            this.radVertical.UseVisualStyleBackColor = true;
            this.radVertical.Click += new System.EventHandler(this.radVertical_Click);
            // 
            // radHor
            // 
            this.radHor.AutoSize = true;
            this.radHor.Checked = true;
            this.radHor.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radHor.Location = new System.Drawing.Point(28, 34);
            this.radHor.Name = "radHor";
            this.radHor.Size = new System.Drawing.Size(89, 18);
            this.radHor.TabIndex = 2;
            this.radHor.TabStop = true;
            this.radHor.Text = "Horizontal";
            this.radHor.UseVisualStyleBackColor = true;
            this.radHor.Click += new System.EventHandler(this.radHor_Click);
            // 
            // frmSelection
            // 
            this.frmSelection.Controls.Add(this.radDetails);
            this.frmSelection.Controls.Add(this.radSumm);
            this.frmSelection.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmSelection.Location = new System.Drawing.Point(229, 321);
            this.frmSelection.Name = "frmSelection";
            this.frmSelection.Size = new System.Drawing.Size(200, 78);
            this.frmSelection.TabIndex = 7;
            this.frmSelection.TabStop = false;
            this.frmSelection.Text = "Selection";
            this.frmSelection.Visible = false;
            // 
            // radDetails
            // 
            this.radDetails.AutoSize = true;
            this.radDetails.Checked = true;
            this.radDetails.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radDetails.Location = new System.Drawing.Point(23, 35);
            this.radDetails.Name = "radDetails";
            this.radDetails.Size = new System.Drawing.Size(68, 18);
            this.radDetails.TabIndex = 3;
            this.radDetails.TabStop = true;
            this.radDetails.Text = "Details";
            this.radDetails.UseVisualStyleBackColor = true;
            // 
            // radSumm
            // 
            this.radSumm.AutoSize = true;
            this.radSumm.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSumm.Location = new System.Drawing.Point(119, 35);
            this.radSumm.Name = "radSumm";
            this.radSumm.Size = new System.Drawing.Size(75, 18);
            this.radSumm.TabIndex = 2;
            this.radSumm.Text = "Summry";
            this.radSumm.UseVisualStyleBackColor = true;
            // 
            // frmRptAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(469, 398);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmRptAccounts";
            this.Load += new System.EventHandler(this.frmRptStoreLedger_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.grpHorVer.ResumeLayout(false);
            this.grpHorVer.PerformLayout();
            this.frmSelection.ResumeLayout(false);
            this.frmSelection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dteToDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dteFromDate;
        private System.Windows.Forms.GroupBox grpHorVer;
        private System.Windows.Forms.RadioButton radVertical;
        private System.Windows.Forms.RadioButton radHor;
        private System.Windows.Forms.GroupBox frmSelection;
        private System.Windows.Forms.RadioButton radDetails;
        private System.Windows.Forms.RadioButton radSumm;
        private System.Windows.Forms.CheckBox chkSqpCls;
    }
}
