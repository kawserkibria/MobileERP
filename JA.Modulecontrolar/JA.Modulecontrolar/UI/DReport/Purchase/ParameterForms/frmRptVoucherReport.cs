using Dutility;
using JA.Modulecontrolar.JINVMS;
using JA.Modulecontrolar.JACCMS;
using JA.Modulecontrolar.JSAPUR;
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
    public partial class frmRptVoucherReport : JA.Shared.UI.frmSmartFormStandard
    {

        JACCMS.SWJAGClient accms = new SWJAGClient();
        JSAPUR.WSalesPurchaseClient orpt = new WSalesPurchaseClient();
        public string strReportName { get; set; }
        public string strSelection { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        private ListBox lstMrName = new ListBox();
        List<Invoice> ooPartyName;
        List<AccountdGroup> oogrp;
        List<AccountsLedger> ooosuplyar;
        List<RSalesPurchase> ooosiinvo;
        List<RSalesPurchase> orptt;
        private string strComID { get; set; }
        public frmRptVoucherReport()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.dteFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteFromDate_KeyPress);
            //this.dteFromDate.GotFocus += new System.EventHandler(this.dteFromDate_GotFocus);
            this.dteToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteToDate_KeyPress);
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
                var strResponse = MessageBox.Show("                    Quit                    ", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponse == DialogResult.Yes)
                {
                    this.Dispose();
                }
            }

            return false;
        }    

        #region "User Deifne"
        private void uctxtMrName_GotFocus(object sender, System.EventArgs e)
        {
            //if (strSelection == "Purchase")
            //{
            //    mloadSupplyer();
            //}
            //else
            //{
            //    mloadParty();

            //}

        }
        private void DGMr_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DGMr.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Yellow;
            DGMr.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            DGMr.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("verdana", 9);
        }
        private void DGMr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                int i = Convert.ToInt16(DGMr.CurrentRow.Index.ToString());
                uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                uctxtMrName.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                DGMr.Visible = false;
                btnPrint.Focus();
            }
        }
        private void DGMr_DoubleClick(object sender, EventArgs e)
        {

            if (DGMr.SelectedRows.Count > 0)
            {
                int i = Convert.ToInt16(DGMr.CurrentRow.Index.ToString());
                uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                uctxtMrName.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                DGMr.Visible = false;

                if (rbtnIndividualParty.Checked)
                {
                    mloadParty();
                }
                btnPrint.Focus();
                
            }
        }

        private void uctxtMrName_TextChanged(object sender, EventArgs e)
        {
            if (rbtnIndividualParty.Checked == true)
            {
                lstMrName.SelectedIndex = lstMrName.FindString(uctxtMrName.Text);
            }
            if (rbtbIndividualVouNo.Checked == true)
            {
                DGMr.Columns[1].Visible = false;
                DGMr.Columns[0].Visible = false;
                DGMr.Columns[2].HeaderText = "Voucher No";
            }
        }
        private void mloadParty()
        {
            int introw = 0;
            DGMr.Rows.Add();
            DGMr.Columns[1].Visible = false;
            DGMr.Columns[0].Visible = false;
            DGMr[0, introw].Value = false;
            DGMr[1, introw].Value = false;
            DGMr[2, introw].Value = false;
            DGMr[3, introw].Value = false;
            DGMr.Columns[2].HeaderText = "Mpo Name";
            DGMr.Rows.Clear();

            if (strSelection == "Sales")
            {
                ooPartyName = invms.mfillPartyNameNew(strComID, "", Utility.gblnAccessControl, Utility.gstrUserName,0,"","").ToList();
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

                    DGMr.AllowUserToAddRows = false;
                }
            }

        }

        private void mloadSupplyer()
        {
            int introw = 0;
            DGMr.Rows.Clear();

            DGMr.Rows.Add();
            DGMr.Columns[1].Visible = false;
            DGMr.Columns[0].Visible = false;
            DGMr[0, introw].Value = false;
            DGMr[1, introw].Value = false;
            DGMr[2, introw].Value = false;
            DGMr[3, introw].Value = false;
            DGMr.Columns[2].HeaderText = "Supplier";
            DGMr.Rows.Clear();

            ooosuplyar = accms.mFillLedgerList(strComID, 203).ToList();
            if (ooosuplyar.Count > 0)
            {

                foreach (AccountsLedger ogrp in ooosuplyar)
                {
                    DGMr.Rows.Add();
                    DGMr.Columns[1].Visible = false;
                    DGMr.Columns[0].Visible = false;
                    DGMr[0, introw].Value = false;
                    DGMr[1, introw].Value = false;
                    DGMr[2, introw].Value = ogrp.strLedgerName;
                    DGMr[3, introw].Value = false;
                    introw += 1;
                }

                DGMr.AllowUserToAddRows = false;
            }
        }
        private void mloadPIinvno()
        {
            int introw = 0;
            DGMr.Rows.Clear();
            DGMr.Rows.Add();
            DGMr.Columns[1].Visible = false;
            DGMr.Columns[0].Visible = false;
            DGMr[0, introw].Value = false;
            DGMr[1, introw].Value = false;
            DGMr[2, introw].Value = false;
            DGMr[3, introw].Value = false;
            DGMr.Columns[2].HeaderText = "Voucher No";
            DGMr.Rows.Clear();

            string DataLoadMode = "";
            int vtype = 0;

            if (strSelection == "Purchase")

                if (rbtnPurchaseInv.Checked == true)
                {
                    DataLoadMode = "PurchaseInvoice";
                    vtype = 33;
                }
            if (rbtnPurchaseReturn.Checked == true)
            {
                DataLoadMode = "PurchaseReturn";
                vtype = 32;
            }
            {
                 orptt = orpt.mGetVoucherRefNo(strComID, dteFromDate.Text, dteToDate.Text, DataLoadMode, "0001", vtype).ToList();

                if (orptt.Count > 0)
                {

                    foreach (RSalesPurchase ogrp in orptt)
                    {
                        DGMr.Rows.Add();
                        DGMr.Columns[1].Visible = false;
                        DGMr.Columns[0].Visible = false;
                        DGMr[0, introw].Value = false;
                        DGMr[1, introw].Value = false;
                        DGMr[2, introw].Value = ogrp.strRefNo;
                        DGMr[3, introw].Value = false;
                        introw += 1;
                    }

                    DGMr.AllowUserToAddRows = false;
                }

            }
        }
        private void mloadSIinvno()
        {
            int voucherType = 0;
            int introw = 0;
            DGMr.Rows.Clear();
            string DataLoadMode = "";
            if (strSelection == "Sales")

                if (rbtnPurchaseInv.Checked == true)
                {
                    DataLoadMode = "SalesInvoice";
                    voucherType = 16;

                }
            if (rbtnPurchaseReturn.Checked == true)
            {
                DataLoadMode = "SalesReturn";
                voucherType = 13;
            }

            if (rbtnSalesChalan.Checked == true)
            {
                DataLoadMode = "SalesChalan";
                voucherType = 15;
            }
            if (rbtnSalesSamp.Checked == true)
            {
                DataLoadMode = "SalesChalan";
                voucherType = 17;
            }

            {
                orptt = orpt.mGetVoucherRefNo(strComID, dteFromDate.Text, dteToDate.Text, DataLoadMode, "0001", voucherType).ToList();

                if (orptt.Count > 0)
                {

                    foreach (RSalesPurchase ogrp in orptt)
                    {
                        DGMr.Rows.Add();
                        DGMr.Columns[1].Visible = false;
                        DGMr.Columns[0].Visible = false;
                        DGMr[0, introw].Value = false;
                        DGMr[1, introw].Value = false;
                        DGMr[2, introw].Value = ogrp.strRefNo;
                        DGMr[3, introw].Value = false;
                        introw += 1;
                    }

                    DGMr.AllowUserToAddRows = false;
                }

            }
        }

        private void uctxtMrName_KeyUp(object sender, KeyEventArgs e)
        {
            if (rbtbIndividualVouNo.Checked == false)
            {

                if (strSelection == "Sales")
                {
                    if (rbtnIndividualParty.Checked)
                    {
                        SearchListViewPartyName(ooPartyName, uctxtMrName.Text);
                    }
                }
                if (strSelection == "Purchase")
                {
                    if (rbtnIndividualParty.Checked)
                    {
                        SearchListViewSuppliyerName(ooosuplyar, uctxtMrName.Text);
                    }
                }
            }
            else
            {
                SearchListViewVoucherNo(orptt, uctxtMrName.Text);
            }
        }

        private void SearchListViewVoucherNo(IEnumerable<RSalesPurchase> tests, string searchString = "")
        {
            IEnumerable<RSalesPurchase> query;
            query = tests;
            try
            {
                if (searchString != "")
                {
                    query = tests.Where(x => x.strRefNo.ToLower().Trim().Contains(searchString.ToLower().Trim()));
                }

                DGMr.Rows.Clear();
                int introw = 0;

                foreach (RSalesPurchase tran in query)
                {
                    DGMr.Rows.Add();
                    DGMr.Columns[1].Visible = false;
                    DGMr.Columns[0].Visible = false;
                    DGMr[0, introw].Value = false;
                    DGMr[1, introw].Value = false;
                    DGMr[2, introw].Value = tran.strRefNo;
                    DGMr[3, introw].Value = false;
                    introw += 1;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void SearchListViewSuppliyerName(IEnumerable<AccountsLedger> tests, string searchString = "")
        {
            IEnumerable<AccountsLedger> query;
            query = tests;
            if (searchString != "")
            {
                query = tests.Where(x => x.strLedgerName.ToLower().Trim().Contains(searchString.ToLower().Trim()));
            }

            DGMr.Rows.Clear();
            int introw = 0;
            try
            {
                foreach (AccountsLedger ogrp in query)
                {
                    DGMr.Rows.Add();
                    DGMr.Columns[1].Visible = false;
                    DGMr.Columns[0].Visible = false;
                    DGMr[0, introw].Value = false;
                    DGMr[1, introw].Value = false;
                    DGMr[2, introw].Value = ogrp.strLedgerName;
                    DGMr[3, introw].Value = false;
                    introw += 1;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
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
                        uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                        uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                        uctxtMrName.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                        DGMr.Visible = false;
                        btnPrint.Focus();
                        
                    }
                }
                else
                {
                    int i = 0;

                    uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                    uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                    uctxtMrName.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                    DGMr.Visible = false;
                    btnPrint.Focus();
                }
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

            return;
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
                if (rbtnAll.Checked == true )
                {
                    btnPrint.Focus();
                }
                else
                {
                    uctxtMrName.Visible = true;
                    uctxtMrName.Text = "";
                    DGMr.Top = uctxtMrName.Top + 25;
                    DGMr.Left = uctxtMrName.Left;
                    DGMr.Width = uctxtMrName.Width;
                    DGMr.Height = 150;
                    DGMr.BringToFront();
                    DGMr.AllowUserToAddRows = false;
                    DGMr.Visible = true;
                    uctxtMrName.Focus();
                }
               
            }
        }

        #endregion
        private void radAll_Click(object sender, EventArgs e)
        {

        }

        private void frmRptStoreLedger_Load(object sender, EventArgs e)
        {
            dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");
            lstMrName.Visible = false;
            rbtnPurchaseInv.PerformClick();
            rbtnAll.PerformClick();
            rbtnDetail.PerformClick();
            chkboxNarration.Visible = false;
            rbtnSalesChalan.Visible = false;
            rbtnSalesSamp.Visible = false;
            dteFromDate.Select();
            uctxtMrName.Text = "";
            //label5.Text = "";
            if (strSelection == "Sales")
            {
                rbtnPurchaseInv.Text = "Sales Invoice";
                rbtnPurchaseReturn.Text = "Sales Return";
                rbtnIndividualParty.Text = "Indvidual MPO";
                rbtnSalesChalan.Visible = true;
                rbtnSalesSamp.Visible = true;
                label5.Text = "Sales Voucher Reports";
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmReportViewer frmviewer = new frmReportViewer();
           
            frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
            frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
            int vouchertype = 0;
            if (strSelection == "Purchase")
            {
                if (rbtnPurchaseInv.Checked == true)
                {
                    vouchertype = 33;
                }
                else
                {
                    vouchertype = 32;
                }

            }

            if (strSelection == "Sales")
            {
                if (rbtnPurchaseInv.Checked == true)
                {
                    vouchertype = 16;
                }
                if (rbtnSalesChalan.Checked == true)
                {
                    vouchertype = 15;
                }
                if (rbtnPurchaseReturn.Checked == true)
                {
                    vouchertype = 13;
                }
                if (rbtnSalesSamp.Checked == true)
                {
                    vouchertype = 15;

                }
                if (radSalesOrder.Checked == true)
                {
                    vouchertype = 17;

                }
            }

            if ((rbtnSalesChalan.Checked == true) && (rbtnAll.Checked == true) && (rbtnSummary.Checked == true))
            {

                frmviewer.selector = ViewerSelector.VoucherSalesChalan;
                frmviewer.strLedgerName = "";
                frmviewer.intSuppress = 1;
                frmviewer.intvType = vouchertype;
                frmviewer.intMode = 2;
                frmviewer.reportTitle2 = "A";
                frmviewer.strSelction = "Sum";
                frmviewer.strString2 = "Sales Chalan (Summary)";
                frmviewer.Show();
                return;
            }
            if ((rbtnSalesChalan.Checked == true) && (rbtnAll.Checked == true) && (rbtnDetail.Checked == true))
            {

                frmviewer.selector = ViewerSelector.VoucherSalesChalan;
                frmviewer.strLedgerName = uctxtMrName.Text;
                frmviewer.intSuppress = 1;
                frmviewer.intvType = vouchertype;
                frmviewer.intMode = 1;
                frmviewer.strString2 = "Sales Chalan (Detail)";
                frmviewer.reportTitle2 = "A";
                frmviewer.Show();
                return;
            }
            if ((rbtnSalesChalan.Checked == true) && (rbtnIndividualParty.Checked == true) && (rbtnDetail.Checked == true))
            {
                frmviewer.selector = ViewerSelector.VoucherSalesChalan;
                frmviewer.strLedgerName = uctxtMrName.Text;
                frmviewer.intSuppress = 1;
                frmviewer.intvType = vouchertype;
                frmviewer.intMode = 1;
                frmviewer.strString2 = "Sales Chalan Detail (Individual)";
                frmviewer.reportTitle2 = "A";
                frmviewer.Show();
                return;
            }
            if ((rbtnSalesChalan.Checked == true) && (rbtnIndividualParty.Checked == true) && (rbtnSummary.Checked == true))
            {

                frmviewer.selector = ViewerSelector.VoucherSalesChalan;
                frmviewer.strLedgerName = uctxtMrName.Text;
                frmviewer.intSuppress = 1;
                frmviewer.intvType = vouchertype;
                frmviewer.intMode = 2;
                frmviewer.reportTitle2 = "A";
                frmviewer.strSelction = "Sum";
                frmviewer.strString2 = "Sales Chalan (Summary)";
                frmviewer.Show();
                return;
            }
            if ((rbtnSalesChalan.Checked == true) && (rbtbIndividualVouNo.Checked == true) && (rbtnSummary.Checked == true))
            {

                frmviewer.selector = ViewerSelector.VoucherSalesChalan;
                frmviewer.strLedgerName = uctxtMrName.Text;
                frmviewer.intSuppress = 1;
                frmviewer.intvType = vouchertype;
                frmviewer.intMode = 3;
                frmviewer.strString2 = "Sales Chalan";
                frmviewer.reportTitle2 = "A";
                frmviewer.Show();
                return;
            }


            if ((rbtnSalesChalan.Checked == true) && (rbtbIndividualVouNo.Checked == true) && (rbtnDetail.Checked == true))
            {

                string strPrevix = "";
                string strBranchId = "0001";
                string strString2 = "";

                if (strSelection == "Purchase")
                {
                    strPrevix = "PI" + strBranchId;
                }
                else
                {
                    strPrevix = "SC" + strBranchId;
                }


                strString2 = strString2 + "'" + strPrevix + uctxtMrName.Text + "',";

                if (strString2 != "")
                {
                    strString2 = Utility.Mid(strString2, 0, strString2.Length - 1);
                }
                frmviewer.selector = ViewerSelector.VoucherSalesChalan;
                frmviewer.strLedgerName = uctxtMrName.Text;
                frmviewer.intSuppress = 1;
                frmviewer.intvType = vouchertype;
                frmviewer.intMode = 3;
                frmviewer.strString2 = "Sales Chalan";
                frmviewer.reportTitle2 = "A";
                frmviewer.Show();
                return;
            }


            if ((rbtnPurchaseInv.Checked == true) && (rbtnAll.Checked == true) && (rbtnSummary.Checked == true))
            {

                frmviewer.selector = ViewerSelector.Vouchear;
                frmviewer.strLedgerName = "";
                frmviewer.intMode = vouchertype;
                frmviewer.intvType = vouchertype;
                frmviewer.intSuppress = 1;
                if (strSelection == "Sales")
                {
                    frmviewer.strString2 = "Sales Invoice (Summary)";
                }
                else
                {
                    frmviewer.strString2 = "Purchase Invoice (Summary)";
                }
                frmviewer.reportTitle2 = "A";
                frmviewer.Show();
                return;
            }
            if ((rbtnPurchaseInv.Checked == true) && (rbtnIndividualParty.Checked == true) && (rbtnSummary.Checked == true))
            {

           
                if (strSelection == "Sales")
                {
                    frmviewer.selector = ViewerSelector.Vouchear;
                    frmviewer.strLedgerName = uctxtMrName.Text;
                    frmviewer.intMode = vouchertype;
                    frmviewer.intvType = vouchertype;
                    frmviewer.intSuppress = 1;
                    if (strSelection == "Sales")
                    {
                        frmviewer.strString2 = "Sales Invoice (Summary)";
                    }
                    else
                    {
                        frmviewer.strString2 = "Purchase Invoice (Summary)";
                    }
                    frmviewer.reportTitle2 = "A";
                    frmviewer.Show();
                }
                else
                {
                    frmviewer.selector = ViewerSelector.VouchearInvoiceSingleSumm;
                    frmviewer.strLedgerName = uctxtMrName.Text;
                    frmviewer.intSuppress = 1;
                    frmviewer.intMode = vouchertype;
                    frmviewer.intvType = vouchertype;
                    frmviewer.reportTitle2 = "A";

                    frmviewer.strString2 = "Purchase Invoice (Individual)";

                    frmviewer.strSelction = "Sum";
                    frmviewer.Show();
                    return;
                }
                return;
            }

            if ((rbtnSalesSamp.Checked == true) && (rbtnAll.Checked == true) && (rbtnSummary.Checked == true) )
            {

                JA.Modulecontrolar.UI.DReport.Inventory.Viewer.frmReportViewer frmviewerInventory = new JA.Modulecontrolar.UI.DReport.Inventory.Viewer.frmReportViewer();
                frmviewerInventory.selector = JA.Modulecontrolar.UI.DReport.Inventory.ViewerSelector.intventoryVoucher;
                frmviewerInventory.strFdate = dteFromDate.Text;
                frmviewerInventory.strTdate = dteToDate.Text;
                frmviewerInventory.strString = "";
                frmviewerInventory.strSummDetails = "Summ";
                frmviewerInventory.strSelction = "S";
                frmviewerInventory.Show();
                return;
            }
            if ((rbtnSalesSamp.Checked == true) && (rbtnIndividualParty.Checked == true) && (rbtnSummary.Checked == true))
            {

                frmviewer.selector = ViewerSelector.Vouchear;
                frmviewer.strLedgerName = uctxtMrName.Text;
                frmviewer.intSuppress = 1;
                frmviewer.intvType = vouchertype;
                frmviewer.intMode = vouchertype;
                frmviewer.reportTitle2 = "A";
                frmviewer.strString2 = "Sales Sample (Individual)";
                frmviewer.strSelction = "Sum";
                frmviewer.Show();
                return;
            }
            if ((rbtnSalesSamp.Checked == true) && (rbtnIndividualParty.Checked == true) && (rbtnDetail.Checked == true))
            {
                frmviewer.selector = ViewerSelector.VoucherSalesChalan;
                frmviewer.strLedgerName = uctxtMrName.Text;
                frmviewer.intSuppress = 1;
                frmviewer.intvType = vouchertype;
                frmviewer.intMode = 1;
                frmviewer.strString2 = "Sales Sample Detail (Individual)";
                frmviewer.reportTitle2 = "A";
                frmviewer.Show();
                return;
            }
            if ((rbtnSalesSamp.Checked == true) && (rbtnAll.Checked == true) && (rbtnDetail.Checked == true))
            {

                JA.Modulecontrolar.UI.DReport.Inventory.Viewer.frmReportViewer frmviewerInventory = new JA.Modulecontrolar.UI.DReport.Inventory.Viewer.frmReportViewer();
                frmviewerInventory.selector = JA.Modulecontrolar.UI.DReport.Inventory.ViewerSelector.intventoryVoucher;
                frmviewerInventory.strFdate = dteFromDate.Text;
                frmviewerInventory.strTdate = dteToDate.Text;
                frmviewerInventory.strString = "";
                frmviewerInventory.strSummDetails = "Details";
                frmviewerInventory.strSelction = "S";
                frmviewerInventory.intSuppress = 1;
                frmviewerInventory.Show();


                //frmviewer.selector = ViewerSelector.VoucherSalesChalan;
                //frmviewer.strLedgerName = uctxtMrName.Text;
                //frmviewer.intSuppress = 1;
                //frmviewer.intvType = vouchertype;
                //frmviewer.intMode = 1;
                //frmviewer.strString2 = "Sales Sample (Detail)";
                //frmviewer.reportTitle2 = "A";
                //frmviewer.Show();
                return;
            }
            if ((rbtnSalesSamp.Checked == true) && (rbtbIndividualVouNo.Checked == true) && (rbtnDetail.Checked == true))
            {
                //string strPrevix = "";
                //string strBranchId = "0001";
                //string strString2 = "";

                //if (strSelection == "Purchase")
                //{
                //    strPrevix = "PI" + strBranchId;
                //}
                //else
                //{
                //    strPrevix = "SM" + strBranchId;
                //}


                //strString2 = strString2 + "'" + strPrevix + uctxtMrName.Text + "',";

                //if (strString2 != "")
                //{
                //    strString2 = Utility.Mid(strString2, 0, strString2.Length - 1);
                //}

                //frmviewer.selector = ViewerSelector.VoucherSalesChalan;
                //frmviewer.strLedgerName = strString2;
                //frmviewer.intSuppress = 1;
                //frmviewer.intvType = vouchertype;
                //frmviewer.intMode = 3;
                //if (strSelection == "Sales")
                //{
                //    frmviewer.strString2 = "Sample Invoice (Detail)";
                //}
                //else
                //{
                //    frmviewer.strString2 = "Purchase Invoice (Detail)";
                //}
                //frmviewer.reportTitle2 = "A";
                //frmviewer.Show();
                //return;
                //kawser
                string strPrevix = "";
                string strBranchId = "0001";
                string strString2 = "";

                if (strSelection == "Purchase")
                {
                    strPrevix = "PI" + strBranchId;
                }
                else
                {
                    strPrevix = "SM" + strBranchId;
                }


                strString2 = strString2 + "'" + strPrevix + uctxtMrName.Text + "',";

                if (strString2 != "")
                {
                    strString2 = Utility.Mid(strString2, 0, strString2.Length - 1);
                }


                frmviewer.selector = ViewerSelector.VoucherSalesChalan;
                frmviewer.strLedgerName = uctxtMrName.Text;
                frmviewer.intSuppress = 1;
                frmviewer.intvType = vouchertype;
                frmviewer.intMode = 3;
                if (strSelection == "Sales")
                {
                    frmviewer.strString2 = "Sample Invoice (Summary)";
                }
                else
                {
                    frmviewer.strString2 = "Purchase Invoice (Summary)";
                }
                frmviewer.reportTitle2 = "A";
                frmviewer.Show();
                return;
            }
            if ((rbtnSalesSamp.Checked == true) && (rbtbIndividualVouNo.Checked == true) && (rbtnSummary.Checked == true))
            {
                string strPrevix = "";
                string strBranchId = "0001";
                string strString2 = "";

                if (strSelection == "Purchase")
                {
                    strPrevix = "PI" + strBranchId;
                }
                else
                {
                    strPrevix = "SM" + strBranchId;
                }


                strString2 = strString2 + "'" + strPrevix + uctxtMrName.Text + "',";

                if (strString2 != "")
                {
                    strString2 = Utility.Mid(strString2, 0, strString2.Length - 1);
                }


                frmviewer.selector = ViewerSelector.VoucherSalesChalan;
                frmviewer.strLedgerName = uctxtMrName.Text;
                frmviewer.intSuppress = 1;
                frmviewer.intvType = vouchertype;
                frmviewer.intMode = 3;
                if (strSelection == "Sales")
                {
                    frmviewer.strString2 = "Sample Invoice (Summary)";
                }
                else
                {
                    frmviewer.strString2 = "Purchase Invoice (Summary)";
                }
                frmviewer.reportTitle2 = "A";
                frmviewer.Show();
                return;

            }

            if ((rbtnPurchaseInv.Checked == true) && (rbtbIndividualVouNo.Checked == true) && (rbtnDetail.Checked == true))
            {
                string strPrevix = "";
                string strBranchId = "0001";
                string strString2 = "";

                if (strSelection == "Purchase")
                {
                    strPrevix = "PI" + strBranchId;
                }
                else
                {
                    strPrevix = "SI" + strBranchId;
                }


                strString2 = strString2 + "'" + strPrevix + uctxtMrName.Text + "',";

                if (strString2 != "")
                {
                    strString2 = Utility.Mid(strString2, 0, strString2.Length - 1);
                }


                frmviewer.selector = ViewerSelector.VouchearVouNo;
                frmviewer.strLedgerName = strString2;
                frmviewer.intMode = vouchertype;
                frmviewer.intvType = vouchertype;
                if (strSelection == "Sales")
                {
                    frmviewer.strString2 = "Sales Invoice ";
                }
                else
                {
                    frmviewer.strString2 = "Purchase Invoice ";
                }
                frmviewer.reportTitle2 = "A";
                frmviewer.Show();
                return;
            }
            if ((rbtnPurchaseInv.Checked == true) && (rbtbIndividualVouNo.Checked == true) && (rbtnSummary.Checked == true))
            {
                string strPrevix = "";
                string strBranchId = "0001";
                string strString2 = "";

                if (strSelection == "Purchase")
                {
                    strPrevix = "PI" + strBranchId;
                }
                else
                {
                    strPrevix = "SI" + strBranchId;
                }


                strString2 = strString2 + "'" + strPrevix + uctxtMrName.Text + "',";

                if (strString2 != "")
                {
                    strString2 = Utility.Mid(strString2, 0, strString2.Length - 1);
                }
                frmviewer.selector = ViewerSelector.VouchearVouNo;
                frmviewer.strLedgerName = strString2;
                frmviewer.intMode = vouchertype;
                frmviewer.intvType = vouchertype;
                if (strSelection == "Sales")
                {
                    frmviewer.strString2 = "Sales Invoice ";
                }
                else
                {
                    frmviewer.strString2 = "Purchase Invoice ";
                }
                frmviewer.reportTitle2 = "A";
                frmviewer.Show();
                return;
            }


            if ((rbtnPurchaseInv.Checked == true) && (rbtnAll.Checked == true) && (rbtnDetail.Checked == true))
            {

                frmviewer.selector = ViewerSelector.Vouchear;
                frmviewer.strLedgerName = "";
                frmviewer.intMode = vouchertype;
                frmviewer.intvType = vouchertype;
                if (strSelection == "Sales")
                {
                    frmviewer.strString2 = "Sales Invoice (Detail)";
                }
                else
                {
                    frmviewer.strString2 = "Purchase Invoice (Detail)";
                }
                frmviewer.reportTitle2 = "A";
                frmviewer.Show();
                return;
            }
            if ((rbtnPurchaseInv.Checked == true) && (rbtnIndividualParty.Checked == true) && (rbtnDetail.Checked == true))
            {

                frmviewer.selector = ViewerSelector.Vouchear;
                frmviewer.strLedgerName = uctxtMrName.Text;
                frmviewer.intMode = vouchertype;
                frmviewer.intvType = vouchertype;
                if (strSelection == "Sales")
                {
                    frmviewer.strString2 = "Sales Invoice (Individual)";
                }
                else
                {
                    frmviewer.strString2 = "Purchase Invoice (Individual)";
                }
                frmviewer.reportTitle2 = "A";
                frmviewer.Show();
                return;
            }

            //if ((rbtnPurchaseInv.Checked == true) && (rbtbIndividualVouNo.Checked == true) && (rbtnDetail.Checked == true))
            //{
            //    string strPrevix = "";
            //    string strBranchId = "0001";
            //    string strString2 = "";

            //    if (strSelection == "Purchase")
            //    {
            //        strPrevix = "PI" + strBranchId;
            //    }
            //    else
            //    {
            //        strPrevix = "SI" + strBranchId;
            //    }


            //    strString2 = strString2 + "'" + strPrevix + uctxtMrName.Text + "',";

            //    if (strString2 != "")
            //    {
            //        strString2 = Utility.Mid(strString2, 0, strString2.Length - 1);
            //    }



            //    if (strSelection == "Sales")
            //    {
            //        frmviewer.selector = ViewerSelector.VouchearVouNo;
            //        frmviewer.strLedgerName = strString2;
            //        frmviewer.intMode = vouchertype;
            //        frmviewer.intvType = vouchertype;
            //        frmviewer.strString2 = "Sales Invoice ";
            //    }
            //    else
            //    {
            //        frmviewer.selector = ViewerSelector.VouchearVouNoPurch;
            //        frmviewer.strLedgerName = strString2;
            //        frmviewer.intMode = vouchertype;
            //        frmviewer.intvType = vouchertype;
            //        frmviewer.strString2 = "Purchase Invoice ";
            //        frmviewer.intSuppress = 2;
            //    }
            //    frmviewer.reportTitle2 = "A";
            //    frmviewer.Show();
            //    return;
            //}


            if ((rbtnPurchaseReturn.Checked == true) && (rbtnAll.Checked == true) && (rbtnSummary.Checked == true))
            {

                frmviewer.selector = ViewerSelector.Vouchear;
                frmviewer.strLedgerName = "";
                frmviewer.intSuppress = 1;
                frmviewer.intvType = vouchertype;
                frmviewer.intMode = vouchertype;
                if (strSelection == "Sales")
                {
                    frmviewer.strString2 = "Sales Return (Summary)";
                }
                else
                {
                    frmviewer.strString2 = "Purchase Return (Summary)";
                }
                frmviewer.reportTitle2 = "A";
                frmviewer.strSelction = "Sum";
                frmviewer.Show();
                return;
            }
            if ((rbtnPurchaseReturn.Checked == true) && (rbtbIndividualVouNo.Checked == true) && (rbtnSummary.Checked == true))
            {
                string strPrevix = "";
                string strBranchId = "0001";
                string strString2 = "";

                if (strSelection == "Purchase")
                {
                    strPrevix = "PR" + strBranchId;
                }
                else
                {
                    strPrevix = "SR" + strBranchId;
                }


                strString2 = strString2 + "'" + strPrevix + uctxtMrName.Text + "',";

                if (strString2 != "")
                {
                    strString2 = Utility.Mid(strString2, 0, strString2.Length - 1);
                }
                frmviewer.selector = ViewerSelector.VouchearVouNo;
                frmviewer.strLedgerName = strString2;
                frmviewer.intMode = vouchertype;
                frmviewer.intvType = vouchertype;
                if (strSelection == "Sales")
                {
                    frmviewer.strString2 = "Sales Return ";
                }
                else
                {
                    frmviewer.strString2 = "Purchase Invoice ";
                }
                frmviewer.reportTitle2 = "A";
                frmviewer.Show();
                return;
                //string strPrevix = "";
                //string strBranchId = "0001";
                //string strString2 = "";

                //if (strSelection == "Purchase")
                //{
                //    strPrevix = "PR" + strBranchId;
                //}
                //else
                //{
                //    strPrevix = "SR" + strBranchId;
                //}


                //strString2 = strString2 + "'" + strPrevix + uctxtMrName.Text + "',";

                //if (strString2 != "")
                //{
                //    strString2 = Utility.Mid(strString2, 0, strString2.Length - 1);
                //}

                //frmviewer.selector = ViewerSelector.VoucherSalesChalan;
                //frmviewer.strLedgerName = uctxtMrName.Text;
                //frmviewer.intSuppress = 1;
                //frmviewer.intvType = vouchertype;
                //frmviewer.intMode = 3;
                //if (strSelection == "Sales")
                //{
                //    frmviewer.strString2 = "Sales Return (Summary)";
                //}
                //else
                //{
                //    frmviewer.strString2 = "Purchase Return (Summary)";
                //    frmviewer.strSelction = "Purchase";
                //}
                //frmviewer.reportTitle2 = "A";
                //frmviewer.Show();
                //return;
            }

            if ((rbtnPurchaseReturn.Checked == true) && (rbtnIndividualParty.Checked == true) && (rbtnDetail.Checked == true))
            {

                if (strSelection == "Sales")
                {
                    frmviewer.selector = ViewerSelector.VoucherSalesChalan;
                    frmviewer.strLedgerName = uctxtMrName.Text;
                    frmviewer.intSuppress = 1;
                    frmviewer.intvType = vouchertype;
                    frmviewer.intMode = 1;

                    frmviewer.strString2 = "Sales Return (Individual)";
                    frmviewer.reportTitle2 = "A";
                    frmviewer.Show();
                    return;
                }
                else
                {

                    frmviewer.selector = ViewerSelector.Vouchear;
                    frmviewer.strLedgerName = uctxtMrName.Text;
                    frmviewer.intMode = vouchertype;
                    frmviewer.intvType = vouchertype;
                    frmviewer.strString2 = "Purchase Invoice (Individual)";
                    frmviewer.reportTitle2 = "A";
                    frmviewer.Show();
                    return;
                }
            }
            if ((rbtnPurchaseReturn.Checked == true) && (rbtnIndividualParty.Checked == true) && (rbtnSummary.Checked == true))
            {

                frmviewer.selector = ViewerSelector.Vouchear;
                frmviewer.strLedgerName = uctxtMrName.Text;
                frmviewer.intMode = vouchertype;
                frmviewer.reportTitle2 = "A";
                frmviewer.intvType = vouchertype;
                frmviewer.strSelction = "Sum";
                if (strSelection == "Sales")
                {
                    frmviewer.strString2 = "Sales Return (Individual)";
                }
                else
                {
                    frmviewer.strString2 = "Purchase Return (Individual)";
                }
                frmviewer.Show();
                return;
            }

            if ((rbtnPurchaseReturn.Checked == true) && (rbtnIndividualParty.Checked == true) && (rbtnDetail.Checked == true))
            {

                if (strSelection == "Sales")
                {
                    frmviewer.selector = ViewerSelector.VoucherSalesChalan;
                    frmviewer.strLedgerName = uctxtMrName.Text;
                    frmviewer.intSuppress = 1;
                    frmviewer.intvType = vouchertype;
                    frmviewer.intMode = 1;

                    frmviewer.strString2 = "Sales Return (Individual)";
                    frmviewer.reportTitle2 = "A";
                    frmviewer.Show();
                    return;
                }
                else
                {

                    frmviewer.selector = ViewerSelector.Vouchear;
                    frmviewer.strLedgerName = uctxtMrName.Text;
                    frmviewer.intMode = vouchertype;
                    frmviewer.intvType = vouchertype;
                    frmviewer.strString2 = "Purchase Invoice (Individual)";
                    frmviewer.reportTitle2 = "A";
                    frmviewer.Show();
                    return;
                }
            }

            if ((rbtnPurchaseReturn.Checked == true) && (rbtbIndividualVouNo.Checked == true) && (rbtnDetail.Checked == true))
            {
                string strPrevix = "";
                string strBranchId = "0001";
                string strString2 = "";

                if (strSelection == "Purchase")
                {
                    strPrevix = "PR" + strBranchId;
                }
                else
                {
                    strPrevix = "SR" + strBranchId;
                }


                strString2 = strString2 + "'" + strPrevix + uctxtMrName.Text + "',";

                if (strString2 != "")
                {
                    strString2 = Utility.Mid(strString2, 0, strString2.Length - 1);
                }
                frmviewer.selector = ViewerSelector.VouchearVouNo;
                frmviewer.strLedgerName = strString2;
                frmviewer.intMode = vouchertype;
                frmviewer.intvType = vouchertype;
                if (strSelection == "Sales")
                {
                    frmviewer.strString2 = "Sales Return ";
                }
                else
                {
                    frmviewer.strString2 = "Purchase Invoice ";
                }
                frmviewer.reportTitle2 = "A";
                frmviewer.Show();
                return;
                //string strPrevix = "";
                //string strBranchId = "0001";
                //string strString2 = "";

                //if (strSelection == "Purchase")
                //{
                //    strPrevix = "PR" + strBranchId;
                //}
                //else
                //{
                //    strPrevix = "SR" + strBranchId;
                //}


                //strString2 = strString2 + "'" + strPrevix + uctxtMrName.Text + "',";

                //if (strString2 != "")
                //{
                //    strString2 = Utility.Mid(strString2, 0, strString2.Length - 1);
                //}

                ////frmviewer.selector = ViewerSelector.VoucherSalesChalan;
                //frmviewer.selector = ViewerSelector.VouchearVouNo;
                
                //frmviewer.strLedgerName = uctxtMrName.Text;
                //frmviewer.intSuppress = 1;
                //frmviewer.intvType = vouchertype;
                //frmviewer.intMode = 3;
                //if (strSelection == "Sales")
                //{
                //    frmviewer.strString2 = "Sales Return (Detail)";
                //}
                //else
                //{
                //    frmviewer.strString2 = "Purchase Return (Detail)";
                //    frmviewer.strSelction = "Purchase";
                //}
                //frmviewer.reportTitle2 = "A";
                //frmviewer.Show();
                //return;

            }


            if ((rbtnPurchaseReturn.Checked == true) && (rbtnAll.Checked == true) && (rbtnDetail.Checked == true))
            {

                if (strSelection == "Sales")
                {
                    frmviewer.selector = ViewerSelector.VoucherSalesChalan;
                    frmviewer.strLedgerName = uctxtMrName.Text;
                    frmviewer.intSuppress = 1;
                    frmviewer.intvType = vouchertype;
                    frmviewer.intMode = 1;

                    frmviewer.strString2 = "Sales Return (Detail)";
                    frmviewer.reportTitle2 = "A";
                    frmviewer.Show();
                    return;
                }
                else
                {
                    frmviewer.selector = ViewerSelector.Vouchear;
                    frmviewer.strLedgerName = "";
                    frmviewer.intMode = vouchertype;
                    frmviewer.intvType = vouchertype;
                    frmviewer.strString2 = "Purchase Return (Detail)";
                    frmviewer.reportTitle2 = "A";
                    frmviewer.Show();
                    return;
                }
            }


        }
        private void btnClose_Click(object sender, EventArgs e)
        {

        }
        private void rbtnIndividualParty_Click(object sender, EventArgs e)
        {

            label4.Text = "Party Name";
            label4.Visible = true;
            uctxtMrName.Visible = true;
            uctxtMrName.Text = "";
            //rbtnReceiveInv.Visible = true;
            if (strSelection == "Purchase")
            {
                label4.Text = "Supplier Name:";
                mloadSupplyer();
            }
            else
            {
                label4.Text = "MPO Name:";
                mloadParty();

            }
            uctxtMrName.Visible = true;
            uctxtMrName.Text = "";
            DGMr.Top = uctxtMrName.Top + 25;
            DGMr.Left = uctxtMrName.Left;
            DGMr.Width = uctxtMrName.Width;
            DGMr.Height = 150;
            DGMr.BringToFront();
            DGMr.AllowUserToAddRows = false;
            DGMr.Visible = true;
            uctxtMrName.Focus();
            
            
        }

        private void rbtbIndividualVouNo_Click(object sender, EventArgs e)
        {
            label4.Visible = true;

            uctxtMrName.Visible = true;
            uctxtMrName.Text = "";
            //rbtnReceiveInv.Visible = false;
            DGMr.Visible = false;
            DGMr.Rows.Clear();
            if (rbtnPurchaseInv.Checked == true)
            {
                if (strSelection == "Purchase")
                {
                    label4.Text = "Voucher No.";
                    mloadPIinvno();
                }
                else
                {
                    label4.Text = "Voucher No.";
                    mloadSIinvno();
                }
            }
            if (rbtnSalesChalan.Checked == true)
            {
                if (strSelection == "Purchase")
                {
                    label4.Text = "Voucher No.";
                    mloadPIinvno();
                }
                else
                {
                    label4.Text = "Voucher No.";
                    mloadSIinvno();
                }
            }
            if (rbtnPurchaseReturn.Checked == true)
            {
                if (strSelection == "Purchase")
                {
                    label4.Text = "Voucher No.";
                    mloadPIinvno();
                }
                else
                {
                    label4.Text = "Voucher No.";
                    mloadSIinvno();
                }
            }
            if (rbtnSalesSamp.Checked == true)
            {
                if (strSelection == "Purchase")
                {
                    label4.Text = "Voucher No.";
                    mloadPIinvno();
                }
                else
                {
                    label4.Text = "Voucher No.";
                    mloadSIinvno();
                }
            }
            uctxtMrName.Visible = true;
            uctxtMrName.Text = "";
            DGMr.Top = uctxtMrName.Top + 25;
            DGMr.Left = uctxtMrName.Left;
            DGMr.Width = uctxtMrName.Width;
            DGMr.Height = 150;
            DGMr.BringToFront();
            DGMr.AllowUserToAddRows = false;
            DGMr.Visible = true;
            uctxtMrName.Focus();

        }

        private void rbtnAll_Click(object sender, EventArgs e)
        {
            label4.Visible = false;
            rbtnReceiveInv.Visible = false;
            uctxtMrName.Visible = false;
            DGMr.Visible = false;
            uctxtMrName.Text = "";
        }

        private void rbtnPurchaseInv_Click(object sender, EventArgs e)
        {
            groupBox6.Visible = false;
            chkboxNarration.Visible = false;
            uctxtMrName.Visible = false;
            label4.Visible = false;
            DGMr.Visible = false;
        }

        private void rbtnPurchaseOrder_Click(object sender, EventArgs e)
        {
            groupBox6.Visible = false;
            chkboxNarration.Visible = false;
            uctxtMrName.Visible = false;
            DGMr.Visible = false;
            label4.Visible = false;
        }
        private void rbtnReceiveInv_Click(object sender, EventArgs e)
        {
            groupBox6.Visible = true;
            chkboxNarration.Visible = true;
        }

        private void rbtnPurchaseReturn_Click(object sender, EventArgs e)
        {
            groupBox6.Visible = false;
            label4.Visible = false;
            rbtnReceiveInv.Visible = false;
            uctxtMrName.Visible = false;
            DGMr.Visible = false;

        }
        private void rbtnPurchaseRequisition_Click(object sender, EventArgs e)
        {
            groupBox6.Visible = false;
            label4.Visible = false;
            rbtnReceiveInv.Visible = false;
            uctxtMrName.Visible = false;
            DGMr.Visible = false;
        }
        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
