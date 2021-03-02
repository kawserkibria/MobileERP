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
    public partial class frmRptFixetAsset : JA.Shared.UI.frmSmartFormStandard
    {
       
        public string strReportName { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        private string strComID { get; set; }
        public frmRptFixetAsset()
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

        private void frmRptStoreLedger_Load(object sender, EventArgs e)
        {
           
            frmLabel.Text = strReportName;
            dteFromDate.Text = Utility.gdteFinancialYearFrom;
            dteToDate.Text = Utility.gdteFinancialYearTo;
            //radGroupW.PerformClick();
            //radReducingBalance.PerformClick();
            //radyearlry.PerformClick();
            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string strSelection = "", strstring = "";
            if (radStraightline.Checked)
            {
                strSelection = "S";
            }
            else
            {
                strSelection = "R";
            }
            if (radGroupW.Checked == true)
            {
                strstring = "G";
            }
            else
            {
                strstring = "L";
            }

            frmReportViewer frmviewer = new frmReportViewer();
            frmviewer.selector = ViewerSelector.FixedAsset;
            if (strstring == "G")
            {
                frmviewer.strHeading = "Fixed Asset Schedule(Group Wise)";
            }
            else
            {
                frmviewer.strHeading = "Fixed Asset Schedule(Ledger Wise)";
            }
            frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
            frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
            frmviewer.dteFdate = dteFromDate.Value;
            frmviewer.dteTdate = dteToDate.Value;
            frmviewer.strSelction = strSelection;
            frmviewer.strString = strstring;
            frmviewer.Show();


        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radMonthly_Click(object sender, EventArgs e)
        {
            groupBox6.Enabled = true;
            dteFromDate.Focus();
        }

        private void radyearlry_Click(object sender, EventArgs e)
        {
            groupBox6.Enabled = false;
        }
    }
}
