namespace JA.Modulecontrolar.UI.DReport.Inventory.ParameterForms
{
    partial class frmRptStockSummSPrice
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbtCategory = new System.Windows.Forms.RadioButton();
            this.radGroup = new System.Windows.Forms.RadioButton();
            this.radAll = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.uctxtName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.uctxtLevelName = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblCount = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(108, 9);
            this.frmLabel.Size = new System.Drawing.Size(379, 33);
            this.frmLabel.Text = "Stock Status (Sales Price Wise)";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.lblCount);
            this.pnlMain.Controls.Add(this.progressBar1);
            this.pnlMain.Controls.Add(this.uctxtLevelName);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.uctxtName);
            this.pnlMain.Controls.Add(this.panel2);
            this.pnlMain.Location = new System.Drawing.Point(1, -86);
            this.pnlMain.Size = new System.Drawing.Size(562, 457);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(565, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(130, 379);
            this.btnEdit.Size = new System.Drawing.Size(10, 10);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(17, 379);
            this.btnSave.Size = new System.Drawing.Size(20, 10);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(173, 379);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(16, 390);
            this.btnNew.Size = new System.Drawing.Size(10, 10);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(447, 375);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(311, 375);
            this.btnPrint.Size = new System.Drawing.Size(133, 39);
            this.btnPrint.Text = "Preview";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 414);
            this.groupBox1.Size = new System.Drawing.Size(565, 25);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbtCategory);
            this.panel2.Controls.Add(this.radGroup);
            this.panel2.Controls.Add(this.radAll);
            this.panel2.Location = new System.Drawing.Point(20, 148);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(522, 52);
            this.panel2.TabIndex = 0;
            // 
            // rbtCategory
            // 
            this.rbtCategory.AutoSize = true;
            this.rbtCategory.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtCategory.Location = new System.Drawing.Point(189, 15);
            this.rbtCategory.Name = "rbtCategory";
            this.rbtCategory.Size = new System.Drawing.Size(83, 18);
            this.rbtCategory.TabIndex = 2;
            this.rbtCategory.Text = "Category";
            this.rbtCategory.UseVisualStyleBackColor = true;
            this.rbtCategory.Click += new System.EventHandler(this.rbtCategory_Click);
            // 
            // radGroup
            // 
            this.radGroup.AutoSize = true;
            this.radGroup.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroup.Location = new System.Drawing.Point(370, 15);
            this.radGroup.Name = "radGroup";
            this.radGroup.Size = new System.Drawing.Size(98, 18);
            this.radGroup.TabIndex = 1;
            this.radGroup.Text = "Group Wise";
            this.radGroup.UseVisualStyleBackColor = true;
            this.radGroup.Click += new System.EventHandler(this.radGroup_Click);
            // 
            // radAll
            // 
            this.radAll.AutoSize = true;
            this.radAll.Checked = true;
            this.radAll.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAll.Location = new System.Drawing.Point(49, 15);
            this.radAll.Name = "radAll";
            this.radAll.Size = new System.Drawing.Size(43, 18);
            this.radAll.TabIndex = 0;
            this.radAll.TabStop = true;
            this.radAll.Text = "All ";
            this.radAll.UseVisualStyleBackColor = true;
            this.radAll.Click += new System.EventHandler(this.radAll_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(58, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 27;
            this.label3.Text = "Name:";
            // 
            // uctxtName
            // 
            this.uctxtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtName.Location = new System.Drawing.Point(121, 218);
            this.uctxtName.Name = "uctxtName";
            this.uctxtName.Size = new System.Drawing.Size(421, 22);
            this.uctxtName.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(17, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 16);
            this.label4.TabIndex = 28;
            this.label4.Text = "Level Name:";
            // 
            // uctxtLevelName
            // 
            this.uctxtLevelName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtLevelName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtLevelName.Location = new System.Drawing.Point(121, 249);
            this.uctxtLevelName.Name = "uctxtLevelName";
            this.uctxtLevelName.Size = new System.Drawing.Size(421, 22);
            this.uctxtLevelName.TabIndex = 29;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(121, 297);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(421, 23);
            this.progressBar1.TabIndex = 30;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(17, 410);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(0, 13);
            this.lblCount.TabIndex = 31;
            // 
            // frmRptStockSummSPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(565, 439);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmRptStockSummSPrice";
            this.Load += new System.EventHandler(this.frmRptStoreLedger_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radGroup;
        private System.Windows.Forms.RadioButton radAll;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uctxtName;
        private System.Windows.Forms.TextBox uctxtLevelName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbtCategory;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblCount;
    }
}
