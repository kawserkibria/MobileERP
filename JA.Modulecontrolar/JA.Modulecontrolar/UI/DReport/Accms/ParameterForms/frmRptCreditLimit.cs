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
namespace JA.Modulecontrolar.UI.DReport.Accms.ParameterForms
{
    public partial class frmRptCreditLimit : JA.Shared.UI.frmSmartFormStandard
    {
        private ListBox lstBranch = new ListBox();
        private ListBox lstMrName = new ListBox();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        private string strComID { get; set; }
        public string strReportName { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        List<Invoice> ooPartyName;
        List<AccountdGroup> oogrp;
        public frmRptCreditLimit()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.dteFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteFromDate_KeyPress);
            this.dteToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteToDate_KeyPress);
            this.dteToDate.TextChanged += new System.EventHandler(this.dteToDate_TextChanged);
            this.dteToDate.KeyDown += new KeyEventHandler(dteToDate_KeyDown);
      
            this.uctxtBranch.GotFocus += new System.EventHandler(this.uctxtBranch_GotFocus);
            this.uctxtBranch.KeyDown += new KeyEventHandler(uctxtBranch_KeyDown);
            this.uctxtBranch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranch_KeyPress);
            this.lstBranch.DoubleClick += new System.EventHandler(this.lstBranch_DoubleClick);
            this.uctxtBranch.TextChanged += new System.EventHandler(this.uctxtBranch_TextChanged);

            this.uctxtMrName.GotFocus += new System.EventHandler(this.uctxtMrName_GotFocus);
            this.uctxtMrName.KeyDown += new KeyEventHandler(uctxtMrName_KeyDown);
            this.uctxtMrName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtMrName_KeyPress);
            this.uctxtMrName.TextChanged += new System.EventHandler(this.uctxtMrName_TextChanged);
            this.uctxtMrName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uctxtMrName_KeyUp);
            this.DGMr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(DGMr_KeyPress);
            this.DGMr.DoubleClick += new System.EventHandler(this.DGMr_DoubleClick);
            this.DGMr.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGMr_CellFormatting);
            Utility.CreateListBox(lstBranch, pnlMain, uctxtBranch, 0);
            Utility.CreateListBox(lstMrName, pnlMain, uctxtMrName, 0);
        }

        #region "User Deifne"
        private void DGMr_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DGMr.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Yellow;
            DGMr.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            DGMr.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("verdana", 9);
        }
        private void DGMr_DoubleClick(object sender, EventArgs e)
        {

            if (DGMr.SelectedRows.Count > 0)
            {
                int i = Convert.ToInt16(DGMr.CurrentRow.Index.ToString());
                //uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                //uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                uctxtMrName.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                DGMr.Visible = false;
                dteFromDate.Focus();
            }
        }
        private void DGMr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                int i = Convert.ToInt16(DGMr.CurrentRow.Index.ToString());
                //uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                //uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                uctxtMrName.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                DGMr.Visible = false;
                dteFromDate.Focus();
                
            }
        }

        private void uctxtMrName_KeyDown(object sender, KeyEventArgs e)
        {
            DGMr.Visible = true;
            if (e.KeyCode == Keys.Up)
            {
                DGMr.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                DGMr.Focus();
            }
            DGMr.Top = uctxtMrName.Top + 25;
            DGMr.Left = uctxtMrName.Left;
            DGMr.Width = uctxtMrName.Width;
            DGMr.Height = 200;
            DGMr.BringToFront();
            DGMr.AllowUserToAddRows = false;
            return;
        }
        private void dteToDate_TextChanged(object sender, EventArgs e)
        {
            //btnPrint.Focus();
        }
        private void uctxtMrName_TextChanged(object sender, EventArgs e)
        {
            if (rbtMPOGroup.Checked)
            {
                if (uctxtMrName.Text == "")
                {
                    uctxtTerritoryCode.Text = "";
                    uctxtTeritorryName.Text = "";
                }
            }
            else
            {

            }
        }
        private void uctxtMrName_GotFocus(object sender, System.EventArgs e)
        {
           
        }
        private void uctxtMrName_KeyUp(object sender, KeyEventArgs e)
        {
            if (rbtMPOGroup.Checked)
            {
                SearchListViewGroupName(oogrp, uctxtMrName.Text);
            }
            else
            {
                SearchListViewMPO(ooPartyName, uctxtMrName.Text);
            }
        }
        private void SearchListViewMPO(IEnumerable<Invoice> tests, string searchString = "")
        {
            IEnumerable<Invoice> query;
            query = tests;
            if (searchString != "")
            {
                query = tests.Where(x => x.strMereString.ToLower().Trim().Contains(searchString.ToLower().Trim()));
            }
            DGMr.Rows.Clear();
            int i = 0;
            try
            {
                foreach (Invoice tran in query)
                {
                    DGMr.Rows.Add();
                    DGMr[0, i].Value = tran.strTeritorryCode;
                    DGMr[1, i].Value = tran.strTeritorryName;
                    DGMr[2, i].Value = tran.strLedgerName;
                    DGMr[3, i].Value = tran.strMereString;
                    i += 1;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void SearchListViewGroupName(IEnumerable<AccountdGroup> tests, string searchString = "")
        {
            IEnumerable<AccountdGroup> query;
            query = tests;
            if (searchString != "")
            {
                query = tests.Where(x => x.GroupName.ToLower().Trim().Contains(searchString.ToLower().Trim()));
            }

            DGMr.Rows.Clear();
            int i = 0;
            try
            {
                foreach (AccountdGroup tran in query)
                {
                    DGMr.Rows.Add();
                    DGMr[0, i].Value = "";
                    DGMr[1, i].Value = "";
                    DGMr[2, i].Value = tran.GroupName;
                    DGMr[3, i].Value = tran.GroupName;
                    i += 1;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void uctxtMrName_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtMrName.Text == "")
                {
                    uctxtMrName.Text = "";
                    if (DGMr.Rows.Count > 0)
                    {
                        int i = 0;
                        DGMr.Visible = true;
                    }

                    DGMr.Visible = false;

                    return;
                }
                if (uctxtMrName.Text != "")
                {
                    DGMr.Focus();
                    if (DGMr.Rows.Count > 0)
                    {
                        int i = 0;
                        //uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                        //uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                        uctxtMrName.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                        DGMr.Visible = false;
                        dteFromDate.Focus();
                        
                    }
                }
                else
                {
                    int i = 0;

                    //uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                    //uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                    uctxtMrName.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                    DGMr.Visible = false;
                    dteFromDate.Focus();
                }
            }
        }
        private void uctxtBranch_TextChanged(object sender, EventArgs e)
        {
            lstBranch.SelectedIndex = lstBranch.FindString(uctxtBranch.Text);
        }
        private void uctxtBranch_GotFocus(object sender, System.EventArgs e)
        {

            lstBranch.Visible = true;

            lstBranch.SelectedIndex = lstBranch.FindString(uctxtBranch.Text);


            lstBranch.Top = 174;
            lstBranch.Left = 151;
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
        private void dteToDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                btnPrint.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                btnPrint.Focus();
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
                dteToDate.Focus();
                int year = dteFromDate.Value.Year;
                int Mont = dteFromDate.Value.Month;
                DateTime firstDay = new DateTime(year, Mont, 1);
                DateTime lastDay = new DateTime(year, 12, 31);
                dteFromDate.Text = firstDay.ToString();
                dteFromDate2.Value = dteFromDate.Value.AddMonths(1);
                dteFromDate3.Value = dteFromDate2.Value.AddMonths(1);
                dteFromDate4.Value = dteFromDate3.Value.AddMonths(1);
                dtpLastDate.Value = dteFromDate4.Value.AddMonths(1);
                dteToDate.Value = dtpLastDate.Value.AddDays(-1);
            }
        }
        private void dteToDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnPrint.Focus();
        }
        
        #endregion
  
        private void mloadGroup()
        {
            int introw = 0;
            DGMr.Rows.Clear();

            oogrp = accms.GetGroupList(strComID, 202, false, Utility.gstrUserName).ToList();

            if (oogrp.Count > 0)
            {

                foreach (AccountdGroup ogrp in oogrp)
                {
                    DGMr.Columns[2].HeaderText = "MPO Group";
                    DGMr.Rows.Add();
                    DGMr.Columns[1].Visible = false;
                    DGMr.Columns[0].Visible = false;
                    DGMr[2, introw].Value = ogrp.GroupName;
                    DGMr[3, introw].Value = ogrp.GroupName;
                    introw += 1;
                }

                DGMr.AllowUserToAddRows = false;
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            string strBranchId = "";
            int intRtst = 0;
            if (uctxtBranch.Text == "")
            {
                MessageBox.Show("Please Select Branch Name.");
                return;
            }
            else
            {
                strBranchId = Utility.gstrGetBranchID(strComID, uctxtBranch.Text);
            }
                
                int year =dteFromDate.Value.Year;
                int Mont = dteFromDate.Value.Month;
                DateTime firstDay = new DateTime(year, Mont, 1);
                DateTime lastDay = new DateTime(year, 12, 31);
                dteFromDate.Text = firstDay.ToString();
                dteFromDate2.Value = dteFromDate.Value.AddMonths(1);
                dteFromDate3.Value = dteFromDate2.Value.AddMonths(1);
                dteFromDate4.Value = dteFromDate3.Value.AddMonths(1);
                dtpLastDate.Value = dteFromDate4.Value.AddMonths(1);
                dteToDate.Value = dtpLastDate.Value.AddDays(-1);
                if (radAll.Checked == true)
                {

                  
                    JA.Modulecontrolar.UI.DReport.Accms.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Accms.Viewer.frmReportViewer();
                    frmviewer.selector = JA.Modulecontrolar.UI.DReport.Accms.ViewerSelector.CreditLimit;
                    frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                    frmviewer.strTdate = dteFromDate2.Value.ToString("dd-MM-yyyy");
                    frmviewer.strString = dteFromDate3.Value.ToString("dd-MM-yyyy");
                    frmviewer.strString2 = dteFromDate4.Value.ToString("dd-MM-yyyy");
                    frmviewer.strString3 = dtpLastDate.Value.ToString("dd-MM-yyyy");
                    frmviewer.strSelf = dteToDate.Value.ToString("dd-MM-yyyy");
                    frmviewer.mstrBranchName = "Branch :" + uctxtBranch.Text;
                    frmviewer.strBranchID = strBranchId;
                    frmviewer.strSelction = "";
                    frmviewer.intVtype = 0;
                    frmviewer.intSP = 0;
                    if (chkboxPendingS.Checked == true)
                    {
                        if (rbtnasc.Checked== true)
                        {
                            frmviewer.intSP = 1;
                          
                        }

                        else  
                        {
                            frmviewer.intSP = 2;
                        }
                    
                   
                    }
                    frmviewer.Show();
                    return;
                }

                if (radIndividual.Checked == true)
                {

                    JA.Modulecontrolar.UI.DReport.Accms.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Accms.Viewer.frmReportViewer();
                    frmviewer.selector = JA.Modulecontrolar.UI.DReport.Accms.ViewerSelector.CreditLimit;
                    frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                    frmviewer.strTdate = dteFromDate2.Value.ToString("dd-MM-yyyy");
                    frmviewer.strString = dteFromDate3.Value.ToString("dd-MM-yyyy");
                    frmviewer.strString2 = dteFromDate4.Value.ToString("dd-MM-yyyy");
                    frmviewer.strString3 = dtpLastDate.Value.ToString("dd-MM-yyyy");
                    frmviewer.strSelf = dteToDate.Value.ToString("dd-MM-yyyy");
                    frmviewer.mstrBranchName = "Branch :" + uctxtBranch.Text;
                    frmviewer.strBranchID = strBranchId;
                    frmviewer.strSelction = uctxtMrName.Text;
                    if (rbtMPOGroup.Checked)
                    {
                        frmviewer.intVtype = 2;
                    }
                    if (rbtMPO.Checked)
                    {
                        frmviewer.intVtype = 1;
                    }
                    frmviewer.Show();
                    return;
                }
            }
           
        private void radIndividual_Click(object sender, EventArgs e)
        {
            PnlMPOGroup.Visible = true;
            rbtMPOGroup.PerformClick();
            chkboxPendingS.Checked = false;
            chkboxPendingS.Visible = false;
            panel3.Visible = false;

       
        }
        private void radAll_Click(object sender, EventArgs e)
        {
            chkboxPendingS.Visible = true;
            panel3.Visible = false;
            labCatname.Visible = false;
            DGMr.Visible = false;
            uctxtMrName.Visible = false;
            dteFromDate.Focus();
            PnlMPOGroup.Visible = false;
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radAll_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbtMPOGroup_Click(object sender, EventArgs e)
        {
            labCatname.Visible = true;
            DGMr.Visible = false;
            uctxtMrName.Visible = true;
            uctxtMrName.Visible = true;
            uctxtMrName.Text = "";
            DGMr.Top = uctxtMrName.Top + 25;
            DGMr.Left = uctxtMrName.Left;
            DGMr.Width = uctxtMrName.Width;
            DGMr.Height = 200;
            DGMr.BringToFront();
            DGMr.Visible = true;
            DGMr.AllowUserToAddRows = false;
            labCatname.Text = "MPO Group :";

            mloadGroup();
            uctxtMrName.Focus();
        }


        private void frmRptCreditLimit_Load(object sender, EventArgs e)
        {
            frmLabel.Text = strReportName;
            //if (strReportName == "Credit Limit")
            //{
            //    groupBox2.Visible = true;
            //}
            //else
            //{
            //    groupBox2.Visible = false;
            //}

       
            panel3.Visible = false;
        
            lstBranch.Visible = false;
            lstMrName.Visible = false;
            lstBranch.ValueMember = "BranchID";
            lstBranch.DisplayMember = "BranchName";
            lstBranch.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
            labCatname.Visible = false;
            DGMr.Visible = false;
            uctxtMrName.Visible = false;
            PnlMPOGroup.Visible = false;
           

            dteToDate.Focus();
            int year = dteFromDate.Value.Year;
            int Mont = dteFromDate.Value.Month;
            DateTime firstDay = new DateTime(year, Mont, 1);
            DateTime lastDay = new DateTime(year, 12, 31);
            dteFromDate.Text = firstDay.ToString();
            dteFromDate2.Value = dteFromDate.Value.AddMonths(1);
            dteFromDate3.Value = dteFromDate2.Value.AddMonths(1);
            dteFromDate4.Value = dteFromDate3.Value.AddMonths(1);
            dtpLastDate.Value = dteFromDate4.Value.AddMonths(1);
            dteToDate.Value = dtpLastDate.Value.AddDays(-1);
            uctxtBranch.Select();
        }

        private void rbtMPO_Click(object sender, EventArgs e)
        {
            labCatname.Text = "MPO :";
            mloadParty();

        }
        private void mloadParty()
        {
            int introw = 0;
            DGMr.Rows.Clear();

            ooPartyName = invms.mfillPartyNameNew(strComID, lstBranch.SelectedValue.ToString(), Utility.gblnAccessControl, Utility.gstrUserName, 0, "","").ToList();

            if (ooPartyName.Count > 0)
            {
                labCatname.Visible = true;
                DGMr.Visible = false;
                uctxtMrName.Visible = true;
                uctxtMrName.Visible = true;
                uctxtMrName.Text = "";
                DGMr.Top = uctxtMrName.Top + 25;
                DGMr.Left = uctxtMrName.Left;
                DGMr.Width = uctxtMrName.Width;
                DGMr.Height = 200;
                DGMr.BringToFront();
                DGMr.Visible = true;
                DGMr.AllowUserToAddRows = false;
                uctxtMrName.Focus();
                DGMr.Columns[2].HeaderText = "MPO Name";
                foreach (Invoice ogrp in ooPartyName)
                {                                    
                    DGMr.Rows.Add();
                    DGMr.Columns[1].Visible = true;
                    DGMr.Columns[0].Visible = true;
                    DGMr[0, introw].Value = ogrp.strTeritorryCode;
                    DGMr[1, introw].Value = ogrp.strTeritorryName;
                    DGMr[2, introw].Value = ogrp.strLedgerName;
                    DGMr[3, introw].Value = ogrp.strMereString;
                    introw += 1;
                }

                DGMr.AllowUserToAddRows = false;
            }
        }

        private void chkboxPendingS_Click(object sender, EventArgs e)
        {
            if (chkboxPendingS.Checked== true)
            {
                panel3.Visible = true;
            }
            else
            {
                panel3.Visible = false;
            }
        }
      
    }
}
