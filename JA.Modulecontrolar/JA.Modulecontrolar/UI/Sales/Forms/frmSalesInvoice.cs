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
using JA.Modulecontrolar.UI.Accms.Forms;

using JA.Modulecontrolar.JACCMS;
using JA.Modulecontrolar.UI.Inventory;
using Microsoft.VisualBasic;
using JA.Modulecontrolar.UI.Accms;
using Microsoft.Win32;
using JA.Modulecontrolar.JRPT;

namespace JA.Modulecontrolar.UI.Sales.Forms
{
    public partial class frmSalesInvoice : JA.Shared.UI.frmSmartFormStandard
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        SPWOIS objWIS = new SPWOIS();
        private string strMysql { get; set; }
        private ListBox lstPartyName = new ListBox();
        private ListBox lstLedgerName = new ListBox();
        private ListBox lstSalesLedger = new ListBox();
        private ListBox lstBranchName = new ListBox();
        private ListBox lstLocation = new ListBox();
        private ListBox lstCustomer = new ListBox();
        private ListBox lstRefType = new ListBox();
        private ListBox lstBatch = new ListBox();
        private ListBox lstGroup = new ListBox();
        private ListBox lstAddlessLedger = new ListBox();
        private ListBox lstCostCategory = new ListBox();
        private ListBox lstCostCenter = new ListBox();
        private ListBox lstTypeofRef = new ListBox();
        private ListBox lstTeritorryCode = new ListBox();
        private ListBox lstTeritorryName = new ListBox();
        //private ListBox lstRefTypeNew = new ListBox();
        
