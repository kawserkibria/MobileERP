﻿namespace JA.Modulecontrolar.UI.Sales.Forms
{
    partial class frmDeliveryRoute
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
            this.uctxtOldDeliveryRoute = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDeliveryRoute = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(142, 9);
            this.frmLabel.Size = new System.Drawing.Size(187, 33);
            this.frmLabel.Text = "Delivery Route";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.txtDeliveryRoute);
            this.pnlMain.Location = new System.Drawing.Point(1, 58);
            this.pnlMain.Size = new System.Drawing.Size(451, 97);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.uctxtOldDeliveryRoute);
            this.pnlTop.Size = new System.Drawing.Size(453, 58);
            this.pnlTop.Controls.SetChildIndex(this.frmLabel, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnTopClose, 0);
            this.pnlTop.Controls.SetChildIndex(this.uctxtOldDeliveryRoute, 0);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(2, 161);
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
            this.btnDelete.Location = new System.Drawing.Point(174, 162);
            this.btnDelete.Size = new System.Drawing.Size(10, 9);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(159, 162);
            this.btnNew.Size = new System.Drawing.Size(10, 10);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(336, 161);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(198, 162);
            this.btnPrint.Size = new System.Drawing.Size(10, 12);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 204);
            this.groupBox1.Size = new System.Drawing.Size(453, 25);
            // 
            // uctxtOldDeliveryRoute
            // 
            this.uctxtOldDeliveryRoute.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtOldDeliveryRoute.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtOldDeliveryRoute.Location = new System.Drawing.Point(34, 9);
            this.uctxtOldDeliveryRoute.Name = "uctxtOldDeliveryRoute";
            this.uctxtOldDeliveryRoute.Size = new System.Drawing.Size(49, 23);
            this.uctxtOldDeliveryRoute.TabIndex = 18;
            this.uctxtOldDeliveryRoute.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 14);
            this.label1.TabIndex = 17;
            this.label1.Text = "Route Name";
            // 
            // txtDeliveryRoute
            // 
            this.txtDeliveryRoute.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeliveryRoute.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeliveryRoute.Location = new System.Drawing.Point(32, 47);
            this.txtDeliveryRoute.MaxLength = 60;
            this.txtDeliveryRoute.Name = "txtDeliveryRoute";
            this.txtDeliveryRoute.Size = new System.Drawing.Size(387, 23);
            this.txtDeliveryRoute.TabIndex = 16;
            // 
            // frmDeliveryRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(453, 229);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmDeliveryRoute";
            this.Load += new System.EventHandler(this.frmDeliveryRoute_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDeliveryRoute;
        private System.Windows.Forms.TextBox uctxtOldDeliveryRoute;

    }
}
