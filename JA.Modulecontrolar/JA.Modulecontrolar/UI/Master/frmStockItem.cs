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
using JA.Modulecontrolar.UI.Sales.Forms;
using Microsoft.Win32;
using Microsoft.VisualBasic;


namespace JA.Modulecontrolar.UI.Master
{
    public partial class frmStockItem : JA.Shared.UI.frmSmartFormStandard
    {
        private ListBox lstStockUnder = new ListBox();
        private ListBox lstStockCategory = new ListBox();
        private ListBox lstStockUnit = new ListBox();
        private ListBox lstAltUnit = new ListBox();
        private ListBox lstManufacturer = new ListBox();
        private ListBox lstStatus = new ListBox();
        private ListBox lstLocation = new ListBox();
        //private ListBox lstBatch = new ListBox();
        private ListBox lstMaterialType = new ListBox();
        private ListBox lstItemBatch = new ListBox();
        private string mstrOldItem { get; set; }
        public long lngFormPriv { get; set; }
        public string strFormName { get; set; }
        private string mstrOldAlias { get; set; }
        public int m_action { get; set; }
        public int mSingleEntry { get; set; }
        private string strComID { get; set; }
        JACCMS.SWJAGClient accms = new SWJAGClient();
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public frmStockItem()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.uctxtItemName.GotFocus += new System.EventHandler(this.uctxtItemName_GotFocus);
            this.uctxtItemName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtItemName_KeyPress);
            this.uctxtItemName.TextChanged += new System.EventHandler(this.uctxtItemName_TextChanged);
            this.uctxtItemName.KeyDown += new KeyEventHandler(uctxtItemName_KeyDown);

