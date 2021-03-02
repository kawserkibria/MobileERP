namespace JA.Modulecontrolar.UI.Sales.Forms
{
    partial class frmSampleClass
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.uclstGrdItem = new MayhediControlLibrary.StandardDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DG = new MayhediDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnDown = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.uctxtQty = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.uctxtItemName = new System.Windows.Forms.TextBox();
            this.txtOldName = new System.Windows.Forms.TextBox();
            this.chkFG = new System.Windows.Forms.CheckBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uclstGrdItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).BeginInit();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(212, 9);
            this.frmLabel.Size = new System.Drawing.Size(170, 33);
            this.frmLabel.Text = "Sample Class";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.chkFG);
            this.pnlMain.Controls.Add(this.panel2);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.txtClassName);
            this.pnlMain.Location = new System.Drawing.Point(0, 58);
            this.pnlMain.Size = new System.Drawing.Size(597, 351);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.txtOldName);
            this.pnlTop.Size = new System.Drawing.Size(601, 58);
            this.pnlTop.Controls.SetChildIndex(this.frmLabel, 0);
            this.pnlTop.Controls.SetChildIndex(this.btnTopClose, 0);
            this.pnlTop.Controls.SetChildIndex(this.txtOldName, 0);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(2, 410);
            this.btnEdit.Size = new System.Drawing.Size(134, 39);
            this.btnEdit.Text = "List All";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(377, 411);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(239, 429);
            this.btnDelete.Size = new System.Drawing.Size(5, 6);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(206, 429);
            this.btnNew.Size = new System.Drawing.Size(9, 6);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(489, 411);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(266, 431);
            this.btnPrint.Size = new System.Drawing.Size(5, 6);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 455);
            this.groupBox1.Size = new System.Drawing.Size(601, 25);
            // 
            // txtClassName
            // 
            this.txtClassName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClassName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClassName.Location = new System.Drawing.Point(140, 8);
            this.txtClassName.MaxLength = 50;
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(339, 22);
            this.txtClassName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.label1.Location = new System.Drawing.Point(26, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Class Name :";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.uclstGrdItem);
            this.panel2.Controls.Add(this.DG);
            this.panel2.Controls.Add(this.btnDown);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.uctxtQty);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.uctxtItemName);
            this.panel2.Location = new System.Drawing.Point(1, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(588, 303);
            this.panel2.TabIndex = 117;
            // 
            // uclstGrdItem
            // 
            this.uclstGrdItem.AllowUserToAddRows = false;
            this.uclstGrdItem.AllowUserToDeleteRows = false;
            this.uclstGrdItem.AllowUserToOrderColumns = true;
            this.uclstGrdItem.AllowUserToResizeColumns = false;
            this.uclstGrdItem.AllowUserToResizeRows = false;
            this.uclstGrdItem.BackgroundColor = System.Drawing.Color.White;
            this.uclstGrdItem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.uclstGrdItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.uclstGrdItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uclstGrdItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uclstGrdItem.DefaultCellStyle = dataGridViewCellStyle4;
            this.uclstGrdItem.Location = new System.Drawing.Point(4, 52);
            this.uclstGrdItem.MultiSelect = false;
            this.uclstGrdItem.Name = "uclstGrdItem";
            this.uclstGrdItem.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.uclstGrdItem.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.uclstGrdItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.uclstGrdItem.Size = new System.Drawing.Size(431, 28);
            this.uclstGrdItem.TabIndex = 96;
            this.uclstGrdItem.Visible = false;
            this.uclstGrdItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uclstGrdItem_KeyPress_1);
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn1.HeaderText = "Item Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 320;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn2.HeaderText = "Closing Qty";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // DG
            // 
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.DG.Location = new System.Drawing.Point(10, 52);
            this.DG.Name = "DG";
            this.DG.Size = new System.Drawing.Size(569, 236);
            this.DG.TabIndex = 68;
            this.DG.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Item Name";
            this.Column1.Name = "Column1";
            this.Column1.Width = 350;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Qty.";
            this.Column2.Name = "Column2";
            this.Column2.Width = 120;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Del.";
            this.Column3.Name = "Column3";
            this.Column3.Width = 50;
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(549, 23);
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
            this.label11.Location = new System.Drawing.Point(479, 2);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 18);
            this.label11.TabIndex = 60;
            this.label11.Text = "Qty";
            // 
            // uctxtQty
            // 
            this.uctxtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtQty.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtQty.Location = new System.Drawing.Point(437, 23);
            this.uctxtQty.Name = "uctxtQty";
            this.uctxtQty.Size = new System.Drawing.Size(108, 23);
            this.uctxtQty.TabIndex = 59;
            this.uctxtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uctxtQty_KeyPress_1);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 18);
            this.label12.TabIndex = 57;
            this.label12.Text = "Item Name";
            // 
            // uctxtItemName
            // 
            this.uctxtItemName.BackColor = System.Drawing.Color.White;
            this.uctxtItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtItemName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtItemName.ForeColor = System.Drawing.Color.Black;
            this.uctxtItemName.Location = new System.Drawing.Point(2, 23);
            this.uctxtItemName.Name = "uctxtItemName";
            this.uctxtItemName.Size = new System.Drawing.Size(435, 23);
            this.uctxtItemName.TabIndex = 56;
            this.uctxtItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.uctxtItemName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uctxtItemName_KeyUp);
            // 
            // txtOldName
            // 
            this.txtOldName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOldName.Location = new System.Drawing.Point(30, 9);
            this.txtOldName.Name = "txtOldName";
            this.txtOldName.Size = new System.Drawing.Size(20, 20);
            this.txtOldName.TabIndex = 15;
            this.txtOldName.Visible = false;
            // 
            // chkFG
            // 
            this.chkFG.AutoSize = true;
            this.chkFG.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFG.Location = new System.Drawing.Point(542, 12);
            this.chkFG.Name = "chkFG";
            this.chkFG.Size = new System.Drawing.Size(44, 18);
            this.chkFG.TabIndex = 118;
            this.chkFG.Text = "FG";
            this.chkFG.UseVisualStyleBackColor = true;
            this.chkFG.CheckedChanged += new System.EventHandler(this.chkFG_CheckedChanged);
            this.chkFG.Click += new System.EventHandler(this.chkFG_Click);
            // 
            // frmSampleClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(601, 480);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmSampleClass";
            this.Load += new System.EventHandler(this.frmSampleClass_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uclstGrdItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox uctxtQty;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox uctxtItemName;
        private MayhediDataGridView DG;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewButtonColumn Column3;
        private System.Windows.Forms.TextBox txtOldName;
        private MayhediControlLibrary.StandardDataGridView uclstGrdItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.CheckBox chkFG;
    }
}
