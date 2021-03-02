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


namespace JA.Modulecontrolar.UI.Inventory
{
    public partial class frmStockOthersCategory : JA.Shared.UI.frmSmartFormStandard
    {
        private ListBox lstUnder = new ListBox();
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public int m_action { get; set; }
        public int mSingleEntry { get; set; }
        private string strComID { get; set; }
        public frmStockOthersCategory()
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

            Utility.CreateListBox(lstUnder, pnlMain, txtUnder);
        }

        #region "User Define"
        private void txtGroupName_GotFocus(object sender, System.EventArgs e)
        {
            lstUnder.Visible = false;

        }
        private void txtGroupName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtUnder.Focus();

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
            lstUnder.DataSource = new BindingSource(invms.mLoadStockCategoryOthers(strComID), null);
            lstUnder.SelectedIndex = lstUnder.FindString(txtUnder.Text);
        }

        #endregion

        private void frmStockOthersCategory_Load(object sender, EventArgs e)
        {
            lstUnder.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string i = "";
            if (txtGroupName.Text == "")
            {
                MessageBox.Show("Group Name Cannot be Empty");
                txtGroupName.Focus();
                return;
            }
            if (txtUnder.Text == "")
            {
                MessageBox.Show("Group Under Cannot be Empty");
                txtUnder.Focus();
                return;
            }
            if (m_action == 1)
            {
                var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        i = invms.mInsertOtherscategory(strComID, txtGroupName.Text.ToString(), txtUnder.Text.ToString());

                        if (i == "Inseretd...")
                        {
                            btnNew.PerformClick();
                            txtGroupName.Focus();
                            txtUnder.Text = "";
                            txtSlNo.Text = "";
                            txtGroupName.Text = "";
                            m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;

                            if (mSingleEntry == 1)
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
                var strResponseInsert = MessageBox.Show("Do You Want to Update?", "Update Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        i = invms.mUpdateOtherscategory(strComID, Convert.ToInt64(txtSlNo.Text), txtGroupName.Text.ToString(), txtUnder.Text.ToString());

                        if (i == "Updated...")
                        {
                            btnNew.PerformClick();
                            txtGroupName.Focus();
                            txtUnder.Text = "";
                            txtGroupName.Text = "";
                            txtSlNo.Text = "";
                            m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;

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
            frmStockOthersCategoryList objfrm = new frmStockOthersCategoryList();
            objfrm.onAddAllButtonClicked = new frmStockOthersCategoryList.AddAllClick(DisplayVoucherList);
            objfrm.MdiParent = MdiParent;
            //objfrm.lngFormPriv = lngFormPriv;
            objfrm.ShowDialog();
        }
        private void DisplayVoucherList(List<StockCategory> tests, object sender, EventArgs e)
        {
            try
            {
                m_action = 2;
                txtSlNo.Text = tests[0].lngslNo.ToString();
                List<StockCategory> ooGrp = invms.mDisplayCategoryRecordOthers(strComID, Convert.ToInt64(tests[0].lngslNo)).ToList();
                if (ooGrp.Count > 0)
                {
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



    }
}
