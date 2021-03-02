using Dutility;
using JA.Modulecontrolar.JACCMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using JA.Modulecontrolar.UI.Forms;
using JA.Modulecontrolar.UI.Accms.Forms;
using Microsoft.VisualBasic;
using Microsoft.Win32;

namespace JA.Modulecontrolar.UI.Accms
{
    public partial class frmAccountsLedger : JA.Shared.UI.frmSmartFormStandard
    {
        
        JACCMS.SWJAGClient accms = new SWJAGClient();
        private ListBox lstUnder = new ListBox();
        private ListBox lstCostCenter = new ListBox();
        private ListBox lsteffectInventory = new ListBox();
        private ListBox lstcurrency = new ListBox();
        private ListBox lstInactive = new ListBox();
        private ListBox lstBranchName = new ListBox();
        private ListBox lstCostCategory = new ListBox();
        private ListBox lstCostCenterNew = new ListBox();
        private ListBox lstAssetsBranch = new ListBox();
        private ListBox lstLedgerBranch = new ListBox();
      
        private ListBox lstLedgerBranchAccumulated = new ListBox();
        public int m_acction =0;
        public long lngFormPriv { get; set; }
        public int mSingleEntry { get; set; }
        private string mstrOldLedger;
        private long mlngSlNo;
        private double mdblOpeningBalance { get; set; }
        private double mdblDebit { get; set; }
        private double mdblCredit { get; set; }
        private string strComID { get; set; }
        public frmAccountsLedger()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            #region "User In"

         


            this.uctxtLedgerName.KeyDown += new KeyEventHandler(uctxtLedgerName_KeyDown);
            this.uctxtLedgerName.LostFocus += new System.EventHandler(this.uctxtLedgerName_LostFocus);
            this.uctxtLedgerName.TextChanged += new System.EventHandler(this.uctxtLedgerName_TextChanged);
            this.uctxtLedgerName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uctxtLedgerName_KeyPress);
            this.uctxtLedgerName.GotFocus += new System.EventHandler(this.uctxtLedgerName_GotFocus);

