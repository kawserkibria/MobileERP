namespace JA.Modulecontrolar.UI.Inventory
{
    partial class frmCommissionConfig
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label5 = new System.Windows.Forms.Label();
            this.uctxtBranch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uctxtGroupConfig = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dteEffectiveDate = new System.Windows.Forms.DateTimePicker();
            this.DG = new MayhediDataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radStaff = new System.Windows.Forms.RadioButton();
            this.radNormal = new System.Windows.Forms.RadioButton();
            this.txtOldKey = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(169, 8);
            this.frmLabel.Size = new System.Drawing.Size(326, 33);
            this.frmLabel.Text = "Commission Configuration";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.DG);
            this.pnlMain.Controls.Add(this.dteEffectiveDate);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.uctxtGroupConfig);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.uctxtBranch);
            this.pnlMain.Size = new System.Drawing.Size(626, 583);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.txtOldKey);
            this.pnlTop.Controls.Add(this.panel2);
            this.pnlTop.Size = new System.Drawing.Size(628, 58);
            this.pnlTop.Controls.SetChildIndex(this.frmLabel, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnTopClose, 0);
            this.pnlTop.Controls.SetChildIndex(this.panel2, 0);
            this.pnlTop.Controls.SetChildIndex(this.txtOldKey, 0);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(6, 500);
            this.btnEdit.Size = new System.Drawing.Size(121, 39);
            this.btnEdit.Text = "List All";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(400, 500);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(150, 430);
            this.btnDelete.Size = new System.Drawing.Size(8, 15);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(36, 425);
            this.btnNew.Size = new System.Drawing.Size(11, 15);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(511, 500);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(361, 426);
            this.btnPrint.Size = new System.Drawing.Size(3, 15);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 544);
            this.groupBox1.Size = new System.Drawing.Size(628, 25);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(123, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 18);
            this.label5.TabIndex = 52;
            this.label5.Text = "Branch:";
            // 
            // uctxtBranch
            // 
            this.uctxtBranch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtBranch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtBranch.Location = new System.Drawing.Point(195, 166);
            this.uctxtBranch.Name = "uctxtBranch";
            this.uctxtBranch.Size = new System.Drawing.Size(377, 23);
            this.uctxtBranch.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 18);
            this.label1.TabIndex = 54;
            this.label1.Text = "Group Config. Name:";
            // 
            // uctxtGroupConfig
            // 
            this.uctxtGroupConfig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtGroupConfig.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtGroupConfig.Location = new System.Drawing.Point(195, 192);
            this.uctxtGroupConfig.MaxLength = 50;
            this.uctxtGroupConfig.Name = "uctxtGroupConfig";
            this.uctxtGroupConfig.Size = new System.Drawing.Size(377, 23);
            this.uctxtGroupConfig.TabIndex = 53;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(71, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 18);
            this.label3.TabIndex = 56;
            this.label3.Text = "Effective Date:";
            // 
            // dteEffectiveDate
            // 
            this.dteEffectiveDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteEffectiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteEffectiveDate.Location = new System.Drawing.Point(195, 219);
            this.dteEffectiveDate.Name = "dteEffectiveDate";
            this.dteEffectiveDate.Size = new System.Drawing.Size(158, 22);
            this.dteEffectiveDate.TabIndex = 57;
            // 
            // DG
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DG.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG.Location = new System.Drawing.Point(4, 249);
            this.DG.Name = "DG";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DG.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DG.Size = new System.Drawing.Size(615, 323);
            this.DG.TabIndex = 58;
            this.DG.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellDoubleClick);
            this.DG.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellEndEdit);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radStaff);
            this.panel2.Controls.Add(this.radNormal);
            this.panel2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(12, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(175, 33);
            this.panel2.TabIndex = 59;
            this.panel2.Visible = false;
            // 
            // radStaff
            // 
            this.radStaff.AutoSize = true;
            this.radStaff.Location = new System.Drawing.Point(108, 8);
            this.radStaff.Name = "radStaff";
            this.radStaff.Size = new System.Drawing.Size(56, 17);
            this.radStaff.TabIndex = 1;
            this.radStaff.Text = "Staff";
            this.radStaff.UseVisualStyleBackColor = true;
            // 
            // radNormal
            // 
            this.radNormal.AutoSize = true;
            this.radNormal.Checked = true;
            this.radNormal.Location = new System.Drawing.Point(23, 7);
            this.radNormal.Name = "radNormal";
            this.radNormal.Size = new System.Drawing.Size(72, 17);
            this.radNormal.TabIndex = 0;
            this.radNormal.TabStop = true;
            this.radNormal.Text = "Normal";
            this.radNormal.UseVisualStyleBackColor = true;
            // 
            // txtOldKey
            // 
            this.txtOldKey.Location = new System.Drawing.Point(547, 19);
            this.txtOldKey.Name = "txtOldKey";
            this.txtOldKey.Size = new System.Drawing.Size(25, 20);
            this.txtOldKey.TabIndex = 60;
            this.txtOldKey.Visible = false;
            // 
            // frmCommissionConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(628, 569);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmCommissionConfig";
            this.Load += new System.EventHandler(this.frmCommissionConfig_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox uctxtBranch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uctxtGroupConfig;
        private MayhediDataGridView DG;
        private System.Windows.Forms.DateTimePicker dteEffectiveDate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radStaff;
        private System.Windows.Forms.RadioButton radNormal;
        private System.Windows.Forms.TextBox txtOldKey;
    }
}
