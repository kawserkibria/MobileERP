namespace JA.Modulecontrolar.UI.DReport.Inventory.ParameterForms
{
    partial class frmRptBOMList
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
            this.uctxtName = new System.Windows.Forms.TextBox();
            this.pnlSelection = new System.Windows.Forms.Panel();
            this.radWithoutAlias = new System.Windows.Forms.RadioButton();
            this.radOnlyAlias = new System.Windows.Forms.RadioButton();
            this.radWithAlias = new System.Windows.Forms.RadioButton();
            this.chkstockrequisition = new System.Windows.Forms.CheckBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(168, 9);
            this.frmLabel.Size = new System.Drawing.Size(119, 33);
            this.frmLabel.Text = "BOM List";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.chkstockrequisition);
            this.pnlMain.Controls.Add(this.pnlSelection);
            this.pnlMain.Controls.Add(this.uctxtName);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Location = new System.Drawing.Point(0, -86);
            this.pnlMain.Size = new System.Drawing.Size(450, 407);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(454, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(114, 360);
            this.btnEdit.Size = new System.Drawing.Size(10, 10);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(-2, 280);
            this.btnSave.Size = new System.Drawing.Size(20, 10);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(157, 360);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(30, 276);
            this.btnNew.Size = new System.Drawing.Size(10, 10);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(338, 328);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(202, 328);
            this.btnPrint.Size = new System.Drawing.Size(133, 39);
            this.btnPrint.Text = "Preview";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 371);
            this.groupBox1.Size = new System.Drawing.Size(454, 25);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(6, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "Process Name:";
            // 
            // uctxtName
            // 
            this.uctxtName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtName.Location = new System.Drawing.Point(117, 240);
            this.uctxtName.Name = "uctxtName";
            this.uctxtName.Size = new System.Drawing.Size(277, 22);
            this.uctxtName.TabIndex = 22;
            // 
            // pnlSelection
            // 
            this.pnlSelection.Controls.Add(this.radWithoutAlias);
            this.pnlSelection.Controls.Add(this.radOnlyAlias);
            this.pnlSelection.Controls.Add(this.radWithAlias);
            this.pnlSelection.Location = new System.Drawing.Point(42, 152);
            this.pnlSelection.Name = "pnlSelection";
            this.pnlSelection.Size = new System.Drawing.Size(383, 52);
            this.pnlSelection.TabIndex = 23;
            // 
            // radWithoutAlias
            // 
            this.radWithoutAlias.AutoSize = true;
            this.radWithoutAlias.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radWithoutAlias.Location = new System.Drawing.Point(257, 11);
            this.radWithoutAlias.Name = "radWithoutAlias";
            this.radWithoutAlias.Size = new System.Drawing.Size(112, 18);
            this.radWithoutAlias.TabIndex = 2;
            this.radWithoutAlias.Text = "Without Code";
            this.radWithoutAlias.UseVisualStyleBackColor = true;
            // 
            // radOnlyAlias
            // 
            this.radOnlyAlias.AutoSize = true;
            this.radOnlyAlias.Checked = true;
            this.radOnlyAlias.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radOnlyAlias.Location = new System.Drawing.Point(22, 11);
            this.radOnlyAlias.Name = "radOnlyAlias";
            this.radOnlyAlias.Size = new System.Drawing.Size(90, 18);
            this.radOnlyAlias.TabIndex = 1;
            this.radOnlyAlias.TabStop = true;
            this.radOnlyAlias.Text = "Only Code";
            this.radOnlyAlias.UseVisualStyleBackColor = true;
            // 
            // radWithAlias
            // 
            this.radWithAlias.AutoSize = true;
            this.radWithAlias.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radWithAlias.Location = new System.Drawing.Point(143, 11);
            this.radWithAlias.Name = "radWithAlias";
            this.radWithAlias.Size = new System.Drawing.Size(91, 18);
            this.radWithAlias.TabIndex = 0;
            this.radWithAlias.Text = "With Code";
            this.radWithAlias.UseVisualStyleBackColor = true;
            // 
            // chkstockrequisition
            // 
            this.chkstockrequisition.AutoSize = true;
            this.chkstockrequisition.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkstockrequisition.Location = new System.Drawing.Point(299, 213);
            this.chkstockrequisition.Name = "chkstockrequisition";
            this.chkstockrequisition.Size = new System.Drawing.Size(98, 17);
            this.chkstockrequisition.TabIndex = 24;
            this.chkstockrequisition.Text = "MFG Process";
            this.chkstockrequisition.UseVisualStyleBackColor = true;
            this.chkstockrequisition.Click += new System.EventHandler(this.chkstockrequisition_Click);
            // 
            // frmRptBOMList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(454, 396);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmRptBOMList";
            this.Load += new System.EventHandler(this.frmRptBOMList_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlSelection.ResumeLayout(false);
            this.pnlSelection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox uctxtName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlSelection;
        private System.Windows.Forms.RadioButton radWithoutAlias;
        private System.Windows.Forms.RadioButton radOnlyAlias;
        private System.Windows.Forms.RadioButton radWithAlias;
        private System.Windows.Forms.CheckBox chkstockrequisition;

    }
}