            this.uctxtOpeningBalance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uctxtOpeningBalance_KeyPress);
            this.uctxtOpeningBalance.TextChanged += new System.EventHandler(this.uctxtOpeningBalance_TextChanged);

            this.uctxtOpeningBalance.GotFocus += new System.EventHandler(this.uctxtOpeningBalance_GotFocus);
            this.uctxtAddress1.GotFocus += new System.EventHandler(this.uctxtAddress1_GotFocus);
            this.uctxtPostal.GotFocus += new System.EventHandler(this.uctxtPostal_GotFocus);
            this.uctxtPhone.GotFocus += new System.EventHandler(this.uctxtPhone_GotFocus);
            this.uctxtEMail.GotFocus += new System.EventHandler(this.uctxtEMail_GotFocus);
            this.uctxtFax.GotFocus += new System.EventHandler(this.uctxtFax_GotFocus);
            this.uctxtFax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uctxtFax_KeyPress);
            this.uctxtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uctxtPhone_KeyPress);
            this.uctxtEMail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uctxtEMail_KeyPress);
            this.uctxtDrCr.GotFocus += new System.EventHandler(this.uctxtDrCr_GotFocus);
            //this.uctxtDrCr.TextChanged += new System.EventHandler(this.uctxtDrCr_TextChanged);
            

            this.uctxtDrCr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtDrCr_KeyPress);
            this.uctxtDrCr.KeyDown += new KeyEventHandler(uctxtDrCr_KeyDown);
            this.uctxtPFAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtPFAmount_KeyPress);

            this.uctxtUnder.GotFocus += new System.EventHandler(this.uctxtUnder_GotFocus);
            this.uctxtUnder.KeyDown += new KeyEventHandler(uctxtUnder_KeyDown);
            this.uctxtUnder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtUnder_KeyPress);
            this.lstUnder.DoubleClick += new System.EventHandler(this.lstUnder_DoubleClick);
            this.uctxtUnder.TextChanged += new System.EventHandler(this.uctxtUnder_TextChanged);

            this.uctxtCostCentre.GotFocus += new System.EventHandler(this.uctxtCostCentre_GotFocus);
            this.uctxtCostCentre.KeyDown += new KeyEventHandler(uctxtCostCentre_KeyDown);
            this.uctxtCostCentre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtCostCentre_KeyPress);
            this.lstCostCenter.DoubleClick += new System.EventHandler(this.lstCostCenter_DoubleClick);
            this.uctxtCostCentre.TextChanged += new System.EventHandler(this.uctxtCostCentre_TextChanged);

            this.txtEffectInventory.GotFocus += new System.EventHandler(this.txtEffectInventory_GotFocus);
            this.txtEffectInventory.KeyDown += new KeyEventHandler(txtEffectInventory_KeyDown);
            this.txtEffectInventory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtEffectInventory_KeyPress);
            this.lsteffectInventory.DoubleClick += new System.EventHandler(this.lsteffectInventory_DoubleClick);
            this.txtEffectInventory.TextChanged += new System.EventHandler(this.txtEffectInventory_TextChanged);

            this.uctxtInactive.GotFocus += new System.EventHandler(this.uctxtInactive_GotFocus);
            this.uctxtInactive.KeyDown += new KeyEventHandler(uctxtInactive_KeyDown);
            this.uctxtInactive.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtInactive_KeyPress);
            this.lstInactive.DoubleClick += new System.EventHandler(this.lstInactive_DoubleClick);
            this.uctxtInactive.TextChanged += new System.EventHandler(this.uctxtInactive_TextChanged);

            this.uctxtCurrency.GotFocus += new System.EventHandler(this.uctxtCurrency_GotFocus);
            this.uctxtCurrency.KeyDown += new KeyEventHandler(uctxtCurrency_KeyDown);
            this.uctxtCurrency.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtCurrency_KeyPress);
            this.lstcurrency.DoubleClick += new System.EventHandler(this.lstcurrency_DoubleClick);
            this.uctxtCurrency.TextChanged += new System.EventHandler(this.uctxtCurrency_TextChanged);

            this.txtAssetsLedger.GotFocus += new System.EventHandler(this.txtAssetsLedger_GotFocus);
            this.txtPurchaseAmount.TextChanged += new System.EventHandler(this.txtPurchaseAmount_TextChanged);
            this.txtPurchaseAmount.GotFocus += new System.EventHandler(this.txtPurchaseAmount_GotFocus);

            this.cboDepMethod.GotFocus += new System.EventHandler(this.cboDepMethod_GotFocus);
            this.txtDepRate.GotFocus += new System.EventHandler(this.txtDepRate_GotFocus);
            this.txtDepRate.TextChanged += new System.EventHandler(this.txtDepRate_TextChanged);

            this.txtAssetsLife.GotFocus += new System.EventHandler(this.txtAssetsLife_GotFocus);
            this.dteEffectform.GotFocus += new System.EventHandler(this.dteEffectform_GotFocus);
            this.dteEffectform.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteEffectform_KeyPress);

            this.txtAccumulatedDep.GotFocus += new System.EventHandler(this.txtAccumulatedDep_GotFocus);
            this.txtAccumulatedDep.TextChanged += new System.EventHandler(this.txtAccumulatedDep_TextChanged);
            this.txtAccumulatedDep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtAccumulatedDep_KeyPress);

            this.txtWittendownValue.GotFocus += new System.EventHandler(this.txtWittendownValue_GotFocus);
            this.txtWittendownValue.TextChanged += new System.EventHandler(this.txtWittendownValue_TextChanged);

            this.txtSalvageValue.GotFocus += new System.EventHandler(this.txtSalvageValue_GotFocus);
            this.txtSalvageValue.TextChanged += new System.EventHandler(this.txtSalvageValue_TextChanged);
            this.txtSalvageValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtSalvageValue_KeyPress);
            

            this.DgCostCenter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(DgCostCenter_KeyPress);


            this.uctxtBranch.KeyDown += new KeyEventHandler(uctxtBranch_KeyDown);
            this.uctxtBranch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranch_KeyPress);
            this.uctxtBranch.TextChanged += new System.EventHandler(this.uctxtBranch_TextChanged);
            this.lstBranchName.DoubleClick += new System.EventHandler(this.lstBranchName_DoubleClick);
            this.uctxtBranch.GotFocus += new System.EventHandler(this.uctxtBranch_GotFocus);

            this.uctxtAssetBranchName.KeyDown += new KeyEventHandler(uctxtAssetBranchName_KeyDown);
            this.uctxtAssetBranchName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtAssetBranchName_KeyPress);
            this.uctxtAssetBranchName.TextChanged += new System.EventHandler(this.uctxtAssetBranchName_TextChanged);
            this.lstAssetsBranch.DoubleClick += new System.EventHandler(this.lstAssetsBranch_DoubleClick);
            this.uctxtAssetBranchName.GotFocus += new System.EventHandler(this.uctxtAssetBranchName_GotFocus);

            this.uctxtLedgerBranch.KeyDown += new KeyEventHandler(uctxtLedgerBranch_KeyDown);
            this.uctxtLedgerBranch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtLedgerBranch_KeyPress);
            this.uctxtLedgerBranch.TextChanged += new System.EventHandler(this.uctxtLedgerBranch_TextChanged);
            this.lstLedgerBranch.DoubleClick += new System.EventHandler(this.lstLedgerBranch_DoubleClick);
            this.uctxtLedgerBranch.GotFocus += new System.EventHandler(this.uctxtLedgerBranch_GotFocus);

            this.uctxtBranchAmount.GotFocus += new System.EventHandler(this.uctxtBranchAmount_GotFocus);
            this.uctxtBranchAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranchAmount_KeyPress);

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

            this.uctxtBranchAssAmount.GotFocus += new System.EventHandler(this.uctxtBranchAssAmount_GotFocus);
            this.uctxtBranchAssAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranchAssAmount_KeyPress);
            this.uctxtBranchAssAmount.TextChanged += new System.EventHandler(this.uctxtBranchAssAmount_TextChanged);

            this.uctxtAmount.GotFocus += new System.EventHandler(this.uctxtAmount_GotFocus);
            this.uctxtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtAmount_KeyPress);

            this.dgBranch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dgBranch_KeyPress);

            this.btnBranchClose.Click += new System.EventHandler(this.btnBranchClose_Click);

            this.txtAccBranch.GotFocus += new System.EventHandler(this.txtAccBrancht_GotFocus);
            this.txtAccBranch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtAccBranch_KeyPress);
            this.txtAccBranch.TextChanged += new System.EventHandler(this.txtAccBranch_TextChanged);
            this.txtAccBranch.KeyDown += new KeyEventHandler(txtAccBranch_KeyDown);
            this.lstLedgerBranchAccumulated.DoubleClick += new System.EventHandler(this.lstLedgerBranchAccumulated_DoubleClick);

            this.dgAccumulateBranch.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgAccumulateBranch_CellContentClick);
            this.txtAccuBranchAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAccuBranchAmount_KeyPress);
            this.txtWittendownValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWittendownValue_KeyPress);
            this.txtAssetsLife.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAssetsLife_KeyPress);
            this.txtDepRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDepRate_KeyPress);

            Utility.CreateListBoxHeight(lstUnder, pnlMain, uctxtUnder, 0, 200);
            Utility.CreateListBox(lstCostCenter, pnlMain, uctxtCostCentre);
            Utility.CreateListBox(lsteffectInventory, pnlMain, txtEffectInventory);
            Utility.CreateListBox(lstcurrency, pnlMain, uctxtCurrency);
            Utility.CreateListBox(lstInactive, pnlMain, uctxtInactive);

            Utility.CreateListBox(lstBranchName, pnlCostCenter, uctxtBranch,uctxtCostCenterNew.Width);
            Utility.CreateListBox(lstCostCategory, pnlCostCenter, uctxtCostCategory,100);
            Utility.CreateListBox(lstCostCenterNew, pnlCostCenter, uctxtCostCenterNew,100);

            Utility.CreateListBox(lstLedgerBranch, pnlBranch, uctxtLedgerBranch, 0);
            Utility.CreateListBox(lstAssetsBranch, pnlAssets, uctxtAssetBranchName, 100);
            Utility.CreateListBox(lstLedgerBranchAccumulated, PicAssetBranch, txtAccBranch, 0);
        

            TabChange();
            #endregion
        }

        #region "Tab change

        private void TabChange()
        {
            uctxtLedgerName.Focus();

            uctxtLedgerName.AllToNextTab(uctxtUnder);
            uctxtUnder.AllToNextTab(uctxtCostCentre);
            uctxtCostCentre.AllToNextTab(uctxtCurrency);
            uctxtCurrency.AllToNextTab(txtEffectInventory);
            txtEffectInventory.AllToNextTab(uctxtOpeningBalance);
            uctxtOpeningBalance.AllToNextTab(uctxtDrCr);
           
            uctxtDrCr.AllToNextTab(uctxtInactive);
            uctxtAddress1.AllToNextTab(uctxtCity);
            uctxtCity.AllToNextTab(uctxtPostal);
            uctxtPostal.AllToNextTab(uctxtPhone);
            uctxtPhone.AllToNextTab(uctxtEMail);
            uctxtEMail.AllToNextTab(uctxtFax);
            uctxtFax.AllToNextTab(uctxtInactive);
            uctxtInactive.AllToNextTab(btnSave);

            txtAssetsLedger.AllToNextTab(txtPurchaseAmount);
            txtPurchaseAmount.AllToNextTab(cboDepMethod);
            cboDepMethod.AllToNextTab(txtDepRate);
            txtDepRate.AllToNextTab(txtAssetsLife);
            txtAssetsLife.AllToNextTab(dteEffectform);
            dteEffectform.AllToNextTab(txtAccumulatedDep);
            txtAccumulatedDep.AllToNextTab(txtWittendownValue);
            txtWittendownValue.AllToNextTab(txtSalvageValue);
            txtSalvageValue.AllToNextTab(uctxtCostCentre);

           


        }
        #endregion
        #region "Additem"
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
                calculateTotal();
            }

        }
        #endregion
        #region "Calculatetotal
        private void calculateTotal()
        {
            double dblNetAmount = 0,dblBranchTotal=0,dblAssetsTotal=0,dblAccBranchTotal=0;
            for (int i = 0; i < DgCostCenter.Rows.Count; i++)
            {
                dblNetAmount = dblNetAmount + Convert.ToDouble(DgCostCenter.Rows[i].Cells[3].Value);
            }
            for (int i = 0; i < dgBranch.Rows.Count; i++)
            {
                dblBranchTotal = dblBranchTotal + Convert.ToDouble(dgBranch.Rows[i].Cells[1].Value);
            }
            for (int i = 0; i < ucGridAssetBranch.Rows.Count; i++)
            {
                dblAssetsTotal = dblAssetsTotal + Convert.ToDouble(ucGridAssetBranch.Rows[i].Cells[1].Value);
            }
            for (int i = 0; i < dgAccumulateBranch.Rows.Count; i++)
            {
                dblAccBranchTotal = dblAccBranchTotal + Convert.ToDouble(dgAccumulateBranch.Rows[i].Cells[1].Value);
            }
            txtTotal.Text = dblNetAmount.ToString();
            txtBranchTotal.Text = dblBranchTotal.ToString();
            txtAssetsTotalBranch.Text = dblAssetsTotal.ToString();
            txtTotalAccBranch.Text = dblAccBranchTotal.ToString();
        }
        #endregion
        #region "User DefineEvent"
     

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

        private void txtDepRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtAssetsLife.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(txtDepRate, txtPurchaseAmount);
            }
        }
        private void txtAssetsLife_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dteEffectform.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(txtAssetsLife, txtDepRate);
            }
        }
        private void txtWittendownValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtSalvageValue.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(txtWittendownValue, txtAccumulatedDep);
            }
        }
        private void txtAccBranch_TextChanged(object sender, EventArgs e)
        {
            if (txtAccBranch.Text != "")
            {
                lstLedgerBranchAccumulated.Visible = true;
            }
            lstLedgerBranchAccumulated.SelectedIndex = lstLedgerBranchAccumulated.FindString(txtAccBranch.Text);
        }

        private void lstLedgerBranchAccumulated_DoubleClick(object sender, EventArgs e)
        {
            txtAccBranch.Text = lstLedgerBranchAccumulated.Text;
            txtAccuBranchAmount.Focus();
            lstLedgerBranchAccumulated.Visible = false;

        }

        private void txtAccBranch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                if (lstLedgerBranchAccumulated.Items.Count > 0)
                {
                    txtAccBranch.Text = lstLedgerBranchAccumulated.Text;
                }
                txtAccuBranchAmount.Focus();
                lstLedgerBranchAccumulated.Visible = false;
               


            }
        }
        private void txtAccBranch_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Up)
            {
                if (lstLedgerBranchAccumulated.SelectedItem != null)
                {
                    lstLedgerBranchAccumulated.SelectedIndex = lstLedgerBranchAccumulated.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstLedgerBranchAccumulated.Items.Count - 1 > lstLedgerBranchAccumulated.SelectedIndex)
                {
                    lstLedgerBranchAccumulated.SelectedIndex = lstLedgerBranchAccumulated.SelectedIndex + 1;
                }
            }

        }




        private void txtAccBrancht_GotFocus(object sender, System.EventArgs e)
        {
            lstAssetsBranch.Visible = false;
            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
          
        }

        private void txtAccumulatedDep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtWittendownValue.Text = (Utility.Val(txtPurchaseAmount.Text) - Utility.Val(txtAccumulatedDep.Text)).ToString();
                if (Utility.Val(txtAccumulatedDep.Text.ToString()) > 0)
                {
                    PicAssetBranch.Visible = true;
                    PicAssetBranch.Top = PicAssetBranch.Top + 5;
                    PicAssetBranch.Left = PicAssetBranch.Left + 1;
                    PicAssetBranch.Size = new Size(433, 179);
                    dgAccumulateBranch.Size = new Size(423, 92);
                    btnAssetApply.Top = PicAssetBranch.Height + 30;
                    btnAssetApply.Left = 200;
                    txtAccDistrAmountPre.Text = txtAccumulatedDep.Text;
                    txtAccuBranchAmount.Text = txtAccumulatedDep.Text;
                    txtAccBranch.Focus();
                }
                else
                {
                    txtWittendownValue.Focus();
                }
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(txtAccumulatedDep, txtAssetsLife);
            }
        }
        private void dteEffectform_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtWittendownValue.Text = (Utility.Val(txtPurchaseAmount.Text) - Utility.Val(txtAccumulatedDep.Text)).ToString();
                txtAccumulatedDep.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(txtAssetsLife, txtAssetsLife);
            }
        }
        private void uctxtLedgerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R && e.Modifiers == Keys.Control)
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
                uctxtLedgerName.Text = (String)rk.GetValue("Ledger", "");
                rk.Close();
            }

        }
        private void uctxtBranchAssAmount_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumericNew(uctxtBranchAmount.Text) == false)
            {
                uctxtBranchAmount.Text = "";
            }
        }
        private void uctxtOpeningBalance_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumericNew(uctxtOpeningBalance.Text) == false)
            {
                uctxtOpeningBalance.Text = "";
            }
        }

        private void uctxtOpeningBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                mChangeOpening(uctxtDrCr.Text);
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtOpeningBalance, txtEffectInventory);
            }
        }

        private void uctxtLedgerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            long lngGroupPrimaryType=0;
            if (e.KeyChar == (char)Keys.Return)
            {
                if (m_acction == 1)
                {
                    if (Utility.gIsExistLedger(strComID, uctxtLedgerName.Text.ToString()))
                    {
                        MessageBox.Show("Sorry This is Duplicate, Can't Save");
                        uctxtLedgerName.Text = "";
                        uctxtLedgerName.Focus();
                        return;

                    }
                }

                if (uctxtUnder.Enabled)
                {
                    uctxtUnder.Focus();
                }
                else
                {
                    if (Utility.Val(uctxtOpeningBalance.Text) == 0)
                    {
                        if (lngGroupPrimaryType == 0)
                        {
                            if (Utility.Val(uctxtOpeningBalance.Text) == 0)
                            {
                                if (lngGroupPrimaryType == 0)
                                {
                                    lngGroupPrimaryType = Utility.glngGetPrimaryType(uctxtUnder.Text);
                                }
                                if (lngGroupPrimaryType == (long)Utility.LEDGER_PRM_TYPE.lgrASSET || lngGroupPrimaryType == (long)Utility.LEDGER_PRM_TYPE.lgrEXPENSES)
                                {
                                    uctxtDrCr.Text = "Dr";
                                }
                                else
                                {
                                    uctxtDrCr.Text = "Cr";
                                }

                            }
                        }

                    }
                    uctxtCostCentre.Select();
                    uctxtCostCentre.Focus();
                }
            }
        }
        private void uctxtLedgerName_TextChanged(object sender, EventArgs e)
        {
            int x = uctxtLedgerName.SelectionStart;
            uctxtLedgerName.Text = Utility.gmakeProperCase(uctxtLedgerName.Text);
            uctxtLedgerName.SelectionStart = x;
        }
        private void uctxtBranchAmount_GotFocus(object sender, System.EventArgs e)
        {
            lstLedgerBranch.Visible = false;
            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
           
        }
        private void uctxtBranchAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtBranchAmount.Text != "" || uctxtBranchAmount.Text != "0")
                {
                    mAdditemBillBranchOpn(uctxtLedgerBranch.Text, Convert.ToDouble(uctxtBranchAmount.Text));
                    uctxtLedgerBranch.Focus();
                }
                else
                {
                    btnBranchApply.Focus();
                }


            }
        }
        private void uctxtLedgerBranch_GotFocus(object sender, System.EventArgs e)
        {
            //lstLedgerBranch.Visible = true;
            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
          
            lstLedgerBranch.SelectedIndex = lstLedgerBranch.FindString(uctxtLedgerBranch.Text);
        }
        private void mAdditemBillBranchOpn(string strBranchName, double dblOpnAmount)
        {
            int selRaw;
            if (Utility.Val(txtBranchPreTotal.Text) != Utility.Val(txtBranchTotal.Text))
                dgBranch.AllowUserToAddRows = true;
            selRaw = Convert.ToInt16(dgBranch.RowCount.ToString());
            selRaw = selRaw - 1;
            dgBranch.Rows.Add();
            dgBranch[0, selRaw].Value = strBranchName.ToString();
            dgBranch[1, selRaw].Value = dblOpnAmount.ToString();
            dgBranch[2, selRaw].Value = "Delete";
            dgBranch.AllowUserToAddRows = false;
            uctxtLedgerBranch.Text = "";
            uctxtBranchAmount.Text = "";
            //uctxtBatchNo.Text = "";
            calculateTotal();
            uctxtBranchAmount.Text = (Utility.Val(txtBranchPreTotal.Text) - Utility.Val(txtBranchTotal.Text)).ToString();
        }
        private void uctxtLedgerBranch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (Utility.Val(txtBranchPreTotal.Text) != Utility.Val(txtBranchTotal.Text))
                {
                    if (lstBranchName.Items.Count > 0)
                    {
                        uctxtLedgerBranch.Text = lstBranchName.Text;
                    }

                    uctxtBranchAmount.Focus();
                }
                else
                {
                    lstBranchName.Visible = false;
                    btnBranchApply.Focus();
                }
               


            }
        }
        private void uctxtLedgerBranch_TextChanged(object sender, EventArgs e)
        {
            if (uctxtLedgerBranch.Text != "")
            {
                lstLedgerBranch.Visible = true;
            }
            lstLedgerBranch.SelectedIndex = lstLedgerBranch.FindString(uctxtLedgerBranch.Text);
        }

        private void lstLedgerBranch_DoubleClick(object sender, EventArgs e)
        {
            uctxtLedgerBranch.Text = lstLedgerBranch.Text;
            uctxtBranchAmount.Focus();


        }

        private void uctxtAssetBranchName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                if (lstLedgerBranch.Items.Count > 0)
                {
                    uctxtAssetBranchName.Text = lstAssetsBranch.Text;
                }
                uctxtBranchAssAmount.Focus();


            }
        }
        private void uctxtLedgerBranch_KeyDown(object sender, KeyEventArgs e)
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

      


        private void uctxtBranchAssAmount_GotFocus(object sender, System.EventArgs e)
        {
            lstAssetsBranch.Visible = false;
            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
           
        }
        private void mAdditemBill(string strBranchName, double dblOpnAmount)
        {
            int selRaw;
            bool blngCheck=false ;
            string strDown = "";
            for (int j = 0; j < ucGridAssetBranch.RowCount; j++)
            {
                if (ucGridAssetBranch[0, j].Value != null)
                {
                    strDown = ucGridAssetBranch[0, j].Value.ToString();
                }
                if (strBranchName == strDown.ToString())
                {
                    blngCheck = true;
                }

            }
          

            if (blngCheck == false)
            {
                if (Utility.Val(txtAssetBranchAmountPre.Text) != Utility.Val(txtAssetsTotalBranch.Text))
                    ucGridAssetBranch.AllowUserToAddRows = true;
                selRaw = Convert.ToInt16(ucGridAssetBranch.RowCount.ToString());
                selRaw = selRaw - 1;
                if (selRaw ==-1)
                {
                    selRaw = 0;
                }
                ucGridAssetBranch.Rows.Add();
                ucGridAssetBranch[0, selRaw].Value = strBranchName.ToString();
                ucGridAssetBranch[1, selRaw].Value = dblOpnAmount.ToString();
                ucGridAssetBranch[2, selRaw].Value = "Delete";
                ucGridAssetBranch.AllowUserToAddRows = false;
                uctxtBranchAssAmount.Text = "";
                uctxtAssetBranchName.Text = "";
            }
            //uctxtBatchNo.Text = "";
            calculateTotal();
            uctxtBranchAssAmount.Text = (Utility.Val(txtAssetBranchAmountPre.Text) - Utility.Val(txtAssetsTotalBranch.Text)).ToString();
        }

        private void mAdditemBillnew (string strBranchName, double dblOpnAmount)
        {
            int selRaw;
            bool blngCheck = false;
            string strDown = "";
            for (int j = 0; j < dgAccumulateBranch.RowCount; j++)
            {
                if (dgAccumulateBranch[0, j].Value != null)
                {
                    strDown = dgAccumulateBranch[0, j].Value.ToString();
                }
                if (strBranchName == strDown.ToString())
                {
                    blngCheck = true;
                }

            }


            if (blngCheck == false)
            {
                if (Utility.Val(txtAccDistrAmountPre.Text) != Utility.Val(txtTotalAccBranch.Text))
                    ucGridAssetBranch.AllowUserToAddRows = true;
                selRaw = Convert.ToInt16(dgAccumulateBranch.RowCount.ToString());
                selRaw = selRaw - 1;
                if (selRaw==-1)
                {
                    selRaw = 0;
                }
                dgAccumulateBranch.Rows.Add();
                dgAccumulateBranch[0, selRaw].Value = strBranchName.ToString();
                dgAccumulateBranch[1, selRaw].Value = dblOpnAmount.ToString();
                dgAccumulateBranch[2, selRaw].Value = "Delete";
                dgAccumulateBranch.AllowUserToAddRows = false;
                txtAccuBranchAmount.Text = "";
                txtAccBranch.Text = "";
            }
            //uctxtBatchNo.Text = "";
            calculateTotal();
            txtAccuBranchAmount.Text = (Utility.Val(txtAccDistrAmountPre.Text) - Utility.Val(txtTotalAccBranch.Text)).ToString();
        }
        private void uctxtBranchAssAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtBranchAssAmount.Text != "" || uctxtBranchAssAmount.Text != "0")
                {
                    mAdditemBill(uctxtAssetBranchName.Text, Convert.ToDouble(uctxtBranchAssAmount.Text));
                    uctxtAssetBranchName.Focus();
                    lstAssetsBranch.Visible = false;
                    if (Utility.Val(uctxtBranchAssAmount.Text) ==0)
                    {
                        pnlAssets.Visible = false;
                        cboDepMethod.Focus();

                    }
                }
                else
                {
                    btnAssetApply.Focus();
                }
               

            }
        }
        private void uctxtAssetBranchName_TextChanged(object sender, EventArgs e)
        {
            lstAssetsBranch.Visible = true;
            lstAssetsBranch.SelectedIndex = lstAssetsBranch.FindString(uctxtAssetBranchName.Text);
        }

        private void lstAssetsBranch_DoubleClick(object sender, EventArgs e)
        {
            uctxtAssetBranchName.Text = lstAssetsBranch.Text;
            uctxtBranchAssAmount.Focus();


        }

       
        private void uctxtAssetBranchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstAssetsBranch.SelectedItem != null)
                {
                    lstAssetsBranch.SelectedIndex = lstAssetsBranch.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstAssetsBranch.Items.Count - 1 > lstAssetsBranch.SelectedIndex)
                {
                    lstAssetsBranch.SelectedIndex = lstAssetsBranch.SelectedIndex + 1;
                }
            }

        }

        private void uctxtAssetBranchName_GotFocus(object sender, System.EventArgs e)
        {
            //lstAssetsBranch .Visible = true;
            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstUnder.Visible = false;
            lstInactive.Visible = false;
            lstcurrency.Visible = false;
            lstBranchName.Visible = false;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
         
        }


        private void btnBranchClose_Click(object sender, EventArgs e)
        {
            pnlAssets.Visible = false;
        }
        private void txtAccumulatedDep_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumericNew(txtAccumulatedDep.Text) == false)
            {
                txtAccumulatedDep.Text = "";
            }
        }
        private void txtSalvageValue_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumericNew(txtSalvageValue.Text) == false)
            {
                txtSalvageValue.Text = "";
            }
        }
        private void txtWittendownValue_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumericNew(txtWittendownValue.Text) == false)
            {
                txtWittendownValue.Text = "";
            }
        }

        private void txtDepRate_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumericNew(txtDepRate.Text) == false)
            {
                txtDepRate.Text = "";
            }
        }

        private void txtPurchaseAmount_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumericNew(txtPurchaseAmount.Text) == false)
            {
                txtPurchaseAmount.Text = "";
            }
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
        private void uctxtLedgerName_LostFocus(object sender, System.EventArgs e)
        {
            //if (m_acction == 1)
            //{
            //    if (Utility.gIsExistLedger(strComID, uctxtLedgerName.Text.ToString()))
            //    {
            //        MessageBox.Show("Sorry This is Duplicate, Can't Save");
            //        uctxtLedgerName.Text = "";
            //        uctxtLedgerName.Focus();
            //        return;

            //    }
            //}
            //else if (m_acction == 2)
            //{
            //    uctxtLedgerName.Focus();
            //}
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

            }
        }
        private void uctxtAmount_GotFocus(object sender, System.EventArgs e)
        {
            lstCostCategory.Visible = false;
            lstCostCenterNew.Visible = false;
            lstUnder.Visible = false;
            lstcurrency.Visible = false;
            lstInactive.Visible = false;
            lsteffectInventory.Visible = false;
            lstBranchName.Visible = false;
           
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

            lstCostCategory.Visible = false;
            lstCostCenterNew.Visible = true;
            lstUnder.Visible = false;
            lstcurrency.Visible = false;
            lstInactive.Visible = false;
            lsteffectInventory.Visible = false;
         

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

            lstCostCategory.Visible = true ;
            lstCostCenterNew.Visible = false;
            lstUnder.Visible = false;
            lstcurrency.Visible = false;
            lstInactive.Visible = false;
            lsteffectInventory.Visible = false;
          
            lstBranchName.Visible = false;
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
            lstCostCategory.Visible = false;
            lstCostCenterNew.Visible = false;
            lstUnder.Visible = false;
            lstcurrency.Visible = false;
            lstInactive.Visible = false;
            lsteffectInventory.Visible = false;
       
            
            lstBranchName.SelectedIndex = lstBranchName.FindString(uctxtBranch.Text);
        }
        private void txtSalvageValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                pnlFixedAssets.Visible = false;
                if (Utility.gblnBranch)
                {
                    if (uctxtOpeningBalance.Text != "" && uctxtOpeningBalance.Text != "0")
                    {
                        lstCostCenter.Visible = false;
                        pnlBranch.Visible = true;
                        pnlBranch.Top = uctxtOpeningBalance.Top + 25;
                        pnlBranch.Left = uctxtOpeningBalance.Left;
                        pnlBranch.Size = new Size(609, 307);
                        dgBranch.Size = new Size(593, 189);
                        btnBranchApply.Top = DgCostCenter.Height + 70;
                        btnBranchApply.Location = new Point(12, 255);
                        btnBranchCancel.Location = new Point(105, 255);
                        btnBranchCancel.Top = DgCostCenter.Height + 70;
                        txtTotal.Top = DgCostCenter.Height + 70;
                        txtBranchPreTotal.Text = uctxtOpeningBalance.Text;
                        uctxtBranchAmount.Text = uctxtOpeningBalance.Text;
                        uctxtLedgerBranch.Focus();
                    }
                }
                else
                {
                    uctxtCostCentre.Focus();
                }

            }

            if (e.KeyChar ==(char)Keys.Back)
            {
                Utility.PriorSetFocusText(txtSalvageValue, txtWittendownValue);
            }

        }
        private void txtSalvageValue_GotFocus(object sender, System.EventArgs e)
        {
            lstUnder.Visible = false;
            lstCostCenter.Visible = false;
            lstcurrency.Visible = false;
            lsteffectInventory.Visible = false;
            lstInactive.Visible = false;
        
        }
        private void txtWittendownValue_GotFocus(object sender, System.EventArgs e)
        {
            lstUnder.Visible = false;
            lstCostCenter.Visible = false;
            lstcurrency.Visible = false;
            lsteffectInventory.Visible = false;
            lstInactive.Visible = false;
           
        }
        private void txtAccumulatedDep_GotFocus(object sender, System.EventArgs e)
        {
            lstUnder.Visible = false;
            lstCostCenter.Visible = false;
            lstcurrency.Visible = false;
            lsteffectInventory.Visible = false;
            lstInactive.Visible = false;

        }
        private void dteEffectform_GotFocus(object sender, System.EventArgs e)
        {
            lstUnder.Visible = false;
            lstCostCenter.Visible = false;
            lstcurrency.Visible = false;
            lsteffectInventory.Visible = false;
            lstInactive.Visible = false;
          
        }
        private void txtAssetsLife_GotFocus(object sender, System.EventArgs e)
        {
            lstUnder.Visible = false;
            lstCostCenter.Visible = false;
            lstcurrency.Visible = false;
            lsteffectInventory.Visible = false;
            lstInactive.Visible = false;
        
        }
        private void txtDepRate_GotFocus(object sender, System.EventArgs e)
        {
            lstUnder.Visible = false;
            lstCostCenter.Visible = false;
            lstcurrency.Visible = false;
            lsteffectInventory.Visible = false;
            lstInactive.Visible = false;
           
        }
        private void cboDepMethod_GotFocus(object sender, System.EventArgs e)
        {
            lstUnder.Visible = false;
            lstCostCenter.Visible = false;
            lstcurrency.Visible = false;
            lsteffectInventory.Visible = false;
            lstInactive.Visible = false;
           
        }
        private void txtPurchaseAmount_GotFocus(object sender, System.EventArgs e)
        {
            lstUnder.Visible = false;
            lstCostCenter.Visible = false;
            lstcurrency.Visible = false;
            lsteffectInventory.Visible = false;
            lstInactive.Visible = false;

        }
        private void txtAssetsLedger_GotFocus(object sender, System.EventArgs e)
        {
            lstUnder.Visible = false;
            lstCostCenter.Visible = false;
            lstcurrency.Visible = false;
            lsteffectInventory.Visible = false;
            lstInactive.Visible = false;
          
        }
        private void DgCostCenter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(char)Keys.Return)
            {
                pnlCostCenter.Visible = false;
                uctxtAddress1.Focus();
            }
        }
        private void uctxtDrCr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                mChangeOpening(uctxtDrCr.Text);
                if (uctxtCostCentre.Text == "Yes")
                {
                    if (uctxtOpeningBalance.Text != "" && uctxtOpeningBalance.Text != "0")
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
                            if (uctxtOpeningBalance.Text != "" && uctxtOpeningBalance.Text != "0")
                            {
                                pnlBranch.Visible = true;
                                pnlBranch.Top = uctxtOpeningBalance.Top + 25;
                                pnlBranch.Left = uctxtOpeningBalance.Left;
                                pnlBranch.Size = new Size(609, 250);
                                dgBranch.Size = new Size(593, 159);
                                pnlBranch.Location = new Point(126, 307);

                                btnBranchApply.Top = DgCostCenter.Height + 70;
                                btnBranchApply.Location = new Point(12, 226);
                                btnBranchCancel.Location = new Point(105, 226);

                                btnBranchCancel.Top = DgCostCenter.Height + 70;
                                txtTotal.Top = DgCostCenter.Height + 70;
                                txtBranchPreTotal.Text = uctxtOpeningBalance.Text;
                                uctxtBranchAmount.Text = uctxtOpeningBalance.Text;
                                if (dgBranch.Rows.Count > 0)
                                {
                                    if (m_acction == 1)
                                    {
                                        if (dgBranch[1, 0].Value != null)
                                        {
                                            if (Utility.Val(dgBranch[1, 0].Value.ToString()) != Utility.Val(uctxtOpeningBalance.Text))
                                            {
                                                dgBranch[1, 0].Value = Utility.Val(uctxtOpeningBalance.Text);
                                                calculateTotal();
                                            }
                                        }
                                    }
                                }
                                uctxtLedgerBranch.Focus();

                            }
                        }
                    }
                }

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtDrCr, uctxtOpeningBalance);
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

        private void uctxtDrCr_GotFocus(object sender, System.EventArgs e)
        {
            lstUnder.Visible = false;
            lstCostCenter.Visible = false;
            lstcurrency.Visible = false;
            lsteffectInventory.Visible = false;
            lstInactive.Visible = false;
       
        }
        private void uctxtCurrency_TextChanged(object sender, EventArgs e)
        {
            lstcurrency.SelectedIndex = lstcurrency.FindString(uctxtCurrency.Text);
        }
        private void uctxtInactive_TextChanged(object sender, EventArgs e)
        {
            lstInactive.SelectedIndex = lstInactive.FindString(uctxtInactive.Text);
        }
        private void uctxtUnder_TextChanged(object sender, EventArgs e)
        {
            lstUnder.SelectedIndex = lstUnder.FindString(uctxtUnder.Text);
        }

        private void uctxtCostCentre_TextChanged(object sender, EventArgs e)
        {
            lstCostCenter.SelectedIndex = lstCostCenter.FindString(uctxtCostCentre.Text);
        }
        private void txtEffectInventory_TextChanged(object sender, EventArgs e)
        {
            lsteffectInventory.SelectedIndex = lsteffectInventory.FindString(txtEffectInventory.Text);
        }

        private void lstInactive_DoubleClick(object sender, EventArgs e)
        {
            uctxtInactive.Text = lstInactive.Text;
            lstInactive.Visible = false;
            btnSave.Focus();
        }

        private void uctxtInactive_GotFocus(object sender, System.EventArgs e)
        {
            lstUnder.Visible = false;
            lstCostCenter.Visible = false;
            lstcurrency.Visible = false;
            lsteffectInventory.Visible = false;
           
            lstInactive.Visible = true;
            lstInactive.SelectedIndex = lstInactive.FindString(uctxtInactive.Text);
        }

        private void uctxtInactive_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstInactive.Items.Count > 0)
                {
                    uctxtInactive.Text = lstInactive.Text;
                }
                btnSave.Focus();
                lstInactive.Visible = false;
            }
            if (e.KeyChar==(char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtInactive, uctxtDrCr);
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

        private void uctxtFax_GotFocus(object sender, System.EventArgs e)
        {
            lstUnder.Visible = false;
            lstCostCenter.Visible = false;
            lstcurrency.Visible = false;
            lsteffectInventory.Visible = false;
            lstInactive.Visible = false;
          
        }
        private void uctxtEMail_GotFocus(object sender, System.EventArgs e)
        {
            lstUnder.Visible = false;
            lstCostCenter.Visible = false;
            lstcurrency.Visible = false;
            lsteffectInventory.Visible = false;
            lstInactive.Visible = false;
      
        }
        private void uctxtPhone_GotFocus(object sender, System.EventArgs e)
        {
            lstUnder.Visible = false;
            lstCostCenter.Visible = false;
            lstcurrency.Visible = false;
            lsteffectInventory.Visible = false;
            lstInactive.Visible = false;
           
        }
        private void uctxtPostal_GotFocus(object sender, System.EventArgs e)
        {
            lstUnder.Visible = false;
            lstCostCenter.Visible = false;
            lstcurrency.Visible = false;
            lsteffectInventory.Visible = false;
            lstInactive.Visible = false;
         
        }
        private void uctxtAddress1_GotFocus(object sender, System.EventArgs e)
        {
            lstUnder.Visible = false;
            lstCostCenter.Visible = false;
            lstcurrency.Visible = false;
            lsteffectInventory.Visible = false;
            lstInactive.Visible = false;
       
        }
        private void uctxtOpeningBalance_GotFocus(object sender, System.EventArgs e)
        {
            lstUnder.Visible = false;
            lstCostCenter.Visible = false;
            lstcurrency.Visible = false;
            lsteffectInventory.Visible = false;
            lstInactive.Visible = false;
          
        }
        private void uctxtLedgerName_GotFocus(object sender, System.EventArgs e)
        {
            lstUnder.Visible = false;
            lstCostCenter.Visible = false;
            lstcurrency.Visible = false;
            lsteffectInventory.Visible = false;
            lstInactive.Visible = false;
        
           
           
        }


        private void lstcurrency_DoubleClick(object sender, EventArgs e)
        {
            uctxtCurrency.Text = lstcurrency.Text;
            lstcurrency.Visible = false;
            txtEffectInventory.Focus();
        }

        private void uctxtCurrency_GotFocus(object sender, System.EventArgs e)
        {
            lstUnder.Visible = false;
            lstCostCenter.Visible = false;
            lstcurrency.Visible = true;
            lsteffectInventory.Visible = false;
            lstInactive.Visible = false;
         
            lstcurrency.SelectedIndex = lstcurrency.FindString(uctxtCurrency.Text);
        }

        private void uctxtCurrency_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstcurrency.Items.Count > 0)
                {
                    uctxtCurrency.Text = lstcurrency.Text;
                }
                txtEffectInventory.Focus();

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


        private void lsteffectInventory_DoubleClick(object sender, EventArgs e)
        {
            txtEffectInventory.Text = lsteffectInventory.Text;
            lsteffectInventory.Visible = false;
            uctxtPFAmount.Focus();
        }

        private void txtEffectInventory_GotFocus(object sender, System.EventArgs e)
        {
            lstUnder.Visible = false;
            lstCostCenter.Visible = false;
            lstcurrency.Visible = false;
            lsteffectInventory.Visible = true;
            lstInactive.Visible = false;
        
            lsteffectInventory.SelectedIndex = lsteffectInventory.FindString(txtEffectInventory.Text);
        }
        private void uctxtPFAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtOpeningBalance.Focus();

            }
           
        }
        private void txtEffectInventory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lsteffectInventory.Items.Count > 0)
                {
                    txtEffectInventory.Text = lsteffectInventory.Text;
                }
                uctxtPFAmount.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(txtEffectInventory, uctxtCostCentre);
            }
        }
        private void txtEffectInventory_KeyDown(object sender, KeyEventArgs e)
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



        private void uctxtCostCentre_GotFocus(object sender, System.EventArgs e)
        {

            lstUnder.Visible = false;
            lstCostCenter.Visible = true ;
            lstcurrency.Visible = false;
            lsteffectInventory.Visible = false;
            lstInactive.Visible = false;
       
            lstCostCenter.SelectedIndex = lstCostCenter.FindString(uctxtCostCentre.Text);
        }
        private void lstCostCenter_DoubleClick(object sender, EventArgs e)
        {
            uctxtCostCentre.Text = lstCostCenter.Text;
            lstCostCenter.Visible = false;
            if (uctxtCurrency.Enabled)
            {
                uctxtCurrency.Focus();
            }
            else
            {
                txtEffectInventory.Focus();
            }
        }
        private void uctxtCostCentre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstCostCenter.Items.Count > 0)
                {
                    uctxtCostCentre.Text = lstCostCenter.Text;
                }
                if (uctxtCurrency.Enabled)
                {
                    uctxtCurrency.Focus();
                }
                else
                {
                    txtEffectInventory.Focus();
                }

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                if (uctxtUnder.Enabled)
                {
                    Utility.PriorSetFocusText(uctxtCostCentre, uctxtUnder);
                }
                else
                {
                    Utility.PriorSetFocusText(uctxtCostCentre, uctxtLedgerName);
                }
            }

        }
        private void uctxtCostCentre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstUnder.SelectedItem != null)
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
        private void uctxtUnder_GotFocus(object sender, System.EventArgs e)
        {

            lstUnder.Visible = true;
            lstCostCenter.Visible = false;
            lstcurrency.Visible = false;
            lsteffectInventory.Visible = false;
            lstInactive.Visible = false;
         
            lstUnder.SelectedIndex = lstUnder.FindString(uctxtUnder.Text);
        }
        private void lstUnder_DoubleClick(object sender, EventArgs e)
        {
            long lngGroupPrimaryType = 0;
            uctxtUnder.Text = lstUnder.Text;
            if (Utility.Val(uctxtOpeningBalance.Text) == 0)
            {
                if (lngGroupPrimaryType == 0)
                {
                    if (Utility.Val(uctxtOpeningBalance.Text) == 0)
                    {
                        if (lngGroupPrimaryType == 0)
                        {
                            lngGroupPrimaryType = Utility.glngGetPrimaryType(uctxtUnder.Text);
                        }
                        if (lngGroupPrimaryType == (long)Utility.LEDGER_PRM_TYPE.lgrASSET || lngGroupPrimaryType == (long)Utility.LEDGER_PRM_TYPE.lgrEXPENSES)
                        {
                            uctxtDrCr.Text = "Dr";
                        }
                        else
                        {
                            uctxtDrCr.Text = "Cr";
                        }

                    }
                }

            }
            lstUnder.Visible = false;
            uctxtCostCentre.Focus();
        }
        private void uctxtUnder_KeyPress(object sender, KeyPressEventArgs e)
        {
            long lngGroupPrimaryType = 0;
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtUnder.Text = lstUnder.Text;
                if (Utility.Val(uctxtOpeningBalance.Text) == 0)
                {
                    if (lngGroupPrimaryType == 0)
                    {
                        if (Utility.Val(uctxtOpeningBalance.Text) == 0)
                        {
                            if (lngGroupPrimaryType == 0)
                            {
                                lngGroupPrimaryType = Utility.glngGetPrimaryType(uctxtUnder.Text);
                            }
                            if (lngGroupPrimaryType == (long)Utility.LEDGER_PRM_TYPE.lgrASSET || lngGroupPrimaryType == (long)Utility.LEDGER_PRM_TYPE.lgrEXPENSES)
                            {
                                uctxtDrCr.Text = "Dr";
                            }
                            else
                            {
                                uctxtDrCr.Text = "Cr";
                            }

                        }
                    }

                }

                if (lstUnder.Items.Count > 0)
                {
                    long lngFixedAssets = Utility.mlngFixedAsset(uctxtUnder.Text);
                    if (lngFixedAssets == (long)(Utility.GR_GROUP_TYPE.grFIXED_ASSET))
                    {
                        txtAssetsLedger.Text = uctxtLedgerName.Text;
                        pnlFixedAssets.Top = uctxtUnder.Top + 25;
                        pnlFixedAssets.Left = uctxtUnder.Left;
                        pnlFixedAssets.Visible = true;
                        pnlFixedAssets.Size = new Size(447, 270);
                        txtAssetsLedger.Focus();
                    }
                    else
                    {
                        pnlFixedAssets.Visible = false;
                        uctxtCostCentre.Focus();
                    }
                }


            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtUnder, uctxtLedgerName);
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

        #endregion
        #region "Change Opn"
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
        #endregion
        #region "Load"
        private void frmAccountsLedger_Load(object sender, EventArgs e)
        {
            lstAssetsBranch.Visible = false;
            lstUnder.Visible = false;
            lstCostCenter.Visible = false;
            lsteffectInventory.Visible = false;
            lstcurrency.Visible = false;
            lstInactive.Visible = false ;
            lstCostCenterNew.Visible = false;
            lstCostCategory.Visible = false;
            lstBranchName.Visible = false;
            lstLedgerBranch.Visible = false;
            lstLedgerBranchAccumulated.Visible = false;

            lstcurrency.ValueMember = "strCurrency";
            lstcurrency.DisplayMember = "strCurrency";
            lstcurrency.DataSource = accms.mFillCurrencyList(strComID).ToList();

            lstUnder.ValueMember = "GroupName";
            lstUnder.DisplayMember = "GroupName";
            lstUnder.DataSource = accms.mFillGroup(strComID, 0).ToList();

            lstBranchName.ValueMember = "BranchID";
            lstBranchName.DisplayMember = "BranchName";
            lstBranchName.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();

            lstAssetsBranch.ValueMember = "BranchID";
            lstAssetsBranch.DisplayMember = "BranchName";
            lstAssetsBranch.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();

            lstLedgerBranch.ValueMember = "BranchID";
            lstLedgerBranch.DisplayMember = "BranchName";
            lstLedgerBranch.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();

            lstLedgerBranchAccumulated.ValueMember = "BranchID";
            lstLedgerBranchAccumulated.DisplayMember = "BranchName";
            lstLedgerBranchAccumulated.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();

            lstCostCategory.ValueMember = "strVectorcategory";
            lstCostCategory.DisplayMember = "strVectorcategory";
            lstCostCategory.DataSource = accms.mFillVectorCategory(strComID).ToList();

           
            //if (Utility.gblnBranch)
            //{
            //    mloadBrach();
            //}

            LoadDefaultValue();
        }
        #endregion
        #region "Load Branch"
        private void mloadBrach()
        {
           int introw=0;
           List<BranchConfig> ooBranch = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
           if (ooBranch.Count>0)
           {
               foreach (BranchConfig ob in ooBranch)
               {
                   dgBranch.Rows.Add();
                   ucGridAssetBranch.Rows.Add();
                   dgBranch[0, introw].Value = ob.BranchName;
                   ucGridAssetBranch[0, introw].Value = ob.BranchName;
                   introw += 1;
               }
           }
        }
        #endregion
        #region "Default Value"
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

            string strDiffenece = accms.mDisplayOpening(strComID);
            var results = strDiffenece.Split(new string[] { "~" }, StringSplitOptions.None);
            lblDebit.Text = results[0];
            lblCredit.Text = results[1];
            lblDifference.Text = results[2];
            mdblDebit = Utility.Val(results[0]);
            mdblCredit = Utility.Val(results[1]);

        }
        #endregion
        #region "Click
        private void btnCancel_Click(object sender, EventArgs e)
        {
            pnlCostCenter.Visible = false;
            uctxtInactive.Focus();
        }
       
        private void btnApply_Click(object sender, EventArgs e)
        {
            if (DgCostCenter[0, 0].Value != null)
            {
                if (txtpreAmount.Text != txtTotal.Text)
                {
                    MessageBox.Show("Cost Center Amount Mismatch");
                    txtTotal.Focus();
                    return;
                }
            }
            pnlCostCenter.Visible = false;
            if (Utility.gblnBranch )
            {
                if (pnlCostCenter.Visible == false)
                {
                    if (uctxtOpeningBalance.Text != "" && uctxtOpeningBalance.Text != "0")
                    {
                        pnlBranch.Visible = true;
                        uctxtLedgerBranch.Focus();
                        pnlBranch.Top = uctxtOpeningBalance.Top + 25;
                        pnlBranch.Left = uctxtOpeningBalance.Left;
                        pnlBranch.Size = new Size(619, 282);
                        pnlBranch.Location = new Point(148, 327);
                        dgBranch.Size = new Size(593, 177);
                        btnBranchApply.Top = DgCostCenter.Height + 70;
                        //btnBranchApply.Left = 200;
                        //btnBranchCancel.Left = 300;
                        btnBranchCancel.Top = DgCostCenter.Height + 70;
                        txtTotal.Top = DgCostCenter.Height + 70;
                        txtBranchPreTotal.Text = uctxtOpeningBalance.Text;
                        uctxtLedgerBranch.Focus();
                    }
                }
            }
            else
            {
                uctxtInactive.Focus();
            }
        }
        private void DgCostCenter_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 4)
                {
                    double dblamnt = 0;
                    if (e.RowIndex == 0)
                    {
                        dblamnt = Convert.ToDouble(txtpreAmount.Text);
                        uctxtAmount.Text = (Convert.ToDouble(txtpreAmount.Text) - dblamnt).ToString();
                    }
                    else
                    {
                        DgCostCenter.Rows.RemoveAt(e.RowIndex);
                        for (int i = 0; i < DgCostCenter.Rows.Count; i++)
                        {
                            dblamnt = dblamnt + Convert.ToDouble(DgCostCenter.Rows[i].Cells[3].Value);
                        }
                        uctxtAmount.Text = (Convert.ToDouble(txtpreAmount.Text) - dblamnt).ToString();
                    }
                  
                   
                    calculateTotal();
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void btnBranchApply_Click(object sender, EventArgs e)
        {
            
            if (Convert.ToDouble(txtBranchPreTotal.Text) != Convert.ToDouble(txtBranchTotal.Text))
            {
                MessageBox.Show("Branch Total Mismatch");
                return;
            }
            pnlBranch.Visible = false;
            btnSave.Focus();
        }

        private void btnBranchCancel_Click(object sender, EventArgs e)
        {
            pnlBranch.Visible = false;
            uctxtAddress1.Focus();
        }
        #endregion
        #region "Validationfield"
        private bool ValidateFields()
        {
            

            if (uctxtDrCr.Text =="")
            {
                MessageBox.Show("Cannot be Empty", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                uctxtDrCr.Focus();
                return false;
            }

            if (uctxtLedgerName.Text == "")
            {
                MessageBox.Show("Cannot be Empty", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                uctxtLedgerName.Focus();
                return false;
            }
            if (Utility.gblnAccessControl)
            {
                if (!Utility.glngGetPriviliges(strComID,Utility.gstrUserName, lngFormPriv, m_acction))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return false;
                }
            }


            return true;
        }
        #endregion
        #region "Clear"
        private void mClear()
        {
            uctxtLedgerName.Text="";
            //uctxtUnder.Text="";
            uctxtFax.Text="";
            uctxtPFAmount.Text = "";
            uctxtEMail.Text="";
            uctxtAddress1.Text="";
            uctxtUnder.Enabled = true;
            pnlBranch.Visible = false;
            txtAssetsLedger.ReadOnly = true;
            uctxtCity.Text="";
            uctxtPostal.Text="";
            uctxtCurrency.Text = "BDT";
            uctxtPhone.Text="";
            txtBranchTotal.Text = "";
            txtEffectInventory.Text="";
            uctxtInactive.Text="";
            uctxtCostCentre.Text=""; 
            uctxtDrCr.Text="";
            uctxtOpeningBalance.Text ="";
            DgCostCenter.Rows.Clear();
            dgBranch.Rows.Clear();
            ucGridAssetBranch.Rows.Clear();
            dgAccumulateBranch.Rows.Clear();
            txtPurchaseAmount.Text ="";
            txtAssetsLife.Text ="";
            txtDepRate.Text ="";
            txtAccumulatedDep.Text = "";
            txtWittendownValue.Text ="";
            txtSalvageValue.Text ="";
            uctxtDrCr.Text = "Dr";
            
            if (m_acction == 1)
            {
                uctxtLedgerName.Focus();
            }
            m_acction = 1;
        }
        #endregion
        #region "Click"
        private void btnSave_Click(object sender, EventArgs e)
        {

            string strCostcenter = "", strBranch = "", strAssetsLedger = "", strmsg = "", strStatus = "", strCostCenterStatus = "", strAccBranch = "";
            long lngAssetPercent = 0, lngReducingBal = 0;
            double dblOpnBalance = 0, dblPurchaseAmount = 0, dblAssetsLife = 0,
                dblDeprate = 0, dblAccumulatedDep = 0, dblwrittendownvalue = 0, dblSalvagevalue = 0;

            if (ValidateFields() == false)
            {
                return;
            }
            if (uctxtInactive.Text == "")
            {
                strStatus = "No";
            }
            else
            {
                strStatus = uctxtInactive.Text;
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
                for (int i = 0; i < dgBranch.Rows.Count; i++)
                {
                    if (dgBranch[0, i].Value != null)
                    {
                        strBranch += dgBranch[0, i].Value.ToString() + "," + dgBranch[1, i].Value.ToString() + "~";
                    }
                }
                for (int i = 0; i < ucGridAssetBranch.Rows.Count; i++)
                {
                    if (ucGridAssetBranch[0, i].Value != null)
                    {
                        strAssetsLedger += ucGridAssetBranch[0, i].Value.ToString() + "," + ucGridAssetBranch[1, i].Value.ToString() + "~";
                    }
                }
                for (int i = 0; i < dgAccumulateBranch.Rows.Count; i++)
                {
                    if (dgAccumulateBranch[0, i].Value != null)
                    {
                        strAccBranch += dgAccumulateBranch[0, i].Value.ToString() + "," + dgAccumulateBranch[1, i].Value.ToString() + "~";
                    }
                }
            }
            catch (Exception ex)
            {

            }

            if (cboDepMethod.Text == "Reducing Balance")
            {
                lngReducingBal = 1;
            }
            else if (cboDepMethod.Text == "Straight Line")
            {
                if (Convert.ToInt16(txtDepRate.Text) > 0)
                {
                    lngAssetPercent = 1;
                }
                lngReducingBal = 2;
            }
            else
            {
                lngReducingBal = 0;
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
                if (txtPurchaseAmount.Text != "")
                {
                    dblPurchaseAmount = Convert.ToDouble(txtPurchaseAmount.Text);
                }
                else
                {
                    dblPurchaseAmount = 0;
                }
                if (txtAssetsLife.Text != "")
                {
                    dblAssetsLife = Convert.ToDouble(txtAssetsLife.Text);
                }
                else
                {
                    dblAssetsLife = 0;
                }
                if (txtDepRate.Text != "")
                {
                    dblDeprate = Convert.ToDouble(txtDepRate.Text);
                }
                else
                {
                    dblDeprate = 0;
                }
                if (txtAccumulatedDep.Text != "")
                {
                    dblAccumulatedDep = Convert.ToDouble(txtAccumulatedDep.Text);
                }
                else
                {
                    dblAccumulatedDep = 0;
                }
                if (txtWittendownValue.Text != "")
                {
                    dblwrittendownvalue = Convert.ToDouble(txtWittendownValue.Text);
                }
                else
                {
                    dblwrittendownvalue = 0;
                }
                if (txtSalvageValue.Text != "")
                {
                    dblSalvagevalue = Convert.ToDouble(txtSalvageValue.Text);
                }
                else
                {
                    dblSalvagevalue = 0;
                }
                if (uctxtCostCentre.Text == "")
                {
                    strCostCenterStatus = "No";
                }
                else
                {
                    strCostCenterStatus = uctxtCostCentre.Text;
                }
                if (m_acction == 1)
                {
                    //Interaction.SaveSetting(Application.ExecutablePath, "AccLedger", "Ledger", uctxtLedgerName.Text);
                    RegistryKey rk = Registry.CurrentUser.CreateSubKey("SOFTWARE\\SmartAccounts");
                    rk.SetValue("Ledger", uctxtLedgerName.Text);
                    rk.Close();

                    strmsg = accms.mSaveLedger(strComID, uctxtLedgerName.Text, uctxtUnder.Text, uctxtFax.Text,
                                                        uctxtEMail.Text, uctxtAddress1.Text, "", uctxtCity.Text,
                                                        uctxtPostal.Text, uctxtPhone.Text, "", uctxtCurrency.Text, txtEffectInventory.Text,
                                                        strStatus, strCostCenterStatus, uctxtDrCr.Text,
                                                        dblOpnBalance, strCostcenter, strBranch,
                                                        dblPurchaseAmount,
                                                        dteEffectform.Text.ToString(), lngReducingBal,
                                                        dblAssetsLife,
                                                        dblDeprate,
                                                        dblAccumulatedDep,
                                                        dblwrittendownvalue,
                                                        dblSalvagevalue, lngAssetPercent,
                                                        strAssetsLedger, strAccBranch,uctxtPFAmount.Text);
                }
                else
                {
                    strmsg = accms.mUpdateLedger(strComID, mstrOldLedger, mlngSlNo, uctxtLedgerName.Text, uctxtUnder.Text, uctxtFax.Text,
                                                        uctxtEMail.Text, uctxtAddress1.Text, "", uctxtCity.Text,
                                                        uctxtPostal.Text, uctxtPhone.Text, "", uctxtCurrency.Text, txtEffectInventory.Text,
                                                        strStatus, strCostCenterStatus, uctxtDrCr.Text,
                                                        dblOpnBalance, strCostcenter, strBranch,
                                                        dblPurchaseAmount,
                                                        dteEffectform.Text.ToString(), lngReducingBal,
                                                        dblAssetsLife,
                                                        dblDeprate,
                                                        dblAccumulatedDep,
                                                        dblwrittendownvalue,
                                                        dblSalvagevalue, lngAssetPercent,
                                                        strAssetsLedger, strAccBranch, uctxtPFAmount.Text);
                }
                if (strmsg == "1")
                {
                    if (mSingleEntry == 1)
                    {
                        mSingleEntry = 0;
                        this.Dispose();
                    }
                    if (Utility.gblnAccessControl)
                    {
                        string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), uctxtLedgerName.Text, "Ledger Configuration",
                                                                m_acction, dblOpnBalance, (int)Utility.MODULE_TYPE.mtACCOUNT, "0001");
                    }
                }

                if (m_acction == 2)
                {

                    uctxtCurrency.Text = "BDT";
                    uctxtDrCr.Text = "Dr";
                    frmAccountsLedgerList objfrm = new frmAccountsLedgerList();
                    objfrm.mintLedgerGroup = 0;
                    objfrm.lngFormPriv = lngFormPriv;
                    objfrm.onAddAllButtonClicked = new frmAccountsLedgerList.AddAllClick(DisplayReqList);
                    objfrm.Show();
                    objfrm.MdiParent = this.MdiParent;
                    //uctxtLedgerName.Focus();
                }

                mClear();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnAssetApply_Click(object sender, EventArgs e)
        {

        }

        private void ucGridAssetBranch_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            calculateTotal();
        }

        private void ucGridAssetBranch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(char)Keys.Return)
            {
                btnApply.Focus();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            
            frmTreeView objfrm = new frmTreeView();
            objfrm.MdiParent = this.MdiParent;
            objfrm.Show();
            
        }

        private void dgBranch_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            calculateTotal();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            mClear();
            uctxtCurrency.Text = "BDT";
            uctxtDrCr.Text = "Dr";
            frmAccountsLedgerList objfrm = new frmAccountsLedgerList();
            objfrm.mintLedgerGroup = 0;
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.onAddAllButtonClicked = new frmAccountsLedgerList.AddAllClick(DisplayReqList);
            objfrm.Show();
            objfrm.MdiParent = this.MdiParent;
        }


        private void DisplayReqList(List<AccountsLedger> tests, object sender, EventArgs e)
        {
            try
            {

                List<AccountsLedger> ooled = accms.mDisplayLedgerList(strComID, tests[0].lngSlno).ToList();
                if (ooled.Count > 0)
                {

                    uctxtLedgerName.Focus();
                    uctxtLedgerName.Select();
                    txtAssetsLedger.ReadOnly = false;
                    mlngSlNo = tests[0].lngSlno;
                    m_acction = 2;
                    uctxtLedgerName.Text = ooled[0].strOldLedgerName;
                    mstrOldLedger = ooled[0].strOldLedgerName;
                    uctxtUnder.Text = ooled[0].strUder;
                    if (tests[0].intDefaultGroup == 1)
                    {
                        uctxtUnder.Enabled = false;
                    }
                    else
                    {
                        uctxtUnder.Enabled = true;
                    }
                    if (ooled[0].intCostCenter == 1)
                    {
                        uctxtCostCentre.Text = "No";
                    }
                    else if (ooled[0].intCostCenter == 2)
                    {
                        uctxtCostCentre.Text = "Yes";
                    }
                    uctxtCurrency.Text = ooled[0].strCurrency;
                    if (ooled[0].intInventoryEffect == 2)
                    {
                        txtEffectInventory.Text = "Yes";
                    }
                    else
                    {
                        txtEffectInventory.Text = "No";
                    }
                    uctxtOpeningBalance.Text = Math.Abs(ooled[0].dblOpnBalance).ToString();
                    uctxtPFAmount.Text = ooled[0].dblPFAmount.ToString();
                    mdblOpeningBalance = Utility.Val(ooled[0].dblOpnBalance.ToString());
                    if (Convert.ToDouble(ooled[0].dblOpnBalance) < 0)
                    {
                        uctxtDrCr.Text = "Dr";
                    }
                    else if (Convert.ToDouble(ooled[0].dblOpnBalance) > 0)
                    {
                        uctxtDrCr.Text = "Cr";
                    }

                    uctxtAddress1.Text = ooled[0].strAddress;
                    uctxtCity.Text = ooled[0].strCity;
                    uctxtPostal.Text = ooled[0].strPostalCode;
                    uctxtPhone.Text = ooled[0].strPhone;
                    uctxtEMail.Text = ooled[0].strFax;
                    uctxtFax.Text = ooled[0].strEmail;
                    if (ooled[0].intStatus == 1)
                    {
                        uctxtInactive.Text = "Yes";
                    }
                    else
                    {
                        uctxtInactive.Text = "No";
                    }

                    DgCostCenter.Rows.Clear();
                    dgBranch.Rows.Clear();
                    ucGridAssetBranch.Rows.Clear();
                    double dblVectorAmount = 0, dblBrancAmount = 0, dblAssetTotalBranch = 0;

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

                    //List<BranchConfig> obranch = accms.mDisplayBranchOpening(strComID, mstrOldLedger,"").ToList();
                    //{
                    //    if (obranch.Count > 0)
                    //    {
                    //        int i = 0;
                    //        foreach (BranchConfig ooBran in obranch)
                    //        {
                    //            dgBranch.Rows.Add();
                    //            dgBranch.Rows[i].Cells[0].Value = Utility.gstrGetBranchName(strComID, ooBran.BranchID);
                    //            dgBranch.Rows[i].Cells[1].Value = Math.Abs(ooBran.dblbranchOpening);
                    //            dblBrancAmount = dblBrancAmount + Math.Abs(ooBran.dblbranchOpening);
                    //            i += 1;
                    //        }
                    //        dgBranch.AllowUserToAddRows = false;
                    //        txtBranchTotal.Text = dblBrancAmount.ToString();

                    //    }
                    //}
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
                    List<FixedAssets> oFixed = accms.mDisplayFixedAssest(strComID, mstrOldLedger).ToList();
                    {
                        if (oFixed.Count > 0)
                        {
                            foreach (FixedAssets ooFixed in oFixed)
                            {
                                uctxtLedgerName.Text = mstrOldLedger;
                                txtAssetsLedger.Text = mstrOldLedger;

                                txtPurchaseAmount.Text = ooFixed.dblPurchaseAmount.ToString();
                                txtAssetsLife.Text = ooFixed.dblAssetsLife.ToString();
                                txtDepRate.Text = ooFixed.dblDepRate.ToString();
                                txtAccumulatedDep.Text = ooFixed.dblAccumulatedDep.ToString();
                                txtWittendownValue.Text = ooFixed.dblWrittendownValue.ToString();
                                txtSalvageValue.Text = ooFixed.dblSalvageValue.ToString();
                                dteEffectform.Text = ooFixed.strEffectiveDate;
                                cboDepMethod.Text = ooFixed.strDepMethod;
                            }


                        }

                        List<FixedAssets> ooFixedopn = accms.mDisplayFixedAssestOpening(strComID, mstrOldLedger).ToList();
                        {
                            if (ooFixedopn.Count > 0)
                            {
                                int i = 0;
                                foreach (FixedAssets ooFixed in ooFixedopn)
                                {
                                    ucGridAssetBranch.Rows.Add();
                                    ucGridAssetBranch.Rows[i].Cells[0].Value = Utility.gstrGetBranchName(strComID, ooFixed.strBranchID);
                                    ucGridAssetBranch.Rows[i].Cells[1].Value = Math.Abs(ooFixed.dblAccumulatedDep);
                                    dblAssetTotalBranch = dblAssetTotalBranch + Math.Abs(ooFixed.dblAccumulatedDep);
                                    i += 1;
                                }
                                ucGridAssetBranch.AllowUserToAddRows = false;
                                txtAssetsTotalBranch.Text = dblAssetTotalBranch.ToString();

                            }
                        }
                        List<FixedAssets> ooAccu = accms.mDisplayFixedAssestAccOpening(strComID, mstrOldLedger).ToList();
                        {
                            dblAssetTotalBranch = 0;
                            if (ooAccu.Count > 0)
                            {
                                int i = 0;
                                foreach (FixedAssets ooFixed in ooAccu)
                                {
                                    dgAccumulateBranch.Rows.Add();
                                    dgAccumulateBranch.Rows[i].Cells[0].Value = Utility.gstrGetBranchName(strComID, ooFixed.strBranchID);
                                    dgAccumulateBranch.Rows[i].Cells[1].Value = Math.Abs(ooFixed.dblAccumulatedDep);
                                    dblAssetTotalBranch = dblAssetTotalBranch + Math.Abs(ooFixed.dblAccumulatedDep);
                                    i += 1;
                                }
                                dgAccumulateBranch.AllowUserToAddRows = false;
                                txtTotalAccBranch.Text = dblAssetTotalBranch.ToString();

                            }
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

        private void btnNew1_Click(object sender, EventArgs e)
        {
            m_acction = 1;
        }

        private void dgBranch_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {
            calculateTotal();
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgBranch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==2)
            {
                dgBranch.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string strDiffenece = accms.mDisplayOpening(strComID);
            var results = strDiffenece.Split(new string[] { "~" }, StringSplitOptions.None);
            lblDebit.Text = results[0];
            lblCredit.Text = results[1];
            lblDifference.Text = results[2];
            uctxtLedgerName.Focus();
        }

        private void txtPurchaseAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                pnlAssets.Visible = true;
                pnlAssets.Top = txtPurchaseAmount.Top + 25;
                pnlAssets.Left = pnlAssets.Left+1;
                pnlAssets.Size = new Size(433, 179);
                ucGridAssetBranch.Size = new Size(423, 92);
                btnAssetApply.Top = ucGridAssetBranch.Height + 30;
                btnAssetApply.Left = 200;
                txtAssetBranchAmountPre.Text = txtPurchaseAmount.Text;
                uctxtBranchAssAmount.Text = txtPurchaseAmount.Text;
                uctxtAssetBranchName.Focus();
            }
        }

        private void ucGridAssetBranch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==2)
            {
                ucGridAssetBranch.Rows.RemoveAt(e.RowIndex);
            }
        }

  
        private void txtAccuBranchAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtAccuBranchAmount.Text != "" || txtAccuBranchAmount.Text != "0")
                {
                    mAdditemBillnew(txtAccBranch.Text, Convert.ToDouble(txtAccuBranchAmount.Text));
                    txtAccBranch.Focus();
                    lstAssetsBranch.Visible = false;
                    if (Utility.Val(txtAccuBranchAmount.Text) == 0)
                    {
                        PicAssetBranch.Visible = false;
                        txtWittendownValue.Focus();

                    }
                }
                else
                {
                    txtWittendownValue.Focus();
                }


            }
        }

        private void dgAccumulateBranch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex ==2)
            {
                dgAccumulateBranch.Rows.RemoveAt(e.RowIndex);
            }
        }


        #endregion

        private void uctxtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(char)Keys.Return)
            {
                uctxtEMail.Focus();
            }
        }

        private void uctxtFax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtInactive.Focus();
            }
        }

        private void uctxtEMail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtFax.Focus();
            }
        }

        




















    }
}
