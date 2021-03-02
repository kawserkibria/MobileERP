namespace JA.Modulecontrolar.UI.Forms
{
    partial class frmGroupConfiguration
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
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAccountsType = new System.Windows.Forms.TextBox();
            this.txtUnder = new System.Windows.Forms.TextBox();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.txtCashFlowType = new System.Windows.Forms.TextBox();
            this.txtSlNo = new System.Windows.Forms.TextBox();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.txtConatctNo = new System.Windows.Forms.TextBox();
            this.lblMobileNo = new System.Windows.Forms.Label();
            this.lblContactNo = new System.Windows.Forms.Label();
            this.lblSorting = new System.Windows.Forms.Label();
            this.txtSortingPos = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(142, 9);
            this.frmLabel.Size = new System.Drawing.Size(256, 33);
            this.frmLabel.Text = "Group Configuration";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.lblSorting);
            this.pnlMain.Controls.Add(this.lblContactNo);
            this.pnlMain.Controls.Add(this.lblMobileNo);
            this.pnlMain.Controls.Add(this.txtSortingPos);
            this.pnlMain.Controls.Add(this.txtConatctNo);
            this.pnlMain.Controls.Add(this.txtMobileNo);
            this.pnlMain.Controls.Add(this.txtSlNo);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.txtAccountsType);
            this.pnlMain.Controls.Add(this.txtUnder);
            this.pnlMain.Controls.Add(this.txtGroupName);
            this.pnlMain.Controls.Add(this.txtCashFlowType);
            this.pnlMain.Size = new System.Drawing.Size(533, 409);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(534, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(120, 332);
            this.btnEdit.Size = new System.Drawing.Size(139, 39);
            this.btnEdit.Text = "Tree View";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(312, 332);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(120, 275);
            this.btnDelete.Size = new System.Drawing.Size(12, 14);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(4, 332);
            this.btnNew.Size = new System.Drawing.Size(113, 39);
            this.btnNew.Text = "List All";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(424, 332);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(6, 275);
            this.btnPrint.Size = new System.Drawing.Size(12, 14);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 374);
            this.groupBox1.Size = new System.Drawing.Size(534, 25);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(269, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 14);
            this.label4.TabIndex = 40;
            this.label4.Text = "Cash Flow Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 38;
            this.label3.Text = "Nature:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 37;
            this.label1.Text = "Under:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 16);
            this.label5.TabIndex = 36;
            this.label5.Text = "Name:";
            // 
            // txtAccountsType
            // 
            this.txtAccountsType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccountsType.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountsType.Location = new System.Drawing.Point(26, 268);
            this.txtAccountsType.MaxLength = 50;
            this.txtAccountsType.Name = "txtAccountsType";
            this.txtAccountsType.Size = new System.Drawing.Size(232, 22);
            this.txtAccountsType.TabIndex = 35;
            // 
            // txtUnder
            // 
            this.txtUnder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnder.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnder.Location = new System.Drawing.Point(26, 220);
            this.txtUnder.MaxLength = 50;
            this.txtUnder.Name = "txtUnder";
            this.txtUnder.Size = new System.Drawing.Size(445, 22);
            this.txtUnder.TabIndex = 34;
            // 
            // txtGroupName
            // 
            this.txtGroupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGroupName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGroupName.Location = new System.Drawing.Point(26, 173);
            this.txtGroupName.MaxLength = 50;
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(445, 22);
            this.txtGroupName.TabIndex = 33;
            // 
            // txtCashFlowType
            // 
            this.txtCashFlowType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCashFlowType.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCashFlowType.Location = new System.Drawing.Point(269, 268);
            this.txtCashFlowType.MaxLength = 50;
            this.txtCashFlowType.Name = "txtCashFlowType";
            this.txtCashFlowType.Size = new System.Drawing.Size(206, 22);
            this.txtCashFlowType.TabIndex = 39;
            // 
            // txtSlNo
            // 
            this.txtSlNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSlNo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSlNo.Location = new System.Drawing.Point(469, 150);
            this.txtSlNo.Name = "txtSlNo";
            this.txtSlNo.Size = new System.Drawing.Size(21, 22);
            this.txtSlNo.TabIndex = 41;
            this.txtSlNo.Visible = false;
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMobileNo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobileNo.Location = new System.Drawing.Point(26, 317);
            this.txtMobileNo.MaxLength = 50;
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(232, 22);
            this.txtMobileNo.TabIndex = 42;
            this.txtMobileNo.Visible = false;
            // 
            // txtConatctNo
            // 
            this.txtConatctNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConatctNo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConatctNo.Location = new System.Drawing.Point(269, 317);
            this.txtConatctNo.MaxLength = 50;
            this.txtConatctNo.Name = "txtConatctNo";
            this.txtConatctNo.Size = new System.Drawing.Size(206, 22);
            this.txtConatctNo.TabIndex = 43;
            this.txtConatctNo.Visible = false;
            // 
            // lblMobileNo
            // 
            this.lblMobileNo.AutoSize = true;
            this.lblMobileNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMobileNo.Location = new System.Drawing.Point(26, 295);
            this.lblMobileNo.Name = "lblMobileNo";
            this.lblMobileNo.Size = new System.Drawing.Size(125, 16);
            this.lblMobileNo.TabIndex = 44;
            this.lblMobileNo.Text = "Corporate Mobile:";
            this.lblMobileNo.Visible = false;
            // 
            // lblContactNo
            // 
            this.lblContactNo.AutoSize = true;
            this.lblContactNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactNo.Location = new System.Drawing.Point(271, 297);
            this.lblContactNo.Name = "lblContactNo";
            this.lblContactNo.Size = new System.Drawing.Size(115, 16);
            this.lblContactNo.TabIndex = 45;
            this.lblContactNo.Text = "Personal Mobile:";
            this.lblContactNo.Visible = false;
            // 
            // lblSorting
            // 
            this.lblSorting.AutoSize = true;
            this.lblSorting.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSorting.Location = new System.Drawing.Point(110, 364);
            this.lblSorting.Name = "lblSorting";
            this.lblSorting.Size = new System.Drawing.Size(98, 16);
            this.lblSorting.TabIndex = 47;
            this.lblSorting.Text = "Sort Position:";
            this.lblSorting.Visible = false;
            // 
            // txtSortingPos
            // 
            this.txtSortingPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSortingPos.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSortingPos.Location = new System.Drawing.Point(214, 361);
            this.txtSortingPos.MaxLength = 50;
            this.txtSortingPos.Name = "txtSortingPos";
            this.txtSortingPos.Size = new System.Drawing.Size(105, 22);
            this.txtSortingPos.TabIndex = 46;
            this.txtSortingPos.Visible = false;
            // 
            // frmGroupConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(534, 399);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmGroupConfiguration";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAccountsType;
        private System.Windows.Forms.TextBox txtUnder;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.TextBox txtCashFlowType;
        private System.Windows.Forms.TextBox txtSlNo;
        private System.Windows.Forms.Label lblContactNo;
        private System.Windows.Forms.Label lblMobileNo;
        private System.Windows.Forms.TextBox txtConatctNo;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.Label lblSorting;
        private System.Windows.Forms.TextBox txtSortingPos;
    }
}
