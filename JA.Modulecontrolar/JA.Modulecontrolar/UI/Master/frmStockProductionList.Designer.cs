namespace JA.Modulecontrolar.UI.Master
{
    partial class frmStockProductionList
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
            this.DG = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.PanelSearch = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTodate = new System.Windows.Forms.Label();
            this.lblfromDate = new System.Windows.Forms.Label();
            this.uctxtToDate = new System.Windows.Forms.TextBox();
            this.uctxtFromDate = new System.Windows.Forms.TextBox();
            this.uctxtExpression = new System.Windows.Forms.TextBox();
            this.lblExpression = new System.Windows.Forms.Label();
            this.uctxtFindWhat = new System.Windows.Forms.TextBox();
            this.lblFindwhat = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).BeginInit();
            this.PanelSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(279, 6);
            this.frmLabel.Size = new System.Drawing.Size(338, 33);
            this.frmLabel.Text = "Manufacturing Voucher List";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.PanelSearch);
            this.pnlMain.Controls.Add(this.DG);
            this.pnlMain.Size = new System.Drawing.Size(971, 564);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.btnSearch);
            this.pnlTop.Size = new System.Drawing.Size(974, 58);
            this.pnlTop.Controls.SetChildIndex(this.frmLabel, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnTopClose, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnSearch, 0);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(412, 62);
            this.btnEdit.Size = new System.Drawing.Size(10, 7);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(223, 60);
            this.btnSave.Size = new System.Drawing.Size(10, 7);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(525, 62);
            this.btnDelete.Size = new System.Drawing.Size(10, 7);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(186, 62);
            this.btnNew.Size = new System.Drawing.Size(10, 7);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(747, 62);
            this.btnClose.Size = new System.Drawing.Size(10, 7);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(636, 62);
            this.btnPrint.Size = new System.Drawing.Size(10, 7);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 478);
            this.groupBox1.Size = new System.Drawing.Size(974, 25);
            // 
            // DG
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DG.DefaultCellStyle = dataGridViewCellStyle2;
            this.DG.Location = new System.Drawing.Point(6, 148);
            this.DG.Name = "DG";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DG.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DG.Size = new System.Drawing.Size(961, 411);
            this.DG.TabIndex = 74;
            this.DG.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGMFGVoucherList_CellContentClick);
            this.DG.DoubleClick += new System.EventHandler(this.DGMFGVoucherList_DoubleClick);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(10, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(129, 37);
            this.btnSearch.TabIndex = 18;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // PanelSearch
            // 
            this.PanelSearch.Controls.Add(this.button1);
            this.PanelSearch.Controls.Add(this.btnCancel);
            this.PanelSearch.Controls.Add(this.lblTodate);
            this.PanelSearch.Controls.Add(this.lblfromDate);
            this.PanelSearch.Controls.Add(this.uctxtToDate);
            this.PanelSearch.Controls.Add(this.uctxtFromDate);
            this.PanelSearch.Controls.Add(this.uctxtExpression);
            this.PanelSearch.Controls.Add(this.lblExpression);
            this.PanelSearch.Controls.Add(this.uctxtFindWhat);
            this.PanelSearch.Controls.Add(this.lblFindwhat);
            this.PanelSearch.Location = new System.Drawing.Point(269, 227);
            this.PanelSearch.Name = "PanelSearch";
            this.PanelSearch.Size = new System.Drawing.Size(364, 195);
            this.PanelSearch.TabIndex = 77;
            this.PanelSearch.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(363, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(5, 167);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(356, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblTodate
            // 
            this.lblTodate.AutoSize = true;
            this.lblTodate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTodate.Location = new System.Drawing.Point(32, 108);
            this.lblTodate.Name = "lblTodate";
            this.lblTodate.Size = new System.Drawing.Size(60, 14);
            this.lblTodate.TabIndex = 11;
            this.lblTodate.Text = "To Date:";
            this.lblTodate.Visible = false;
            // 
            // lblfromDate
            // 
            this.lblfromDate.AutoSize = true;
            this.lblfromDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfromDate.Location = new System.Drawing.Point(15, 84);
            this.lblfromDate.Name = "lblfromDate";
            this.lblfromDate.Size = new System.Drawing.Size(77, 14);
            this.lblfromDate.TabIndex = 10;
            this.lblfromDate.Text = "From Date:";
            this.lblfromDate.Visible = false;
            // 
            // uctxtToDate
            // 
            this.uctxtToDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtToDate.Location = new System.Drawing.Point(95, 104);
            this.uctxtToDate.Name = "uctxtToDate";
            this.uctxtToDate.Size = new System.Drawing.Size(245, 23);
            this.uctxtToDate.TabIndex = 9;
            this.uctxtToDate.Visible = false;
            // 
            // uctxtFromDate
            // 
            this.uctxtFromDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtFromDate.Location = new System.Drawing.Point(95, 80);
            this.uctxtFromDate.Name = "uctxtFromDate";
            this.uctxtFromDate.Size = new System.Drawing.Size(245, 23);
            this.uctxtFromDate.TabIndex = 8;
            this.uctxtFromDate.Visible = false;
            // 
            // uctxtExpression
            // 
            this.uctxtExpression.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtExpression.Location = new System.Drawing.Point(95, 56);
            this.uctxtExpression.Name = "uctxtExpression";
            this.uctxtExpression.Size = new System.Drawing.Size(245, 23);
            this.uctxtExpression.TabIndex = 7;
            // 
            // lblExpression
            // 
            this.lblExpression.AutoSize = true;
            this.lblExpression.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpression.Location = new System.Drawing.Point(11, 59);
            this.lblExpression.Name = "lblExpression";
            this.lblExpression.Size = new System.Drawing.Size(81, 14);
            this.lblExpression.TabIndex = 6;
            this.lblExpression.Text = "Expression:";
            // 
            // uctxtFindWhat
            // 
            this.uctxtFindWhat.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtFindWhat.Location = new System.Drawing.Point(95, 26);
            this.uctxtFindWhat.Name = "uctxtFindWhat";
            this.uctxtFindWhat.Size = new System.Drawing.Size(245, 23);
            this.uctxtFindWhat.TabIndex = 5;
            // 
            // lblFindwhat
            // 
            this.lblFindwhat.AutoSize = true;
            this.lblFindwhat.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFindwhat.Location = new System.Drawing.Point(16, 32);
            this.lblFindwhat.Name = "lblFindwhat";
            this.lblFindwhat.Size = new System.Drawing.Size(76, 14);
            this.lblFindwhat.TabIndex = 4;
            this.lblFindwhat.Text = "Find What:";
            // 
            // frmStockProductionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(974, 503);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmStockProductionList";
            this.Load += new System.EventHandler(this.frmMFGVoucherList_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).EndInit();
            this.PanelSearch.ResumeLayout(false);
            this.PanelSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DG;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel PanelSearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTodate;
        private System.Windows.Forms.Label lblfromDate;
        private System.Windows.Forms.TextBox uctxtToDate;
        private System.Windows.Forms.TextBox uctxtFromDate;
        private System.Windows.Forms.TextBox uctxtExpression;
        private System.Windows.Forms.Label lblExpression;
        private System.Windows.Forms.TextBox uctxtFindWhat;
        private System.Windows.Forms.Label lblFindwhat;
    }
}
