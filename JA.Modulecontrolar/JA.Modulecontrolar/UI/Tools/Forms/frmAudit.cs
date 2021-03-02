using Dutility;
using JA.Modulecontrolar.JINVMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using JA.Modulecontrolar.UI.DReport.Accms.Viewer;
using JA.Modulecontrolar.UI.DReport.Accms;
using JA.Modulecontrolar.UI.Inventory;
using JA.Modulecontrolar.JACCMS;
using JA.Modulecontrolar.UI.Accms.Forms;
using Microsoft.Win32;

namespace JA.Modulecontrolar.UI.Tools.Forms
{
    public partial class frmAudit : JA.Shared.UI.frmSmartFormStandard
    {
        public string strReportName { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        private ListBox lstUserName = new ListBox();
        private string strComID { get; set; }
        public frmAudit()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.dtpFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dtpFromDate_KeyPress);
            //this.dteFromDate.GotFocus += new System.EventHandler(this.dteFromDate_GotFocus);

            this.dtpToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dtpToDate_KeyPress);
            this.txtUserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtUserName_KeyPress);
            this.txtUserName.GotFocus += new System.EventHandler(this.txtUserName_GotFocus);
            this.txtUserName.KeyDown += new KeyEventHandler(txtUserName_KeyDown);
            this.lstUserName.DoubleClick += new System.EventHandler(this.lstUserName_DoubleClick);
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            
            Utility.CreateListBox(lstUserName, pnlMain, txtUserName);
        }
        #region User Define code
        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstUserName.Items.Count > 0)
                {
                    txtUserName.Text = lstUserName.Text;                  

                }
                lstUserName.Visible = false;
                dtpFromDate.Focus();
            }
        }
        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            lstUserName.Visible = true;
            if (e.KeyCode == Keys.Up)
            {
                if (lstUserName.SelectedItem != null)
                {
                    lstUserName.SelectedIndex = lstUserName.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstUserName.Items.Count - 1 > lstUserName.SelectedIndex)
                {
                    lstUserName.SelectedIndex = lstUserName.SelectedIndex + 1;
                }
            }


        }
        private void txtUserName_GotFocus(object sender, System.EventArgs e)
        {
           
            lstUserName.Visible = true;
            lstUserName.SelectedIndex = lstUserName.FindString(txtUserName.Text);
           
        }
        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

            lstUserName.Visible = true;
            lstUserName.SelectedIndex = lstUserName.FindString(txtUserName.Text);
        }
        private void lstUserName_DoubleClick(object sender, EventArgs e)
        {
            txtUserName.Text = lstUserName.Text;
            lstUserName.Visible = false;
            dtpFromDate.Focus();
        }
        #endregion

        private void dtpFromDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dtpToDate.Focus();
            }
        }

        private void dtpToDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                btnSave.Focus();

            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            int VoucherType =0, intOption=0;
            string ReportHeading = "";

            if (rbtnVoucher.Checked== true)
            {
                intOption = 1;
            }
            else
            {
                intOption = 0;
            }
            if (radAccounts.Checked == true )
            {
                VoucherType = 4;
            }
            if (radSales.Checked == true)
            {
                VoucherType = 1;
            }
            if (radStock.Checked == true)
            {
                VoucherType = 3;
            }
            if (radPurchase.Checked == true)
            {
                VoucherType = 2;
            }
            if (txtUserName.Text == "<<All User>>")
            {
                ReportHeading = "Audit Trail";
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.Audit;
                frmviewer.strFdate = dtpFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dtpToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.intVtype = VoucherType;
                frmviewer.intSP = intOption;
                frmviewer.strString = txtUserName.Text;
                frmviewer.intNarration = 1;
                frmviewer.strHeading = ReportHeading;
                frmviewer.Show();
            }
            else
            {
                ReportHeading = "Audit Trail (User Wise)";
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.Audit;
                frmviewer.strFdate = dtpFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dtpToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.intVtype = VoucherType;
                frmviewer.intSP = intOption;
                frmviewer.strString = txtUserName.Text;
                frmviewer.strHeading = ReportHeading;
                frmviewer.intNarration=0;
                frmviewer.Show();
            }


         

        }

        private void frmAudit_Load(object sender, EventArgs e)
        {
            lstUserName.Items.Add("<<All User>>");
            radAll.PerformClick();
            txtUserName.Text = "<<All User>>";
            mLoadStockGroup();
            lstUserName.Visible = false;
        }
        private void mLoadStockGroup()
        {
            List<UserAccess> oogrp = accms.mFillUsername(strComID).ToList();
            if (oogrp.Count > 0)
            {
                foreach (UserAccess ostk in oogrp)
                {
                    lstUserName.Items.Add(ostk.LogInName);
                }
            }
        }
    }


}

