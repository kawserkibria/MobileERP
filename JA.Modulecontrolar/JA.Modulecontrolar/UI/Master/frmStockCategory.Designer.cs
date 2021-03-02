namespace JA.Modulecontrolar.UI.Master
{
    partial class frmStockCategory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStockCategory));
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUnder = new System.Windows.Forms.TextBox();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.txtSlNo = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.row4 = new System.Windows.Forms.ImageList(this.components);
            this.btnTreeView = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(262, 8);
            this.frmLabel.Size = new System.Drawing.Size(124, 33);
            this.frmLabel.Text = "Pack Size";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.txtUnder);
            this.pnlMain.Controls.Add(this.txtGroupName);
            this.pnlMain.Controls.Add(this.txtSlNo);
            this.pnlMain.Size = new System.Drawing.Size(659, 303);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.textBox1);
            this.pnlTop.Size = new System.Drawing.Size(660, 58);
            this.pnlTop.Controls.SetChildIndex(this.frmLabel, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnTopClose, 0);
            this.pnlTop.Controls.SetChildIndex(this.textBox1, 0);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(11, 221);
            this.btnEdit.Size = new System.Drawing.Size(118, 41);
            this.btnEdit.Text = "List All";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(424, 221);
            this.btnSave.Size = new System.Drawing.Size(118, 41);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(428, 6);
            this.btnDelete.Size = new System.Drawing.Size(10, 39);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(281, 221);
            this.btnNew.Size = new System.Drawing.Size(10, 39);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(538, 221);
            this.btnClose.Size = new System.Drawing.Size(118, 41);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(539, 6);
            this.btnPrint.Size = new System.Drawing.Size(10, 39);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 265);
            this.groupBox1.Size = new System.Drawing.Size(660, 25);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 47;
            this.label1.Text = "Under:";
            this.label1.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 18);
            this.label5.TabIndex = 46;
            this.label5.Text = "Name:";
            // 
            // txtUnder
            // 
            this.txtUnder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnder.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnder.Location = new System.Drawing.Point(11, 233);
            this.txtUnder.MaxLength = 50;
            this.txtUnder.Name = "txtUnder";
            this.txtUnder.Size = new System.Drawing.Size(631, 23);
            this.txtUnder.TabIndex = 44;
            this.txtUnder.Visible = false;
            // 
            // txtGroupName
            // 
            this.txtGroupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGroupName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGroupName.Location = new System.Drawing.Point(11, 180);
            this.txtGroupName.MaxLength = 50;
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(631, 23);
            this.txtGroupName.TabIndex = 43;
            // 
            // txtSlNo
            // 
            this.txtSlNo.Location = new System.Drawing.Point(12, 11);
            this.txtSlNo.Name = "txtSlNo";
            this.txtSlNo.Size = new System.Drawing.Size(87, 20);
            this.txtSlNo.TabIndex = 45;
            this.txtSlNo.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(28, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(87, 20);
            this.textBox1.TabIndex = 16;
            this.textBox1.Visible = false;
            // 
            // row4
            // 
            this.row4.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("row4.ImageStream")));
            this.row4.TransparentColor = System.Drawing.Color.Transparent;
            this.row4.Images.SetKeyName(0, "Medical-Nurse-Female-Light-icon.png");
            this.row4.Images.SetKeyName(1, "doctor-icon.png");
            this.row4.Images.SetKeyName(2, "HumanResource-icon.png");
            this.row4.Images.SetKeyName(3, "Report-icon.png");
            this.row4.Images.SetKeyName(4, "Property-icon.png");
            this.row4.Images.SetKeyName(5, "stock-icon.png");
            this.row4.Images.SetKeyName(6, "system-icon.png");
            this.row4.Images.SetKeyName(7, "group44.png");
            this.row4.Images.SetKeyName(8, "lab2.png");
            this.row4.Images.SetKeyName(9, "placeholder8.png");
            // 
            // btnTreeView
            // 
            this.btnTreeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnTreeView.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTreeView.ForeColor = System.Drawing.Color.Navy;
            this.btnTreeView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTreeView.ImageIndex = 3;
            this.btnTreeView.ImageList = this.row4;
            this.btnTreeView.Location = new System.Drawing.Point(129, 219);
            this.btnTreeView.Name = "btnTreeView";
            this.btnTreeView.Size = new System.Drawing.Size(114, 45);
            this.btnTreeView.TabIndex = 17;
            this.btnTreeView.Text = "TreeView";
            this.btnTreeView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTreeView.UseVisualStyleBackColor = false;
            this.btnTreeView.Click += new System.EventHandler(this.btnTreeView_Click);
            // 
            // frmStockCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(660, 290);
            this.Controls.Add(this.btnTreeView);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmStockCategory";
            this.Load += new System.EventHandler(this.frmStockCategory_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.pnlMain, 0);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.Controls.SetChildIndex(this.btnTreeView, 0);
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ImageList row4;
        private System.Windows.Forms.Button btnTreeView;
    }
}
