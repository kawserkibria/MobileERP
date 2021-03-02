namespace JA.Modulecontrolar.UI.Inventory
{
    partial class frmMaterialType
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
            this.label5 = new System.Windows.Forms.Label();
            this.uctxtMaterialType = new System.Windows.Forms.TextBox();
            this.txtOLdMaterialType = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(194, 7);
            this.frmLabel.Size = new System.Drawing.Size(175, 33);
            this.frmLabel.Text = "Material Type";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.uctxtMaterialType);
            this.pnlMain.Size = new System.Drawing.Size(576, 272);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.txtOLdMaterialType);
            this.pnlTop.Size = new System.Drawing.Size(578, 58);
            this.pnlTop.Controls.SetChildIndex(this.frmLabel, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnTopClose, 0);
            this.pnlTop.Controls.SetChildIndex(this.txtOLdMaterialType, 0);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(2, 191);
            this.btnEdit.Size = new System.Drawing.Size(122, 39);
            this.btnEdit.Text = "List All";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(351, 191);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(350, 143);
            this.btnDelete.Size = new System.Drawing.Size(10, 16);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(11, 143);
            this.btnNew.Size = new System.Drawing.Size(10, 16);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(462, 191);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(462, 142);
            this.btnPrint.Size = new System.Drawing.Size(10, 16);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 231);
            this.groupBox1.Size = new System.Drawing.Size(578, 25);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 18);
            this.label5.TabIndex = 52;
            this.label5.Text = "Material Type";
            // 
            // uctxtMaterialType
            // 
            this.uctxtMaterialType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtMaterialType.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtMaterialType.Location = new System.Drawing.Point(16, 192);
            this.uctxtMaterialType.MaxLength = 60;
            this.uctxtMaterialType.Name = "uctxtMaterialType";
            this.uctxtMaterialType.Size = new System.Drawing.Size(550, 23);
            this.uctxtMaterialType.TabIndex = 51;
            // 
            // txtOLdMaterialType
            // 
            this.txtOLdMaterialType.Location = new System.Drawing.Point(429, 20);
            this.txtOLdMaterialType.Name = "txtOLdMaterialType";
            this.txtOLdMaterialType.Size = new System.Drawing.Size(100, 20);
            this.txtOLdMaterialType.TabIndex = 15;
            this.txtOLdMaterialType.Visible = false;
            // 
            // frmMaterialType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(578, 256);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmMaterialType";
            this.Load += new System.EventHandler(this.frmMaterialType_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox uctxtMaterialType;
        private System.Windows.Forms.TextBox txtOLdMaterialType;
    }
}
