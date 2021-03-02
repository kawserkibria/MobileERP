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

namespace JA.Modulecontrolar.UI.Sales.Forms
{
    public partial class frmSalesReturn : JA.Shared.UI.frmSmartFormStandard
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();


        public long lngFormPriv { get; set; }
        public string  strFormName { get; set; }
        public int intModuletype { get; set; }
        private bool mblnNumbMethod { get; set; }
        private int mintIsPrin { get; set; }

        private ListBox lstPartyName = new ListBox();
        private ListBox lstBranchName = new ListBox();
        private ListBox lstLocation = new ListBox();
        private ListBox lstRefType = new ListBox();
        public ListBox lstBatch = new ListBox();
        private ListBox lstSalesLedger = new ListBox();
        private ListBox lstAddlessLedger = new ListBox();
        private ListBox lstCostCategory = new ListBox();
        private ListBox lstCostCenter = new ListBox();
        private ListBox lstTypeofRef = new ListBox();
        private ListBox lstcustomer = new ListBox();
        
        List<StockItem> oogrp;
        List<AccBillwise> ooRefNo;
        List<Invoice> ooPartyName;
        List<Invoice> ooCustomer;
        private string strPreserveSQl { get; set; }
        public int lngLedgeras { get; set; }
        public int m_action { get; set; }
        public int intVtype { get; set; }
        List<InvoiceConfig> oinv;
        private string strComID { get; set; }
        public frmSalesReturn()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            #region "User IN"
            this.btnBillapply.Click += new System.EventHandler(this.btnBillapply_Click);
            this.btnBillCancel.Click += new System.EventHandler(this.btnBillCancel_Click);

            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.uctxtRefNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtRefNo_KeyPress);
            this.uctxtRefNo.GotFocus += new System.EventHandler(this.uctxtRefNo_GotFocus);

            this.uctxtBonusReturn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBonusReturn_KeyPress);
            this.uctxtBonusReturn.GotFocus += new System.EventHandler(this.uctxtBonusReturn_GotFocus);


            this.dteDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteDate_KeyPress);
            this.dteDate.GotFocus += new System.EventHandler(this.dteDate_GotFocus);

            this.dteDuedate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteDuedate_KeyPress);
            this.dteDuedate.GotFocus += new System.EventHandler(this.dteDuedate_GotFocus);

            this.uctxtPartyName.KeyDown += new KeyEventHandler(uctxtPartyName_KeyDown);
            this.uctxtPartyName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtPartyName_KeyPress);
            this.uctxtPartyName.TextChanged += new System.EventHandler(this.uctxtPartyName_TextChanged);
            //this.lstPartyName.DoubleClick += new System.EventHandler(this.lstPartyName_DoubleClick);
            this.uctxtPartyName.GotFocus += new System.EventHandler(this.uctxtPartyName_GotFocus);

            this.DGMr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(DGMr_KeyPress);
            this.DGMr.DoubleClick += new System.EventHandler(this.DGMr_DoubleClick);


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

            this.uclstGrdItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uclstGrdItem_KeyPress);
            this.uclstGrdItem.DoubleClick += new System.EventHandler(this.uclstGrdItem_DoubleClick);

            this.uctxtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtQty_KeyPress);
            this.uctxtQty.GotFocus += new System.EventHandler(this.uctxtQty_GotFocus);
            this.uctxtQty.TextChanged += new System.EventHandler(this.uctxtQty_TextChanged);

            this.uctxtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtRate_KeyPress);
            this.uctxtRate.GotFocus += new System.EventHandler(this.uctxtRate_GotFocus);
            this.uctxtRate.TextChanged += new System.EventHandler(this.uctxtRate_TextChanged);

            this.uctxtBatch.KeyDown += new KeyEventHandler(uctxtBatch_KeyDown);
            this.uctxtBatch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBatch_KeyPress);
            this.uctxtBatch.TextChanged += new System.EventHandler(this.uctxtBatch_TextChanged);
            this.lstBatch.DoubleClick += new System.EventHandler(this.lstBatch_DoubleClick);
            this.uctxtBatch.GotFocus += new System.EventHandler(this.uctxtBatch_GotFocus);

            this.uctxtSalesLedger.KeyDown += new KeyEventHandler(uctxtSalesLedger_KeyDown);
            this.uctxtSalesLedger.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtSalesLedger_KeyPress);
            this.uctxtSalesLedger.TextChanged += new System.EventHandler(this.uctxtSalesLedger_TextChanged);
            this.lstSalesLedger.DoubleClick += new System.EventHandler(this.lstSalesLedger_DoubleClick);
            this.uctxtSalesLedger.GotFocus += new System.EventHandler(this.uctxtSalesLedger_GotFocus);

            this.btnAddLessApply.Click += new System.EventHandler(this.btnAddLessApply_Click);
            this.btnAddLessCancel.Click += new System.EventHandler(this.btnAddLessCancel_Click);

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

            this.uctxtNarration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtNarration_KeyPress);
            this.uctxtNarration.GotFocus += new System.EventHandler(this.uctxtNarration_GotFocus);
            this.DGAddLess.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGAddLess_CellContentClick);

            this.txtCustomer.KeyDown += new KeyEventHandler(txtCustomer_KeyDown);
            this.txtCustomer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtCustomer_KeyPress);
            this.txtCustomer.TextChanged += new System.EventHandler(txtCustomer_TextChanged);
            //this.lstPartyName.DoubleClick += new System.EventHandler(this.lstPartyName_DoubleClick);
            this.txtCustomer.GotFocus += new System.EventHandler(this.txtCustomer_GotFocus);
            this.lstcustomer.DoubleClick += new System.EventHandler(this.lstcustomer_DoubleClick);

            this.DGMr.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGMr_CellFormatting);
            this.lstRefTypeNew.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.lstRefTypeNew_CellFormatting);

            this.uclstGrdItem.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.uclstGrdItem_CellFormatting);

            //Utility.CreateListBox(lstPartyName, pnlMain, uctxtPartyName);
            Utility.CreateListBox(lstBranchName, pnlMain,uctxtBranchName);
            Utility.CreateListBox(lstLocation, pnlMain, uctxtLocation);
            Utility.CreateListBox(lstRefType, pnlMain, uctxtRefType);
            Utility.CreateListBox(lstBatch, panel2, uctxtBatch);
            Utility.CreateListBox(lstSalesLedger, pnlMain, uctxtSalesLedger);
            Utility.CreateListBox(lstAddlessLedger, pnlAddLess, uctxtAddleddLedger);
            Utility.CreateListBox(lstTypeofRef, pnlBillWise, uctxtTypeofRef);
            Utility.CreateListBox(lstCostCategory, pnlCostCenter, uctxtCostCategory);
            Utility.CreateListBox(lstCostCenter, pnlCostCenter, uctxtCostCenter);
            Utility.CreateListBox(lstcustomer, pnlMain, txtCustomer);
            #endregion
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
        #region "Calculatetotal
        private void calculateTotal()
        {
            double dblTotalQnty = 0, dblTotalAmount = 0;
            int introw = 0;

           
            //lblNetAmount.Text = (Utility.Val(lblTotalAmount.Text) + Utility.Val(uctxtAdd.Text) - Utility.Val(uctxtLess.Text)).ToString();


            for (int i = 0; i < DGSalesGrid.Rows.Count; i++)
            {
                if (DGSalesGrid.Rows[i].Cells[1].Value != null)
                {
                    dblTotalQnty = dblTotalQnty + Utility.Val(DGSalesGrid.Rows[i].Cells[2].Value.ToString());
                    dblTotalAmount = dblTotalAmount + Utility.Val(DGSalesGrid.Rows[i].Cells[5].Value.ToString());
                    introw += 1;
                }
            }
            txtTotalItem.Text = "Total Item: " + introw.ToString();
            lblQuantityTotal.Text = dblTotalQnty.ToString();
            lblTotalAmount.Text = dblTotalAmount.ToString();
            lblNetAmount.Text = ((dblTotalAmount + Utility.Val(uctxtAdd.Text)) - Utility.Val(uctxtLess.Text)).ToString();

        }
        #endregion
        #region "User Define"

        private void txtCustomer_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstRefType.Visible = false;
            lstBatch.Visible = false;
            lstAddlessLedger.Visible = false;
            lstCostCategory.Visible = false;
            lstCostCenter.Visible = false;
            uclstGrdItem.Visible = false;
            lstcustomer.Visible = true;
            DGMr.Visible = false;
        }
        private void txtCustomer_TextChanged(object sender, EventArgs e)
        {
            lstcustomer.SelectedIndex = lstcustomer.FindString(txtCustomer.Text);
        }

        private void lstcustomer_DoubleClick(object sender, EventArgs e)
        {
            txtCustomer.Text = lstcustomer.Text;
            uctxtRefType.Focus();
            lstcustomer.Visible = false;
        }

        private void txtCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtCustomer.Text!="")
                {
                    txtCustomer.Text = lstcustomer.Text;
                }
                else
                {
                    txtCustomer.Text = Utility.gcEND_OF_LIST;
                }
                lstcustomer.Visible = false;
                uctxtRefType.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                //PriorSetFocusText(uctxtCostCenter, sender, e);
            }
        }
        private void txtCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstcustomer.SelectedItem != null)
                {
                    lstcustomer.SelectedIndex = lstcustomer.SelectedIndex - 1;
                    txtCustomer.Text = lstcustomer.Text;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstcustomer.Items.Count - 1 > lstcustomer.SelectedIndex)
                {
                    lstcustomer.SelectedIndex = lstcustomer.SelectedIndex + 1;
                    txtCustomer.Text = lstcustomer.Text;
                }
            }

        }
        //*********
        private void lstRefTypeNew_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            lstRefTypeNew.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Yellow;
            lstRefTypeNew.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            lstRefTypeNew.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("verdana", 9);
        }
        private void uclstGrdItem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            uclstGrdItem.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Yellow;
            uclstGrdItem.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            uclstGrdItem.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("verdana", 9);
        }
        private void DGMr_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DGMr.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Yellow;
            DGMr.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            DGMr.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("verdana", 9);
        }
        private void uctxtBonusReturn_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstRefType.Visible = false;
            lstBatch.Visible = false;
            lstAddlessLedger.Visible = false;
            lstCostCategory.Visible = false;
            lstCostCenter.Visible = false;
            uclstGrdItem.Visible = false;
            lstcustomer.Visible = false;
            DGMr.Visible = false;
        }

      private void uctxtBonusReturn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtBatch.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtBonusReturn, uctxtRate);
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
                //pnlCostCenter.Size = new Size(695, 269);
                pnlCostCenter.Location = new Point(206, 181);
                //pnlCostCenter.Top = uctxtBranchName.Top + 10;
                //pnlCostCenter.Left = uctxtQty.Left;
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
       

     
        private void txtBillRefNo_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstRefType.Visible = false;
            lstBatch.Visible = false;

            lstAddlessLedger.Visible = false;
            lstTypeofRef.Visible = false;
            lstCostCategory.Visible = false;
            lstCostCenter.Visible = false;
            uclstGrdItem.Visible = false;
            lstcustomer.Visible = false;
            DGMr.Visible = false;
        }


        private void txtRefTypeNew_KeyDown(object sender, KeyEventArgs e)
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
            return;


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
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtAmount, sender, e);
            }

        }
        private void uctxtAmount_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstRefType.Visible = false;
            lstBatch.Visible = false;
            lstAddlessLedger.Visible = false;
            lstCostCategory.Visible = false;
            lstCostCenter.Visible = false;
            uclstGrdItem.Visible = false;
            lstcustomer.Visible = false;
            DGMr.Visible = false;

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
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtCostCenter, sender, e);
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
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstRefType.Visible = false;
            lstBatch.Visible = false;
            lstAddlessLedger.Visible = false;
            lstCostCategory.Visible = false;
            lstCostCenter.Visible = true;
            uclstGrdItem.Visible = false;
            lstcustomer.Visible = false;
            DGMr.Visible = false;
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
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtCostCategory, sender, e);
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
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstRefType.Visible = false;
            lstBatch.Visible = false;
            lstAddlessLedger.Visible = false;
            lstCostCategory.Visible = true;
            uclstGrdItem.Visible = false;
            lstcustomer.Visible = false;
            DGMr.Visible = false;
            lstCostCategory.SelectedIndex = lstCostCategory.FindString(uctxtCostCategory.Text);

        }
        private void txtInte_KeyPress(object sender, KeyPressEventArgs e)
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
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(txtBillAmount, sender, e);
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
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtTypeofRef, sender, e);
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
            lstcustomer.Visible = false;
            DGMr.Visible = false;
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
                selRaw = Convert.ToInt16(dgBillBranch.RowCount.ToString());
                selRaw = selRaw - 1;
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
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstRefType.Visible = false;
            lstBatch.Visible = false;
            lstAddlessLedger.Visible = false;
            uclstGrdItem.Visible = false;
            lstcustomer.Visible = false;
            DGMr.Visible = false;
        }
        private void ucttAddlessSymbol_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstRefType.Visible = false;
            uclstGrdItem.Visible = false;
            lstBatch.Visible = false;
            lstcustomer.Visible = false;
            lstAddlessLedger.Visible = false;
            DGMr.Visible = false;
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
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstRefType.Visible = false;
            lstBatch.Visible = false;
            uclstGrdItem.Visible = false;
            lstcustomer.Visible = false;
            //lstAddlessLedger.Visible = false;
            DGMr.Visible = false;
            lstAddlessLedger.ValueMember = "strLedgerName";
            lstAddlessLedger.DisplayMember = "strLedgerName";
            lstAddlessLedger.DataSource = invms.mfillLedgerInvoice(strComID, false, lngLedgeras,"").ToList();

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
                    else
                    {
                        dblTotalCommissionPlus = dblTotalCommissionPlus + Utility.Val(DGAddLess[2, introw].Value.ToString());
                    }
                }
            }

            uctxtAdd.Text = dblTotalCommissionPlus.ToString();
            uctxtLess.Text = dblTotalCommissionMinus.ToString();
            lblNetAmount.Text = (Utility.Val(lblTotalAmount.Text) + Utility.Val(uctxtAdd.Text) - Utility.Val(uctxtLess.Text)).ToString();

            pnlCostCenter.Visible = false;
            if (Utility.mblnBillWise(strComID, uctxtPartyName.Text) == true)
            {
                pnlBillWise.Visible = true;
                pnlBillWise.Top = uctxtQty.Top + 60;
                pnlBillWise.Left = uctxtItemName.Left + 80;
                pnlBillWise.Size = new Size(711, 301);
                txtBillLedger.Text = uctxtPartyName.Text;
                txtBillRefNo.Text = uctxtRefNo.Text;

                txtBillDrcr.Text = "Dr";
                txtBillPreTotal.Text = lblTotalAmount.Text;
                txtBillAmount.Text = lblTotalAmount.Text;
                txtComm.Text = "0";
                txtInte.Text = "0";
                lblBillWise.Text = "Bill Wise Details for " + uctxtPartyName.Text;
                uctxtTypeofRef.Focus();
            }

            if (pnlBillWise.Visible == false)
            {
                if (Utility.gbcheckCostCenter(strComID, uctxtPartyName.Text) == true)
                {
                    pnlCostCenter.Visible = true;
                    uctxtCostCategory.Focus();
                    pnlCostCenter.Top = uctxtBranchName.Top + 10;
                    pnlCostCenter.Left = uctxtQty.Left;
                    pnlBillWise.Size = new Size(711, 301);
                    btnApply.Top = DgCostCenter.Height + 70;
                    btnCancel.Top = DgCostCenter.Height + 70;
                    uctxtAmount.Text = (Utility.Val(lblTotalAmount.Text)).ToString();
                    txtpreAmount.Text = lblTotalAmount.Text;
                    txtLedgerName.Text = strLegderName;
                }
            }

            if (pnlBillWise.Visible == false && pnlCostCenter.Visible == false)
            {
                btnSave.Focus();
            }
        }
     
        private void uctxtSalesLedger_TextChanged(object sender, EventArgs e)
        {
            lstSalesLedger.SelectedIndex = lstSalesLedger.FindString(uctxtSalesLedger.Text);
        }

        private void lstSalesLedger_DoubleClick(object sender, EventArgs e)
        {
            uctxtSalesLedger.Text = lstSalesLedger.Text;
            lblSupplierCB.Text = Utility.gstrLedgerBalance(strComID, uctxtSalesLedger.Text);
            uctxtPartyName.Focus();
            lstSalesLedger.Visible = false;
        }

        private void uctxtSalesLedger_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstSalesLedger.Items.Count > 0)
                {
                    uctxtSalesLedger.Text = lstSalesLedger.Text;
                    lblSupplierCB.Text = Utility.gstrLedgerBalance(strComID, uctxtSalesLedger.Text);
                }
                uctxtPartyName.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtSalesLedger, uctxtRefNo);
            }
        }
        private void uctxtSalesLedger_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstSalesLedger.SelectedItem != null)
                {
                    lstSalesLedger.SelectedIndex = lstSalesLedger.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstSalesLedger.Items.Count - 1 > lstSalesLedger.SelectedIndex)
                {
                    lstSalesLedger.SelectedIndex = lstSalesLedger.SelectedIndex + 1;
                }
            }

        }

        private void uctxtSalesLedger_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstBatch.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstRefType.Visible = false;
            uclstGrdItem.Visible = false;
            lstSalesLedger.Visible = true;
            lstcustomer.Visible = false;
            DGMr.Visible = false;
            if (intVtype == (long)Utility.VOUCHER_TYPE.vtSALES_RETURN)
            {
                lstSalesLedger.ValueMember = "strSalesLedger";
                lstSalesLedger.DisplayMember = "strSalesLedger";
                lstSalesLedger.DataSource = invms.gFillSalesLedger(strComID, (long)Utility.GR_GROUP_TYPE.grSALES).ToList();
            }
            else
            {
                lstSalesLedger.ValueMember = "strPurchaseLedger";
                lstSalesLedger.DisplayMember = "strPurchaseLedger";
                lstSalesLedger.DataSource = invms.gFillPurchaseLedger(strComID).ToList();
            }
            lstSalesLedger.SelectedIndex = lstSalesLedger.FindString(uctxtSalesLedger.Text);
        }

        private void uctxtNarration_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstBatch.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstRefType.Visible = false;
            lstSalesLedger.Visible = false;
            uclstGrdItem.Visible = false;
            lstcustomer.Visible = false;
            DGMr.Visible = false;
        }
        private void uctxtNarration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                //uctxtAddleddLedger.Focus();
                //pnlAddLess.Visible = true;
                //pnlAddLess.Location = new Point(380, 364);
                //pnlAddLess.Size = new Size(500, 280);
                //uctxtAddleddLedger.Focus();
                btnSave.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtNarration, uctxtBatch);
            }
        }
        private void uctxtBatch_TextChanged(object sender, EventArgs e)
        {
            lstBatch.SelectedIndex = lstBatch.FindString(uctxtBatch.Text);
        }

        private void lstBatch_DoubleClick(object sender, EventArgs e)
        {
            uctxtBatch.Text = lstBatch.Text;
            addItem();
            uctxtItemName.Focus();
        }

        private void uctxtBatch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBatch.Items.Count > 0)
                {
                    uctxtBatch.Text = lstBatch.Text;
                }
                addItem();
                uctxtItemName.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtBatch, uctxtBonusReturn);
            }
        }
        private void addItem()
        {
            string  strUOM = "";
            //double dblDis = 0;

            if (uctxtItemName.Text != "")
            {
                if (uctxtItemName.Text != "")
                {
                    strUOM = Utility.gGetBaseUOM(strComID, uctxtItemName.Text);
                    //strItemDescription = Utility.mGetItemDescription(uctxtItemName.Text);
                    mAddStockItem(uctxtItemName.Text,Utility.Val(uctxtBonusReturn.Text), Utility.Val(uctxtQty.Text), Utility.Val(uctxtRate.Text), strUOM, uctxtBatch.Text);
                    uctxtItemName.Focus();
                }
            }

        }

        private void mAddStockItem(string strItemName,double dblBonusQty,  double dblQty, double dblRate, string strUom, string strBatch)
        {
            int selRaw;

            string strDown = "";
            Boolean blngCheck = false;
            for (int j = 0; j < DGSalesGrid.RowCount; j++)
            {
                if (DGSalesGrid[0, j].Value != null)
                {
                    strDown = DGSalesGrid[0, j].Value.ToString();
                }
                if (strItemName == strDown.ToString())
                {
                    blngCheck = true;
                }

            }
            if (blngCheck == false)
            {

                DGSalesGrid.AllowUserToAddRows = true;
                selRaw = Convert.ToInt16(DGSalesGrid.RowCount.ToString());
                selRaw = selRaw - 1;
                DGSalesGrid.Rows.Add();
               
                //DgCostCenter[0, selRaw].Value = strBranchName.ToString();
                DGSalesGrid[1, selRaw].Value = strItemName.ToString();
                DGSalesGrid[2, selRaw].Value = dblQty.ToString();
                DGSalesGrid[3, selRaw].Value = dblRate.ToString();
                DGSalesGrid[4, selRaw].Value = strUom;
                DGSalesGrid[5, selRaw].Value = (dblQty * dblRate);
                DGSalesGrid[6, selRaw].Value = dblBonusQty;
                DGSalesGrid[8, selRaw].Value = "Delete";
                if (strBatch != Utility.gcEND_OF_LIST)
                {
                    DGSalesGrid[7, selRaw].Value = strBatch;
                }
                else
                {
                    DGSalesGrid[7, selRaw].Value = "";
                }
                uctxtItemName.Text = "";
                uctxtQty.Text = "";
                uctxtRate.Text = "";
                uctxtBatch.Text = "";
                uctxtBonusReturn.Text = "";
                DGSalesGrid.AllowUserToAddRows = false;
                calculateTotal();
                DGSalesGrid.ClearSelection();
                int nColumnIndex = 2;
                int nRowIndex = DGSalesGrid.Rows.Count - 1;
                DGSalesGrid.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;
                DGSalesGrid.FirstDisplayedScrollingRowIndex = nRowIndex;
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
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstRefType.Visible = false;
            lstBatch.Visible = true;
            lstSalesLedger.Visible = false;
            uclstGrdItem.Visible = false;
            DGMr.Visible = false;
            lstcustomer.Visible = false;
            lstBatch.ValueMember = "Key";
            lstBatch.DisplayMember = "Value";
            lstBatch.DataSource = invms.mFillBatch(strComID).ToList();

            lstBatch.SelectedIndex = lstBatch.FindString(uctxtBatch.Text);
        }

        private void uctxtRate_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstBatch.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstSalesLedger.Visible = false;
            DGMr.Visible = false;
            lstcustomer.Visible = false;
        }

        private void uctxtQty_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstRefType.Visible = false;
            lstBatch.Visible = false;
            lstSalesLedger.Visible = false;
            uclstGrdItem.Visible = false;
            DGMr.Visible = false;
            lstcustomer.Visible = false;
        }
        private void uctxtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            double dblrate = 0, dblBonus = 0;
            if (e.KeyChar == (char)Keys.Return)
            {
                if (intVtype == (int)Utility.VOUCHER_TYPE.vtSALES_RETURN)
                {
                    dblrate = Utility.gdblGetEnterpriseSalesPrice(strComID, uctxtItemName.Text, dteDate.Text, Utility.Val(uctxtQty.Text.ToString()), 0, "");
                    dblBonus = Math.Round(Utility.mdblGetBonus(strComID, uctxtItemName.Text, Utility.gstrGetBranchID(strComID, uctxtBranchName.Text), Utility.Val(uctxtQty.Text.ToString()), dteDate.Text), 2);
                    uctxtBonusReturn.Text = dblBonus.ToString();
                    uctxtRate.Text = dblrate.ToString();
                    //uctxtBonusReturn.Text = "0";
                    uctxtRate.Focus();
                }
                else
                {

                    dblrate = Utility.gdblPurchasePrice(strComID, uctxtItemName.Text, dteDate.Text, uctxtLocation.Text);
                    uctxtRate.Text = dblrate.ToString();
                    uctxtBonusReturn.Text = "0";
                    uctxtRate.Focus();
                }
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtQty, uctxtItemName);
            }
        }
        private void uctxtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtBonusReturn.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtRate, uctxtQty);
            }
        }


        private void uctxtItemName_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstBatch.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstRefType.Visible = false;
            lstSalesLedger.Visible = false;
            uclstGrdItem.Visible = false;
            DGMr.Visible = false;
            lstcustomer.Visible = false;
        }
        private void mLoadAllItemStock()
        {
            int introw = 0;

            //oogrp = invms.gFillStockItem(uctxtLocation.Text, "", false).ToList();
            if (intVtype == (int)Utility.VOUCHER_TYPE.vtSALES_RETURN)
            {
                oogrp = invms.mloadAddStockItemFg(strComID, uctxtLocation.Text).ToList();
            }
            else
            {
                oogrp = invms.mloadAddStockItemRMPack(strComID, uctxtLocation.Text,uctxtSalesLedger.Text,"N").ToList();
            }

            if (oogrp.Count > 0)
            {
                foreach (StockItem ogrp in oogrp)
                {
                    uclstGrdItem.Rows.Add();
                    uclstGrdItem[0, introw].Value = ogrp.strItemName;
                    uclstGrdItem[1, introw].Value = ogrp.dblClsBalance + " " + ogrp.strUnit; ;
                    //if (introw % 2 == 0)
                    //{
                    //    uclstGrdItem.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    uclstGrdItem.Rows[introw].DefaultCellStyle.BackColor = Color.White;
                    //}
                    introw += 1;
                }
                uclstGrdItem.AllowUserToAddRows = false;
            }


        }
        private void uclstGrdItem_DoubleClick(object sender, EventArgs e)
        {
            //DateTime firstDay = Convert.ToDateTime(DateTime.Parse(month + ", 1 " + year, CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"));
            //DateTime lastDay = Convert.ToDateTime(firstDay.AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy"));
            //int LastDay = lastDay.Day;


            if (uclstGrdItem.SelectedRows.Count > 0)
            {
                uctxtItemName.Text = Utility.GetDgValue(uclstGrdItem, uctxtItemName, 0);
                uclstGrdItem.Visible = false;
                uctxtQty.Focus();


            }
        }
        private void uclstGrdItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtItemName.Text = Utility.GetDgValue(uclstGrdItem, uctxtItemName, 0);
                uclstGrdItem.Visible = false;
                uctxtQty.Focus();
            }
        }
        private void uctxtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtItemName.Text == "")
                {
                    uctxtItemName.Text = "";
                    uclstGrdItem.Visible = false;
                    pnlAddLess.Visible = true;
                    pnlAddLess.Top = uctxtBranchName.Top + 40;
                    pnlAddLess.Left = dteDate.Left + 80;
                    pnlAddLess.Size = new Size(510, 200);
                    pnlAddLess.Location = new Point(364, 197);
                    uctxtAddleddLedger.Focus();
                    return;
                }


                if (uctxtItemName.Text != "")
                {
                    uclstGrdItem.Focus();
                    if (uclstGrdItem.Rows.Count > 0)
                    {
                        int i = 0;

                        uctxtItemName.Text = uclstGrdItem.Rows[i].Cells[0].Value.ToString();
                        uclstGrdItem.Visible = false;
                        uctxtQty.Focus();
                    }
                }
                else
                {
                    int i = 0;

                    uctxtItemName.Text = uclstGrdItem.Rows[i].Cells[0].Value.ToString();
                    uclstGrdItem.Visible = false;
                    uctxtQty.Focus();
                }
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtItemName, uctxtRefType);
            }
        }


        private void uctxtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            uclstGrdItem.Visible = true;
            //txtFoodCode.Text = "";
            //txtFoodName.Text = "";
            if (e.KeyCode == Keys.Up)
            {
                uclstGrdItem.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                uclstGrdItem.Focus();
            }

            uclstGrdItem.Top = uctxtItemName.Top + 25;
            uclstGrdItem.Left = uctxtItemName.Left;
            uclstGrdItem.Width = uctxtItemName.Width;
            uclstGrdItem.Height = 200;
            //ucdgList.Size = new Size(546, 222);
            uclstGrdItem.BringToFront();
            uclstGrdItem.AllowUserToAddRows = false;
            return;

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
        private void dteDuedate_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstBatch.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstSalesLedger.Visible = false;
            uclstGrdItem.Visible = false;
            DGMr.Visible = false;
            lstcustomer.Visible = false;
        }
        private void dteDuedate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtBranchName.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                uctxtSalesLedger.Focus();
            }

        }

        private void uctxtRefNo_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstBatch.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstSalesLedger.Visible = false;
            uclstGrdItem.Visible = false;
            DGMr.Visible = false;
            lstcustomer.Visible = false;
        }
        private void dteDate_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstBatch.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstSalesLedger.Visible = false;
            uclstGrdItem.Visible = false;
            DGMr.Visible = false;
            lstcustomer.Visible = false;
        }
        private void dteDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtSalesLedger.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                uctxtRefNo.Focus();
            }
        }
        private void uctxtRefNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dteDate.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtRefNo, uctxtLocation);
            }
        }
        private void uctxtPartyName_TextChanged(object sender, EventArgs e)
        {
            //lstPartyName.SelectedIndex = lstPartyName.FindString(uctxtPartyName.Text);
            if (uctxtPartyName.Text == "")
            {
                uctxtTeritoryCode.Text = "";
                uctxtTeritorryName.Text = "";

            }
        }

        private void lstPartyName_DoubleClick(object sender, EventArgs e)
        {
            uctxtPartyName.Text = lstPartyName.Text;
            uctxtSalesLedger.Focus();
        }

        private void uctxtPartyName_KeyPress(object sender, KeyPressEventArgs e)
        {
       
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtPartyName.Text == "")
                {
                    //txtItemCode.Text = "";
                    uctxtPartyName.Text = "";
                    if (DGMr.Rows.Count > 0)
                    {
                        int i = 0;
                        //uctxtTeritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                        //uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                        //uctxtPartyName.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                        DGMr.Visible = true;
                        //dteDuedate.Focus();
                    }
                    //if (uctxtPartyName.Text != "")
                    //{
                    //    mloadCustomer();
                    //    //lstCustomer.Items.Add(oinv.strSalesRepresentative);

                    //    //lstCustomer.DisplayMember = "strSalesRepresentative";
                    //    //lstCustomer.ValueMember = "strSalesRepresentative";
                    //    //lstCustomer.DataSource = ooinv.ToList();

                    //}
                    DGMr.Visible = false;
                    //uctxtNarration.Focus();

                    return;
                }


                if (uctxtItemName.Text != "")
                {
                    DGMr.Focus();
                    if (DGMr.Rows.Count > 0)
                    {
                        int i = 0;
                        uctxtTeritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                        uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                        uctxtPartyName.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                        DGMr.Visible = false;
                        if (txtCustomer.Visible)
                        {
                            txtCustomer.Focus();
                        }
                        else
                        {
                            uctxtRefType.Focus();
                        }
                    }
                }
                else
                {
                    int i = 0;

                    uctxtTeritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                    uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                    uctxtPartyName.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                    DGMr.Visible = false;
                    if (txtCustomer.Visible)
                    {
                        txtCustomer.Focus();
                    }
                    else
                    {
                        uctxtRefType.Focus();
                    }
                }
            }
            mloadCustomerSales();
            lblPurchaseCB.Text = Utility.gstrLedgerBalance(strComID, uctxtPartyName.Text);
            if (e.KeyChar == (char)Keys.Back)
            {
               Utility.PriorSetFocusText(uctxtPartyName, uctxtSalesLedger);
            }
        }
        private void uctxtPartyName_KeyDown(object sender, KeyEventArgs e)
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

            DGMr.Top = uctxtPartyName.Top + 25;
            DGMr.Left = uctxtPartyName.Left;
            DGMr.Width = uctxtPartyName.Width;
            DGMr.Height = 200;
            //ucdgList.Size = new Size(546, 222);
            DGMr.BringToFront();
            DGMr.AllowUserToAddRows = false;
            //uctxtItemName.Text = Utility.GetDgValue(ucdgList, uctxtItemName, 0);
            //ucdgList.Focus();
            return;
        }
        private void mloadCustomerSales()
        {
            if (intVtype == (int)Utility.VOUCHER_TYPE.vtSALES_RETURN)
            {
                if (uctxtPartyName.Text != "")
                {
                    lstcustomer.ValueMember = "strLedgerName";
                    lstcustomer.DisplayMember = "strMereString";
                    lstcustomer.DataSource = invms.mFillSalesRepFromMPoNew1(strComID, (long)Utility.GR_GROUP_TYPE.grSALES_REP, uctxtPartyName.Text).ToList();
                }
            }
            //int introw = 0;
            //lstcustomer.Items.Clear();

            //ooCustomer = invms.mFillSalesRepFromMPoNew1(strComID, (long)Utility.GR_GROUP_TYPE.grSALES_REP, uctxtPartyName.Text).ToList();

            //if (ooCustomer.Count > 0)
            //{

            //    foreach (Invoice ogrp in ooCustomer)
            //    {
            //        DGcustomer.Rows.Add();
            //        DGcustomer[3, introw].Value = ogrp.strTeritorryCode;
            //        DGcustomer[2, introw].Value = ogrp.strLedgerName;
            //        //DGcustomer[2, introw].Value = ogrp.strTeritorryName;

            //        DGcustomer[3, introw].Value = ogrp.strMereString;
            //        //if (introw % 2 == 0)
            //        //{
            //        //    DGcustomer.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
            //        //}
            //        //else
            //        //{
            //        //    DGcustomer.Rows[introw].DefaultCellStyle.BackColor = Color.White;
            //        //}
            //        introw += 1;
            //    }

            //    DGcustomer.AllowUserToAddRows = false;
            //}
        }
        private void DGMr_DoubleClick(object sender, EventArgs e)
        {
            //DateTime firstDay = Convert.ToDateTime(DateTime.Parse(month + ", 1 " + year, CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"));
            //DateTime lastDay = Convert.ToDateTime(firstDay.AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy"));
            //int LastDay = lastDay.Day;


            if (DGMr.SelectedRows.Count > 0)
            {
                int i = Convert.ToInt16(DGMr.CurrentRow.Index.ToString());
                uctxtTeritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                uctxtPartyName.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                mloadCustomerSales();
                DGMr.Visible = false;
                lblPurchaseCB.Text = Utility.gstrLedgerBalance(strComID, uctxtPartyName.Text);
                if (txtCustomer.Visible)
                {
                    txtCustomer.Focus();
                }
                else
                {
                    uctxtRefType.Focus();
                }


            }
        }
        private void DGMr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                //uctxtPartyName.Text = Utility.GetDgValue(DGMr, uctxtPartyName, 0);
                int i = Convert.ToInt16(DGMr.CurrentRow.Index.ToString());
                uctxtTeritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                uctxtPartyName.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                mloadCustomerSales();
                DGMr.Visible = false;
                lblPurchaseCB.Text = Utility.gstrLedgerBalance(strComID, uctxtPartyName.Text);
                if (txtCustomer.Visible)
                {
                    txtCustomer.Focus();
                }
                else
                {
                    uctxtRefType.Focus();
                }
            }
        }
        private void uctxtPartyName_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = true;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstRefType.Visible = false;
            lstBatch.Visible = false;
            lstSalesLedger.Visible = false;
            uclstGrdItem.Visible = false;
            DGMr.Visible = false;
            //if (intVtype == (long)Utility.VOUCHER_TYPE.vtSALES_RETURN)
            //{
            //    lstPartyName.ValueMember = "strLedgerName";
            //    lstPartyName.DisplayMember = "strLedgerName";
            //    lstPartyName.DataSource = invms.mfillPartyName(strComID).ToList();
            //}
            //else
            //{
            //    lstPartyName.ValueMember = "strLedgerName";
            //    lstPartyName.DisplayMember = "strLedgerName";
            //    //lstPartyName.DataSource = invms.mfillLedgerInvoice(strComID, false, lngLedgeras).ToList();
            //    lstPartyName.DataSource = accms.mFillLedgerList(strComID, lngLedgeras).ToList();
            //}

            //lstPartyName.SelectedIndex = lstPartyName.FindString(uctxtPartyName.Text);
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
                    DGSalesOrder.AllowUserToAddRows = false;
                    txtRefTypeNew.Text = "";
                    calculateTotal();
                }

            }
            catch (Exception ex)
            {

            }
        }
        private void txtRefTypeNew_LostFocus(object sender, System.EventArgs e)
        {
            int i = 0;
            double dblPrice = 0,dblTotalCommissionMinus = 0, dblTotalCommissionPlus = 0;
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

                                    DGSalesGrid[0, i].Value = oinv.strBillKey; //strBillKey;
                                    DGSalesGrid[1, i].Value = oinv.strItemName;
                                    DGSalesGrid[2, i].Value = oinv.dblQty;
                                    //DGSalesGrid[3, i].Value = oinv.dblRate;
                                    DGSalesGrid[3, i].Value = Math.Round(oinv.dblBillAmount, 2) / oinv.dblQty;
                                    DGSalesGrid[4, i].Value = oinv.strUnit;
                                    //DGSalesGrid[5, i].Value = Math.Round(oinv.dblQty * oinv.dblRate, 2);
                                    DGSalesGrid[5, i].Value = Math.Round(oinv.dblBillAmount - oinv.dblCommAmount, 0);
                                    DGSalesGrid[6, i].Value = oinv.dblBonusQty;
                                    DGSalesGrid[7, i].Value = oinv.strBatch;
                                    DGSalesGrid[8, i].Value = "Delete";
                                    DGSalesGrid[9, i].Value = DGSalesOrder[0, introw].Value.ToString(); //strBillKey;
                                    DGSalesGrid[10, i].Value = DGSalesOrder[0, introw].Value.ToString(); //strRefNo;


                                    //DGSalesGrid[0, i].Value = oinv.dblQty;
                                    //dblPrice = Utility.gdblGetEnterpriseSalesPrice(strComID, oinv.strItemName, dteDate.Text, oinv.dblQty, 0);
                                    //DGSalesGrid[1, i].Value = oinv.strItemName;
                                    ////DGSalesGrid[2, i].Value = Utility.mGetItemDescription(oinv.strItemName);
                                    //DGSalesGrid[2, i].Value = oinv.dblQty + " " + oinv.strUom;
                                    //DGSalesGrid[3, i].Value = oinv.dblRate;
                                    //DGSalesGrid[4, i].Value = oinv.strUnit;
                                    //DGSalesGrid[5, i].Value = Math.Round(oinv.dblQty * oinv.dblRate, 2);
                                    ////DGSalesGrid[7, i].Value = oinv.dblDiscount;
                                    ////DGSalesGrid[8, i].Value = Math.Round((oinv.dblQty * dblPrice) - oinv.dblDiscount, 2);
                                    //DGSalesGrid[6, i].Value = oinv.strBatch;
                                    //DGSalesGrid[7, i].Value = 0;
                                    //DGSalesGrid[8, i].Value = Math.Round(oinv.dblQty * oinv.dblRate, 2); ;
                                    //DGSalesGrid[9, i].Value = DGSalesOrder[0, introw].Value.ToString();
                                    //DGSalesGrid[10, i].Value = DGSalesOrder[1, introw].Value.ToString();
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
        private void txtRefTypeNew_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstRefTypeNew.Visible = true;
            lstRefType.Visible = false;
            lstBatch.Visible = false;
            lstAddlessLedger.Visible = false;
            lstCostCategory.Visible = false;
            lstCostCenter.Visible = false; ;
            uclstGrdItem.Visible = false;
            long lngRefType = gobjVoucherName.VoucherName.GetVoucherType(uctxtRefType.Text);
            if (uctxtLocation.Text != "")
            {
                mLoadAllItem(uctxtPartyName.Text, lngRefType, dteDate.Text, Utility.gstrGetBranchID(strComID, uctxtBranchName.Text), uctxtLocation.Text);
            }
           
        }

        private void mLoadAllItem(string strPartyname, long lngVtype, string strDate, string strBranchID,string strLocation)
        {
            int introw = 0;
           
            lstRefTypeNew.Rows.Clear();
            string strFdate = Convert.ToDateTime(strDate).AddMonths(-2).ToString("dd-MM-yyyy");

            ooRefNo = accms.gFillPreRefNoNew(strComID, strPartyname, lngVtype, strFdate, strBranchID, strLocation, "", 1,strDate).ToList();

            if (ooRefNo.Count > 0)
            {

                foreach (AccBillwise ogrp in ooRefNo)
                {
                    lstRefTypeNew.Rows.Add();
                    lstRefTypeNew[0, introw].Value = ogrp.strBillKey;

                    lstRefTypeNew[1, introw].Value = Utility.Mid(ogrp.strRefNo, 6, ogrp.strRefNo.Length - 6);
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
                    }
                }
                else
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
                }
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(txtRefTypeNew, sender, e);
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
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtRefType, uctxtPartyName);
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
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstRefType.Visible = true;
            uclstGrdItem.Visible = false;
            lstBatch.Visible = false;
            lstSalesLedger.Visible = false;
            lstRefType.SelectedIndex = lstRefType.FindString(uctxtRefType.Text);
        }
        private void uctxtLocation_TextChanged(object sender, EventArgs e)
        {
            lstLocation.SelectedIndex = lstLocation.FindString(uctxtLocation.Text);
        }

        private void lstLocation_DoubleClick(object sender, EventArgs e)
        {
            uctxtLocation.Text = lstLocation.Text;
            uctxtRefType.Focus();
        }

        private void uctxtLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstLocation.Items.Count > 0)
                {
                    uctxtLocation.Text = lstLocation.Text;
                }
                if (uctxtLocation.Text != "")
                {
                    mLoadAllItemStock();
                }
                uctxtRefNo.Focus();
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
            lstBranchName.Visible = false;
            lstLocation.Visible = true;
            lstRefType.Visible = false;
            lstBatch.Visible = false;
            lstSalesLedger.Visible = false;
            uclstGrdItem.Visible = false;
           
            if (uctxtBranchName.Text !="")
            {
                lstLocation.ValueMember = "strLocation";
                lstLocation.DisplayMember = "strLocation";
                lstLocation.DataSource = invms.gLoadLocation(strComID, lstBranchName.SelectedValue.ToString(), Utility.gblnAccessControl, Utility.gstrUserName,0).ToList();
            }
            lstLocation.SelectedIndex = lstLocation.FindString(uctxtLocation.Text);
        }


        private void uctxtBranchName_TextChanged(object sender, EventArgs e)
        {
            lstBranchName.Visible = true;
            lstBranchName.SelectedIndex = lstBranchName.FindString(uctxtBranchName.Text);
        }

        private void lstBranchName_DoubleClick(object sender, EventArgs e)
        {
            uctxtBranchName.Text = lstBranchName.Text;
            //mloadParty(lstBranchName.SelectedValue.ToString());
            if (intVtype == (int)Utility.VOUCHER_TYPE.vtSALES_RETURN)
            {
                mloadParty(lstBranchName.SelectedValue.ToString());
            }
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
                if (intVtype == (int)Utility.VOUCHER_TYPE.vtSALES_RETURN)
                {
                    mloadParty(lstBranchName.SelectedValue.ToString());
                }
                
                //uctxtLocation.Text = "";
                uctxtLocation.Focus();
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
           
            lstLocation.Visible = false;
            lstRefType.Visible = false;
            lstBatch.Visible = false;
            lstSalesLedger.Visible = false;
            lstBranchName.ValueMember = "BranchID";
            lstBranchName.DisplayMember = "BranchName";
            lstBranchName.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
            lstBranchName.SelectedIndex = lstBranchName.FindString(uctxtBranchName.Text);
        }

        private void uctxtItemName_KeyUp(object sender, KeyEventArgs e)
        {
            if (uctxtLocation.Text != "")
            {
                SearchListView(oogrp, uctxtItemName.Text);
            }
        }

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
                query = tests.Where(x => x.strItemName.ToLower().Trim().Contains(searchString.ToLower().Trim()));
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
            uclstGrdItem.Rows.Clear();
            int i = 0;
            try
            {
                foreach (StockItem tran in query)
                {
                    uclstGrdItem.Rows.Add();
                    uclstGrdItem[0, i].Value = tran.strItemName;
                    uclstGrdItem[1, i].Value = tran.dblClsBalance + " " + tran.strUnit;
                    //if (i % 2 == 0)
                    //{
                    //    uclstGrdItem.Rows[i].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    uclstGrdItem.Rows[i].DefaultCellStyle.BackColor = Color.White;
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
        #region "Getconfig"
        private void mGetConfig()
        {
            List<VoucherTypes> ooVtype = accms.mGetConfig(strComID, intVtype).ToList();
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
        #region "Load"
        private void mloadCustomer()
        {
            int introw = 0;
            DGMr.Rows.Clear();
            //accms.mFillLedgerList(strComID, lngLedgeras).ToList()
            ooPartyName = invms.mfillLedgerInvoice(strComID, false, lngLedgeras,"").ToList();

            if (ooPartyName.Count > 0)
            {

                foreach (Invoice ogrp in ooPartyName)
                {
                    DGMr.Rows.Add();
                    DGMr[0, introw].Value = "";
                    DGMr[1, introw].Value = "";
                    DGMr[2, introw].Value = ogrp.strLedgerName;
                    DGMr[3, introw].Value = ogrp.strMereString;
                   
                    //DGMr.Rows[introw].DefaultCellStyle.Font = new Font("verdana", 9);
                    //DGMr.Rows[introw].DefaultCellStyle.SelectionBackColor = Color.Yellow;
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
        private void mloadParty(string strBranchID)
        {
            int introw = 0;
            DGMr.Rows.Clear();

            ooPartyName = invms.mfillPartyNameNew(strComID, strBranchID, Utility.gblnAccessControl, Utility.gstrUserName, 0,"").ToList();

            if (ooPartyName.Count > 0)
            {

                foreach (Invoice ogrp in ooPartyName)
                {
                    DGMr.Rows.Add();
                    DGMr[0, introw].Value = ogrp.strTeritorryCode;
                    DGMr[1, introw].Value = ogrp.strTeritorryName;
                    DGMr[2, introw].Value = ogrp.strLedgerName;
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
        private void frmSalesReturn_Load(object sender, EventArgs e)
        {
            mGetConfig();
            mClear();
            if (mblnNumbMethod)
            {
                uctxtRefNo.ReadOnly = true;
                uctxtBranchName.Focus();
                uctxtBranchName.Select();
            }
            else
            {

                uctxtBranchName.Focus();
                uctxtBranchName.Select();
            }
            lstPartyName.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstcustomer.Visible = false;
            lstRefType.Visible = false;
            lstBatch.Visible = false;
            lstSalesLedger.Visible = false;
            lstAddlessLedger.Visible = false;
            lstTypeofRef.Visible = false;
            lstCostCategory.Visible = false;
            lstCostCenter.Visible = false;
            lstBranchName.Visible = false;
            dgBillBranch.AllowUserToAddRows = false;
            DgCostCenter.AllowUserToAddRows = false;
            DGAddLess.AllowUserToAddRows = false;
            DGSalesGrid.AllowUserToAddRows = false;
            if (intVtype==(int)Utility.VOUCHER_TYPE.vtSALES_RETURN)
            {
                frmLabel.Text = "Sales Return";
                lblLedgerName.Text = "Sales Return No:";
                lblMpoName.Text = "MPO Name:";
                lblLedger.Text = "Sales Ledger:";

                lblTeritorryCode.Visible = true;
                lblTeritorryName.Visible = true;
                uctxtTeritorryName.Visible = true;
                uctxtTeritoryCode.Visible = true;
                //this.DGMr.DefaultCellStyle.Font = new Font("verdana", 9);
                DGMr.Columns.Add(Utility.Create_Grid_Column("Teritorry Code", "Teritorry Code", 110, true, DataGridViewContentAlignment.TopLeft, true));
                DGMr.Columns.Add(Utility.Create_Grid_Column("Teritorry name", "Teritorry name", 170, true, DataGridViewContentAlignment.TopLeft, true));
                DGMr.Columns.Add(Utility.Create_Grid_Column("MPO Name", "MPO Name", 260, true, DataGridViewContentAlignment.TopLeft, true));
                DGMr.Columns.Add(Utility.Create_Grid_Column("String", "String", 290, false, DataGridViewContentAlignment.TopLeft, true));
                //mloadParty();
            }
            else
            {
                frmLabel.Text = "Purchase Return";
                lblTeritorryCode.Visible = false;
                lblTeritorryName.Visible = false;
                uctxtTeritorryName.Visible = false;
                uctxtTeritoryCode.Visible = false;
                lblLedgerName.Text = "Purchase Return No:";
                lblMpoName.Text = "Supplier Name:";
                lblLedger.Text = "Purchase Ledger:";
                lblCistomer.Visible = false;
                txtCustomer.Visible = false;
                //this.DGMr.DefaultCellStyle.Font = new Font("verdana", 9);
                DGMr.Columns.Add(Utility.Create_Grid_Column("Teritorry Code", "Teritorry Code", 110, false, DataGridViewContentAlignment.TopLeft, true));
                DGMr.Columns.Add(Utility.Create_Grid_Column("Teritorry name", "Teritorry name", 170, false, DataGridViewContentAlignment.TopLeft, true));
                DGMr.Columns.Add(Utility.Create_Grid_Column("MPO Name", "MPO Name", 400, true, DataGridViewContentAlignment.TopLeft, true));
                DGMr.Columns.Add(Utility.Create_Grid_Column("String", "String", 290, false, DataGridViewContentAlignment.TopLeft, true));
                mloadCustomer();
            }
            oinv = invms.mGetInvoiceConfig(strComID).ToList();
            //oinv = invms.mGetInvoiceConfigNew(strComID).ToList();

            LoadDefaultValue();
            //oinv = invms.mGetInvoiceConfig(strComID).ToList();
           
            //oinv = invms.mGetInvoiceConfigNew().ToList();
            lstRefTypeNew.Columns.Add(Utility.Create_Grid_Column("Bill Key", "Bill. Key", 350, false, DataGridViewContentAlignment.TopLeft, true));
            lstRefTypeNew.Columns.Add(Utility.Create_Grid_Column("Ref. No", "Ref. No", 130, true, DataGridViewContentAlignment.TopLeft, true));
            lstRefTypeNew.Columns.Add(Utility.Create_Grid_Column("Date", "Date", 100, true, DataGridViewContentAlignment.TopLeft, true));
            //lstRefTypeNew.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));
        }
        #endregion
        #region "Default Value"
        private void LoadDefaultValue()
        {
            if (intVtype == (int)Utility.VOUCHER_TYPE.vtSALES_RETURN)
            {
                SortedDictionary<string, int> userCache = new SortedDictionary<string, int>
                {
                  {Utility.gcEND_OF_LIST, 1},
                  //{gobjVoucherName.VoucherName.GetVoucherName((long)Utility.VOUCHER_TYPE.vtSALES_ORDER), 2},
                  {gobjVoucherName.VoucherName.GetVoucherName((long)Utility.VOUCHER_TYPE.vtSALES_INVOICE), 2}
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
                  //{gobjVoucherName.VoucherName.GetVoucherName((long)Utility.VOUCHER_TYPE.vtSALES_ORDER), 2},
                  {gobjVoucherName.VoucherName.GetVoucherName((long)Utility.VOUCHER_TYPE.vtPURCHASE_INVOICE), 2}
                };
                lstRefType.DisplayMember = "Key";
                lstRefType.ValueMember = "Value";
                lstRefType.DataSource = new BindingSource(userCache, null);
            }
            


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
            if (uctxtBranchName.Text == "")
            {
                MessageBox.Show("Cannot Empty");
                uctxtBranchName.Focus();
                return false;
            }
            if (DGSalesGrid.Rows.Count == 0)
            {
                MessageBox.Show("Item Cannot be Empty");
                uctxtItemName.Focus();
                return false;
            }
            if (Utility.Val(lblNetAmount.Text) == 0 || Utility.Val(lblNetAmount.Text) < 0)
            {
                MessageBox.Show("Net Amount be Empty");
                uctxtItemName.Focus();
                return false;
            }

            long lngDate = Convert.ToInt64(dteDate.Value.ToString("yyyyMMdd"));
            long lngFiscalYearfrom = Convert.ToInt64(Convert.ToDateTime(Utility.gdteFinancialYearFrom).ToString("yyyyMMdd"));
            long lngFiscalYearTo = Convert.ToInt64(Convert.ToDateTime(Utility.gdteFinancialYearTo).ToString("yyyyMMdd"));

            if (lngDate < lngFiscalYearfrom)
            {
                MessageBox.Show("Invalid Date, Date Can't less then Financial Year");
                return false;
            }
            if (lngDate > lngFiscalYearTo)
            {
                MessageBox.Show("Invalid Date, Date Can't less then Financial Year");
                return false;
            }

            string strBacklockDate = Utility.gCheckBackLock(strComID);

            if (DGSalesGrid.Rows.Count ==0)
            {
                MessageBox.Show("Item Cannot be empty");
                uctxtItemName.Focus();
                return false;
            }

            if (strBacklockDate != "")
            {
                long lngBackdate = Convert.ToInt64(Convert.ToDateTime(strBacklockDate).ToString("yyyyMMdd"));
                if (lngDate <= lngBackdate)
                {
                    MessageBox.Show("Invalid Date, Back Date is locked");
                    return false;
                }
            }
           
            double dblClosingQTY = 0, dblCurrentQTY = 0;
            string strBillKey = "", strNegetiveItem = "";
            int intCheckNegetive = 0;
            if (oinv[0].mlngBlockNegativeStock > 0)
            {
                for (int i = 0; i < DGSalesGrid.Rows.Count; i++)
                {
                    if (DGSalesGrid[0, i].Value != null)
                    {
                        strBillKey = DGSalesGrid[0, i].ToString();
                        dblClosingQTY = Utility.gdblClosingStock(strComID, DGSalesGrid[0, i].Value.ToString(), uctxtLocation.Text, dteDate.Text);
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

          
            return true;
        }
        #endregion
        #region "Save Sales Return"
        private string mSaveSalesReturn()
        {
            string strABillTranKey,strBillRefNo, strGitItem, strDGSales = "", strDGSalesOrder = "", strBarchID = "", strDGBillWise = "", strDgvector = "", strDGAddless = "", strRefNumber="";
            long lngAgstRef;
            double dblcostRate;

         
            try
            {
                for (int i = 0; i < DGSalesGrid.Rows.Count; i++)
                {
                    if (DGSalesGrid[0, i].Value != null)
                    {
                        strABillTranKey = DGSalesGrid[0, i].Value.ToString();
                    }
                    else
                    {
                        strABillTranKey = "";
                    }
                    if (DGSalesGrid[10, i].Value != null)
                    {
                        strBillRefNo = DGSalesGrid[10, i].Value.ToString();
                    }
                    else
                    {
                        strBillRefNo = "";
                    }
                    if (DGSalesGrid[8, i].Value != null)
                    {
                        strGitItem = DGSalesGrid[8, i].Value.ToString();
                    }
                    else
                    {
                        strGitItem = "";
                    }
                    dblcostRate = Utility.gdblGetCostPriceReturn(strComID, DGSalesGrid[1, i].Value.ToString(), dteDate.Text);
                    strDGSales = strDGSales + Utility.gCheckNull(DGSalesGrid[1, i].Value.ToString()) + "|" +//Item
                                                                Utility.Val(DGSalesGrid[2, i].Value.ToString()) + "|" +//qty
                                                                Utility.Val(DGSalesGrid[3, i].Value.ToString()) + "|" +//rate
                                                                Utility.gCheckNull(DGSalesGrid[4, i].Value.ToString()) + "|" + //Unit
                                                                Utility.Val(DGSalesGrid[5, i].Value.ToString()) + "|" + //amount
                                                                Utility.gCheckNull(DGSalesGrid[6, i].Value.ToString()) + "|" + //Bonus
                                                                Utility.gCheckNull(DGSalesGrid[7, i].Value.ToString()) + "|" + //Batch
                                                                dblcostRate + "|" +//costrate
                                                                strGitItem + "|" + //GiftItem
                                                                strABillTranKey + "|" + //BillTran Key
                                                                strBillRefNo + "~"; //BillTran refno

                    //Utility.gCheckNull(DGSalesGrid[10, i].Value.ToString()) + "~";
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

                for (int i = 0; i < DGAddLess.Rows.Count; i++)
                {
                    if (DGAddLess[0, i].Value != null)
                    {
                        strDGAddless = strDGAddless + Utility.gCheckNull(DGAddLess[0, i].Value.ToString()) + "|" +
                                                                    Utility.gCheckNull(DGAddLess[1, i].Value.ToString()) + "|" +
                                                                    Utility.Val(DGAddLess[2, i].Value.ToString()) + "~";

                    }

                }

                lngAgstRef = gobjVoucherName.VoucherName.GetVoucherType(uctxtRefType.Text);
                strBarchID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);

                if (mblnNumbMethod == false)
                {
                    strRefNumber = gobjVoucherName.VoucherName.GetVoucherString(intVtype) + strBarchID + uctxtRefNo.Text;
                }
                else
                {
                    strRefNumber = gobjVoucherName.VoucherName.GetVoucherString(intVtype) + strBarchID + Utility.gstrLastNumber(strComID, intVtype);
                }
                string strSalesRep;
                if (txtCustomer.Text.Trim() != Utility.gcEND_OF_LIST)
                {
                    strSalesRep = lstcustomer.SelectedValue.ToString();
                }
                else
                {
                    strSalesRep = Utility.gcEND_OF_LIST;
                }
                string strMsg = invms.mSaveSalesReturn(strComID,strRefNumber, intVtype, dteDate.Text, dteDuedate.Text, dteDate.Value.ToString("MMMyy"), Utility.gCheckNull(uctxtPartyName.Text),
                                                    uctxtSalesLedger.Text, Utility.Val(lblNetAmount.Text), Utility.Val(lblTotalAmount.Text), Utility.Val(uctxtAdd.Text), Utility.Val(uctxtLess.Text),
                                                    Utility.gCheckNull(uctxtRefType.Text), lngAgstRef, oinv[0].mlngIsInvEffinDirSalesInv,
                                                    Utility.gCheckNull(uctxtNarration.Text), strBarchID, Utility.gCheckNull(uctxtLocation.Text), 0, 1, strDGSales, strDGSalesOrder, strDgvector,
                                                    strDGBillWise, strDGAddless, false, 0, "", mblnNumbMethod, strSalesRep);
                if (Utility.gblnAccessControl)
                {
                    string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"),"Sales Return", uctxtRefNo.Text,
                                                            1, 0, (int)Utility.MODULE_TYPE.mtSALES, "0001");
                } 
                return strMsg;

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            finally
            {
                
            }
            
        }
        #endregion
        #region "Update Sales Return"
        private string mUpdateSalesReturn()
        {
            string strABillTranKey, strGitItem, strDGSales = "", strDGSalesOrder = "", strBarchID = "", strDGBillWise = "", strDgvector = "", strDGAddless = "";
            long lngAgstRef;
            double dblcostRate;
            try
            {
                for (int i = 0; i < DGSalesGrid.Rows.Count; i++)
                {
                    if (DGSalesGrid[7, i].Value != null)
                    {
                        strABillTranKey = DGSalesGrid[7, i].Value.ToString();
                    }
                    else
                    {
                        strABillTranKey = "";
                    }
                    if (DGSalesGrid[8, i].Value != null)
                    {
                        strGitItem = DGSalesGrid[8, i].Value.ToString();
                    }
                    else
                    {
                        strGitItem = "";
                    }
                    dblcostRate = Utility.gdblGetCostPriceReturn(strComID, DGSalesGrid[1, i].Value.ToString(), dteDate.Text);
                    strDGSales = strDGSales + Utility.gCheckNull(DGSalesGrid[1, i].Value.ToString()) + "|" +//Item
                                                                Utility.Val(DGSalesGrid[2, i].Value.ToString()) + "|" +//qty
                                                                Utility.Val(DGSalesGrid[3, i].Value.ToString()) + "|" +//rate
                                                                Utility.gCheckNull(DGSalesGrid[4, i].Value.ToString()) + "|" + //Unit
                                                                Utility.Val(DGSalesGrid[5, i].Value.ToString()) + "|" + //amount
                                                                Utility.gCheckNull(DGSalesGrid[6, i].Value.ToString()) + "|" + //Batch
                                                                Utility.gCheckNull(DGSalesGrid[7, i].Value.ToString()) + "|" + //Batch
                                                                dblcostRate + "|" +//costrate
                                                                strABillTranKey + "|" + //BillTran Key
                                                                strGitItem + "~"; //GiftItem

                    //Utility.gCheckNull(DGSalesGrid[10, i].Value.ToString()) + "~";
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

                for (int i = 0; i < DGAddLess.Rows.Count; i++)
                {
                    if (DGAddLess[0, i].Value != null)
                    {
                        strDGAddless = strDGAddless + Utility.gCheckNull(DGAddLess[0, i].Value.ToString()) + "|" +
                                                                    Utility.gCheckNull(DGAddLess[1, i].Value.ToString()) + "|" +
                                                                    Utility.Val(DGAddLess[2, i].Value.ToString()) + "~";

                    }

                }
                string strSalesRep;
                if (txtCustomer.Text.Trim() != Utility.gcEND_OF_LIST)
                {
                    strSalesRep = lstcustomer.SelectedValue.ToString();
                }
                else
                {
                    strSalesRep = Utility.gcEND_OF_LIST;
                }
                lngAgstRef = gobjVoucherName.VoucherName.GetVoucherType(uctxtRefType.Text);
                strBarchID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);

                string strMsg = invms.mUpdateSalesReturn(strComID, txtOldRefNo.Text, uctxtRefNo.Text, intVtype, dteDate.Text, dteDuedate.Text, dteDate.Value.ToString("MMMyy"), Utility.gCheckNull(uctxtPartyName.Text),
                                                    uctxtSalesLedger.Text, Utility.Val(lblNetAmount.Text), Utility.Val(lblTotalAmount.Text), Utility.Val(uctxtAdd.Text), Utility.Val(uctxtLess.Text),
                                                    Utility.gCheckNull(uctxtRefType.Text), lngAgstRef, oinv[0].mlngIsInvEffinDirSalesInv,
                                                    Utility.gCheckNull(uctxtNarration.Text), strBarchID, Utility.gCheckNull(uctxtLocation.Text), 0, 1, strDGSales, strDGSalesOrder, strDgvector,
                                                    strDGBillWise, strDGAddless, false, 0, "", strSalesRep);
                if (Utility.gblnAccessControl)
                {
                    string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Sales Return", uctxtRefNo.Text,
                                                            2, 0, (int)Utility.MODULE_TYPE.mtSALES, "0001");
                } 
                return strMsg;

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            finally
            {

            }

        }
        #endregion
        #region "Clear"
        private void mClear()
        {
            uctxtRefNo.Text = "";
            uctxtPartyName.Text = "";
            uctxtSalesLedger.Text = "";
            uctxtBranchName.Text = "";
            uctxtLocation.Text = "";
            uctxtRefType.Text = "";
            uctxtNarration.Text = "";
            txtTotalItem.Text = "";
            lblTotalAmount.Text = "0";
            lblNetAmount.Text = "0";
            uctxtAdd.Text = "";
            uctxtLess.Text = "";
            lblQuantityTotal.Text = "";
            dgBillBranch.Rows.Clear();
            DGAddLess.Rows.Clear();
            DgCostCenter.Rows.Clear();
            DGSalesGrid.Rows.Clear();
            DGSalesOrder.Rows.Clear();
            DGSalesGrid.Enabled = true ;
            DGSalesOrder.Enabled = true;
            pnlAddLess.Visible = false;
            txtCustomer.Text = "";
            
            m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            if (mblnNumbMethod)
            {
                uctxtRefNo.Text = Utility.gstrLastNumber(strComID, intVtype);
            }
            else
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
              
                if (intVtype == (int)Utility.VOUCHER_TYPE.vtSALES_RETURN)
                {
                    //uctxtRefNo.Text = Interaction.GetSetting(Application.ExecutablePath, "frmSalesReturn", "VoucherNoSR");
                    uctxtRefNo.AppendText((String)rk.GetValue("VoucherNoSR", ""));
                    rk.Close();
                }
                else
                {
                    //uctxtRefNo.Text = Interaction.GetSetting(Application.ExecutablePath, "frmSalesReturn", "VoucherNoPK");
                    uctxtRefNo.AppendText((String)rk.GetValue("VoucherNoPK", ""));
                }
                uctxtRefNo.Text = Utility.gobjNextNumber(uctxtRefNo.Text);
            }
            uctxtBranchName.Focus();
        }
        #endregion
        #region "Click"
        private void DGSalesOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                DGSalesOrder.Rows.RemoveAt(e.RowIndex);
                txtRefTypeNew_LostFocus(sender, e);
                calculateTotal();
            }
        }

        private void btnCan_Click(object sender, EventArgs e)
        {
            pnlAddLess.Visible = false;
        }

        private void btnAddLessApply_Click_1(object sender, EventArgs e)
        {

        }

        private void DGAddLess_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                DGAddLess.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string i = "", strDuplicate="";
            if (ValidateFields() == false)
            {
                return;
            }
            string strBarchID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);
            var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (strResponseInsert == DialogResult.Yes)
            {
                try
                {
                    if (m_action == (int)Utility.ACTION_MODE_ENUM.ADD_MODE)
                    {
                        strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_COMPANY_VOUCHER", "COMP_REF_NO", uctxtRefNo.Text);
                        if (strDuplicate != "")
                        {
                            MessageBox.Show(strDuplicate);
                            uctxtRefNo.Focus();
                            return;
                        }
                         i= mSaveSalesReturn();
                        if (i == "Inserted...")

                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, dteDate.Text, strFormName, strFormName,
                                                                        3, 0, intModuletype, strBarchID);
                            }
                            mClear();
                        }
                    }
                    else
                    {
                        i = mUpdateSalesReturn();
                        if (i == "Updated...")
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, dteDate.Text, strFormName, strFormName,
                                                                        3, 0, intModuletype, strBarchID);
                            }
                            mClear();
                            frmAccountsVoucherList objfrm = new frmAccountsVoucherList();
                            objfrm.mintVType = Convert.ToInt32(intVtype);
                            objfrm.lngFormPriv = lngFormPriv;
                            objfrm.strPreserveSQl = strPreserveSQl;
                            objfrm.strFormName = "Sales Return";
                            objfrm.intModuleType = intModuletype;
                            objfrm.onAddAllButtonClicked = new frmAccountsVoucherList.AddAllClick(DisplayVoucherList);
                            objfrm.Show();
                            objfrm.MdiParent = this.MdiParent;
                           
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(i.ToString());
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            mClear();
            frmAccountsVoucherList objfrm = new frmAccountsVoucherList();
            objfrm.mintVType = Convert.ToInt32(intVtype);
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.strFormName = "Sales Return";
            objfrm.intModuleType = intModuletype;
            objfrm.strPreserveSQl = strPreserveSQl;
            objfrm.onAddAllButtonClicked = new frmAccountsVoucherList.AddAllClick(DisplayVoucherList);
            objfrm.Show();
            objfrm.MdiParent = this.MdiParent;
            uctxtBranchName.Focus();
        }

        #endregion
        #region "Display List"
        private void DisplayVoucherList(List<AccountsVoucher> tests, object sender, EventArgs e)
        {
            try
            {
                int introw = 0;
                double dblTotalCommissionMinus = 0, dblTotalCommissionPlus=0;
                m_action = (int)Utility.ACTION_MODE_ENUM.EDIT_MODE;
                DGSalesGrid.Rows.Clear();
                DGSalesGrid.Enabled = true;
                DGSalesOrder.Enabled = false;
                List<AccountsVoucher> ooaccVou = accms.DisplayCompVoucherList(strComID, tests[0].strVoucherNo, intVtype).ToList();
                if (ooaccVou.Count > 0)
                {
                    foreach (AccountsVoucher oCom in ooaccVou)
                    {
                        uctxtRefNo.Text = Utility.Mid(oCom.strVoucherNo,6,oCom.strVoucherNo.Length-6);
                        txtOldRefNo.Text = oCom.strVoucherNo;
                        strPreserveSQl = tests[0].strPreserveSQL;
                        dteDate.Text = oCom.strTranDate;
                        dteDuedate.Text = oCom.strDueDate;
                        uctxtPartyName.Text = Utility.GetLedgerNameFromMerzeName(strComID, oCom.strMerzeName);

                        uctxtTeritoryCode.Text = Utility.GetTeritorryCodeFromLedgerName(strComID, uctxtPartyName.Text);
                        uctxtTeritorryName.Text = Utility.GetTeritorryName(strComID, uctxtTeritoryCode.Text);
                        if (oCom.strSalesRepresentive != "")
                        {
                           txtCustomer.Text = Utility.gGetLedgerNameMerze(strComID, oCom.strSalesRepresentive);
                        }
                        else
                        {
                            txtCustomer.Text = Utility.gcEND_OF_LIST;
                        }
                        uctxtBranchName.Text = Utility.gstrGetBranchName(strComID, oCom.strBranchID);
                        uctxtNarration.Text = oCom.strNarration;
                        List<AccountsLedger> ooSSalesLedger = accms.DisplaycommonInvoiceVoucher(strComID, tests[0].strVoucherNo).ToList();
                        if (ooSSalesLedger.Count > 0)
                        {
                            uctxtSalesLedger.Text = ooSSalesLedger[0].strLedgerName;
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
                                DGSalesGrid[2, introw].Value = oacc.dblQnty;
                                DGSalesGrid[3, introw].Value = oacc.dblRate;
                                DGSalesGrid[4, introw].Value = oacc.strPer;
                                DGSalesGrid[5, introw].Value = oacc.dblAmount;
                                DGSalesGrid[6, introw].Value = oacc.dblBonusQnty;
                                DGSalesGrid[7, introw].Value = oacc.strBatchNo;
                                DGSalesGrid[8, introw].Value = "Delete";
                                DGSalesGrid[9, introw].Value = oacc.strBillKey;
                                DGSalesGrid[10, introw].Value = oacc.strRefNo;
                                introw += 1;
                            }
                            DGSalesGrid.AllowUserToAddRows = false;
                        }
                        introw = 0;
                        List<AccBillwise> ooOrder = accms.DisplaycommonInvoiceOrder(strComID, tests[0].strVoucherNo.ToString(), intVtype).ToList();
                        if (ooOrder.Count > 0)
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
                        else
                        {
                            uctxtRefType.Text = Utility.gcEND_OF_LIST;
                        }
                        DGSalesOrder.AllowUserToAddRows = false;

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
                                    DGAddLess.Rows[i].Cells[2].Value = Math.Abs(ooBill.dblDebitAmount + ooBill.dblCreditAmount);

                                    if (ooBill.strAddlessSign == "-")
                                    {
                                        dblTotalCommissionMinus = dblTotalCommissionMinus + Utility.Val(DGAddLess[2, i].Value.ToString());
                                    }
                                    else
                                    {
                                        dblTotalCommissionPlus = dblTotalCommissionPlus + Utility.Val(DGAddLess[2, i].Value.ToString());
                                    }
                                    i += 1;
                                }
                                uctxtAdd.Text = dblTotalCommissionPlus.ToString();
                                uctxtLess.Text = dblTotalCommissionMinus.ToString();


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
        private void uctxtPartyName_KeyUp(object sender, KeyEventArgs e)
        {
            if (intVtype == (int)Utility.VOUCHER_TYPE.vtSALES_RETURN)
            {
                SearchListViewPartyName(ooPartyName, uctxtPartyName.Text);
            }
            else
            {
                SearchListViewCustomerName(ooPartyName, uctxtPartyName.Text);
            }
        }

        private void SearchListViewCustomerName(IEnumerable<Invoice> tests, string searchString = "")
        {
            IEnumerable<Invoice> query;
            //if ((searchString.Length > 0))
            //{
            query = tests;

            //if (chkVoucheNo.Checked == true)
            //{
            if (searchString != "")
            {
                query = tests.Where(x => x.strLedgerName.ToLower().Trim().Contains(searchString.ToLower().Trim()));
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
                    DGMr[0, i].Value = "";
                    DGMr[1, i].Value = "";
                    DGMr[2, i].Value = tran.strLedgerName;
                    DGMr[3, i].Value = tran.strMereString;
                    //DGMr.Rows[i].DefaultCellStyle.Font = new Font("verdana", 9);
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
                    DGMr[1, i].Value = tran.strTeritorryName;
                    DGMr[2, i].Value = tran.strLedgerName;
                    DGMr[3, i].Value = tran.strMereString;
                    //DGMr.Rows[i].DefaultCellStyle.Font = new Font("verdana", 9);
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
        #endregion
        #region "Click"
        private void btnAddLessCancel_Click(object sender, EventArgs e)
        {
            pnlAddLess.Visible = false;
            uctxtNarration.Focus();

        }

       

        private void DGSalesGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==8)
            {
                if (uctxtRefType.Text == "End of List")
                {
                    DGSalesGrid.Rows.RemoveAt(e.RowIndex);
                    calculateTotal();
                }
            }
        }
        #endregion

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

        private void txtRefTypeNew_TextChanged(object sender, EventArgs e)
        {

        }

      





    }
}
