namespace JA.Modulecontrolar.UI.Inventory
{
    partial class frmMFGStockConsumDilProces
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMFGStockConsumDilProces));
            this.imagelst = new System.Windows.Forms.ImageList(this.components);
            this.btnOk = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnLeftAll = new System.Windows.Forms.Button();
            this.btnLeftSingle = new System.Windows.Forms.Button();
            this.btnRightAll = new System.Windows.Forms.Button();
            this.btnRightSingle = new System.Windows.Forms.Button();
            this.lstRight = new System.Windows.Forms.ListBox();
            this.lstLeft = new System.Windows.Forms.ListBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblNo = new System.Windows.Forms.Label();
            this.lblNetTotal = new System.Windows.Forms.Label();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // imagelst
            // 
            this.imagelst.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagelst.ImageStream")));
            this.imagelst.TransparentColor = System.Drawing.Color.Transparent;
            this.imagelst.Images.SetKeyName(0, "22.png");
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(468, 477);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(98, 35);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(29, 387);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(636, 18);
            this.progressBar1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(567, 477);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 35);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtSearch);
            this.groupBox7.Controls.Add(this.btnLeftAll);
            this.groupBox7.Controls.Add(this.btnLeftSingle);
            this.groupBox7.Controls.Add(this.btnRightAll);
            this.groupBox7.Controls.Add(this.btnRightSingle);
            this.groupBox7.Controls.Add(this.lstRight);
            this.groupBox7.Controls.Add(this.lstLeft);
            this.groupBox7.Location = new System.Drawing.Point(4, 43);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(665, 308);
            this.groupBox7.TabIndex = 6;
            this.groupBox7.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(7, 17);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(299, 22);
            this.txtSearch.TabIndex = 6;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnLeftAll
            // 
            this.btnLeftAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLeftAll.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftAll.Location = new System.Drawing.Point(316, 155);
            this.btnLeftAll.Name = "btnLeftAll";
            this.btnLeftAll.Size = new System.Drawing.Size(36, 23);
            this.btnLeftAll.TabIndex = 5;
            this.btnLeftAll.Text = "<<";
            this.btnLeftAll.UseVisualStyleBackColor = false;
            // 
            // btnLeftSingle
            // 
            this.btnLeftSingle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLeftSingle.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftSingle.Location = new System.Drawing.Point(316, 130);
            this.btnLeftSingle.Name = "btnLeftSingle";
            this.btnLeftSingle.Size = new System.Drawing.Size(36, 23);
            this.btnLeftSingle.TabIndex = 4;
            this.btnLeftSingle.Text = "<";
            this.btnLeftSingle.UseVisualStyleBackColor = false;
            // 
            // btnRightAll
            // 
            this.btnRightAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRightAll.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRightAll.Location = new System.Drawing.Point(316, 105);
            this.btnRightAll.Name = "btnRightAll";
            this.btnRightAll.Size = new System.Drawing.Size(36, 23);
            this.btnRightAll.TabIndex = 3;
            this.btnRightAll.Text = ">>";
            this.btnRightAll.UseVisualStyleBackColor = false;
            // 
            // btnRightSingle
            // 
            this.btnRightSingle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRightSingle.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRightSingle.Location = new System.Drawing.Point(316, 80);
            this.btnRightSingle.Name = "btnRightSingle";
            this.btnRightSingle.Size = new System.Drawing.Size(36, 23);
            this.btnRightSingle.TabIndex = 2;
            this.btnRightSingle.Text = ">";
            this.btnRightSingle.UseVisualStyleBackColor = false;
            // 
            // lstRight
            // 
            this.lstRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstRight.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstRight.FormattingEnabled = true;
            this.lstRight.ItemHeight = 14;
            this.lstRight.Location = new System.Drawing.Point(360, 41);
            this.lstRight.Name = "lstRight";
            this.lstRight.Size = new System.Drawing.Size(301, 254);
            this.lstRight.TabIndex = 1;
            // 
            // lstLeft
            // 
            this.lstLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstLeft.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLeft.FormattingEnabled = true;
            this.lstLeft.ItemHeight = 14;
            this.lstLeft.Location = new System.Drawing.Point(6, 43);
            this.lstLeft.Name = "lstLeft";
            this.lstLeft.Size = new System.Drawing.Size(301, 254);
            this.lstLeft.TabIndex = 0;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(29, 439);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(16, 16);
            this.lblCount.TabIndex = 7;
            this.lblCount.Text = "0";
            // 
            // lblNo
            // 
            this.lblNo.AutoSize = true;
            this.lblNo.Location = new System.Drawing.Point(29, 477);
            this.lblNo.Name = "lblNo";
            this.lblNo.Size = new System.Drawing.Size(16, 16);
            this.lblNo.TabIndex = 8;
            this.lblNo.Text = "0";
            // 
            // lblNetTotal
            // 
            this.lblNetTotal.AutoSize = true;
            this.lblNetTotal.Location = new System.Drawing.Point(29, 368);
            this.lblNetTotal.Name = "lblNetTotal";
            this.lblNetTotal.Size = new System.Drawing.Size(16, 16);
            this.lblNetTotal.TabIndex = 9;
            this.lblNetTotal.Text = "0";
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(29, 411);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(636, 18);
            this.progressBar2.TabIndex = 11;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(272, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(240, 23);
            this.textBox1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(222, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Date:";
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(369, 476);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(98, 35);
            this.btnView.TabIndex = 13;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // frmMFGStockConsumDilProces
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(678, 520);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.lblNetTotal);
            this.Controls.Add(this.lblNo);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnOk);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMFGStockConsumDilProces";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Stock Weight & Average Method";
            this.Load += new System.EventHandler(this.frmMFGStockConsumDilProces_Load);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imagelst;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnLeftAll;
        private System.Windows.Forms.Button btnLeftSingle;
        private System.Windows.Forms.Button btnRightAll;
        private System.Windows.Forms.Button btnRightSingle;
        private System.Windows.Forms.ListBox lstRight;
        private System.Windows.Forms.ListBox lstLeft;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblNo;
        private System.Windows.Forms.Label lblNetTotal;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnView;

    }
}