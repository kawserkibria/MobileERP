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
    public partial class frmRptAccountsLedger : JA.Shared.UI.frmSmartFormStandard
    {
        private ListBox lstLedgerList = new ListBox();
        //private ListBox lstItem = new ListBox();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        SPWOIS objWoIS = new SPWOIS();
        public string strReportName { get; set; }
        private string strComID { get; set; }
        public string strMpo { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public frmRptAccountsLedger()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.dteFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteFromDate_KeyPress);
            this.dteFromDate.GotFocus += new System.EventHandler(this.dteFromDate_GotFocus);

            this.dteToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteToDate_KeyPress);
            this.dteToDate.GotFocus += new System.EventHandler(this.dteToDate_GotFocus);
            this.uctxtLedgerName.GotFocus += new System.EventHandler(this.uctxtLedgerName_GotFocus);
            this.lstLedgerList.DoubleClick += new System.EventHandler(this.lstLedgerList_DoubleClick);
            this.uctxtLedgerName.KeyDown += new KeyEventHandler(uctxtLedgerName_KeyDown);
            this.uctxtLedgerName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtLedgerName_KeyPress);
            this.uctxtLedgerName.TextChanged += new System.EventHandler(this.uctxtLedgerName_TextChanged);
            Utility.CreateListBoxHeight(lstLedgerList, pnlMain, uctxtLedgerName,0,200);

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
            textBox1.Text = lstLedgerList.SelectedValue.ToString();
            //string[] words = lstLedgerList.Text.Split('-');
            //foreach (string word in words)
            //{

            //    uctxtTerritoryCode.Text = words[1].ToString();
            //    uctxtTeritorryName.Text = words[2].ToString();
            //    uctxtLedgerName.Text = words[0].ToString();

            //}
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
                    textBox1.Text = lstLedgerList.SelectedValue.ToString();
                    //string[] words = lstLedgerList.Text.Split('-');
                    //foreach (string word in words)
                    //{
                    //    if (words[1].ToString() != "")
                    //    {
                    //        uctxtTerritoryCode.Text = words[1].ToString();
                    //        uctxtTeritorryName.Text = words[2].ToString();
                    //        uctxtLedgerName.Text = words[0].ToString();
                    //    }
                    //    else
                    //    {
                    //        uctxtLedgerName.Text = words[0].ToString();
                    //    }
                    //}
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
       

        private void radAll_Click(object sender, EventArgs e)
        {
            dteFromDate.Focus();
           
        }

        private void frmRptAccountsLedger_Load(object sender, EventArgs e)
        {
            //frmLabel.Text = strReportName;
            uctxtLedgerName.Focus();
            uctxtLedgerName.Select();
            //dteFromDate.Text = Utility.gdteFinancialYearFrom;
            //dteToDate.Text = Utility.gdteFinancialYearTo;
            dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");
            if (strMpo == "")
            {
               
                lstLedgerList.DisplayMember = "strmerzeString";
                lstLedgerList.ValueMember = "strLedgerName";
                lstLedgerList.DataSource = objWoIS.mLedgerAdditemMr(strComID, 0,"","").ToList();
            }
            else
            {
                chkNarration.Checked = false;
                lstLedgerList.DisplayMember = "strmerzeString";
                lstLedgerList.ValueMember = "strLedgerName";
                lstLedgerList.DataSource = objWoIS.mLedgerAdditemMr(strComID, 0, strMpo,Utility.gstrUserName).ToList();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            int intSelection = 1, intchecke = 0, intSignatory = 0, intVoucherWise=0;
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
            if (chkSignatory.Checked ==true)
            {
                intSignatory = 1;
            }
            else
            {
                intSignatory = 0;
            }
            if (chkboxVoucherW.Checked == true)
            {
                intVoucherWise = 5;
            }
            frmReportViewer frmviewer = new frmReportViewer();
            frmviewer.selector = ViewerSelector.Ledger;
            frmviewer.strFdate  = dteFromDate.Value.ToString("dd-MM-yyyy");
            frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
            frmviewer.strString = textBox1.Text;
            frmviewer.intSalesColl  = intVoucherWise;
            frmviewer.strBranchID = "";
            frmviewer.intSignatory = intSignatory;
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

        private void radMonthlySummary_Click(object sender, EventArgs e)
        {
            chkNarration.Visible = false;
        }

        private void radsummary_Click(object sender, EventArgs e)
        {
            chkNarration.Visible = true;
        }

        private void radDetails_Click(object sender, EventArgs e)
        {
            chkNarration.Visible = true;
        }

        private void chkActive_Click(object sender, EventArgs e)
        {
            int intStatus = 0;
            if (chkActive.Checked == true)
            {
                intStatus = 0;
            }
            else
            {
                intStatus = 1;
            }
            uctxtLedgerName.Text = "";


            lstLedgerList.DisplayMember = "strmerzeString";
            lstLedgerList.ValueMember = "strLedgerName";
            lstLedgerList.DataSource = objWoIS.mLedgerAdditemMr(strComID, intStatus, strMpo,Utility.gstrUserName).ToList();

        }
    }
}