            this.uctxtItemCode.GotFocus += new System.EventHandler(this.uctxtItemCode_GotFocus);
            this.uctxtItemCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtItemCode_KeyPress);

            this.uctxtItemDescription.GotFocus += new System.EventHandler(this.uctxtItemDescription_GotFocus);
            this.uctxtItemDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtItemDescription_KeyPress);
            this.uctxtItemDescription.TextChanged += new System.EventHandler(this.uctxtItemDescription_TextChanged);

            this.cboBatchYesNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(cboBatchYesNo_KeyPress);
            this.cboBatchYesNo.GotFocus += new System.EventHandler(this.cboBatchYesNo_GotFocus);

            this.uctxtPowerClass.GotFocus += new System.EventHandler(this.uctxtPowerClass_GotFocus);
            this.uctxtPowerClass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtPowerClass_KeyPress);
            this.uctxtPowerClass.TextChanged += new System.EventHandler(this.uctxtPowerClass_TextChanged);

            this.uctxtMinumunStock.GotFocus += new System.EventHandler(this.uctxtMinumunStock_GotFocus);
            this.uctxtMinumunStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtMinumunStock_KeyPress);
            this.uctxtMinumunStock.TextChanged += new System.EventHandler(this.uctxtMinumunStock_TextChanged);

            this.uctxtReorderQnty.GotFocus += new System.EventHandler(this.uctxtReorderQnty_GotFocus);
            this.uctxtReorderQnty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtReorderQnty_KeyPress);
            this.uctxtReorderQnty.TextChanged += new System.EventHandler(this.uctxtReorderQnty_TextChanged);


            this.uctxtOpnQty.GotFocus += new System.EventHandler(this.uctxtOpnQty_GotFocus);
            this.uctxtOpnQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtOpnQty_KeyPress);
            this.uctxtOpnQty.TextChanged += new System.EventHandler(this.uctxtOpnQty_TextChanged);

            this.uctxtOpnRate.GotFocus += new System.EventHandler(this.uctxtOpnRate_GotFocus);
            this.uctxtOpnRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtOpnRate_KeyPress);
            this.uctxtOpnRate.TextChanged += new System.EventHandler(this.uctxtOpnRate_TextChanged);

            this.uctxtopnValue.GotFocus += new System.EventHandler(this.uctxtopnValue_GotFocus);
            this.uctxtopnValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtopnValue_KeyPress);
            this.uctxtopnValue.TextChanged += new System.EventHandler(this.uctxtopnValue_TextChanged);

            this.uctxtWhere.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtWhere_KeyPress);
            this.uctxtWhereUnit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxttoUnit_KeyPress);
            this.uctxtWhere.GotFocus += new System.EventHandler(this.uctxtWhere_GotFocus);
            this.uctxtWhereUnit.GotFocus += new System.EventHandler(this.uctxttoUnit_GotFocus);
            this.uctxtStockUnder.KeyDown += new KeyEventHandler(uctxtStockUnder_KeyDown);
            this.uctxtStockUnder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtStockUnder_KeyPress);
            this.uctxtStockUnder.TextChanged += new System.EventHandler(this.uctxtStockUnder_TextChanged);
            this.lstStockUnder.DoubleClick += new System.EventHandler(this.lstStockUnder_DoubleClick);
            this.uctxtStockUnder.GotFocus += new System.EventHandler(this.uctxtStockUnder_GotFocus);
            this.uctxtStockCategory.KeyDown += new KeyEventHandler(uctxtStockCategory_KeyDown);
            this.uctxtStockCategory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtStockCategory_KeyPress);
            this.uctxtStockCategory.TextChanged += new System.EventHandler(this.uctxtStockCategory_TextChanged);
            this.lstStockCategory.DoubleClick += new System.EventHandler(this.lstStockCategory_DoubleClick);
            this.uctxtStockCategory.GotFocus += new System.EventHandler(this.uctxtStockCategory_GotFocus);

            this.uctxtUnit.KeyDown += new KeyEventHandler(uctxtUnit_KeyDown);
            this.uctxtUnit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtUnit_KeyPress);
            this.uctxtUnit.TextChanged += new System.EventHandler(this.uctxtUnit_TextChanged);
            this.lstStockUnit.DoubleClick += new System.EventHandler(this.lstStockUnit_DoubleClick);
            this.uctxtUnit.GotFocus += new System.EventHandler(this.uctxtUnit_GotFocus);


            this.uctxtAltUnit.KeyDown += new KeyEventHandler(uctxtAltUnit_KeyDown);
            this.uctxtAltUnit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtAltUnit_KeyPress);
            this.uctxtAltUnit.TextChanged += new System.EventHandler(this.uctxtAltUnit_TextChanged);
            this.lstAltUnit.DoubleClick += new System.EventHandler(this.lstAltUnit_DoubleClick);
            this.uctxtAltUnit.GotFocus += new System.EventHandler(this.uctxtAltUnit_GotFocus);

            this.uctxtManufacturer.KeyDown += new KeyEventHandler(uctxtManufacturer_KeyDown);
            this.uctxtManufacturer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtManufacturer_KeyPress);
            this.uctxtManufacturer.TextChanged += new System.EventHandler(this.uctxtManufacturer_TextChanged);
            this.lstStockUnit.DoubleClick += new System.EventHandler(this.lstStockUnit_DoubleClick);
            this.uctxtManufacturer.GotFocus += new System.EventHandler(this.uctxtManufacturer_GotFocus);

            this.uctxtStatus.KeyDown += new KeyEventHandler(uctxtStatus_KeyDown);
            this.uctxtStatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtStatus_KeyPress);
            this.uctxtStatus.TextChanged += new System.EventHandler(this.uctxtStatus_TextChanged);
            this.lstStatus.DoubleClick += new System.EventHandler(this.lstStatus_DoubleClick);
            this.uctxtStatus.GotFocus += new System.EventHandler(this.uctxtStatus_GotFocus);

            this.uctxtBranchName.KeyDown += new KeyEventHandler(uctxtBranchName_KeyDown);
            this.uctxtBranchName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranchName_KeyPress);
            this.uctxtBranchName.TextChanged += new System.EventHandler(this.uctxtBranchName_TextChanged);
            this.lstLocation.DoubleClick += new System.EventHandler(this.lstLocation_DoubleClick);
            this.uctxtBranchName.GotFocus += new System.EventHandler(this.uctxtBranchName_GotFocus);

           
            this.uctxtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtQty_KeyPress);
            this.uctxtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtRate_KeyPress);
            this.uctxtStatus.GotFocus += new System.EventHandler(this.uctxtRate_GotFocus);

            this.uctxtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtAmount_KeyPress);
            this.uctxtAmount.GotFocus += new System.EventHandler(this.uctxtAmount_GotFocus);

            this.uctxtBatchNo.KeyDown += new KeyEventHandler(uctxtBatchNo_KeyDown);
            this.uctxtBatchNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBatchNo_KeyPress);
            this.uctxtBatchNo.TextChanged += new System.EventHandler(this.uctxtBatchNo_TextChanged);
            this.lstBatch.DoubleClick += new System.EventHandler(this.lstBatch_DoubleClick);
            this.uctxtBatchNo.GotFocus += new System.EventHandler(this.uctxtBatchNo_GotFocus);

            this.uctxtMaterialType.KeyDown += new KeyEventHandler(uctxtMaterialType_KeyDown);
            this.uctxtMaterialType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtMaterialType_KeyPress);
            this.uctxtMaterialType.TextChanged += new System.EventHandler(this.uctxtMaterialType_TextChanged);
            this.lstMaterialType.DoubleClick += new System.EventHandler(this.lstMaterialType_DoubleClick);
            this.uctxtMaterialType.GotFocus += new System.EventHandler(this.uctxtMaterialType_GotFocus);

            this.uctxtBatch.KeyDown += new KeyEventHandler(uctxtBatch_KeyDown);
            this.uctxtBatch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBatch_KeyPress);
            this.uctxtBatch.TextChanged += new System.EventHandler(this.uctxtBatch_TextChanged);
            this.lstItemBatch.DoubleClick += new System.EventHandler(this.lstItemBatch_DoubleClick);

            
            this.uctxtBatch.GotFocus += new System.EventHandler(this.uctxtBatch_GotFocus);


            Utility.CreateListBox(lstStockUnder, pnlMain, uctxtStockUnder);
            Utility.CreateListBox(lstStockCategory, pnlMain, uctxtStockCategory);
            Utility.CreateListBox(lstStockUnit, pnlMain, uctxtUnit);
            Utility.CreateListBox(lstManufacturer, pnlMain, uctxtManufacturer);
            Utility.CreateListBox(lstAltUnit, PanelAltUnit, textBox1);
            Utility.CreateListBox(lstStatus, pnlMain, uctxtStatus);
            Utility.CreateListBox(lstLocation, pnlBillWise, uctxtBranchName);
            //Utility.CreateListBox(lstBatch, panel3, uctxtBatch);
            lstBatch.Location = new Point(618, 419);
            lstBatch.Size = new Size(202, 132);
            Utility.CreateListBox(lstMaterialType, pnlMain, uctxtMaterialType);
            Utility.CreateListBox(lstItemBatch, pnlBillWise, uctxtBatchNo);
            //TabChange();
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
        #region "Tab change
        private void uctxtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R && e.Modifiers == Keys.Control)
            {
                //uctxtItemName.AppendText(Interaction.GetSetting(Application.ExecutablePath, "StockItem", "ItemName"));
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
                uctxtItemName.AppendText((String)rk.GetValue("ItemName", ""));
                rk.Close();
            }

        }
        private void uctxtPowerClass_TextChanged(object sender, EventArgs e)
        {
            int x = uctxtPowerClass.SelectionStart;
            uctxtPowerClass.Text = Utility.gmakeProperCase(uctxtPowerClass.Text);
            uctxtPowerClass.SelectionStart = x;
        }
        private void uctxtItemName_TextChanged(object sender, EventArgs e)
        {
            int x = uctxtItemName.SelectionStart;
            uctxtItemName.Text = Utility.gmakeProperCase(uctxtItemName.Text);
            uctxtItemName.SelectionStart = x;
           
        }
        private void uctxtItemDescription_TextChanged(object sender, EventArgs e)
        {
            int x = uctxtItemDescription.SelectionStart;
            uctxtItemDescription.Text = Utility.gmakeProperCase(uctxtItemDescription.Text);
            uctxtItemDescription.SelectionStart = x;
        }
        private void uctxtMaterialType_TextChanged(object sender, EventArgs e)
        {
            lstMaterialType.SelectedIndex = lstMaterialType.FindString(uctxtMaterialType.Text);
        }

        private void lstMaterialType_DoubleClick(object sender, EventArgs e)
        {
            uctxtMaterialType.Text = lstMaterialType.Text;
            uctxtUnit.Focus();
        }

        private void uctxtMaterialType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtMaterialType.Text != "")
                {
                    if (lstMaterialType.Items.Count > 0)
                    {
                        uctxtMaterialType.Text = lstMaterialType.Text;
                    }
                }
                uctxtUnit.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtMaterialType, sender, e);
            }
        }
        private void uctxtMaterialType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstMaterialType.SelectedItem != null)
                {
                    lstMaterialType.SelectedIndex = lstMaterialType.SelectedIndex - 1;
                    uctxtMaterialType.Text = lstMaterialType.Text;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstMaterialType.Items.Count - 1 > lstMaterialType.SelectedIndex)
                {
                    lstMaterialType.SelectedIndex = lstMaterialType.SelectedIndex + 1;
                    uctxtMaterialType.Text = lstMaterialType.Text;
                }
            }
            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {
             
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 59))
                    {
                        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                if (System.Windows.Forms.Application.OpenForms["frmMaterialType"] as frmMaterialType == null)
                {
                    frmMaterialType objfrm = new frmMaterialType();
                    objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                    objfrm.lngFormPriv = 59;
                    objfrm.strFormName = "Material Type";
                    objfrm.mSingleEntry = 1;
                    objfrm.Show();
                    objfrm.MdiParent = this.MdiParent;

                }
                else
                {
                    frmMaterialType objfrm = (frmMaterialType)Application.OpenForms["frmMaterialType"];
                    objfrm.strFormName = "Material Type";
                    objfrm.lngFormPriv = 59;
                    objfrm.Focus();
                    objfrm.MdiParent = this.MdiParent;
                }

            }

        }

        private void uctxtMaterialType_GotFocus(object sender, System.EventArgs e)
        {
            lstStockUnder.Visible = false;
            lstStockCategory.Visible = false;
            lstStockUnit.Visible = false;
            lstAltUnit.Visible = false;
            lstManufacturer.Visible = false;
            lstStatus.Visible = false;
            lstBatch.Visible = false;
            lstLocation.Visible = false;
            lstMaterialType.Visible = true;

            lstMaterialType.ValueMember = "strMaterialType";
            lstMaterialType.DisplayMember = "strMaterialType";
            lstMaterialType.DataSource = invms.mFillMaterialType(strComID).ToList();

            lstMaterialType.SelectedIndex = lstMaterialType.FindString(uctxtMaterialType.Text);
        }
        private void TabChange()
        {
            uctxtItemName.Focus();

           // uctxtItemName.AllToNextTab(uctxtItemCode);
           // uctxtItemCode.AllToNextTab(uctxtItemDescription);
           // uctxtItemDescription.AllToNextTab(uctxtStockUnder);
           // uctxtStockUnder.AllToNextTab(uctxtStockCategory);
           // uctxtStockCategory.AllToNextTab(uctxtUnit);
           // uctxtUnit.AllToNextTab(uctxtMinumunStock);

           // uctxtAltUnit.AllToNextTab(uctxtWhere);
           // uctxtWhere.AllToNextTab(uctxtWhereUnit);
           // uctxtWhereUnit.AllToNextTab(uctxtMinumunStock);

           // //chkMaintainAltUnit.AllToNextTab(uctxtMinumunStock);
           // uctxtMinumunStock.AllToNextTab(uctxtReorderQnty);
           // uctxtReorderQnty.AllToNextTab(uctxtManufacturer);
           // uctxtManufacturer.AllToNextTab(uctxtStatus);
           // uctxtStatus.AllToNextTab(uctxtOpnQty);
           //// chkMaintainBatch.AllToNextTab(uctxtOpnQty);
           // uctxtOpnQty.AllToNextTab(uctxtOpnRate);
           // uctxtOpnRate.AllToNextTab(uctxtopnValue);
           // uctxtopnValue.AllToNextTab(btnSave);

            




        }
        #endregion
        #region "User Define"
        private void uctxtBatch_TextChanged(object sender, EventArgs e)
        {
            lstBatch.SelectedIndex = lstBatch.FindString(uctxtBatchNo.Text);

        }

        private void lstBatch_DoubleClick(object sender, EventArgs e)
        {
            uctxtBatch.Text = lstBatch.Text;
            lstBatch.Visible = false;
            btnSave.Focus();
        }

        private void uctxtBatch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBatch.Items.Count > 0)
                {
                    uctxtBatch.Text = lstBatch.Text;
                }
                lstBatch.Visible = false;
                btnSave.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtBatchNo, sender, e);
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
            lstStockUnder.Visible = false;
            lstStockCategory.Visible = false;
            lstStockUnit.Visible = false;
            lstAltUnit.Visible = false;
            lstManufacturer.Visible = false;
            lstStatus.Visible = false;
            lstBatch.Visible = true;
            lstLocation.Visible = false;
            lstMaterialType.Visible = false;
            lstItemBatch.Visible = false;
            lstBatch.SelectedIndex = lstBatch.FindString(uctxtBatchNo.Text);
        }
        private void uctxtPowerClass_GotFocus(object sender, System.EventArgs e)
        {
            lstStockUnder.Visible = false;
            lstStockCategory.Visible = false;
            lstStockUnit.Visible = false;
            lstAltUnit.Visible = false;
            lstManufacturer.Visible = false;
            lstStatus.Visible = false;
            lstBatch.Visible = false;
            lstLocation.Visible = false;
            lstMaterialType.Visible = false;
            lstItemBatch.Visible = false;
        }
        private void uctxtPowerClass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtStockUnder.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtPowerClass, sender, e);
            }
        }
        private void uctxtBatchNo_TextChanged(object sender, EventArgs e)
        {
            lstItemBatch.SelectedIndex = lstItemBatch.FindString(uctxtBatchNo.Text);
        }

        private void lstItemBatch_DoubleClick(object sender, EventArgs e)
        {
            uctxtBatchNo.Text = lstItemBatch.Text;
            if (uctxtQty.Text != "" || uctxtQty.Text != "0")
            {
                mAdditemBill(uctxtBranchName.Text, Convert.ToDouble(uctxtQty.Text), Convert.ToDouble(uctxtRate.Text),
                                                    Convert.ToDouble(uctxtAmount.Text), uctxtBatchNo.Text);
            }
            uctxtBranchName.Focus();
        }

        private void uctxtBatchNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstItemBatch.Items.Count > 0)
                {
                    uctxtBatchNo.Text = lstItemBatch.Text;
                }
                if (Utility.Val(uctxtQty.Text) < 0)
                {
                    MessageBox.Show("Qnty is Mismatch");
                    uctxtQty.Focus();
                    return;
                }
                if (Utility.Val(uctxtAmount.Text) == 0)
                {
                    MessageBox.Show("Amount Cannot be Zero");
                    uctxtAmount.Focus();
                    return;
                }
                if (uctxtQty.Text != "" || uctxtQty.Text != "0")
                {
                    mAdditemBill(uctxtBranchName.Text, Convert.ToDouble(uctxtQty.Text), Convert.ToDouble(uctxtRate.Text),
                                                        Convert.ToDouble(uctxtAmount.Text), uctxtBatchNo.Text);
                }
                if (Utility.Val(uctxtQty.Text) < 0)
                {
                    MessageBox.Show("Qnty is Mismatch");
                    uctxtQty.Focus();
                    return;
                }
                uctxtBranchName.Focus();

            }
        }
        private void uctxtBatchNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstItemBatch.SelectedItem != null)
                {
                    lstItemBatch.SelectedIndex = lstItemBatch.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstItemBatch.Items.Count - 1 > lstItemBatch.SelectedIndex)
                {
                    lstItemBatch.SelectedIndex = lstItemBatch.SelectedIndex + 1;
                }
            }

        }

        private void uctxtBatchNo_GotFocus(object sender, System.EventArgs e)
        {
            lstStockUnder.Visible = false;
            lstStockCategory.Visible = false;
            lstStockUnit.Visible = false;
            lstAltUnit.Visible = false;
            lstManufacturer.Visible = false;
            lstStatus.Visible = false;
            lstBatch.Visible = false;
            lstLocation.Visible = false;
            lstMaterialType.Visible = false;
            lstItemBatch.Visible = true;
            lstItemBatch.SelectedIndex = lstItemBatch.FindString(uctxtBatchNo.Text);
        }

        private void uctxtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
               
                uctxtBatchNo.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtAmount, sender, e);
            }
        }
        private void uctxtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtRate.Text=="")
                {
                    MessageBox.Show("Cannot be Empty");
                    uctxtRate.Focus();
                    return;
                }
                uctxtAmount.Text = (Convert.ToDouble(uctxtQty.Text) * Convert.ToDouble(uctxtRate.Text)).ToString();
                uctxtAmount.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtRate, uctxtQty);
            }
        }
        private void uctxtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (Utility.Val(txtBillTotal.Text) != Utility.Val(txtBillPreTotal.Text))
                {
                    uctxtRate.Focus();
                }
                else
                {
                    btnBillapply.Focus();
                }

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtQty, uctxtBranchName);
            }
        }

        private void uctxtBranchName_TextChanged(object sender, EventArgs e)
        {
            lstLocation.Visible = true;
            lstLocation.SelectedIndex = lstLocation.FindString(uctxtBranchName.Text);
        }

        private void lstLocation_DoubleClick(object sender, EventArgs e)
        {
            uctxtBranchName.Text = lstLocation.Text;
            if (txtBillPreTotal.Text != "")
            {
                if (Utility.Val(txtBillPreTotal.Text) != Utility.Val(txtBillTotal.Text))
                {
                    uctxtQty.Focus();
                }
                else
                {
                    btnBillapply.Focus();
                }
            }
            else
            {
                btnBillapply.Focus();
            }
        }

        private void uctxtBranchName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtBillPreTotal.Text != "")
                {
                    if (Utility.Val(txtBillPreTotal.Text) != Utility.Val(txtBillTotal.Text))
                    {
                        if (lstLocation.Items.Count > 0)
                        {
                            uctxtBranchName.Text = lstLocation.Text;
                            uctxtQty.Text = (Utility.Val(txtBillPreTotal.Text) - Utility.Val(txtBillTotal.Text)).ToString();
                            lstLocation.Visible = false;
                            uctxtQty.Focus();
                        }
                    }
                    else
                    {
                        btnBillapply.Focus();
                    }
                }
                else
                {
                    btnBillapply.Focus();
                }
              

            }
        }
        private void uctxtBranchName_KeyDown(object sender, KeyEventArgs e)
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
        private void uctxtRate_GotFocus(object sender, System.EventArgs e)
        {
            
            lstStockUnder.Visible = false;
            lstStockCategory.Visible = false;
            lstStockUnit.Visible = false;
            lstAltUnit.Visible = false;
            lstManufacturer.Visible = false;
            lstStatus.Visible = false;
            lstLocation.Visible = false;
            lstBatch.Visible = false;
            lstMaterialType.Visible = false;
            lstItemBatch.Visible = false;

        }
        private void uctxtAmount_GotFocus(object sender, System.EventArgs e)
        {
             
            lstStockUnder.Visible = false;
            lstStockCategory.Visible = false;
            lstStockUnit.Visible = false;
            lstAltUnit.Visible = false;
            lstManufacturer.Visible = false;
            lstStatus.Visible = false;
            lstLocation.Visible = false;
            lstBatch.Visible = false;
            lstMaterialType.Visible = false;
            lstItemBatch.Visible = false;
           
        }
        private void uctxtBranchName_GotFocus(object sender, System.EventArgs e)
        {
            lstStockUnder.Visible = false;
            lstStockCategory.Visible = false;
            lstStockUnit.Visible = false;
            lstAltUnit.Visible = false;
            lstManufacturer.Visible = false;
            lstStatus.Visible = false;
            lstLocation.Visible = false;
            lstBatch.Visible = false;
            lstMaterialType.Visible = false;
            lstItemBatch.Visible = false;
            lstLocation.SelectedIndex = lstLocation.FindString(uctxtBranchName.Text);
        }
        private void uctxttoUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtMinumunStock.Focus();

            }
        }

        private void uctxtWhere_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtWhereUnit.Focus();

            }
        }

        private void uctxtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (m_action == 1)
                {
                    string strDuplicate = Utility.mCheckDuplicateItem(strComID, "INV_STOCKITEM", "STOCKITEM_NAME", uctxtItemName.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        uctxtItemName.Text = "";
                        uctxtItemName.Focus();
                        return;
                    }
                }
                uctxtItemCode.Focus();

            }
        }
        private void uctxtItemCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (m_action == 1 && uctxtItemCode.Text !="")
                {
                    string strDuplicate = Utility.mCheckDuplicateItem(strComID, "INV_STOCKITEM", "STOCKITEM_ALIAS", uctxtItemCode.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        uctxtItemCode.Text = "";
                        uctxtItemCode.Focus();
                        return;
                    }
                }
                uctxtItemDescription.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtItemCode, sender, e);
            }


        }
        private void cboBatchYesNo_GotFocus(object sender, System.EventArgs e)
        {
            lstStockUnder.Visible = false;
            lstStockCategory.Visible = false;
            lstStockUnit.Visible = false;
            lstAltUnit.Visible = false;
            lstManufacturer.Visible = false;
            lstStatus.Visible = false;
            lstMaterialType.Visible = false;
            lstItemBatch.Visible = false;
        }
        private void cboBatchYesNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (cboBatchYesNo.Text=="Yes")
                {
                     uctxtBatch.Enabled = true;
                }
                else
                {
                    uctxtBatch.Enabled = false;
                }


                uctxtStatus.Focus();
            }
            //if (e.KeyChar == (char)Keys.Back)
            //{
            //    PriorSetFocusText(cboBatchYesNo, sender, e);
            //}
        }
        private void uctxtItemDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtPowerClass.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtItemDescription, sender, e);
            }
        }
        private void uctxtopnValue_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumericNew(uctxtopnValue.Text) == false)
            {
                uctxtopnValue.Text = "";
            }
        }
        private void uctxtOpnRate_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumericNew(uctxtOpnRate.Text) == false)
            {
                uctxtOpnRate.Text = "";
            }
        }
        private void uctxtOpnQty_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumericNew(uctxtOpnQty.Text) == false)
            {
                uctxtOpnQty.Text = "";
            }
        }
        private void uctxtMinumunStock_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumericNew(uctxtMinumunStock.Text) == false)
            {
                uctxtMinumunStock.Text = "";
            }
        }
        private void uctxtMinumunStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtReorderQnty.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtMinumunStock, sender, e);
            }
        }
        private void uctxtReorderQnty_TextChanged(object sender, EventArgs e)
        {
           if (Utility.IsNumericNew(uctxtReorderQnty.Text)==false)
           {
               uctxtReorderQnty.Text = "";
           }
        }
        private void uctxtReorderQnty_KeyPress(object sender, KeyPressEventArgs e)
        {
           

            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtManufacturer.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtReorderQnty, sender, e);
            }
        }

        private void mAdditemBill(string strBranchName,double dblOponQty, double  dblOpnRate, double dblOpnAmount, string strBatchNo)
        {
            int selRaw;
            if (Utility.Val(txtBillTotal.Text) != Utility.Val(txtBillPreTotal.Text))
                dgBillBranch.AllowUserToAddRows = true;
                selRaw = Convert.ToInt16(dgBillBranch.RowCount.ToString());
                selRaw = selRaw - 1;
                dgBillBranch.Rows.Add();
                dgBillBranch[0, selRaw].Value = strBranchName.ToString();
                dgBillBranch[1, selRaw].Value = dblOponQty.ToString();
                dgBillBranch[2, selRaw].Value = dblOpnRate.ToString();
                dgBillBranch[3, selRaw].Value = dblOpnAmount.ToString();
                dgBillBranch[4, selRaw].Value = strBatchNo.ToString();
                dgBillBranch[5, selRaw].Value = "Delete";
                dgBillBranch.AllowUserToAddRows = false;
                uctxtBranchName.Text = "";
                uctxtopnValue.Text = "";
                //uctxtBatchNo.Text = "";
                calculateTotal();
                uctxtQty.Text = (Utility.Val(txtBillPreTotal.Text) - Utility.Val(txtBillTotal.Text)).ToString();
                if (Utility.Val(uctxtQty.Text) < 0)
                {
                    dgBillBranch.Rows.RemoveAt(selRaw);
                }
        }
        #endregion
        #region "Calculatetotal
        private void calculateTotal()
        {
            double dblNetAmount = 0;
            
            for (int i = 0; i < dgBillBranch.Rows.Count; i++)
            {
                dblNetAmount = dblNetAmount + Convert.ToDouble(dgBillBranch.Rows[i].Cells[1].Value);
            }
            
                txtBillTotal.Text = dblNetAmount.ToString();

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
        #region "UserDeine"
        private void uctxtOpnQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (Utility.gblnBranch)
                {
                    
                    if (uctxtOpnQty.Text != "" && uctxtOpnQty.Text != "0")
                    {
                        pnlBillWise.Visible = true;
                        pnlBillWise.Top = uctxtItemName.Top + 10;
                        pnlBillWise.Size = new Size(711, 320);
                        pnlBillWise.Location = new Point(107, 194);
                        txtBillPreTotal.Text = uctxtOpnQty.Text + " " + uctxtUnit.Text;
                        uctxtQty.Text = uctxtOpnQty.Text;
                        uctxtRate.Text = "";
                        if (uctxtOpnRate.Text == "")
                        {
                            uctxtOpnRate.Text = "";
                            uctxtopnValue.Text = "";
                        }
                        txtBillLedger.Text = uctxtItemName.Text;
                        uctxtBranchName.Focus();
                    }
                    else
                    {
                        if (dgBillBranch.Rows.Count > 0)
                        {
                            for (int intRow=0; intRow < dgBillBranch.Rows.Count; intRow++)
                            {
                                dgBillBranch.Rows.RemoveAt(intRow);
                            }
                        }
                        uctxtOpnRate.Focus();
                    }
                }
                else
                {
                    uctxtOpnRate.Focus();
                }
                if (uctxtOpnQty.Text =="0" || uctxtOpnQty.Text =="")
                {
                    uctxtOpnRate.Text = "0";
                    uctxtopnValue.Text = "0";
                }
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtOpnQty, sender, e);
            }
        }
        private void uctxtOpnRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            double dblopnqty = 0, dblrate = 0;
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtOpnQty.Text=="")
                {
                    dblopnqty = 0;
                }
                else
                {
                    dblopnqty = Convert.ToDouble(uctxtOpnQty.Text);
                }
                if (uctxtOpnRate.Text == "")
                {
                    dblrate = 0;
                }
                else
                {
                    dblrate = Convert.ToDouble(uctxtOpnRate.Text);
                }
                uctxtopnValue.Text = (dblopnqty * dblrate).ToString();
                uctxtopnValue.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtOpnRate, sender, e);
            }


        }
        private void uctxtopnValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtBatch.Enabled)
                {
                    uctxtBatch.Focus();
                }
                else
                {
                    btnSave.Focus();
                }

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtopnValue, sender, e);
            }

        }
        private void uctxtWhere_GotFocus(object sender, System.EventArgs e)
        {
            lstStockUnder.Visible = false;
            lstStockCategory.Visible = false;
            lstStockUnit.Visible = false;
            lstAltUnit.Visible = false;
            lstManufacturer.Visible = false;
            lstStatus.Visible = false;
            lstMaterialType.Visible = false;
            lstItemBatch.Visible = false;
        }
        private void uctxttoUnit_GotFocus(object sender, System.EventArgs e)
        {
            lstStockUnder.Visible = false;
            lstStockCategory.Visible = false;
            lstStockUnit.Visible = false;
            lstAltUnit.Visible = false;
            lstManufacturer.Visible = false;
            lstStatus.Visible = false;
            lstMaterialType.Visible = false;
            lstItemBatch.Visible = false;
        }
        private void uctxtAltUnit_TextChanged(object sender, EventArgs e)
        {
            PanelAltUnit.Visible=true;
            lstAltUnit.Visible = true;
            lstAltUnit.SelectedIndex = lstAltUnit.FindString(uctxtAltUnit.Text);
        }
        private void lstAltUnit_DoubleClick(object sender, EventArgs e)
        {
            uctxtAltUnit.Text = lstAltUnit.Text;
            uctxtWhere.Focus();
        }
        private void uctxtAltUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstAltUnit.Items.Count > 0)
                {
                    uctxtAltUnit.Text = lstAltUnit.Text;
                }
                uctxtWhere.Focus();

            }
        }
        private void uctxtAltUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstAltUnit.SelectedItem != null)
                {
                    lstAltUnit.SelectedIndex = lstAltUnit.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstAltUnit.Items.Count - 1 > lstAltUnit.SelectedIndex)
                {
                    lstAltUnit.SelectedIndex = lstAltUnit.SelectedIndex + 1;
                }
            }

        }
        private void uctxtAltUnit_GotFocus(object sender, System.EventArgs e)
        {
            lstStockUnder.Visible = false;
            lstStockCategory.Visible = false;
            lstStockUnit.Visible = false;
            //lstAltUnit.Visible = true;
            lstManufacturer.Visible = false;
            lstStatus.Visible = false;
            lstMaterialType.Visible = false;
            lstItemBatch.Visible = false;
            lstAltUnit.Visible = true;
            lstAltUnit.SelectedIndex = lstAltUnit.FindString(uctxtAltUnit.Text);
        }
        private void uctxtStatus_TextChanged(object sender, EventArgs e)
        {
            lstStatus.SelectedIndex = lstStatus.FindString(uctxtStatus.Text);
        }
        private void lstStatus_DoubleClick(object sender, EventArgs e)
        {
            uctxtStatus.Text = lstStatus.Text;
            uctxtOpnQty.Focus();
        }
        private void uctxtStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstStatus.Items.Count > 0)
                {
                    uctxtStatus.Text = lstStatus.Text;
                }
                uctxtOpnQty.Focus();
            }

            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtStatus, sender, e);
            }
        }
        private void uctxtStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstStatus.SelectedItem != null)
                {
                    lstStatus.SelectedIndex = lstStatus.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstStatus.Items.Count - 1 > lstStatus.SelectedIndex)
                {
                    lstStatus.SelectedIndex = lstStatus.SelectedIndex + 1;
                }
            }

        }
        private void uctxtStatus_GotFocus(object sender, System.EventArgs e)
        {
            lstStockUnder.Visible = false;
            lstStockCategory.Visible = false;
            lstStockUnit.Visible = false;
            lstAltUnit.Visible = false;
            lstManufacturer.Visible = false;
            lstStatus.Visible = true;
            lstMaterialType.Visible = false;
            lstItemBatch.Visible = false;
            lstStatus.SelectedIndex = lstStatus.FindString(uctxtStatus.Text);
        }
        private void uctxtManufacturer_TextChanged(object sender, EventArgs e)
        {
            lstManufacturer.SelectedIndex = lstManufacturer.FindString(uctxtManufacturer.Text);
        }
        private void lstAccountType_DoubleClick(object sender, EventArgs e)
        {
            uctxtManufacturer.Text = lstManufacturer.Text;
            uctxtStatus.Focus();
        }
        private void uctxtManufacturer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtManufacturer.Text !="")
                {
                    uctxtManufacturer.Text = lstManufacturer.Text;
                }
                cboBatchYesNo.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtManufacturer, sender, e);
            }
        }
        private void uctxtManufacturer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstManufacturer.SelectedItem != null)
                {
                    lstManufacturer.SelectedIndex = lstManufacturer.SelectedIndex - 1;
                    uctxtManufacturer.Text = lstManufacturer.Text;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstManufacturer.Items.Count - 1 > lstManufacturer.SelectedIndex)
                {
                    lstManufacturer.SelectedIndex = lstManufacturer.SelectedIndex + 1;
                    uctxtManufacturer.Text = lstManufacturer.Text;
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
                    objfrm.intvtype = (int)Utility.GR_GROUP_TYPE.grSUPPLIER;
                    objfrm.m_acction = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                    objfrm.mSingleEntry = 1;
                    objfrm.lngFormPriv = 2;
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
        private void uctxtManufacturer_GotFocus(object sender, System.EventArgs e)
        {
            lstStockUnder.Visible = false;
            lstStockCategory.Visible = false;
            lstStockUnit.Visible = false;
            lstAltUnit.Visible = false;
            lstManufacturer.Visible = true;
            lstStatus.Visible = false;
            lstMaterialType.Visible = false;
            lstItemBatch.Visible = false;
            lstManufacturer.ValueMember = "strLedgerName";
            lstManufacturer.DisplayMember = "strLedgerName";
            lstManufacturer.DataSource = invms.mFillLedger(strComID, 203).ToList();

            lstManufacturer.SelectedIndex = lstManufacturer.FindString(uctxtManufacturer.Text);



        }
        private void uctxtItemName_GotFocus(object sender, System.EventArgs e)
        {
            lstStockUnder.Visible = false;
            lstStockCategory.Visible = false;
            lstStockUnit.Visible = false;
            lstAltUnit.Visible = false;
            lstManufacturer.Visible = false;
            lstStatus.Visible = false;
            lstMaterialType.Visible = false;
            lstItemBatch.Visible = false;
        }
        private void uctxtItemCode_GotFocus(object sender, System.EventArgs e)
        {
            lstStockUnder.Visible = false;
            lstStockCategory.Visible = false;
            lstStockUnit.Visible = false;
            lstAltUnit.Visible = false;
            lstManufacturer.Visible = false;
            lstStatus.Visible = false;
            lstMaterialType.Visible = false;
            lstItemBatch.Visible = false;
        }
        private void uctxtItemDescription_GotFocus(object sender, System.EventArgs e)
        {
            lstStockUnder.Visible = false;
            lstStockCategory.Visible = false;
            lstStockUnit.Visible = false;
            lstAltUnit.Visible = false;
            lstManufacturer.Visible = false;
            lstStatus.Visible = false;
            lstMaterialType.Visible = false;
            lstItemBatch.Visible = false;
        }
        private void uctxtMinumunStock_GotFocus(object sender, System.EventArgs e)
        {
            lstStockUnder.Visible = false;
            lstStockCategory.Visible = false;
            lstStockUnit.Visible = false;
            lstAltUnit.Visible = false;
            lstManufacturer.Visible = false;
            lstStatus.Visible = false;
            lstMaterialType.Visible = false;
            lstItemBatch.Visible = false;
        }
        private void uctxtReorderQnty_GotFocus(object sender, System.EventArgs e)
        {
            lstStockUnder.Visible = false;
            lstStockCategory.Visible = false;
            lstStockUnit.Visible = false;
            lstAltUnit.Visible = false;
            lstManufacturer.Visible = false;
            lstStatus.Visible = false;
            lstMaterialType.Visible = false;
            lstItemBatch.Visible = false;
        }
        private void uctxtOpnQty_GotFocus(object sender, System.EventArgs e)
        {
            lstStockUnder.Visible = false;
            lstStockCategory.Visible = false;
            lstStockUnit.Visible = false;
            lstAltUnit.Visible = false;
            lstManufacturer.Visible = false;
            lstStatus.Visible = false;
            lstMaterialType.Visible = false;
            PanelAltUnit.Visible = false;
        }
        private void uctxtOpnRate_GotFocus(object sender, System.EventArgs e)
        {
            lstStockUnder.Visible = false;
            lstStockCategory.Visible = false;
            lstStockUnit.Visible = false;
            lstAltUnit.Visible = false;
            lstManufacturer.Visible = false;
            lstStatus.Visible = false;
            lstMaterialType.Visible = false;
            lstItemBatch.Visible = false;
        }
        private void uctxtopnValue_GotFocus(object sender, System.EventArgs e)
        {
            lstStockUnder.Visible = false;
            lstStockCategory.Visible = false;
            lstStockUnit.Visible = false;
            lstAltUnit.Visible = false;
            lstManufacturer.Visible = false;
            lstStatus.Visible = false;
            lstMaterialType.Visible = false;
            lstItemBatch.Visible = false;
        }
        private void uctxtUnit_TextChanged(object sender, EventArgs e)
        {
            lstStockUnit.SelectedIndex = lstStockUnit.FindString(uctxtUnit.Text);
        }
        private void lstStockUnit_DoubleClick(object sender, EventArgs e)
        {
            uctxtUnit.Text = lstStockUnit.Text;
            uctxtMinumunStock.Focus();
        }
        private void uctxtUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstStockUnit.Items.Count > 0)
                {
                    uctxtUnit.Text = lstStockUnit.Text;
                }
                uctxtMinumunStock.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtUnit, sender, e);
            }
        }
        private void uctxtUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstStockUnit.SelectedItem != null)
                {
                    lstStockUnit.SelectedIndex = lstStockUnit.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstStockUnit.Items.Count - 1 > lstStockUnit.SelectedIndex)
                {
                    lstStockUnit.SelectedIndex = lstStockUnit.SelectedIndex + 1;
                }
            }

            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {
              
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 60))
                    {
                        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                if (System.Windows.Forms.Application.OpenForms["frmMeasurementUnit"] as frmMeasurementUnit == null)
                {
                    frmMeasurementUnit objfrm = new frmMeasurementUnit();
                    objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                    objfrm.lngFormPriv = 60;
                    objfrm.strFormName = "Measurement Unit";
                    objfrm.mSingleEntry = 1;
                    objfrm.Show();
                    objfrm.MdiParent = this.MdiParent;

                }
                else
                {
                    frmMeasurementUnit objfrm = (frmMeasurementUnit)Application.OpenForms["frmMeasurementUnit"];
                    objfrm.strFormName = "Measurement Unit";
                    objfrm.lngFormPriv = 60;
                    objfrm.mSingleEntry = 1;
                    objfrm.Focus();
                    objfrm.MdiParent = this.MdiParent;
                }

            }
        }
        private void uctxtUnit_GotFocus(object sender, System.EventArgs e)
        {
            lstStockCategory.Visible = false;
            lstStockUnder.Visible = false;
            lstStockUnit.Visible = true;
            lstAltUnit.Visible = false;
            lstManufacturer.Visible = false;
            lstStatus.Visible = false;
            lstLocation.Visible = false;
            lstBatch.Visible = false;
            lstItemBatch.Visible = false;
            lstMaterialType.Visible = false;
            lstStockUnit.ValueMember = "strUnit";
            lstStockUnit.DisplayMember = "strUnit";
            lstStockUnit.DataSource = invms.mFillUOM(strComID).ToList();
            lstStockUnit.SelectedIndex = lstStockUnit.FindString(uctxtUnit.Text);
        }
        private void uctxtStockCategory_TextChanged(object sender, EventArgs e)
        {
            lstStockCategory.SelectedIndex = lstStockCategory.FindString(uctxtStockCategory.Text);
        }
        private void lstStockCategory_DoubleClick(object sender, EventArgs e)
        {
            uctxtStockCategory.Text = lstStockCategory.Text;
            uctxtMaterialType.Focus();
        }
        private void uctxtStockCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                if (uctxtStockCategory.Text != "")
                {
                    uctxtStockCategory.Text = lstStockCategory.Text;
                }
                uctxtMaterialType.Focus();


            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtStockCategory, sender, e);
            }
        }
        private void uctxtStockCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstStockCategory.SelectedItem != null)
                {
                    lstStockCategory.SelectedIndex = lstStockCategory.SelectedIndex - 1;
                    uctxtStockCategory.Text = lstStockCategory.Text;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstStockCategory.Items.Count - 1 > lstStockCategory.SelectedIndex)
                {
                    lstStockCategory.SelectedIndex = lstStockCategory.SelectedIndex + 1;
                    uctxtStockCategory.Text = lstStockCategory.Text;
                }
            }
            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {
              
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 56))
                    {
                        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (System.Windows.Forms.Application.OpenForms["frmStockCategory"] as frmStockCategory == null)
                {
                    frmStockCategory objfrm = new frmStockCategory();
                    objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                    objfrm.lngFormPriv = 56;
                    objfrm.strFormName = "Pack Size";
                    objfrm.mSingleEntry = 1;
                    objfrm.Show();
                    objfrm.MdiParent = this.MdiParent;

                }
                else
                {
                    frmStockCategory objfrm = (frmStockCategory)Application.OpenForms["frmStockCategory"];
                    objfrm.strFormName = "Pack Size";
                    objfrm.lngFormPriv = 56;
                    objfrm.mSingleEntry = 1;
                    objfrm.Focus();
                    objfrm.MdiParent = this.MdiParent;
                }
            }

        }
        private void uctxtStockCategory_GotFocus(object sender, System.EventArgs e)
        {
            lstStockCategory.Visible = true;
            lstStockUnder.Visible = false;
            lstStockUnit.Visible = false;
            lstAltUnit.Visible = false;
            lstManufacturer.Visible = false;
            lstStatus.Visible = false;
            lstLocation.Visible = false;
            lstBatch.Visible = false;
            lstMaterialType.Visible = false;
            lstItemBatch.Visible = false;
            lstStockCategory.DisplayMember = "Key";
            lstStockCategory.ValueMember = "Value";
            lstStockCategory.DataSource = invms.mLoadStockCategoryItem(strComID).ToList();

            lstStockCategory.SelectedIndex = lstStockCategory.FindString(uctxtStockCategory.Text);
        }
        private void uctxtStockUnder_TextChanged(object sender, EventArgs e)
        {
            lstStockUnder.SelectedIndex = lstStockUnder.FindString(uctxtStockUnder.Text);
        }
        private void lstStockUnder_DoubleClick(object sender, EventArgs e)
        {
            uctxtStockUnder.Text = lstStockUnder.Text;
            bool blngCheck = Utility.getPackSizeYeNo(strComID, uctxtStockUnder.Text);
            if (blngCheck == true)
            {
                if (m_action == 1)
                {
                    uctxtStockCategory.Text = "";
                }
                uctxtStockCategory.Enabled = true;
            }
            else
            {
                if (m_action == 1)
                {
                    uctxtStockCategory.Text = "";
                }
                uctxtStockCategory.Enabled = false;
            }

            if (uctxtStockCategory.Enabled)
            {
                uctxtStockCategory.Focus();
            }
            else
            {
                uctxtMaterialType.Focus();
            }

        }
        private void uctxtStockUnder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstStockUnder.Items.Count > 0)
                {
                    uctxtStockUnder.Text = lstStockUnder.Text;
                }
                bool blngCheck = Utility.getPackSizeYeNo(strComID, uctxtStockUnder.Text);
                if (blngCheck == true)
                {
                    if (m_action == 1)
                    {
                        uctxtStockCategory.Text = "";
                    }
                    uctxtStockCategory.Enabled = true;
                }
                else
                {
                    if (m_action == 1)
                    {
                        uctxtStockCategory.Text = "";
                    }
                    uctxtStockCategory.Enabled = false ;
                }

                if (uctxtStockCategory.Enabled)
                {
                    uctxtStockCategory.Focus();
                }
                else
                {
                    uctxtMaterialType.Focus();
                }
            }
            if (e.KeyChar == (char)Keys.Back)
            {
               PriorSetFocusText(uctxtStockUnder, sender, e);
            }
        }
        private void uctxtStockUnder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstStockUnder.SelectedItem != null)
                {
                    lstStockUnder.SelectedIndex = lstStockUnder.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstStockUnder.Items.Count - 1 > lstStockUnder.SelectedIndex)
                {
                    lstStockUnder.SelectedIndex = lstStockUnder.SelectedIndex + 1;
                }
            }
            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 55))
                    {
                        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (System.Windows.Forms.Application.OpenForms["frmStockGroup"] as frmStockGroup == null)
                {
                    frmStockGroup objfrm = new frmStockGroup();
                    objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                    objfrm.lngFormPriv = 55;
                    objfrm.mSingleEntry = 1;
                    objfrm.strFormName = "Stock Group";
                    objfrm.Show();
                    objfrm.MdiParent = this.MdiParent;

                }
                else
                {
                    frmStockGroup objfrm = (frmStockGroup)Application.OpenForms["frmStockGroup"];
                    objfrm.strFormName = "Stock Group";
                    objfrm.lngFormPriv = 55;
                    objfrm.mSingleEntry = 1;
                    objfrm.Focus();
                    objfrm.MdiParent = this.MdiParent;
                }
                
            }

        }
        private void uctxtStockUnder_GotFocus(object sender, System.EventArgs e)
        {
            lstStockUnder.Visible = true;
            lstStockCategory.Visible = false;
            lstStockUnit.Visible = false;
            lstAltUnit.Visible = false;
            lstManufacturer.Visible = false;
            lstStatus.Visible = false;
            lstLocation.Visible = false;
            lstBatch.Visible = false;
            lstMaterialType.Visible = false;
            lstItemBatch.Visible = false;
            lstStockUnder.ValueMember = "strItemGroup";
            lstStockUnder.DisplayMember = "strItemGroup";
            lstStockUnder.DataSource = invms.gLoadStockGroup(strComID, Utility.gblnAccessControl, Utility.gstrUserName,"N","").ToList();
            lstStockUnder.SelectedIndex = lstStockUnder.FindString(uctxtStockUnder.Text);
        }

        #endregion
        #region "Click
        private void btnTreeView_Click(object sender, EventArgs e)
        {
        //    frmStockTree objfrm = new frmStockTree();
        //    objfrm.MdiParent = this.MdiParent;
        //    objfrm.strName = "1";
        //    objfrm.Show();
        //    objfrm.MdiParent = this.MdiParent;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            uctxtItemName.Focus();
        }
        private void chkMaintainAltUnit_Click(object sender, EventArgs e)
        {
            if (chkMaintainAltUnit.Checked==true)
            {
                pnlAltUnit.Visible = true;
                PanelAltUnit.Visible = true;
                uctxtAltUnit.Focus();
            }
            else
            {
                PanelAltUnit.Visible = false;
                pnlAltUnit.Visible = false;
            }
        }

        private void frmStockItem_Load(object sender, EventArgs e)
        {
            lstStockUnder.Visible=false ;
            lstStockCategory.Visible=false ;
            lstStockUnit.Visible=false ;
            lstAltUnit.Visible = false;
            lstManufacturer.Visible = false;
            lstStatus.Visible = false;
            lstLocation.Visible = false;
            lstBatch.Visible = false;
            lstMaterialType.Visible = false;
            lstItemBatch.Visible = false;
            dgBillBranch.AllowUserToAddRows = false;

            //lstLocation.ValueMember = "BranchID";
            //lstLocation.DisplayMember = "BranchName";
            //lstLocation.DataSource = accms.mFillBranch().ToList();

            //lstBatch.ValueMember = "strBatch";
            //lstBatch.DisplayMember = "strBatch";
            //lstBatch.DataSource = invms.mFillOpeningBatch().ToList();

            lstBatch.DisplayMember = "value";
            lstBatch.ValueMember = "Key";
            lstBatch.DataSource = new BindingSource(invms.mFillOpeningBatch(strComID), null);

            lstItemBatch.DisplayMember = "value";
            lstItemBatch.ValueMember = "Key";
            lstItemBatch.DataSource = new BindingSource(invms.mFillOpeningBatch(strComID), null);

            //lstLocation.ValueMember = "BranchID";
            //lstLocation.DisplayMember = "BranchName";
            //lstLocation.DataSource = accms.mFillBranch().ToList();
            lstLocation.ValueMember = "strLocation";
            lstLocation.DisplayMember = "strLocation";
            lstLocation.DataSource = invms.gLoadLocation(strComID, "", Utility.gblnAccessControl, Utility.gstrUserName,0).ToList();
            
           

            lstAltUnit.ValueMember = "strUnit";
            lstAltUnit.DisplayMember = "strUnit";
            lstAltUnit.DataSource = invms.mFillUOM(strComID).ToList();


            LoadDefaultValue();
             
        }
        private void LoadDefaultValue()
        {
            SortedDictionary<string, int> userCache = new SortedDictionary<string, int>
            {
              {"No", 1},
              {"Yes", 2}
            };

            lstStatus.DisplayMember = "Key";
            lstStatus.ValueMember = "Value";
            lstStatus.DataSource = new BindingSource(userCache, null);



        }
        private void btnBillapply_Click(object sender, EventArgs e)
        {
            double dblAmount = 0;
            if (txtBillPreTotal.Text != "")
            {
                if (Utility.Val(uctxtOpnQty.Text) != Utility.Val(txtBillTotal.Text))
                {
                    MessageBox.Show("Qnty is Mismatch");
                    uctxtQty.Text = "";
                    uctxtQty.Focus();
                    btnSave.Enabled = false;
                    return;
                }
                else
                {
                    btnSave.Enabled = true;
                }
            }
           
            if (uctxtOpnRate.Text == "")
            {
                for (int i = 0; i < dgBillBranch.Rows.Count;i++ )
                {
                    dblAmount = dblAmount + Utility.Val(dgBillBranch[3, i].Value.ToString());
                }
                uctxtOpnRate.Text = (dblAmount / Utility.Val(uctxtOpnQty.Text)).ToString();
                uctxtopnValue.Text = (Utility.Val(uctxtOpnQty.Text) * Utility.Val(uctxtOpnRate.Text)).ToString();
            }
            else if (uctxtOpnRate.Text != uctxtRate.Text)
            {
                //if (uctxtRate.Text != "")
                //{
                    for (int i = 0; i < dgBillBranch.Rows.Count; i++)
                    {
                        dblAmount = dblAmount + Utility.Val(dgBillBranch[3, i].Value.ToString());
                    }
                    uctxtOpnRate.Text = (dblAmount / Utility.Val(uctxtOpnQty.Text)).ToString();
                    uctxtopnValue.Text = (Utility.Val(uctxtOpnQty.Text) * Utility.Val(uctxtOpnRate.Text)).ToString();
                //}
            }
            if (uctxtBatchNo.Text != "")
            {
                uctxtBatch.Text = uctxtBatchNo.Text;
            }
            uctxtopnValue.Text = (Utility.Val(uctxtOpnQty.Text) * Utility.Val(uctxtOpnRate.Text)).ToString();
            pnlBillWise.Visible = false;
            btnSave.Focus();
        }

        private void btnBillCancel_Click(object sender, EventArgs e)
        {
            pnlBillWise.Visible = false;
            uctxtOpnRate.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string i = "",strCatgortyName="";
            long lngMaintainBatch = 0;
            int intSpItem = 0;
            if (uctxtItemName.Text == "")
            {
                MessageBox.Show("Cannot be Empty");
                uctxtItemName.Focus();
                return;
            }
            if (uctxtUnit.Text == "")
            {
                MessageBox.Show("Cannot be Empty");
                uctxtUnit.Focus();
                return;
            }
            if (uctxtStockUnder.Text == "")
            {
                MessageBox.Show("Cannot be Empty");
                uctxtStockUnder.Focus();
                return;
            }
            if (uctxtStockCategory.Text =="")
            {
                strCatgortyName = "";
            }
            else
            {
                strCatgortyName = uctxtStockCategory.Text;
            }

            if (cboBatchYesNo.Text =="Yes")
            {
                lngMaintainBatch=2;
            }
            else
            {
                lngMaintainBatch=1;
            }
            if (chkSpItem.Checked==true)
            {
                intSpItem = 1;
            }
            else
            {
                intSpItem = 0;
            }

            //if (uctxtStockCategory.Enabled )
            //{
            //    if (uctxtStockCategory.Text =="")
            //    {
            //        MessageBox.Show("Pack Size Cannot be Empty");
            //        uctxtStockCategory.Focus();
            //        return ;
            //    }
            //}
            if (uctxtBatch.Text == "No" && uctxtBatch.Text != Utility.gcEND_OF_LIST)
            {
                MessageBox.Show("You Cannt change Batch Status,Batch Is Active");
                uctxtBatch.Focus();
                return;
            }
            if (Utility.gblnAccessControl)
            {
                if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, m_action))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }

            string strGrid = "";
            for (int intgrid = 0; intgrid < dgBillBranch.Rows.Count;intgrid++ )
            {
                strGrid = strGrid + dgBillBranch[0, intgrid].Value.ToString() + "|" +
                                    dgBillBranch[1, intgrid].Value.ToString() + "|"+
                                    dgBillBranch[2,intgrid].Value.ToString() + "|"+
                                    dgBillBranch[3,intgrid].Value.ToString() + "|"+
                                    dgBillBranch[4,intgrid].Value.ToString() +"~";

            }

            double dblMinimumStock = 0, dblReorderQty = 0, dblOpnty = 0, dblOpnRate = 0, dblopnAmnt = 0;
            if (uctxtMinumunStock.Text=="")
            {
                dblMinimumStock = 0;
            }
            else
            {
                dblMinimumStock = Convert.ToDouble(uctxtMinumunStock.Text);
            }
            if (uctxtMinumunStock.Text == "")
            {
                dblReorderQty = 0;
            }
            else
            {
                dblReorderQty = Convert.ToDouble(uctxtReorderQnty.Text);
            }
            if (uctxtOpnQty.Text == "")
            {
                dblOpnty = 0;
            }
            else
            {
                dblOpnty = Convert.ToDouble(uctxtOpnQty.Text);
            }
            if (uctxtOpnRate.Text == "")
            {
                dblOpnRate = 0;
            }
            else
            {
                dblOpnRate = Convert.ToDouble(uctxtOpnRate.Text);
            }
            if (uctxtopnValue.Text == "")
            {
                dblopnAmnt = 0;
            }
            else
            {
                dblopnAmnt = Convert.ToDouble(uctxtopnValue.Text);
            }
            string strDuplicate = "";
                if (m_action == 1)
                {
                    
                    strDuplicate = Utility.mCheckDuplicateItem(strComID, "INV_STOCKITEM", "STOCKITEM_NAME", uctxtItemName.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        uctxtItemName.Text = "";
                        uctxtItemName.Focus();
                        return;
                    }
                    if (uctxtItemCode.Text != "")
                    {
                        strDuplicate = Utility.mCheckDuplicateItem(strComID, "INV_STOCKITEM", "STOCKITEM_ALIAS", uctxtItemCode.Text);
                        if (strDuplicate != "")
                        {
                            MessageBox.Show(strDuplicate);
                            uctxtItemCode.Text = "";
                            uctxtItemCode.Focus();
                            return;
                        }
                    }

                    var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (strResponseInsert == DialogResult.Yes)
                    {
                        try
                        {
                            i = invms.mInsertStockItem(strComID, uctxtItemName.Text, uctxtStockUnder.Text, lngMaintainBatch, uctxtStatus.Text, 
                                                        uctxtItemName.Text, uctxtItemCode.Text, uctxtItemDescription.Text, "",
                                                        strCatgortyName, uctxtUnit.Text, uctxtAltUnit.Text, uctxtWhere.Text, 
                                                        uctxtWhereUnit.Text, uctxtManufacturer.Text, "", "", "", 
                                                        dblMinimumStock, dblReorderQty,
                                                        dblOpnty, dblOpnRate,
                                                        dblopnAmnt, strGrid, Utility.gCheckNull(uctxtMaterialType.Text), 
                                                        Utility.gCheckNull(uctxtPowerClass.Text), Utility.gCheckNull(uctxtBatch.Text),intSpItem);

                            if (i == "Inseretd...")
                            {
                                if (Utility.gblnAccessControl)
                                {
                                    string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), strFormName, uctxtItemName.Text,
                                                                            1, 0, (int)Utility.MODULE_TYPE.mtSTOCK, "0001");
                                }
                                if (mSingleEntry==1)
                                {
                                    mSingleEntry = 0;
                                    this.Dispose();
                                }
                                //Interaction.SaveSetting(Application.ExecutablePath, "StockItem", "ItemName", uctxtItemName.Text);
                                RegistryKey rk = Registry.CurrentUser.CreateSubKey("SOFTWARE\\SmartAccounts");
                                rk.SetValue("ItemName", uctxtItemName.Text);
                                rk.Close();
                                mclear();

                            }
                            else
                            {
                                MessageBox.Show(i);
                            }
                        }


                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
                if (m_action == 2)
                {

                    if (mstrOldItem.Trim().ToUpper() != uctxtItemName.Text.Trim().ToUpper())
                    {
                        strDuplicate = Utility.mCheckDuplicateItem(strComID, "INV_STOCKITEM", "STOCKITEM_NAME", uctxtItemName.Text);
                        if (strDuplicate != "")
                        {
                            MessageBox.Show(strDuplicate);
                            uctxtItemName.Text = "";
                            uctxtItemName.Focus();
                            return;
                        }
                    }
                    if (mstrOldAlias != uctxtItemCode.Text)
                    {
                        if (uctxtItemCode.Text != "")
                        {
                            strDuplicate = Utility.mCheckDuplicateItem(strComID, "INV_STOCKITEM", "STOCKITEM_ALIAS", uctxtItemCode.Text);
                            if (strDuplicate != "")
                            {
                                MessageBox.Show(strDuplicate);
                                uctxtItemCode.Text = "";
                                uctxtItemCode.Focus();
                                return;
                            }
                        }
                    }



                    var strResponseInsert = MessageBox.Show("Do You Want to Update?", "Update Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (strResponseInsert == DialogResult.Yes)
                    {
                        try
                        {
                            i = invms.mUpdateStockItem(strComID, Convert.ToInt64(txtSlNo.Text), uctxtItemName.Text, uctxtStockUnder.Text, lngMaintainBatch, uctxtStatus.Text,
                                                        uctxtItemName.Text, uctxtItemCode.Text, uctxtItemDescription.Text, "",
                                                        strCatgortyName, uctxtUnit.Text, uctxtAltUnit.Text, uctxtWhere.Text,
                                                        uctxtWhereUnit.Text, uctxtManufacturer.Text, "", "", "",
                                                        dblMinimumStock, dblReorderQty,
                                                        dblOpnty, dblOpnRate,
                                                        dblopnAmnt, strGrid, Utility.gCheckNull(uctxtMaterialType.Text), Utility.gCheckNull(uctxtPowerClass.Text), Utility.gCheckNull(uctxtBatch.Text), intSpItem);


                            if (i == "Updated...")
                            {
                                if (Utility.gblnAccessControl)
                                {
                                    string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), strFormName, uctxtItemName.Text,
                                                                            2, 0, (int)Utility.MODULE_TYPE.mtSTOCK, "0001");
                                }
                                mclear();
                               
                            }
                            else
                            {
                                MessageBox.Show("Error!!!");
                            }
                        }


                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            mclear();
            frmStockItemList objfrm = new frmStockItemList();
            objfrm.onAddAllButtonClicked = new frmStockItemList.AddAllClick(DisplayReqList);
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.strFormName = strFormName;
            objfrm.Show();
            objfrm.MdiParent = this.MdiParent;
            
        }
        #endregion
        #region "Clear"
        private void mclear()
        {
            uctxtItemName.Text = "";
            chkSpItem.Checked = false;
            uctxtItemCode.Text = "";
            uctxtItemDescription.Text = "";
            uctxtPowerClass.Text = "";
            //uctxtStockUnder.Text = "";
            uctxtStockCategory.Text = "";
            uctxtMaterialType.Text = "";
            uctxtUnit.Text = "";
            uctxtMinumunStock.Text = "";
            uctxtReorderQnty.Text = "";
            uctxtManufacturer.Text = "";
            uctxtStatus.Text = "";
            uctxtAltUnit.Text = "";
            uctxtWhere.Text = "";
            uctxtBatch.Text = "";
            uctxtBatchNo.Text = "";
            uctxtBranchName.Text = "";
            uctxtAmount.Text = "";
            txtBillTotal.Text  = "";
            uctxtWhereUnit.Text = "";
            chkMaintainAltUnit.Checked = false;
            cboBatchYesNo.Text = "No";
            uctxtopnValue.Text = "";
            uctxtOpnQty.Text = "";
            uctxtOpnRate.Text = "";
            m_action = 1;
            dgBillBranch.Rows.Clear();
            uctxtItemName.Focus();

        }
        #endregion
        #region "DisplayReq"
        private void DisplayReqList(List<StockItem> tests, object sender, EventArgs e)
        {
            try
            {
               
                m_action = 2;
                txtSlNo.Text = tests[0].lngSlNo.ToString();
                List<StockItem> ooItem = invms.mDisplayItemRecord(strComID, Convert.ToInt64(tests[0].lngSlNo)).ToList();
                if (ooItem.Count > 0)
                {
                    foreach (StockItem ts in ooItem)
                    {
                        //txtSlNo.Text = ts.lngSlNo.ToString();
                        mstrOldItem = ts.strItemName;
                        uctxtItemName.Text = ts.strItemName;
                        uctxtItemCode.Text = ts.strItemcode;
                        mstrOldAlias = ts.strItemcode;
                        uctxtItemDescription.Text = ts.strItemDescription ;
                        uctxtStockUnder.Text = ts.strItemGroup;
                        uctxtStockCategory.Text = ts.strItemCategory;
                        uctxtMaterialType.Text = ts.strMatType;
                        uctxtPowerClass.Text = ts.strPowerClass;
                        uctxtUnit.Text = ts.strUnit;
                        uctxtAltUnit.Text = ts.strAltUnit;
                        uctxtWhere.Text = ts.strDenominator;
                        uctxtWhereUnit.Text = ts.strConversion;
                        if (ts.intSPItem==1)
                        {
                            chkSpItem.Checked = true;
                        }
                        else
                        {
                            chkSpItem.Checked =false;
                        }
                        if (uctxtAltUnit.Text != "")
                        {
                            chkMaintainAltUnit.Checked = true;
                            pnlAltUnit.Visible = true;
                            PanelAltUnit.Visible = true;
                            uctxtAltUnit.Focus();
                        }
                        else
                        {
                            chkMaintainAltUnit.Checked = false;
                            PanelAltUnit.Visible = false;
                            pnlAltUnit.Visible = false;

                        }
                        uctxtManufacturer.Text = ts.strManufacturer;
                        uctxtMinumunStock.Text = ts.dblMinimumStock.ToString();
                        uctxtReorderQnty.Text = ts.dblReorderQty.ToString();
                        uctxtStatus.Text = ts.strStatus;
                        uctxtOpnQty.Text = ts.dblOpnQty.ToString();
                        uctxtOpnRate.Text = ts.dblOpnRate.ToString();
                        uctxtopnValue.Text = ts.dblOpnValue.ToString();
                        if (ts.intMaintainBatch ==2)
                        {
                            cboBatchYesNo.Text = "Yes";
                        }
                        else
                        {
                            cboBatchYesNo.Text = "No";
                        }

                        dgBillBranch.Rows.Clear();
                        List<StockItem> ooGodown = invms.mLoadGodownData(strComID, ts.strItemName).ToList();
                        if (ooGodown.Count > 0)
                        {
                            int introw = 0;
                            foreach (StockItem otem in ooGodown)
                            {
                                dgBillBranch.Rows.Add();
                                dgBillBranch[0, introw].Value = otem.strBranchName;
                                dgBillBranch[1, introw].Value = otem.dblBranchQty;
                                dgBillBranch[2, introw].Value = otem.dblBranchRate;
                                dgBillBranch[3, introw].Value = otem.dblBranchAmnout;
                                dgBillBranch[4, introw].Value = otem.strBatch;
                                dgBillBranch[5, introw].Value = "Delete";
                                uctxtBatch.Text = otem.strBatch;
                                introw += 1;
                            }
                            dgBillBranch.AllowUserToAddRows = false;
                            calculateTotal();
                        }

                    }
                
                }
                uctxtItemName.Focus();
                   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        #endregion
       
        private void dgBillBranch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==5)
            {
                try
                {
                    dgBillBranch.Rows.RemoveAt(e.RowIndex);
                    calculateTotal();
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string value = " ";
            if (Utility.InputBox("Find Card No", "Enter Your Card No:", ref value) == DialogResult.OK)
            {
                try
                {

                    m_action = 2;
                    txtSlNo.Text = Utility.GetslNoFItem(strComID,value).ToString();
                    List<StockItem> ooItem = invms.mDisplayItemRecord(strComID, Convert.ToInt64(txtSlNo.Text)).ToList();
                    if (ooItem.Count > 0)
                    {
                        foreach (StockItem ts in ooItem)
                        {
                            //txtSlNo.Text = ts.lngSlNo.ToString();
                            mstrOldItem = ts.strItemName;
                            uctxtItemName.Text = ts.strItemName;
                            uctxtItemCode.Text = ts.strItemcode;
                            mstrOldAlias = ts.strItemcode;
                            uctxtItemDescription.Text = ts.strItemDescription;
                            uctxtStockUnder.Text = ts.strItemGroup;
                            uctxtStockCategory.Text = ts.strItemCategory;
                            uctxtMaterialType.Text = ts.strMatType;
                            uctxtPowerClass.Text = ts.strPowerClass;
                            uctxtUnit.Text = ts.strUnit;
                            uctxtAltUnit.Text = ts.strAltUnit;
                            uctxtWhere.Text = ts.strDenominator;
                            uctxtWhereUnit.Text = ts.strConversion;
                            if (ts.intSPItem == 1)
                            {
                                chkSpItem.Checked = true;
                            }
                            else
                            {
                                chkSpItem.Checked = false;
                            }
                            if (uctxtAltUnit.Text != "")
                            {
                                chkMaintainAltUnit.Checked = true;
                                pnlAltUnit.Visible = true;
                                PanelAltUnit.Visible = true;
                                uctxtAltUnit.Focus();
                            }
                            else
                            {
                                chkMaintainAltUnit.Checked = false;
                                PanelAltUnit.Visible = false;
                                pnlAltUnit.Visible = false;

                            }
                            uctxtManufacturer.Text = ts.strManufacturer;
                            uctxtMinumunStock.Text = ts.dblMinimumStock.ToString();
                            uctxtReorderQnty.Text = ts.dblReorderQty.ToString();
                            uctxtStatus.Text = ts.strStatus;
                            uctxtOpnQty.Text = ts.dblOpnQty.ToString();
                            uctxtOpnRate.Text = ts.dblOpnRate.ToString();
                            uctxtopnValue.Text = ts.dblOpnValue.ToString();
                            if (ts.intMaintainBatch == 2)
                            {
                                cboBatchYesNo.Text = "Yes";
                            }
                            else
                            {
                                cboBatchYesNo.Text = "No";
                            }

                            dgBillBranch.Rows.Clear();
                            List<StockItem> ooGodown = invms.mLoadGodownData(strComID, ts.strItemName).ToList();
                            if (ooGodown.Count > 0)
                            {
                                int introw = 0;
                                foreach (StockItem otem in ooGodown)
                                {
                                    dgBillBranch.Rows.Add();
                                    dgBillBranch[0, introw].Value = otem.strBranchName;
                                    dgBillBranch[1, introw].Value = otem.dblBranchQty;
                                    dgBillBranch[2, introw].Value = otem.dblBranchRate;
                                    dgBillBranch[3, introw].Value = otem.dblBranchAmnout;
                                    dgBillBranch[4, introw].Value = otem.strBatch;
                                    dgBillBranch[5, introw].Value = "Delete";
                                    uctxtBatch.Text = otem.strBatch;
                                    introw += 1;
                                }
                                dgBillBranch.AllowUserToAddRows = false;
                                calculateTotal();
                            }

                        }

                    }
                    uctxtItemName.Focus();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }



      
      


    }
}
