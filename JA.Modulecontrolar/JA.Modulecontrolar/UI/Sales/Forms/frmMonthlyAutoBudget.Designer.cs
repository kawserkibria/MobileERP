namespace JA.Modulecontrolar.UI.Sales.Forms
{
    partial class frmMonthlyAutoBudget
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
            this.label1 = new System.Windows.Forms.Label();
            this.dteFromdate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLedgerName = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.dteFDate = new System.Windows.Forms.DateTimePicker();
            this.dteTDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(152, 8);
            this.frmLabel.Size = new System.Drawing.Size(299, 33);
            this.frmLabel.Text = "Monthly Budget Process";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.dteTDate);
            this.pnlMain.Controls.Add(this.dteFDate);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.txtLedgerName);
            this.pnlMain.Controls.Add(this.progressBar1);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.dteFromdate);
            this.pnlMain.Size = new System.Drawing.Size(594, 424);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(597, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(0, 343);
            this.btnEdit.Size = new System.Drawing.Size(19, 10);
            this.btnEdit.Text = "List All";
            this.btnEdit.Visible = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(335, 341);
            this.btnSave.Size = new System.Drawing.Size(129, 39);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Generate";
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
            this.btnNew.Location = new System.Drawing.Point(420, 341);
            this.btnNew.Size = new System.Drawing.Size(10, 10);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(470, 341);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(161, 341);
            this.btnPrint.Size = new System.Drawing.Size(10, 10);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 381);
            this.groupBox1.Size = new System.Drawing.Size(597, 25);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(66, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 16);
            this.label1.TabIndex = 65;
            this.label1.Text = "Process Date:";
            // 
            // dteFromdate
            // 
            this.dteFromdate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteFromdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteFromdate.Location = new System.Drawing.Point(173, 210);
            this.dteFromdate.Name = "dteFromdate";
            this.dteFromdate.Size = new System.Drawing.Size(164, 22);
            this.dteFromdate.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(87, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 14);
            this.label3.TabIndex = 69;
            this.label3.Text = "MPO Name:";
            // 
            // txtLedgerName
            // 
            this.txtLedgerName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLedgerName.Location = new System.Drawing.Point(172, 235);
            this.txtLedgerName.Name = "txtLedgerName";
            this.txtLedgerName.Size = new System.Drawing.Size(355, 22);
            this.txtLedgerName.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(66, 313);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(461, 23);
            this.progressBar1.TabIndex = 66;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(70, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 14);
            this.label4.TabIndex = 70;
            this.label4.Text = "Process Generate Should by:";
            // 
            // dteFDate
            // 
            this.dteFDate.Enabled = false;
            this.dteFDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteFDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteFDate.Location = new System.Drawing.Point(264, 161);
            this.dteFDate.Name = "dteFDate";
            this.dteFDate.Size = new System.Drawing.Size(105, 22);
            this.dteFDate.TabIndex = 71;
            // 
            // dteTDate
            // 
            this.dteTDate.Enabled = false;
            this.dteTDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteTDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteTDate.Location = new System.Drawing.Point(409, 160);
            this.dteTDate.Name = "dteTDate";
            this.dteTDate.Size = new System.Drawing.Size(105, 22);
            this.dteTDate.TabIndex = 72;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(377, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 14);
            this.label5.TabIndex = 73;
            this.label5.Text = "to";
            // 
            // frmMonthlyAutoBudget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(597, 406);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmMonthlyAutoBudget";
            this.Load += new System.EventHandler(this.frmMonthlyAutoBudget_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dteFromdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLedgerName;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dteTDate;
        private System.Windows.Forms.DateTimePicker dteFDate;
        private System.Windows.Forms.Label label4;
    }
}
