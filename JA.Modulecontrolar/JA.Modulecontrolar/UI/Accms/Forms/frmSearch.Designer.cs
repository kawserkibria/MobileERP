namespace JA.Modulecontrolar.UI.Accms.Forms
{
    partial class frmSearch
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
            this.txtSerach = new System.Windows.Forms.TextBox();
            this.lstLedger = new System.Windows.Forms.ListBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(159, 6);
            this.frmLabel.Size = new System.Drawing.Size(0, 33);
            this.frmLabel.Text = "";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.lstLedger);
            this.pnlMain.Controls.Add(this.txtSerach);
            this.pnlMain.Size = new System.Drawing.Size(533, 679);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(533, 9);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(19, 341);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(3, 423);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(8, 465);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(1, 381);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(6, 553);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(1, 510);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 592);
            this.groupBox1.Size = new System.Drawing.Size(533, 25);
            // 
            // txtSerach
            // 
            this.txtSerach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSerach.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerach.Location = new System.Drawing.Point(6, 97);
            this.txtSerach.Name = "txtSerach";
            this.txtSerach.Size = new System.Drawing.Size(517, 22);
            this.txtSerach.TabIndex = 0;
            // 
            // lstLedger
            // 
            this.lstLedger.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstLedger.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLedger.FormattingEnabled = true;
            this.lstLedger.ItemHeight = 16;
            this.lstLedger.Location = new System.Drawing.Point(7, 121);
            this.lstLedger.Name = "lstLedger";
            this.lstLedger.Size = new System.Drawing.Size(516, 546);
            this.lstLedger.TabIndex = 1;
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(533, 617);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.Name = "frmSearch";
            this.Text = "Search";
            this.Load += new System.EventHandler(this.frmSearch_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtSerach;
        private System.Windows.Forms.ListBox lstLedger;
    }
}
