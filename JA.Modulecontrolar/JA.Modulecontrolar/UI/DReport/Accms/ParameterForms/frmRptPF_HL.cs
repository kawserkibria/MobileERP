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
    public partial class frmRptPF_HL : JA.Shared.UI.frmSmartFormStandard 
    {
        private ListBox lstBranch = new ListBox();
        private ListBox lstMrName = new ListBox();
        private string strComID { get; set; }
     
        List<Invoice> ooPartyName;
        List<AccountdGroup> oogrp;
        public string strReportName { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public string strBranchID { get; set; }
        public frmRptPF_HL()
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
                uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                uctxtLedgerConfig.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                DGMr.Visible = false;
                if (chkboxClosing.Checked == true)
                {
                    btnPrint.Focus();
                }
                else
                {
                    dteFromDate.Focus();
                }


            }
        }
        private void DGMr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                int i = Convert.ToInt16(DGMr.CurrentRow.Index.ToString());
                uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
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
                        if (chkboxClosing.Checked == true)
                        {
                            btnPrint.Focus();
                        }
                        else
                        {
                            dteFromDate.Focus();
                        }
                    }
                }
                else
                {
                    int i = 0;

                    uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                    uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                    uctxtLedgerConfig.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                    DGMr.Visible = false;
                    if (chkboxClosing.Checked== true)
                    {
                        btnPrint.Focus();
                    }
                    else
                    {
                        dteFromDate.Focus();
                    }
                   
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


            return;
        }

        private void uctxtLedgerConfig_GotFocus(object sender, System.EventArgs e)
        {

                mloadParty();
                DGMr.Visible = true;
                DGMr.AllowUserToAddRows = true;

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
            
           if (radIndividual .Checked == true )
           {
               uctxtLedgerConfig.Focus();
           }
           else
           {
               dteFromDate.Focus();
           }
        }
        private void uctxtBranch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBranch.Items.Count > 0)
                {
                    uctxtBranch.Text = lstBranch.Text;
            
                    lstBranch.Visible = false;
                    dteFromDate.Focus();
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
            dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");
            uctxtBranch.Focus();
            lstBranch.Visible = false;
            lstMrName.Visible = false;

            lstBranch.ValueMember = "Key";
            lstBranch.DisplayMember = "value";
            lstBranch.DataSource = accms.mfillBranchNew(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();

            lstMrName.ValueMember = "strLedgerName";
            lstMrName.DisplayMember = "strLedgerName";
            lstMrName.DataSource = accms.mFillLedgerList(strComID, (int)Utility.GR_GROUP_TYPE.grCUSTOMER).ToList();
           
            radAll.PerformClick();
            uctxtLedgerConfig.Visible = false;
            //groupBox2.Visible = false;
  
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            string strBranchId = "";
    
            int intchkstatus = 0;

            if (radActive.Checked == true)
            {
                intchkstatus = 0;
            }
            else if (radInactive.Checked == true)
            {
                intchkstatus = 1;
            }
            else
            {
                intchkstatus = 3;
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


            if (chkboxClosing.Checked == true)
            {

                if (radIndividual.Checked == true)
                {
                    if (uctxtLedgerConfig.Text == "")
                    {
                        MessageBox.Show("Please Select Ledger Name.");
                        return;
                    }
                }

                dteToDate.Value=DateTime.Now.Date;
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.PFHLClosing;
                frmviewer.strFdate =Convert.ToString(dteToDate.Value).ToString();
                frmviewer.strHeading = "MPO Final Settlement";
                frmviewer.strBranchID = strBranchId;
                frmviewer.strString = uctxtLedgerConfig.Text;
                frmviewer.intSP = intchkstatus;
                frmviewer.strString2 = "Branch :" + uctxtBranch.Text;
                if (radIndividual.Checked == true)
                {
                    frmviewer.intHor_ver = 1;
                }
                else
                {
                    frmviewer.intHor_ver = 2;
                }
                frmviewer.ReportTitle = "A";
                frmviewer.Show();
            }
            else
            {
                //1=Group,3=gropParent,2=primary

            
                if (radIndividual.Checked == true)
                {
                    if (uctxtLedgerConfig.Text == "")
                    {
                        MessageBox.Show("Please Select Leger Group.");
                        return;
                    }
                }


                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.PFHL;
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strHeading = "HL/PF Information ";
                frmviewer.strBranchID = strBranchId;
                frmviewer.strString = uctxtLedgerConfig.Text;
                frmviewer.intSP = intchkstatus;
                frmviewer.strString2 = "Branch :" + uctxtBranch.Text;
                if (radIndividual.Checked == true)
                {
                    frmviewer.intHor_ver = 1;
                }
                else
                {
                    frmviewer.intHor_ver = 2;
                }
                frmviewer.ReportTitle = "A";
                frmviewer.Show();
            }
        }
        private void mloadGroup()
        {
            int introw = 0;
            DGMr.Rows.Clear();

            oogrp = accms.GetGroupList(strComID, 202, Utility.gblnAccessControl, Utility.gstrUserName).ToList();

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
                    introw += 1;
                }

                DGMr.AllowUserToAddRows = false;
            }
        }
        //private void mloadParty()
        //{
        //    int introw = 0;
        //    DGMr.Rows.Clear();

        //    ooPartyName = invms.mfillPartyNameNew(strComID, "", Utility.gblnAccessControl, Utility.gstrUserName, 0, "").ToList();

        //    if (ooPartyName.Count > 0)
        //    {

        //        foreach (Invoice ogrp in ooPartyName)
        //        {
        //            DGMr.Rows.Add();
        //            DGMr.Columns[1].Visible = true;
        //            DGMr.Columns[0].Visible = true;
        //            DGMr[0, introw].Value = ogrp.strTeritorryCode;
        //            DGMr[1, introw].Value = ogrp.strTeritorryName;
        //            DGMr[2, introw].Value = ogrp.strLedgerName;
        //            DGMr[3, introw].Value = ogrp.strMereString;
        //            DGMr.Columns[2].Width = 270;
        //            introw += 1;
        //        }

        //        DGMr.AllowUserToAddRows = false;
        //    }
        //}

        private void uctxtLedgerConfig_KeyUp(object sender, KeyEventArgs e)
        {

                SearchListViewPartyName(ooPartyName, uctxtLedgerConfig.Text);
     
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
            label4.Visible  = false;
            optAll.Visible = true;
            optAll.PerformClick();

        }

        private void radIndividual_Click(object sender, EventArgs e)
        {
  
            optAll.Visible = false;
            uctxtLedgerConfig.Visible = true;
            uctxtLedgerConfig.Text = "";
         
            label4.Visible = true;
            DGMr.Top = uctxtLedgerConfig.Top + 25;
            DGMr.Left = uctxtLedgerConfig.Left;
            DGMr.Width = uctxtLedgerConfig.Width;
            DGMr.Height = 200;
            DGMr.BringToFront();
            DGMr.Visible = true;
            DGMr.AllowUserToAddRows = false;
            radActive.Checked = true;
            uctxtLedgerConfig.Focus();


        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chkboxClosing_Click(object sender, EventArgs e)
        {
            if (chkboxClosing.Checked == true)
            {

                groupBox6.Visible = false;
                //groupBox2.Visible = true;
                //uctxtBranch.Enabled = false;
                //label3.Enabled = false;
                //lstBranch.Visible = false;
                //uctxtBranch.Text = "";

                uctxtLedgerConfig.Visible = false;
                uctxtLedgerConfig.Text = "";
                DGMr.Visible = false;
                btnPrint.Focus();
                label4.Visible = false;
                radAll.PerformClick();

            }
            else
            {
                groupBox6.Visible = true;
                //groupBox2.Visible = false;
                //uctxtBranch.Enabled = true;
                //label3.Enabled = true;
                //lstBranch.Visible = true;
                uctxtBranch.Select();
                uctxtBranch.Focus ();
                radAll.PerformClick();

            }
        }


        private void mloadParty()
        {
            int introw = 0, intstatus = 0;
            DGMr.Rows.Clear();
            strBranchID = Utility.gstrGetBranchID(strComID, uctxtBranch.Text);
            if (radActive.Checked == true)
            {
                intstatus = 0;
            }
            else
            {
                intstatus = 1;
            }
            ooPartyName = invms.mfillPartyNameNew(strComID, strBranchID, Utility.gblnAccessControl, Utility.gstrUserName, intstatus, "").ToList();

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
                    introw += 1;
                }

                //DGMr.AllowUserToAddRows = false;
            }
        }

        private void radActive_Click(object sender, EventArgs e)
        {
            mloadParty();
        }

        private void radInactive_Click(object sender, EventArgs e)
        {
            mloadParty();
        }

        private void optAll_Click(object sender, EventArgs e)
        {
            optAll.Visible = true;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
