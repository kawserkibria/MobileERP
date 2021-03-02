namespace JA.Modulecontrolar.UI.Inventory
{
    partial class frmStationery
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStationery));
            this.label5 = new System.Windows.Forms.Label();
            this.uctxtInvoiceNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.uctxtBranchName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.uctxtFromLocation = new System.Windows.Forms.TextBox();
            this.dteDate = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblQty = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblnetAmount = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.uclstGrdItem = new MayhediControlLibrary.StandardDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDown = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.uctxtQty = new System.Windows.Forms.TextBox();
            this.DG = new MayhediDataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.uctxtItemName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.uctxtNarration = new System.Windows.Forms.TextBox();
            this.txtRefNo = new System.Windows.Forms.TextBox();
            this.lblRepackingFG = new System.Windows.Forms.Label();
            this.uctxtToLocation = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.uctxtRate = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uclstGrdItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).BeginInit();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(328, 4);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.uctxtRate);
            this.pnlMain.Controls.Add(this.lblRepackingFG);
            this.pnlMain.Controls.Add(this.uctxtToLocation);
            this.pnlMain.Controls.Add(this.label13);
            this.pnlMain.Controls.Add(this.uctxtNarration);
            this.pnlMain.Controls.Add(this.panel2);
            this.pnlMain.Controls.Add(this.dteDate);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.uctxtFromLocation);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.uctxtBranchName);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.uctxtInvoiceNo);
            this.pnlMain.Size = new System.Drawing.Size(886, 601);
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.txtRefNo);
            this.pnlTop.Size = new System.Drawing.Size(890, 46);
            this.pnlTop.Controls.SetChildIndex(this.frmLabel, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnTopClose, 0);
            this.pnlTop.Controls.SetChildIndex(this.txtRefNo, 0);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(0, 516);
            this.btnEdit.Size = new System.Drawing.Size(119, 39);
            this.btnEdit.Text = "List All";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(664, 516);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(611, 491);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(90, 515);
            this.btnNew.Size = new System.Drawing.Size(11, 13);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(778, 516);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(722, 491);
            this.btnPrint.Size = new System.Drawing.Size(10, 10);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 561);
            this.groupBox1.Size = new System.Drawing.Size(890, 25);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(206, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 16);
            this.label5.TabIndex = 50;
            this.label5.Text = "Voucher No:";
            // 
            // uctxtInvoiceNo
            // 
            this.uctxtInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtInvoiceNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtInvoiceNo.Location = new System.Drawing.Point(298, 139);
            this.uctxtInvoiceNo.Name = "uctxtInvoiceNo";
            this.uctxtInvoiceNo.Size = new System.Drawing.Size(173, 23);
            this.uctxtInvoiceNo.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(192, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 16);
            this.label1.TabIndex = 52;
            this.label1.Text = "Voucher Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(195, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 54;
            this.label3.Text = "Branch Name:";
            // 
            // uctxtBranchName
            // 
            this.uctxtBranchName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtBranchName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtBranchName.Location = new System.Drawing.Point(298, 187);
            this.uctxtBranchName.Name = "uctxtBranchName";
            this.uctxtBranchName.Size = new System.Drawing.Size(377, 23);
            this.uctxtBranchName.TabIndex = 53;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(147, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 16);
            this.label4.TabIndex = 56;
            this.label4.Text = "From Location Name:";
            // 
            // uctxtFromLocation
            // 
            this.uctxtFromLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtFromLocation.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtFromLocation.Location = new System.Drawing.Point(298, 211);
            this.uctxtFromLocation.Name = "uctxtFromLocation";
            this.uctxtFromLocation.Size = new System.Drawing.Size(377, 23);
            this.uctxtFromLocation.TabIndex = 55;
            // 
            // dteDate
            // 
            this.dteDate.Enabled = false;
            this.dteDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteDate.Location = new System.Drawing.Point(298, 163);
            this.dteDate.Name = "dteDate";
            this.dteDate.Size = new System.Drawing.Size(173, 23);
            this.dteDate.TabIndex = 88;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblQty);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.lblnetAmount);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.uclstGrdItem);
            this.panel2.Controls.Add(this.btnDown);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.uctxtQty);
            this.panel2.Controls.Add(this.DG);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.uctxtItemName);
            this.panel2.Location = new System.Drawing.Point(3, 273);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(877, 281);
            this.panel2.TabIndex = 89;
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty.Location = new System.Drawing.Point(428, 252);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(17, 16);
            this.lblQty.TabIndex = 99;
            this.lblQty.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(314, 251);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(109, 16);
            this.label17.TabIndex = 98;
            this.label17.Text = "Total Quantity:";
            // 
            // lblnetAmount
            // 
            this.lblnetAmount.AutoSize = true;
            this.lblnetAmount.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnetAmount.Location = new System.Drawing.Point(680, 252);
            this.lblnetAmount.Name = "lblnetAmount";
            this.lblnetAmount.Size = new System.Drawing.Size(17, 16);
            this.lblnetAmount.TabIndex = 97;
            this.lblnetAmount.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(566, 252);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(102, 16);
            this.label15.TabIndex = 96;
            this.label15.Text = "Total Amount:";
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
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.uclstGrdItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.uclstGrdItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uclstGrdItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uclstGrdItem.DefaultCellStyle = dataGridViewCellStyle12;
            this.uclstGrdItem.Location = new System.Drawing.Point(2, 51);
            this.uclstGrdItem.MultiSelect = false;
            this.uclstGrdItem.Name = "uclstGrdItem";
            this.uclstGrdItem.RowHeadersVisible = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            this.uclstGrdItem.RowsDefaultCellStyle = dataGridViewCellStyle13;
            this.uclstGrdItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.uclstGrdItem.Size = new System.Drawing.Size(676, 28);
            this.uclstGrdItem.TabIndex = 93;
            this.uclstGrdItem.Visible = false;
            // 
            // Column1
            // 
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle10;
            this.Column1.HeaderText = "Item Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 500;
            // 
            // Column2
            // 
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column2.DefaultCellStyle = dataGridViewCellStyle11;
            this.Column2.HeaderText = "Closing Qty";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(815, 23);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(30, 23);
            this.btnDown.TabIndex = 67;
            this.btnDown.Text = ">>";
            this.btnDown.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(680, 3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 18);
            this.label11.TabIndex = 60;
            this.label11.Text = "Qty";
            // 
            // uctxtQty
            // 
            this.uctxtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtQty.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtQty.Location = new System.Drawing.Point(678, 24);
            this.uctxtQty.Name = "uctxtQty";
            this.uctxtQty.Size = new System.Drawing.Size(135, 23);
            this.uctxtQty.TabIndex = 59;
            // 
            // DG
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DG.DefaultCellStyle = dataGridViewCellStyle15;
            this.DG.Location = new System.Drawing.Point(3, 49);
            this.DG.Name = "DG";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DG.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.DG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DG.Size = new System.Drawing.Size(868, 191);
            this.DG.TabIndex = 58;
            this.DG.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellContentClick);
            this.DG.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellEndEdit);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 18);
            this.label12.TabIndex = 57;
            this.label12.Text = "Item Name:";
            // 
            // uctxtItemName
            // 
            this.uctxtItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtItemName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtItemName.Location = new System.Drawing.Point(2, 24);
            this.uctxtItemName.Name = "uctxtItemName";
            this.uctxtItemName.Size = new System.Drawing.Size(676, 23);
            this.uctxtItemName.TabIndex = 56;
            this.uctxtItemName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uctxtItemName_KeyUp);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(114, 566);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 16);
            this.label13.TabIndex = 91;
            this.label13.Text = "Narration:";
            // 
            // uctxtNarration
            // 
            this.uctxtNarration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtNarration.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtNarration.Location = new System.Drawing.Point(195, 563);
            this.uctxtNarration.Name = "uctxtNarration";
            this.uctxtNarration.Size = new System.Drawing.Size(377, 23);
            this.uctxtNarration.TabIndex = 90;
            // 
            // txtRefNo
            // 
            this.txtRefNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRefNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefNo.Location = new System.Drawing.Point(57, 12);
            this.txtRefNo.Name = "txtRefNo";
            this.txtRefNo.Size = new System.Drawing.Size(78, 23);
            this.txtRefNo.TabIndex = 50;
            this.txtRefNo.Visible = false;
            // 
            // lblRepackingFG
            // 
            this.lblRepackingFG.AutoSize = true;
            this.lblRepackingFG.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRepackingFG.Location = new System.Drawing.Point(163, 238);
            this.lblRepackingFG.Name = "lblRepackingFG";
            this.lblRepackingFG.Size = new System.Drawing.Size(132, 16);
            this.lblRepackingFG.TabIndex = 96;
            this.lblRepackingFG.Text = "To Location Name:";
            // 
            // uctxtToLocation
            // 
            this.uctxtToLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtToLocation.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtToLocation.Location = new System.Drawing.Point(298, 236);
            this.uctxtToLocation.Name = "uctxtToLocation";
            this.uctxtToLocation.Size = new System.Drawing.Size(377, 23);
            this.uctxtToLocation.TabIndex = 95;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-search-48.png");
            // 
            // uctxtRate
            // 
            this.uctxtRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtRate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtRate.Location = new System.Drawing.Point(621, 137);
            this.uctxtRate.Name = "uctxtRate";
            this.uctxtRate.Size = new System.Drawing.Size(173, 23);
            this.uctxtRate.TabIndex = 97;
            this.uctxtRate.Visible = false;
            // 
            // frmStationery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(890, 586);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmStationery";
            this.Load += new System.EventHandler(this.frmStationery_Load);
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

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox uctxtFromLocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uctxtBranchName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox uctxtInvoiceNo;
        private System.Windows.Forms.DateTimePicker dteDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox uctxtNarration;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox uctxtQty;
        private MayhediDataGridView DG;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox uctxtItemName;
        private System.Windows.Forms.TextBox txtRefNo;
        private MayhediControlLibrary.StandardDataGridView uclstGrdItem;
        private System.Windows.Forms.Label lblnetAmount;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblRepackingFG;
        private System.Windows.Forms.TextBox uctxtToLocation;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.TextBox uctxtRate;

    }
}
