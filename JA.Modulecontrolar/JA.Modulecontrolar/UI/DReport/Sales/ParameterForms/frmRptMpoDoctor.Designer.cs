namespace JA.Modulecontrolar.UI.DReport.Sales.ParameterForms
{
    partial class frmRptMpoDoctor
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
            this.btnMpoList = new ColorButton.ColorButton();
            this.btnCustomerList = new ColorButton.ColorButton();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmLabel
            // 
            this.frmLabel.Location = new System.Drawing.Point(119, 9);
            this.frmLabel.Size = new System.Drawing.Size(0, 33);
            this.frmLabel.Text = "";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnCustomerList);
            this.pnlMain.Controls.Add(this.btnMpoList);
            this.pnlMain.Location = new System.Drawing.Point(0, -86);
            this.pnlMain.Size = new System.Drawing.Size(485, 274);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(487, 58);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(54, 174);
            this.btnEdit.Size = new System.Drawing.Size(10, 10);
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 174);
            this.btnSave.Size = new System.Drawing.Size(10, 10);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.ImageIndex = -1;
            this.btnDelete.ImageKey = "(none)";
            this.btnDelete.Location = new System.Drawing.Point(136, 173);
            this.btnDelete.Size = new System.Drawing.Size(10, 10);
            this.btnDelete.Text = "";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(96, 174);
            this.btnNew.Size = new System.Drawing.Size(10, 10);
            this.btnNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.ImageIndex = -1;
            this.btnClose.ImageKey = "(none)";
            this.btnClose.Location = new System.Drawing.Point(209, 173);
            this.btnClose.Size = new System.Drawing.Size(10, 10);
            this.btnClose.Text = "";
            this.btnClose.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.ImageIndex = -1;
            this.btnPrint.Location = new System.Drawing.Point(193, 173);
            this.btnPrint.Size = new System.Drawing.Size(10, 10);
            this.btnPrint.Text = "";
            this.btnPrint.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 192);
            this.groupBox1.Size = new System.Drawing.Size(487, 25);
            // 
            // btnMpoList
            // 
            this.btnMpoList.Active = true;
            this.btnMpoList.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnMpoList.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMpoList.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnMpoList.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnMpoList.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnMpoList.HoverColorB = System.Drawing.Color.White;
            this.btnMpoList.Location = new System.Drawing.Point(69, 161);
            this.btnMpoList.Name = "btnMpoList";
            this.btnMpoList.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnMpoList.NormalColorA = System.Drawing.Color.White;
            this.btnMpoList.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnMpoList.Size = new System.Drawing.Size(340, 40);
            this.btnMpoList.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnMpoList.TabIndex = 29;
            this.btnMpoList.Text = "MPO List";
            this.btnMpoList.Click += new System.EventHandler(this.btnMpoList_Click);
            // 
            // btnCustomerList
            // 
            this.btnCustomerList.Active = true;
            this.btnCustomerList.ButtonStyle = ColorButton.ColorButton.ButtonStyles.Rectangle;
            this.btnCustomerList.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomerList.GradientStyle = ColorButton.ColorButton.GradientStyles.Vertical;
            this.btnCustomerList.HoverBorderColor = System.Drawing.Color.MediumVioletRed;
            this.btnCustomerList.HoverColorA = System.Drawing.Color.LemonChiffon;
            this.btnCustomerList.HoverColorB = System.Drawing.Color.White;
            this.btnCustomerList.Location = new System.Drawing.Point(69, 204);
            this.btnCustomerList.Name = "btnCustomerList";
            this.btnCustomerList.NormalBorderColor = System.Drawing.Color.Aqua;
            this.btnCustomerList.NormalColorA = System.Drawing.Color.White;
            this.btnCustomerList.NormalColorB = System.Drawing.Color.Honeydew;
            this.btnCustomerList.Size = new System.Drawing.Size(340, 40);
            this.btnCustomerList.SmoothingQuality = ColorButton.ColorButton.SmoothingQualities.AntiAlias;
            this.btnCustomerList.TabIndex = 30;
            this.btnCustomerList.Text = "Doctor/Customer List";
            this.btnCustomerList.Click += new System.EventHandler(this.btnCustomerList_Click);
            // 
            // frmRptMpoDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(487, 217);
            this.isEnterTabAllow = true;
            this.KeyPreview = false;
            this.MinimizeBox = false;
            this.Name = "frmRptMpoDoctor";
            this.Load += new System.EventHandler(this.frmRptMpoDoctor_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ColorButton.ColorButton btnCustomerList;
        private ColorButton.ColorButton btnMpoList;


    }
}
