namespace JA.Modulecontrolar.UI.Master.Accounts
{
    partial class frmAccountsLedgerList
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
            this.DG = new System.Windows.Forms.DataGridView();
            this.txtSeacrh = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblDr = new System.Windows.Forms.Label();
            this.lblCr = new System.Windows.Forms.Label();
            this.chkStatus = new System.Windows.Forms.CheckBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.chkClose = new System.Windows.Forms.CheckBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).BeginInit();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(457, 9);
            this.frmLabel.Size = new System.Drawing.Size(144, 33);
            this.frmLabel.Text = "Ledger List";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.DG);
            this.pnlMain.Size = new System.Drawing.Size(1028, 613);
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.chkClose);
            this.pnlTop.Controls.Add(this.textBox2);
            this.pnlTop.Controls.Add(this.textBox1);
            this.pnlTop.Controls.Add(this.lblCount);
            this.pnlTop.Controls.Add(this.chkStatus);
            this.pnlTop.Controls.Add(this.lblSearch);
            this.pnlTop.Controls.Add(this.txtSeacrh);
            this.pnlTop.Size = new System.Drawing.Size(1029, 58);
            this.pnlTop.Controls.SetChildIndex(this.frmLabel, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnTopClose, 0);
            this.pnlTop.Controls.SetChildIndex(this.txtSeacrh, 0);
            this.pnlTop.Controls.SetChildIndex(this.lblSearch, 0);
            this.pnlTop.Controls.SetChildIndex(this.chkStatus, 0);
            this.pnlTop.Controls.SetChildIndex(this.lblCount, 0);
            this.pnlTop.Controls.SetChildIndex(this.textBox1, 0);
            this.pnlTop.Controls.SetChildIndex(this.textBox2, 0);
            this.pnlTop.Controls.SetChildIndex(this.chkClose, 0);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(412, 54);
            this.btnEdit.Size = new System.Drawing.Size(10, 13);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(299, 54);
            this.btnSave.Size = new System.Drawing.Size(10, 13);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(525, 54);
            this.btnDelete.Size = new System.Drawing.Size(10, 13);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(186, 54);
            this.btnNew.Size = new System.Drawing.Size(10, 13);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(747, 54);
            this.btnClose.Size = new System.Drawing.Size(10, 13);
            this.btnClose.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(636, 54);
            this.btnPrint.Size = new System.Drawing.Size(10, 13);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCr);
            this.groupBox1.Controls.Add(this.lblDr);
            this.groupBox1.Location = new System.Drawing.Point(0, 526);
            this.groupBox1.Size = new System.Drawing.Size(1029, 25);
            this.groupBox1.Controls.SetChildIndex(this.lblDr, 0);
            this.groupBox1.Controls.SetChildIndex(this.lblCr, 0);
            // 
            // DG
            // 
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG.Location = new System.Drawing.Point(4, 146);
            this.DG.Name = "DG";
            this.DG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DG.Size = new System.Drawing.Size(1019, 462);
            this.DG.TabIndex = 1;
            // 
            // txtSeacrh
            // 
            this.txtSeacrh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSeacrh.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeacrh.Location = new System.Drawing.Point(11, 22);
            this.txtSeacrh.Name = "txtSeacrh";
            this.txtSeacrh.Size = new System.Drawing.Size(249, 26);
            this.txtSeacrh.TabIndex = 0;
            this.txtSeacrh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSeacrh_KeyDown);
            this.txtSeacrh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSeacrh_KeyPress_1);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(17, 5);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(114, 16);
            this.lblSearch.TabIndex = 16;
            this.lblSearch.Text = "Search(Code):";
            // 
            // lblDr
            // 
            this.lblDr.AutoSize = true;
            this.lblDr.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDr.ForeColor = System.Drawing.Color.Magenta;
            this.lblDr.Location = new System.Drawing.Point(571, 8);
            this.lblDr.Name = "lblDr";
            this.lblDr.Size = new System.Drawing.Size(16, 14);
            this.lblDr.TabIndex = 16;
            this.lblDr.Text = "0";
            // 
            // lblCr
            // 
            this.lblCr.AutoSize = true;
            this.lblCr.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCr.ForeColor = System.Drawing.Color.Magenta;
            this.lblCr.Location = new System.Drawing.Point(822, 8);
            this.lblCr.Name = "lblCr";
            this.lblCr.Size = new System.Drawing.Size(16, 14);
            this.lblCr.TabIndex = 17;
            this.lblCr.Text = "0";
            // 
            // chkStatus
            // 
            this.chkStatus.AutoSize = true;
            this.chkStatus.Checked = true;
            this.chkStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkStatus.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkStatus.ForeColor = System.Drawing.Color.Red;
            this.chkStatus.Location = new System.Drawing.Point(845, 6);
            this.chkStatus.Name = "chkStatus";
            this.chkStatus.Size = new System.Drawing.Size(60, 18);
            this.chkStatus.TabIndex = 17;
            this.chkStatus.Text = "Active";
            this.chkStatus.UseVisualStyleBackColor = true;
            this.chkStatus.CheckedChanged += new System.EventHandler(this.chkStatus_CheckedChanged);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.ForeColor = System.Drawing.Color.Fuchsia;
            this.lblCount.Location = new System.Drawing.Point(839, 27);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(16, 14);
            this.lblCount.TabIndex = 18;
            this.lblCount.Text = "0";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(313, 9);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(17, 20);
            this.textBox1.TabIndex = 19;
            this.textBox1.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(685, 13);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(13, 20);
            this.textBox2.TabIndex = 20;
            this.textBox2.Visible = false;
            // 
            // chkClose
            // 
            this.chkClose.AutoSize = true;
            this.chkClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkClose.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkClose.ForeColor = System.Drawing.Color.Red;
            this.chkClose.Location = new System.Drawing.Point(922, 5);
            this.chkClose.Name = "chkClose";
            this.chkClose.Size = new System.Drawing.Size(58, 18);
            this.chkClose.TabIndex = 21;
            this.chkClose.Text = "Close";
            this.chkClose.UseVisualStyleBackColor = true;
            this.chkClose.Visible = false;
            this.chkClose.CheckedChanged += new System.EventHandler(this.chkClose_CheckedChanged);
            // 
            // frmAccountsLedgerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1029, 551);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmAccountsLedgerList";
            this.Load += new System.EventHandler(this.frmAccountsLedgerList_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DG;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSeacrh;
        private System.Windows.Forms.Label lblCr;
        private System.Windows.Forms.Label lblDr;
        private System.Windows.Forms.CheckBox chkStatus;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox chkClose;
    }
}
