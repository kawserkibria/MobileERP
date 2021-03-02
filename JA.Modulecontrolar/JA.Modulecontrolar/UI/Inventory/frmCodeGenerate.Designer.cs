namespace JA.Modulecontrolar.UI.Inventory
{
    partial class frmCodeGenerate
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
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.txtcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btngenerate = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(155, 9);
            this.frmLabel.Size = new System.Drawing.Size(191, 33);
            this.frmLabel.Text = "Code Generate";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btngenerate);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.txtcode);
            this.pnlMain.Controls.Add(this.txtGroupName);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Size = new System.Drawing.Size(504, 311);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(505, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(43, 225);
            this.btnEdit.Size = new System.Drawing.Size(10, 23);
            this.btnEdit.Text = "List All";
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(282, 230);
            this.btnSave.Size = new System.Drawing.Size(10, 10);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(243, 232);
            this.btnDelete.Size = new System.Drawing.Size(10, 12);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(193, 230);
            this.btnNew.Size = new System.Drawing.Size(10, 12);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(396, 230);
            this.btnClose.Size = new System.Drawing.Size(10, 10);
            this.btnClose.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(129, 232);
            this.btnPrint.Size = new System.Drawing.Size(10, 12);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 248);
            this.groupBox1.Size = new System.Drawing.Size(505, 25);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 18);
            this.label5.TabIndex = 48;
            this.label5.Text = "Group Selection:";
            // 
            // txtGroupName
            // 
            this.txtGroupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGroupName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGroupName.Location = new System.Drawing.Point(152, 162);
            this.txtGroupName.MaxLength = 50;
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(264, 22);
            this.txtGroupName.TabIndex = 49;
            // 
            // txtcode
            // 
            this.txtcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcode.Enabled = false;
            this.txtcode.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcode.Location = new System.Drawing.Point(152, 190);
            this.txtcode.MaxLength = 50;
            this.txtcode.Name = "txtcode";
            this.txtcode.Size = new System.Drawing.Size(264, 22);
            this.txtcode.TabIndex = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 18);
            this.label1.TabIndex = 51;
            this.label1.Text = "Code Generate:";
            // 
            // btngenerate
            // 
            this.btngenerate.BackColor = System.Drawing.Color.Cornsilk;
            this.btngenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngenerate.Location = new System.Drawing.Point(304, 218);
            this.btngenerate.Name = "btngenerate";
            this.btngenerate.Size = new System.Drawing.Size(112, 36);
            this.btngenerate.TabIndex = 52;
            this.btngenerate.Text = "Generate";
            this.btngenerate.UseVisualStyleBackColor = false;
            this.btngenerate.Click += new System.EventHandler(this.btngenerate_Click);
            // 
            // frmCodeGenerate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(505, 273);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmCodeGenerate";
            this.Load += new System.EventHandler(this.frmCodeGenerate_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtcode;
        private System.Windows.Forms.Button btngenerate;
    }
}
