namespace JA.Modulecontrolar.UI.Inventory
{
    partial class frmAllItem
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
            this.uctxtItemName = new System.Windows.Forms.TextBox();
            this.DG = new MayhediDataGridView();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).BeginInit();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(58, 3);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.DG);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.uctxtItemName);
            this.pnlMain.Size = new System.Drawing.Size(761, 680);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(762, 10);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(231, 553);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(118, 553);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(344, 553);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(5, 553);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(76, 536);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(230, 551);
            // 
            // groupBox1
            // 
            this.groupBox1.Size = new System.Drawing.Size(762, 25);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 18);
            this.label5.TabIndex = 52;
            this.label5.Text = "Name:";
            // 
            // uctxtItemName
            // 
            this.uctxtItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtItemName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtItemName.Location = new System.Drawing.Point(75, 106);
            this.uctxtItemName.Name = "uctxtItemName";
            this.uctxtItemName.Size = new System.Drawing.Size(677, 23);
            this.uctxtItemName.TabIndex = 51;
            this.uctxtItemName.TextChanged += new System.EventHandler(this.uctxtItemName_TextChanged);
            this.uctxtItemName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uctxtItemName_KeyUp);
            // 
            // DG
            // 
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG.Location = new System.Drawing.Point(4, 135);
            this.DG.Name = "DG";
            this.DG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DG.Size = new System.Drawing.Size(752, 496);
            this.DG.TabIndex = 54;
            this.DG.DoubleClick += new System.EventHandler(this.DG_DoubleClick);
            // 
            // frmAllItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(762, 623);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.Name = "frmAllItem";
            this.Text = "Item Search";
            this.Load += new System.EventHandler(this.frmAllItem_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox uctxtItemName;
        private MayhediDataGridView DG;
    }
}
