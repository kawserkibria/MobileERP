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
using Microsoft.Win32;

namespace JA.Modulecontrolar.UI.Master.Accounts
{
    public partial class frmFixedAssets : JA.Shared.UI.frmJagoronFromSearch
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
        private ListBox lstAssetsLedger = new ListBox();
        private ListBox lstLedgerBranchAccumulated = new ListBox();
        private ListBox lstAssetsBranch = new ListBox();
        public long lngFormPriv { get; set; }
        public int m_action { get; set; }
        private long mlngSLNo {get;set;}
        private string  mstrOldLedger { get; set; }
        private string strComID { get; set; }
        public frmFixedAssets()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            #region "User Define In"
            this.txtAssetsLedger.KeyDown += new KeyEventHandler(txtAssetsLedger_KeyDown);
            this.txtAssetsLedger.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtAssetsLedger_KeyPress);
            this.txtAssetsLedger.TextChanged += new System.EventHandler(this.txtAssetsLedger_TextChanged);
            this.lstAssetsLedger.DoubleClick += new System.EventHandler(this.lstAssetsLedger_DoubleClick);
            this.txtAssetsLedger.GotFocus += new System.EventHandler(this.txtAssetsLedger_GotFocus);

            this.txtPurchaseAmount.GotFocus += new System.EventHandler(this.txtPurchaseAmount_GotFocus);
            this.cboDepMethod.GotFocus += new System.EventHandler(this.cboDepMethod_GotFocus);
            this.txtDepRate.GotFocus += new System.EventHandler(this.txtDepRate_GotFocus);
            this.txtDepRate.TextChanged += new System.EventHandler(this.txtDepRate_TextChanged);

            this.txtAssetsLife.GotFocus += new System.EventHandler(this.txtAssetsLife_GotFocus);
            this.dteEffectform.GotFocus += new System.EventHandler(this.dteEffectform_GotFocus);
            this.dteEffectform.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteEffectform_KeyPress);

            
            this.txtWittendownValue.GotFocus += new System.EventHandler(this.txtWittendownValue_GotFocus);
            this.txtSalvageValue.GotFocus += new System.EventHandler(this.txtSalvageValue_GotFocus);
          
            this.txtPurchaseAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtPurchaseAmount_KeyPress);

            this.txtWittendownValue.TextChanged += new System.EventHandler(this.txtWittendownValue_TextChanged);
            this.txtAccumulatedDep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtAccumulatedDep_KeyPress);
            this.txtAccumulatedDep.GotFocus += new System.EventHandler(this.txtAccumulatedDep_GotFocus);
            this.txtAccumulatedDep.TextChanged += new System.EventHandler(this.txtAccumulatedDep_TextChanged);
            
            this.txtSalvageValue.TextChanged += new System.EventHandler(this.txtSalvageValue_TextChanged);
            this.txtPurchaseAmount.TextChanged += new System.EventHandler(this.txtPurchaseAmount_TextChanged);

            this.txtAccBranch.GotFocus += new System.EventHandler(this.txtAccBrancht_GotFocus);
            this.txtAccBranch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtAccBranch_KeyPress);
            this.txtAccBranch.TextChanged += new System.EventHandler(this.txtAccBranch_TextChanged);
            this.txtAccBranch.KeyDown += new KeyEventHandler(txtAccBranch_KeyDown);
            this.lstLedgerBranchAccumulated.DoubleClick += new System.EventHandler(this.lstLedgerBranchAccumulated_DoubleClick);

            this.dgAccumulateBranch.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgAccumulateBranch_CellContentClick);
            this.txtAccuBranchAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAccuBranchAmount_KeyPress);
            
            this.uctxtAssetBranchName.KeyDown += new KeyEventHandler(uctxtAssetBranchName_KeyDown);
            this.uctxtAssetBranchName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtAssetBranchName_KeyPress);
            this.uctxtAssetBranchName.TextChanged += new System.EventHandler(this.uctxtAssetBranchName_TextChanged);
            this.lstAssetsBranch.DoubleClick += new System.EventHandler(this.lstAssetsBranch_DoubleClick);
            this.uctxtAssetBranchName.GotFocus += new System.EventHandler(this.uctxtAssetBranchName_GotFocus);

            this.uctxtBranchAssAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranchAssAmount_KeyPress);
            this.btnAdjustment.Click += new System.EventHandler(this.btnAdjustment_Click);
            Utility.CreateListBox(lstAssetsLedger, pnlFixedAssets, txtAssetsLedger);
            Utility.CreateListBox(lstLedgerBranchAccumulated, PicAssetBranch, txtAccBranch, 0);
            Utility.CreateListBox(lstAssetsBranch, pnlAssets, uctxtAssetBranchName, 100);
            TabChange();
            #endregion
        }
        #region "User Define"
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

        private void uctxtBranchAssAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtBranchAssAmount.Text != "" || uctxtBranchAssAmount.Text != "0")
                {
                    mAdditemBill(uctxtAssetBranchName.Text, Convert.ToDouble(uctxtBranchAssAmount.Text));
                    uctxtAssetBranchName.Focus();
                    lstAssetsBranch.Visible = false;
                    if (Utility.Val(uctxtBranchAssAmount.Text) == 0)
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
        private void uctxtAssetBranchName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                if (lstAssetsBranch.Items.Count > 0)
                {
                    uctxtAssetBranchName.Text = lstAssetsBranch.Text;
                }
                lstAssetsBranch.Visible = false;
                uctxtBranchAssAmount.Focus();


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
            //lstCostCenter.Visible = false;
            //lsteffectInventory.Visible = false;
            //lstUnder.Visible = false;
            //lstInactive.Visible = false;
            //lstcurrency.Visible = false;
            //lstBranchName.Visible = false;
            //lstCostCenterNew.Visible = false;
            //lstCostCategory.Visible = false;

        }
        private void dgAccumulateBranch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                dgAccumulateBranch.Rows.RemoveAt(e.RowIndex);
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
                    lstLedgerBranchAccumulated.Visible = false;
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
            //lstAssetsBranch.Visible = false;
            //lstCostCenter.Visible = false;
            //lsteffectInventory.Visible = false;
            //lstUnder.Visible = false;
            //lstInactive.Visible = false;
            //lstcurrency.Visible = false;
            //lstBranchName.Visible = false;
            //lstCostCenterNew.Visible = false;
            //lstCostCategory.Visible = false;

        }

        private void txtWittendownValue_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumericNew(txtWittendownValue.Text) == false)
            {
                txtWittendownValue.Text = "";
            }
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
        private void mAdditemBill(string strBranchName, double dblOpnAmount)
        {
            int selRaw;
            bool blngCheck = false;
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
                if (selRaw == -1)
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
        private void txtAccumulatedDep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtWittendownValue.Text = (Utility.Val(txtPurchaseAmount.Text) - Utility.Val(txtAccumulatedDep.Text)).ToString();
                if (Utility.Val(txtAccumulatedDep.Text.ToString()) > 0)
                {
                    PicAssetBranch.Visible = true;
                    PicAssetBranch.Top = txtAssetsLedger.Top + 5;
                    PicAssetBranch.Left = pnlFixedAssets.Left + 1;
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
        private void txtPurchaseAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                pnlAssets.Visible = true;
                pnlAssets.Top = txtPurchaseAmount.Top + 25;
                pnlAssets.Left = pnlAssets.Left + 1;
                pnlAssets.Size = new Size(433, 179);
                ucGridAssetBranch.Size = new Size(423, 92);
                btnAssetApply.Top = ucGridAssetBranch.Height + 30;
                btnAssetApply.Left = 200;
                txtAssetBranchAmountPre.Text = txtPurchaseAmount.Text;
                uctxtBranchAssAmount.Text = txtPurchaseAmount.Text;
                uctxtAssetBranchName.Focus();
            }
        }
        private void txtSalvageValue_GotFocus(object sender, System.EventArgs e)
        {
            lstAssetsLedger.Visible = false;

        }
        private void dteEffectform_GotFocus(object sender, System.EventArgs e)
        {
            lstAssetsLedger.Visible = false;

        }
        private void txtAccumulatedDep_GotFocus(object sender, System.EventArgs e)
        {
            lstAssetsLedger.Visible = false;

        }
        private void txtWittendownValue_GotFocus(object sender, System.EventArgs e)
        {
            lstAssetsLedger.Visible = false;

        }
        private void cboDepMethod_GotFocus(object sender, System.EventArgs e)
        {
            lstAssetsLedger.Visible = false;

        }
        private void txtDepRate_GotFocus(object sender, System.EventArgs e)
        {
            lstAssetsLedger.Visible = false;

        }
        private void txtAssetsLife_GotFocus(object sender, System.EventArgs e)
        {
            lstAssetsLedger.Visible = false;

        }
        private void txtPurchaseAmount_GotFocus(object sender, System.EventArgs e)
        {
            lstAssetsLedger.Visible = false;
          
        }
        private void txtAssetsLedger_TextChanged(object sender, EventArgs e)
        {
            lstAssetsLedger.SelectedIndex = lstAssetsLedger.FindString(txtAssetsLedger.Text);
        }

        private void lstAssetsLedger_DoubleClick(object sender, EventArgs e)
        {
            txtAssetsLedger.Text = lstAssetsLedger.Text;
            mGetDisplay(txtAssetsLedger.Text);
            txtPurchaseAmount.Focus();
        }
        private void mGetDisplay(string strLedgerName)
        {
            double dblAssetTotalBranch=0;
            List<FixedAssets> oFixed = accms.mDisplayFixedAssest(strComID, strLedgerName).ToList();
            {
                if (oFixed.Count > 0)
                {
                    foreach (FixedAssets ooFixed in oFixed)
                    {
                        
                        txtAssetsLedger.Text = strLedgerName;
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
                List<FixedAssets> ooFixedopn = accms.mDisplayFixedAssestOpening(strComID, strLedgerName).ToList();
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
                List<FixedAssets> ooAccu = accms.mDisplayFixedAssestAccOpening(strComID, strLedgerName).ToList();
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

                //mloadBrach();
                //List<FixedAssets> oofxtBranch = accms.mDisplayFixedBranchList(strComID, strLedgerName).ToList();
                //{
                //    if (oofxtBranch.Count > 0)
                //    {
                //        int i = 0;
                //        foreach (FixedAssets ofxd in oofxtBranch)
                //        {
                //            if (ucGridAssetBranch.Rows[i].Cells[0].Value.ToString() == Utility.gstrGetBranchName(strComID, ofxd.strBranchID))
                //            {
                //                ucGridAssetBranch.Rows[i].Cells[1].Value = 0;
                //                ucGridAssetBranch.Rows[i].Cells[1].Value = ofxd.dblPurchaseAmount;
                //            }
                //            else
                //            {
                //                ucGridAssetBranch.Rows[i].Cells[1].Value = 0;
                //            }
                //            i += 1;
                //        }
                //        ucGridAssetBranch.AllowUserToAddRows = false;
                //        calculateTotal();

                //    }
                //}
            }

        }
        private void txtAssetsLedger_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstAssetsLedger.Items.Count > 0)
                {
                    txtAssetsLedger.Text = lstAssetsLedger.Text;
                }
                mGetDisplay(txtAssetsLedger.Text);
                txtPurchaseAmount.Focus();

            }
        }
        private void txtAssetsLedger_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstAssetsLedger.SelectedItem != null)
                {
                    lstAssetsLedger.SelectedIndex = lstAssetsLedger.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstAssetsLedger.Items.Count - 1 > lstAssetsLedger.SelectedIndex)
                {
                    lstAssetsLedger.SelectedIndex = lstAssetsLedger.SelectedIndex + 1;
                }
            }

        }

        private void txtAssetsLedger_GotFocus(object sender, System.EventArgs e)
        {
            lstAssetsLedger.Visible = true;
            //lstAssetsLedger = Sales.gFillSalesLedger(lstAssetsLedger);
            lstAssetsLedger.SelectedIndex = lstAssetsLedger.FindString(txtAssetsLedger.Text);
           
        }
        #endregion
        #region "Tab change
        private void TabChange()
        {
            txtAssetsLedger.Focus();

           

            txtAssetsLedger.AllToNextTab(txtPurchaseAmount);
            txtPurchaseAmount.AllToNextTab(cboDepMethod);
            cboDepMethod.AllToNextTab(txtDepRate);
            txtDepRate.AllToNextTab(txtAssetsLife);
            txtAssetsLife.AllToNextTab(dteEffectform);
            dteEffectform.AllToNextTab(txtAccumulatedDep);
            txtAccumulatedDep.AllToNextTab(txtWittendownValue);
            txtWittendownValue.AllToNextTab(txtSalvageValue);
            txtSalvageValue.AllToNextTab(btnSave);




        }
        #endregion
        #region "Load Branch"
        //private void mloadBrach()
        //{
        //    int introw = 0;
        //    ucGridAssetBranch.Rows.Clear();
        //    List<BranchConfig> ooBranch = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
        //    if (ooBranch.Count > 0)
        //    {
        //        foreach (BranchConfig ob in ooBranch)
        //        {
        //            ucGridAssetBranch.Rows.Add();
        //            ucGridAssetBranch[0, introw].Value = ob.BranchName;
        //            introw += 1;
        //        }
        //        ucGridAssetBranch.AllowUserToAddRows = false;
        //        // ucGridAssetBranch.AllowUserToAddRows = false;
        //    }
        //}
        #endregion
        #region "Calculatetotal
        private void calculateTotal()
        {
            double dblAssetsTotal = 0, dblAccuTotal = 0;
          
            for (int i = 0; i < ucGridAssetBranch.Rows.Count; i++)
            {
                dblAssetsTotal = dblAssetsTotal + Convert.ToDouble(ucGridAssetBranch.Rows[i].Cells[1].Value);
            }
            for (int i = 0; i < dgAccumulateBranch.Rows.Count; i++)
            {
                dblAccuTotal = dblAccuTotal + Convert.ToDouble(dgAccumulateBranch.Rows[i].Cells[1].Value);
            }
            txtAssetsTotalBranch.Text = dblAssetsTotal.ToString();
            txtTotalAccBranch.Text = dblAccuTotal.ToString();
        }
        #endregion
        #region "Load"
        private void frmFixedAssets_Load(object sender, EventArgs e)
        {
            ucGridAssetBranch.AllowUserToAddRows = false;
            lstAssetsLedger.Visible = false;
            lstLedgerBranchAccumulated.Visible = false;
            lstAssetsBranch.Visible = false;
            lstAssetsLedger.ValueMember = "LedgerName";
            lstAssetsLedger.DisplayMember = "LedgerName";
            lstAssetsLedger.DataSource = basSales.gFillSalesLedger(strComID, (long)Utility.GR_GROUP_TYPE.grFIXED_ASSET);

            lstAssetsBranch.ValueMember = "BranchID";
            lstAssetsBranch.DisplayMember = "BranchName";
            lstAssetsBranch.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();

            lstLedgerBranchAccumulated.ValueMember = "BranchID";
            lstLedgerBranchAccumulated.DisplayMember = "BranchName";
            lstLedgerBranchAccumulated.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();

            //if (Utility.gblnBranch)
            //{
            //    mloadBrach();
            //}
          
        }
        #endregion
        #region "Click"
        private void btnAssetApply_Click(object sender, EventArgs e)
        {
            if (txtAssetBranchAmountPre.Text != txtAssetsTotalBranch.Text)
            {
                if (txtAssetBranchAmountPre.Text != "")
                {
                    MessageBox.Show("Amount Mismatch");
                    ucGridAssetBranch.Focus();
                    return;
                }
            }
            pnlAssets.Visible = false;
            cboDepMethod.Focus();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            mClear();

        }

        private void btnAdjustment_Click(object sender, EventArgs e)
        {
            //frmDepreciationAdjustment objfrm = new frmDepreciationAdjustment();
            //objfrm.MdiParent = MdiParent;
            //objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            //objfrm.Show();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            mClear();
            pnlAssets.Visible = false;
            frmFixedAssetsList objfrm = new frmFixedAssetsList();
            objfrm.onAddAllButtonClicked = new frmFixedAssetsList.AddAllClick(DisplayReqList);
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.Show();
            objfrm.MdiParent = MdiParent;
        }
        private void ucGridAssetBranch_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            calculateTotal();
         
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strAssetsLedger = "",strDGAccuBrancg="";
            long lngAssetPercent = 0, lngReducingBal = 0;
            double dblPurchaseAmount = 0, dblAssetsLife = 0,
                dblDeprate = 0, dblAccumulatedDep = 0, dblwrittendownvalue = 0, dblSalvagevalue = 0;

            
            if (cboDepMethod.Text == "Reducing Balance")
             {
                 lngReducingBal = 1;
             }
             else if (cboDepMethod.Text == "Straight Line")
             {
                 if  (Convert.ToInt16 (txtDepRate.Text) > 0)
                 {
                      lngAssetPercent = 1;
                 }
                     lngReducingBal = 2;
             }
             else
             {
                 lngReducingBal = 0;
             }


            for (int i = 0; i < ucGridAssetBranch.Rows.Count; i++)
            {
                if (ucGridAssetBranch[0, i].Value != null)
                {
                    if (ucGridAssetBranch[1, i].Value==null)
                    {
                        ucGridAssetBranch[1, i].Value = 0;
                    }

                    strAssetsLedger += ucGridAssetBranch[0, i].Value.ToString() + "," + ucGridAssetBranch[1, i].Value.ToString() + "~";
                }
            }
            for (int i = 0; i < dgAccumulateBranch.Rows.Count; i++)
            {
                if (dgAccumulateBranch[0, i].Value != null)
                {
                    if (dgAccumulateBranch[1, i].Value == null)
                    {
                        dgAccumulateBranch[1, i].Value = 0;
                    }

                    strDGAccuBrancg += dgAccumulateBranch[0, i].Value.ToString() + "," + dgAccumulateBranch[1, i].Value.ToString() + "~";
                }
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
            if (m_action == (int)Utility.ACTION_MODE_ENUM.ADD_MODE)
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 1))
                    {
                         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                        return;
                    }
                }
                var strResponseInsert = MessageBox.Show("Do You Want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        string strmsg = accms.mSaveFixedAssets(strComID, txtAssetsLedger.Text, dblPurchaseAmount, dteEffectform.Text, lngReducingBal, dblAssetsLife,
                                                                dblDeprate, dblAccumulatedDep, dblwrittendownvalue, dblSalvagevalue, lngAssetPercent, strAssetsLedger, strDGAccuBrancg);

                        if (strmsg == "Inserted...")
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Fixed Assets", txtAssetsLedger.Text,
                                                                        1, dblPurchaseAmount, (int)Utility.MODULE_TYPE.mtACCOUNT, "0001");
                            }
                            
                            mClear();
                        }
                        else
                        {
                            MessageBox.Show(strmsg);
                        }
                        //mloadBrach();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            else
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 2))
                    {
                         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                        return;
                    }
                }
                var strResponseInsert = MessageBox.Show("Do You Want to Update?", "Update Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        string strmsg = accms.mUpdateFixedAssets(strComID, mlngSLNo, mstrOldLedger, txtAssetsLedger.Text, dblPurchaseAmount, dteEffectform.Text, lngReducingBal, dblAssetsLife,
                                                                dblDeprate, dblAccumulatedDep, dblwrittendownvalue, dblSalvagevalue, lngAssetPercent, strAssetsLedger, strDGAccuBrancg);
                        if (strmsg == "Updated...")
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Fixed Assets", txtAssetsLedger.Text,
                                                                        2, dblPurchaseAmount, (int)Utility.MODULE_TYPE.mtACCOUNT, "0001");
                            }

                         
                            mClear();
                        }
                        else
                        {
                            MessageBox.Show(strmsg);
                        }
                        //mloadBrach();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }


        }
        #endregion
        #region "Clear"
        private void mClear()
        {
           
            txtAssetsLedger.Text = "";
            txtPurchaseAmount.Text = "";
            txtAssetsLife.Text = "";
            txtDepRate.Text = "";
            txtWittendownValue.Text = "";
            txtSalvageValue.Text = "";
            ucGridAssetBranch.Rows.Clear();
            m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            txtAssetsLedger.Focus();

        }
        #endregion
        #region "DisplayReqList"
        private void DisplayReqList(List<FixedAssets> tests, object sender, EventArgs e)
        {
            try
            {
                double dblAssetTotalBranch = 0;
                
                List<FixedAssets> oofxt = accms.mDisplayAssetList(strComID, tests[0].lngSerialNo).ToList();
                foreach (FixedAssets ts in oofxt)
                {
                    m_action = (int)Utility.ACTION_MODE_ENUM.EDIT_MODE;
                    mlngSLNo = tests[0].lngSerialNo;
                    txtAssetsLedger.Text =ts.strLedgerName;
                    mstrOldLedger = ts.strLedgerName;
                    txtPurchaseAmount.Text = ts.dblPurchaseAmount.ToString();
                    dteEffectform.Text = ts.strEffectiveDate;
                    cboDepMethod.Text =ts.strDepMethod;
                    txtAssetsLife.Text =ts.dblAssetsLife.ToString();
                    txtDepRate.Text = ts.dblDepRate.ToString();
                    txtAccumulatedDep.Text = ts.dblAccumulatedDep.ToString() ;
                    txtWittendownValue.Text = ts.dblWrittendownValue.ToString();
                    txtSalvageValue.Text = ts.dblSalvageValue.ToString();
                    cboDepMethod.Text = ts.strDepMethod;
                    //mloadBrach();
                    //List<FixedAssets> oofxtBranch = accms.mDisplayFixedBranchList(strComID, ts.strLedgerName).ToList();
                    //{
                    //    if (oofxtBranch.Count>0)
                    //    { 
                    //        int i=0;
                    //        foreach (FixedAssets ofxd in oofxtBranch)
                    //        {
                    //            if (ucGridAssetBranch.Rows[i].Cells[0].Value.ToString() == Utility.gstrGetBranchName(strComID, ofxd.strBranchID))
                    //            {
                    //                ucGridAssetBranch.Rows[i].Cells[1].Value = 0;
                    //                ucGridAssetBranch.Rows[i].Cells[1].Value = ofxd.dblPurchaseAmount;
                    //            }
                    //            else
                    //            {
                    //                ucGridAssetBranch.Rows[i].Cells[1].Value = 0;
                    //            }
                    //            i += 1;
                    //        }
                    //        ucGridAssetBranch.AllowUserToAddRows = false;
                    //        calculateTotal();

                    //    }
                    //}

                    List<FixedAssets> ooFixedopn = accms.mDisplayFixedAssestOpening(strComID, ts.strLedgerName).ToList();
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
                    List<FixedAssets> ooAccu = accms.mDisplayFixedAssestAccOpening(strComID, ts.strLedgerName).ToList();
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


                    txtAssetsLedger.Focus();
                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        #endregion
        #region "Keydown"
        private void ucGridAssetBranch_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            int iColumn = ucGridAssetBranch.CurrentCell.ColumnIndex;
            int iRow = ucGridAssetBranch.CurrentCell.RowIndex;
            if (iColumn == ucGridAssetBranch.ColumnCount - 1)
            {
                if (ucGridAssetBranch.RowCount > (iRow + 1))
                {
                    ucGridAssetBranch.CurrentCell = ucGridAssetBranch[1, iRow + 1];
                }
                else
                {
                    btnAssetApply.Focus();
                }
            }
            else
                ucGridAssetBranch.CurrentCell = ucGridAssetBranch[iColumn + 1, iRow];
        }

        #endregion
        private void mAdditemBillnew(string strBranchName, double dblOpnAmount)
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
                if (selRaw == -1)
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

        private void btnAdjustment_Click_1(object sender, EventArgs e)
        {

        }

       


    }
}
