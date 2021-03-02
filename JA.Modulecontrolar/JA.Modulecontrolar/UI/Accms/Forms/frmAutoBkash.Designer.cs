namespace JA.Modulecontrolar.UI.Accms.Forms
{
    partial class frmAutoBkash
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.uctxtLedgerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSelectionType = new System.Windows.Forms.Label();
            this.cboGeneral = new System.Windows.Forms.ComboBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblFileName = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmLabel.Location = new System.Drawing.Point(171, 5);
            this.frmLabel.Size = new System.Drawing.Size(237, 25);
            this.frmLabel.Text = "Auto Receipt Voucher";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.lblTotal);
            this.pnlMain.Controls.Add(this.lblFileName);
            this.pnlMain.Controls.Add(this.dataGridView1);
            this.pnlMain.Controls.Add(this.btnImport);
            this.pnlMain.Controls.Add(this.lblSelectionType);
            this.pnlMain.Controls.Add(this.cboGeneral);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.uctxtLedgerName);
            this.pnlMain.Controls.Add(this.progressBar1);
            this.pnlMain.Size = new System.Drawing.Size(587, 368);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(590, 42);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(306, 287);
            this.btnEdit.Size = new System.Drawing.Size(132, 40);
            this.btnEdit.Text = "Save";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(57, 12);
            this.btnSave.Size = new System.Drawing.Size(10, 10);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(109, 7);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(50, 216);
            this.btnNew.Size = new System.Drawing.Size(17, 20);
            this.btnNew.Text = "Generate";
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(439, 287);
            this.btnClose.Size = new System.Drawing.Size(147, 40);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(140, 15);
            this.btnPrint.Size = new System.Drawing.Size(10, 10);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 330);
            this.groupBox1.Size = new System.Drawing.Size(590, 25);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(9, 281);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(570, 23);
            this.progressBar1.TabIndex = 10;
            // 
            // uctxtLedgerName
            // 
            this.uctxtLedgerName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtLedgerName.Location = new System.Drawing.Point(126, 208);
            this.uctxtLedgerName.Name = "uctxtLedgerName";
            this.uctxtLedgerName.Size = new System.Drawing.Size(321, 22);
            this.uctxtLedgerName.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(125, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 14);
            this.label1.TabIndex = 14;
            this.label1.Text = "Bank Name:";
            // 
            // lblSelectionType
            // 
            this.lblSelectionType.AutoSize = true;
            this.lblSelectionType.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectionType.ForeColor = System.Drawing.Color.Black;
            this.lblSelectionType.Location = new System.Drawing.Point(125, 131);
            this.lblSelectionType.Name = "lblSelectionType";
            this.lblSelectionType.Size = new System.Drawing.Size(114, 16);
            this.lblSelectionType.TabIndex = 220;
            this.lblSelectionType.Text = "Selection Type";
            // 
            // cboGeneral
            // 
            this.cboGeneral.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGeneral.FormattingEnabled = true;
            this.cboGeneral.Location = new System.Drawing.Point(126, 151);
            this.cboGeneral.Name = "cboGeneral";
            this.cboGeneral.Size = new System.Drawing.Size(190, 22);
            this.cboGeneral.TabIndex = 0;
            this.cboGeneral.SelectedIndexChanged += new System.EventHandler(this.cboGeneral_SelectedIndexChanged);
            this.cboGeneral.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboGeneral_KeyPress);
            // 
            // btnImport
            // 
            this.btnImport.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Location = new System.Drawing.Point(447, 207);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(79, 23);
            this.btnImport.TabIndex = 221;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(5, 310);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(577, 2);
            this.dataGridView1.TabIndex = 223;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileName.ForeColor = System.Drawing.Color.Red;
            this.lblFileName.Location = new System.Drawing.Point(126, 247);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(0, 14);
            this.lblFileName.TabIndex = 224;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(392, 332);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(15, 14);
            this.lblTotal.TabIndex = 225;
            this.lblTotal.Text = "0";
            // 
            // frmAutoBkash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(590, 355);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmAutoBkash";
            this.Load += new System.EventHandler(this.frmAutoBkash_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uctxtLedgerName;
        private System.Windows.Forms.Label lblSelectionType;
        private System.Windows.Forms.ComboBox cboGeneral;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Label lblTotal;

    }
}
