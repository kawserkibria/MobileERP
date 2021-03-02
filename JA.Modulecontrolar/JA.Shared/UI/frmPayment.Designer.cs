namespace AH.Shared.UI
{
    partial class frmPayment
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
            this.txtAmount = new AtiqsControlLibrary.SmartNumericTextBox();
            this.smartLabel1 = new AtiqsControlLibrary.SmartLabel();
            this.txtPateintNo = new System.Windows.Forms.TextBox();
            this.smartLabel2 = new AtiqsControlLibrary.SmartLabel();
            this.smartLabel3 = new AtiqsControlLibrary.SmartLabel();
            this.smartLabel4 = new AtiqsControlLibrary.SmartLabel();
            this.smartLabel5 = new AtiqsControlLibrary.SmartLabel();
            this.txtVATAmount = new AtiqsControlLibrary.SmartNumericTextBox();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.smartLabel6 = new AtiqsControlLibrary.SmartLabel();
            this.txtTotalPayableAmount = new AtiqsControlLibrary.SmartTextBox();
            this.txtDiscountPercentage = new AtiqsControlLibrary.SmartNumericTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVATPercentage = new AtiqsControlLibrary.SmartNumericTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbPayment = new AtiqsControlLibrary.SmartTab();
            this.pgCash = new System.Windows.Forms.TabPage();
            this.txtOthersRemarks = new System.Windows.Forms.TextBox();
            this.smartLabel25 = new AtiqsControlLibrary.SmartLabel();
            this.txtOthersAmount = new AtiqsControlLibrary.SmartNumericTextBoxColorful();
            this.smartLabel17 = new AtiqsControlLibrary.SmartLabel();
            this.smartLabel23 = new AtiqsControlLibrary.SmartLabel();
            this.cboBankName = new AtiqsControlLibrary.SmartComboBox();
            this.txtChequeAmount = new AtiqsControlLibrary.SmartNumericTextBoxColorful();
            this.txtChequeNo = new AtiqsControlLibrary.SmartNumericTextBoxColorful();
            this.smartLabel22 = new AtiqsControlLibrary.SmartLabel();
            this.smartLabel21 = new AtiqsControlLibrary.SmartLabel();
            this.smartLabel18 = new AtiqsControlLibrary.SmartLabel();
            this.smartLabel20 = new AtiqsControlLibrary.SmartLabel();
            this.smartLabel7 = new AtiqsControlLibrary.SmartLabel();
            this.txtDiscNote = new System.Windows.Forms.TextBox();
            this.cboCardTypeDebit = new AtiqsControlLibrary.SmartComboBox();
            this.txtLastDigitDebitCard = new AtiqsControlLibrary.SmartNumericTextBoxColorful();
            this.cboBNKDebitCard = new AtiqsControlLibrary.SmartComboBox();
            this.txtDebitAmount = new AtiqsControlLibrary.SmartNumericTextBoxColorful();
            this.txtCash = new AtiqsControlLibrary.SmartNumericTextBoxColorful();
            this.txtChange = new System.Windows.Forms.TextBox();
            this.smartLabel14 = new AtiqsControlLibrary.SmartLabel();
            this.smartLabel15 = new AtiqsControlLibrary.SmartLabel();
            this.lblChange = new AtiqsControlLibrary.SmartLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnExact = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnBSpace = new System.Windows.Forms.Button();
            this.btnN100 = new System.Windows.Forms.Button();
            this.btnN5000 = new System.Windows.Forms.Button();
            this.btn1000 = new System.Windows.Forms.Button();
            this.btn500 = new System.Windows.Forms.Button();
            this.btnN00 = new System.Windows.Forms.Button();
            this.smartLabel11 = new AtiqsControlLibrary.SmartLabel();
            this.txtCashAmount = new AtiqsControlLibrary.SmartNumericTextBox();
            this.smartLabel13 = new AtiqsControlLibrary.SmartLabel();
            this.smartLabel24 = new AtiqsControlLibrary.SmartLabel();
            this.cboCardTypeCredit = new AtiqsControlLibrary.SmartComboBox();
            this.smartLabel19 = new AtiqsControlLibrary.SmartLabel();
            this.smartLabel16 = new AtiqsControlLibrary.SmartLabel();
            this.txtLastDigitCreditCard = new AtiqsControlLibrary.SmartNumericTextBoxColorful();
            this.cboBNKNameCreditCard = new AtiqsControlLibrary.SmartComboBox();
            this.txtCreditAmount = new AtiqsControlLibrary.SmartNumericTextBoxColorful();
            this.smartLabel12 = new AtiqsControlLibrary.SmartLabel();
            this.smartLabel8 = new AtiqsControlLibrary.SmartLabel();
            this.txtAdvancePaid = new AtiqsControlLibrary.SmartTextBox();
            this.smartLabel9 = new AtiqsControlLibrary.SmartLabel();
            this.txtNetPayableAmount = new AtiqsControlLibrary.SmartTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtDiscountAmount = new AtiqsControlLibrary.SmartNumericTextBox();
            this.smartLabel10 = new AtiqsControlLibrary.SmartLabel();
            this.txtPayableAmount = new AtiqsControlLibrary.SmartTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtPreviousDue = new AtiqsControlLibrary.SmartNumericTextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.tbPayment.SuspendLayout();
            this.pgCash.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTopClose
            // 
            this.btnTopClose.BackColor = System.Drawing.Color.Transparent;
            this.btnTopClose.Location = new System.Drawing.Point(638, 2);
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(219, 3);
            this.frmLabel.Size = new System.Drawing.Size(231, 33);
            this.frmLabel.Text = "Patient Card Issue";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.smartLabel24);
            this.pnlMain.Controls.Add(this.panel6);
            this.pnlMain.Controls.Add(this.panel5);
            this.pnlMain.Controls.Add(this.panel4);
            this.pnlMain.Controls.Add(this.txtPreviousDue);
            this.pnlMain.Controls.Add(this.cboCardTypeCredit);
            this.pnlMain.Controls.Add(this.panel3);
            this.pnlMain.Controls.Add(this.smartLabel10);
            this.pnlMain.Controls.Add(this.smartLabel19);
            this.pnlMain.Controls.Add(this.txtPayableAmount);
            this.pnlMain.Controls.Add(this.txtDiscountAmount);
            this.pnlMain.Controls.Add(this.smartLabel16);
            this.pnlMain.Controls.Add(this.txtLastDigitCreditCard);
            this.pnlMain.Controls.Add(this.panel2);
            this.pnlMain.Controls.Add(this.cboBNKNameCreditCard);
            this.pnlMain.Controls.Add(this.smartLabel8);
            this.pnlMain.Controls.Add(this.txtAdvancePaid);
            this.pnlMain.Controls.Add(this.txtCreditAmount);
            this.pnlMain.Controls.Add(this.smartLabel12);
            this.pnlMain.Controls.Add(this.groupBox2);
            this.pnlMain.Controls.Add(this.panel1);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.txtVATPercentage);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.txtDiscountPercentage);
            this.pnlMain.Controls.Add(this.smartLabel6);
            this.pnlMain.Controls.Add(this.txtTotalPayableAmount);
            this.pnlMain.Controls.Add(this.smartLabel5);
            this.pnlMain.Controls.Add(this.txtVATAmount);
            this.pnlMain.Controls.Add(this.smartLabel4);
            this.pnlMain.Location = new System.Drawing.Point(5, 60);
            this.pnlMain.Size = new System.Drawing.Size(696, 633);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTop.Size = new System.Drawing.Size(703, 51);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(36, 738);
            this.btnEdit.Size = new System.Drawing.Size(17, 40);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(176)))), ((int)(((byte)(67)))));
            this.btnSave.ImageIndex = 12;
            this.btnSave.Location = new System.Drawing.Point(441, 749);
            this.btnSave.Size = new System.Drawing.Size(143, 38);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Pay Now!";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(39, 751);
            this.btnDelete.Size = new System.Drawing.Size(14, 31);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(39, 738);
            this.btnNew.Size = new System.Drawing.Size(14, 40);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(589, 750);
            this.btnClose.Size = new System.Drawing.Size(107, 38);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(39, 738);
            this.btnPrint.Size = new System.Drawing.Size(24, 40);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 795);
            this.groupBox1.Size = new System.Drawing.Size(703, 25);
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.LightGray;
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.ForeColor = System.Drawing.Color.Navy;
            this.txtAmount.Location = new System.Drawing.Point(119, 11);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(181, 24);
            this.txtAmount.TabIndex = 0;
            // 
            // smartLabel1
            // 
            this.smartLabel1.AutoSize = true;
            this.smartLabel1.BackColor = System.Drawing.Color.Transparent;
            this.smartLabel1.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold);
            this.smartLabel1.Location = new System.Drawing.Point(-1, 9);
            this.smartLabel1.Name = "smartLabel1";
            this.smartLabel1.Size = new System.Drawing.Size(63, 18);
            this.smartLabel1.TabIndex = 1;
            this.smartLabel1.Text = "Amount :";
            // 
            // txtPateintNo
            // 
            this.txtPateintNo.BackColor = System.Drawing.Color.LightGray;
            this.txtPateintNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPateintNo.Font = new System.Drawing.Font("Maiandra GD", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPateintNo.ForeColor = System.Drawing.Color.Red;
            this.txtPateintNo.Location = new System.Drawing.Point(66, 9);
            this.txtPateintNo.Name = "txtPateintNo";
            this.txtPateintNo.ReadOnly = true;
            this.txtPateintNo.Size = new System.Drawing.Size(178, 28);
            this.txtPateintNo.TabIndex = 3;
            // 
            // smartLabel2
            // 
            this.smartLabel2.AutoSize = true;
            this.smartLabel2.BackColor = System.Drawing.Color.Transparent;
            this.smartLabel2.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold);
            this.smartLabel2.Location = new System.Drawing.Point(3, 14);
            this.smartLabel2.Name = "smartLabel2";
            this.smartLabel2.Size = new System.Drawing.Size(66, 18);
            this.smartLabel2.TabIndex = 4;
            this.smartLabel2.Text = "HCN No :";
            // 
            // smartLabel3
            // 
            this.smartLabel3.AutoSize = true;
            this.smartLabel3.BackColor = System.Drawing.Color.Transparent;
            this.smartLabel3.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold);
            this.smartLabel3.Location = new System.Drawing.Point(254, 14);
            this.smartLabel3.Name = "smartLabel3";
            this.smartLabel3.Size = new System.Drawing.Size(51, 18);
            this.smartLabel3.TabIndex = 6;
            this.smartLabel3.Text = "Name :";
            // 
            // smartLabel4
            // 
            this.smartLabel4.AutoSize = true;
            this.smartLabel4.BackColor = System.Drawing.Color.Transparent;
            this.smartLabel4.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold);
            this.smartLabel4.Location = new System.Drawing.Point(381, 51);
            this.smartLabel4.Name = "smartLabel4";
            this.smartLabel4.Size = new System.Drawing.Size(68, 18);
            this.smartLabel4.TabIndex = 8;
            this.smartLabel4.Text = "Discount :";
            // 
            // smartLabel5
            // 
            this.smartLabel5.AutoSize = true;
            this.smartLabel5.BackColor = System.Drawing.Color.Transparent;
            this.smartLabel5.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold);
            this.smartLabel5.Location = new System.Drawing.Point(289, 135);
            this.smartLabel5.Name = "smartLabel5";
            this.smartLabel5.Size = new System.Drawing.Size(160, 18);
            this.smartLabel5.TabIndex = 10;
            this.smartLabel5.Text = "(Value Added Tax) VAT :";
            // 
            // txtVATAmount
            // 
            this.txtVATAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVATAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVATAmount.Location = new System.Drawing.Point(585, 132);
            this.txtVATAmount.MaxLength = 7;
            this.txtVATAmount.Name = "txtVATAmount";
            this.txtVATAmount.Size = new System.Drawing.Size(97, 24);
            this.txtVATAmount.TabIndex = 9;
            this.txtVATAmount.TextChanged += new System.EventHandler(this.txtVATAmount_TextChanged);
            this.txtVATAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtVATAmount_KeyUp);
            this.txtVATAmount.Leave += new System.EventHandler(this.txtVATAmount_Leave);
            // 
            // txtPatientName
            // 
            this.txtPatientName.BackColor = System.Drawing.Color.LightGray;
            this.txtPatientName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPatientName.Font = new System.Drawing.Font("Maiandra GD", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatientName.ForeColor = System.Drawing.Color.Navy;
            this.txtPatientName.Location = new System.Drawing.Point(305, 9);
            this.txtPatientName.Multiline = true;
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.ReadOnly = true;
            this.txtPatientName.Size = new System.Drawing.Size(381, 28);
            this.txtPatientName.TabIndex = 11;
            // 
            // smartLabel6
            // 
            this.smartLabel6.AutoSize = true;
            this.smartLabel6.BackColor = System.Drawing.Color.Transparent;
            this.smartLabel6.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold);
            this.smartLabel6.Location = new System.Drawing.Point(298, 172);
            this.smartLabel6.Name = "smartLabel6";
            this.smartLabel6.Size = new System.Drawing.Size(151, 18);
            this.smartLabel6.TabIndex = 13;
            this.smartLabel6.Text = "Total Payable Amount  :";
            // 
            // txtTotalPayableAmount
            // 
            this.txtTotalPayableAmount.BackColor = System.Drawing.Color.LightGray;
            this.txtTotalPayableAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalPayableAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPayableAmount.ForeColor = System.Drawing.Color.Navy;
            this.txtTotalPayableAmount.Location = new System.Drawing.Point(489, 169);
            this.txtTotalPayableAmount.Name = "txtTotalPayableAmount";
            this.txtTotalPayableAmount.ReadOnly = true;
            this.txtTotalPayableAmount.Size = new System.Drawing.Size(193, 24);
            this.txtTotalPayableAmount.TabIndex = 12;
            // 
            // txtDiscountPercentage
            // 
            this.txtDiscountPercentage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiscountPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscountPercentage.Location = new System.Drawing.Point(455, 48);
            this.txtDiscountPercentage.MaxLength = 3;
            this.txtDiscountPercentage.Name = "txtDiscountPercentage";
            this.txtDiscountPercentage.Size = new System.Drawing.Size(58, 24);
            this.txtDiscountPercentage.TabIndex = 14;
            this.txtDiscountPercentage.TextChanged += new System.EventHandler(this.txtDiscountPercentage_TextChanged);
            this.txtDiscountPercentage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDiscountPercentage_KeyUp);
            this.txtDiscountPercentage.Leave += new System.EventHandler(this.txtDiscountPercentage_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(513, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 24);
            this.label1.TabIndex = 15;
            this.label1.Text = "%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(547, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 24);
            this.label3.TabIndex = 17;
            this.label3.Text = "%";
            // 
            // txtVATPercentage
            // 
            this.txtVATPercentage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVATPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVATPercentage.Location = new System.Drawing.Point(489, 132);
            this.txtVATPercentage.MaxLength = 3;
            this.txtVATPercentage.Name = "txtVATPercentage";
            this.txtVATPercentage.Size = new System.Drawing.Size(58, 24);
            this.txtVATPercentage.TabIndex = 16;
            this.txtVATPercentage.TextChanged += new System.EventHandler(this.txtVATPercentage_TextChanged);
            this.txtVATPercentage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtVATPercentage_KeyUp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(336, 160);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(380, 3);
            this.panel1.TabIndex = 18;
            // 
            // groupBox2
            // 
            this.groupBox2.Font = new System.Drawing.Font("Maiandra GD", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Brown;
            this.groupBox2.Location = new System.Drawing.Point(-5, 238);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(697, 446);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Payment :-";
            // 
            // tbPayment
            // 
            this.tbPayment.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tbPayment.Controls.Add(this.pgCash);
            this.tbPayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbPayment.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPayment.Location = new System.Drawing.Point(3, 323);
            this.tbPayment.Name = "tbPayment";
            this.tbPayment.SelectedIndex = 0;
            this.tbPayment.Size = new System.Drawing.Size(700, 425);
            this.tbPayment.TabIndex = 3;
            this.tbPayment.SelectedIndexChanged += new System.EventHandler(this.tbPayment_SelectedIndexChanged);
            // 
            // pgCash
            // 
            this.pgCash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pgCash.Controls.Add(this.txtOthersRemarks);
            this.pgCash.Controls.Add(this.smartLabel25);
            this.pgCash.Controls.Add(this.txtOthersAmount);
            this.pgCash.Controls.Add(this.smartLabel17);
            this.pgCash.Controls.Add(this.smartLabel23);
            this.pgCash.Controls.Add(this.cboBankName);
            this.pgCash.Controls.Add(this.txtChequeAmount);
            this.pgCash.Controls.Add(this.txtChequeNo);
            this.pgCash.Controls.Add(this.smartLabel22);
            this.pgCash.Controls.Add(this.smartLabel21);
            this.pgCash.Controls.Add(this.smartLabel18);
            this.pgCash.Controls.Add(this.smartLabel20);
            this.pgCash.Controls.Add(this.smartLabel7);
            this.pgCash.Controls.Add(this.txtDiscNote);
            this.pgCash.Controls.Add(this.cboCardTypeDebit);
            this.pgCash.Controls.Add(this.txtLastDigitDebitCard);
            this.pgCash.Controls.Add(this.cboBNKDebitCard);
            this.pgCash.Controls.Add(this.txtDebitAmount);
            this.pgCash.Controls.Add(this.txtCash);
            this.pgCash.Controls.Add(this.txtChange);
            this.pgCash.Controls.Add(this.smartLabel14);
            this.pgCash.Controls.Add(this.smartLabel15);
            this.pgCash.Controls.Add(this.lblChange);
            this.pgCash.Controls.Add(this.groupBox3);
            this.pgCash.Controls.Add(this.smartLabel11);
            this.pgCash.Controls.Add(this.txtCashAmount);
            this.pgCash.Controls.Add(this.smartLabel13);
            this.pgCash.Location = new System.Drawing.Point(4, 31);
            this.pgCash.Name = "pgCash";
            this.pgCash.Size = new System.Drawing.Size(692, 390);
            this.pgCash.TabIndex = 5;
            this.pgCash.Text = ".";
            // 
            // txtOthersRemarks
            // 
            this.txtOthersRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOthersRemarks.Location = new System.Drawing.Point(192, 280);
            this.txtOthersRemarks.Multiline = true;
            this.txtOthersRemarks.Name = "txtOthersRemarks";
            this.txtOthersRemarks.Size = new System.Drawing.Size(478, 37);
            this.txtOthersRemarks.TabIndex = 11;
            this.txtOthersRemarks.Enter += new System.EventHandler(this.txtOthersRemarks_Enter);
            // 
            // smartLabel25
            // 
            this.smartLabel25.AutoSize = true;
            this.smartLabel25.BackColor = System.Drawing.Color.Transparent;
            this.smartLabel25.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.smartLabel25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.smartLabel25.Location = new System.Drawing.Point(192, 259);
            this.smartLabel25.Name = "smartLabel25";
            this.smartLabel25.Size = new System.Drawing.Size(174, 16);
            this.smartLabel25.TabIndex = 46;
            this.smartLabel25.Text = "Remarks/Due Reason :";
            // 
            // txtOthersAmount
            // 
            this.txtOthersAmount.BackColor = System.Drawing.Color.White;
            this.txtOthersAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOthersAmount.Font = new System.Drawing.Font("Maiandra GD", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOthersAmount.ForeColor = System.Drawing.Color.Red;
            this.txtOthersAmount.Location = new System.Drawing.Point(9, 280);
            this.txtOthersAmount.MaxLength = 12;
            this.txtOthersAmount.Name = "txtOthersAmount";
            this.txtOthersAmount.Size = new System.Drawing.Size(179, 42);
            this.txtOthersAmount.TabIndex = 9;
            this.txtOthersAmount.TextChanged += new System.EventHandler(this.txtOthersAmount_TextChanged);
            this.txtOthersAmount.Enter += new System.EventHandler(this.txtOthersAmount_Enter);
            this.txtOthersAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtOthersAmount_KeyUp);
            this.txtOthersAmount.Leave += new System.EventHandler(this.txtOthersAmount_Leave);
            // 
            // smartLabel17
            // 
            this.smartLabel17.AutoSize = true;
            this.smartLabel17.BackColor = System.Drawing.Color.Transparent;
            this.smartLabel17.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.smartLabel17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.smartLabel17.Location = new System.Drawing.Point(9, 259);
            this.smartLabel17.Name = "smartLabel17";
            this.smartLabel17.Size = new System.Drawing.Size(123, 16);
            this.smartLabel17.TabIndex = 44;
            this.smartLabel17.Text = "Others Amount:";
            // 
            // smartLabel23
            // 
            this.smartLabel23.AutoSize = true;
            this.smartLabel23.BackColor = System.Drawing.Color.Transparent;
            this.smartLabel23.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.smartLabel23.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.smartLabel23.Location = new System.Drawing.Point(541, 127);
            this.smartLabel23.Name = "smartLabel23";
            this.smartLabel23.Size = new System.Drawing.Size(134, 16);
            this.smartLabel23.TabIndex = 42;
            this.smartLabel23.Text = "Card No(4 Digit) :";
            // 
            // cboBankName
            // 
            this.cboBankName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBankName.Enabled = false;
            this.cboBankName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBankName.ForeColor = System.Drawing.Color.Blue;
            this.cboBankName.FormattingEnabled = true;
            this.cboBankName.Location = new System.Drawing.Point(192, 213);
            this.cboBankName.Name = "cboBankName";
            this.cboBankName.Size = new System.Drawing.Size(237, 26);
            this.cboBankName.TabIndex = 7;
            this.cboBankName.Enter += new System.EventHandler(this.cboBankName_Enter);
            // 
            // txtChequeAmount
            // 
            this.txtChequeAmount.BackColor = System.Drawing.Color.White;
            this.txtChequeAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChequeAmount.Font = new System.Drawing.Font("Maiandra GD", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChequeAmount.ForeColor = System.Drawing.Color.Red;
            this.txtChequeAmount.Location = new System.Drawing.Point(9, 213);
            this.txtChequeAmount.MaxLength = 12;
            this.txtChequeAmount.Name = "txtChequeAmount";
            this.txtChequeAmount.Size = new System.Drawing.Size(179, 42);
            this.txtChequeAmount.TabIndex = 6;
            this.txtChequeAmount.TextChanged += new System.EventHandler(this.txtChequeAmount_TextChanged);
            this.txtChequeAmount.Enter += new System.EventHandler(this.txtChequeAmount_Enter);
            this.txtChequeAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtChequeAmount_KeyUp);
            this.txtChequeAmount.Leave += new System.EventHandler(this.txtChequeAmount_Leave);
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChequeNo.Enabled = false;
            this.txtChequeNo.Location = new System.Drawing.Point(441, 213);
            this.txtChequeNo.MaxLength = 20;
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.Size = new System.Drawing.Size(229, 27);
            this.txtChequeNo.TabIndex = 8;
            this.txtChequeNo.Enter += new System.EventHandler(this.txtChequeNo_Enter);
            // 
            // smartLabel22
            // 
            this.smartLabel22.AutoSize = true;
            this.smartLabel22.BackColor = System.Drawing.Color.Transparent;
            this.smartLabel22.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.smartLabel22.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.smartLabel22.Location = new System.Drawing.Point(441, 127);
            this.smartLabel22.Name = "smartLabel22";
            this.smartLabel22.Size = new System.Drawing.Size(81, 16);
            this.smartLabel22.TabIndex = 41;
            this.smartLabel22.Text = "Card Type";
            // 
            // smartLabel21
            // 
            this.smartLabel21.AutoSize = true;
            this.smartLabel21.BackColor = System.Drawing.Color.Transparent;
            this.smartLabel21.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.smartLabel21.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.smartLabel21.Location = new System.Drawing.Point(193, 127);
            this.smartLabel21.Name = "smartLabel21";
            this.smartLabel21.Size = new System.Drawing.Size(155, 16);
            this.smartLabel21.TabIndex = 38;
            this.smartLabel21.Text = "Bank Name (Card ) :";
            // 
            // smartLabel18
            // 
            this.smartLabel18.AutoSize = true;
            this.smartLabel18.BackColor = System.Drawing.Color.Transparent;
            this.smartLabel18.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.smartLabel18.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.smartLabel18.Location = new System.Drawing.Point(9, 126);
            this.smartLabel18.Name = "smartLabel18";
            this.smartLabel18.Size = new System.Drawing.Size(112, 16);
            this.smartLabel18.TabIndex = 37;
            this.smartLabel18.Text = "Card Amount :";
            // 
            // smartLabel20
            // 
            this.smartLabel20.AutoSize = true;
            this.smartLabel20.BackColor = System.Drawing.Color.Transparent;
            this.smartLabel20.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.smartLabel20.ForeColor = System.Drawing.Color.Crimson;
            this.smartLabel20.Location = new System.Drawing.Point(196, 321);
            this.smartLabel20.Name = "smartLabel20";
            this.smartLabel20.Size = new System.Drawing.Size(118, 16);
            this.smartLabel20.TabIndex = 34;
            this.smartLabel20.Text = "Discount Note :";
            // 
            // smartLabel7
            // 
            this.smartLabel7.AutoSize = true;
            this.smartLabel7.BackColor = System.Drawing.Color.Transparent;
            this.smartLabel7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.smartLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.smartLabel7.Location = new System.Drawing.Point(9, 192);
            this.smartLabel7.Name = "smartLabel7";
            this.smartLabel7.Size = new System.Drawing.Size(129, 16);
            this.smartLabel7.TabIndex = 22;
            this.smartLabel7.Text = "Cheque Amount:";
            // 
            // txtDiscNote
            // 
            this.txtDiscNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiscNote.Location = new System.Drawing.Point(192, 340);
            this.txtDiscNote.Multiline = true;
            this.txtDiscNote.Name = "txtDiscNote";
            this.txtDiscNote.Size = new System.Drawing.Size(478, 44);
            this.txtDiscNote.TabIndex = 12;
            this.txtDiscNote.Enter += new System.EventHandler(this.txtDiscNote_Enter);
            this.txtDiscNote.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiscNote_KeyPress);
            this.txtDiscNote.Leave += new System.EventHandler(this.txtDiscNote_Leave);
            // 
            // cboCardTypeDebit
            // 
            this.cboCardTypeDebit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCardTypeDebit.Enabled = false;
            this.cboCardTypeDebit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCardTypeDebit.ForeColor = System.Drawing.Color.Blue;
            this.cboCardTypeDebit.FormattingEnabled = true;
            this.cboCardTypeDebit.Location = new System.Drawing.Point(441, 151);
            this.cboCardTypeDebit.Name = "cboCardTypeDebit";
            this.cboCardTypeDebit.Size = new System.Drawing.Size(109, 26);
            this.cboCardTypeDebit.TabIndex = 4;
            this.cboCardTypeDebit.Enter += new System.EventHandler(this.cboCardTypeDebit_Enter);
            // 
            // txtLastDigitDebitCard
            // 
            this.txtLastDigitDebitCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLastDigitDebitCard.Enabled = false;
            this.txtLastDigitDebitCard.Location = new System.Drawing.Point(564, 151);
            this.txtLastDigitDebitCard.MaxLength = 4;
            this.txtLastDigitDebitCard.Name = "txtLastDigitDebitCard";
            this.txtLastDigitDebitCard.Size = new System.Drawing.Size(109, 27);
            this.txtLastDigitDebitCard.TabIndex = 5;
            this.txtLastDigitDebitCard.Enter += new System.EventHandler(this.txtLastDigitDebitCard_Enter);
            this.txtLastDigitDebitCard.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLastDigitDebitCard_KeyPress);
            this.txtLastDigitDebitCard.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtLastDigitDebitCard_KeyUp);
            this.txtLastDigitDebitCard.Leave += new System.EventHandler(this.txtLastDigitDebitCard_Leave);
            // 
            // cboBNKDebitCard
            // 
            this.cboBNKDebitCard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBNKDebitCard.Enabled = false;
            this.cboBNKDebitCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBNKDebitCard.ForeColor = System.Drawing.Color.Blue;
            this.cboBNKDebitCard.FormattingEnabled = true;
            this.cboBNKDebitCard.Location = new System.Drawing.Point(192, 151);
            this.cboBNKDebitCard.Name = "cboBNKDebitCard";
            this.cboBNKDebitCard.Size = new System.Drawing.Size(241, 26);
            this.cboBNKDebitCard.TabIndex = 3;
            this.cboBNKDebitCard.SelectedIndexChanged += new System.EventHandler(this.cboBNKDebitCard_SelectedIndexChanged);
            this.cboBNKDebitCard.Enter += new System.EventHandler(this.cboBNKDebitCard_Enter);
            // 
            // txtDebitAmount
            // 
            this.txtDebitAmount.BackColor = System.Drawing.Color.White;
            this.txtDebitAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDebitAmount.Font = new System.Drawing.Font("Maiandra GD", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDebitAmount.ForeColor = System.Drawing.Color.Red;
            this.txtDebitAmount.Location = new System.Drawing.Point(9, 147);
            this.txtDebitAmount.MaxLength = 12;
            this.txtDebitAmount.Name = "txtDebitAmount";
            this.txtDebitAmount.Size = new System.Drawing.Size(177, 42);
            this.txtDebitAmount.TabIndex = 2;
            this.txtDebitAmount.TextChanged += new System.EventHandler(this.txtDebitAmount_TextChanged);
            this.txtDebitAmount.Enter += new System.EventHandler(this.txtDebitAmount_Enter);
            this.txtDebitAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDebitAmount_KeyUp);
            this.txtDebitAmount.Leave += new System.EventHandler(this.txtDebitAmount_Leave);
            // 
            // txtCash
            // 
            this.txtCash.BackColor = System.Drawing.Color.White;
            this.txtCash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCash.Font = new System.Drawing.Font("Maiandra GD", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCash.ForeColor = System.Drawing.Color.Red;
            this.txtCash.Location = new System.Drawing.Point(9, 77);
            this.txtCash.MaxLength = 12;
            this.txtCash.Name = "txtCash";
            this.txtCash.Size = new System.Drawing.Size(181, 42);
            this.txtCash.TabIndex = 1;
            this.txtCash.TextChanged += new System.EventHandler(this.txtCash_TextChanged);
            this.txtCash.Enter += new System.EventHandler(this.txtCash_Enter);
            this.txtCash.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCash_KeyPress);
            this.txtCash.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCash_KeyUp);
            this.txtCash.Leave += new System.EventHandler(this.txtCash_Leave);
            // 
            // txtChange
            // 
            this.txtChange.BackColor = System.Drawing.Color.White;
            this.txtChange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChange.Font = new System.Drawing.Font("Maiandra GD", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChange.ForeColor = System.Drawing.Color.Red;
            this.txtChange.Location = new System.Drawing.Point(9, 340);
            this.txtChange.MaxLength = 12;
            this.txtChange.Name = "txtChange";
            this.txtChange.ReadOnly = true;
            this.txtChange.Size = new System.Drawing.Size(179, 42);
            this.txtChange.TabIndex = 20;
            this.txtChange.TextChanged += new System.EventHandler(this.txtChange_TextChanged);
            // 
            // smartLabel14
            // 
            this.smartLabel14.AutoSize = true;
            this.smartLabel14.BackColor = System.Drawing.Color.Transparent;
            this.smartLabel14.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.smartLabel14.Location = new System.Drawing.Point(9, 54);
            this.smartLabel14.Name = "smartLabel14";
            this.smartLabel14.Size = new System.Drawing.Size(110, 16);
            this.smartLabel14.TabIndex = 18;
            this.smartLabel14.Text = "Cash Amount:";
            // 
            // smartLabel15
            // 
            this.smartLabel15.AutoSize = true;
            this.smartLabel15.BackColor = System.Drawing.Color.Transparent;
            this.smartLabel15.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.smartLabel15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.smartLabel15.Location = new System.Drawing.Point(441, 192);
            this.smartLabel15.Name = "smartLabel15";
            this.smartLabel15.Size = new System.Drawing.Size(95, 16);
            this.smartLabel15.TabIndex = 29;
            this.smartLabel15.Text = "Cheque No :";
            // 
            // lblChange
            // 
            this.lblChange.AutoSize = true;
            this.lblChange.BackColor = System.Drawing.Color.Transparent;
            this.lblChange.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblChange.Location = new System.Drawing.Point(9, 322);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(63, 16);
            this.lblChange.TabIndex = 19;
            this.lblChange.Text = "Change";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.groupBox3.Controls.Add(this.btnExact);
            this.groupBox3.Controls.Add(this.btnClear);
            this.groupBox3.Controls.Add(this.btnBSpace);
            this.groupBox3.Controls.Add(this.btnN100);
            this.groupBox3.Controls.Add(this.btnN5000);
            this.groupBox3.Controls.Add(this.btn1000);
            this.groupBox3.Controls.Add(this.btn500);
            this.groupBox3.Controls.Add(this.btnN00);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(208, -3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(481, 127);
            this.groupBox3.TabIndex = 60;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Payment Calculator";
            // 
            // btnExact
            // 
            this.btnExact.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnExact.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExact.ForeColor = System.Drawing.Color.Red;
            this.btnExact.Location = new System.Drawing.Point(124, 71);
            this.btnExact.Name = "btnExact";
            this.btnExact.Size = new System.Drawing.Size(109, 45);
            this.btnExact.TabIndex = 18;
            this.btnExact.Text = "Exact";
            this.btnExact.UseVisualStyleBackColor = false;
            this.btnExact.Click += new System.EventHandler(this.btnExact_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.Red;
            this.btnClear.Location = new System.Drawing.Point(357, 71);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(109, 45);
            this.btnClear.TabIndex = 20;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnBSpace
            // 
            this.btnBSpace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnBSpace.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBSpace.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBSpace.ForeColor = System.Drawing.Color.Red;
            this.btnBSpace.Location = new System.Drawing.Point(241, 71);
            this.btnBSpace.Name = "btnBSpace";
            this.btnBSpace.Size = new System.Drawing.Size(109, 45);
            this.btnBSpace.TabIndex = 19;
            this.btnBSpace.Text = "Bk Spc";
            this.btnBSpace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBSpace.UseVisualStyleBackColor = false;
            this.btnBSpace.Click += new System.EventHandler(this.btnBSpace_Click);
            // 
            // btnN100
            // 
            this.btnN100.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnN100.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnN100.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnN100.ForeColor = System.Drawing.Color.Red;
            this.btnN100.Location = new System.Drawing.Point(6, 20);
            this.btnN100.Name = "btnN100";
            this.btnN100.Size = new System.Drawing.Size(109, 45);
            this.btnN100.TabIndex = 14;
            this.btnN100.Text = "100";
            this.btnN100.UseVisualStyleBackColor = false;
            this.btnN100.Click += new System.EventHandler(this.btnN100_Click);
            // 
            // btnN5000
            // 
            this.btnN5000.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnN5000.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnN5000.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnN5000.ForeColor = System.Drawing.Color.Red;
            this.btnN5000.Location = new System.Drawing.Point(357, 20);
            this.btnN5000.Name = "btnN5000";
            this.btnN5000.Size = new System.Drawing.Size(109, 45);
            this.btnN5000.TabIndex = 17;
            this.btnN5000.Text = "5000";
            this.btnN5000.UseVisualStyleBackColor = false;
            this.btnN5000.Click += new System.EventHandler(this.btnN5000_Click);
            // 
            // btn1000
            // 
            this.btn1000.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn1000.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn1000.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn1000.ForeColor = System.Drawing.Color.Red;
            this.btn1000.Location = new System.Drawing.Point(241, 20);
            this.btn1000.Name = "btn1000";
            this.btn1000.Size = new System.Drawing.Size(109, 45);
            this.btn1000.TabIndex = 16;
            this.btn1000.Text = "1000";
            this.btn1000.UseVisualStyleBackColor = false;
            this.btn1000.Click += new System.EventHandler(this.btn1000_Click);
            // 
            // btn500
            // 
            this.btn500.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn500.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn500.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn500.ForeColor = System.Drawing.Color.Red;
            this.btn500.Location = new System.Drawing.Point(124, 20);
            this.btn500.Name = "btn500";
            this.btn500.Size = new System.Drawing.Size(109, 45);
            this.btn500.TabIndex = 15;
            this.btn500.Text = "500";
            this.btn500.UseVisualStyleBackColor = false;
            this.btn500.Click += new System.EventHandler(this.btn500_Click);
            // 
            // btnN00
            // 
            this.btnN00.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnN00.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnN00.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnN00.ForeColor = System.Drawing.Color.Red;
            this.btnN00.Location = new System.Drawing.Point(6, 71);
            this.btnN00.Name = "btnN00";
            this.btnN00.Size = new System.Drawing.Size(109, 45);
            this.btnN00.TabIndex = 13;
            this.btnN00.Text = "00";
            this.btnN00.UseVisualStyleBackColor = false;
            this.btnN00.Click += new System.EventHandler(this.btnN00_Click);
            // 
            // smartLabel11
            // 
            this.smartLabel11.AutoSize = true;
            this.smartLabel11.BackColor = System.Drawing.Color.Transparent;
            this.smartLabel11.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.smartLabel11.ForeColor = System.Drawing.Color.Blue;
            this.smartLabel11.Location = new System.Drawing.Point(9, 5);
            this.smartLabel11.Name = "smartLabel11";
            this.smartLabel11.Size = new System.Drawing.Size(117, 16);
            this.smartLabel11.TabIndex = 9;
            this.smartLabel11.Text = "Final Amount  :";
            // 
            // txtCashAmount
            // 
            this.txtCashAmount.BackColor = System.Drawing.Color.LightYellow;
            this.txtCashAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCashAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCashAmount.Location = new System.Drawing.Point(9, 25);
            this.txtCashAmount.MaxLength = 12;
            this.txtCashAmount.Name = "txtCashAmount";
            this.txtCashAmount.ReadOnly = true;
            this.txtCashAmount.Size = new System.Drawing.Size(181, 24);
            this.txtCashAmount.TabIndex = 0;
            this.txtCashAmount.TextChanged += new System.EventHandler(this.txtCashAmount_TextChanged);
            // 
            // smartLabel13
            // 
            this.smartLabel13.AutoSize = true;
            this.smartLabel13.BackColor = System.Drawing.Color.Transparent;
            this.smartLabel13.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.smartLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.smartLabel13.Location = new System.Drawing.Point(193, 192);
            this.smartLabel13.Name = "smartLabel13";
            this.smartLabel13.Size = new System.Drawing.Size(99, 16);
            this.smartLabel13.TabIndex = 28;
            this.smartLabel13.Text = "Bank Name :";
            // 
            // smartLabel24
            // 
            this.smartLabel24.AutoSize = true;
            this.smartLabel24.BackColor = System.Drawing.Color.Transparent;
            this.smartLabel24.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold);
            this.smartLabel24.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.smartLabel24.Location = new System.Drawing.Point(50, 96);
            this.smartLabel24.Name = "smartLabel24";
            this.smartLabel24.Size = new System.Drawing.Size(169, 18);
            this.smartLabel24.TabIndex = 43;
            this.smartLabel24.Text = "Bank Name (Credit Card ) :";
            this.smartLabel24.Visible = false;
            // 
            // cboCardTypeCredit
            // 
            this.cboCardTypeCredit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCardTypeCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCardTypeCredit.ForeColor = System.Drawing.Color.Blue;
            this.cboCardTypeCredit.FormattingEnabled = true;
            this.cboCardTypeCredit.Location = new System.Drawing.Point(177, 118);
            this.cboCardTypeCredit.Name = "cboCardTypeCredit";
            this.cboCardTypeCredit.Size = new System.Drawing.Size(34, 26);
            this.cboCardTypeCredit.TabIndex = 6;
            this.cboCardTypeCredit.Visible = false;
            // 
            // smartLabel19
            // 
            this.smartLabel19.AutoSize = true;
            this.smartLabel19.BackColor = System.Drawing.Color.Transparent;
            this.smartLabel19.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold);
            this.smartLabel19.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.smartLabel19.Location = new System.Drawing.Point(100, 117);
            this.smartLabel19.Name = "smartLabel19";
            this.smartLabel19.Size = new System.Drawing.Size(71, 18);
            this.smartLabel19.TabIndex = 36;
            this.smartLabel19.Text = "Card Type";
            this.smartLabel19.Visible = false;
            // 
            // smartLabel16
            // 
            this.smartLabel16.AutoSize = true;
            this.smartLabel16.BackColor = System.Drawing.Color.Transparent;
            this.smartLabel16.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold);
            this.smartLabel16.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.smartLabel16.Location = new System.Drawing.Point(217, 96);
            this.smartLabel16.Name = "smartLabel16";
            this.smartLabel16.Size = new System.Drawing.Size(140, 18);
            this.smartLabel16.TabIndex = 33;
            this.smartLabel16.Text = "Card No(Last 4 Digit) :";
            this.smartLabel16.Visible = false;
            // 
            // txtLastDigitCreditCard
            // 
            this.txtLastDigitCreditCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLastDigitCreditCard.Location = new System.Drawing.Point(218, 116);
            this.txtLastDigitCreditCard.MaxLength = 4;
            this.txtLastDigitCreditCard.Name = "txtLastDigitCreditCard";
            this.txtLastDigitCreditCard.Size = new System.Drawing.Size(16, 20);
            this.txtLastDigitCreditCard.TabIndex = 7;
            this.txtLastDigitCreditCard.Visible = false;
            this.txtLastDigitCreditCard.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLastDigitCreditCard_KeyPress);
            this.txtLastDigitCreditCard.Leave += new System.EventHandler(this.txtLastDigitCreditCard_Leave);
            // 
            // cboBNKNameCreditCard
            // 
            this.cboBNKNameCreditCard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBNKNameCreditCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBNKNameCreditCard.ForeColor = System.Drawing.Color.Blue;
            this.cboBNKNameCreditCard.FormattingEnabled = true;
            this.cboBNKNameCreditCard.Location = new System.Drawing.Point(50, 117);
            this.cboBNKNameCreditCard.Name = "cboBNKNameCreditCard";
            this.cboBNKNameCreditCard.Size = new System.Drawing.Size(47, 26);
            this.cboBNKNameCreditCard.TabIndex = 5;
            this.cboBNKNameCreditCard.Visible = false;
            // 
            // txtCreditAmount
            // 
            this.txtCreditAmount.BackColor = System.Drawing.Color.White;
            this.txtCreditAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCreditAmount.Font = new System.Drawing.Font("Maiandra GD", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreditAmount.ForeColor = System.Drawing.Color.Red;
            this.txtCreditAmount.Location = new System.Drawing.Point(19, 116);
            this.txtCreditAmount.MaxLength = 12;
            this.txtCreditAmount.Name = "txtCreditAmount";
            this.txtCreditAmount.Size = new System.Drawing.Size(25, 42);
            this.txtCreditAmount.TabIndex = 4;
            this.txtCreditAmount.Visible = false;
            this.txtCreditAmount.TextChanged += new System.EventHandler(this.txtCreditAmount_TextChanged);
            this.txtCreditAmount.Enter += new System.EventHandler(this.txtCreditAmount_Enter);
            this.txtCreditAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCreditAmount_KeyUp);
            this.txtCreditAmount.Leave += new System.EventHandler(this.txtCreditAmount_Leave);
            // 
            // smartLabel12
            // 
            this.smartLabel12.AutoSize = true;
            this.smartLabel12.BackColor = System.Drawing.Color.Transparent;
            this.smartLabel12.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold);
            this.smartLabel12.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.smartLabel12.Location = new System.Drawing.Point(-5, 96);
            this.smartLabel12.Name = "smartLabel12";
            this.smartLabel12.Size = new System.Drawing.Size(51, 18);
            this.smartLabel12.TabIndex = 24;
            this.smartLabel12.Text = "Credit :";
            this.smartLabel12.Visible = false;
            // 
            // smartLabel8
            // 
            this.smartLabel8.AutoSize = true;
            this.smartLabel8.BackColor = System.Drawing.Color.Transparent;
            this.smartLabel8.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold);
            this.smartLabel8.Location = new System.Drawing.Point(352, 213);
            this.smartLabel8.Name = "smartLabel8";
            this.smartLabel8.Size = new System.Drawing.Size(97, 18);
            this.smartLabel8.TabIndex = 21;
            this.smartLabel8.Text = "Advance Paid :";
            // 
            // txtAdvancePaid
            // 
            this.txtAdvancePaid.BackColor = System.Drawing.Color.LightGray;
            this.txtAdvancePaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdvancePaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdvancePaid.ForeColor = System.Drawing.Color.Navy;
            this.txtAdvancePaid.Location = new System.Drawing.Point(490, 210);
            this.txtAdvancePaid.Name = "txtAdvancePaid";
            this.txtAdvancePaid.ReadOnly = true;
            this.txtAdvancePaid.Size = new System.Drawing.Size(192, 24);
            this.txtAdvancePaid.TabIndex = 20;
            // 
            // smartLabel9
            // 
            this.smartLabel9.AutoSize = true;
            this.smartLabel9.BackColor = System.Drawing.Color.Transparent;
            this.smartLabel9.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold);
            this.smartLabel9.Location = new System.Drawing.Point(4, 10);
            this.smartLabel9.Name = "smartLabel9";
            this.smartLabel9.Size = new System.Drawing.Size(87, 18);
            this.smartLabel9.TabIndex = 23;
            this.smartLabel9.Text = "Net Payable :";
            // 
            // txtNetPayableAmount
            // 
            this.txtNetPayableAmount.BackColor = System.Drawing.Color.LightGray;
            this.txtNetPayableAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNetPayableAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNetPayableAmount.ForeColor = System.Drawing.Color.Navy;
            this.txtNetPayableAmount.Location = new System.Drawing.Point(121, 9);
            this.txtNetPayableAmount.Name = "txtNetPayableAmount";
            this.txtNetPayableAmount.ReadOnly = true;
            this.txtNetPayableAmount.Size = new System.Drawing.Size(181, 24);
            this.txtNetPayableAmount.TabIndex = 22;
            this.txtNetPayableAmount.TextChanged += new System.EventHandler(this.txtNetPayableAmount_TextChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(338, 81);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(380, 3);
            this.panel2.TabIndex = 24;
            // 
            // txtDiscountAmount
            // 
            this.txtDiscountAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiscountAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscountAmount.Location = new System.Drawing.Point(551, 48);
            this.txtDiscountAmount.MaxLength = 8;
            this.txtDiscountAmount.Name = "txtDiscountAmount";
            this.txtDiscountAmount.Size = new System.Drawing.Size(131, 24);
            this.txtDiscountAmount.TabIndex = 25;
            this.txtDiscountAmount.TextChanged += new System.EventHandler(this.txtDiscountAmount_TextChanged);
            this.txtDiscountAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDiscountAmount_KeyUp);
            this.txtDiscountAmount.Leave += new System.EventHandler(this.txtDiscountAmount_Leave);
            // 
            // smartLabel10
            // 
            this.smartLabel10.AutoSize = true;
            this.smartLabel10.BackColor = System.Drawing.Color.Transparent;
            this.smartLabel10.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold);
            this.smartLabel10.Location = new System.Drawing.Point(332, 93);
            this.smartLabel10.Name = "smartLabel10";
            this.smartLabel10.Size = new System.Drawing.Size(117, 18);
            this.smartLabel10.TabIndex = 27;
            this.smartLabel10.Text = "Payable Amount  :";
            // 
            // txtPayableAmount
            // 
            this.txtPayableAmount.BackColor = System.Drawing.Color.LightGray;
            this.txtPayableAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPayableAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPayableAmount.ForeColor = System.Drawing.Color.Navy;
            this.txtPayableAmount.Location = new System.Drawing.Point(490, 90);
            this.txtPayableAmount.Name = "txtPayableAmount";
            this.txtPayableAmount.ReadOnly = true;
            this.txtPayableAmount.Size = new System.Drawing.Size(192, 24);
            this.txtPayableAmount.TabIndex = 26;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DimGray;
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(336, 125);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(380, 3);
            this.panel3.TabIndex = 28;
            // 
            // txtPreviousDue
            // 
            this.txtPreviousDue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPreviousDue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPreviousDue.Location = new System.Drawing.Point(319, 49);
            this.txtPreviousDue.MaxLength = 3;
            this.txtPreviousDue.Name = "txtPreviousDue";
            this.txtPreviousDue.Size = new System.Drawing.Size(58, 24);
            this.txtPreviousDue.TabIndex = 29;
            this.txtPreviousDue.Text = "0";
            this.txtPreviousDue.Visible = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SteelBlue;
            this.panel4.Controls.Add(this.txtAmount);
            this.panel4.Controls.Add(this.smartLabel1);
            this.panel4.Location = new System.Drawing.Point(0, 49);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(314, 44);
            this.panel4.TabIndex = 30;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Tan;
            this.panel5.Controls.Add(this.smartLabel9);
            this.panel5.Controls.Add(this.txtNetPayableAmount);
            this.panel5.Location = new System.Drawing.Point(-1, 192);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(316, 47);
            this.panel5.TabIndex = 31;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(182)))), ((int)(((byte)(241)))));
            this.panel6.Controls.Add(this.txtPateintNo);
            this.panel6.Controls.Add(this.smartLabel2);
            this.panel6.Controls.Add(this.txtPatientName);
            this.panel6.Controls.Add(this.smartLabel3);
            this.panel6.Location = new System.Drawing.Point(-4, -2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(696, 47);
            this.panel6.TabIndex = 32;
            // 
            // frmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(703, 820);
            this.Controls.Add(this.tbPayment);
            this.isEnterTabAllow = true;
            this.Name = "frmPayment";
            this.Load += new System.EventHandler(this.frmPayment_Load);
            this.LocationChanged += new System.EventHandler(this.frmPayment_LocationChanged);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.pnlMain, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.Controls.SetChildIndex(this.tbPayment, 0);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.tbPayment.ResumeLayout(false);
            this.pgCash.ResumeLayout(false);
            this.pgCash.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private AtiqsControlLibrary.SmartNumericTextBox txtAmount;
        private AtiqsControlLibrary.SmartLabel smartLabel1;
        private AtiqsControlLibrary.SmartLabel smartLabel3;
        private AtiqsControlLibrary.SmartLabel smartLabel2;
        private System.Windows.Forms.TextBox txtPateintNo;
        private AtiqsControlLibrary.SmartLabel smartLabel6;
        private AtiqsControlLibrary.SmartTextBox txtTotalPayableAmount;
        private System.Windows.Forms.TextBox txtPatientName;
        private AtiqsControlLibrary.SmartLabel smartLabel5;
        private AtiqsControlLibrary.SmartLabel smartLabel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private AtiqsControlLibrary.SmartTab tbPayment;
        private AtiqsControlLibrary.SmartNumericTextBox txtVATAmount;
        private AtiqsControlLibrary.SmartNumericTextBox txtVATPercentage;
        private AtiqsControlLibrary.SmartNumericTextBox txtDiscountPercentage;
        private AtiqsControlLibrary.SmartLabel smartLabel9;
        private AtiqsControlLibrary.SmartTextBox txtNetPayableAmount;
        private AtiqsControlLibrary.SmartLabel smartLabel8;
        private AtiqsControlLibrary.SmartTextBox txtAdvancePaid;
        private System.Windows.Forms.TabPage pgCash;
        private System.Windows.Forms.Panel panel2;
        private AtiqsControlLibrary.SmartNumericTextBox txtDiscountAmount;
        private AtiqsControlLibrary.SmartLabel smartLabel10;
        private AtiqsControlLibrary.SmartTextBox txtPayableAmount;
        private System.Windows.Forms.Panel panel3;
        private AtiqsControlLibrary.SmartLabel smartLabel11;
        private AtiqsControlLibrary.SmartNumericTextBox txtCashAmount;
        private AtiqsControlLibrary.SmartNumericTextBox txtPreviousDue;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnBSpace;
        private System.Windows.Forms.Button btnN100;
        private System.Windows.Forms.Button btnN5000;
        private System.Windows.Forms.Button btn1000;
        private System.Windows.Forms.Button btn500;
        private System.Windows.Forms.Button btnN00;
        private AtiqsControlLibrary.SmartLabel smartLabel14;
        private AtiqsControlLibrary.SmartLabel lblChange;
        private System.Windows.Forms.TextBox txtChange;
        private AtiqsControlLibrary.SmartNumericTextBoxColorful txtCash;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private AtiqsControlLibrary.SmartNumericTextBoxColorful txtCreditAmount;
        private AtiqsControlLibrary.SmartLabel smartLabel12;
        private AtiqsControlLibrary.SmartNumericTextBoxColorful txtDebitAmount;
        private AtiqsControlLibrary.SmartLabel smartLabel7;
        private AtiqsControlLibrary.SmartLabel smartLabel15;
        private AtiqsControlLibrary.SmartLabel smartLabel13;
        private AtiqsControlLibrary.SmartNumericTextBoxColorful txtLastDigitDebitCard;
        private AtiqsControlLibrary.SmartComboBox cboBNKDebitCard;
        private AtiqsControlLibrary.SmartLabel smartLabel16;
        private AtiqsControlLibrary.SmartNumericTextBoxColorful txtLastDigitCreditCard;
        private AtiqsControlLibrary.SmartComboBox cboBNKNameCreditCard;
        private AtiqsControlLibrary.SmartComboBox cboCardTypeCredit;
        private AtiqsControlLibrary.SmartLabel smartLabel19;
        private AtiqsControlLibrary.SmartComboBox cboCardTypeDebit;
        private System.Windows.Forms.Button btnExact;
        private AtiqsControlLibrary.SmartLabel smartLabel20;
        private System.Windows.Forms.TextBox txtDiscNote;
        private AtiqsControlLibrary.SmartComboBox cboBankName;
        private AtiqsControlLibrary.SmartNumericTextBoxColorful txtChequeNo;
        private AtiqsControlLibrary.SmartNumericTextBoxColorful txtChequeAmount;
        private AtiqsControlLibrary.SmartLabel smartLabel18;
        private AtiqsControlLibrary.SmartLabel smartLabel24;
        private AtiqsControlLibrary.SmartLabel smartLabel23;
        private AtiqsControlLibrary.SmartLabel smartLabel22;
        private AtiqsControlLibrary.SmartLabel smartLabel21;
        private AtiqsControlLibrary.SmartNumericTextBoxColorful txtOthersAmount;
        private AtiqsControlLibrary.SmartLabel smartLabel17;
        private AtiqsControlLibrary.SmartLabel smartLabel25;
        private System.Windows.Forms.TextBox txtOthersRemarks;
    }
}