namespace JA.Modulecontrolar.UI.Master.Sales
{
    partial class frmSalesRepresentive
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
            this.uctxtLedgerName = new System.Windows.Forms.TextBox();
            this.lblLedgerName = new System.Windows.Forms.Label();
            this.uctxtUnder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uctxtSalesRep = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.uctxtCommType = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.uctxtCommission = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.uctxtAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.uctxtAddress2 = new System.Windows.Forms.TextBox();
            this.uctxttargetAmount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.uctxtComments = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.uctxtDrcr = new System.Windows.Forms.TextBox();
            this.uctxtcpCode = new System.Windows.Forms.TextBox();
            this.uctxthomoeohall = new System.Windows.Forms.TextBox();
            this.uctxtTerritoryCode = new MayhediControlLibrary.StandardNumericTextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.uctxtTeritorryName = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.uctxtPhone = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.uctxtInactive = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(222, 6);
            this.frmLabel.Size = new System.Drawing.Size(218, 33);
            this.frmLabel.Text = "Doctor/Customer";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.uctxtInactive);
            this.pnlMain.Controls.Add(this.label13);
            this.pnlMain.Controls.Add(this.uctxtTerritoryCode);
            this.pnlMain.Controls.Add(this.label28);
            this.pnlMain.Controls.Add(this.uctxtTeritorryName);
            this.pnlMain.Controls.Add(this.lblCity);
            this.pnlMain.Controls.Add(this.uctxthomoeohall);
            this.pnlMain.Controls.Add(this.uctxtcpCode);
            this.pnlMain.Controls.Add(this.uctxtDrcr);
            this.pnlMain.Controls.Add(this.uctxtComments);
            this.pnlMain.Controls.Add(this.label12);
            this.pnlMain.Controls.Add(this.uctxtPhone);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.label11);
            this.pnlMain.Controls.Add(this.uctxtSalesRep);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.uctxtCommType);
            this.pnlMain.Controls.Add(this.uctxttargetAmount);
            this.pnlMain.Controls.Add(this.label9);
            this.pnlMain.Controls.Add(this.uctxtAddress2);
            this.pnlMain.Controls.Add(this.uctxtAddress);
            this.pnlMain.Controls.Add(this.label6);
            this.pnlMain.Controls.Add(this.uctxtCommission);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.uctxtUnder);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.uctxtLedgerName);
            this.pnlMain.Controls.Add(this.lblLedgerName);
            this.pnlMain.Size = new System.Drawing.Size(604, 491);
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(609, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(129, 411);
            this.btnEdit.Size = new System.Drawing.Size(141, 39);
            this.btnEdit.Text = "Tree View";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(377, 410);
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(305, 413);
            this.btnDelete.Size = new System.Drawing.Size(10, 15);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(0, 410);
            this.btnNew.Size = new System.Drawing.Size(127, 39);
            this.btnNew.Text = "List All";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(491, 410);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(331, 413);
            this.btnPrint.Size = new System.Drawing.Size(13, 15);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 458);
            this.groupBox1.Size = new System.Drawing.Size(609, 25);
            // 
            // uctxtLedgerName
            // 
            this.uctxtLedgerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtLedgerName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtLedgerName.Location = new System.Drawing.Point(177, 182);
            this.uctxtLedgerName.MaxLength = 60;
            this.uctxtLedgerName.Name = "uctxtLedgerName";
            this.uctxtLedgerName.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtLedgerName.Size = new System.Drawing.Size(413, 22);
            this.uctxtLedgerName.TabIndex = 1;
            // 
            // lblLedgerName
            // 
            this.lblLedgerName.AutoSize = true;
            this.lblLedgerName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLedgerName.Location = new System.Drawing.Point(66, 184);
            this.lblLedgerName.Name = "lblLedgerName";
            this.lblLedgerName.Size = new System.Drawing.Size(104, 16);
            this.lblLedgerName.TabIndex = 71;
            this.lblLedgerName.Text = "Doctor  Name:";
            // 
            // uctxtUnder
            // 
            this.uctxtUnder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtUnder.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtUnder.Location = new System.Drawing.Point(177, 229);
            this.uctxtUnder.Name = "uctxtUnder";
            this.uctxtUnder.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtUnder.Size = new System.Drawing.Size(413, 22);
            this.uctxtUnder.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(118, 231);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 73;
            this.label1.Text = "Under:";
            // 
            // uctxtSalesRep
            // 
            this.uctxtSalesRep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtSalesRep.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtSalesRep.Location = new System.Drawing.Point(177, 301);
            this.uctxtSalesRep.MaxLength = 60;
            this.uctxtSalesRep.Name = "uctxtSalesRep";
            this.uctxtSalesRep.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtSalesRep.Size = new System.Drawing.Size(413, 22);
            this.uctxtSalesRep.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(86, 304);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 16);
            this.label3.TabIndex = 75;
            this.label3.Text = "MPO Name:";
            // 
            // uctxtCommType
            // 
            this.uctxtCommType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtCommType.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtCommType.Location = new System.Drawing.Point(3, 217);
            this.uctxtCommType.Name = "uctxtCommType";
            this.uctxtCommType.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtCommType.Size = new System.Drawing.Size(22, 22);
            this.uctxtCommType.TabIndex = 78;
            this.uctxtCommType.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(74, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 16);
            this.label4.TabIndex = 77;
            this.label4.Text = "Doctor Code:";
            // 
            // uctxtCommission
            // 
            this.uctxtCommission.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtCommission.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtCommission.Location = new System.Drawing.Point(5, 332);
            this.uctxtCommission.Name = "uctxtCommission";
            this.uctxtCommission.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtCommission.Size = new System.Drawing.Size(20, 22);
            this.uctxtCommission.TabIndex = 80;
            this.uctxtCommission.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(51, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 16);
            this.label5.TabIndex = 79;
            this.label5.Text = "Pharmacy Name:";
            // 
            // uctxtAddress
            // 
            this.uctxtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtAddress.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtAddress.Location = new System.Drawing.Point(177, 324);
            this.uctxtAddress.MaxLength = 50;
            this.uctxtAddress.Name = "uctxtAddress";
            this.uctxtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtAddress.Size = new System.Drawing.Size(413, 22);
            this.uctxtAddress.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(104, 330);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 16);
            this.label6.TabIndex = 81;
            this.label6.Text = "Address:";
            // 
            // uctxtAddress2
            // 
            this.uctxtAddress2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtAddress2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtAddress2.Location = new System.Drawing.Point(177, 348);
            this.uctxtAddress2.MaxLength = 50;
            this.uctxtAddress2.Name = "uctxtAddress2";
            this.uctxtAddress2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtAddress2.Size = new System.Drawing.Size(413, 22);
            this.uctxtAddress2.TabIndex = 8;
            // 
            // uctxttargetAmount
            // 
            this.uctxttargetAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxttargetAmount.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxttargetAmount.Location = new System.Drawing.Point(177, 372);
            this.uctxttargetAmount.MaxLength = 50;
            this.uctxttargetAmount.Name = "uctxttargetAmount";
            this.uctxttargetAmount.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxttargetAmount.Size = new System.Drawing.Size(413, 22);
            this.uctxttargetAmount.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(59, 374);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 16);
            this.label9.TabIndex = 85;
            this.label9.Text = "Target Amount:";
            // 
            // uctxtComments
            // 
            this.uctxtComments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtComments.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtComments.Location = new System.Drawing.Point(177, 444);
            this.uctxtComments.MaxLength = 50;
            this.uctxtComments.Name = "uctxtComments";
            this.uctxtComments.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtComments.Size = new System.Drawing.Size(413, 22);
            this.uctxtComments.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(88, 446);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 16);
            this.label12.TabIndex = 91;
            this.label12.Text = "Comments:";
            // 
            // uctxtDrcr
            // 
            this.uctxtDrcr.BackColor = System.Drawing.Color.White;
            this.uctxtDrcr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtDrcr.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtDrcr.Location = new System.Drawing.Point(14, 284);
            this.uctxtDrcr.Name = "uctxtDrcr";
            this.uctxtDrcr.ReadOnly = true;
            this.uctxtDrcr.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtDrcr.Size = new System.Drawing.Size(11, 22);
            this.uctxtDrcr.TabIndex = 93;
            this.uctxtDrcr.Text = "Cr";
            this.uctxtDrcr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.uctxtDrcr.Visible = false;
            // 
            // uctxtcpCode
            // 
            this.uctxtcpCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtcpCode.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtcpCode.Location = new System.Drawing.Point(177, 159);
            this.uctxtcpCode.MaxLength = 60;
            this.uctxtcpCode.Name = "uctxtcpCode";
            this.uctxtcpCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtcpCode.Size = new System.Drawing.Size(231, 22);
            this.uctxtcpCode.TabIndex = 0;
            // 
            // uctxthomoeohall
            // 
            this.uctxthomoeohall.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxthomoeohall.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxthomoeohall.Location = new System.Drawing.Point(177, 206);
            this.uctxthomoeohall.MaxLength = 60;
            this.uctxthomoeohall.Name = "uctxthomoeohall";
            this.uctxthomoeohall.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxthomoeohall.Size = new System.Drawing.Size(413, 22);
            this.uctxthomoeohall.TabIndex = 2;
            // 
            // uctxtTerritoryCode
            // 
            this.uctxtTerritoryCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtTerritoryCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtTerritoryCode.Location = new System.Drawing.Point(177, 252);
            this.uctxtTerritoryCode.MaxLength = 4;
            this.uctxtTerritoryCode.Name = "uctxtTerritoryCode";
            this.uctxtTerritoryCode.Size = new System.Drawing.Size(231, 24);
            this.uctxtTerritoryCode.TabIndex = 4;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(62, 254);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(108, 16);
            this.label28.TabIndex = 122;
            this.label28.Text = "Territory Code:";
            // 
            // uctxtTeritorryName
            // 
            this.uctxtTeritorryName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtTeritorryName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtTeritorryName.Location = new System.Drawing.Point(177, 277);
            this.uctxtTeritorryName.MaxLength = 60;
            this.uctxtTeritorryName.Name = "uctxtTeritorryName";
            this.uctxtTeritorryName.ReadOnly = true;
            this.uctxtTeritorryName.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtTeritorryName.Size = new System.Drawing.Size(413, 22);
            this.uctxtTeritorryName.TabIndex = 5;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCity.Location = new System.Drawing.Point(59, 281);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(111, 16);
            this.lblCity.TabIndex = 121;
            this.lblCity.Text = "Territory Name:";
            // 
            // uctxtPhone
            // 
            this.uctxtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtPhone.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtPhone.Location = new System.Drawing.Point(177, 396);
            this.uctxtPhone.MaxLength = 30;
            this.uctxtPhone.Name = "uctxtPhone";
            this.uctxtPhone.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtPhone.Size = new System.Drawing.Size(413, 22);
            this.uctxtPhone.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(116, 398);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 16);
            this.label11.TabIndex = 89;
            this.label11.Text = "Phone:";
            // 
            // uctxtInactive
            // 
            this.uctxtInactive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtInactive.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtInactive.Location = new System.Drawing.Point(176, 420);
            this.uctxtInactive.MaxLength = 2;
            this.uctxtInactive.Name = "uctxtInactive";
            this.uctxtInactive.Size = new System.Drawing.Size(232, 22);
            this.uctxtInactive.TabIndex = 123;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(102, 422);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 16);
            this.label13.TabIndex = 124;
            this.label13.Text = "Inactive:";
            // 
            // frmSalesRepresentive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(609, 483);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmSalesRepresentive";
            this.Load += new System.EventHandler(this.frmSalesRepresentive_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox uctxtLedgerName;
        private System.Windows.Forms.Label lblLedgerName;
        private System.Windows.Forms.TextBox uctxtComments;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox uctxttargetAmount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox uctxtAddress2;
        private System.Windows.Forms.TextBox uctxtAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox uctxtCommission;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox uctxtCommType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox uctxtSalesRep;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uctxtUnder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uctxtDrcr;
        private System.Windows.Forms.TextBox uctxtcpCode;
        private System.Windows.Forms.TextBox uctxthomoeohall;
        private MayhediControlLibrary.StandardNumericTextBox uctxtTerritoryCode;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox uctxtTeritorryName;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox uctxtPhone;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox uctxtInactive;
        private System.Windows.Forms.Label label13;
    }
}
