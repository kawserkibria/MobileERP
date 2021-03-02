using Dutility;
using JA.Modulecontrolar.JACCMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using JA.Modulecontrolar.UI.Accms.Forms;

using Microsoft.VisualBasic;
using Microsoft.Win32;

namespace JA.Modulecontrolar.UI.Sales.Forms
{
    public partial class frmCustomer : JA.Shared.UI.frmJagoronFromSearch
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public int intvtype { get; set; }
        private ListBox lstUnder = new ListBox();
        private ListBox lstCostCenter = new ListBox();
        private ListBox lsteffectInventory = new ListBox();
        private ListBox lstcurrency = new ListBox();
        private ListBox lstInactive = new ListBox();              //Listview Declaration
        private ListBox lstBranchName = new ListBox();
        private ListBox lstCostCategory = new ListBox();
        private ListBox lstCostCenterNew = new ListBox();
        private ListBox lstPriceLebel = new ListBox();
        private ListBox lstBillwiseBranch = new ListBox();
        private ListBox lstTeritorryCode = new ListBox();
        private ListBox lstTeritorryName = new ListBox();
        private ListBox lstLedgerBranch = new ListBox();
        private ListBox lstPFLedger = new ListBox();
        private ListBox lstHLLedger = new ListBox();
        public long lngFormPriv { get; set; }
        public int intModuleType { get; set; }
        public string strFormname { get; set; }
        public string strPreserveSQL { get; set; }
        public int intStatus { get; set; }
        public int m_acction { get; set; }
        public int mSingleEntry { get; set; }
        private long mlngSlNo { get; set; }
        private string mstrOldLedger { get; set; }
        private string mstrOldTerritoryCode { get; set; }
        private double mdblOpeningBalance { get; set; }
        private double mdblDebit { get; set; }
        private double mdblCredit { get; set; }
        private string strComID { get; set; }

        public frmCustomer()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            #region "User Define Ini"

