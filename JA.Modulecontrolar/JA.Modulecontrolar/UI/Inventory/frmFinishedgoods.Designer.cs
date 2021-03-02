namespace JA.Modulecontrolar.UI.Inventory
{
    partial class frmFinishedgoods
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
            this.label5 = new System.Windows.Forms.Label();
            this.uctxtInvoiceNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.uctxtBranchName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.uctxtLocation = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.uctxtBatch = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.uctxtProcessName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.uctxtCosting = new System.Windows.Forms.TextBox();
            this.dteDate = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.uctxtRate = new System.Windows.Forms.TextBox();
            this.btnDown = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.uctxtQty = new System.Windows.Forms.TextBox();
            this.DG = new MayhediDataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.uctxtItemName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.uctxtNarration = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.label14);
            this.pnlMain.Controls.Add(this.textBox1);
            this.pnlMain.Controls.Add(this.label13);
            this.pnlMain.Controls.Add(this.uctxtNarration);
            this.pnlMain.Controls.Add(this.panel2);
            this.pnlMain.Controls.Add(this.dteDate);
            this.pnlMain.Controls.Add(this.label9);
            this.pnlMain.Controls.Add(this.uctxtCosting);
            this.pnlMain.Controls.Add(this.label8);
            this.pnlMain.Controls.Add(this.uctxtProcessName);
            this.pnlMain.Controls.Add(this.label6);
            this.pnlMain.Controls.Add(this.uctxtBatch);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.uctxtLocation);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.uctxtBranchName);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.uctxtInvoiceNo);
            this.pnlMain.Size = new System.Drawing.Size(863, 753);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(412, 671);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(299, 671);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(525, 671);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(186, 671);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(747, 671);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(636, 671);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 714);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(209, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 16);
            this.label5.TabIndex = 50;
            this.label5.Text = "Invoice No:";
            // 
            // uctxtInvoiceNo
            // 
            this.uctxtInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtInvoiceNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtInvoiceNo.Location = new System.Drawing.Point(298, 155);
            this.uctxtInvoiceNo.Name = "uctxtInvoiceNo";
            this.uctxtInvoiceNo.Size = new System.Drawing.Size(377, 23);
            this.uctxtInvoiceNo.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(248, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 52;
            this.label1.Text = "Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(193, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 54;
            this.label3.Text = "Branch Name:";
            // 
            // uctxtBranchName
            // 
            this.uctxtBranchName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtBranchName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtBranchName.Location = new System.Drawing.Point(298, 203);
            this.uctxtBranchName.Name = "uctxtBranchName";
            this.uctxtBranchName.Size = new System.Drawing.Size(377, 23);
            this.uctxtBranchName.TabIndex = 53;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(182, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 16);
            this.label4.TabIndex = 56;
            this.label4.Text = "Location Name:";
            // 
            // uctxtLocation
            // 
            this.uctxtLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtLocation.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtLocation.Location = new System.Drawing.Point(298, 227);
            this.uctxtLocation.Name = "uctxtLocation";
            this.uctxtLocation.Size = new System.Drawing.Size(377, 23);
            this.uctxtLocation.TabIndex = 55;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(219, 252);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 16);
            this.label6.TabIndex = 58;
            this.label6.Text = "Batch No:";
            // 
            // uctxtBatch
            // 
            this.uctxtBatch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtBatch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtBatch.Location = new System.Drawing.Point(298, 251);
            this.uctxtBatch.Name = "uctxtBatch";
            this.uctxtBatch.Size = new System.Drawing.Size(377, 23);
            this.uctxtBatch.TabIndex = 57;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(148, 277);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 16);
            this.label8.TabIndex = 60;
            this.label8.Text = "Process Information:";
            // 
            // uctxtProcessName
            // 
            this.uctxtProcessName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtProcessName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtProcessName.Location = new System.Drawing.Point(298, 275);
            this.uctxtProcessName.Name = "uctxtProcessName";
            this.uctxtProcessName.Size = new System.Drawing.Size(377, 23);
            this.uctxtProcessName.TabIndex = 59;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(230, 301);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 16);
            this.label9.TabIndex = 62;
            this.label9.Text = "Costing:";
            // 
            // uctxtCosting
            // 
            this.uctxtCosting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtCosting.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtCosting.Location = new System.Drawing.Point(298, 299);
            this.uctxtCosting.Name = "uctxtCosting";
            this.uctxtCosting.Size = new System.Drawing.Size(377, 23);
            this.uctxtCosting.TabIndex = 61;
            // 
            // dteDate
            // 
            this.dteDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteDate.Location = new System.Drawing.Point(298, 179);
            this.dteDate.Name = "dteDate";
            this.dteDate.Size = new System.Drawing.Size(144, 23);
            this.dteDate.TabIndex = 88;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.uctxtRate);
            this.panel2.Controls.Add(this.btnDown);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.uctxtQty);
            this.panel2.Controls.Add(this.DG);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.uctxtItemName);
            this.panel2.Location = new System.Drawing.Point(3, 375);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(855, 298);
            this.panel2.TabIndex = 89;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(774, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 18);
            this.label10.TabIndex = 71;
            this.label10.Text = "Rate";
            // 
            // uctxtRate
            // 
            this.uctxtRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtRate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtRate.Location = new System.Drawing.Point(684, 24);
            this.uctxtRate.Name = "uctxtRate";
            this.uctxtRate.Size = new System.Drawing.Size(135, 23);
            this.uctxtRate.TabIndex = 70;
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
            this.label11.Location = new System.Drawing.Point(550, 3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 18);
            this.label11.TabIndex = 60;
            this.label11.Text = "Qty";
            // 
            // uctxtQty
            // 
            this.uctxtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtQty.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtQty.Location = new System.Drawing.Point(549, 24);
            this.uctxtQty.Name = "uctxtQty";
            this.uctxtQty.Size = new System.Drawing.Size(135, 23);
            this.uctxtQty.TabIndex = 59;
            // 
            // DG
            // 
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG.Location = new System.Drawing.Point(3, 49);
            this.DG.Name = "DG";
            this.DG.Size = new System.Drawing.Size(842, 229);
            this.DG.TabIndex = 58;
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
            this.uctxtItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtItemName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtItemName.Location = new System.Drawing.Point(2, 24);
            this.uctxtItemName.Name = "uctxtItemName";
            this.uctxtItemName.Size = new System.Drawing.Size(547, 23);
            this.uctxtItemName.TabIndex = 56;
            this.uctxtItemName.Text = "*****Press F3*****";
            this.uctxtItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(217, 682);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 16);
            this.label13.TabIndex = 91;
            this.label13.Text = "Narration:";
            // 
            // uctxtNarration
            // 
            this.uctxtNarration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtNarration.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtNarration.Location = new System.Drawing.Point(298, 679);
            this.uctxtNarration.Name = "uctxtNarration";
            this.uctxtNarration.Size = new System.Drawing.Size(377, 23);
            this.uctxtNarration.TabIndex = 90;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(186, 326);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(105, 16);
            this.label14.TabIndex = 93;
            this.label14.Text = "Section Name:";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(297, 324);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(377, 23);
            this.textBox1.TabIndex = 92;
            // 
            // frmFinishedgoods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(864, 739);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.Name = "frmFinishedgoods";
            this.Load += new System.EventHandler(this.frmFinishedgoods_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox uctxtBatch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox uctxtLocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uctxtBranchName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox uctxtInvoiceNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox uctxtCosting;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox uctxtProcessName;
        private System.Windows.Forms.DateTimePicker dteDate;
        private System.Windows.Forms.Label label13;
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
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox1;

    }
}
