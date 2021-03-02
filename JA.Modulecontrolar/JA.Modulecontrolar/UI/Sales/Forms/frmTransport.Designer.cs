namespace JA.Modulecontrolar.UI.Sales.Forms
{
    partial class frmTransport
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
            this.txtTransportName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uctxtOldTransport = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(142, 6);
            this.frmLabel.Size = new System.Drawing.Size(131, 33);
            this.frmLabel.Text = "Transport";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.txtTransportName);
            this.pnlMain.Location = new System.Drawing.Point(1, 58);
            this.pnlMain.Size = new System.Drawing.Size(451, 97);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.uctxtOldTransport);
            this.pnlTop.Size = new System.Drawing.Size(453, 58);
            this.pnlTop.Controls.SetChildIndex(this.frmLabel, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnTopClose, 0);
            this.pnlTop.Controls.SetChildIndex(this.uctxtOldTransport, 0);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(6, 159);
            this.btnEdit.Size = new System.Drawing.Size(118, 39);
            this.btnEdit.Text = "List All";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(224, 161);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(165, 161);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(142, 161);
            this.btnNew.Size = new System.Drawing.Size(10, 10);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(336, 161);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(184, 161);
            this.btnPrint.Size = new System.Drawing.Size(10, 10);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 204);
            this.groupBox1.Size = new System.Drawing.Size(453, 25);
            // 
            // txtTransportName
            // 
            this.txtTransportName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTransportName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransportName.Location = new System.Drawing.Point(36, 38);
            this.txtTransportName.MaxLength = 60;
            this.txtTransportName.Name = "txtTransportName";
            this.txtTransportName.Size = new System.Drawing.Size(387, 23);
            this.txtTransportName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Transport Name :";
            // 
            // uctxtOldTransport
            // 
            this.uctxtOldTransport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtOldTransport.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtOldTransport.Location = new System.Drawing.Point(33, 18);
            this.uctxtOldTransport.Name = "uctxtOldTransport";
            this.uctxtOldTransport.Size = new System.Drawing.Size(49, 23);
            this.uctxtOldTransport.TabIndex = 15;
            this.uctxtOldTransport.Visible = false;
            // 
            // frmTransport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(453, 229);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmTransport";
            this.Load += new System.EventHandler(this.frmTransport_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtTransportName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uctxtOldTransport;
    }
}
