namespace JA.Modulecontrolar.UI.Inventory
{
    partial class frmOverheadValueInsert
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
            this.label5 = new System.Windows.Forms.Label();
            this.dteFromDate = new System.Windows.Forms.DateTimePicker();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(148, 8);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.dteFromDate);
            this.pnlMain.Size = new System.Drawing.Size(472, 317);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(476, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(154, 153);
            this.btnEdit.Size = new System.Drawing.Size(10, 10);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(353, 236);
            this.btnSave.Size = new System.Drawing.Size(119, 39);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(154, 153);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(20, 153);
            this.btnNew.Size = new System.Drawing.Size(10, 10);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(101, 148);
            this.btnClose.Size = new System.Drawing.Size(10, 10);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(90, 148);
            this.btnPrint.Size = new System.Drawing.Size(10, 10);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 281);
            this.groupBox1.Size = new System.Drawing.Size(476, 25);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(106, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "Date:";
            // 
            // dteFromDate
            // 
            this.dteFromDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteFromDate.Location = new System.Drawing.Point(163, 177);
            this.dteFromDate.Name = "dteFromDate";
            this.dteFromDate.Size = new System.Drawing.Size(167, 22);
            this.dteFromDate.TabIndex = 20;
            // 
            // frmOverheadValueInsert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(476, 306);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmOverheadValueInsert";
            this.Load += new System.EventHandler(this.frmOverheadValueInsert_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dteFromDate;

    }
}
