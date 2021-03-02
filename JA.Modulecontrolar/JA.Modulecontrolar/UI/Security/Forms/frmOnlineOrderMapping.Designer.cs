namespace JA.Modulecontrolar.UI.Security.Forms
{
    partial class frmOnlineOrderMapping
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DG = new System.Windows.Forms.DataGridView();
            this.lblName = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.uctxtSeacrh = new System.Windows.Forms.TextBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.uctxtPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.uctxtUserID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtSLNo = new System.Windows.Forms.TextBox();
            this.uctxtSecurityCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSMS = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(351, 9);
            this.frmLabel.Size = new System.Drawing.Size(192, 33);
            this.frmLabel.Text = "Online Security";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnSMS);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.uctxtSecurityCode);
            this.pnlMain.Controls.Add(this.txtSLNo);
            this.pnlMain.Controls.Add(this.btnRefresh);
            this.pnlMain.Controls.Add(this.cboStatus);
            this.pnlMain.Controls.Add(this.label6);
            this.pnlMain.Controls.Add(this.uctxtPassword);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.uctxtUserID);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.groupBox2);
            this.pnlMain.Controls.Add(this.DG);
            this.pnlMain.Size = new System.Drawing.Size(937, 700);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblName);
            this.pnlTop.Size = new System.Drawing.Size(940, 58);
            this.pnlTop.Controls.SetChildIndex(this.frmLabel, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnTopClose, 0);
            this.pnlTop.Controls.SetChildIndex(this.lblName, 0);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(10, 530);
            this.btnEdit.Size = new System.Drawing.Size(10, 10);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(698, 614);
            this.btnSave.Size = new System.Drawing.Size(118, 43);
            this.btnSave.Visible = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(123, 530);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(6, 569);
            this.btnNew.Size = new System.Drawing.Size(17, 10);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(818, 614);
            this.btnClose.Size = new System.Drawing.Size(118, 43);
            this.btnClose.Visible = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(234, 530);
            this.btnPrint.Size = new System.Drawing.Size(10, 10);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 658);
            this.groupBox1.Size = new System.Drawing.Size(940, 25);
            // 
            // DG
            // 
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DG.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DG.DefaultCellStyle = dataGridViewCellStyle7;
            this.DG.Location = new System.Drawing.Point(3, 319);
            this.DG.Name = "DG";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DG.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.DG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DG.Size = new System.Drawing.Size(924, 375);
            this.DG.TabIndex = 72;
            this.DG.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellClick);
            this.DG.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellContentClick);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Blue;
            this.lblName.Location = new System.Drawing.Point(709, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 18);
            this.lblName.TabIndex = 16;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblSearch);
            this.groupBox2.Controls.Add(this.uctxtSeacrh);
            this.groupBox2.Location = new System.Drawing.Point(7, 266);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(920, 48);
            this.groupBox2.TabIndex = 78;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(110, 21);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(62, 16);
            this.lblSearch.TabIndex = 59;
            this.lblSearch.Text = "User ID:";
            // 
            // uctxtSeacrh
            // 
            this.uctxtSeacrh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtSeacrh.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtSeacrh.Location = new System.Drawing.Point(216, 19);
            this.uctxtSeacrh.Name = "uctxtSeacrh";
            this.uctxtSeacrh.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtSeacrh.Size = new System.Drawing.Size(443, 22);
            this.uctxtSeacrh.TabIndex = 58;
            this.uctxtSeacrh.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uctxtSeacrh_KeyUp);
            // 
            // cboStatus
            // 
            this.cboStatus.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(128, 197);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(138, 24);
            this.cboStatus.TabIndex = 85;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(60, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 16);
            this.label6.TabIndex = 84;
            this.label6.Text = "Status:";
            // 
            // uctxtPassword
            // 
            this.uctxtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtPassword.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtPassword.Location = new System.Drawing.Point(514, 159);
            this.uctxtPassword.Name = "uctxtPassword";
            this.uctxtPassword.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtPassword.Size = new System.Drawing.Size(295, 22);
            this.uctxtPassword.TabIndex = 83;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(433, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 16);
            this.label4.TabIndex = 82;
            this.label4.Text = "Password:";
            // 
            // uctxtUserID
            // 
            this.uctxtUserID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtUserID.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtUserID.Location = new System.Drawing.Point(128, 159);
            this.uctxtUserID.Name = "uctxtUserID";
            this.uctxtUserID.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtUserID.Size = new System.Drawing.Size(195, 22);
            this.uctxtUserID.TabIndex = 81;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(56, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 80;
            this.label3.Text = "User ID:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnRefresh.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnRefresh.ForeColor = System.Drawing.Color.Navy;
            this.btnRefresh.Location = new System.Drawing.Point(843, 227);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(84, 41);
            this.btnRefresh.TabIndex = 86;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtSLNo
            // 
            this.txtSLNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSLNo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSLNo.Location = new System.Drawing.Point(27, 233);
            this.txtSLNo.Name = "txtSLNo";
            this.txtSLNo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSLNo.Size = new System.Drawing.Size(71, 22);
            this.txtSLNo.TabIndex = 82;
            this.txtSLNo.Visible = false;
            // 
            // uctxtSecurityCode
            // 
            this.uctxtSecurityCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtSecurityCode.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtSecurityCode.Location = new System.Drawing.Point(514, 200);
            this.uctxtSecurityCode.Name = "uctxtSecurityCode";
            this.uctxtSecurityCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtSecurityCode.Size = new System.Drawing.Size(295, 22);
            this.uctxtSecurityCode.TabIndex = 87;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(396, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 88;
            this.label1.Text = "Securtity Code:";
            // 
            // btnSMS
            // 
            this.btnSMS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnSMS.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnSMS.ForeColor = System.Drawing.Color.Navy;
            this.btnSMS.Location = new System.Drawing.Point(735, 228);
            this.btnSMS.Name = "btnSMS";
            this.btnSMS.Size = new System.Drawing.Size(106, 41);
            this.btnSMS.TabIndex = 89;
            this.btnSMS.Text = "SMS";
            this.btnSMS.UseVisualStyleBackColor = false;
            this.btnSMS.Click += new System.EventHandler(this.btnSMS_Click);
            // 
            // frmOnlineOrderMapping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(940, 683);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmOnlineOrderMapping";
            this.Load += new System.EventHandler(this.frmOnlineOrderMapping_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DG;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox uctxtSeacrh;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox uctxtPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox uctxtUserID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtSLNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uctxtSecurityCode;
        private System.Windows.Forms.Button btnSMS;
    }
}
