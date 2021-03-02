using ExtraReports.Projection.Reports.RProjection.Viewer;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
//using JA.Modulecontrolar.JINVMS;
using System.Windows.Forms;
using ExtraReports.JSAPUR;
using ExtraReports.JACCMS;
using Dutility;
using ExtraReports.JINVMS;
using ExtraReports.EXTRA;
using System.Drawing.Drawing2D;
namespace ExtraReports.Projection.Reports.RProjection.ParameterForms
{
    public partial class frmRptProjection : JA.Shared.UI.frmSmartFormStandard 
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
        //private ListBox lstGroupConfig = new ListBox();
        //List<ProjectionSet> ooPartyName;
        //List<ProjectionSet> oogrp;
        List<Invoice> ooPartyName;
        List<AccountdGroup> oogrp;
        public string strReportName { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        //JACCMS.SWJAGClient accms = new SWJAGClient();
        public frmRptProjection()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.txtMonthID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonthID_KeyPress);
            this.txtMonthID.GotFocus += new System.EventHandler(this.txtMonthID_GotFocus);
            this.txtMonthID.KeyDown += new KeyEventHandler(txtMonthID_KeyDown);
            this.txtMonthID.TextChanged += new System.EventHandler(this.txtMonthID_TextChanged);
            this.lstMonthID.DoubleClick += new System.EventHandler(this.lstMonthID_DoubleClick);

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
            Utility.CreateListBox(lstMonthID, pnlMain, txtMonthID, 0);
           
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
        private void lstMonthID_DoubleClick(object sender, EventArgs e)
        {
            txtMonthID.Text = lstMonthID.Text;
            lstMonthID.Visible = false;
            MonName();
            if (radIndividual.Checked== true)
            {
                uctxtLedgerConfig.Focus();
            }
            else
            {
                btnPrint.Focus();
            }
     
        }
        private void txtMonthID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstMonthID.Items.Count > 0)
                {
                    txtMonthID.Text = lstMonthID.Text;

                    lstMonthID.Visible = false;
                }

                if (radIndividual.Checked == true)
                {
                    uctxtLedgerConfig.Focus();
                }
                else
                {
                    btnPrint.Focus();
                }
            }
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
  
        private void DGMr_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DGMr.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Yellow;
            DGMr.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            DGMr.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("verdana", 9);
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
        private void MonName()
        {
            strMontName = txtMonthID.Text.Substring(0, 3).ToUpper();
            strMontNameYY = txtMonthID.Text.Substring(3, 2).ToUpper();
        }
        private void DGMr_DoubleClick(object sender, EventArgs e)
        {

            if (DGMr.SelectedRows.Count > 0)
            {
                int i = Convert.ToInt16(DGMr.CurrentRow.Index.ToString());
                if (radGroupwise.Checked == true)
                {
                    uctxtTerritoryCode.Text = "";
                    uctxtTeritorryName.Text ="";
                    uctxtLedgerConfig.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                    
                    btnPrint.Focus();
                }
                else
                {
                    uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                    uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                    uctxtLedgerConfig.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                   
                    btnPrint.Focus();
                }

                DGMr.Visible = false;

            }
        }
        private void DGMr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                int i = Convert.ToInt16(DGMr.CurrentRow.Index.ToString());
                if (radGroupwise.Checked == true)
                {
                    uctxtTerritoryCode.Text = "";
                    uctxtTeritorryName.Text = "";
                    uctxtLedgerConfig.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                    btnPrint.Focus();
                }
                else
                {
                    uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                    uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                    uctxtLedgerConfig.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                    btnPrint.Focus();
                }
                DGMr.Visible = false;
            
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
                   
                    }
                }
                else
                {
                    int i = 0;

                    uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                    uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                    uctxtLedgerConfig.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                    DGMr.Visible = false;
                   
                }

                btnPrint.Focus();

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

            DGMr.Top = uctxtLedgerConfig.Top + 25;
            DGMr.Left = uctxtLedgerConfig.Left;
            DGMr.Width = uctxtLedgerConfig.Width;
            DGMr.Height = 200;
            DGMr.BringToFront();
            DGMr.AllowUserToAddRows = false;
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

            radGroupwise.Focus();
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
                radGroupwise.Focus();
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

            strMonth = txtMonthID.Text.Substring(0, 3).ToUpper();

            intYY = Convert.ToInt32(txtMonthID.Text.Substring(3, 2));
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
        private void btnPrint_Click(object sender, EventArgs e)
        {
            string strBranchId = "", strMonthID = "";

            //int intmode = 0, intSelection = 0, intPrint = 0;
            //string strValOption = "";
            //double dblAmount = 0, dblBelowAmnt = 0;

            if (uctxtBranch.Text == "")
            {
                MessageBox.Show("Please Select Branch Name.");
                return;
            }
            else
            {
                strBranchId = Utility.gstrGetBranchID(strComID, uctxtBranch.Text);
            }
        
            if (txtMonthID.Text == "")
            {
                MessageBox.Show("Please Select Month.");
                txtMonthID.Focus();
                return;
            }
            dateset();
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.ProjectionR;
                frmviewer.strString1 = strThisMonth;
                frmviewer.strString2 = strLastMonth;
                frmviewer.strledgerName = uctxtLedgerConfig.Text;
                frmviewer.Show();
                dteFromDate.Text = DateTime.Now.ToString();
                dteToDate.Text = DateTime.Now.ToString();
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
                    DGMr.Columns[2].Width = 500;
                    DGMr[2, introw].Value = ogrp.GroupName;
                    DGMr[3, introw].Value = ogrp.GroupName;
                    if (introw % 2 == 0)
                    {
                        DGMr.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                    }
                    else
                    {
                        DGMr.Rows[introw].DefaultCellStyle.BackColor = Color.White;
                    }
                    introw += 1;
                }

                DGMr.AllowUserToAddRows = false;
            }
        }
        private void mloadParty()
        {
            int introw = 0,intStatus=0;
            DGMr.Rows.Clear();

            ooPartyName = invms.mfillPartyNameNew(strComID, "", true, Utility.gstrUserName, intStatus, "").ToList();

            if (ooPartyName.Count > 0)
            {

                foreach (Invoice ogrp in ooPartyName)
                {
                    DGMr.Rows.Add();
                    DGMr.Columns[1].Visible = true;
                    DGMr.Columns[0].Visible = true;
                    DGMr.Columns[2].Width = 270;
                    DGMr[0, introw].Value = ogrp.strTeritorryCode;
                    DGMr[1, introw].Value = ogrp.strTeritorryName;
                    DGMr[2, introw].Value = ogrp.strLedgerName;
                    DGMr[3, introw].Value = ogrp.strMereString;
                    if (introw % 2 == 0)
                    {
                        DGMr.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                    }
                    else
                    {
                        DGMr.Rows[introw].DefaultCellStyle.BackColor = Color.White;
                    }
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

        private void radGroupwise_Click(object sender, EventArgs e)
        {
            if (radIndividual.Checked)
            {
                lstMonthID.Visible = false;
                uctxtLedgerConfig.Text = "";
                uctxtLedgerConfig.Visible = true;
                uctxtLedgerConfig.Focus();
            }
            else
            {
             
            }
        }

        private void radLedgerW_Click(object sender, EventArgs e)
        {
            if (radIndividual.Checked)
            {
                lstMonthID.Visible = false;
                grpBox.Visible = true;
                uctxtLedgerConfig.Text = "";
                uctxtLedgerConfig.Visible = true;
                uctxtLedgerConfig.Focus();
            }
            else
            {
              
            }
        }

        private void radAll_Click(object sender, EventArgs e)
        {
            lstMonthID.Visible = false;
            grpBox.Visible = true;
            DGMr.Visible = false;
            uctxtLedgerConfig.Visible = false;
            uctxtLedgerConfig.Text = "";
        }

        private void radIndividual_Click(object sender, EventArgs e)
        {

            lstMonthID.Visible = false;
            uctxtLedgerConfig.Visible = true;
            uctxtLedgerConfig.Text = "";
            DGMr.Top = uctxtLedgerConfig.Top + 25;
            DGMr.Left = uctxtLedgerConfig.Left;
            DGMr.Width = uctxtLedgerConfig.Width;
            DGMr.Height = 200;
            DGMr.BringToFront();
            DGMr.AllowUserToAddRows = false;
            uctxtLedgerConfig.Focus();
        }

        private void radInactive_Click(object sender, EventArgs e)
        {
            if (strReportName == "Final Settlement")
            {
                mloadParty();
            }
            else
            {
                frmLabel.Text = "Market Monitoring Sheet";
                groupBox3.Visible = false;
            }
        }

        private void radActive_Click(object sender, EventArgs e)
        {
            if (strReportName == "Final Settlement")
            {
                mloadParty();
            }
            else
            {
                frmLabel.Text = "Market Monitoring Sheet";
                groupBox3.Visible = false;
            }
        }

        private void frmRptFinalStatement_Load(object sender, EventArgs e)
        {

            dteFromDate.Text = DateTime.Now.ToString();
            dteToDate.Text = DateTime.Now.ToString();
            uctxtBranch.Focus();
            lstBranch.Visible = false;
            lstMrName.Visible = false;
            lstMonthID.Visible = false;
            lstBranch.ValueMember = "BranchID";
            lstBranch.DisplayMember = "BranchName";
            lstBranch.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
            frmLabel.Text = "Projection";
            groupBox3.Visible = true;
            uctxtLedgerConfig.Visible = false;


        }

    }
}
