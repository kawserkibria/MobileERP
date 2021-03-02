namespace JA.Modulecontrolar.UI.DReport.Sales.ParameterForms
{
    partial class frmRptProductwiseAnalysis
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
            this.grpboxPer = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dteToDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dteFromDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.radItemwiseSum = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.radItemWDet = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radProductW = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radPartyW = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radSelection = new System.Windows.Forms.RadioButton();
            this.radall = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ChkboxProdkuctTotal = new System.Windows.Forms.CheckBox();
            this.cheSupPartyT = new System.Windows.Forms.CheckBox();
            this.groupSelection = new System.Windows.Forms.GroupBox();
            this.lstRight2 = new System.Windows.Forms.ListBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lstLeft2 = new System.Windows.Forms.ListBox();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnLeftAll = new System.Windows.Forms.Button();
            this.btnLeftSingle = new System.Windows.Forms.Button();
            this.btnRightAll = new System.Windows.Forms.Button();
            this.btnRightSingle = new System.Windows.Forms.Button();
            this.lstRight = new System.Windows.Forms.ListBox();
            this.lstLeft = new System.Windows.Forms.ListBox();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.cmbTranType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpboxPer.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Font = new System.Drawing.Font("Verdana", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmLabel.Location = new System.Drawing.Point(67, 2);
            this.frmLabel.Size = new System.Drawing.Size(427, 32);
            this.frmLabel.Text = "Productwise/MPOwise Analysis";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.cmbTranType);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.btn2);
            this.pnlMain.Controls.Add(this.btn1);
            this.pnlMain.Controls.Add(this.groupSelection);
            this.pnlMain.Controls.Add(this.groupBox4);
            this.pnlMain.Controls.Add(this.groupBox3);
            this.pnlMain.Controls.Add(this.groupBox2);
            this.pnlMain.Controls.Add(this.grpboxPer);
            this.pnlMain.Location = new System.Drawing.Point(0, -86);
            this.pnlMain.Size = new System.Drawing.Size(565, 554);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(566, 44);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(148, 482);
            this.btnEdit.Size = new System.Drawing.Size(14, 19);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(35, 482);
            this.btnSave.Size = new System.Drawing.Size(14, 14);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(191, 482);
            this.btnDelete.Size = new System.Drawing.Size(10, 14);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(64, 481);
            this.btnNew.Size = new System.Drawing.Size(11, 15);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(439, 471);
            this.btnClose.Size = new System.Drawing.Size(125, 39);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(299, 471);
            this.btnPrint.Size = new System.Drawing.Size(138, 39);
            this.btnPrint.Text = "Preview";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 510);
            this.groupBox1.Size = new System.Drawing.Size(566, 25);
            // 
            // grpboxPer
            // 
            this.grpboxPer.Controls.Add(this.label1);
            this.grpboxPer.Controls.Add(this.dteToDate);
            this.grpboxPer.Controls.Add(this.label5);
            this.grpboxPer.Controls.Add(this.dteFromDate);
            this.grpboxPer.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpboxPer.Location = new System.Drawing.Point(207, 468);
            this.grpboxPer.Name = "grpboxPer";
            this.grpboxPer.Size = new System.Drawing.Size(345, 80);
            this.grpboxPer.TabIndex = 5;
            this.grpboxPer.TabStop = false;
            this.grpboxPer.Text = "Period Seletion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(68, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "To Date :";
            // 
            // dteToDate
            // 
            this.dteToDate.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteToDate.Location = new System.Drawing.Point(155, 49);
            this.dteToDate.Name = "dteToDate";
            this.dteToDate.Size = new System.Drawing.Size(165, 25);
            this.dteToDate.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(52, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "From Date :";
            // 
            // dteFromDate
            // 
            this.dteFromDate.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteFromDate.Location = new System.Drawing.Point(155, 21);
            this.dteFromDate.Name = "dteFromDate";
            this.dteFromDate.Size = new System.Drawing.Size(165, 25);
            this.dteFromDate.TabIndex = 20;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel5);
            this.groupBox2.Controls.Add(this.panel4);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(11, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(542, 52);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Report Option";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.radItemwiseSum);
            this.panel5.Location = new System.Drawing.Point(223, 20);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(155, 26);
            this.panel5.TabIndex = 19;
            // 
            // radItemwiseSum
            // 
            this.radItemwiseSum.AutoSize = true;
            this.radItemwiseSum.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radItemwiseSum.Location = new System.Drawing.Point(4, 5);
            this.radItemwiseSum.Name = "radItemwiseSum";
            this.radItemwiseSum.Size = new System.Drawing.Size(145, 18);
            this.radItemwiseSum.TabIndex = 4;
            this.radItemwiseSum.Text = "Itemwise Summary";
            this.radItemwiseSum.UseVisualStyleBackColor = true;
            this.radItemwiseSum.Click += new System.EventHandler(this.radItemwiseSum_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.radItemWDet);
            this.panel4.Location = new System.Drawing.Point(379, 20);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(151, 27);
            this.panel4.TabIndex = 18;
            // 
            // radItemWDet
            // 
            this.radItemWDet.AutoSize = true;
            this.radItemWDet.Checked = true;
            this.radItemWDet.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radItemWDet.Location = new System.Drawing.Point(5, 7);
            this.radItemWDet.Name = "radItemWDet";
            this.radItemWDet.Size = new System.Drawing.Size(130, 18);
            this.radItemWDet.TabIndex = 5;
            this.radItemWDet.TabStop = true;
            this.radItemWDet.Text = "Itemwise Details";
            this.radItemWDet.UseVisualStyleBackColor = true;
            this.radItemWDet.Click += new System.EventHandler(this.radItemWDet_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.radProductW);
            this.panel3.Location = new System.Drawing.Point(107, 20);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(116, 27);
            this.panel3.TabIndex = 17;
            // 
            // radProductW
            // 
            this.radProductW.AutoSize = true;
            this.radProductW.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radProductW.Location = new System.Drawing.Point(5, 5);
            this.radProductW.Name = "radProductW";
            this.radProductW.Size = new System.Drawing.Size(108, 18);
            this.radProductW.TabIndex = 3;
            this.radProductW.Text = "Product Wise";
            this.radProductW.UseVisualStyleBackColor = true;
            this.radProductW.Click += new System.EventHandler(this.radProductW_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radPartyW);
            this.panel2.Location = new System.Drawing.Point(7, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(98, 27);
            this.panel2.TabIndex = 16;
            // 
            // radPartyW
            // 
            this.radPartyW.AutoSize = true;
            this.radPartyW.Checked = true;
            this.radPartyW.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPartyW.Location = new System.Drawing.Point(6, 2);
            this.radPartyW.Name = "radPartyW";
            this.radPartyW.Size = new System.Drawing.Size(88, 18);
            this.radPartyW.TabIndex = 2;
            this.radPartyW.TabStop = true;
            this.radPartyW.Text = "MPO Wise";
            this.radPartyW.UseVisualStyleBackColor = true;
            this.radPartyW.Click += new System.EventHandler(this.radPartyW_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radSelection);
            this.groupBox3.Controls.Add(this.radall);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(40, 183);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(150, 43);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            // 
            // radSelection
            // 
            this.radSelection.AutoSize = true;
            this.radSelection.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSelection.Location = new System.Drawing.Point(60, 21);
            this.radSelection.Name = "radSelection";
            this.radSelection.Size = new System.Drawing.Size(82, 18);
            this.radSelection.TabIndex = 2;
            this.radSelection.Text = "Selection";
            this.radSelection.UseVisualStyleBackColor = true;
            this.radSelection.Click += new System.EventHandler(this.radSelection_Click);
            // 
            // radall
            // 
            this.radall.AutoSize = true;
            this.radall.Checked = true;
            this.radall.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radall.Location = new System.Drawing.Point(6, 20);
            this.radall.Name = "radall";
            this.radall.Size = new System.Drawing.Size(43, 18);
            this.radall.TabIndex = 1;
            this.radall.TabStop = true;
            this.radall.Text = "All ";
            this.radall.UseVisualStyleBackColor = true;
            this.radall.Click += new System.EventHandler(this.radioButton2_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ChkboxProdkuctTotal);
            this.groupBox4.Controls.Add(this.cheSupPartyT);
            this.groupBox4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(192, 183);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(360, 44);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            // 
            // ChkboxProdkuctTotal
            // 
            this.ChkboxProdkuctTotal.AutoSize = true;
            this.ChkboxProdkuctTotal.Location = new System.Drawing.Point(182, 22);
            this.ChkboxProdkuctTotal.Name = "ChkboxProdkuctTotal";
            this.ChkboxProdkuctTotal.Size = new System.Drawing.Size(163, 18);
            this.ChkboxProdkuctTotal.TabIndex = 1;
            this.ChkboxProdkuctTotal.Text = "Supress Product Total";
            this.ChkboxProdkuctTotal.UseVisualStyleBackColor = true;
            this.ChkboxProdkuctTotal.Click += new System.EventHandler(this.ChkboxProdkuctTotal_Click);
            // 
            // cheSupPartyT
            // 
            this.cheSupPartyT.AutoSize = true;
            this.cheSupPartyT.Location = new System.Drawing.Point(9, 21);
            this.cheSupPartyT.Name = "cheSupPartyT";
            this.cheSupPartyT.Size = new System.Drawing.Size(148, 18);
            this.cheSupPartyT.TabIndex = 0;
            this.cheSupPartyT.Text = "Supress Party Total";
            this.cheSupPartyT.UseVisualStyleBackColor = true;
            this.cheSupPartyT.Click += new System.EventHandler(this.cheSupPartyT_Click);
            // 
            // groupSelection
            // 
            this.groupSelection.Controls.Add(this.lstRight2);
            this.groupSelection.Controls.Add(this.textBox2);
            this.groupSelection.Controls.Add(this.lstLeft2);
            this.groupSelection.Controls.Add(this.btncancel);
            this.groupSelection.Controls.Add(this.btnOK);
            this.groupSelection.Controls.Add(this.textBox1);
            this.groupSelection.Controls.Add(this.txtSearch);
            this.groupSelection.Controls.Add(this.btnLeftAll);
            this.groupSelection.Controls.Add(this.btnLeftSingle);
            this.groupSelection.Controls.Add(this.btnRightAll);
            this.groupSelection.Controls.Add(this.btnRightSingle);
            this.groupSelection.Controls.Add(this.lstRight);
            this.groupSelection.Controls.Add(this.lstLeft);
            this.groupSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupSelection.Location = new System.Drawing.Point(11, 265);
            this.groupSelection.Name = "groupSelection";
            this.groupSelection.Size = new System.Drawing.Size(541, 201);
            this.groupSelection.TabIndex = 26;
            this.groupSelection.TabStop = false;
            this.groupSelection.Text = "Selection";
            // 
            // lstRight2
            // 
            this.lstRight2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstRight2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstRight2.FormattingEnabled = true;
            this.lstRight2.ItemHeight = 14;
            this.lstRight2.Location = new System.Drawing.Point(294, 41);
            this.lstRight2.Name = "lstRight2";
            this.lstRight2.Size = new System.Drawing.Size(234, 128);
            this.lstRight2.TabIndex = 31;
            this.lstRight2.DoubleClick += new System.EventHandler(this.lstRight2_DoubleClick);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(472, 15);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(10, 20);
            this.textBox2.TabIndex = 30;
            this.textBox2.Visible = false;
            // 
            // lstLeft2
            // 
            this.lstLeft2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstLeft2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLeft2.FormattingEnabled = true;
            this.lstLeft2.ItemHeight = 14;
            this.lstLeft2.Location = new System.Drawing.Point(6, 41);
            this.lstLeft2.Name = "lstLeft2";
            this.lstLeft2.Size = new System.Drawing.Size(240, 128);
            this.lstLeft2.TabIndex = 30;
            // 
            // btncancel
            // 
            this.btncancel.BackColor = System.Drawing.Color.LemonChiffon;
            this.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btncancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.Location = new System.Drawing.Point(294, 171);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(70, 27);
            this.btncancel.TabIndex = 29;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = false;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(174, 171);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(72, 27);
            this.btnOK.TabIndex = 28;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(472, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(10, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.Visible = false;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(6, 19);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(240, 22);
            this.txtSearch.TabIndex = 0;
            // 
            // btnLeftAll
            // 
            this.btnLeftAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLeftAll.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftAll.Location = new System.Drawing.Point(252, 138);
            this.btnLeftAll.Name = "btnLeftAll";
            this.btnLeftAll.Size = new System.Drawing.Size(36, 23);
            this.btnLeftAll.TabIndex = 5;
            this.btnLeftAll.Text = "<<";
            this.btnLeftAll.UseVisualStyleBackColor = false;
            this.btnLeftAll.Click += new System.EventHandler(this.btnLeftAll_Click);
            // 
            // btnLeftSingle
            // 
            this.btnLeftSingle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLeftSingle.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftSingle.Location = new System.Drawing.Point(252, 113);
            this.btnLeftSingle.Name = "btnLeftSingle";
            this.btnLeftSingle.Size = new System.Drawing.Size(36, 23);
            this.btnLeftSingle.TabIndex = 4;
            this.btnLeftSingle.Text = "<";
            this.btnLeftSingle.UseVisualStyleBackColor = false;
            this.btnLeftSingle.Click += new System.EventHandler(this.btnLeftSingle_Click);
            // 
            // btnRightAll
            // 
            this.btnRightAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRightAll.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRightAll.Location = new System.Drawing.Point(252, 88);
            this.btnRightAll.Name = "btnRightAll";
            this.btnRightAll.Size = new System.Drawing.Size(36, 23);
            this.btnRightAll.TabIndex = 3;
            this.btnRightAll.Text = ">>";
            this.btnRightAll.UseVisualStyleBackColor = false;
            this.btnRightAll.Click += new System.EventHandler(this.btnRightAll_Click);
            // 
            // btnRightSingle
            // 
            this.btnRightSingle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRightSingle.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRightSingle.Location = new System.Drawing.Point(252, 63);
            this.btnRightSingle.Name = "btnRightSingle";
            this.btnRightSingle.Size = new System.Drawing.Size(36, 23);
            this.btnRightSingle.TabIndex = 2;
            this.btnRightSingle.Text = ">";
            this.btnRightSingle.UseVisualStyleBackColor = false;
            this.btnRightSingle.Click += new System.EventHandler(this.btnRightSingle_Click);
            // 
            // lstRight
            // 
            this.lstRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstRight.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstRight.FormattingEnabled = true;
            this.lstRight.ItemHeight = 14;
            this.lstRight.Location = new System.Drawing.Point(294, 41);
            this.lstRight.Name = "lstRight";
            this.lstRight.Size = new System.Drawing.Size(234, 128);
            this.lstRight.TabIndex = 1;
            // 
            // lstLeft
            // 
            this.lstLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstLeft.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLeft.FormattingEnabled = true;
            this.lstLeft.ItemHeight = 14;
            this.lstLeft.Location = new System.Drawing.Point(6, 41);
            this.lstLeft.Name = "lstLeft";
            this.lstLeft.Size = new System.Drawing.Size(240, 128);
            this.lstLeft.TabIndex = 0;
            // 
            // btn1
            // 
            this.btn1.BackColor = System.Drawing.Color.LemonChiffon;
            this.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn1.Location = new System.Drawing.Point(78, 229);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(187, 30);
            this.btn1.TabIndex = 27;
            this.btn1.Text = "button1";
            this.btn1.UseVisualStyleBackColor = false;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn2
            // 
            this.btn2.BackColor = System.Drawing.Color.LemonChiffon;
            this.btn2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn2.Location = new System.Drawing.Point(282, 229);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(195, 30);
            this.btn2.TabIndex = 28;
            this.btn2.Text = "button2";
            this.btn2.UseVisualStyleBackColor = false;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // cmbTranType
            // 
            this.cmbTranType.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTranType.FormattingEnabled = true;
            this.cmbTranType.Location = new System.Drawing.Point(15, 495);
            this.cmbTranType.Name = "cmbTranType";
            this.cmbTranType.Size = new System.Drawing.Size(165, 26);
            this.cmbTranType.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(15, 472);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 16);
            this.label3.TabIndex = 29;
            this.label3.Text = "Transaction Type ";
            // 
            // frmRptProductwiseAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(566, 535);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmRptProductwiseAnalysis";
            this.Load += new System.EventHandler(this.frmRptStoreLedger_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.grpboxPer.ResumeLayout(false);
            this.grpboxPer.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupSelection.ResumeLayout(false);
            this.groupSelection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpboxPer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dteToDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dteFromDate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radSelection;
        private System.Windows.Forms.RadioButton radall;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox ChkboxProdkuctTotal;
        private System.Windows.Forms.CheckBox cheSupPartyT;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton radItemwiseSum;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton radItemWDet;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton radProductW;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radPartyW;
        private System.Windows.Forms.GroupBox groupSelection;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnLeftAll;
        private System.Windows.Forms.Button btnLeftSingle;
        private System.Windows.Forms.Button btnRightAll;
        private System.Windows.Forms.Button btnRightSingle;
        private System.Windows.Forms.ListBox lstRight;
        private System.Windows.Forms.ListBox lstLeft;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ListBox lstLeft2;
        private System.Windows.Forms.ListBox lstRight2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox cmbTranType;
        private System.Windows.Forms.Label label3;
    }
}
