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
    public partial class frmMaterialType : JA.Shared.UI.frmSmartFormStandard
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public int m_action { get; set; }
        public long lngFormPriv { get; set; }
        public string strFormName { get; set; }
        public int mSingleEntry { get; set; }
        private string strComID { get; set; }
        public frmMaterialType()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.uctxtMaterialType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtMaterialType_KeyPress);
            this.uctxtMaterialType.TextChanged += new System.EventHandler(this.uctxtMaterialType_TextChanged);
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
        private void uctxtMaterialType_TextChanged(object sender, EventArgs e)
        {
            int x = uctxtMaterialType.SelectionStart;
            uctxtMaterialType.Text = Utility.gmakeProperCase(uctxtMaterialType.Text);
            uctxtMaterialType.SelectionStart = x;
        }
        private void uctxtMaterialType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (m_action == 1)
                {
                    string strDuplicate = Utility.mCheckDuplicateItem(strComID, "INV_STOCK_MATERIAL_TYPE", "MATERIAL_TYPE", uctxtMaterialType.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        uctxtMaterialType.Text = "";
                        uctxtMaterialType.Focus();
                        return;
                    }
                }
                btnSave.Focus();

            }
        }
        #endregion
        #region "Click"
        private void btnSave_Click(object sender, EventArgs e)
        {
            string strmsg = "";
            if (uctxtMaterialType.Text == "")
            {
                MessageBox.Show("Cannot be Empty");
                uctxtMaterialType.Focus();
                return;
            }
            if (m_action == 1)
            {
               
                string strDuplicate = Utility.mCheckDuplicateItem(strComID, "INV_STOCK_MATERIAL_TYPE", "MATERIAL_TYPE", uctxtMaterialType.Text);
                if (strDuplicate != "")
                {
                    MessageBox.Show(strDuplicate);
                    uctxtMaterialType.Text = "";
                    uctxtMaterialType.Focus();
                    return;
                }

                var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        strmsg = invms.mInsertMaterialType(strComID, uctxtMaterialType.Text.Replace("'", "''"));
                        txtOLdMaterialType.Text = "";
                        uctxtMaterialType.Text = "";
                        if (mSingleEntry == 1)
                        {
                            mSingleEntry = 0;
                            this.Dispose();
                        }
                        else
                        {
                            uctxtMaterialType.Focus();
                        }
                    }
                    catch (Exception EX)
                    {
                        MessageBox.Show(strmsg);
                    }
                }
            }
            else
            {
                if (txtOLdMaterialType.Text != uctxtMaterialType.Text)
                {
                    string strDuplicate = Utility.mCheckDuplicateItem(strComID, "INV_STOCK_MATERIAL_TYPE", "MATERIAL_TYPE", uctxtMaterialType.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        uctxtMaterialType.Focus();
                        return;
                    }
                }
                var strResponseInsert = MessageBox.Show("Do You Want to Update?", "Update Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        strmsg = invms.mUpdateMaterialType(strComID, txtOLdMaterialType.Text.Replace("'", "''"), uctxtMaterialType.Text.Replace("'", "''"));
                        txtOLdMaterialType.Text = "";
                        uctxtMaterialType.Text = "";
                        //MessageBox.Show(strmsg);
                        uctxtMaterialType.Focus();
                    }
                    catch (Exception EX)
                    {
                        MessageBox.Show(strmsg);
                    }
                }
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmMaterialtypeList objfrm = new frmMaterialtypeList();
            objfrm.onAddAllButtonClicked = new frmMaterialtypeList.AddAllClick(DisplayList);
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.strFormName = strFormName;
            objfrm.Show();
            objfrm.MdiParent = this.MdiParent;
            uctxtMaterialType.Focus();
        }
        #endregion
        private void DisplayList(List<MaterialType> tests, object sender, EventArgs e)
        {
            try
            {
                uctxtMaterialType.Text = "";
                txtOLdMaterialType.Text = "";
                m_action = 2;
                txtOLdMaterialType.Text = tests[0].strMaterialType.ToString();
                uctxtMaterialType.Text = tests[0].strMaterialType.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void frmMaterialType_Load(object sender, EventArgs e)
        {

        }






    }
}
