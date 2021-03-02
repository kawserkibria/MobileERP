namespace MayhediControlLibrary
{
    partial class UserWidget
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
            this.pnlPicture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPicture
            // 
            this.pnlPicture.BackColor = System.Drawing.Color.DimGray;
            this.pnlPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPicture.Controls.Add(this.picUser);
            this.pnlPicture.Location = new System.Drawing.Point(122, 4);
            this.pnlPicture.Name = "pnlPicture";
            this.pnlPicture.Size = new System.Drawing.Size(140, 115);
            this.pnlPicture.TabIndex = 40;
            // 
            // picUser
            // 
            this.picUser.BackColor = System.Drawing.Color.AliceBlue;
            this.picUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picUser.Location = new System.Drawing.Point(3, 3);
            this.picUser.Name = "picUser";
            this.picUser.Size = new System.Drawing.Size(132, 107);
            this.picUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picUser.TabIndex = 38;
            this.picUser.TabStop = false;
            // 
            // lblLogInTime
            // 
            this.lblLogInTime.AutoSize = true;
            this.lblLogInTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogInTime.ForeColor = System.Drawing.Color.DimGray;
            this.lblLogInTime.Location = new System.Drawing.Point(235, 141);
            this.lblLogInTime.Name = "lblLogInTime";
            this.lblLogInTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblLogInTime.Size = new System.Drawing.Size(32, 13);
            this.lblLogInTime.TabIndex = 2;
            this.lblLogInTime.Text = "date";
            // 
            // lblDesignation
            // 
            this.lblDesignation.AutoSize = true;
            this.lblDesignation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesignation.ForeColor = System.Drawing.Color.DarkGray;
            this.lblDesignation.Location = new System.Drawing.Point(142, 122);
            this.lblDesignation.Name = "lblDesignation";
            this.lblDesignation.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDesignation.Size = new System.Drawing.Size(94, 13);
            this.lblDesignation.TabIndex = 1;
            this.lblDesignation.Text = "Mayhedi Hasan";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.BackColor = System.Drawing.Color.Transparent;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.Blue;
            this.lblUserName.Location = new System.Drawing.Point(89, 99);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblUserName.Size = new System.Drawing.Size(132, 20);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "Mayhedi Hasan";
            // 
            // UserWidget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.Controls.Add(this.lblLogInTime);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblDesignation);
            this.Controls.Add(this.pnlPicture);
            this.Name = "UserWidget";
            this.Size = new System.Drawing.Size(276, 172);
            this.pnlPicture.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlPicture;
        public System.Windows.Forms.Label lblUserName;
        public System.Windows.Forms.PictureBox picUser;
        public System.Windows.Forms.Label lblDesignation;
        public System.Windows.Forms.Label lblLogInTime;
    }
}
