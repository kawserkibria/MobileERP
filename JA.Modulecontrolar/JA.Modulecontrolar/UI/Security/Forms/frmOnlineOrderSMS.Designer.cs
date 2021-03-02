namespace JA.Modulecontrolar.UI.Security.Forms
{
    partial class frmOnlineOrderSMS
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.lblName = new System.Windows.Forms.Label();
            this.dteImportDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnClose = new ColorButton.ColorButton();
            this.btnSendSMS = new ColorButton.ColorButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Honeydew;
            this.panel1.Controls.Add(this.chkAll);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.dteImportDate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtMobileNo);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnSendSMS);
            this.panel1.Location = new System.Drawing.Point(0, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(434, 540);
            this.panel1.TabIndex = 0;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(356, 6);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(64, 17);
            this.chkAll.TabIndex = 111;
            this.chkAll.Text = "All MPO";
            this.chkAll.UseVisualStyleBackColor = true;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(6, 54);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(37, 14);
            this.lblName.TabIndex = 110;
            this.lblName.Text = "Date";
            // 
            // dteImportDate
            // 
            this.dteImportDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteImportDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteImportDate.Location = new System.Drawing.Point(6, 71);
            this.dteImportDate.Name = "dteImportDate";
            this.dteImportDate.Size = new System.Drawing.Size(215, 22);
            this.dteImportDate.TabIndex = 109;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 108;
            this.label2.Text = "Mobile No :";
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMobileNo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobileNo.Location = new System.Drawing.Point(6, 26);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(417, 22);
            this.txtMobileNo.TabIndex = 1;
            this.txtMobileNo.Text = "01707207767";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(6, 99);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(417, 388);
            this.textBox1.TabIndex = 104;
            // 
            // btnClose
            // 
            this.btnClose.Active = true;
            this.btnClose.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnClose.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnClose.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnClose.HoverColorB = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(219, 490);
            this.btnClose.Name = "btnClose";
            this.btnClose.NormalBorderColor = System.Drawing.Color.PowderBlue;
            this.btnClose.NormalColorA = System.Drawing.Color.White;
            this.btnClose.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnClose.Size = new System.Drawing.Size(129, 40);
            this.btnClose.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnClose.TabIndex = 103;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSendSMS
            // 
            this.btnSendSMS.Active = true;
            this.btnSendSMS.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnSendSMS.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendSMS.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnSendSMS.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnSendSMS.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnSendSMS.HoverColorB = System.Drawing.Color.White;
            this.btnSendSMS.Location = new System.Drawing.Point(87, 490);
            this.btnSendSMS.Name = "btnSendSMS";
            this.btnSendSMS.NormalBorderColor = System.Drawing.Color.PowderBlue;
            this.btnSendSMS.NormalColorA = System.Drawing.Color.White;
            this.btnSendSMS.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnSendSMS.Size = new System.Drawing.Size(129, 40);
            this.btnSendSMS.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnSendSMS.TabIndex = 102;
            this.btnSendSMS.Text = "Send";
            this.btnSendSMS.Click += new System.EventHandler(this.btnSendSMS_Click_1);
            // 
            // frmOnlineOrderSMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 557);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOnlineOrderSMS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Send SMS";
            this.Load += new System.EventHandler(this.frmOnlineOrderSMS_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.TextBox textBox1;
        private ColorButton.ColorButton btnClose;
        private ColorButton.ColorButton btnSendSMS;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.DateTimePicker dteImportDate;
        private System.Windows.Forms.CheckBox chkAll;

    }
}