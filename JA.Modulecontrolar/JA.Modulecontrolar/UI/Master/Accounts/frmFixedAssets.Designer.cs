namespace JA.Modulecontrolar.UI.Master.Accounts
{
    partial class frmFixedAssets
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFixedAssets = new System.Windows.Forms.Panel();
            this.btnAdjustment = new System.Windows.Forms.Button();
            this.PicAssetBranch = new System.Windows.Forms.Panel();
            this.label29 = new System.Windows.Forms.Label();
            this.txtAccuBranchAmount = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtAccBranch = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label31 = new System.Windows.Forms.Label();
            this.dgAccumulateBranch = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtAccDistrAmountPre = new System.Windows.Forms.TextBox();
            this.txtTotalAccBranch = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.pnlAssets = new System.Windows.Forms.Panel();
            this.label25 = new System.Windows.Forms.Label();
            this.uctxtBranchAssAmount = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.uctxtAssetBranchName = new System.Windows.Forms.TextBox();
            this.btnBranchClose = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.ucGridAssetBranch = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtAssetBranchAmountPre = new System.Windows.Forms.TextBox();
            this.txtAssetsTotalBranch = new System.Windows.Forms.TextBox();
            this.btnAssetApply = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.txtSalvageValue = new System.Windows.Forms.TextBox();
            this.txtWittendownValue = new System.Windows.Forms.TextBox();
            this.txtAccumulatedDep = new System.Windows.Forms.TextBox();
            this.dteEffectform = new System.Windows.Forms.DateTimePicker();
            this.txtAssetsLife = new System.Windows.Forms.TextBox();
            this.txtDepRate = new System.Windows.Forms.TextBox();
            this.cboDepMethod = new System.Windows.Forms.ComboBox();
            this.txtPurchaseAmount = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtAssetsLedger = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlFixedAssets.SuspendLayout();
            this.PicAssetBranch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAccumulateBranch)).BeginInit();
            this.pnlAssets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridAssetBranch)).BeginInit();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(112, 5);
            this.frmLabel.Size = new System.Drawing.Size(328, 33);
            this.frmLabel.Text = "Fixed Assets Configuration";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlFixedAssets);
            this.pnlMain.Size = new System.Drawing.Size(507, 459);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(511, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(2, 376);
            this.btnEdit.Size = new System.Drawing.Size(121, 39);
            this.btnEdit.Text = "List All";
            this.btnEdit.Visible = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(286, 376);
            this.btnSave.Visible = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(5, -2);
            this.btnDelete.Size = new System.Drawing.Size(9, 12);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(8, 333);
            this.btnNew.Size = new System.Drawing.Size(10, 19);
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(396, 376);
            this.btnClose.Visible = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(116, -2);
            this.btnPrint.Size = new System.Drawing.Size(10, 13);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 415);
            this.groupBox1.Size = new System.Drawing.Size(511, 25);
            // 
            // pnlFixedAssets
            // 
            this.pnlFixedAssets.BackColor = System.Drawing.Color.Beige;
            this.pnlFixedAssets.Controls.Add(this.btnAdjustment);
            this.pnlFixedAssets.Controls.Add(this.PicAssetBranch);
            this.pnlFixedAssets.Controls.Add(this.pnlAssets);
            this.pnlFixedAssets.Controls.Add(this.label18);
            this.pnlFixedAssets.Controls.Add(this.txtSalvageValue);
            this.pnlFixedAssets.Controls.Add(this.txtWittendownValue);
            this.pnlFixedAssets.Controls.Add(this.txtAccumulatedDep);
            this.pnlFixedAssets.Controls.Add(this.dteEffectform);
            this.pnlFixedAssets.Controls.Add(this.txtAssetsLife);
            this.pnlFixedAssets.Controls.Add(this.txtDepRate);
            this.pnlFixedAssets.Controls.Add(this.cboDepMethod);
            this.pnlFixedAssets.Controls.Add(this.txtPurchaseAmount);
            this.pnlFixedAssets.Controls.Add(this.label16);
            this.pnlFixedAssets.Controls.Add(this.txtAssetsLedger);
            this.pnlFixedAssets.Controls.Add(this.label15);
            this.pnlFixedAssets.Controls.Add(this.label14);
            this.pnlFixedAssets.Controls.Add(this.label9);
            this.pnlFixedAssets.Controls.Add(this.label8);
            this.pnlFixedAssets.Controls.Add(this.label6);
            this.pnlFixedAssets.Controls.Add(this.label5);
            this.pnlFixedAssets.Controls.Add(this.label4);
            this.pnlFixedAssets.Controls.Add(this.label3);
            this.pnlFixedAssets.Location = new System.Drawing.Point(7, 146);
            this.pnlFixedAssets.Name = "pnlFixedAssets";
            this.pnlFixedAssets.Size = new System.Drawing.Size(495, 310);
            this.pnlFixedAssets.TabIndex = 69;
            // 
            // btnAdjustment
            // 
            this.btnAdjustment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAdjustment.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdjustment.Location = new System.Drawing.Point(393, 248);
            this.btnAdjustment.Name = "btnAdjustment";
            this.btnAdjustment.Size = new System.Drawing.Size(98, 56);
            this.btnAdjustment.TabIndex = 74;
            this.btnAdjustment.Text = "Adjustment Entry";
            this.btnAdjustment.UseVisualStyleBackColor = false;
            this.btnAdjustment.Click += new System.EventHandler(this.btnAdjustment_Click_1);
            // 
            // PicAssetBranch
            // 
            this.PicAssetBranch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.PicAssetBranch.Controls.Add(this.label29);
            this.PicAssetBranch.Controls.Add(this.txtAccuBranchAmount);
            this.PicAssetBranch.Controls.Add(this.label30);
            this.PicAssetBranch.Controls.Add(this.txtAccBranch);
            this.PicAssetBranch.Controls.Add(this.button1);
            this.PicAssetBranch.Controls.Add(this.label31);
            this.PicAssetBranch.Controls.Add(this.dgAccumulateBranch);
            this.PicAssetBranch.Controls.Add(this.txtAccDistrAmountPre);
            this.PicAssetBranch.Controls.Add(this.txtTotalAccBranch);
            this.PicAssetBranch.Controls.Add(this.button2);
            this.PicAssetBranch.Location = new System.Drawing.Point(7, 80);
            this.PicAssetBranch.Name = "PicAssetBranch";
            this.PicAssetBranch.Size = new System.Drawing.Size(434, 188);
            this.PicAssetBranch.TabIndex = 72;
            this.PicAssetBranch.Visible = false;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(210, 37);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(58, 16);
            this.label29.TabIndex = 67;
            this.label29.Text = "Amount";
            // 
            // txtAccuBranchAmount
            // 
            this.txtAccuBranchAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccuBranchAmount.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccuBranchAmount.Location = new System.Drawing.Point(271, 36);
            this.txtAccuBranchAmount.Name = "txtAccuBranchAmount";
            this.txtAccuBranchAmount.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAccuBranchAmount.Size = new System.Drawing.Size(116, 22);
            this.txtAccuBranchAmount.TabIndex = 66;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(3, 20);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(100, 16);
            this.label30.TabIndex = 65;
            this.label30.Text = "Branch Name:";
            // 
            // txtAccBranch
            // 
            this.txtAccBranch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccBranch.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccBranch.Location = new System.Drawing.Point(8, 36);
            this.txtAccBranch.Name = "txtAccBranch";
            this.txtAccBranch.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAccBranch.Size = new System.Drawing.Size(198, 22);
            this.txtAccBranch.TabIndex = 64;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Blue;
            this.button1.Location = new System.Drawing.Point(105, 148);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 6);
            this.button1.TabIndex = 63;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(87, 6);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(140, 16);
            this.label31.TabIndex = 62;
            this.label31.Text = "Distributed Amount:";
            // 
            // dgAccumulateBranch
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgAccumulateBranch.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgAccumulateBranch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgAccumulateBranch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAccumulateBranch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewButtonColumn1});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgAccumulateBranch.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgAccumulateBranch.Location = new System.Drawing.Point(7, 61);
            this.dgAccumulateBranch.Name = "dgAccumulateBranch";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgAccumulateBranch.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgAccumulateBranch.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgAccumulateBranch.Size = new System.Drawing.Size(426, 65);
            this.dgAccumulateBranch.TabIndex = 61;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Branch Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "Delete";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Width = 60;
            // 
            // txtAccDistrAmountPre
            // 
            this.txtAccDistrAmountPre.BackColor = System.Drawing.Color.White;
            this.txtAccDistrAmountPre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccDistrAmountPre.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccDistrAmountPre.Location = new System.Drawing.Point(241, 3);
            this.txtAccDistrAmountPre.Name = "txtAccDistrAmountPre";
            this.txtAccDistrAmountPre.ReadOnly = true;
            this.txtAccDistrAmountPre.Size = new System.Drawing.Size(108, 22);
            this.txtAccDistrAmountPre.TabIndex = 60;
            this.txtAccDistrAmountPre.Text = "0";
            this.txtAccDistrAmountPre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalAccBranch
            // 
            this.txtTotalAccBranch.BackColor = System.Drawing.Color.White;
            this.txtTotalAccBranch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalAccBranch.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAccBranch.Location = new System.Drawing.Point(270, 126);
            this.txtTotalAccBranch.Name = "txtTotalAccBranch";
            this.txtTotalAccBranch.ReadOnly = true;
            this.txtTotalAccBranch.Size = new System.Drawing.Size(100, 22);
            this.txtTotalAccBranch.TabIndex = 4;
            this.txtTotalAccBranch.Text = "0";
            this.txtTotalAccBranch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Blue;
            this.button2.Location = new System.Drawing.Point(7, 147);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 6);
            this.button2.TabIndex = 2;
            this.button2.Text = "Apply";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            // 
            // pnlAssets
            // 
            this.pnlAssets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlAssets.Controls.Add(this.label25);
            this.pnlAssets.Controls.Add(this.uctxtBranchAssAmount);
            this.pnlAssets.Controls.Add(this.label26);
            this.pnlAssets.Controls.Add(this.uctxtAssetBranchName);
            this.pnlAssets.Controls.Add(this.btnBranchClose);
            this.pnlAssets.Controls.Add(this.label23);
            this.pnlAssets.Controls.Add(this.ucGridAssetBranch);
            this.pnlAssets.Controls.Add(this.txtAssetBranchAmountPre);
            this.pnlAssets.Controls.Add(this.txtAssetsTotalBranch);
            this.pnlAssets.Controls.Add(this.btnAssetApply);
            this.pnlAssets.Location = new System.Drawing.Point(8, 222);
            this.pnlAssets.Name = "pnlAssets";
            this.pnlAssets.Size = new System.Drawing.Size(433, 10);
            this.pnlAssets.TabIndex = 73;
            this.pnlAssets.Visible = false;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(252, 37);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(58, 16);
            this.label25.TabIndex = 67;
            this.label25.Text = "Amount";
            // 
            // uctxtBranchAssAmount
            // 
            this.uctxtBranchAssAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtBranchAssAmount.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtBranchAssAmount.Location = new System.Drawing.Point(312, 37);
            this.uctxtBranchAssAmount.Name = "uctxtBranchAssAmount";
            this.uctxtBranchAssAmount.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtBranchAssAmount.Size = new System.Drawing.Size(110, 22);
            this.uctxtBranchAssAmount.TabIndex = 66;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(13, 18);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(100, 16);
            this.label26.TabIndex = 65;
            this.label26.Text = "Branch Name:";
            // 
            // uctxtAssetBranchName
            // 
            this.uctxtAssetBranchName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtAssetBranchName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtAssetBranchName.Location = new System.Drawing.Point(9, 36);
            this.uctxtAssetBranchName.Name = "uctxtAssetBranchName";
            this.uctxtAssetBranchName.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uctxtAssetBranchName.Size = new System.Drawing.Size(238, 22);
            this.uctxtAssetBranchName.TabIndex = 64;
            // 
            // btnBranchClose
            // 
            this.btnBranchClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnBranchClose.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBranchClose.ForeColor = System.Drawing.Color.Blue;
            this.btnBranchClose.Location = new System.Drawing.Point(105, 151);
            this.btnBranchClose.Name = "btnBranchClose";
            this.btnBranchClose.Size = new System.Drawing.Size(97, 10);
            this.btnBranchClose.TabIndex = 63;
            this.btnBranchClose.Text = "Cancel";
            this.btnBranchClose.UseVisualStyleBackColor = false;
            this.btnBranchClose.Visible = false;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(114, 2);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(140, 16);
            this.label23.TabIndex = 62;
            this.label23.Text = "Distributed Amount:";
            // 
            // ucGridAssetBranch
            // 
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGridAssetBranch.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ucGridAssetBranch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.ucGridAssetBranch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ucGridAssetBranch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Column8});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ucGridAssetBranch.DefaultCellStyle = dataGridViewCellStyle8;
            this.ucGridAssetBranch.Location = new System.Drawing.Point(7, 61);
            this.ucGridAssetBranch.Name = "ucGridAssetBranch";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ucGridAssetBranch.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGridAssetBranch.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.ucGridAssetBranch.Size = new System.Drawing.Size(423, 92);
            this.ucGridAssetBranch.TabIndex = 61;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Branch Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 120;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Delete";
            this.Column8.Name = "Column8";
            this.Column8.Width = 60;
            // 
            // txtAssetBranchAmountPre
            // 
            this.txtAssetBranchAmountPre.BackColor = System.Drawing.Color.White;
            this.txtAssetBranchAmountPre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAssetBranchAmountPre.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAssetBranchAmountPre.Location = new System.Drawing.Point(260, 2);
            this.txtAssetBranchAmountPre.Name = "txtAssetBranchAmountPre";
            this.txtAssetBranchAmountPre.ReadOnly = true;
            this.txtAssetBranchAmountPre.Size = new System.Drawing.Size(108, 22);
            this.txtAssetBranchAmountPre.TabIndex = 60;
            this.txtAssetBranchAmountPre.Text = "0";
            this.txtAssetBranchAmountPre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAssetsTotalBranch
            // 
            this.txtAssetsTotalBranch.BackColor = System.Drawing.Color.White;
            this.txtAssetsTotalBranch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAssetsTotalBranch.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAssetsTotalBranch.Location = new System.Drawing.Point(330, 155);
            this.txtAssetsTotalBranch.Name = "txtAssetsTotalBranch";
            this.txtAssetsTotalBranch.ReadOnly = true;
            this.txtAssetsTotalBranch.Size = new System.Drawing.Size(100, 22);
            this.txtAssetsTotalBranch.TabIndex = 4;
            this.txtAssetsTotalBranch.Text = "0";
            this.txtAssetsTotalBranch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAssetApply
            // 
            this.btnAssetApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAssetApply.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssetApply.ForeColor = System.Drawing.Color.Blue;
            this.btnAssetApply.Location = new System.Drawing.Point(7, 151);
            this.btnAssetApply.Name = "btnAssetApply";
            this.btnAssetApply.Size = new System.Drawing.Size(97, 10);
            this.btnAssetApply.TabIndex = 2;
            this.btnAssetApply.Text = "Apply";
            this.btnAssetApply.UseVisualStyleBackColor = false;
            this.btnAssetApply.Visible = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(208, 100);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(27, 16);
            this.label18.TabIndex = 63;
            this.label18.Text = "%:";
            // 
            // txtSalvageValue
            // 
            this.txtSalvageValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSalvageValue.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalvageValue.Location = new System.Drawing.Point(151, 201);
            this.txtSalvageValue.Name = "txtSalvageValue";
            this.txtSalvageValue.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSalvageValue.Size = new System.Drawing.Size(284, 22);
            this.txtSalvageValue.TabIndex = 61;
            // 
            // txtWittendownValue
            // 
            this.txtWittendownValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWittendownValue.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWittendownValue.Location = new System.Drawing.Point(151, 177);
            this.txtWittendownValue.Name = "txtWittendownValue";
            this.txtWittendownValue.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtWittendownValue.Size = new System.Drawing.Size(284, 22);
            this.txtWittendownValue.TabIndex = 60;
            // 
            // txtAccumulatedDep
            // 
            this.txtAccumulatedDep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccumulatedDep.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccumulatedDep.Location = new System.Drawing.Point(151, 153);
            this.txtAccumulatedDep.Name = "txtAccumulatedDep";
            this.txtAccumulatedDep.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAccumulatedDep.Size = new System.Drawing.Size(284, 22);
            this.txtAccumulatedDep.TabIndex = 59;
            // 
            // dteEffectform
            // 
            this.dteEffectform.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteEffectform.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteEffectform.Location = new System.Drawing.Point(151, 126);
            this.dteEffectform.Name = "dteEffectform";
            this.dteEffectform.Size = new System.Drawing.Size(284, 22);
            this.dteEffectform.TabIndex = 58;
            // 
            // txtAssetsLife
            // 
            this.txtAssetsLife.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAssetsLife.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAssetsLife.Location = new System.Drawing.Point(319, 98);
            this.txtAssetsLife.Name = "txtAssetsLife";
            this.txtAssetsLife.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAssetsLife.Size = new System.Drawing.Size(115, 22);
            this.txtAssetsLife.TabIndex = 57;
            // 
            // txtDepRate
            // 
            this.txtDepRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDepRate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepRate.Location = new System.Drawing.Point(151, 98);
            this.txtDepRate.Name = "txtDepRate";
            this.txtDepRate.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDepRate.Size = new System.Drawing.Size(53, 22);
            this.txtDepRate.TabIndex = 56;
            this.txtDepRate.Text = "0";
            this.txtDepRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cboDepMethod
            // 
            this.cboDepMethod.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDepMethod.FormattingEnabled = true;
            this.cboDepMethod.Items.AddRange(new object[] {
            "Reducing Balance",
            "Straight Line"});
            this.cboDepMethod.Location = new System.Drawing.Point(151, 75);
            this.cboDepMethod.Name = "cboDepMethod";
            this.cboDepMethod.Size = new System.Drawing.Size(284, 24);
            this.cboDepMethod.TabIndex = 55;
            this.cboDepMethod.Text = "Reducing Balance";
            // 
            // txtPurchaseAmount
            // 
            this.txtPurchaseAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPurchaseAmount.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPurchaseAmount.Location = new System.Drawing.Point(151, 51);
            this.txtPurchaseAmount.Name = "txtPurchaseAmount";
            this.txtPurchaseAmount.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPurchaseAmount.Size = new System.Drawing.Size(284, 22);
            this.txtPurchaseAmount.TabIndex = 54;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(40, 201);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(106, 16);
            this.label16.TabIndex = 53;
            this.label16.Text = "Salvage Value:";
            // 
            // txtAssetsLedger
            // 
            this.txtAssetsLedger.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAssetsLedger.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAssetsLedger.Location = new System.Drawing.Point(151, 28);
            this.txtAssetsLedger.Name = "txtAssetsLedger";
            this.txtAssetsLedger.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAssetsLedger.Size = new System.Drawing.Size(284, 22);
            this.txtAssetsLedger.TabIndex = 52;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(2, 177);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(144, 16);
            this.label15.TabIndex = 47;
            this.label15.Text = "Written Down Value:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(13, 152);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(134, 16);
            this.label14.TabIndex = 46;
            this.label14.Text = "Accumulated Dep.:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(21, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 16);
            this.label9.TabIndex = 45;
            this.label9.Text = "Dep. Effect From:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(237, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 16);
            this.label8.TabIndex = 44;
            this.label8.Text = "Asset Life:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(73, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 16);
            this.label6.TabIndex = 43;
            this.label6.Text = "Dep.Rate:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(49, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 16);
            this.label5.TabIndex = 42;
            this.label5.Text = "Dep. Method:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 16);
            this.label4.TabIndex = 41;
            this.label4.Text = "Purchase Amount:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(48, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 16);
            this.label3.TabIndex = 40;
            this.label3.Text = "Ledger Name:";
            // 
            // frmFixedAssets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(511, 440);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmFixedAssets";
            this.Load += new System.EventHandler(this.frmFixedAssets_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlFixedAssets.ResumeLayout(false);
            this.pnlFixedAssets.PerformLayout();
            this.PicAssetBranch.ResumeLayout(false);
            this.PicAssetBranch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAccumulateBranch)).EndInit();
            this.pnlAssets.ResumeLayout(false);
            this.pnlAssets.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridAssetBranch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFixedAssets;
        private System.Windows.Forms.Button btnAdjustment;
        private System.Windows.Forms.Panel PicAssetBranch;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtAccuBranchAmount;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtAccBranch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.DataGridView dgAccumulateBranch;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.TextBox txtAccDistrAmountPre;
        private System.Windows.Forms.TextBox txtTotalAccBranch;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel pnlAssets;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox uctxtBranchAssAmount;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox uctxtAssetBranchName;
        private System.Windows.Forms.Button btnBranchClose;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DataGridView ucGridAssetBranch;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewButtonColumn Column8;
        private System.Windows.Forms.TextBox txtAssetBranchAmountPre;
        private System.Windows.Forms.TextBox txtAssetsTotalBranch;
        private System.Windows.Forms.Button btnAssetApply;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtSalvageValue;
        private System.Windows.Forms.TextBox txtWittendownValue;
        private System.Windows.Forms.TextBox txtAccumulatedDep;
        private System.Windows.Forms.DateTimePicker dteEffectform;
        private System.Windows.Forms.TextBox txtAssetsLife;
        private System.Windows.Forms.TextBox txtDepRate;
        private System.Windows.Forms.ComboBox cboDepMethod;
        private System.Windows.Forms.TextBox txtPurchaseAmount;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtAssetsLedger;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;

    }
}
