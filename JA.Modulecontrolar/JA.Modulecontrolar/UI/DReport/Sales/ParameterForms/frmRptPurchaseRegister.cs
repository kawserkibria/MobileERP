using Dutility;
using JA.Modulecontrolar.JINVMS;
using JA.Modulecontrolar.JACCMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using JA.Modulecontrolar.UI.DReport.Purchase.Viewer;
using Microsoft.Win32;
namespace JA.Modulecontrolar.UI.DReport.Purchase.ParameterForms
{
    public partial class frmRptPurchaseRegister : JA.Shared.UI.frmSmartFormStandard
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public string strSelection = "";
        public string strReportName { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        //private ListBox lstMedicalRep = new ListBox();
        List<Invoice> ooPartyName;
        private string strComID { get; set; }
        private ListBox lstMrName = new ListBox();

        public frmRptPurchaseRegister()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.dteFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteFromDate_KeyPress);
            //this.dteFromDate.GotFocus += new System.EventHandler(this.dteFromDate_GotFocus);
            this.dteToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteToDate_KeyPress);
            //this.dteToDate.GotFocus += new System.EventHandler(this.dteToDate_GotFocus);
            this.uctxtMrName.GotFocus += new System.EventHandler(this.uctxtMrName_GotFocus);
            this.uctxtMrName.KeyDown += new KeyEventHandler(uctxtMrName_KeyDown);
            this.uctxtMrName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtMrName_KeyPress);
            this.lstMrName.DoubleClick += new System.EventHandler(this.lstMrName_DoubleClick);
            this.uctxtMrName.TextChanged += new System.EventHandler(this.uctxtMrName_TextChanged);
            this.uctxtMrName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uctxtMrName_KeyUp);

            this.DGMr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(DGMr_KeyPress);
            this.DGMr.DoubleClick += new System.EventHandler(this.DGMr_DoubleClick);
            this.DGMr.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGMr_CellFormatting);

            Utility.CreateListBox(lstMrName, pnlMain, uctxtMrName);

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
                if (strSelection == "SalesReg")
                {
                    int i = Convert.ToInt16(DGMr.CurrentRow.Index.ToString());
                    //uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                    uctxtMrName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                    //uctxtTeritorryName.Text = DGMr.Rows[i].Cells[2].Value.ToString();

                    DGMr.Visible = false;
                    btnPrint.Focus();
                    
                }
                else
                {
                    int i = Convert.ToInt16(DGMr.CurrentRow.Index.ToString());
                    //uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                    //uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                    uctxtMrName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                    DGMr.Visible = false;
                    btnPrint.Focus();
                }
            }

        }
        private void DGMr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                int i = Convert.ToInt16(DGMr.CurrentRow.Index.ToString());
                //uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                uctxtMrName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                //uctxtTeritorryName.Text = DGMr.Rows[i].Cells[2].Value.ToString();
               
                DGMr.Visible = false;
                btnPrint.Focus();
            }
        }
        private void uctxtMrName_KeyUp(object sender, KeyEventArgs e)
        {
            if (rbtnIndividualParty.Checked)
            {
                SearchListViewPartyName(ooPartyName, uctxtMrName.Text);
            }
        }
        private void SearchListViewPartyName(IEnumerable<Invoice> tests, string searchString = "")
        {
            if ((strSelection == "SalesReg") || (strSelection== "ReturnReg"))
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
                        DGMr[1, i].Value = tran.strLedgerName;
                        DGMr[2, i].Value = tran.strTeritorryName;
                        DGMr[3, i].Value = tran.strMereString;
                        i += 1;
                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
            
        }
        private void lstMrName_DoubleClick(object sender, EventArgs e)
        {
            uctxtMrName.Text = lstMrName.Text;
            lstMrName.Visible = false;
            btnPrint.Focus();
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
                        uctxtMrName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                        //uctxtTeritorryName.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                        DGMr.Visible = false;
                        btnPrint.Focus();
                    }
                }
                else
                {
                    int i = 0;
                    uctxtMrName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                    //uctxtTeritorryName.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                    DGMr.Visible = false;
                    btnPrint.Focus();
                }
                lstMrName.Visible = false;

            }

        }
        private void uctxtMrName_TextChanged(object sender, EventArgs e)
        {
            lstMrName.SelectedIndex = lstMrName.FindString(uctxtMrName.Text);
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

            return;
        }
        private void uctxtMrName_GotFocus(object sender, System.EventArgs e)
        {

            if (strSelection == "SalesReg")
            {
                    mloadParty();
                    DGMr.Visible = true;
                    DGMr.AllowUserToAddRows = true;
            }
            if (strSelection == "PurchaseReg")
            {
                DGMr.Columns[1].Visible = false;
                DGMr.Columns[0].Visible = false;
                DGMr.Columns[2].Width = 480;
                DGMr.Columns[2].HeaderText = "Supplier Name";

                    mLaodsuplierList();
                    DGMr.Visible = true;
                    DGMr.AllowUserToAddRows = true;
            }
            if (strSelection == "ReturnReg")
            {
                mloadParty();
                DGMr.Visible = true;
                DGMr.AllowUserToAddRows = true;

            }
            if (strSelection == "PurchaseReturn")
            {
                DGMr.Columns[1].Visible = false;
                DGMr.Columns[0].Visible = false;
                DGMr.Columns[2].Width = 480;
                DGMr.Columns[2].HeaderText = "Supplier Name";
                mLaodsuplierList();
                DGMr.Visible = true;
                DGMr.AllowUserToAddRows = true;
            }

        }
        private void mLaodsuplierList()
        {
            int introw = 0;
            DGMr.Rows.Clear();

            this.DGMr.DefaultCellStyle.Font = new Font("verdana", 9);
            DGMr.Rows.Clear();
            List<AccountsLedger> oogrp = accms.mFillLedgerList(strComID, 203).ToList();
            if (oogrp.Count > 0)
            {

                foreach (AccountsLedger ogrp in oogrp)
                {

                    DGMr.Rows.Add();
                    DGMr.Columns[0].Visible = false;
                    DGMr.Columns[1].Visible = false;
                    DGMr[2, introw].Value = ogrp.strLedgerName;
                    introw += 1;

                }
                DGMr.AllowUserToAddRows = false;
            }
        }
        private void mloadSalesRep()
        {
            int introw = 0;
            DGMr.Rows.Clear();
            if (ooPartyName.Count > 0)
            {

                foreach (Invoice ogrp in ooPartyName)
                {
                    DGMr.Rows.Add();
                    DGMr.Columns[1].Visible = true;
                    DGMr.Columns[0].Visible = true;
                    DGMr[0, introw].Value = ogrp.strTeritorryCode;
                    DGMr[1, introw].Value = ogrp.strLedgerName;
                    DGMr[2, introw].Value = ogrp.strTeritorryName;
                    DGMr[3, introw].Value = ogrp.strMereString;
                    introw += 1;
                }

                DGMr.AllowUserToAddRows = false;
            }
        }
        private void mloadParty()
        {
            int introw = 0;
            DGMr.Rows.Clear();

            ooPartyName = invms.mfillPartyNameNew(strComID,"").ToList();

            if (ooPartyName.Count > 0)
            {

                foreach (Invoice ogrp in ooPartyName)
                {
                    DGMr.Rows.Add();
                    DGMr.Columns[1].Visible = true;
                    DGMr.Columns[0].Visible = true;
                    DGMr[0, introw].Value = ogrp.strTeritorryCode;
                    DGMr[1, introw].Value = ogrp.strLedgerName;
                    DGMr[2, introw].Value = ogrp.strTeritorryName;                   
                    DGMr[3, introw].Value = ogrp.strMereString;
                    introw += 1;
                }

                DGMr.AllowUserToAddRows = false;
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
            DGMr.Visible = false;
            lstMrName.Visible = false;
        }

        private void frmRptStoreLedger_Load(object sender, EventArgs e)
        {
            uctxtMrName.Visible = false;
            label4.Visible = false;
            rbtnAll.PerformClick();
          

            lstMrName.Visible = false;
            if (strSelection == "SalesReg")
            {
                tetReportHader.Text = "Sales Register";
                label9.Text = "Sales Register";
                rbtnIndividualParty.Text = "Individual MPO";
            }
            if (strSelection == "PurchaseReg")
            {
                tetReportHader.Text = "Purchase Register";
                label9.Text = "Purchase Register";
            }
            if (strSelection == "ReturnReg")
            {
                tetReportHader.Text = "Sales Return Register";
                label9.Text = "Sales Return Register";
                rbtnIndividualParty.Text = "Individual MPO";
            }
            if (strSelection == "PurchaseReturn")
            {
                tetReportHader.Text = "Purchase Return Register";
                label9.Text = "Purchase Return Register";
            }
            
            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {


            if ((rbtnAll.Checked == true) && (chkboxSummary.Checked == true))
            {
                string strBrachID = "";
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.rptPurchesSumm;
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.intSuppress = 1;
                frmviewer.reportTitle2 = "A";
                frmviewer.strLedgerName = "";
                if (strSelection== "SalesReg")
                {
                    frmviewer.strString2 = "16";
                }
                if (strSelection == "PurchaseReg")
                {
                    frmviewer.strString2 = "33";
                }
                if (strSelection == "ReturnReg")
                {
                    frmviewer.strString2 = "13";
                }
                if (strSelection == "PurchaseReturn")
                {
                    frmviewer.strString2 = "32";
                }
                frmviewer.Show();
                return;
            }
            if ((rbtnIndividualParty.Checked == true) && (chkboxSummary.Checked == true))
            {
                string strBrachID = "";
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.rptPurchesSumm;
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strLedgerName = uctxtMrName.Text;
                frmviewer.reportTitle2 = "A";
                frmviewer.intSuppress = 0;
                if (strSelection == "SalesReg")
                {
                    frmviewer.strString2 = "16";
                }
                if (strSelection == "PurchaseReg")
                {
                    frmviewer.strString2 = "33";
                }
                if (strSelection == "ReturnReg")
                {
                    frmviewer.strString2 = "13";
                }
                if (strSelection == "PurchaseReturn")
                {
                    frmviewer.strString2 = "32";
                }
                frmviewer.Show();
                return;
            }

            if (rbtnAll.Checked == true)
            {
                string strBrachID = "";
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.rptPurchesAll;
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.reportTitle2 = "A";
                frmviewer.strLedgerName = "";
                if (strSelection == "SalesReg")
                {
                    frmviewer.strString2 = "16";
                }
                if (strSelection == "PurchaseReg")
                {
                    frmviewer.strString2 = "33";
                }
                if (strSelection == "ReturnReg")
                {
                    frmviewer.strString2 = "13";
                }
                if (strSelection == "PurchaseReturn")
                {
                    frmviewer.strString2 = "32";
                }
                frmviewer.Show();
                return;
            }

            if (rbtnIndividualParty.Checked == true)
            {
                string strBrachID = "";
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.rptPurchesAll;
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strLedgerName = uctxtMrName.Text;
                frmviewer.reportTitle2 = "A";
                if (strSelection == "SalesReg")
                {
                    frmviewer.strString2 = "16";
                }
                if (strSelection == "PurchaseReg")
                {
                    frmviewer.strString2 = "33";
                }
                if (strSelection == "ReturnReg")
                {
                    frmviewer.strString2 = "13";
                }
                if (strSelection == "PurchaseReturn")
                {
                    frmviewer.strString2 = "32";
                }
                frmviewer.Show();
                return;
            }
        }
        private void chkboxSummary_Click(object sender, EventArgs e)
        {
            if (chkboxSummary.Checked == true )
            {
                ChkboxNarr.Enabled = false;
            }
            else 
            {
                ChkboxNarr.Enabled = true;
            }
           
        }
        private void rbtnIndividualParty_Click(object sender, EventArgs e)
        {
            uctxtMrName.Visible = true;
            label4.Visible = true;
            uctxtMrName.Focus();
            label4.Text = "MPO Name";
            uctxtMrName.Visible = true;
            uctxtMrName.Text = "";
            DGMr.Top = uctxtMrName.Top + 25;
            DGMr.Left = uctxtMrName.Left;
            DGMr.Width = uctxtMrName.Width;
            DGMr.Height = 200;
            DGMr.BringToFront();
            DGMr.AllowUserToAddRows = false;
            uctxtMrName.Focus();
        }

        private void rbtnAll_Click(object sender, EventArgs e)
        {
            uctxtMrName.Visible = false;
            label4.Visible = false;
            lstMrName.Visible = false;
            //dteFromDate.Focus();
            DGMr.Visible = false;
            lstMrName.Visible = false;
        }

        private void tetReportHader_KeyPress(object sender, KeyPressEventArgs e)
        {
            dteFromDate.Focus();
        }
    }
}