        public int m_action { get; set; }
        public long lngFormPriv { get; set; }
        private string strOldBranchName { get; set; }
        public string mstrOldMedicalName { get; set; }
        List<Teritorry> oTer;
        //List<Invoice> ooinv;
        List<Invoice> ooCustomer;
        List<Invoice> ooPartyName;
        List<AccBillwise> ooRefNo;
        public int intVtype { get; set; }
        public int lngLedgeras { get; set; }
        public double mdblNetAmount { get; set; }
        private bool mblnNumbMethod { get; set; }
        private int mintIsPrin { get; set; }
        List<InvoiceConfig> oinv;
        List<StockItem> oogrp;
        private string strComID { get; set; }
        public frmSalesInvoice()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            #region "User IN"
            this.uctxtRefNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtRefNo_KeyPress);
            this.uctxtRefNo.KeyDown += new KeyEventHandler(uctxtRefNo_KeyDown);
            
            this.uctxtRefNo.GotFocus += new System.EventHandler(this.uctxtRefNo_GotFocus);

            this.uctxtOrderNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtOrderNo_KeyPress);
            this.uctxtOrderNo.GotFocus += new System.EventHandler(this.uctxtOrderNo_GotFocus);

            this.dtePreparedDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteOrderDate_KeyPress);
            this.dtePreparedDate.GotFocus += new System.EventHandler(this.dteOrderDate_GotFocus);

            this.uctxtPreParedBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtPreParedBy_KeyPress);
            this.uctxtPreParedBy.GotFocus += new System.EventHandler(this.uctxtPreParedBy_GotFocus);

            this.dteOrderDateNew.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteOrderDateNew_KeyPress);
            this.dteOrderDateNew.GotFocus += new System.EventHandler(this.dteOrderDateNew_GotFocus);

            this.dteDeliveryDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteDeliveryDate_KeyPress);
            this.dteDeliveryDate.GotFocus += new System.EventHandler(this.dteDeliveryDate_GotFocus);

           
            this.uctxtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtQty_KeyPress);
            this.uctxtQty.GotFocus += new System.EventHandler(this.uctxtQty_GotFocus);
            this.uctxtQty.TextChanged += new System.EventHandler(this.uctxtQty_TextChanged);

            this.uctxtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtRate_KeyPress);
            this.uctxtRate.GotFocus += new System.EventHandler(this.uctxtRate_GotFocus);
            this.uctxtRate.TextChanged += new System.EventHandler(this.uctxtRate_TextChanged);

            this.uctxtDisc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtDisc_KeyPress);
            this.uctxtDisc.GotFocus += new System.EventHandler(this.uctxtDisc_GotFocus);
            this.uctxtDisc.TextChanged += new System.EventHandler(this.uctxtDisc_TextChanged);
           
            this.uctxtShortQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtShortQty_KeyPress);
            this.uctxtShortQty.GotFocus += new System.EventHandler(this.uctxtShortQty_GotFocus);
            this.uctxtShortQty.TextChanged += new System.EventHandler(this.uctxtShortQty_TextChanged);

           
            this.uctxtMedicalRep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtMedicalRep_KeyPress);
            this.uctxtMedicalRep.GotFocus += new System.EventHandler(this.uctxtMedicalRep_GotFocus);

            this.uctxtLedgerName.KeyDown += new KeyEventHandler(uctxtLedgerName_KeyDown);
            this.uctxtLedgerName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtLedgerName_KeyPress);
            this.uctxtLedgerName.TextChanged += new System.EventHandler(this.uctxtLedgerName_TextChanged);
            this.lstLedgerName.DoubleClick += new System.EventHandler(this.lstLedgerName_DoubleClick);
            this.uctxtLedgerName.GotFocus += new System.EventHandler(this.uctxtLedgerName_GotFocus);

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

            this.uctxtCustomer.KeyDown += new KeyEventHandler(uctxtCustomer_KeyDown);
            this.uctxtCustomer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtCustomer_KeyPress);
            this.uctxtCustomer.TextChanged += new System.EventHandler(this.uctxtCustomer_TextChanged);
            //this.lstCustomer.DoubleClick += new System.EventHandler(this.lstCustomer_DoubleClick);
            this.uctxtCustomer.GotFocus += new System.EventHandler(this.uctxtCustomer_GotFocus);

            this.DGcustomer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(DGcustomer_KeyPress);
            this.DGcustomer.DoubleClick += new System.EventHandler(this.DGcustomer_DoubleClick);

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
            
            this.uctxtAddleddLedger.KeyDown += new KeyEventHandler(uctxtAddleddLedger_KeyDown);
            this.uctxtAddleddLedger.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtAddleddLedger_KeyPress);
            this.uctxtAddleddLedger.TextChanged += new System.EventHandler(this.uctxtAddleddLedger_TextChanged);
            this.lstAddlessLedger.DoubleClick += new System.EventHandler(this.lstAddlessLedger_DoubleClick);
            this.uctxtAddleddLedger.GotFocus += new System.EventHandler(this.uctxtAddleddLedger_GotFocus);

            this.uctxtAddlessSymbol.KeyPress += new System.Windows.Forms.KeyPressEventHandler(ucttAddlessSymbol_KeyPress);
            this.uctxtAddlessSymbol.GotFocus += new System.EventHandler(this.ucttAddlessSymbol_GotFocus);

            this.uctxtAddlessAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtAddlessAmount_KeyPress);
            this.uctxtAddlessAmount.GotFocus += new System.EventHandler(this.uctxtAddlessAmount_GotFocus);
            this.uctxtAddlessAmount.TextChanged += new System.EventHandler(this.uctxtAddlessAmount_TextChanged);


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


            this.uctxtGroupName.KeyDown += new KeyEventHandler(uctxtGroupName_KeyDown);
            this.uctxtGroupName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtGroupName_KeyPress);
            this.uctxtGroupName.TextChanged += new System.EventHandler(this.uctxtGroupName_TextChanged);
            this.lstGroup.DoubleClick += new System.EventHandler(this.lstGroup_DoubleClick);
            this.uctxtGroupName.GotFocus += new System.EventHandler(this.uctxtGroupName_GotFocus);

            this.uctxtTerritoryCode.GotFocus += new System.EventHandler(this.uctxtTerritoryCode_GotFocus);
            this.uctxtTerritoryCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtTerritoryCode_KeyPress);
            this.uctxtTerritoryCode.KeyDown += new KeyEventHandler(uctxtTerritoryCode_KeyDown);
            this.uctxtTerritoryCode.TextChanged += new System.EventHandler(this.uctxtTerritoryCode_TextChanged);
            this.DGMr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(DGMr_KeyPress);
            this.DGMr.DoubleClick += new System.EventHandler(this.DGMr_DoubleClick);

            this.uctxtTeritorryName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtTeritorryName_KeyPress);
            this.uctxtTeritorryName.GotFocus += new System.EventHandler(this.uctxtTeritorryName_GotFocus);
            this.DGMr.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGMr_CellFormatting);
            this.DGcustomer.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGcustomer_CellFormatting);
            this.ucdgList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.ucdgList_CellFormatting);
            this.lstRefTypeNew.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.lstRefTypeNew_CellFormatting);

            this.DGSalesGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGSalesGrid_CellDoubleClick);

            Utility.CreateListBox(lstPartyName, pnlMain, uctxtMedicalRep);
            Utility.CreateListBox(lstLedgerName, pnlMain, uctxtLedgerName);
            //Utility.CreateListBox(lstSalesLedger, pnlMain, uctxtSalesLedger);
            Utility.CreateListBox(lstBranchName, pnlMain, uctxtBranchName);
            Utility.CreateListBox(lstLocation, pnlMain, uctxtLocation);
            Utility.CreateListBox(lstCustomer, pnlMain, uctxtCustomer);
            Utility.CreateListBox(lstRefType, pnlMain, uctxtRefType);
            Utility.CreateListBox(lstGroup, panel2, uctxtGroupName);
            Utility.CreateListBox(lstBatch, panel2, uctxtBatch);
            Utility.CreateListBox(lstAddlessLedger, pnlAddLess, uctxtAddleddLedger);
            Utility.CreateListBox(lstTypeofRef, pnlBillWise, uctxtTypeofRef);
            Utility.CreateListBox(lstCostCategory, pnlCostCenter, uctxtCostCategory);
            Utility.CreateListBox(lstCostCenter, pnlCostCenter, uctxtCostCenter);
            //Utility.CreateListBox(lstRefTypeNew, pnlMain, txtRefTypeNew);
            
            #endregion
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

        #region "Calculatetotal
        private void calculateTotal()
        
        {
            int intloop=0;
            double dblNetAmount = 0, dblBillAmount = 0, dblDiscount = 0, dblTotalQnty = 0, dblTotalAmount = 0, dblTotalAmount1 = 0;
            double dblTotalCommissionMinus = 0, dblTotalCommissionPlus = 0,dblNetAmountNew = 0;;
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
                    DGSalesGrid.Rows[i].Cells[8].Value = Utility.Val(DGSalesGrid.Rows[i].Cells[5].Value.ToString()) * Utility.Val(DGSalesGrid.Rows[i].Cells[6].Value.ToString());
                    dblTotalQnty = dblTotalQnty + Utility.Val(DGSalesGrid.Rows[i].Cells[5].Value.ToString());
                    dblTotalAmount = dblTotalAmount + Utility.Val(DGSalesGrid.Rows[i].Cells[8].Value.ToString());
                    dblTotalAmount1 = dblTotalAmount1 + Utility.Val(DGSalesGrid.Rows[i].Cells[10].Value.ToString());
                    dblDiscount = dblDiscount + Utility.Val(DGSalesGrid.Rows[i].Cells[9].Value.ToString());
                    intloop+=1;
                }
            }


            for (int introw = 0; introw < DGAddLess.Rows.Count ; introw++)
            {
                if (DGAddLess[2, introw].Value != null )
                {
                    if (DGAddLess[0, introw].Value != "Round Off")
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

                }
            }

            //lblNetAmount.Text = (Utility.Val(lblTotalAmount.Text) + Utility.Val(uctxtAdd.Text) - Utility.Val(uctxtLess.Text)).ToString();

            uctxtAdd.Text = dblTotalCommissionPlus.ToString();
            uctxtLess.Text = dblTotalCommissionMinus.ToString();
            txtTotal.Text = dblNetAmount.ToString();
            txtBillTotal.Text = dblBillAmount.ToString();
            lblQuantityTotal.Text = dblTotalQnty.ToString();
            lblNetTotal.Text = dblTotalAmount.ToString();
            lblTotalAmount.Text = dblTotalAmount.ToString();
            uctxtcommission.Text = dblDiscount.ToString();
            txtTotalItem.Text = "Total Item :" + intloop;
            dblNetAmountNew = Utility.Val(lblTotalAmount.Text) + Utility.Val(uctxtAdd.Text) - (Utility.Val(uctxtLess.Text) + Utility.Val(uctxtcommission.Text));
            //dblNetAmountNew = Utility.Val(lblTotalAmount.Text) + Utility.Val(uctxtAdd.Text) - (Utility.Val(uctxtLess.Text) + Utility.Val(uctxtcommission.Text));
            //int selRaw = Convert.ToInt16(DgCostCenter.RowCount.ToString());
            //selRaw = selRaw - 1;
             
            if (chkRoundOff.Checked == true)
            {
                //DGAddLess.Rows.Add();
                int selraw = Convert.ToInt32 (DGAddLess.Rows.Count)-1;
                double dblFraction = 0, dblFraction1 = 0; ;
                lblNetAmount.Text = Math.Round(dblNetAmountNew, 0).ToString();
                txtRoundOff.Text = Math.Round((Math.Round(dblNetAmountNew, 0) - dblNetAmountNew), 4).ToString();
                dblFraction1 = Math.Abs((double)Math.Round((Math.Round(dblNetAmountNew, 0) - dblNetAmountNew), 4));
                int indexOfpoint = dblNetAmountNew.ToString().LastIndexOf(".");
                if (indexOfpoint >= 0)
                {
                    dblFraction = Utility.Val(dblNetAmountNew.ToString().Substring(indexOfpoint));

                }
                if (dblFraction >= .5)
                {
                    uctxtAdd.Text = Math.Abs(dblFraction1).ToString();
                    mAdditemLedgerBill("Round Off", "+", dblFraction1);
                }
                else
                {
                    uctxtLess.Text = Math.Abs(dblFraction1).ToString();
                    mAdditemLedgerBill("Round Off", "-", dblFraction1);
                }

                if (dblFraction >= .5)
                {
                    uctxtAdd.Text = (dblTotalCommissionPlus + dblFraction1).ToString();
                }
                else if (dblFraction < .5)
                {
                    uctxtLess.Text = (dblTotalCommissionMinus + dblFraction1).ToString();
                }
                else
                {
                    uctxtAdd.Text = (dblTotalCommissionPlus + dblFraction1).ToString();
                    uctxtLess.Text = (dblTotalCommissionMinus + dblFraction1).ToString();
                }
                dblNetAmountNew = Utility.Val(lblTotalAmount.Text) + Utility.Val(uctxtAdd.Text) - (Utility.Val(uctxtLess.Text) + Utility.Val(uctxtcommission.Text));
                if (uctxtLess.Text != "0")
                {
                    lblNetAmount.Text = Math.Ceiling(dblNetAmountNew).ToString();
                }
                else
                {

                } lblNetAmount.Text = dblNetAmountNew.ToString();
            }
            else
            {
                lblNetAmount.Text = dblNetAmountNew.ToString();
                //txtRoundOff.Text = Math.Round((Math.Round(dblNetAmountNew, 0) - dblNetAmountNew), 2).ToString();
            }

        }
        #endregion
        #region "PriorSetFocus"
        private void PriorSetFocusText(TextBox txtbox, object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Back)
            {
                if (txtbox.SelectionLength > 0)
                {
                    txtbox.SelectionLength = 0;

                    this.SelectNextControl((Control)sender, false, true, true, true);
                }
                else
                {
                    if ((e.KeyChar == (char)Keys.Back) & (((Control)sender).Text.Length == 0))
                    {

                        this.SelectNextControl((Control)sender, false, true, true, true);
                    }
                }
            }


        }
        #endregion
        #region "User Define event"
        private void ucdgList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ucdgList.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Yellow;
            ucdgList.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            ucdgList.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("verdana", 9);
        }
        private void lstRefTypeNew_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            lstRefTypeNew.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Yellow;
            lstRefTypeNew.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            lstRefTypeNew.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("verdana", 9);
        }
        private void DGcustomer_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DGcustomer.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Yellow;
            DGcustomer.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            DGcustomer.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("verdana", 9);
        }
        private void DGMr_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DGMr.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Yellow;
            DGMr.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            DGMr.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("verdana", 9);
        }
        private void uctxtTeritorryName_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstCustomer.Visible = false;
            lstRefType.Visible = false;
            lstGroup.Visible = false;
            lstBatch.Visible = false;
            lstAddlessLedger.Visible = false;
            lstTypeofRef.Visible = false;
            lstCostCategory.Visible = false;
            lstCostCenter.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            ucdgList.Visible = false;
            DGMr.Visible = false;
            DGcustomer.Visible = false;
            lstTeritorryName.SelectedIndex = lstTeritorryName.FindString(uctxtTeritorryName.Text);
        }
        private void lstTeritorryName_DoubleClick(object sender, EventArgs e)
        {
            uctxtMedicalRep.Focus();

        }

        private void uctxtTeritorryName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstTeritorryName.SelectedItem != null)
                {
                    lstTeritorryName.SelectedIndex = lstTeritorryName.SelectedIndex - 1;
                    
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstTeritorryName.Items.Count - 1 > lstTeritorryName.SelectedIndex)
                {
                    lstTeritorryName.SelectedIndex = lstTeritorryName.SelectedIndex + 1;
                }
            }

        }
        private void uctxtTeritorryName_TextChanged(object sender, EventArgs e)
        {
            lstTeritorryName.Visible = true;
            lstTeritorryName.SelectedIndex = lstTeritorryName.FindString(uctxtTeritorryName.Text);
        }
        private void uctxtTeritorryName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtMedicalRep.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtTeritorryName, sender, e);
            }
        }


        private void uctxtTerritoryCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == (char)Keys.Return)
            {
                try
                {
                    if (uctxtTerritoryCode.Text == "")
                    {

                        uctxtTerritoryCode.Text = "";
                        if (DGMr.Rows.Count > 0)
                        {
                            uctxtTerritoryCode.Text = DGMr.Rows[0].Cells[3].Value.ToString();
                            //uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                            uctxtMedicalRep.Text = DGMr.Rows[0].Cells[1].Value.ToString();
                            long lngdays = Utility.mGetDeliveryDays(strComID, uctxtMedicalRep.Text);
                            dteDeliveryDate.Text = dtePreparedDate.Value.AddDays(lngdays).ToString();
                            //lblCreditLimit.Text = Utility.gdblCreditLimitGrace(strComID, uctxtMedicalRep.Text, dtePreparedDate.Value.ToString("MMMyy"),dtePreparedDate.Text).ToString();
                            lblCreditLimit.Text = Utility.gdblCreditLimit(strComID, uctxtMedicalRep.Text, dtePreparedDate.Value.ToString("MMMyy")).ToString();
                            double dblCls = Utility.dblLedgerClosingBalance(strComID, Utility.gdteFinancialYearFrom.ToString(), Utility.gdteFinancialYearTo.ToString(), uctxtMedicalRep.Text, "");
                            if (dblCls < 0)
                            {
                                lblCurrentBalance.Text = Math.Abs(dblCls) + "Dr";
                            }
                            else
                            {
                                lblCurrentBalance.Text = Math.Abs(dblCls) + "Cr";
                            }
                            if (lblCreditLimit.Text != "0")
                            {
                                string strFDate = Utility.FirstDayOfMonth(dtePreparedDate.Value).ToString();
                                //double dblLedgerClosing = Utility.dblLedgerClosingBalance(strComID, strFDate, dtePreparedDate.Text, uctxtMedicalRep.Text, "");
                                lblPending.Text = Math.Round(Utility.Val(lblCreditLimit.Text) - Math.Abs(dblCls), 2).ToString();
                                DGMr.Visible = false;
                                uctxtCustomer.Focus();
                            }
                        }
                        return;
                    }


                    if (uctxtItemName.Text != "")
                    {
                        DGMr.Focus();
                        if (DGMr.Rows.Count > 0)
                        {
                            int i = 0;
                            uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[3].Value.ToString();
                            //uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                            uctxtMedicalRep.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                            long lngdays = Utility.mGetDeliveryDays(strComID, uctxtMedicalRep.Text);
                            dteDeliveryDate.Text = dtePreparedDate.Value.AddDays(lngdays).ToString();
                            //lblCreditLimit.Text = Utility.gdblCreditLimitGrace(strComID, uctxtMedicalRep.Text, dtePreparedDate.Value.ToString("MMMyy"),dtePreparedDate.Text).ToString();
                            lblCreditLimit.Text = Utility.gdblCreditLimit(strComID, uctxtMedicalRep.Text, dtePreparedDate.Value.ToString("MMMyy")).ToString();
                            double dblCls = Utility.dblLedgerClosingBalance(strComID, Utility.gdteFinancialYearFrom.ToString(), Utility.gdteFinancialYearTo.ToString(), uctxtMedicalRep.Text, "");
                            if (dblCls < 0)
                            {
                                lblCurrentBalance.Text = Math.Abs(dblCls) + "Dr";
                            }
                            else
                            {
                                lblCurrentBalance.Text = Math.Abs(dblCls) + "Cr";
                            }
                            if (lblCreditLimit.Text != "0")
                            {
                                string strFDate = Utility.FirstDayOfMonth(dtePreparedDate.Value).ToString();
                                //double dblLedgerClosing = Utility.dblLedgerClosingBalance(strComID, strFDate, dtePreparedDate.Text, uctxtMedicalRep.Text, "");
                                lblPending.Text = Math.Round(Utility.Val(lblCreditLimit.Text) - Math.Abs(dblCls), 2).ToString();
                                DGMr.Visible = false;
                                uctxtCustomer.Focus();
                            }
                            DGMr.Visible = false;
                            uctxtCustomer.Focus();
                        }
                    }
                    else
                    {
                        int i = 0;

                        uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[3].Value.ToString();
                        //uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                        uctxtMedicalRep.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                        long lngdays = Utility.mGetDeliveryDays(strComID, uctxtMedicalRep.Text);
                        dteDeliveryDate.Text = dtePreparedDate.Value.AddDays(lngdays).ToString();
                        //lblCreditLimit.Text = Utility.gdblCreditLimitGrace(strComID, uctxtMedicalRep.Text, dtePreparedDate.Value.ToString("MMMyy"),dtePreparedDate.Text).ToString();
                        lblCreditLimit.Text = Utility.gdblCreditLimit(strComID, uctxtMedicalRep.Text, dtePreparedDate.Value.ToString("MMMyy")).ToString();
                        double dblCls = Utility.dblLedgerClosingBalance(strComID, Utility.gdteFinancialYearFrom.ToString(), Utility.gdteFinancialYearTo.ToString(), uctxtMedicalRep.Text, "");
                        if (dblCls < 0)
                        {
                            lblCurrentBalance.Text = Math.Abs(dblCls) + "Dr";
                        }
                        else
                        {
                            lblCurrentBalance.Text = Math.Abs(dblCls) + "Cr";
                        }
                        if (lblCreditLimit.Text != "0")
                        {
                            string strFDate = Utility.FirstDayOfMonth(dtePreparedDate.Value).ToString();
                            //double dblLedgerClosing = Utility.dblLedgerClosingBalance(strComID, strFDate, dtePreparedDate.Text, uctxtMedicalRep.Text, "");
                            lblPending.Text = Math.Round(Utility.Val(lblCreditLimit.Text) - Math.Abs(dblCls), 2).ToString();
                            DGMr.Visible = false;
                            uctxtCustomer.Focus();
                        }
                        DGMr.Visible = false;
                        uctxtCustomer.Focus();
                    }
                }
                catch (Exception ex)
                {

                }
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtTerritoryCode, sender, e);
            }
        }
        private void uctxtTerritoryCode_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstCustomer.Visible = false;
            lstRefType.Visible = false;
            lstGroup.Visible = false;
            lstBatch.Visible = false;
            lstAddlessLedger.Visible = false;
            lstTypeofRef.Visible = false;
            lstCostCategory.Visible = false;
            lstCostCenter.Visible = false;
            ucdgList.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            DGMr.Visible = false;
            DGcustomer.Visible = false;
            mloadParty(lstBranchName.SelectedValue.ToString());
        }
        private void DGMr_DoubleClick(object sender, EventArgs e)
        {
            if (DGMr.SelectedRows.Count > 0)
            {
                int i = Convert.ToInt16(DGMr.CurrentRow.Index.ToString());
                uctxtTerritoryCode.Text  = DGMr.Rows[i].Cells[3].Value.ToString();
                //uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                uctxtMedicalRep.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                long lngdays = Utility.mGetDeliveryDays(strComID, uctxtMedicalRep.Text);
                dteDeliveryDate.Text = dtePreparedDate.Value.AddDays(lngdays).ToString();
                //lblCreditLimit.Text = Utility.gdblCreditLimitGrace(strComID, uctxtMedicalRep.Text, dtePreparedDate.Value.ToString("MMMyy"),dtePreparedDate.Text).ToString();
                lblCreditLimit.Text = Utility.gdblCreditLimit(strComID, uctxtMedicalRep.Text, dtePreparedDate.Value.ToString("MMMyy")).ToString();
                double dblCls = Utility.dblLedgerClosingBalance(strComID, Utility.gdteFinancialYearFrom.ToString(), Utility.gdteFinancialYearTo.ToString(), uctxtMedicalRep.Text, "");
                if (dblCls < 0)
                {
                    lblCurrentBalance.Text = Math.Abs(dblCls) + "Dr";
                }
                else
                {
                    lblCurrentBalance.Text = Math.Abs(dblCls) + "Cr";
                }
                if (lblCreditLimit.Text != "0")
                {
                    string strFDate = Utility.FirstDayOfMonth(dtePreparedDate.Value).ToString();
                    //double dblLedgerClosing = Utility.dblLedgerClosingBalance(strComID, strFDate, dtePreparedDate.Text, uctxtMedicalRep.Text, "");
                    lblPending.Text = Math.Round(Utility.Val(lblCreditLimit.Text) - Math.Abs(dblCls), 2).ToString();
                    DGMr.Visible = false;
                    uctxtCustomer.Focus();
                }
                DGMr.Visible = false;
                uctxtCustomer.Focus();


            }
        }
        private void DGMr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                int i = Convert.ToInt16(DGMr.CurrentRow.Index.ToString());
                uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[3].Value.ToString();
                //uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                uctxtMedicalRep.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                long lngdays = Utility.mGetDeliveryDays(strComID, uctxtMedicalRep.Text);
                dteDeliveryDate.Text = dtePreparedDate.Value.AddDays(lngdays).ToString();
                //lblCreditLimit.Text = Utility.gdblCreditLimitGrace(strComID, uctxtMedicalRep.Text, dtePreparedDate.Value.ToString("MMMyy"),dtePreparedDate.Text).ToString();
                lblCreditLimit.Text = Utility.gdblCreditLimit(strComID, uctxtMedicalRep.Text, dtePreparedDate.Value.ToString("MMMyy")).ToString();
                double dblCls = Utility.dblLedgerClosingBalance(strComID, Utility.gdteFinancialYearFrom.ToString(), Utility.gdteFinancialYearTo.ToString(), uctxtMedicalRep.Text, "");
                if (dblCls < 0)
                {
                    lblCurrentBalance.Text = Math.Abs(dblCls) + "Dr";
                }
                else
                {
                    lblCurrentBalance.Text = Math.Abs(dblCls) + "Cr";
                }
                if (lblCreditLimit.Text != "0")
                {
                    string strFDate = Utility.FirstDayOfMonth(dtePreparedDate.Value).ToString();
                    //double dblLedgerClosing = Utility.dblLedgerClosingBalance(strComID, strFDate, dtePreparedDate.Text, uctxtMedicalRep.Text, "");
                    lblPending.Text = Math.Round(Utility.Val(lblCreditLimit.Text) - Math.Abs(dblCls), 2).ToString();
                    DGMr.Visible = false;
                    uctxtCustomer.Focus();
                }
                DGMr.Visible = false;
                uctxtCustomer.Focus();
            }
        }
        private void uctxtTerritoryCode_TextChanged(object sender, EventArgs e)
        {
            if (uctxtTerritoryCode.Text == "")
            {
                uctxtTerritoryCode.Text = "";
                uctxtTeritorryName.Text = "";
                uctxtMedicalRep.Text = "";
                uctxtCustomer.Text = "";
                txtHomoeoHall.Text = "";
                txtCustomerAddress.Text = "";
                txtCustomerCode.Text = "";
            }
        }


        private void uctxtTerritoryCode_KeyDown(object sender, KeyEventArgs e)
        {
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
            DGMr.Visible = true;
            if (e.KeyCode == Keys.Up)
            {
                DGMr.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                DGMr.Focus();
            }

            DGMr.Top = uctxtTerritoryCode.Top + 25;
            DGMr.Left = uctxtTerritoryCode.Left;
            DGMr.Width = uctxtTerritoryCode.Width;
            DGMr.Height = 200;
            DGMr.BringToFront();
            DGMr.AllowUserToAddRows = false;
            return;
        }

        private void uctxtAddlessAmount_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumericNew(uctxtAddlessAmount.Text) == false)
            {
                uctxtAddlessAmount.Text = "";
            }
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


        private void uctxtShortQty_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumericNew(uctxtShortQty.Text) == false)
            {
                uctxtShortQty.Text = "";
            }
        }
        private void dteOrderDateNew_GotFocus(object sender, System.EventArgs e)
        {

            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstCustomer.Visible = false;
            lstRefType.Visible = false;
            lstGroup.Visible = false;
            lstBatch.Visible = false;
            lstAddlessLedger.Visible = false;
            lstTypeofRef.Visible = false;
            lstCostCategory.Visible = false;
            lstCostCenter.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            ucdgList.Visible = false;
            DGMr.Visible = false;
            DGcustomer.Visible = false;
        }
        private void dteOrderDateNew_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                 
                dteDeliveryDate.Focus();
            }
            
        }
        private void uctxtPreParedBy_GotFocus(object sender, System.EventArgs e)
        {

            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstCustomer.Visible = false;
            lstRefType.Visible = false;
            lstGroup.Visible = false ;
            lstBatch.Visible = false;
            lstAddlessLedger.Visible = false;
            lstTypeofRef.Visible = false;
            lstCostCategory.Visible = false;
            lstCostCenter.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            ucdgList.Visible = false;
            DGMr.Visible = false;
            DGcustomer.Visible = false;
        }
        private void uctxtPreParedBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dteOrderDateNew.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtPreParedBy, sender, e);
            }
        }
        private void uctxtOrderNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dteOrderDateNew.Focus();

            }
        }
        private void uctxtOrderNo_GotFocus(object sender, System.EventArgs e)
        {

            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstCustomer.Visible = false;
            lstRefType.Visible = false;
            lstGroup.Visible = false;
            lstBatch.Visible = false;
            lstAddlessLedger.Visible = false;
            lstTypeofRef.Visible = false;
            lstCostCategory.Visible = false;
            lstCostCenter.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            ucdgList.Visible = false;
            DGMr.Visible = false;
            DGcustomer.Visible = false;
        }
        private void uctxtGroupName_TextChanged(object sender, EventArgs e)
        {
            lstGroup.SelectedIndex = lstGroup.FindString(uctxtGroupName.Text);
        }

        private void lstGroup_DoubleClick(object sender, EventArgs e)
        {
            uctxtGroupName.Text = lstGroup.Text;
            uctxtItemName.Text = "";
            mloadItem();
            uctxtItemName.Focus();
        }

        private void uctxtGroupName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                if (lstGroup.Items.Count > 0)
                {
                    uctxtGroupName.Text = lstGroup.Text;
                }
                uctxtItemName.Text = "";
                mloadItem();
                uctxtItemName.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtGroupName, sender, e);
            }
        }
        private void uctxtGroupName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstGroup.SelectedItem != null)
                {
                    lstGroup.SelectedIndex = lstGroup.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstGroup.Items.Count - 1 > lstGroup.SelectedIndex)
                {
                    lstGroup.SelectedIndex = lstGroup.SelectedIndex + 1;
                }
            }

        }

        private void uctxtGroupName_GotFocus(object sender, System.EventArgs e)
        {

            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstCustomer.Visible = false;
            lstRefType.Visible = false;
            lstGroup.Visible = true;
            lstBatch.Visible = false;
            lstAddlessLedger.Visible = false;
            lstTypeofRef.Visible = false;
            lstCostCategory.Visible = false;
            lstCostCenter.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            ucdgList.Visible = false;
            DGMr.Visible = false;
            DGcustomer.Visible = false;
            //lstGroup.DisplayMember = "strGroupName";
            //lstGroup.ValueMember = "strGroupName";
            //lstGroup.DataSource = invms.mFillSample(strComID).ToList();
            //lstGroup.SelectedIndex = lstGroup.FindString(uctxtGroupName.Text);
        }
        private void ucdgList_DoubleClick(object sender, EventArgs e)
        {

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
        private void txtBillRefNo_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstCustomer.Visible = false;
            lstRefType.Visible = false;
            lstGroup.Visible = false;
            lstBatch.Visible = false;
            lstAddlessLedger.Visible = false;
            lstTypeofRef.Visible = false;
            lstCostCategory.Visible = false;
            lstCostCenter.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            ucdgList.Visible = false;
            DGMr.Visible = false;
            DGcustomer.Visible = false;
        }
        private void txtRefTypeNew_LostFocus(object sender, System.EventArgs e)
        {
            int i = 0;
            string strPowerClass, strPackSize, strString="";
            double dblPrice=0;
            if (m_action != (int)Utility.ACTION_MODE_ENUM.EDIT_MODE)
            {
                if (txtRefTypeNew.Text != Utility.gcEND_OF_LIST)
                {
                    long lngRefType = gobjVoucherName.VoucherName.GetVoucherType(uctxtRefType.Text);
                    string strBraID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);
                   
                    DGSalesGrid.Rows.Clear();
                    for (int introw = 0; introw < DGSalesOrder.Rows.Count; introw++)
                    {
                       
                        if (DGSalesOrder[0, introw].Value != null)
                        {
                            List<Invoice> ooinv = invms.mGetAllOrder(strComID, strBraID, lngRefType, DGSalesOrder[0, introw].Value.ToString()).ToList();
                            if (ooinv.Count > 0)
                            {
                                foreach (Invoice oinv in ooinv)
                                {
                                    DGSalesGrid.Rows.Add();
                                    strString = strString + Utility.Mid(DGSalesOrder[0, introw].Value.ToString(),6,DGSalesOrder[0, introw].Value.ToString().Length-6) + ",";
                                    strPowerClass = Utility.mGetPowerClass(strComID, uctxtItemName.Text);
                                    strPackSize = Utility.mGetPackSize(strComID, uctxtItemName.Text);
                                    uctxtCustomer.Text = Utility.gGetAppsCustomerMerze(strComID, uctxtMedicalRep.Text, DGSalesOrder[0, introw].Value.ToString());
                                    txtCustomerAddress.Text = Utility.gstrGetLedgerAddress(strComID, uctxtCustomer.Text);
                                    DGSalesGrid[0, i].Value = oinv.strGroupName;
                                    DGSalesGrid[1, i].Value = oinv.strGroupName;
                                    DGSalesGrid[2, i].Value = oinv.strItemName.ToString();
                                    DGSalesGrid[3, i].Value = strPowerClass.ToString();
                                    DGSalesGrid[4, i].Value = strPackSize.ToString();
                                    DGSalesGrid[5, i].Value = oinv.dblQty.ToString();
                                    DGSalesGrid[6, i].Value = oinv.dblRate.ToString();
                                    DGSalesGrid[7, i].Value = oinv.strUnit;;
                                    DGSalesGrid[8, i].Value = Math.Round(oinv.dblQty * dblPrice, 2);
                                    DGSalesGrid[9, i].Value = oinv.dblDiscount; ;
                                    DGSalesGrid[10, i].Value = Math.Round((oinv.dblQty * dblPrice) - oinv.dblDiscount, 2);
                                    DGSalesGrid[11, i].Value = oinv.strBatch; ;
                                    DGSalesGrid[12, i].Value = oinv.dblBonusQty; ;
                                    DGSalesGrid[13, i].Value = 0;
                                    DGSalesGrid[14, i].Value = "Delete";
                                    DGSalesGrid[15, i].Value = Utility.mGetStockGroupFromItemGroup(strComID, oinv.strGroupName);
                                    DGSalesGrid[17, i].Value = DGSalesOrder[0, introw].Value.ToString();

                                    i += 1;
                                }
                                DGSalesGrid.AllowUserToAddRows = false;
                                if (strString != "")
                                {
                                    strString = Utility.Mid(strString, 0, strString.Length - 1);
                                }
                                uctxtOrderNo.Text = Utility.Mid(DGSalesOrder[0, introw].Value.ToString(), 6, DGSalesOrder[0, introw].Value.ToString().Length - 6);
                                dteOrderDateNew.Text = DGSalesOrder[2, introw].Value.ToString();
                            }
                        }
                        calculateTotal();
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
            lstCustomer.Visible = false;
            lstRefType.Visible = false;
            lstGroup.Visible = false;
            lstBatch.Visible = false;
            lstAddlessLedger.Visible = false;
            lstCostCategory.Visible = false;
            lstCostCenter.Visible = false; ;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            ucdgList.Visible = false;
            DGMr.Visible = false;
            DGcustomer.Visible = false;
        }
        private void txtRefTypeNew_KeyDown(object sender, KeyEventArgs e)
        {
           //if (e.KeyCode==Keys.F3)
           //{
           //    lstRefType.Visible = false;
           //    long lngRefType = gobjVoucherName.VoucherName.GetVoucherType(uctxtRefType.Text);
           //    frmAllReferance objfrm = new frmAllReferance();
           //    objfrm.strPartyname = uctxtMedicalRep.Text;
           //    objfrm.strBranchID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);
           //    objfrm.strDate = dtePreparedDate.Text;
           //    objfrm.lngVtype = lngRefType;
           //    objfrm.onAddAllButtonClicked = new frmAllReferance.AddAllClick(DisplayReferance);
           //    objfrm.MdiParent = MdiParent;
           //    objfrm.ShowDialog();
           //}
            if (DGSalesOrder.Rows.Count == 0)
            {

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
            }
            return;

        }
        private void lstRefTypeNew_DoubleClick(object sender, EventArgs e)
        {
            //DateTime firstDay = Convert.ToDateTime(DateTime.Parse(month + ", 1 " + year, CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"));
            //DateTime lastDay = Convert.ToDateTime(firstDay.AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy"));
            //int LastDay = lastDay.Day;

            string strBillKey, strRefNo, strDate;
            if (lstRefTypeNew.SelectedRows.Count > 0)
            {
                int i = Convert.ToInt16(lstRefTypeNew.CurrentRow.Index.ToString());

                txtRefTypeNew.Text = Utility.GetDgValue(lstRefTypeNew, uctxtItemName, 0);

                strBillKey = lstRefTypeNew.Rows[i].Cells[0].Value.ToString();
                strRefNo = lstRefTypeNew.Rows[i].Cells[1].Value.ToString();
                strDate = lstRefTypeNew.Rows[i].Cells[2].Value.ToString();
                DisplayReferance(strBillKey, strRefNo, strDate);
                lstRefTypeNew.Visible = false;
                txtRefTypeNew.Text = "";
                txtRefTypeNew.Focus();
                lstRefTypeNew.Rows.RemoveAt(i);



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
                    txtRefTypeNew.Text = "";
                    txtRefTypeNew.Focus();
                    lstRefTypeNew.Rows.RemoveAt(i);

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
                    DGSalesOrder[3, selRaw].Value = "Delete";
                    DGSalesOrder.AllowUserToAddRows = false;
                    txtRefTypeNew.Text = "";
                    calculateTotal();
                }

            }
            catch (Exception ex)
            {

            }
        }
        private void txtRefTypeNew_KeyPress(object sender, KeyPressEventArgs e)
        {
            string strBillKey, strRefNo, strDate;
            if (e.KeyChar == (char)Keys.Return)
            {
                try
                {
                    if (DGSalesOrder.Rows.Count==1)
                    {
                        uctxtItemName.Focus();
                        return;
                    }
                   
                    if (txtRefTypeNew.Text == "")
                    {
                        //txtItemCode.Text = "";
                        txtRefTypeNew.Text = "";
                        lstRefTypeNew.Visible = false;
                        uctxtItemName.Focus();
                        return;
                    }


                    if (txtRefTypeNew.Text != "")
                    {
                        lstRefTypeNew.Focus();
                        if (lstRefTypeNew.Rows.Count > 0)
                        {
                            int i = 0;
                            foreach (DataGridViewRow row in lstRefTypeNew.SelectedRows)
                            {
                                i = Convert.ToInt16(row.Index);
                            }

                            txtRefTypeNew.Text = lstRefTypeNew.Rows[i].Cells[0].Value.ToString();
                            //i = Convert.ToInt16(lstRefTypeNew.CurrentRow.Index.ToString());
                            strBillKey = lstRefTypeNew.Rows[i].Cells[0].Value.ToString();
                            strRefNo = lstRefTypeNew.Rows[i].Cells[1].Value.ToString();
                            strDate = lstRefTypeNew.Rows[i].Cells[2].Value.ToString();
                            DisplayReferance(strBillKey, strRefNo, strDate);
                            lstRefTypeNew.Visible = false;
                            txtRefTypeNew.Focus();
                            lstRefTypeNew.Rows.RemoveAt(i);
                        }
                    }
                    else
                    {
                        int i = 0;
                        // i = Convert.ToInt16(lstRefTypeNew.CurrentRow.Index.ToString());
                        foreach (DataGridViewRow row in lstRefTypeNew.SelectedRows)
                        {
                            i = Convert.ToInt16(row.Index);
                        }

                        txtRefTypeNew.Text = lstRefTypeNew.Rows[i].Cells[0].Value.ToString();
                        //i = Convert.ToInt16(lstRefTypeNew.CurrentRow.Index.ToString());
                        strBillKey = lstRefTypeNew.Rows[i].Cells[0].Value.ToString();
                        strRefNo = lstRefTypeNew.Rows[i].Cells[1].Value.ToString();
                        strDate = lstRefTypeNew.Rows[i].Cells[2].Value.ToString();
                        DisplayReferance(strBillKey, strRefNo, strDate);
                        lstRefTypeNew.Visible = false;
                        txtRefTypeNew.Focus();
                        lstRefTypeNew.Rows.RemoveAt(i);
                    }
                }
                catch (Exception ex)
                {

                }
            }

            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(txtRefTypeNew, sender, e);
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
            lstCustomer.Visible = false;
            lstRefType.Visible = false;
            lstGroup.Visible = false;
            lstBatch.Visible = false;
            lstAddlessLedger.Visible = false;
            lstCostCategory.Visible = false;
            lstCostCenter.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            ucdgList.Visible = false;
            DGMr.Visible = false;
            DGcustomer.Visible = false;
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
            lstCustomer.Visible = false;
            lstRefType.Visible = false;
            lstGroup.Visible = false;
            lstBatch.Visible = false;
            lstAddlessLedger.Visible = false;
            lstCostCategory.Visible = false;
            lstCostCenter.Visible = true;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            ucdgList.Visible = false;
            DGMr.Visible = false;
            DGcustomer.Visible = false;
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
            lstCustomer.Visible = false;
            lstRefType.Visible = false;
            lstGroup.Visible = false;
            lstBatch.Visible = false;
            lstAddlessLedger.Visible = false;
            lstCostCategory.Visible = true;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            ucdgList.Visible = false;
            DGMr.Visible = false;
            DGcustomer.Visible = false;
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
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(txtInte, sender, e);
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
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(txtComm, sender, e);
            }
        }
        private void txtBillDrcr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtComm.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(txtBillDrcr, sender, e);
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
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(txtBillAmount, sender, e);
            }
        }
        private void txtBillRefNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dteBillDueDate.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(txtBillRefNo, sender, e);
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
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            ucdgList.Visible = false;
            DGMr.Visible = false;
            DGcustomer.Visible = false;
            lstTypeofRef.SelectedIndex = lstTypeofRef.FindString(uctxtTypeofRef.Text);
        }


        private void uctxtAddlessAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                //uctxtAddleddLedger.Focus();
                mAdditemLedgerBill(uctxtAddleddLedger.Text, uctxtAddlessSymbol.Text, Utility.Val(uctxtAddlessAmount.Text.ToString()));
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtAddlessAmount, sender, e);
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
                }

            }
            if (blngCheck == false)
            {

                DGAddLess.AllowUserToAddRows = true;
                selRaw = Convert.ToInt16(DGAddLess.RowCount.ToString());
                selRaw = selRaw - 1;
                DGAddLess.Rows.Add();
                DGAddLess[0, selRaw].Value = strLedgerName.ToString();
                if (Utility.Left(strSymbol, 1) == "-")
                {
                    DGAddLess[1, selRaw].Value = "-";
                }
                else
                {
                    DGAddLess[1, selRaw].Value = "+";
                }
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
            lstCustomer.Visible = false;
            lstRefType.Visible = false;
            lstGroup.Visible = false;
            lstBatch.Visible = false;
            lstAddlessLedger.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            ucdgList.Visible = false;
            DGMr.Visible = false;
            DGcustomer.Visible = false;
        }
        private void ucttAddlessSymbol_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstCustomer.Visible = false;
            lstRefType.Visible = false;
            lstGroup.Visible = false;
            lstBatch.Visible = false;
            lstAddlessLedger.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            ucdgList.Visible = false;
            DGMr.Visible = false;
            DGcustomer.Visible = false;
        }
        private void ucttAddlessSymbol_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtAddlessAmount.Text = uctxtAddlessSymbol.Text;
                uctxtAddlessAmount.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtAddlessSymbol, sender, e);
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
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtAddleddLedger, sender, e);
            }
        }
        private void uctxtAddleddLedger_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {
                frmAccountsLedger objfrm = new frmAccountsLedger();
                objfrm.m_acction = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.mSingleEntry = 1;
                objfrm.Show();

            }


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

        }

        private void uctxtAddleddLedger_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstCustomer.Visible = false;
            lstRefType.Visible = false;
            lstGroup.Visible = false;
            lstBatch.Visible = false;
            lstAddlessLedger.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            ucdgList.Visible = false;
            DGMr.Visible = false;
            DGcustomer.Visible = false;
            if (lstBranchName.SelectedValue.ToString() == "0002")
            {
                lstAddlessLedger.ValueMember = "strLedgerName";
                lstAddlessLedger.DisplayMember = "strLedgerName";
                lstAddlessLedger.DataSource = invms.mfillLedgerInvoice(strComID, false, 0,"Loose").ToList();
            }
            lstAddlessLedger.SelectedIndex = lstAddlessLedger.FindString(uctxtAddleddLedger.Text);
        }


        private void btnAddLessApply_Click(object sender, EventArgs e)
        {
            double dblTotalCommissionMinus = 0, dblTotalCommissionPlus = 0, dblNetAmountNew=0;
            pnlAddLess.Visible = false;
            //int selraw = 0;
            string strLegderName = "";
            int selraw = Convert.ToInt32(DGAddLess.Rows.Count);
            mCalculateDiscount();
            for (int introw = 0; introw < DGAddLess.Rows.Count; introw++)
            {
                if (DGAddLess[2, introw].Value != null )
                {
                    if (DGAddLess[0, introw].Value != "Round Off")
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
                }
            }

            uctxtAdd.Text = dblTotalCommissionPlus.ToString();
            uctxtLess.Text = dblTotalCommissionMinus.ToString();
            dblNetAmountNew = Utility.Val(lblTotalAmount.Text) + Utility.Val(uctxtAdd.Text) - (Utility.Val(uctxtLess.Text) + Utility.Val(uctxtcommission.Text));
            //int selRaw = Convert.ToInt16(DgCostCenter.RowCount.ToString());
            //selRaw = selRaw - 1;
            if (chkRoundOff.Checked == true)
            {
                double dblFraction = 0, dblFraction1=0;
                lblNetAmount.Text = Math.Round(dblNetAmountNew, 0).ToString();
                txtRoundOff.Text = Math.Round((Math.Round(dblNetAmountNew, 0) - dblNetAmountNew), 4).ToString();
                dblFraction1 = Math.Abs((double)Math.Round((Math.Round(dblNetAmountNew, 0) - dblNetAmountNew), 4));
                int indexOfpoint = dblNetAmountNew.ToString().LastIndexOf(".");
                if (indexOfpoint >= 0)
                {
                    dblFraction = Utility.Val(dblNetAmountNew.ToString().Substring(indexOfpoint));
                    
                }

                if (dblFraction >= .5)
                {
                    uctxtAdd.Text = Math.Abs(dblFraction1).ToString();
                    mAdditemLedgerBill("Round Off", "+", dblFraction1);
                }
                else
                {
                    uctxtLess.Text = Math.Abs(dblFraction1).ToString();
                    mAdditemLedgerBill("Round Off", "-", dblFraction1);
                }
                if (dblFraction >= .5)
                {
                    uctxtAdd.Text = (dblTotalCommissionPlus + dblFraction1).ToString();
                }
                else  if (dblFraction < .5)
                {
                    uctxtLess.Text = (dblTotalCommissionMinus + dblFraction1).ToString();
                }
                else
                {
                    uctxtAdd.Text = (dblTotalCommissionPlus + dblFraction1).ToString();
                    uctxtLess.Text = (dblTotalCommissionMinus + dblFraction1).ToString();
                }
               
               
                dblNetAmountNew = Utility.Val(lblTotalAmount.Text) + Utility.Val(uctxtAdd.Text) - (Utility.Val(uctxtLess.Text) + Utility.Val(uctxtcommission.Text));
                if (uctxtLess.Text != "0")
                {
                    lblNetAmount.Text = Math.Ceiling(dblNetAmountNew).ToString();
                }
                else
                {
                    lblNetAmount.Text = dblNetAmountNew.ToString();
                } 

            }
            else
            {
                lblNetAmount.Text = dblNetAmountNew.ToString();
                //txtRoundOff.Text = Math.Round((Math.Round(dblNetAmountNew, 0) - dblNetAmountNew), 2).ToString();
            }

                pnlCostCenter.Visible = false;
                //if (Utility.mblnBillWise(strComID, uctxtMedicalRep.Text) == true)
                //{
                //    pnlBillWise.Visible = true;
                //    pnlBillWise.Top = uctxtQty.Top + 60;
                //    pnlBillWise.Left = uctxtItemName.Left + 80;
                //    pnlBillWise.Size = new Size(711, 301);
                //    txtBillLedger.Text = uctxtMedicalRep.Text;
                //    txtBillRefNo.Text = uctxtRefNo.Text;

                //    txtBillDrcr.Text = "Dr";
                //    txtBillPreTotal.Text = lblTotalAmount.Text;
                //    txtBillAmount.Text = lblTotalAmount.Text;
                //    txtComm.Text = "0";
                //    txtInte.Text = "0";
                //    lblBillWise.Text = "Bill Wise Details for " + uctxtMedicalRep.Text;
                //    uctxtTypeofRef.Focus();
                //}

                //if (pnlBillWise.Visible == false)
                //{
                //    if (Utility.gbcheckCostCenter(strComID, uctxtMedicalRep.Text) == true)
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
                if (pnlBillWise.Visible == false && pnlCostCenter.Visible == true)
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
            if (Utility.gbcheckCostCenter(strComID, uctxtMedicalRep.Text) == true)
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

            ucdgList.Visible = false;
            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstCustomer.Visible = false;
            lstRefType.Visible = false;
            lstGroup.Visible = false;
            lstBatch.Visible = false;
            pnlAddLess.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            DGMr.Visible = false;
            DGcustomer.Visible = false;
            

        }
        private void mCalculateDiscount()
        {
            string strItemGroup = "", str2ndGroup = "", strGrid = "",strBranchID="";
            double dblItemAmount = 0, dblAmount = 0;
            //List<Sample> ooSample = invms.mFillSample().ToList();
            strBranchID =Utility.gstrGetBranchID(strComID,uctxtBranchName.Text);
            List<StockGroup> ooSample = invms.mFillStockGroupconfig(strComID).ToList();
            foreach (StockGroup oobj in ooSample)
            {
                strItemGroup = oobj.GroupName;

                for (int int2nd = 0; int2nd < DGSalesGrid.Rows.Count; int2nd++)
                {
                    if (DGSalesGrid[1, int2nd].Value != null)
                    {
                        str2ndGroup = DGSalesGrid[15, int2nd].Value.ToString();
                        if (strItemGroup == str2ndGroup)
                        {
                            
                            dblAmount = (Utility.Val(DGSalesGrid[5, int2nd].Value.ToString()) * Utility.Val(DGSalesGrid[6, int2nd].Value.ToString()));
                            dblItemAmount = dblItemAmount + dblAmount;
                        }
                    }
                }
                if (dblItemAmount != 0)
                {
                    strGrid += strItemGroup + "|" + dblItemAmount + "~";
                }
                dblItemAmount = 0;
            }


            //MessageBox.Show(strGrid);
            if (strGrid != "")
            {
                double dblPercent = 0,dblFixedPercent=0;
                string strFDate="", strTdate = "";
                string[] words = strGrid.Split('~');
                foreach (string ooassets in words)
                {
                    string[] oAssets = ooassets.Split('|');
                    if (oAssets[0] != "")
                    {
                        dblPercent = Utility.mdblGetCommiPercen(strComID, oAssets[0], Utility.Val(oAssets[1]), strBranchID);
                        strFDate = Utility.FirstDayOfMonth(dtePreparedDate.Value).ToString("dd/MM/yyyy");
                        strTdate = dtePreparedDate.Text;
                        if (m_action == 1)
                        {
                            dblFixedPercent = Utility.mdblGetMaxCommiPercen(strComID, txtCustomerCode.Text, oAssets[0], strFDate, strTdate, strBranchID,"");
                        }
                        else
                        {
                            dblFixedPercent = Utility.mdblGetMaxCommiPercen(strComID, txtCustomerCode.Text, oAssets[0], strFDate, strTdate, strBranchID,uctxtOldRefNo.Text);
                        }
                        if (dblFixedPercent == 40)
                        {
                            dblPercent = 40;
                        }
                     
                        for (int int2nd = 0; int2nd < DGSalesGrid.Rows.Count; int2nd++)
                        {
                            if (DGSalesGrid[15, int2nd].Value != null)
                            {
                                str2ndGroup = DGSalesGrid[15, int2nd].Value.ToString();
                                if (oAssets[0] == str2ndGroup)
                                {
                                    DGSalesGrid[9, int2nd].Value = ((Utility.Val(DGSalesGrid[5, int2nd].Value.ToString()) * Utility.Val(DGSalesGrid[6, int2nd].Value.ToString())) * dblPercent) / 100;
                                    DGSalesGrid[10, int2nd].Value = Utility.Val(DGSalesGrid[8, int2nd].Value.ToString()) - Utility.Val(DGSalesGrid[9, int2nd].Value.ToString());
                                    DGSalesGrid[16, int2nd].Value = dblPercent;
                                }
                            }
                        }
                        dblItemAmount = 0;
                    }
                }
                calculateTotal();
            }



        }
        private void uctxtNarration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
              
                btnSave.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtNarration, sender, e);
            }
        }
        private void uctxtShortQty_GotFocus(object sender, System.EventArgs e)
        {

            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstCustomer.Visible = false;
            lstRefType.Visible = false;
            lstGroup.Visible = false;
            lstBatch.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            ucdgList.Visible = false;
            DGMr.Visible = false;
            DGcustomer.Visible = false;
            lstRefTypeNew.Visible = false;
        }
        private void uctxtDisc_GotFocus(object sender, System.EventArgs e)
        {

            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstCustomer.Visible = false;
            lstRefType.Visible = false;
            lstGroup.Visible = false;
            lstBatch.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            ucdgList.Visible = false;
            DGMr.Visible = false;
            DGcustomer.Visible = false;
            lstRefTypeNew.Visible = false;
        }
        private void uctxtRate_GotFocus(object sender, System.EventArgs e)
        {

            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstCustomer.Visible = false;
            lstRefType.Visible = false;
           // lstItemName.Visible = false;
            lstBatch.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            ucdgList.Visible = false;
            DGMr.Visible = false;
            DGcustomer.Visible = false;
            lstRefTypeNew.Visible = false;
        }
        private void uctxtQty_GotFocus(object sender, System.EventArgs e)
        {

            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstCustomer.Visible = false;
            lstRefType.Visible = false;
            lstGroup.Visible = false;
            lstBatch.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            ucdgList.Visible = false;
            DGMr.Visible = false;
            DGcustomer.Visible = false;
            lstRefTypeNew.Visible = false;
        }
        private void dteDeliveryDate_GotFocus(object sender, System.EventArgs e)
        {

            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstCustomer.Visible = false;
            lstRefType.Visible = false;
            lstGroup.Visible = false;
            lstBatch.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            ucdgList.Visible = false;
            DGMr.Visible = false;
            DGcustomer.Visible = false;
            lstRefTypeNew.Visible = false;
        }
        private void dteOrderDate_GotFocus(object sender, System.EventArgs e)
        {

            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstCustomer.Visible = false;
            lstRefType.Visible = false;
            lstGroup.Visible = false;
            lstBatch.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            lstRefTypeNew.Visible = false;
            ucdgList.Visible = false;
            DGMr.Visible = false;
            DGcustomer.Visible = false;
        }

        private void uctxtRefNo_GotFocus(object sender, System.EventArgs e)
        {

            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstCustomer.Visible = false;
            lstRefType.Visible = false;
            lstGroup.Visible = false;
            lstBatch.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            lstRefTypeNew.Visible = false;
            ucdgList.Visible = false;
            DGMr.Visible = false;
            DGcustomer.Visible = false;
        }
        private void uctxtBatch_TextChanged(object sender, EventArgs e)
        {
            lstBatch.SelectedIndex = lstBatch.FindString(uctxtBatch.Text);
        }

        private void lstBatch_DoubleClick(object sender, EventArgs e)
        {
            uctxtBatch.Text = lstBatch.Text;
            uctxtShortQty.Focus();
        }

        private void uctxtBatch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBatch.Items.Count > 0)
                {
                    uctxtBatch.Text = lstBatch.Text;
                }
                uctxtShortQty.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtBatch, sender, e);
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
            lstCustomer.Visible = false;
            lstRefType.Visible = false;
            lstGroup.Visible = false;
            lstBatch.Visible = true;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            ucdgList.Visible = false;
            lstRefTypeNew.Visible = false;
            DGMr.Visible = false;
            DGcustomer.Visible = false;
            lstBatch.ValueMember = "Key";
            lstBatch.DisplayMember = "Value";
            lstBatch.DataSource = invms.mFillBatch(strComID).ToList();

            lstBatch.SelectedIndex = lstBatch.FindString(uctxtBatch.Text);
        }

        //private void uctxtItemName_TextChanged(object sender, EventArgs e)
        //{
        //    lstItemName.SelectedIndex = lstItemName.FindString(uctxtItemName.Text);
        //}

        //private void lstItemName_DoubleClick(object sender, EventArgs e)
        //{
        //    uctxtItemName.Text = lstItemName.Text;
        //    uctxtQty.Focus();
        //}

        private void uctxtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtItemName.Text == "")
                {
                    
                    uctxtItemName.Text = "";
                    ucdgList.Visible = false;
                    pnlAddLess.Visible = true;
                    if (pnlAddLess.Visible == true)
                    {
                        if (lstBranchName.SelectedValue.ToString() == "0002")
                        {
                            uctxtAddleddLedger.Focus();
                        }
                        else
                        {
                            btnAddLessApply.Focus();
                        }
                        pnlAddLess.Location = new Point(509, 364);
                        pnlAddLess.Size = new Size(512, 210);
                    }
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
                //PriorSetFocusText(uctxtItemName, sender, e);
                Utility.PriorSetFocusText(uctxtItemName, uctxtGroupName);
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
            //txtFoodCode.Text = "";
            //txtFoodName.Text = "";
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
            ucdgList.Height = 200;
            //ucdgList.Size = new Size(546, 222);
            ucdgList.BringToFront();
            ucdgList.AllowUserToAddRows = false;
            //uctxtItemName.Text = Utility.GetDgValue(ucdgList, uctxtItemName, 0);
            //ucdgList.Focus();
            return;
           
        }

        private void uctxtItemName_GotFocus(object sender, System.EventArgs e)
        {
            
            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstCustomer.Visible = false;
            lstRefType.Visible = false;
            lstGroup.Visible = false;
            lstBatch.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            lstRefTypeNew.Visible = false;
            DGMr.Visible = false;
            DGcustomer.Visible = false;
            
        }
        private void mloadItem()
        {
            int introw = 0;
            ucdgList.Rows.Clear();
            if (uctxtLocation.Text=="")
            {
                return;
            }
            string strDate=DateTime.Now.ToString("dd-MM-yyyy");
            if (uctxtGroupName.Text =="")
            {
                MessageBox.Show("Cannot be Empty");
                uctxtGroupName.FindForm();
                return;
            }
            if (uctxtLocation.Text =="Main Location")
            {
                oogrp = objWIS.mGetProductStatementView(strComID, uctxtGroupName.Text, "0001",uctxtLocation.Text,"").ToList();
            }
            else
            {
                oogrp = objWIS.mGetProductStatementView(strComID, uctxtGroupName.Text, "0002", uctxtLocation.Text,"").ToList();
            }
            
           //oogrp = invms.mloadAddStockItemSI(strComID, uctxtGroupName.Text, uctxtLocation.Text).ToList();
            //oogrp = objWIS.mGetProductStatementNew(strComID, strDate, "'" + uctxtGroupName.Text.ToString() + "' ", "0001").ToList();

            if (oogrp.Count > 0)
            {

                foreach (StockItem ogrp in oogrp)
                {
                    ucdgList.Rows.Add();
                    ucdgList[0, introw].Value = ogrp.strItemName;
                    ucdgList[1, introw].Value = ogrp.dblClsBalance + " " + ogrp.strUnit;
                    
                    introw += 1;
                }

                ucdgList.AllowUserToAddRows = false;
            }
        }
        private void uctxtShortQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            string strPowerClass = "", strUOM = "",strPackSize="";
            //double dblDis = 0;
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtItemName.Text != "")
                {
                    if (uctxtItemName.Text != "")
                    {
                        strUOM = Utility.gGetBaseUOM(strComID, uctxtItemName.Text);
                        strPowerClass = Utility.mGetPowerClass(strComID, uctxtItemName.Text);
                        strPackSize = Utility.mGetPackSize(strComID, uctxtItemName.Text);
                        if (uctxtRate.Text != "" && uctxtRate.Text != "0")
                        {
                            mAddStockItem(uctxtGroupName.Text, uctxtItemName.Text, strPowerClass, strPackSize, Utility.Val(uctxtQty.Text), Utility.Val(uctxtRate.Text), strUOM, uctxtDisc.Text,
                                            uctxtBatch.Text, Utility.Val(uctxtShortQty.Text));
                            uctxtItemName.Focus();
                        }
                        else if (Utility.Val(uctxtShortQty.Text) > 0)
                        {
                            mAddStockItem(uctxtGroupName.Text, uctxtItemName.Text, strPowerClass, strPackSize, Utility.Val(uctxtQty.Text), Utility.Val(uctxtRate.Text), strUOM, uctxtDisc.Text,
                                            uctxtBatch.Text, Utility.Val(uctxtShortQty.Text));
                            uctxtItemName.Focus();
                        }
                        else
                        {
                            uctxtRate.Focus();
                        }
                    }
                }
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtShortQty, sender, e);
            }
        }

        private void mAddStockItem(string strGroupName,string strItemName, string strPowerClass,string strPackSize, double dblQty, double dblRate,
                                    string strUom,string  strDis,string strBatch,double dblShort)
        {
            int selRaw;

            string strDown = "";
            double  dblDis=0;
            Boolean blngCheck = false;
            for (int j = 0; j < DGSalesGrid.RowCount; j++)
            {
                if (DGSalesGrid[2, j].Value != null)
                {
                    strDown = DGSalesGrid[2, j].Value.ToString();
                }
                if (strItemName == strDown.ToString())
                {
                    blngCheck = true;
                    
                }

            }
            if (blngCheck == false)
            {

                DGSalesGrid.AllowUserToAddRows = true;
                if (txtRowIndex.Text == "")
                {
                    selRaw = Convert.ToInt16(DGSalesGrid.RowCount.ToString());
                    selRaw = selRaw - 1;
                    DGSalesGrid.Rows.Add();
                }
                else
                {
                    selRaw = Convert.ToInt16(txtRowIndex.Text);
                    
                }
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
                double dblbonus = Math.Round(Utility.mdblGetBonus(strComID, uctxtItemName.Text, Utility.gstrGetBranchID(strComID, uctxtBranchName.Text), Utility.Val(uctxtQty.Text.ToString()), dtePreparedDate.Text), 2);
                if (m_action==2)
                {
                    DGSalesGrid[0, selRaw].Value = Utility.mGetRefNo(strComID, "ACC_BILL_TRAN", "BILL_TRAN_KEY", "COMP_REF_NO", textBox1.Text);
                }


                DGSalesGrid[1, selRaw].Value = strGroupName.ToString();
                DGSalesGrid[2, selRaw].Value = strItemName.ToString();
                DGSalesGrid[3, selRaw].Value = strPowerClass.ToString();
                DGSalesGrid[4, selRaw].Value = strPackSize.ToString();
                DGSalesGrid[5, selRaw].Value = dblQty.ToString();
                DGSalesGrid[6, selRaw].Value = dblRate.ToString();
                DGSalesGrid[7, selRaw].Value = strUom;
                DGSalesGrid[8, selRaw].Value = (dblQty * dblRate);
                DGSalesGrid[9, selRaw].Value = dblDis;
                DGSalesGrid[10, selRaw].Value =(dblQty * dblRate)- dblDis;
                DGSalesGrid[11, selRaw].Value = strBatch;
                DGSalesGrid[12, selRaw].Value = dblbonus;
                DGSalesGrid[13, selRaw].Value = dblShort;
                DGSalesGrid[14, selRaw].Value = "Delete";
                DGSalesGrid[15, selRaw].Value = Utility.mGetStockGroupFromItemGroup(strComID, strGroupName);
                
                //uctxtItemName.Text = "*****Press F3*****";
                uctxtQty.Text = "";
                uctxtRate.Text = "";
                uctxtDisc.Text = "";
                uctxtBatch.Text = "";
                uctxtShortQty.Text = "";
                uctxtItemName.Text = "";
                DGSalesGrid.AllowUserToAddRows = false;
                calculateTotal();
                if (txtRowIndex.Text == "")
                {
                    DGSalesGrid.ClearSelection();
                    int nColumnIndex = 2;
                    int nRowIndex = DGSalesGrid.Rows.Count - 1;
                    DGSalesGrid.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;
                    DGSalesGrid.FirstDisplayedScrollingRowIndex = nRowIndex;
                }
                else
                {
                    txtRowIndex.Text = "";
                }
            }
            else
            {
                
                uctxtQty.Text = "";
                uctxtRate.Text = "";
                uctxtDisc.Text = "";
                uctxtBatch.Text = "";
                uctxtShortQty.Text = "";
                uctxtItemName.Text = "";
                MessageBox.Show("Item is Already Exists");
                uctxtItemName.Focus();
                return;
            }

        }


        private void uctxtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtShortQty.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtRate, sender, e);
            }
        }
       
        private void uctxtDisc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtBatch.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtDisc, sender, e);
            }
        }
        private void uctxtRefNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R && e.Modifiers == Keys.Control)
            {
                //txtNarration.Text = Interaction.GetSetting(Application.ExecutablePath, intvtype.ToString(), "Narration");
                //RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
                //uctxtRefNo.AppendText((String)rk.GetValue("VoucherNoSI", ""));
                string strRefNo = Utility.GetSalesInvoiceLastNo(strComID, uctxtRefNo.Text);
                uctxtRefNo.Text = "";
                uctxtRefNo.AppendText(strRefNo);
                //rk.Close();
            }

        }
        private void uctxtRefNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (m_action == 1)
                {
                    string strBarchID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);
                    string strRefNo = "SI" +strBarchID + uctxtRefNo.Text;
                    string strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_COMPANY_VOUCHER", "COMP_REF_NO", strRefNo);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        uctxtRefNo.Focus();
                        return;
                    }
                }
                uctxtOrderNo.Focus();

            }
        }
        private void dteOrderDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
              
                dteDeliveryDate.Focus();

            }
        }
        private void dteDeliveryDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtLedgerName.Focus();

            }
        }
        private void uctxtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            double dblrate = 0,dblBonus=0;
            if (e.KeyChar == (char)Keys.Return)
            {
                if (intVtype == (int)Utility.VOUCHER_TYPE.vtSALES_INVOICE)
                {
                    dblrate = Utility.gdblGetEnterpriseSalesPrice(strComID, uctxtItemName.Text, dtePreparedDate.Text, Utility.Val(uctxtQty.Text.ToString()), 0, "");
                    //dblBonus = Utility.mdblGetBonus(uctxtItemName.Text, Utility.gstrGetBranchID(strComID, uctxtBranch.Text);,Utility.Val(uctxtQty.Text.ToString()),dteOrderDate.Text);
                    if (lstBranchName.SelectedValue.ToString()=="0002")
                    {
                        uctxtRate.ReadOnly = false;
                    }
                    else
                    {
                        uctxtRate.ReadOnly = true;
                    }

                    uctxtRate.Text = dblrate.ToString();
                    //uctxtShortQty.Text = dblBonus.ToString();
                }
                else
                {

                    dblrate = Utility.gdblPurchasePrice(uctxtItemName.Text, dtePreparedDate.Text, uctxtLocation.Text);
                    uctxtRate.Text = dblrate.ToString();
                }
                //if (dblrate > 0)
                //{
                //    uctxtDisc.Focus();
                //}
                //else
                //{
                uctxtShortQty.Focus();
                //}
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtQty, sender, e);
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
                if (uctxtRefType.Text != Utility.gcEND_OF_LIST)
                {
                    long lngRefType = gobjVoucherName.VoucherName.GetVoucherType(uctxtRefType.Text);
                    if (uctxtLocation.Text != "")
                    {
                        mLoadAllItemOrder(uctxtMedicalRep.Text, lngRefType, dtePreparedDate.Text, Utility.gstrGetBranchID(strComID, uctxtBranchName.Text), uctxtLocation.Text, "");
                    }
                    txtRefTypeNew.Focus();
                }
                else
                {
                    uctxtGroupName.Focus();
                }
            }
            else
            {
                uctxtGroupName.Focus();
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
                        long lngRefType = gobjVoucherName.VoucherName.GetVoucherType(uctxtRefType.Text);
                        if (uctxtLocation.Text != "")
                        {
                            mLoadAllItemOrder(uctxtMedicalRep.Text, lngRefType, dtePreparedDate.Text, Utility.gstrGetBranchID(strComID, uctxtBranchName.Text), uctxtLocation.Text, "");
                        }
                        txtRefTypeNew.Focus();
                    }
                    else
                    {
                        uctxtGroupName.Focus();
                    }
            }
        }
        #region "Item Order"
        private void mLoadAllItemOrder(string strPartyname, long lngVtype, string strDate, string strBranchID, string strLocation, string strRefNo)
        {
            int introw = 0;
            //this.lstRefTypeNew.DefaultCellStyle.Font = new Font("verdana", 9);
            lstRefTypeNew.Rows.Clear();
            if (lngVtype != (int)Utility.VOUCHER_TYPE.vt_SAMPLE_CLASS)
            {
                ooRefNo = accms.gFillPreRefNoNew2(strComID, strPartyname, lngVtype, strDate, strBranchID, strLocation, strRefNo, 0).ToList();
            }
            else
            {
                ooRefNo = accms.gFillPreSampleClass(strComID).ToList();
            }
            if (ooRefNo.Count > 0)
            {

                foreach (AccBillwise ogrp in ooRefNo)
                {

                    lstRefTypeNew.Rows.Add();
                    lstRefTypeNew[0, introw].Value = ogrp.strBillKey;
                    if (lngVtype != (long)Utility.VOUCHER_TYPE.vt_SAMPLE_CLASS)
                    {
                        lstRefTypeNew[1, introw].Value = Utility.Mid(ogrp.strRefNo, 6, ogrp.strRefNo.Length - 6);
                    }
                    else
                    {
                        lstRefTypeNew[1, introw].Value = ogrp.strRefNo;
                    }
                    lstRefTypeNew[2, introw].Value = ogrp.strDate;
                    //if (introw % 2 == 0)
                    //{
                    //    lstRefTypeNew.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    lstRefTypeNew.Rows[introw].DefaultCellStyle.BackColor = Color.White;
                    //}
                    introw += 1;
                }
                lstRefTypeNew.AllowUserToAddRows = false;
            }
        }
        #endregion
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
                    //txtRefTypeNew.Text = "*****Press F3*****";
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
            lstCustomer.Visible = false;
            lstRefType.Visible = true;
            lstGroup.Visible = false;
            lstBatch.Visible = false;
            DGMr.Visible = false;
            lstRefTypeNew.Visible = false;
            DGcustomer.Visible = false;
            lstRefType.SelectedIndex = lstRefType.FindString(uctxtRefType.Text);
        }

        private void uctxtCustomer_TextChanged(object sender, EventArgs e)
        {
           //// lstCustomer.SelectedIndex = lstCustomer.FindString(uctxtCustomer.Text);
           // int n, i = 0;
           // bool isNumeric = int.TryParse(uctxtCustomer.Text, out n);
           // if (isNumeric)
           // {
           //     i = 1;
           // }
           // if (uctxtCustomer.Text == "")
           // {
           //     i = 2;
           // }
           // //if (uctxtCustomer.Text != "")
           // //{
           //     SearchListViewSalesRep(ooinv, uctxtCustomer.Text, i);
           // //}
            if (uctxtCustomer.Text == "")
            {
                txtCustomerCode.Text = "";
                txtHomoeoHall.Text = "";
                txtCustomerAddress.Text = "";
            }
        }

        //private void lstCustomer_DoubleClick(object sender, EventArgs e)
        //{
        //    //uctxtCustomer.Text = lstCustomer.Text;
        //    string[] words = lstCustomer.Text.Split('~');
        //    foreach (string word in words)
        //    {
        //        if (words[0].ToString() != Utility.gcEND_OF_LIST)
        //        {
        //            txtCustomerCode.Text = words[0].ToString();
        //            uctxtCustomer.Text = words[1].ToString();
        //            txtHomoeoHall.Text = words[2].ToString();
        //            txtCustomerAddress.Text = Utility.gGeCustomerAddress(strComID, uctxtCustomer.Text);
        //        }
        //        else
        //        {
        //            uctxtCustomer.Text = Utility.gcEND_OF_LIST;
        //        }
        //    }
        //    uctxtLocation.Focus();
        //}

        private void uctxtCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
          
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtCustomer.Text == "" || uctxtCustomer.Text == Utility.gcEND_OF_LIST)
                {
                    //txtItemCode.Text = "";
                    uctxtCustomer.Text = "";
                    uctxtCustomer.Text = Utility.gcEND_OF_LIST;
                    DGcustomer.Visible = false;
                    uctxtLocation.Focus();

                    return;
                }


                if (uctxtItemName.Text != "")
                {
                    DGcustomer.Focus();
                    if (DGcustomer.Rows.Count > 0)
                    {
                        int i = 0;
                        txtCustomerCode.Text = DGcustomer.Rows[i].Cells[1].Value.ToString();
                        uctxtCustomer.Text = DGcustomer.Rows[i].Cells[3].Value.ToString();
                        //txtHomoeoHall.Text = DGcustomer.Rows[i].Cells[2].Value.ToString();
                        txtCustomerAddress.Text = Utility.gGeCustomerAddress(strComID, txtCustomerCode.Text);
                        DGcustomer.Visible = false;
                        uctxtLocation.Focus();
                    }
                }
                else
                {
                    if (DGcustomer.Rows.Count > 0)
                    {
                        int i = 0;

                        txtCustomerCode.Text = DGcustomer.Rows[i].Cells[1].Value.ToString();
                        uctxtCustomer.Text = DGcustomer.Rows[i].Cells[3].Value.ToString();
                        //txtHomoeoHall.Text = DGcustomer.Rows[i].Cells[2].Value.ToString();
                        txtCustomerAddress.Text = Utility.gGeCustomerAddress(strComID, txtCustomerCode.Text);
                        DGcustomer.Visible = false;
                    }
                    else
                    {
                        txtCustomerCode.Text = "";
                        uctxtCustomer.Text = "End of List";
                        txtHomoeoHall.Text = "";
                        txtCustomerAddress.Text = "";
                    }
                    uctxtLocation.Focus();
                }
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtCustomer, sender, e);
            }
            //}


        }
        private void uctxtCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 4))
                    {
                        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                if (System.Windows.Forms.Application.OpenForms["frmSalesRepresentive"] as frmSalesRepresentive == null)
                {
                    frmSalesRepresentive objfrm = new frmSalesRepresentive();
                    objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                    objfrm.lngFormPriv = 4;
                    objfrm.Show();
                    objfrm.MdiParent = this.MdiParent;

                }
                else
                {
                    frmSalesRepresentive objfrm = (frmSalesRepresentive)Application.OpenForms["frmSalesRepresentive"];
                    objfrm.Focus();
                    objfrm.MdiParent = this.MdiParent;
                }

            }
            DGcustomer.Visible = true;
            if (e.KeyCode == Keys.Up)
            {
                DGcustomer.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                DGcustomer.Focus();
            }

            DGcustomer.Top = uctxtCustomer.Top + 25;
            DGcustomer.Left = uctxtCustomer.Left;
            DGcustomer.Width = uctxtCustomer.Width;
            DGcustomer.Height = 200;
            //ucdgList.Size = new Size(546, 222);
            DGcustomer.BringToFront();
            DGcustomer.AllowUserToAddRows = false;
            //uctxtItemName.Text = Utility.GetDgValue(ucdgList, uctxtItemName, 0);
            //ucdgList.Focus();
            return;
         

        }
        private void DGcustomer_DoubleClick(object sender, EventArgs e)
        {
            //DateTime firstDay = Convert.ToDateTime(DateTime.Parse(month + ", 1 " + year, CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"));
            //DateTime lastDay = Convert.ToDateTime(firstDay.AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy"));
            //int LastDay = lastDay.Day;


            if (DGMr.SelectedRows.Count > 0)
            {
                int i = Convert.ToInt16(DGcustomer.CurrentRow.Index.ToString());
                txtCustomerCode.Text = DGcustomer.Rows[i].Cells[1].Value.ToString();
                uctxtCustomer.Text = DGcustomer.Rows[i].Cells[3].Value.ToString();
                //txtHomoeoHall.Text = DGcustomer.Rows[i].Cells[2].Value.ToString();
                txtCustomerAddress.Text = Utility.gGeCustomerAddress(strComID, txtCustomerCode.Text);
                DGcustomer.Visible = false;
                uctxtLocation.Focus();


            }
        }
        private void DGcustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                //uctxtPartyName.Text = Utility.GetDgValue(DGMr, uctxtPartyName, 0);
                int i = Convert.ToInt16(DGcustomer.CurrentRow.Index.ToString());
                txtCustomerCode.Text = DGcustomer.Rows[i].Cells[1].Value.ToString();
                uctxtCustomer.Text = DGcustomer.Rows[i].Cells[3].Value.ToString();
                //txtHomoeoHall.Text = DGcustomer.Rows[i].Cells[2].Value.ToString();
                txtCustomerAddress.Text = Utility.gGeCustomerAddress(strComID, txtCustomerCode.Text);
                DGcustomer.Visible = false;
                uctxtLocation.Focus();
            }
        }
        private void uctxtCustomer_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstCustomer.Visible = false ;
            lstRefType.Visible = false;
            lstGroup.Visible = false;
            lstBatch.Visible = false;
            ucdgList.Visible = false;
            lstTeritorryCode.Visible = false;
            DGMr.Visible = false;
            DGcustomer.Visible = false;
            if (uctxtMedicalRep.Text != "")
            {
                mloadCustomer();
            }
        }

        private void mloadCustomer()
        {
            int introw = 0;
            DGcustomer.Rows.Clear();

            ooCustomer = invms.mFillSalesRepFromMPoNew1(strComID, (long)Utility.GR_GROUP_TYPE.grSALES_REP, uctxtMedicalRep.Text).ToList();

            if (ooCustomer.Count > 0)
            {

                foreach (Invoice ogrp in ooCustomer)
                {
                    DGcustomer.Rows.Add();
                    DGcustomer[3, introw].Value = ogrp.strTeritorryCode;
                    DGcustomer[2, introw].Value = ogrp.strLedgerName;
                    //DGcustomer[2, introw].Value = ogrp.strTeritorryName;

                    DGcustomer[3, introw].Value = ogrp.strMereString;
                    //if (introw % 2 == 0)
                    //{
                    //    DGcustomer.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    DGcustomer.Rows[introw].DefaultCellStyle.BackColor = Color.White;
                    //}
                    introw += 1;
                }

                DGcustomer.AllowUserToAddRows = false;
            }
        }
        private void uctxtLocation_TextChanged(object sender, EventArgs e)
        {
            lstLocation.SelectedIndex = lstLocation.FindString(uctxtLocation.Text);
        }

        private void lstLocation_DoubleClick(object sender, EventArgs e)
        {
            uctxtLocation.Text = lstLocation.Text;
            if (uctxtRefType.Enabled)
            {
                uctxtRefType.Focus();
            }
            else
            {
                uctxtGroupName.Focus();
            }
        }

        private void uctxtLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstLocation.Items.Count > 0)
                {
                    uctxtLocation.Text = lstLocation.Text;
                }
                if (uctxtLocation.Text=="")
                {
                    uctxtLocation.Text = lstLocation.Text;
                }
                if (uctxtRefType.Enabled)
                {
                    uctxtRefType.Focus();
                }
                else
                {
                    uctxtGroupName.Focus();
                }
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtLocation, sender, e);
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
            lstCustomer.Visible = false;
            lstRefType.Visible = false;
            lstGroup.Visible = false;
            lstBatch.Visible = false;
            ucdgList.Visible = false;
            DGMr.Visible = false;
            DGcustomer.Visible = false;
            //lstLocation.Items.Clear();
            //lstLocation.Items.Add("Main Location");
            if (uctxtBranchName.Text != "")
            {
                lstLocation.ValueMember = "strLocation";
                lstLocation.DisplayMember = "strLocation";
                //lstLocation.DataSource = invms.gLoadLocation(strComID, lstBranchName.SelectedValue.ToString(), Utility.gblnAccessControl, Utility.gstrUserName, 0).ToList();
                lstLocation.DataSource = invms.gLoadInvoiceLocation(strComID, lstBranchName.SelectedValue.ToString(), Utility.gblnAccessControl, Utility.gstrUserName, 0).ToList();
            }
            if (lstBranchName.SelectedValue == "0001")
            {
                uctxtLocation.Text = lstLocation.Text;
            }
            else
            {
                uctxtLocation.Text = lstLocation.Text;
            }
            lstLocation.SelectedIndex = lstLocation.FindString(uctxtLocation.Text);
        }


        private void uctxtBranchName_TextChanged(object sender, EventArgs e)
        {
            lstBranchName.SelectedIndex = lstBranchName.FindString(uctxtBranchName.Text);
        }

        private void lstBranchName_DoubleClick(object sender, EventArgs e)
        {
            uctxtBranchName.Text = lstBranchName.Text;
            if (lstBranchName.SelectedValue.ToString().Trim() == "0001")
            {
                uctxtLocation.Text = "Main Location";
            }
            else
            {
                uctxtLocation.Text = "";
            }
            uctxtRefNo.Focus();
        }

        private void uctxtBranchName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBranchName.Items.Count > 0)
                {
                    uctxtBranchName.Text = lstBranchName.Text;
                }
              
                uctxtRefNo.Focus();
                if (lstBranchName.SelectedValue.ToString().Trim() == "0001")
                {
                    uctxtLocation.Text = "Main Location";
                }
                else
                {
                    uctxtLocation.Text = "";
                }
                if (strOldBranchName != uctxtBranchName.Text)
                {
                    uctxtTerritoryCode.Text = "";
                    uctxtTeritorryName.Text = "";
                    uctxtMedicalRep.Text = "";
                    uctxtCustomer.Text = "";
                    txtHomoeoHall.Text = "";
                    txtCustomerAddress.Text = "";
                    txtCustomerCode.Text = "";
                   // uctxtLocation.Text = "";

                }
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtBranchName, sender, e);
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
            lstCustomer.Visible = false;
            lstRefType.Visible = false;
            lstGroup.Visible = false;
            lstBatch.Visible = false;
            ucdgList.Visible = false;
            DGMr.Visible = false;
            DGcustomer.Visible = false;
            lstBranchName.ValueMember = "BranchID";
            lstBranchName.DisplayMember = "BranchName";
            lstBranchName.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
            lstBranchName.SelectedIndex = lstBranchName.FindString(uctxtBranchName.Text);
        }


        private void uctxtLedgerName_TextChanged(object sender, EventArgs e)
        {
            lstLedgerName.SelectedIndex = lstLedgerName.FindString(uctxtLedgerName.Text);
        }

        private void lstLedgerName_DoubleClick(object sender, EventArgs e)
        {
            uctxtLedgerName.Text = lstLedgerName.Text;
            lstTeritorryCode.Items.Clear();
            oTer = accms.mFillTeritorrySI(strComID, "").ToList();
            foreach (Teritorry yy in oTer)
            {
                lstTeritorryCode.Items.Add(yy.strTeritorrycode);
            }
            uctxtTerritoryCode.Focus();
        }

        private void uctxtLedgerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstLedgerName.Items.Count > 0)
                {
                    uctxtLedgerName.Text = lstLedgerName.Text;
                }
                uctxtTerritoryCode.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtLedgerName, sender, e);
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
                frmAccountsLedger objfrm = new frmAccountsLedger();
                objfrm.m_acction = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.mSingleEntry = 1;
                objfrm.lngFormPriv = 96;
                objfrm.Show();

            }

        }

        private void uctxtLedgerName_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstLedgerName.Visible = true;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstCustomer.Visible = false;
            lstRefType.Visible = false;
            lstGroup.Visible = false;
            lstBatch.Visible = false;
            ucdgList.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            DGMr.Visible = false;
            DGcustomer.Visible = false;
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



        private void uctxtMedicalRep_TextChanged(object sender, EventArgs e)
        {
            lstPartyName.SelectedIndex = lstPartyName.FindString(uctxtMedicalRep.Text);
        }

        private void lstPartyName_DoubleClick(object sender, EventArgs e)
        {
            uctxtLedgerName.Focus();
        }

        private void uctxtMedicalRep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtLedgerName.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtMedicalRep, sender, e);
            }
        }
        private void uctxtMedicalRep_KeyDown(object sender, KeyEventArgs e)
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
                frmCustomer objfrm = new frmCustomer();
                objfrm.m_acction = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.intvtype = (int)Utility.GR_GROUP_TYPE.grCUSTOMER;
                objfrm.mSingleEntry = 1;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
        }

        private void uctxtMedicalRep_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstCustomer.Visible = false;
            lstRefType.Visible = false;
            lstGroup.Visible = false;
            lstBatch.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            ucdgList.Visible = false;
            
            DGcustomer.Visible = false;
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
          
            DGAddLess.AllowUserToAddRows = false;
            lstPartyName.Visible = false;
            lstLedgerName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstCustomer.Visible = false;
            lstRefType.Visible = false;
            lstGroup.Visible = false;
            lstBatch.Visible = false;
            lstAddlessLedger.Visible = false;
            lstTypeofRef.Visible = false;
            lstCostCategory.Visible = false;
            lstCostCenter.Visible = false;
            lstTeritorryCode.Visible = false;
            lstTeritorryName.Visible = false;
            if (Utility.gblnAccessControl)
            {
                uctxtPreParedBy.Text = Utility.gstrUserName;
            }

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
            //oinv = invms.mGetInvoiceConfig().ToList();
            oinv = invms.mGetInvoiceConfig(strComID).ToList();

            mGetConfig();
            mClear();
            DGSalesOrder.AllowUserToAddRows = false;
            this.lstRefTypeNew.DefaultCellStyle.Font = new Font("verdana", 10F);
            lstRefTypeNew.Columns.Add(Utility.Create_Grid_Column("Bill Key", "Bill. Key", 350, false, DataGridViewContentAlignment.TopLeft, true));
            lstRefTypeNew.Columns.Add(Utility.Create_Grid_Column("Ref. No", "Ref. No", 160, true, DataGridViewContentAlignment.TopLeft, true));
            lstRefTypeNew.Columns.Add(Utility.Create_Grid_Column("Date", "Date", 100, true, DataGridViewContentAlignment.TopLeft, true));

            lstGroup.DisplayMember = "strGroupName";
            lstGroup.ValueMember = "strGroupName";
            lstGroup.DataSource = invms.mFillSample(strComID,"SI").ToList();
            lstGroup.SelectedIndex = lstGroup.FindString(uctxtGroupName.Text);
           
        }
        private void mloadParty(string strBranchID)
        {
            int introw = 0;
            DGMr.Rows.Clear();

            ooPartyName = invms.mfillPartyNameNewSI(strComID, strBranchID, Utility.gblnAccessControl, Utility.gstrUserName, 0, "X").ToList();

            if (ooPartyName.Count > 0)
            {

                foreach (Invoice ogrp in ooPartyName)
                {
                    DGMr.Rows.Add();
                    DGMr[0, introw].Value = ogrp.strTeritorryCode;
                    DGMr[1, introw].Value = ogrp.strLedgerName;
                    DGMr[2, introw].Value = ogrp.strTeritorryName;
                    DGMr[3, introw].Value = ogrp.strMereString;
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
        #region "Validation Field"
        private bool ValidateFields()
        {
            double dblClosingQTY = 0, dblCurrentQTY = 0;
            double dblPending = 0, dblCreditLimit = 0, dblLedgerClosing = 0;
            string strBillKey = "", strNegetiveItem = "", strBranchID = "";
            int intCheckNegetive = 0;

            if (uctxtMedicalRep.Text == "")
            {
                MessageBox.Show("Cannot Empty");
                uctxtMedicalRep.Focus();
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
            if (uctxtOrderNo.Text == "")
            {
                MessageBox.Show("Cannot Empty");
                uctxtOrderNo.Focus();
                return false;
            }
            if (DGSalesGrid.Rows.Count==0)
            {
                MessageBox.Show("Item Cannot be Empty");
                uctxtItemName.Focus();
                return false;
            }
            if  (Utility.Val(lblNetAmount.Text) <0)
            {
                MessageBox.Show("Net Amount Cannot be Netgetive");
                uctxtOldRefNo.Focus();
                return false;
            }
            if (Utility.gblnAccessControl)
            {
                if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, m_action))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return false;
                }
            }
            long lngDate = Convert.ToInt64(dtePreparedDate.Value.ToString("yyyyMMdd"));
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
               
                 //dblCreditLimit = Utility.Val (lblCreditLimit.Text);
                 dblCreditLimit = Utility.gdblCreditLimit(strComID, uctxtMedicalRep.Text, dtePreparedDate.Value.ToString("MMMyy"));
               
                if (dblCreditLimit != 0)
                {
                    string strFDate = Utility.FirstDayOfMonth(dtePreparedDate.Value).ToString("dd-MM-yyyy");
                    //dblLedgerClosing = Utility.dblLedgerClosingBalance(strComID, strFDate, dtePreparedDate.Text, uctxtMedicalRep.Text, "");
                    dblLedgerClosing  = Utility.dblLedgerClosingBalance(strComID, Utility.gdteFinancialYearFrom.ToString(), Utility.gdteFinancialYearTo.ToString(), uctxtMedicalRep.Text, "");
                    if (m_action == 1)
                    {
                        dblPending = Math.Round(dblCreditLimit - Math.Abs(dblLedgerClosing), 2);
                    }
                    else
                    {
                        if (mstrOldMedicalName.ToUpper() == uctxtMedicalRep.Text.ToUpper())
                        {
                            dblPending = Math.Round(dblCreditLimit - (Math.Abs(dblLedgerClosing) - Math.Abs(mdblNetAmount)), 2);
                            dblPending = dblPending - Math.Abs(mdblNetAmount);
                        }
                        else
                        {
                            dblPending = Math.Round(dblCreditLimit - (Math.Abs(dblLedgerClosing)), 2);
                            dblPending =dblPending - Math.Abs(Utility.Val(lblNetAmount.Text));
                        }
                    }
                    if (dblPending < Utility.Val(lblNetAmount.Text))
                    {
                        string strCls = "";
                        if (dblLedgerClosing < 0)
                        {
                            strCls = dblLedgerClosing *-1+ " Dr";
                        }
                        else
                        {
                            strCls = dblLedgerClosing  + " Cr";
                        }
                        MessageBox.Show("You have crossed your Credit Limit" + Environment.NewLine + "Closing Balance :" + strCls + Environment.NewLine 
                                                                        + "Credit Limt :" + dblCreditLimit + Environment.NewLine + "Pending : " + dblPending , "Credit Limit Information", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        return false;
                       
                    }
                }

              
               
                strBranchID = lstBranchName.SelectedValue.ToString();
                if (oinv[0].mlngBlockNegativeStock > 0)
                {
                    for (int i = 0; i < DGSalesGrid.Rows.Count; i++)
                    {

                        if (DGSalesGrid[0, i].Value != null)
                        {
                            strBillKey = DGSalesGrid[0, i].Value.ToString();
                        }
                        else
                        {
                            strBillKey = "";
                        }
                        
                        if (DGSalesGrid[1, i].Value.ToString() != "Dilution" && strBranchID !="0001")
                        {

                            dblClosingQTY = Utility.gdblClosingStockSales(strComID, DGSalesGrid[2, i].Value.ToString(), strBranchID, DGSalesGrid[1, i].Value.ToString(), uctxtLocation.Text);
                            if (m_action == (int)Utility.ACTION_MODE_ENUM.EDIT_MODE)
                            {
                                dblClosingQTY = dblClosingQTY + Utility.gdblGetBillTranQty(strComID, strBillKey);
                            }
                            dblCurrentQTY = Utility.Val(DGSalesGrid[5, i].Value.ToString());
                            if ((dblClosingQTY) - dblCurrentQTY < 0)
                            {
                                strNegetiveItem = strNegetiveItem + Environment.NewLine + DGSalesGrid[2, i].Value.ToString();
                                intCheckNegetive = 1;
                                dblClosingQTY = 0;
                            }
                        }
                    }
                    if (strNegetiveItem !="")
                    {
                        MessageBox.Show("You have no valid quantity for Item: " + strNegetiveItem);
                        DGSalesGrid.Focus();
                        strNegetiveItem="";
                        return false;
                    }
                    dblClosingQTY = 0;

                }
               
                //if (Utility.mblnBillWise(uctxtMedicalRep.Text) == true)
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
            int introundoff=0;
            if (chkRoundOff.Checked)
                introundoff=1;
            string strBarchID = "", strDGSales = "", strRefNo = "", strDGSalesOrder = "", strDGBillWise = "", strDgvector = "", strDGAddless="",strAgnstRefNo="";
            for (int i = 0; i < DGSalesGrid.Rows.Count; i++)
            {
                if (DGSalesGrid[16, i].Value ==null)
                {
                    DGSalesGrid[16, i].Value = 0;
                }
                if (DGSalesGrid[17, i].Value == null)
                {
                    strAgnstRefNo = "";
                }
                else
                {
                    strAgnstRefNo = DGSalesGrid[17, i].Value.ToString();
                }
                strDGSales = strDGSales + Utility.gCheckNull(DGSalesGrid[1, i].Value.ToString()) + "|" +//Group
                                                            Utility.gCheckNull(DGSalesGrid[2, i].Value.ToString()) + "|" +//Item
                                                            Utility.mGetItemDescription(strComID, DGSalesGrid[2, i].Value.ToString()) + "|" +//Des
                                                            Utility.Val(DGSalesGrid[5, i].Value.ToString()) + "|" +//qty
                                                            Utility.Val(DGSalesGrid[6, i].Value.ToString()) + "|" + //Rate
                                                            Utility.gCheckNull(DGSalesGrid[7, i].Value.ToString()) + "|" +//Unit
                                                            Utility.Val(DGSalesGrid[8, i].Value.ToString()) + "|" + //amount
                                                            Utility.Val(DGSalesGrid[9, i].Value.ToString()) + "|" + //dis
                                                            Utility.Val(DGSalesGrid[10, i].Value.ToString()) + "|" + //New amount
                                                            Utility.gCheckNull(DGSalesGrid[11, i].Value.ToString()) + "|" + //batch
                                                            Utility.gCheckNull(DGSalesGrid[12, i].Value.ToString()) + "|" + //bonus
                                                            Utility.gCheckNull(DGSalesGrid[8, i].Value.ToString()) + "|" + //addless String
                                                           Utility.Val(uctxtLess.Text) + "|" +
                                                            dblcostRate + "|" + Utility.gCheckNull(DGSalesGrid[13, i].Value.ToString()) + "|" + introundoff + "|" +
                                                           Utility.Val(DGSalesGrid[16, i].Value.ToString()) + "|" + strAgnstRefNo + "~";
                //Utility.gCheckNull(DGSalesGrid[10, i].Value.ToString()) + "~";
            }
            for (int i = 0; i < dgBillBranch.Rows.Count; i++)
            {
                if (dgBillBranch[0, i].Value != null)
                {
                    strDGBillWise = strDGBillWise + Utility.gCheckNull(dgBillBranch[0, i].Value.ToString()) + "|" +
                                                                Utility.gCheckNull(dgBillBranch[1, i].Value.ToString()) + "|" +
                                                                Utility.gCheckNull(dgBillBranch[2, i].Value.ToString()) + "|" +
                                                                Utility.Val(dgBillBranch[3, i].Value.ToString()) + "|" +
                                                                Utility.gCheckNull(dgBillBranch[4, i].Value.ToString()) + "|" +
                                                                 Utility.Val(dgBillBranch[5, i].Value.ToString()) + "~";
                }

            }

            for (int i = 0; i < DgCostCenter.Rows.Count; i++)
            {
                if (DgCostCenter[0, i].Value != null)
                {
                    strDgvector = strDgvector + Utility.gCheckNull(DgCostCenter[0, i].Value.ToString()) + "|" +
                                                                Utility.gCheckNull(DgCostCenter[1, i].Value.ToString()) + "|" +
                                                                Utility.Val(DgCostCenter[2, i].Value.ToString()) + "~";
                }
            }

            for (int i = 0; i < DGSalesOrder.Rows.Count; i++)
            {
                if (DGSalesOrder[0, i].Value != null)
                {
                    strDGSalesOrder = strDGSalesOrder + Utility.gCheckNull(DGSalesOrder[0, i].Value.ToString()) + "|" +
                                                                Utility.gCheckNull(DGSalesOrder[1, i].Value.ToString()) + "|" +
                                                                Utility.gCheckNull(DGSalesOrder[2, i].Value.ToString()) + "~";
                }
            }
            for (int i = 0; i < DGAddLess.Rows.Count; i++)
            {
                if (DGAddLess[0, i].Value != null)
                {
                    if (DGAddLess[0, i].Value.ToString() != "Round Off")
                    {
                        strDGAddless = strDGAddless + Utility.gCheckNull(DGAddLess[0, i].Value.ToString()) + "|" +
                                                                    Utility.gCheckNull(DGAddLess[1, i].Value.ToString()) + "|" +
                                                                    Utility.Val(DGAddLess[2, i].Value.ToString()) + "~";
                    }
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
            if(txtCustomerCode.Text == "")
            {
                txtCustomerCode.Text = Utility.GetLedgerNameFromMerzeName(strComID, uctxtCustomer.Text);
                //txtCustomerAddress.Text = Utility.gstrGetLedgerAddress(strComID, txtCustomerCode.Text);
            }

            string k = objWIS.mSaveSalesInvoice(strComID, strRefNo, intVtype, dtePreparedDate.Text, dtePreparedDate.Text, dtePreparedDate.Value.ToString("MMMyy"), uctxtMedicalRep.Text,
                                                uctxtLedgerName.Text, Utility.Val(lblNetTotal.Text),  Utility.Val(lblNetAmount.Text),
                                                Utility.Val(uctxtAdd.Text), Utility.Val(uctxtLess.Text), uctxtRefType.Text, lngAgstRef, oinv[0].mlngIsInvEffinDirSalesInv, 1,
                                                uctxtNarration.Text, strBarchID, uctxtLocation.Text, 0, txtCustomerCode.Text, strDGSales,
                                                strDgvector, strDGBillWise, strDGSalesOrder, strDGAddless, false, 0, "", mblnNumbMethod, uctxtOrderNo.Text, dteOrderDateNew.Text,
                                                Utility.gstrUserName, dteDeliveryDate.Text, Utility.Val(uctxtcommission.Text), Utility.Val(txtRoundOff.Text));


            return k;
        }
        private string mUpdateSalesInvoice()
        {
            long lngAgstRef;
            double dblcostRate = 0;
            int introundoff = 0;
            if (chkRoundOff.Checked)
                introundoff = 1;
            string strBarchID = "", strDGSales = "", strRefNo = "", strDGSalesOrder = "", strDGBillWise = "", strDgvector = "", strDGAddless = "", strAgnstRefNo="";
            for (int i = 0; i < DGSalesGrid.Rows.Count; i++)
            {
                if (DGSalesGrid[16, i].Value == null)
                {
                    DGSalesGrid[16, i].Value = 0;
                }
                if (DGSalesGrid[17, i].Value == null)
                {
                    strAgnstRefNo = "";
                }
                else
                {
                    strAgnstRefNo = DGSalesGrid[17, i].Value.ToString();
                }
                strDGSales = strDGSales + Utility.gCheckNull(DGSalesGrid[1, i].Value.ToString()) + "|" +//Group
                                                            Utility.gCheckNull(DGSalesGrid[2, i].Value.ToString()) + "|" +//Item
                                                            Utility.mGetItemDescription(strComID, DGSalesGrid[2, i].Value.ToString()) + "|" +//Des
                                                            Utility.Val(DGSalesGrid[5, i].Value.ToString()) + "|" +//qty
                                                            Utility.Val(DGSalesGrid[6, i].Value.ToString()) + "|" + //Rate
                                                            Utility.gCheckNull(DGSalesGrid[7, i].Value.ToString()) + "|" +//Unit
                                                            Utility.Val(DGSalesGrid[8, i].Value.ToString()) + "|" + //amount
                                                            Utility.Val(DGSalesGrid[9, i].Value.ToString()) + "|" + //dis
                                                            Utility.Val(DGSalesGrid[10, i].Value.ToString()) + "|" + //New amount
                                                            Utility.gCheckNull(DGSalesGrid[11, i].Value.ToString()) + "|" + //batch
                                                            Utility.gCheckNull(DGSalesGrid[12, i].Value.ToString()) + "|" + //bonus
                                                            Utility.gCheckNull(DGSalesGrid[8, i].Value.ToString()) + "|" + //addless String
                                                           Utility.Val(uctxtLess.Text) + "|" +
                                                            dblcostRate + "|" + Utility.gCheckNull(DGSalesGrid[13, i].Value.ToString()) + "|" + introundoff + "|" +
                                                            Utility.Val(DGSalesGrid[16, i].Value.ToString()) + "|" + strAgnstRefNo + "~";
                //Utility.gCheckNull(DGSalesGrid[10, i].Value.ToString()) + "~";
            }
            for (int i = 0; i < dgBillBranch.Rows.Count; i++)
            {
                if (dgBillBranch[0, i].Value != null)
                {
                    strDGBillWise = strDGBillWise + Utility.gCheckNull(dgBillBranch[0, i].Value.ToString()) + "|" +
                                                                Utility.gCheckNull(dgBillBranch[1, i].Value.ToString()) + "|" +
                                                                Utility.gCheckNull(dgBillBranch[2, i].Value.ToString()) + "|" +
                                                                Utility.Val(dgBillBranch[3, i].Value.ToString()) + "|" +
                                                                Utility.gCheckNull(dgBillBranch[4, i].Value.ToString()) + "|" +
                                                                 Utility.Val(dgBillBranch[5, i].Value.ToString()) + "~";
                }

            }

            for (int i = 0; i < DgCostCenter.Rows.Count; i++)
            {
                if (DgCostCenter[0, i].Value != null)
                {
                    strDgvector = strDgvector + Utility.gCheckNull(DgCostCenter[0, i].Value.ToString()) + "|" +
                                                                Utility.gCheckNull(DgCostCenter[1, i].Value.ToString()) + "|" +
                                                                Utility.Val(DgCostCenter[2, i].Value.ToString()) + "~";
                }
            }

            for (int i = 0; i < DGSalesOrder.Rows.Count; i++)
            {
                if (DGSalesOrder[0, i].Value != null)
                {
                    strDGSalesOrder = strDGSalesOrder + Utility.gCheckNull(DGSalesOrder[0, i].Value.ToString()) + "|" +
                                                                Utility.gCheckNull(DGSalesOrder[1, i].Value.ToString()) + "|" +
                                                                Utility.gCheckNull(DGSalesOrder[2, i].Value.ToString()) + "~";
                }
            }
            for (int i = 0; i < DGAddLess.Rows.Count; i++)
            {
                if (DGAddLess[0, i].Value != null)
                {
                    if (DGAddLess[0, i].Value.ToString() != "Round Off")
                    {
                        strDGAddless = strDGAddless + Utility.gCheckNull(DGAddLess[0, i].Value.ToString()) + "|" +
                                                                    Utility.gCheckNull(DGAddLess[1, i].Value.ToString()) + "|" +
                                                                    Utility.Val(DGAddLess[2, i].Value.ToString()) + "~";
                    }
                }

            }
            if (txtCustomerCode.Text == "")
            {
                txtCustomerCode.Text = Utility.GetLedgerNameFromMerzeName(strComID, uctxtCustomer.Text);
                //txtCustomerAddress.Text = Utility.gstrGetLedgerAddress(strComID, txtCustomerCode.Text);
            }
            lngAgstRef = gobjVoucherName.VoucherName.GetVoucherType(uctxtRefType.Text);
            strBarchID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);
            strRefNo = "SI" + strBarchID + uctxtRefNo.Text;
            string k = objWIS.mUpdateSalesInvoice(strComID, uctxtOldRefNo.Text, strRefNo, intVtype, dtePreparedDate.Text, dtePreparedDate.Text, dtePreparedDate.Value.ToString("MMMyy"), uctxtMedicalRep.Text,
                                                uctxtLedgerName.Text, Utility.Val(lblNetTotal.Text),Utility.Val(lblNetAmount.Text),
                                                Utility.Val(uctxtAdd.Text), Utility.Val(uctxtLess.Text), uctxtRefType.Text, lngAgstRef, oinv[0].mlngIsInvEffinDirSalesInv, 1,
                                                uctxtNarration.Text, strBarchID, uctxtLocation.Text, 0, txtCustomerCode.Text, strDGSales,
                                                strDgvector, strDGBillWise, strDGSalesOrder, strDGAddless,false, 0, "", uctxtOrderNo.Text, dteOrderDateNew.Text,
                                               Utility.gstrUserName, dteDeliveryDate.Text, Utility.Val(uctxtcommission.Text), Utility.Val(txtRoundOff.Text));


            return k;
        }
        #endregion
        
        #region "Click"
        private void DGSalesGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 14)
            {
                if (uctxtRefType.Text == Utility.gcEND_OF_LIST)
                {
                    DGSalesGrid.Rows.RemoveAt(e.RowIndex);
                    calculateTotal();
                }
                else
                {
                    MessageBox.Show("You Cannot Delete,Because Your Ref. Type is Sales Order");
                    uctxtNarration.Focus();
                    return;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           string strResponse,strDuplicate="";
            if (ValidateFields() == false)
            {
                return;
            }
            btnAddLessApply_Click(sender, e);
            calculateTotal();

            RegistryKey rk = Registry.CurrentUser.CreateSubKey("SOFTWARE\\SmartAccounts");
            rk.SetValue("NarrationsSI", uctxtNarration.Text);
          
            rk.Close();
            try
            {


                var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    string strBarchID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);
                    if (m_action == (int)Utility.ACTION_MODE_ENUM.ADD_MODE)
                    {
                      
                        string strRefNo = strBarchID + uctxtRefNo.Text;
                        strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_COMPANY_VOUCHER", "COMP_REF_NO", strRefNo);
                        if (strDuplicate != "")
                        {
                            MessageBox.Show(strDuplicate);
                            uctxtRefNo.Focus();
                            return;
                        }

                        if (intVtype == (int)Utility.VOUCHER_TYPE.vtSALES_INVOICE)
                        {
                            strResponse = mSaveSalesInvoice();
                            if (strResponse == "Inserted...")
                            {
                                if (Utility.gblnAccessControl)
                                {
                                    string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, dtePreparedDate.Text, "Sales Invoice", uctxtRefNo.Text,
                                                                            1, Utility.Val(lblNetAmount.Text), (int)Utility.MODULE_TYPE.mtSALES, strBarchID);
                                }
                                mClear();
                                dtePreparedDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                                uctxtRefNo.Focus();
                            }
                            else
                            {
                                MessageBox.Show(strResponse.ToString());
                            }
                        }
                    }
                    else
                    {
                        if (intVtype == (int)Utility.VOUCHER_TYPE.vtSALES_INVOICE)
                        {
                            strResponse = mUpdateSalesInvoice();
                            if (strResponse == "Updated...")
                            {
                                if (Utility.gblnAccessControl)
                                {
                                    string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, dtePreparedDate.Text, "Sales Invoice", uctxtRefNo.Text,
                                                                            2, Utility.Val(lblNetAmount.Text), (int)Utility.MODULE_TYPE.mtSALES, strBarchID,uctxtOldRefNo.Text);
                                }
                                mClear();
                                dtePreparedDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                                dteOrderDateNew.Text = DateTime.Now.ToString("dd-MM-yyyy");
                                dteDeliveryDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                MessageBox.Show(strResponse.ToString());
                            }
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
           
            frmAccountsVoucherList objfrm = new frmAccountsVoucherList();
            objfrm.mintVType = intVtype;
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.strFormName = "Sales Invoice";
            objfrm.strPreserveSQl = strMysql;
            objfrm.onAddAllButtonClicked = new frmAccountsVoucherList.AddAllClick(DisplayVoucherList);
            objfrm.Show();
            objfrm.MdiParent = MdiParent;
            uctxtRefNo.Focus();
        }
        #endregion
        #region "Celar"
        private void mClear()
        {
            txtCustomerCode.Text = "";
            lstRefTypeNew.Rows.Clear();
            txtRoundOff.Text = "";
            txtHomoeoHall.Text = "";
            uctxtTeritorryName.Text = "";
            uctxtTerritoryCode.Text = "";
            //uctxtLedgerName.Text = "";
            uctxtMedicalRep.Text = "";
            //uctxtBranchName.Text = "";
            uctxtLocation.Text = "Main Location";
            uctxtOrderNo.Text = "";
            uctxtCustomer.Text = "";
            DGAddLess.Rows.Clear();
            dgBillBranch.Rows.Clear();
            DGSalesGrid.Rows.Clear();
            DgCostCenter.Rows.Clear();
            uctxtNarration.Text = "";
            uctxtAdd.Text = "";
            uctxtLess.Text = "";
            lblNetTotal.Text = "";
            uctxtcommission.Text = "";
            lblNetAmount.Text = "";
            lblQuantityTotal.Text = "";
            lblTotalAmount.Text = "";
            uctxtOldRefNo.Text = "";
            uctxtRefType.Text = "";
            DGSalesOrder.Rows.Clear();
            txtTotalItem.Text = "";
            DGSalesOrder.Enabled = true;
            uctxtRefType.Enabled = true  ;
            lblCreditLimit.Text = "0";
            lblCurrentBalance.Text = "0";
            lblPending.Text = "0";

            m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            if (mblnNumbMethod)
            {
                uctxtRefNo.Text = Utility.gstrLastNumber(strComID, (int)intVtype);
                uctxtRefNo.ReadOnly = true;
                uctxtBranchName.Focus();
                uctxtBranchName.Select();
            }
            else
            {

                uctxtRefNo.Text = Utility.gobjNextNumber(uctxtRefNo.Text);
                uctxtRefNo.ReadOnly = false;
                uctxtBranchName.Focus();
                uctxtBranchName.Select();

            } 
           
        }
        private void mClear1()
        {
            txtCustomerCode.Text = "";
            lstRefTypeNew.Rows.Clear();
            txtRoundOff.Text = "";
            txtHomoeoHall.Text = "";
            uctxtTeritorryName.Text = "";
            uctxtTerritoryCode.Text = "";
            //uctxtLedgerName.Text = "";
            uctxtMedicalRep.Text = "";
            //uctxtBranchName.Text = "";
            uctxtLocation.Text = "Main Location";
            uctxtOrderNo.Text = "";
            uctxtCustomer.Text = "";
            DGAddLess.Rows.Clear();
            dgBillBranch.Rows.Clear();
            DGSalesGrid.Rows.Clear();
            DgCostCenter.Rows.Clear();
            uctxtNarration.Text = "";
            uctxtAdd.Text = "";
            uctxtLess.Text = "";
            lblNetTotal.Text = "";
            uctxtcommission.Text = "";
            lblNetAmount.Text = "";
            lblQuantityTotal.Text = "";
            lblTotalAmount.Text = "";
            uctxtOldRefNo.Text = "";
            uctxtRefType.Text = "";
            DGSalesOrder.Rows.Clear();
            txtTotalItem.Text = "";
            DGSalesOrder.Enabled = true;
            uctxtRefType.Enabled = true;
            lblCreditLimit.Text = "0";
            lblCurrentBalance.Text = "0";
            lblPending.Text = "0";

            m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            //if (mblnNumbMethod)
            //{
            //    uctxtRefNo.Text = Utility.gstrLastNumber(strComID, (int)intVtype);
            //    uctxtRefNo.ReadOnly = true;
            //    uctxtBranchName.Focus();
            //    uctxtBranchName.Select();
            //}
            //else
            //{

            //    uctxtRefNo.Text = Utility.gobjNextNumber(uctxtRefNo.Text);
            //    uctxtRefNo.ReadOnly = false;
            //    uctxtBranchName.Focus();
            //    uctxtBranchName.Select();

            //}

        }
        #endregion
        #region "DisplayVoucher"
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
            
                string strAddress;
                
                uctxtOldRefNo.Text = tests[0].strVoucherNo;
                strMysql = tests[0].strPreserveSQL;
                List<AccountsVoucher> ooaccVou = accms.DisplayCompVoucherList(strComID, tests[0].strVoucherNo, intVtype).ToList();
                if (ooaccVou.Count > 0)
                {
                    uctxtRefType.Enabled = false;
                    DGSalesOrder.Enabled = false;
                    foreach (AccountsVoucher oCom in ooaccVou)
                    {
                        textBox1.Text = oCom.strVoucherNo;
                        uctxtRefNo.Text = Utility.Mid(oCom.strVoucherNo, 6, oCom.strVoucherNo.Length - 6);
                        dtePreparedDate.Text = oCom.strPreparedDate;
                       
                        dteDeliveryDate.Text = oCom.strPreparedDate;
                        uctxtBranchName.Text = Utility.gstrGetBranchName(strComID, oCom.strBranchID);
                        strOldBranchName = uctxtBranchName.Text;
                        uctxtNarration.Text = oCom.strNarration;
                        uctxtOrderNo.Text = oCom.strOrderNo;
                        dtePreparedDate.Text = oCom.strTranDate;
                        uctxtPreParedBy.Text = oCom.strPreparedby;
                        dteOrderDateNew.Text = oCom.strOrderDate;
                        uctxtTerritoryCode.Text = oCom.strMerzeName;
                        uctxtLedgerName.Text = Utility.GetSalesLedger(strComID, oCom.strVoucherNo);
                        uctxtMedicalRep.Text = Utility.GetLedgerNameFromMerzeName(strComID, oCom.strLedgerName);
                        mstrOldMedicalName = oCom.strLedgerName;
                        //uctxtTerritoryCode.Text = Utility.GetLedgerNameFromMerzeName(strComID, oCom.strLedgerName);
                        //uctxtTerritoryCode.Text = strTeritoryCode;
                        //string strTeritorryname = Utility.GetTeritorryName(strComID, uctxtTerritoryCode.Text);
                        //uctxtTeritorryName.Text = strTeritorryname;
                        uctxtCustomer.Text = Utility.GetLedgerNameMerze(strComID, oCom.strSalesRepresentive);
                        txtCustomerCode.Text = oCom.strSalesRepresentive;
                        strAddress = Utility.gstrGetLedgerAddress(strComID, uctxtCustomer.Text);
                        txtCustomerAddress.Text = strAddress;
                        //txtCustomerCode.Text = Utility.gGeCustomerCode(strComID, uctxtCustomer.Text);
                        //txtHomoeoHall.Text = Utility.gGeCustomerHooeohall(strComID, uctxtCustomer.Text);
                        uctxtAdd.Text = oCom.dblAddAmount.ToString();
                        uctxtLess.Text = oCom.dblLessAmount.ToString();
                        lblTotalAmount.Text = oCom.dblAmount.ToString();
                        uctxtcommission.Text = oCom.dblProcessAmount.ToString();
                        uctxtcommission.Text = oCom.dblProcessAmount.ToString();
                        lblNetAmount.Text = oCom.dblNetAmount.ToString();
                        txtRoundOff.Text = oCom.dblRoundOff.ToString();
                        mdblNetAmount = oCom.dblNetAmount;
                        //List<AccountsLedger> ooSSalesLedger = accms.DisplaycommonInvoiceVoucher(strComID, tests[0].strVoucherNo).ToList();
                        //if (ooSSalesLedger.Count > 0)
                        //{
                        //    uctxtLedgerName.Text = ooSSalesLedger[0].strLedgerName;
                        //}
                        uctxtLedgerName.Text = "Sales Accounts";

                        long lngdays = Utility.mGetDeliveryDays(strComID, uctxtMedicalRep.Text);
                        dteDeliveryDate.Text = dtePreparedDate.Value.AddDays(lngdays).ToString();
                        //lblCreditLimit.Text = Utility.gdblCreditLimitGrace(strComID, uctxtMedicalRep.Text, dtePreparedDate.Value.ToString("MMMyy"),dtePreparedDate.Text).ToString();
                        lblCreditLimit.Text = Utility.gdblCreditLimit(strComID, uctxtMedicalRep.Text, dtePreparedDate.Value.ToString("MMMyy")).ToString();

                        double dblCls = Utility.dblLedgerClosingBalance(strComID, Utility.gdteFinancialYearFrom.ToString(), Utility.gdteFinancialYearTo.ToString(), uctxtMedicalRep.Text, "");
                        if (dblCls < 0)
                        {
                            lblCurrentBalance.Text = Math.Abs(dblCls) + "Dr";
                        }
                        else
                        {
                            lblCurrentBalance.Text = Math.Abs(dblCls) + "Cr";
                        }
                        if (lblCreditLimit.Text != "0")
                        {
                            string strFDate = Utility.FirstDayOfMonth(dtePreparedDate.Value).ToString();
                            //double dblLedgerClosing = Utility.dblLedgerClosingBalance(strComID, strFDate, dtePreparedDate.Text, uctxtMedicalRep.Text, "");
                            lblPending.Text = Math.Round(Utility.Val(lblCreditLimit.Text) - Math.Abs(dblCls), 2).ToString();
                            DGMr.Visible = false;
                        }

                        List<AccBillwise> ooVouList = accms.DisplayCommonInvoice(strComID, tests[0].strVoucherNo).ToList();
                        if (ooVouList.Count > 0)
                        {

                            foreach (AccBillwise oacc in ooVouList)
                            {
                                uctxtLocation.Text = oacc.strGodownsName;
                                DGSalesGrid.Rows.Add();
                                DGSalesGrid[0, introw].Value = oacc.strBillKey;
                                DGSalesGrid[1, introw].Value = oacc.strStockGroupName;
                                DGSalesGrid[2, introw].Value = oacc.strStockItemName;
                                DGSalesGrid[3, introw].Value = Utility.mGetPowerClass(strComID, oacc.strStockItemName);
                                DGSalesGrid[4, introw].Value = Utility.mGetPackSize(strComID, oacc.strStockItemName);
                                //DGSalesGrid[5, introw].Value = oacc.strDescription;
                                DGSalesGrid[5, introw].Value = oacc.dblQnty;
                                DGSalesGrid[6, introw].Value = oacc.dblRate;
                                DGSalesGrid[7, introw].Value = oacc.strPer;
                                DGSalesGrid[8, introw].Value = oacc.dblAmount;
                                DGSalesGrid[9, introw].Value = oacc.strBillAddless;
                                DGSalesGrid[10, introw].Value = oacc.dblBillNetAmount; 
                                DGSalesGrid[11, introw].Value = oacc.strBatchNo;
                                DGSalesGrid[12, introw].Value = oacc.dblBonusQnty;
                                DGSalesGrid[13, introw].Value = oacc.dblShortQty;
                                DGSalesGrid[15, introw].Value = Utility.mGetStockGroupFromItemGroup(strComID, oacc.strStockGroupName);
                                DGSalesGrid[14, introw].Value = "Delete";
                                DGSalesGrid[16, introw].Value = oacc.dblComm;
                                DGSalesGrid[17, introw].Value = oacc.strAgnstVoucherRefNo;
                                //DGSalesOrder.AllowUserToAddRows = false;
                                introw += 1;
                            }
                            txtTotalItem.Text = "Total Item :" + introw;
                            DGSalesGrid.AllowUserToAddRows = false;
                            introw = 0;
                            List<AccBillwise> ooOrder = accms.DisplaycommonInvoiceOrder(strComID, tests[0].strVoucherNo, intVtype).ToList();
                            if (ooOrder.Count > 0)
                            {
                                foreach (AccBillwise oaccOrder in ooOrder)
                                {
                                    DGSalesOrder.Rows.Add();
                                    DGSalesOrder[0, introw].Value = oaccOrder.strBillKey;
                                    DGSalesOrder[1, introw].Value = Utility.Mid(oaccOrder.strRefNo,6,oaccOrder.strRefNo.Length-6);
                                    DGSalesOrder[2, introw].Value = oaccOrder.strDate;
                                    DGSalesOrder[3, introw].Value = "Delete";
                                    uctxtRefType.Text = oaccOrder.strRefType;
                                    introw += 1;
                                }
                            }
                            else
                            {
                                uctxtRefType.Text = Utility.gcEND_OF_LIST;
                            }
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
                                   
                                    if (ooBill.strLedgerName != "Round Off")
                                    {
                                        DGAddLess.Rows.Add();
                                        DGAddLess.Rows[i].Cells[0].Value = ooBill.strLedgerName;
                                        DGAddLess.Rows[i].Cells[1].Value = ooBill.strAddlessSign;
                                        DGAddLess.Rows[i].Cells[2].Value = Math.Abs(ooBill.dblDebitAmount + ooBill.dblCreditAmount);
                                        i += 1;
                                    }
                                    
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
        private void SearchListView(IEnumerable<StockItem> tests, string searchString = "")
        {
            IEnumerable<StockItem> query;
            //if ((searchString.Length > 0))
            //{
            query = tests;

            //if (chkVoucheNo.Checked == true)
            //{
            if (searchString != "")
            {
                //query = tests.Where(x => x.strItemName.ToLower().Trim().Contains(searchString.ToLower().Trim()));
                query = (from test in tests
                         where test.strItemName.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
                         select test);
            }
            //}
            //else if (chkEntryby.Checked)
            //{
            //query = (from test in tests
            //         where test.entryby.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
            //         select test);

            //}

            //else if (chkAmount.Checked)
            //{
            //    query = (from test in tests
            //             where test.dblNetDebitAmount.ToString().StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
            //             select test);
            //}
            ucdgList.Rows.Clear();
            int i = 0;
            try
            {
                foreach (StockItem tran in query)
                {
                    ucdgList.Rows.Add();
                    ucdgList[0, i].Value = tran.strItemName;
                    if (tran.dblClsBalance > 0)
                    {
                        ucdgList[1, i].Value = tran.dblClsBalance + " " + tran.strUnit;
                    }
                    else
                    {
                        ucdgList[1, i].Value = 0 + " " + tran.strUnit;
                    }
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

        private void uctxtItemName_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                //if (uctxtItemName.Text != "")
                //{
                    SearchListView(oogrp, uctxtItemName.Text);

                //}

            }
            catch (Exception ex)
            {

            }

        }
        #endregion

        private void btnAddCancel_Click(object sender, EventArgs e)
        {
            pnlAddLess.Visible = false;
            uctxtItemName.Focus();
        }

      

        private void DGAddLess_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            double dblTotalCommissionMinus = 0, dblTotalCommissionPlus = 0;
            if (e.ColumnIndex == 3)
            {
                DGAddLess.Rows.RemoveAt(e.RowIndex);

                for (int introw = 0; introw < DGAddLess.Rows.Count; introw++)
                {
                    if (DGAddLess[0, introw].Value != "")
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
                }
                uctxtAdd.Text = dblTotalCommissionPlus.ToString();
                uctxtLess.Text = dblTotalCommissionMinus.ToString();
                lblNetAmount.Text = (Utility.Val(lblTotalAmount.Text) + Utility.Val(uctxtAdd.Text) - (Utility.Val(uctxtLess.Text) + Utility.Val(uctxtcommission.Text))).ToString();
               

            }
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }
        #region "Keyup"
        private void uctxtTerritoryCode_KeyUp(object sender, KeyEventArgs e)
        {
            SearchListViewPartyName(ooPartyName, uctxtTerritoryCode.Text);
        }

        private void SearchListViewPartyName(IEnumerable<Invoice> tests, string searchString = "")
        {
            IEnumerable<Invoice> query;
            //if ((searchString.Length > 0))
            //{
            query = tests;

            //if (chkVoucheNo.Checked == true)
            //{
            if (searchString != "")
            {
                query = tests.Where(x => x.strMereString.ToLower().Trim().Contains(searchString.ToLower().Trim()));
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
            DGMr.Rows.Clear();
            int i = 0;
            try
            {
                foreach (Invoice tran in query)
                {
                    DGMr.Rows.Add();
                    DGMr[0, i].Value = tran.strTeritorryCode;
                    //DGMr[1, i].Value = tran.strTeritorryName;
                    DGMr[1, i].Value = tran.strLedgerName;
                    DGMr[2, i].Value = tran.strTeritorryName;
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


        private void uctxtCustomer_KeyUp(object sender, KeyEventArgs e)
        {
            SearchListViewCustomerName(ooCustomer, uctxtCustomer.Text);
           
        }

        private void SearchListViewCustomerName(IEnumerable<Invoice> tests, string searchString = "")
        {
            IEnumerable<Invoice> query;
            if (tests == null)
            {
                return;
            }
            //if ((searchString.Length > 0))
            //{
            query = tests;

            //if (chkVoucheNo.Checked == true)
            //{
            if (searchString != "")
            {
                query = tests.Where(x => x.strMereString.ToLower().Trim().Contains(searchString.ToLower().Trim()));
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
            DGcustomer.Rows.Clear();
            int i = 0;
            try
            {
                foreach (Invoice tran in query)
                {
                    DGcustomer.Rows.Add();
                    DGcustomer[0, i].Value = tran.strTeritorryCode;
                    DGcustomer[2, i].Value = tran.strTeritorryName;
                    DGcustomer[1, i].Value = tran.strLedgerName;
                    DGcustomer[3, i].Value = tran.strMereString;
                    //if (i % 2 == 0)
                    //{
                    //    DGcustomer.Rows[i].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    DGcustomer.Rows[i].DefaultCellStyle.BackColor = Color.White;
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

        private void btnAddLessApply_Click_1(object sender, EventArgs e)
        {

        }

        private void DGAddLess_KeyPress(object sender, KeyPressEventArgs e)
        {
            double dblTotalCommissionMinus = 0, dblTotalCommissionPlus = 0;
            if (e.KeyChar==(char)Keys.Return)
            {
                
                if (DGAddLess[0, 1].Value.ToString() != "")
                {
                    for (int introw = 0; introw <= DGAddLess.Rows.Count - 1; introw++)
                    {
                        if (DGAddLess[2, introw].Value != "")
                        {
                            if (Utility.Left(Utility.Val(DGAddLess[2, introw].Value.ToString()).ToString(), 1) == "-")
                            {
                                dblTotalCommissionMinus = dblTotalCommissionMinus + Utility.Val(DGAddLess[2, introw].Value.ToString());
                            }
                            else
                            {
                                dblTotalCommissionPlus = dblTotalCommissionPlus + Utility.Val(DGAddLess[2, introw].Value.ToString());
                            }
                        }
                    }
                }
                else
                {
                    uctxtAdd.Text = dblTotalCommissionPlus.ToString();
                    uctxtLess.Text = dblTotalCommissionMinus.ToString();
                    lblNetAmount.Text = (Utility.Val(lblTotalAmount.Text) + Utility.Val(uctxtAdd.Text) - (Utility.Val(uctxtLess.Text) + Utility.Val(uctxtcommission.Text))).ToString();
                }
            }
        }

        private void txtRefTypeNew_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                string searchString = "";
                if (txtRefTypeNew.Text != "")
                {
                    searchString = txtRefTypeNew.Text.Trim();
                    if (searchString == string.Empty || searchString.Length > 20)
                    {
                        //MessageBox.Show("Enter Valid Consumer Number..!");
                    }
                    else
                    {
                        foreach (DataGridViewRow row in lstRefTypeNew.Rows)
                        {
                            if (row.Cells[1].Value.ToString().Contains(searchString))
                            {
                                lstRefTypeNew.ClearSelection();
                                lstRefTypeNew.CurrentRow.Selected = true;
                                lstRefTypeNew.Rows[row.Index].Selected = true;
                                int index = row.Index;
                                lstRefTypeNew.FirstDisplayedScrollingRowIndex = index;
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void DGSalesOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==3)
            {
                DGSalesOrder.Rows.RemoveAt(e.RowIndex);
                txtRefTypeNew_LostFocus(sender, e);
                calculateTotal();
            }
        }

        private void DGSalesGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGSalesGrid.Rows.Count > 0)
            {
                var strResponseInsert = MessageBox.Show("Do You  want to Modify this Item?" + "(" + DGSalesGrid.CurrentRow.Cells[2].Value.ToString() + ")", "Modify Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    uctxtGroupName.Text = DGSalesGrid.CurrentRow.Cells[1].Value.ToString();
                    uctxtItemName.Text = DGSalesGrid.CurrentRow.Cells[2].Value.ToString();
                    uctxtQty.Text = DGSalesGrid.CurrentRow.Cells[5].Value.ToString();
                    uctxtRate.Text = DGSalesGrid.CurrentRow.Cells[6].Value.ToString();
                    uctxtShortQty.Text = DGSalesGrid.CurrentRow.Cells[13].Value.ToString();
                    txtRowIndex.Text = e.RowIndex.ToString();
                    DGSalesGrid.CurrentRow.Cells[0].Value = "";
                    DGSalesGrid.CurrentRow.Cells[1].Value = "";
                    DGSalesGrid.CurrentRow.Cells[2].Value = "";
                    DGSalesGrid.CurrentRow.Cells[3].Value = "";
                    DGSalesGrid.CurrentRow.Cells[4].Value = "";
                    DGSalesGrid.CurrentRow.Cells[5].Value = "";
                    DGSalesGrid.CurrentRow.Cells[6].Value = "";
                    DGSalesGrid.CurrentRow.Cells[7].Value = "";
                    DGSalesGrid.CurrentRow.Cells[8].Value = "";
                    DGSalesGrid.CurrentRow.Cells[9].Value = "";
                    DGSalesGrid.CurrentRow.Cells[10].Value = "";
                    DGSalesGrid.CurrentRow.Cells[11].Value = "";
                    DGSalesGrid.CurrentRow.Cells[12].Value = "";
                    DGSalesGrid.CurrentRow.Cells[13].Value = "";
                    DGSalesGrid.CurrentRow.Cells[15].Value = "";
                    DGSalesGrid.CurrentRow.Cells[16].Value = "";
                    DGSalesGrid.CurrentRow.Cells[17].Value = "";

                    //DGSalesGrid.Rows.RemoveAt(e.RowIndex);
                    uctxtGroupName.Focus();
                }
            }
        }

       




    }
}
