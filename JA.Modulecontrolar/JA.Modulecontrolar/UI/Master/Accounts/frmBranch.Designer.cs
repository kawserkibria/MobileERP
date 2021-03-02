namespace JA.Modulecontrolar.UI.Master.Accounts
{
    partial class frmBranch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.uctxtBranchName = new System.Windows.Forms.TextBox();
            this.lblLedgerName = new System.Windows.Forms.Label();
            this.uctxtAddress1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uctxtAddress2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.uctxtCountry = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.uctxtTelephone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.uctxtFax = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.uctxtLocation = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.uctxtDeafaultBranch = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.uctxtInactive = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.uctxtComments = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.DG = new System.Windows.Forms.DataGridView();
            this.txtbranchId = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).BeginInit();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(187, 7);
            this.frmLabel.Size = new System.Drawing.Size(265, 33);
            this.frmLabel.Text = "Branch Configuration";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.DG);
            this.pnlMain.Controls.Add(this.uctxtComments);
            this.pnlMain.Controls.Add(this.label11);
            this.pnlMain.Controls.Add(this.uctxtInactive);
            this.pnlMain.Controls.Add(this.label10);
            this.pnlMain.Controls.Add(this.uctxtDeafaultBranch);
            this.pnlMain.Controls.Add(this.label9);
            this.pnlMain.Controls.Add(this.uctxtLocation);
            this.pnlMain.Controls.Add(this.label8);
            this.pnlMain.Controls.Add(this.uctxtFax);
            this.pnlMain.Controls.Add(this.label6);
            this.pnlMain.Controls.Add(this.uctxtTelephone);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.uctxtCountry);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.uctxtAddress2);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.uctxtAddress1);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.uctxtBranchName);
            this.pnlMain.Controls.Add(this.lblLedgerName);
            this.pnlMain.Location = new System.Drawing.Point(0, -98);
            this.pnlMain.Size = new System.Drawing.Size(639, 558);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.txtbranchId);
            this.pnlTop.Size = new System.Drawing.Size(641, 58);
            this.pnlTop.Controls.SetChildIndex(this.frmLabel, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnTopClose, 0);
            this.pnlTop.Controls.SetChildIndex(this.txtbranchId, 0);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(10, 478);
            this.btnEdit.Size = new System.Drawing.Size(10, 10);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(418, 462);
            this.btnSave.Visible = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(123, 467);
            this.btnDelete.Size = new System.Drawing.Size(10, 14);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(305, 462);
            this.btnNew.Visible = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(532, 462);
            this.btnClose.Visible = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(234, 467);
            this.btnPrint.Size = new System.Drawing.Size(10, 13);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 501);
            this.groupBox1.Size = new System.Drawing.Size(641, 25);
            // 
            // uctxtBranchName
            // 
            this.uctxtBranchName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtBranchName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtBranchName.Location = new System.Drawing.Point(142, 159);
            this.uctxtBranchName.Name = "uctxtBranchName";
            this.uctxtBranchName.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtBranchName.Size = new System.Drawing.Size(446, 22);
            this.uctxtBranchName.TabIndex = 53;
            // 
            // lblLedgerName
            // 
            this.lblLedgerName.AutoSize = true;
            this.lblLedgerName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLedgerName.Location = new System.Drawing.Point(24, 159);
            this.lblLedgerName.Name = "lblLedgerName";
            this.lblLedgerName.Size = new System.Drawing.Size(100, 16);
            this.lblLedgerName.TabIndex = 52;
            this.lblLedgerName.Text = "Branch Name:";
            // 
            // uctxtAddress1
            // 
            this.uctxtAddress1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtAddress1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtAddress1.Location = new System.Drawing.Point(142, 183);
            this.uctxtAddress1.Name = "uctxtAddress1";
            this.uctxtAddress1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtAddress1.Size = new System.Drawing.Size(446, 22);
            this.uctxtAddress1.TabIndex = 55;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 54;
            this.label1.Text = "Address1:";
            // 
            // uctxtAddress2
            // 
            this.uctxtAddress2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtAddress2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtAddress2.Location = new System.Drawing.Point(142, 208);
            this.uctxtAddress2.Name = "uctxtAddress2";
            this.uctxtAddress2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtAddress2.Size = new System.Drawing.Size(446, 22);
            this.uctxtAddress2.TabIndex = 57;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(50, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 16);
            this.label3.TabIndex = 56;
            this.label3.Text = "Address2:";
            // 
            // uctxtCountry
            // 
            this.uctxtCountry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtCountry.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtCountry.Location = new System.Drawing.Point(142, 232);
            this.uctxtCountry.Name = "uctxtCountry";
            this.uctxtCountry.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtCountry.Size = new System.Drawing.Size(446, 22);
            this.uctxtCountry.TabIndex = 59;
            this.uctxtCountry.Text = "Bangladesh";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(58, 235);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 16);
            this.label4.TabIndex = 58;
            this.label4.Text = "Country:";
            // 
            // uctxtTelephone
            // 
            this.uctxtTelephone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtTelephone.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtTelephone.Location = new System.Drawing.Point(142, 257);
            this.uctxtTelephone.Name = "uctxtTelephone";
            this.uctxtTelephone.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtTelephone.Size = new System.Drawing.Size(446, 22);
            this.uctxtTelephone.TabIndex = 61;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(42, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 16);
            this.label5.TabIndex = 60;
            this.label5.Text = "Telephone:";
            // 
            // uctxtFax
            // 
            this.uctxtFax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtFax.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtFax.Location = new System.Drawing.Point(142, 282);
            this.uctxtFax.Name = "uctxtFax";
            this.uctxtFax.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtFax.Size = new System.Drawing.Size(446, 22);
            this.uctxtFax.TabIndex = 63;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(87, 285);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 16);
            this.label6.TabIndex = 62;
            this.label6.Text = "Fax:";
            // 
            // uctxtLocation
            // 
            this.uctxtLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtLocation.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtLocation.Location = new System.Drawing.Point(142, 307);
            this.uctxtLocation.Name = "uctxtLocation";
            this.uctxtLocation.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtLocation.Size = new System.Drawing.Size(446, 22);
            this.uctxtLocation.TabIndex = 65;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(54, 311);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 16);
            this.label8.TabIndex = 64;
            this.label8.Text = "Location:";
            // 
            // uctxtDeafaultBranch
            // 
            this.uctxtDeafaultBranch.BackColor = System.Drawing.Color.White;
            this.uctxtDeafaultBranch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtDeafaultBranch.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtDeafaultBranch.Location = new System.Drawing.Point(142, 332);
            this.uctxtDeafaultBranch.Name = "uctxtDeafaultBranch";
            this.uctxtDeafaultBranch.ReadOnly = true;
            this.uctxtDeafaultBranch.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtDeafaultBranch.Size = new System.Drawing.Size(446, 22);
            this.uctxtDeafaultBranch.TabIndex = 67;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(56, 361);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 16);
            this.label9.TabIndex = 66;
            this.label9.Text = "Inactive:";
            // 
            // uctxtInactive
            // 
            this.uctxtInactive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtInactive.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtInactive.Location = new System.Drawing.Point(142, 357);
            this.uctxtInactive.Name = "uctxtInactive";
            this.uctxtInactive.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtInactive.Size = new System.Drawing.Size(174, 22);
            this.uctxtInactive.TabIndex = 69;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(13, 336);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 16);
            this.label10.TabIndex = 68;
            this.label10.Text = "Default Branch:";
            // 
            // uctxtComments
            // 
            this.uctxtComments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtComments.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtComments.Location = new System.Drawing.Point(142, 382);
            this.uctxtComments.Name = "uctxtComments";
            this.uctxtComments.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtComments.Size = new System.Drawing.Size(446, 22);
            this.uctxtComments.TabIndex = 71;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(42, 386);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 16);
            this.label11.TabIndex = 70;
            this.label11.Text = "Comments:";
            // 
            // DG
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG.Location = new System.Drawing.Point(5, 408);
            this.DG.Name = "DG";
            this.DG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DG.Size = new System.Drawing.Size(629, 146);
            this.DG.TabIndex = 72;
            this.DG.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellContentClick);
            // 
            // txtbranchId
            // 
            this.txtbranchId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbranchId.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbranchId.Location = new System.Drawing.Point(54, 12);
            this.txtbranchId.Name = "txtbranchId";
            this.txtbranchId.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtbranchId.Size = new System.Drawing.Size(48, 22);
            this.txtbranchId.TabIndex = 70;
            this.txtbranchId.Visible = false;
            // 
            // frmBranch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(641, 526);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmBranch";
            this.Load += new System.EventHandler(this.frmBranch_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox uctxtBranchName;
        private System.Windows.Forms.Label lblLedgerName;
        private System.Windows.Forms.TextBox uctxtComments;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox uctxtInactive;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox uctxtDeafaultBranch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox uctxtLocation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox uctxtFax;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox uctxtTelephone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox uctxtCountry;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox uctxtAddress2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uctxtAddress1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DG;
        private System.Windows.Forms.TextBox txtbranchId;
    }
}
