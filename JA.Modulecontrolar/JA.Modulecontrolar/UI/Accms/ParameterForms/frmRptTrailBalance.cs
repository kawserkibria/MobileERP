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
    public partial class frmRptTrailBalance : JA.Shared.UI.frmSmartFormStandard
    {
        //private ListBox lstLocation = new ListBox();
        //private ListBox lstItem = new ListBox();
        //JACCMS.SWJAGClient accms = new SWJAGClient();
        public string strReportName { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        private string strComID { get; set; }
        public frmRptTrailBalance()
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

        private void frmRptTrailBalance_Load(object sender, EventArgs e)
        {
            //lstLocation.Visible = false;
            //lstItem.Visible = false;
            //mLoadLocation();
            //mLaodItem();
            frmLabel.Text = strReportName;
            //dteFromDate.Text = Convert.ToDateTime(Utility.gdteFinancialYearFrom).ToString("dd/MM/yyyy");
            //dteToDate.Text = Convert.ToDateTime(Utility.gdteFinancialYearTo).ToString("dd/MM/yyyy");
            dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");

            dteFromDate.Focus();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            int intSelection,intsummDet=0,intSuppress;
            if (radGroup.Checked==true)
            {
                intSelection = 0;
            }
            else
            {
                intSelection = 1;
            }
            if (chkSuppress.Checked==true)
            {
                intSuppress = 1;
            }
            else
            {
                intSuppress = 0;
            }
            // 1 opn +tran +cls 2 opn +tra 3 +opn+cls tran +cls 4 5 opn 6 tra 7 cls
            if (chkOpening.Checked==true && chktransaction.Checked==true && chkClosing.Checked==true)
            {
                intsummDet = 1;
            }
            else if (chkOpening.Checked == true && chktransaction.Checked == true && chkClosing.Checked == false)
            {
                intsummDet = 2;
            }
            else if (chkOpening.Checked == true && chktransaction.Checked == false  && chkClosing.Checked == true)
            {
                intsummDet = 3;
            }
            else if (chkOpening.Checked == false && chktransaction.Checked == true && chkClosing.Checked == true)
            {
                intsummDet = 4;
            }
            else if (chkOpening.Checked == true && chktransaction.Checked == false && chkClosing.Checked == false)
            {
                intsummDet = 5;
            }
            else if (chkOpening.Checked == false && chktransaction.Checked == true && chkClosing.Checked == false)
            {
                intsummDet = 6;
            }
            else if (chkOpening.Checked == false && chktransaction.Checked == false && chkClosing.Checked == true)
            {
                intsummDet = 7;
            }


            frmReportViewer frmviewer = new frmReportViewer();
            frmviewer.selector = ViewerSelector.TrailBalance;
            frmviewer.dteFdate = dteFromDate.Value;
            frmviewer.dteTdate = dteToDate.Value;
            frmviewer.strSelction = "Trail Balance";
            frmviewer.intNarration = intSelection;
            frmviewer.intSummDetails = intsummDet;
            frmviewer.intSP  = intSuppress;
            frmviewer.Show();
            

           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
