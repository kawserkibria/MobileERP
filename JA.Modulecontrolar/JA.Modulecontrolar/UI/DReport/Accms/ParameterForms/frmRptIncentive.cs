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
    public partial class frmRptIncentive : JA.Shared.UI.frmSmartFormStandard
    {
       
        public string strReportName { get; set; }
        private string strComID { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public frmRptIncentive()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.dteFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteFromDate_KeyPress);
            this.dteToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteToDate_KeyPress);


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

        private void frmRptIncentive_Load(object sender, EventArgs e)
        {

            dteFromDate.Value = Utility.FirstDayOfMonth(DateTime.Now);
            dteToDate.Value = Utility.LastDayOfMonth(DateTime.Now);
          
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
           
            string strLedgerOption = "", strSelectOption = ""; 
            int year = dteFromDate.Value.Year;
            int Mont = dteFromDate.Value.Month;
            DateTime firstDay = new DateTime(year, Mont, 1);
            DateTime lastDay = new DateTime(year, 12, 31);
            dteFromDate.Text = firstDay.ToString();
            dteFromDate2.Value = dteFromDate.Value.AddMonths(1);
            dteToDate.Value = dteFromDate2.Value.AddDays(-1);

            if (rbtnMpo.Checked==true)
            {
                strLedgerOption = "MPO";
            }
            else if (rbtnAH.Checked == true)
            {
                strLedgerOption = "AH";
            }
            else if (rbtnDSM.Checked == true)
            {
                strLedgerOption = "DH";
            }

            if (radMonthly.Checked == true)
            {
                strSelectOption = "M";
            }
            else if (radYearly.Checked == true)
            {
                strSelectOption = "Y";
            }
            else if (rbtnyearlyE.Checked == true)
            {
                strSelectOption = "YE";
            }

        

                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.IncMonthly;
                frmviewer.strFdate = Convert.ToDateTime(dteFromDate.Value).ToString("dd-MM-yyyy");
                frmviewer.strTdate = Convert.ToDateTime(dteToDate.Value).ToString("dd-MM-yyyy");

                if (rbtnMpo.Checked == true)
                {
                    frmviewer.strHeading = "MPO Incentive (Monthly)";
                }
                else if (rbtnAH.Checked == true)
                {
                    frmviewer.strHeading = "Area Head Incentive (Monthly)";
                }
                else
                {
                    frmviewer.strHeading = "Divisional Head Incentive (Monthly)";
                }
                frmviewer.strString = strLedgerOption;
                frmviewer.strString2 = strSelectOption;
                frmviewer.Show();
          

           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void radVertical_Click(object sender, EventArgs e)
        {
          
        }

        private void radHor_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmReportViewer frmviewer = new frmReportViewer();
            frmviewer.selector = ViewerSelector.ProfitLossLedger ;
            frmviewer.dteFdate = dteFromDate.Value;
            frmviewer.dteTdate = dteToDate.Value;
            frmviewer.Show();
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

       
    }
}
