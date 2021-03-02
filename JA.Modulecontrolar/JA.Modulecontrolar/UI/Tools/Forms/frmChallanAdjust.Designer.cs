namespace JA.Modulecontrolar.UI.Tools.Forms
{
    partial class frmChallanAdjust
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChallanAdjust));
            this.imagelst = new System.Windows.Forms.ImageList(this.components);
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblQty = new System.Windows.Forms.Label();
            this.chkFG = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLocationName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.uctxtItemName = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dteToDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dteFromDate = new System.Windows.Forms.DateTimePicker();
            this.DG = new System.Windows.Forms.DataGridView();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.pnlMain.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).BeginInit();
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
            this.btnOk.Location = new System.Drawing.Point(470, 518);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(98, 35);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(568, 518);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 35);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnShow);
            this.pnlMain.Controls.Add(this.lblQty);
            this.pnlMain.Controls.Add(this.chkFG);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.txtLocationName);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.uctxtItemName);
            this.pnlMain.Controls.Add(this.groupBox6);
            this.pnlMain.Controls.Add(this.DG);
            this.pnlMain.Controls.Add(this.progressBar1);
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(665, 511);
            this.pnlMain.TabIndex = 3;
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Location = new System.Drawing.Point(543, 477);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(16, 16);
            this.lblQty.TabIndex = 46;
            this.lblQty.Text = "0";
            // 
            // chkFG
            // 
            this.chkFG.AutoSize = true;
            this.chkFG.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFG.ForeColor = System.Drawing.Color.Blue;
            this.chkFG.Location = new System.Drawing.Point(509, 20);
            this.chkFG.Name = "chkFG";
            this.chkFG.Size = new System.Drawing.Size(130, 18);
            this.chkFG.TabIndex = 45;
            this.chkFG.Text = "Finished Product";
            this.chkFG.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(14, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 16);
            this.label4.TabIndex = 44;
            this.label4.Text = "Location Name:";
            // 
            // txtLocationName
            // 
            this.txtLocationName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLocationName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocationName.Location = new System.Drawing.Point(141, 20);
            this.txtLocationName.Name = "txtLocationName";
            this.txtLocationName.Size = new System.Drawing.Size(362, 22);
            this.txtLocationName.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(41, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 16);
            this.label3.TabIndex = 42;
            this.label3.Text = "Item Name:";
            // 
            // uctxtItemName
            // 
            this.uctxtItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctxtItemName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctxtItemName.Location = new System.Drawing.Point(141, 124);
            this.uctxtItemName.Name = "uctxtItemName";
            this.uctxtItemName.Size = new System.Drawing.Size(420, 22);
            this.uctxtItemName.TabIndex = 41;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.dteToDate);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.dteFromDate);
            this.groupBox6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(17, 48);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(622, 70);
            this.groupBox6.TabIndex = 40;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Period Seletion";
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(562, 123);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(28, 23);
            this.btnShow.TabIndex = 24;
            this.btnShow.Text = "..";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(382, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "To:";
            // 
            // dteToDate
            // 
            this.dteToDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteToDate.Location = new System.Drawing.Point(418, 26);
            this.dteToDate.Name = "dteToDate";
            this.dteToDate.Size = new System.Drawing.Size(126, 22);
            this.dteToDate.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(67, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "From:";
            // 
            // dteFromDate
            // 
            this.dteFromDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteFromDate.Location = new System.Drawing.Point(124, 25);
            this.dteFromDate.Name = "dteFromDate";
            this.dteFromDate.Size = new System.Drawing.Size(126, 22);
            this.dteFromDate.TabIndex = 20;
            // 
            // DG
            // 
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG.Location = new System.Drawing.Point(7, 191);
            this.DG.Name = "DG";
            this.DG.Size = new System.Drawing.Size(650, 283);
            this.DG.TabIndex = 38;
            this.DG.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellEndEdit);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(7, 170);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(650, 18);
            this.progressBar1.TabIndex = 37;
            // 
            // frmChallanAdjust
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(678, 556);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChallanAdjust";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Stock Weight & Average Method";
            this.Load += new System.EventHandler(this.frmUpdateAVG_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imagelst;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.CheckBox chkFG;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLocationName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uctxtItemName;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dteToDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dteFromDate;
        private System.Windows.Forms.DataGridView DG;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Label lblQty;

    }
}