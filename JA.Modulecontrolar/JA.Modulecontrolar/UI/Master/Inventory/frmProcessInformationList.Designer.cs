namespace JA.Modulecontrolar.UI.Inventory
{
    partial class frmProcessInformationList
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
            this.DgProcessList = new System.Windows.Forms.DataGridView();
            this.txtSerach = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.chkTransfer = new System.Windows.Forms.CheckBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgProcessList)).BeginInit();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Size = new System.Drawing.Size(302, 33);
            this.frmLabel.Text = "Process Information List";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.DgProcessList);
            this.pnlMain.Size = new System.Drawing.Size(954, 584);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.chkTransfer);
            this.pnlTop.Controls.Add(this.txtSerach);
            this.pnlTop.Controls.Add(this.lblSearch);
            this.pnlTop.Size = new System.Drawing.Size(957, 58);
            this.pnlTop.Controls.SetChildIndex(this.frmLabel, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnTopClose, 0);
            this.pnlTop.Controls.SetChildIndex(this.lblSearch, 0);
            this.pnlTop.Controls.SetChildIndex(this.txtSerach, 0);
            this.pnlTop.Controls.SetChildIndex(this.chkTransfer, 0);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(412, 64);
            this.btnEdit.Size = new System.Drawing.Size(10, 10);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(388, 64);
            this.btnSave.Size = new System.Drawing.Size(10, 10);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(525, 64);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(275, 64);
            this.btnNew.Size = new System.Drawing.Size(14, 10);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(747, 64);
            this.btnClose.Size = new System.Drawing.Size(10, 10);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(636, 64);
            this.btnPrint.Size = new System.Drawing.Size(10, 10);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCount);
            this.groupBox1.Location = new System.Drawing.Point(0, 498);
            this.groupBox1.Size = new System.Drawing.Size(957, 25);
            this.groupBox1.Controls.SetChildIndex(this.lblCount, 0);
            // 
            // DgProcessList
            // 
            this.DgProcessList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgProcessList.Location = new System.Drawing.Point(4, 146);
            this.DgProcessList.Name = "DgProcessList";
            this.DgProcessList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgProcessList.Size = new System.Drawing.Size(944, 433);
            this.DgProcessList.TabIndex = 73;
            this.DgProcessList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgProcessList_CellContentClick);
            this.DgProcessList.DoubleClick += new System.EventHandler(this.DgProcessList_DoubleClick);
            // 
            // txtSerach
            // 
            this.txtSerach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSerach.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerach.Location = new System.Drawing.Point(9, 23);
            this.txtSerach.Name = "txtSerach";
            this.txtSerach.Size = new System.Drawing.Size(251, 22);
            this.txtSerach.TabIndex = 18;
            this.txtSerach.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSerach_KeyUp);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(20, 2);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(111, 16);
            this.lblSearch.TabIndex = 19;
            this.lblSearch.Text = "Process Name";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.ForeColor = System.Drawing.Color.Fuchsia;
            this.lblCount.Location = new System.Drawing.Point(744, 3);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(16, 14);
            this.lblCount.TabIndex = 21;
            this.lblCount.Text = "0";
            // 
            // chkTransfer
            // 
            this.chkTransfer.AutoSize = true;
            this.chkTransfer.Checked = true;
            this.chkTransfer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTransfer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTransfer.Location = new System.Drawing.Point(813, 25);
            this.chkTransfer.Name = "chkTransfer";
            this.chkTransfer.Size = new System.Drawing.Size(127, 17);
            this.chkTransfer.TabIndex = 20;
            this.chkTransfer.Text = "MFG Production";
            this.chkTransfer.UseVisualStyleBackColor = true;
            this.chkTransfer.Click += new System.EventHandler(this.chkTransfer_Click);
            // 
            // frmProcessInformationList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(957, 523);
            this.isEnterTabAllow = true;
            this.MinimizeBox = false;
            this.Name = "frmProcessInformationList";
            this.Load += new System.EventHandler(this.frmProcessInformationList_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgProcessList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgProcessList;
        private System.Windows.Forms.TextBox txtSerach;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.CheckBox chkTransfer;
    }
}
