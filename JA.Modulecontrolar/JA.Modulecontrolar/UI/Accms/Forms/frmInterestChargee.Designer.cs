namespace JA.Modulecontrolar.UI.Accms.Forms
{
    partial class frmInterestChargee
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
            this.pnlFixedAssets = new System.Windows.Forms.Panel();
            this.dteToDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInterestR = new System.Windows.Forms.TextBox();
            this.dteEffectform = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.txtCreditLedger = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlFixedAssets.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(165, 7);
            this.frmLabel.Size = new System.Drawing.Size(200, 33);
            this.frmLabel.Text = "Interest Charge";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlFixedAssets);
            this.pnlMain.Size = new System.Drawing.Size(507, 309);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(511, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(8, 228);
            this.btnEdit.Size = new System.Drawing.Size(44, 6);
            this.btnEdit.Text = "List All";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(243, 226);
            this.btnSave.Size = new System.Drawing.Size(128, 39);
            this.btnSave.Text = "Apply";
            this.btnSave.Visible = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(5, -2);
            this.btnDelete.Size = new System.Drawing.Size(10, 22);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(60, 228);
            this.btnNew.Size = new System.Drawing.Size(14, 10);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(377, 228);
            this.btnClose.Size = new System.Drawing.Size(128, 39);
            this.btnClose.Visible = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(116, -2);
            this.btnPrint.Size = new System.Drawing.Size(12, 10);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 269);
            this.groupBox1.Size = new System.Drawing.Size(511, 25);
            // 
            // pnlFixedAssets
            // 
            this.pnlFixedAssets.BackColor = System.Drawing.Color.Beige;
            this.pnlFixedAssets.Controls.Add(this.dteToDate);
            this.pnlFixedAssets.Controls.Add(this.label1);
            this.pnlFixedAssets.Controls.Add(this.txtInterestR);
            this.pnlFixedAssets.Controls.Add(this.dteEffectform);
            this.pnlFixedAssets.Controls.Add(this.label16);
            this.pnlFixedAssets.Controls.Add(this.txtCreditLedger);
            this.pnlFixedAssets.Controls.Add(this.label9);
            this.pnlFixedAssets.Controls.Add(this.label3);
            this.pnlFixedAssets.Location = new System.Drawing.Point(5, 149);
            this.pnlFixedAssets.Name = "pnlFixedAssets";
            this.pnlFixedAssets.Size = new System.Drawing.Size(495, 147);
            this.pnlFixedAssets.TabIndex = 69;
            // 
            // dteToDate
            // 
            this.dteToDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteToDate.Location = new System.Drawing.Point(148, 72);
            this.dteToDate.Name = "dteToDate";
            this.dteToDate.Size = new System.Drawing.Size(142, 22);
            this.dteToDate.TabIndex = 74;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(69, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 73;
            this.label1.Text = "To Date :";
            // 
            // txtInterestR
            // 
            this.txtInterestR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInterestR.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInterestR.Location = new System.Drawing.Point(147, 100);
            this.txtInterestR.Name = "txtInterestR";
            this.txtInterestR.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInterestR.Size = new System.Drawing.Size(143, 22);
            this.txtInterestR.TabIndex = 61;
            // 
            // dteEffectform
            // 
            this.dteEffectform.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteEffectform.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteEffectform.Location = new System.Drawing.Point(147, 44);
            this.dteEffectform.Name = "dteEffectform";
            this.dteEffectform.Size = new System.Drawing.Size(142, 22);
            this.dteEffectform.TabIndex = 58;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(33, 100);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(107, 16);
            this.label16.TabIndex = 53;
            this.label16.Text = "Interest Rate :";
            // 
            // txtCreditLedger
            // 
            this.txtCreditLedger.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCreditLedger.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreditLedger.Location = new System.Drawing.Point(148, 14);
            this.txtCreditLedger.Name = "txtCreditLedger";
            this.txtCreditLedger.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCreditLedger.Size = new System.Drawing.Size(332, 22);
            this.txtCreditLedger.TabIndex = 52;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(54, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 16);
            this.label9.TabIndex = 45;
            this.label9.Text = "From Date :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 16);
            this.label3.TabIndex = 40;
            this.label3.Text = "Credit Ledger :";
            // 
            // frmInterestChargee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(511, 294);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmInterestChargee";
            this.Load += new System.EventHandler(this.frmInterestChargee_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlFixedAssets.ResumeLayout(false);
            this.pnlFixedAssets.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFixedAssets;
        private System.Windows.Forms.DateTimePicker dteEffectform;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtCreditLedger;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dteToDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInterestR;
    }
}
