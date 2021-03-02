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
    public partial class frmDeliveryRoute : JA.Shared.UI.frmSmartFormStandard
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public long lngFormPriv { get; set; }
        public int lngLedgeras { get; set; }
        public string mstrOldDestination { get; set; }
        public int m_action { get; set; }
        public int intVtype { get; set; }
        private string strComID { get; set; }

        public frmDeliveryRoute()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.txtDeliveryRoute.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtDeliveryRoute_KeyPress);
            this.txtDeliveryRoute.TextChanged += new System.EventHandler(this.txtDeliveryRoute_TextChanged);
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
        private void txtDeliveryRoute_KeyPress(object sender, KeyPressEventArgs e)
        {
            string strDuplicate = "";
            if (e.KeyChar == (char)Keys.Return)
            {
                if (m_action == 2)
                {
                    if (mstrOldDestination != txtDeliveryRoute.Text)
                    {
                        strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_DELIVERY_ROUTE", "DELIVERY_ROUTE_NAME", txtDeliveryRoute.Text);
                        if (strDuplicate != "")
                        {
                            MessageBox.Show(strDuplicate);
                            txtDeliveryRoute.Text = "";
                            txtDeliveryRoute.Focus();
                            return;
                        }
                    }
                }
                else
                {
                    strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_DESTINATION", "DESTINATION_NAME", txtDeliveryRoute.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        txtDeliveryRoute.Text = "";
                        txtDeliveryRoute.Focus();
                        return;
                    }
                }

                btnSave.Focus();
            }
        }
        private void txtDeliveryRoute_TextChanged(object sender, EventArgs e)
        {
            int x = txtDeliveryRoute.SelectionStart;
            txtDeliveryRoute.Text = Utility.gmakeProperCase(txtDeliveryRoute.Text);
            txtDeliveryRoute.SelectionStart = x;
        }
        #endregion
        private void frmDeliveryRoute_Load(object sender, EventArgs e)
        {
            txtDeliveryRoute.Focus();
        }

        #region "Click"
        private void btnSave_Click(object sender, EventArgs e)
        {
            string i = "", strDuplicate="";
            if (txtDeliveryRoute.Text == "")
            {
                MessageBox.Show("Cannot be Empty");
                txtDeliveryRoute.Focus();
                return;
            }
            if (Utility.gblnAccessControl)
            {
                if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, m_action))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (m_action==2)
            {
                if (mstrOldDestination != txtDeliveryRoute.Text)
                {
                    strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_DELIVERY_ROUTE", "DELIVERY_ROUTE_NAME", txtDeliveryRoute.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        txtDeliveryRoute.Text = "";
                        txtDeliveryRoute.Focus();
                        return;
                    }
                }
            }
            else
            {
                strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_DELIVERY_ROUTE", "DELIVERY_ROUTE_NAME", txtDeliveryRoute.Text);
                if (strDuplicate != "")
                {
                    MessageBox.Show(strDuplicate);
                    txtDeliveryRoute.Text = "";
                    txtDeliveryRoute.Focus();
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

                        i = invms.mInsertDeliveryRoute(strComID, txtDeliveryRoute.Text);
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "DeliveryRoute", txtDeliveryRoute.Text,
                                                                    1, 0, (int)Utility.MODULE_TYPE.mtSALES, "0001");
                        }
                        txtDeliveryRoute.Text = "";
                        txtDeliveryRoute.Focus();
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

                        i = invms.mUpdateDeliveryRoute(strComID, uctxtOldDeliveryRoute.Text, txtDeliveryRoute.Text);
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "DeliveryRoute", txtDeliveryRoute.Text,
                                                                    2, 0, (int)Utility.MODULE_TYPE.mtSALES, "0001");
                        }
                        txtDeliveryRoute.Text = "";
                        txtDeliveryRoute.Focus();
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
            frmDeliveryRouteList objfrm = new frmDeliveryRouteList();
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.onAddAllButtonClicked = new frmDeliveryRouteList.AddAllClick(DisplayList);
            objfrm.Show();
            objfrm.MdiParent = MdiParent;
            txtDeliveryRoute.Focus();
        }
        #endregion
        private void DisplayList(List<DeliveryRoute> tests, object sender, EventArgs e)
        {
            try
            {
                uctxtOldDeliveryRoute.Text = "";
                txtDeliveryRoute.Text = "";
                m_action = 2;
                mstrOldDestination = tests[0].strDeliveryRoute.ToString();
                uctxtOldDeliveryRoute.Text = tests[0].strDeliveryRoute.ToString();
                txtDeliveryRoute.Text = tests[0].strDeliveryRoute.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

      
    }
}
