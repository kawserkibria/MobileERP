namespace JA.Modulecontrolar.UI.Accms.Forms
{
    partial class frmAccountsVoucherList
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccountsVoucherList));
            this.DG = new System.Windows.Forms.DataGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnpreview = new System.Windows.Forms.Button();
            this.btnDPrint = new System.Windows.Forms.Button();
            this.btnFocus = new System.Windows.Forms.Button();
            this.lblAmount = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).BeginInit();
            this.PanelSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(472, 9);
            this.frmLabel.Size = new System.Drawing.Size(160, 33);
            this.frmLabel.Text = "Voucher List";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.PanelSearch);
            this.pnlMain.Controls.Add(this.DG);
            this.pnlMain.Size = new System.Drawing.Size(1190, 596);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.btnFocus);
            this.pnlTop.Controls.Add(this.btnDPrint);
            this.pnlTop.Controls.Add(this.btnpreview);
            this.pnlTop.Controls.Add(this.btnSearch);
            this.pnlTop.Size = new System.Drawing.Size(1192, 58);
            this.pnlTop.Controls.SetChildIndex(this.frmLabel, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnTopClose, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnSearch, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnpreview, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnDPrint, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnFocus, 0);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(412, 64);
            this.btnEdit.Size = new System.Drawing.Size(0, 5);
            this.btnEdit.Text = "&Edit";
            this.btnEdit.Visible = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(299, 64);
            this.btnSave.Size = new System.Drawing.Size(13, 13);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(525, 64);
            this.btnDelete.Size = new System.Drawing.Size(10, 8);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(186, 64);
            this.btnNew.Size = new System.Drawing.Size(10, 8);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(747, 64);
            this.btnClose.Size = new System.Drawing.Size(10, 8);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(636, 64);
            this.btnPrint.Size = new System.Drawing.Size(10, 8);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblAmount);
            this.groupBox1.Controls.Add(this.lblCount);
            this.groupBox1.Location = new System.Drawing.Point(0, 510);
            this.groupBox1.Size = new System.Drawing.Size(1192, 25);
            this.groupBox1.Controls.SetChildIndex(this.lblCount, 0);
            this.groupBox1.Controls.SetChildIndex(this.lblAmount, 0);
            // 
            // DG
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DG.DefaultCellStyle = dataGridViewCellStyle2;
            this.DG.Location = new System.Drawing.Point(3, 147);
            this.DG.Name = "DG";
            this.DG.RowHeadersWidth = 5;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DG.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DG.Size = new System.Drawing.Size(1183, 445);
            this.DG.TabIndex = 2;
            this.DG.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellContentClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "FOLDRS01.ICO");
            this.imageList1.Images.SetKeyName(1, "DATA16.ICO");
            this.imageList1.Images.SetKeyName(2, "Text.ico");
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
            this.PanelSearch.Location = new System.Drawing.Point(360, 321);
            this.PanelSearch.Name = "PanelSearch";
            this.PanelSearch.Size = new System.Drawing.Size(496, 10);
            this.PanelSearch.TabIndex = 3;
            this.PanelSearch.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(496, 26);
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
            this.lblTodate.Location = new System.Drawing.Point(32, 101);
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
            this.lblfromDate.Location = new System.Drawing.Point(15, 80);
            this.lblfromDate.Name = "lblfromDate";
            this.lblfromDate.Size = new System.Drawing.Size(77, 14);
            this.lblfromDate.TabIndex = 10;
            this.lblfromDate.Text = "From Date:";
            this.lblfromDate.Visible = false;
            // 
            // uctxtToDate
            // 
            this.uctxtToDate.Location = new System.Drawing.Point(95, 97);
            this.uctxtToDate.Name = "uctxtToDate";
            this.uctxtToDate.Size = new System.Drawing.Size(176, 20);
            this.uctxtToDate.TabIndex = 9;
            this.uctxtToDate.Visible = false;
            // 
            // uctxtFromDate
            // 
            this.uctxtFromDate.Location = new System.Drawing.Point(95, 76);
            this.uctxtFromDate.Name = "uctxtFromDate";
            this.uctxtFromDate.Size = new System.Drawing.Size(176, 20);
            this.uctxtFromDate.TabIndex = 8;
            this.uctxtFromDate.Visible = false;
            // 
            // uctxtExpression
            // 
            this.uctxtExpression.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtExpression.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtExpression.Location = new System.Drawing.Point(95, 55);
            this.uctxtExpression.Name = "uctxtExpression";
            this.uctxtExpression.Size = new System.Drawing.Size(373, 22);
            this.uctxtExpression.TabIndex = 7;
            // 
            // lblExpression
            // 
            this.lblExpression.AutoSize = true;
            this.lblExpression.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpression.Location = new System.Drawing.Point(11, 58);
            this.lblExpression.Name = "lblExpression";
            this.lblExpression.Size = new System.Drawing.Size(81, 14);
            this.lblExpression.TabIndex = 6;
            this.lblExpression.Text = "Expression:";
            // 
            // uctxtFindWhat
            // 
            this.uctxtFindWhat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtFindWhat.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtFindWhat.Location = new System.Drawing.Point(95, 28);
            this.uctxtFindWhat.Name = "uctxtFindWhat";
            this.uctxtFindWhat.Size = new System.Drawing.Size(176, 22);
            this.uctxtFindWhat.TabIndex = 5;
            // 
            // lblFindwhat
            // 
            this.lblFindwhat.AutoSize = true;
            this.lblFindwhat.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFindwhat.Location = new System.Drawing.Point(16, 34);
            this.lblFindwhat.Name = "lblFindwhat";
            this.lblFindwhat.Size = new System.Drawing.Size(76, 14);
            this.lblFindwhat.TabIndex = 4;
            this.lblFindwhat.Text = "Find What:";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(8, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(129, 37);
            this.btnSearch.TabIndex = 15;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblCount.Location = new System.Drawing.Point(535, 5);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(17, 16);
            this.lblCount.TabIndex = 19;
            this.lblCount.Text = "0";
            // 
            // btnpreview
            // 
            this.btnpreview.Location = new System.Drawing.Point(148, 14);
            this.btnpreview.Name = "btnpreview";
            this.btnpreview.Size = new System.Drawing.Size(0, 26);
            this.btnpreview.TabIndex = 16;
            this.btnpreview.Text = "&View";
            this.btnpreview.UseVisualStyleBackColor = true;
            this.btnpreview.Click += new System.EventHandler(this.btnpreview_Click);
            // 
            // btnDPrint
            // 
            this.btnDPrint.Location = new System.Drawing.Point(163, 16);
            this.btnDPrint.Name = "btnDPrint";
            this.btnDPrint.Size = new System.Drawing.Size(0, 10);
            this.btnDPrint.TabIndex = 17;
            this.btnDPrint.Text = "&Print";
            this.btnDPrint.UseVisualStyleBackColor = true;
            this.btnDPrint.Click += new System.EventHandler(this.btnDPrint_Click);
            // 
            // btnFocus
            // 
            this.btnFocus.Location = new System.Drawing.Point(267, 16);
            this.btnFocus.Name = "btnFocus";
            this.btnFocus.Size = new System.Drawing.Size(0, 10);
            this.btnFocus.TabIndex = 18;
            this.btnFocus.Text = "&Focus";
            this.btnFocus.UseVisualStyleBackColor = true;
            this.btnFocus.Click += new System.EventHandler(this.btnFocus_Click);
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblAmount.Location = new System.Drawing.Point(886, 5);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(17, 16);
            this.lblAmount.TabIndex = 20;
            this.lblAmount.Text = "0";
            // 
            // frmAccountsVoucherList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1192, 535);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmAccountsVoucherList";
            this.Load += new System.EventHandler(this.frmAccountsVoucherList_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).EndInit();
            this.PanelSearch.ResumeLayout(false);
            this.PanelSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DG;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel PanelSearch;
        private System.Windows.Forms.Label lblTodate;
        private System.Windows.Forms.Label lblfromDate;
        private System.Windows.Forms.TextBox uctxtToDate;
        private System.Windows.Forms.TextBox uctxtFromDate;
        private System.Windows.Forms.TextBox uctxtExpression;
        private System.Windows.Forms.Label lblExpression;
        private System.Windows.Forms.TextBox uctxtFindWhat;
        private System.Windows.Forms.Label lblFindwhat;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnpreview;
        private System.Windows.Forms.Button btnDPrint;
        private System.Windows.Forms.Button btnFocus;
        private System.Windows.Forms.Label lblAmount;
    }
}
