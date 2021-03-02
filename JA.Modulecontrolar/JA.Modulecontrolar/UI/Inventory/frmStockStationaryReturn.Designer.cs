namespace JA.Modulecontrolar.UI.Inventory
{
    partial class frmStockStationaryReturn
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dteDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.uctxtToLocation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.uctxtNarration = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.DGright = new MayhediDataGridView();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.DG = new MayhediDataGridView();
            this.uctxtFromLocation = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGright)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).BeginInit();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(372, 9);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnGenerate);
            this.pnlMain.Controls.Add(this.panel2);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.uctxtNarration);
            this.pnlMain.Controls.Add(this.uctxtFromLocation);
            this.pnlMain.Controls.Add(this.dteDate);
            this.pnlMain.Controls.Add(this.label9);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.uctxtToLocation);
            this.pnlMain.Size = new System.Drawing.Size(953, 590);
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(956, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(83, 507);
            this.btnEdit.Size = new System.Drawing.Size(10, 10);
            this.btnEdit.Text = "List All";
            this.btnEdit.Visible = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(730, 509);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(288, 217);
            this.btnDelete.Size = new System.Drawing.Size(10, 11);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(266, 215);
            this.btnNew.Size = new System.Drawing.Size(10, 11);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(844, 509);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(311, 214);
            this.btnPrint.Size = new System.Drawing.Size(10, 11);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 552);
            this.groupBox1.Size = new System.Drawing.Size(956, 25);
            // 
            // dteDate
            // 
            this.dteDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteDate.Location = new System.Drawing.Point(140, 148);
            this.dteDate.Name = "dteDate";
            this.dteDate.Size = new System.Drawing.Size(326, 23);
            this.dteDate.TabIndex = 111;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(79, 153);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 16);
            this.label9.TabIndex = 112;
            this.label9.Text = "Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label1.Location = new System.Drawing.Point(29, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 16);
            this.label1.TabIndex = 108;
            this.label1.Text = "From Location:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label3.Location = new System.Drawing.Point(485, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 16);
            this.label3.TabIndex = 110;
            this.label3.Text = "To Location:";
            // 
            // uctxtToLocation
            // 
            this.uctxtToLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtToLocation.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtToLocation.Location = new System.Drawing.Point(582, 188);
            this.uctxtToLocation.Name = "uctxtToLocation";
            this.uctxtToLocation.Size = new System.Drawing.Size(320, 23);
            this.uctxtToLocation.TabIndex = 109;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label4.Location = new System.Drawing.Point(245, 554);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 16);
            this.label4.TabIndex = 115;
            this.label4.Text = "Narration:";
            // 
            // uctxtNarration
            // 
            this.uctxtNarration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtNarration.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtNarration.Location = new System.Drawing.Point(325, 551);
            this.uctxtNarration.Name = "uctxtNarration";
            this.uctxtNarration.Size = new System.Drawing.Size(422, 23);
            this.uctxtNarration.TabIndex = 114;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.DGright);
            this.panel2.Controls.Add(this.txtQty);
            this.panel2.Controls.Add(this.btnNext);
            this.panel2.Controls.Add(this.DG);
            this.panel2.Location = new System.Drawing.Point(5, 236);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(941, 299);
            this.panel2.TabIndex = 116;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(422, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 18);
            this.label6.TabIndex = 111;
            this.label6.Text = "Return Qty";
            this.label6.Visible = false;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(5, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(401, 23);
            this.txtSearch.TabIndex = 110;

            // 
            // DGright
            // 
            this.DGright.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGright.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGright.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGright.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGright.Location = new System.Drawing.Point(520, 11);
            this.DGright.Name = "DGright";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGright.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGright.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGright.Size = new System.Drawing.Size(415, 274);
            this.DGright.TabIndex = 107;
            this.DGright.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGright_CellContentClick);
            // 
            // txtQty
            // 
            this.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQty.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(448, 96);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(66, 23);
            this.txtQty.TabIndex = 106;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(414, 94);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(32, 26);
            this.btnNext.TabIndex = 98;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // DG
            // 
            this.DG.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DG.DefaultCellStyle = dataGridViewCellStyle5;
            this.DG.Location = new System.Drawing.Point(3, 28);
            this.DG.Name = "DG";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DG.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DG.Size = new System.Drawing.Size(404, 257);
            this.DG.TabIndex = 58;
            this.DG.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellContentClick);
            // 
            // uctxtFromLocation
            // 
            this.uctxtFromLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtFromLocation.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtFromLocation.Location = new System.Drawing.Point(140, 188);
            this.uctxtFromLocation.Name = "uctxtFromLocation";
            this.uctxtFromLocation.Size = new System.Drawing.Size(326, 23);
            this.uctxtFromLocation.TabIndex = 107;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(902, 186);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(29, 27);
            this.btnGenerate.TabIndex = 120;
            this.btnGenerate.Text = "G";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // frmStockStationaryReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(956, 577);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmStockStationaryReturn";
            this.Load += new System.EventHandler(this.frmStockStationaryReturn_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGright)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dteDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uctxtToLocation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox uctxtNarration;
        private System.Windows.Forms.Panel panel2;
        private MayhediDataGridView DG;
        private System.Windows.Forms.TextBox uctxtFromLocation;
        private System.Windows.Forms.Button btnGenerate;
        private MayhediDataGridView DGright;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label6;
    }
}
