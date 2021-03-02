namespace JA.Modulecontrolar.UI.Sales
{
    partial class frmTarget
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uctxtbranchName = new System.Windows.Forms.TextBox();
            this.dteTodate = new System.Windows.Forms.DateTimePicker();
            this.dtefromDate = new System.Windows.Forms.DateTimePicker();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.DG = new MayhediDataGridView();
            this.lblDisplay = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblTotalrecord = new System.Windows.Forms.Label();
            this.btnCheckExcelSheet = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblLedgerName = new System.Windows.Forms.Label();
            this.uctxtLedgerName = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).BeginInit();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(540, 3);
            this.frmLabel.Size = new System.Drawing.Size(93, 33);
            this.frmLabel.Text = "Target";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.dateTimePicker1);
            this.pnlMain.Controls.Add(this.lblLedgerName);
            this.pnlMain.Controls.Add(this.lblTotalrecord);
            this.pnlMain.Controls.Add(this.lblDisplay);
            this.pnlMain.Controls.Add(this.DG);
            this.pnlMain.Controls.Add(this.textBox1);
            this.pnlMain.Controls.Add(this.btnImport);
            this.pnlMain.Controls.Add(this.btnGenerate);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.uctxtbranchName);
            this.pnlMain.Controls.Add(this.dteTodate);
            this.pnlMain.Controls.Add(this.dtefromDate);
            this.pnlMain.Controls.Add(this.uctxtLedgerName);
            this.pnlMain.Size = new System.Drawing.Size(1198, 553);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(1199, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(6, 469);
            this.btnEdit.Size = new System.Drawing.Size(137, 39);
            this.btnEdit.Text = "List All";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(960, 469);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(621, 485);
            this.btnDelete.Size = new System.Drawing.Size(12, 13);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(596, 485);
            this.btnNew.Size = new System.Drawing.Size(10, 13);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1074, 469);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(727, 485);
            this.btnPrint.Size = new System.Drawing.Size(17, 13);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 509);
            this.groupBox1.Size = new System.Drawing.Size(1199, 25);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(402, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 14);
            this.label4.TabIndex = 14;
            this.label4.Text = "Branch Name :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(437, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 14);
            this.label3.TabIndex = 13;
            this.label3.Text = "To Date :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(420, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 14);
            this.label1.TabIndex = 12;
            this.label1.Text = "From Date :";
            // 
            // uctxtbranchName
            // 
            this.uctxtbranchName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtbranchName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtbranchName.Location = new System.Drawing.Point(510, 194);
            this.uctxtbranchName.Name = "uctxtbranchName";
            this.uctxtbranchName.Size = new System.Drawing.Size(482, 22);
            this.uctxtbranchName.TabIndex = 11;
            // 
            // dteTodate
            // 
            this.dteTodate.CalendarFont = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteTodate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteTodate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteTodate.Location = new System.Drawing.Point(510, 171);
            this.dteTodate.Name = "dteTodate";
            this.dteTodate.Size = new System.Drawing.Size(172, 22);
            this.dteTodate.TabIndex = 10;
            // 
            // dtefromDate
            // 
            this.dtefromDate.CalendarFont = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtefromDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtefromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtefromDate.Location = new System.Drawing.Point(510, 147);
            this.dtefromDate.Name = "dtefromDate";
            this.dtefromDate.Size = new System.Drawing.Size(172, 22);
            this.dtefromDate.TabIndex = 9;
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnGenerate.Location = new System.Drawing.Point(992, 192);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(32, 23);
            this.btnGenerate.TabIndex = 16;
            this.btnGenerate.Text = "...";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.Yellow;
            this.btnImport.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Location = new System.Drawing.Point(1082, 151);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(106, 61);
            this.btnImport.TabIndex = 17;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(49, 149);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 18;
            this.textBox1.Visible = false;
            // 
            // DG
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DG.DefaultCellStyle = dataGridViewCellStyle4;
            this.DG.Location = new System.Drawing.Point(5, 243);
            this.DG.Name = "DG";
            this.DG.Size = new System.Drawing.Size(1188, 305);
            this.DG.TabIndex = 19;
            // 
            // lblDisplay
            // 
            this.lblDisplay.AutoSize = true;
            this.lblDisplay.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplay.ForeColor = System.Drawing.Color.Red;
            this.lblDisplay.Location = new System.Drawing.Point(55, 180);
            this.lblDisplay.Name = "lblDisplay";
            this.lblDisplay.Size = new System.Drawing.Size(0, 16);
            this.lblDisplay.TabIndex = 20;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.ForeColor = System.Drawing.Color.Red;
            this.lblCount.Location = new System.Drawing.Point(229, 491);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(16, 16);
            this.lblCount.TabIndex = 15;
            this.lblCount.Text = "0";
            this.lblCount.Visible = false;
            // 
            // lblTotalrecord
            // 
            this.lblTotalrecord.AutoSize = true;
            this.lblTotalrecord.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalrecord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblTotalrecord.Location = new System.Drawing.Point(9, 201);
            this.lblTotalrecord.Name = "lblTotalrecord";
            this.lblTotalrecord.Size = new System.Drawing.Size(0, 14);
            this.lblTotalrecord.TabIndex = 21;
            // 
            // btnCheckExcelSheet
            // 
            this.btnCheckExcelSheet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnCheckExcelSheet.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnCheckExcelSheet.Location = new System.Drawing.Point(854, 468);
            this.btnCheckExcelSheet.Name = "btnCheckExcelSheet";
            this.btnCheckExcelSheet.Size = new System.Drawing.Size(105, 41);
            this.btnCheckExcelSheet.TabIndex = 22;
            this.btnCheckExcelSheet.Text = "Check Excel";
            this.btnCheckExcelSheet.UseVisualStyleBackColor = false;
            this.btnCheckExcelSheet.Click += new System.EventHandler(this.btnCheckExcelSheet_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(153, 469);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(694, 16);
            this.progressBar1.TabIndex = 23;
            // 
            // lblLedgerName
            // 
            this.lblLedgerName.AutoSize = true;
            this.lblLedgerName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLedgerName.Location = new System.Drawing.Point(402, 220);
            this.lblLedgerName.Name = "lblLedgerName";
            this.lblLedgerName.Size = new System.Drawing.Size(100, 14);
            this.lblLedgerName.TabIndex = 22;
            this.lblLedgerName.Text = "Ledger Name :";
            this.lblLedgerName.Visible = false;
            // 
            // uctxtLedgerName
            // 
            this.uctxtLedgerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtLedgerName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtLedgerName.Location = new System.Drawing.Point(510, 217);
            this.uctxtLedgerName.Name = "uctxtLedgerName";
            this.uctxtLedgerName.Size = new System.Drawing.Size(482, 22);
            this.uctxtLedgerName.TabIndex = 23;
            this.uctxtLedgerName.Visible = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(231, 174);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(62, 22);
            this.dateTimePicker1.TabIndex = 24;
            this.dateTimePicker1.Visible = false;
            // 
            // frmTarget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1199, 534);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnCheckExcelSheet);
            this.Controls.Add(this.lblCount);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmTarget";
            this.Load += new System.EventHandler(this.frmTarget_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.pnlMain, 0);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.Controls.SetChildIndex(this.lblCount, 0);
            this.Controls.SetChildIndex(this.btnCheckExcelSheet, 0);
            this.Controls.SetChildIndex(this.progressBar1, 0);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uctxtbranchName;
        private System.Windows.Forms.DateTimePicker dteTodate;
        private System.Windows.Forms.DateTimePicker dtefromDate;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.TextBox textBox1;
        private MayhediDataGridView DG;
        private System.Windows.Forms.Label lblDisplay;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblTotalrecord;
        private System.Windows.Forms.Button btnCheckExcelSheet;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox uctxtLedgerName;
        private System.Windows.Forms.Label lblLedgerName;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}
