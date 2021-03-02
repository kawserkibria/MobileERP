namespace JA.Modulecontrolar.UI.Sales.Forms
{
    partial class frmTeritorry
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
            this.uctxtTeritorryName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.uctxtTeritorryCode = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(207, 9);
            this.frmLabel.Size = new System.Drawing.Size(126, 33);
            this.frmLabel.Text = "Teritorry ";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.uctxtTeritorryCode);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.uctxtTeritorryName);
            this.pnlMain.Location = new System.Drawing.Point(0, 57);
            this.pnlMain.Size = new System.Drawing.Size(524, 99);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.textBox1);
            this.pnlTop.Size = new System.Drawing.Size(525, 58);
            this.pnlTop.Controls.SetChildIndex(this.frmLabel, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnTopClose, 0);
            this.pnlTop.Controls.SetChildIndex(this.textBox1, 0);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(240, 162);
            this.btnEdit.Size = new System.Drawing.Size(10, 11);
            this.btnEdit.Text = "Tree View";
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(302, 161);
            this.btnSave.TabIndex = 2;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(199, 162);
            this.btnDelete.Size = new System.Drawing.Size(12, 11);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(4, 161);
            this.btnNew.Size = new System.Drawing.Size(120, 39);
            this.btnNew.Text = "List All";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(413, 161);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(215, 162);
            this.btnPrint.Size = new System.Drawing.Size(10, 11);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 204);
            this.groupBox1.Size = new System.Drawing.Size(525, 25);
            // 
            // uctxtTeritorryName
            // 
            this.uctxtTeritorryName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtTeritorryName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtTeritorryName.Location = new System.Drawing.Point(136, 52);
            this.uctxtTeritorryName.MaxLength = 60;
            this.uctxtTeritorryName.Name = "uctxtTeritorryName";
            this.uctxtTeritorryName.Size = new System.Drawing.Size(338, 22);
            this.uctxtTeritorryName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Teritorry Name :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "Teritorry Code :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(93, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(39, 20);
            this.textBox1.TabIndex = 15;
            this.textBox1.Visible = false;
            // 
            // uctxtTeritorryCode
            // 
            this.uctxtTeritorryCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtTeritorryCode.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtTeritorryCode.Location = new System.Drawing.Point(136, 29);
            this.uctxtTeritorryCode.MaxLength = 8;
            this.uctxtTeritorryCode.Name = "uctxtTeritorryCode";
            this.uctxtTeritorryCode.Size = new System.Drawing.Size(338, 22);
            this.uctxtTeritorryCode.TabIndex = 9;
            // 
            // frmTeritorry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(525, 229);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmTeritorry";
            this.Load += new System.EventHandler(this.frmTeritorry_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox uctxtTeritorryName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox uctxtTeritorryCode;
    }
}
