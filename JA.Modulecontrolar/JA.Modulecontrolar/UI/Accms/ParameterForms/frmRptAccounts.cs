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
using Microsoft.Win32;
namespace JA.Modulecontrolar.UI.DReport.Accms.ParameterForms
{
    public partial class frmRptAccounts : JA.Shared.UI.frmSmartFormStandard
    {
        //private ListBox lstLocation = new ListBox();
        //private ListBox lstItem = new ListBox();
        //JACCMS.SWJAGClient accms = new SWJAGClient();
        public string strReportName { get; set; }
        private string strComID { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public frmRptAccounts()
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
           
            //txtLocationName.Enabled = true;
            //txtLocationName.Focus();
        }

        private void radAll_Click(object sender, EventArgs e)
        {
            dteFromDate.Focus();
            //txtLocationName.Enabled = false;
        }

        private void frmRptStoreLedger_Load(object sender, EventArgs e)
        {
         
            if (strReportName=="Receipt && Payment")
            {
                frmSelection.Visible = true;
                grpHorVer.Visible = false;
                dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");
            }
            if (strReportName == "Trading")
            {
                chkSqpCls.Visible = true;
                grpHorVer.Visible = false;
                dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");
            }
            if (strReportName == "Balance sheet")
            {
                //chkSqpCls.Visible = true;
                grpHorVer.Visible = false;
                //dteFromDate.Text = Utility.gdteFinancialYearFrom;
                //dteToDate.Text = Utility.gdteFinancialYearTo;
                dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");
            }
            if (strReportName == "Profit && Loss")
            {
                dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");
                //dteFromDate.Text = Utility.gdteFinancialYearFrom;
                //dteToDate.Text = Utility.gdteFinancialYearTo;
                //chkSqpCls.Visible = true;
                grpHorVer.Visible = false;
            }
            frmLabel.Text = strReportName;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            int intSummDetails = 0, intHor_ver = 0 ;
            if (radHor.Checked == true)
            {
                intHor_ver = 1;
            }
            else
            {
                intHor_ver = 0;
            }
            if (strReportName == "Balance sheet")
            {
                
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.BalanceSheet;
                frmviewer.dteFdate = dteFromDate.Value;
                frmviewer.dteTdate = dteToDate.Value;
                frmviewer.strSelction = "BalanceSheet";
                frmviewer.intHor_ver = intHor_ver;
                frmviewer.Show();
            }
            else if (strReportName == "Receipt && Payment")
            {
                int intSuppresss = 0;
                if (radSumm.Checked == true)
                {

                    intSummDetails = 1;
                    intSuppresss = 1;
                }
                else
                {
                    intSummDetails = 0;
                }

                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.ReceiptPayment;
                frmviewer.dteFdate = dteFromDate.Value;
                frmviewer.dteTdate = dteToDate.Value;
                frmviewer.strSelction = "Receipt & Payment";
                frmviewer.intSummDetails = intSummDetails;
                frmviewer.intSuppress = intSuppresss;
                frmviewer.intHor_ver = intHor_ver;
                frmviewer.Show();
            }
            else if (strReportName == "Trading")
            {
               
                if (chkSqpCls.Checked == true)
                {
                    intSummDetails = 1;
                }
                else
                {
                    intSummDetails = 0;
                }
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.Trading;
                frmviewer.dteFdate  = dteFromDate.Value;
                frmviewer.dteTdate  = dteToDate.Value;
                frmviewer.strSelction = "Trading";
                frmviewer.intSummDetails = intSummDetails;
                frmviewer.intHor_ver = intHor_ver;
                frmviewer.Show();
            }
            else
            {
               
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.ProfitLoss;
                frmviewer.dteFdate = dteFromDate.Value;
                frmviewer.dteTdate = dteToDate.Value;
                frmviewer.strSelction = "ProfitLoss";
                frmviewer.intHor_ver = intHor_ver;
                frmviewer.Show();
            }
          

           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void radVertical_Click(object sender, EventArgs e)
        {
            chkSqpCls.Checked = true;
            chkSqpCls.Visible = false;
        }

        private void radHor_Click(object sender, EventArgs e)
        {
            chkSqpCls.Visible = true;
        }
    }
}
