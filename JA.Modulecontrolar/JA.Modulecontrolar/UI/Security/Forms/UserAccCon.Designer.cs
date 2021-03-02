namespace JA.Modulecontrolar.UI.Security.Forms
{
    partial class UserAccCon
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
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DGMaster = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DGTransaction = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.DGReports = new System.Windows.Forms.DataGridView();
            this.SalesRB = new System.Windows.Forms.RadioButton();
            this.Inventory = new System.Windows.Forms.RadioButton();
            this.AccountRB = new System.Windows.Forms.RadioButton();
            this.RBStockG = new System.Windows.Forms.RadioButton();
            this.Purchase = new System.Windows.Forms.RadioButton();
            this.lblModuleName = new System.Windows.Forms.Label();
            this.RBTools = new System.Windows.Forms.RadioButton();
            this.RBBranch = new System.Windows.Forms.RadioButton();
            this.RBLocation = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.RBmpo = new System.Windows.Forms.RadioButton();
            this.pnlSelection = new System.Windows.Forms.Panel();
            this.txtSerachRight = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblGroup = new System.Windows.Forms.Label();
            this.cboGroup = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnLeftAll = new System.Windows.Forms.Button();
            this.btnLeftSingle = new System.Windows.Forms.Button();
            this.btnRightAll = new System.Windows.Forms.Button();
            this.btnRightSingle = new System.Windows.Forms.Button();
            this.lstRight = new System.Windows.Forms.ListBox();
            this.lstLeft = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.cboTools = new System.Windows.Forms.ComboBox();
            this.cboAccounts = new System.Windows.Forms.ComboBox();
            this.cboInventory = new System.Windows.Forms.ComboBox();
            this.cboPurchase = new System.Windows.Forms.ComboBox();
            this.cboSales = new System.Windows.Forms.ComboBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.cboProjection = new System.Windows.Forms.ComboBox();
            this.radProjection = new System.Windows.Forms.RadioButton();
            this.radLedger = new System.Windows.Forms.RadioButton();
            this.btnMenuWise = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGMaster)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGTransaction)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGReports)).BeginInit();
            this.pnlSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.frmLabel.Location = new System.Drawing.Point(4, 9);
            this.frmLabel.Size = new System.Drawing.Size(0, 33);
            this.frmLabel.Text = "";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnMenuWise);
            this.pnlMain.Controls.Add(this.radLedger);
            this.pnlMain.Controls.Add(this.cboProjection);
            this.pnlMain.Controls.Add(this.radProjection);
            this.pnlMain.Controls.Add(this.btnReport);
            this.pnlMain.Controls.Add(this.txtUserName);
            this.pnlMain.Controls.Add(this.cboTools);
            this.pnlMain.Controls.Add(this.cboAccounts);
            this.pnlMain.Controls.Add(this.cboInventory);
            this.pnlMain.Controls.Add(this.cboPurchase);
            this.pnlMain.Controls.Add(this.cboSales);
            this.pnlMain.Controls.Add(this.RBmpo);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.RBLocation);
            this.pnlMain.Controls.Add(this.RBBranch);
            this.pnlMain.Controls.Add(this.RBTools);
            this.pnlMain.Controls.Add(this.Purchase);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.RBStockG);
            this.pnlMain.Controls.Add(this.AccountRB);
            this.pnlMain.Controls.Add(this.Inventory);
            this.pnlMain.Controls.Add(this.SalesRB);
            this.pnlMain.Controls.Add(this.tabControl1);
            this.pnlMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMain.Size = new System.Drawing.Size(1079, 639);
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.label4);
            this.pnlTop.Controls.Add(this.lblModuleName);
            this.pnlTop.Size = new System.Drawing.Size(1080, 58);
            this.pnlTop.Controls.SetChildIndex(this.lblModuleName, 0);
            this.pnlTop.Controls.SetChildIndex(this.frmLabel, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnTopClose, 0);
            this.pnlTop.Controls.SetChildIndex(this.label4, 0);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(363, 561);
            this.btnEdit.Size = new System.Drawing.Size(33, 10);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSave.Location = new System.Drawing.Point(817, 558);
            this.btnSave.Size = new System.Drawing.Size(129, 45);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(351, 559);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(363, 561);
            this.btnNew.Size = new System.Drawing.Size(18, 10);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(950, 558);
            this.btnClose.Size = new System.Drawing.Size(125, 45);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(351, 559);
            this.btnPrint.Size = new System.Drawing.Size(10, 10);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 604);
            this.groupBox1.Size = new System.Drawing.Size(1080, 25);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Name :";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(258, 151);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(820, 484);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DGMaster);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(812, 453);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "                   Master                                  ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DGMaster
            // 
            this.DGMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGMaster.Location = new System.Drawing.Point(2, 6);
            this.DGMaster.Name = "DGMaster";
            this.DGMaster.Size = new System.Drawing.Size(800, 432);
            this.DGMaster.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DGTransaction);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(812, 453);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "                  Transaction                            ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DGTransaction
            // 
            this.DGTransaction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGTransaction.Location = new System.Drawing.Point(4, 5);
            this.DGTransaction.Name = "DGTransaction";
            this.DGTransaction.Size = new System.Drawing.Size(804, 442);
            this.DGTransaction.TabIndex = 4;
            // 
            // tabPage3
            // 
            this.tabPage3.AutoScroll = true;
            this.tabPage3.AutoScrollMinSize = new System.Drawing.Size(500, 0);
            this.tabPage3.Controls.Add(this.DGReports);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(812, 453);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "                    Report                                  ";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // DGReports
            // 
            this.DGReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGReports.Location = new System.Drawing.Point(4, 4);
            this.DGReports.Name = "DGReports";
            this.DGReports.Size = new System.Drawing.Size(804, 442);
            this.DGReports.TabIndex = 5;
            // 
            // SalesRB
            // 
            this.SalesRB.AutoSize = true;
            this.SalesRB.Checked = true;
            this.SalesRB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalesRB.Location = new System.Drawing.Point(11, 252);
            this.SalesRB.Name = "SalesRB";
            this.SalesRB.Size = new System.Drawing.Size(67, 24);
            this.SalesRB.TabIndex = 4;
            this.SalesRB.TabStop = true;
            this.SalesRB.Text = "Sales";
            this.SalesRB.UseVisualStyleBackColor = true;
            // 
            // Inventory
            // 
            this.Inventory.AutoSize = true;
            this.Inventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Inventory.Location = new System.Drawing.Point(11, 314);
            this.Inventory.Name = "Inventory";
            this.Inventory.Size = new System.Drawing.Size(92, 24);
            this.Inventory.TabIndex = 5;
            this.Inventory.Text = "Inventory";
            this.Inventory.UseVisualStyleBackColor = true;
            // 
            // AccountRB
            // 
            this.AccountRB.AutoSize = true;
            this.AccountRB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountRB.Location = new System.Drawing.Point(11, 342);
            this.AccountRB.Name = "AccountRB";
            this.AccountRB.Size = new System.Drawing.Size(94, 24);
            this.AccountRB.TabIndex = 6;
            this.AccountRB.Text = "Accounts";
            this.AccountRB.UseVisualStyleBackColor = true;
            this.AccountRB.CheckedChanged += new System.EventHandler(this.AccountRB_CheckedChanged);
            // 
            // RBStockG
            // 
            this.RBStockG.AutoSize = true;
            this.RBStockG.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBStockG.Location = new System.Drawing.Point(126, 499);
            this.RBStockG.Name = "RBStockG";
            this.RBStockG.Size = new System.Drawing.Size(117, 24);
            this.RBStockG.TabIndex = 7;
            this.RBStockG.Text = "Stock Group";
            this.RBStockG.UseVisualStyleBackColor = true;
            this.RBStockG.Click += new System.EventHandler(this.RBStockG_Click);
            // 
            // Purchase
            // 
            this.Purchase.AutoSize = true;
            this.Purchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Purchase.Location = new System.Drawing.Point(11, 285);
            this.Purchase.Name = "Purchase";
            this.Purchase.Size = new System.Drawing.Size(94, 24);
            this.Purchase.TabIndex = 12;
            this.Purchase.Text = "Purchase";
            this.Purchase.UseVisualStyleBackColor = true;
            // 
            // lblModuleName
            // 
            this.lblModuleName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblModuleName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblModuleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblModuleName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblModuleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModuleName.ForeColor = System.Drawing.Color.Black;
            this.lblModuleName.Location = new System.Drawing.Point(509, 5);
            this.lblModuleName.Name = "lblModuleName";
            this.lblModuleName.Size = new System.Drawing.Size(562, 39);
            this.lblModuleName.TabIndex = 14;
            this.lblModuleName.Text = "                                Sales                                            " +
    "  ";
            this.lblModuleName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // RBTools
            // 
            this.RBTools.AutoSize = true;
            this.RBTools.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBTools.Location = new System.Drawing.Point(11, 409);
            this.RBTools.Name = "RBTools";
            this.RBTools.Size = new System.Drawing.Size(65, 24);
            this.RBTools.TabIndex = 15;
            this.RBTools.Text = "Tools";
            this.RBTools.UseVisualStyleBackColor = true;
            // 
            // RBBranch
            // 
            this.RBBranch.AutoSize = true;
            this.RBBranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBBranch.Location = new System.Drawing.Point(7, 456);
            this.RBBranch.Name = "RBBranch";
            this.RBBranch.Size = new System.Drawing.Size(78, 24);
            this.RBBranch.TabIndex = 16;
            this.RBBranch.Text = "Branch";
            this.RBBranch.UseVisualStyleBackColor = true;
            this.RBBranch.Click += new System.EventHandler(this.RBBranch_Click);
            // 
            // RBLocation
            // 
            this.RBLocation.AutoSize = true;
            this.RBLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBLocation.Location = new System.Drawing.Point(126, 456);
            this.RBLocation.Name = "RBLocation";
            this.RBLocation.Size = new System.Drawing.Size(88, 24);
            this.RBLocation.TabIndex = 17;
            this.RBLocation.Text = "Location";
            this.RBLocation.UseVisualStyleBackColor = true;
            this.RBLocation.CheckedChanged += new System.EventHandler(this.RBLocation_CheckedChanged);
            this.RBLocation.Click += new System.EventHandler(this.RBLocation_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Fuchsia;
            this.label3.Location = new System.Drawing.Point(2, 576);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "Press \'Y\' = Yes ; Press \'N\'= No";
            // 
            // RBmpo
            // 
            this.RBmpo.AutoSize = true;
            this.RBmpo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBmpo.Location = new System.Drawing.Point(7, 499);
            this.RBmpo.Name = "RBmpo";
            this.RBmpo.Size = new System.Drawing.Size(111, 24);
            this.RBmpo.TabIndex = 24;
            this.RBmpo.Text = "MPO Group";
            this.RBmpo.UseVisualStyleBackColor = true;
            this.RBmpo.Click += new System.EventHandler(this.RBmpo_Click);
            // 
            // pnlSelection
            // 
            this.pnlSelection.Controls.Add(this.txtSerachRight);
            this.pnlSelection.Controls.Add(this.progressBar1);
            this.pnlSelection.Controls.Add(this.lblGroup);
            this.pnlSelection.Controls.Add(this.cboGroup);
            this.pnlSelection.Controls.Add(this.txtSearch);
            this.pnlSelection.Controls.Add(this.btnLeftAll);
            this.pnlSelection.Controls.Add(this.btnLeftSingle);
            this.pnlSelection.Controls.Add(this.btnRightAll);
            this.pnlSelection.Controls.Add(this.btnRightSingle);
            this.pnlSelection.Controls.Add(this.lstRight);
            this.pnlSelection.Controls.Add(this.lstLeft);
            this.pnlSelection.Location = new System.Drawing.Point(263, 66);
            this.pnlSelection.Name = "pnlSelection";
            this.pnlSelection.Size = new System.Drawing.Size(812, 479);
            this.pnlSelection.TabIndex = 19;
            this.pnlSelection.Visible = false;
            // 
            // txtSerachRight
            // 
            this.txtSerachRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSerachRight.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerachRight.Location = new System.Drawing.Point(434, 22);
            this.txtSerachRight.Name = "txtSerachRight";
            this.txtSerachRight.Size = new System.Drawing.Size(352, 22);
            this.txtSerachRight.TabIndex = 16;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(146, 459);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(619, 15);
            this.progressBar1.TabIndex = 15;
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroup.Location = new System.Drawing.Point(7, 6);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(50, 13);
            this.lblGroup.TabIndex = 14;
            this.lblGroup.Text = "Group:";
            this.lblGroup.Visible = false;
            // 
            // cboGroup
            // 
            this.cboGroup.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGroup.FormattingEnabled = true;
            this.cboGroup.Location = new System.Drawing.Point(63, 2);
            this.cboGroup.Name = "cboGroup";
            this.cboGroup.Size = new System.Drawing.Size(274, 22);
            this.cboGroup.TabIndex = 13;
            this.cboGroup.Visible = false;
            this.cboGroup.SelectedIndexChanged += new System.EventHandler(this.cboGroup_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(0, 24);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(337, 22);
            this.txtSearch.TabIndex = 12;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged_1);
            // 
            // btnLeftAll
            // 
            this.btnLeftAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLeftAll.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftAll.Location = new System.Drawing.Point(348, 296);
            this.btnLeftAll.Name = "btnLeftAll";
            this.btnLeftAll.Size = new System.Drawing.Size(77, 45);
            this.btnLeftAll.TabIndex = 11;
            this.btnLeftAll.Text = "<<";
            this.btnLeftAll.UseVisualStyleBackColor = false;
            // 
            // btnLeftSingle
            // 
            this.btnLeftSingle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLeftSingle.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftSingle.Location = new System.Drawing.Point(348, 253);
            this.btnLeftSingle.Name = "btnLeftSingle";
            this.btnLeftSingle.Size = new System.Drawing.Size(77, 45);
            this.btnLeftSingle.TabIndex = 10;
            this.btnLeftSingle.Text = "<";
            this.btnLeftSingle.UseVisualStyleBackColor = false;
            // 
            // btnRightAll
            // 
            this.btnRightAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRightAll.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRightAll.Location = new System.Drawing.Point(348, 201);
            this.btnRightAll.Name = "btnRightAll";
            this.btnRightAll.Size = new System.Drawing.Size(77, 45);
            this.btnRightAll.TabIndex = 9;
            this.btnRightAll.Text = ">>";
            this.btnRightAll.UseVisualStyleBackColor = false;
            // 
            // btnRightSingle
            // 
            this.btnRightSingle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRightSingle.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRightSingle.Location = new System.Drawing.Point(348, 156);
            this.btnRightSingle.Name = "btnRightSingle";
            this.btnRightSingle.Size = new System.Drawing.Size(77, 45);
            this.btnRightSingle.TabIndex = 8;
            this.btnRightSingle.Text = ">";
            this.btnRightSingle.UseVisualStyleBackColor = false;
            this.btnRightSingle.Click += new System.EventHandler(this.btnRightSingle_Click_1);
            // 
            // lstRight
            // 
            this.lstRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstRight.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstRight.FormattingEnabled = true;
            this.lstRight.ItemHeight = 14;
            this.lstRight.Location = new System.Drawing.Point(433, 46);
            this.lstRight.Name = "lstRight";
            this.lstRight.Size = new System.Drawing.Size(354, 408);
            this.lstRight.TabIndex = 7;
            // 
            // lstLeft
            // 
            this.lstLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstLeft.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLeft.FormattingEnabled = true;
            this.lstLeft.ItemHeight = 14;
            this.lstLeft.Location = new System.Drawing.Point(0, 49);
            this.lstLeft.Name = "lstLeft";
            this.lstLeft.Size = new System.Drawing.Size(338, 408);
            this.lstLeft.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.BackColor = System.Drawing.Color.Turquoise;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(3, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(507, 39);
            this.label4.TabIndex = 15;
            this.label4.Text = "             Access Control Settings";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(6, 183);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(208, 26);
            this.txtUserName.TabIndex = 52;
            // 
            // cboTools
            // 
            this.cboTools.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cboTools.Enabled = false;
            this.cboTools.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTools.FormattingEnabled = true;
            this.cboTools.Items.AddRange(new object[] {
            "Full",
            "Partial",
            "No access"});
            this.cboTools.Location = new System.Drawing.Point(111, 409);
            this.cboTools.Name = "cboTools";
            this.cboTools.Size = new System.Drawing.Size(137, 26);
            this.cboTools.TabIndex = 51;
            // 
            // cboAccounts
            // 
            this.cboAccounts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cboAccounts.Enabled = false;
            this.cboAccounts.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAccounts.FormattingEnabled = true;
            this.cboAccounts.Items.AddRange(new object[] {
            "Full",
            "Partial",
            "No access"});
            this.cboAccounts.Location = new System.Drawing.Point(111, 345);
            this.cboAccounts.Name = "cboAccounts";
            this.cboAccounts.Size = new System.Drawing.Size(137, 26);
            this.cboAccounts.TabIndex = 50;
            // 
            // cboInventory
            // 
            this.cboInventory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cboInventory.Enabled = false;
            this.cboInventory.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboInventory.FormattingEnabled = true;
            this.cboInventory.Items.AddRange(new object[] {
            "Full",
            "Partial",
            "No access"});
            this.cboInventory.Location = new System.Drawing.Point(111, 315);
            this.cboInventory.Name = "cboInventory";
            this.cboInventory.Size = new System.Drawing.Size(137, 26);
            this.cboInventory.TabIndex = 49;
            // 
            // cboPurchase
            // 
            this.cboPurchase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cboPurchase.Enabled = false;
            this.cboPurchase.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPurchase.FormattingEnabled = true;
            this.cboPurchase.Items.AddRange(new object[] {
            "Full",
            "Partial",
            "No access"});
            this.cboPurchase.Location = new System.Drawing.Point(111, 285);
            this.cboPurchase.Name = "cboPurchase";
            this.cboPurchase.Size = new System.Drawing.Size(137, 26);
            this.cboPurchase.TabIndex = 48;
            // 
            // cboSales
            // 
            this.cboSales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cboSales.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSales.FormattingEnabled = true;
            this.cboSales.Items.AddRange(new object[] {
            "Full",
            "Partial",
            "No access"});
            this.cboSales.Location = new System.Drawing.Point(111, 255);
            this.cboSales.Name = "cboSales";
            this.cboSales.Size = new System.Drawing.Size(137, 26);
            this.cboSales.TabIndex = 47;
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Location = new System.Drawing.Point(6, 211);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(112, 27);
            this.btnReport.TabIndex = 53;
            this.btnReport.Text = "Module Wise";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // cboProjection
            // 
            this.cboProjection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cboProjection.Enabled = false;
            this.cboProjection.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProjection.FormattingEnabled = true;
            this.cboProjection.Items.AddRange(new object[] {
            "Full",
            "Partial",
            "No access"});
            this.cboProjection.Location = new System.Drawing.Point(112, 377);
            this.cboProjection.Name = "cboProjection";
            this.cboProjection.Size = new System.Drawing.Size(137, 26);
            this.cboProjection.TabIndex = 55;
            // 
            // radProjection
            // 
            this.radProjection.AutoSize = true;
            this.radProjection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radProjection.Location = new System.Drawing.Point(12, 378);
            this.radProjection.Name = "radProjection";
            this.radProjection.Size = new System.Drawing.Size(97, 24);
            this.radProjection.TabIndex = 54;
            this.radProjection.Text = "Projection";
            this.radProjection.UseVisualStyleBackColor = true;
            // 
            // radLedger
            // 
            this.radLedger.AutoSize = true;
            this.radLedger.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.radLedger.Location = new System.Drawing.Point(8, 541);
            this.radLedger.Name = "radLedger";
            this.radLedger.Size = new System.Drawing.Size(77, 24);
            this.radLedger.TabIndex = 56;
            this.radLedger.TabStop = true;
            this.radLedger.Text = "Ledger";
            this.radLedger.UseVisualStyleBackColor = true;
            this.radLedger.CheckedChanged += new System.EventHandler(this.radLedger_CheckedChanged);
            this.radLedger.Click += new System.EventHandler(this.radLedger_Click);
            // 
            // btnMenuWise
            // 
            this.btnMenuWise.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuWise.Location = new System.Drawing.Point(119, 211);
            this.btnMenuWise.Name = "btnMenuWise";
            this.btnMenuWise.Size = new System.Drawing.Size(96, 27);
            this.btnMenuWise.TabIndex = 57;
            this.btnMenuWise.Text = "Menu Wise";
            this.btnMenuWise.UseVisualStyleBackColor = true;
            this.btnMenuWise.Click += new System.EventHandler(this.btnMenuWise_Click);
            // 
            // UserAccCon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1080, 629);
            this.Controls.Add(this.pnlSelection);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "UserAccCon";
            this.Load += new System.EventHandler(this.UserAccCon_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.pnlMain, 0);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.Controls.SetChildIndex(this.pnlSelection, 0);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGMaster)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGTransaction)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGReports)).EndInit();
            this.pnlSelection.ResumeLayout(false);
            this.pnlSelection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RadioButton SalesRB;
        private System.Windows.Forms.RadioButton AccountRB;
        private System.Windows.Forms.RadioButton Inventory;
        private System.Windows.Forms.RadioButton RBStockG;
        internal System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RadioButton Purchase;
        private System.Windows.Forms.Label lblModuleName;
        private System.Windows.Forms.RadioButton RBTools;
        private System.Windows.Forms.RadioButton RBLocation;
        private System.Windows.Forms.RadioButton RBBranch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton RBmpo;
        private System.Windows.Forms.DataGridView DGMaster;
        private System.Windows.Forms.DataGridView DGTransaction;
        private System.Windows.Forms.DataGridView DGReports;
        private System.Windows.Forms.Panel pnlSelection;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnLeftAll;
        private System.Windows.Forms.Button btnLeftSingle;
        private System.Windows.Forms.Button btnRightAll;
        private System.Windows.Forms.Button btnRightSingle;
        private System.Windows.Forms.ListBox lstRight;
        private System.Windows.Forms.ListBox lstLeft;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.ComboBox cboTools;
        private System.Windows.Forms.ComboBox cboAccounts;
        private System.Windows.Forms.ComboBox cboInventory;
        private System.Windows.Forms.ComboBox cboPurchase;
        private System.Windows.Forms.ComboBox cboSales;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.ComboBox cboProjection;
        private System.Windows.Forms.RadioButton radProjection;
        private System.Windows.Forms.RadioButton radLedger;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.ComboBox cboGroup;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox txtSerachRight;
        private System.Windows.Forms.Button btnMenuWise;
    }
}
