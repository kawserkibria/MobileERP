namespace MayhediControlLibrary
{
    partial class UserWidgetMetro
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlPicture = new System.Windows.Forms.Panel();
            this.picUser = new System.Windows.Forms.PictureBox();
            this.lblLogInTime = new System.Windows.Forms.Label();
            this.lblDesignation = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.pnlLogOut = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLogInAs = new System.Windows.Forms.Label();
            this.pnlPicture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            this.pnlLogOut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPicture
            // 
            this.pnlPicture.BackColor = System.Drawing.Color.Transparent;
            this.pnlPicture.Controls.Add(this.picUser);
            this.pnlPicture.Location = new System.Drawing.Point(9, 3);
            this.pnlPicture.Name = "pnlPicture";
            this.pnlPicture.Size = new System.Drawing.Size(135, 116);
            this.pnlPicture.TabIndex = 40;
            // 
            // picUser
            // 
            this.picUser.BackColor = System.Drawing.Color.Transparent;
            this.picUser.Location = new System.Drawing.Point(3, 3);
            this.picUser.Name = "picUser";
            this.picUser.Size = new System.Drawing.Size(127, 112);
            this.picUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picUser.TabIndex = 38;
            this.picUser.TabStop = false;
            // 
            // lblLogInTime
            // 
            this.lblLogInTime.AutoSize = true;
            this.lblLogInTime.BackColor = System.Drawing.Color.Transparent;
            this.lblLogInTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogInTime.ForeColor = System.Drawing.Color.White;
            this.lblLogInTime.Location = new System.Drawing.Point(144, 69);
            this.lblLogInTime.Name = "lblLogInTime";
            this.lblLogInTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblLogInTime.Size = new System.Drawing.Size(32, 13);
            this.lblLogInTime.TabIndex = 2;
            this.lblLogInTime.Text = "date";
            // 
            // lblDesignation
            // 
            this.lblDesignation.AutoSize = true;
            this.lblDesignation.BackColor = System.Drawing.Color.Transparent;
            this.lblDesignation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesignation.ForeColor = System.Drawing.Color.White;
            this.lblDesignation.Location = new System.Drawing.Point(144, 30);
            this.lblDesignation.Name = "lblDesignation";
            this.lblDesignation.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDesignation.Size = new System.Drawing.Size(133, 13);
            this.lblDesignation.TabIndex = 1;
            this.lblDesignation.Text = "A.N.M. Atiqur Rahman";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.BackColor = System.Drawing.Color.Transparent;
            this.lblUserName.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.White;
            this.lblUserName.Location = new System.Drawing.Point(144, 7);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblUserName.Size = new System.Drawing.Size(215, 16);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "A.N.M. Atiqur Rahman Shumon";
            // 
            // pnlLogOut
            // 
            this.pnlLogOut.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlLogOut.Controls.Add(this.pictureBox1);
            this.pnlLogOut.Controls.Add(this.label1);
            this.pnlLogOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlLogOut.Location = new System.Drawing.Point(144, 87);
            this.pnlLogOut.Name = "pnlLogOut";
            this.pnlLogOut.Size = new System.Drawing.Size(105, 31);
            this.pnlLogOut.TabIndex = 41;
            this.pnlLogOut.Click += new System.EventHandler(this.pnlLogOut_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AtiqsControlLibrary.Properties.Resources.Other_Power_Switch_User_Metro_icon;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(41, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Logout";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblLogInAs
            // 
            this.lblLogInAs.AutoSize = true;
            this.lblLogInAs.BackColor = System.Drawing.Color.Transparent;
            this.lblLogInAs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogInAs.ForeColor = System.Drawing.Color.White;
            this.lblLogInAs.Location = new System.Drawing.Point(144, 49);
            this.lblLogInAs.Name = "lblLogInAs";
            this.lblLogInAs.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblLogInAs.Size = new System.Drawing.Size(61, 13);
            this.lblLogInAs.TabIndex = 42;
            this.lblLogInAs.Text = "LogIn As:";
            // 
            // UserWidgetMetro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblLogInAs);
            this.Controls.Add(this.pnlLogOut);
            this.Controls.Add(this.lblLogInTime);
            this.Controls.Add(this.lblDesignation);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.pnlPicture);
            this.Name = "UserWidgetMetro";
            this.Size = new System.Drawing.Size(362, 122);
            this.pnlPicture.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            this.pnlLogOut.ResumeLayout(false);
            this.pnlLogOut.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlPicture;
        public System.Windows.Forms.Label lblUserName;
        public System.Windows.Forms.PictureBox picUser;
        public System.Windows.Forms.Label lblDesignation;
        public System.Windows.Forms.Label lblLogInTime;
        //private SmartLabel smartLabel3;
        //private SmartLabel smartLabel2;
        //private SmartLabel smartLabel1;
        private System.Windows.Forms.Panel pnlLogOut;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblLogInAs;
    }
}
