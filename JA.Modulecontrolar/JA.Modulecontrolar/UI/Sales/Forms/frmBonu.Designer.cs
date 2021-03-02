namespace JA.Modulecontrolar.UI.Sales.Forms
{
    partial class frmBonu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.uctxtBranchName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dteApplicableDate = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.uctxtAddres = new System.Windows.Forms.TextBox();
            this.btnDown = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.uctxtPhone = new System.Windows.Forms.TextBox();
            this.DG = new MayhediDataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.uctxtEmpCode = new System.Windows.Forms.TextBox();
            this.TextEmpname = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).BeginInit();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Size = new System.Drawing.Size(256, 33);
            this.frmLabel.Text = "Bonus Configuration";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.panel2);
            this.pnlMain.Controls.Add(this.uctxtBranchName);
            this.pnlMain.Controls.Add(this.label8);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.dteApplicableDate);
            this.pnlMain.Size = new System.Drawing.Size(863, 615);
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(7, 531);
            this.btnEdit.Size = new System.Drawing.Size(121, 39);
            this.btnEdit.Text = "List All";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(633, 530);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(150, 528);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(520, 528);
            this.btnNew.Size = new System.Drawing.Size(10, 10);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(747, 530);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(261, 528);
            this.btnPrint.Size = new System.Drawing.Size(10, 10);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 570);
            // 
            // uctxtBranchName
            // 
            this.uctxtBranchName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtBranchName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtBranchName.Location = new System.Drawing.Point(302, 181);
            this.uctxtBranchName.Name = "uctxtBranchName";
            this.uctxtBranchName.Size = new System.Drawing.Size(377, 23);
            this.uctxtBranchName.TabIndex = 68;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(179, 182);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 18);
            this.label8.TabIndex = 67;
            this.label8.Text = "Branch Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(167, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 18);
            this.label1.TabIndex = 65;
            this.label1.Text = "Applicable Date:";
            // 
            // dteApplicableDate
            // 
            this.dteApplicableDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteApplicableDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteApplicableDate.Location = new System.Drawing.Point(302, 153);
            this.dteApplicableDate.Name = "dteApplicableDate";
            this.dteApplicableDate.Size = new System.Drawing.Size(163, 22);
            this.dteApplicableDate.TabIndex = 64;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.TextEmpname);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.uctxtAddres);
            this.panel2.Controls.Add(this.btnDown);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.uctxtPhone);
            this.panel2.Controls.Add(this.DG);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.uctxtEmpCode);
            this.panel2.Location = new System.Drawing.Point(3, 209);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(855, 402);
            this.panel2.TabIndex = 70;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(726, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 18);
            this.label5.TabIndex = 71;
            this.label5.Text = "Addres";
            // 
            // uctxtAddres
            // 
            this.uctxtAddres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtAddres.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtAddres.Location = new System.Drawing.Point(721, 32);
            this.uctxtAddres.Name = "uctxtAddres";
            this.uctxtAddres.Size = new System.Drawing.Size(94, 23);
            this.uctxtAddres.TabIndex = 70;
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(815, 32);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(30, 23);
            this.btnDown.TabIndex = 67;
            this.btnDown.Text = ">>";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(626, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 18);
            this.label4.TabIndex = 60;
            this.label4.Text = "Phone";
            // 
            // uctxtPhone
            // 
            this.uctxtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtPhone.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtPhone.Location = new System.Drawing.Point(554, 32);
            this.uctxtPhone.Name = "uctxtPhone";
            this.uctxtPhone.Size = new System.Drawing.Size(167, 23);
            this.uctxtPhone.TabIndex = 59;
            // 
            // DG
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DG.DefaultCellStyle = dataGridViewCellStyle4;
            this.DG.Location = new System.Drawing.Point(3, 56);
            this.DG.Name = "DG";
            this.DG.Size = new System.Drawing.Size(842, 343);
            this.DG.TabIndex = 58;
            this.DG.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellClick_1);
            this.DG.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 18);
            this.label3.TabIndex = 57;
            this.label3.Text = "Code:";
            // 
            // uctxtEmpCode
            // 
            this.uctxtEmpCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtEmpCode.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtEmpCode.Location = new System.Drawing.Point(3, 32);
            this.uctxtEmpCode.Name = "uctxtEmpCode";
            this.uctxtEmpCode.Size = new System.Drawing.Size(121, 23);
            this.uctxtEmpCode.TabIndex = 56;
            this.uctxtEmpCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.uctxtEmpCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uctxtItemName_KeyUp);
            // 
            // TextEmpname
            // 
            this.TextEmpname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextEmpname.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextEmpname.Location = new System.Drawing.Point(120, 32);
            this.TextEmpname.Name = "TextEmpname";
            this.TextEmpname.Size = new System.Drawing.Size(436, 23);
            this.TextEmpname.TabIndex = 72;
            this.TextEmpname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(317, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 18);
            this.label6.TabIndex = 73;
            this.label6.Text = "Emp Name:";
            // 
            // frmBonu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(864, 595);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmBonu";
            this.Load += new System.EventHandler(this.frmBonu_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox uctxtBranchName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dteApplicableDate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox uctxtAddres;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox uctxtPhone;
        private MayhediDataGridView DG;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uctxtEmpCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TextEmpname;
    }
}
