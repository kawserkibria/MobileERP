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
using JA.Modulecontrolar.JACCMS;
using Microsoft.Win32;
namespace JA.Modulecontrolar.UI.DReport.Accms.ParameterForms
{
    public partial class frmRptCashbank : JA.Shared.UI.frmSmartFormStandard
    {
        private ListBox lstBranchName = new ListBox();
        private ListBox lstLedgerList = new ListBox();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        private string strComID { get; set; }
        public string strReportName { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public frmRptCashbank()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.dteFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteFromDate_KeyPress);
            this.dteFromDate.GotFocus += new System.EventHandler(this.dteFromDate_GotFocus);

            this.dteToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteToDate_KeyPress);
            this.dteToDate.GotFocus += new System.EventHandler(this.dteToDate_GotFocus);

            this.uctxtBranchName.GotFocus += new System.EventHandler(this.uctxtBranchName_GotFocus);
            this.lstBranchName.DoubleClick += new System.EventHandler(this.lstBranchName_DoubleClick);
            this.uctxtBranchName.KeyDown += new KeyEventHandler(uctxtBranchName_KeyDown);
            this.uctxtBranchName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranchName_KeyPress);
            this.uctxtBranchName.TextChanged += new System.EventHandler(this.uctxtBranchName_TextChanged);

            this.uctxtLedgerName.GotFocus += new System.EventHandler(this.uctxtLedgerName_GotFocus);
            this.lstLedgerList.DoubleClick += new System.EventHandler(this.lstLedgerList_DoubleClick);
            this.uctxtLedgerName.KeyDown += new KeyEventHandler(uctxtLedgerName_KeyDown);
            this.uctxtLedgerName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtLedgerName_KeyPress);
            this.uctxtLedgerName.TextChanged += new System.EventHandler(this.uctxtLedgerName_TextChanged);

            Utility.CreateListBox(lstBranchName, pnlMain, uctxtBranchName);
            Utility.CreateListBox(lstLedgerList, pnlMain, uctxtLedgerName);

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
        private void uctxtLedgerName_TextChanged(object sender, EventArgs e)
        {
            lstLedgerList.SelectedIndex = lstLedgerList.FindString(uctxtLedgerName.Text);
        }

        private void lstLedgerList_DoubleClick(object sender, EventArgs e)
        {
            uctxtLedgerName.Text = lstLedgerList.Text;
            dteFromDate.Focus();
        }
        private void uctxtLedgerName_GotFocus(object sender, System.EventArgs e)
        {
            lstLedgerList.Visible = true;
            lstBranchName.Visible = false;

        }

        private void uctxtLedgerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstLedgerList.Items.Count > 0)
                {
                    uctxtLedgerName.Text = lstLedgerList.Text;
                }
                dteFromDate.Focus();

            }
        }

        private void uctxtLedgerName_KeyDown(object sender, KeyEventArgs e)
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
        private void uctxtBranchName_TextChanged(object sender, EventArgs e)
        {
            lstBranchName.SelectedIndex = lstBranchName.FindString(uctxtBranchName.Text);
        }

        private void lstBranchName_DoubleClick(object sender, EventArgs e)
        {
            uctxtBranchName.Text = lstBranchName.Text;
            uctxtLedgerName.Focus();
        }
        private void uctxtBranchName_GotFocus(object sender, System.EventArgs e)
        {
            lstBranchName.Visible = true;
            lstLedgerList.Visible = false;
            lstBranchName.SelectedIndex = lstBranchName.FindString(uctxtBranchName.Text);
        }

        private void uctxtBranchName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBranchName.Items.Count > 0)
                {
                    uctxtBranchName.Text = lstBranchName.Text;
                }
                uctxtLedgerName.Focus();

            }
        }

        private void uctxtBranchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstBranchName.SelectedItem != null)
                {
                    lstBranchName.SelectedIndex = lstBranchName.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstBranchName.Items.Count - 1 > lstBranchName.SelectedIndex)
                {
                    lstBranchName.SelectedIndex = lstBranchName.SelectedIndex + 1;
                }
            }

        }

        private void dteFromDate_GotFocus(object sender, System.EventArgs e)
        {
            lstLedgerList.Visible = false;
            lstBranchName.Visible = false;

        }
        private void dteToDate_GotFocus(object sender, System.EventArgs e)
        {
            lstLedgerList.Visible = false;
            lstBranchName.Visible = false;

        }
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

       

       
        private void frmRptStoreLedger_Load(object sender, EventArgs e)
        {
         
            
            dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString();
            lstBranchName.ValueMember = "Key";
            lstBranchName.DisplayMember = "Value";
            //lstBranchName.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
            lstBranchName.DataSource = accms.mfillBranchNew(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string strBrachID = "";
            int intSelection = 1, intchecke = 0, intRunnTotoal = 0, intSignatory = 0;
            if (uctxtLedgerName.Text == "")
            {
                MessageBox.Show("Ledger Name Cannot be Empty");
                uctxtLedgerName.Focus();
                return;
            }
            if (chkSignatory.Checked == true)
            {
                intSignatory = 1;
            }
            else
            {
                intSignatory = 0;
            }
            //1 narration,2 Summarry 3 monthlysummarry
            if (radDetails.Checked == true)
            {
                intSelection = 1;
            }
            else
            {
                intSelection = 2;
            }
            if (chkRunning.Checked == true)
                intRunnTotoal = 1;

            if (chkNarration.Checked == true)
            {
                intchecke = 1;
            }
           
            if (uctxtBranchName.Text !="")
            {
                strBrachID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);
            }
            else
            {
                strBrachID = "";
            }
            frmReportViewer frmviewer = new frmReportViewer();
            frmviewer.selector = ViewerSelector.Ledger;
            frmviewer.strFdate = dteFromDate.Text;
            frmviewer.strTdate = dteToDate.Text;
            frmviewer.strString = uctxtLedgerName.Text;
            frmviewer.strBranchID = strBrachID;
            frmviewer.strSelction = "4";
            frmviewer.intSummDetails = intSelection;
            frmviewer.strHeading = uctxtLedgerName.Text;
            frmviewer.intNarration = intchecke;
            frmviewer.intSP = intRunnTotoal;
            frmviewer.intSignatory = intSignatory;
            frmviewer.Show();
          

           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void radIndividual_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radCashInHand_Click(object sender, EventArgs e)
        {
            uctxtLedgerName.Focus();
            lstLedgerList.DisplayMember = "strLedgerName";
            lstLedgerList.ValueMember = "strLedgerName";
            lstLedgerList.DataSource = accms.mFillLedgerNew(strComID, (long)Utility.GR_GROUP_TYPE.grCash).ToList();
        }

        private void radBankAccounts_Click(object sender, EventArgs e)
        {
            uctxtLedgerName.Focus();
            lstLedgerList.DisplayMember = "strLedgerName";
            lstLedgerList.ValueMember = "strLedgerName";
            lstLedgerList.DataSource = accms.mFillLedgerNew(strComID, (long)Utility.GR_GROUP_TYPE.grBANKACCOUNTS).ToList();
        }

       

        
    }
}
