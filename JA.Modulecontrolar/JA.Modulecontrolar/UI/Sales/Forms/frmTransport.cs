using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using JA.Modulecontrolar.UI.Inventory;
using JA.Modulecontrolar.JACCMS;
using JA.Modulecontrolar.UI.Accms.Forms;
using Dutility;
using JA.Modulecontrolar.JINVMS;
using Microsoft.Win32;

namespace JA.Modulecontrolar.UI.Sales.Forms
{
    public partial class frmTransport : JA.Shared.UI.frmSmartFormStandard
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public int lngLedgeras { get; set; }
        public long lngFormPriv { get; set; }
        public int m_action { get; set; }
        public int intVtype { get; set; }
        private string mstrOldTransport { get; set; }
        private string strComID { get; set; }

        public frmTransport()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.txtTransportName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtTransportName_KeyPress);
            this.txtTransportName.TextChanged += new System.EventHandler(this.txtTransportName_TextChanged);
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
        private void txtTransportName_KeyPress(object sender, KeyPressEventArgs e)
        {
            string strDuplicate = "";
            if (e.KeyChar == (char)Keys.Return)
            {
                if (m_action == 2)
                {
                    if (mstrOldTransport != txtTransportName.Text)
                    {
                        strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_TRANSPORT_NAME", "TRANSPORT_NAME", txtTransportName.Text);
                        if (strDuplicate != "")
                        {
                            MessageBox.Show(strDuplicate);
                            txtTransportName.Text = "";
                            txtTransportName.Focus();
                            return;
                        }
                    }
                }
                else
                {
                    strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_TRANSPORT_NAME", "TRANSPORT_NAME", txtTransportName.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        txtTransportName.Text = "";
                        txtTransportName.Focus();
                        return;
                    }
                }

                btnSave.Focus();
            }
        }

        private void txtTransportName_TextChanged(object sender, EventArgs e)
        {
            int x = txtTransportName.SelectionStart;
            txtTransportName.Text = Utility.gmakeProperCase(txtTransportName.Text);
            txtTransportName.SelectionStart = x;
        }
        #endregion
        #region "Click"
        private void btnSave_Click(object sender, EventArgs e)
        {
            string i = "", strDuplicate="";
            if (txtTransportName.Text =="")
            {
                MessageBox.Show("Cannot be Empty");
                txtTransportName.Focus();
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
                if (mstrOldTransport != txtTransportName.Text)
                {
                    strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_TRANSPORT_NAME", "TRANSPORT_NAME", txtTransportName.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        txtTransportName.Text = "";
                        txtTransportName.Focus();
                        return;
                    }
                }
            }
            else
            {
                strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_TRANSPORT_NAME", "TRANSPORT_NAME", txtTransportName.Text);
                if (strDuplicate != "")
                {
                    MessageBox.Show(strDuplicate);
                    txtTransportName.Text = "";
                    txtTransportName.Focus();
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

                        i = invms.mInsertTransport(strComID, txtTransportName.Text);
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Transport", txtTransportName.Text,
                                                                    1, 0, (int)Utility.MODULE_TYPE.mtSALES, "0001");
                        } 

                        txtTransportName.Text = "";

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

                        i = invms.mUpdateTransport(strComID, uctxtOldTransport.Text, txtTransportName.Text);
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Transport", txtTransportName.Text,
                                                                    2, 0, (int)Utility.MODULE_TYPE.mtSALES, "0001");
                        } 
                        txtTransportName.Text = "";
                        //MessageBox.Show(i);
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
            frmTransportList objfrm = new frmTransportList();
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.onAddAllButtonClicked = new frmTransportList.AddAllClick(DisplayList);
            objfrm.Show();
            objfrm.MdiParent = MdiParent;
            txtTransportName.Focus();
        }
        #endregion
        #region "Display List"
        private void DisplayList(List<Transport> tests, object sender, EventArgs e)
        {
            try
            {
                uctxtOldTransport.Text = "";
                txtTransportName.Text = "";
                m_action = 2;
                mstrOldTransport = tests[0].strTransPort.ToString();
                uctxtOldTransport.Text = tests[0].strTransPort.ToString();
                txtTransportName.Text = tests[0].strTransPort.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion
        #region "Load"
        private void frmTransport_Load(object sender, EventArgs e)
        {
            txtTransportName.Focus();
        }
        #endregion


    }
}
