namespace JA.Modulecontrolar.UI.Security.Forms
{
    partial class frmSecurityConfig
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblLedgerName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uctxtFormKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DG = new System.Windows.Forms.DataGridView();
            this.txtSlNo = new System.Windows.Forms.TextBox();
            this.cmoModuleConfig = new System.Windows.Forms.ComboBox();
            this.cboModeType = new System.Windows.Forms.ComboBox();
            this.uctxtformName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.uctxtSeacrh = new System.Windows.Forms.TextBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(337, 9);
            this.frmLabel.Size = new System.Drawing.Size(245, 33);
            this.frmLabel.Text = "Form Configuration";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.cboStatus);
            this.pnlMain.Controls.Add(this.label6);
            this.pnlMain.Controls.Add(this.groupBox2);
            this.pnlMain.Controls.Add(this.uctxtformName);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.cboModeType);
            this.pnlMain.Controls.Add(this.cmoModuleConfig);
            this.pnlMain.Controls.Add(this.DG);
            this.pnlMain.Controls.Add(this.uctxtFormKey);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.lblLedgerName);
            this.pnlMain.Size = new System.Drawing.Size(965, 700);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.txtSlNo);
            this.pnlTop.Size = new System.Drawing.Size(970, 58);
            this.pnlTop.Controls.SetChildIndex(this.frmLabel, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnTopClose, 0);
            this.pnlTop.Controls.SetChildIndex(this.txtSlNo, 0);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(10, 530);
            this.btnEdit.Size = new System.Drawing.Size(10, 10);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(738, 619);
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
            this.btnNew.Location = new System.Drawing.Point(6, 619);
            this.btnNew.Size = new System.Drawing.Size(120, 39);
            this.btnNew.Visible = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(847, 619);
            this.btnClose.Visible = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(234, 530);
            this.btnPrint.Size = new System.Drawing.Size(10, 10);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 663);
            this.groupBox1.Size = new System.Drawing.Size(970, 25);
            // 
            // lblLedgerName
            // 
            this.lblLedgerName.AutoSize = true;
            this.lblLedgerName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLedgerName.Location = new System.Drawing.Point(24, 160);
            this.lblLedgerName.Name = "lblLedgerName";
            this.lblLedgerName.Size = new System.Drawing.Size(101, 16);
            this.lblLedgerName.TabIndex = 52;
            this.lblLedgerName.Text = "Module Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(465, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 54;
            this.label1.Text = "Mode Type:";
            // 
            // uctxtFormKey
            // 
            this.uctxtFormKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtFormKey.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtFormKey.Location = new System.Drawing.Point(131, 187);
            this.uctxtFormKey.Name = "uctxtFormKey";
            this.uctxtFormKey.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtFormKey.Size = new System.Drawing.Size(285, 22);
            this.uctxtFormKey.TabIndex = 57;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(50, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 56;
            this.label3.Text = "Form Key:";
            // 
            // DG
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DG.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG.Location = new System.Drawing.Point(6, 275);
            this.DG.Name = "DG";
            this.DG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DG.Size = new System.Drawing.Size(948, 416);
            this.DG.TabIndex = 72;
            this.DG.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellClick);
            this.DG.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellContentClick);
            // 
            // txtSlNo
            // 
            this.txtSlNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSlNo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSlNo.Location = new System.Drawing.Point(54, 12);
            this.txtSlNo.Name = "txtSlNo";
            this.txtSlNo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSlNo.Size = new System.Drawing.Size(48, 22);
            this.txtSlNo.TabIndex = 70;
            this.txtSlNo.Visible = false;
            // 
            // cmoModuleConfig
            // 
            this.cmoModuleConfig.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmoModuleConfig.FormattingEnabled = true;
            this.cmoModuleConfig.Items.AddRange(new object[] {
            "Sales",
            "Purchase",
            "Inventory",
            "Accounts",
            "Projection",
            "Tools"});
            this.cmoModuleConfig.Location = new System.Drawing.Point(131, 160);
            this.cmoModuleConfig.Name = "cmoModuleConfig";
            this.cmoModuleConfig.Size = new System.Drawing.Size(285, 24);
            this.cmoModuleConfig.TabIndex = 73;
            // 
            // cboModeType
            // 
            this.cboModeType.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboModeType.FormattingEnabled = true;
            this.cboModeType.Location = new System.Drawing.Point(560, 160);
            this.cboModeType.Name = "cboModeType";
            this.cboModeType.Size = new System.Drawing.Size(157, 24);
            this.cboModeType.TabIndex = 74;
            // 
            // uctxtformName
            // 
            this.uctxtformName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtformName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtformName.Location = new System.Drawing.Point(560, 187);
            this.uctxtformName.Name = "uctxtformName";
            this.uctxtformName.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtformName.Size = new System.Drawing.Size(385, 22);
            this.uctxtformName.TabIndex = 76;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(436, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 16);
            this.label4.TabIndex = 75;
            this.label4.Text = "Norm Form Name:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblSearch);
            this.groupBox2.Controls.Add(this.uctxtSeacrh);
            this.groupBox2.Location = new System.Drawing.Point(12, 221);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(933, 48);
            this.groupBox2.TabIndex = 77;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(153, 21);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(87, 16);
            this.lblSearch.TabIndex = 59;
            this.lblSearch.Text = "Form Name:";
            // 
            // uctxtSeacrh
            // 
            this.uctxtSeacrh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtSeacrh.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtSeacrh.Location = new System.Drawing.Point(246, 19);
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
            this.cboStatus.Location = new System.Drawing.Point(807, 160);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(138, 24);
            this.cboStatus.TabIndex = 79;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(739, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 16);
            this.label6.TabIndex = 78;
            this.label6.Text = "Status:";
            // 
            // frmSecurityConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(970, 688);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmSecurityConfig";
            this.Load += new System.EventHandler(this.frmBranch_Load);
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

        private System.Windows.Forms.Label lblLedgerName;
        private System.Windows.Forms.TextBox uctxtFormKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DG;
        private System.Windows.Forms.TextBox txtSlNo;
        private System.Windows.Forms.ComboBox cboModeType;
        private System.Windows.Forms.ComboBox cmoModuleConfig;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox uctxtSeacrh;
        private System.Windows.Forms.TextBox uctxtformName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label label6;
    }
}
