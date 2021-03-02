using Dutility;
using JA.Modulecontrolar.JINVMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;


using JA.Modulecontrolar.JACCMS;
using JA.Modulecontrolar.UI.Inventory;
using Microsoft.VisualBasic;

using Microsoft.Win32;
using JA.Modulecontrolar.UI.Master.Sales;

namespace JA.Modulecontrolar.UI.Sales.Forms
{
    public partial class frmPurchaseInvoice : JA.Shared.UI.frmSmartFormStandard
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        SPWOIS objWIS = new SPWOIS();
        private ListBox lstPartyName = new ListBox();
        private ListBox lstLedgerName = new ListBox();
        private ListBox lstSalesLedger = new ListBox();
        private ListBox lstBranchName = new ListBox();
        private ListBox lstLocation = new ListBox();
        private ListBox lstSalesRepresentive = new ListBox();
        private ListBox lstRefType = new ListBox();
        private ListBox lstBatch = new ListBox();
        private ListBox lstItemName = new ListBox();
        private ListBox lstAddlessLedger = new ListBox();
        private ListBox lstCostCategory = new ListBox();
        private ListBox lstCostCenter = new ListBox();
        private ListBox lstTypeofRef = new ListBox(); 
        public int m_action { get; set; }
        public int intVtype { get; set; }
        public int lngLedgeras { get; set; }
        public double mdblNetAmount { get; set; }
        private bool mblnNumbMethod { get; set; }
        public long lngFormPriv { get; set; }
        public string strFormName { get; set; }
        public int intModuleType { get; set; }
        private int mintIsPrin { get; set; }
        private string strComID { get; set; }
        List<InvoiceConfig> oinv;
        List<StockItem> oogrp;
        List<AccBillwise> ooRefNo;
        private string strPreserveSQl { get; set; }
        public frmPurchaseInvoice()
        {
            InitializeComponent();
            #region "User Define Event"
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.DGSalesGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGSalesGrid_CellEndEdit);
            this.uctxtRefNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtRefNo_KeyPress);
            this.uctxtRefNo.GotFocus += new System.EventHandler(this.uctxtRefNo_GotFocus);
            this.dteDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteDate_KeyPress);
            this.dteDate.GotFocus += new System.EventHandler(this.dteDate_GotFocus);
            this.dteDuedate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteDuedate_KeyPress);
            this.dteDuedate.GotFocus += new System.EventHandler(this.dteDuedate_GotFocus);
           // this.uctxtItemName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtItemName_KeyPress);
            
            
            this.uctxtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtQty_KeyPress);
            this.uctxtQty.GotFocus += new System.EventHandler(this.uctxtQty_GotFocus);
            this.uctxtQty.TextChanged += new System.EventHandler(this.uctxtQty_TextChanged);

            this.uctxtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtRate_KeyPress);
            this.uctxtRate.GotFocus += new System.EventHandler(this.uctxtRate_GotFocus);
            this.uctxtRate.TextChanged += new System.EventHandler(this.uctxtRate_TextChanged);

            this.uctxtDisc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtDisc_KeyPress);
            this.uctxtDisc.GotFocus += new System.EventHandler(this.uctxtDisc_GotFocus);
            this.uctxtDisc.TextChanged += new System.EventHandler(this.uctxtDisc_TextChanged);
            //this.uctxtBatch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBatch_KeyPress);
            this.uctxtBonusQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBonusQty_KeyPress);
            this.uctxtBonusQty.GotFocus += new System.EventHandler(this.uctxtBonusQty_GotFocus);
            this.uctxtBonusQty.TextChanged += new System.EventHandler(this.uctxtBonusQty_TextChanged);

            this.uctxtPartyName.KeyDown += new KeyEventHandler(uctxtPartyName_KeyDown);
            this.uctxtPartyName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtPartyName_KeyPress);
            this.uctxtPartyName.TextChanged += new System.EventHandler(this.uctxtPartyName_TextChanged);
            this.lstPartyName.DoubleClick += new System.EventHandler(this.lstPartyName_DoubleClick);
            this.uctxtPartyName.GotFocus += new System.EventHandler(this.uctxtPartyName_GotFocus);

            this.uctxtLedgerName.KeyDown += new KeyEventHandler(uctxtLedgerName_KeyDown);
            this.uctxtLedgerName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtLedgerName_KeyPress);
            this.uctxtLedgerName.TextChanged += new System.EventHandler(this.uctxtLedgerName_TextChanged);
            this.lstLedgerName.DoubleClick += new System.EventHandler(this.lstLedgerName_DoubleClick);
            this.uctxtLedgerName.GotFocus += new System.EventHandler(this.uctxtLedgerName_GotFocus);

            //this.uctxtSalesLedger.KeyDown += new KeyEventHandler(uctxtSalesLedger_KeyDown);
            //this.uctxtSalesLedger.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtSalesLedger_KeyPress);
            //this.uctxtSalesLedger.TextChanged += new System.EventHandler(this.uctxtSalesLedger_TextChanged);
            //this.lstSalesLedger.DoubleClick += new System.EventHandler(this.lstSalesLedger_DoubleClick);
            //this.uctxtSalesLedger.GotFocus += new System.EventHandler(this.uctxtSalesLedger_GotFocus);

            this.uctxtBranchName.KeyDown += new KeyEventHandler(uctxtBranchName_KeyDown);
            this.uctxtBranchName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranchName_KeyPress);
            this.uctxtBranchName.TextChanged += new System.EventHandler(this.uctxtBranchName_TextChanged);
            this.lstBranchName.DoubleClick += new System.EventHandler(this.lstBranchName_DoubleClick);
            this.uctxtBranchName.GotFocus += new System.EventHandler(this.uctxtBranchName_GotFocus);

            this.uctxtLocation.KeyDown += new KeyEventHandler(uctxtLocation_KeyDown);
            this.uctxtLocation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtLocation_KeyPress);
            this.uctxtLocation.TextChanged += new System.EventHandler(this.uctxtLocation_TextChanged);
            this.lstLocation.DoubleClick += new System.EventHandler(this.lstLocation_DoubleClick);
            this.uctxtLocation.GotFocus += new System.EventHandler(this.uctxtLocation_GotFocus);

            this.uctxtSalesRep.KeyDown += new KeyEventHandler(uctxtSalesRep_KeyDown);
            this.uctxtSalesRep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtSalesRep_KeyPress);
            this.uctxtSalesRep.TextChanged += new System.EventHandler(this.uctxtSalesRep_TextChanged);
            this.lstSalesRepresentive.DoubleClick += new System.EventHandler(this.lstSalesRepresentive_DoubleClick);
            this.uctxtSalesRep.GotFocus += new System.EventHandler(this.uctxtSalesRep_GotFocus);

            this.uctxtRefType.KeyDown += new KeyEventHandler(uctxtRefType_KeyDown);
            this.uctxtRefType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtRefType_KeyPress);
            this.uctxtRefType.TextChanged += new System.EventHandler(this.uctxtRefType_TextChanged);
            this.lstRefType.DoubleClick += new System.EventHandler(this.lstRefType_DoubleClick);
            this.uctxtRefType.GotFocus += new System.EventHandler(this.uctxtRefType_GotFocus);

            this.txtRefTypeNew.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtRefTypeNew_KeyPress);
            this.txtRefTypeNew.GotFocus += new System.EventHandler(this.txtRefTypeNew_GotFocus);

            this.txtRefTypeNew.KeyDown += new KeyEventHandler(txtRefTypeNew_KeyDown);
            this.txtRefTypeNew.LostFocus += new System.EventHandler(this.txtRefTypeNew_LostFocus);
            this.lstRefTypeNew.KeyPress += new System.Windows.Forms.KeyPressEventHandler(lstRefTypeNew_KeyPress);
            this.lstRefTypeNew.DoubleClick += new System.EventHandler(this.lstRefTypeNew_DoubleClick);

            this.uctxtItemName.KeyDown += new KeyEventHandler(uctxtItemName_KeyDown);
            this.uctxtItemName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtItemName_KeyPress);
            //this.uctxtItemName.TextChanged += new System.EventHandler(this.uctxtItemName_TextChanged);
            //this.lstItemName.DoubleClick += new System.EventHandler(this.lstItemName_DoubleClick);
            this.uctxtItemName.GotFocus += new System.EventHandler(this.uctxtItemName_GotFocus);
            
            this.ucdgList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(ucdgList_KeyPress);
            this.ucdgList.DoubleClick += new System.EventHandler(this.ucdgList_DoubleClick);


            this.uctxtBatch.KeyDown += new KeyEventHandler(uctxtBatch_KeyDown);
            this.uctxtBatch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBatch_KeyPress);
            this.uctxtBatch.TextChanged += new System.EventHandler(this.uctxtBatch_TextChanged);
            this.lstBatch.DoubleClick += new System.EventHandler(this.lstBatch_DoubleClick);
            this.uctxtBatch.GotFocus += new System.EventHandler(this.uctxtBatch_GotFocus);

            this.uctxtNarration.GotFocus += new System.EventHandler(this.uctxtNarration_GotFocus);
            this.uctxtNarration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtNarration_KeyPress);

            this.btnBillapply.Click += new System.EventHandler(this.btnBillapply_Click);
            this.btnBillCancel.Click += new System.EventHandler(this.btnBillCancel_Click);

            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.btnAddLessApply.Click += new System.EventHandler(this.btnAddLessApply_Click);
            //this.btnAddlessCancel.Click += new System.EventHandler(this.btnAddlessCancel_Click);

            this.uctxtAddleddLedger.KeyDown += new KeyEventHandler(uctxtAddleddLedger_KeyDown);
            this.uctxtAddleddLedger.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtAddleddLedger_KeyPress);
            this.uctxtAddleddLedger.TextChanged += new System.EventHandler(this.uctxtAddleddLedger_TextChanged);
            this.lstAddlessLedger.DoubleClick += new System.EventHandler(this.lstAddlessLedger_DoubleClick);
            this.uctxtAddleddLedger.GotFocus += new System.EventHandler(this.uctxtAddleddLedger_GotFocus);

            this.uctxtAddlessSymbol.KeyPress += new System.Windows.Forms.KeyPressEventHandler(ucttAddlessSymbol_KeyPress);
            this.uctxtAddlessSymbol.GotFocus += new System.EventHandler(this.ucttAddlessSymbol_GotFocus);

            this.uctxtAddlessAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtAddlessAmount_KeyPress);
            this.uctxtAddlessAmount.GotFocus += new System.EventHandler(this.uctxtAddlessAmount_GotFocus);

            this.uctxtTypeofRef.KeyDown += new KeyEventHandler(uctxtTypeofRef_KeyDown);
            this.uctxtTypeofRef.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtTypeofRef_KeyPress);
            this.uctxtTypeofRef.TextChanged += new System.EventHandler(this.uctxtTypeofRef_TextChanged);
            this.lstTypeofRef.DoubleClick += new System.EventHandler(this.lstTypeofRef_DoubleClick);
            this.uctxtTypeofRef.GotFocus += new System.EventHandler(this.uctxtTypeofRef_GotFocus);


            this.uctxtCostCategory.KeyDown += new KeyEventHandler(uctxtCostCategory_KeyDown);
            this.uctxtCostCategory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtCostCategory_KeyPress);
            this.uctxtCostCategory.TextChanged += new System.EventHandler(this.uctxtCostCategory_TextChanged);
            this.lstCostCategory.DoubleClick += new System.EventHandler(this.lstCostCategory_DoubleClick);
            this.uctxtCostCategory.GotFocus += new System.EventHandler(this.uctxtCostCategory_GotFocus);


            this.uctxtBatch.KeyDown += new KeyEventHandler(uctxtBatch_KeyDown);
            this.uctxtBatch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBatch_KeyPress);
            this.uctxtBatch.TextChanged += new System.EventHandler(this.uctxtBatch_TextChanged);
            this.lstBatch.DoubleClick += new System.EventHandler(this.lstBatch_DoubleClick);
            this.uctxtBatch.GotFocus += new System.EventHandler(this.uctxtBatch_GotFocus);

            this.uctxtCostCenter.KeyDown += new KeyEventHandler(uctxtCostCenter_KeyDown);
            this.uctxtCostCenter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtCostCenter_KeyPress);
            this.uctxtCostCenter.TextChanged += new System.EventHandler(this.uctxtCostCenter_TextChanged);
            this.lstCostCenter.DoubleClick += new System.EventHandler(this.lstCostCenter_DoubleClick);
            this.uctxtCostCenter.GotFocus += new System.EventHandler(this.uctxtCostCenter_GotFocus);

            this.uctxtAmount.GotFocus += new System.EventHandler(this.uctxtAmount_GotFocus);
            this.uctxtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtAmount_KeyPress);

            this.txtBillRefNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtBillRefNo_KeyPress);
            this.txtBillRefNo.GotFocus += new System.EventHandler(this.txtBillRefNo_GotFocus);

            this.dteBillDueDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteBillDueDate_KeyPress);
            this.txtBillAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtBillAmount_KeyPress);
            this.txtBillDrcr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtBillDrcr_KeyPress);
            this.txtComm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtComm_KeyPress);
            this.txtInte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtInte_KeyPress);
            this.DGAddLess.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGAddLess_CellContentClick);
            this.ucdgList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.ucdgList_CellFormatting);
            this.btnCancelnew.Click += new System.EventHandler(this.btnCancelnew_Click);
            this.DGSalesGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DGSalesGrid_EditingControlShowing);
            this.DGSalesGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGSalesGrid_KeyDown);
            this.DGSalesGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGSalesGrid_CellContentClick);

            Utility.CreateListBox(lstPartyName, pnlMain, uctxtPartyName);
            Utility.CreateListBox(lstLedgerName, pnlMain, uctxtLedgerName);
            //Utility.CreateListBox(lstSalesLedger, pnlMain, uctxtSalesLedger);
            Utility.CreateListBox(lstBranchName, pnlMain, uctxtBranchName);
            Utility.CreateListBox(lstLocation, pnlMain, uctxtLocation);
            Utility.CreateListBox(lstSalesRepresentive, pnlMain, uctxtSalesRep);
            Utility.CreateListBox(lstRefType, pnlMain, uctxtRefType);
            Utility.CreateListBox(lstItemName, pnlMain, uctxtItemName);
            Utility.CreateListBox(lstBatch, panel2, uctxtBatch);
            Utility.CreateListBox(lstAddlessLedger, pnlAddLess, uctxtAddleddLedger);
            Utility.CreateListBox(lstTypeofRef, pnlBillWise, uctxtTypeofRef);
            Utility.CreateListBox(lstCostCategory, pnlCostCenter, uctxtCostCategory);
            Utility.CreateListBox(lstCostCenter, pnlCostCenter, uctxtCostCenter);
            #endregion
        }

        #region "Calculatetotal
        private void calculateTotal()
        {
            int intloop = 0;
            double dblNetAmount = 0, dblBillAmount = 0, dblTotalQnty = 0, dblTotalAmount = 0, dblTotalCommissionMinus=0, dblTotalCommissionPlus=0;
            for (int i = 0; i < DgCostCenter.Rows.Count; i++)
            {
                if (DgCostCenter.Rows[i].Cells[1].Value != null)
                {
                    dblNetAmount = dblNetAmount + Utility.Val(DgCostCenter.Rows[i].Cells[2].Value.ToString());
                }
            }
            for (int i = 0; i < dgBillBranch.Rows.Count; i++)
            {
                if (dgBillBranch.Rows[i].Cells[1].Value != null)
                {
                    dblBillAmount = dblBillAmount + Utility.Val(dgBillBranch.Rows[i].Cells[3].Value.ToString());
                }
            }

            for (int i = 0; i < DGSalesGrid.Rows.Count; i++)
            {
                if (DGSalesGrid.Rows[i].Cells[1].Value != null)
                {
                    dblTotalQnty = dblTotalQnty + Utility.Val(DGSalesGrid.Rows[i].Cells[3].Value.ToString());
                    dblTotalAmount = dblTotalAmount + Utility.Val(DGSalesGrid.Rows[i].Cells[6].Value.ToString());
                    intloop += 1;
                }
            }

            for (int introw = 0; introw < DGAddLess.Rows.Count; introw++)
            {
                if (DGAddLess[2, introw].Value != "")
                {
                    if (DGAddLess[1, introw].Value != "" && DGAddLess[1, introw].Value != null)
                    {
                        if (Utility.Left(DGAddLess[1, introw].Value.ToString(), 1) == "-")
                        {
                            dblTotalCommissionMinus = dblTotalCommissionMinus + Utility.Val(DGAddLess[2, introw].Value.ToString());
                        }
                        else
                        {
                            dblTotalCommissionPlus = dblTotalCommissionPlus + Utility.Val(DGAddLess[2, introw].Value.ToString());
                        }
                    }
                    //else
                    //{
                    //    dblTotalCommissionPlus = dblTotalCommissionPlus + Utility.Val(DGAddLess[2, introw].Value.ToString());
                    //}
                }
            }

            uctxtAdd.Text = dblTotalCommissionPlus.ToString();
            uctxtLess.Text = dblTotalCommissionMinus.ToString();
            //lblNetAmount.Text = (Utility.Val(lblTotalAmount.Text) + Utility.Val(uctxtAdd.Text) - Utility.Val(uctxtLess.Text)).ToString();

            txtTotalItem.Text = "Total Item :" + intloop;
            txtTotal.Text = dblNetAmount.ToString();
            txtBillTotal.Text = dblBillAmount.ToString();
            lblQuantityTotal.Text = dblTotalQnty.ToString();
            lblNetTotal.Text = dblTotalAmount.ToString();
            lblTotalAmount.Text = dblTotalAmount.ToString();
            lblNetAmount.Text = (Utility.Val(lblTotalAmount.Text) + Utility.Val(uctxtAdd.Text) - Utility.Val(uctxtLess.Text)).ToString();

        }
        #endregion
        #region "User Define event"
        #region "Keydown"
        private void DGSalesGrid_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                e.SuppressKeyPress = true;
                int iColumn = DGSalesGrid.CurrentCell.ColumnIndex;
                int iRow = DGSalesGrid.CurrentCell.RowIndex;
                if (iRow == DGSalesGrid.Rows.Count - 1)
                    btnSave.Focus();
                else
                    DGSalesGrid.CurrentCell = DGSalesGrid[iColumn, iRow + 1];
            }
        }
        #endregion
        private void DGSalesGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (DGSalesGrid.CurrentCell.ColumnIndex == 4) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }

            }
           

        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                if (e.KeyChar != 46)
                {
                    e.Handled = true;
                }
            }
        }
        private void ucdgList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ucdgList.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Yellow;
            ucdgList.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            ucdgList.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("verdana", 9);
        }
        private void DGSalesGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                DGSalesGrid[6, e.RowIndex].Value = Utility.Val(DGSalesGrid[3, e.RowIndex].Value.ToString()) * Utility.Val(DGSalesGrid[4, e.RowIndex].Value.ToString());
                DGSalesGrid[8, e.RowIndex].Value = Utility.Val(DGSalesGrid[3, e.RowIndex].Value.ToString()) * Utility.Val(DGSalesGrid[4, e.RowIndex].Value.ToString());
            }
            if (e.ColumnIndex == 3)
            {
                DGSalesGrid[6, e.RowIndex].Value = Utility.Val(DGSalesGrid[3, e.RowIndex].Value.ToString()) * Utility.Val(DGSalesGrid[4, e.RowIndex].Value.ToString());
                DGSalesGrid[8, e.RowIndex].Value = Utility.Val(DGSalesGrid[3, e.RowIndex].Value.ToString()) * Utility.Val(DGSalesGrid[4, e.RowIndex].Value.ToString());
            }
            if (e.ColumnIndex == 8)
            {
                DGSalesGrid[6, e.RowIndex].Value = Utility.Val(DGSalesGrid[8, e.RowIndex].Value.ToString());
                DGSalesGrid[4, e.RowIndex].Value = Math.Round(Utility.Val(DGSalesGrid[8, e.RowIndex].Value.ToString()) / Utility.Val(DGSalesGrid[3, e.RowIndex].Value.ToString()),2);
            }

            calculateTotal();
        }
        private void uctxtQty_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumericNew(uctxtQty.Text) == false)
            {
                uctxtQty.Text = "";
            }
        }

        private void uctxtRate_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumericNew(uctxtRate.Text) == false)
            {
                uctxtRate.Text = "";
            }
        }


        private void uctxtDisc_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumericNew(uctxtDisc.Text) == false)
            {
                uctxtDisc.Text = "";
            }
        }


        private void uctxtBonusQty_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumericNew(uctxtBonusQty.Text) == false)
            {
                uctxtBonusQty.Text = "";
            }
        }
        private void txtBillRefNo_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstRefType.Visible = false;
            lstItemName.Visible = false;
            lstBatch.Visible = false;
            lstAddlessLedger.Visible = false;
            lstTypeofRef.Visible = false;
            lstCostCategory.Visible = false;
            lstCostCenter.Visible = false;
        }
        private void txtRefTypeNew_LostFocus(object sender, System.EventArgs e)
        {
            int i = 0;
            double dblPrice=0;
            if (m_action != (int)Utility.ACTION_MODE_ENUM.EDIT_MODE)
            {
                if (txtRefTypeNew.Text != Utility.gcEND_OF_LIST)
                {
                    long lngRefType = gobjVoucherName.VoucherName.GetVoucherType(uctxtRefType.Text);
                    string strBraID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);
                    if (txtRefTypeNew.Text == "Purchase Order")
                    {
                        DGSalesGrid.Rows.Clear();
                        for (int introw = 0; introw < DGSalesOrder.Rows.Count; introw++)
                        {
                            if (DGSalesOrder[0, introw].Value != null)
                            {
                                List<Invoice> ooinv = invms.mGetAllOrder(strComID, strBraID, lngRefType, DGSalesOrder[1, introw].Value.ToString()).ToList();
                                if (ooinv.Count > 0)
                                {
                                    foreach (Invoice oinv in ooinv)
                                    {
                                        DGSalesGrid.Rows.Add();
                                        //dblPrice = Utility.gdblGetEnterpriseSalesPrice(oinv.strItemName, dteDate.Text, oinv.dblQty, 0);
                                        DGSalesGrid[1, i].Value = oinv.strItemName;
                                        DGSalesGrid[2, i].Value = Utility.mGetItemDescription(strComID, oinv.strItemName);
                                        DGSalesGrid[3, i].Value = oinv.dblQty + " " + oinv.strUom;
                                        DGSalesGrid[4, i].Value = oinv.dblRate;
                                        DGSalesGrid[5, i].Value = oinv.strUnit; ;
                                        DGSalesGrid[6, i].Value = Math.Round(oinv.dblQty * oinv.dblRate, 2);
                                        DGSalesGrid[7, i].Value = oinv.dblDiscount;
                                        DGSalesGrid[8, i].Value = Math.Round((oinv.dblQty * oinv.dblRate) - oinv.dblDiscount, 2);
                                        DGSalesGrid[9, i].Value = oinv.strBatch;
                                        DGSalesGrid[10, i].Value = oinv.dblBonusQty;
                                        DGSalesGrid[12, i].Value = DGSalesOrder[0, introw].Value.ToString();
                                        DGSalesGrid[13, i].Value = DGSalesOrder[0, introw].Value.ToString();
                                        i += 1;
                                    }
                                    DGSalesGrid.AllowUserToAddRows = false;
                                }
                            }
                            calculateTotal();
                        }
                    }
                }
            }
        }
        private void txtRefTypeNew_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstRefType.Visible = false;
            lstItemName.Visible = false;
            lstBatch.Visible = false;
            lstAddlessLedger.Visible = false;
            lstCostCategory.Visible = false;
            lstCostCenter.Visible = false; ;

            long lngRefType = gobjVoucherName.VoucherName.GetVoucherType(uctxtRefType.Text);
            if (uctxtLocation.Text != "")
            {
                mLoadAllItem(uctxtPartyName.Text, lngRefType, dteDate.Text, Utility.gstrGetBranchID(strComID, uctxtBranchName.Text), uctxtLocation.Text);
            }
        }

        private void mLoadAllItem(string strPartyname, long lngVtype, string strDate, string strBranchID,string strGodowns)
        {
            int introw = 0;
            this.lstRefTypeNew.DefaultCellStyle.Font = new Font("verdana", 9);
            lstRefTypeNew.Rows.Clear();
            ooRefNo = accms.gFillPreRefNo(strComID, strPartyname, lngVtype, strDate, strBranchID, strGodowns,"",0).ToList();
            if (ooRefNo.Count > 0)
            {

                foreach (AccBillwise ogrp in ooRefNo)
                {
                    lstRefTypeNew.Rows.Add();
                    lstRefTypeNew[0, introw].Value = ogrp.strBillKey;
                    //if (lngVtype != (long)Utility.VOUCHER_TYPE.vt_SAMPLE_CLASS)
                    //{
                    lstRefTypeNew[1, introw].Value = Utility.Mid(ogrp.strRefNo, 6, ogrp.strRefNo.Length - 6);
                    //}
                    //else
                    //{
                    //    lstRefTypeNew[1, introw].Value = ogrp.strRefNo;
                    //}
                    lstRefTypeNew[2, introw].Value = ogrp.strDate;
                    if (introw % 2 == 0)
                    {
                        lstRefTypeNew.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                    }
                    else
                    {
                        lstRefTypeNew.Rows[introw].DefaultCellStyle.BackColor = Color.White;
                    }
                    introw += 1;
                }
                lstRefTypeNew.AllowUserToAddRows = false;
            }
        }
        private void txtRefTypeNew_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.F3)
            //{
            //    lstRefType.Visible = false;
            //    long lngRefType = gobjVoucherName.VoucherName.GetVoucherType(uctxtRefType.Text);
            //    frmAllReferance objfrm = new frmAllReferance();
            //    objfrm.strPartyname = uctxtPartyName.Text;
            //    objfrm.strBranchID = Utility.gstrGetBranchID(strComID, uctxtBranch.Text);;
            //    objfrm.strDate = dteDate.Text;
            //    objfrm.lngVtype = lngRefType;
            //    objfrm.onAddAllButtonClicked = new frmAllReferance.AddAllClick(DisplayReferance);
            //    objfrm.Show();
            //    objfrm.MdiParent = MdiParent;
            //}
            lstRefTypeNew.Visible = true;
            //txtFoodCode.Text = "";
            //txtFoodName.Text = "";
            if (e.KeyCode == Keys.Up)
            {
                lstRefTypeNew.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                lstRefTypeNew.Focus();
            }

            lstRefTypeNew.Top = txtRefTypeNew.Top + 25;
            lstRefTypeNew.Left = txtRefTypeNew.Left;
            lstRefTypeNew.Width = txtRefTypeNew.Width;
            lstRefTypeNew.Height = 200;
            //ucdgList.Size = new Size(546, 222);
            lstRefTypeNew.BringToFront();
            lstRefTypeNew.AllowUserToAddRows = false;
            //uctxtItemName.Text = Utility.GetDgValue(ucdgList, uctxtItemName, 0);
            //ucdgList.Focus();
            return;


        }

        private void txtRefTypeNew_KeyPress(object sender, KeyPressEventArgs e)
        {
            string strBillKey, strRefNo, strDate;
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtRefTypeNew.Text == "")
                {
                    //txtItemCode.Text = "";
                    txtRefTypeNew.Text = "";
                    lstRefTypeNew.Visible = false;
                    uctxtNarration.Focus();
                    return;
                }


                if (txtRefTypeNew.Text != "")
                {
                    lstRefTypeNew.Focus();
                    if (lstRefTypeNew.Rows.Count > 0)
                    {
                        int i = 0;

                        txtRefTypeNew.Text = lstRefTypeNew.Rows[i].Cells[0].Value.ToString();

                        i = Convert.ToInt16(lstRefTypeNew.CurrentRow.Index.ToString());
                        strBillKey = lstRefTypeNew.Rows[i].Cells[0].Value.ToString();
                        strRefNo = lstRefTypeNew.Rows[i].Cells[1].Value.ToString();
                        strDate = lstRefTypeNew.Rows[i].Cells[2].Value.ToString();
                        DisplayReferance(strBillKey, strRefNo, strDate);


                        lstRefTypeNew.Visible = false;
                        txtRefTypeNew.Focus();
                    }
                }
                else
                {
                    int i = 0;

                    txtRefTypeNew.Text = lstRefTypeNew.Rows[i].Cells[0].Value.ToString();

                    i = Convert.ToInt16(lstRefTypeNew.CurrentRow.Index.ToString());
                    strBillKey = lstRefTypeNew.Rows[i].Cells[0].Value.ToString();
                    strRefNo = lstRefTypeNew.Rows[i].Cells[1].Value.ToString();
                    strDate = lstRefTypeNew.Rows[i].Cells[2].Value.ToString();
                    DisplayReferance(strBillKey, strRefNo, strDate);
                    lstRefTypeNew.Visible = false;
                    txtRefTypeNew.Focus();
                }
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                //PriorSetFocusText(txtRefTypeNew, sender, e);
            }
        }

        private void lstRefTypeNew_DoubleClick(object sender, EventArgs e)
        {
            //DateTime firstDay = Convert.ToDateTime(DateTime.Parse(month + ", 1 " + year, CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"));
            //DateTime lastDay = Convert.ToDateTime(firstDay.AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy"));
            //int LastDay = lastDay.Day;

            string strBillKey, strRefNo, strDate;
            if (lstRefTypeNew.SelectedRows.Count > 0)
            {
                txtRefTypeNew.Text = Utility.GetDgValue(lstRefTypeNew, uctxtItemName, 0);
                int i = Convert.ToInt16(lstRefTypeNew.CurrentRow.Index.ToString());
                strBillKey = lstRefTypeNew.Rows[i].Cells[0].Value.ToString();
                strRefNo = lstRefTypeNew.Rows[i].Cells[1].Value.ToString();
                strDate = lstRefTypeNew.Rows[i].Cells[2].Value.ToString();
                DisplayReferance(strBillKey, strRefNo, strDate);
                lstRefTypeNew.Visible = false;
                txtRefTypeNew.Focus();


            }
        }
        private void lstRefTypeNew_KeyPress(object sender, KeyPressEventArgs e)
        {
            string strBillKey, strRefNo, strDate;
            if (lstRefTypeNew.SelectedRows.Count > 0)
                if (e.KeyChar == (char)Keys.Return)
                {
                    txtRefTypeNew.Text = Utility.GetDgValue(lstRefTypeNew, uctxtItemName, 0);
                    int i = Convert.ToInt16(lstRefTypeNew.CurrentRow.Index.ToString());
                    strBillKey = lstRefTypeNew.Rows[i].Cells[0].Value.ToString();
                    strRefNo = lstRefTypeNew.Rows[i].Cells[1].Value.ToString();
                    strDate = lstRefTypeNew.Rows[i].Cells[2].Value.ToString();
                    DisplayReferance(strBillKey, strRefNo, strDate);
                    lstRefTypeNew.Visible = false;
                    txtRefTypeNew.Focus();
                }
        }
        private void DisplayReferance(string strBillKey, string strRefNo, string strDate)
        {
            try
            {

                //uctxtItemName.Text = tests[0].strItemName;
                int selRaw;
                // string strSalesOrder = "";

                string strDown = "";
                Boolean blngCheck = false;
                for (int j = 0; j < DGSalesOrder.RowCount; j++)
                {
                    if (DGSalesOrder[0, j].Value != null)
                    {
                        strDown = DGSalesOrder[0, j].Value.ToString();
                    }
                    if (strBillKey == strDown.ToString())
                    {
                        blngCheck = true;
                    }

                }
                if (blngCheck == false)
                {

                    DGSalesOrder.AllowUserToAddRows = true;
                    selRaw = Convert.ToInt16(DGSalesOrder.RowCount.ToString());
                    selRaw = selRaw - 1;
                    DGSalesOrder.Rows.Add();
                    DGSalesOrder[0, selRaw].Value = strBillKey;
                    DGSalesOrder[1, selRaw].Value = strRefNo;
                    DGSalesOrder[2, selRaw].Value = strDate;
                    DGSalesOrder.AllowUserToAddRows = false;
                    txtRefTypeNew.Text = "";
                    calculateTotal();
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void uctxtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                if (uctxtAmount.Text != "")
                {
                    if (uctxtAmount.Text != "0")
                    {
                        mAdditemCostCenter("", uctxtCostCategory.Text, uctxtCostCenter.Text, Convert.ToDouble(uctxtAmount.Text));
                        uctxtCostCenter.Focus();
                        uctxtAmount.Text = (Convert.ToDouble(txtpreAmount.Text) - Convert.ToDouble(txtTotal.Text)).ToString();
                    }
                    else
                    {
                        btnApply.Focus();
                    }
                }
                else
                {
                    uctxtAmount.Focus();
                }
                calculateTotal();
                uctxtCostCategory.Focus();
            }
        }
        private void uctxtAmount_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstRefType.Visible = false;
            lstItemName.Visible = false;
            lstBatch.Visible = false;
            lstAddlessLedger.Visible = false;
            lstCostCategory.Visible = false;
            lstCostCenter.Visible = false;
            
        }


        private void uctxtCostCenter_TextChanged(object sender, EventArgs e)
        {
            lstCostCenter.SelectedIndex = lstCostCenter.FindString(uctxtCostCenter.Text);
        }

        private void lstCostCenter_DoubleClick(object sender, EventArgs e)
        {
            uctxtCostCenter.Text = lstCostCenter.Text;
            uctxtAmount.Focus();
        }

        private void uctxtCostCenter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstCostCenter.Items.Count > 0)
                {
                    uctxtCostCenter.Text = lstCostCenter.Text;
                }
                uctxtAmount.Focus();

            }
        }
        private void uctxtCostCenter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstCostCenter.SelectedItem != null)
                {
                    lstCostCenter.SelectedIndex = lstCostCenter.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstCostCenter.Items.Count - 1 > lstCostCenter.SelectedIndex)
                {
                    lstCostCenter.SelectedIndex = lstCostCenter.SelectedIndex + 1;
                }
            }

        }
        private void mAdditemCostCenter(string strBranchName, string strCostCategory, string strCostCenter, double dblnetamount)
        {
            int selRaw;

            string strDown = "";
            Boolean blngCheck = false;
            for (int j = 0; j < DgCostCenter.RowCount; j++)
            {
                if (DgCostCenter[1, j].Value != null)
                {
                    strDown = DgCostCenter[1, j].Value.ToString();
                }
                if (strCostCenter == strDown.ToString())
                {
                    blngCheck = true;
                }

            }
            if (blngCheck == false)
            {

                DgCostCenter.AllowUserToAddRows = true;
                selRaw = Convert.ToInt16(DgCostCenter.RowCount.ToString());
                selRaw = selRaw - 1;
                DgCostCenter.Rows.Add();
                //DgCostCenter[0, selRaw].Value = strBranchName.ToString();
                DgCostCenter[0, selRaw].Value = strCostCategory.ToString();
                DgCostCenter[1, selRaw].Value = strCostCenter.ToString();
                DgCostCenter[2, selRaw].Value = dblnetamount.ToString();
                DgCostCenter.AllowUserToAddRows = false;
                calculateTotal();
            }

        }
        private void uctxtCostCenter_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstRefType.Visible = false;
            lstItemName.Visible = false;
            lstBatch.Visible = false;
            lstAddlessLedger.Visible = false;
            lstCostCategory.Visible = false;
            lstCostCenter.Visible = true;
            lstCostCategory.SelectedIndex = lstCostCategory.FindString(uctxtCostCategory.Text);
            if (uctxtCostCategory.Text != "")
            {
                lstCostCenter.ValueMember = "strCostCenter";
                lstCostCenter.DisplayMember = "strCostCenter";
                lstCostCenter.DataSource = accms.mFillVectorMaster(strComID, uctxtCostCategory.Text).ToList();
            }
            lstCostCenter.SelectedIndex = lstCostCenter.FindString(uctxtCostCenter.Text);
        }
        private void uctxtCostCategory_TextChanged(object sender, EventArgs e)
        {
            lstCostCategory.SelectedIndex = lstCostCategory.FindString(uctxtCostCategory.Text);
        }

        private void lstCostCategory_DoubleClick(object sender, EventArgs e)
        {
            uctxtCostCategory.Text = lstCostCategory.Text;
            uctxtCostCenter.Focus();
        }

        private void uctxtCostCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtAmount.Text != "0")
                {
                    if (lstCostCategory.Items.Count > 0)
                    {
                        uctxtCostCategory.Text = lstCostCategory.Text;
                        uctxtCostCenter.Focus();
                    }
                    else
                    {
                        btnApply.Focus();
                    }
                   
                }
                else
                {
                    btnApply.Focus();
                }

            }
        }
        private void uctxtCostCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstCostCategory.SelectedItem != null)
                {
                    lstCostCategory.SelectedIndex = lstCostCategory.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstCostCategory.Items.Count - 1 > lstCostCategory.SelectedIndex)
                {
                    lstCostCategory.SelectedIndex = lstCostCategory.SelectedIndex + 1;
                }
            }

        }

        private void uctxtCostCategory_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstRefType.Visible = false;
            lstItemName.Visible = false;
            lstBatch.Visible = false;
            lstAddlessLedger.Visible = false;
            lstCostCategory.Visible = true;
            lstCostCategory.SelectedIndex = lstCostCategory.FindString(uctxtCostCategory.Text);

        }
        private void txtInte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                // uctxtTypeofRef.Focus();
                double dblComm = 0, dblint = 0;
                if (e.KeyChar == (char)Keys.Return)
                {

                    if (txtBillRefNo.Text != "")
                    {
                        {
                            if (txtComm.Text == "")
                            {
                                dblComm = 0;
                            }
                            else
                            {
                                dblComm = Convert.ToDouble(txtComm.Text);
                            }
                            if (txtInte.Text == "")
                            {
                                dblint = 0;
                            }
                            else
                            {
                                dblint = Convert.ToDouble(txtInte.Text);
                            }

                            mAdditemBill(uctxtTypeofRef.Text, txtBillRefNo.Text, dteBillDueDate.Text, Utility.Val(txtBillAmount.Text), txtBillDrcr.Text, dblComm, dblint);
                            txtBillAmount.Text = (Utility.Val(txtBillPreTotal.Text) - Utility.Val(txtBillTotal.Text)).ToString();
                        }

                    }
                    //txtBillDrcr.Text = uctxtDrCr.Text;
                    uctxtTypeofRef.Text = "";
                    txtBillRefNo.Text = "";
                    txtComm.Text = "0";
                    txtInte.Text = "0";
                    uctxtTypeofRef.Focus();


                }
            }
        }

        private void mAdditemBill(string strTypeofRef, string strBillRefNo, string strdueDate, double dblAmount, string strDrcr, double dblComm, double dblInt)
        {
            int selRaw;

            string strDown = "";
            Boolean blngCheck = false;
            for (int j = 0; j < dgBillBranch.RowCount; j++)
            {
                if (dgBillBranch[1, j].Value != null)
                {
                    strDown = dgBillBranch[2, j].Value.ToString();
                }
                if (strBillRefNo == strDown.ToString())
                {
                    blngCheck = true;
                }

            }
            if (blngCheck == false)
            {

                dgBillBranch.AllowUserToAddRows = true;
                selRaw = Convert.ToInt16(dgBillBranch.RowCount.ToString());
                selRaw = selRaw - 1;
                dgBillBranch.Rows.Add();
                dgBillBranch[0, selRaw].Value = strTypeofRef.ToString();
                dgBillBranch[1, selRaw].Value = strBillRefNo.ToString();
                dgBillBranch[2, selRaw].Value = strdueDate.ToString();
                dgBillBranch[3, selRaw].Value = dblAmount.ToString();
                dgBillBranch[4, selRaw].Value = strDrcr.ToString();
                dgBillBranch[5, selRaw].Value = dblComm.ToString();
                dgBillBranch[6, selRaw].Value = dblInt.ToString();
                dgBillBranch.AllowUserToAddRows = false;
                uctxtTypeofRef.Text = "";
                txtBillRefNo.Text = "";
                txtBillAmount.Text = "";
                txtComm.Text = "0";
                txtInte.Text = "0";
                calculateTotal();
            }

        }



        private void txtComm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtInte.Focus();

            }
        }
        private void txtBillDrcr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtComm.Focus();

            }
        }
        private void dteBillDueDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtBillAmount.Focus();

            }
        }
        private void txtBillAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtBillDrcr.Focus();

            }
        }
        private void txtBillRefNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dteBillDueDate.Focus();

            }
        }

        private void uctxtTypeofRef_TextChanged(object sender, EventArgs e)
        {
            lstTypeofRef.SelectedIndex = lstTypeofRef.FindString(uctxtTypeofRef.Text);
        }

        private void lstTypeofRef_DoubleClick(object sender, EventArgs e)
        {
            uctxtTypeofRef.Text = lstTypeofRef.Text;
            txtBillRefNo.Focus();
        }

        private void uctxtTypeofRef_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtBillTotal.Text == txtBillPreTotal.Text)
                {
                    btnBillapply.Focus();
                    return;
                }
                if (txtBillAmount.Text == "" || txtBillAmount.Text == "0")
                {
                    btnBillapply.Focus();
                    return;
                }
                else
                {
                    if (lstTypeofRef.Items.Count > 0)
                    {
                        uctxtTypeofRef.Text = lstTypeofRef.Text;
                    }

                    txtBillRefNo.Focus();
                }


            }
        }
        private void uctxtTypeofRef_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstTypeofRef.SelectedItem != null)
                {
                    lstTypeofRef.SelectedIndex = lstTypeofRef.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstTypeofRef.Items.Count - 1 > lstTypeofRef.SelectedIndex)
                {
                    lstTypeofRef.SelectedIndex = lstTypeofRef.SelectedIndex + 1;
                }
            }

        }

        private void uctxtTypeofRef_GotFocus(object sender, System.EventArgs e)
        {
            lstTypeofRef.Visible = true;
            lstTypeofRef.SelectedIndex = lstTypeofRef.FindString(uctxtTypeofRef.Text);
        }


        private void uctxtAddlessAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                //uctxtAddleddLedger.Focus();
                mAdditemLedgerBill(uctxtAddleddLedger.Text, uctxtAddlessSymbol.Text, Utility.Val(uctxtAddlessAmount.Text.ToString()));
                //uctxtAddleddLedger.Focus();
            }
        }

        private void mAdditemLedgerBill(string strLedgerName, string strSymbol, double dblnetamount)
        {
            int selRaw;

            string strDown = "";
            Boolean blngCheck = false;
            for (int j = 0; j < DGAddLess.RowCount; j++)
            {
                if (DGAddLess[0, j].Value != null)
                {
                    strDown = DGAddLess[0, j].Value.ToString();
                }
                if (strLedgerName == strDown.ToString())
                {
                    blngCheck = true;
                    uctxtAddleddLedger.Text = "";
                    uctxtAddlessSymbol.Text = "";
                    uctxtAddlessAmount.Text = "";
                    uctxtAddleddLedger.Focus();
                }

            }
            if (blngCheck == false)
            {

                DGAddLess.AllowUserToAddRows = true;
                selRaw = Convert.ToInt16(dgBillBranch.RowCount.ToString());
                selRaw = selRaw - 1;
                if(selRaw ==-1)
                {
                    selRaw = 0;
                }
                DGAddLess.Rows.Add();
                DGAddLess[0, selRaw].Value = strLedgerName.ToString();
                DGAddLess[1, selRaw].Value = strSymbol.ToString();
                DGAddLess[2, selRaw].Value = dblnetamount.ToString();
                dgBillBranch.AllowUserToAddRows = false;
                uctxtAddleddLedger.Text = "";
                uctxtAddlessSymbol.Text = "";
                uctxtAddlessAmount.Text = "";
                uctxtAddleddLedger.Focus();
                DGAddLess.AllowUserToAddRows = false;
                //calculateTotal();
            }

        }

        private void uctxtAddlessAmount_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstRefType.Visible = false;
            lstItemName.Visible = false;
            lstBatch.Visible = false;
            lstAddlessLedger.Visible = false;
        }
        private void ucttAddlessSymbol_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstRefType.Visible = false;
            lstItemName.Visible = false;
            lstBatch.Visible = false;
            lstAddlessLedger.Visible = false;
        }
        private void ucttAddlessSymbol_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
               
                uctxtAddlessAmount.Focus();

            }
        }
        private void uctxtAddleddLedger_TextChanged(object sender, EventArgs e)
        {
            lstAddlessLedger.Visible = true;
            lstAddlessLedger.SelectedIndex = lstAddlessLedger.FindString(uctxtAddleddLedger.Text);
        }

        private void lstAddlessLedger_DoubleClick(object sender, EventArgs e)
        {
            uctxtAddleddLedger.Text = lstAddlessLedger.Text;
            uctxtAddlessSymbol.Focus();
        }

        private void uctxtAddleddLedger_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtAddleddLedger.Text != "")
                {
                    if (lstAddlessLedger.Items.Count > 0)
                    {
                        uctxtAddleddLedger.Text = lstAddlessLedger.Text;
                    }
                    uctxtAddlessSymbol.Focus();
                }
                else
                {
                    btnAddLessApply.Focus();
                }

            }
        }
        private void uctxtAddleddLedger_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode==Keys.F3)
            //{
            //    uctxtAddleddLedger.Text = "";
            //    lstAddlessLedger.Visible = true;
            //}

            if (e.KeyCode == Keys.Up)
            {
                if (lstAddlessLedger.SelectedItem != null)
                {
                    lstAddlessLedger.SelectedIndex = lstAddlessLedger.SelectedIndex - 1;
                    uctxtAddleddLedger.Text = lstAddlessLedger.Text;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstAddlessLedger.Items.Count - 1 > lstAddlessLedger.SelectedIndex)
                {
                    lstAddlessLedger.SelectedIndex = lstAddlessLedger.SelectedIndex + 1;
                    uctxtAddleddLedger.Text = lstAddlessLedger.Text;
                }
            }
            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 96))
                    {
                        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                //if (System.Windows.Forms.Application.OpenForms["frmAccountsLedger"] as frmAccountsLedger == null)
                //{
                //    frmAccountsLedger objfrm = new frmAccountsLedger();
                //    objfrm.m_acction = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                //    objfrm.lngFormPriv = 96;
                //    objfrm.mSingleEntry = 1;
                //    objfrm.Show();
                //    objfrm.BringToFront();
                //    objfrm.MdiParent = this.MdiParent;

                //}
                //else
                //{
                //    frmAccountsLedger objfrm = (frmAccountsLedger)Application.OpenForms["frmAccountsLedger"];
                //    objfrm.lngFormPriv = 96;
                //    objfrm.mSingleEntry = 1;
                //    objfrm.Focus();
                //    objfrm.MdiParent = this.MdiParent;
                //}


            }

        }

        private void uctxtAddleddLedger_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstRefType.Visible = false;
            lstItemName.Visible = false;
            lstBatch.Visible = false;
            lstAddlessLedger.Visible = false;
            lstAddlessLedger.ValueMember = "strLedgerName";
            lstAddlessLedger.DisplayMember = "strLedgerName";
            lstAddlessLedger.DataSource = invms.mfillLedgerInvoice(strComID, false, 0,"").ToList();

            lstAddlessLedger.SelectedIndex = lstAddlessLedger.FindString(uctxtAddleddLedger.Text);
        }


        private void btnAddLessApply_Click(object sender, EventArgs e)
        {
            double dblTotalCommissionMinus = 0, dblTotalCommissionPlus = 0;
            pnlAddLess.Visible = false;
            //int selraw = 0;
            string strLegderName = "";

            for (int introw = 0; introw < DGAddLess.Rows.Count; introw++)
            {
                if (DGAddLess[2, introw].Value != "")
                {
                    //if (DGAddLess[1, introw].Value != "" && DGAddLess[1, introw].Value != null)
                    //{
                        if (Utility.Left(DGAddLess[2, introw].Value.ToString(), 1) == "-")
                        {
                            dblTotalCommissionMinus = dblTotalCommissionMinus + Utility.Val(DGAddLess[2, introw].Value.ToString());
                        }
                        else
                        {
                            dblTotalCommissionPlus = dblTotalCommissionPlus + Utility.Val(DGAddLess[2, introw].Value.ToString());
                        }
                    //}
                    //else
                    //{
                    //    dblTotalCommissionPlus = dblTotalCommissionPlus + Utility.Val(DGAddLess[2, introw].Value.ToString());
                    //}
                }
            }

            uctxtAdd.Text = dblTotalCommissionPlus.ToString();
            uctxtLess.Text = dblTotalCommissionMinus.ToString();
            lblNetAmount.Text = (Utility.Val(lblTotalAmount.Text) + Utility.Val(uctxtAdd.Text) - Utility.Val(uctxtLess.Text)).ToString();

                pnlCostCenter.Visible = false;
                //if (Utility.mblnBillWise(strComID, uctxtPartyName.Text) == true)
                //{
                //    pnlBillWise.Visible = true;
                //    pnlBillWise.Top = uctxtQty.Top + 60;
                //    pnlBillWise.Left = uctxtItemName.Left + 80;
                //    pnlBillWise.Size = new Size(711, 301);
                //    txtBillLedger.Text = uctxtPartyName.Text;
                //    txtBillRefNo.Text = uctxtRefNo.Text;

                //    txtBillDrcr.Text = "Dr";
                //    txtBillPreTotal.Text = lblTotalAmount.Text;
                //    txtBillAmount.Text = lblTotalAmount.Text;
                //    txtComm.Text = "0";
                //    txtInte.Text = "0";
                //    lblBillWise.Text = "Bill Wise Details for " + uctxtPartyName.Text;
                //    uctxtTypeofRef.Focus();
                //}

                //if (pnlBillWise.Visible == false)
                //{
                //    if (Utility.gbcheckCostCenter(strComID, uctxtPartyName.Text) == true)
                //    {
                //        pnlCostCenter.Visible = true;
                //        uctxtCostCategory.Focus();
                //        pnlCostCenter.Top = uctxtBranchName.Top + 10;
                //        pnlCostCenter.Left = uctxtQty.Left;
                //        pnlBillWise.Size = new Size(711, 301);
                //        btnApply.Top = DgCostCenter.Height + 70;
                //        btnCancel.Top = DgCostCenter.Height + 70;
                //        uctxtAmount.Text =  (Utility.Val(lblTotalAmount.Text)).ToString();
                //        txtpreAmount.Text = lblTotalAmount.Text;
                //        txtLedgerName.Text = strLegderName;
                //    }
                //}

                if (pnlBillWise.Visible == false && pnlCostCenter.Visible == false)
                {
                    uctxtNarration.Focus();
                }
        }
     
        private void btnApply_Click(object sender, EventArgs e)
        {

            pnlCostCenter.Visible = false;

            if (pnlBillWise.Visible == false && pnlCostCenter.Visible == false)
            {
                uctxtNarration.Focus();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            pnlCostCenter.Visible = false;
            uctxtNarration.Focus();
        }
        private void btnBillapply_Click(object sender, EventArgs e)
        {
            //int selraw;
            string strLegderName = "";
            if (Utility.gbcheckCostCenter(strComID, uctxtPartyName.Text) == true)
            {
                pnlBillWise.Visible = false;
                uctxtCostCategory.Focus();
                pnlCostCenter.Visible = true;
                uctxtCostCategory.Focus();
                pnlCostCenter.Top = uctxtQty.Top + 60;
                pnlCostCenter.Left = uctxtQty.Left;
                pnlCostCenter.Size = new Size(695, 269);

                pnlCostCenter.Top = uctxtBranchName.Top + 10;
                pnlCostCenter.Left = uctxtQty.Left;
                pnlCostCenter.Size = new Size(711, 301);

                DgCostCenter.Size = new Size(687, 173);
                btnApply.Top = DgCostCenter.Height + 70;
                btnCancel.Top = DgCostCenter.Height + 70;
                uctxtAmount.Text = (Utility.Val(lblTotalAmount.Text)).ToString();
                txtpreAmount.Text = lblTotalAmount.Text;
                txtLedgerName.Text = strLegderName;
            }
            else
            {
                pnlBillWise.Visible = false;
                uctxtNarration.Focus();
            }

        }
        private void btnBillCancel_Click(object sender, EventArgs e)
        {
            pnlBillWise.Visible = false;
            uctxtNarration.Focus();
        }

        private void uctxtNarration_GotFocus(object sender, System.EventArgs e)
        {

           
            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstRefType.Visible = false;
            lstItemName.Visible = false;
            lstBatch.Visible = false;
            ucdgList.Visible = false;

        }
        private void uctxtNarration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
               
                btnSave.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtNarration, uctxtRate);
            }
        }
        private void uctxtBonusQty_GotFocus(object sender, System.EventArgs e)
        {

            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstRefType.Visible = false;
            lstItemName.Visible = false;
            lstBatch.Visible = false;
            ucdgList.Visible = false;
        }
        private void uctxtDisc_GotFocus(object sender, System.EventArgs e)
        {

            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstRefType.Visible = false;
            lstItemName.Visible = false;
            lstBatch.Visible = false;
            ucdgList.Visible = false;
        }

        private void uctxtRate_GotFocus(object sender, System.EventArgs e)
        {

            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstRefType.Visible = false;
            lstItemName.Visible = false;
            lstBatch.Visible = false;
            ucdgList.Visible = false;
        }
        private void uctxtQty_GotFocus(object sender, System.EventArgs e)
        {

            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstRefType.Visible = false;
            lstItemName.Visible = false;
            lstBatch.Visible = false;
            ucdgList.Visible = false;
        }
        private void dteDuedate_GotFocus(object sender, System.EventArgs e)
        {

            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstRefType.Visible = false;
            lstItemName.Visible = false;
            lstBatch.Visible = false;
            ucdgList.Visible = false;
        }
        private void dteDate_GotFocus(object sender, System.EventArgs e)
        {

            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstRefType.Visible = false;
            lstItemName.Visible = false;
            lstBatch.Visible = false;
            ucdgList.Visible = false;
        }

        private void uctxtRefNo_GotFocus(object sender, System.EventArgs e)
        {

            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstRefType.Visible = false;
            lstItemName.Visible = false;
            lstBatch.Visible = false;
            ucdgList.Visible = false;
        }
        private void uctxtBatch_TextChanged(object sender, EventArgs e)
        {
            lstBatch.SelectedIndex = lstBatch.FindString(uctxtBatch.Text);
        }

        private void lstBatch_DoubleClick(object sender, EventArgs e)
        {
            uctxtBatch.Text = lstBatch.Text;
            uctxtBonusQty.Focus();
        }

        private void uctxtBatch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBatch.Items.Count > 0)
                {
                    uctxtBatch.Text = lstBatch.Text;
                }
                uctxtBonusQty.Focus();

            }
        }
        private void uctxtBatch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstBatch.SelectedItem != null)
                {
                    lstBatch.SelectedIndex = lstBatch.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstBatch.Items.Count - 1 > lstBatch.SelectedIndex)
                {
                    lstBatch.SelectedIndex = lstBatch.SelectedIndex + 1;
                }
            }

        }

        private void uctxtBatch_GotFocus(object sender, System.EventArgs e)
        {

            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstRefType.Visible = false;
            lstItemName.Visible = false;
            lstBatch.Visible = true;
            ucdgList.Visible = false;
            lstBatch.ValueMember = "Key";
            lstBatch.DisplayMember = "Value";
            lstBatch.DataSource = invms.mFillBatch(strComID).ToList();

            lstBatch.SelectedIndex = lstBatch.FindString(uctxtBatch.Text);
        }

        private void uctxtItemName_TextChanged(object sender, EventArgs e)
        {
            lstItemName.SelectedIndex = lstItemName.FindString(uctxtItemName.Text);
        }

        private void lstItemName_DoubleClick(object sender, EventArgs e)
        {
            uctxtItemName.Text = lstItemName.Text;
            uctxtQty.Focus();
        }

        private void uctxtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtItemName.Text == "")
                {
                    uctxtItemName.Text = "";
                    ucdgList.Visible = false;
                    //uctxtNarration.Focus();

                    uctxtAddleddLedger.Focus();
                    pnlAddLess.Visible = true;
                    pnlAddLess.Location = new Point(311, 201);
                    pnlAddLess.Size = new Size(509, 248);
                    uctxtAddleddLedger.Focus();

                    return;
                }


                if (uctxtItemName.Text != "")
                {
                    ucdgList.Focus();
                    if (ucdgList.Rows.Count > 0)
                    {
                        int i = 0;

                        uctxtItemName.Text = ucdgList.Rows[i].Cells[0].Value.ToString();
                        ucdgList.Visible = false;
                        uctxtQty.Focus();
                    }
                    else
                    {
                        uctxtQty.Focus();
                    }

                }
                else
                {
                    int i = 0;

                    uctxtItemName.Text = ucdgList.Rows[i].Cells[0].Value.ToString();
                    ucdgList.Visible = false;
                    uctxtQty.Focus();
                }
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtItemName, uctxtLocation);
            }

        }

        private void mLoadAllItem()
        {
            int introw = 0;
            //var data = bbSc.GetBBTestFeeMaps(feecat).ToList();
            //oogrp = invms.gFillStockItemAll(strComID, "").ToList();
            oogrp = invms.mloadAddStockItemRMPack(strComID, uctxtLocation.Text,uctxtLedgerName.Text,"N").ToList();
            //var bil = (from tsfee in oogrp
            //           select new
            //           {
            //               tsfee.strItemName,
            //               tsfee.dblClsBalance
            //           }).ToList();



            ////ucdgList.value
            //ucdgList.DataSource = bil;
            //ucdgList.Columns[1].Name = "Stock Item";
            //ucdgList.Columns[2].Name = "Cls. Qty";

            if (oogrp.Count > 0)
            {

                foreach (StockItem ogrp in oogrp)
                {
                    ucdgList.Rows.Add();
                    ucdgList[0, introw].Value = ogrp.strItemName;
                    //DG[1, introw].Value = ogrp.strItemcode;
                    //DG[2, introw].Value = ogrp.strUnit;
                    ucdgList[1, introw].Value = ogrp.dblClsBalance  + ogrp.strUnit ;

                    //if (introw % 2 == 0)
                    //{
                    //    ucdgList.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    ucdgList.Rows[introw].DefaultCellStyle.BackColor = Color.White;
                    //}
                    introw += 1;
                }
                ucdgList.AllowUserToAddRows = false;
            }


        }
        private void ucdgList_DoubleClick(object sender, EventArgs e)
        {
            //DateTime firstDay = Convert.ToDateTime(DateTime.Parse(month + ", 1 " + year, CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"));
            //DateTime lastDay = Convert.ToDateTime(firstDay.AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy"));
            //int LastDay = lastDay.Day;


            if (ucdgList.SelectedRows.Count > 0)
            {
                uctxtItemName.Text = Utility.GetDgValue(ucdgList, uctxtItemName, 0);
                ucdgList.Visible = false;
                uctxtQty.Focus();


            }
        }
        private void ucdgList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtItemName.Text = Utility.GetDgValue(ucdgList, uctxtItemName, 0);
                ucdgList.Visible = false;
                uctxtQty.Focus();
            }
        }
        private void DisplayToQty(List<StockItem> tests, object sender, EventArgs e)
        {
            try
            {

                uctxtItemName.Text = tests[0].strItemName;
               

            }
            catch (Exception ex)
            {

            }
        }
        private void uctxtItemName_KeyDown(object sender, KeyEventArgs e)
        {
           
            ucdgList.Visible = true;
            if (e.KeyCode == Keys.Up)
            {
                ucdgList.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                ucdgList.Focus();
            }

            ucdgList.Top = uctxtItemName.Top + 25;
            ucdgList.Left = uctxtItemName.Left;
            ucdgList.Width = uctxtItemName.Width;
            ucdgList.Height = 180;
            ucdgList.BringToFront();
            ucdgList.DefaultCellStyle.SelectionBackColor = Color.Black;
            ucdgList.DefaultCellStyle.SelectionForeColor = Color.Yellow;
            ucdgList.AllowUserToAddRows = false;
            return;

        }

        private void uctxtItemName_GotFocus(object sender, System.EventArgs e)
        {

            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstRefType.Visible = false;
            lstItemName.Visible = false;
            lstBatch.Visible = false;

            mLoadAllItem();
            lstItemName.SelectedIndex = lstItemName.FindString(uctxtItemName.Text);
        }

        private void uctxtBonusQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            string strItemDescription = "", strUOM = "";
            double dblDis = 0;
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtItemName.Text != "")
                {
                    if (uctxtItemName.Text != "")
                    {
                        strUOM = Utility.gGetBaseUOM(strComID, uctxtItemName.Text);
                        strItemDescription = Utility.mGetItemDescription(strComID, uctxtItemName.Text);
                        mAddStockItem(uctxtItemName.Text, strItemDescription, Utility.Val(uctxtQty.Text), Utility.Val(uctxtRate.Text), strUOM, uctxtDisc.Text, 
                                        uctxtBatch.Text, Utility.Val(uctxtBonusQty.Text));
                        uctxtItemName.Focus();
                    }
                }

            }
        }

        private void mAddStockItem(string strItemName, string strDecription, double dblQty, double dblRate,string strUom,string  strDis,string strBatch,double dblBonus)
        {
            int selRaw;

            string strDown = "";
            double  dblDis=0;
            Boolean blngCheck = false;
            for (int j = 0; j < DGSalesGrid.RowCount; j++)
            {
                if (DGSalesGrid[1, j].Value != null)
                {
                    strDown = DGSalesGrid[1, j].Value.ToString();
                }
                if (strItemName == strDown.ToString())
                {
                    blngCheck = true;
                }

            }
            try
            {
                if (blngCheck == false)
                {

                    DGSalesGrid.AllowUserToAddRows = true;
                    selRaw = Convert.ToInt16(DGSalesGrid.RowCount.ToString());
                    selRaw = selRaw - 1;
                    DGSalesGrid.Rows.Add();
                    if (strDis != "")
                    {
                        if (Utility.Right(strDis, 1) == "%")
                        {
                            dblDis = ((dblQty * dblRate) * Utility.Val(strDis)) / 100;
                        }
                        else
                        {
                            dblDis = Utility.Val(strDis);
                        }
                    }
                    else
                    {
                        dblDis = 0;
                    }
                    //DgCostCenter[0, selRaw].Value = strBranchName.ToString();
                    DGSalesGrid[1, selRaw].Value = strItemName.ToString();
                    DGSalesGrid[2, selRaw].Value = strDecription.ToString();
                    DGSalesGrid[3, selRaw].Value = dblQty.ToString();
                    DGSalesGrid[4, selRaw].Value = dblRate.ToString();
                    DGSalesGrid[5, selRaw].Value = strUom;
                    DGSalesGrid[6, selRaw].Value = (dblQty * dblRate);
                    DGSalesGrid[7, selRaw].Value = dblDis;
                    DGSalesGrid[8, selRaw].Value = (dblQty * dblRate) - dblDis;
                    DGSalesGrid[9, selRaw].Value = strBatch;
                    DGSalesGrid[10, selRaw].Value = dblBonus;
                    DGSalesGrid[11, selRaw].Value = "Delete";
                    uctxtItemName.Text = "";
                    uctxtQty.Text = "";
                    uctxtRate.Text = "";
                    uctxtDisc.Text = "";
                    uctxtBatch.Text = "";
                    uctxtBonusQty.Text = "";

                    DGSalesGrid.AllowUserToAddRows = false;
                    calculateTotal();
                    DGSalesGrid.ClearSelection();
                    int nColumnIndex = 2;
                    int nRowIndex = DGSalesGrid.Rows.Count - 1;
                    DGSalesGrid.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;
                    DGSalesGrid.FirstDisplayedScrollingRowIndex = nRowIndex;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }


        private void uctxtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            string strUOM = "", strItemDescription = "";
            if (e.KeyChar == (char)Keys.Return)
            {
                if (Utility.Val(uctxtRate.Text) > 0)
                {
                    if (uctxtItemName.Text != "")
                    {
                        if (uctxtItemName.Text != "")
                        {
                            strUOM = Utility.gGetBaseUOM(strComID, uctxtItemName.Text);
                            strItemDescription = Utility.mGetItemDescription(strComID, uctxtItemName.Text);
                            mAddStockItem(uctxtItemName.Text, strItemDescription, Utility.Val(uctxtQty.Text), Utility.Val(uctxtRate.Text), strUOM, "0",
                                            "", 0);
                            uctxtItemName.Focus();
                        }
                    }
                }

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtRate, uctxtQty);
            }
        }
       
        private void uctxtDisc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtBatch.Focus();

            }
        }

        private void uctxtRefNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dteDate.Focus();

            }
        }
        private void dteDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtPartyName.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                uctxtRefNo.Focus();

            }
        }
        private void dteDuedate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtBranchName.Focus();

            }
        }
        private void uctxtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            string strUOM = "", strItemDescription = "";
            double dblrate = 0,dblBonus=0;
            if (e.KeyChar == (char)Keys.Return)
            {
                if (Utility.Val (uctxtQty.Text) == 0)
                {
                    uctxtQty.Focus();
                    return;
                }
                if (intVtype == (int)Utility.VOUCHER_TYPE.vtSALES_INVOICE)
                {
                    dblrate = Utility.gdblGetEnterpriseSalesPrice(strComID, uctxtItemName.Text, dteDate.Text, Utility.Val(uctxtQty.Text.ToString()), 0, "");
                    dblBonus = Utility.mdblGetBonus(strComID, uctxtItemName.Text, Utility.gstrGetBranchID(strComID, uctxtBranchName.Text), Utility.Val(uctxtQty.Text.ToString()), dteDate.Text);
                    uctxtRate.Text = dblrate.ToString();
                    uctxtBonusQty.Text = dblBonus.ToString();
                }
                else
                {

                    dblrate = Utility.gdblPurchasePrice(strComID, uctxtItemName.Text, dteDate.Text, uctxtLocation.Text);
                    uctxtRate.Text = dblrate.ToString();
                }
                //if (dblrate > 0)
                //{
                //    if (uctxtItemName.Text != "")
                //    {
                //        if (uctxtItemName.Text != "")
                //        {
                //            strUOM = Utility.gGetBaseUOM(strComID, uctxtItemName.Text);
                //            strItemDescription = Utility.mGetItemDescription(strComID, uctxtItemName.Text);
                //            mAddStockItem(uctxtItemName.Text, strItemDescription, Utility.Val(uctxtQty.Text), Utility.Val(uctxtRate.Text), strUOM, "0",
                //                            "", 0);
                //            uctxtItemName.Focus();
                //        }
                //    }
                //}
                //else
                //{
                uctxtRate.Focus();
                //}
                

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtQty, uctxtItemName);
            }

        }


        private void uctxtRefType_TextChanged(object sender, EventArgs e)
        {
            lstRefType.SelectedIndex = lstRefType.FindString(uctxtRefType.Text);
        }

        private void lstRefType_DoubleClick(object sender, EventArgs e)
        {
            uctxtRefType.Text = lstRefType.Text;
            if (uctxtRefType.Text != Utility.gcEND_OF_LIST)
            {
                txtRefTypeNew.Focus();
            }
            else
            {
                uctxtItemName.Focus();
            }
        }

        private void uctxtRefType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
               
                    if (lstRefType.Items.Count > 0)
                    {
                        uctxtRefType.Text = lstRefType.Text;
                    }
                    if (uctxtRefType.Text != Utility.gcEND_OF_LIST)
                    {
                        txtRefTypeNew.Focus();
                    }
                    else
                    {
                        uctxtItemName.Focus();
                    }
                   
                

            }
        }

        private void DisplayReferance(List<AccBillwise> tests, object sender, EventArgs e)
        {
            try
            {

                //uctxtItemName.Text = tests[0].strItemName;
                int selRaw;
                // string strSalesOrder = "";

                string strDown = "";
                Boolean blngCheck = false;
                for (int j = 0; j < DGSalesOrder.RowCount; j++)
                {
                    if (DGSalesOrder[0, j].Value != null)
                    {
                        strDown = DGSalesOrder[0, j].Value.ToString();
                    }
                    if (tests[0].strRefNo.ToString() == strDown.ToString())
                    {
                        blngCheck = true;
                    }

                }
                if (blngCheck == false)
                {

                    DGSalesOrder.AllowUserToAddRows = true;
                    selRaw = Convert.ToInt16(DGSalesOrder.RowCount.ToString());
                    selRaw = selRaw - 1;
                    DGSalesOrder.Rows.Add();
                    DGSalesOrder[0, selRaw].Value = tests[0].strBillKey.ToString();
                    DGSalesOrder[1, selRaw].Value = tests[0].strRefNo.ToString();
                    DGSalesOrder[2, selRaw].Value = tests[0].strDate.ToString();
                    DGSalesOrder.AllowUserToAddRows = false;
                    txtRefTypeNew.Text = "";
                    calculateTotal();
                }

            }
            catch (Exception ex)
            {

            }
        }


        private void uctxtRefType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstRefType.SelectedItem != null)
                {
                    lstRefType.SelectedIndex = lstRefType.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstRefType.Items.Count - 1 > lstRefType.SelectedIndex)
                {
                    lstRefType.SelectedIndex = lstRefType.SelectedIndex + 1;
                }
            }

        }

        private void uctxtRefType_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstRefType.Visible = true;
            lstItemName.Visible = false;
            lstBatch.Visible = false;
            lstRefType.SelectedIndex = lstRefType.FindString(uctxtRefType.Text);
        }

        private void uctxtSalesRep_TextChanged(object sender, EventArgs e)
        {
            lstSalesRepresentive.SelectedIndex = lstSalesRepresentive.FindString(uctxtSalesRep.Text);
        }

        private void lstSalesRepresentive_DoubleClick(object sender, EventArgs e)
        {
            uctxtSalesRep.Text = lstSalesRepresentive.Text;
            if (uctxtRefType.Enabled)
            {
                uctxtRefType.Focus();
            }
            else
            {
                uctxtItemName.Focus();
            }
        }

        private void uctxtSalesRep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtSalesRep.Text != Utility.gcEND_OF_LIST)
                {
                    if (lstSalesRepresentive.Items.Count > 0)
                    {
                        uctxtSalesRep.Text = lstSalesRepresentive.Text;
                    }
                    if (uctxtRefType.Enabled)
                    {
                        uctxtRefType.Focus();
                    }
                    else
                    {
                        uctxtItemName.Focus();
                    }
                }
                else
                {
                    uctxtItemName.Focus();
                }

            }
        }
        private void uctxtSalesRep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstSalesRepresentive.SelectedItem != null)
                {
                    lstSalesRepresentive.SelectedIndex = lstSalesRepresentive.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstSalesRepresentive.Items.Count - 1 > lstSalesRepresentive.SelectedIndex)
                {
                    lstSalesRepresentive.SelectedIndex = lstSalesRepresentive.SelectedIndex + 1;
                }
            }
            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 2))
                    {
                        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                if (System.Windows.Forms.Application.OpenForms["frmCustomer"] as frmCustomer == null)
                {
                    frmCustomer objfrm = new frmCustomer();
                    objfrm.m_acction = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                    objfrm.intvtype = (int)Utility.GR_GROUP_TYPE.grCUSTOMER;
                    objfrm.lngFormPriv = 2;
                    objfrm.mSingleEntry = 1;
                    objfrm.intModuleType = (int)Utility.MODULE_TYPE.mtSALES;
                    objfrm.strFormname = "Medical Representative";
                    objfrm.Show();
                    objfrm.MdiParent = this.MdiParent;

                }
                else
                {
                    frmCustomer objfrm = (frmCustomer)Application.OpenForms["frmCustomer"];
                    objfrm.Focus();
                    objfrm.MdiParent = this.MdiParent;
                }
           

            }
        }

        private void uctxtSalesRep_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstSalesRepresentive.Visible = true;
            lstRefType.Visible = false;
            lstItemName.Visible = false;
            lstBatch.Visible = false;


            lstSalesRepresentive.DisplayMember = "value";
            lstSalesRepresentive.ValueMember = "Key";
            lstSalesRepresentive.DataSource = new BindingSource(invms.mFillSalesRepLedger(strComID, (long)Utility.GR_GROUP_TYPE.grSALES_REP), null);
            lstSalesRepresentive.SelectedIndex = lstSalesRepresentive.FindString(uctxtSalesRep.Text);
        }


        private void uctxtLocation_TextChanged(object sender, EventArgs e)
        {
            lstLocation.SelectedIndex = lstLocation.FindString(uctxtLocation.Text);
        }

        private void lstLocation_DoubleClick(object sender, EventArgs e)
        {
            uctxtLocation.Text = lstLocation.Text;
            uctxtItemName.Focus();
        }

        private void uctxtLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstLocation.Items.Count > 0)
                {
                    uctxtLocation.Text = lstLocation.Text;
                }
                uctxtItemName.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtLocation, uctxtBranchName);
            }
        }
        private void uctxtLocation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstLocation.SelectedItem != null)
                {
                    lstLocation.SelectedIndex = lstLocation.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstLocation.Items.Count - 1 > lstLocation.SelectedIndex)
                {
                    lstLocation.SelectedIndex = lstLocation.SelectedIndex + 1;
                }
            }

        }

        private void uctxtLocation_GotFocus(object sender, System.EventArgs e)
        {
            
            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = true;
            lstSalesRepresentive.Visible = false;
            lstRefType.Visible = false;
            lstItemName.Visible = false;
            lstBatch.Visible = false;
            ucdgList.Visible = false;
            if (lstBranchName.SelectedValue.ToString() != "0")
            {
                lstLocation.ValueMember = "strLocation";
                lstLocation.DisplayMember = "strLocation";
                lstLocation.DataSource = invms.gLoadLocation(strComID, lstBranchName.SelectedValue.ToString(), Utility.gblnAccessControl, Utility.gstrUserName,0).ToList();
                lstLocation.SelectedIndex = lstLocation.FindString(uctxtLocation.Text);
            }
           
        }


        private void uctxtBranchName_TextChanged(object sender, EventArgs e)
        {
            lstBranchName.SelectedIndex = lstBranchName.FindString(uctxtBranchName.Text);
        }

        private void lstBranchName_DoubleClick(object sender, EventArgs e)
        {
            uctxtBranchName.Text = lstBranchName.Text;
            //uctxtLocation.Text = "";
            uctxtLocation.Focus();
        }

        private void uctxtBranchName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBranchName.Items.Count > 0)
                {
                    uctxtBranchName.Text = lstBranchName.Text;
                }
                //uctxtLocation.Text = "";
                uctxtLocation.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtBranchName, uctxtLedgerName);
            }
        }
        private void uctxtBranchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstBranchName.SelectedItem != null)
                {
                    lstBranchName.SelectedIndex = lstBranchName.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstBranchName.Items.Count - 1 > lstBranchName.SelectedIndex)
                {
                    lstBranchName.SelectedIndex = lstBranchName.SelectedIndex + 1;
                }
            }

        }

        private void uctxtBranchName_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = true;
            lstLocation.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstRefType.Visible = false;
            lstItemName.Visible = false;
            lstBatch.Visible = false;
            ucdgList.Visible = false;
            lstBranchName.ValueMember = "BranchID";
            lstBranchName.DisplayMember = "BranchName";
            lstBranchName.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
            lstBranchName.SelectedIndex = lstBranchName.FindString(uctxtBranchName.Text);
        }



        //private void uctxtSalesLedger_TextChanged(object sender, EventArgs e)
        //{
        //    lstSalesLedger.SelectedIndex = lstSalesLedger.FindString(uctxtSalesLedger.Text);
        //}

        //private void lstSalesLedger_DoubleClick(object sender, EventArgs e)
        //{
        //    uctxtSalesLedger.Text = lstSalesLedger.Text;
        //    dteDuedate.Focus();
        //}

        //private void uctxtSalesLedger_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Return)
        //    {
        //        if (lstSalesLedger.Items.Count > 0)
        //        {
        //            uctxtSalesLedger.Text = lstSalesLedger.Text;
        //        }
        //        dteDuedate.Focus();

        //    }
        //}
        //private void uctxtSalesLedger_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Up)
        //    {
        //        if (lstSalesLedger.SelectedItem != null)
        //        {
        //            lstSalesLedger.SelectedIndex = lstSalesLedger.SelectedIndex - 1;
        //        }
        //    }
        //    if (e.KeyCode == Keys.Down)
        //    {
        //        if (lstSalesLedger.Items.Count - 1 > lstSalesLedger.SelectedIndex)
        //        {
        //            lstSalesLedger.SelectedIndex = lstSalesLedger.SelectedIndex + 1;
        //        }
        //    }

        //}

        //private void uctxtSalesLedger_GotFocus(object sender, System.EventArgs e)
        //{
        //    lstPartyName.Visible = false;
        //    lstLedgerName.Visible = false;
        //    lstSalesLedger.Visible = true;
        //    lstBranchName.Visible = false;
        //    lstLocation.Visible = false;
        //    lstSalesRepresentive.Visible = false;
        //    lstRefType.Visible = false;
        //    lstItemName.Visible = false;
        //    lstBatch.Visible = false;

        //    if (intVtype == (long)Utility.VOUCHER_TYPE.vtSALES_INVOICE)
        //    {
        //        lstLedgerName.ValueMember = "strSalesLedger";
        //        lstLedgerName.DisplayMember = "strSalesLedger";
        //        lstLedgerName.DataSource = invms.gFillSalesLedger(intVtype).ToList();
        //    }
        //    else
        //    {
        //        lstLedgerName.ValueMember = "strSalesLedger";
        //        lstLedgerName.DisplayMember = "strSalesLedger";
        //        lstLedgerName.DataSource = invms.gFillPurchaseLedger().ToList();
        //    }

        //    lstSalesLedger.SelectedIndex = lstSalesLedger.FindString(uctxtSalesLedger.Text);
        //}


        private void uctxtLedgerName_TextChanged(object sender, EventArgs e)
        {
            lstLedgerName.SelectedIndex = lstLedgerName.FindString(uctxtLedgerName.Text);
        }

        private void lstLedgerName_DoubleClick(object sender, EventArgs e)
        {
            uctxtLedgerName.Text = lstLedgerName.Text;
            uctxtBranchName.Focus();
        }

        private void uctxtLedgerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstLedgerName.Items.Count > 0)
                {
                  

                    uctxtLedgerName.Text = lstLedgerName.Text;
                    lblPurchaseCB.Text = Utility.gstrLedgerBalance(strComID, uctxtLedgerName.Text);
                }
                uctxtBranchName.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtLedgerName, uctxtPartyName);
            }
        }
        private void uctxtLedgerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstLedgerName.SelectedItem != null)
                {
                    lstLedgerName.SelectedIndex = lstLedgerName.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstLedgerName.Items.Count - 1 > lstLedgerName.SelectedIndex)
                {
                    lstLedgerName.SelectedIndex = lstLedgerName.SelectedIndex + 1;
                }
            }

            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 96))
                    {
                        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                //if (System.Windows.Forms.Application.OpenForms["frmAccountsLedger"] as frmAccountsLedger == null)
                //{
                //    frmAccountsLedger objfrm = new frmAccountsLedger();
                //    objfrm.m_acction = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                //    objfrm.lngFormPriv = 96;
                //    objfrm.mSingleEntry = 1;
                //    objfrm.Show();
                //    objfrm.BringToFront();
                //    objfrm.MdiParent = this.MdiParent;

                //}
                //else
                //{
                //    frmAccountsLedger objfrm = (frmAccountsLedger)Application.OpenForms["frmAccountsLedger"];
                //    objfrm.lngFormPriv = 96;
                //    objfrm.Focus();
                //    objfrm.MdiParent = this.MdiParent;
                //}
          

            }

        }

        private void uctxtLedgerName_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstLedgerName.Visible = true;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstRefType.Visible = false;
            lstItemName.Visible = false;
            lstBatch.Visible = false;
            ucdgList.Visible = false;
            if (intVtype == (long)Utility.VOUCHER_TYPE.vtSALES_INVOICE)
            {
                lstLedgerName.ValueMember = "strSalesLedger";
                lstLedgerName.DisplayMember = "strSalesLedger";
                lstLedgerName.DataSource = invms.gFillSalesLedger(strComID, (long)Utility.GR_GROUP_TYPE.grSALES).ToList();
            }
            else
            {
                lstLedgerName.ValueMember = "strPurchaseLedger";
                lstLedgerName.DisplayMember = "strPurchaseLedger";
                lstLedgerName.DataSource = invms.gFillPurchaseLedger(strComID).ToList();
            }


            lstLedgerName.SelectedIndex = lstLedgerName.FindString(uctxtLedgerName.Text);
        }



        private void uctxtPartyName_TextChanged(object sender, EventArgs e)
        {
            lstPartyName.SelectedIndex = lstPartyName.FindString(uctxtPartyName.Text);
        }

        private void lstPartyName_DoubleClick(object sender, EventArgs e)
        {
            uctxtPartyName.Text = lstPartyName.Text;
            lblSupplierCB.Text = Utility.gstrLedgerBalance(strComID, uctxtPartyName.Text);
            uctxtLedgerName.Focus();
        }

        private void uctxtPartyName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstPartyName.Items.Count > 0)
                {
                    uctxtPartyName.Text = lstPartyName.Text;
                    lblSupplierCB.Text = Utility.gstrLedgerBalance(strComID, uctxtPartyName.Text);
                }
                
                uctxtLedgerName.Focus();
            }

            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtPartyName, uctxtRefNo);

            }
        }
        private void uctxtPartyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstPartyName.SelectedItem != null)
                {
                    lstPartyName.SelectedIndex = lstPartyName.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstPartyName.Items.Count - 1 > lstPartyName.SelectedIndex)
                {
                    lstPartyName.SelectedIndex = lstPartyName.SelectedIndex + 1;
                }
            }
            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 42))
                    {
                        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                if (System.Windows.Forms.Application.OpenForms["frmSupplier"] as frmSupplier == null)
                {
                    frmSupplier objfrm = new frmSupplier();
                    objfrm.m_acction = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                    objfrm.intvtype = (int)Utility.GR_GROUP_TYPE.grSUPPLIER;
                    objfrm.intModuleType = (int)Utility.MODULE_TYPE.mtPURCHASE;
                    objfrm.lngFormPriv = 42;
                    objfrm.mSingleEntry = 1;
                    objfrm.strFormName = "Supplier";
                    objfrm.Show();
                    objfrm.MdiParent = this.MdiParent;

                }
                else
                {
                    frmSupplier objfrm = (frmSupplier)Application.OpenForms["frmSupplier"];
                    objfrm.lngFormPriv = 42;
                    objfrm.Focus();
                    objfrm.MdiParent = this.MdiParent;
                }

            }

        }

        private void uctxtPartyName_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = true;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstRefType.Visible = false;
            lstItemName.Visible = false;
            lstBatch.Visible = false;
            ucdgList.Visible = false;
            lstPartyName.ValueMember = "strLedgerName";
            lstPartyName.DisplayMember = "strLedgerName";
            //lstPartyName.DataSource = invms.mfillLedgerInvoice(strComID, false, lngLedgeras).ToList();
            lstPartyName.DataSource = accms.mFillLedgerList(strComID, lngLedgeras).ToList();
           
            lstPartyName.SelectedIndex = lstPartyName.FindString(uctxtPartyName.Text);
        }



        #endregion
        #region "Default Value"
        private void LoadDefaultValue()
        {

            SortedDictionary<string, int> userCacheRef = new SortedDictionary<string, int>
            {
              {"Advance", 1},
              {"Agst Ref", 2},
              {"New Ref", 2}
            };

            lstTypeofRef.DisplayMember = "Key";
            lstTypeofRef.ValueMember = "Value";
            lstTypeofRef.DataSource = new BindingSource(userCacheRef, null);


            if ((long)Utility.VOUCHER_TYPE.vtSALES_INVOICE == intVtype)
            {
                SortedDictionary<string, int> userCache = new SortedDictionary<string, int>
                {
                  {Utility.gcEND_OF_LIST, 1},
                  {gobjVoucherName.VoucherName.GetVoucherName((long)Utility.VOUCHER_TYPE.vtSALES_ORDER), 2}
                };
                lstRefType.DisplayMember = "Key";
                lstRefType.ValueMember = "Value";
                lstRefType.DataSource = new BindingSource(userCache, null);
            }
            else
            {
                SortedDictionary<string, int> userCache = new SortedDictionary<string, int>
                {
                  {Utility.gcEND_OF_LIST, 1},
                  {gobjVoucherName.VoucherName.GetVoucherName((long)Utility.VOUCHER_TYPE.vtPURCHASE_ORDER), 2},
                  //{gobjVoucherName.VoucherName.GetVoucherName((long)Utility.VOUCHER_TYPE.vtPURCHASE_RECEIVE), 3}
                };

                lstRefType.DisplayMember = "Key";
                lstRefType.ValueMember = "Value";
                lstRefType.DataSource = new BindingSource(userCache, null);
            }


        }
        #endregion
        #region "Load"
        private void frmCommonInvoice_Load(object sender, EventArgs e)
        {
            
            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstRefType.Visible = false;
            lstItemName.Visible = false;
            lstBatch.Visible = false;
            lstAddlessLedger.Visible = false;
            lstTypeofRef.Visible = false;
            lstCostCategory.Visible = false;
            lstCostCenter.Visible = false;
            DGAddLess.AllowUserToAddRows = false;
            DGSalesGrid.AllowUserToAddRows = false;
            if (intVtype ==(int)Utility.VOUCHER_TYPE.vtSALES_INVOICE)
            {
                frmLabel.Text = "Sales Invoice";
               
            }
            else if(intVtype ==(int)Utility.VOUCHER_TYPE.vtPURCHASE_INVOICE)
            {
                frmLabel.Text = "Purchase Invoice";
            }
            lstCostCategory.ValueMember = "strVectorcategory";
            lstCostCategory.DisplayMember = "strVectorcategory";
            lstCostCategory.DataSource = accms.mFillVectorCategory(strComID).ToList();
            LoadDefaultValue();
            oinv = invms.mGetInvoiceConfig(strComID).ToList();
            oinv = invms.mGetInvoiceConfigNew(strComID).ToList();

            mGetConfig();
            mClear();
           
            if (mblnNumbMethod)
            {
                uctxtRefNo.ReadOnly = true;
                dteDate.Focus();
                dteDate.Select();
            }
            else
            {
                uctxtRefNo.Focus();
                uctxtRefNo.Select();
            }
            lstRefTypeNew.Columns.Add(Utility.Create_Grid_Column("Bill Key", "Bill. Key", 350, false, DataGridViewContentAlignment.TopLeft, true));
            lstRefTypeNew.Columns.Add(Utility.Create_Grid_Column("Ref. No", "Ref. No", 120, true, DataGridViewContentAlignment.TopLeft, true));
            lstRefTypeNew.Columns.Add(Utility.Create_Grid_Column("Date", "Date", 100, true, DataGridViewContentAlignment.TopLeft, true));
        }
        #endregion
        #region "Getconfig"
        private void mGetConfig()
        {
            List<VoucherTypes> ooVtype = accms.mGetConfig(strComID, (int)intVtype).ToList();
            if (ooVtype.Count > 0)
            {
                if (ooVtype[0].intVoucherNoMethod == 0)
                {
                    mblnNumbMethod = true;
                }
                else
                {
                    mblnNumbMethod = false;
                }
                mintIsPrin = ooVtype[0].intVoucherNoMethod;
            }


        }
        #endregion
        #region "Invoicd config"
        private void mloadInvoiceconfig()
        {
           
        }
        #endregion
        #region "Validation Field"
        private bool ValidateFields()
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, m_action))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return false;
                }
            }
            if (uctxtPartyName.Text == "")
            {
                MessageBox.Show("Cannot Empty");
                uctxtPartyName.Focus();
                return false;
            }
            if (uctxtRefNo.Text == "")
            {
                MessageBox.Show("Cannot Empty");
                uctxtRefNo.Focus();
                return false;
            }
            if (uctxtLedgerName.Text == "")
            {
                MessageBox.Show("Cannot Empty");
                uctxtLedgerName.Focus();
                return false;
            }
            if (uctxtBranchName.Text == "")
            {
                MessageBox.Show("Cannot Empty");
                uctxtLedgerName.Focus();
                return false;
            }
            if (uctxtLocation.Text == "")
            {
                MessageBox.Show("Cannot Empty");
                uctxtLocation.Focus();
                return false;
            }
            if (DGSalesGrid.Rows.Count==0)
            {
                MessageBox.Show("Item Cannot be Empty");
                uctxtItemName.Focus();
                return false;
            }

            long lngDate = Convert.ToInt64(dteDate.Value.ToString("yyyyMMdd"));
            long lngFiscalYearfrom = Convert.ToInt64(Convert.ToDateTime(Utility.gdteFinancialYearFrom).ToString("yyyyMMdd"));
            long lngFiscalYearTo = Convert.ToInt64(Convert.ToDateTime(Utility.gdteFinancialYearTo).ToString("yyyyMMdd"));

            if (lngDate < lngFiscalYearfrom)
            {
                    MessageBox.Show  ("Invalid Date, Date Can't less then Financial Year");
                    return false;
            }
            if (lngDate > lngFiscalYearTo)
            {
                MessageBox.Show("Invalid Date, Date Can't less then Financial Year");
                return false;
            }

            string strBacklockDate = Utility.gCheckBackLock(strComID);
            if (strBacklockDate != "")
            {
                long lngBackdate = Convert.ToInt64(Convert.ToDateTime(strBacklockDate).ToString("yyyyMMdd"));
                if (lngDate <= lngBackdate)
                 {
                     MessageBox.Show("Invalid Date, Back Date is locked");
                     return false;
                 }
            }
            //strBranchId = Utility.gstrGetBranchID(uctxtBranchName.Text.Replace("'", "''"));
            if (intVtype == (int)Utility.VOUCHER_TYPE.vtSALES_INVOICE)
            {
                double dblCreditLimit=0 ;//= Utility.gdblCreditLimit(strComID, uctxtPartyName.Text);
                double dblBalance = 0;
                string strBalance = "";
                if (dblCreditLimit != 0)
                {
                    strBalance = Utility.gstrLedgerBalance(strComID, uctxtPartyName.Text);
                    dblCreditLimit = Utility.Val(strBalance);
                    if (Utility.Right(strBalance, 2) == "Dr")
                    {
                        if (m_action == (int)Utility.ACTION_MODE_ENUM.ADD_MODE)
                        {
                            if ((dblCreditLimit - dblBalance) < Utility.Val(lblNetAmount.Text))
                            {
                                var strResponseInsert = MessageBox.Show("You have crossed your Credit Limit (" + dblCreditLimit.ToString() + ")", "accept ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (strResponseInsert == DialogResult.Yes)
                                {
                                    return false;
                                }
                            }
                        }
                        else if (m_action == (int)Utility.ACTION_MODE_ENUM.EDIT_MODE)
                        {
                            if ((dblCreditLimit - (dblBalance - mdblNetAmount)) < Utility.Val(lblNetAmount.Text))
                            {
                                var strResponseInsert = MessageBox.Show("You have crossed your Credit Limit (" + dblCreditLimit.ToString() + ")", "accept ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (strResponseInsert == DialogResult.Yes)
                                {
                                    return false;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (dblCreditLimit < Utility.Val(lblNetAmount.Text))
                        {
                            var strResponseInsert = MessageBox.Show("You have crossed your Credit Limit (" + dblCreditLimit.ToString() + ")", "accept ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (strResponseInsert == DialogResult.Yes)
                            {
                                return false;
                            }
                        }
                    }
                }
                double dblClosingQTY = 0, dblCurrentQTY = 0;
                string strBillKey = "", strNegetiveItem = "";
                int intCheckNegetive = 0;
                if (oinv[0].mlngBlockNegativeStock > 0)
                {
                    for (int i = 0; i < DGSalesGrid.Rows.Count; i++)
                    {
                        if (DGSalesGrid[0, i].Value.ToString() != "")
                        {
                            strBillKey = DGSalesGrid[0, i].ToString();
                            dblClosingQTY = Utility.gdblClosingStock(DGSalesGrid[0, i].Value.ToString(), uctxtLocation.Text, dteDate.Text);
                            if (m_action == (int)Utility.ACTION_MODE_ENUM.EDIT_MODE)
                            {
                                dblClosingQTY = dblClosingQTY + Utility.gdblGetBillQty(strComID, strBillKey);
                            }
                            dblCurrentQTY = Utility.Val(DGSalesGrid[2, i].ToString());
                            if ((dblClosingQTY) - dblCurrentQTY < 0)
                            {
                                strNegetiveItem = strNegetiveItem + Environment.NewLine + DGSalesGrid[2, i].ToString();
                                intCheckNegetive = 1;
                                dblClosingQTY = 0;
                            }
                        }
                        dblClosingQTY = 0;
                    }
                }
                if (intCheckNegetive > 0)
                {
                    MessageBox.Show("You have no valid quantity for Item: " + strNegetiveItem);
                    DGSalesGrid.Focus();
                    return false;
                }

                //if (Utility.mblnBillWise(uctxtPartyName.Text) == true)
                //{
                //    if (dgBillBranch.Rows.Count==0)
                //    {
                //        MessageBox.Show()
                //    }
                //}



            }



            return true;
        }
        #endregion
        #region "Save Sales invoice"
        private string  mSaveSalesInvoice()
        {
            long lngAgstRef;
            double dblcostRate = 0;
            string strBarchID = "", strDGSales = "", strRefNo = "", strDGSalesOrder = "", strDGBillWise = "", strDgvector = "", strDGAddless="";
            for (int i = 0; i < DGSalesGrid.Rows.Count; i++)
            {
                strDGSales = strDGSales + Utility.gCheckNull(DGSalesGrid[1, i].Value.ToString()) + "," +//Item
                                                            Utility.gCheckNull(DGSalesGrid[2, i].Value.ToString()) + "," +//Des
                                                            Utility.Val(DGSalesGrid[3, i].Value.ToString()) + "," +//qty
                                                            Utility.Val(DGSalesGrid[4, i].Value.ToString()) + "," + //Rate
                                                            Utility.gCheckNull(DGSalesGrid[5, i].Value.ToString()) + "," +//Unit
                                                            Utility.Val(DGSalesGrid[6, i].Value.ToString()) + "," + //amount
                                                            Utility.Val(DGSalesGrid[7, i].Value.ToString()) + "," + //dis
                                                            Utility.Val(DGSalesGrid[8, i].Value.ToString()) + "," + //New amount
                                                            Utility.gCheckNull(DGSalesGrid[9, i].Value.ToString()) + "," + //batch
                                                            Utility.gCheckNull(DGSalesGrid[10, i].Value.ToString()) + "," + //bonus
                                                            Utility.gCheckNull(DGSalesGrid[7, i].Value.ToString()) + "," + //addless String
                                                           Utility.Val(uctxtLess.Text) + "," +
                                                            dblcostRate + "~";     
                //Utility.gCheckNull(DGSalesGrid[10, i].Value.ToString()) + "~";
            }
            for (int i = 0; i < dgBillBranch.Rows.Count; i++)
            {
                if (dgBillBranch[0, i].Value != null)
                {
                    strDGBillWise = strDGBillWise + Utility.gCheckNull(dgBillBranch[0, i].Value.ToString()) + "," +
                                                                Utility.gCheckNull(dgBillBranch[1, i].Value.ToString()) + "," +
                                                                Utility.gCheckNull(dgBillBranch[2, i].Value.ToString()) + "," +
                                                                Utility.Val(dgBillBranch[3, i].Value.ToString()) + "," +
                                                                Utility.gCheckNull(dgBillBranch[4, i].Value.ToString()) + "," +
                                                                 Utility.Val(dgBillBranch[5, i].Value.ToString()) + "~";
                }

            }

            for (int i = 0; i < DgCostCenter.Rows.Count; i++)
            {
                if (DgCostCenter[0, i].Value != null)
                {
                    strDgvector = strDgvector + Utility.gCheckNull(DgCostCenter[0, i].Value.ToString()) + "," +
                                                                Utility.gCheckNull(DgCostCenter[1, i].Value.ToString()) + "," +
                                                                Utility.Val(DgCostCenter[2, i].Value.ToString()) + "~";
                }
            }

            for (int i = 0; i < DGSalesOrder.Rows.Count; i++)
            {
                if (DGSalesOrder[0, i].Value != null)
                {
                    strDGSalesOrder = strDGSalesOrder + Utility.gCheckNull(DGSalesOrder[0, i].Value.ToString()) + "," +
                                                                Utility.gCheckNull(DGSalesOrder[1, i].Value.ToString()) + "," +
                                                                Utility.gCheckNull(DGSalesOrder[2, i].Value.ToString()) + "~";
                }
            }
            for (int i = 0; i < DGAddLess.Rows.Count; i++)
            {
                if (DGAddLess[0, i].Value != null)
                {
                    strDGAddless = strDGAddless + Utility.gCheckNull(DGAddLess[0, i].Value.ToString()) + "," +
                                                                Utility.gCheckNull(DGAddLess[1, i].Value.ToString()) + "," +
                                                                Utility.Val(dgBillBranch[2, i].Value.ToString()) + "~";

                }

            }
            lngAgstRef = gobjVoucherName.VoucherName.GetVoucherType(uctxtRefType.Text);
            strBarchID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);

            if (mblnNumbMethod == false)
            {
                strRefNo = gobjVoucherName.VoucherName.GetVoucherString(intVtype) + strBarchID + uctxtRefNo.Text;
            }
            else
            {
                strRefNo = gobjVoucherName.VoucherName.GetVoucherString(intVtype) + strBarchID + Utility.gstrLastNumber(strComID, intVtype);
            }


            string k = objWIS.mSaveSalesInvoice(strComID, strRefNo, intVtype, dteDate.Text, dteDate.Text, dteDate.Value.ToString("MMMyy"), uctxtPartyName.Text,
                                                uctxtLedgerName.Text, Utility.Val(lblNetTotal.Text),  Utility.Val(lblNetAmount.Text),
                                                Utility.Val(uctxtAdd.Text), Utility.Val(uctxtLess.Text), uctxtRefType.Text, lngAgstRef, oinv[0].mlngIsInvEffinDirSalesInv, 1,
                                                uctxtNarration.Text, strBarchID, uctxtLocation.Text, 0, uctxtSalesRep.Text, strDGSales, strDgvector, 
                                                strDGBillWise, strDGSalesOrder,strDGAddless, false, 0, "",mblnNumbMethod,"","","","",0,0);
            

            return k;
        }
        private string mUpdateSalesInvoice()
        {
            long lngAgstRef;
            double dblcostRate = 0;
            string strBarchID = "", strDGSales = "", strRefNo = "", strDGSalesOrder = "", strDGBillWise = "", strDgvector = "", strDGAddless="";
            for (int i = 0; i < DGSalesGrid.Rows.Count; i++)
            {
                dblcostRate = Utility.gdblGetCostPrice(strComID, DGSalesGrid[1, i].Value.ToString(), dteDate.Text);
                strDGSales = strDGSales + Utility.gCheckNull(DGSalesGrid[1, i].Value.ToString()) + "," +//Item
                                                            Utility.gCheckNull(DGSalesGrid[2, i].Value.ToString()) + "," +//Des
                                                            Utility.Val(DGSalesGrid[3, i].Value.ToString()) + "," +//qty
                                                            Utility.Val(DGSalesGrid[4, i].Value.ToString()) + "," + //Rate
                                                            Utility.gCheckNull(DGSalesGrid[5, i].Value.ToString()) + "," +//Unit
                                                            Utility.Val(DGSalesGrid[6, i].Value.ToString()) + "," + //amount
                                                            Utility.Val(DGSalesGrid[7, i].Value.ToString()) + "," + //dis
                                                            Utility.Val(DGSalesGrid[8, i].Value.ToString()) + "," + //New amount
                                                            Utility.gCheckNull(DGSalesGrid[9, i].Value.ToString()) + "," + //batch
                                                            Utility.gCheckNull(DGSalesGrid[10, i].Value.ToString()) + "," + //bonus
                                                            Utility.gCheckNull(DGSalesGrid[7, i].Value.ToString()) + "," + //addless String
                                                            Utility.Val(uctxtLess.Text) + ","+
                                                            dblcostRate + "~";        
                //Utility.gCheckNull(DGSalesGrid[10, i].Value.ToString()) + "~";
            }
            for (int i = 0; i < dgBillBranch.Rows.Count; i++)
            {
                if (dgBillBranch[0, i].Value != null)
                {
                    strDGBillWise = strDGBillWise + Utility.gCheckNull(dgBillBranch[0, i].Value.ToString()) + "," +
                                                                Utility.gCheckNull(dgBillBranch[1, i].Value.ToString()) + "," +
                                                                Utility.gCheckNull(dgBillBranch[2, i].Value.ToString()) + "," +
                                                                Utility.Val(dgBillBranch[3, i].Value.ToString()) + "," +
                                                                Utility.gCheckNull(dgBillBranch[4, i].Value.ToString()) + "," +
                                                                 Utility.Val(dgBillBranch[5, i].Value.ToString()) + "~";
                }

            }

            for (int i = 0; i < DgCostCenter.Rows.Count; i++)
            {
                if (DgCostCenter[0, i].Value != null)
                {
                    strDgvector = strDgvector + Utility.gCheckNull(DgCostCenter[0, i].Value.ToString()) + "," +
                                                                Utility.gCheckNull(DgCostCenter[1, i].Value.ToString()) + "," +
                                                                Utility.Val(DgCostCenter[2, i].Value.ToString()) + "~";
                }
            }

            for (int i = 0; i < DGSalesOrder.Rows.Count; i++)
            {
                if (DGSalesOrder[0, i].Value != null)
                {
                    strDGSalesOrder = strDGSalesOrder + Utility.gCheckNull(DGSalesOrder[0, i].Value.ToString()) + "," +
                                                                Utility.gCheckNull(DGSalesOrder[1, i].Value.ToString()) + "," +
                                                                Utility.gCheckNull(DGSalesOrder[2, i].Value.ToString()) + "~";
                }
            }
            for (int i = 0; i < DGAddLess.Rows.Count; i++)
            {
                if (DGAddLess[0, i].Value != null)
                {
                    strDGAddless = strDGAddless + Utility.gCheckNull(DGAddLess[0, i].Value.ToString()) + "," +
                                                                Utility.gCheckNull(DGAddLess[1, i].Value.ToString()) + "," +
                                                                Utility.Val(dgBillBranch[2, i].Value.ToString()) + "~";

                }

            }

            lngAgstRef = gobjVoucherName.VoucherName.GetVoucherType(uctxtRefType.Text);
            strBarchID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);
            strRefNo = Utility.vtSALES_INVOICE_STR + strBarchID + uctxtRefNo.Text;
            string k = objWIS.mUpdateSalesInvoice(strComID, uctxtOldRefNo.Text, strRefNo, intVtype, dteDate.Text, dteDate.Text, dteDate.Value.ToString("MMMyy"), uctxtPartyName.Text,
                                                uctxtLedgerName.Text, Utility.Val(lblNetTotal.Text),Utility.Val(lblNetAmount.Text),
                                                Utility.Val(uctxtAdd.Text), Utility.Val(uctxtLess.Text), uctxtRefType.Text, lngAgstRef, oinv[0].mlngIsInvEffinDirSalesInv, 1,
                                                uctxtNarration.Text, strBarchID, uctxtLocation.Text, 0, uctxtSalesRep.Text, strDGSales, strDgvector, strDGBillWise,
                                                strDGSalesOrder,strDGAddless, false, 0, "", "", "", "", "",0,0);


            return k;
        }
        #endregion
        #region "Save PI"
        private string mSavePurchaseInvoice()
        {
            long lngAgstRef;
            double dblcostRate = 0;
            string strBarchID = "", strDGSales = "", strDGSalesOrder = "", strDGBillWise = "", strDgvector = "",strDGAddless="",strRefNo="",strBillKey,strBillRefNo;
            for (int i = 0; i < DGSalesGrid.Rows.Count; i++)
            {
                if (DGSalesGrid[12, i].Value != null)
                {
                    strBillKey = DGSalesGrid[12, i].Value.ToString();
                }
                else
                {
                    strBillKey = "";
                }
                if (DGSalesGrid[13, i].Value != null)
                {
                    strBillRefNo = DGSalesGrid[13, i].Value.ToString();
                }
                else
                {
                    strBillRefNo = "";
                }
               
                strDGSales = strDGSales + Utility.gCheckNull(DGSalesGrid[1, i].Value.ToString()) + "|" +//Item
                                                            Utility.gCheckNull(DGSalesGrid[2, i].Value.ToString()) + "|" +//Des
                                                            Utility.Val(DGSalesGrid[3, i].Value.ToString()) + "|" +//qty
                                                            Utility.Val(DGSalesGrid[4, i].Value.ToString()) + "|" + //Rate
                                                            Utility.gCheckNull(DGSalesGrid[5, i].Value.ToString()) + "|" +//Unit
                                                            Utility.Val(DGSalesGrid[6, i].Value.ToString()) + "|" + //amount
                                                            Utility.Val(DGSalesGrid[7, i].Value.ToString()) + "|" + //dis
                                                            Utility.Val(DGSalesGrid[8, i].Value.ToString()) + "|" + //New amount
                                                            Utility.gCheckNull(DGSalesGrid[9, i].Value.ToString()) + "|" + //batch
                                                            Utility.gCheckNull(DGSalesGrid[10, i].Value.ToString()) + "|" + //bonus
                                                            Utility.gCheckNull(DGSalesGrid[7, i].Value.ToString()) + "|" + //addless String
                                                            Utility.Val(uctxtLess.Text) + "|" +
                                                            dblcostRate + "|" +
                                                            strBillKey + "|" +
                                                            strBillRefNo + "~";
                //Utility.gCheckNull(DGSalesGrid[10, i].Value.ToString()) + "~";
            }
            //for (int i = 0; i < dgBillBranch.Rows.Count; i++)
            //{
            //    if (dgBillBranch[0, i].Value != null)
            //    {
            //        strDGBillWise = strDGBillWise + Utility.gCheckNull(dgBillBranch[0, i].Value.ToString()) + "," +
            //                                                    Utility.gCheckNull(dgBillBranch[1, i].Value.ToString()) + "," +
            //                                                    Utility.gCheckNull(dgBillBranch[2, i].Value.ToString()) + "," +
            //                                                    Utility.Val(dgBillBranch[3, i].Value.ToString()) + "," +
            //                                                    Utility.gCheckNull(dgBillBranch[4, i].Value.ToString()) + "," +
            //                                                     Utility.Val(dgBillBranch[5, i].Value.ToString()) + "~";
            //    }

            //}
            for (int i = 0; i < DGAddLess.Rows.Count; i++)
            {
                if (DGAddLess[0, i].Value != null)
                {
                    strDGAddless = strDGAddless + Utility.gCheckNull(DGAddLess[0, i].Value.ToString()) + "|" +
                                                                Utility.gCheckNull(DGAddLess[1, i].Value.ToString()) + "|" +
                                                                Utility.Val(DGAddLess[2, i].Value.ToString()) + "~";
                                                              
                }

            }
            //for (int i = 0; i < DgCostCenter.Rows.Count; i++)
            //{
            //    if (DgCostCenter[0, i].Value != null)
            //    {
            //        strDgvector = strDgvector + Utility.gCheckNull(DgCostCenter[0, i].Value.ToString()) + "," +
            //                                                    Utility.gCheckNull(DgCostCenter[1, i].Value.ToString()) + "," +
            //                                                    Utility.Val(DgCostCenter[2, i].Value.ToString()) + "~";
            //    }
            //}

            //for (int i = 0; i < DGSalesOrder.Rows.Count; i++)
            //{
            //    if (DGSalesOrder[0, i].Value != null)
            //    {
            //        strDGSalesOrder = strDGSalesOrder + Utility.gCheckNull(DGSalesOrder[0, i].Value.ToString()) + "," +
            //                                                    Utility.gCheckNull(DGSalesOrder[1, i].Value.ToString()) + "," +
            //                                                    Utility.gCheckNull(DGSalesOrder[2, i].Value.ToString()) + "~";
            //    }
            //}

            lngAgstRef = gobjVoucherName.VoucherName.GetVoucherType(uctxtRefType.Text);
            strBarchID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);

            if (mblnNumbMethod == false)
            {
                strRefNo = gobjVoucherName.VoucherName.GetVoucherString(intVtype) + strBarchID + uctxtRefNo.Text;
            }
            else
            {
                strRefNo = gobjVoucherName.VoucherName.GetVoucherString(intVtype) + strBarchID + Utility.gstrLastNumber(strComID, intVtype);
            }



            string k = invms.mSavePurchaseInvoice(strComID, strRefNo, intVtype, dteDate.Text, dteDate.Text, dteDate.Value.ToString("MMMyy"), uctxtPartyName.Text,
                                                uctxtLedgerName.Text, Utility.Val(lblNetTotal.Text), Utility.Val(lblNetAmount.Text),
                                                Utility.Val(uctxtAdd.Text), Utility.Val(uctxtLess.Text), uctxtRefType.Text, lngAgstRef, oinv[0].mlngIsInvEffinDirSalesInv, 1,
                                                uctxtNarration.Text, strBarchID, uctxtLocation.Text, 0, uctxtSalesRep.Text, strDGSales,
                                                strDgvector, strDGBillWise,strDGAddless , strDGSalesOrder, false, 0, "",mblnNumbMethod);


            return k;
        }
        private string mUpdatePurchaseInvoice()
        {
            long lngAgstRef;
            double dblcostRate = 0;
            string strBarchID = "", strDGSales = "", strDGSalesOrder = "", strDGBillWise = "", strDgvector = "", strDGAddless = "", strRefNo = "", strBillKey, strBillRefNo;
            for (int i = 0; i < DGSalesGrid.Rows.Count; i++)
            {
                if (DGSalesGrid[12, i].Value != null)
                {
                    strBillKey = DGSalesGrid[12, i].Value.ToString();
                }
                else
                {
                    strBillKey = "";
                }
                if (DGSalesGrid[13, i].Value != null)
                {
                    strBillRefNo = DGSalesGrid[13, i].Value.ToString();
                }
                else
                {
                    strBillRefNo = "";
                }

                strDGSales = strDGSales + Utility.gCheckNull(DGSalesGrid[1, i].Value.ToString()) + "|" +//Item
                                                            Utility.gCheckNull(DGSalesGrid[2, i].Value.ToString()) + "|" +//Des
                                                            Utility.Val(DGSalesGrid[3, i].Value.ToString()) + "|" +//qty
                                                            Utility.Val(DGSalesGrid[4, i].Value.ToString()) + "|" + //Rate
                                                            Utility.gCheckNull(DGSalesGrid[5, i].Value.ToString()) + "|" +//Unit
                                                            Utility.Val(DGSalesGrid[6, i].Value.ToString()) + "|" + //amount
                                                            Utility.Val(DGSalesGrid[7, i].Value.ToString()) + "|" + //dis
                                                            Utility.Val(DGSalesGrid[8, i].Value.ToString()) + "|" + //New amount
                                                            Utility.gCheckNull(DGSalesGrid[9, i].Value.ToString()) + "|" + //batch
                                                            Utility.gCheckNull(DGSalesGrid[10, i].Value.ToString()) + "|" + //bonus
                                                            Utility.gCheckNull(DGSalesGrid[7, i].Value.ToString()) + "|" + //addless String
                                                            Utility.Val(uctxtLess.Text) + "|" +
                                                            dblcostRate + "|" +
                                                            strBillKey + "|" +
                                                            strBillRefNo + "~";
                //Utility.gCheckNull(DGSalesGrid[10, i].Value.ToString()) + "~";
            }
            //for (int i = 0; i < dgBillBranch.Rows.Count; i++)
            //{
            //    if (dgBillBranch[0, i].Value != null)
            //    {
            //        strDGBillWise = strDGBillWise + Utility.gCheckNull(dgBillBranch[0, i].Value.ToString()) + "," +
            //                                                    Utility.gCheckNull(dgBillBranch[1, i].Value.ToString()) + "," +
            //                                                    Utility.gCheckNull(dgBillBranch[2, i].Value.ToString()) + "," +
            //                                                    Utility.Val(dgBillBranch[3, i].Value.ToString()) + "," +
            //                                                    Utility.gCheckNull(dgBillBranch[4, i].Value.ToString()) + "," +
            //                                                     Utility.Val(dgBillBranch[5, i].Value.ToString()) + "~";
            //    }

            //}
            for (int i = 0; i < DGAddLess.Rows.Count; i++)
            {
                if (DGAddLess[0, i].Value != null)
                {
                    strDGAddless = strDGAddless + Utility.gCheckNull(DGAddLess[0, i].Value.ToString()) + "|" +
                                                                Utility.gCheckNull(DGAddLess[1, i].Value.ToString()) + "|" +
                                                                Utility.Val(DGAddLess[2, i].Value.ToString()) + "~";

                }

            }
            //for (int i = 0; i < DgCostCenter.Rows.Count; i++)
            //{
            //    if (DgCostCenter[0, i].Value != null)
            //    {
            //        strDgvector = strDgvector + Utility.gCheckNull(DgCostCenter[0, i].Value.ToString()) + "," +
            //                                                    Utility.gCheckNull(DgCostCenter[1, i].Value.ToString()) + "," +
            //                                                    Utility.Val(DgCostCenter[2, i].Value.ToString()) + "~";
            //    }
            //}

            //for (int i = 0; i < DGSalesOrder.Rows.Count; i++)
            //{
            //    if (DGSalesOrder[0, i].Value != null)
            //    {
            //        strDGSalesOrder = strDGSalesOrder + Utility.gCheckNull(DGSalesOrder[0, i].Value.ToString()) + "," +
            //                                                    Utility.gCheckNull(DGSalesOrder[1, i].Value.ToString()) + "," +
            //                                                    Utility.gCheckNull(DGSalesOrder[2, i].Value.ToString()) + "~";
            //    }
            //}

            lngAgstRef = gobjVoucherName.VoucherName.GetVoucherType(uctxtRefType.Text);
            strBarchID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);
            strRefNo = Utility.vtPURCHASE_INVOICE_STR + strBarchID + uctxtRefNo.Text;
            string k = invms.mUpdatePurchaseInvoice(strComID, uctxtOldRefNo.Text, strRefNo, intVtype, dteDate.Text, dteDate.Text, dteDate.Value.ToString("MMMyy"), uctxtPartyName.Text,
                                                uctxtLedgerName.Text, Utility.Val(lblNetTotal.Text), Utility.Val(lblNetAmount.Text),
                                                Utility.Val(uctxtAdd.Text), Utility.Val(uctxtLess.Text), uctxtRefType.Text, lngAgstRef, oinv[0].mlngIsInvEffinDirSalesInv, 1,
                                                uctxtNarration.Text, strBarchID, uctxtLocation.Text, 0, uctxtSalesRep.Text, strDGSales, strDgvector, strDGBillWise, strDGAddless, strDGSalesOrder, false, 0, "");


            return k;
        }
        #endregion
        #region "Save"
        private void btnSave_Click(object sender, EventArgs e)
        {
            string strResponse;
            if (ValidateFields() == false)
            {
                return;
            }

        
            RegistryKey rk = Registry.CurrentUser.CreateSubKey("SOFTWARE\\SmartAccounts");
            rk.SetValue("NarrationsPI", uctxtNarration.Text);
            rk.SetValue("VoucherNoPI", uctxtRefNo.Text);
            rk.Close();
            string strBranchID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);
            var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (strResponseInsert == DialogResult.Yes)
            {

                if (m_action == (int)Utility.ACTION_MODE_ENUM.ADD_MODE)
                {
                    strResponse = mSavePurchaseInvoice();
                    if (strResponse == "Inserted...")
                    {
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, dteDate.Text, strFormName, uctxtRefNo.Text,
                                                                    1, 0, (int)Utility.MODULE_TYPE.mtPURCHASE, strBranchID);
                        }
                        mClear();
                    }
                    else
                    {
                        MessageBox.Show(strResponse.ToString());
                    }
                }
                else
                {
                    strResponse = mUpdatePurchaseInvoice();
                    if (strResponse == "Updated...")
                    {
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, dteDate.Text, strFormName, uctxtRefNo.Text,
                                                                    2, 0, (int)Utility.MODULE_TYPE.mtPURCHASE, strBranchID);
                        }
                        mClear();
                        //frmAccountsVoucherList objfrm = new frmAccountsVoucherList();
                        //objfrm.mintVType = intVtype;
                        //objfrm.lngFormPriv = lngFormPriv;
                        //objfrm.strFormName = strFormName;
                        //objfrm.intModuleType = intModuleType;
                        //objfrm.strPreserveSQl = strPreserveSQl;
                        //objfrm.onAddAllButtonClicked = new frmAccountsVoucherList.AddAllClick(DisplayVoucherList);
                        //objfrm.Show();
                        //objfrm.MdiParent = MdiParent;
                      
                    }
                    else
                    {
                        MessageBox.Show(strResponse.ToString());
                    }
                }


            }
        }
        #endregion
        #region "Clear"
        private void mClear()
        {
            uctxtLedgerName.Text = "";
            uctxtPartyName.Text = "";
            //uctxtBranchName.Text = "";
            //uctxtLocation.Text = "";
            lblNetTotal.Text = "";
            lblSupplierCB.Text = "0";
            lblPurchaseCB.Text = "0";
            uctxtSalesRep.Text = "";
            DGAddLess.Rows.Clear();
            dgBillBranch.Rows.Clear();
            DGSalesGrid.Rows.Clear();
            DgCostCenter.Rows.Clear();
            uctxtNarration.Text = "";
            uctxtAdd.Text = "";
            uctxtLess.Text = "";
            lblNetAmount.Text = "";
            lblQuantityTotal.Text = "";
            lblTotalAmount.Text = "";
            uctxtOldRefNo.Text = "";
            uctxtRefType.Text = "";
            DGSalesOrder.Rows.Clear();
            txtTotalItem.Text = "Total Item :0";
            m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            if (mblnNumbMethod)
            {
                uctxtRefNo.Text = Utility.gstrLastNumber(strComID, (int)intVtype);
            }
            else
            {
                uctxtRefNo.Text = "";
                //uctxtRefNo.Text = Interaction.GetSetting(Application.ExecutablePath, "frmPIInvoice", "VoucherNoPI");
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
                uctxtRefNo.AppendText((String)rk.GetValue("VoucherNoPI", ""));
                rk.Close();
                uctxtRefNo.Text = Utility.gobjNextNumber(uctxtRefNo.Text);
                

            }
           
            uctxtRefNo.Focus();
        }
        #endregion
        #region "Click"
        private void DGSalesGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 11)
            {
                DGSalesGrid.Rows.RemoveAt(e.RowIndex);
                calculateTotal();
            }
        }
        private void btnCancelnew_Click(object sender, EventArgs e)
        {
            pnlAddLess.Visible = false;
            uctxtNarration.Focus();
        }

        private void DGAddLess_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                DGAddLess.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //mClear();
            //frmAccountsVoucherList objfrm = new frmAccountsVoucherList();
            //objfrm.mintVType = intVtype;
            //objfrm.lngFormPriv = lngFormPriv;
            //objfrm.strFormName = strFormName;
            //objfrm.strPreserveSQl = strPreserveSQl;
            //objfrm.intModuleType = intModuleType;
            //objfrm.onAddAllButtonClicked = new frmAccountsVoucherList.AddAllClick(DisplayVoucherList);
            //objfrm.Show();
            //objfrm.MdiParent = MdiParent;
            //uctxtRefNo.Focus();
        }
        #endregion
        #region"Display"
        private void DisplayVoucherList(List<AccountsVoucher> tests, object sender, EventArgs e)
        {
            try
            {
                int introw = 0;
                m_action = (int)Utility.ACTION_MODE_ENUM.EDIT_MODE;
                DGSalesGrid.Rows.Clear();
                dgBillBranch.Rows.Clear();
                DgCostCenter.Rows.Clear();
                DGAddLess.Rows.Clear();
                DGSalesOrder.Enabled = false;
                uctxtRefType.Enabled = false;
                uctxtOldRefNo.Text = tests[0].strVoucherNo;
                List<AccountsVoucher> ooaccVou = accms.DisplayCompVoucherList(strComID, tests[0].strVoucherNo, intVtype).ToList();
                if (ooaccVou.Count > 0)
                {
                    foreach (AccountsVoucher oCom in ooaccVou)
                    {
                        uctxtRefNo.Text = Utility.Mid(oCom.strVoucherNo,6,oCom.strVoucherNo.Length-6);
                        strPreserveSQl = tests[0].strPreserveSQL;
                        dteDate.Text = oCom.strTranDate;
                        uctxtPartyName.Text = oCom.strLedgerName;
                        dteDuedate.Text = oCom.strDueDate;
                        uctxtBranchName.Text = Utility.gstrGetBranchName(strComID, oCom.strBranchID);
                        uctxtSalesRep.Text = oCom.strSalesRepresentive;
                        uctxtNarration.Text = oCom.strNarration;
                        //uctxtAdd.Text = oCom.dbladdAmnt;
                        //uctxtLess.Text = oCom.dblLessAmount;
                        List<AccountsLedger> ooSSalesLedger = accms.DisplaycommonInvoiceVoucher(strComID, tests[0].strVoucherNo).ToList();
                        if (ooSSalesLedger.Count > 0)
                         {
                             uctxtLedgerName.Text = ooSSalesLedger[0].strLedgerName;
                         }


                        List<AccBillwise> ooVouList = accms.DisplayCommonInvoice(strComID, tests[0].strVoucherNo).ToList();
                        if (ooVouList.Count > 0)
                        {

                            foreach (AccBillwise oacc in ooVouList)
                            {
                                uctxtLocation.Text = oacc.strGodownsName;
                                DGSalesGrid.Rows.Add();
                                DGSalesGrid[0, introw].Value = oacc.strBillKey;
                                DGSalesGrid[1, introw].Value = oacc.strStockItemName;
                                DGSalesGrid[2, introw].Value = oacc.strDescription;
                                DGSalesGrid[3, introw].Value = oacc.dblQnty;
                                DGSalesGrid[4, introw].Value = oacc.dblRate;
                                DGSalesGrid[5, introw].Value = oacc.strPer;
                                DGSalesGrid[6, introw].Value = oacc.dblAmount;
                                DGSalesGrid[7, introw].Value = oacc.strBillAddless;
                                DGSalesGrid[8, introw].Value = oacc.dblBillNetAmount;
                                DGSalesGrid[9, introw].Value = oacc.strBatchNo;
                                DGSalesGrid[10, introw].Value = oacc.dblBonusQnty;
                                DGSalesGrid[11, introw].Value = "Delete";
                                DGSalesGrid[12, introw].Value = oacc.strAgnstVoucherRefNo;
                                DGSalesGrid[13, introw].Value = oacc.strAgnstVoucherRefNo1;
                                List<AccBillwise> ooOrder = accms.DisplaycommonInvoiceOrder(strComID, tests[0].strVoucherNo, intVtype).ToList();
                                if (ooVouList.Count > 0)
                                {
                                    foreach (AccBillwise oaccOrder in ooOrder)
                                    {
                                        DGSalesOrder.Rows.Add();
                                        DGSalesOrder[0, introw].Value = oaccOrder.strBillKey;
                                        DGSalesOrder[1, introw].Value = Utility.Mid(oaccOrder.strRefNo, 6, oaccOrder.strRefNo.Length - 6);
                                        DGSalesOrder[2, introw].Value = oaccOrder.strDate;
                                        uctxtRefType.Text = oaccOrder.strRefType;
                                        introw += 1;
                                    }
                                }
                                DGSalesOrder.AllowUserToAddRows = false;
                                introw += 1;
                            }
                            DGSalesGrid.AllowUserToAddRows = false;
                        }

                        List<AccBillwise> obill = accms.DisplaycommonInvoiceBill(strComID, tests[0].strVoucherNo).ToList();
                        {
                            if (obill.Count > 0)
                            {
                                int i = 0;
                                foreach (AccBillwise ooBill in obill)
                                {
                                    dgBillBranch.Rows.Add();
                                    dgBillBranch.Rows[i].Cells[0].Value = ooBill.strBillPrevNew;
                                    dgBillBranch.Rows[i].Cells[1].Value = ooBill.strAgnstVoucherRefNo;
                                    dgBillBranch.Rows[i].Cells[2].Value = ooBill.strDueDate;
                                    dgBillBranch.Rows[i].Cells[3].Value = Math.Abs(ooBill.dblAmount);
                                    dgBillBranch.Rows[i].Cells[4].Value = ooBill.dblComm;
                                    dgBillBranch.Rows[i].Cells[5].Value = ooBill.dblInt;

                                
                                    i += 1;
                                }
                            }
                        }
                        List<AccBillwise> obilladdless = accms.DisplaycommonInvoiceAddless(strComID, tests[0].strVoucherNo).ToList();
                        {
                            if (obilladdless.Count > 0)
                            {
                                int i = 0;
                                foreach (AccBillwise ooBill in obilladdless)
                                {
                                    DGAddLess.Rows.Add();
                                    DGAddLess.Rows[i].Cells[0].Value = ooBill.strLedgerName;
                                    DGAddLess.Rows[i].Cells[1].Value = ooBill.strAddlessSign;
                                    DGAddLess.Rows[i].Cells[2].Value = Math.Abs(ooBill.dblDebitAmount+ ooBill.dblCreditAmount);
                                    i += 1;
                                }
                            }
                        }

                        List<VectorCategory> oveg = accms.DisplayVectorList(strComID, tests[0].strVoucherNo).ToList();
                        {
                            if (oveg.Count > 0)
                            {
                                int i = 0;
                                foreach (VectorCategory vc in oveg)
                                {
                                    DgCostCenter.Rows.Add();
                                    DgCostCenter.Rows[i].Cells[0].Value = Utility.gstrGetBranchName(strComID, vc.strBranchId);
                                    DgCostCenter.Rows[i].Cells[1].Value = vc.strVectorcategory;
                                    DgCostCenter.Rows[i].Cells[2].Value = vc.strCostCenter;
                                    DgCostCenter.Rows[i].Cells[3].Value = Math.Abs(vc.dblAmount);
                                    //dblVectorAmount = dblVectorAmount + Math.Abs(vc.dblAmount);
                                    i += 1;

                                }
                                DgCostCenter.AllowUserToAddRows = false;
                                //txtTotal.Text = dblVectorAmount.ToString();
                            }
                        }

                        calculateTotal();


                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        #endregion
        #region "Keyup"
        private void uctxtItemName_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                SearchListView(oogrp, uctxtItemName.Text);

            }
            catch (Exception ex)
            {

            }
        }
        #endregion
        #region "Search"
        private void SearchListView(IEnumerable<StockItem> tests, string searchString = "")
        {
            IEnumerable<StockItem> query;
            query = tests;
            if (searchString != "")
            {
                //query = tests.Where(x => x.strItemName.ToLower().Trim().Contains(searchString.ToLower().Trim()));
                query = (from test in tests
                         where test.strItemName.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
                         select test);
            }
         
            ucdgList.Rows.Clear();
            int i = 0;
            try
            {
                foreach (StockItem tran in query)
                {
                    ucdgList.Rows.Add();
                    ucdgList[0, i].Value = tran.strItemName;
                    ucdgList[1, i].Value = tran.dblClsBalance + " " + tran.strUnit;
                    //if (i % 2 == 0)
                    //{
                    //    ucdgList.Rows[i].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    ucdgList.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    //}
                    i += 1;
                }


            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        #endregion
        #region "Keyup"
        private void txtRefTypeNew_KeyUp(object sender, KeyEventArgs e)
        {
            SearchListViewRefNo(ooRefNo, uctxtItemName.Text);
        }
        private void SearchListViewRefNo(IEnumerable<AccBillwise> tests, string searchString = "")
        {
            IEnumerable<AccBillwise> query;
            //if ((searchString.Length > 0))
            //{
            query = tests;

            //if (chkVoucheNo.Checked == true)
            //{
            if (searchString != "")
            {
                query = tests.Where(x => x.strRefNo.ToLower().Trim().Contains(searchString.ToLower().Trim()));
            }
            //}
            //else if (chkEntryby.Checked)
            //{
            //    query = (from test in tests
            //             where test.entryby.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
            //             select test);

            //}

            //else if (chkAmount.Checked)
            //{
            //    query = (from test in tests
            //             where test.dblNetDebitAmount.ToString().StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
            //             select test);
            //}
            lstRefTypeNew.Rows.Clear();
            int i = 0;
            try
            {
                foreach (AccBillwise tran in query)
                {
                    lstRefTypeNew.Rows.Add();
                    lstRefTypeNew[0, i].Value = tran.strBillKey;
                    lstRefTypeNew[1, i].Value = Utility.Mid(tran.strRefNo,6,tran.strRefNo.Length-6);
                    lstRefTypeNew[2, i].Value = tran.strDate;
                    if (i % 2 == 0)
                    {
                        lstRefTypeNew.Rows[i].DefaultCellStyle.BackColor = Color.Beige;
                    }
                    else
                    {
                        lstRefTypeNew.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    }
                    i += 1;
                }


            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        #endregion

        private void DGSalesGrid_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {

        }

       
      
      

       

       

       

       






    }
}
