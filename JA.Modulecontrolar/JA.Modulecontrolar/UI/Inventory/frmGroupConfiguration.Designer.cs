namespace JA.Modulecontrolar.UI.Inventory
{
    partial class frmGroupConfiguration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGroupConfiguration));
            this.label5 = new System.Windows.Forms.Label();
            this.uctxtGroupConfigName = new System.Windows.Forms.TextBox();
            this.uctxtOldName = new System.Windows.Forms.TextBox();
            this.row4 = new System.Windows.Forms.ImageList(this.components);
            this.btnTreeView = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(228, 4);
            this.frmLabel.Size = new System.Drawing.Size(239, 33);
            this.frmLabel.Text = "Commission Group";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.uctxtGroupConfigName);
            this.pnlMain.Size = new System.Drawing.Size(677, 289);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.uctxtOldName);
            this.pnlTop.Size = new System.Drawing.Size(679, 58);
            this.pnlTop.Controls.SetChildIndex(this.frmLabel, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnTopClose, 0);
            this.pnlTop.Controls.SetChildIndex(this.uctxtOldName, 0);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(11, 207);
            this.btnEdit.Size = new System.Drawing.Size(126, 39);
            this.btnEdit.Text = "List All";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(455, 207);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(150, 156);
            this.btnDelete.Size = new System.Drawing.Size(6, 18);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(30, 161);
            this.btnNew.Size = new System.Drawing.Size(7, 22);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(569, 207);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(480, 156);
            this.btnPrint.Size = new System.Drawing.Size(19, 13);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 257);
            this.groupBox1.Size = new System.Drawing.Size(679, 25);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(171, 18);
            this.label5.TabIndex = 50;
            this.label5.Text = "Comm. Group Name:";
            // 
            // uctxtGroupConfigName
            // 
            this.uctxtGroupConfigName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtGroupConfigName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtGroupConfigName.Location = new System.Drawing.Point(203, 192);
            this.uctxtGroupConfigName.MaxLength = 50;
            this.uctxtGroupConfigName.Name = "uctxtGroupConfigName";
            this.uctxtGroupConfigName.Size = new System.Drawing.Size(377, 23);
            this.uctxtGroupConfigName.TabIndex = 49;
            this.uctxtGroupConfigName.TextChanged += new System.EventHandler(this.uctxtGroupConfigName_TextChanged);
            // 
            // uctxtOldName
            // 
            this.uctxtOldName.Location = new System.Drawing.Point(37, 13);
            this.uctxtOldName.Name = "uctxtOldName";
            this.uctxtOldName.Size = new System.Drawing.Size(100, 20);
            this.uctxtOldName.TabIndex = 15;
            this.uctxtOldName.Visible = false;
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
            this.btnTreeView.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnTreeView.ForeColor = System.Drawing.Color.Navy;
            this.btnTreeView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTreeView.ImageIndex = 3;
            this.btnTreeView.ImageList = this.row4;
            this.btnTreeView.Location = new System.Drawing.Point(139, 205);
            this.btnTreeView.Name = "btnTreeView";
            this.btnTreeView.Size = new System.Drawing.Size(115, 44);
            this.btnTreeView.TabIndex = 17;
            this.btnTreeView.Text = "TreeView";
            this.btnTreeView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTreeView.UseVisualStyleBackColor = false;
            this.btnTreeView.Click += new System.EventHandler(this.btnTreeView_Click);
            // 
            // frmGroupConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(679, 282);
            this.Controls.Add(this.btnTreeView);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmGroupConfiguration";
            this.Load += new System.EventHandler(this.frmGroupConfiguration_Load);
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

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox uctxtGroupConfigName;
        private System.Windows.Forms.TextBox uctxtOldName;
        private System.Windows.Forms.ImageList row4;
        private System.Windows.Forms.Button btnTreeView;
    }
}
