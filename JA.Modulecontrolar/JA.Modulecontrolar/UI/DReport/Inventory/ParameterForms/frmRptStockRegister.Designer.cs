namespace JA.Modulecontrolar.UI.DReport.Inventory.ParameterForms
{
    partial class frmRptStockRegister
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
            this.pnlSelection = new System.Windows.Forms.Panel();
            this.radIndividual = new System.Windows.Forms.RadioButton();
            this.radAll = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dteToDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dteFromDate = new System.Windows.Forms.DateTimePicker();
            this.pnlIndividual = new System.Windows.Forms.Panel();
            this.radToLocation = new System.Windows.Forms.RadioButton();
            this.radFromLocation = new System.Windows.Forms.RadioButton();
            this.label14 = new System.Windows.Forms.Label();
            this.txtFgLocation = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbtnTransferIN = new System.Windows.Forms.RadioButton();
            this.rbtnTransferOut = new System.Windows.Forms.RadioButton();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlSelection.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.pnlIndividual.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(124, 9);
            this.frmLabel.Size = new System.Drawing.Size(187, 33);
            this.frmLabel.Text = "Stock Transfer";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.panel2);
            this.pnlMain.Controls.Add(this.label14);
            this.pnlMain.Controls.Add(this.txtFgLocation);
            this.pnlMain.Controls.Add(this.pnlIndividual);
            this.pnlMain.Controls.Add(this.groupBox6);
            this.pnlMain.Controls.Add(this.pnlSelection);
            this.pnlMain.Location = new System.Drawing.Point(0, -86);
            this.pnlMain.Size = new System.Drawing.Size(427, 538);
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(432, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(111, 488);
            this.btnEdit.Size = new System.Drawing.Size(10, 10);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(-2, 330);
            this.btnSave.Size = new System.Drawing.Size(20, 10);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(154, 488);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(30, 484);
            this.btnNew.Size = new System.Drawing.Size(10, 10);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(316, 456);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(180, 456);
            this.btnPrint.Size = new System.Drawing.Size(133, 39);
            this.btnPrint.Text = "Preview";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 516);
            this.groupBox1.Size = new System.Drawing.Size(432, 25);
            // 
            // pnlSelection
            // 
            this.pnlSelection.Controls.Add(this.radIndividual);
            this.pnlSelection.Controls.Add(this.radAll);
            this.pnlSelection.Location = new System.Drawing.Point(20, 217);
            this.pnlSelection.Name = "pnlSelection";
            this.pnlSelection.Size = new System.Drawing.Size(383, 52);
            this.pnlSelection.TabIndex = 0;
            // 
            // radIndividual
            // 
            this.radIndividual.AutoSize = true;
            this.radIndividual.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radIndividual.Location = new System.Drawing.Point(221, 15);
            this.radIndividual.Name = "radIndividual";
            this.radIndividual.Size = new System.Drawing.Size(143, 18);
            this.radIndividual.TabIndex = 1;
            this.radIndividual.Text = "Individual Location";
            this.radIndividual.UseVisualStyleBackColor = true;
            this.radIndividual.Click += new System.EventHandler(this.radIndividual_Click);
            // 
            // radAll
            // 
            this.radAll.AutoSize = true;
            this.radAll.Checked = true;
            this.radAll.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAll.Location = new System.Drawing.Point(86, 15);
            this.radAll.Name = "radAll";
            this.radAll.Size = new System.Drawing.Size(96, 18);
            this.radAll.TabIndex = 0;
            this.radAll.TabStop = true;
            this.radAll.Text = "All Location";
            this.radAll.UseVisualStyleBackColor = true;
            this.radAll.Click += new System.EventHandler(this.radAll_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.dteToDate);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.dteFromDate);
            this.groupBox6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(29, 432);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(376, 95);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Period Seletion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(91, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "To:";
            // 
            // dteToDate
            // 
            this.dteToDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteToDate.Location = new System.Drawing.Point(143, 55);
            this.dteToDate.Name = "dteToDate";
            this.dteToDate.Size = new System.Drawing.Size(126, 22);
            this.dteToDate.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(91, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "From:";
            // 
            // dteFromDate
            // 
            this.dteFromDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteFromDate.Location = new System.Drawing.Point(143, 27);
            this.dteFromDate.Name = "dteFromDate";
            this.dteFromDate.Size = new System.Drawing.Size(126, 22);
            this.dteFromDate.TabIndex = 20;
            // 
            // pnlIndividual
            // 
            this.pnlIndividual.Controls.Add(this.radToLocation);
            this.pnlIndividual.Controls.Add(this.radFromLocation);
            this.pnlIndividual.Location = new System.Drawing.Point(20, 272);
            this.pnlIndividual.Name = "pnlIndividual";
            this.pnlIndividual.Size = new System.Drawing.Size(383, 52);
            this.pnlIndividual.TabIndex = 6;
            this.pnlIndividual.Visible = false;
            // 
            // radToLocation
            // 
            this.radToLocation.AutoSize = true;
            this.radToLocation.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radToLocation.Location = new System.Drawing.Point(227, 15);
            this.radToLocation.Name = "radToLocation";
            this.radToLocation.Size = new System.Drawing.Size(96, 18);
            this.radToLocation.TabIndex = 1;
            this.radToLocation.Text = "To Location";
            this.radToLocation.UseVisualStyleBackColor = true;
            this.radToLocation.Click += new System.EventHandler(this.radToLocation_Click);
            // 
            // radFromLocation
            // 
            this.radFromLocation.AutoSize = true;
            this.radFromLocation.Checked = true;
            this.radFromLocation.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radFromLocation.Location = new System.Drawing.Point(86, 15);
            this.radFromLocation.Name = "radFromLocation";
            this.radFromLocation.Size = new System.Drawing.Size(113, 18);
            this.radFromLocation.TabIndex = 0;
            this.radFromLocation.TabStop = true;
            this.radFromLocation.Text = "From Location";
            this.radFromLocation.UseVisualStyleBackColor = true;
            this.radFromLocation.Click += new System.EventHandler(this.radFromLocation_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label14.Location = new System.Drawing.Point(34, 360);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 16);
            this.label14.TabIndex = 110;
            this.label14.Text = "Location:";
            // 
            // txtFgLocation
            // 
            this.txtFgLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFgLocation.Enabled = false;
            this.txtFgLocation.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFgLocation.Location = new System.Drawing.Point(110, 357);
            this.txtFgLocation.Name = "txtFgLocation";
            this.txtFgLocation.Size = new System.Drawing.Size(293, 23);
            this.txtFgLocation.TabIndex = 109;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbtnTransferIN);
            this.panel2.Controls.Add(this.rbtnTransferOut);
            this.panel2.Location = new System.Drawing.Point(20, 159);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(383, 52);
            this.panel2.TabIndex = 111;
            // 
            // rbtnTransferIN
            // 
            this.rbtnTransferIN.AutoSize = true;
            this.rbtnTransferIN.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnTransferIN.Location = new System.Drawing.Point(221, 15);
            this.rbtnTransferIN.Name = "rbtnTransferIN";
            this.rbtnTransferIN.Size = new System.Drawing.Size(94, 18);
            this.rbtnTransferIN.TabIndex = 1;
            this.rbtnTransferIN.Text = "Transfer IN";
            this.rbtnTransferIN.UseVisualStyleBackColor = true;
            // 
            // rbtnTransferOut
            // 
            this.rbtnTransferOut.AutoSize = true;
            this.rbtnTransferOut.Checked = true;
            this.rbtnTransferOut.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnTransferOut.Location = new System.Drawing.Point(86, 15);
            this.rbtnTransferOut.Name = "rbtnTransferOut";
            this.rbtnTransferOut.Size = new System.Drawing.Size(103, 18);
            this.rbtnTransferOut.TabIndex = 0;
            this.rbtnTransferOut.TabStop = true;
            this.rbtnTransferOut.Text = "Transfer Out";
            this.rbtnTransferOut.UseVisualStyleBackColor = true;
            // 
            // frmRptStockRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(432, 541);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmRptStockRegister";
            this.Load += new System.EventHandler(this.frmRptProduct_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlSelection.ResumeLayout(false);
            this.pnlSelection.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.pnlIndividual.ResumeLayout(false);
            this.pnlIndividual.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSelection;
        private System.Windows.Forms.RadioButton radIndividual;
        private System.Windows.Forms.RadioButton radAll;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dteToDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dteFromDate;
        private System.Windows.Forms.Panel pnlIndividual;
        private System.Windows.Forms.RadioButton radToLocation;
        private System.Windows.Forms.RadioButton radFromLocation;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtFgLocation;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbtnTransferIN;
        private System.Windows.Forms.RadioButton rbtnTransferOut;
    }
}
