namespace JA.Modulecontrolar.UI.Master.Inventory
{
    partial class frmMeasurementUnit
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
            this.uctxtSymbol = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uctxtFormalName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.uctxtNoofDecimalPlaces = new System.Windows.Forms.TextBox();
            this.txtSlNo = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).BeginInit();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(238, 7);
            this.frmLabel.Size = new System.Drawing.Size(232, 33);
            this.frmLabel.Text = "Measurement Unit";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.uctxtNoofDecimalPlaces);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.uctxtFormalName);
            this.pnlMain.Controls.Add(this.DG);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.uctxtSymbol);
            this.pnlMain.Size = new System.Drawing.Size(665, 578);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.txtSlNo);
            this.pnlTop.Size = new System.Drawing.Size(667, 58);
            this.pnlTop.Controls.SetChildIndex(this.frmLabel, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnTopClose, 0);
            this.pnlTop.Controls.SetChildIndex(this.txtSlNo, 0);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(329, 155);
            this.btnEdit.Size = new System.Drawing.Size(10, 11);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(438, 494);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(442, 155);
            this.btnDelete.Size = new System.Drawing.Size(10, 11);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(12, 494);
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(552, 494);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(553, 155);
            this.btnPrint.Size = new System.Drawing.Size(10, 11);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 534);
            this.groupBox1.Size = new System.Drawing.Size(667, 25);
            // 
            // DG
            // 
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG.Location = new System.Drawing.Point(5, 241);
            this.DG.Name = "DG";
            this.DG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DG.Size = new System.Drawing.Size(655, 333);
            this.DG.TabIndex = 45;
            this.DG.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellClick);
            this.DG.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellContentClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(135, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 18);
            this.label5.TabIndex = 44;
            this.label5.Text = "Symbol:";
            // 
            // uctxtSymbol
            // 
            this.uctxtSymbol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtSymbol.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtSymbol.Location = new System.Drawing.Point(211, 161);
            this.uctxtSymbol.MaxLength = 10;
            this.uctxtSymbol.Name = "uctxtSymbol";
            this.uctxtSymbol.Size = new System.Drawing.Size(248, 23);
            this.uctxtSymbol.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(91, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 18);
            this.label1.TabIndex = 47;
            this.label1.Text = "Formal Name:";
            // 
            // uctxtFormalName
            // 
            this.uctxtFormalName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtFormalName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtFormalName.Location = new System.Drawing.Point(211, 187);
            this.uctxtFormalName.MaxLength = 20;
            this.uctxtFormalName.Name = "uctxtFormalName";
            this.uctxtFormalName.Size = new System.Drawing.Size(248, 23);
            this.uctxtFormalName.TabIndex = 46;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 18);
            this.label3.TabIndex = 49;
            this.label3.Text = "No of Decimal Palces:";
            // 
            // uctxtNoofDecimalPlaces
            // 
            this.uctxtNoofDecimalPlaces.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtNoofDecimalPlaces.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtNoofDecimalPlaces.Location = new System.Drawing.Point(211, 212);
            this.uctxtNoofDecimalPlaces.Name = "uctxtNoofDecimalPlaces";
            this.uctxtNoofDecimalPlaces.Size = new System.Drawing.Size(248, 23);
            this.uctxtNoofDecimalPlaces.TabIndex = 48;
            // 
            // txtSlNo
            // 
            this.txtSlNo.Location = new System.Drawing.Point(33, 12);
            this.txtSlNo.Name = "txtSlNo";
            this.txtSlNo.Size = new System.Drawing.Size(87, 20);
            this.txtSlNo.TabIndex = 17;
            this.txtSlNo.Visible = false;
            // 
            // frmMeasurementUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(667, 559);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmMeasurementUnit";
            this.Load += new System.EventHandler(this.frmMeasurementUnit_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uctxtFormalName;
        private System.Windows.Forms.DataGridView DG;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox uctxtSymbol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uctxtNoofDecimalPlaces;
        private System.Windows.Forms.TextBox txtSlNo;

    }
}
