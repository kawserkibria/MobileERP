namespace JA.Modulecontrolar.UI.Accms.Forms
{
    partial class frmCostCenter
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
            this.label3 = new System.Windows.Forms.Label();
            this.uctxtCostCenter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uctxtCostCategory = new System.Windows.Forms.TextBox();
            this.uctxtOldCostCenter = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(222, 9);
            this.frmLabel.Size = new System.Drawing.Size(153, 33);
            this.frmLabel.Text = "Cost Center";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.uctxtCostCenter);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.uctxtCostCategory);
            this.pnlMain.Size = new System.Drawing.Size(561, 341);
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.uctxtOldCostCenter);
            this.pnlTop.Size = new System.Drawing.Size(566, 58);
            this.pnlTop.Controls.SetChildIndex(this.frmLabel, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnTopClose, 0);
            this.pnlTop.Controls.SetChildIndex(this.uctxtOldCostCenter, 0);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(134, 257);
            this.btnEdit.Size = new System.Drawing.Size(139, 39);
            this.btnEdit.Text = "Tree view";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(342, 257);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(153, 260);
            this.btnDelete.Size = new System.Drawing.Size(16, 13);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(3, 257);
            this.btnNew.Size = new System.Drawing.Size(129, 39);
            this.btnNew.Text = "List All";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(456, 257);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(298, 10);
            this.btnPrint.Size = new System.Drawing.Size(10, 10);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 298);
            this.groupBox1.Size = new System.Drawing.Size(566, 25);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(75, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Cost Center:";
            // 
            // uctxtCostCenter
            // 
            this.uctxtCostCenter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtCostCenter.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtCostCenter.Location = new System.Drawing.Point(175, 178);
            this.uctxtCostCenter.Name = "uctxtCostCenter";
            this.uctxtCostCenter.Size = new System.Drawing.Size(304, 22);
            this.uctxtCostCenter.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Cost Categories:";
            // 
            // uctxtCostCategory
            // 
            this.uctxtCostCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtCostCategory.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtCostCategory.Location = new System.Drawing.Point(175, 203);
            this.uctxtCostCategory.Name = "uctxtCostCategory";
            this.uctxtCostCategory.Size = new System.Drawing.Size(304, 22);
            this.uctxtCostCategory.TabIndex = 1;
            // 
            // uctxtOldCostCenter
            // 
            this.uctxtOldCostCenter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtOldCostCenter.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtOldCostCenter.Location = new System.Drawing.Point(29, 9);
            this.uctxtOldCostCenter.Name = "uctxtOldCostCenter";
            this.uctxtOldCostCenter.Size = new System.Drawing.Size(49, 22);
            this.uctxtOldCostCenter.TabIndex = 9;
            this.uctxtOldCostCenter.Visible = false;
            // 
            // frmCostCenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(566, 323);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmCostCenter";
            this.Load += new System.EventHandler(this.frmCostCenter_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uctxtCostCenter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uctxtCostCategory;
        private System.Windows.Forms.TextBox uctxtOldCostCenter;
    }
}
