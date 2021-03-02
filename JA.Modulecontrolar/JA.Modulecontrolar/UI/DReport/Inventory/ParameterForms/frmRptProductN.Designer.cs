namespace JA.Modulecontrolar.UI.DReport.Inventory.ParameterForms
{
    partial class frmRptProductN
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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dteToDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dteFromDate = new System.Windows.Forms.DateTimePicker();
            this.uctxtBranchName = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.gboxInwardPurchase = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radAlias = new System.Windows.Forms.RadioButton();
            this.radItem = new System.Windows.Forms.RadioButton();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.rbtnPurchase = new System.Windows.Forms.RadioButton();
            this.rbtntopSheet = new System.Windows.Forms.RadioButton();
            this.rbtnInvoiceP = new System.Windows.Forms.RadioButton();
            this.lstLeft = new System.Windows.Forms.ListBox();
            this.lstRight = new System.Windows.Forms.ListBox();
            this.btnRightSingle = new System.Windows.Forms.Button();
            this.btnRightAll = new System.Windows.Forms.Button();
            this.btnLeftSingle = new System.Windows.Forms.Button();
            this.btnLeftAll = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboGroupName = new System.Windows.Forms.ComboBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.chkStationary = new System.Windows.Forms.CheckBox();
            this.chkMainLocation = new System.Windows.Forms.CheckBox();
            this.chkboxRate = new System.Windows.Forms.CheckBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.gboxInwardPurchase.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.frmLabel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmLabel.Location = new System.Drawing.Point(250, 9);
            this.frmLabel.Size = new System.Drawing.Size(159, 23);
            this.frmLabel.Text = "Stock Information";
            this.frmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.chkboxRate);
            this.pnlMain.Controls.Add(this.chkMainLocation);
            this.pnlMain.Controls.Add(this.chkStationary);
            this.pnlMain.Controls.Add(this.groupBox7);
            this.pnlMain.Controls.Add(this.groupBox9);
            this.pnlMain.Controls.Add(this.gboxInwardPurchase);
            this.pnlMain.Controls.Add(this.uctxtBranchName);
            this.pnlMain.Controls.Add(this.lblCategory);
            this.pnlMain.Controls.Add(this.groupBox6);
            this.pnlMain.Size = new System.Drawing.Size(722, 529);
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(731, 51);
            this.pnlTop.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTop_Paint);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(354, 448);
            this.btnEdit.Size = new System.Drawing.Size(10, 14);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(241, 448);
            this.btnSave.Size = new System.Drawing.Size(10, 14);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(467, 448);
            this.btnDelete.Size = new System.Drawing.Size(10, 14);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(128, 448);
            this.btnNew.Size = new System.Drawing.Size(10, 14);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(614, 443);
            this.btnClose.Size = new System.Drawing.Size(108, 35);
            this.btnClose.Visible = true;
            // 
            // btnPrint
            // 
            this.btnPrint.ImageIndex = -1;
            this.btnPrint.ImageKey = "print.png";
            this.btnPrint.Location = new System.Drawing.Point(484, 443);
            this.btnPrint.Size = new System.Drawing.Size(124, 35);
            this.btnPrint.Text = "Preview";
            this.btnPrint.Visible = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 484);
            this.groupBox1.Size = new System.Drawing.Size(731, 25);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.dteToDate);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.dteFromDate);
            this.groupBox6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox6.Location = new System.Drawing.Point(186, 419);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(342, 89);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Date  Selection";
            this.groupBox6.Enter += new System.EventHandler(this.groupBox6_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(80, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "To:";
            // 
            // dteToDate
            // 
            this.dteToDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteToDate.Location = new System.Drawing.Point(118, 49);
            this.dteToDate.Name = "dteToDate";
            this.dteToDate.Size = new System.Drawing.Size(167, 22);
            this.dteToDate.TabIndex = 22;
            this.dteToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dteToDate_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(61, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "From:";
            // 
            // dteFromDate
            // 
            this.dteFromDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteFromDate.Location = new System.Drawing.Point(118, 21);
            this.dteFromDate.Name = "dteFromDate";
            this.dteFromDate.Size = new System.Drawing.Size(167, 22);
            this.dteFromDate.TabIndex = 20;
            this.dteFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dteFromDate_KeyPress);
            // 
            // uctxtBranchName
            // 
            this.uctxtBranchName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtBranchName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtBranchName.Location = new System.Drawing.Point(128, 194);
            this.uctxtBranchName.Name = "uctxtBranchName";
            this.uctxtBranchName.Size = new System.Drawing.Size(293, 23);
            this.uctxtBranchName.TabIndex = 58;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(27, 197);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(95, 14);
            this.lblCategory.TabIndex = 59;
            this.lblCategory.Text = "Branch Name:";
            // 
            // gboxInwardPurchase
            // 
            this.gboxInwardPurchase.Controls.Add(this.groupBox3);
            this.gboxInwardPurchase.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gboxInwardPurchase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gboxInwardPurchase.Location = new System.Drawing.Point(6, 484);
            this.gboxInwardPurchase.Name = "gboxInwardPurchase";
            this.gboxInwardPurchase.Size = new System.Drawing.Size(10, 11);
            this.gboxInwardPurchase.TabIndex = 62;
            this.gboxInwardPurchase.TabStop = false;
            this.gboxInwardPurchase.Text = "Invoice/Purchase Price Option";
            this.gboxInwardPurchase.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radAlias);
            this.groupBox3.Controls.Add(this.radItem);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(6, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(320, 35);
            this.groupBox3.TabIndex = 61;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sort Order";
            // 
            // radAlias
            // 
            this.radAlias.AutoSize = true;
            this.radAlias.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAlias.ForeColor = System.Drawing.Color.Black;
            this.radAlias.Location = new System.Drawing.Point(206, 9);
            this.radAlias.Name = "radAlias";
            this.radAlias.Size = new System.Drawing.Size(54, 18);
            this.radAlias.TabIndex = 1;
            this.radAlias.Text = "Alias";
            this.radAlias.UseVisualStyleBackColor = true;
            // 
            // radItem
            // 
            this.radItem.AutoSize = true;
            this.radItem.Checked = true;
            this.radItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radItem.ForeColor = System.Drawing.Color.Black;
            this.radItem.Location = new System.Drawing.Point(85, 9);
            this.radItem.Name = "radItem";
            this.radItem.Size = new System.Drawing.Size(94, 18);
            this.radItem.TabIndex = 0;
            this.radItem.TabStop = true;
            this.radItem.Text = "Item Name";
            this.radItem.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.rbtnPurchase);
            this.groupBox9.Controls.Add(this.rbtntopSheet);
            this.groupBox9.Controls.Add(this.rbtnInvoiceP);
            this.groupBox9.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox9.ForeColor = System.Drawing.Color.Black;
            this.groupBox9.Location = new System.Drawing.Point(20, 139);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(686, 47);
            this.groupBox9.TabIndex = 66;
            this.groupBox9.TabStop = false;
            this.groupBox9.Enter += new System.EventHandler(this.groupBox9_Enter);
            // 
            // rbtnPurchase
            // 
            this.rbtnPurchase.AutoSize = true;
            this.rbtnPurchase.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPurchase.ForeColor = System.Drawing.Color.Black;
            this.rbtnPurchase.Location = new System.Drawing.Point(526, 19);
            this.rbtnPurchase.Name = "rbtnPurchase";
            this.rbtnPurchase.Size = new System.Drawing.Size(121, 22);
            this.rbtnPurchase.TabIndex = 3;
            this.rbtnPurchase.Text = "Raw Material";
            this.rbtnPurchase.UseVisualStyleBackColor = true;
            this.rbtnPurchase.Click += new System.EventHandler(this.rbtnPurchase_Click);
            this.rbtnPurchase.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbtnPurchase_MouseClick);
            // 
            // rbtntopSheet
            // 
            this.rbtntopSheet.AutoSize = true;
            this.rbtntopSheet.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtntopSheet.ForeColor = System.Drawing.Color.Black;
            this.rbtntopSheet.Location = new System.Drawing.Point(228, 19);
            this.rbtntopSheet.Name = "rbtntopSheet";
            this.rbtntopSheet.Size = new System.Drawing.Size(218, 22);
            this.rbtntopSheet.TabIndex = 1;
            this.rbtntopSheet.Text = "Finished Goods Top Sheet";
            this.rbtntopSheet.UseVisualStyleBackColor = true;
            this.rbtntopSheet.Click += new System.EventHandler(this.rbtntopSheet_Click);
            this.rbtntopSheet.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbtnCostP_MouseClick);
            // 
            // rbtnInvoiceP
            // 
            this.rbtnInvoiceP.AutoSize = true;
            this.rbtnInvoiceP.Checked = true;
            this.rbtnInvoiceP.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnInvoiceP.ForeColor = System.Drawing.Color.Black;
            this.rbtnInvoiceP.Location = new System.Drawing.Point(41, 19);
            this.rbtnInvoiceP.Name = "rbtnInvoiceP";
            this.rbtnInvoiceP.Size = new System.Drawing.Size(139, 22);
            this.rbtnInvoiceP.TabIndex = 0;
            this.rbtnInvoiceP.TabStop = true;
            this.rbtnInvoiceP.Text = "Finished Goods";
            this.rbtnInvoiceP.UseVisualStyleBackColor = true;
            this.rbtnInvoiceP.Click += new System.EventHandler(this.rbtnInvoiceP_Click);
            this.rbtnInvoiceP.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbtnInvoiceP_MouseClick);
            // 
            // lstLeft
            // 
            this.lstLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstLeft.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLeft.FormattingEnabled = true;
            this.lstLeft.ItemHeight = 14;
            this.lstLeft.Location = new System.Drawing.Point(6, 53);
            this.lstLeft.Name = "lstLeft";
            this.lstLeft.Size = new System.Drawing.Size(254, 128);
            this.lstLeft.TabIndex = 0;
            // 
            // lstRight
            // 
            this.lstRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstRight.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstRight.FormattingEnabled = true;
            this.lstRight.ItemHeight = 14;
            this.lstRight.Location = new System.Drawing.Point(308, 52);
            this.lstRight.Name = "lstRight";
            this.lstRight.Size = new System.Drawing.Size(221, 128);
            this.lstRight.TabIndex = 1;
            // 
            // btnRightSingle
            // 
            this.btnRightSingle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRightSingle.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRightSingle.Location = new System.Drawing.Point(268, 64);
            this.btnRightSingle.Name = "btnRightSingle";
            this.btnRightSingle.Size = new System.Drawing.Size(36, 23);
            this.btnRightSingle.TabIndex = 2;
            this.btnRightSingle.Text = ">";
            this.btnRightSingle.UseVisualStyleBackColor = false;
            this.btnRightSingle.Click += new System.EventHandler(this.btnRightSingle_Click);
            // 
            // btnRightAll
            // 
            this.btnRightAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRightAll.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRightAll.Location = new System.Drawing.Point(268, 89);
            this.btnRightAll.Name = "btnRightAll";
            this.btnRightAll.Size = new System.Drawing.Size(36, 23);
            this.btnRightAll.TabIndex = 3;
            this.btnRightAll.Text = ">>";
            this.btnRightAll.UseVisualStyleBackColor = false;
            this.btnRightAll.Click += new System.EventHandler(this.btnRightAll_Click);
            // 
            // btnLeftSingle
            // 
            this.btnLeftSingle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLeftSingle.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftSingle.Location = new System.Drawing.Point(268, 114);
            this.btnLeftSingle.Name = "btnLeftSingle";
            this.btnLeftSingle.Size = new System.Drawing.Size(36, 23);
            this.btnLeftSingle.TabIndex = 4;
            this.btnLeftSingle.Text = "<";
            this.btnLeftSingle.UseVisualStyleBackColor = false;
            this.btnLeftSingle.Click += new System.EventHandler(this.btnLeftSingle_Click);
            // 
            // btnLeftAll
            // 
            this.btnLeftAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLeftAll.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftAll.Location = new System.Drawing.Point(268, 139);
            this.btnLeftAll.Name = "btnLeftAll";
            this.btnLeftAll.Size = new System.Drawing.Size(36, 23);
            this.btnLeftAll.TabIndex = 5;
            this.btnLeftAll.Text = "<<";
            this.btnLeftAll.UseVisualStyleBackColor = false;
            this.btnLeftAll.Click += new System.EventHandler(this.btnLeftAll_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(6, 30);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(254, 22);
            this.txtSearch.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(202, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "Search";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(308, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 16);
            this.label6.TabIndex = 24;
            this.label6.Text = "Stock Group Select";
            this.label6.Visible = false;
            // 
            // cboGroupName
            // 
            this.cboGroupName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGroupName.ForeColor = System.Drawing.Color.Blue;
            this.cboGroupName.FormattingEnabled = true;
            this.cboGroupName.Location = new System.Drawing.Point(308, 28);
            this.cboGroupName.Name = "cboGroupName";
            this.cboGroupName.Size = new System.Drawing.Size(220, 22);
            this.cboGroupName.TabIndex = 25;
            this.cboGroupName.SelectedIndexChanged += new System.EventHandler(this.cboGroupName_SelectedIndexChanged_1);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label11);
            this.groupBox7.Controls.Add(this.cboGroupName);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.txtSearch);
            this.groupBox7.Controls.Add(this.btnLeftAll);
            this.groupBox7.Controls.Add(this.btnLeftSingle);
            this.groupBox7.Controls.Add(this.btnRightAll);
            this.groupBox7.Controls.Add(this.btnRightSingle);
            this.groupBox7.Controls.Add(this.lstRight);
            this.groupBox7.Controls.Add(this.lstLeft);
            this.groupBox7.Location = new System.Drawing.Point(91, 223);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(534, 190);
            this.groupBox7.TabIndex = 72;
            this.groupBox7.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Blue;
            this.label11.Location = new System.Drawing.Point(7, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 16);
            this.label11.TabIndex = 33;
            this.label11.Text = "Stock Group";
            // 
            // chkStationary
            // 
            this.chkStationary.AutoSize = true;
            this.chkStationary.Font = new System.Drawing.Font("Verdana", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkStationary.Location = new System.Drawing.Point(451, 200);
            this.chkStationary.Name = "chkStationary";
            this.chkStationary.Size = new System.Drawing.Size(15, 14);
            this.chkStationary.TabIndex = 73;
            this.chkStationary.UseVisualStyleBackColor = true;
            this.chkStationary.Visible = false;
            this.chkStationary.Click += new System.EventHandler(this.chkStationary_Click);
            // 
            // chkMainLocation
            // 
            this.chkMainLocation.AutoSize = true;
            this.chkMainLocation.Checked = true;
            this.chkMainLocation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMainLocation.Enabled = false;
            this.chkMainLocation.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMainLocation.Location = new System.Drawing.Point(12, 491);
            this.chkMainLocation.Name = "chkMainLocation";
            this.chkMainLocation.Size = new System.Drawing.Size(115, 17);
            this.chkMainLocation.TabIndex = 74;
            this.chkMainLocation.Text = "Main Location";
            this.chkMainLocation.UseVisualStyleBackColor = true;
            // 
            // chkboxRate
            // 
            this.chkboxRate.AutoSize = true;
            this.chkboxRate.Font = new System.Drawing.Font("Verdana", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkboxRate.Location = new System.Drawing.Point(628, 235);
            this.chkboxRate.Name = "chkboxRate";
            this.chkboxRate.Size = new System.Drawing.Size(94, 18);
            this.chkboxRate.TabIndex = 75;
            this.chkboxRate.Text = "Summary";
            this.chkboxRate.UseVisualStyleBackColor = true;
            this.chkboxRate.Visible = false;
            this.chkboxRate.Click += new System.EventHandler(this.chkboxRate_Click);
            // 
            // frmRptProductN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(731, 509);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmRptProductN";
            this.Load += new System.EventHandler(this.frmRptProductN_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.gboxInwardPurchase.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dteToDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dteFromDate;
        private System.Windows.Forms.TextBox uctxtBranchName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.GroupBox gboxInwardPurchase;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radAlias;
        private System.Windows.Forms.RadioButton radItem;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.RadioButton rbtnPurchase;
        private System.Windows.Forms.RadioButton rbtntopSheet;
        private System.Windows.Forms.RadioButton rbtnInvoiceP;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ComboBox cboGroupName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnLeftAll;
        private System.Windows.Forms.Button btnLeftSingle;
        private System.Windows.Forms.Button btnRightAll;
        private System.Windows.Forms.Button btnRightSingle;
        private System.Windows.Forms.ListBox lstRight;
        private System.Windows.Forms.ListBox lstLeft;
        private System.Windows.Forms.CheckBox chkStationary;
        private System.Windows.Forms.CheckBox chkMainLocation;
        private System.Windows.Forms.CheckBox chkboxRate;
        private System.Windows.Forms.Label label11;
    }
}
