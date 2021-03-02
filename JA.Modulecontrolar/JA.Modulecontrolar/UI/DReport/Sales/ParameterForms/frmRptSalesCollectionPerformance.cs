using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using Dutility;
using System.Drawing.Drawing2D;
using JA.Modulecontrolar.JSAPUR;
using JA.Modulecontrolar.JINVMS;
using JA.Modulecontrolar.JACCMS;
using JA.Modulecontrolar.EXTRA;

using JA.Modulecontrolar.UI.DReport.Sales.Viewer;

namespace JA.Modulecontrolar.UI.DReport.Sales.ParameterForms

{
    public partial class frmRptSalesCollectionPerformance : JA.Shared.UI.frmSmartFormStandard 
    {
        private ListBox lstBranch = new ListBox();
        private ListBox lstMrName = new ListBox();

        public string strMontNameYY = "";
        public string strMontName = "";

        public string strThisMonth = "";
        public string strLastMonth= "";

        JACCMS.SWJAGClient accms = new JACCMS.SWJAGClient();
        JSAPUR.WSalesPurchaseClient orpt = new WSalesPurchaseClient();
        EXTRA.SWPRJClient objExtra = new EXTRA.SWPRJClient();

        private ListBox lstLedger = new ListBox();
        private ListBox lstLedgerType = new ListBox();
        private ListBox lstMonthID = new ListBox();
        private string strComID { get; set; }
        string strBranchId = "";
      
        public string strReportName { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public frmRptSalesCollectionPerformance()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");


            this.dtpFDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dtpFDate_KeyPress);

            this.dtpTDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dtpTDate_KeyPress);

