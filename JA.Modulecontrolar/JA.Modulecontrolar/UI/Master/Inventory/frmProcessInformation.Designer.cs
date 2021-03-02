namespace JA.Modulecontrolar.UI.Inventory
{
    partial class frmProcessInformation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label5 = new System.Windows.Forms.Label();
            this.uctxtProcessName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ucWastageList = new MayhediControlLibrary.StandardDataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtWasQty = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.uctxtWastage = new System.Windows.Forms.TextBox();
            this.DgWastage = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ucRmList = new MayhediControlLibrary.StandardDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRmQty = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.uctxtConsumption = new System.Windows.Forms.TextBox();
            this.DgRm = new System.Windows.Forms.DataGridView();
            this.ucFGList = new MayhediControlLibrary.StandardDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uctxtFgQty = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uctxtFgItem = new System.Windows.Forms.TextBox();
            this.DgFG = new System.Windows.Forms.DataGridView();
            this.chkconversionFg = new System.Windows.Forms.CheckBox();
            this.chkTransfer = new System.Windows.Forms.CheckBox();
            this.btnFGProcess = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.uctxtBranchName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.uctxtLocation = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucWastageList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgWastage)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucRmList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgRm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucFGList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgFG)).BeginInit();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(402, 2);
            this.frmLabel.Size = new System.Drawing.Size(254, 33);
            this.frmLabel.Text = "Process Information";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.label10);
            this.pnlMain.Controls.Add(this.uctxtBranchName);
            this.pnlMain.Controls.Add(this.label11);
            this.pnlMain.Controls.Add(this.uctxtLocation);
            this.pnlMain.Controls.Add(this.chkTransfer);
            this.pnlMain.Controls.Add(this.groupBox2);
            this.pnlMain.Controls.Add(this.uctxtProcessName);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Location = new System.Drawing.Point(0, -89);
            this.pnlMain.Size = new System.Drawing.Size(1050, 604);
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.chkconversionFg);
            this.pnlTop.Size = new System.Drawing.Size(1057, 45);
            this.pnlTop.Controls.SetChildIndex(this.frmLabel, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnTopClose, 0);
            this.pnlTop.Controls.SetChildIndex(this.chkconversionFg, 0);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(11, 523);
            this.btnEdit.Size = new System.Drawing.Size(124, 35);
            this.btnEdit.Text = "List All";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(825, 523);
            this.btnSave.Size = new System.Drawing.Size(108, 35);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(331, 530);
            this.btnDelete.Size = new System.Drawing.Size(10, 8);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(470, 532);
            this.btnNew.Size = new System.Drawing.Size(10, 10);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(938, 523);
            this.btnClose.Size = new System.Drawing.Size(108, 35);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(442, 530);
            this.btnPrint.Size = new System.Drawing.Size(10, 10);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 561);
            this.groupBox1.Size = new System.Drawing.Size(1057, 25);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(222, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 18);
            this.label5.TabIndex = 50;
            this.label5.Text = "Process Name:";
            // 
            // uctxtProcessName
            // 
            this.uctxtProcessName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtProcessName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtProcessName.Location = new System.Drawing.Point(356, 142);
            this.uctxtProcessName.MaxLength = 50;
            this.uctxtProcessName.Name = "uctxtProcessName";
            this.uctxtProcessName.Size = new System.Drawing.Size(377, 23);
            this.uctxtProcessName.TabIndex = 49;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.ucFGList);
            this.groupBox2.Controls.Add(this.uctxtFgQty);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.uctxtFgItem);
            this.groupBox2.Controls.Add(this.DgFG);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(11, 217);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1032, 379);
            this.groupBox2.TabIndex = 73;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Finished Goods";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.ucWastageList);
            this.groupBox4.Controls.Add(this.txtWasQty);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.uctxtWastage);
            this.groupBox4.Controls.Add(this.DgWastage);
            this.groupBox4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(0, 360);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(57, 41);
            this.groupBox4.TabIndex = 75;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Wastage";
            this.groupBox4.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(827, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 18);
            this.label9.TabIndex = 98;
            this.label9.Text = "Qty.:";
            // 
            // ucWastageList
            // 
            this.ucWastageList.AllowUserToAddRows = false;
            this.ucWastageList.AllowUserToDeleteRows = false;
            this.ucWastageList.AllowUserToOrderColumns = true;
            this.ucWastageList.AllowUserToResizeColumns = false;
            this.ucWastageList.AllowUserToResizeRows = false;
            this.ucWastageList.BackgroundColor = System.Drawing.Color.White;
            this.ucWastageList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.ucWastageList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ucWastageList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ucWastageList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ucWastageList.DefaultCellStyle = dataGridViewCellStyle4;
            this.ucWastageList.Location = new System.Drawing.Point(209, 43);
            this.ucWastageList.MultiSelect = false;
            this.ucWastageList.Name = "ucWastageList";
            this.ucWastageList.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.ucWastageList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.ucWastageList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ucWastageList.Size = new System.Drawing.Size(615, 28);
            this.ucWastageList.TabIndex = 97;
            this.ucWastageList.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn3.HeaderText = "Item Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 500;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn4.HeaderText = "Closing Qty.";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // txtWasQty
            // 
            this.txtWasQty.BackColor = System.Drawing.Color.White;
            this.txtWasQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWasQty.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWasQty.ForeColor = System.Drawing.Color.Black;
            this.txtWasQty.Location = new System.Drawing.Point(877, 14);
            this.txtWasQty.Name = "txtWasQty";
            this.txtWasQty.Size = new System.Drawing.Size(136, 23);
            this.txtWasQty.TabIndex = 96;
            this.txtWasQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(101, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 18);
            this.label4.TabIndex = 76;
            this.label4.Text = "Item Name:";
            // 
            // uctxtWastage
            // 
            this.uctxtWastage.BackColor = System.Drawing.Color.White;
            this.uctxtWastage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtWastage.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtWastage.ForeColor = System.Drawing.Color.Black;
            this.uctxtWastage.Location = new System.Drawing.Point(206, 14);
            this.uctxtWastage.Name = "uctxtWastage";
            this.uctxtWastage.Size = new System.Drawing.Size(618, 23);
            this.uctxtWastage.TabIndex = 75;
            this.uctxtWastage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uctxtWastage_KeyUp);
            // 
            // DgWastage
            // 
            this.DgWastage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgWastage.Location = new System.Drawing.Point(206, 39);
            this.DgWastage.Name = "DgWastage";
            this.DgWastage.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgWastage.Size = new System.Drawing.Size(820, 91);
            this.DgWastage.TabIndex = 74;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(825, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 18);
            this.label6.TabIndex = 76;
            this.label6.Text = "Qty.:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.ucRmList);
            this.groupBox3.Controls.Add(this.txtRmQty);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.uctxtConsumption);
            this.groupBox3.Controls.Add(this.DgRm);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(0, 137);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1032, 243);
            this.groupBox3.TabIndex = 96;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Consumption";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(830, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 18);
            this.label8.TabIndex = 99;
            this.label8.Text = "Qty.:";
            // 
            // ucRmList
            // 
            this.ucRmList.AllowUserToAddRows = false;
            this.ucRmList.AllowUserToDeleteRows = false;
            this.ucRmList.AllowUserToOrderColumns = true;
            this.ucRmList.AllowUserToResizeColumns = false;
            this.ucRmList.AllowUserToResizeRows = false;
            this.ucRmList.BackgroundColor = System.Drawing.Color.White;
            this.ucRmList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.ucRmList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.ucRmList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ucRmList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ucRmList.DefaultCellStyle = dataGridViewCellStyle9;
            this.ucRmList.Location = new System.Drawing.Point(210, 35);
            this.ucRmList.MultiSelect = false;
            this.ucRmList.Name = "ucRmList";
            this.ucRmList.RowHeadersVisible = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            this.ucRmList.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.ucRmList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ucRmList.Size = new System.Drawing.Size(614, 28);
            this.ucRmList.TabIndex = 98;
            this.ucRmList.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn1.HeaderText = "Item Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 500;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn2.HeaderText = "Closing Qty.";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // txtRmQty
            // 
            this.txtRmQty.BackColor = System.Drawing.Color.White;
            this.txtRmQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRmQty.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRmQty.ForeColor = System.Drawing.Color.Black;
            this.txtRmQty.Location = new System.Drawing.Point(877, 9);
            this.txtRmQty.Name = "txtRmQty";
            this.txtRmQty.Size = new System.Drawing.Size(136, 23);
            this.txtRmQty.TabIndex = 96;
            this.txtRmQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(101, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 18);
            this.label3.TabIndex = 74;
            this.label3.Text = "Item Name:";
            // 
            // uctxtConsumption
            // 
            this.uctxtConsumption.BackColor = System.Drawing.Color.White;
            this.uctxtConsumption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtConsumption.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtConsumption.ForeColor = System.Drawing.Color.Black;
            this.uctxtConsumption.Location = new System.Drawing.Point(206, 9);
            this.uctxtConsumption.Name = "uctxtConsumption";
            this.uctxtConsumption.Size = new System.Drawing.Size(618, 23);
            this.uctxtConsumption.TabIndex = 73;
            this.uctxtConsumption.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uctxtConsumption_KeyUp);
            this.uctxtConsumption.Layout += new System.Windows.Forms.LayoutEventHandler(this.uctxtConsumption_Layout);
            // 
            // DgRm
            // 
            this.DgRm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgRm.Location = new System.Drawing.Point(206, 33);
            this.DgRm.Name = "DgRm";
            this.DgRm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgRm.Size = new System.Drawing.Size(822, 203);
            this.DgRm.TabIndex = 72;
            // 
            // ucFGList
            // 
            this.ucFGList.AllowUserToAddRows = false;
            this.ucFGList.AllowUserToDeleteRows = false;
            this.ucFGList.AllowUserToOrderColumns = true;
            this.ucFGList.AllowUserToResizeColumns = false;
            this.ucFGList.AllowUserToResizeRows = false;
            this.ucFGList.BackgroundColor = System.Drawing.Color.White;
            this.ucFGList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.ucFGList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.ucFGList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ucFGList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ucFGList.DefaultCellStyle = dataGridViewCellStyle14;
            this.ucFGList.Location = new System.Drawing.Point(208, 40);
            this.ucFGList.MultiSelect = false;
            this.ucFGList.Name = "ucFGList";
            this.ucFGList.RowHeadersVisible = false;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            this.ucFGList.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.ucFGList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ucFGList.Size = new System.Drawing.Size(616, 28);
            this.ucFGList.TabIndex = 95;
            this.ucFGList.Visible = false;
            // 
            // Column1
            // 
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle12;
            this.Column1.HeaderText = "Item Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 500;
            // 
            // Column2
            // 
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column2.DefaultCellStyle = dataGridViewCellStyle13;
            this.Column2.HeaderText = "Closing Qty.";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 108;
            // 
            // uctxtFgQty
            // 
            this.uctxtFgQty.BackColor = System.Drawing.Color.White;
            this.uctxtFgQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtFgQty.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtFgQty.ForeColor = System.Drawing.Color.Black;
            this.uctxtFgQty.Location = new System.Drawing.Point(877, 11);
            this.uctxtFgQty.Name = "uctxtFgQty";
            this.uctxtFgQty.Size = new System.Drawing.Size(145, 23);
            this.uctxtFgQty.TabIndex = 95;
            this.uctxtFgQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(101, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 18);
            this.label1.TabIndex = 71;
            this.label1.Text = "Item Name:";
            // 
            // uctxtFgItem
            // 
            this.uctxtFgItem.BackColor = System.Drawing.Color.White;
            this.uctxtFgItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtFgItem.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtFgItem.ForeColor = System.Drawing.Color.Black;
            this.uctxtFgItem.Location = new System.Drawing.Point(206, 11);
            this.uctxtFgItem.Name = "uctxtFgItem";
            this.uctxtFgItem.Size = new System.Drawing.Size(618, 23);
            this.uctxtFgItem.TabIndex = 70;
            this.uctxtFgItem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uctxtFgItem_KeyUp);
            // 
            // DgFG
            // 
            this.DgFG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgFG.Location = new System.Drawing.Point(206, 37);
            this.DgFG.Name = "DgFG";
            this.DgFG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgFG.Size = new System.Drawing.Size(822, 77);
            this.DgFG.TabIndex = 69;
            // 
            // chkconversionFg
            // 
            this.chkconversionFg.AutoSize = true;
            this.chkconversionFg.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkconversionFg.Location = new System.Drawing.Point(905, 9);
            this.chkconversionFg.Name = "chkconversionFg";
            this.chkconversionFg.Size = new System.Drawing.Size(120, 17);
            this.chkconversionFg.TabIndex = 97;
            this.chkconversionFg.Text = "Conversion FG";
            this.chkconversionFg.UseVisualStyleBackColor = true;
            this.chkconversionFg.Visible = false;
            this.chkconversionFg.CheckedChanged += new System.EventHandler(this.chkconversionFg_CheckedChanged);
            this.chkconversionFg.Click += new System.EventHandler(this.chkconversionFg_Click);
            // 
            // chkTransfer
            // 
            this.chkTransfer.AutoSize = true;
            this.chkTransfer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTransfer.Location = new System.Drawing.Point(904, 140);
            this.chkTransfer.Name = "chkTransfer";
            this.chkTransfer.Size = new System.Drawing.Size(127, 17);
            this.chkTransfer.TabIndex = 98;
            this.chkTransfer.Text = "MFG Production";
            this.chkTransfer.UseVisualStyleBackColor = true;
            this.chkTransfer.Visible = false;
            // 
            // btnFGProcess
            // 
            this.btnFGProcess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnFGProcess.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFGProcess.Location = new System.Drawing.Point(136, 522);
            this.btnFGProcess.Name = "btnFGProcess";
            this.btnFGProcess.Size = new System.Drawing.Size(108, 35);
            this.btnFGProcess.TabIndex = 15;
            this.btnFGProcess.Text = "FG Process";
            this.btnFGProcess.UseVisualStyleBackColor = false;
            this.btnFGProcess.Click += new System.EventHandler(this.btnFGProcess_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(251, 167);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 16);
            this.label10.TabIndex = 121;
            this.label10.Text = "Branch Name:";
            // 
            // uctxtBranchName
            // 
            this.uctxtBranchName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtBranchName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtBranchName.Location = new System.Drawing.Point(356, 167);
            this.uctxtBranchName.Name = "uctxtBranchName";
            this.uctxtBranchName.Size = new System.Drawing.Size(377, 23);
            this.uctxtBranchName.TabIndex = 120;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(240, 193);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(111, 16);
            this.label11.TabIndex = 119;
            this.label11.Text = "Location Name:";
            // 
            // uctxtLocation
            // 
            this.uctxtLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtLocation.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtLocation.Location = new System.Drawing.Point(356, 192);
            this.uctxtLocation.Name = "uctxtLocation";
            this.uctxtLocation.Size = new System.Drawing.Size(377, 23);
            this.uctxtLocation.TabIndex = 118;
            // 
            // frmProcessInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1057, 586);
            this.Controls.Add(this.btnFGProcess);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmProcessInformation";
            this.Load += new System.EventHandler(this.frmProcessInformation_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.pnlMain, 0);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.Controls.SetChildIndex(this.btnFGProcess, 0);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucWastageList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgWastage)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucRmList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgRm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucFGList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgFG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox uctxtProcessName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uctxtFgItem;
        private System.Windows.Forms.DataGridView DgFG;
        private System.Windows.Forms.TextBox uctxtFgQty;
        private System.Windows.Forms.CheckBox chkconversionFg;
        private MayhediControlLibrary.StandardDataGridView ucFGList;
        private System.Windows.Forms.GroupBox groupBox3;
        private MayhediControlLibrary.StandardDataGridView ucRmList;
        private System.Windows.Forms.TextBox txtRmQty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uctxtConsumption;
        private System.Windows.Forms.DataGridView DgRm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label9;
        private MayhediControlLibrary.StandardDataGridView ucWastageList;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.TextBox txtWasQty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox uctxtWastage;
        private System.Windows.Forms.DataGridView DgWastage;
        private System.Windows.Forms.CheckBox chkTransfer;
        private System.Windows.Forms.Button btnFGProcess;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox uctxtBranchName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox uctxtLocation;
    }
}
