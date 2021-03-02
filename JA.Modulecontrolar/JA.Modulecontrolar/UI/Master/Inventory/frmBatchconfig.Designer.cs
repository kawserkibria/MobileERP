namespace JA.Modulecontrolar.UI.Master.Inventory
{
    partial class frmBatchconfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBatchconfig));
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.uctxtBatchNo = new System.Windows.Forms.TextBox();
            this.txtSlNo = new System.Windows.Forms.TextBox();
            this.uctxtComments = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.uctxtPartyName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.uctxtBatchSize = new MayhediControlLibrary.StandardNumericTextBox();
            this.mskManufactureDate = new System.Windows.Forms.TextBox();
            this.dteExpireDate = new System.Windows.Forms.TextBox();
            this.btnDashBoard = new System.Windows.Forms.Button();
            this.dteStartDate = new System.Windows.Forms.TextBox();
            this.dteEnddate = new System.Windows.Forms.TextBox();
            this.uctxtBatch1 = new System.Windows.Forms.TextBox();
            this.btnSerach1 = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(287, 9);
            this.frmLabel.Size = new System.Drawing.Size(249, 33);
            this.frmLabel.Text = "Batch Configuration";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnSerach1);
            this.pnlMain.Controls.Add(this.uctxtBatch1);
            this.pnlMain.Controls.Add(this.dteEnddate);
            this.pnlMain.Controls.Add(this.dteStartDate);
            this.pnlMain.Controls.Add(this.btnDashBoard);
            this.pnlMain.Controls.Add(this.dteExpireDate);
            this.pnlMain.Controls.Add(this.mskManufactureDate);
            this.pnlMain.Controls.Add(this.uctxtBatchSize);
            this.pnlMain.Controls.Add(this.label11);
            this.pnlMain.Controls.Add(this.label10);
            this.pnlMain.Controls.Add(this.label9);
            this.pnlMain.Controls.Add(this.label8);
            this.pnlMain.Controls.Add(this.uctxtPartyName);
            this.pnlMain.Controls.Add(this.label12);
            this.pnlMain.Controls.Add(this.cboYear);
            this.pnlMain.Controls.Add(this.cboStatus);
            this.pnlMain.Controls.Add(this.label6);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.uctxtComments);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.uctxtBatchNo);
            this.pnlMain.Size = new System.Drawing.Size(754, 405);
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.txtSlNo);
            this.pnlTop.Size = new System.Drawing.Size(757, 58);
            this.pnlTop.Controls.SetChildIndex(this.txtSlNo, 0);
            this.pnlTop.Controls.SetChildIndex(this.frmLabel, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnTopClose, 0);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(8, 321);
            this.btnEdit.Size = new System.Drawing.Size(132, 39);
            this.btnEdit.Text = "List All";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(529, 321);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(355, 320);
            this.btnDelete.Size = new System.Drawing.Size(10, 14);
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(411, 319);
            this.btnNew.Size = new System.Drawing.Size(10, 16);
            this.btnNew.Visible = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(643, 321);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(475, 323);
            this.btnPrint.Size = new System.Drawing.Size(10, 14);
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 360);
            this.groupBox1.Size = new System.Drawing.Size(757, 25);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(284, 321);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 18);
            this.label3.TabIndex = 56;
            this.label3.Text = "End Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 321);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 18);
            this.label1.TabIndex = 54;
            this.label1.Text = "Start Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 18);
            this.label5.TabIndex = 52;
            this.label5.Text = "Batch No";
            // 
            // uctxtBatchNo
            // 
            this.uctxtBatchNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtBatchNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtBatchNo.Location = new System.Drawing.Point(231, 227);
            this.uctxtBatchNo.MaxLength = 5;
            this.uctxtBatchNo.Name = "uctxtBatchNo";
            this.uctxtBatchNo.Size = new System.Drawing.Size(150, 23);
            this.uctxtBatchNo.TabIndex = 51;
            // 
            // txtSlNo
            // 
            this.txtSlNo.Location = new System.Drawing.Point(38, 12);
            this.txtSlNo.Name = "txtSlNo";
            this.txtSlNo.Size = new System.Drawing.Size(87, 20);
            this.txtSlNo.TabIndex = 50;
            this.txtSlNo.Visible = false;
            // 
            // uctxtComments
            // 
            this.uctxtComments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtComments.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtComments.Location = new System.Drawing.Point(161, 483);
            this.uctxtComments.Name = "uctxtComments";
            this.uctxtComments.Size = new System.Drawing.Size(10, 23);
            this.uctxtComments.TabIndex = 57;
            this.uctxtComments.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 483);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 18);
            this.label4.TabIndex = 58;
            this.label4.Text = "Commnets:";
            this.label4.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(586, 321);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 18);
            this.label6.TabIndex = 59;
            this.label6.Text = "Batch Status";
            // 
            // cboStatus
            // 
            this.cboStatus.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "Active",
            "Suspend",
            "Complete"});
            this.cboStatus.Location = new System.Drawing.Point(586, 344);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(131, 24);
            this.cboStatus.TabIndex = 60;
            this.cboStatus.Text = "Active";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label12.Location = new System.Drawing.Point(191, 153);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 16);
            this.label12.TabIndex = 99;
            this.label12.Text = "Year:";
            // 
            // cboYear
            // 
            this.cboYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboYear.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboYear.ForeColor = System.Drawing.Color.Red;
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Items.AddRange(new object[] {
            "2001",
            "2002",
            "2003",
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030",
            "2031",
            "2032",
            "2033",
            "2034",
            "2035",
            "2036",
            "2037",
            "2038",
            "2039",
            "2040",
            "2041",
            "2042",
            "2043",
            "2044",
            "2045",
            "2046",
            "2047",
            "2048",
            "2049",
            "2050"});
            this.cboYear.Location = new System.Drawing.Point(243, 152);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(169, 22);
            this.cboYear.TabIndex = 98;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(533, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 18);
            this.label8.TabIndex = 104;
            this.label8.Text = "Party Name:";
            this.label8.Visible = false;
            // 
            // uctxtPartyName
            // 
            this.uctxtPartyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtPartyName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtPartyName.Location = new System.Drawing.Point(632, 153);
            this.uctxtPartyName.MaxLength = 60;
            this.uctxtPartyName.Name = "uctxtPartyName";
            this.uctxtPartyName.Size = new System.Drawing.Size(28, 23);
            this.uctxtPartyName.TabIndex = 103;
            this.uctxtPartyName.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(284, 266);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 18);
            this.label9.TabIndex = 105;
            this.label9.Text = "Expire Date";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "FOLDRS01.ICO");
            this.imageList1.Images.SetKeyName(1, "DATA16.ICO");
            this.imageList1.Images.SetKeyName(2, "Text.ico");
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(466, 204);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 18);
            this.label10.TabIndex = 110;
            this.label10.Text = "Batch Size";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(8, 266);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(140, 18);
            this.label11.TabIndex = 111;
            this.label11.Text = "Manufacture Date";
            // 
            // uctxtBatchSize
            // 
            this.uctxtBatchSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtBatchSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtBatchSize.Location = new System.Drawing.Point(466, 227);
            this.uctxtBatchSize.Name = "uctxtBatchSize";
            this.uctxtBatchSize.Size = new System.Drawing.Size(251, 24);
            this.uctxtBatchSize.TabIndex = 113;
            // 
            // mskManufactureDate
            // 
            this.mskManufactureDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mskManufactureDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskManufactureDate.Location = new System.Drawing.Point(8, 289);
            this.mskManufactureDate.MaxLength = 50;
            this.mskManufactureDate.Name = "mskManufactureDate";
            this.mskManufactureDate.Size = new System.Drawing.Size(223, 23);
            this.mskManufactureDate.TabIndex = 114;
            // 
            // dteExpireDate
            // 
            this.dteExpireDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dteExpireDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteExpireDate.Location = new System.Drawing.Point(284, 289);
            this.dteExpireDate.MaxLength = 50;
            this.dteExpireDate.Name = "dteExpireDate";
            this.dteExpireDate.Size = new System.Drawing.Size(251, 23);
            this.dteExpireDate.TabIndex = 115;
            // 
            // btnDashBoard
            // 
            this.btnDashBoard.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashBoard.Location = new System.Drawing.Point(416, 150);
            this.btnDashBoard.Name = "btnDashBoard";
            this.btnDashBoard.Size = new System.Drawing.Size(79, 24);
            this.btnDashBoard.TabIndex = 116;
            this.btnDashBoard.Text = "Tree View";
            this.btnDashBoard.UseVisualStyleBackColor = true;
            this.btnDashBoard.Click += new System.EventHandler(this.btnDashBoard_Click);
            // 
            // dteStartDate
            // 
            this.dteStartDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dteStartDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteStartDate.Location = new System.Drawing.Point(8, 344);
            this.dteStartDate.MaxLength = 50;
            this.dteStartDate.Name = "dteStartDate";
            this.dteStartDate.Size = new System.Drawing.Size(223, 23);
            this.dteStartDate.TabIndex = 117;
            // 
            // dteEnddate
            // 
            this.dteEnddate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dteEnddate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteEnddate.Location = new System.Drawing.Point(284, 344);
            this.dteEnddate.MaxLength = 50;
            this.dteEnddate.Name = "dteEnddate";
            this.dteEnddate.Size = new System.Drawing.Size(251, 23);
            this.dteEnddate.TabIndex = 118;
            // 
            // uctxtBatch1
            // 
            this.uctxtBatch1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtBatch1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtBatch1.Location = new System.Drawing.Point(8, 227);
            this.uctxtBatch1.MaxLength = 50;
            this.uctxtBatch1.Name = "uctxtBatch1";
            this.uctxtBatch1.ReadOnly = true;
            this.uctxtBatch1.Size = new System.Drawing.Size(223, 23);
            this.uctxtBatch1.TabIndex = 119;
            // 
            // btnSerach1
            // 
            this.btnSerach1.BackColor = System.Drawing.Color.White;
            this.btnSerach1.ForeColor = System.Drawing.Color.Teal;
            this.btnSerach1.ImageIndex = 0;
            this.btnSerach1.ImageList = this.imageList1;
            this.btnSerach1.Location = new System.Drawing.Point(379, 226);
            this.btnSerach1.Name = "btnSerach1";
            this.btnSerach1.Size = new System.Drawing.Size(30, 25);
            this.btnSerach1.TabIndex = 120;
            this.btnSerach1.UseVisualStyleBackColor = false;
            this.btnSerach1.Click += new System.EventHandler(this.btnSerach1_Click);
            // 
            // frmBatchconfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(757, 385);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmBatchconfig";
            this.Load += new System.EventHandler(this.frmBatchconfig_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox uctxtBatchNo;
        private System.Windows.Forms.TextBox txtSlNo;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox uctxtComments;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox uctxtPartyName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private MayhediControlLibrary.StandardNumericTextBox uctxtBatchSize;
        private System.Windows.Forms.TextBox mskManufactureDate;
        private System.Windows.Forms.TextBox dteExpireDate;
        private System.Windows.Forms.Button btnDashBoard;
        private System.Windows.Forms.TextBox dteEnddate;
        private System.Windows.Forms.TextBox dteStartDate;
        private System.Windows.Forms.TextBox uctxtBatch1;
        private System.Windows.Forms.Button btnSerach1;
    }
}
