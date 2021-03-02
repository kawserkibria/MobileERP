namespace JA.Modulecontrolar.UI.Accms.Forms
{
    partial class frmLoanSchedule
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
            this.uctxtTotalAmount = new System.Windows.Forms.TextBox();
            this.DG = new System.Windows.Forms.DataGridView();
            this.lblLedgerName = new System.Windows.Forms.Label();
            this.uctxtTemplateName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.uctxtNoOfIstallment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNetTotal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.uctxtAmount = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).BeginInit();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(138, 9);
            this.frmLabel.Size = new System.Drawing.Size(191, 33);
            this.frmLabel.Text = "Loan Template";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.uctxtAmount);
            this.pnlMain.Controls.Add(this.lblNetTotal);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.btnGenerate);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.uctxtNoOfIstallment);
            this.pnlMain.Controls.Add(this.uctxtTemplateName);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.lblLedgerName);
            this.pnlMain.Controls.Add(this.DG);
            this.pnlMain.Controls.Add(this.uctxtTotalAmount);
            this.pnlMain.Size = new System.Drawing.Size(500, 602);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.textBox1);
            this.pnlTop.Size = new System.Drawing.Size(502, 58);
            this.pnlTop.Controls.SetChildIndex(this.frmLabel, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnTopClose, 0);
            this.pnlTop.Controls.SetChildIndex(this.textBox1, 0);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(6, 519);
            this.btnEdit.Size = new System.Drawing.Size(122, 39);
            this.btnEdit.Text = "List All";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(278, 518);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(397, 161);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(186, 177);
            this.btnNew.Size = new System.Drawing.Size(14, 11);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(390, 518);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(397, 177);
            this.btnPrint.Size = new System.Drawing.Size(10, 10);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 564);
            this.groupBox1.Size = new System.Drawing.Size(502, 25);
            // 
            // uctxtTotalAmount
            // 
            this.uctxtTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtTotalAmount.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtTotalAmount.Location = new System.Drawing.Point(11, 211);
            this.uctxtTotalAmount.Name = "uctxtTotalAmount";
            this.uctxtTotalAmount.Size = new System.Drawing.Size(477, 22);
            this.uctxtTotalAmount.TabIndex = 0;
            // 
            // DG
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG.Location = new System.Drawing.Point(11, 298);
            this.DG.Name = "DG";
            this.DG.Size = new System.Drawing.Size(476, 271);
            this.DG.TabIndex = 2;
            this.DG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DG_KeyPress);
            // 
            // lblLedgerName
            // 
            this.lblLedgerName.AutoSize = true;
            this.lblLedgerName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLedgerName.Location = new System.Drawing.Point(14, 192);
            this.lblLedgerName.Name = "lblLedgerName";
            this.lblLedgerName.Size = new System.Drawing.Size(102, 16);
            this.lblLedgerName.TabIndex = 53;
            this.lblLedgerName.Text = "Total Amount:";
            // 
            // uctxtTemplateName
            // 
            this.uctxtTemplateName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtTemplateName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtTemplateName.Location = new System.Drawing.Point(11, 167);
            this.uctxtTemplateName.Name = "uctxtTemplateName";
            this.uctxtTemplateName.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtTemplateName.Size = new System.Drawing.Size(476, 22);
            this.uctxtTemplateName.TabIndex = 78;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 16);
            this.label5.TabIndex = 79;
            this.label5.Text = "Template Name:";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(13, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(80, 22);
            this.textBox1.TabIndex = 79;
            this.textBox1.Visible = false;
            // 
            // uctxtNoOfIstallment
            // 
            this.uctxtNoOfIstallment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtNoOfIstallment.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtNoOfIstallment.Location = new System.Drawing.Point(11, 263);
            this.uctxtNoOfIstallment.Name = "uctxtNoOfIstallment";
            this.uctxtNoOfIstallment.Size = new System.Drawing.Size(132, 22);
            this.uctxtNoOfIstallment.TabIndex = 80;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 16);
            this.label1.TabIndex = 81;
            this.label1.Text = "No. Of Installment:";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.Location = new System.Drawing.Point(396, 266);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(86, 23);
            this.btnGenerate.TabIndex = 82;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(157, 574);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 16);
            this.label3.TabIndex = 83;
            this.label3.Text = "Total Amount:";
            // 
            // lblNetTotal
            // 
            this.lblNetTotal.AutoSize = true;
            this.lblNetTotal.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetTotal.Location = new System.Drawing.Point(321, 574);
            this.lblNetTotal.Name = "lblNetTotal";
            this.lblNetTotal.Size = new System.Drawing.Size(15, 14);
            this.lblNetTotal.TabIndex = 84;
            this.lblNetTotal.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(165, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 16);
            this.label4.TabIndex = 86;
            this.label4.Text = "Installment Amount";
            // 
            // uctxtAmount
            // 
            this.uctxtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtAmount.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtAmount.Location = new System.Drawing.Point(162, 263);
            this.uctxtAmount.Name = "uctxtAmount";
            this.uctxtAmount.Size = new System.Drawing.Size(132, 22);
            this.uctxtAmount.TabIndex = 85;
            // 
            // frmLoanSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(502, 589);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmLoanSchedule";
            this.Load += new System.EventHandler(this.frmLoanScheduleList_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox uctxtTotalAmount;
        private System.Windows.Forms.DataGridView DG;
        private System.Windows.Forms.Label lblLedgerName;
        private System.Windows.Forms.TextBox uctxtTemplateName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uctxtNoOfIstallment;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label lblNetTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox uctxtAmount;
    }
}
