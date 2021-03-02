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
using JA.Modulecontrolar.UI.DReport.Purchase.Viewer;
using Microsoft.Win32;
namespace JA.Modulecontrolar.UI.DReport.Purchase.ParameterForms
{
    public partial class frmRptPayables : JA.Shared.UI.frmSmartFormStandard
    {
        //private ListBox lstLocation = new ListBox();
        //private ListBox lstItem = new ListBox();
        //JACCMS.SWJAGClient accms = new SWJAGClient();
        public string strReportName { get; set; }
        private string strComID { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public frmRptPayables()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            rbtnAll.Checked = true;
            rbtnGW.Checked = true;
           

            this.dteToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteToDate_KeyPress);
            //this.dteToDate.GotFocus += new System.EventHandler(this.dteToDate_GotFocus);
            //rbtnAll.CheckedChanged += new EventHandler(this.rbtnAll_Checked);
            //rbtnGW.CheckedChanged += new EventHandler(this.rbtnGW_Checked);


    
 
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

        //private void rbtnAll_Checked(object sender, EventArgs e)
        //{
           
        //        rbtnAll.Checked = true;
           
        //}

        //private void rbtnGW_Checked(object sender, EventArgs e)
        //{
           
               
        //        rbtnGW.Checked = true;
        // }

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
           
            //txtLocationName.Enabled = true;
            //txtLocationName.Focus();
        }

        private void radAll_Click(object sender, EventArgs e)
        {
            //rbtnAll.Enabled = false;
            //dteToDate.Focus();
            //rbtnGroupWise.PerformClick();
            //txtLocationName.Enabled = false;
        }

        private void frmRptStoreLedger_Load(object sender, EventArgs e)
        {
            dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            //dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");
            //lstLocation.Visible = false;
            //lstItem.Visible = false;
            //mLoadLocation();
            //mLaodItem();
            txtPartyName.Visible = false;
            label4 .Visible =false ;
            //rbtnAll.PerformClick();
            rbtnGroupWise.PerformClick();
            rbtnPenDetail.PerformClick();
            //rbtnVoucherDate.p
            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string strBrachID = "";

            frmReportViewer frmviewer = new frmReportViewer();
            frmviewer.selector = ViewerSelector.Payables;
            frmviewer.strFdate = dteToDate.Text;
            frmviewer.strTdate = dteToDate.Text;
            frmviewer.strLedgerName = tetReportHader.Text;
            //frmviewer.strSelction = "BalanceSheet";

            frmviewer.Show();
            return;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rbtnOutstanding_Click(object sender, EventArgs e)
        {
            //rbtnAll.PerformLayout();
        }

        private void rbtnallll_Click(object sender, EventArgs e)
        {
            rbtnOut.Checked = false;
        }

        private void rbtnGW_Click(object sender, EventArgs e)
        {
            rbtnpart.Checked = false;
        }

        private void rbtndet_Click(object sender, EventArgs e)
        {
            rbtnsumm.Checked = false;
        }

        private void rbtnVou_Click(object sender, EventArgs e)
        {
            rbtnDue.Checked = false;
        }

        private void rbtnOut_Click(object sender, EventArgs e)
        {
            rbtnallll.Checked = false;
        }

        private void rbtnpart_Click(object sender, EventArgs e)
        {
            rbtnGW.Checked = false;
        }

        private void rbtnsumm_Click(object sender, EventArgs e)
        {
            rbtndet.Checked = false;
        }

        private void rbtnDue_Click(object sender, EventArgs e)
        {
            rbtnVou.Checked = false;
        }
    }
}
