namespace JA.Modulecontrolar.UI.Master
{
    partial class frmStockItemList
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
            this.chkStatus = new System.Windows.Forms.CheckBox();
            this.txtSerach = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).BeginInit();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(478, 9);
            this.frmLabel.Size = new System.Drawing.Size(191, 33);
            this.frmLabel.Text = "Stock Item List";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.DG);
            this.pnlMain.Size = new System.Drawing.Size(1030, 598);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.chkStatus);
            this.pnlTop.Controls.Add(this.txtSerach);
            this.pnlTop.Controls.Add(this.lblSearch);
            this.pnlTop.Size = new System.Drawing.Size(1032, 58);
            this.pnlTop.Controls.SetChildIndex(this.frmLabel, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnTopClose, 0);
            this.pnlTop.Controls.SetChildIndex(this.lblSearch, 0);
            this.pnlTop.Controls.SetChildIndex(this.txtSerach, 0);
            this.pnlTop.Controls.SetChildIndex(this.chkStatus, 0);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(568, 446);
            this.btnEdit.Size = new System.Drawing.Size(16, 15);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(455, 446);
            this.btnSave.Size = new System.Drawing.Size(10, 19);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(681, 446);
            this.btnDelete.Size = new System.Drawing.Size(15, 19);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(342, 446);
            this.btnNew.Size = new System.Drawing.Size(11, 12);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(903, 446);
            this.btnClose.Size = new System.Drawing.Size(22, 15);
            this.btnClose.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(792, 446);
            this.btnPrint.Size = new System.Drawing.Size(13, 19);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCount);
            this.groupBox1.Location = new System.Drawing.Point(0, 513);
            this.groupBox1.Size = new System.Drawing.Size(1032, 25);
            this.groupBox1.Controls.SetChildIndex(this.lblCount, 0);
            // 
            // DG
            // 
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG.Location = new System.Drawing.Point(5, 150);
            this.DG.Name = "DG";
            this.DG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DG.Size = new System.Drawing.Size(1019, 443);
            this.DG.TabIndex = 1;
            this.DG.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellClick);
            this.DG.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellContentClick);
            // 
            // chkStatus
            // 
            this.chkStatus.AutoSize = true;
            this.chkStatus.Checked = true;
            this.chkStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkStatus.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkStatus.ForeColor = System.Drawing.Color.Red;
            this.chkStatus.Location = new System.Drawing.Point(945, 22);
            this.chkStatus.Name = "chkStatus";
            this.chkStatus.Size = new System.Drawing.Size(60, 18);
            this.chkStatus.TabIndex = 15;
            this.chkStatus.Text = "Active";
            this.chkStatus.UseVisualStyleBackColor = true;
            this.chkStatus.CheckedChanged += new System.EventHandler(this.chkStatus_CheckedChanged);
            // 
            // txtSerach
            // 
            this.txtSerach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSerach.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerach.Location = new System.Drawing.Point(4, 26);
            this.txtSerach.Name = "txtSerach";
            this.txtSerach.Size = new System.Drawing.Size(380, 22);
            this.txtSerach.TabIndex = 16;
            this.txtSerach.TextChanged += new System.EventHandler(this.txtSerach_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(18, 5);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(191, 16);
            this.lblSearch.TabIndex = 17;
            this.lblSearch.Text = "Item Name Wise Search :";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.ForeColor = System.Drawing.Color.Fuchsia;
            this.lblCount.Location = new System.Drawing.Point(821, 2);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(16, 14);
            this.lblCount.TabIndex = 20;
            this.lblCount.Text = "0";
            // 
            // frmStockItemList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1032, 538);
            this.isEnterTabAllow = true;
            this.MinimizeBox = false;
            this.Name = "frmStockItemList";
            this.Load += new System.EventHandler(this.frmStockItemList_Load);
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
        private System.Windows.Forms.TextBox txtSerach;
        private System.Windows.Forms.CheckBox chkStatus;
        private System.Windows.Forms.Label lblCount;
    }
}
