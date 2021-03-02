namespace JA.Modulecontrolar.UI.Inventory
{
    partial class frmStockGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStockGroup));
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUnder = new System.Windows.Forms.TextBox();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.txtSlNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.uctxtGroupConfig = new System.Windows.Forms.TextBox();
            this.cboPackSize = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTreeView = new System.Windows.Forms.Button();
            this.row4 = new System.Windows.Forms.ImageList(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboDilEffect = new System.Windows.Forms.ComboBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(244, 6);
            this.frmLabel.Size = new System.Drawing.Size(160, 33);
            this.frmLabel.Text = "Stock Group";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.label8);
            this.pnlMain.Controls.Add(this.cboDilEffect);
            this.pnlMain.Controls.Add(this.label6);
            this.pnlMain.Controls.Add(this.cboStatus);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.cboPackSize);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.uctxtGroupConfig);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.txtUnder);
            this.pnlMain.Controls.Add(this.txtGroupName);
            this.pnlMain.Location = new System.Drawing.Point(0, -85);
            this.pnlMain.Size = new System.Drawing.Size(662, 415);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.txtSlNo);
            this.pnlTop.Size = new System.Drawing.Size(665, 58);
            this.pnlTop.Controls.SetChildIndex(this.frmLabel, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnTopClose, 0);
            this.pnlTop.Controls.SetChildIndex(this.txtSlNo, 0);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(8, 336);
            this.btnEdit.Size = new System.Drawing.Size(117, 39);
            this.btnEdit.Text = "List All";
            this.btnEdit.Visible = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(434, 336);
            this.btnSave.Visible = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(436, 4);
            this.btnDelete.Size = new System.Drawing.Size(29, 13);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(347, 359);
            this.btnNew.Size = new System.Drawing.Size(26, 13);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(548, 336);
            this.btnClose.Visible = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(478, 4);
            this.btnPrint.Size = new System.Drawing.Size(21, 13);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 381);
            this.groupBox1.Size = new System.Drawing.Size(665, 25);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 215);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 41;
            this.label1.Text = "Under:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 18);
            this.label5.TabIndex = 40;
            this.label5.Text = "Name:";
            // 
            // txtUnder
            // 
            this.txtUnder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnder.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnder.Location = new System.Drawing.Point(21, 238);
            this.txtUnder.MaxLength = 50;
            this.txtUnder.Name = "txtUnder";
            this.txtUnder.Size = new System.Drawing.Size(631, 23);
            this.txtUnder.TabIndex = 1;
            // 
            // txtGroupName
            // 
            this.txtGroupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGroupName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGroupName.Location = new System.Drawing.Point(21, 185);
            this.txtGroupName.MaxLength = 50;
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(631, 23);
            this.txtGroupName.TabIndex = 0;
            // 
            // txtSlNo
            // 
            this.txtSlNo.Location = new System.Drawing.Point(22, 16);
            this.txtSlNo.Name = "txtSlNo";
            this.txtSlNo.Size = new System.Drawing.Size(87, 20);
            this.txtSlNo.TabIndex = 15;
            this.txtSlNo.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 273);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 18);
            this.label3.TabIndex = 43;
            this.label3.Text = "Commission Group:";
            // 
            // uctxtGroupConfig
            // 
            this.uctxtGroupConfig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtGroupConfig.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtGroupConfig.Location = new System.Drawing.Point(21, 296);
            this.uctxtGroupConfig.MaxLength = 50;
            this.uctxtGroupConfig.Name = "uctxtGroupConfig";
            this.uctxtGroupConfig.Size = new System.Drawing.Size(631, 23);
            this.uctxtGroupConfig.TabIndex = 42;
            // 
            // cboPackSize
            // 
            this.cboPackSize.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPackSize.FormattingEnabled = true;
            this.cboPackSize.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.cboPackSize.Location = new System.Drawing.Point(24, 352);
            this.cboPackSize.Name = "cboPackSize";
            this.cboPackSize.Size = new System.Drawing.Size(177, 22);
            this.cboPackSize.TabIndex = 44;
            this.cboPackSize.Text = "No";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 328);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 18);
            this.label4.TabIndex = 45;
            this.label4.Text = "Use Pack Size:";
            // 
            // btnTreeView
            // 
            this.btnTreeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnTreeView.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTreeView.ForeColor = System.Drawing.Color.Navy;
            this.btnTreeView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTreeView.ImageIndex = 3;
            this.btnTreeView.ImageList = this.row4;
            this.btnTreeView.Location = new System.Drawing.Point(125, 333);
            this.btnTreeView.Name = "btnTreeView";
            this.btnTreeView.Size = new System.Drawing.Size(110, 46);
            this.btnTreeView.TabIndex = 16;
            this.btnTreeView.Text = "TreeView";
            this.btnTreeView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTreeView.UseVisualStyleBackColor = false;
            this.btnTreeView.Click += new System.EventHandler(this.btnTreeView_Click);
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(240, 328);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 18);
            this.label6.TabIndex = 47;
            this.label6.Text = "Status";
            // 
            // cboStatus
            // 
            this.cboStatus.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.cboStatus.Location = new System.Drawing.Point(243, 352);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(177, 22);
            this.cboStatus.TabIndex = 46;
            this.cboStatus.Text = "No";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(458, 328);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(186, 18);
            this.label8.TabIndex = 49;
            this.label8.Text = "Dilution Effect Inventory";
            // 
            // cboDilEffect
            // 
            this.cboDilEffect.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDilEffect.FormattingEnabled = true;
            this.cboDilEffect.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.cboDilEffect.Location = new System.Drawing.Point(461, 352);
            this.cboDilEffect.Name = "cboDilEffect";
            this.cboDilEffect.Size = new System.Drawing.Size(177, 22);
            this.cboDilEffect.TabIndex = 48;
            this.cboDilEffect.Text = "No";
            // 
            // frmStockGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(665, 406);
            this.Controls.Add(this.btnTreeView);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmStockGroup";
            this.Load += new System.EventHandler(this.frmGroup_Load);
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboPackSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uctxtGroupConfig;
        private System.Windows.Forms.Button btnTreeView;
        private System.Windows.Forms.ImageList row4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboDilEffect;
    }
}
