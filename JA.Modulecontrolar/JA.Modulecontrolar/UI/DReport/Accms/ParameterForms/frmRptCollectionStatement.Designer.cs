namespace JA.Modulecontrolar.UI.DReport.Accms.ParameterForms
{
    partial class frmRptCollectionStatement
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
            this.label1 = new System.Windows.Forms.Label();
            this.dteToDate = new System.Windows.Forms.DateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cheZone = new System.Windows.Forms.CheckBox();
            this.cheRSMDSM = new System.Windows.Forms.CheckBox();
            this.cheFMAM = new System.Windows.Forms.CheckBox();
            this.cheMPO = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TxtGreater = new System.Windows.Forms.TextBox();
            this.txtLess = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.radIndividual = new System.Windows.Forms.RadioButton();
            this.radAll = new System.Windows.Forms.RadioButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dteFromDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.panelBranch = new System.Windows.Forms.Panel();
            this.uctxtBranch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.uctxtTeritorryName = new System.Windows.Forms.TextBox();
            this.uctxtTerritoryCode = new System.Windows.Forms.TextBox();
            this.DGMr = new MayhediControlLibrary.StandardDataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblMpoName = new System.Windows.Forms.Label();
            this.uctxtMrName = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panelBranch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGMr)).BeginInit();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(135, 9);
            this.frmLabel.Size = new System.Drawing.Size(267, 33);
            this.frmLabel.Text = "Collection Statemnet ";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.DGMr);
            this.pnlMain.Controls.Add(this.lblMpoName);
            this.pnlMain.Controls.Add(this.uctxtMrName);
            this.pnlMain.Controls.Add(this.panelBranch);
            this.pnlMain.Controls.Add(this.panel5);
            this.pnlMain.Controls.Add(this.panel2);
            this.pnlMain.Controls.Add(this.panel3);
            this.pnlMain.Location = new System.Drawing.Point(0, -86);
            this.pnlMain.Size = new System.Drawing.Size(486, 540);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(488, 57);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(125, 365);
            this.btnEdit.Size = new System.Drawing.Size(14, 19);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 365);
            this.btnSave.Size = new System.Drawing.Size(23, 19);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(168, 365);
            this.btnDelete.Size = new System.Drawing.Size(10, 14);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(41, 364);
            this.btnNew.Size = new System.Drawing.Size(36, 13);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(365, 460);
            this.btnClose.Size = new System.Drawing.Size(121, 39);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(237, 460);
            this.btnPrint.Size = new System.Drawing.Size(127, 39);
            this.btnPrint.Text = "Preview";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 499);
            this.groupBox1.Size = new System.Drawing.Size(488, 25);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(41, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "To:";
            // 
            // dteToDate
            // 
            this.dteToDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteToDate.Location = new System.Drawing.Point(88, 42);
            this.dteToDate.Name = "dteToDate";
            this.dteToDate.Size = new System.Drawing.Size(129, 22);
            this.dteToDate.TabIndex = 22;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.cheZone);
            this.panel3.Controls.Add(this.cheRSMDSM);
            this.panel3.Controls.Add(this.cheFMAM);
            this.panel3.Controls.Add(this.cheMPO);
            this.panel3.Location = new System.Drawing.Point(23, 338);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(446, 51);
            this.panel3.TabIndex = 11;
            // 
            // cheZone
            // 
            this.cheZone.AutoSize = true;
            this.cheZone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cheZone.Location = new System.Drawing.Point(346, 15);
            this.cheZone.Name = "cheZone";
            this.cheZone.Size = new System.Drawing.Size(66, 21);
            this.cheZone.TabIndex = 7;
            this.cheZone.Text = "ZONE";
            this.cheZone.UseVisualStyleBackColor = true;
            this.cheZone.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cheZone_MouseClick);
            // 
            // cheRSMDSM
            // 
            this.cheRSMDSM.AutoSize = true;
            this.cheRSMDSM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cheRSMDSM.Location = new System.Drawing.Point(225, 15);
            this.cheRSMDSM.Name = "cheRSMDSM";
            this.cheRSMDSM.Size = new System.Drawing.Size(91, 21);
            this.cheRSMDSM.TabIndex = 6;
            this.cheRSMDSM.Text = "DSM/RSM";
            this.cheRSMDSM.UseVisualStyleBackColor = true;
            this.cheRSMDSM.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cheRSMDSM_MouseClick);
            // 
            // cheFMAM
            // 
            this.cheFMAM.AutoSize = true;
            this.cheFMAM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cheFMAM.Location = new System.Drawing.Point(117, 15);
            this.cheFMAM.Name = "cheFMAM";
            this.cheFMAM.Size = new System.Drawing.Size(70, 21);
            this.cheFMAM.TabIndex = 5;
            this.cheFMAM.Text = "AM/FM";
            this.cheFMAM.UseVisualStyleBackColor = true;
            this.cheFMAM.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cheFMAM_MouseClick);
            // 
            // cheMPO
            // 
            this.cheMPO.AutoSize = true;
            this.cheMPO.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cheMPO.Location = new System.Drawing.Point(30, 15);
            this.cheMPO.Name = "cheMPO";
            this.cheMPO.Size = new System.Drawing.Size(58, 21);
            this.cheMPO.TabIndex = 4;
            this.cheMPO.Text = "MPO";
            this.cheMPO.UseVisualStyleBackColor = true;
            this.cheMPO.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cheMPO_MouseClick);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.TxtGreater);
            this.panel2.Controls.Add(this.txtLess);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.radIndividual);
            this.panel2.Controls.Add(this.radAll);
            this.panel2.Location = new System.Drawing.Point(23, 201);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(446, 59);
            this.panel2.TabIndex = 17;
            // 
            // TxtGreater
            // 
            this.TxtGreater.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtGreater.Location = new System.Drawing.Point(282, 28);
            this.TxtGreater.Name = "TxtGreater";
            this.TxtGreater.Size = new System.Drawing.Size(139, 22);
            this.TxtGreater.TabIndex = 13;
            // 
            // txtLess
            // 
            this.txtLess.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLess.Location = new System.Drawing.Point(282, 3);
            this.txtLess.Name = "txtLess";
            this.txtLess.Size = new System.Drawing.Size(139, 22);
            this.txtLess.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(172, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 14);
            this.label6.TabIndex = 11;
            this.label6.Text = "Above Amount :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(174, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 14);
            this.label4.TabIndex = 10;
            this.label4.Text = "Below Amount :";
            // 
            // radIndividual
            // 
            this.radIndividual.AutoSize = true;
            this.radIndividual.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radIndividual.Location = new System.Drawing.Point(59, 31);
            this.radIndividual.Name = "radIndividual";
            this.radIndividual.Size = new System.Drawing.Size(85, 21);
            this.radIndividual.TabIndex = 1;
            this.radIndividual.TabStop = true;
            this.radIndividual.Text = "Individual";
            this.radIndividual.UseVisualStyleBackColor = true;
            this.radIndividual.Click += new System.EventHandler(this.radIndividual_Click);
            this.radIndividual.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radIndividual_MouseClick);
            // 
            // radAll
            // 
            this.radAll.AutoSize = true;
            this.radAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAll.Location = new System.Drawing.Point(59, 4);
            this.radAll.Name = "radAll";
            this.radAll.Size = new System.Drawing.Size(41, 21);
            this.radAll.TabIndex = 0;
            this.radAll.TabStop = true;
            this.radAll.Text = "All";
            this.radAll.UseVisualStyleBackColor = true;
            this.radAll.CheckedChanged += new System.EventHandler(this.radAll_CheckedChanged);
            this.radAll.Click += new System.EventHandler(this.radAll_Click);
            this.radAll.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radAll_MouseClick);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.dteFromDate);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.dteToDate);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Location = new System.Drawing.Point(206, 406);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(263, 75);
            this.panel5.TabIndex = 19;
            // 
            // dteFromDate
            // 
            this.dteFromDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteFromDate.Location = new System.Drawing.Point(89, 14);
            this.dteFromDate.Name = "dteFromDate";
            this.dteFromDate.Size = new System.Drawing.Size(129, 22);
            this.dteFromDate.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(20, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "From:";
            // 
            // panelBranch
            // 
            this.panelBranch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBranch.Controls.Add(this.uctxtBranch);
            this.panelBranch.Controls.Add(this.label3);
            this.panelBranch.Location = new System.Drawing.Point(23, 153);
            this.panelBranch.Name = "panelBranch";
            this.panelBranch.Size = new System.Drawing.Size(446, 42);
            this.panelBranch.TabIndex = 20;
            // 
            // uctxtBranch
            // 
            this.uctxtBranch.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtBranch.Location = new System.Drawing.Point(116, 12);
            this.uctxtBranch.Name = "uctxtBranch";
            this.uctxtBranch.Size = new System.Drawing.Size(319, 22);
            this.uctxtBranch.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "Branch Name:";
            // 
            // uctxtTeritorryName
            // 
            this.uctxtTeritorryName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtTeritorryName.Location = new System.Drawing.Point(41, 402);
            this.uctxtTeritorryName.Name = "uctxtTeritorryName";
            this.uctxtTeritorryName.Size = new System.Drawing.Size(10, 22);
            this.uctxtTeritorryName.TabIndex = 210;
            this.uctxtTeritorryName.Visible = false;
            // 
            // uctxtTerritoryCode
            // 
            this.uctxtTerritoryCode.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtTerritoryCode.Location = new System.Drawing.Point(12, 402);
            this.uctxtTerritoryCode.Name = "uctxtTerritoryCode";
            this.uctxtTerritoryCode.Size = new System.Drawing.Size(10, 22);
            this.uctxtTerritoryCode.TabIndex = 209;
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
            this.DGMr.Location = new System.Drawing.Point(23, 309);
            this.DGMr.MultiSelect = false;
            this.DGMr.Name = "DGMr";
            this.DGMr.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            this.DGMr.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DGMr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGMr.Size = new System.Drawing.Size(446, 23);
            this.DGMr.TabIndex = 213;
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
            this.dataGridViewTextBoxColumn13.Width = 130;
            // 
            // dataGridViewTextBoxColumn14
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn14.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn14.HeaderText = "MPO Name";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 190;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.HeaderText = "String";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Visible = false;
            // 
            // lblMpoName
            // 
            this.lblMpoName.AutoSize = true;
            this.lblMpoName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMpoName.Location = new System.Drawing.Point(20, 263);
            this.lblMpoName.Name = "lblMpoName";
            this.lblMpoName.Size = new System.Drawing.Size(80, 14);
            this.lblMpoName.TabIndex = 212;
            this.lblMpoName.Text = "MPO Name:";
            // 
            // uctxtMrName
            // 
            this.uctxtMrName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtMrName.Location = new System.Drawing.Point(23, 280);
            this.uctxtMrName.Name = "uctxtMrName";
            this.uctxtMrName.Size = new System.Drawing.Size(446, 22);
            this.uctxtMrName.TabIndex = 211;
            // 
            // frmRptCollectionStatement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(488, 524);
            this.Controls.Add(this.uctxtTeritorryName);
            this.Controls.Add(this.uctxtTerritoryCode);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmRptCollectionStatement";
            this.Load += new System.EventHandler(this.frmRptStoreLedger_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.pnlMain, 0);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.uctxtTerritoryCode, 0);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.Controls.SetChildIndex(this.uctxtTeritorryName, 0);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panelBranch.ResumeLayout(false);
            this.panelBranch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGMr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dteToDate;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radIndividual;
        private System.Windows.Forms.RadioButton radAll;
        private System.Windows.Forms.CheckBox cheZone;
        private System.Windows.Forms.CheckBox cheRSMDSM;
        private System.Windows.Forms.CheckBox cheFMAM;
        private System.Windows.Forms.CheckBox cheMPO;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DateTimePicker dteFromDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelBranch;
        private System.Windows.Forms.TextBox uctxtBranch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uctxtTeritorryName;
        private System.Windows.Forms.TextBox uctxtTerritoryCode;
        private MayhediControlLibrary.StandardDataGridView DGMr;
        private System.Windows.Forms.Label lblMpoName;
        private System.Windows.Forms.TextBox uctxtMrName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtGreater;
        private System.Windows.Forms.TextBox txtLess;
    }
}
