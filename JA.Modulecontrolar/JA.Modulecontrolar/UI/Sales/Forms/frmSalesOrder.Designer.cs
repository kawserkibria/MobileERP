namespace JA.Modulecontrolar.UI.Sales.Forms
{
    partial class frmSalesOrder
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
            this.dteDate = new System.Windows.Forms.DateTimePicker();
            this.uctxtLocation = new System.Windows.Forms.TextBox();
            this.uctxtbranchName = new System.Windows.Forms.TextBox();
            this.uctxtSalesRepresentive = new System.Windows.Forms.TextBox();
            this.uctxtPartyName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uctxtSalesOrderNo = new System.Windows.Forms.TextBox();
            this.dteDueDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.uclstGrdItem = new MayhediControlLibrary.StandardDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.uctxtRate = new System.Windows.Forms.TextBox();
            this.btnDown = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.uctxtQty = new System.Windows.Forms.TextBox();
            this.DG = new MayhediDataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.uctxtItemName = new System.Windows.Forms.TextBox();
            this.uctxtNarration = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.uctxtdelivery = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.uctxtPayment = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.uctxtSupportWarrenty = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.uctxtValidityQuotation = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.uctxtOthersterms = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblTotalQnty = new System.Windows.Forms.Label();
            this.lblTotalAmnt = new System.Windows.Forms.Label();
            this.lblcurrBalance = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uclstGrdItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).BeginInit();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(365, 4);
            this.frmLabel.Size = new System.Drawing.Size(152, 33);
            this.frmLabel.Text = "Sales Order";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.textBox1);
            this.pnlMain.Controls.Add(this.lblcurrBalance);
            this.pnlMain.Controls.Add(this.lblTotalAmnt);
            this.pnlMain.Controls.Add(this.lblTotalQnty);
            this.pnlMain.Controls.Add(this.label21);
            this.pnlMain.Controls.Add(this.label20);
            this.pnlMain.Controls.Add(this.uctxtOthersterms);
            this.pnlMain.Controls.Add(this.label19);
            this.pnlMain.Controls.Add(this.uctxtValidityQuotation);
            this.pnlMain.Controls.Add(this.label18);
            this.pnlMain.Controls.Add(this.uctxtSupportWarrenty);
            this.pnlMain.Controls.Add(this.label17);
            this.pnlMain.Controls.Add(this.uctxtPayment);
            this.pnlMain.Controls.Add(this.label16);
            this.pnlMain.Controls.Add(this.uctxtdelivery);
            this.pnlMain.Controls.Add(this.label15);
            this.pnlMain.Controls.Add(this.label14);
            this.pnlMain.Controls.Add(this.uctxtNarration);
            this.pnlMain.Controls.Add(this.label13);
            this.pnlMain.Controls.Add(this.panel2);
            this.pnlMain.Controls.Add(this.dteDueDate);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.dteDate);
            this.pnlMain.Controls.Add(this.uctxtLocation);
            this.pnlMain.Controls.Add(this.uctxtbranchName);
            this.pnlMain.Controls.Add(this.uctxtSalesRepresentive);
            this.pnlMain.Controls.Add(this.uctxtPartyName);
            this.pnlMain.Controls.Add(this.label11);
            this.pnlMain.Controls.Add(this.label10);
            this.pnlMain.Controls.Add(this.label9);
            this.pnlMain.Controls.Add(this.label8);
            this.pnlMain.Controls.Add(this.label6);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.uctxtSalesOrderNo);
            this.pnlMain.Size = new System.Drawing.Size(863, 798);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(864, 46);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(6, 713);
            this.btnEdit.Size = new System.Drawing.Size(116, 39);
            this.btnEdit.Text = "List All";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(642, 713);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(332, 715);
            this.btnDelete.Size = new System.Drawing.Size(10, 17);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(478, 713);
            this.btnNew.Size = new System.Drawing.Size(10, 17);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(752, 713);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(440, 717);
            this.btnPrint.Size = new System.Drawing.Size(10, 17);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 758);
            // 
            // dteDate
            // 
            this.dteDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteDate.Location = new System.Drawing.Point(299, 174);
            this.dteDate.Name = "dteDate";
            this.dteDate.Size = new System.Drawing.Size(200, 23);
            this.dteDate.TabIndex = 1;
            // 
            // uctxtLocation
            // 
            this.uctxtLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtLocation.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtLocation.Location = new System.Drawing.Point(298, 298);
            this.uctxtLocation.Name = "uctxtLocation";
            this.uctxtLocation.Size = new System.Drawing.Size(358, 23);
            this.uctxtLocation.TabIndex = 6;
            // 
            // uctxtbranchName
            // 
            this.uctxtbranchName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtbranchName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtbranchName.Location = new System.Drawing.Point(298, 273);
            this.uctxtbranchName.Name = "uctxtbranchName";
            this.uctxtbranchName.Size = new System.Drawing.Size(358, 23);
            this.uctxtbranchName.TabIndex = 5;
            // 
            // uctxtSalesRepresentive
            // 
            this.uctxtSalesRepresentive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtSalesRepresentive.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtSalesRepresentive.Location = new System.Drawing.Point(298, 224);
            this.uctxtSalesRepresentive.Name = "uctxtSalesRepresentive";
            this.uctxtSalesRepresentive.Size = new System.Drawing.Size(358, 23);
            this.uctxtSalesRepresentive.TabIndex = 3;
            // 
            // uctxtPartyName
            // 
            this.uctxtPartyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtPartyName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtPartyName.Location = new System.Drawing.Point(298, 199);
            this.uctxtPartyName.Name = "uctxtPartyName";
            this.uctxtPartyName.Size = new System.Drawing.Size(358, 23);
            this.uctxtPartyName.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(212, 298);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 18);
            this.label11.TabIndex = 80;
            this.label11.Text = "Location:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(177, 274);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 18);
            this.label10.TabIndex = 79;
            this.label10.Text = "Branch name:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(135, 229);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(155, 18);
            this.label9.TabIndex = 78;
            this.label9.Text = "Sales Representive:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(187, 200);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 18);
            this.label8.TabIndex = 77;
            this.label8.Text = "Party Name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(240, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 18);
            this.label6.TabIndex = 76;
            this.label6.Text = "Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(203, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 18);
            this.label1.TabIndex = 75;
            this.label1.Text = "Order No:";
            // 
            // uctxtSalesOrderNo
            // 
            this.uctxtSalesOrderNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtSalesOrderNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtSalesOrderNo.Location = new System.Drawing.Point(298, 148);
            this.uctxtSalesOrderNo.Name = "uctxtSalesOrderNo";
            this.uctxtSalesOrderNo.Size = new System.Drawing.Size(358, 23);
            this.uctxtSalesOrderNo.TabIndex = 0;
            // 
            // dteDueDate
            // 
            this.dteDueDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteDueDate.Location = new System.Drawing.Point(298, 248);
            this.dteDueDate.Name = "dteDueDate";
            this.dteDueDate.Size = new System.Drawing.Size(200, 23);
            this.dteDueDate.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(206, 251);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 18);
            this.label3.TabIndex = 86;
            this.label3.Text = "Due Date:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.uclstGrdItem);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.uctxtRate);
            this.panel2.Controls.Add(this.btnDown);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.uctxtQty);
            this.panel2.Controls.Add(this.DG);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.uctxtItemName);
            this.panel2.Location = new System.Drawing.Point(11, 327);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(855, 284);
            this.panel2.TabIndex = 88;
            // 
            // uclstGrdItem
            // 
            this.uclstGrdItem.AllowUserToAddRows = false;
            this.uclstGrdItem.AllowUserToDeleteRows = false;
            this.uclstGrdItem.AllowUserToOrderColumns = true;
            this.uclstGrdItem.AllowUserToResizeColumns = false;
            this.uclstGrdItem.AllowUserToResizeRows = false;
            this.uclstGrdItem.BackgroundColor = System.Drawing.Color.White;
            this.uclstGrdItem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.uclstGrdItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.uclstGrdItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uclstGrdItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uclstGrdItem.DefaultCellStyle = dataGridViewCellStyle2;
            this.uclstGrdItem.Location = new System.Drawing.Point(7, 62);
            this.uclstGrdItem.MultiSelect = false;
            this.uclstGrdItem.Name = "uclstGrdItem";
            this.uclstGrdItem.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            this.uclstGrdItem.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.uclstGrdItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.uclstGrdItem.Size = new System.Drawing.Size(542, 28);
            this.uclstGrdItem.TabIndex = 95;
            this.uclstGrdItem.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Item Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 420;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Cls. Qty";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(774, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 18);
            this.label5.TabIndex = 71;
            this.label5.Text = "Rate";
            // 
            // uctxtRate
            // 
            this.uctxtRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtRate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtRate.Location = new System.Drawing.Point(684, 24);
            this.uctxtRate.Name = "uctxtRate";
            this.uctxtRate.Size = new System.Drawing.Size(135, 23);
            this.uctxtRate.TabIndex = 9;
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(815, 23);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(30, 23);
            this.btnDown.TabIndex = 67;
            this.btnDown.Text = ">>";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(550, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 18);
            this.label4.TabIndex = 60;
            this.label4.Text = "Qty";
            // 
            // uctxtQty
            // 
            this.uctxtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtQty.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtQty.Location = new System.Drawing.Point(549, 24);
            this.uctxtQty.Name = "uctxtQty";
            this.uctxtQty.Size = new System.Drawing.Size(135, 23);
            this.uctxtQty.TabIndex = 8;
            // 
            // DG
            // 
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG.Location = new System.Drawing.Point(3, 49);
            this.DG.Name = "DG";
            this.DG.Size = new System.Drawing.Size(842, 229);
            this.DG.TabIndex = 58;
            this.DG.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellContentClick);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 18);
            this.label12.TabIndex = 57;
            this.label12.Text = "Name:";
            // 
            // uctxtItemName
            // 
            this.uctxtItemName.BackColor = System.Drawing.Color.White;
            this.uctxtItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtItemName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtItemName.ForeColor = System.Drawing.Color.Red;
            this.uctxtItemName.Location = new System.Drawing.Point(2, 24);
            this.uctxtItemName.Name = "uctxtItemName";
            this.uctxtItemName.Size = new System.Drawing.Size(547, 23);
            this.uctxtItemName.TabIndex = 7;
            this.uctxtItemName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uctxtItemName_KeyUp);
            // 
            // uctxtNarration
            // 
            this.uctxtNarration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtNarration.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtNarration.Location = new System.Drawing.Point(300, 654);
            this.uctxtNarration.Name = "uctxtNarration";
            this.uctxtNarration.Size = new System.Drawing.Size(358, 23);
            this.uctxtNarration.TabIndex = 10;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(214, 654);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 18);
            this.label13.TabIndex = 89;
            this.label13.Text = "Narration:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label14.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(23, 684);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(156, 18);
            this.label14.TabIndex = 91;
            this.label14.Text = "Terms && Condition :";
            // 
            // uctxtdelivery
            // 
            this.uctxtdelivery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtdelivery.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtdelivery.Location = new System.Drawing.Point(184, 712);
            this.uctxtdelivery.Name = "uctxtdelivery";
            this.uctxtdelivery.Size = new System.Drawing.Size(236, 23);
            this.uctxtdelivery.TabIndex = 11;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(103, 711);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 18);
            this.label15.TabIndex = 92;
            this.label15.Text = "Delivery:";
            // 
            // uctxtPayment
            // 
            this.uctxtPayment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtPayment.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtPayment.Location = new System.Drawing.Point(612, 720);
            this.uctxtPayment.Name = "uctxtPayment";
            this.uctxtPayment.Size = new System.Drawing.Size(236, 23);
            this.uctxtPayment.TabIndex = 14;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(525, 721);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(81, 18);
            this.label16.TabIndex = 94;
            this.label16.Text = "Payment:";
            // 
            // uctxtSupportWarrenty
            // 
            this.uctxtSupportWarrenty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtSupportWarrenty.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtSupportWarrenty.Location = new System.Drawing.Point(184, 736);
            this.uctxtSupportWarrenty.Name = "uctxtSupportWarrenty";
            this.uctxtSupportWarrenty.Size = new System.Drawing.Size(236, 23);
            this.uctxtSupportWarrenty.TabIndex = 12;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(15, 736);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(163, 18);
            this.label17.TabIndex = 96;
            this.label17.Text = "Support && Warrenty:";
            // 
            // uctxtValidityQuotation
            // 
            this.uctxtValidityQuotation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtValidityQuotation.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtValidityQuotation.Location = new System.Drawing.Point(612, 744);
            this.uctxtValidityQuotation.Name = "uctxtValidityQuotation";
            this.uctxtValidityQuotation.Size = new System.Drawing.Size(236, 23);
            this.uctxtValidityQuotation.TabIndex = 15;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(435, 745);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(170, 18);
            this.label18.TabIndex = 98;
            this.label18.Text = "Validity of Quotation :";
            // 
            // uctxtOthersterms
            // 
            this.uctxtOthersterms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtOthersterms.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtOthersterms.Location = new System.Drawing.Point(184, 760);
            this.uctxtOthersterms.Name = "uctxtOthersterms";
            this.uctxtOthersterms.Size = new System.Drawing.Size(236, 23);
            this.uctxtOthersterms.TabIndex = 13;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(68, 758);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(107, 18);
            this.label19.TabIndex = 100;
            this.label19.Text = "Other Terms:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(321, 616);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(84, 16);
            this.label20.TabIndex = 102;
            this.label20.Text = "Total Qnty:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(602, 616);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(102, 16);
            this.label21.TabIndex = 103;
            this.label21.Text = "Total Amount:";
            // 
            // lblTotalQnty
            // 
            this.lblTotalQnty.AutoSize = true;
            this.lblTotalQnty.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalQnty.ForeColor = System.Drawing.Color.Red;
            this.lblTotalQnty.Location = new System.Drawing.Point(408, 619);
            this.lblTotalQnty.Name = "lblTotalQnty";
            this.lblTotalQnty.Size = new System.Drawing.Size(15, 14);
            this.lblTotalQnty.TabIndex = 104;
            this.lblTotalQnty.Text = "0";
            // 
            // lblTotalAmnt
            // 
            this.lblTotalAmnt.AutoSize = true;
            this.lblTotalAmnt.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmnt.ForeColor = System.Drawing.Color.Red;
            this.lblTotalAmnt.Location = new System.Drawing.Point(712, 618);
            this.lblTotalAmnt.Name = "lblTotalAmnt";
            this.lblTotalAmnt.Size = new System.Drawing.Size(15, 14);
            this.lblTotalAmnt.TabIndex = 105;
            this.lblTotalAmnt.Text = "0";
            // 
            // lblcurrBalance
            // 
            this.lblcurrBalance.AutoSize = true;
            this.lblcurrBalance.Location = new System.Drawing.Point(662, 203);
            this.lblcurrBalance.Name = "lblcurrBalance";
            this.lblcurrBalance.Size = new System.Drawing.Size(13, 13);
            this.lblcurrBalance.TabIndex = 106;
            this.lblcurrBalance.Text = "0";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(43, 144);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(39, 23);
            this.textBox1.TabIndex = 107;
            this.textBox1.Visible = false;
            // 
            // frmSalesOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(864, 783);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmSalesOrder";
            this.Load += new System.EventHandler(this.frmSalesOrder_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uclstGrdItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dteDueDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dteDate;
        private System.Windows.Forms.TextBox uctxtLocation;
        private System.Windows.Forms.TextBox uctxtbranchName;
        private System.Windows.Forms.TextBox uctxtSalesRepresentive;
        private System.Windows.Forms.TextBox uctxtPartyName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uctxtSalesOrderNo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox uctxtRate;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox uctxtQty;
        private MayhediDataGridView DG;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox uctxtItemName;
        private System.Windows.Forms.Label lblcurrBalance;
        private System.Windows.Forms.Label lblTotalAmnt;
        private System.Windows.Forms.Label lblTotalQnty;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox uctxtOthersterms;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox uctxtValidityQuotation;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox uctxtSupportWarrenty;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox uctxtPayment;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox uctxtdelivery;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox uctxtNarration;
        private System.Windows.Forms.Label label13;
        private MayhediControlLibrary.StandardDataGridView uclstGrdItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.TextBox textBox1;
    }
}
