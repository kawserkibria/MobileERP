namespace JA.Modulecontrolar.UI.Accms.Forms
{
    partial class frmAutoJV
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblName = new System.Windows.Forms.Label();
            this.dteImportDate = new System.Windows.Forms.DateTimePicker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnReplacement = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmLabel.Location = new System.Drawing.Point(183, 7);
            this.frmLabel.Size = new System.Drawing.Size(131, 23);
            this.frmLabel.Text = "Auto Journal";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnReplacement);
            this.pnlMain.Controls.Add(this.textBox1);
            this.pnlMain.Controls.Add(this.progressBar1);
            this.pnlMain.Controls.Add(this.lblName);
            this.pnlMain.Controls.Add(this.dteImportDate);
            this.pnlMain.Size = new System.Drawing.Size(501, 415);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(503, 42);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(92, 39);
            this.btnEdit.Size = new System.Drawing.Size(10, 10);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(57, 48);
            this.btnSave.Size = new System.Drawing.Size(10, 10);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(109, 43);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(212, 331);
            this.btnNew.Size = new System.Drawing.Size(133, 41);
            this.btnNew.Text = "Generate";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(347, 332);
            this.btnClose.Size = new System.Drawing.Size(147, 40);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(140, 51);
            this.btnPrint.Size = new System.Drawing.Size(10, 10);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 374);
            this.groupBox1.Size = new System.Drawing.Size(503, 25);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(19, 206);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(461, 23);
            this.progressBar1.TabIndex = 10;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(146, 157);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(37, 14);
            this.lblName.TabIndex = 9;
            this.lblName.Text = "Date";
            // 
            // dteImportDate
            // 
            this.dteImportDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteImportDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteImportDate.Location = new System.Drawing.Point(189, 155);
            this.dteImportDate.Name = "dteImportDate";
            this.dteImportDate.Size = new System.Drawing.Size(132, 22);
            this.dteImportDate.TabIndex = 8;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(18, 235);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(462, 175);
            this.textBox1.TabIndex = 11;
            // 
            // btnReplacement
            // 
            this.btnReplacement.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReplacement.Location = new System.Drawing.Point(326, 154);
            this.btnReplacement.Name = "btnReplacement";
            this.btnReplacement.Size = new System.Drawing.Size(102, 24);
            this.btnReplacement.TabIndex = 12;
            this.btnReplacement.Text = "Replacement";
            this.btnReplacement.UseVisualStyleBackColor = true;
            this.btnReplacement.Click += new System.EventHandler(this.btnReplacement_Click);
            // 
            // frmAutoJV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(503, 399);
            this.isEnterTabAllow = true;
            this.MinimizeBox = false;
            this.Name = "frmAutoJV";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.DateTimePicker dteImportDate;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnReplacement;

    }
}
