namespace JA.Modulecontrolar.UI.Tools.Forms
{
    partial class frmSplitCompany
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSplitCompany));
            this.label3 = new System.Windows.Forms.Label();
            this.dteFinanicalTo = new System.Windows.Forms.DateTimePicker();
            this.dtefinancialform = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.proBar = new System.Windows.Forms.ProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.imagelst = new System.Windows.Forms.ImageList(this.components);
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(167, 8);
            this.frmLabel.Size = new System.Drawing.Size(193, 33);
            this.frmLabel.Text = "Split Company ";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.button4);
            this.pnlMain.Controls.Add(this.button3);
            this.pnlMain.Controls.Add(this.button2);
            this.pnlMain.Controls.Add(this.progressBar1);
            this.pnlMain.Controls.Add(this.button1);
            this.pnlMain.Controls.Add(this.pbImage);
            this.pnlMain.Controls.Add(this.pictureBox1);
            this.pnlMain.Controls.Add(this.proBar);
            this.pnlMain.Controls.Add(this.txtCompanyName);
            this.pnlMain.Controls.Add(this.label17);
            this.pnlMain.Controls.Add(this.dteFinanicalTo);
            this.pnlMain.Controls.Add(this.dtefinancialform);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Size = new System.Drawing.Size(490, 323);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(491, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(63, 222);
            this.btnEdit.Size = new System.Drawing.Size(10, 10);
            this.btnEdit.Text = "List All";
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(228, 242);
            this.btnSave.Size = new System.Drawing.Size(126, 39);
            this.btnSave.Text = "Split";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(206, 222);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(238, 222);
            this.btnNew.Size = new System.Drawing.Size(10, 10);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(357, 242);
            this.btnClose.Size = new System.Drawing.Size(122, 39);
            this.btnClose.Text = "Cancel";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(222, 222);
            this.btnPrint.Size = new System.Drawing.Size(10, 10);
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 287);
            this.groupBox1.Size = new System.Drawing.Size(491, 36);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 432);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 17);
            this.label3.TabIndex = 86;
            this.label3.Text = "New Company  :";
            this.label3.Visible = false;
            // 
            // dteFinanicalTo
            // 
            this.dteFinanicalTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteFinanicalTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteFinanicalTo.Location = new System.Drawing.Point(141, 406);
            this.dteFinanicalTo.Name = "dteFinanicalTo";
            this.dteFinanicalTo.Size = new System.Drawing.Size(176, 24);
            this.dteFinanicalTo.TabIndex = 93;
            this.dteFinanicalTo.Visible = false;
            // 
            // dtefinancialform
            // 
            this.dtefinancialform.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtefinancialform.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtefinancialform.Location = new System.Drawing.Point(141, 381);
            this.dtefinancialform.Name = "dtefinancialform";
            this.dtefinancialform.Size = new System.Drawing.Size(176, 24);
            this.dtefinancialform.TabIndex = 92;
            this.dtefinancialform.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 407);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 91;
            this.label1.Text = "To Date :";
            this.label1.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(42, 383);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(93, 17);
            this.label17.TabIndex = 116;
            this.label17.Text = "From Date :";
            this.label17.Visible = false;
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(141, 437);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(26, 20);
            this.txtCompanyName.TabIndex = 117;
            this.txtCompanyName.Visible = false;
            // 
            // proBar
            // 
            this.proBar.Location = new System.Drawing.Point(75, 208);
            this.proBar.Name = "proBar";
            this.proBar.Size = new System.Drawing.Size(352, 23);
            this.proBar.TabIndex = 118;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(38, 274);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 27);
            this.pictureBox1.TabIndex = 122;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // imagelst
            // 
            this.imagelst.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagelst.ImageStream")));
            this.imagelst.TransparentColor = System.Drawing.Color.Transparent;
            this.imagelst.Images.SetKeyName(0, "comingSoon.jpg.png");
            // 
            // pbImage
            // 
            this.pbImage.BackColor = System.Drawing.Color.Transparent;
            this.pbImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbImage.BackgroundImage")));
            this.pbImage.Location = new System.Drawing.Point(38, 342);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(10, 10);
            this.pbImage.TabIndex = 124;
            this.pbImage.TabStop = false;
            this.pbImage.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(75, 237);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(352, 23);
            this.progressBar1.TabIndex = 127;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(359, 381);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 126;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(367, 274);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 128;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(115, 295);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(24, 167);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 129;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // frmSplitCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(491, 323);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmSplitCompany";
            this.Load += new System.EventHandler(this.frmSplitCompany_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dteFinanicalTo;
        private System.Windows.Forms.DateTimePicker dtefinancialform;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ProgressBar proBar;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ImageList imagelst;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}
