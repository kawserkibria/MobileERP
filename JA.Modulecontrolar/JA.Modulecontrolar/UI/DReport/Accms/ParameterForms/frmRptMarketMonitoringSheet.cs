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
using JA.Modulecontrolar.JACCMS;
using JA.Modulecontrolar.UI.DReport.Accms.Viewer;
using Microsoft.Win32;
using JA.Modulecontrolar.EXTRA;

namespace JA.Modulecontrolar.UI.DReport.Accms.ParameterForms
{
    public partial class frmRptMarketMonitoringSheet : JA.Shared.UI.frmSmartFormStandard 
    {
        private ListBox lstBranch = new ListBox();
        private ListBox lstMrName = new ListBox();
        EXTRA.SWPRJClient objExtra = new EXTRA.SWPRJClient();
        private string strComID { get; set; }
        //private ListBox lstGroupConfig = new ListBox();
        List<Invoice> ooPartyName;
        List<AccountdGroup> oogrp;
        List<Mprojection> orptt;
        string strBranchId = "";
        public string strReportName { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public frmRptMarketMonitoringSheet()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.dteFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteFromDate_KeyPress);
            //this.dteFromDate.GotFocus += new System.EventHandler(this.dteFromDate_GotFocus);

            this.dteToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteToDate_KeyPress);

