namespace JA.Modulecontrolar.UI.Inventory
{
    partial class frmStockRequisition
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.uctxtInvoiceNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dteDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.uctxtNarration = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblQnty = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.uclstGrdItem = new MayhediControlLibrary.StandardDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblAmount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnDown = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.uctxtQty = new System.Windows.Forms.TextBox();
            this.DG = new MayhediDataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.uctxtItemName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.uctxtRate = new System.Windows.Forms.TextBox();
            this.uctxtFromLocation = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.uctxtProcessName = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtBranch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.uctxtProcessManuQty = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uclstGrdItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).BeginInit();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(329, 6);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnGenerate);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.uctxtProcessManuQty);
            this.pnlMain.Controls.Add(this.label14);
            this.pnlMain.Controls.Add(this.txtBranch);
            this.pnlMain.Controls.Add(this.label13);
            this.pnlMain.Controls.Add(this.uctxtProcessName);
            this.pnlMain.Controls.Add(this.panel2);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.uctxtNarration);
            this.pnlMain.Controls.Add(this.uctxtFromLocation);
            this.pnlMain.Controls.Add(this.uctxtInvoiceNo);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.dteDate);
            this.pnlMain.Controls.Add(this.label9);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Size = new System.Drawing.Size(810, 636);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.textBox1);
            this.pnlTop.Controls.Add(this.uctxtRate);
            this.pnlTop.Controls.Add(this.label10);
            this.pnlTop.Size = new System.Drawing.Size(815, 58);
            this.pnlTop.Controls.SetChildIndex(this.label10, 0);
            this.pnlTop.Controls.SetChildIndex(this.uctxtRate, 0);
            this.pnlTop.Controls.SetChildIndex(this.frmLabel, 0);
            this.pnlTop.Controls.SetChildIndex(this.textBox1, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnTopClose, 0);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(6, 558);
            this.btnEdit.Size = new System.Drawing.Size(135, 39);
            this.btnEdit.Text = "List All";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(588, 553);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(288, 217);
            this.btnDelete.Size = new System.Drawing.Size(10, 11);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(266, 215);
            this.btnNew.Size = new System.Drawing.Size(10, 11);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(702, 553);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(311, 214);
            this.btnPrint.Size = new System.Drawing.Size(10, 11);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Size = new System.Drawing.Size(815, 25);
            // 
            // uctxtInvoiceNo
            // 
            this.uctxtInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtInvoiceNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtInvoiceNo.Location = new System.Drawing.Point(9, 225);
            this.uctxtInvoiceNo.Name = "uctxtInvoiceNo";
            this.uctxtInvoiceNo.Size = new System.Drawing.Size(180, 23);
            this.uctxtInvoiceNo.TabIndex = 105;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.label5.Location = new System.Drawing.Point(9, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 18);
            this.label5.TabIndex = 106;
            this.label5.Text = "Requisition No.";
            // 
            // dteDate
            // 
            this.dteDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteDate.Location = new System.Drawing.Point(9, 271);
            this.dteDate.Name = "dteDate";
            this.dteDate.Size = new System.Drawing.Size(180, 23);
            this.dteDate.TabIndex = 111;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.label9.Location = new System.Drawing.Point(9, 250);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 18);
            this.label9.TabIndex = 112;
            this.label9.Text = "Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.label1.Location = new System.Drawing.Point(392, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 18);
            this.label1.TabIndex = 108;
            this.label1.Text = "Location";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label4.Location = new System.Drawing.Point(170, 599);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 16);
            this.label4.TabIndex = 115;
            this.label4.Text = "Narration:";
            // 
            // uctxtNarration
            // 
            this.uctxtNarration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtNarration.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtNarration.Location = new System.Drawing.Point(250, 596);
            this.uctxtNarration.Name = "uctxtNarration";
            this.uctxtNarration.Size = new System.Drawing.Size(422, 23);
            this.uctxtNarration.TabIndex = 114;
            this.uctxtNarration.Text = "Narration";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblQnty);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.uclstGrdItem);
            this.panel2.Controls.Add(this.lblAmount);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.btnDown);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.uctxtQty);
            this.panel2.Controls.Add(this.DG);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.uctxtItemName);
            this.panel2.Location = new System.Drawing.Point(5, 300);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(797, 288);
            this.panel2.TabIndex = 116;
            // 
            // lblQnty
            // 
            this.lblQnty.AutoSize = true;
            this.lblQnty.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQnty.Location = new System.Drawing.Point(330, 259);
            this.lblQnty.Name = "lblQnty";
            this.lblQnty.Size = new System.Drawing.Size(15, 14);
            this.lblQnty.TabIndex = 97;
            this.lblQnty.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(205, 259);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 14);
            this.label15.TabIndex = 96;
            this.label15.Text = "Total Quantity:";
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uclstGrdItem.DefaultCellStyle = dataGridViewCellStyle4;
            this.uclstGrdItem.Location = new System.Drawing.Point(3, 56);
            this.uclstGrdItem.MultiSelect = false;
            this.uclstGrdItem.Name = "uclstGrdItem";
            this.uclstGrdItem.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.uclstGrdItem.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.uclstGrdItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.uclstGrdItem.Size = new System.Drawing.Size(652, 28);
            this.uclstGrdItem.TabIndex = 95;
            this.uclstGrdItem.Visible = false;
            // 
            // Column1
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "Item Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 600;
            // 
            // Column2
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column2.HeaderText = "Clsosing Qty";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            this.Column2.Width = 110;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(612, 259);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(15, 14);
            this.lblAmount.TabIndex = 75;
            this.lblAmount.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(488, 259);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 14);
            this.label8.TabIndex = 74;
            this.label8.Text = "Total Amount:";
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(755, 2);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(30, 23);
            this.btnDown.TabIndex = 67;
            this.btnDown.Text = ">>";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(696, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 18);
            this.label11.TabIndex = 60;
            this.label11.Text = "Qty";
            // 
            // uctxtQty
            // 
            this.uctxtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtQty.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtQty.Location = new System.Drawing.Point(654, 27);
            this.uctxtQty.Name = "uctxtQty";
            this.uctxtQty.Size = new System.Drawing.Size(135, 23);
            this.uctxtQty.TabIndex = 59;
            // 
            // DG
            // 
            this.DG.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DG.DefaultCellStyle = dataGridViewCellStyle7;
            this.DG.Location = new System.Drawing.Point(3, 53);
            this.DG.Name = "DG";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DG.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.DG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DG.Size = new System.Drawing.Size(786, 201);
            this.DG.TabIndex = 58;
            this.DG.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellContentClick);
            this.DG.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellEndEdit);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 18);
            this.label12.TabIndex = 57;
            this.label12.Text = "Name";
            // 
            // uctxtItemName
            // 
            this.uctxtItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtItemName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtItemName.Location = new System.Drawing.Point(2, 27);
            this.uctxtItemName.Name = "uctxtItemName";
            this.uctxtItemName.Size = new System.Drawing.Size(652, 23);
            this.uctxtItemName.TabIndex = 56;
            this.uctxtItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.uctxtItemName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uctxtItemName_KeyUp);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(685, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 18);
            this.label10.TabIndex = 71;
            this.label10.Text = "Rate";
            this.label10.Visible = false;
            // 
            // uctxtRate
            // 
            this.uctxtRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtRate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtRate.Location = new System.Drawing.Point(651, 6);
            this.uctxtRate.Name = "uctxtRate";
            this.uctxtRate.Size = new System.Drawing.Size(10, 23);
            this.uctxtRate.TabIndex = 70;
            this.uctxtRate.Visible = false;
            // 
            // uctxtFromLocation
            // 
            this.uctxtFromLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtFromLocation.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtFromLocation.Location = new System.Drawing.Point(392, 172);
            this.uctxtFromLocation.Name = "uctxtFromLocation";
            this.uctxtFromLocation.Size = new System.Drawing.Size(377, 23);
            this.uctxtFromLocation.TabIndex = 107;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.label13.Location = new System.Drawing.Point(392, 200);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(115, 18);
            this.label13.TabIndex = 118;
            this.label13.Text = "Process Name";
            // 
            // uctxtProcessName
            // 
            this.uctxtProcessName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtProcessName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtProcessName.Location = new System.Drawing.Point(392, 225);
            this.uctxtProcessName.Name = "uctxtProcessName";
            this.uctxtProcessName.Size = new System.Drawing.Size(377, 23);
            this.uctxtProcessName.TabIndex = 117;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(733, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(37, 23);
            this.textBox1.TabIndex = 119;
            this.textBox1.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(9, 152);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 18);
            this.label14.TabIndex = 121;
            this.label14.Text = "Branch";
            // 
            // txtBranch
            // 
            this.txtBranch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBranch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBranch.Location = new System.Drawing.Point(9, 172);
            this.txtBranch.Name = "txtBranch";
            this.txtBranch.Size = new System.Drawing.Size(352, 23);
            this.txtBranch.TabIndex = 120;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.label3.Location = new System.Drawing.Point(392, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 18);
            this.label3.TabIndex = 123;
            this.label3.Text = "Process Qnty.";
            // 
            // uctxtProcessManuQty
            // 
            this.uctxtProcessManuQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtProcessManuQty.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtProcessManuQty.Location = new System.Drawing.Point(392, 273);
            this.uctxtProcessManuQty.Name = "uctxtProcessManuQty";
            this.uctxtProcessManuQty.Size = new System.Drawing.Size(115, 23);
            this.uctxtProcessManuQty.TabIndex = 122;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.Location = new System.Drawing.Point(509, 272);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 24);
            this.btnGenerate.TabIndex = 124;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // frmStockRequisition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(815, 623);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmStockRequisition";
            this.Load += new System.EventHandler(this.frmStockDamage_Load);
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

        private System.Windows.Forms.TextBox uctxtInvoiceNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dteDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox uctxtNarration;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox uctxtRate;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox uctxtQty;
        private MayhediDataGridView DG;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox uctxtItemName;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox uctxtFromLocation;
        private MayhediControlLibrary.StandardDataGridView uclstGrdItem;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox uctxtProcessName;
        private System.Windows.Forms.Label lblQnty;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtBranch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uctxtProcessManuQty;
    }
}
