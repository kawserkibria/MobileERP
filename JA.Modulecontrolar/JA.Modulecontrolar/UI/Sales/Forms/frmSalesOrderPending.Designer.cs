namespace JA.Modulecontrolar.UI.Sales.Forms
{
    partial class frmSalesOrderPending
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalesOrderPending));
            this.DG = new System.Windows.Forms.DataGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblCount = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).BeginInit();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(260, 9);
            this.frmLabel.Size = new System.Drawing.Size(234, 33);
            this.frmLabel.Text = "Pending Order List";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.DG);
            this.pnlMain.Size = new System.Drawing.Size(779, 573);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(784, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(553, 437);
            this.btnEdit.Size = new System.Drawing.Size(10, 10);
            this.btnEdit.Text = "Approved";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(309, 437);
            this.btnSave.Size = new System.Drawing.Size(10, 10);
            this.btnSave.Text = "Commission Calculator";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(525, 64);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(698, 437);
            this.btnNew.Size = new System.Drawing.Size(10, 10);
            this.btnNew.Text = "Not Approved";
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
            this.groupBox1.Location = new System.Drawing.Point(0, 531);
            this.groupBox1.Size = new System.Drawing.Size(784, 25);
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
            this.DG.Size = new System.Drawing.Size(771, 423);
            this.DG.TabIndex = 2;
            this.DG.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellContentClick);
            this.DG.DoubleClick += new System.EventHandler(this.DG_DoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "FOLDRS01.ICO");
            this.imageList1.Images.SetKeyName(1, "DATA16.ICO");
            this.imageList1.Images.SetKeyName(2, "Text.ico");
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.ForeColor = System.Drawing.Color.Fuchsia;
            this.lblCount.Location = new System.Drawing.Point(643, 489);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(16, 14);
            this.lblCount.TabIndex = 20;
            this.lblCount.Text = "0";
            // 
            // frmSalesOrderPending
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(784, 556);
            this.Controls.Add(this.lblCount);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmSalesOrderPending";
            this.Load += new System.EventHandler(this.frmSalesOrderPending_Load);
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
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DG;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblCount;
    }
}
