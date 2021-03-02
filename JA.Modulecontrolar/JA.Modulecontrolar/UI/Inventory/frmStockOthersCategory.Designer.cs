namespace JA.Modulecontrolar.UI.Inventory
{
    partial class frmStockOthersCategory
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
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUnder = new System.Windows.Forms.TextBox();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.txtSlNo = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(230, 5);
            this.frmLabel.Size = new System.Drawing.Size(212, 33);
            this.frmLabel.Text = "Others Categoey";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.txtUnder);
            this.pnlMain.Controls.Add(this.txtGroupName);
            this.pnlMain.Controls.Add(this.txtSlNo);
            this.pnlMain.Size = new System.Drawing.Size(676, 409);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(680, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(6, 328);
            this.btnEdit.Size = new System.Drawing.Size(149, 39);
            this.btnEdit.Text = "List All";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(454, 328);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(346, 258);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(73, 273);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(568, 328);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(457, 258);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 370);
            this.groupBox1.Size = new System.Drawing.Size(680, 25);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 46;
            this.label1.Text = "Under:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(29, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 18);
            this.label5.TabIndex = 45;
            this.label5.Text = "Name:";
            // 
            // txtUnder
            // 
            this.txtUnder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnder.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnder.Location = new System.Drawing.Point(29, 232);
            this.txtUnder.Name = "txtUnder";
            this.txtUnder.Size = new System.Drawing.Size(631, 23);
            this.txtUnder.TabIndex = 43;
            // 
            // txtGroupName
            // 
            this.txtGroupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGroupName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGroupName.Location = new System.Drawing.Point(29, 179);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(631, 23);
            this.txtGroupName.TabIndex = 42;
            // 
            // txtSlNo
            // 
            this.txtSlNo.Location = new System.Drawing.Point(32, 280);
            this.txtSlNo.Name = "txtSlNo";
            this.txtSlNo.Size = new System.Drawing.Size(87, 20);
            this.txtSlNo.TabIndex = 44;
            this.txtSlNo.Visible = false;
            // 
            // frmStockOthersCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(680, 395);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.Name = "frmStockOthersCategory";
            this.Load += new System.EventHandler(this.frmStockOthersCategory_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUnder;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.TextBox txtSlNo;
    }
}