            this.txtPFLedger.KeyDown += new KeyEventHandler(txtPFLedger_KeyDown);
            this.txtPFLedger.TextChanged += new System.EventHandler(this.txtPFLedger_TextChanged);
            this.txtPFLedger.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPFLedger_KeyPress);
            this.txtPFLedger.GotFocus += new System.EventHandler(this.txtPFLedger_GotFocus);
            this.lstPFLedger.DoubleClick += new System.EventHandler(this.lstPFLedger_DoubleClick);

            this.txtHLLedger.KeyDown += new KeyEventHandler(txtHLLedger_KeyDown);
            this.txtHLLedger.TextChanged += new System.EventHandler(this.txtHLLedger_TextChanged);
            this.txtHLLedger.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHLLedger_KeyPress);
            this.txtHLLedger.GotFocus += new System.EventHandler(this.txtPFLedger_GotFocus);
            this.lstPFLedger.DoubleClick += new System.EventHandler(this.lstPFLedger_DoubleClick);


            this.uctxtMpoName.GotFocus += new System.EventHandler(this.uctxtMpoName_GotFocus);
            this.uctxtMpoName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uctxtMpoName_KeyPress);
            this.uctxtMpoName.TextChanged += new System.EventHandler(this.uctxtMpoName_TextChanged);
            this.uctxtMpoName.KeyDown += new KeyEventHandler(uctxtMpoName_KeyDown);

            this.uctxtOpeningBalance.GotFocus += new System.EventHandler(this.uctxtOpeningBalance_GotFocus);
            this.uctxtOpeningBalance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uctxtOpeningBalance_KeyPress);
            this.uctxtOpeningBalance.TextChanged += new System.EventHandler(this.uctxtOpeningBalance_TextChanged);

            this.cboClass.GotFocus += new System.EventHandler(this.cboClass_GotFocus);
            this.cboClass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(cboClass_KeyPress);

            this.cboBkash.GotFocus += new System.EventHandler(this.cboBkash_GotFocus);
            this.cboBkash.KeyPress += new System.Windows.Forms.KeyPressEventHandler(cboBkash_KeyPress);

            this.uctxtDrCr.GotFocus += new System.EventHandler(this.uctxtDrCr_GotFocus);
            this.uctxtDrCr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtDrCr_KeyPress);
            
            this.uctxtDrCr.KeyDown += new KeyEventHandler(uctxtDrCr_KeyDown);
            this.uctxtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uctxtPhone_KeyPress);

            this.txtCreditLimit.GotFocus += new System.EventHandler(this.txtCreditLimit_GotFocus);
            this.txtCreditLimit.TextChanged += new System.EventHandler(this.txtCreditLimit_TextChanged);

            this.uctxtCreditDate.GotFocus += new System.EventHandler(this.uctxtCreditDate_GotFocus);
            this.uctxtCreditDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uctxtCreditDate_KeyPress);

            this.txtCloseDate.GotFocus += new System.EventHandler(this.txtCloseDate_GotFocus);
            this.txtCloseDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCloseDate_KeyPress);

            this.txtPeriod.GotFocus += new System.EventHandler(this.txtPeriod_GotFocus);
            this.txtPeriod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtPeriod_KeyPress);
            this.txtPeriod.TextChanged += new System.EventHandler(this.txtPeriod_TextChanged);
            this.uctxtAddress1.GotFocus += new System.EventHandler(this.uctxtAddress1_GotFocus);
          

            this.uctxtPostal.GotFocus += new System.EventHandler(this.uctxtPostal_GotFocus);
            this.uctxtPostal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uctxtPostal_KeyPress);

            this.uctxtFax.GotFocus += new System.EventHandler(this.uctxtFax_GotFocus);
            this.uctxtFax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uctxtFax_KeyPress);

            this.uctxtEMail.GotFocus += new System.EventHandler(this.uctxtEMail_GotFocus);
            this.uctxtEMail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uctxtEMail_KeyPress);

            this.txtComments.GotFocus += new System.EventHandler(this.txtComments_GotFocus);
            this.txtComments.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtComments_KeyPress);

            this.uctxtUnder.KeyDown += new KeyEventHandler(uctxtUnder_KeyDown);
            this.uctxtUnder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtUnder_KeyPress);
            this.uctxtUnder.TextChanged += new System.EventHandler(this.uctxtUnder_TextChanged);
            this.lstUnder.DoubleClick += new System.EventHandler(this.lstUnder_DoubleClick);
            this.uctxtUnder.GotFocus += new System.EventHandler(this.uctxtUnder_GotFocus);

            this.uctxtCostCentre.KeyDown += new KeyEventHandler(uctxtCostCentre_KeyDown);
            this.uctxtCostCentre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtCostCentre_KeyPress);
            this.uctxtCostCentre.TextChanged += new System.EventHandler(this.uctxtCostCentre_TextChanged);
            this.lstCostCenter.DoubleClick += new System.EventHandler(this.lstCostCenter_DoubleClick);
            this.uctxtCostCentre.GotFocus += new System.EventHandler(this.uctxtCostCentre_GotFocus);

            this.txtBillWise.KeyDown += new KeyEventHandler(txtBillWise_KeyDown);
            this.txtBillWise.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtBillWise_KeyPress);
            this.txtBillWise.TextChanged += new System.EventHandler(this.txtBillWise_TextChanged);
            this.lsteffectInventory.DoubleClick += new System.EventHandler(this.lsteffectInventory_DoubleClick);
            this.txtBillWise.GotFocus += new System.EventHandler(this.txtBillWise_GotFocus);


            this.txtPriceLevel.KeyDown += new KeyEventHandler(txtPriceLevel_KeyDown);
            this.txtPriceLevel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtPriceLevel_KeyPress);
            this.txtPriceLevel.TextChanged += new System.EventHandler(this.txtPriceLevel_TextChanged);
            this.lstPriceLebel.DoubleClick += new System.EventHandler(this.lstPriceLebel_DoubleClick);
            this.txtPriceLevel.GotFocus += new System.EventHandler(this.txtPriceLevel_GotFocus);

            this.uctxtInactive.KeyDown += new KeyEventHandler(uctxtInactive_KeyDown);
            this.uctxtInactive.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtInactive_KeyPress);
            this.uctxtInactive.TextChanged += new System.EventHandler(this.uctxtInactive_TextChanged);
            this.lstInactive.DoubleClick += new System.EventHandler(this.lstInactive_DoubleClick);
            this.uctxtInactive.GotFocus += new System.EventHandler(this.uctxtInactive_GotFocus);

            this.uctxtCurrency.KeyDown += new KeyEventHandler(uctxtCurrency_KeyDown);
            this.uctxtCurrency.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtCurrency_KeyPress);
            this.uctxtCurrency.TextChanged += new System.EventHandler(this.uctxtCurrency_TextChanged);
            this.lstcurrency.DoubleClick += new System.EventHandler(this.lstcurrency_DoubleClick);
            this.uctxtCurrency.GotFocus += new System.EventHandler(this.uctxtCurrency_GotFocus);

            this.DgCostCenter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(DgCostCenter_KeyPress);


            this.uctxtBranch.KeyDown += new KeyEventHandler(uctxtBranch_KeyDown);
            this.uctxtBranch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranch_KeyPress);
            this.uctxtBranch.TextChanged += new System.EventHandler(this.uctxtBranch_TextChanged);
            this.lstLedgerBranch.DoubleClick += new System.EventHandler(this.lstLedgerBranch_DoubleClick);
            this.uctxtBranch.GotFocus += new System.EventHandler(this.uctxtBranch_GotFocus);

            this.uctxtCostCategory.KeyDown += new KeyEventHandler(uctxtCostCategory_KeyDown);
            this.uctxtCostCategory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtCostCategory_KeyPress);
            this.uctxtCostCategory.TextChanged += new System.EventHandler(this.uctxtCostCategory_TextChanged);
            this.lstCostCategory.DoubleClick += new System.EventHandler(this.lstCostCategory_DoubleClick);
            this.uctxtCostCategory.GotFocus += new System.EventHandler(this.uctxtCostCategory_GotFocus);


            this.uctxtCostCenterNew.KeyDown += new KeyEventHandler(uctxtCostCenterNew_KeyDown);
            this.uctxtCostCenterNew.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtCostCenterNew_KeyPress);
            this.uctxtCostCenterNew.TextChanged += new System.EventHandler(this.uctxtCostCenterNew_TextChanged);
            this.lstCostCenterNew.DoubleClick += new System.EventHandler(this.lstCostCenterNew_DoubleClick);
            this.uctxtCostCenterNew.GotFocus += new System.EventHandler(this.uctxtCostCenterNew_GotFocus);

            this.uctxtAmount.GotFocus += new System.EventHandler(this.uctxtAmount_GotFocus);
            this.uctxtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtAmount_KeyPress);

            this.dgBranch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dgBranch_KeyPress);


            this.txtBillWiseBranch.KeyDown += new KeyEventHandler(txtBillWiseBranch_KeyDown); 
            this.txtBillWiseBranch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtBillWiseBranch_KeyPress);
            this.txtBillWiseBranch.TextChanged += new System.EventHandler(this.txtBillWiseBranch_TextChanged);
            this.lstBillwiseBranch.DoubleClick += new System.EventHandler(this.lstBillwiseBranch_DoubleClick);
            this.txtBillWiseBranch.GotFocus += new System.EventHandler(this.txtBillWiseBranch_GotFocus);

            this.dteBillDate.GotFocus += new System.EventHandler(this.dteBillDate_GotFocus);
            this.txtBillRefNo.GotFocus += new System.EventHandler(this.txtBillRefNo_GotFocus);
            this.dtedueDate.GotFocus += new System.EventHandler(this.dtedueDate_GotFocus);
            this.txtBillAmount.GotFocus += new System.EventHandler(this.txtBillAmount_GotFocus);
            this.txtBillDrcr.GotFocus += new System.EventHandler(this.txtBillDrcr_GotFocus);

            this.txtBillWiseBranch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtBillWiseBranch_KeyPress);
            this.dteBillDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteBillDate_KeyPress);
            this.txtBillRefNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtBillRefNo_KeyPress);
            this.dtedueDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dtedueDate_KeyPress);
            this.txtBillAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtBillAmount_KeyPress);
            this.txtBillDrcr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtBillDrcr_KeyPress);

            this.uctxtResignDate.GotFocus += new System.EventHandler(this.uctxtResignDate_GotFocus);
            this.uctxtResignDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtResignDate_KeyPress);

            this.cboCommission.GotFocus += new System.EventHandler(this.cboCommission_GotFocus);
            this.cboCommission.KeyPress += new System.Windows.Forms.KeyPressEventHandler(cboCommission_KeyPress);
            this.uctxtAddress1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uctxtAddress1_KeyPress);

            this.dgBranch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgBranch_KeyDown);
            this.txtCountry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCountry_KeyPress);
            this.txtPeriod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPeriod_KeyPress);

            this.uctxtTerritoryCode.GotFocus += new System.EventHandler(this.uctxtTerritoryCode_GotFocus);
            this.uctxtTerritoryCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtTerritoryCode_KeyPress);
            this.uctxtTerritoryCode.KeyDown += new KeyEventHandler(uctxtTerritoryCode_KeyDown);
            this.uctxtTerritoryCode.TextChanged += new System.EventHandler(this.uctxtTerritoryCode_TextChanged);
            this.lstTeritorryCode.DoubleClick += new System.EventHandler(this.lstTeritorryCode_DoubleClick);

            this.uctxtTeritorryName.KeyDown += new KeyEventHandler(uctxtTeritorryName_KeyDown);
            this.uctxtTeritorryName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtTeritorryName_KeyPress);
            this.uctxtTeritorryName.TextChanged += new System.EventHandler(this.uctxtTeritorryName_TextChanged);
            this.lstTeritorryName.DoubleClick += new System.EventHandler(this.lstTeritorryName_DoubleClick);
            this.uctxtTeritorryName.GotFocus += new System.EventHandler(this.uctxtTeritorryName_GotFocus);

            this.uctxtLedgerBranch.KeyDown += new KeyEventHandler(uctxtLedgerBranch_KeyDown);
            this.uctxtLedgerBranch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtLedgerBranch_KeyPress);
            this.uctxtLedgerBranch.TextChanged += new System.EventHandler(this.uctxtLedgerBranch_TextChanged);
            //this.lstBranchName.DoubleClick += new System.EventHandler(this.lstBranchName_DoubleClick);
            this.uctxtLedgerBranch.GotFocus += new System.EventHandler(this.uctxtLedgerBranch_GotFocus);

            Utility.CreateListBox(lstUnder, pnlMain, uctxtUnder);
            Utility.CreateListBox(lstCostCenter, pnlMain, uctxtCostCentre);
            Utility.CreateListBox(lstcurrency, pnlMain, uctxtCurrency);
            Utility.CreateListBox(lsteffectInventory, pnlMain, txtBillWise);
            Utility.CreateListBox(lstPriceLebel, pnlMain, txtPriceLevel);
            Utility.CreateListBox(lstBranchName, pnlCostCenter, uctxtBranch, uctxtCostCenterNew.Width);
            Utility.CreateListBox(lstCostCategory, pnlCostCenter, uctxtCostCategory, 100);
            Utility.CreateListBox(lstCostCenterNew, pnlCostCenter, uctxtCostCenterNew, 100);
            Utility.CreateListBox(lstBillwiseBranch, pnlBillWise, txtBillWiseBranch, 100);
            Utility.CreateListBox(lstInactive, pnlMain, uctxtInactive);            //Load Listview
            Utility.CreateListBox(lstTeritorryCode, pnlMain, uctxtTerritoryCode);            //Load Listview
            Utility.CreateListBox(lstTeritorryName, pnlMain, uctxtTeritorryName);            //Load Listview
            Utility.CreateListBox(lstTeritorryName, pnlMain, uctxtTeritorryName);
            Utility.CreateListBox(lstLedgerBranch, pnlMain, uctxtLedgerBranch);
            Utility.CreateListBoxHeight(lstPFLedger, pnlMain, txtPFLedger, 0, 200);
            Utility.CreateListBoxHeight(lstHLLedger, pnlMain, txtHLLedger, 0, 100);
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
        #region "Keydown"
        private void txtPeriod_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumericNew(txtPeriod.Text) == false)
            {
                txtPeriod.Text = "";
            }
        }
        private void uctxtMpoName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R && e.Modifiers == Keys.Control)
            {
                //uctxtMpoName.Text = Interaction.GetSetting(Application.ExecutablePath, "frmCustomer", "MPO Name");
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
                uctxtMpoName.AppendText((String)rk.GetValue("MPO Name", ""));
                rk.Close();
            }

        }
        private void uctxtOpeningBalance_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumericNew(uctxtOpeningBalance.Text) == false)
            {
                uctxtOpeningBalance.Text = "";
            }
        }
        private void txtCreditLimit_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumericNew(txtCreditLimit.Text) == false)
            {
                txtCreditLimit.Text = "";
            }
        }
        private void txtCountry_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtContact.Focus();

            }
            //if (e.KeyChar == (char)Keys.Back)
            //{
            //    Utility.PriorSetFocusText(txtCountry, sender, e);
            //}
        }

        private void dgBranch_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                e.SuppressKeyPress = true;
                int iColumn = dgBranch.CurrentCell.ColumnIndex;
                int iRow = dgBranch.CurrentCell.RowIndex;
                if (iColumn == dgBranch.Columns.Count - 1)
                    btnBranchApply.PerformClick();
                else
                    dgBranch.CurrentCell = dgBranch[iColumn + 1, iRow];


            }
        }
        #endregion
        #region "PriorSetFocus"
        private void txtPeriod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtCreditDate.Focus();
            }
            //if (e.KeyChar == (char)Keys.Back)
            //{
            //    PriorSetFocusText(txtPeriod, sender, e);
            //}
        }
        //private void PriorSetFocusText(TextBox txtbox, object sender, KeyPressEventArgs e)
        //{

        //    if (e.KeyChar == (char)Keys.Back)
        //    {
        //        if (txtbox.SelectionLength > 0)
        //        {
        //            txtbox.SelectionLength = 0;

        //            this.SelectNextControl((Control)sender, false, true, true, true);
        //        }
        //        else
        //        {
        //            if ((e.KeyChar == (char)Keys.Back) & (((Control)sender).Text.Length == 0))
        //            {

        //                this.SelectNextControl((Control)sender, false, true, true, true);
        //            }
        //        }
        //    }


        //}
        //private void PriorSetFocusCombo(ComboBox txtbox, object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Back)
        //    {
        //        if (txtbox.SelectionLength > 0)
        //        {
        //            txtbox.SelectionLength = 0;

        //            this.SelectNextControl((Control)sender, false, true, true, true);
        //        }
        //        else
        //        {
        //            if ((e.KeyChar == (char)Keys.Back) & (((Control)sender).Text.Length == 0))
        //            {

        //                this.SelectNextControl((Control)sender, false, true, true, true);
        //            }
        //        }
        //    }
        //}

        #endregion
        #region "Change Opening"
        private void mChangeOpening(string vstrDrCr)
        {
            double dblDebit, dblCredit, dblDiff;

            
            if (m_acction == (int)Utility.ACTION_MODE_ENUM.EDIT_MODE)
            {
                if (mdblOpeningBalance < 0)
                {
                    mdblDebit = Utility.Val(lblDebit.Text) + mdblOpeningBalance;
                }
                if (mdblOpeningBalance > 0)
                {
                    mdblCredit = Utility.Val(lblCredit.Text) - mdblOpeningBalance;
                }
            }

            if (vstrDrCr == "Dr")
            {
                dblDebit = mdblDebit + Utility.Val(uctxtOpeningBalance.Text);
                lblDebit.Text = dblDebit.ToString() + " Dr";
                lblCredit.Text = mdblCredit.ToString() + " Cr";
                dblDiff = Math.Round(mdblCredit - dblDebit,2);
                if (dblDiff < 0)
                {
                    lblDifference.Text = Math.Abs(dblDiff).ToString() + " Dr";
                }
                else if (dblDiff > 0)
                {
                    lblDifference.Text = Math.Abs(dblDiff).ToString() + " Cr";
                }
                else
                {
                    lblDifference.Text = "0";
                }
            }

            if (vstrDrCr == "Cr")
            {
                dblCredit = mdblCredit + Utility.Val(uctxtOpeningBalance.Text); ;
                lblDebit.Text = mdblDebit + " Dr";
                lblCredit.Text = dblCredit.ToString() + " Cr";
                dblDiff = Math.Round(dblCredit - mdblDebit,2);
                if (dblDiff < 0)
                {
                    lblDifference.Text = Math.Abs(dblDiff).ToString() + " Dr";
                }
                else if (dblDiff > 0)
                {
                    lblDifference.Text = Math.Abs(dblDiff).ToString() + " Cr";
                }
                else
                {
                    lblDifference.Text = "0";
                }
                if (m_acction == (int)Utility.ACTION_MODE_ENUM.EDIT_MODE)
                {
                    if (mdblOpeningBalance < 0)
                    {
                        mdblDebit = mdblDebit - mdblOpeningBalance;
                    }
                    if (mdblOpeningBalance > 0)
                    {
                        mdblCredit = mdblCredit + mdblOpeningBalance;
                    }
                }
            }

        }
        #endregion
        #region "AddItem"
        private void mAdditemBill(string strBranchName, string strDdate, string strRfeNo,string strdueDate, double dblnetamount,string strDrcr)
        {
            int selRaw;

            string strDown = "";
            Boolean blngCheck = false;
            for (int j = 0; j < dgBillBranch.RowCount; j++)
            {
                if (dgBillBranch[2, j].Value != null)
                {
                    strDown = dgBillBranch[2, j].Value.ToString();
                }
                if (strRfeNo == strDown.ToString())
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
                dgBillBranch[0, selRaw].Value = strBranchName.ToString();
                dgBillBranch[1, selRaw].Value = strDdate.ToString();
                dgBillBranch[2, selRaw].Value = strRfeNo.ToString();
                dgBillBranch[3, selRaw].Value = strdueDate.ToString();
                dgBillBranch[4, selRaw].Value = dblnetamount.ToString();
                dgBillBranch[5, selRaw].Value = strDrcr.ToString();
                dgBillBranch.AllowUserToAddRows = false;
                txtBillWiseBranch.Text = "";
                txtBillRefNo.Text = "";
                txtBillAmount.Text = "";
                calculateTotal();
            }

        }
        private void mAdditem(string strBranchName, string strCostCategory, string strCostCenter, double dblnetamount)
        {
            int selRaw;

            string strDown = "";
            Boolean blngCheck = false;
            for (int j = 0; j < DgCostCenter.RowCount; j++)
            {
                if (DgCostCenter[2, j].Value != null)
                {
                    strDown = DgCostCenter[2, j].Value.ToString();
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
                DgCostCenter[0, selRaw].Value = strBranchName.ToString();
                DgCostCenter[1, selRaw].Value = strCostCategory.ToString();
                DgCostCenter[2, selRaw].Value = strCostCenter.ToString();
                DgCostCenter[3, selRaw].Value = dblnetamount.ToString();
                DgCostCenter.AllowUserToAddRows = false;
                txtBillWiseBranch.Text = "";
                txtBillRefNo.Text = "";
                txtBillAmount.Text = "";
                txtBillDrcr.Text = uctxtDrCr.Text;
                calculateTotal();
            }

        }
        #endregion
        #region "Calculatetotal
        private void calculateTotal()
        {
            double dblNetAmount = 0, dblBranchTotal = 0, dblBillTotal = 0;
            for (int i = 0; i < DgCostCenter.Rows.Count; i++)
            {
                dblNetAmount = dblNetAmount + Convert.ToDouble(DgCostCenter.Rows[i].Cells[3].Value);
            }
            for (int i = 0; i < dgBranch.Rows.Count - 1; i++)
            {
                dblBranchTotal = dblBranchTotal + Convert.ToDouble(dgBranch.Rows[i].Cells[1].Value);
            }
            for (int i = 0; i < dgBillBranch.Rows.Count; i++)
            {
                dblBillTotal = dblBillTotal + Convert.ToDouble(dgBillBranch.Rows[i].Cells[4].Value);
            }
            txtTotal.Text = dblNetAmount.ToString();
            txtBranchTotal.Text = dblBranchTotal.ToString();
            txtBillTotal.Text = dblBillTotal.ToString();
        }
        #endregion
        #region "User Define"
        private void txtHLLedger_TextChanged(object sender, EventArgs e)
        {
         
            lstPFLedger.Visible = false  ;
            lstHLLedger.Visible = true;
            lstHLLedger.SelectedIndex = lstHLLedger.FindString(txtHLLedger.Text);
        }

        private void lstHLLedger_DoubleClick(object sender, EventArgs e)
        {
            txtHLLedger.Text = lstHLLedger.Text;
            lstHLLedger.Visible = false;
            btnSave.Focus();
        }

        private void txtHLLedger_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
               
                if (txtHLLedger.Text != "")
                {
                    txtHLLedger.Text = lstHLLedger.Text;
                    lstHLLedger.Visible = false;
                    btnSave.Focus();
                }
                else
                {
                    lstHLLedger.Visible = false;
                    btnSave.Focus();
                }



            }
        }
        private void txtHLLedger_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstHLLedger.SelectedItem != null)
                {
                    lstHLLedger.SelectedIndex = lstHLLedger.SelectedIndex - 1;
                    txtHLLedger.Text = lstPFLedger.Text;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstHLLedger.Items.Count - 1 > lstHLLedger.SelectedIndex)
                {
                    lstHLLedger.SelectedIndex = lstHLLedger.SelectedIndex + 1;
                    txtHLLedger.Text = lstHLLedger.Text;
                }
            }

        }

        private void txtHLLedger_GotFocus(object sender, System.EventArgs e)
        {
            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstPriceLebel.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            lstLedgerBranch.Visible = false;
            lstPFLedger.Visible = false;
            lstHLLedger.Visible = false;
            lstHLLedger.SelectedIndex = lstHLLedger.FindString(txtHLLedger.Text);
        }

        private void txtPFLedger_TextChanged(object sender, EventArgs e)
        {
            lstPFLedger.Visible = true;
            lstHLLedger.Visible = false;
            lstPFLedger.SelectedIndex = lstPFLedger.FindString(txtPFLedger.Text);
        }

        private void lstPFLedger_DoubleClick(object sender, EventArgs e)
        {
            txtPFLedger.Text = lstPFLedger.Text;
            lstPFLedger.Visible = false;
            txtHLLedger.Focus();
        }

        private void txtPFLedger_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                
                if (txtPFLedger.Text != "")
                {
                    txtPFLedger.Text = lstPFLedger.Text;
                    txtHLLedger.Focus();
                    lstPFLedger.Visible = false;
                }
                else
                {
                 
                    txtHLLedger.Focus();
                    lstPFLedger.Visible = false;
                }



            }
        }
        private void txtPFLedger_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstPFLedger.SelectedItem != null)
                {
                    lstPFLedger.SelectedIndex = lstPFLedger.SelectedIndex - 1;
                    txtPFLedger.Text = lstPFLedger.Text;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstPFLedger.Items.Count - 1 > lstPFLedger.SelectedIndex)
                {
                    lstPFLedger.SelectedIndex = lstPFLedger.SelectedIndex + 1;
                    txtPFLedger.Text = lstPFLedger.Text;
                }
            }

        }

        private void txtPFLedger_GotFocus(object sender, System.EventArgs e)
        {
            lstCostCategory.Visible = false;
            lstCostCenterNew.Visible = false;
            lstUnder.Visible = false;
            lstcurrency.Visible = false;
            lstInactive.Visible = false;
            lsteffectInventory.Visible = false;
            lstPFLedger.Visible = true;
            lstHLLedger.Visible = false;
            lstPFLedger.SelectedIndex = lstPFLedger.FindString(txtPFLedger.Text);
        }

        //************
        private void txtCloseDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtCloseDate.Text = Utility.ctrlDateFormat(txtCloseDate.Text);
                cboCommission.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(txtCloseDate, uctxtResignDate);
            }
        }
        private void txtCloseDate_GotFocus(object sender, System.EventArgs e)
        {
            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstPriceLebel.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            lstLedgerBranch.Visible = false;
            lstPFLedger.Visible = false ;
            lstHLLedger.Visible = false;
        }
        private void cboBkash_GotFocus(object sender, System.EventArgs e)
        {
            lstBillwiseBranch.Visible = false;
            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstPriceLebel.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            lstLedgerBranch.Visible = false;
            lstPFLedger.Visible = false;
            lstHLLedger.Visible = false;
        }
        private void cboBkash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtComments.Focus();
            }

        }
        private void uctxtLedgerBranch_TextChanged(object sender, EventArgs e)
        {
            lstLedgerBranch.SelectedIndex = lstLedgerBranch.FindString(uctxtLedgerBranch.Text);
        }

        //private void lstBranchName_DoubleClick(object sender, EventArgs e)
        //{
        //    uctxtLedgerBranch.Text = lstLedgerBranch.Text;
        //    if (uctxtTerritoryCode.Enabled)
        //    {
        //        uctxtTerritoryCode.Focus();
        //    }
        //    else
        //    {
        //        uctxtMpoName.Focus();
        //    }
        //}

        private void uctxtLedgerBranch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstLedgerBranch.Items.Count>0)
                {
                    uctxtLedgerBranch.Text = lstLedgerBranch.Text;
                }
                if (uctxtTerritoryCode.Enabled)
                {
                    uctxtTerritoryCode.Focus();
                }
                else
                {
                    uctxtMpoName.Focus();
                }
            }
            //if (e.KeyChar == (char)Keys.Back)
            //{
            //    PriorSetFocusText(uctxtLedgerBranch, sender, e);
            //}
        }
        private void uctxtLedgerBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstLedgerBranch.SelectedItem != null)
                {
                    lstLedgerBranch.SelectedIndex = lstLedgerBranch.SelectedIndex - 1;
                    uctxtLedgerBranch.Text = lstLedgerBranch.Text;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstLedgerBranch.Items.Count - 1 > lstLedgerBranch.SelectedIndex)
                {
                    lstLedgerBranch.SelectedIndex = lstLedgerBranch.SelectedIndex + 1;
                    uctxtLedgerBranch.Text = lstBranchName.Text;
                }
            }

        }

        private void uctxtLedgerBranch_GotFocus(object sender, System.EventArgs e)
        {
            lstBillwiseBranch.Visible = false;
            lstPFLedger.Visible = false;
            lstHLLedger.Visible = false;
            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstPriceLebel.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            lstLedgerBranch.Visible = true;
       
            

            lstLedgerBranch.ValueMember = "BranchID";
            lstLedgerBranch.DisplayMember = "BranchName";
            lstLedgerBranch.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
            lstLedgerBranch.SelectedIndex = lstBranchName.FindString(uctxtLedgerBranch.Text);
        }

        private void cboClass_GotFocus(object sender, System.EventArgs e)
        {
            lstBillwiseBranch.Visible = false;
            lstPFLedger.Visible = false;
            lstHLLedger.Visible = false;
            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstPriceLebel.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            lstLedgerBranch.Visible = false;
           
        }
        private void cboClass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtPeriod.Focus();
            }
            
        }


        private void lstTeritorryName_DoubleClick(object sender, EventArgs e)
        {
            uctxtTeritorryName.Text = lstTeritorryName.Text;
            uctxtTerritoryCode.Text = Utility.GetTeritorryCode(strComID, uctxtTeritorryName.Text);
            uctxtMpoName.Focus();


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
                if (lstTeritorryName.Items.Count > 0)
                {
                    uctxtTeritorryName.Text = lstTeritorryName.Text;
                    uctxtTerritoryCode.Text = Utility.GetTeritorryCode(strComID, uctxtTeritorryName.Text);

                }
                if (uctxtTeritorryName.Text == "")
                {
                    uctxtTeritorryName.Focus();
                }
                else
                {
                    uctxtMpoName.Focus();
                }
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtTeritorryName, uctxtTerritoryCode);
            }
        }


        private void uctxtTerritoryCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                
                if (lstTeritorryCode.Items.Count > 0)
                {
                    uctxtTerritoryCode.Text = lstTeritorryCode.Text;
                    uctxtTeritorryName.Text = Utility.GetTeritorryName(strComID, uctxtTerritoryCode.Text);
                }
                if (uctxtTeritorryName.Text == "")
                {
                    uctxtTeritorryName.Focus();
                }
                else
                {
                    uctxtMpoName.Focus();
                }
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtTerritoryCode, uctxtLedgerBranch);
            }
        }
        private void uctxtTerritoryCode_GotFocus(object sender, System.EventArgs e)
        {
            lstBillwiseBranch.Visible = false;
            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstPFLedger.Visible = false;
            lstHLLedger.Visible = false;
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstPriceLebel.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
            lstTeritorryName.Visible = false;
            lstLedgerBranch.Visible = false;
            //lstTeritorryCode.Visible = true ;
            lstTeritorryCode.SelectedIndex = lstTeritorryCode.FindString(uctxtTerritoryCode.Text);
        }
        private void uctxtTerritoryCode_TextChanged(object sender, EventArgs e)
        {
            
            lstTeritorryCode.SelectedIndex = lstTeritorryCode.FindString(uctxtTerritoryCode.Text);
        }

        private void lstTeritorryCode_DoubleClick(object sender, EventArgs e)
        {
            uctxtTerritoryCode.Text = lstTeritorryCode.Text;
            uctxtTeritorryName.Text = Utility.GetTeritorryName(strComID, uctxtTerritoryCode.Text);
            if (uctxtTeritorryName.Text == "")
            {
                uctxtTeritorryName.Focus();
            }
            else
            {
                uctxtMpoName.Focus();
            }


        }


        private void uctxtTerritoryCode_KeyDown(object sender, KeyEventArgs e)
        {
            lstTeritorryCode.Visible = true;
            if (e.KeyCode == Keys.Up)
            {
                if (lstTeritorryCode.SelectedItem != null)
                {
                    lstTeritorryCode.SelectedIndex = lstTeritorryCode.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstTeritorryCode.Items.Count - 1 > lstTeritorryCode.SelectedIndex)
                {
                    lstTeritorryCode.SelectedIndex = lstTeritorryCode.SelectedIndex + 1;
                }
            }

        }

       

        private void uctxtMpoName_TextChanged(object sender, EventArgs e)
        {
            int x = uctxtMpoName.SelectionStart;
            uctxtMpoName.Text = Utility.gmakeProperCase(uctxtMpoName.Text);
            uctxtMpoName.SelectionStart = x;
        }
       
        private void uctxtAddress1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtPhone.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtAddress1, uctxtCreditDate);
            }
        }
        private void uctxtEMail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtResignDate.Focus();
            }
            //if (e.KeyChar == (char)Keys.Back)
            //{
            //    PriorSetFocusText(uctxtEMail, sender, e);
            //}
        }

        private void uctxtFax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtResignDate.Focus();
            }
            //if (e.KeyChar == (char)Keys.Back)
            //{
            //    PriorSetFocusText(uctxtFax, sender, e);
            //}
        }

        private void uctxtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtContact.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtPhone, uctxtAddress1);
            }
        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtResignDate.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(txtContact, uctxtPhone);
            }
        }

        private void uctxtPostal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtContact.Focus();
            }
            //if (e.KeyChar == (char)Keys.Back)
            //{
            //    PriorSetFocusText(uctxtPostal, sender, e);
            //}
        }

       

        private void txtCreditLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtPeriod.Focus();
            }
            //if (e.KeyChar == (char)Keys.Back)
            //{
            //    PriorSetFocusText(txtCreditLimit, sender, e);
            //}
        }

       

        private void uctxtOpeningBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                mChangeOpening(uctxtDrCr.Text);
                uctxtDrCr.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtOpeningBalance, uctxtUnder);
            }
        }
        private void txtComments_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtPFLedger.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(txtComments, uctxtInactive);
               
            }
        }
        private void uctxtCreditDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtCreditDate.Text = Utility.ctrlDateFormat(uctxtCreditDate.Text);
                uctxtAddress1.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtCreditDate, uctxtDrCr);
            }
        }
        private void uctxtMpoName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (m_acction == 2)
                {
                    if (mstrOldLedger.Trim().ToUpper() != uctxtMpoName.Text.Trim().ToUpper())
                    {
                        string strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_LEDGER", "LEDGER_NAME", uctxtMpoName.Text);
                        if (strDuplicate != "")
                        {
                            MessageBox.Show(strDuplicate);
                            uctxtMpoName.Focus();
                            return;
                        }
                    }
                }
                else
                {
                    string strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_LEDGER", "LEDGER_NAME", uctxtMpoName.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        uctxtMpoName.Focus();
                        return;
                    }
                }
                uctxtUnder.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtMpoName, uctxtTerritoryCode);
            }
           

        }
      
        private void uctxtResignDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
            
                    uctxtResignDate.Text = Utility.ctrlDateFormat(uctxtResignDate.Text);
                    txtCloseDate.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtResignDate, txtContact);
            }
        }
        private void cboCommission_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtInactive.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                txtCloseDate.Focus();
            }
        }
        private void cboCommission_GotFocus(object sender, System.EventArgs e)
        {
            lstBillwiseBranch.Visible = false;
            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstPFLedger.Visible = false;
            lstHLLedger.Visible = false;
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstPriceLebel.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            lstLedgerBranch.Visible = false;
        }
        private void uctxtResignDate_GotFocus(object sender, System.EventArgs e)
        {
            lstBillwiseBranch.Visible = false;
            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstPFLedger.Visible = false;
            lstHLLedger.Visible = false;
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstPriceLebel.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            lstLedgerBranch.Visible = false;
        }
        private void txtBillDrcr_GotFocus(object sender, System.EventArgs e)
        {
            lstBillwiseBranch.Visible = false;
            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstPFLedger.Visible = false;
            lstHLLedger.Visible = false;
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstPriceLebel.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            lstLedgerBranch.Visible = false;
        }
        private void txtBillAmount_GotFocus(object sender, System.EventArgs e)
        {
            lstBillwiseBranch.Visible = false;
            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstPFLedger.Visible = false;
            lstHLLedger.Visible = false;
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstPriceLebel.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            lstLedgerBranch.Visible = false;
        }
        private void dtedueDate_GotFocus(object sender, System.EventArgs e)
        {
            lstBillwiseBranch.Visible = false;
            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstPriceLebel.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            lstLedgerBranch.Visible = false;
            lstPFLedger.Visible = false;
            lstHLLedger.Visible = false;
        }
        private void txtBillRefNo_GotFocus(object sender, System.EventArgs e)
        {
            lstBillwiseBranch.Visible = false;
            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstPriceLebel.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            lstPFLedger.Visible = false;
            lstHLLedger.Visible = false;
            lstLedgerBranch.Visible = false;
        }
        private void dteBillDate_GotFocus(object sender, System.EventArgs e)
        {
            lstBillwiseBranch.Visible = false;
            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstPriceLebel.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstPFLedger.Visible = false;
            lstHLLedger.Visible = false;
            lstCostCategory.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            lstLedgerBranch.Visible = false;
        }
        private void txtBillDrcr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (m_acction==2)
                {
                    txtBillAmount.Text = "0";
                }
                if (txtBillRefNo.Text != "")
                {
                    
                    {
                        mAdditemBill(txtBillWiseBranch.Text, dteBillDate.Text, txtBillRefNo.Text, dtedueDate.Text, Convert.ToDouble(txtBillAmount.Text), txtBillDrcr.Text);
                        txtBillAmount.Text = (Convert.ToDouble(txtBillPreTotal.Text) - Convert.ToDouble(txtBillTotal.Text)).ToString();
                    }
                    
                }
                    //txtBillDrcr.Text = uctxtDrCr.Text;
                    txtBillWiseBranch.Text = "";
                    txtBillRefNo.Text = "";
                
                txtBillWiseBranch.Focus();

            }
        }
        private void txtBillAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtBillDrcr.Focus();

            }
        }
        private void dtedueDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                txtBillAmount.Focus();

            }
        }
        private void txtBillRefNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                dtedueDate.Focus();

            }
        }

        private void dteBillDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                
                txtBillRefNo.Focus();

            }
        }

        private void txtBillWiseBranch_TextChanged(object sender, EventArgs e)
        {
            lstBillwiseBranch.Visible = true;
            lstBillwiseBranch.SelectedIndex = lstBillwiseBranch.FindString(txtBillWiseBranch.Text);
        }

        private void lstBillwiseBranch_DoubleClick(object sender, EventArgs e)
        {
            txtBillWiseBranch.Text = lstBillwiseBranch.Text;
            if (txtBillWiseBranch.Text != "")
            {
                dteBillDate.Focus();
            }
            else
            {
                btnBillapply.Focus();
            }

           
        }

        private void txtBillWiseBranch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtBillAmount.Text != "" && txtBillAmount.Text != "0")
                {
                    if (lstBillwiseBranch.Items.Count > 0)
                    {
                        txtBillWiseBranch.Text = lstBillwiseBranch.Text;
                    }
                    dteBillDate.Focus();
                }
                else
                {
                    lstBillwiseBranch.Visible = false;
                    btnBillapply.Focus();
                }

            }
        }
        private void txtBillWiseBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstBillwiseBranch.SelectedItem != null)
                {
                    lstBillwiseBranch.SelectedIndex = lstBillwiseBranch.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstBillwiseBranch.Items.Count - 1 > lstBillwiseBranch.SelectedIndex)
                {
                    lstBillwiseBranch.SelectedIndex = lstBillwiseBranch.SelectedIndex + 1;
                }
            }

        }

        private void txtBillWiseBranch_GotFocus(object sender, System.EventArgs e)
        {
            lstBillwiseBranch.Visible = false;
            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstPFLedger.Visible = false;
            lstHLLedger.Visible = false;
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstPriceLebel.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            lstLedgerBranch.Visible = false;
            lstBillwiseBranch.SelectedIndex = lstBillwiseBranch.FindString(txtBillWiseBranch.Text);
        }


        private void dgBranch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                if (txtBranchTotal.Text != "0")
                {
                    if (txtBranchPreTotal.Text != txtBranchTotal.Text)
                    {

                        MessageBox.Show("Amount is Mismatch");
                        return;
                    }
                }
                uctxtAddress1.Focus();

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
                        mAdditem(uctxtBranch.Text, uctxtCostCategory.Text, uctxtCostCenterNew.Text, Convert.ToDouble(uctxtAmount.Text));
                        uctxtCostCenterNew.Focus();
                        uctxtAmount.Text = (Convert.ToDouble(Utility.Val(txtpreAmount.Text)) - Convert.ToDouble(Utility.Val(txtTotal.Text))).ToString();
                        uctxtCostCenterNew.Text = "";
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

            }
        }
        private void uctxtAmount_GotFocus(object sender, System.EventArgs e)
        {
            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstPriceLebel.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
            lstTeritorryName.Visible = false;
            lstPFLedger.Visible = false;
            lstHLLedger.Visible = false;
            lstTeritorryCode.Visible = false;
            lstLedgerBranch.Visible = false;
        }
        private void uctxtCostCenterNew_TextChanged(object sender, EventArgs e)
        {

            lstCostCenterNew.SelectedIndex = lstCostCenterNew.FindString(uctxtCostCenterNew.Text);
        }

        private void lstCostCenterNew_DoubleClick(object sender, EventArgs e)
        {
            uctxtCostCenterNew.Text = lstCostCenterNew.Text;
            uctxtAmount.Focus();
        }

        private void uctxtCostCenterNew_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstCostCenterNew.Items.Count > 0)
                {
                    uctxtCostCenterNew.Text = lstCostCenterNew.Text;
                }

                uctxtAmount.Focus();

            }
        }
        private void uctxtCostCenterNew_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstCostCenterNew.SelectedItem != null)
                {
                    lstCostCenterNew.SelectedIndex = lstCostCenterNew.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstCostCenterNew.Items.Count - 1 > lstCostCenterNew.SelectedIndex)
                {
                    lstCostCenterNew.SelectedIndex = lstCostCenterNew.SelectedIndex + 1;
                }
            }

        }

        private void uctxtCostCenterNew_GotFocus(object sender, System.EventArgs e)
        {

            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstPFLedger.Visible = false;
            lstHLLedger.Visible = false;
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstPriceLebel.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = true;
            lstCostCategory.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            lstLedgerBranch.Visible = false;
            if (uctxtCostCategory.Text != "")
            {
                lstCostCenterNew.ValueMember = "strCostCenter";
                lstCostCenterNew.DisplayMember = "strCostCenter";
                lstCostCenterNew.DataSource = accms.mFillVectorMaster(strComID, uctxtCostCategory.Text).ToList();
            }
            lstCostCenterNew.SelectedIndex = lstCostCenterNew.FindString(uctxtCostCenterNew.Text);
        }
        private void uctxtCostCategory_TextChanged(object sender, EventArgs e)
        {
            lstCostCategory.SelectedIndex = lstCostCategory.FindString(uctxtCostCategory.Text);
        }

        private void lstCostCategory_DoubleClick(object sender, EventArgs e)
        {
            uctxtCostCategory.Text = lstCostCategory.Text;
            uctxtCostCenterNew.Focus();
        }

        private void uctxtCostCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstCostCategory.Items.Count > 0)
                {
                    uctxtCostCategory.Text = lstCostCategory.Text;
                }
                uctxtCostCenterNew.Focus();

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

            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstPFLedger.Visible = false;
            lstHLLedger.Visible = false;
            lstUnder.Visible = false;
            lstLedgerBranch.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstPriceLebel.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = true;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            lstLedgerBranch.Visible = false;
            lstCostCategory.SelectedIndex = lstCostCategory.FindString(uctxtCostCategory.Text);
        }
        private void uctxtBranch_TextChanged(object sender, EventArgs e)
        {
            lstBranchName.Visible = true;
            lstBranchName.SelectedIndex = lstLedgerBranch.FindString(uctxtBranch.Text);
        }

        private void lstLedgerBranch_DoubleClick(object sender, EventArgs e)
        {
            uctxtLedgerBranch.Text = lstLedgerBranch.Text;
            if (uctxtTerritoryCode.Enabled)
            {
                uctxtTerritoryCode.Focus();
            }
            else
            {
                uctxtMpoName.Focus();
            }
        }

        private void uctxtBranch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstLedgerBranch.Items.Count > 0)
                {
                    uctxtBranch.Text = lstLedgerBranch.Text;
                }
                uctxtCostCategory.Focus();

            }
        }
        private void uctxtBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstLedgerBranch.SelectedItem != null)
                {
                    lstLedgerBranch.SelectedIndex = lstLedgerBranch.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstLedgerBranch.Items.Count - 1 > lstLedgerBranch.SelectedIndex)
                {
                    lstLedgerBranch.SelectedIndex = lstLedgerBranch.SelectedIndex + 1;
                }
            }

        }

        private void uctxtBranch_GotFocus(object sender, System.EventArgs e)
        {
            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstPriceLebel.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
            lstTeritorryName.Visible = false;
            lstPFLedger.Visible = false;
            lstHLLedger.Visible = false;
            lstTeritorryCode.Visible = false;
            lstLedgerBranch.Visible = true;
            lstLedgerBranch.SelectedIndex = lstLedgerBranch.FindString(uctxtBranch.Text);
        }


        private void DgCostCenter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                pnlCostCenter.Visible = false;
                txtCreditLimit.Focus();
            }
        }
        private void uctxtDrCr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C)
            {
                uctxtDrCr.Text = "Cr";
                mChangeOpening(uctxtDrCr.Text);

            }
            if (e.KeyCode == Keys.D)
            {
                uctxtDrCr.Text = "Dr";
                mChangeOpening(uctxtDrCr.Text);
            }

        }
        private void mloadBrach()
        {
            int introw = 0;
            List<BranchConfig> ooBranch = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
            if (ooBranch.Count > 0)
            {
                foreach (BranchConfig ob in ooBranch)
                {
                    dgBranch.Rows.Add();
                    dgBranch[0, introw].Value = ob.BranchName;
                    introw += 1;
                }
                //dgBranch.AllowUserToAddRows = false;
                // ucGridAssetBranch.AllowUserToAddRows = false;
            }
        }
        private void uctxtDrCr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                mChangeOpening(uctxtDrCr.Text);
                if (uctxtCostCentre.Text == "NOne")
                {
                    if (Utility.Val(uctxtOpeningBalance.Text) > 0)
                    {
                        pnlCostCenter.Visible = true;
                        pnlCostCenter.Top = uctxtOpeningBalance.Top + 25;
                        pnlCostCenter.Left = uctxtOpeningBalance.Left;
                        pnlCostCenter.Size = new Size(687, 279);
                        DgCostCenter.Size = new Size(700, 183);
                        btnApply.Top = DgCostCenter.Height + 70;
                        btnCancel.Top = DgCostCenter.Height + 70;
                        btnApply.Left = 300;
                        btnCancel.Left = 388;
                        txtTotal.Top = DgCostCenter.Height + 70;
                        txtTotal.Left = 510;
                        txtpreAmount.Text = uctxtOpeningBalance.Text;
                        uctxtAmount.Text = uctxtOpeningBalance.Text;
                        uctxtBranch.Focus();
                    }
                }
                else
                {
                    if (Utility.gblnBranch)
                    {
                        if (pnlCostCenter.Visible == false)
                        {
                            if (Utility.Val(uctxtOpeningBalance.Text) > 0)
                            {
                                pnlBranch.Visible = true;
                                pnlBranch.Top = uctxtOpeningBalance.Top + 25;
                                pnlBranch.Left = uctxtOpeningBalance.Left;
                                pnlBranch.Size = new Size(639, 238);
                                dgBranch.Size = new Size(580, 163);
                                btnBranchApply.Top = dgBranch.Height + 40;
                                btnBranchApply.Left = 200;
                                btnBranchCancel.Left = 300;
                                btnBranchCancel.Top = dgBranch.Height + 40;
                                txtTotal.Top = DgCostCenter.Height + 70;
                                txtBranchPreTotal.Text = uctxtOpeningBalance.Text;
                                ///SendKeys.Send("{Enter}");
                                if (dgBranch.Rows.Count>0)
                                {
                                    if (m_acction == 1)
                                    {
                                        dgBranch[1, 0].Value = uctxtOpeningBalance.Text;
                                    }
                                }
                                dgBranch.Focus();
                                calculateTotal();
                              
                            }
                        }
                    }

                    if (txtBillWise.Text.ToUpper()=="YES" )
                    {
                        if (pnlBranch.Visible==false)
                        {
                            if (Utility.Val(uctxtOpeningBalance.Text) > 0)
                            {
                                pnlBillWise.Visible = true;
                                lblBillWise.Text = "Bill Wise Details for " + uctxtMpoName.Text;
                                pnlBillWise.Top = uctxtOpeningBalance.Top + 10;
                                pnlBillWise.Location = new Point(7, 334);
                                pnlBillWise.Size = new Size(716, 299);
                                txtBillPreTotal.Text = uctxtOpeningBalance.Text;
                                txtBillAmount.Text = uctxtOpeningBalance.Text;
                                txtBillDrcr.Text = uctxtDrCr.Text;
                                txtBillWiseBranch.Focus();
                            }

                        }
                    }
                    if (Utility.Val(uctxtOpeningBalance.Text) == 0)
                    {
                        cboClass.Focus();
                    }
                }

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtDrCr, uctxtOpeningBalance);
            }

        }

        private void txtComments_GotFocus(object sender, System.EventArgs e)
        {
            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstPriceLebel.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            lstLedgerBranch.Visible = false;
            lstPFLedger.Visible = false;
            lstHLLedger.Visible = false;
        }
        private void uctxtEMail_GotFocus(object sender, System.EventArgs e)
        {
            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstPriceLebel.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            lstLedgerBranch.Visible = false;
            lstPFLedger.Visible = false;
            lstHLLedger.Visible = false;
        }
        private void uctxtFax_GotFocus(object sender, System.EventArgs e)
        {
            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstPriceLebel.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            lstLedgerBranch.Visible = false;
            lstPFLedger.Visible = false;
            lstHLLedger.Visible = false;
        }
        private void uctxtPostal_GotFocus(object sender, System.EventArgs e)
        {
            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstPriceLebel.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            lstLedgerBranch.Visible = false;
            lstPFLedger.Visible = false;
            lstHLLedger.Visible = false;
        }
        private void uctxtTeritorryName_GotFocus(object sender, System.EventArgs e)
        {
            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstPriceLebel.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            lstLedgerBranch.Visible = false;
            lstPFLedger.Visible = false;
            lstHLLedger.Visible = false;
            lstTeritorryName.SelectedIndex = lstTeritorryName.FindString(uctxtTeritorryName.Text);
        }
        private void uctxtAddress1_GotFocus(object sender, System.EventArgs e)
        {
            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstPriceLebel.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            lstLedgerBranch.Visible = false;
            lstPFLedger.Visible = false;
            lstHLLedger.Visible = false;
        }
        private void txtPeriod_GotFocus(object sender, System.EventArgs e)
        {
            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstPriceLebel.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            lstLedgerBranch.Visible = false;
            lstPFLedger.Visible = false;
            lstHLLedger.Visible = false;
        }
        private void uctxtCreditDate_GotFocus(object sender, System.EventArgs e)
        {
            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstPriceLebel.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            lstLedgerBranch.Visible = false;
            lstPFLedger.Visible = false;
            lstHLLedger.Visible = false;
        }
        private void txtCreditLimit_GotFocus(object sender, System.EventArgs e)
        {
            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstPriceLebel.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            lstLedgerBranch.Visible = false;
            lstPFLedger.Visible = false;
            lstHLLedger.Visible = false;
        }
        private void uctxtDrCr_GotFocus(object sender, System.EventArgs e)
        {
            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstPriceLebel.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            lstLedgerBranch.Visible = false;
            lstPFLedger.Visible = false;
            lstHLLedger.Visible = false;
        }
        private void uctxtOpeningBalance_GotFocus(object sender, System.EventArgs e)
        {
            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstPriceLebel.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            lstLedgerBranch.Visible = false;
            lstPFLedger.Visible = false;
            lstHLLedger.Visible = false;
        }

        private void uctxtCurrency_TextChanged(object sender, EventArgs e)
        {
            lstcurrency.SelectedIndex = lstcurrency.FindString(uctxtCurrency.Text);
        }

        private void lstcurrency_DoubleClick(object sender, EventArgs e)
        {
            uctxtCurrency.Text = lstcurrency.Text;
            txtBillWise.Focus();
        }

        private void uctxtCurrency_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstcurrency.Items.Count > 0)
                {
                    uctxtCurrency.Text = lstcurrency.Text;
                }
                txtBillWise.Focus();
            }
            //if (e.KeyChar == (char)Keys.Back)
            //{
            //    Utility.PriorSetFocusText(uctxtCurrency, sender, e);
            //}
        }
        private void uctxtCurrency_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstcurrency.SelectedItem != null)
                {
                    lstcurrency.SelectedIndex = lstcurrency.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstcurrency.Items.Count - 1 > lstcurrency.SelectedIndex)
                {
                    lstcurrency.SelectedIndex = lstcurrency.SelectedIndex + 1;
                }
            }

        }

        private void uctxtCurrency_GotFocus(object sender, System.EventArgs e)
        {
            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = true;
            lstPriceLebel.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            lstPFLedger.Visible = false;
            lstHLLedger.Visible = false;
            lstLedgerBranch.Visible = false;
            lstcurrency.SelectedIndex = lstcurrency.FindString(uctxtCurrency.Text);
        }


        private void uctxtMpoName_GotFocus(object sender, System.EventArgs e)
        {
            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstPriceLebel.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            lstLedgerBranch.Visible = false;
            lstPFLedger.Visible = false;
            lstHLLedger.Visible = false;
        }
        private void uctxtInactive_TextChanged(object sender, EventArgs e)
        {
            lstInactive.SelectedIndex = lstInactive.FindString(uctxtInactive.Text);
        }

        private void lstInactive_DoubleClick(object sender, EventArgs e)
        {
            uctxtInactive.Text = lstInactive.Text;
            lstInactive.Visible = false;
            cboBkash.Focus();
        }

        private void uctxtInactive_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstInactive.Items.Count > 0)
                {
                    uctxtInactive.Text = lstInactive.Text;
                }
                lstInactive.Visible = false;
                cboBkash.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtInactive, uctxtResignDate);
            }
        }
        private void uctxtInactive_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstInactive.SelectedItem != null)
                {
                    lstInactive.SelectedIndex = lstInactive.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstInactive.Items.Count - 1 > lstInactive.SelectedIndex)
                {
                    lstInactive.SelectedIndex = lstInactive.SelectedIndex + 1;
                }
            }

        }

        private void uctxtInactive_GotFocus(object sender, System.EventArgs e)
        {
            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstUnder.Visible = false;
            lstInactive.Visible = true;
            lstcurrency.Visible = false;
            lstPriceLebel.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            lstLedgerBranch.Visible = false;
            lstPFLedger.Visible = false;
            lstHLLedger.Visible = false;
            lstInactive.SelectedIndex = lstInactive.FindString(uctxtInactive.Text);
        }
        private void txtPriceLevel_TextChanged(object sender, EventArgs e)
        {
            lstPriceLebel.SelectedIndex = lstPriceLebel.FindString(txtPriceLevel.Text);
        }

        private void lstPriceLebel_DoubleClick(object sender, EventArgs e)
        {
            txtPriceLevel.Text = lstPriceLebel.Text;
            uctxtOpeningBalance.Focus();
        }

        private void txtPriceLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstPriceLebel.Items.Count > 0)
                {
                    txtPriceLevel.Text = lstPriceLebel.Text;
                }
                uctxtOpeningBalance.Focus();

            }
            //if (e.KeyChar == (char)Keys.Back)
            //{

            //    Utility.PriorSetFocusText(txtPriceLevel, sender, e);
            //}
        }
        private void txtPriceLevel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstPriceLebel.SelectedItem != null)
                {
                    lstPriceLebel.SelectedIndex = lstPriceLebel.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstPriceLebel.Items.Count - 1 > lstPriceLebel.SelectedIndex)
                {
                    lstPriceLebel.SelectedIndex = lstPriceLebel.SelectedIndex + 1;
                }
            }

        }

        private void txtPriceLevel_GotFocus(object sender, System.EventArgs e)
        {
            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstPriceLebel.Visible = true;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            lstLedgerBranch.Visible = false;
            lstPFLedger.Visible = false;
            lstHLLedger.Visible = false;
            lstPriceLebel.SelectedIndex = lstPriceLebel.FindString(txtPriceLevel.Text);
        }
        private void txtBillWise_TextChanged(object sender, EventArgs e)
        {
            lstPriceLebel.SelectedIndex = lstPriceLebel.FindString(txtPriceLevel.Text);
        }

        private void lsteffectInventory_DoubleClick(object sender, EventArgs e)
        {
            txtBillWise.Text = lsteffectInventory.Text;
            txtPriceLevel.Focus();
        }

        private void txtBillWise_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lsteffectInventory.Items.Count > 0)
                {
                    txtBillWise.Text = lsteffectInventory.Text;
                }
                txtPriceLevel.Focus();

            }
            //if (e.KeyChar == (char)Keys.Back)
            //{
            //    PriorSetFocusText(txtBillWise, sender, e);
             
            //}

        }
        private void txtBillWise_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lsteffectInventory.SelectedItem != null)
                {
                    lsteffectInventory.SelectedIndex = lsteffectInventory.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lsteffectInventory.Items.Count - 1 > lsteffectInventory.SelectedIndex)
                {
                    lsteffectInventory.SelectedIndex = lsteffectInventory.SelectedIndex + 1;
                }
            }

        }

        private void txtBillWise_GotFocus(object sender, System.EventArgs e)
        {
            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = true;
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstPriceLebel.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
            lstTeritorryName.Visible = false;
            lstLedgerBranch.Visible = false;
            lstPFLedger.Visible = false;
            lstHLLedger.Visible = false;
            lstTeritorryCode.Visible = false;
            lsteffectInventory.SelectedIndex = lsteffectInventory.FindString(txtBillWise.Text);
        }


        private void uctxtCostCentre_TextChanged(object sender, EventArgs e)
        {
            lstCostCenter.SelectedIndex = lstCostCenter.FindString(uctxtCostCentre.Text);
        }

        private void lstCostCenter_DoubleClick(object sender, EventArgs e)
        {
            uctxtCostCentre.Text = lstCostCenter.Text;
            uctxtCurrency.Focus();
        }

        private void uctxtCostCentre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstCostCenter.Items.Count > 0)
                {
                    uctxtCostCentre.Text = lstCostCenter.Text;
                }
                uctxtCurrency.Focus();
            }
            //if (e.KeyChar == (char)Keys.Back)
            //{
            //    PriorSetFocusText(uctxtCostCentre, sender, e);
            //}
        }
        private void uctxtCostCentre_KeyDown(object sender, KeyEventArgs e)
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

        private void uctxtCostCentre_GotFocus(object sender, System.EventArgs e)
        {
            lstCostCenter.Visible = true;
            lsteffectInventory.Visible = false;
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstPriceLebel.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            lstLedgerBranch.Visible = false;
            lstPFLedger.Visible = false;
            lstHLLedger.Visible = false;
            lstCostCenter.SelectedIndex = lstCostCenter.FindString(uctxtCostCentre.Text);
        }
        private void uctxtUnder_TextChanged(object sender, EventArgs e)
        {
            lstUnder.SelectedIndex = lstUnder.FindString(uctxtUnder.Text);
        }

       

        private void lstUnder_DoubleClick(object sender, EventArgs e)
        {
            uctxtUnder.Text = lstUnder.Text;

            txtDisplay.Text = Utility.getDSMfromGrName(strComID, uctxtUnder.Text);
            uctxtOpeningBalance.Focus();
        }

        
        private void uctxtUnder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstUnder.Items.Count > 0)
                {
                    uctxtUnder.Text = lstUnder.Text;
                    txtDisplay.Text = Utility.getDSMfromGrName(strComID, uctxtUnder.Text);
                }
               

                uctxtOpeningBalance.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtUnder,uctxtMpoName);
            }
        }
        private void uctxtUnder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstUnder.SelectedItem != null)
                {
                    lstUnder.SelectedIndex = lstUnder.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstUnder.Items.Count - 1 > lstUnder.SelectedIndex)
                {
                    lstUnder.SelectedIndex = lstUnder.SelectedIndex + 1;
                }
            }

        }

        private void uctxtUnder_GotFocus(object sender, System.EventArgs e)
        {
            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstUnder.Visible = true;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstPriceLebel.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            lstLedgerBranch.Visible = false;
            lstPFLedger.Visible = false;
            lstHLLedger.Visible = false;
            lstUnder.SelectedIndex = lstUnder.FindString(uctxtUnder.Text);
        }

        #endregion
        #region "Tab change

        private void TabChange()
        {
            //uctxtMpoName.Focus();

            uctxtMpoName.AllToNextTab(uctxtUnder);
            uctxtUnder.AllToNextTab(uctxtCostCentre);
            uctxtCostCentre.AllToNextTab(uctxtCurrency);
            uctxtCurrency.AllToNextTab(txtBillWise);
            txtBillWise.AllToNextTab(txtPriceLevel);
            txtPriceLevel.AllToNextTab(uctxtOpeningBalance);

            uctxtOpeningBalance.AllToNextTab(uctxtDrCr);
            uctxtDrCr.AllToNextTab(txtCreditLimit);
            txtCreditLimit.AllToNextTab(uctxtCreditDate);
            uctxtCreditDate.AllToNextTab(txtPeriod);


            txtPeriod.AllToNextTab(uctxtAddress1);
            uctxtAddress1.AllToNextTab(uctxtTeritorryName);
            uctxtTeritorryName.AllToNextTab(uctxtPostal);
            uctxtPostal.AllToNextTab(uctxtPhone);
            uctxtPhone.AllToNextTab(uctxtFax);
            uctxtFax.AllToNextTab(uctxtEMail);
            uctxtEMail.AllToNextTab(txtComments);
            txtComments.AllToNextTab(uctxtInactive);
            uctxtInactive.AllToNextTab(btnSave);






        }
        #endregion
        #region "Load"
        private void frmCustomer_Load(object sender, EventArgs e)
        {
            uctxtLedgerBranch.Select();
            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstPriceLebel.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
            lstTeritorryName.Visible = false;
            lstTeritorryCode.Visible = false;
            lstPFLedger.Visible = false;
            lstHLLedger.Visible = false;

            lstBranchName.ValueMember = "BranchID";
            lstBranchName.DisplayMember = "BranchName";
            lstBranchName.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();

            lstBillwiseBranch.ValueMember = "BranchID";
            lstBillwiseBranch.DisplayMember = "BranchName";
            lstBillwiseBranch.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();

            lstcurrency.ValueMember = "strCurrency";
            lstcurrency.DisplayMember = "strCurrency";
            lstcurrency.DataSource = accms.mFillCurrencyList(strComID).ToList();

            lstCostCategory.ValueMember = "strVectorcategory";
            lstCostCategory.DisplayMember = "strVectorcategory";
            lstCostCategory.DataSource = accms.mFillVectorCategory(strComID).ToList();

            lstUnder.ValueMember = "GroupName";
            lstUnder.DisplayMember = "GroupName";
            //lstUnder.DataSource = accms.mFillGroup(strComID,intvtype).ToList();
            lstUnder.DataSource = accms.mFillGroupSales(strComID, intvtype).ToList();


            lstTeritorryCode.ValueMember = "strTeritorrycode";
            lstTeritorryCode.DisplayMember = "strTeritorrycode";
            lstTeritorryCode.DataSource = accms.mFillTeritorry(strComID, "").ToList();

            lstTeritorryName.ValueMember = "strTeritorryName";
            lstTeritorryName.DisplayMember = "strTeritorryName";
            lstTeritorryName.DataSource = accms.mFillTeritorry(strComID, "").ToList();


            lstHLLedger.ValueMember = "strLedgerName";
            lstHLLedger.DisplayMember = "strLedgerName";
            lstHLLedger.DataSource = accms.mFillHLLedger(strComID, 205, 0).ToList();

            lstPFLedger.ValueMember = "strLedgerName";
            lstPFLedger.DisplayMember = "strLedgerName";
            lstPFLedger.DataSource = accms.mFillPFLedger(strComID, 205).ToList();

            dgBranch.Columns.Add(Utility.Create_Grid_Column("Branch Name", "Branch Name", 370, true, DataGridViewContentAlignment.TopLeft, true));
            dgBranch.Columns.Add(Utility.Create_Grid_Column("Amount To", "Amount To", 150, true, DataGridViewContentAlignment.TopLeft, false));

            string strDiffenece = accms.mDisplayOpening(strComID);
            var results = strDiffenece.Split(new string[] { "~" }, StringSplitOptions.None);
            lblDebit.Text = results[0];
            lblCredit.Text = results[1];
            lblDifference.Text = results[2];
            mdblDebit = Utility.Val(results[0]);
            mdblCredit = Utility.Val(results[1]);

            LoadDefaultValue();
           
            if (Utility.gblnBranch)
            {
                mloadBrach();
            }

            //mChangeOpening(uctxtDrCr.Text);
        }
        #endregion
        #region "Display List"
        private void DisplayReqList(List<AccountsLedger> tests, object sender, EventArgs e)
        {
            try
            {
                uctxtTerritoryCode.Focus();
                List<AccountsLedger> ooled = accms.mDisplayLedgerList(strComID, tests[0].lngSlno).ToList();
                if (ooled.Count > 0)
                {
                    mlngSlNo = Convert.ToInt64(tests[0].lngSlno);
                    m_acction = 2;
                    uctxtLedgerBranch.Text = Utility.gstrGetBranchName(strComID, ooled[0].strBranchID);
                    strPreserveSQL = tests[0].strPreserveSQL;
                    intStatus = tests[0].intStatus;
                    uctxtMpoName.Text = ooled[0].strOldLedgerName;
                    mstrOldLedger = ooled[0].strOldLedgerName;
                    mstrOldTerritoryCode = ooled[0].strTeritorryCode;
                    uctxtUnder.Text = ooled[0].strUder;
                    txtDisplay.Text = Utility.getDSMfromGrName(strComID, uctxtUnder.Text);
                    if (ooled[0].intCostCenter == 1)
                    {
                        uctxtCostCentre.Text = "No";
                    }
                    else if (ooled[0].intCostCenter == 2)
                    {
                        uctxtCostCentre.Text = "Yes";
                    }
                    uctxtCurrency.Text = ooled[0].strCurrency;
                    if (ooled[0].intBillwise == 2)
                    {
                        txtBillWise.Text = "Yes";
                    }
                    else
                    {
                        txtBillWise.Text = "No";
                    }

                    uctxtTerritoryCode.Text = ooled[0].strTeritorryCode;
                    uctxtTeritorryName.Text = ooled[0].strTerritoryName;
                    txtPFLedger.Text = ooled[0].strPFLedger;
                    txtHLLedger.Text = ooled[0].strHLLedgerName;

                    uctxtOpeningBalance.Text = Math.Abs(ooled[0].dblOpnBalance).ToString();
                    mdblOpeningBalance = ooled[0].dblOpnBalance;
                    if (Convert.ToDouble(ooled[0].dblOpnBalance) < 0)
                    {
                        uctxtDrCr.Text = "Dr";
                    }
                    else if (Convert.ToDouble(ooled[0].dblOpnBalance) > 0)
                    {
                        uctxtDrCr.Text = "Cr";
                    }
                    txtContact.Text = ooled[0].strCantactPerson;
                    txtPeriod.Text = ooled[0].dblPeriod.ToString();
                    uctxtCreditDate.Text = ooled[0].strCreditDate;
                    uctxtAddress1.Text = ooled[0].strAddress;
                    //uctxtc.Text = ooled[0].strCity;
                    uctxtPostal.Text = ooled[0].strPostalCode;
                    uctxtPhone.Text = ooled[0].strPhone;
                    uctxtFax.Text = ooled[0].strFax;
                    uctxtEMail.Text = ooled[0].strEmail;
                    txtCloseDate.Text = ooled[0].strcloseDate;
                    if (ooled[0].intStatus == 1)
                    {
                        uctxtInactive.Text = "Yes";
                    }
                    else if (ooled[0].intStatus == 2)
                    {
                        uctxtInactive.Text = "Close";
                    }
                    else
                    {
                        uctxtInactive.Text = "No";
                    }
                    uctxtResignDate.Text = ooled[0].strResinDate;
                    cboCommission.Text = ooled[0].strCommission;
                    cboClass.Text = ooled[0].strClass;
                    if (ooled[0].intBkash == 1)
                    {
                        cboBkash.Text = "Yes";
                    }
                    else
                    {
                        cboBkash.Text = "No";
                    }
                    DgCostCenter.Rows.Clear();
                    dgBranch.Rows.Clear();
                    dgBillBranch.Rows.Clear();

                    double dblVectorAmount = 0, dblBrancAmount = 0, dblBillAmount = 0;

                    List<VectorCategory> oveg = accms.mDisplayVectorCategory(strComID, mstrOldLedger).ToList();
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
                                dblVectorAmount = dblVectorAmount + Math.Abs(vc.dblAmount);
                                i += 1;

                            }
                            dgBranch.AllowUserToAddRows = false;
                            txtTotal.Text = dblVectorAmount.ToString();
                        }
                    }
                    mloadBrach();
             
                    for (int introw = 0; introw < dgBranch.Rows.Count - 1; introw++)
                    {
              
                        string strBranchID = Utility.gstrGetBranchID(strComID, dgBranch.Rows[introw].Cells[0].Value.ToString());
                        List<BranchConfig> obranch = accms.mDisplayBranchOpening(strComID, mstrOldLedger, strBranchID).ToList();

                        if (obranch.Count != 0)
                        {
        
                            dgBranch.Rows[introw].Cells[1].Value = Math.Abs(obranch[0].dblbranchOpening);
                            dblBrancAmount = dblBrancAmount + Math.Abs(obranch[0].dblbranchOpening);
                        }
                        else
                        {
                            dgBranch.Rows[introw].Cells[1].Value = 0;
                        }
                   
                    }
                    //dgBranch.AllowUserToAddRows = false;
                    txtBranchTotal.Text = dblBrancAmount.ToString();

                    //    }
                    //}
                    List<AccBillwise> oBoll = accms.mLoadBillWise(strComID, mstrOldLedger).ToList();
                    {
                        if (oBoll.Count > 0)
                        {
                            int i = 0;
                            foreach (AccBillwise ooFixed in oBoll)
                            {
                                dgBillBranch.Rows.Add();
                                dgBillBranch.Rows[i].Cells[0].Value = Utility.gstrGetBranchName(strComID, ooFixed.Branch.BranchID);
                                dgBillBranch.Rows[i].Cells[1].Value = ooFixed.strDate;
                                dgBillBranch.Rows[i].Cells[2].Value = ooFixed.strRefNo;
                                dgBillBranch.Rows[i].Cells[3].Value = ooFixed.strDueDate;
                                dgBillBranch.Rows[i].Cells[4].Value = Math.Abs(ooFixed.dblAmount);
                                dgBillBranch.Rows[i].Cells[5].Value = ooFixed.strDrCr;
                                dblBillAmount = dblBillAmount + Math.Abs(ooFixed.dblAmount);
                                i += 1;
                            }
                            dgBranch.AllowUserToAddRows = false;
                            txtBillTotal.Text = dblBillAmount.ToString();

                        }
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
        #region "Click"
        private void LoadDefaultValue()
        {
            SortedDictionary<string, int> userCache = new SortedDictionary<string, int>
            {
              {"No", 1},
              {"Yes", 2}
            };

            lstCostCenter.DisplayMember = "Key";
            lstCostCenter.ValueMember = "Value";
            lstCostCenter.DataSource = new BindingSource(userCache, null);

            lsteffectInventory.DisplayMember = "Key";
            lsteffectInventory.ValueMember = "Value";
            lsteffectInventory.DataSource = new BindingSource(userCache, null);
            SortedDictionary<string, int> userCacheStatus = new SortedDictionary<string, int>
            {
              {"No", 1},
              {"Yes", 2},
              {"Close", 3}
            };

            lstInactive.DisplayMember = "Key";
            lstInactive.ValueMember = "Value";
            lstInactive.DataSource = new BindingSource(userCacheStatus, null);

            //string strDiffenece = accms.mDisplayOpening();
            //var results = strDiffenece.Split(new string[] { "~" }, StringSplitOptions.None);
            //lblDebit.Text = results[0];
            //lblCredit.Text = results[1];
            //lblDifference.Text = results[2];

        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (txtpreAmount.Text != txtTotal.Text)
            {
                MessageBox.Show("Cost Center Amount Mismatch");
                txtTotal.Focus();
                return;
            }
            pnlCostCenter.Visible = false;
            if (Utility.gblnBranch)
            {
                if (pnlCostCenter.Visible == false)
                {
                    if (uctxtOpeningBalance.Text != "" || uctxtOpeningBalance.Text == "0")
                    {
                        pnlBranch.Visible = true;
                        pnlBranch.Top = uctxtOpeningBalance.Top + 25;
                        pnlBranch.Left = uctxtOpeningBalance.Left;
                        pnlBranch.Size = new Size(582, 280);
                        dgBranch.Size = new Size(567, 203);
                        btnBranchApply.Top = DgCostCenter.Height + 70;
                        btnBranchApply.Left = 200;
                        btnBranchCancel.Left = 300;
                        btnBranchCancel.Top = DgCostCenter.Height + 70;
                        txtTotal.Top = DgCostCenter.Height + 70;
                        txtBranchPreTotal.Text = uctxtOpeningBalance.Text;
                        dgBranch.Focus();
                    }
                }
                if (txtBillWise.Text.ToUpper() == "YES")
                {
                    if (pnlBranch.Visible == false)
                    {
                        pnlBillWise.Visible = true;
                        lblBillWise.Text = "Bill Wise Details for " + uctxtMpoName.Text;
                        pnlBillWise.Top = uctxtOpeningBalance.Top + 10;
                        pnlBillWise.Location = new Point(7, 334);
                        pnlBillWise.Size = new Size(716, 299);
                        //txtBillPreTotal.Text = uctxtOpeningBalance.Text.ToString();
                        txtBillDrcr.Text = uctxtDrCr.Text;
                        txtBillWiseBranch.Focus();
                    }
                }
            }
            else if (txtBillWise.Text.ToUpper() == "YES")
                {
                    if (pnlBranch.Visible == false)
                    {
                        pnlBillWise.Visible = true;
                        lblBillWise.Text = "Bill Wise Details for " + uctxtMpoName.Text;
                        pnlBillWise.Top = uctxtOpeningBalance.Top + 10;
                        pnlBillWise.Location = new Point(7, 334);
                        pnlBillWise.Size = new Size(716, 299);
                        txtBillPreTotal.Text = uctxtOpeningBalance.Text.ToString();
                        txtBillAmount.Text = uctxtOpeningBalance.Text;
                        txtBillDrcr.Text = uctxtDrCr.Text;
                        txtBillWiseBranch.Focus();


                    }
                }
            else
            {
                txtCreditLimit.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtBranchPreTotal.Text) != Convert.ToDouble(txtBranchTotal.Text))
            {
                MessageBox.Show("Branch Total Mismatch");
                return;
            }
            pnlBranch.Visible = false;
            txtCreditLimit.Focus();
        }

        private void btnBranchApply_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(Utility.Val(txtBranchPreTotal.Text)) != Convert.ToDouble(Utility.Val(txtBranchTotal.Text)))
            {
                MessageBox.Show("Branch Total Mismatch");
                return;
            }
            pnlBranch.Visible = false;
            if (txtBillWise.Text.ToUpper() == "YES")
            {
                if (pnlBranch.Visible == false)
                {
                    pnlBillWise.Visible = true;
                    lblBillWise.Text = "Bill Wise Details for " + uctxtMpoName.Text;
                    pnlBillWise.Top = uctxtOpeningBalance.Top + 10;
                    pnlBillWise.Location = new Point(7, 334);
                    pnlBillWise.Size = new Size(716, 299);
                    txtBillPreTotal.Text = uctxtOpeningBalance.Text;
                    txtBillAmount.Text = uctxtOpeningBalance.Text;
                    txtBillDrcr.Text = uctxtDrCr.Text;
                    txtBillWiseBranch.Focus();
                }
            }
            else
            {
                cboClass.Focus();
            }
        }

        private void btnBranchCancel_Click(object sender, EventArgs e)
        {
            pnlBranch.Visible = false;
            txtCreditLimit.Focus();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            mClear();
            uctxtCurrency.Text = "BDT";
            uctxtDrCr.Text = "Dr";
            frmAccountsLedgerList objfrm = new frmAccountsLedgerList();
            //objfrm.mintLedgerGroup = (int)Utility.GR_GROUP_TYPE.grCUSTOMER;
            objfrm.mintLedgerGroup = intvtype;
            objfrm.onAddAllButtonClicked = new frmAccountsLedgerList.AddAllClick(DisplayReqList);
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.strMySQL = strPreserveSQL;
            objfrm.intLoadType = intStatus;
            objfrm.Show();
            objfrm.MdiParent = this.MdiParent;
           
        }

        private void btnNew1_Click(object sender, EventArgs e)
        {
            m_acction = 1;
        }
        #region "Validation Field"
        private bool ValidateFields()
        {
            string strDuplicate = "";
            if (uctxtTeritorryName.Text == "")
            {
                MessageBox.Show("Cannot be Empty");
                uctxtTeritorryName.Focus();
                return false;
            }
            if (uctxtTerritoryCode.Text == "")
            {
                MessageBox.Show("Cannot be Empty");
                uctxtTerritoryCode.Focus();
                return false;
            }
            if (uctxtMpoName.Text == "")
            {
                MessageBox.Show("Cannot be Empty");
                uctxtMpoName.Focus();
                return false;
            }
            if (uctxtUnder.Text == "")
            {
                MessageBox.Show("Cannot be Empty");
                uctxtUnder.Focus();
                return false;
            }

            if (cboClass.Text == "")
            {
                MessageBox.Show("Cannot be Empty");
                cboClass.Focus();
                return false;
            }
            if (m_acction == 2)
            {
                if (mstrOldLedger.Trim().ToUpper() != uctxtMpoName.Text.ToUpper())
                {
                    strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_LEDGER", "LEDGER_NAME", uctxtMpoName.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        uctxtMpoName.Focus();
                        return false;
                    }
                }
            }
            else
            {
                strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_LEDGER", "LEDGER_NAME", uctxtMpoName.Text);
                if (strDuplicate != "")
                {
                    MessageBox.Show(strDuplicate);
                    uctxtMpoName.Text = "";
                    uctxtMpoName.Focus();
                    return false;
                }
            }
            if (Utility.gblnAccessControl)
            {
                if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, m_acction))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return false;
                }
            }

            return true;
        }

        #endregion
        private void btnSave_Click(object sender, EventArgs e)
        {
            string strCostcenter = "",strBillGrid="", strBranch = "", strmsg = "",strResindate,strClass,strBranchID,strCloseDate="";
            double dblOpnBalance = 0, dblCreditLimit = 0, dblPeriod = 0;
            int intStatus = 0,intBkash=0;

            if (ValidateFields() == false)
            {
                return;
            }
            //Interaction.SaveSetting(Application.ExecutablePath, "frmCustomer", "Teritorry", uctxtTerritoryCode.Text);
            //Interaction.SaveSetting(Application.ExecutablePath, "frmCustomer", "MPO Name", uctxtMpoName.Text);
            RegistryKey rk = Registry.CurrentUser.CreateSubKey("SOFTWARE\\SmartAccounts");
            rk.SetValue("MPO Name", uctxtMpoName.Text);
            rk.Close();

            if (uctxtLedgerBranch.Text != "")
            {
                strBranchID = Utility.gstrGetBranchID(strComID, uctxtLedgerBranch.Text);
            }
            else
            {
                strBranchID = "";
            }

            uctxtCostCenterNew.Text = "No";
            txtBillWise.Text = "No";
            uctxtCurrency.Text = "BDT";
            txtCountry.Text = "Bangladesh";
            if (cboClass.Text !="")
            {
                strClass = cboClass.Text;
            }
            else
            {
                strClass = "";
            }

            if (cboCommission.Text == "Yes")
            {
                intStatus = 1;
            }
            else
            {
                intStatus = 0;
            }
            if (cboBkash.Text == "Yes")
            {
                intBkash = 1;
            }
            else
            {
                intBkash = 0;
            }

            if (uctxtResignDate.Text !="")
            {
                strResindate = uctxtResignDate.Text ;
            }
            else
            {
                strResindate = "";
            }

            if (txtCloseDate.Text != "")
            {
                strCloseDate = txtCloseDate.Text;
            }
            else
            {
                strCloseDate = "";
            }

            try
            {
                for (int i = 0; i < DgCostCenter.Rows.Count; i++)
                {

                    if (DgCostCenter[0, i].Value != null)
                    {
                        strCostcenter += DgCostCenter[0, i].Value.ToString() + "," + DgCostCenter[1, i].Value.ToString() +
                                                "," + DgCostCenter[2, i].Value.ToString() + "," + DgCostCenter[3, i].Value.ToString() + "~";
                    }
                }
                for (int i = 0; i < dgBranch.Rows.Count - 1; i++)
                {
                    if (dgBranch[0, i].Value != null)
                    {
                        strBranch += dgBranch[0, i].Value.ToString() + "," + dgBranch[1, i].Value.ToString() + "~";
                    }
                }
                for (int i = 0; i < dgBillBranch.Rows.Count ; i++)
                {
                    if (dgBillBranch[0, i].Value != null)
                    {
                        strBillGrid += dgBillBranch[0, i].Value.ToString() + "," + 
                                        dgBillBranch[1, i].Value.ToString() + "," + 
                                        dgBillBranch[2, i].Value.ToString() +","+
                                        dgBillBranch[3, i].Value.ToString()+ ","+
                                        dgBillBranch[4, i].Value.ToString()+","+
                                        dgBillBranch[5, i].Value.ToString()+ "~";
                    }
                }
                
            }
            catch (Exception ex)
            {

            }

            
            try
            {
                if (uctxtOpeningBalance.Text != "")
                {
                    dblOpnBalance = Convert.ToDouble(uctxtOpeningBalance.Text);
                }
                else
                {
                    dblOpnBalance = 0;
                }
                
                if (txtCreditLimit.Text !="")
                {
                    dblCreditLimit=Convert.ToDouble(txtCreditLimit.Text);
                }
                else
                {
                    dblCreditLimit=0;
                }
                 if (txtPeriod.Text !="")
                {
                    dblPeriod=Convert.ToDouble(txtPeriod.Text);
                }
                else
                {
                    dblPeriod=0;
                }

                if (m_acction == 1)
                {

                    strmsg = accms.mSaveCustomerLedger(strComID, strBranchID, uctxtMpoName.Text, uctxtUnder.Text, txtPriceLevel.Text, uctxtCreditDate.Text, uctxtEMail.Text,
                                                        uctxtFax.Text, uctxtAddress1.Text, "", uctxtTeritorryName.Text,txtCountry.Text,txtContact.Text ,
                                                        uctxtPostal.Text, uctxtPhone.Text, txtComments.Text, uctxtCurrency.Text, txtBillWise.Text,
                                                        uctxtInactive.Text, uctxtCostCentre.Text, uctxtDrCr.Text,
                                                        dblOpnBalance, strCostcenter, strBranch,strBillGrid,
                                                        dblCreditLimit, dblPeriod, Utility.gdteFinancialYearFrom, strResindate, intStatus
                                                        , uctxtTerritoryCode.Text, uctxtTeritorryName.Text.Replace("'", "''"), strClass, intBkash, strCloseDate,
                                                        txtPFLedger.Text, txtHLLedger.Text);
                                                        
                }
                else
                {
                    strmsg = accms.mUpDateCustomerLedger(strComID, mstrOldLedger, strBranchID, mlngSlNo, uctxtMpoName.Text, uctxtUnder.Text, txtPriceLevel.Text, uctxtCreditDate.Text, uctxtEMail.Text,
                                                        uctxtFax.Text, uctxtAddress1.Text, "", uctxtTeritorryName.Text, txtCountry.Text, txtContact.Text,
                                                        uctxtPostal.Text, uctxtPhone.Text, txtComments.Text, uctxtCurrency.Text, txtBillWise.Text,
                                                        uctxtInactive.Text, uctxtCostCentre.Text, uctxtDrCr.Text,
                                                        dblOpnBalance, strCostcenter, strBranch, strBillGrid,
                                                        dblCreditLimit, dblPeriod, Utility.gdteFinancialYearFrom, strResindate, intStatus
                                                        , uctxtTerritoryCode.Text, uctxtTeritorryName.Text.Replace("'", "''"), strClass, intBkash, strCloseDate, txtPFLedger.Text, txtHLLedger.Text);
                }
                if (strmsg == "1")
                {
                    if (Utility.gblnAccessControl)
                    {

                        string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), strFormname, uctxtMpoName.Text,
                                                                  m_acction, dblOpnBalance, intModuleType, "0001");
                    }
                   
                    if (mSingleEntry==1)
                    {
                        mSingleEntry = 0;
                        this.Dispose();
                    }
                     
                    if (m_acction==2)
                    {
                        string strDiffenece = accms.mDisplayOpening(strComID);
                        var results = strDiffenece.Split(new string[] { "~" }, StringSplitOptions.None);
                        lblDebit.Text = results[0];
                        lblCredit.Text = results[1];
                        lblDifference.Text = results[2];
                        mdblDebit = Utility.Val(results[0]);
                        mdblCredit = Utility.Val(results[1]);
                        btnNew.PerformClick();
                        
                    }
                    else
                    {
                        mClear();
                    }
                }
        
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void dgBillBranch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                if (e.RowIndex == 0)
                {
                    dgBillBranch.Rows.Clear();
                }
                else
                {
                    dgBillBranch.Rows.RemoveAt(e.RowIndex);
                }
                calculateTotal();
            }
        }

        private void mClear()
        {
            cboClass.Text = "Class A";
            txtDisplay.Text = "";
            uctxtMpoName.Text = "";
            uctxtUnder.Text="";
            txtPriceLevel.Text="";
            uctxtTerritoryCode.Text = "";
            txtPFLedger.Text = "";
            txtHLLedger.Text = "";
            uctxtTeritorryName.Text = "";
            uctxtEMail.Text="";
            uctxtFax.Text="";
            uctxtAddress1.Text="";
            uctxtTeritorryName.Text="";
            txtCloseDate.Text = "";
            txtCountry.Text="";
            txtContact.Text="";
            txtPeriod.Text = "";
            uctxtPostal .Text="";
            uctxtPhone.Text="";
            txtComments.Text="";
            uctxtCurrency.Text="";
            txtBillWise.Text="";
            uctxtInactive.Text="";
            uctxtCostCentre.Text="";
            uctxtDrCr.Text="Dr";
            uctxtCreditDate.Text = "";
            uctxtResignDate.Text = "";
            pnlCostCenter.Visible = false;
            DgCostCenter.Rows.Clear();
            pnlBranch.Visible = false;
            dgBillBranch.Rows.Clear();
            pnlBillWise.Visible = false;
            //dgBranch.Rows.Clear();
            uctxtOpeningBalance.Text = "";
            txtCreditLimit.Text = "";
            cboCommission.Text = "Yes";
            m_acction = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;

            string strDiffenece = accms.mDisplayOpening(strComID);
            var results = strDiffenece.Split(new string[] { "~" }, StringSplitOptions.None);
            lblDebit.Text = results[0];
            lblCredit.Text = results[1];
            lblDifference.Text = results[2];
            uctxtLedgerBranch.Focus();

        }

        private void btnBillapply_Click(object sender, EventArgs e)
        {
            if (txtBillPreTotal.Text != txtBillTotal.Text)
            {
                MessageBox.Show("Bill Amount Mismatch");
                txtTotal.Focus();
                return;
            }

            pnlBillWise.Visible = false;
            txtCreditLimit.Focus();
        }

        private void btnBillCancel_Click(object sender, EventArgs e)
        {
            pnlBillWise.Visible = false;
            txtCreditLimit.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmTreeView objfrm = new frmTreeView();
            objfrm.strType = "M";
            objfrm.Show();
            objfrm.MdiParent = this.MdiParent;
        }

        private void dgBranch_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            calculateTotal();
        }

        private void DgCostCenter_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            calculateTotal();
        }

        #endregion

        private void DgCostCenter_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==4)
            {
                DgCostCenter.Rows.RemoveAt(e.RowIndex);
                calculateTotal();
            }
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

       
       

      

       

      

        

       




    }
}
