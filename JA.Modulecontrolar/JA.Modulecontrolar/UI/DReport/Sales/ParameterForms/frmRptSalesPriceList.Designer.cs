namespace JA.Modulecontrolar.UI.DReport.Sales.ParameterForms
{
    partial class frmRptSalesPriceList
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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dteToDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dteFromDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.radLevelWise = new System.Windows.Forms.RadioButton();
            this.radItemWise = new System.Windows.Forms.RadioButton();
            this.radStockGroupWise = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.dteFromDate1 = new System.Windows.Forms.DateTimePicker();
            this.txtLevelName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(157, 9);
            this.frmLabel.Size = new System.Drawing.Size(189, 33);
            this.frmLabel.Text = "Sales Price List";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.label6);
            this.pnlMain.Controls.Add(this.dtpToDate);
            this.pnlMain.Controls.Add(this.txtLevelName);
            this.pnlMain.Controls.Add(this.dteFromDate1);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.radStockGroupWise);
            this.pnlMain.Controls.Add(this.radItemWise);
            this.pnlMain.Controls.Add(this.radLevelWise);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.groupBox6);
            this.pnlMain.Location = new System.Drawing.Point(-8, -86);
            this.pnlMain.Size = new System.Drawing.Size(521, 386);
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(514, 54);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(132, 307);
            this.btnEdit.Size = new System.Drawing.Size(10, 10);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(19, 307);
            this.btnSave.Size = new System.Drawing.Size(10, 10);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(175, 307);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(48, 306);
            this.btnNew.Size = new System.Drawing.Size(10, 10);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(380, 307);
            this.btnClose.Size = new System.Drawing.Size(133, 39);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(232, 307);
            this.btnPrint.Size = new System.Drawing.Size(142, 39);
            this.btnPrint.Text = "Preview";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 352);
            this.groupBox1.Size = new System.Drawing.Size(514, 17);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.dteToDate);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.dteFromDate);
            this.groupBox6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(37, 417);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(440, 96);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Period Seletion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(105, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "To:";
            // 
            // dteToDate
            // 
            this.dteToDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteToDate.Location = new System.Drawing.Point(161, 62);
            this.dteToDate.Name = "dteToDate";
            this.dteToDate.Size = new System.Drawing.Size(129, 22);
            this.dteToDate.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(86, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "From:";
            // 
            // dteFromDate
            // 
            this.dteFromDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteFromDate.Location = new System.Drawing.Point(161, 31);
            this.dteFromDate.Name = "dteFromDate";
            this.dteFromDate.Size = new System.Drawing.Size(129, 22);
            this.dteFromDate.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(50, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "Level Name:";
            // 
            // radLevelWise
            // 
            this.radLevelWise.AutoSize = true;
            this.radLevelWise.Checked = true;
            this.radLevelWise.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLevelWise.Location = new System.Drawing.Point(70, 143);
            this.radLevelWise.Name = "radLevelWise";
            this.radLevelWise.Size = new System.Drawing.Size(91, 21);
            this.radLevelWise.TabIndex = 9;
            this.radLevelWise.TabStop = true;
            this.radLevelWise.Text = "LevelWise";
            this.radLevelWise.UseVisualStyleBackColor = true;
            this.radLevelWise.Click += new System.EventHandler(this.radLevelWise_Click);
            // 
            // radItemWise
            // 
            this.radItemWise.AutoSize = true;
            this.radItemWise.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radItemWise.Location = new System.Drawing.Point(208, 143);
            this.radItemWise.Name = "radItemWise";
            this.radItemWise.Size = new System.Drawing.Size(83, 21);
            this.radItemWise.TabIndex = 10;
            this.radItemWise.Text = "ItemWise";
            this.radItemWise.UseVisualStyleBackColor = true;
            this.radItemWise.Click += new System.EventHandler(this.radItemWise_Click);
            // 
            // radStockGroupWise
            // 
            this.radStockGroupWise.AutoSize = true;
            this.radStockGroupWise.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radStockGroupWise.Location = new System.Drawing.Point(333, 143);
            this.radStockGroupWise.Name = "radStockGroupWise";
            this.radStockGroupWise.Size = new System.Drawing.Size(136, 21);
            this.radStockGroupWise.TabIndex = 11;
            this.radStockGroupWise.Text = "StockGroup Wise";
            this.radStockGroupWise.UseVisualStyleBackColor = true;
            this.radStockGroupWise.Click += new System.EventHandler(this.radStockGroupWise_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(257, 300);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 14);
            this.label4.TabIndex = 12;
            this.label4.Text = "Effective Date:";
            // 
            // dteFromDate1
            // 
            this.dteFromDate1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteFromDate1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteFromDate1.Location = new System.Drawing.Point(362, 300);
            this.dteFromDate1.Name = "dteFromDate1";
            this.dteFromDate1.Size = new System.Drawing.Size(129, 22);
            this.dteFromDate1.TabIndex = 21;
            // 
            // txtLevelName
            // 
            this.txtLevelName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLevelName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLevelName.Location = new System.Drawing.Point(141, 194);
            this.txtLevelName.Name = "txtLevelName";
            this.txtLevelName.Size = new System.Drawing.Size(350, 23);
            this.txtLevelName.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(282, 328);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 16);
            this.label6.TabIndex = 55;
            this.label6.Text = "To Date :";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(362, 328);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(129, 22);
            this.dtpToDate.TabIndex = 54;
            // 
            // frmRptSalesPriceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(514, 369);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmRptSalesPriceList";
            this.Load += new System.EventHandler(this.frmRptStoreLedger_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dteToDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dteFromDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radStockGroupWise;
        private System.Windows.Forms.RadioButton radItemWise;
        private System.Windows.Forms.RadioButton radLevelWise;
        private System.Windows.Forms.DateTimePicker dteFromDate1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLevelName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpToDate;
    }
}