            this.uctxtBranch.GotFocus += new System.EventHandler(this.uctxtBranch_GotFocus);
            this.uctxtBranch.KeyDown += new KeyEventHandler(uctxtBranch_KeyDown);
            this.uctxtBranch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranch_KeyPress);
            this.lstBranch.DoubleClick += new System.EventHandler(this.lstBranch_DoubleClick);
            this.uctxtBranch.TextChanged += new System.EventHandler(this.uctxtBranch_TextChanged);
            this.lstLeft.DoubleClick += new System.EventHandler(this.lstLeft_DoubleClick);
            this.lstRight.DoubleClick += new System.EventHandler(this.lstRight_DoubleClick);
            this.btnRightAll.Click += new System.EventHandler(this.btnRightAll_Click);
            this.btnRightSingle.Click += new System.EventHandler(this.btnRightSingle_Click);
            this.btnLeftSingle.Click += new System.EventHandler(this.btnLeftSingle_Click);
            this.btnLeftAll.Click += new System.EventHandler(this.btnLeftAll_Click);
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            this.lstLeft.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstLeft_KeyPress);
            Utility.CreateListBox(lstBranch, pnlMain, uctxtBranch, 0);
           
        }
        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {

            SearchListViewPartyName(orptt, txtSearch.Text);
            
        }
        private void SearchListViewPartyName(IEnumerable<Mprojection> tests, string searchString = "")
        {
            IEnumerable<Mprojection> query;
            query = tests;
            if (searchString != "")
            {
                if (radMpo.Checked == true)
                {
                    query = tests.Where(x => x.strGRName.ToLower().Trim().Contains(searchString.ToLower().Trim()));
                }
                else if (rbtnArea.Checked == true)
                {
                    query = tests.Where(x => x.strGRName.ToLower().Trim().Contains(searchString.ToLower().Trim()));
                }
                else if (rbtnDivision.Checked == true)
                {
                    query = tests.Where(x => x.strGRName.ToLower().Trim().Contains(searchString.ToLower().Trim()));
                }
                else if (rbtnZone.Checked == true)
                {
                    query = tests.Where(x => x.strGRName.ToLower().Trim().Contains(searchString.ToLower().Trim()));
                }

            }

            lstLeft.Items.Clear();
            
            try
            {
               
                foreach (Mprojection tran in query)
                {
                    lstLeft.Items.Add(tran.strGRName);
                    lstLeft.SetSelected(0, true);
                }


            }
            catch (Exception ex)
            {
                ex.ToString();
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

        private void lstLeft_DoubleClick(object sender, EventArgs e)
        {
            if (lstLeft.SelectedItems.Count > 0)
            {
                lstRight.Items.Add(lstLeft.SelectedItem.ToString());
                lstRight.SelectedValue = lstLeft.SelectedValue;
                lstLeft.Items.Remove(lstLeft.SelectedItem.ToString());
            }

        }
        private void lstRight_DoubleClick(object sender, EventArgs e)
        {
            if (lstRight.SelectedItems.Count > 0)
            {
                lstLeft.Items.Add(lstRight.SelectedItem.ToString());
                lstLeft.SelectedValue = lstRight.SelectedValue;
                lstRight.Items.Remove(lstRight.SelectedItem.ToString());
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
        private void TxtGreater_GotFocus(object sender, System.EventArgs e)
        {
            //txtLess.Text = "";
        }

        private void TxtGreater_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dteFromDate.Focus();
            }
        }

      
        private void txtLess_GotFocus(object sender, System.EventArgs e)
        {
            //TxtGreater.Text = "";
        }

        private void txtLess_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dteFromDate.Focus();
            }

        }
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
            dteFromDate.Focus();
           
        }
        private void uctxtBranch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBranch.Items.Count > 0)
                {
                    uctxtBranch.Text = lstBranch.Text;
                    dteFromDate.Focus();
                    lstBranch.Visible = false;
                }

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
        private void dteFromDate_GotFocus(object sender, System.EventArgs e)
        {
            lstBranch.Visible = false;
         
        }
     
        private void dteFromDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dteFromDate.Text = Utility.FirstDayOfMonth (dteFromDate.Value).ToString();
                dteToDate.Text = Utility.LastDayOfMonth(dteFromDate.Value).ToString();
                dteToDate.Focus();

            }
        }

        private void dteToDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                //dteToDate.Text = Utility.LastDayOfMonth(dteToDate.Value).ToString();
                btnPrint.Focus();

            }
        }
        

        #endregion


        private void btnPrint_Click(object sender, EventArgs e)
        {


            string strMonthID = "", strString2 = "";

            int intSelection = 0, intSumm = 0, intBaseTarget = 0, intReportOption = 0, intspreport = 1,intDetails=0;


            if (uctxtBranch.Text == "")
            {
                MessageBox.Show("Please Select Branch Name.");
                return;
            }
            else
            {
                strBranchId = Utility.gstrGetBranchID(strComID, uctxtBranch.Text);
            }

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

            if (radAll.Checked == true)
            {
                intReportOption = 1;
            }
            else if (radMpo.Checked == true)
            {
                intReportOption = 2;
            }
            else if (rbtnArea.Checked == true)
            {
                intReportOption = 3;
            }
            else if (rbtnDivision.Checked == true)
            {
                intReportOption = 4;
            }
            else if (rbtnZone.Checked == true)
            {
                intReportOption = 5;
            }
            else
            {
                intReportOption = 0;
            }

            if (chkBaseTarget.Checked == true)
            {
                intBaseTarget = 1;
            }
            else
            {
                intBaseTarget = 0;
            }
           

            if (chkboxSpecial.Checked != true)
            {
                intspreport = 0;
                dteFromDate.Text = Utility.FirstDayOfMonth(dteFromDate.Value).ToString();
                //dteToDate.Text = Utility.LastDayOfMonth(dteToDate.Value).ToString();
                dteToDate.Text = dteToDate.Text;
            }


            if (radAll.Checked == true)
            {
                intSumm = 1;
            }
            if (chkboxDetails.Checked == true)
            {
                intDetails= 1;
            }
            DateTime dateTimePicker1 = dteFromDate.Value;

            int intTotalMonth = Utility.GetMonthDifference(dteToDate.Value, dteFromDate.Value);

            for (int introw = 1; introw <= intTotalMonth; introw++)
            {

                strMonthID = strMonthID + "'" + dateTimePicker1.ToString("MMMyy").ToUpper() + "',";
                dateTimePicker1 = dateTimePicker1.AddMonths(1);
            }
            if (strMonthID != "")
            {
                strMonthID = Utility.Mid(strMonthID, 0, strMonthID.Length - 1);
            }


            if (radAll.Checked != true)
            {

                if (lstRight.Items.Count <= 0)
                {
                    MessageBox.Show("Data Not Found.");
                    return;
                }
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
            frmviewer.selector = ViewerSelector.MarketMonitoring;
            frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
            frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
            frmviewer.strBranchID = strBranchId;
            frmviewer.intNarration = intSelection;
            frmviewer.intVtype = intReportOption;
            frmviewer.intSummDetails = intSumm;
            frmviewer.strString = strMonthID;
            frmviewer.intTarget = intBaseTarget;
            frmviewer.intSP = intspreport;
            frmviewer.intValueSuppress = intDetails;
            frmviewer.strString2 = strString2;
            frmviewer.Show();



        }

        private void frmRptMarketMonitoringSheet_Load(object sender, EventArgs e)
        {
            dteFromDate.Text = Utility.FirstDayOfMonth(dteFromDate.Value).ToString();
            dteToDate.Text = Utility.LastDayOfMonth(dteToDate.Value).ToString();
            uctxtBranch.Focus();
            lstBranch.Visible = false;
            lstMrName.Visible = false;
            groupSelection.Enabled = false;
            lstBranch.ValueMember = "Key";
            lstBranch.DisplayMember = "Value";
            lstBranch.DataSource = accms.mfillBranchNew(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();

            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 222))
                {
                    //MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    chkboxSpecial.Visible = false;
                    return;
                }
            }
        }

        private void radMpo_Click(object sender, EventArgs e)
        {
            
            mLoadLedgerName();
          
        }

        private void mLoadLedgerName()
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
            int Intmode = 0, intSelection = 0;
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


            if (radAll.Checked == true)
            {
                Intmode = 5;
            }
            if (radMpo.Checked == true)
            {
                Intmode = 4;
            }
            if (rbtnArea.Checked == true)
            {
                Intmode = 3;
            }
            if (rbtnDivision.Checked == true)
            {
                Intmode = 2;
            }
            if (rbtnZone.Checked == true)
            {
                Intmode = 1;
            }

            if (Intmode < 5)
            {
                 orptt = objExtra.mGetLedgerGroupLoad(strComID, Intmode, Utility.gstrUserName, intSelection, strBranchId).ToList();
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
                dteFromDate.Focus();
            }
        }

        private void radAll_Click(object sender, EventArgs e)
        {
            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            groupSelection.Enabled = false;
        }

        private void rbtnArea_Click(object sender, EventArgs e)
        {
          
            mLoadLedgerName();
           
        }

        private void rbtnDivision_Click(object sender, EventArgs e)
        {
          
            mLoadLedgerName();
            
        }

        private void rbtnZone_Click(object sender, EventArgs e)
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

        private void radAllStatus_Click(object sender, EventArgs e)
        {
            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            groupSelection.Enabled = true;
            mLoadLedgerName();
        }

        private void rbtnZone_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstLeft.SelectedItem != null)
                {
                    lstLeft.SelectedIndex = lstLeft.SelectedIndex - 1;
                    lstLeft.Focus();
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstLeft.Items.Count - 1 > lstLeft.SelectedIndex)
                {
                    lstLeft.SelectedIndex = lstLeft.SelectedIndex + 1;
                    lstLeft.Focus();
                }
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==(char)Keys.Return)
            {
                if (txtSearch.Text == "")
                {
                    dteFromDate.Focus();
                }
                else
                {
                    btnRightSingle.PerformClick();
                }
            }
        }

        private void btnRightSingle_Click_1(object sender, EventArgs e)
        {

        }

        private void lstLeft_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==(char)Keys.Return)
            {
                btnRightSingle.PerformClick();
                lstLeft.Focus();
            }
        }

        private void chkboxSpecial_Click(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
            grpBox.Enabled = false;
            if (chkboxSpecial.Checked == true)
            {
                chkBaseTarget.Checked = false;
                radMpo.Checked = true;
                radActive.Checked = true;
                chkboxSpecial.Checked = true;
                mLoadLedgerName();
                groupBox2.Enabled = false;
                grpBox.Enabled = false;

            }
            else
            {
                chkboxSpecial.Checked = false;
                groupBox2.Enabled = true;
                grpBox.Enabled = true;

            }

        }

        private void chkBaseTarget_Click(object sender, EventArgs e)
        {
            chkboxSpecial.Checked = false;
            groupBox2.Enabled = true;
            grpBox.Enabled = true;
        }
    }
}
