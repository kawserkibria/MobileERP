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
    public partial class frmRptStatistics : JA.Shared.UI.frmSmartFormStandard
    {
        //private ListBox lstLocation = new ListBox();
        //private ListBox lstItem = new ListBox();
        //JACCMS.SWJAGClient accms = new SWJAGClient();
        private string strComID { get; set; }
        public string strReportName { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public frmRptStatistics()
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
           
        }



        private void btnPrint_Click(object sender, EventArgs e)
        {
            int intsumDet = 0, intSorting = 0;
            if (radDetails.Checked == true)
            {
                intsumDet = 1;
            }
            else
            {
                intsumDet = 0;
            }
            if (chkSorting.Checked == true)
            {
                intSorting = 1;
            }
            else
            {
                intSorting = 0;
            }
            if (strReportName == "Cash Flow")
            {

                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.CashFlow;
                frmviewer.strFdate = dteFromDate.Text;
                frmviewer.strTdate = dteToDate.Text;
                frmviewer.strSelction = "Cash Flow";
                frmviewer.intSummDetails = intsumDet;
                
                frmviewer.Show();
            }
            else if (strReportName == "Manufacturing")
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.Manufacturing;
                frmviewer.strFdate = dteFromDate.Text;
                frmviewer.strTdate = dteToDate.Text;
                frmviewer.strSelction = "Manufacturing";
                frmviewer.Show();
            }
            else if (strReportName == "Cheque")
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.Cheque;
                frmviewer.strFdate = dteFromDate.Text;
                frmviewer.strTdate = dteToDate.Text;
                frmviewer.strSelction = "Cheque";
                frmviewer.intSP = intSorting;
                frmviewer.Show();
            }
            else if (strReportName == "Special Commission")
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.SP;
                frmviewer.strFdate = dteFromDate.Text;
                frmviewer.strTdate = dteToDate.Text;
                frmviewer.strSelction = "SP";
                frmviewer.Show();
            }

            else if (strReportName == "Payment Summary")
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.ExpenseSumm;
                frmviewer.strFdate = dteFromDate.Text;
                frmviewer.strTdate = dteToDate.Text;
                frmviewer.strSelction = "Payment Summary";
                frmviewer.intSummDetails = intsumDet;
                frmviewer.Show();

            }
            else if (strReportName == "ERP Statistics")
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.Statistics;
                frmviewer.strFdate = dteFromDate.Text;
                frmviewer.strTdate = dteToDate.Text;
                frmviewer.strSelction = "ERP Statistics";
                frmviewer.Show();
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void frmRptStatistics_Load(object sender, EventArgs e)
        {
            if (strReportName == "Cash Flow")
            {
                pnlSummDet.Visible = true;
                chkSorting.Visible = false;
            }
            else if (strReportName == "Cheque")
            {
                chkSorting.Visible = true;
                pnlSummDet.Visible = false;
            }
            else if (strReportName == "Payment Summary")
            {
                chkSorting.Visible = false;
                pnlSummDet.Visible = true;
            }
               
            else
            {
                chkSorting.Visible = false;
                pnlSummDet.Visible = false;
            }

            frmLabel.Text = strReportName;
            //dteFromDate.Text = Utility.gdteFinancialYearFrom;
            //dteToDate.Text = Utility.gdteFinancialYearTo;
            dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
