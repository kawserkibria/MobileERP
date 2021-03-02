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
using JA.Modulecontrolar.JSAPUR;
using JA.Modulecontrolar.JRPT;
using JA.Modulecontrolar.UI.DReport.Purchase.ReportUI;
using JA.Modulecontrolar.UI.DReport.Purchase.Viewer;
using Microsoft.Win32;
namespace JA.Modulecontrolar.UI.DReport.Purchase.ParameterForms
{
    public partial class frmRptSuppliersList : JA.Shared.UI.frmSmartFormStandard
    {

        private ListBox lstMrName = new ListBox();
        private ListBox lstSuppLedgerGroup = new ListBox();
        public string  strSelection="";
        private ListBox lstBranch = new ListBox();
        public int lngLedgeras { get; set; }
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public string strReportName { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        List<Invoice> ooPartyName;
        //List<Invoice> ooCustomerrr;
        private string strComID { get; set; }
        List<AccountsLedger> oogrp;
        //List<Invoice> ooCustomer;    
        JSAPUR.WSalesPurchaseClient orpt = new WSalesPurchaseClient();
        List<RSalesPurchase> oooRg;
        public frmRptSuppliersList()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.dteFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteFromDate_KeyPress);
            this.dteToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteToDate_KeyPress);

            this.uctxtBranchName.KeyDown += new KeyEventHandler(uctxtBranchName_KeyDown);
            this.uctxtBranchName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranchName_KeyPress);
            this.uctxtBranchName.TextChanged += new System.EventHandler(this.uctxtBranchName_TextChanged);
            this.lstBranch.DoubleClick += new System.EventHandler(this.lstBranch_DoubleClick);
            this.uctxtBranchName.GotFocus += new System.EventHandler(this.uctxtBranchName_GotFocus);

            this.uctxtMrName.GotFocus += new System.EventHandler(this.uctxtMrName_GotFocus);
            this.uctxtMrName.KeyDown += new KeyEventHandler(uctxtMrName_KeyDown);
            this.uctxtMrName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtMrName_KeyPress);
            this.lstMrName.DoubleClick += new System.EventHandler(this.lstMrName_DoubleClick);
            this.uctxtMrName.TextChanged += new System.EventHandler(this.uctxtMrName_TextChanged);
            this.uctxtMrName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uctxtMrName_KeyUp);

            this.DGMr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(DGMr_KeyPress);
            this.DGMr.DoubleClick += new System.EventHandler(this.DGMr_DoubleClick);
            this.DGMr.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGMr_CellFormatting);
            Utility.CreateListBox(lstBranch, pnlMain, uctxtBranchName);
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
        private void uctxtBranchName_TextChanged(object sender, EventArgs e)
        {
            lstBranch.SelectedIndex = lstBranch.FindString(uctxtBranchName.Text);
        }
        private void lstBranch_DoubleClick(object sender, EventArgs e)
        {
            uctxtBranchName.Text = lstBranch.Text;
            lstBranch.Visible = false;
            btnPrint.Focus();
        }
        private void uctxtBranchName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBranch.Items.Count > 0)
                {
                    uctxtBranchName.Text = lstBranch.Text;
                    lstBranch.Visible = false;
                  
                    btnPrint.Focus();
                }

            }
        }
        private void uctxtBranchName_KeyDown(object sender, KeyEventArgs e)
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

        private void uctxtBranchName_GotFocus(object sender, System.EventArgs e)
        {
            lstBranch.Visible = true;

            lstBranch.SelectedIndex = lstBranch.FindString(uctxtBranchName.Text);
        }

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
                if (strSelection == "Sales")
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
                    uctxtMrName.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                    DGMr.Visible = false;
                    //dteFromDate.Focus();
                    btnPrint.Focus();
                }
                else
                {
                    int i = Convert.ToInt16(DGMr.CurrentRow.Index.ToString());
                    //uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                    //uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                    uctxtMrName.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                    DGMr.Visible = false;
                    //dteFromDate.Focus();
                    btnPrint.Focus();
                }
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
                uctxtMrName.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                DGMr.Visible = false;
                //dteFromDate.Focus();
                btnPrint.Focus();
            }
        }
        private void uctxtMrName_KeyUp(object sender, KeyEventArgs e)
        {
            if (radIndividual.Checked)
            {
                SearchListViewPartyName(ooPartyName, uctxtMrName.Text);
            }
        }
        private void SearchListViewPartyName(IEnumerable<Invoice> tests, string searchString = "")
        {
            if (strSelection == "Sales")
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
                        uctxtMrName.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                        DGMr.Visible = false;
                        //dteFromDate.Focus();
                        btnPrint.Focus();
                    }
                }
                else
                {
                    int i = 0;

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
                    uctxtMrName.Text = DGMr.Rows[i].Cells[2].Value.ToString();
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
            lstBranch.Visible = false;
            if (strSelection == "Sales")
            {
                if ((rbtnLedgerwise.Checked == true) && (radIndividual.Checked == true ))
                {
                    mloadParty();

                }
                else 
                {
                    mloadGroup();
                    DGMr.Columns[1].Visible = false;
                    DGMr.Columns[0].Visible = false;
                    DGMr.Columns[2].HeaderText = "Group Name";  
                }            
            }
            if (strSelection == "Purchase")
            {
                if ((rbtnLedgerwise.Checked == true) && (radIndividual.Checked == true))
                {
                    mLaodsuplierList();

                        DGMr.Columns[1].Visible = false;
                        DGMr.Columns[0].Visible = false;
                        DGMr.Columns[2].HeaderText = "Ledger Name";
                }
                else
                {
                    mloadLedgerGroup();
                    DGMr.Columns[1].Visible = false;
                    DGMr.Columns[0].Visible = false;
                    DGMr.Columns[2].HeaderText = "Group Name";
                }
            }
        
        }
        private void mloadParty()
        {
            int introw = 0;
            DGMr.Rows.Clear();

            ooPartyName = invms.mfillPartyNameNew(strComID, "", Utility.gblnAccessControl, Utility.gstrUserName, 0, "","").ToList();

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
                    introw += 1;
                }

                DGMr.AllowUserToAddRows = false;
            }
        }
        private void mloadGroup()
        {
            int introw = 0;
            DGMr.Rows.Clear();
            
            //ooPartyName = invms.mfillPartyNameNew().ToList();
            if (strSelection=="Sales")
            {
                ooPartyName = invms.mFillLedgerParentGroup(strComID, (int)Utility.GR_GROUP_TYPE.grSALES_REP, strSelection).ToList();
            }
            else
            {
                ooPartyName = invms.mFillLedgerParentGroup(strComID, (int)Utility.GR_GROUP_TYPE.grSALES_REP, strSelection).ToList();
            }
            if (ooPartyName.Count > 0)
            {

                foreach (Invoice ogrp in ooPartyName)
                {
                    DGMr.Rows.Add();
                    DGMr.Columns[1].Visible = true;
                    DGMr.Columns[0].Visible = true;
                    if (ogrp.strTeritorryCode != "")
                    {
                        DGMr[0, introw].Value = ogrp.strTeritorryCode;
                    }
                    else
                    {
                        DGMr[0, introw].Value = "";
                    }
                    if (ogrp.strTeritorryName != "")
                    {
                        DGMr[1, introw].Value = ogrp.strTeritorryName;
                    }
                    else
                    {
                        DGMr[1, introw].Value = "";
                    }
                   
                    DGMr[2, introw].Value = ogrp.strLedgerName;
                    DGMr[3, introw].Value = ogrp.strMereString;
                    introw += 1;
                }

                DGMr.AllowUserToAddRows = false;
            }
        }

        private void mloadLedgerGroup()
        {
            int introw = 0;
            DGMr.Rows.Clear();

            oooRg = orpt.LEDGERPARENTGROUP(strComID, (int)Utility.GR_GROUP_TYPE.grSALES_REP).ToList();

            if (oooRg.Count > 0)
            {

                foreach (RSalesPurchase ogrp in oooRg)
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
        private void dteFromDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
               
                //dteToDate.Focus();

            }
        }

        private void dteToDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                //btnPrint.Focus();

            }
        }      
        #endregion

        private void frmRptStoreLedger_Load(object sender, EventArgs e)
        {
            chkBoxTarget.Visible = false;
            ChbRevised.Visible = false;
            lstBranch.ValueMember = "BranchID";
            lstBranch.DisplayMember = "BranchName";
            lstBranch.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
            lstBranch.SelectedIndex = lstBranch.FindString(uctxtBranchName.Text);

            dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");
            if (strSelection == "Sales") 
            {
                label4.Text = "Doctor/Customer List";

            }
            else
            {
                label4.Text = "Supplier List";
                rbtnLedgerwise.Text = "Ledger Wise";
            }
            uctxtMrName.Visible = false;
            lstSuppLedgerGroup.Visible = false;
            lstMrName.Visible = false;
            lblMpoName.Visible = false;
            dteFromDate.Text = Utility.gdteFinancialYearFrom;
           

        } 
        private void btnPrint_Click(object sender, EventArgs e)
        {
            string strBraID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);
            
            if (strSelection == "Sales")
            {
                if ((rbtnGroupWise.Checked == true) && (radAll.Checked == true))
                {
                    frmReportViewer frmviewer = new frmReportViewer();
                    frmviewer.selector = ViewerSelector.customerlist;
                    frmviewer.strString = "";
                    frmviewer.strString2 = "204";
                    frmviewer.strStockItemName = "Groupwise";
                    frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                    frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                    frmviewer.strSelction = "Sales";
                    frmviewer.reportTitle2 = "A";
                    frmviewer.strBranchID = strBraID;
                    frmviewer.intMode = 2;
                    frmviewer.intSuppress = 1;
                    frmviewer.Show();
                }

                if ((rbtnGroupWise.Checked == true) && (radIndividual.Checked == true))
                {
                    frmReportViewer frmviewer = new frmReportViewer();
                    frmviewer.selector = ViewerSelector.customerInd;
                    frmviewer.strString = uctxtMrName.Text;
                    frmviewer.strString2 = "204";
                    frmviewer.strStockItemName = "Groupwise";
                    frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                    frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                    frmviewer.strSelction = "Sales";
                    frmviewer.strBranchID = strBraID;
                    frmviewer.reportTitle2 = "A";
                    frmviewer.intMode = 3;
                    frmviewer.Show();
                }

                if ((rbtnLedgerwise.Checked == true) && (radAll.Checked == true))
                {
                    if (chkBoxTarget.Checked == true)
                    {

                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.customerInd;
                        frmviewer.strString = "";
                        frmviewer.strString2 = "204";
                        frmviewer.strStockItemName = "LedwiseR";
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strSelction = "Sales";
                        frmviewer.reportTitle2 = "A";
                        frmviewer.intSuppress = 1;
                        frmviewer.strBranchID = strBraID;
                        frmviewer.intvType = 1;
                        frmviewer.intMode = 2;
                        frmviewer.Show();
                    }
                    else if (ChbRevised.Checked == true)
                    {

                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.customerInd2;
                        frmviewer.strString = "";
                        frmviewer.strString2 = "204";
                        frmviewer.strStockItemName = "LedwiseR";
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strSelction = "Sales";
                        frmviewer.reportTitle2 = "A";
                        frmviewer.strBranchID = strBraID;
                        frmviewer.intSuppress = 1;
                        frmviewer.intvType = 1;
                        frmviewer.intMode = 4;
                        frmviewer.Show();
                    }
                    else
                    {
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.customerInd1;
                        frmviewer.strString = "";
                        frmviewer.strString2 = "204";
                        frmviewer.strStockItemName = "LedwiseR";
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strSelction = "Sales";
                        frmviewer.reportTitle2 = "A";
                        frmviewer.strBranchID = strBraID;
                        frmviewer.intSuppress = 1;
                        frmviewer.intvType = 1;
                        frmviewer.intMode = 2;
                        frmviewer.Show();
                    }
                }


                if ((rbtnLedgerwise.Checked == true) && (radIndividual.Checked == true))
                {
                    if (ChbRevised.Checked == true)
                    {

                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.customerInd2;
                        frmviewer.strString = uctxtMrName.Text;
                        frmviewer.strString2 = "204";
                        frmviewer.strStockItemName = "LedwiseR";
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strSelction = "Sales";
                        frmviewer.reportTitle2 = "A";
                        frmviewer.strBranchID = strBraID;
                        frmviewer.intSuppress = 1;
                        frmviewer.intvType = 1;
                        frmviewer.intMode = 4;
                        frmviewer.Show();
                    }
                    else
                    {
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.customerInd;
                        frmviewer.strString = uctxtMrName.Text;
                        frmviewer.strString2 = "204";
                        frmviewer.strStockItemName = "Ledwise";
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strSelction = "Sales";
                        frmviewer.reportTitle2 = "A";
                        frmviewer.strBranchID = strBraID;
                        frmviewer.intMode = 2;
                        frmviewer.intSuppress = 2;
                        frmviewer.Show();
                    }
                }

            }
            else
            {

                if ((rbtnGroupWise.Checked == true) && (radAll.Checked == true))
                {
                    frmReportViewer frmviewer = new frmReportViewer();
                    frmviewer.selector = ViewerSelector.SupplieGroup;
                    frmviewer.strString = "";
                    frmviewer.strString2 = "203";
                    frmviewer.strSelction = "BalanceSheet";
                    frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                    frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                    frmviewer.intMode = 5;
                    frmviewer.strBranchID = "";
                    frmviewer.reportTitle2 = "A";
                    frmviewer.Show();
                }

                if ((rbtnGroupWise.Checked == true) && (radIndividual.Checked == true))
                {
                    frmReportViewer frmviewer = new frmReportViewer();
                    frmviewer.selector = ViewerSelector.SupplieGroup;
                    frmviewer.strString = uctxtMrName.Text;
                    frmviewer.strString2 = "203";
                    frmviewer.strSelction = "BalanceSheet";
                    frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                    frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                    frmviewer.intMode = 6;
                    frmviewer.strBranchID = "";
                    frmviewer.reportTitle2 = "A";
                    frmviewer.Show();
                }

                if ((rbtnLedgerwise.Checked == true) && (radAll.Checked == true))
                {
                    frmReportViewer frmviewer = new frmReportViewer();
                    frmviewer.selector = ViewerSelector.SupplieinfoInd;
                    frmviewer.strString = "";
                    frmviewer.strString2 = "203";
                    frmviewer.strSelction = "Ledwise";
                    frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                    frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                    frmviewer.reportTitle2 = "A";
                    frmviewer.intMode = 5;
                    frmviewer.strBranchID = "";
                    frmviewer.Show();
                }

                if ((rbtnLedgerwise.Checked == true) && (radIndividual.Checked == true))
                {
                    frmReportViewer frmviewer = new frmReportViewer();
                    frmviewer.selector = ViewerSelector.SupplieGroup;
                    frmviewer.strString = uctxtMrName.Text;
                    frmviewer.strString2 = "203";
                    frmviewer.strSelction = "";
                    frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                    frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                    frmviewer.reportTitle2 = "A";
                    frmviewer.strBranchID = "";
                    frmviewer.intMode = 5;
                    frmviewer.Show();
                }

            }
        }
   
        private void radIndividual_Click(object sender, EventArgs e)
        {
            lstBranch.Visible = false;
            if (strSelection == "Sales")
            {
                lblMpoName.Visible = true;
                uctxtMrName.Visible = true;
                uctxtMrName.Focus();
            }
            else
            {
                lblMpoName.Visible = true;
                lblMpoName.Text = "ledger Name";
                uctxtMrName.Visible = true;
                DGMr.Visible = false;
                lstMrName.Visible = false ;
                uctxtMrName.Focus();
            }

            DGMr.Top = uctxtMrName.Top + 25;
            DGMr.Left = uctxtMrName.Left;
            DGMr.Width = uctxtMrName.Width;
            DGMr.Height = 200;
            DGMr.BringToFront();
            DGMr.Visible = true;
            DGMr.AllowUserToAddRows = false;

        }
        private void radAll_Click(object sender, EventArgs e)
        {
            lstBranch.Visible = false;
            //dteFromDate.Focus();
            btnPrint.Focus();
            lstSuppLedgerGroup.Visible = false;
            uctxtMrName.Visible = false;
            lblMpoName.Visible = false;
            uctxtMrName.Visible = false;
            DGMr.Visible = false;
            lstMrName.Visible = false;                    
        }

        //private void rbtnGroupWise_Click(object sender, EventArgs e)
        //{
        //    lblMpoName.Visible = false;
        //    DGMr.Visible = false;
        //    lstMrName.Visible = false;
        //    uctxtMrName.Text ="";
        //    if (radIndividual.Checked==true)
        //    {
        //        uctxtMrName.Focus();
        //    }

        //}
        private void rbtnGroupWise_Click(object sender, EventArgs e)
        {

            ChbRevised.Visible = false;
            lblMpoName.Visible = false;
            DGMr.Visible = false;
            lstMrName.Visible = false;
            uctxtMrName.Text = "";
            chkBoxTarget.Visible = false;
            if (radIndividual.Checked == true)
            {
                uctxtMrName.Focus();
            }

        }
        private void rbtnLedgerwise_Click(object sender, EventArgs e)
        {
            if (strSelection == "Sales")
            {
                ChbRevised.Visible = true;
                chkBoxTarget.Visible = true;
            }
            lstBranch.Visible = false;        
            if (radIndividual.Checked == true)
            {
                uctxtMrName.Text = "";
                uctxtMrName.Focus();

            }
        }

        private void chkBoxTarget_Click(object sender, EventArgs e)
        {
            lstBranch.Visible = false;
            ChbRevised.Checked = false;
        }

        private void ChbRevised_Click(object sender, EventArgs e)
        {
            lstBranch.Visible = false;
            chkBoxTarget.Checked = false;
        }

    }
}
