namespace JA.Modulecontrolar.UI.Sales
{
    partial class frmItem_PowerClassWiseTarget
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uctxtbranchName = new System.Windows.Forms.TextBox();
            this.dteTodate = new System.Windows.Forms.DateTimePicker();
            this.dtefromDate = new System.Windows.Forms.DateTimePicker();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblDisplay = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.radItemWise = new System.Windows.Forms.RadioButton();
            this.radPackSize = new System.Windows.Forms.RadioButton();
            this.txtOldKey = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.DG = new MayhediDataGridView();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).BeginInit();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(484, 4);
            this.frmLabel.Size = new System.Drawing.Size(223, 33);
            this.frmLabel.Text = "Collection Target ";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.radPackSize);
            this.pnlMain.Controls.Add(this.radItemWise);
            this.pnlMain.Controls.Add(this.lblDisplay);
            this.pnlMain.Controls.Add(this.DG);
            this.pnlMain.Controls.Add(this.btnImport);
            this.pnlMain.Controls.Add(this.btnGenerate);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.uctxtbranchName);
            this.pnlMain.Controls.Add(this.dteTodate);
            this.pnlMain.Controls.Add(this.dtefromDate);
            this.pnlMain.Size = new System.Drawing.Size(1198, 560);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.txtOldKey);
            this.pnlTop.Controls.Add(this.textBox1);
            this.pnlTop.Size = new System.Drawing.Size(1201, 58);
            this.pnlTop.Controls.SetChildIndex(this.frmLabel, 0);
            this.pnlTop.Controls.SetChildIndex(this.textBox1, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnTopClose, 0);
            this.pnlTop.Controls.SetChildIndex(this.txtOldKey, 0);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(6, 473);
            this.btnEdit.Size = new System.Drawing.Size(137, 39);
            this.btnEdit.Text = "List All";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(960, 473);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(621, 489);
            this.btnDelete.Size = new System.Drawing.Size(12, 13);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(596, 489);
            this.btnNew.Size = new System.Drawing.Size(10, 13);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1074, 473);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(727, 489);
            this.btnPrint.Size = new System.Drawing.Size(17, 13);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 512);
            this.groupBox1.Size = new System.Drawing.Size(1201, 25);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(314, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 14);
            this.label4.TabIndex = 14;
            this.label4.Text = "Branch Name :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(47, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 14);
            this.label3.TabIndex = 13;
            this.label3.Text = "To Date :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 14);
            this.label1.TabIndex = 12;
            this.label1.Text = "From Date :";
            // 
            // uctxtbranchName
            // 
            this.uctxtbranchName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtbranchName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtbranchName.Location = new System.Drawing.Point(421, 163);
            this.uctxtbranchName.Name = "uctxtbranchName";
            this.uctxtbranchName.Size = new System.Drawing.Size(315, 22);
            this.uctxtbranchName.TabIndex = 11;
            // 
            // dteTodate
            // 
            this.dteTodate.CalendarFont = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteTodate.Enabled = false;
            this.dteTodate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteTodate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteTodate.Location = new System.Drawing.Point(120, 175);
            this.dteTodate.Name = "dteTodate";
            this.dteTodate.Size = new System.Drawing.Size(172, 22);
            this.dteTodate.TabIndex = 10;
            // 
            // dtefromDate
            // 
            this.dtefromDate.CalendarFont = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtefromDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtefromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtefromDate.Location = new System.Drawing.Point(120, 151);
            this.dtefromDate.Name = "dtefromDate";
            this.dtefromDate.Size = new System.Drawing.Size(172, 22);
            this.dtefromDate.TabIndex = 9;
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnGenerate.Location = new System.Drawing.Point(737, 162);
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
            this.btnImport.Size = new System.Drawing.Size(106, 41);
            this.btnImport.TabIndex = 17;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Visible = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 18;
            this.textBox1.Visible = false;
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
            this.lblCount.Location = new System.Drawing.Point(234, 483);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(0, 16);
            this.lblCount.TabIndex = 15;
            // 
            // radItemWise
            // 
            this.radItemWise.AutoSize = true;
            this.radItemWise.Checked = true;
            this.radItemWise.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radItemWise.Location = new System.Drawing.Point(816, 158);
            this.radItemWise.Name = "radItemWise";
            this.radItemWise.Size = new System.Drawing.Size(89, 18);
            this.radItemWise.TabIndex = 23;
            this.radItemWise.TabStop = true;
            this.radItemWise.Text = "Item Wise";
            this.radItemWise.UseVisualStyleBackColor = true;
            this.radItemWise.Click += new System.EventHandler(this.radItemWise_Click);
            // 
            // radPackSize
            // 
            this.radPackSize.AutoSize = true;
            this.radPackSize.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPackSize.Location = new System.Drawing.Point(924, 158);
            this.radPackSize.Name = "radPackSize";
            this.radPackSize.Size = new System.Drawing.Size(84, 18);
            this.radPackSize.TabIndex = 24;
            this.radPackSize.Text = "Pack Size";
            this.radPackSize.UseVisualStyleBackColor = true;
            this.radPackSize.CheckedChanged += new System.EventHandler(this.radPackSize_CheckedChanged);
            // 
            // txtOldKey
            // 
            this.txtOldKey.Location = new System.Drawing.Point(193, 12);
            this.txtOldKey.Name = "txtOldKey";
            this.txtOldKey.Size = new System.Drawing.Size(100, 20);
            this.txtOldKey.TabIndex = 19;
            this.txtOldKey.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(422, 477);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(484, 23);
            this.progressBar1.TabIndex = 16;
            // 
            // DG
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DG.DefaultCellStyle = dataGridViewCellStyle2;
            this.DG.Location = new System.Drawing.Point(5, 203);
            this.DG.Name = "DG";
            this.DG.Size = new System.Drawing.Size(1188, 352);
            this.DG.TabIndex = 19;
            this.DG.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellEndEdit);
            // 
            // frmItem_PowerClassWiseTarget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1201, 537);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblCount);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmItem_PowerClassWiseTarget";
            this.Load += new System.EventHandler(this.frmCollectionCommitement_Load);
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
        private System.Windows.Forms.Label lblDisplay;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.RadioButton radPackSize;
        private System.Windows.Forms.RadioButton radItemWise;
        private System.Windows.Forms.TextBox txtOldKey;
        private System.Windows.Forms.ProgressBar progressBar1;
        private MayhediDataGridView DG;
    }
}
