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
namespace JA.Modulecontrolar.UI.DReport.Accms.ParameterForms
{
    public partial class frmRptAccountsLedger1 : JA.Shared.UI.frmSmartFormStandard
    {
        private ListBox lstLedgerList = new ListBox();
        //private ListBox lstItem = new ListBox();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public string strReportName { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public frmRptAccountsLedger1()
        {
            InitializeComponent();

            this.dteFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteFromDate_KeyPress);
            this.dteFromDate.GotFocus += new System.EventHandler(this.dteFromDate_GotFocus);

            this.dteToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteToDate_KeyPress);
            this.dteToDate.GotFocus += new System.EventHandler(this.dteToDate_GotFocus);
            this.uctxtLedgerName.GotFocus += new System.EventHandler(this.uctxtLedgerName_GotFocus);
            this.lstLedgerList.DoubleClick += new System.EventHandler(this.lstLedgerList_DoubleClick);
            this.uctxtLedgerName.KeyDown += new KeyEventHandler(uctxtLedgerName_KeyDown);
            this.uctxtLedgerName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtLedgerName_KeyPress);
            this.uctxtLedgerName.TextChanged += new System.EventHandler(this.uctxtLedgerName_TextChanged);
            Utility.CreateListBox(lstLedgerList, pnlMain, uctxtLedgerName);

        }

        #region "User Deifne"
        private void dteFromDate_GotFocus(object sender, System.EventArgs e)
        {
            lstLedgerList.Visible = false ;
        }
        private void dteToDate_GotFocus(object sender, System.EventArgs e)
        {
            lstLedgerList.Visible = false;
        }
        private void uctxtLedgerName_TextChanged(object sender, EventArgs e)
        {
            if (uctxtLedgerName.Text == "")
            {
                uctxtTerritoryCode.Text ="";
                uctxtTeritorryName.Text = "";
                uctxtLedgerName.Text = "";
            }
            lstLedgerList.SelectedIndex = lstLedgerList.FindString(uctxtLedgerName.Text);
        }

        private void lstLedgerList_DoubleClick(object sender, EventArgs e)
        {
            uctxtLedgerName.Text = lstLedgerList.Text;
            string[] words = lstLedgerList.Text.Split('-');
            foreach (string word in words)
            {

                uctxtTerritoryCode.Text = words[1].ToString();
                uctxtTeritorryName.Text = words[2].ToString();
                uctxtLedgerName.Text = words[0].ToString();

            }
            dteFromDate.Focus();
        }
        private void uctxtLedgerName_GotFocus(object sender, System.EventArgs e)
        {
            lstLedgerList.Visible = true;

        }

        private void uctxtLedgerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstLedgerList.Items.Count > 0)
                {
                    uctxtLedgerName.Text = lstLedgerList.Text;
                    string[] words = lstLedgerList.Text.Split('-');
                    foreach (string word in words)
                    {
                        uctxtTerritoryCode.Text = words[1].ToString();
                        uctxtTeritorryName.Text = words[2].ToString();
                        uctxtLedgerName.Text = words[0].ToString();
                       
                    }
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
            //frmLabel.Text = strReportName;
            lstLedgerList.DisplayMember = "strLedgerName";
            lstLedgerList.ValueMember = "strLedgerName";
            lstLedgerList.DataSource = accms.mLedgerAdditemMr("").ToList();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            int intSelection=1,intchecke=0;
            if (uctxtLedgerName.Text =="")
            {
                MessageBox.Show("Ledger Name Cannot be Empty");
                uctxtLedgerName.Focus();
                return;
            }

            //1 narration,2 Summarry 3 monthlysummarry
           if  (radsummary.Checked==true)
            {
                intSelection = 2;
            }
            else if (radMonthlySummary.Checked == true)
            {
                intSelection = 3;
            }
            else
            {
                intSelection = 1;
            }

            if (chkNarration.Checked==true)
            {
                intchecke = 1;
            }
            else if (chkChequeNo.Checked == true)
            {
                intchecke = 2;
            }
            frmReportViewer frmviewer = new frmReportViewer();
            frmviewer.selector = ViewerSelector.Ledger;
            frmviewer.strFdate  = dteFromDate.Text;
            frmviewer.strTdate  = dteToDate.Text ;
            frmviewer.strString = uctxtLedgerName.Text;
            frmviewer.strBranchID = "";
            frmviewer.intSummDetails = intSelection;
            frmviewer.intNarration = intchecke;
            frmviewer.strSelction = intSelection.ToString();
            frmviewer.strHeading = uctxtLedgerName.Text;
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
