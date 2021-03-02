namespace JA.Modulecontrolar.UI.DReport.Purchase.ParameterForms
{
    partial class frmRptVoucherReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtnSalesSamp = new System.Windows.Forms.RadioButton();
            this.rbtnPurchaseReturn = new System.Windows.Forms.RadioButton();
            this.rbtnPurchaseInv = new System.Windows.Forms.RadioButton();
            this.rbtnReceiveInv = new System.Windows.Forms.RadioButton();
            this.rbtnSalesChalan = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbtbIndividualVouNo = new System.Windows.Forms.RadioButton();
            this.rbtnIndividualParty = new System.Windows.Forms.RadioButton();
            this.rbtnAll = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rbtnSummary = new System.Windows.Forms.RadioButton();
            this.rbtnDetail = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rbtnPenSummary = new System.Windows.Forms.RadioButton();
            this.rbtnPenDetail = new System.Windows.Forms.RadioButton();
            this.rbtnPending = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dteToDate = new System.Windows.Forms.DateTimePicker();
            this.dteFromDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.chkboxNarration = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.uctxtTerritoryCode = new System.Windows.Forms.TextBox();
            this.DGMr = new MayhediControlLibrary.StandardDataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uctxtTeritorryName = new System.Windows.Forms.TextBox();
            this.uctxtMrName = new System.Windows.Forms.TextBox();
            this.radSalesOrder = new System.Windows.Forms.RadioButton();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGMr)).BeginInit();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(173, 9);
            this.frmLabel.Size = new System.Drawing.Size(0, 33);
            this.frmLabel.Text = "";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.uctxtTerritoryCode);
            this.pnlMain.Controls.Add(this.DGMr);
            this.pnlMain.Controls.Add(this.uctxtTeritorryName);
            this.pnlMain.Controls.Add(this.uctxtMrName);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.chkboxNarration);
            this.pnlMain.Controls.Add(this.groupBox6);
            this.pnlMain.Controls.Add(this.groupBox5);
            this.pnlMain.Controls.Add(this.groupBox4);
            this.pnlMain.Controls.Add(this.groupBox3);
            this.pnlMain.Controls.Add(this.groupBox2);
            this.pnlMain.Location = new System.Drawing.Point(0, -86);
            this.pnlMain.Size = new System.Drawing.Size(681, 534);
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.label5);
            this.pnlTop.Size = new System.Drawing.Size(685, 58);
            this.pnlTop.Controls.SetChildIndex(this.frmLabel, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnTopClose, 0);
            this.pnlTop.Controls.SetChildIndex(this.label5, 0);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(130, 336);
            this.btnEdit.Size = new System.Drawing.Size(10, 13);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 336);
            this.btnSave.Size = new System.Drawing.Size(10, 13);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(146, 336);
            this.btnDelete.Size = new System.Drawing.Size(10, 13);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(28, 336);
            this.btnNew.Size = new System.Drawing.Size(10, 13);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(573, 450);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(436, 450);
            this.btnPrint.Size = new System.Drawing.Size(131, 39);
            this.btnPrint.Text = "Preview";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 489);
            this.groupBox1.Size = new System.Drawing.Size(685, 22);
            this.groupBox1.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radSalesOrder);
            this.groupBox2.Controls.Add(this.rbtnSalesSamp);
            this.groupBox2.Controls.Add(this.rbtnPurchaseReturn);
            this.groupBox2.Controls.Add(this.rbtnPurchaseInv);
            this.groupBox2.Controls.Add(this.rbtnReceiveInv);
            this.groupBox2.Controls.Add(this.rbtnSalesChalan);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(6, 149);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(669, 66);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // rbtnSalesSamp
            // 
            this.rbtnSalesSamp.AutoSize = true;
            this.rbtnSalesSamp.Checked = true;
            this.rbtnSalesSamp.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnSalesSamp.Location = new System.Drawing.Point(542, 19);
            this.rbtnSalesSamp.Name = "rbtnSalesSamp";
            this.rbtnSalesSamp.Size = new System.Drawing.Size(119, 21);
            this.rbtnSalesSamp.TabIndex = 6;
            this.rbtnSalesSamp.TabStop = true;
            this.rbtnSalesSamp.Text = "Sales Sample";
            this.rbtnSalesSamp.UseVisualStyleBackColor = true;
            this.rbtnSalesSamp.Click += new System.EventHandler(this.rbtnPurchaseRequisition_Click);
            // 
            // rbtnPurchaseReturn
            // 
            this.rbtnPurchaseReturn.AutoSize = true;
            this.rbtnPurchaseReturn.Checked = true;
            this.rbtnPurchaseReturn.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPurchaseReturn.Location = new System.Drawing.Point(285, 18);
            this.rbtnPurchaseReturn.Name = "rbtnPurchaseReturn";
            this.rbtnPurchaseReturn.Size = new System.Drawing.Size(142, 21);
            this.rbtnPurchaseReturn.TabIndex = 5;
            this.rbtnPurchaseReturn.TabStop = true;
            this.rbtnPurchaseReturn.Text = "Purchase Return";
            this.rbtnPurchaseReturn.UseVisualStyleBackColor = true;
            this.rbtnPurchaseReturn.Click += new System.EventHandler(this.rbtnPurchaseReturn_Click);
            // 
            // rbtnPurchaseInv
            // 
            this.rbtnPurchaseInv.AutoSize = true;
            this.rbtnPurchaseInv.Checked = true;
            this.rbtnPurchaseInv.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPurchaseInv.Location = new System.Drawing.Point(10, 19);
            this.rbtnPurchaseInv.Name = "rbtnPurchaseInv";
            this.rbtnPurchaseInv.Size = new System.Drawing.Size(143, 21);
            this.rbtnPurchaseInv.TabIndex = 4;
            this.rbtnPurchaseInv.TabStop = true;
            this.rbtnPurchaseInv.Text = "Purchase Invoice";
            this.rbtnPurchaseInv.UseVisualStyleBackColor = true;
            this.rbtnPurchaseInv.Click += new System.EventHandler(this.rbtnPurchaseInv_Click);
            // 
            // rbtnReceiveInv
            // 
            this.rbtnReceiveInv.AutoSize = true;
            this.rbtnReceiveInv.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnReceiveInv.Location = new System.Drawing.Point(216, 45);
            this.rbtnReceiveInv.Name = "rbtnReceiveInv";
            this.rbtnReceiveInv.Size = new System.Drawing.Size(151, 21);
            this.rbtnReceiveInv.TabIndex = 3;
            this.rbtnReceiveInv.Text = "Receive Inventory";
            this.rbtnReceiveInv.UseVisualStyleBackColor = true;
            this.rbtnReceiveInv.Visible = false;
            this.rbtnReceiveInv.Click += new System.EventHandler(this.rbtnReceiveInv_Click);
            // 
            // rbtnSalesChalan
            // 
            this.rbtnSalesChalan.AutoSize = true;
            this.rbtnSalesChalan.Checked = true;
            this.rbtnSalesChalan.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnSalesChalan.Location = new System.Drawing.Point(157, 18);
            this.rbtnSalesChalan.Name = "rbtnSalesChalan";
            this.rbtnSalesChalan.Size = new System.Drawing.Size(115, 21);
            this.rbtnSalesChalan.TabIndex = 2;
            this.rbtnSalesChalan.TabStop = true;
            this.rbtnSalesChalan.Text = "Sales Chalan";
            this.rbtnSalesChalan.UseVisualStyleBackColor = true;
            this.rbtnSalesChalan.Click += new System.EventHandler(this.rbtnPurchaseOrder_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbtbIndividualVouNo);
            this.groupBox3.Controls.Add(this.rbtnIndividualParty);
            this.groupBox3.Controls.Add(this.rbtnAll);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(6, 217);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(201, 108);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            // 
            // rbtbIndividualVouNo
            // 
            this.rbtbIndividualVouNo.AutoSize = true;
            this.rbtbIndividualVouNo.Checked = true;
            this.rbtbIndividualVouNo.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtbIndividualVouNo.Location = new System.Drawing.Point(16, 73);
            this.rbtbIndividualVouNo.Name = "rbtbIndividualVouNo";
            this.rbtbIndividualVouNo.Size = new System.Drawing.Size(183, 21);
            this.rbtbIndividualVouNo.TabIndex = 5;
            this.rbtbIndividualVouNo.TabStop = true;
            this.rbtbIndividualVouNo.Text = "Individual Voucher No.";
            this.rbtbIndividualVouNo.UseVisualStyleBackColor = true;
            this.rbtbIndividualVouNo.Click += new System.EventHandler(this.rbtbIndividualVouNo_Click);
            // 
            // rbtnIndividualParty
            // 
            this.rbtnIndividualParty.AutoSize = true;
            this.rbtnIndividualParty.Checked = true;
            this.rbtnIndividualParty.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnIndividualParty.Location = new System.Drawing.Point(16, 46);
            this.rbtnIndividualParty.Name = "rbtnIndividualParty";
            this.rbtnIndividualParty.Size = new System.Drawing.Size(154, 21);
            this.rbtnIndividualParty.TabIndex = 4;
            this.rbtnIndividualParty.TabStop = true;
            this.rbtnIndividualParty.Text = "Individual Supplier";
            this.rbtnIndividualParty.UseVisualStyleBackColor = true;
            this.rbtnIndividualParty.Click += new System.EventHandler(this.rbtnIndividualParty_Click);
            // 
            // rbtnAll
            // 
            this.rbtnAll.AutoSize = true;
            this.rbtnAll.Checked = true;
            this.rbtnAll.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnAll.Location = new System.Drawing.Point(16, 19);
            this.rbtnAll.Name = "rbtnAll";
            this.rbtnAll.Size = new System.Drawing.Size(42, 21);
            this.rbtnAll.TabIndex = 2;
            this.rbtnAll.TabStop = true;
            this.rbtnAll.Text = "All";
            this.rbtnAll.UseVisualStyleBackColor = true;
            this.rbtnAll.Click += new System.EventHandler(this.rbtnAll_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rbtnSummary);
            this.groupBox5.Controls.Add(this.rbtnDetail);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(508, 217);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(167, 62);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            // 
            // rbtnSummary
            // 
            this.rbtnSummary.AutoSize = true;
            this.rbtnSummary.Checked = true;
            this.rbtnSummary.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnSummary.Location = new System.Drawing.Point(16, 34);
            this.rbtnSummary.Name = "rbtnSummary";
            this.rbtnSummary.Size = new System.Drawing.Size(93, 21);
            this.rbtnSummary.TabIndex = 4;
            this.rbtnSummary.TabStop = true;
            this.rbtnSummary.Text = "Summary";
            this.rbtnSummary.UseVisualStyleBackColor = true;
            // 
            // rbtnDetail
            // 
            this.rbtnDetail.AutoSize = true;
            this.rbtnDetail.Checked = true;
            this.rbtnDetail.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnDetail.Location = new System.Drawing.Point(16, 7);
            this.rbtnDetail.Name = "rbtnDetail";
            this.rbtnDetail.Size = new System.Drawing.Size(65, 21);
            this.rbtnDetail.TabIndex = 2;
            this.rbtnDetail.TabStop = true;
            this.rbtnDetail.Text = "Detail";
            this.rbtnDetail.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rbtnPenSummary);
            this.groupBox6.Controls.Add(this.rbtnPenDetail);
            this.groupBox6.Controls.Add(this.rbtnPending);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(508, 278);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(167, 47);
            this.groupBox6.TabIndex = 12;
            this.groupBox6.TabStop = false;
            // 
            // rbtnPenSummary
            // 
            this.rbtnPenSummary.AutoSize = true;
            this.rbtnPenSummary.Checked = true;
            this.rbtnPenSummary.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPenSummary.Location = new System.Drawing.Point(32, 59);
            this.rbtnPenSummary.Name = "rbtnPenSummary";
            this.rbtnPenSummary.Size = new System.Drawing.Size(93, 21);
            this.rbtnPenSummary.TabIndex = 5;
            this.rbtnPenSummary.TabStop = true;
            this.rbtnPenSummary.Text = "Summary";
            this.rbtnPenSummary.UseVisualStyleBackColor = true;
            // 
            // rbtnPenDetail
            // 
            this.rbtnPenDetail.AutoSize = true;
            this.rbtnPenDetail.Checked = true;
            this.rbtnPenDetail.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPenDetail.Location = new System.Drawing.Point(32, 32);
            this.rbtnPenDetail.Name = "rbtnPenDetail";
            this.rbtnPenDetail.Size = new System.Drawing.Size(65, 21);
            this.rbtnPenDetail.TabIndex = 4;
            this.rbtnPenDetail.TabStop = true;
            this.rbtnPenDetail.Text = "Detail";
            this.rbtnPenDetail.UseVisualStyleBackColor = true;
            // 
            // rbtnPending
            // 
            this.rbtnPending.AutoSize = true;
            this.rbtnPending.Checked = true;
            this.rbtnPending.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPending.Location = new System.Drawing.Point(16, 7);
            this.rbtnPending.Name = "rbtnPending";
            this.rbtnPending.Size = new System.Drawing.Size(81, 21);
            this.rbtnPending.TabIndex = 2;
            this.rbtnPending.TabStop = true;
            this.rbtnPending.Text = "Pending";
            this.rbtnPending.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.dteToDate);
            this.groupBox4.Controls.Add(this.dteFromDate);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(213, 217);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(289, 108);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 10F);
            this.label3.Location = new System.Drawing.Point(6, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "To Date :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 10F);
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "From Date :";
            // 
            // dteToDate
            // 
            this.dteToDate.Font = new System.Drawing.Font("Verdana", 11F);
            this.dteToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteToDate.Location = new System.Drawing.Point(105, 57);
            this.dteToDate.Name = "dteToDate";
            this.dteToDate.Size = new System.Drawing.Size(178, 25);
            this.dteToDate.TabIndex = 13;
            // 
            // dteFromDate
            // 
            this.dteFromDate.Font = new System.Drawing.Font("Verdana", 11F);
            this.dteFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteFromDate.Location = new System.Drawing.Point(105, 26);
            this.dteFromDate.Name = "dteFromDate";
            this.dteFromDate.Size = new System.Drawing.Size(178, 25);
            this.dteFromDate.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 20.25F);
            this.label5.Location = new System.Drawing.Point(179, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(356, 32);
            this.label5.TabIndex = 16;
            this.label5.Text = "Purchase Voucher Report";
            // 
            // chkboxNarration
            // 
            this.chkboxNarration.AutoSize = true;
            this.chkboxNarration.Font = new System.Drawing.Font("Verdana", 10F);
            this.chkboxNarration.Location = new System.Drawing.Point(79, 487);
            this.chkboxNarration.Name = "chkboxNarration";
            this.chkboxNarration.Size = new System.Drawing.Size(92, 21);
            this.chkboxNarration.TabIndex = 15;
            this.chkboxNarration.Text = "Narration";
            this.chkboxNarration.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 10F);
            this.label4.Location = new System.Drawing.Point(8, 328);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 17);
            this.label4.TabIndex = 214;
            this.label4.Text = "Party Name :";
            // 
            // uctxtTerritoryCode
            // 
            this.uctxtTerritoryCode.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtTerritoryCode.Location = new System.Drawing.Point(251, 494);
            this.uctxtTerritoryCode.Name = "uctxtTerritoryCode";
            this.uctxtTerritoryCode.Size = new System.Drawing.Size(110, 22);
            this.uctxtTerritoryCode.TabIndex = 215;
            this.uctxtTerritoryCode.Visible = false;
            // 
            // DGMr
            // 
            this.DGMr.AllowUserToAddRows = false;
            this.DGMr.AllowUserToDeleteRows = false;
            this.DGMr.AllowUserToOrderColumns = true;
            this.DGMr.AllowUserToResizeColumns = false;
            this.DGMr.AllowUserToResizeRows = false;
            this.DGMr.BackgroundColor = System.Drawing.Color.White;
            this.DGMr.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGMr.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGMr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGMr.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGMr.DefaultCellStyle = dataGridViewCellStyle5;
            this.DGMr.Location = new System.Drawing.Point(11, 376);
            this.DGMr.MultiSelect = false;
            this.DGMr.Name = "DGMr";
            this.DGMr.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            this.DGMr.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DGMr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGMr.Size = new System.Drawing.Size(555, 23);
            this.DGMr.TabIndex = 218;
            this.DGMr.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn6.HeaderText = "Teritorry Code";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn13.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn13.HeaderText = "Teritorry name";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 180;
            // 
            // dataGridViewTextBoxColumn14
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn14.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn14.HeaderText = "MPO Name";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 250;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.HeaderText = "String";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Visible = false;
            // 
            // uctxtTeritorryName
            // 
            this.uctxtTeritorryName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtTeritorryName.Location = new System.Drawing.Point(367, 494);
            this.uctxtTeritorryName.Name = "uctxtTeritorryName";
            this.uctxtTeritorryName.Size = new System.Drawing.Size(94, 22);
            this.uctxtTeritorryName.TabIndex = 216;
            this.uctxtTeritorryName.Visible = false;
            // 
            // uctxtMrName
            // 
            this.uctxtMrName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtMrName.Location = new System.Drawing.Point(11, 348);
            this.uctxtMrName.Name = "uctxtMrName";
            this.uctxtMrName.Size = new System.Drawing.Size(555, 22);
            this.uctxtMrName.TabIndex = 217;
            // 
            // radSalesOrder
            // 
            this.radSalesOrder.AutoSize = true;
            this.radSalesOrder.Checked = true;
            this.radSalesOrder.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSalesOrder.Location = new System.Drawing.Point(430, 19);
            this.radSalesOrder.Name = "radSalesOrder";
            this.radSalesOrder.Size = new System.Drawing.Size(108, 21);
            this.radSalesOrder.TabIndex = 7;
            this.radSalesOrder.TabStop = true;
            this.radSalesOrder.Text = "Sales Order";
            this.radSalesOrder.UseVisualStyleBackColor = true;
            // 
            // frmRptVoucherReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(685, 511);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmRptVoucherReport";
            this.Load += new System.EventHandler(this.frmRptStoreLedger_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGMr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rbtnPenDetail;
        private System.Windows.Forms.RadioButton rbtnPending;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rbtnSummary;
        private System.Windows.Forms.RadioButton rbtnDetail;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbtbIndividualVouNo;
        private System.Windows.Forms.RadioButton rbtnIndividualParty;
        private System.Windows.Forms.RadioButton rbtnAll;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtnSalesSamp;
        private System.Windows.Forms.RadioButton rbtnPurchaseReturn;
        private System.Windows.Forms.RadioButton rbtnPurchaseInv;
        private System.Windows.Forms.RadioButton rbtnReceiveInv;
        private System.Windows.Forms.RadioButton rbtnSalesChalan;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dteToDate;
        private System.Windows.Forms.DateTimePicker dteFromDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbtnPenSummary;
        private System.Windows.Forms.CheckBox chkboxNarration;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox uctxtTerritoryCode;
        private MayhediControlLibrary.StandardDataGridView DGMr;
        private System.Windows.Forms.TextBox uctxtTeritorryName;
        private System.Windows.Forms.TextBox uctxtMrName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.RadioButton radSalesOrder;

    }
}
