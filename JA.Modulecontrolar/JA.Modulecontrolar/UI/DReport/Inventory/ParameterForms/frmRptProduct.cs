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
using JA.Modulecontrolar.UI.DReport.Inventory.Viewer;
using Microsoft.Win32;
namespace JA.Modulecontrolar.UI.DReport.Inventory.ParameterForms
{
    public partial class frmRptProduct : JA.Shared.UI.frmSmartFormStandard
    {
       
        //JACCMS.SWJAGClient accms = new SWJAGClient();
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public string strName { get; set; }
        private string strComID { get; set; }
        public frmRptProduct()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.dteFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteFromDate_KeyPress);
            this.dteFromDate.GotFocus += new System.EventHandler(this.dteFromDate_GotFocus);

            this.dteToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteToDate_KeyPress);
            this.dteToDate.GotFocus += new System.EventHandler(this.dteToDate_GotFocus);
            this.dteToDate.ValueChanged += new System.EventHandler(this.dteToDate_ValueChanged);

         
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
        private void dteFromDate_GotFocus(object sender, System.EventArgs e)
        {
           
        }
        private void dteToDate_GotFocus(object sender, System.EventArgs e)
        {
           

        }
        private void dteFromDate_KeyPress(object sender, KeyPressEventArgs e)
        {
           if (e.KeyChar == (char)Keys.Return)
            {
                if (strName == "PS")
                {
                    dteToDate.Text = Utility.LastDayOfMonth(dteFromDate.Value).ToString();
                    btnPrint.Focus();
                }
                else
                {
                    dteToDate.Focus();
                }

               

            }
        }

        private void dteToDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnPrint.Focus();

            }
            else
            {
                if (strName == "PS")
                {
                    dteFromDate.Focus();
                }
            }
        }
       

        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {
            int inttype = 1;
            if (strName == "T")
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.ProducTopSheet;
                frmviewer.strFdate = dteFromDate.Text;
                frmviewer.strTdate = dteToDate.Text;
                //frmviewer.strString = strGroupName;
                frmviewer.strSelction = "";
                frmviewer.Show();
            }
            else if (strName == "SP")
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.ProductTopSheetSalesPrice;
                frmviewer.strFdate = dteFromDate.Text;
                frmviewer.strTdate = dteToDate.Text;
                //frmviewer.strString = strGroupName;
                frmviewer.strSelction = "";
                frmviewer.Show();
            }
            else if (strName == "PS")
            {
                if (radRawMaterial.Checked==true)
                {
                    inttype = 1;
                }
                else
                {
                    inttype = 2;
                }
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.ProductStatment;
                frmviewer.strFdate = dteFromDate.Text;
                frmviewer.strTdate = dteToDate.Text;
                //frmviewer.strString = strGroupName;
                frmviewer.intype = inttype;
                frmviewer.strSelction = "";
                frmviewer.Show();
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void frmRptProduct_Load(object sender, EventArgs e)
        {
            //dteFromDate.Text = Utility.gdteFinancialYearFrom;
            //dteToDate.Text = Utility.gdteFinancialYearTo;
            dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");
            if (strName=="PS")
            {
                frmLabel.Text = "Product Statement Report";
                //dteFromDate.Text = Utility.FirstDayOfMonth(DateTime.Now).ToString();
                //dteToDate.Text = Utility.LastDayOfMonth(dteFromDate.Value).ToString();
                pnlSelection.Visible = true;
               
            }
            else if (strName == "SP")
            {
                frmLabel.Text = "Product Top Sheet Sales Price";
                pnlSelection.Visible = false;
            }
            else
            {
                pnlSelection.Visible = false;
            }
        }

        private void dteToDate_ValueChanged(object sender, EventArgs e)
        {
            if (strName == "PS")
            {
                dteFromDate.Focus();
            }

        }
    }
}
