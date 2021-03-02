namespace JA.Modulecontrolar.UI.Master.Accounts
{
    partial class frmMpoCommManual
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
            this.label16 = new System.Windows.Forms.Label();
            this.uctxtMonthID = new System.Windows.Forms.TextBox();
            this.uctxtBranch = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkStatus = new System.Windows.Forms.CheckBox();
            this.uctxtOldKey = new MayhediControlLibrary.StandardTextBox();
            this.DG = new MayhediDataGridView();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).BeginInit();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Font = new System.Drawing.Font("Tahoma", 20.25F);
            this.frmLabel.Location = new System.Drawing.Point(490, 2);
            this.frmLabel.Size = new System.Drawing.Size(289, 33);
            this.frmLabel.Text = "Draft MPO Commission";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.DG);
            this.pnlMain.Controls.Add(this.chkStatus);
            this.pnlMain.Controls.Add(this.uctxtBranch);
            this.pnlMain.Controls.Add(this.label6);
            this.pnlMain.Controls.Add(this.label16);
            this.pnlMain.Controls.Add(this.uctxtMonthID);
            this.pnlMain.Size = new System.Drawing.Size(1284, 658);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.uctxtOldKey);
            this.pnlTop.Size = new System.Drawing.Size(1289, 52);
            this.pnlTop.Controls.SetChildIndex(this.frmLabel, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnTopClose, 0);
            this.pnlTop.Controls.SetChildIndex(this.uctxtOldKey, 0);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(140, 419);
            this.btnEdit.Size = new System.Drawing.Size(20, 10);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1039, 573);
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
            this.btnNew.Location = new System.Drawing.Point(4, 572);
            this.btnNew.Size = new System.Drawing.Size(132, 40);
            this.btnNew.Text = "List All";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1151, 573);
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
            this.groupBox1.Location = new System.Drawing.Point(0, 613);
            this.groupBox1.Size = new System.Drawing.Size(1289, 25);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(1007, 146);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(93, 17);
            this.label16.TabIndex = 215;
            this.label16.Text = "Active Month:";
            // 
            // uctxtMonthID
            // 
            this.uctxtMonthID.BackColor = System.Drawing.Color.White;
            this.uctxtMonthID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtMonthID.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtMonthID.Location = new System.Drawing.Point(1143, 144);
            this.uctxtMonthID.Name = "uctxtMonthID";
            this.uctxtMonthID.ReadOnly = true;
            this.uctxtMonthID.Size = new System.Drawing.Size(105, 23);
            this.uctxtMonthID.TabIndex = 214;
            // 
            // uctxtBranch
            // 
            this.uctxtBranch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtBranch.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtBranch.Location = new System.Drawing.Point(277, 144);
            this.uctxtBranch.Name = "uctxtBranch";
            this.uctxtBranch.Size = new System.Drawing.Size(567, 22);
            this.uctxtBranch.TabIndex = 216;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(176, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 16);
            this.label6.TabIndex = 217;
            this.label6.Text = "Branch Name:";
            // 
            // chkStatus
            // 
            this.chkStatus.AutoSize = true;
            this.chkStatus.Checked = true;
            this.chkStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStatus.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkStatus.Location = new System.Drawing.Point(11, 152);
            this.chkStatus.Name = "chkStatus";
            this.chkStatus.Size = new System.Drawing.Size(63, 18);
            this.chkStatus.TabIndex = 218;
            this.chkStatus.Text = "Active";
            this.chkStatus.UseVisualStyleBackColor = true;
            // 
            // uctxtOldKey
            // 
            this.uctxtOldKey.BackColor = System.Drawing.Color.White;
            this.uctxtOldKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtOldKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtOldKey.Location = new System.Drawing.Point(1194, 15);
            this.uctxtOldKey.Name = "uctxtOldKey";
            this.uctxtOldKey.Size = new System.Drawing.Size(55, 24);
            this.uctxtOldKey.TabIndex = 214;
            this.uctxtOldKey.Visible = false;
            // 
            // DG
            // 
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG.Location = new System.Drawing.Point(5, 170);
            this.DG.Name = "DG";
            this.DG.Size = new System.Drawing.Size(1270, 482);
            this.DG.TabIndex = 219;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(420, 577);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(579, 23);
            this.progressBar1.TabIndex = 16;
            // 
            // frmMpoCommManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1289, 638);
            this.Controls.Add(this.progressBar1);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmMpoCommManual";
            this.Load += new System.EventHandler(this.frmMpoCommManual_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.pnlMain, 0);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.Controls.SetChildIndex(this.progressBar1, 0);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox uctxtMonthID;
        private System.Windows.Forms.TextBox uctxtBranch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkStatus;
        private MayhediControlLibrary.StandardTextBox uctxtOldKey;
        private MayhediDataGridView DG;
        private System.Windows.Forms.ProgressBar progressBar1;

    }
}
