﻿namespace JA.Modulecontrolar.UI.DReport.Inventory.ParameterForms
{
    partial class frmRptVoucherReports
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
            this.label4 = new System.Windows.Forms.Label();
            this.uctxtBranchName = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dteToDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dteFromDate = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radIndividual = new System.Windows.Forms.RadioButton();
            this.radAll = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtnProduction = new System.Windows.Forms.RadioButton();
            this.rbtnStationaryCons = new System.Windows.Forms.RadioButton();
            this.rbtnConversionFG = new System.Windows.Forms.RadioButton();
            this.rbtnstockTrnsferIN = new System.Windows.Forms.RadioButton();
            this.rbtnRequsition = new System.Windows.Forms.RadioButton();
            this.radStockAbsorved = new System.Windows.Forms.RadioButton();
            this.radPhysicalStock = new System.Windows.Forms.RadioButton();
            this.radStockTransfer = new System.Windows.Forms.RadioButton();
            this.radDamage = new System.Windows.Forms.RadioButton();
            this.rbtnMFGVoucher = new System.Windows.Forms.RadioButton();
            this.radManufacturing = new System.Windows.Forms.RadioButton();
            this.radFinishedGoods = new System.Windows.Forms.RadioButton();
            this.radSalesSample = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radSumm = new System.Windows.Forms.RadioButton();
            this.radDetails = new System.Windows.Forms.RadioButton();
            this.cboLocation = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(190, 9);
            this.frmLabel.Size = new System.Drawing.Size(212, 33);
            this.frmLabel.Text = "Voucher Reports";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.cboLocation);
            this.pnlMain.Controls.Add(this.radSalesSample);
            this.pnlMain.Controls.Add(this.groupBox3);
            this.pnlMain.Controls.Add(this.groupBox2);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.uctxtBranchName);
            this.pnlMain.Controls.Add(this.groupBox6);
            this.pnlMain.Controls.Add(this.panel2);
            this.pnlMain.Controls.Add(this.radFinishedGoods);
            this.pnlMain.Size = new System.Drawing.Size(564, 496);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.rbtnMFGVoucher);
            this.pnlTop.Controls.Add(this.radManufacturing);
            this.pnlTop.Size = new System.Drawing.Size(570, 58);
            this.pnlTop.Controls.SetChildIndex(this.radManufacturing, 0);
            this.pnlTop.Controls.SetChildIndex(this.rbtnMFGVoucher, 0);
            this.pnlTop.Controls.SetChildIndex(this.frmLabel, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnTopClose, 0);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(136, 353);
            this.btnEdit.Size = new System.Drawing.Size(10, 10);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(23, 372);
            this.btnSave.Size = new System.Drawing.Size(10, 10);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(249, 353);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(16, 359);
            this.btnNew.Size = new System.Drawing.Size(10, 10);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(456, 413);
            this.btnClose.Size = new System.Drawing.Size(108, 41);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(333, 413);
            this.btnPrint.Size = new System.Drawing.Size(120, 41);
            this.btnPrint.Text = "Preview";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 454);
            this.groupBox1.Size = new System.Drawing.Size(570, 25);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(196, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 16);
            this.label4.TabIndex = 33;
            this.label4.Text = "Branch Name:";
            // 
            // uctxtBranchName
            // 
            this.uctxtBranchName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtBranchName.Enabled = false;
            this.uctxtBranchName.Location = new System.Drawing.Point(196, 168);
            this.uctxtBranchName.Name = "uctxtBranchName";
            this.uctxtBranchName.Size = new System.Drawing.Size(351, 20);
            this.uctxtBranchName.TabIndex = 32;
            this.uctxtBranchName.TextChanged += new System.EventHandler(this.uctxtBranchName_TextChanged_1);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.dteToDate);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.dteFromDate);
            this.groupBox6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(354, 388);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(190, 94);
            this.groupBox6.TabIndex = 31;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Period Seletion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(10, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "To:";
            // 
            // dteToDate
            // 
            this.dteToDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteToDate.Location = new System.Drawing.Point(62, 63);
            this.dteToDate.Name = "dteToDate";
            this.dteToDate.Size = new System.Drawing.Size(112, 22);
            this.dteToDate.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(10, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "From:";
            // 
            // dteFromDate
            // 
            this.dteFromDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteFromDate.Location = new System.Drawing.Point(62, 27);
            this.dteFromDate.Name = "dteFromDate";
            this.dteFromDate.Size = new System.Drawing.Size(112, 22);
            this.dteFromDate.TabIndex = 20;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radIndividual);
            this.panel2.Controls.Add(this.radAll);
            this.panel2.Location = new System.Drawing.Point(15, 140);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(174, 70);
            this.panel2.TabIndex = 30;
            // 
            // radIndividual
            // 
            this.radIndividual.AutoSize = true;
            this.radIndividual.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radIndividual.Location = new System.Drawing.Point(25, 42);
            this.radIndividual.Name = "radIndividual";
            this.radIndividual.Size = new System.Drawing.Size(133, 18);
            this.radIndividual.TabIndex = 1;
            this.radIndividual.Text = "Individual Branch";
            this.radIndividual.UseVisualStyleBackColor = true;
            this.radIndividual.Click += new System.EventHandler(this.radIndividual_Click);
            // 
            // radAll
            // 
            this.radAll.AutoSize = true;
            this.radAll.Checked = true;
            this.radAll.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAll.Location = new System.Drawing.Point(25, 18);
            this.radAll.Name = "radAll";
            this.radAll.Size = new System.Drawing.Size(86, 18);
            this.radAll.TabIndex = 0;
            this.radAll.TabStop = true;
            this.radAll.Text = "All Branch";
            this.radAll.UseVisualStyleBackColor = true;
            this.radAll.Click += new System.EventHandler(this.radAll_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtnProduction);
            this.groupBox2.Controls.Add(this.rbtnStationaryCons);
            this.groupBox2.Controls.Add(this.rbtnConversionFG);
            this.groupBox2.Controls.Add(this.rbtnstockTrnsferIN);
            this.groupBox2.Controls.Add(this.rbtnRequsition);
            this.groupBox2.Controls.Add(this.radStockAbsorved);
            this.groupBox2.Controls.Add(this.radPhysicalStock);
            this.groupBox2.Controls.Add(this.radStockTransfer);
            this.groupBox2.Controls.Add(this.radDamage);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(15, 230);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(530, 125);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Voucher Type ";
            // 
            // rbtnProduction
            // 
            this.rbtnProduction.AutoSize = true;
            this.rbtnProduction.Location = new System.Drawing.Point(161, 58);
            this.rbtnProduction.Name = "rbtnProduction";
            this.rbtnProduction.Size = new System.Drawing.Size(92, 18);
            this.rbtnProduction.TabIndex = 12;
            this.rbtnProduction.TabStop = true;
            this.rbtnProduction.Text = "Production";
            this.rbtnProduction.UseVisualStyleBackColor = true;
            // 
            // rbtnStationaryCons
            // 
            this.rbtnStationaryCons.AutoSize = true;
            this.rbtnStationaryCons.Location = new System.Drawing.Point(339, 88);
            this.rbtnStationaryCons.Name = "rbtnStationaryCons";
            this.rbtnStationaryCons.Size = new System.Drawing.Size(177, 18);
            this.rbtnStationaryCons.TabIndex = 11;
            this.rbtnStationaryCons.TabStop = true;
            this.rbtnStationaryCons.Text = "Stationary Consumption";
            this.rbtnStationaryCons.UseVisualStyleBackColor = true;
            // 
            // rbtnConversionFG
            // 
            this.rbtnConversionFG.AutoSize = true;
            this.rbtnConversionFG.Location = new System.Drawing.Point(339, 58);
            this.rbtnConversionFG.Name = "rbtnConversionFG";
            this.rbtnConversionFG.Size = new System.Drawing.Size(116, 18);
            this.rbtnConversionFG.TabIndex = 10;
            this.rbtnConversionFG.TabStop = true;
            this.rbtnConversionFG.Text = "Conversion FG";
            this.rbtnConversionFG.UseVisualStyleBackColor = true;
            // 
            // rbtnstockTrnsferIN
            // 
            this.rbtnstockTrnsferIN.AutoSize = true;
            this.rbtnstockTrnsferIN.Location = new System.Drawing.Point(339, 28);
            this.rbtnstockTrnsferIN.Name = "rbtnstockTrnsferIN";
            this.rbtnstockTrnsferIN.Size = new System.Drawing.Size(132, 18);
            this.rbtnstockTrnsferIN.TabIndex = 8;
            this.rbtnstockTrnsferIN.TabStop = true;
            this.rbtnstockTrnsferIN.Text = "Stock Transfer IN";
            this.rbtnstockTrnsferIN.UseVisualStyleBackColor = true;
            // 
            // rbtnRequsition
            // 
            this.rbtnRequsition.AutoSize = true;
            this.rbtnRequsition.Checked = true;
            this.rbtnRequsition.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnRequsition.Location = new System.Drawing.Point(9, 28);
            this.rbtnRequsition.Name = "rbtnRequsition";
            this.rbtnRequsition.Size = new System.Drawing.Size(132, 18);
            this.rbtnRequsition.TabIndex = 7;
            this.rbtnRequsition.TabStop = true;
            this.rbtnRequsition.Text = "Stock Requisition";
            this.rbtnRequsition.UseVisualStyleBackColor = true;
            // 
            // radStockAbsorved
            // 
            this.radStockAbsorved.AutoSize = true;
            this.radStockAbsorved.Location = new System.Drawing.Point(9, 58);
            this.radStockAbsorved.Name = "radStockAbsorved";
            this.radStockAbsorved.Size = new System.Drawing.Size(146, 18);
            this.radStockAbsorved.TabIndex = 4;
            this.radStockAbsorved.TabStop = true;
            this.radStockAbsorved.Text = "Stock Consumption";
            this.radStockAbsorved.UseVisualStyleBackColor = true;
            // 
            // radPhysicalStock
            // 
            this.radPhysicalStock.AutoSize = true;
            this.radPhysicalStock.Location = new System.Drawing.Point(161, 88);
            this.radPhysicalStock.Name = "radPhysicalStock";
            this.radPhysicalStock.Size = new System.Drawing.Size(113, 18);
            this.radPhysicalStock.TabIndex = 3;
            this.radPhysicalStock.TabStop = true;
            this.radPhysicalStock.Text = "Physical Stock";
            this.radPhysicalStock.UseVisualStyleBackColor = true;
            // 
            // radStockTransfer
            // 
            this.radStockTransfer.AutoSize = true;
            this.radStockTransfer.Location = new System.Drawing.Point(161, 28);
            this.radStockTransfer.Name = "radStockTransfer";
            this.radStockTransfer.Size = new System.Drawing.Size(141, 18);
            this.radStockTransfer.TabIndex = 2;
            this.radStockTransfer.TabStop = true;
            this.radStockTransfer.Text = "Stock Transfer Out";
            this.radStockTransfer.UseVisualStyleBackColor = true;
            // 
            // radDamage
            // 
            this.radDamage.AutoSize = true;
            this.radDamage.Checked = true;
            this.radDamage.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radDamage.Location = new System.Drawing.Point(9, 88);
            this.radDamage.Name = "radDamage";
            this.radDamage.Size = new System.Drawing.Size(115, 18);
            this.radDamage.TabIndex = 1;
            this.radDamage.TabStop = true;
            this.radDamage.Text = "Stock Damage";
            this.radDamage.UseVisualStyleBackColor = true;
            // 
            // rbtnMFGVoucher
            // 
            this.rbtnMFGVoucher.AutoSize = true;
            this.rbtnMFGVoucher.Location = new System.Drawing.Point(177, 9);
            this.rbtnMFGVoucher.Name = "rbtnMFGVoucher";
            this.rbtnMFGVoucher.Size = new System.Drawing.Size(102, 17);
            this.rbtnMFGVoucher.TabIndex = 9;
            this.rbtnMFGVoucher.TabStop = true;
            this.rbtnMFGVoucher.Text = "MFG Voucher";
            this.rbtnMFGVoucher.UseVisualStyleBackColor = true;
            this.rbtnMFGVoucher.Visible = false;
            // 
            // radManufacturing
            // 
            this.radManufacturing.AutoSize = true;
            this.radManufacturing.Location = new System.Drawing.Point(24, 8);
            this.radManufacturing.Name = "radManufacturing";
            this.radManufacturing.Size = new System.Drawing.Size(179, 17);
            this.radManufacturing.TabIndex = 6;
            this.radManufacturing.TabStop = true;
            this.radManufacturing.Text = "MFG Voucher (Batch Wise)";
            this.radManufacturing.UseVisualStyleBackColor = true;
            this.radManufacturing.Visible = false;
            // 
            // radFinishedGoods
            // 
            this.radFinishedGoods.AutoSize = true;
            this.radFinishedGoods.Location = new System.Drawing.Point(380, 147);
            this.radFinishedGoods.Name = "radFinishedGoods";
            this.radFinishedGoods.Size = new System.Drawing.Size(98, 17);
            this.radFinishedGoods.TabIndex = 5;
            this.radFinishedGoods.TabStop = true;
            this.radFinishedGoods.Text = "Finished Goods";
            this.radFinishedGoods.UseVisualStyleBackColor = true;
            this.radFinishedGoods.Visible = false;
            // 
            // radSalesSample
            // 
            this.radSalesSample.AutoSize = true;
            this.radSalesSample.Location = new System.Drawing.Point(81, 461);
            this.radSalesSample.Name = "radSalesSample";
            this.radSalesSample.Size = new System.Drawing.Size(89, 17);
            this.radSalesSample.TabIndex = 7;
            this.radSalesSample.TabStop = true;
            this.radSalesSample.Text = "Sales Sample";
            this.radSalesSample.UseVisualStyleBackColor = true;
            this.radSalesSample.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radSumm);
            this.groupBox3.Controls.Add(this.radDetails);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(26, 396);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(178, 86);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Report Option";
            // 
            // radSumm
            // 
            this.radSumm.AutoSize = true;
            this.radSumm.Location = new System.Drawing.Point(16, 53);
            this.radSumm.Name = "radSumm";
            this.radSumm.Size = new System.Drawing.Size(147, 18);
            this.radSumm.TabIndex = 3;
            this.radSumm.TabStop = true;
            this.radSumm.Text = "ItemWise Summary";
            this.radSumm.UseVisualStyleBackColor = true;
            // 
            // radDetails
            // 
            this.radDetails.AutoSize = true;
            this.radDetails.Checked = true;
            this.radDetails.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radDetails.Location = new System.Drawing.Point(16, 25);
            this.radDetails.Name = "radDetails";
            this.radDetails.Size = new System.Drawing.Size(132, 18);
            this.radDetails.TabIndex = 2;
            this.radDetails.TabStop = true;
            this.radDetails.Text = "ItemWise Details";
            this.radDetails.UseVisualStyleBackColor = true;
            // 
            // cboLocation
            // 
            this.cboLocation.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLocation.FormattingEnabled = true;
            this.cboLocation.Location = new System.Drawing.Point(196, 208);
            this.cboLocation.Name = "cboLocation";
            this.cboLocation.Size = new System.Drawing.Size(351, 22);
            this.cboLocation.TabIndex = 36;
          
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(196, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 16);
            this.label3.TabIndex = 37;
            this.label3.Text = "Location Name:";
            // 
            // frmRptVoucherReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(570, 479);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmRptVoucherReports";
            this.Load += new System.EventHandler(this.frmRptVoucherReports_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox uctxtBranchName;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dteToDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dteFromDate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radIndividual;
        private System.Windows.Forms.RadioButton radAll;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radSumm;
        private System.Windows.Forms.RadioButton radDetails;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radManufacturing;
        private System.Windows.Forms.RadioButton radFinishedGoods;
        private System.Windows.Forms.RadioButton radStockAbsorved;
        private System.Windows.Forms.RadioButton radPhysicalStock;
        private System.Windows.Forms.RadioButton radStockTransfer;
        private System.Windows.Forms.RadioButton radDamage;
        private System.Windows.Forms.RadioButton radSalesSample;
        private System.Windows.Forms.RadioButton rbtnStationaryCons;
        private System.Windows.Forms.RadioButton rbtnConversionFG;
        private System.Windows.Forms.RadioButton rbtnMFGVoucher;
        private System.Windows.Forms.RadioButton rbtnstockTrnsferIN;
        private System.Windows.Forms.RadioButton rbtnRequsition;
        private System.Windows.Forms.RadioButton rbtnProduction;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboLocation;
    }
}
