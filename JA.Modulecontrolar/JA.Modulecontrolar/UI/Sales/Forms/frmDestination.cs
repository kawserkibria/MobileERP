using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using JA.Modulecontrolar.UI.Inventory;
using JA.Modulecontrolar.JACCMS;
using JA.Modulecontrolar.UI.Accms.Forms;
using Dutility;
using JA.Modulecontrolar.JINVMS;
using Microsoft.Win32;

namespace JA.Modulecontrolar.UI.Sales.Forms
{
    public partial class frmDestination : JA.Shared.UI.frmSmartFormStandard
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public long lngFormPriv { get; set; }
        public int lngLedgeras { get; set; }
        public string mstrOldDestination { get; set; }
        public int m_action { get; set; }
        public int intVtype { get; set; }
        private string strComID { get; set; }

        public frmDestination()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.txtDestinationName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtDestinatinName_KeyPress);
            this.txtDestinationName.TextChanged += new System.EventHandler(this.txtDestinationName_TextChanged);
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
        #region "user Define"
        private void txtDestinatinName_KeyPress(object sender, KeyPressEventArgs e)
        {
            string strDuplicate = "";
            if (e.KeyChar == (char)Keys.Return)
            {
                if (m_action == 2)
                {
                    if (mstrOldDestination != txtDestinationName.Text)
                    {
                        strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_DESTINATION", "DESTINATION_NAME", txtDestinationName.Text);
                        if (strDuplicate != "")
                        {
                            MessageBox.Show(strDuplicate);
                            txtDestinationName.Text = "";
                            txtDestinationName.Focus();
                            return;
                        }
                    }
                }
                else
                {
                    strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_DESTINATION", "DESTINATION_NAME", txtDestinationName.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        txtDestinationName.Text = "";
                        txtDestinationName.Focus();
                        return;
                    }
                }

                btnSave.Focus();
            }
        }
        private void txtDestinationName_TextChanged(object sender, EventArgs e)
        {
            int x = txtDestinationName.SelectionStart;
            txtDestinationName.Text = Utility.gmakeProperCase(txtDestinationName.Text);
            txtDestinationName.SelectionStart = x;
        }
        #endregion
        private void frmDestination_Load(object sender, EventArgs e)
        {
            txtDestinationName.Focus();
        }

        #region "Click"
        private void btnSave_Click(object sender, EventArgs e)
        {
            string i = "", strDuplicate="";
            if (txtDestinationName.Text == "")
            {
                MessageBox.Show("Cannot be Empty");
                txtDestinationName.Focus();
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

            if (m_action==2)
            {
                if (mstrOldDestination != txtDestinationName.Text)
                {
                    strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_DESTINATION", "DESTINATION_NAME", txtDestinationName.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        txtDestinationName.Text = "";
                        txtDestinationName.Focus();
                        return;
                    }
                }
            }
            else
            {
                strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_DESTINATION", "DESTINATION_NAME", txtDestinationName.Text);
                if (strDuplicate != "")
                {
                    MessageBox.Show(strDuplicate);
                    txtDestinationName.Text = "";
                    txtDestinationName.Focus();
                    return;
                }
            }

            if (m_action == 1)
            {
                var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {

                        i = invms.mInsertDesignation(strComID, txtDestinationName.Text);
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Destination", txtDestinationName.Text,
                                                                    1, 0, (int)Utility.MODULE_TYPE.mtSALES, "0001");
                        }
                        txtDestinationName.Text = "";
                        txtDestinationName.Focus();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(i.ToString());
                    }
                }
            }
            if (m_action == 2)
            {
                var strResponseInsert = MessageBox.Show("Do You  want to Update?", "Update Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {

                        i = invms.mUpdateDesignation(strComID, uctxtOldDesignation.Text, txtDestinationName.Text);
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Destination", txtDestinationName.Text,
                                                                    2, 0, (int)Utility.MODULE_TYPE.mtSALES, "0001");
                        }
                        txtDestinationName.Text = "";
                        txtDestinationName.Focus();
                        m_action = 1;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(i.ToString());
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmDestinationList objfrm = new frmDestinationList();
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.onAddAllButtonClicked = new frmDestinationList.AddAllClick(DisplayList);
            objfrm.Show();
            objfrm.MdiParent = MdiParent;
            txtDestinationName.Focus();
        }
        #endregion
        private void DisplayList(List<Designation> tests, object sender, EventArgs e)
        {
            try
            {
                uctxtOldDesignation.Text = "";
                txtDestinationName.Text = "";
                m_action = 2;
                mstrOldDestination = tests[0].strDesignation.ToString();
                uctxtOldDesignation.Text = tests[0].strDesignation.ToString();
                txtDestinationName.Text = tests[0].strDesignation.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

      
    }
}
