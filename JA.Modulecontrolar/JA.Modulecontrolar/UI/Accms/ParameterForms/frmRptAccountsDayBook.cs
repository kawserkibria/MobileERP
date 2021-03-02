﻿using Dutility;
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
using Microsoft.Win32;
namespace JA.Modulecontrolar.UI.DReport.Accms.ParameterForms
{
    public partial class frmRptAccountsDayBook : JA.Shared.UI.frmSmartFormStandard
    {
        //private ListBox lstLocation = new ListBox();
        //private ListBox lstItem = new ListBox();
        //JACCMS.SWJAGClient accms = new SWJAGClient();
        private string strComID { get; set; }
        public string strReportName { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public frmRptAccountsDayBook()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.dteFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteFromDate_KeyPress);
            //this.dteFromDate.GotFocus += new System.EventHandler(this.dteFromDate_GotFocus);

            this.dteToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteToDate_KeyPress);
            //this.dteToDate.GotFocus += new System.EventHandler(this.dteToDate_GotFocus);


        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (Keys.Escape == keyData)
            {
                //return base.ProcessCmdKey(ref msg, keyData);
                var strResponse = MessageBox.Show("                    Quit                    ", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponse == DialogResult.Yes)
                {
                    this.Dispose();
                }
            }

            return false;
        }    
        #region "User Deifne"
        //private void dteFromDate_GotFocus(object sender, System.EventArgs e)
        //{
        //    lstItem.Visible = false;
        //    lstLocation.Visible = false;

        //}
        //private void dteToDate_GotFocus(object sender, System.EventArgs e)
        //{
        //    lstItem.Visible = false;
        //    lstLocation.Visible = false;

        //}
        private void dteFromDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
               
                dteToDate.Focus();

            }
        }

        private void dteToDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnPrint.Focus();

            }
        }
        

        #endregion
        private void mLaodItem()
        {
            //lstItem.ValueMember = "strItemName";
            //lstItem.DisplayMember = "strItemName";
            //lstItem.DataSource = invms.gFillStockItem("", "", false).ToList();
         
        }

        private void radIndividual_Click(object sender, EventArgs e)
        {

            cboVoucherName.Visible  = true;
            lblVoucherName.Visible = true;
            cboVoucherName.Focus();
        }

        private void radAll_Click(object sender, EventArgs e)
        {
            cboVoucherName.Visible = false;
            lblVoucherName.Visible = false;
            dteFromDate.Focus();
            //txtLocationName.Enabled = false;
        }

        private void frmRptStoreLedger_Load(object sender, EventArgs e)
        {
            //frmLabel.Text = strReportName;
            dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            int intNarr = 0, intsumm = 0, intvtype = 0, intSignatory=0;
            if (radIndividual.Checked == true)
            {
                if (cboVoucherName.Text =="")
                {
                    MessageBox.Show("Cannot Empty");
                    cboVoucherName.Focus();
                    return;
                }
            }
            else
            {
                cboVoucherName.Text = "";
            }
            

            if (chkNarration.Checked==true)
            {
                intNarr =1;
            }
            if (radSummary.Checked==true)
            {
                intsumm = 1;
            }
            else
            {
                intsumm = 0;
            }
            if (chkSignatory.Checked == true)
            {
                intSignatory = 1;
            }
            else
            {
                intSignatory = 0;
            }
            
            frmReportViewer frmviewer = new frmReportViewer();
            frmviewer.selector = ViewerSelector.Daybook;
            frmviewer.strFdate = dteFromDate.Text;
            frmviewer.strTdate = dteToDate.Text;
            frmviewer.strString = cboVoucherName.Text;
            frmviewer.strBranchID = "";
            frmviewer.intNarration = intNarr;
            frmviewer.intSummDetails = intsumm;
            frmviewer.strSelction ="";
            frmviewer.intSignatory = intSignatory;
            frmviewer.Show();
           
          

           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        

       
    }
}
