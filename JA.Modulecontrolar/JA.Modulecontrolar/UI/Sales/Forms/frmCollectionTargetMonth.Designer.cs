namespace JA.Modulecontrolar.UI.Sales.Forms
{
    partial class frmCollectionTargetMonth
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
            this.uctxtMonthID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dteFromdate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dteTodate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dteTgrace = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.dteFGrace = new System.Windows.Forms.DateTimePicker();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(161, 8);
            this.frmLabel.Size = new System.Drawing.Size(242, 33);
            this.frmLabel.Text = "Grace Month Setup";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.label9);
            this.pnlMain.Controls.Add(this.label10);
            this.pnlMain.Controls.Add(this.dteTgrace);
            this.pnlMain.Controls.Add(this.label11);
            this.pnlMain.Controls.Add(this.dteFGrace);
            this.pnlMain.Controls.Add(this.label6);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.cboStatus);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.dteTodate);
            this.pnlMain.Controls.Add(this.uctxtMonthID);
            this.pnlMain.Controls.Add(this.label8);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.dteFromdate);
            this.pnlMain.Size = new System.Drawing.Size(594, 371);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(598, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(0, 291);
            this.btnEdit.Size = new System.Drawing.Size(121, 39);
            this.btnEdit.Text = "List All";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(372, 286);
            this.btnSave.TabIndex = 3;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(50, 315);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(420, 315);
            this.btnNew.Size = new System.Drawing.Size(10, 10);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(486, 286);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(161, 315);
            this.btnPrint.Size = new System.Drawing.Size(10, 10);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 331);
            this.groupBox1.Size = new System.Drawing.Size(598, 25);
            // 
            // uctxtMonthID
            // 
            this.uctxtMonthID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtMonthID.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtMonthID.Location = new System.Drawing.Point(216, 166);
            this.uctxtMonthID.MaxLength = 5;
            this.uctxtMonthID.Name = "uctxtMonthID";
            this.uctxtMonthID.Size = new System.Drawing.Size(163, 23);
            this.uctxtMonthID.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(55, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(154, 18);
            this.label8.TabIndex = 67;
            this.label8.Text = "Month ID(MMMYY):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(114, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 18);
            this.label1.TabIndex = 65;
            this.label1.Text = "From Date:";
            // 
            // dteFromdate
            // 
            this.dteFromdate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteFromdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteFromdate.Location = new System.Drawing.Point(216, 225);
            this.dteFromdate.Name = "dteFromdate";
            this.dteFromdate.Size = new System.Drawing.Size(110, 22);
            this.dteFromdate.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(341, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 18);
            this.label3.TabIndex = 70;
            this.label3.Text = "To Date:";
            // 
            // dteTodate
            // 
            this.dteTodate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteTodate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteTodate.Location = new System.Drawing.Point(419, 225);
            this.dteTodate.Name = "dteTodate";
            this.dteTodate.Size = new System.Drawing.Size(113, 22);
            this.dteTodate.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(146, 324);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 18);
            this.label4.TabIndex = 71;
            this.label4.Text = "Status:";
            // 
            // cboStatus
            // 
            this.cboStatus.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.cboStatus.Location = new System.Drawing.Point(216, 323);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(163, 22);
            this.cboStatus.TabIndex = 2;
            this.cboStatus.Text = "Active";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(385, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 18);
            this.label5.TabIndex = 72;
            this.label5.Text = "i.e: JAN19";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(111, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 18);
            this.label6.TabIndex = 73;
            this.label6.Text = "Grace Period";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(111, 256);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(124, 18);
            this.label9.TabIndex = 78;
            this.label9.Text = "Normal Period";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(341, 280);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 18);
            this.label10.TabIndex = 77;
            this.label10.Text = "To Date:";
            // 
            // dteTgrace
            // 
            this.dteTgrace.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteTgrace.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteTgrace.Location = new System.Drawing.Point(419, 280);
            this.dteTgrace.Name = "dteTgrace";
            this.dteTgrace.Size = new System.Drawing.Size(113, 22);
            this.dteTgrace.TabIndex = 75;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(117, 282);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 18);
            this.label11.TabIndex = 76;
            this.label11.Text = "From Date:";
            // 
            // dteFGrace
            // 
            this.dteFGrace.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteFGrace.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteFGrace.Location = new System.Drawing.Point(216, 280);
            this.dteFGrace.Name = "dteFGrace";
            this.dteFGrace.Size = new System.Drawing.Size(110, 22);
            this.dteFGrace.TabIndex = 74;
            // 
            // frmCollectionTargetMonth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(598, 356);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmCollectionTargetMonth";
            this.Load += new System.EventHandler(this.frmCollectionTargetMonth_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox uctxtMonthID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dteFromdate;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dteTodate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dteTgrace;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dteFGrace;
        private System.Windows.Forms.Label label6;
    }
}
