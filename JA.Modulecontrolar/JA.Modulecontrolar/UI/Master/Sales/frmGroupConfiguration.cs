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
using System.Globalization;
using Microsoft.Win32;

namespace JA.Modulecontrolar.UI.Master.Sales
{
    public partial class frmGroupConfiguration : JA.Shared.UI.frmSmartFormStandard
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public string strFoemName;
        public int m_action { get; set; }
        public int mSingleEntry { get; set; }
        public long lngFormPriv { get; set; }
        public string strFormName { get; set; }
        private string strComID { get; set; }
        public frmGroupConfiguration()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.uctxtGroupConfigName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtGroupConfigName_KeyPress);
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
        #region "User Define Event"
        private void uctxtGroupConfigName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (m_action == 1)
                {
                    string strDuplicate = Utility.mCheckDuplicateItem(strComID, "INV_GROUP_MASTER", "GR_NAME", uctxtGroupConfigName.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        uctxtGroupConfigName.Text = "";
                        uctxtGroupConfigName.Focus();
                        return;
                    }
                }
                btnSave.Focus();

            }
        }
        private void uctxtGroupConfigName_TextChanged(object sender, EventArgs e)
        {
            int x = uctxtGroupConfigName.SelectionStart;
            uctxtGroupConfigName.Text = Utility.gmakeProperCase(uctxtGroupConfigName.Text);
            uctxtGroupConfigName.SelectionStart = x;
        }
        #endregion
        private void frmGroupConfiguration_Load(object sender, EventArgs e)
        {
            uctxtGroupConfigName.Select();
        }

        #region "Click Event"
        private void btnSave_Click(object sender, EventArgs e)
        {
            string strmsg = "";
            if (Utility.gblnAccessControl)
            {
                if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, m_action))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (uctxtGroupConfigName.Text =="")
            {
                MessageBox.Show("Cannot be Empty");
                uctxtGroupConfigName.Focus();
                return;
            }
            if (m_action == 1)
            {
                string strDuplicate = Utility.mCheckDuplicateItem(strComID, "INV_GROUP_MASTER", "GR_NAME", uctxtGroupConfigName.Text);
                if (strDuplicate != "")
                {
                    MessageBox.Show(strDuplicate);
                    uctxtGroupConfigName.Text = "";
                    uctxtGroupConfigName.Focus();
                    return;
                }
                var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        strmsg = invms.mInsertStockGroupNew(strComID, uctxtGroupConfigName.Text);
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), strFormName, uctxtGroupConfigName.Text,
                                                                    1, 0, (int)Utility.MODULE_TYPE.mtSTOCK, "0001");
                        } 

                        uctxtOldName.Text = "";
                        uctxtGroupConfigName.Text = "";
                        uctxtGroupConfigName.Focus();
                    }
                    catch (Exception EX)
                    {
                        MessageBox.Show(strmsg);
                    }
                }
            }
            else
            {
                if (uctxtOldName.Text != uctxtGroupConfigName.Text)
                {
                    string strDuplicate = Utility.mCheckDuplicateItem(strComID, "INV_GROUP_MASTER", "GR_NAME", uctxtGroupConfigName.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        uctxtGroupConfigName.Focus();
                        return;
                    }
                }
               
                var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        strmsg = invms.mUpdateStockGroupNew(strComID, Utility.gCheckNull(uctxtOldName.Text), Utility.gCheckNull(uctxtGroupConfigName.Text));
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), strFormName, uctxtGroupConfigName.Text,
                                                                    2, 0, (int)Utility.MODULE_TYPE.mtSTOCK, "0001");
                        } 
                        uctxtOldName.Text = "";
                        uctxtGroupConfigName.Text = "";
                        uctxtGroupConfigName.Focus();
                        m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
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
            //frmGroupConfigurationList objfrm = new frmGroupConfigurationList();
            //objfrm.onAddAllButtonClicked = new frmGroupConfigurationList.AddAllClick(DisplayList);
            //objfrm.MdiParent = MdiParent;
            //objfrm.lngFormPriv = lngFormPriv;
            //objfrm.Show();
            //objfrm.MdiParent = this.MdiParent;
            //uctxtGroupConfigName.Focus();
        }
        #endregion
        #region "DisplayList"
        private void DisplayList(List<StockGroup> tests, object sender, EventArgs e)
        {
            try
            {
                uctxtOldName.Text = "";
                uctxtGroupConfigName.Text = "";
                m_action = 2;
                uctxtOldName.Text = tests[0].GroupName.ToString();
                uctxtGroupConfigName.Text = tests[0].GroupName.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        private void btnTreeView_Click(object sender, EventArgs e)
        {
        //    frmStockTree objfrm = new frmStockTree();
        //    objfrm.strName = "2";
        //    objfrm.Show();
        //    objfrm.MdiParent = this.MdiParent;
        }







        public int intModuleType { get; set; }

        public int inttype { get; set; }
    }
}
