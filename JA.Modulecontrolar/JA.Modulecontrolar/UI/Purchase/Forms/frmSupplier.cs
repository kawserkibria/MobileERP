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
using JA.Modulecontrolar.UI.Forms;
using Microsoft.VisualBasic;
using Microsoft.Win32;

namespace JA.Modulecontrolar.UI.Sales.Forms
{
    public partial class frmSupplier : JA.Shared.UI.frmJagoronFromSearch
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
        SPWOIS objwois = new SPWOIS();
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
        private double mdblOpeningBalance { get; set; }
        private double mdblDebit { get; set; }
        private double mdblCredit { get; set; }
        public long lngFormPriv { get; set; }
        public string strFormName { get; set; }
        public int intModuleType { get; set; }
        public int m_acction { get; set; }
        public int mSingleEntry { get; set; }
        private long mlngSlNo { get; set; }
        private string mstrOldLedger { get; set; }
        private string mstrOldTerritoryCode { get; set; }
        private string strComID { get; set; }
        public frmSupplier()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            #region "user IN"
            this.uctxtSupplierName.GotFocus += new System.EventHandler(this.uctxtSupplierName_GotFocus);
            this.uctxtSupplierName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uctxtSupplierName_KeyPress);
            this.uctxtSupplierName.TextChanged += new System.EventHandler(this.uctxtSupplierName_TextChanged);
            this.uctxtSupplierName.KeyDown += new KeyEventHandler(uctxtSupplierName_KeyDown);

            this.uctxtOpeningBalance.GotFocus += new System.EventHandler(this.uctxtOpeningBalance_GotFocus);
            this.uctxtOpeningBalance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uctxtOpeningBalance_KeyPress);
            this.uctxtOpeningBalance.TextChanged += new System.EventHandler(this.uctxtOpeningBalance_TextChanged);

            this.uctxtDrCr.GotFocus += new System.EventHandler(this.uctxtDrCr_GotFocus);
            this.uctxtDrCr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtDrCr_KeyPress);
            
            this.uctxtDrCr.KeyDown += new KeyEventHandler(uctxtDrCr_KeyDown);
            this.uctxtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uctxtPhone_KeyPress);

            this.txtCreditLimit.GotFocus += new System.EventHandler(this.txtCreditLimit_GotFocus);
            this.txtCreditLimit.TextChanged += new System.EventHandler(this.txtCreditLimit_TextChanged);

            this.uctxtCreditDate.GotFocus += new System.EventHandler(this.uctxtCreditDate_GotFocus);
            this.uctxtCreditDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uctxtCreditDate_KeyPress);
            this.txtPeriod.GotFocus += new System.EventHandler(this.txtPeriod_GotFocus);
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
            this.lstBranchName.DoubleClick += new System.EventHandler(this.lstBranchName_DoubleClick);
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

            this.dgBranch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgBranch_KeyDown);
            this.dgBranch.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBranch_CellEndEdit);
            this.DgCostCenter.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgCostCenter_CellContentClick);
            this.dgBranch.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBranch_CellEndEdit);

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
            #endregion
        }

        #region "Keydown"
        private void DG_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                e.SuppressKeyPress = true;
                int iColumn = dgBranch.CurrentCell.ColumnIndex;
                int iRow = dgBranch.CurrentCell.RowIndex;
                if (iRow == dgBranch.Rows.Count - 1)
                    btnBranchApply.Focus();
                else
                    dgBranch.CurrentCell = dgBranch[iColumn, iRow + 1];


            }
        }
     
        private void uctxtSupplierName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R && e.Modifiers == Keys.Control)
            {
                //uctxtSupplierName.Text = Interaction.GetSetting(Application.ExecutablePath, "frmCustomer", "MPO Name");
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
                uctxtSupplierName.AppendText((String)rk.GetValue("MPO Name", ""));
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
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(txtCountry, uctxtAddress1);
            }
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
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(txtPeriod, uctxtCreditDate);
            }
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
        #region "AddItem"
        private void mChangeOpening(string vstrDrCr)
        {
            double dblDebit, dblCredit, dblDiff;


            if (m_acction == (int)Utility.ACTION_MODE_ENUM.EDIT_MODE)
            {
                if (mdblOpeningBalance < 0)
                {
                    mdblDebit = mdblDebit + mdblOpeningBalance;
                }
                if (mdblOpeningBalance > 0)
                {
                    mdblCredit = mdblCredit - mdblOpeningBalance;
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
            for (int i = 0; i < dgBranch.Rows.Count ; i++)
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
        
       

        private void uctxtSupplierName_TextChanged(object sender, EventArgs e)
        {
            int x = uctxtSupplierName.SelectionStart;
            uctxtSupplierName.Text = Utility.gmakeProperCase(uctxtSupplierName.Text);
            uctxtSupplierName.SelectionStart = x;
        }
       
        private void uctxtAddress1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtCountry.Focus();
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
                uctxtInactive.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
               Utility.PriorSetFocusText(uctxtEMail, uctxtPhone);
            }
        }

        private void uctxtFax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtEMail.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtFax,uctxtPhone);
            }
        }

        private void uctxtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtEMail.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtPhone,txtContact);
            }
        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtPhone.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(txtContact, txtCountry);
            }
        }

        private void uctxtPostal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtContact.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtPostal,uctxtAddress1);
            }
        }

       

        private void txtCreditLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtPeriod.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(txtCreditLimit, uctxtDrCr);
            }
        }

       

        private void uctxtOpeningBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtDrCr.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtOpeningBalance, uctxtCostCentre);
            }
        }
        private void txtComments_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnSave.Focus();
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
                Utility.PriorSetFocusText(uctxtCreditDate,uctxtDrCr);
            }
        }
        private void uctxtSupplierName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (m_acction==2)
                {
                if (mstrOldLedger.ToUpper() != uctxtSupplierName.Text.ToUpper())
                {
                    string strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_LEDGER", "LEDGER_NAME", uctxtSupplierName.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        uctxtSupplierName.Text = "";
                        uctxtSupplierName.Focus();
                        return;
                    }
                }
            }
            else
            {
                string strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_LEDGER", "LEDGER_NAME", uctxtSupplierName.Text);
                if (strDuplicate != "")
                {
                    MessageBox.Show(strDuplicate);
                    uctxtSupplierName.Text = "";
                    uctxtSupplierName.Focus();
                    return;
                }
            }
                uctxtUnder.Focus();
            }
            //if (e.KeyChar == (char)Keys.Back)
            //{
            //    PriorSetFocusText(uctxtSupplierName, sender, e);
            //}
           

        }
      
        private void uctxtResignDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                cboCommission.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtResignDate, uctxtEMail);
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
                uctxtResignDate.Focus();
            }
        }
        private void cboCommission_GotFocus(object sender, System.EventArgs e)
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
            //lstTeritorryName.Visible = false;
            //lstTeritorryCode.Visible = false;
        }
        private void uctxtResignDate_GotFocus(object sender, System.EventArgs e)
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
            //lstTeritorryName.Visible = false;
            //lstTeritorryCode.Visible = false;
        }
        private void txtBillDrcr_GotFocus(object sender, System.EventArgs e)
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
            //lstTeritorryName.Visible = false;
            //lstTeritorryCode.Visible = false;
        }
        private void txtBillAmount_GotFocus(object sender, System.EventArgs e)
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
            //lstTeritorryName.Visible = false;
            //lstTeritorryCode.Visible = false;
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
            //lstTeritorryName.Visible = false;
            //lstTeritorryCode.Visible = false;
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
            //lstTeritorryName.Visible = false;
            //lstTeritorryCode.Visible = false;
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
            lstCostCategory.Visible = false;
            //lstTeritorryName.Visible = false;
            //lstTeritorryCode.Visible = false;
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
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstPriceLebel.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
            //lstTeritorryName.Visible = false;
            //lstTeritorryCode.Visible = false;
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
            //lstTeritorryName.Visible = false;
            //lstTeritorryCode.Visible = false;
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
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstPriceLebel.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = true;
            lstCostCategory.Visible = false;
            //lstTeritorryName.Visible = false;
            //lstTeritorryCode.Visible = false;
            lstBranchName.Visible = false;
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
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstPriceLebel.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = true;
            //lstTeritorryName.Visible = false;
            //lstTeritorryCode.Visible = false;
            lstCostCategory.SelectedIndex = lstCostCategory.FindString(uctxtCostCategory.Text);
        }
        private void uctxtBranch_TextChanged(object sender, EventArgs e)
        {
            lstBranchName.Visible = true;
            lstBranchName.SelectedIndex = lstBranchName.FindString(uctxtBranch.Text);
        }

        private void lstBranchName_DoubleClick(object sender, EventArgs e)
        {
            uctxtBranch.Text = lstBranchName.Text;
            uctxtCostCategory.Focus();
        }

        private void uctxtBranch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtBranch.Text !="")
                {
                    uctxtBranch.Text = lstBranchName.Text;
                    uctxtCostCategory.Focus();
                }
                else
                {
                    btnApply.Focus();
                }
               

            }
        }
        private void uctxtBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstBranchName.SelectedItem != null)
                {
                    lstBranchName.SelectedIndex = lstBranchName.SelectedIndex - 1;
                    uctxtBranch.Text = lstBranchName.Text;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstBranchName.Items.Count - 1 > lstBranchName.SelectedIndex)
                {
                    lstBranchName.SelectedIndex = lstBranchName.SelectedIndex + 1;
                    uctxtBranch.Text = lstBranchName.Text;
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
            //lstTeritorryName.Visible = false;
            //lstTeritorryCode.Visible = false;
            lstBranchName.SelectedIndex = lstBranchName.FindString(uctxtBranch.Text);
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
                dgBranch.AllowUserToAddRows = true;
                foreach (BranchConfig ob in ooBranch)
                {
                    dgBranch.Rows.Add(1);
                    dgBranch[0, introw].Value = ob.BranchName;
                    introw += 1;
                }
                dgBranch.AllowUserToAddRows = false;
                // ucGridAssetBranch.AllowUserToAddRows = false;
            }
        }
        private void uctxtDrCr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                mChangeOpening(uctxtDrCr.Text);
                if (uctxtCostCentre.Text == "Yes")
                {
                    if (Utility.Val(uctxtOpeningBalance.Text) > 0)
                    {
                        pnlCostCenter.Visible = true;
                        pnlCostCenter.Top = uctxtOpeningBalance.Top + 25;
                        pnlCostCenter.Left = uctxtOpeningBalance.Left;
                        pnlCostCenter.Size = new Size(710, 279);
                        DgCostCenter.Size = new Size(700, 139);
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
                                pnlBranch.Size = new Size(582, 280);
                                dgBranch.Size = new Size(605, 187);
                                btnBranchApply.Top = DgCostCenter.Height + 90;
                                btnBranchApply.Left = 200;
                                btnBranchCancel.Left = 300;
                                btnBranchCancel.Top = DgCostCenter.Height + 90;
                                txtBranchTotal.Top = DgCostCenter.Height + 90;
                                txtBranchPreTotal.Text = uctxtOpeningBalance.Text;
                                dgBranch.Focus();
                                SendKeys.Send("{tab}");
                               
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
                                lblBillWise.Text = "Bill Wise Details for " + uctxtSupplierName.Text;
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
                        uctxtCreditDate.Focus();
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
            //lstTeritorryName.Visible = false;
            //lstTeritorryCode.Visible = false;
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
            //lstTeritorryName.Visible = false;
            //lstTeritorryCode.Visible = false;
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
            //lstTeritorryName.Visible = false;
            //lstTeritorryCode.Visible = false;
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
            //lstTeritorryName.Visible = false;
            //lstTeritorryCode.Visible = false;
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
            //lstTeritorryName.Visible = false;
            //lstTeritorryCode.Visible = false;
            //lstTeritorryName.SelectedIndex = lstTeritorryName.FindString(uctxtTeritorryName.Text);
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
            //lstTeritorryName.Visible = false;
            //lstTeritorryCode.Visible = false;
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
            //lstTeritorryName.Visible = false;
            //lstTeritorryCode.Visible = false;
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
            //lstTeritorryName.Visible = false;
            //lstTeritorryCode.Visible = false;
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
            //lstTeritorryName.Visible = false;
            //lstTeritorryCode.Visible = false;
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
            //lstTeritorryName.Visible = false;
            //lstTeritorryCode.Visible = false;
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
            //lstTeritorryName.Visible = false;
            //lstTeritorryCode.Visible = false;
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
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtCurrency, uctxtCostCentre);
            }
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
            //lstTeritorryName.Visible = false;
            //lstTeritorryCode.Visible = false;
            lstcurrency.SelectedIndex = lstcurrency.FindString(uctxtCurrency.Text);
        }


        private void uctxtSupplierName_GotFocus(object sender, System.EventArgs e)
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
            //lstTeritorryName.Visible = false;
            //lstTeritorryCode.Visible = false;
        }
        private void uctxtInactive_TextChanged(object sender, EventArgs e)
        {
            lstInactive.SelectedIndex = lstInactive.FindString(uctxtInactive.Text);
        }

        private void lstInactive_DoubleClick(object sender, EventArgs e)
        {
            uctxtInactive.Text = lstInactive.Text;
            lstInactive.Visible = false;
            txtComments.Focus();
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
                txtComments.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtInactive, uctxtEMail);
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
            //lstTeritorryName.Visible = false;
            //lstTeritorryCode.Visible = false;
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
            if (e.KeyChar == (char)Keys.Back)
            {

                Utility.PriorSetFocusText(txtPriceLevel, txtBillWise);
            }
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
            //lstTeritorryName.Visible = false;
            //lstTeritorryCode.Visible = false;
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
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(txtBillWise, uctxtCostCentre);
             
            }

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
            //lstTeritorryName.Visible = false;
            //lstTeritorryCode.Visible = false;
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
                uctxtOpeningBalance.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtCostCentre, uctxtUnder);
            }
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
            //lstTeritorryName.Visible = false;
            //lstTeritorryCode.Visible = false;
            lstCostCenter.SelectedIndex = lstCostCenter.FindString(uctxtCostCentre.Text);
        }
        private void uctxtUnder_TextChanged(object sender, EventArgs e)
        {
            lstUnder.SelectedIndex = lstUnder.FindString(uctxtUnder.Text);
        }

       

        private void lstUnder_DoubleClick(object sender, EventArgs e)
        {
            uctxtUnder.Text = lstUnder.Text;
            uctxtCostCentre.Focus();
        }

        
        private void uctxtUnder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstUnder.Items.Count > 0)
                {
                    uctxtUnder.Text = lstUnder.Text;
                }
                uctxtCostCentre.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtUnder,uctxtSupplierName);
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
            //lstTeritorryName.Visible = false;
            //lstTeritorryCode.Visible = false;
            lstUnder.SelectedIndex = lstUnder.FindString(uctxtUnder.Text);
        }

        #endregion
        #region "Tab change

        private void TabChange()
        {
            uctxtSupplierName.Focus();

            uctxtSupplierName.AllToNextTab(uctxtUnder);
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
            //uctxtAddress1.AllToNextTab(uctxtTeritorryName);
            //uctxtTeritorryName.AllToNextTab(uctxtPostal);
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
            uctxtSupplierName.Select();
            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstPriceLebel.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
            DgCostCenter.AllowUserToAddRows = false;
            dgBranch.AllowUserToAddRows = false;
            //lstTeritorryName.Visible = false;
            //lstTeritorryCode.Visible = false;

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
            lstUnder.DataSource = accms.mFillGroup(strComID, intvtype).ToList();


            //lstTeritorryCode.ValueMember = "strTeritorrycode";
            //lstTeritorryCode.DisplayMember = "strTeritorrycode";
            //lstTeritorryCode.DataSource = accms.mFillTeritorry("").ToList();

            //lstTeritorryName.ValueMember = "strTeritorryName";
            //lstTeritorryName.DisplayMember = "strTeritorryName";
            //lstTeritorryName.DataSource = accms.mFillTeritorry("").ToList();

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
            mloadBrach();


            //mChangeOpening(uctxtDrCr.Text);
        }
        #endregion
        #region "Display List"
        private void DisplayReqList(List<AccountsLedger> tests, object sender, EventArgs e)
        {
            try
            {

                List<AccountsLedger> ooled = accms.mDisplayLedgerList(strComID, tests[0].lngSlno).ToList();
                if (ooled.Count > 0)
                {
                    mlngSlNo = Convert.ToInt64(tests[0].lngSlno);
                    m_acction = 2;
                    uctxtSupplierName.Text = ooled[0].strOldLedgerName;
                    mstrOldLedger = ooled[0].strOldLedgerName;
                    mstrOldTerritoryCode = ooled[0].strTeritorryCode;
                    uctxtUnder.Text = ooled[0].strUder;
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

                    //uctxtTerritoryCode.Text = ooled[0].strTerritorycode;
                    //uctxtTeritorryName.Text = ooled[0].strTerritoryName;

                    uctxtOpeningBalance.Text = Math.Abs(ooled[0].dblOpnBalance).ToString();
                    mdblOpeningBalance = Utility.Val(ooled[0].dblOpnBalance.ToString());
                    if (Convert.ToDouble(ooled[0].dblOpnBalance) < 0)
                    {
                        uctxtDrCr.Text = "Dr";
                    }
                    else if (Convert.ToDouble(ooled[0].dblOpnBalance) > 0)
                    {
                        uctxtDrCr.Text = "Cr";
                    }
                    txtContact.Text = ooled[0].strCantactPerson;
                    txtCreditLimit.Text = ooled[0].strCreditLimit;
                    uctxtCreditDate.Text = ooled[0].strCreditDate;
                    uctxtAddress1.Text = ooled[0].strAddress.Trim();
                    //uctxtTeritorryName.Text = ooled[0].strCity;
                    uctxtPostal.Text = ooled[0].strPostalCode;
                    uctxtPhone.Text = ooled[0].strPhone;
                    uctxtFax.Text = ooled[0].strFax;
                    uctxtEMail.Text = ooled[0].strEmail;
                    txtComments.Text = ooled[0].strCommnents;
                    if (ooled[0].intStatus == 1)
                    {
                        uctxtInactive.Text = "Yes";
                    }
                    else
                    {
                        uctxtInactive.Text = "No";
                    }
                    uctxtResignDate.Text = ooled[0].strResinDate;
                    cboCommission.Text = ooled[0].strCommission;

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

                    List<BranchConfig> obranch = accms.mDisplayBranchOpening(strComID, mstrOldLedger,"").ToList();
                    {
                        if (obranch.Count > 0)
                        {
                            int i = 0;
                            foreach (BranchConfig ooBran in obranch)
                            {
                                dgBranch.Rows.Add();
                                dgBranch.Rows[i].Cells[0].Value = Utility.gstrGetBranchName(strComID, ooBran.BranchID);
                                dgBranch.Rows[i].Cells[1].Value = Math.Abs(ooBran.dblbranchOpening);
                                dblBrancAmount = dblBrancAmount + Math.Abs(ooBran.dblbranchOpening);
                                i += 1;
                            }
                            dgBranch.AllowUserToAddRows = false;
                            txtBranchTotal.Text = dblBrancAmount.ToString();

                        }
                    }
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

                    //    List<FixedAssets> ooFixedopn = accms.mDisplayFixedAssestOpening(mstrOldLedger).ToList();
                    //    {
                    //        if (ooFixedopn.Count > 0)
                    //        {
                    //            int i = 0;
                    //            foreach (FixedAssets ooFixed in ooFixedopn)
                    //            {
                    //                ucGridAssetBranch.Rows.Add();
                    //                ucGridAssetBranch.Rows[i].Cells[0].Value = Utility.gstrGetBranchName(ooFixed.strBranchID);
                    //                ucGridAssetBranch.Rows[i].Cells[1].Value = Math.Abs(ooFixed.dblAccumulatedDep);
                    //                dblAssetTotalBranch = dblAssetTotalBranch + Math.Abs(ooFixed.dblAccumulatedDep);
                    //                i += 1;
                    //            }
                    //            dgBranch.AllowUserToAddRows = false;
                    //            txtAssetsTotalBranch.Text = dblAssetTotalBranch.ToString();

                    //        }
                    //    }





                    //}

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

            lstInactive.DisplayMember = "Key";
            lstInactive.ValueMember = "Value";
            lstInactive.DataSource = new BindingSource(userCache, null);

            //string strDiffenece = accms.mDisplayOpening();
            //var results = strDiffenece.Split(new string[] { "~" }, StringSplitOptions.None);
            //lblDebit.Text = results[0];
            //lblCredit.Text = results[1];
            //lblDifference.Text = results[2];

        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (DgCostCenter.Rows.Count > 0)
            {
                if (Utility.Val(txtpreAmount.Text) != Utility.Val(txtTotal.Text))
                {
                    MessageBox.Show("Cost Center Amount Mismatch");
                    txtTotal.Focus();
                    return;
                }
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
                        dgBranch.Size = new Size(605, 187);
                        btnBranchApply.Top = dgBranch.Height + 90;
                        btnBranchApply.Left = 200;
                        btnBranchCancel.Left = 300;
                        btnBranchCancel.Top = dgBranch.Height + 90;
                        txtBranchTotal.Top = DgCostCenter.Height + 90;
                        txtBranchPreTotal.Text = uctxtOpeningBalance.Text;
                        dgBranch.Focus();
                        SendKeys.Send("{tab}");
                    }
                }
                if (txtBillWise.Text.ToUpper() == "YES")
                {
                    if (pnlBranch.Visible == false)
                    {
                        pnlBillWise.Visible = true;
                        lblBillWise.Text = "Bill Wise Details for " + uctxtSupplierName.Text;
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
                        lblBillWise.Text = "Bill Wise Details for " + uctxtSupplierName.Text;
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
                uctxtCreditDate.Focus();
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
                    lblBillWise.Text = "Bill Wise Details for " + uctxtSupplierName.Text;
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
                uctxtCreditDate.Focus();
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
            uctxtDrCr.Text = "Cr";
            frmAccountsLedgerList objfrm = new frmAccountsLedgerList();
            objfrm.mintLedgerGroup = (int)Utility.GR_GROUP_TYPE.grSUPPLIER;
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.strFormName = strFormName;
            objfrm.intModuleType = intModuleType;
            objfrm.onAddAllButtonClicked = new frmAccountsLedgerList.AddAllClick(DisplayReqList);
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

            if (Utility.gblnAccessControl)
            {
                if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, m_acction))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return false;
                }
            }
            if (uctxtSupplierName.Text == "")
            {
                MessageBox.Show("Cannot be Empty");
                uctxtSupplierName.Focus();
                return false;
            }
            if (uctxtUnder.Text == "")
            {
                MessageBox.Show("Cannot be Empty");
                uctxtUnder.Focus();
                return false;
            }
            if (m_acction == 2)
            {
                if (mstrOldLedger.ToUpper() != uctxtSupplierName.Text.ToUpper())
                {
                    strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_LEDGER", "LEDGER_NAME", uctxtSupplierName.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        uctxtSupplierName.Text = "";
                        uctxtSupplierName.Focus();
                        return false;
                    }
                }
            }
            else
            {
                strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_LEDGER", "LEDGER_NAME", uctxtSupplierName.Text);
                if (strDuplicate != "")
                {
                    MessageBox.Show(strDuplicate);
                    uctxtSupplierName.Text = "";
                    uctxtSupplierName.Focus();
                    return false;
                }
            }
          

            return true;
        }

        #endregion
        private void btnSave_Click(object sender, EventArgs e)
        {
            string strCostcenter = "",strBillGrid="", strBranch = "", strmsg = "",strResindate;
            double dblOpnBalance = 0, dblCreditLimit = 0, dblPeriod = 0,dblAmount =0;
            int intStatus = 0;

            if (ValidateFields() == false)
            {
                return;
            }
         
            RegistryKey rk = Registry.CurrentUser.CreateSubKey("SOFTWARE\\SmartAccounts");
            rk.SetValue("MPO Name", uctxtSupplierName.Text);
            rk.Close();

            if (cboCommission.Text == "Yes")
            {
                intStatus = 1;
            }
            else
            {
                intStatus = 0;
            }
            if (uctxtResignDate.Text !="")
            {
                strResindate = uctxtResignDate.Text ;
            }
            else
            {
                strResindate = "";
            }
            try
            {
                dblAmount = 0;

                for (int i = 0; i < DgCostCenter.Rows.Count; i++)
                {

                    if (DgCostCenter[0, i].Value != null)
                    {
                        if (dgBranch[3, i].Value != null)
                        {
                            dblAmount = Utility.Val(dgBranch[3, i].Value.ToString());
                        }
                        else
                        {
                            dblAmount = 0;
                        }
                        strCostcenter += DgCostCenter[0, i].Value.ToString() + "," + DgCostCenter[1, i].Value.ToString() +
                                                "," + DgCostCenter[2, i].Value.ToString() + "," + dblAmount + "~";
                    }
                }
                dblAmount = 0;
                for (int i = 0; i < dgBranch.Rows.Count; i++)
                {
                    if (dgBranch[0, i].Value != null)
                    {
                        if (dgBranch[1, i].Value != null)
                        {
                            dblAmount = Utility.Val(dgBranch[1, i].Value.ToString()); 
                        }
                        else
                        {
                            dblAmount = 0;
                        }

                        strBranch += dgBranch[0, i].Value.ToString() + "," + dblAmount + "~";
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

                    strmsg = objwois.mSaveCustomerLedger(strComID, "", uctxtSupplierName.Text, uctxtUnder.Text, txtPriceLevel.Text, "", uctxtEMail.Text,
                                                        uctxtFax.Text, uctxtAddress1.Text, "", "",txtCountry.Text,txtContact.Text ,
                                                        uctxtPostal.Text, uctxtPhone.Text, txtComments.Text, uctxtCurrency.Text, txtBillWise.Text,
                                                        uctxtInactive.Text, uctxtCostCentre.Text, uctxtDrCr.Text,
                                                        dblOpnBalance, strCostcenter, strBranch,strBillGrid,
                                                        dblCreditLimit, dblPeriod, Utility.gdteFinancialYearFrom, strResindate, intStatus
                                                        ,"","","",0,"","","","");
                                                        
                }
                else
                {
                    strmsg = objwois.mUpDateCustomerLedger(strComID, mstrOldLedger, "", mlngSlNo, uctxtSupplierName.Text, uctxtUnder.Text, txtPriceLevel.Text, "", uctxtEMail.Text,
                                                        uctxtFax.Text, uctxtAddress1.Text, "", "", txtCountry.Text, txtContact.Text,
                                                        uctxtPostal.Text, uctxtPhone.Text, txtComments.Text, uctxtCurrency.Text, txtBillWise.Text,
                                                        uctxtInactive.Text, uctxtCostCentre.Text, uctxtDrCr.Text,
                                                        dblOpnBalance, strCostcenter, strBranch, strBillGrid,
                                                        dblCreditLimit, dblPeriod, Utility.gdteFinancialYearFrom, strResindate, intStatus
                                                        , "", "","",0,"","","","");
                }
                if (strmsg == "1")
                {
                    if (Utility.gblnAccessControl)
                    {
                        string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), strFormName, uctxtSupplierName.Text,
                                                                m_acction, 0, (int)Utility.MODULE_TYPE.mtPURCHASE, "0001");
                    }
                    if (mSingleEntry == 1)
                    {
                        mSingleEntry = 0;
                        this.Dispose();
                    }
                    else
                    {
                        mClear();
                        dgBranch.Rows.Clear();
                        mloadBrach();
                    }
                }
                else
                {
                    dgBranch.Rows.Clear();
                    mloadBrach();
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
            
            uctxtSupplierName.Text = "";
            uctxtUnder.Text="";
            txtPriceLevel.Text="";
            //uctxtTerritoryCode.Text = "";
            //uctxtTeritorryName.Text = "";
            uctxtEMail.Text="";
            uctxtFax.Text="";
            uctxtAddress1.Text="";
            //uctxtTeritorryName.Text="";
            txtCountry.Text="";
            txtContact.Text="";
            uctxtPostal .Text="";
            uctxtPhone.Text="";
            txtComments.Text="";
            uctxtCurrency.Text="";
            txtBillWise.Text="";
            uctxtInactive.Text="";
            uctxtCostCentre.Text="";
            uctxtDrCr.Text="Cr";
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
            uctxtCurrency.Text = "BDT";
            txtCountry.Text = "Bangladesh";
            cboCommission.Text = "Yes";
            m_acction = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            string strDiffenece = accms.mDisplayOpening(strComID);
            var results = strDiffenece.Split(new string[] { "~" }, StringSplitOptions.None);
            lblDebit.Text = results[0];
            lblCredit.Text = results[1];
            lblDifference.Text = results[2];
            mdblDebit = Utility.Val(results[0]);
            mdblCredit = Utility.Val(results[1]);
            uctxtSupplierName.Focus();

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
            objfrm.strType = "C";
            objfrm.MdiParent = this.MdiParent;
            objfrm.Show();
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            mClear();
            mChangeOpening(uctxtDrCr.Text);
        }

      

      

       
       

      

       

      

        

       




    }
}
