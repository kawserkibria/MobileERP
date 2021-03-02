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
using Microsoft.Win32;

namespace JA.Modulecontrolar.UI.Master
{
    public partial class frmStockCategory : JA.Shared.UI.frmSmartFormStandard
    {
        private ListBox lstUnder = new ListBox();
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public int mSingleEntry { get; set; }
        public long lngFormPriv { get; set; }
        public string strFormName { get; set; }
        private string strOldPack { get; set; }
        public int m_action { get; set; }
        private string strComID { get; set; }
        public frmStockCategory()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.txtUnder.KeyDown += new KeyEventHandler(txtUnder_KeyDown);
            this.txtUnder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtUnder_KeyPress);
            this.txtUnder.TextChanged += new System.EventHandler(this.txtUnder_TextChanged);
            this.lstUnder.DoubleClick += new System.EventHandler(this.lstUnder_DoubleClick);
            this.txtUnder.GotFocus += new System.EventHandler(this.txtUnder_GotFocus);

            this.txtGroupName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtGroupName_KeyPress);
            this.txtGroupName.GotFocus += new System.EventHandler(this.txtGroupName_GotFocus);
            this.txtGroupName.TextChanged += new System.EventHandler(this.txtGroupName_TextChanged);

            Utility.CreateListBox(lstUnder, pnlMain, txtUnder);
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

        #region "User Define"

        private void txtGroupName_TextChanged(object sender, EventArgs e)
        {
            int x = txtGroupName.SelectionStart;
            txtGroupName.Text = Utility.gmakeProperCase(txtGroupName.Text);
            txtGroupName.SelectionStart = x;
        }
        private void txtGroupName_GotFocus(object sender, System.EventArgs e)
        {
            lstUnder.Visible = false;

        }
        private void txtGroupName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (m_action == 1)
            {
                string strDuplicate = Utility.mCheckDuplicateItem(strComID, "INV_STOCKCATEGORY", "STOCKCATEGORY_NAME", txtGroupName.Text);
                if (strDuplicate != "")
                {
                    MessageBox.Show(strDuplicate);
                    txtGroupName.Text = "";
                    txtGroupName.Focus();
                    return;


                }
            }
            if (e.KeyChar == (char)Keys.Return)
            {
                btnSave.Focus();
            }
        }
        private void txtUnder_TextChanged(object sender, EventArgs e)
        {
            lstUnder.SelectedIndex = lstUnder.FindString(txtUnder.Text);
        }

        private void lstUnder_DoubleClick(object sender, EventArgs e)
        {
            txtUnder.Text = lstUnder.Text;
            btnSave.Focus();
        }

        private void txtUnder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstUnder.Items.Count > 0)
                {
                    txtUnder.Text = lstUnder.Text;
                }
                lstUnder.Visible = false;
                btnSave.Focus();

            }
        }
        private void txtUnder_KeyDown(object sender, KeyEventArgs e)
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

        private void txtUnder_GotFocus(object sender, System.EventArgs e)
        {
            lstUnder.Visible = true;
            lstUnder.DisplayMember = "value";
            lstUnder.ValueMember = "Key";
            lstUnder.DataSource = new BindingSource(invms.mLoadStockCategory(strComID), null);
            lstUnder.SelectedIndex = lstUnder.FindString(txtUnder.Text);
        }

        #endregion
        #region "Click"
        private void btnTreeView_Click(object sender, EventArgs e)
        {
            //frmStockTree objfrm = new frmStockTree();
            //objfrm.strName = "3";
            //objfrm.Show();
            //objfrm.MdiParent = this.MdiParent;
        }
       

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmStockCategoryList objfrm = new frmStockCategoryList();
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.strFormName = strFormName;
            objfrm.onAddAllButtonClicked = new frmStockCategoryList.AddAllClick(DisplayVoucherList);
            objfrm.Show();
            objfrm.MdiParent = MdiParent;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string i = "";
            if (Utility.gblnAccessControl)
            {
                if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, m_action))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (txtGroupName.Text == "")
            {
                MessageBox.Show("Name Cannot be Empty");
                txtGroupName.Focus();
                return;
            }
          
            txtUnder.Text = "Primary";
            if (txtUnder.Text.ToUpper() != "PRIMARY")
            {
                MessageBox.Show("Name Should be Primary");
                txtUnder.Focus();
                return;
            }
            if (m_action == 1)
            {


                string strDuplicate = Utility.mCheckDuplicateItem(strComID, "INV_STOCKCATEGORY", "STOCKCATEGORY_NAME", txtGroupName.Text);
                if (strDuplicate != "")
                {
                    MessageBox.Show(strDuplicate);
                    txtGroupName.Text = "";
                    txtGroupName.Focus();
                    return;

                }

                var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        i = invms.mInsertcategory(strComID, txtGroupName.Text.ToString(), txtUnder.Text.ToString());

                        if (i == "Inseretd...")
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), strFormName, txtGroupName.Text,
                                                                        1, 0, (int)Utility.MODULE_TYPE.mtSTOCK, "0001");
                            }
                            btnNew.PerformClick();
                            txtGroupName.Focus();
                            txtUnder.Text = "";
                            txtSlNo.Text = "";
                            txtGroupName.Text = "";
                            m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                            
                            if (mSingleEntry==1)
                            {
                                mSingleEntry = 0;
                                this.Dispose();
                            }
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
            else
            {
                if (strOldPack != txtGroupName.Text)
                {
                    string strDuplicate = Utility.mCheckDuplicateItem(strComID, "INV_STOCKCATEGORY", "STOCKCATEGORY_NAME", txtGroupName.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        txtGroupName.Focus();
                        return;

                    }
                }
                var strResponseInsert = MessageBox.Show("Do You Want to Update?", "Update Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        i = invms.mUpdatecategory(strComID, Convert.ToInt64(txtSlNo.Text), txtGroupName.Text.ToString(), txtUnder.Text.ToString());

                        if (i == "Updated...")
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), strFormName, txtGroupName.Text,
                                                                        2, 0, (int)Utility.MODULE_TYPE.mtSTOCK, "0001");
                            }
                            btnNew.PerformClick();
                            txtGroupName.Focus();
                            txtUnder.Text = "";
                            txtGroupName.Text = "";
                            txtSlNo.Text = "";
                            m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                            frmStockCategoryList objfrm = new frmStockCategoryList();
                            objfrm.lngFormPriv = lngFormPriv;
                            objfrm.strFormName = strFormName;
                            objfrm.onAddAllButtonClicked = new frmStockCategoryList.AddAllClick(DisplayVoucherList);
                            objfrm.Show();
                            objfrm.MdiParent = MdiParent;
                          
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
        #endregion
        #region "Load"
        private void frmStockCategory_Load(object sender, EventArgs e)
        {
            txtGroupName.Select();
            txtUnder.Text = "Primary";
           
        }
        #endregion
        #region "Display"
        private void DisplayVoucherList(List<StockCategory> tests, object sender, EventArgs e)
        {
            try
            {
                m_action = 2;
                txtSlNo.Text = tests[0].lngslNo.ToString();
                List<StockCategory> ooGrp = invms.mDisplayCategoryRecord(strComID, Convert.ToInt64(tests[0].lngslNo)).ToList();
                if (ooGrp.Count > 0)
                {
                    strOldPack = ooGrp[0].CategoryName;
                    txtGroupName.Text = ooGrp[0].CategoryName;
                    txtUnder.Text = ooGrp[0].CategoryUnder;
                    txtGroupName.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion








    }
}
