namespace JA.Modulecontrolar.UI.Inventory
{
    partial class frmMFGdilutionStore
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtFGQnty = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ucFGList = new MayhediControlLibrary.StandardDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uctxtFgQty = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uctxtFgItem = new System.Windows.Forms.TextBox();
            this.DgFG = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.uctxtBranchName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.uctxtLocation = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtRMTotal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ucRmList = new MayhediControlLibrary.StandardDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRmQty = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.uctxtConsumption = new System.Windows.Forms.TextBox();
            this.DgRm = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNarration = new System.Windows.Forms.TextBox();
            this.dteDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.uctxtInvoiceNo = new System.Windows.Forms.TextBox();
            this.lblFGRate = new System.Windows.Forms.Label();
            this.btnSeach = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucFGList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgFG)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucRmList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgRm)).BeginInit();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(457, 4);
            this.frmLabel.Size = new System.Drawing.Size(176, 33);
            this.frmLabel.Text = "Dilution Store";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnSeach);
            this.pnlMain.Controls.Add(this.lblFGRate);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.uctxtInvoiceNo);
            this.pnlMain.Controls.Add(this.dteDate);
            this.pnlMain.Controls.Add(this.label9);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.txtNarration);
            this.pnlMain.Controls.Add(this.groupBox3);
            this.pnlMain.Controls.Add(this.label10);
            this.pnlMain.Controls.Add(this.uctxtBranchName);
            this.pnlMain.Controls.Add(this.label11);
            this.pnlMain.Controls.Add(this.uctxtLocation);
            this.pnlMain.Controls.Add(this.groupBox2);
            this.pnlMain.Location = new System.Drawing.Point(0, -89);
            this.pnlMain.Size = new System.Drawing.Size(1159, 710);
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(1162, 51);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(11, 624);
            this.btnEdit.Size = new System.Drawing.Size(124, 35);
            this.btnEdit.Text = "List All";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(935, 624);
            this.btnSave.Size = new System.Drawing.Size(108, 35);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(331, 631);
            this.btnDelete.Size = new System.Drawing.Size(10, 8);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(470, 633);
            this.btnNew.Size = new System.Drawing.Size(10, 10);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1048, 624);
            this.btnClose.Size = new System.Drawing.Size(108, 35);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(442, 631);
            this.btnPrint.Size = new System.Drawing.Size(10, 10);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 669);
            this.groupBox1.Size = new System.Drawing.Size(1162, 25);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtFGQnty);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.ucFGList);
            this.groupBox2.Controls.Add(this.uctxtFgQty);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.uctxtFgItem);
            this.groupBox2.Controls.Add(this.DgFG);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(7, 263);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(587, 399);
            this.groupBox2.TabIndex = 73;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Finished Goods";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(305, 372);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 18);
            this.label13.TabIndex = 145;
            this.label13.Text = "FG Qnty:";
            // 
            // txtFGQnty
            // 
            this.txtFGQnty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFGQnty.Enabled = false;
            this.txtFGQnty.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFGQnty.Location = new System.Drawing.Point(387, 370);
            this.txtFGQnty.Name = "txtFGQnty";
            this.txtFGQnty.Size = new System.Drawing.Size(194, 23);
            this.txtFGQnty.TabIndex = 142;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(498, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 18);
            this.label6.TabIndex = 76;
            this.label6.Text = "Qty.";
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
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.ucFGList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.ucFGList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ucFGList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ucFGList.DefaultCellStyle = dataGridViewCellStyle9;
            this.ucFGList.Location = new System.Drawing.Point(8, 77);
            this.ucFGList.MultiSelect = false;
            this.ucFGList.Name = "ucFGList";
            this.ucFGList.RowHeadersVisible = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            this.ucFGList.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.ucFGList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ucFGList.Size = new System.Drawing.Size(493, 28);
            this.ucFGList.TabIndex = 95;
            this.ucFGList.Visible = false;
            // 
            // Column1
            // 
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column1.HeaderText = "Item Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 350;
            // 
            // Column2
            // 
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column2.DefaultCellStyle = dataGridViewCellStyle8;
            this.Column2.HeaderText = "Closing Qty.";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 115;
            // 
            // uctxtFgQty
            // 
            this.uctxtFgQty.BackColor = System.Drawing.Color.White;
            this.uctxtFgQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtFgQty.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtFgQty.ForeColor = System.Drawing.Color.Black;
            this.uctxtFgQty.Location = new System.Drawing.Point(501, 52);
            this.uctxtFgQty.Name = "uctxtFgQty";
            this.uctxtFgQty.Size = new System.Drawing.Size(78, 23);
            this.uctxtFgQty.TabIndex = 95;
            this.uctxtFgQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 18);
            this.label1.TabIndex = 71;
            this.label1.Text = "Item Name";
            // 
            // uctxtFgItem
            // 
            this.uctxtFgItem.BackColor = System.Drawing.Color.White;
            this.uctxtFgItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtFgItem.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtFgItem.ForeColor = System.Drawing.Color.Black;
            this.uctxtFgItem.Location = new System.Drawing.Point(6, 52);
            this.uctxtFgItem.Name = "uctxtFgItem";
            this.uctxtFgItem.Size = new System.Drawing.Size(495, 23);
            this.uctxtFgItem.TabIndex = 70;
            this.uctxtFgItem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uctxtFgItem_KeyUp);
            // 
            // DgFG
            // 
            this.DgFG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgFG.Location = new System.Drawing.Point(8, 78);
            this.DgFG.Name = "DgFG";
            this.DgFG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgFG.Size = new System.Drawing.Size(573, 288);
            this.DgFG.TabIndex = 69;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 196);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 16);
            this.label10.TabIndex = 121;
            this.label10.Text = "Branch Name";
            // 
            // uctxtBranchName
            // 
            this.uctxtBranchName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtBranchName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtBranchName.Location = new System.Drawing.Point(12, 218);
            this.uctxtBranchName.Name = "uctxtBranchName";
            this.uctxtBranchName.Size = new System.Drawing.Size(377, 23);
            this.uctxtBranchName.TabIndex = 120;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(743, 196);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(153, 16);
            this.label11.TabIndex = 119;
            this.label11.Text = "Consumption Location";
            // 
            // uctxtLocation
            // 
            this.uctxtLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtLocation.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtLocation.Location = new System.Drawing.Point(743, 218);
            this.uctxtLocation.Name = "uctxtLocation";
            this.uctxtLocation.Size = new System.Drawing.Size(265, 23);
            this.uctxtLocation.TabIndex = 118;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txtRMTotal);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.ucRmList);
            this.groupBox3.Controls.Add(this.txtRmQty);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.uctxtConsumption);
            this.groupBox3.Controls.Add(this.DgRm);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(600, 266);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(544, 392);
            this.groupBox3.TabIndex = 122;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Consumption";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(224, 365);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(114, 18);
            this.label12.TabIndex = 144;
            this.label12.Text = "Total Amount:";
            // 
            // txtRMTotal
            // 
            this.txtRMTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRMTotal.Enabled = false;
            this.txtRMTotal.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRMTotal.Location = new System.Drawing.Point(344, 362);
            this.txtRMTotal.Name = "txtRMTotal";
            this.txtRMTotal.Size = new System.Drawing.Size(194, 23);
            this.txtRMTotal.TabIndex = 143;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(404, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 18);
            this.label8.TabIndex = 99;
            this.label8.Text = "Qty.";
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.ucRmList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ucRmList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ucRmList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ucRmList.DefaultCellStyle = dataGridViewCellStyle4;
            this.ucRmList.Location = new System.Drawing.Point(9, 72);
            this.ucRmList.MultiSelect = false;
            this.ucRmList.Name = "ucRmList";
            this.ucRmList.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.ucRmList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.ucRmList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ucRmList.Size = new System.Drawing.Size(406, 28);
            this.ucRmList.TabIndex = 98;
            this.ucRmList.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn1.HeaderText = "Item Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 300;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle3;
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
            this.txtRmQty.Location = new System.Drawing.Point(415, 49);
            this.txtRmQty.Name = "txtRmQty";
            this.txtRmQty.Size = new System.Drawing.Size(124, 23);
            this.txtRmQty.TabIndex = 96;
            this.txtRmQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 18);
            this.label3.TabIndex = 74;
            this.label3.Text = "Item Name";
            // 
            // uctxtConsumption
            // 
            this.uctxtConsumption.BackColor = System.Drawing.Color.White;
            this.uctxtConsumption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtConsumption.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtConsumption.ForeColor = System.Drawing.Color.Black;
            this.uctxtConsumption.Location = new System.Drawing.Point(6, 49);
            this.uctxtConsumption.Name = "uctxtConsumption";
            this.uctxtConsumption.Size = new System.Drawing.Size(409, 23);
            this.uctxtConsumption.TabIndex = 73;
            // 
            // DgRm
            // 
            this.DgRm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgRm.Location = new System.Drawing.Point(7, 75);
            this.DgRm.Name = "DgRm";
            this.DgRm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgRm.Size = new System.Drawing.Size(533, 284);
            this.DgRm.TabIndex = 72;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(390, 674);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 16);
            this.label4.TabIndex = 124;
            this.label4.Text = "Narration:";
            // 
            // txtNarration
            // 
            this.txtNarration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNarration.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNarration.Location = new System.Drawing.Point(465, 670);
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.Size = new System.Drawing.Size(377, 23);
            this.txtNarration.TabIndex = 123;
            // 
            // dteDate
            // 
            this.dteDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteDate.Location = new System.Drawing.Point(743, 166);
            this.dteDate.Name = "dteDate";
            this.dteDate.Size = new System.Drawing.Size(302, 23);
            this.dteDate.TabIndex = 139;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(743, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 16);
            this.label9.TabIndex = 140;
            this.label9.Text = "Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 16);
            this.label5.TabIndex = 142;
            this.label5.Text = "Voucher No";
            // 
            // uctxtInvoiceNo
            // 
            this.uctxtInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtInvoiceNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtInvoiceNo.Location = new System.Drawing.Point(10, 166);
            this.uctxtInvoiceNo.Name = "uctxtInvoiceNo";
            this.uctxtInvoiceNo.Size = new System.Drawing.Size(377, 23);
            this.uctxtInvoiceNo.TabIndex = 141;
            // 
            // lblFGRate
            // 
            this.lblFGRate.AutoSize = true;
            this.lblFGRate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFGRate.ForeColor = System.Drawing.Color.Blue;
            this.lblFGRate.Location = new System.Drawing.Point(107, 673);
            this.lblFGRate.Name = "lblFGRate";
            this.lblFGRate.Size = new System.Drawing.Size(17, 16);
            this.lblFGRate.TabIndex = 143;
            this.lblFGRate.Text = "0";
            // 
            // btnSeach
            // 
            this.btnSeach.Location = new System.Drawing.Point(1008, 217);
            this.btnSeach.Name = "btnSeach";
            this.btnSeach.Size = new System.Drawing.Size(36, 25);
            this.btnSeach.TabIndex = 144;
            this.btnSeach.Text = "&F";
            this.btnSeach.UseVisualStyleBackColor = true;
            this.btnSeach.Click += new System.EventHandler(this.btnSeach_Click);
            // 
            // frmMFGdilutionStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1162, 694);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmMFGdilutionStore";
            this.Load += new System.EventHandler(this.frmMFGdilutionStore_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucFGList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgFG)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucRmList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgRm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uctxtFgItem;
        private System.Windows.Forms.DataGridView DgFG;
        private System.Windows.Forms.TextBox uctxtFgQty;
        private MayhediControlLibrary.StandardDataGridView ucFGList;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox uctxtBranchName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox uctxtLocation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNarration;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private MayhediControlLibrary.StandardDataGridView ucRmList;
        private System.Windows.Forms.TextBox txtRmQty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uctxtConsumption;
        private System.Windows.Forms.DataGridView DgRm;
        private System.Windows.Forms.DateTimePicker dteDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox uctxtInvoiceNo;
        private System.Windows.Forms.Label lblFGRate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtRMTotal;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtFGQnty;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button btnSeach;
    }
}
