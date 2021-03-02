using Dutility;
using JA.Modulecontrolar.JINVMS;
using System;
using System.Collections.Generic;
using JA.Modulecontrolar.JACCMS;
using JA.Modulecontrolar.UI.DReport.Accms.ReportUI;
using JA.Modulecontrolar.UI.DReport.Inventory.ReportUI;
using JA.Modulecontrolar.JRPT;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using JA.Modulecontrolar.UI.DReport.Accms.Viewer;
using JA.Modulecontrolar.JACCMS;
using Microsoft.Win32;
namespace JA.Modulecontrolar.UI.DReport.Accms.ParameterForms
{
    public partial class frmRptBudget : JA.Shared.UI.frmSmartFormStandard
    {
        private ListBox lstLedgerList = new ListBox();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        JRPT.SWRPTClient orptCnn = new SWRPTClient();
        public string strReportName { get; set; }
        private string strComID { get; set; }
        public frmRptBudget()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.dteFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteFromDate_KeyPress);
            this.dteToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteToDate_KeyPress);
            this.uctxtLedgerConfig.KeyDown += new KeyEventHandler(uctxtLedgerConfig_KeyDown);
            this.uctxtLedgerConfig.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtLedgerConfig_KeyPress);
            this.uctxtLedgerConfig.TextChanged += new System.EventHandler(this.uctxtLedgerConfig_TextChanged);
            this.lstLedgerList.DoubleClick += new System.EventHandler(this.lstLedgerList_DoubleClick);
            Utility.CreateListBox(lstLedgerList, pnlMain, uctxtLedgerConfig);

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
        
        private void uctxtLedgerConfig_TextChanged(object sender, EventArgs e)
        {

                lstLedgerList.SelectedIndex = lstLedgerList.FindString(uctxtLedgerConfig.Text);
        }
        private void lstLedgerList_DoubleClick(object sender, EventArgs e)
        {
            uctxtLedgerConfig.Text = lstLedgerList.Text;
            dteFromDate.Focus();
            lstLedgerList.Visible = false;

        }
        private void uctxtLedgerConfig_KeyPress(object sender, KeyPressEventArgs e)
        {



                if (e.KeyChar == (char)Keys.Return)
                {
                    if (lstLedgerList.Items.Count > 0)
                    {
                        uctxtLedgerConfig.Text = lstLedgerList.Text;
                        lstLedgerList.Visible = false;
                    }
                    dteFromDate.Focus();
                }
         
        }
        private void uctxtLedgerConfig_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Up)
                {
                    if (lstLedgerList.SelectedItem != null)
                    {
                        lstLedgerList.SelectedIndex = lstLedgerList.SelectedIndex - 1;
                    }
                }
                if (e.KeyCode == Keys.Down)
                {
                    if (lstLedgerList.Items.Count - 1 > lstLedgerList.SelectedIndex)
                    {
                        lstLedgerList.SelectedIndex = lstLedgerList.SelectedIndex + 1;
                    }
                }    
        }
        private void uctxtLedgerConfig_GotFocus(object sender, System.EventArgs e)
        {

            lstLedgerList.Visible = true;

        }                
        #endregion      
        private void radAll_Click(object sender, EventArgs e)
        {
            dteFromDate.Focus();
           
        }
        private void frmRptAccountsLedger_Load(object sender, EventArgs e)
        {
            //dteFromDate.Text = Utility.gdteFinancialYearFrom;
            //dteToDate.Text = Utility.gdteFinancialYearTo;
            dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");
            radAllLedger.PerformClick();
            uctxtLedgerConfig.Visible = false;
            lstLedgerList.Visible = false;
            lstLedgerList.DisplayMember = "strLedgerName";
            lstLedgerList.ValueMember = "strLedgerName";
            lstLedgerList.DataSource = orptCnn.mGetBudgetledgerList(strComID);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string strSelection = "";
            int intSelection=1,intchecke=0;

            if (radbIndividualLedger.Checked == true)
            {
                if (uctxtLedgerConfig.Text == "")
                {
                    MessageBox.Show("Ledger Name Cannot be Empty");
                    uctxtLedgerConfig.Focus();
                    return;
                }
                strSelection = uctxtLedgerConfig.Text;
            }
            else
            {
                strSelection = "";
            }
          
            frmReportViewer frmviewer = new frmReportViewer();
            frmviewer.selector = ViewerSelector.Budget;
            frmviewer.strFdate  = dteFromDate.Value.ToString("dd-MM-yyyy");
            frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
            frmviewer.strString = strSelection;
            frmviewer.strBranchID = "";
            frmviewer.intSummDetails = intSelection;
            frmviewer.intNarration = intchecke;
            frmviewer.strSelction = intSelection.ToString();
            //frmviewer.strHeading = uctxtLedgerConfig.Text;
            frmviewer.Show();
        }
        private void radbIndividualLedger_Click(object sender, EventArgs e)
        {
            uctxtLedgerConfig.Visible = true;
            lstLedgerList.Visible = true;
            uctxtLedgerConfig.Focus();
        }

        private void radAllLedger_Click(object sender, EventArgs e)
        {
            lstLedgerList.Visible = false;
            uctxtLedgerConfig.Visible = false ;
            dteFromDate.Focus();
        }

    }
}
