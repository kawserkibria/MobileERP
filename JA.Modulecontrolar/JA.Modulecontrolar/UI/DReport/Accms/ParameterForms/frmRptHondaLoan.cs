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
    public partial class frmRptHondaLoan : JA.Shared.UI.frmSmartFormStandard 
    {
        private ListBox lstBranch = new ListBox();
        private ListBox lstMrName = new ListBox();
        private string strComID { get; set; }
        //private ListBox lstGroupConfig = new ListBox();
        List<Invoice> ooPartyName;
        List<AccountdGroup> oogrp;
        public string strReportName { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public frmRptHondaLoan()
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
                }
                else
                {
                    uctxtTerritoryCode.Text = "";
                    uctxtTeritorryName.Text = "";
                    uctxtLedgerConfig.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                }
                DGMr.Visible = false;
                btnPrint.Focus();


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
                }
                else
                {
                    uctxtTerritoryCode.Text = "";
                    uctxtTeritorryName.Text = "";
                    uctxtLedgerConfig.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                }
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
                        btnPrint.Focus();
                    }
                }
                else
                {
                    int i = 0;

                    uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                    uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                    uctxtLedgerConfig.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                    DGMr.Visible = false;
                    btnPrint.Focus();
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
                mloadGroup();
                DGMr.Visible = true;
                DGMr.AllowUserToAddRows = true;
            }
        }
        private void mloadParty()
        {
            int introw = 0, intStatus = 0;
            DGMr.Rows.Clear();

            ooPartyName = invms.mfillPartyNameNew(strComID, "", true, Utility.gstrUserName, intStatus, "","").ToList();

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
                    introw += 1;
                }

                DGMr.AllowUserToAddRows = false;
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
            btnPrint.Focus();
           
        }
        private void uctxtBranch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBranch.Items.Count > 0)
                {
                    uctxtBranch.Text = lstBranch.Text;
                    btnPrint.Focus();
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


        private void btnPrint_Click(object sender, EventArgs e)
        {

            Date1.Value = Convert.ToDateTime(dteFromDate.Text).AddMonths(-1);
            string strBranchId = "",strValOption = "";
            int intmode = 0,intsuppres = 0,intSuppDue=0;
            if (uctxtBranch.Text == "")
            {
                MessageBox.Show("Please Select Branch Name.");
                return;
            }
            else
            {
                strBranchId = Utility.gstrGetBranchID(strComID, uctxtBranch.Text);
            }
            if (chkZeroSuppress.Checked)
            {
                intSuppDue = 1;
            }
            else
            {
                intSuppDue = 0;
            }
            if ((radGroupwise.Checked == true) && (radIndividual.Checked == true))
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.Group;
                frmviewer.strFdate = dteFromDate.Text;
                frmviewer.strTdate = dteToDate.Text;
                frmviewer.strString = uctxtLedgerConfig.Text;
                frmviewer.strBranchID = strBranchId;
                frmviewer.intSummDetails = 1;
                frmviewer.strSelction = "Ledger";
                frmviewer.strHeading = "Group Summary (Ledger)";
                frmviewer.strHeading = uctxtLedgerConfig.Text;
                frmviewer.intValueSuppress = intSuppDue;
                frmviewer.Show();
            }
            else
            {
                if (radGroupwise.Checked == true)
                {
                    intmode = 1;
                    intsuppres = 1;
                }
                else if ((radLedgerW.Checked == true) && (radAll.Checked == true))
                {
                    intmode = 1;
                }
                else
                {
                    intmode = 3;
                }
                if (radIndividual.Checked == true)
                {
                    if (uctxtLedgerConfig.Text == "")
                    {
                        MessageBox.Show("Cannot be Empty");
                        uctxtLedgerConfig.Focus();
                        return;
                    }
                }
              

                frmReportViewer frmviewerr = new frmReportViewer();
                frmviewerr.selector = ViewerSelector.HondaLoan;
                frmviewerr.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                var now = DateTime.Now;
                var startOfMonth = new DateTime(dteToDate.Value.Year, dteToDate.Value.Month, 1);
                var DaysInMonth = DateTime.DaysInMonth(dteToDate.Value.Year, dteToDate.Value.Month);
                var lastDay = new DateTime(dteToDate.Value.Year, dteToDate.Value.Month, DaysInMonth);
                frmviewerr.strFdate = Convert.ToDateTime(startOfMonth).ToString();
                frmviewerr.strTdate = Convert.ToDateTime(dteToDate.Text).ToString();
                frmviewerr.strBranchID = strBranchId;
                if (radGroupwise.Checked == true)
                {
                    frmviewerr.strGroup = uctxtLedgerConfig.Text;
                }
                else
                {
                    frmviewerr.strledgerName = uctxtLedgerConfig.Text;
                }
                frmviewerr.intValueSuppress = intSuppDue;
                frmviewerr.intVtype = intmode;
                frmviewerr.strSelction = strValOption;
                frmviewerr.intSuppress = intsuppres;
                frmviewerr.strString3 = Convert.ToDateTime(startOfMonth).ToString();
                frmviewerr.Show();
            }
        }

    
        private void mloadGroup()
        {
            int introw = 0, intmode=0;
            DGMr.Rows.Clear();
            if (radGroupwise.Checked == true)
            {
                intmode = 1;
            }
            else
            {
                intmode = 2;
            }
            oogrp = accms.GetHondaLoanGroupList(strComID, 205, false, Utility.gstrUserName, intmode).ToList();

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
                SearchListViewGroupName(oogrp, uctxtLedgerConfig.Text);
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
            groupBox6.Visible = true;
            if (radIndividual.Checked)
            {
                uctxtLedgerConfig.Text = "";
                uctxtLedgerConfig.Visible = true;
                uctxtLedgerConfig.Focus();
            }
            if ((radGroupwise.Checked == true) &&(radAll.Checked==true))
            {
                label5.Visible = false;
                groupBox6.Text = "";
                label1.Text = "As on";
                dteFromDate.Visible = false;
            }
            else
            {
                label5.Visible = true;
                label5.Text = "From";
                label1.Text = "To";
                dteFromDate.Visible = true;
                groupBox6.Text = "Period Seletion";
            }
    

        }

        private void radLedgerW_Click(object sender, EventArgs e)
        {
            if ((radLedgerW.Checked == true) && (radAll.Checked == true))
            {
                groupBox6.Visible = true;
                label5.Visible = false;
                dteFromDate.Visible = false;
                groupBox6.Text = "";
                label1.Text = "As on";
            }
            if ((radLedgerW.Checked == true) && (radIndividual.Checked == true))
            {
                label5.Visible = false;
                groupBox6.Visible = true;
                dteFromDate.Visible = false;
                groupBox6.Visible = false;
                label1.Text = "As on";
            }
            if (radIndividual.Checked)
            {
                grpBox.Visible = true;
                uctxtLedgerConfig.Text = "";
                uctxtLedgerConfig.Visible = true;
                uctxtLedgerConfig.Focus();
            }
            else
            {
                btnPrint.Focus();
            }
        }

        private void radAll_Click(object sender, EventArgs e)
        {
            groupBox6.Visible = true;
            grpBox.Visible = true;
            DGMr.Visible = false;
            uctxtLedgerConfig.Visible = false;
            //groupBox6.Visible = true;
            uctxtLedgerConfig.Text = "";
            if ((radGroupwise.Checked == true) && (radAll.Checked == true))
            {
                label5.Visible = false;
                dteFromDate.Visible = false;
                groupBox6.Text = "";
                label1.Text = "As on";
            }
       

        }

        private void radIndividual_Click(object sender, EventArgs e)
        {
            if ((radGroupwise.Checked == true) && (radIndividual.Checked == true))
            {
                label5.Visible = true;
                dteFromDate.Visible = true;
                label1.Text = "To";
                label5.Text = "From";
                groupBox6.Text = "Period Seletion";
            }
            if ((radLedgerW.Checked == true) && (radIndividual.Checked == true))
            {
                label5.Visible = true;
            
                dteFromDate.Visible = true;
                groupBox6.Visible = false;
            }
          
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

  

        private void frmRptFinalStatement_Load(object sender, EventArgs e)
        {
            uctxtBranch.Focus();
            lstBranch.Visible = false;
            lstMrName.Visible = false;
            //groupBox6.Visible = false;
            lstBranch.ValueMember = "BranchID";
            lstBranch.DisplayMember = "BranchName";
            lstBranch.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
           
            uctxtLedgerConfig.Visible = false;

            dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");
            if ((radGroupwise.Checked == true) && (radAll.Checked == true))
            {
                label5.Visible = false;
                dteFromDate.Visible = false;
                groupBox6.Text = "";
                label1.Text = "As on";
                dteToDate.Text = Utility.LastDayOfMonth(DateTime.Now).ToString("dd-MM-yyyy");
            }
        }

    

       
     



    }
}
