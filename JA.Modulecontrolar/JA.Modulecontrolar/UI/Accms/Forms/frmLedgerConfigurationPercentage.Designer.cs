namespace JA.Modulecontrolar.UI.Accms.Forms
{
    partial class frmLedgerConfigurationPercentage
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
            this.lblLedgerName = new System.Windows.Forms.Label();
            this.DG = new System.Windows.Forms.DataGridView();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.chkChange = new System.Windows.Forms.CheckBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).BeginInit();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Font = new System.Drawing.Font("Tahoma", 20.25F);
            this.frmLabel.Location = new System.Drawing.Point(263, 6);
            this.frmLabel.Size = new System.Drawing.Size(0, 33);
            this.frmLabel.Text = "";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.DG);
            this.pnlMain.Size = new System.Drawing.Size(743, 616);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.chkActive);
            this.pnlTop.Controls.Add(this.chkChange);
            this.pnlTop.Controls.Add(this.lblLedgerName);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Size = new System.Drawing.Size(746, 52);
            this.pnlTop.Controls.SetChildIndex(this.label1, 0);
            this.pnlTop.Controls.SetChildIndex(this.lblLedgerName, 0);
            this.pnlTop.Controls.SetChildIndex(this.chkChange, 0);
            this.pnlTop.Controls.SetChildIndex(this.frmLabel, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnTopClose, 0);
            this.pnlTop.Controls.SetChildIndex(this.chkActive, 0);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(140, 419);
            this.btnEdit.Size = new System.Drawing.Size(20, 10);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(510, 528);
            this.btnSave.Size = new System.Drawing.Size(109, 38);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(364, 419);
            this.btnDelete.Size = new System.Drawing.Size(10, 14);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(12, 419);
            this.btnNew.Size = new System.Drawing.Size(10, 10);
            this.btnNew.Text = "Alter";
            this.btnNew.Visible = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(622, 528);
            this.btnClose.Size = new System.Drawing.Size(117, 39);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(180, 415);
            this.btnPrint.Size = new System.Drawing.Size(28, 14);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 568);
            this.groupBox1.Size = new System.Drawing.Size(746, 25);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 14);
            this.label1.TabIndex = 15;
            this.label1.Text = "Ledger Name:";
            // 
            // lblLedgerName
            // 
            this.lblLedgerName.AutoSize = true;
            this.lblLedgerName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLedgerName.ForeColor = System.Drawing.Color.Blue;
            this.lblLedgerName.Location = new System.Drawing.Point(22, 25);
            this.lblLedgerName.Name = "lblLedgerName";
            this.lblLedgerName.Size = new System.Drawing.Size(0, 14);
            this.lblLedgerName.TabIndex = 16;
            // 
            // DG
            // 
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG.Location = new System.Drawing.Point(3, 144);
            this.DG.Name = "DG";
            this.DG.Size = new System.Drawing.Size(735, 467);
            this.DG.TabIndex = 0;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 532);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(492, 23);
            this.progressBar1.TabIndex = 15;
            // 
            // chkChange
            // 
            this.chkChange.AutoSize = true;
            this.chkChange.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkChange.Location = new System.Drawing.Point(664, 25);
            this.chkChange.Name = "chkChange";
            this.chkChange.Size = new System.Drawing.Size(74, 17);
            this.chkChange.TabIndex = 18;
            this.chkChange.Text = "Change";
            this.chkChange.UseVisualStyleBackColor = true;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActive.Location = new System.Drawing.Point(118, 0);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(67, 17);
            this.chkActive.TabIndex = 19;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // frmLedgerConfigurationPercentage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(746, 593);
            this.Controls.Add(this.progressBar1);
            this.isEnterTabAllow = true;
            this.MinimizeBox = false;
            this.Name = "frmLedgerConfigurationPercentage";
            this.Load += new System.EventHandler(this.frmLedgerConfigurationPercentage_Load);
            this.Controls.SetChildIndex(this.progressBar1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.pnlMain, 0);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblLedgerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DG;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox chkChange;
        private System.Windows.Forms.CheckBox chkActive;

    }
}
