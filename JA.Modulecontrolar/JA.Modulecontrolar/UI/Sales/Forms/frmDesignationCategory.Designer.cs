namespace JA.Modulecontrolar.UI.Sales.Forms
{
    partial class frmDesignationCategory
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(128, 9);
            this.frmLabel.Size = new System.Drawing.Size(268, 33);
            this.frmLabel.Text = "Designation Category";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.textBox3);
            this.pnlMain.Controls.Add(this.textBox2);
            this.pnlMain.Controls.Add(this.textBox1);
            this.pnlMain.Location = new System.Drawing.Point(0, 57);
            this.pnlMain.Size = new System.Drawing.Size(524, 125);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(525, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(164, 188);
            this.btnEdit.Size = new System.Drawing.Size(136, 39);
            this.btnEdit.Text = "Tree View";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(304, 188);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(6, 188);
            this.btnDelete.Size = new System.Drawing.Size(12, 39);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(41, 188);
            this.btnNew.Size = new System.Drawing.Size(120, 39);
            this.btnNew.Text = "List All";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(415, 188);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(22, 188);
            this.btnPrint.Size = new System.Drawing.Size(10, 39);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 233);
            this.groupBox1.Size = new System.Drawing.Size(525, 25);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(97, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(354, 20);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(97, 45);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(309, 20);
            this.textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(97, 70);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(309, 20);
            this.textBox3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Branch :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(50, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "Name :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(48, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "Under :";
            // 
            // frmDesignationCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(525, 258);
            this.isEnterTabAllow = true;
            this.Name = "frmDesignationCategory";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
