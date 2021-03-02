namespace JA.Modulecontrolar.UI.Inventory
{
    partial class frmSection
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
            this.uctxtSectionName = new System.Windows.Forms.TextBox();
            this.txtOldSectionName = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(179, 7);
            this.frmLabel.Size = new System.Drawing.Size(269, 33);
            this.frmLabel.Text = "Section Configuration";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.uctxtSectionName);
            this.pnlMain.Size = new System.Drawing.Size(594, 272);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.txtOldSectionName);
            this.pnlTop.Size = new System.Drawing.Size(594, 58);
            this.pnlTop.Controls.SetChildIndex(this.frmLabel, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnTopClose, 0);
            this.pnlTop.Controls.SetChildIndex(this.txtOldSectionName, 0);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(10, 187);
            this.btnEdit.Size = new System.Drawing.Size(137, 39);
            this.btnEdit.Text = "List All";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(359, 187);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(350, 143);
            this.btnDelete.Size = new System.Drawing.Size(10, 39);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(11, 143);
            this.btnNew.Size = new System.Drawing.Size(10, 39);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(470, 187);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(462, 142);
            this.btnPrint.Size = new System.Drawing.Size(10, 39);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 236);
            this.groupBox1.Size = new System.Drawing.Size(594, 25);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(52, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 18);
            this.label5.TabIndex = 52;
            this.label5.Text = "Section Name";
            // 
            // uctxtSectionName
            // 
            this.uctxtSectionName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtSectionName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtSectionName.Location = new System.Drawing.Point(55, 192);
            this.uctxtSectionName.MaxLength = 60;
            this.uctxtSectionName.Name = "uctxtSectionName";
            this.uctxtSectionName.Size = new System.Drawing.Size(514, 23);
            this.uctxtSectionName.TabIndex = 51;
            // 
            // txtOldSectionName
            // 
            this.txtOldSectionName.Location = new System.Drawing.Point(45, 13);
            this.txtOldSectionName.Name = "txtOldSectionName";
            this.txtOldSectionName.Size = new System.Drawing.Size(100, 20);
            this.txtOldSectionName.TabIndex = 15;
            this.txtOldSectionName.Visible = false;
            // 
            // frmSection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(594, 261);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.Name = "frmSection";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox uctxtSectionName;
        private System.Windows.Forms.TextBox txtOldSectionName;
    }
}
