namespace JA.Modulecontrolar.UI.Sales.Forms
{
    partial class frmPriceLevel
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
            this.DG = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLevelName = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).BeginInit();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(193, 9);
            this.frmLabel.Size = new System.Drawing.Size(140, 33);
            this.frmLabel.Text = "Price Level";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.DG);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.txtLevelName);
            this.pnlMain.Size = new System.Drawing.Size(522, 539);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(522, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(29, 402);
            this.btnEdit.Size = new System.Drawing.Size(10, 5);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(297, 455);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(142, 402);
            this.btnDelete.Size = new System.Drawing.Size(10, 5);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(3, 455);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(411, 455);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(253, 402);
            this.btnPrint.Size = new System.Drawing.Size(10, 5);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 499);
            this.groupBox1.Size = new System.Drawing.Size(522, 25);
            // 
            // DG
            // 
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG.Location = new System.Drawing.Point(4, 185);
            this.DG.Name = "DG";
            this.DG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DG.Size = new System.Drawing.Size(511, 347);
            this.DG.TabIndex = 51;
            this.DG.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellContentClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 18);
            this.label5.TabIndex = 50;
            this.label5.Text = "Name:";
            // 
            // txtLevelName
            // 
            this.txtLevelName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLevelName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLevelName.Location = new System.Drawing.Point(78, 156);
            this.txtLevelName.Name = "txtLevelName";
            this.txtLevelName.Size = new System.Drawing.Size(393, 23);
            this.txtLevelName.TabIndex = 49;
            // 
            // frmPriceLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(522, 524);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmPriceLevel";
            this.Load += new System.EventHandler(this.frmPriceLevel_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DG;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLevelName;
    }
}
