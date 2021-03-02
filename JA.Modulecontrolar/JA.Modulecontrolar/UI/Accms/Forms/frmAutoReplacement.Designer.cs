namespace JA.Modulecontrolar.UI.Accms.Forms
{
    partial class frmAutoReplacement
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
            this.uctxtLedgerName = new System.Windows.Forms.TextBox();
            this.lblUnder = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uctxtXMpoLedger = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmLabel.Location = new System.Drawing.Point(40, 7);
            this.frmLabel.Size = new System.Drawing.Size(343, 23);
            this.frmLabel.Text = "MPO Replacement for Auto Journal";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.uctxtXMpoLedger);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.uctxtLedgerName);
            this.pnlMain.Controls.Add(this.lblUnder);
            this.pnlMain.Size = new System.Drawing.Size(457, 412);
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(460, 42);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(92, 39);
            this.btnEdit.Size = new System.Drawing.Size(10, 10);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(170, 329);
            this.btnSave.Size = new System.Drawing.Size(132, 42);
            this.btnSave.Text = "Update";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(109, 43);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(31, 344);
            this.btnNew.Size = new System.Drawing.Size(10, 10);
            this.btnNew.Text = "Update";
            this.btnNew.Visible = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(306, 329);
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
            this.groupBox1.Location = new System.Drawing.Point(0, 373);
            this.groupBox1.Size = new System.Drawing.Size(460, 25);
            // 
            // uctxtLedgerName
            // 
            this.uctxtLedgerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtLedgerName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtLedgerName.Location = new System.Drawing.Point(54, 191);
            this.uctxtLedgerName.Name = "uctxtLedgerName";
            this.uctxtLedgerName.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtLedgerName.Size = new System.Drawing.Size(354, 22);
            this.uctxtLedgerName.TabIndex = 54;
            // 
            // lblUnder
            // 
            this.lblUnder.AutoSize = true;
            this.lblUnder.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnder.Location = new System.Drawing.Point(51, 166);
            this.lblUnder.Name = "lblUnder";
            this.lblUnder.Size = new System.Drawing.Size(92, 16);
            this.lblUnder.TabIndex = 53;
            this.lblUnder.Text = "MPO Ledger:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(60, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 55;
            this.label1.Text = "X MPO Ledger";
            // 
            // uctxtXMpoLedger
            // 
            this.uctxtXMpoLedger.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtXMpoLedger.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtXMpoLedger.Location = new System.Drawing.Point(54, 265);
            this.uctxtXMpoLedger.Name = "uctxtXMpoLedger";
            this.uctxtXMpoLedger.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtXMpoLedger.Size = new System.Drawing.Size(354, 22);
            this.uctxtXMpoLedger.TabIndex = 56;
            // 
            // frmAutoReplacement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(460, 398);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmAutoReplacement";
            this.Load += new System.EventHandler(this.frmAutoReplacemenr_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox uctxtXMpoLedger;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uctxtLedgerName;
        private System.Windows.Forms.Label lblUnder;


    }
}
