namespace JA.Modulecontrolar.UI.DReport.Inventory.ParameterForms
{
    partial class frmRptMFGProcess
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
            this.uctxtQty = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lvwProcess = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.btnRowDelete = new System.Windows.Forms.Button();
            this.chkStockRequisition = new System.Windows.Forms.CheckBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(91, 7);
            this.frmLabel.Size = new System.Drawing.Size(254, 33);
            this.frmLabel.Text = "MFG Process Report";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.chkStockRequisition);
            this.pnlMain.Controls.Add(this.btnRowDelete);
            this.pnlMain.Controls.Add(this.lvwProcess);
            this.pnlMain.Controls.Add(this.uctxtQty);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.uctxtName);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Location = new System.Drawing.Point(0, -86);
            this.pnlMain.Size = new System.Drawing.Size(427, 407);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(432, 58);
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
            this.btnClose.Location = new System.Drawing.Point(319, 328);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(183, 328);
            this.btnPrint.Size = new System.Drawing.Size(133, 39);
            this.btnPrint.Text = "Preview";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 380);
            this.groupBox1.Size = new System.Drawing.Size(432, 25);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(42, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "Name:";
            // 
            // uctxtName
            // 
            this.uctxtName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtName.Location = new System.Drawing.Point(98, 158);
            this.uctxtName.Name = "uctxtName";
            this.uctxtName.Size = new System.Drawing.Size(277, 22);
            this.uctxtName.TabIndex = 22;
            // 
            // uctxtQty
            // 
            this.uctxtQty.Location = new System.Drawing.Point(98, 181);
            this.uctxtQty.Name = "uctxtQty";
            this.uctxtQty.Size = new System.Drawing.Size(91, 20);
            this.uctxtQty.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(53, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "Qty:";
            // 
            // lvwProcess
            // 
            this.lvwProcess.BackColor = System.Drawing.SystemColors.Info;
            this.lvwProcess.CheckBoxes = true;
            this.lvwProcess.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvwProcess.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwProcess.FullRowSelect = true;
            this.lvwProcess.Location = new System.Drawing.Point(7, 208);
            this.lvwProcess.Name = "lvwProcess";
            this.lvwProcess.Size = new System.Drawing.Size(408, 189);
            this.lvwProcess.TabIndex = 25;
            this.lvwProcess.UseCompatibleStateImageBehavior = false;
            this.lvwProcess.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Process Name";
            this.columnHeader1.Width = 300;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "QTY.";
            this.columnHeader2.Width = 100;
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSelectAll.Location = new System.Drawing.Point(6, 328);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(82, 18);
            this.chkSelectAll.TabIndex = 15;
            this.chkSelectAll.Text = "Select All";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.Click += new System.EventHandler(this.chkSelectAll_Click);
            // 
            // btnRowDelete
            // 
            this.btnRowDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnRowDelete.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRowDelete.Location = new System.Drawing.Point(317, 184);
            this.btnRowDelete.Name = "btnRowDelete";
            this.btnRowDelete.Size = new System.Drawing.Size(91, 23);
            this.btnRowDelete.TabIndex = 26;
            this.btnRowDelete.Text = "Delete Row";
            this.btnRowDelete.UseVisualStyleBackColor = false;
            this.btnRowDelete.Click += new System.EventHandler(this.btnRowDelete_Click_1);
            // 
            // chkStockRequisition
            // 
            this.chkStockRequisition.AutoSize = true;
            this.chkStockRequisition.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkStockRequisition.Location = new System.Drawing.Point(196, 184);
            this.chkStockRequisition.Name = "chkStockRequisition";
            this.chkStockRequisition.Size = new System.Drawing.Size(98, 17);
            this.chkStockRequisition.TabIndex = 27;
            this.chkStockRequisition.Text = "MFG Process";
            this.chkStockRequisition.UseVisualStyleBackColor = true;
            this.chkStockRequisition.CheckedChanged += new System.EventHandler(this.chkStockRequisition_CheckedChanged);
            this.chkStockRequisition.Click += new System.EventHandler(this.chkStockRequisition_Click);
            // 
            // frmRptMFGProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(432, 405);
            this.Controls.Add(this.chkSelectAll);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmRptMFGProcess";
            this.Load += new System.EventHandler(this.frmRptProduct_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.pnlMain, 0);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.Controls.SetChildIndex(this.chkSelectAll, 0);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwProcess;
        private System.Windows.Forms.TextBox uctxtQty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uctxtName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.Button btnRowDelete;
        private System.Windows.Forms.CheckBox chkStockRequisition;

    }
}
