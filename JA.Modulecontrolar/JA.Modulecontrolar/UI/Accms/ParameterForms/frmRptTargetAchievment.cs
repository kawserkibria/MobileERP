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
    public partial class frmRptTargetAchievment : JA.Shared.UI.frmSmartFormStandard 
    {
        private ListBox lstBranch = new ListBox();
        private ListBox lstMrName = new ListBox();

        //private ListBox lstGroupConfig = new ListBox();
        List<Invoice> ooPartyName;
        List<AccountdGroup> oogrp;
        private string strComID { get; set; }
        public string strReportName { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public frmRptTargetAchievment()
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

            this.uctxtLedgerConfig.KeyDown += new KeyEventHandler(uctxtLedgerConfig_KeyDown);
            this.uctxtLedgerConfig.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtLedgerConfig_KeyPress);
            this.uctxtLedgerConfig.TextChanged += new System.EventHandler(this.uctxtLedgerConfig_TextChanged);
            this.uctxtLedgerConfig.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uctxtLedgerConfig_KeyUp);
            this.uctxtLedgerConfig.GotFocus += new System.EventHandler(this.uctxtLedgerConfig_GotFocus);
            this.DGMr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(DGMr_KeyPress);
            this.DGMr.DoubleClick += new System.EventHandler(this.DGMr_DoubleClick);
            this.DGMr.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGMr_CellFormatting);

            Utility.CreateListBox(lstBranch, pnlMain, uctxtBranch, 0);
           
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
                if (DGMr.Rows[i].Cells[0].Value != null)
                {
                    uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                }
                else
                {
                    uctxtTerritoryCode.Text = "";
                }
                if (DGMr.Rows[i].Cells[1].Value != null)
                {
                    uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                }
                else
                {
                    uctxtTeritorryName.Text = "";
                }
                uctxtLedgerConfig.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                DGMr.Visible = false;
                btnPrint.Focus();


            }
        }
        private void DGMr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                int i = Convert.ToInt16(DGMr.CurrentRow.Index.ToString());
                if (DGMr.Rows[i].Cells[0].Value != null)
                {
                    uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                }
                else
                {
                    uctxtTerritoryCode.Text = "";
                }
                if (DGMr.Rows[i].Cells[1].Value != null)
                {
                    uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                }
                else
                {
                    uctxtTeritorryName.Text = "";
                }
                uctxtLedgerConfig.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                DGMr.Visible = false;
                btnPrint.Focus();
            }
        }

          
        private void uctxtLedgerConfig_TextChanged(object sender, EventArgs e)
        {
            if (uctxtLedgerConfig.Text == "")
            {
                uctxtTerritoryCode.Text = "";
                uctxtTeritorryName.Text = "";
            }
        }
        private void uctxtLedgerConfig_KeyPress(object sender, KeyPressEventArgs e)
        {
        
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtLedgerConfig.Text == "")
                {
                    uctxtLedgerConfig.Text = "";
                    if (DGMr.Rows.Count > 0)
                    {
                        int i = 0;
                        DGMr.Visible = true;
                    }

                    DGMr.Visible = false;

                    return;
                }


                if (uctxtLedgerConfig.Text != "")
                {
                    DGMr.Focus();
                    if (DGMr.Rows.Count > 0)
                    {
                        int i = 0;
                        uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                        uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                        uctxtLedgerConfig.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                        DGMr.Visible = false;
                        dteFromDate.Focus();
                    }
                }
                else
                {
                    int i = 0;

                    uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                    uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                    uctxtLedgerConfig.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                    DGMr.Visible = false;
                    dteFromDate.Focus();
                }
            }

        }
        private void uctxtLedgerConfig_KeyDown(object sender, KeyEventArgs e)
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

            //DGMr.Top = uctxtLedgerConfig.Top + 25;
            //DGMr.Left = uctxtLedgerConfig.Left;
            //DGMr.Width = uctxtLedgerConfig.Width;
            //DGMr.Height = 200;
            //DGMr.BringToFront();
            //DGMr.AllowUserToAddRows = false;
            return;
        }

        private void uctxtLedgerConfig_GotFocus(object sender, System.EventArgs e)
        {
            if ((radGroupwise.Checked == true) && (radIndividual.Checked == true))
            {
                mloadGroup();
                DGMr.Visible = true;
                DGMr.AllowUserToAddRows = true;
            
            }
            else
            {
                mloadParty();
                DGMr.Visible = true;
                DGMr.AllowUserToAddRows = true;
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
                    radGroupwise.Focus();
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

        private void frmRptStoreLedger_Load(object sender, EventArgs e)
        {
            uctxtBranch.Focus();
            DGMr.AllowUserToAddRows = false;
            lstBranch.Visible = false;
            lstMrName.Visible = false;

            lstBranch.ValueMember = "BranchID";
            lstBranch.DisplayMember = "BranchName";
            lstBranch.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();

            //lstMrName.ValueMember = "strLedgerName";
            //lstMrName.DisplayMember = "strLedgerName";
            //lstMrName.DataSource = accms.mFillLedgerList(strComID,(int)Utility.GR_GROUP_TYPE.grCUSTOMER).ToList();
            radGroupwise.PerformClick();
            radAll.PerformClick();
            uctxtLedgerConfig.Visible = false;


            int year = DateTime.Now.Year;
            DateTime firstDay = new DateTime(year, 1, 1);
            DateTime lastDay = new DateTime(year, 12, 31);
            dteFromDate.Text = firstDay.ToString();
            dteToDate.Text = lastDay.ToString();
  
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            int intSelection = 0, intGroupSelection = 0, intmonthNo, intActive = 0, intSuppress;
            //1=Group,3=gropParent,2=primary
            string strBranchId = "", strMonthID = "", strName = "";
            long lngcount = 0;
            if (radLedgerW.Checked==true)
            {
                intSuppress = 1;
            }
            else
            {
                intSuppress = 0;
            }

            if (uctxtBranch.Text == "")
            {
                MessageBox.Show("Please Select Branch Name.");
                return;
            }
            else
            {
                strBranchId = Utility.gstrGetBranchID(strComID, uctxtBranch.Text);
            }
            if (radIndividual.Checked == true)
            {
                if (uctxtLedgerConfig.Text == "")
                {
                    MessageBox.Show("Please Select Leger Group.");
                    return;
                }
            }
            intSelection = 1;
            if (radIndividual.Checked == true)
            {
                if (radGroupwise.Checked == true)
                {
                    intSelection = 1;

                }
                else
                {
                    intSelection = 2;
                }

                strName = uctxtLedgerConfig.Text;
            }
            if (chkStatus.Checked==true)
            {
                intActive = 0;
            }
            else
            {
                intActive = 1;
            }

            if (cbxSelection.Text!= "")
            {
                intSelection = 0;
                if (cbxSelection.Text=="MPO")
                {
                    intGroupSelection = 1;
                    intSuppress = 1;
                    intSelection = 1;
                }
                if (cbxSelection.Text == "ZONE")
                {
                    intGroupSelection = 2;
                }
                if (cbxSelection.Text == "DIVISION")
                {
                    intGroupSelection = 3;
                }
                if (cbxSelection.Text == "AREA")
                {
                    intGroupSelection = 4;
                }
               
            }

            intmonthNo = dteFromDate.Value.Month;
            lngcount = Utility.DateDiff(Utility.DateInterval.Month, dteFromDate.Value, dteToDate.Value);
            DateTime dteFdate = dteFromDate.Value;
            for (int i = intmonthNo; i <= lngcount; i++)
            {
                strMonthID = strMonthID + "'" + dteFdate.ToString("MMMyy").ToUpper() + "',";
                dteFdate = dteFdate.AddMonths(1);
            }

            if (strMonthID != "")
            {
                strMonthID = Utility.Mid(strMonthID, 0, strMonthID.Length - 1);
            }

            frmReportViewer frmviewer = new frmReportViewer();
            frmviewer.selector = ViewerSelector.TargetAchievement;
            frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
            frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
            frmviewer.strBranchID = strBranchId;
            frmviewer.strString = strName;
            frmviewer.strSelction = strMonthID;
            frmviewer.intSummDetails = intSelection;
            frmviewer.intNarration = intActive;
            frmviewer.intSuppress = intSuppress;
            frmviewer.intSP = intGroupSelection;
            frmviewer.Show();

        }
        private void mloadGroup()
        {
            int introw = 0;
            DGMr.Rows.Clear();

            oogrp = accms.GetGroupList(strComID, 202, false, Utility.gstrUserName).ToList();

            if (oogrp.Count > 0)
            {

                foreach (AccountdGroup ogrp in oogrp)
                {
                    DGMr.Rows.Add();
                    DGMr.Columns[1].Visible = false;
                    DGMr.Columns[0].Visible = false;
                    DGMr[2, introw].Value = ogrp.GroupName;
                    DGMr[3, introw].Value = ogrp.GroupName;
                    DGMr.Columns[2].Width = 500;
                    //DataGrid2.Columns.Add(Utility.Create_Grid_Column("Tools Menu Control", "Tools Menu Control", 270, true, DataGridViewContentAlignment.TopLeft, false));
                    //if (introw % 2 == 0)
                    //{
                    //    DGMr.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    DGMr.Rows[introw].DefaultCellStyle.BackColor = Color.White;
                    //}
                    introw += 1;
                }

                DGMr.AllowUserToAddRows = false;
            }
        }
        private void mloadParty()
        {
            int introw = 0;
            DGMr.Rows.Clear();

            ooPartyName = invms.mfillPartyNameNew(strComID, "", false, Utility.gstrUserName, 0, "").ToList();

            if (ooPartyName.Count > 0)
            {

                foreach (Invoice ogrp in ooPartyName)
                {
                    DGMr.Rows.Add();
                    DGMr.Columns[1].Visible = true;
                    DGMr.Columns[0].Visible = true;
                    DGMr[0, introw].Value = ogrp.strTeritorryCode;
                    DGMr[1, introw].Value = ogrp.strTeritorryName;
                    DGMr[2, introw].Value = ogrp.strLedgerName;
                    DGMr[3, introw].Value = ogrp.strMereString;
                    DGMr.Columns[2].Width = 270;
                    //if (introw % 2 == 0)
                    //{
                    //    DGMr.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    DGMr.Rows[introw].DefaultCellStyle.BackColor = Color.White;
                    //}
                    introw += 1;
                }

                DGMr.AllowUserToAddRows = false;
            }
        }

        private void uctxtLedgerConfig_KeyUp(object sender, KeyEventArgs e)
        {
            if (radLedgerW.Checked && radIndividual.Checked)
            {
                SearchListViewPartyName(ooPartyName, uctxtLedgerConfig.Text);
            }
            else
            {
                SearchListViewGroupName(oogrp, uctxtLedgerConfig.Text);
            }
        }
        private void SearchListViewPartyName(IEnumerable<Invoice> tests, string searchString = "")
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
                    //if (i % 2 == 0)
                    //{
                    //    DGMr.Rows[i].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    DGMr.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    //}
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
                    //if (i % 2 == 0)
                    //{
                    //    DGMr.Rows[i].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    DGMr.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    //}
                    i += 1;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void radGroupwise_Click(object sender, EventArgs e)
        {
            if (radIndividual.Checked)
            {
                uctxtLedgerConfig.Text = "";
                uctxtLedgerConfig.Visible = true;
                uctxtLedgerConfig.Focus();
            }
            else
            {
                dteFromDate.Focus();
            }
        }
        private void radLedgerW_Click(object sender, EventArgs e)
        {
            if (radIndividual.Checked)
            {
                uctxtLedgerConfig.Visible = true;
                uctxtLedgerConfig.Text = "";
                uctxtLedgerConfig.Focus();
            }
            else
            {
                dteFromDate.Focus();
            }
        }

        private void radAll_Click(object sender, EventArgs e)
        {
            uctxtLedgerConfig.Visible = false;
            uctxtLedgerConfig.Text = "";
            DGMr.Visible = false;
            dteFromDate.Focus();
        }

        private void radIndividual_Click(object sender, EventArgs e)
        {
            uctxtLedgerConfig.Visible = true;
            uctxtLedgerConfig.Text = "";
            DGMr.Top = uctxtLedgerConfig.Top + 25;
            DGMr.Left = uctxtLedgerConfig.Left;
            DGMr.Width = uctxtLedgerConfig.Width;
            DGMr.Height = 200;
            DGMr.BringToFront();
            DGMr.AllowUserToAddRows = false;
            uctxtLedgerConfig.Focus();
            cbxSelection.Text = "";


        }    
    }
}
