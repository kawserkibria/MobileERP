namespace JA.Modulecontrolar.UI.DReport.Accms.ParameterForms
{
    partial class frmRptIncentive
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
            this.rbtnyearlyE = new System.Windows.Forms.RadioButton();
            this.radMonthly = new System.Windows.Forms.RadioButton();
            this.radYearly = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtnAH = new System.Windows.Forms.RadioButton();
            this.rbtnMpo = new System.Windows.Forms.RadioButton();
            this.rbtnDSM = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dteToDate = new System.Windows.Forms.DateTimePicker();
            this.dteFromDate2 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dteFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpLastDate = new System.Windows.Forms.DateTimePicker();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.frmSelection.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(173, 9);
            this.frmLabel.Size = new System.Drawing.Size(123, 33);
            this.frmLabel.Text = "Incentive";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.groupBox6);
            this.pnlMain.Controls.Add(this.groupBox2);
            this.pnlMain.Controls.Add(this.frmSelection);
            this.pnlMain.Location = new System.Drawing.Point(0, -86);
            this.pnlMain.Size = new System.Drawing.Size(465, 446);
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(469, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(123, 160);
            this.btnEdit.Size = new System.Drawing.Size(10, 10);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(10, 174);
            this.btnSave.Size = new System.Drawing.Size(10, 10);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(115, 174);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(7, 160);
            this.btnNew.Size = new System.Drawing.Size(10, 10);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(357, 366);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(228, 366);
            this.btnPrint.Size = new System.Drawing.Size(126, 39);
            this.btnPrint.Text = "Preview";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 406);
            this.groupBox1.Size = new System.Drawing.Size(469, 25);
            // 
            // frmSelection
            // 
            this.frmSelection.Controls.Add(this.rbtnyearlyE);
            this.frmSelection.Controls.Add(this.radMonthly);
            this.frmSelection.Controls.Add(this.radYearly);
            this.frmSelection.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmSelection.Location = new System.Drawing.Point(6, 242);
            this.frmSelection.Name = "frmSelection";
            this.frmSelection.Size = new System.Drawing.Size(450, 78);
            this.frmSelection.TabIndex = 7;
            this.frmSelection.TabStop = false;
            this.frmSelection.Text = "Selection";
            // 
            // rbtnyearlyE
            // 
            this.rbtnyearlyE.AutoSize = true;
            this.rbtnyearlyE.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnyearlyE.Location = new System.Drawing.Point(307, 35);
            this.rbtnyearlyE.Name = "rbtnyearlyE";
            this.rbtnyearlyE.Size = new System.Drawing.Size(99, 18);
            this.rbtnyearlyE.TabIndex = 4;
            this.rbtnyearlyE.Text = "Yearly Extra";
            this.rbtnyearlyE.UseVisualStyleBackColor = true;
            // 
            // radMonthly
            // 
            this.radMonthly.AutoSize = true;
            this.radMonthly.Checked = true;
            this.radMonthly.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radMonthly.Location = new System.Drawing.Point(39, 35);
            this.radMonthly.Name = "radMonthly";
            this.radMonthly.Size = new System.Drawing.Size(74, 18);
            this.radMonthly.TabIndex = 3;
            this.radMonthly.TabStop = true;
            this.radMonthly.Text = "Monthly";
            this.radMonthly.UseVisualStyleBackColor = true;
            // 
            // radYearly
            // 
            this.radYearly.AutoSize = true;
            this.radYearly.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radYearly.Location = new System.Drawing.Point(176, 35);
            this.radYearly.Name = "radYearly";
            this.radYearly.Size = new System.Drawing.Size(62, 18);
            this.radYearly.TabIndex = 2;
            this.radYearly.Text = "Yearly";
            this.radYearly.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtnAH);
            this.groupBox2.Controls.Add(this.rbtnMpo);
            this.groupBox2.Controls.Add(this.rbtnDSM);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(9, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(447, 78);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Field Force Selection";
            // 
            // rbtnAH
            // 
            this.rbtnAH.AutoSize = true;
            this.rbtnAH.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnAH.Location = new System.Drawing.Point(176, 35);
            this.rbtnAH.Name = "rbtnAH";
            this.rbtnAH.Size = new System.Drawing.Size(91, 18);
            this.rbtnAH.TabIndex = 4;
            this.rbtnAH.Text = "Area Head";
            this.rbtnAH.UseVisualStyleBackColor = true;
            // 
            // rbtnMpo
            // 
            this.rbtnMpo.AutoSize = true;
            this.rbtnMpo.Checked = true;
            this.rbtnMpo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnMpo.Location = new System.Drawing.Point(39, 35);
            this.rbtnMpo.Name = "rbtnMpo";
            this.rbtnMpo.Size = new System.Drawing.Size(53, 18);
            this.rbtnMpo.TabIndex = 3;
            this.rbtnMpo.TabStop = true;
            this.rbtnMpo.Text = "MPO";
            this.rbtnMpo.UseVisualStyleBackColor = true;
            // 
            // rbtnDSM
            // 
            this.rbtnDSM.AutoSize = true;
            this.rbtnDSM.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnDSM.Location = new System.Drawing.Point(307, 35);
            this.rbtnDSM.Name = "rbtnDSM";
            this.rbtnDSM.Size = new System.Drawing.Size(121, 18);
            this.rbtnDSM.TabIndex = 2;
            this.rbtnDSM.Text = "Divisional Head";
            this.rbtnDSM.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.dteToDate);
            this.groupBox6.Controls.Add(this.dteFromDate2);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.dteFromDate);
            this.groupBox6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(6, 326);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(450, 106);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Period Seletion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(129, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "To:";
            // 
            // dteToDate
            // 
            this.dteToDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteToDate.Location = new System.Drawing.Point(180, 65);
            this.dteToDate.Name = "dteToDate";
            this.dteToDate.Size = new System.Drawing.Size(145, 22);
            this.dteToDate.TabIndex = 22;
            // 
            // dteFromDate2
            // 
            this.dteFromDate2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteFromDate2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteFromDate2.Location = new System.Drawing.Point(99, 146);
            this.dteFromDate2.Name = "dteFromDate2";
            this.dteFromDate2.Size = new System.Drawing.Size(10, 22);
            this.dteFromDate2.TabIndex = 223;
            this.dteFromDate2.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(108, 34);
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
            this.dteFromDate.Location = new System.Drawing.Point(180, 28);
            this.dteFromDate.Name = "dteFromDate";
            this.dteFromDate.Size = new System.Drawing.Size(145, 22);
            this.dteFromDate.TabIndex = 20;
            // 
            // dtpLastDate
            // 
            this.dtpLastDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpLastDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpLastDate.Location = new System.Drawing.Point(90, 366);
            this.dtpLastDate.Name = "dtpLastDate";
            this.dtpLastDate.Size = new System.Drawing.Size(10, 22);
            this.dtpLastDate.TabIndex = 224;
            this.dtpLastDate.Visible = false;
            // 
            // frmRptIncentive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(469, 431);
            this.Controls.Add(this.dtpLastDate);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmRptIncentive";
            this.Load += new System.EventHandler(this.frmRptIncentive_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.pnlMain, 0);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.Controls.SetChildIndex(this.dtpLastDate, 0);
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.frmSelection.ResumeLayout(false);
            this.frmSelection.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox frmSelection;
        private System.Windows.Forms.RadioButton radMonthly;
        private System.Windows.Forms.RadioButton radYearly;
        private System.Windows.Forms.RadioButton rbtnyearlyE;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtnAH;
        private System.Windows.Forms.RadioButton rbtnMpo;
        private System.Windows.Forms.RadioButton rbtnDSM;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dteToDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dteFromDate;
        private System.Windows.Forms.DateTimePicker dteFromDate2;
        private System.Windows.Forms.DateTimePicker dtpLastDate;
    }
}