            this.uctxtBranch.GotFocus += new System.EventHandler(this.uctxtBranch_GotFocus);
            this.uctxtBranch.KeyDown += new KeyEventHandler(uctxtBranch_KeyDown);
            this.uctxtBranch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranch_KeyPress);
            this.lstBranch.DoubleClick += new System.EventHandler(this.lstBranch_DoubleClick);
            this.uctxtBranch.TextChanged += new System.EventHandler(this.uctxtBranch_TextChanged);

            this.txtSearch.KeyDown += new KeyEventHandler(txtSearch_KeyDown);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtSearch_KeyPress);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

          
            this.lstLeft.DoubleClick += new System.EventHandler(this.lstLeft_DoubleClick);

            this.btnRightAll.Click += new System.EventHandler(this.btnRightAll_Click);
            this.btnRightSingle.Click += new System.EventHandler(this.btnRightSingle_Click);
            this.btnLeftSingle.Click += new System.EventHandler(this.btnLeftSingle_Click);
            this.btnLeftAll.Click += new System.EventHandler(this.btnLeftAll_Click);
            Utility.CreateListBox(lstBranch, pnlMain, uctxtBranch, 0);
      
           
        }
        private void dtpFDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dtpTDate.Focus(); 
            }
       
        }
        private void dtpTDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnPrint.Focus();
            }
         
        }
     
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            lstLeft.SelectedIndex = lstLeft.FindString(txtSearch.Text);
        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstLeft.SelectedItem != null)
                {
                    lstLeft.SelectedIndex = lstLeft.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstLeft.Items.Count - 1 > lstLeft.SelectedIndex)
                {
                    lstLeft.SelectedIndex = lstLeft.SelectedIndex + 1;
                }
            }

        }
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                //txtSearch.Text = "";

                if (lstLeft.SelectedItems.Count > 0)
                {
                    lstRight.Items.Add(lstLeft.SelectedItem.ToString());
                    lstRight.SelectedValue = lstLeft.SelectedValue;
                    lstLeft.Items.Remove(lstLeft.SelectedItem.ToString());
                    txtSearch.Text = "";
                    txtSearch.Focus();
                }
                //btnPrint.Focus();       
            }

        }

    
        private void lstLeft_DoubleClick(object sender, EventArgs e)
        {
            if (lstLeft.SelectedItems.Count > 0)
            {
                lstRight.Items.Add(lstLeft.SelectedItem.ToString());
                lstRight.SelectedValue = lstLeft.SelectedValue;
                lstLeft.Items.Remove(lstLeft.SelectedItem.ToString());
            }

        }
        private void btnRightSingle_Click(object sender, EventArgs e)
        {
            if (lstLeft.SelectedItems.Count > 0)
            {
                lstRight.Items.Add(lstLeft.SelectedItem.ToString());
                lstRight.SelectedValue = lstLeft.SelectedValue;
                lstLeft.Items.Remove(lstLeft.SelectedItem.ToString());
            }
        }

        private void btnRightAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstLeft.Items.Count; i++)
            {
                string strItem = lstLeft.Items[i].ToString().TrimStart();
                lstRight.Items.Add(strItem);
            }
            lstLeft.Items.Clear();
        }
        private void btnLeftSingle_Click(object sender, EventArgs e)
        {
            if (lstRight.SelectedItems.Count > 0)
            {
                lstLeft.Items.Add(lstRight.SelectedItem.ToString());
                lstRight.Items.Remove(lstRight.SelectedItem.ToString());
            }
        }

        private void btnLeftAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstRight.Items.Count; i++)
            {
                string strItem = lstRight.Items[i].ToString().TrimStart();
                lstLeft.Items.Add(strItem);
            }
            lstRight.Items.Clear();
        }

   


        private void mLoadLedgerName()
        {
            BranchId();
            int Intmode = 0, intSelection=0;
            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            groupSelection.Enabled = true;

            if (radAllStatus.Checked == true)
            {
                intSelection = 3;
            }
            else if (radActive.Checked == true)
            {
                intSelection = 0;
            }
            else if (radInactive.Checked == true)
            {
                intSelection = 1;
            }


            if (rbtnAll.Checked == true)
            {
                Intmode = 5;
            }
            if (rbtnMPO.Checked == true)
            {
                Intmode = 4;
            }
            if (rbtnAMFM.Checked == true)
            {
                Intmode = 3;
            }
            if (rbtnDSMRSM.Checked == true)
            {
                Intmode = 2;
            }
            if (rbtnZONE.Checked == true)
            {
                Intmode = 1;
            }

            if (Intmode < 5)
            {
                List<Mprojection> orptt = objExtra.mGetLedgerGroupLoad(strComID, Intmode, Utility.gstrUserName, intSelection,strBranchId).ToList();
                if (orptt.Count > 0)
                {


                    foreach (Mprojection ostk in orptt)
                    {
                        lstLeft.Items.Add(ostk.strGRName);
                    }
                }

                txtSearch.Focus();
            }
            else
            {
                dtpFDate.Focus();
            }
        }
        private void txtMonthID_TextChanged(object sender, EventArgs e)
        {
            lstMonthID.SelectedIndex = lstMonthID.FindString(uctxtBranch.Text);
        }
        private void txtMonthID_GotFocus(object sender, System.EventArgs e)
        {

            lstMonthID.Visible = true;

            lstMonthID.ValueMember = "strMonthID";
            lstMonthID.DisplayMember = "strMonthID";
            lstMonthID.DataSource = objExtra.mFillMonthConfig(strComID, 0).ToList();
            
        }
    
   
      
        private void txtMonthID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstMonthID.SelectedItem != null)
                {
                    lstMonthID.SelectedIndex = lstMonthID.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstMonthID.Items.Count - 1 > lstMonthID.SelectedIndex)
                {
                    lstMonthID.SelectedIndex = lstMonthID.SelectedIndex + 1;
                }
            }

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
 

        private void txtGroupName_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void uctxtBranch_TextChanged(object sender, EventArgs e)
        {
            lstBranch.SelectedIndex = lstBranch.FindString(uctxtBranch.Text);
        }
        private void uctxtBranch_GotFocus(object sender, System.EventArgs e)
        {

            lstBranch.Visible = true;
            lstBranch.SelectedIndex = lstBranch.FindString(uctxtBranch.Text);
        }
        private void lstBranch_DoubleClick(object sender, EventArgs e)
        {
            uctxtBranch.Text = lstBranch.Text;
            lstBranch.Visible = false;

    
            lstLeft.Items.Clear();
            lstRight.Items.Clear();

            dtpFDate.Focus();
        }
        private void uctxtBranch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBranch.Items.Count > 0)
                {
                    uctxtBranch.Text = lstBranch.Text;
             
                    lstBranch.Visible = false;
                }
           
                lstLeft.Items.Clear();
                lstRight.Items.Clear();
                dtpFDate.Focus();
          
            }
            
        }
        private void uctxtBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstBranch.SelectedItem != null)
                {
                    lstBranch.SelectedIndex = lstBranch.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstBranch.Items.Count - 1 > lstBranch.SelectedIndex)
                {
                    lstBranch.SelectedIndex = lstBranch.SelectedIndex + 1;
                }
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

        private void dateset()
        {
            string strMonth = "";
            int intMonth = 0, intYY = 0;

            //strMonth = txtMonthID.Text.Substring(0, 3).ToUpper();

            //intYY = Convert.ToInt32(txtMonthID.Text.Substring(3, 2));
            intYY = Convert.ToInt32("20" + intYY);
            if (strMonth == "JAN")
            {
                intMonth = 1;
            }
            else if (strMonth == "FEB")
            {
                intMonth = 2;
            }
            else if (strMonth == "MAR")
            {
                intMonth = 3;
            }

            else if (strMonth == "APR")
            {
                intMonth = 4;
            }

            else if (strMonth == "MAY")
            {
                intMonth = 5;
            }

            else if (strMonth == "JUN")
            {
                intMonth = 6;
            }

            else if (strMonth == "JUL")
            {
                intMonth = 7;
            }

            else if (strMonth == "AUG")
            {
                intMonth = 8;
            }

            else if (strMonth == "SEP")
            {
                intMonth = 9;
            }

            else if (strMonth == "OCT")
            {
                intMonth = 10;
            }
            else if (strMonth == "NOV")
            {
                intMonth = 11;
            }
            else if (strMonth == "DEC")
            {
                intMonth = 12;
            }
            else
            {
                return;
            }

            var startOfMonth = new DateTime(intYY, intMonth, 1);
            dteFromDate.Text = Convert.ToDateTime(startOfMonth).ToString();
            dteToDate.Text = dteFromDate.Value.AddMonths(-1).ToString();

            strThisMonth = Convert.ToDateTime(dteFromDate.Text).ToString("MMMyy");
            strLastMonth = Convert.ToDateTime(dteToDate.Text).ToString("MMMyy");

        }

        private void frmRptSalesCollectionPerformance_Load(object sender, EventArgs e)
        {
            dtpFDate.Text = Utility.FirstDayOfMonth(Convert.ToDateTime(dtpFDate.Text)).ToString("dd-MM-yyyy");
            lstMonthID.Visible = false;
            groupSelection.Enabled = false;
            dteToDate.Text = DateTime.Now.ToString();
            uctxtBranch.Focus();
            lstBranch.Visible = false;
            lstMrName.Visible = false;
            lstMonthID.Visible = false;
            lstBranch.ValueMember = "Key";
            lstBranch.DisplayMember = "Value";
            //lstBranch.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
            lstBranch.DataSource = accms.mfillBranchNew(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
        }

   
        private void rbtnMPO_Click(object sender, EventArgs e)
        {

            mLoadLedgerName();
          

        }

        private void rbtnAMFM_Click(object sender, EventArgs e)
        {
            mLoadLedgerName();
        }

        private void rbtnDSMRSM_Click(object sender, EventArgs e)
        {
            mLoadLedgerName();
        }

        private void rbtnZONE_Click(object sender, EventArgs e)
        {
            mLoadLedgerName();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            BranchId();

            string  strString2 = "", strString3 = "", strString4 = "";
            int intmode = 0, intSalesCollAch = 0, intSelection = 0, intBaseTarget = 0, intSpecialMonitor = 0;

            if (radAllStatus.Checked == true)
            {
                intSelection = 2;
            }
            else if (radActive.Checked == true)
            {
                intSelection = 0;
            }
            else if (radInactive.Checked == true)
            {
                intSelection = 1;
            }

            if (chkboxSalesPer.Checked == true)
            {
                intSalesCollAch = 1;
            }
            if (chkboxCollAch.Checked == true)
            {
                intSalesCollAch = 2;
            }

            if (rbtnAll.Checked == true)
            {
                intmode = 5;
            }
            if (rbtnMPO.Checked == true)
            {
                intmode = 4;
            }
            if (rbtnAMFM.Checked == true)
            {
                intmode = 3;
            }
            if (rbtnDSMRSM.Checked == true)
            {
                intmode = 2;
            }
            if (rbtnZONE.Checked == true)
            {
                intmode = 1;
            }
            if (chkBaseTarget.Checked==true)
            {
                intBaseTarget = 1;
            }
            else
            {
                intBaseTarget = 0;
            }

         
            if (rbtnAll.Checked != true)
            {

                if (lstRight.Items.Count <= 0)
                {
                    MessageBox.Show("Data Not Found.");
                    return;
                }
            }


            if (chkbSpecialMonitor.Checked== true)
            {
                intSpecialMonitor = 1;
            }
            else
            {
                intSpecialMonitor = 0;
            }

            for (int i = 0; i < lstRight.Items.Count; i++)
            {
                strString2 = strString2 + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
            }
            if (strString2 != "")
            {
                strString2 = Utility.Mid(strString2, 0, strString2.Length - 1);
            }

            frmReportViewer frmviewer = new frmReportViewer();
            frmviewer.selector = ViewerSelector.SalesCollectonperformance;
            frmviewer.strString2 = strString2;
            frmviewer.strFdate = dtpFDate.Text;
            frmviewer.strTdate = dtpTDate.Text;
            frmviewer.strBranchId = strBranchId;
            frmviewer.intMode = intmode;
            frmviewer.intStatusNew = intSelection;
            frmviewer.intSuppress2 = intSpecialMonitor;
            frmviewer.intStatus = intSalesCollAch;
            frmviewer.secondParameter1 = uctxtBranch.Text;
            frmviewer.reportTitle2 = "A";
            frmviewer.intCheckStatus = intBaseTarget;
            frmviewer.Show();

        }

        private void BranchId()
        {
            if (uctxtBranch.Text == "")
            {
                MessageBox.Show("Please Select Branch Name.");
                return;
            }
            else
            {
                strBranchId = Utility.gstrGetBranchID(strComID, uctxtBranch.Text);
            }

        }

        private void rbtnAll_Click(object sender, EventArgs e)
        {
            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            groupSelection.Enabled = false;

        }

        private void chkboxSalesPer_MouseClick(object sender, MouseEventArgs e)
        {
            if (chkboxSalesPer.Checked == true)
            {
                chkboxSalesPer.Checked = true;
                chkboxCollAch.Checked = false;
           
            }
            else
            {
                chkboxSalesPer.Checked = false;
                chkboxCollAch.Checked = false;
            }

        }

        private void chkboxCollAch_MouseClick(object sender, MouseEventArgs e)
        {
            if (chkboxCollAch.Checked == true)
            {
                chkboxCollAch.Checked = true;
                chkboxSalesPer.Checked = false;
         
            }
            else
            {
                chkboxCollAch.Checked = false;
                chkboxSalesPer.Checked = false;
           
            }

        }

        private void radAllStatus_Click(object sender, EventArgs e)
        {
            mLoadLedgerName();
        }

        private void radActive_Click(object sender, EventArgs e)
        {
            mLoadLedgerName();
        }

        private void radInactive_Click(object sender, EventArgs e)
        {
            mLoadLedgerName();
        }

     
       

     

       
       

    
    }
}
