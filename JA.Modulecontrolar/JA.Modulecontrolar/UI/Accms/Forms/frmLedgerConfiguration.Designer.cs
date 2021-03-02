namespace JA.Modulecontrolar.UI.Accms.Forms
{
    partial class frmLedgerConfiguration
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.uctxtLedgerNamee = new System.Windows.Forms.TextBox();
            this.dtefromDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.DG = new MayhediDataGridView();
            this.StrConfigkey = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).BeginInit();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Font = new System.Drawing.Font("Tahoma", 20.25F);
            this.frmLabel.Location = new System.Drawing.Point(215, 8);
            this.frmLabel.Size = new System.Drawing.Size(264, 33);
            this.frmLabel.Text = "Ledger Configuration";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.StrConfigkey);
            this.pnlMain.Controls.Add(this.DG);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.dtefromDate);
            this.pnlMain.Controls.Add(this.uctxtLedgerNamee);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Size = new System.Drawing.Size(673, 480);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(676, 52);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(134, 396);
            this.btnEdit.Size = new System.Drawing.Size(20, 10);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(419, 397);
            this.btnSave.Size = new System.Drawing.Size(122, 38);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(160, 396);
            this.btnDelete.Size = new System.Drawing.Size(15, 10);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(1, 396);
            this.btnNew.Size = new System.Drawing.Size(122, 38);
            this.btnNew.Text = "List All";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(546, 398);
            this.btnClose.Size = new System.Drawing.Size(122, 38);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(181, 396);
            this.btnPrint.Size = new System.Drawing.Size(10, 12);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 441);
            this.groupBox1.Size = new System.Drawing.Size(676, 25);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Expense Ledger Name :";
            // 
            // uctxtLedgerNamee
            // 
            this.uctxtLedgerNamee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtLedgerNamee.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtLedgerNamee.Location = new System.Drawing.Point(185, 154);
            this.uctxtLedgerNamee.Name = "uctxtLedgerNamee";
            this.uctxtLedgerNamee.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtLedgerNamee.Size = new System.Drawing.Size(438, 22);
            this.uctxtLedgerNamee.TabIndex = 69;
            // 
            // dtefromDate
            // 
            this.dtefromDate.CalendarFont = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtefromDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtefromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtefromDate.Location = new System.Drawing.Point(185, 178);
            this.dtefromDate.Name = "dtefromDate";
            this.dtefromDate.Size = new System.Drawing.Size(152, 22);
            this.dtefromDate.TabIndex = 70;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(75, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 17);
            this.label3.TabIndex = 71;
            this.label3.Text = "Effective Date :";
            // 
            // DG
            // 
            this.DG.AllowUserToDeleteRows = false;
            this.DG.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG.EnableHeadersVisualStyles = false;
            this.DG.Location = new System.Drawing.Point(5, 217);
            this.DG.Name = "DG";
            this.DG.RowHeadersWidth = 15;
            this.DG.Size = new System.Drawing.Size(660, 257);
            this.DG.TabIndex = 72;
            this.DG.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellDoubleClick);
            this.DG.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellEnter);
            // 
            // StrConfigkey
            // 
            this.StrConfigkey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StrConfigkey.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StrConfigkey.Location = new System.Drawing.Point(11, 132);
            this.StrConfigkey.Name = "StrConfigkey";
            this.StrConfigkey.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.StrConfigkey.Size = new System.Drawing.Size(10, 22);
            this.StrConfigkey.TabIndex = 73;
            this.StrConfigkey.Visible = false;
            // 
            // frmLedgerConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(676, 466);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmLedgerConfiguration";
            this.Load += new System.EventHandler(this.frmLedgerConfiguration_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uctxtLedgerNamee;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtefromDate;
        private MayhediDataGridView DG;
        private System.Windows.Forms.TextBox StrConfigkey;

    }
}
