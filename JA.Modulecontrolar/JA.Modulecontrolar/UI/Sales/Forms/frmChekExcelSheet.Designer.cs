namespace JA.Modulecontrolar.UI.Sales.Forms
{
    partial class frmChekExcelSheet
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(307, 9);
            this.frmLabel.Size = new System.Drawing.Size(228, 33);
            this.frmLabel.Text = "Check Excel Sheet";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.textBox1);
            this.pnlMain.Size = new System.Drawing.Size(863, 584);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(412, 63);
            this.btnEdit.Size = new System.Drawing.Size(10, 7);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(299, 63);
            this.btnSave.Size = new System.Drawing.Size(10, 7);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(525, 63);
            this.btnDelete.Size = new System.Drawing.Size(10, 7);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(186, 63);
            this.btnNew.Size = new System.Drawing.Size(10, 7);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(6, 499);
            this.btnClose.Size = new System.Drawing.Size(857, 35);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(636, 63);
            this.btnPrint.Size = new System.Drawing.Size(10, 7);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 558);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(6, 162);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(852, 414);
            this.textBox1.TabIndex = 0;
            // 
            // frmChekExcelSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(864, 583);
            this.isEnterTabAllow = true;
            this.MinimizeBox = false;
            this.Name = "frmChekExcelSheet";
            this.Load += new System.EventHandler(this.frmChekExcelSheet_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;

    }
}
