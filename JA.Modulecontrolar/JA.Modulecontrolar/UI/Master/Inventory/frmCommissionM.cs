using Dutility;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JA.Modulecontrolar.UI.Master
{
    public partial class frmCommissionM : JA.Shared.UI.frmSmartFormStandard
    {
        private string strComID { get; set; }
        public frmCommissionM()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
        }

        private void btnGroupConfiguration_Click(object sender, EventArgs e)
        {
            //if (Utility.gblnAccessControl)
            //{
            //    if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 54))
            //    {
            //        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }
            //}

            //if (System.Windows.Forms.Application.OpenForms["frmGroupConfiguration"] as frmGroupConfiguration == null)
            //{
            //    frmGroupConfiguration objfrm = new frmGroupConfiguration();
            //    objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            //    objfrm.lngFormPriv = 54;
            //    objfrm.strFormName = "Group Configuration";
            //    objfrm.Show();
            //    objfrm.MdiParent = this.MdiParent;

            //}
            //else
            //{
            //    frmGroupConfiguration objfrm = (frmGroupConfiguration)Application.OpenForms["frmGroupConfiguration"];
            //    objfrm.strFormName = "Group Configuration";
            //    objfrm.lngFormPriv = 54;
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}
        }

        private void btnCommissionConfig_Click(object sender, EventArgs e)
        {
            //if (Utility.gblnAccessControl)
            //{
            //    if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 57))
            //    {
            //        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }
            //}

            //if (System.Windows.Forms.Application.OpenForms["frmCommissionConfig"] as frmCommissionConfig == null)
            //{
            //    frmCommissionConfig objfrm = new frmCommissionConfig();
            //    objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            //    objfrm.lngFormPriv = 57;
            //    objfrm.strFormName = "Commission Config";
            //    objfrm.Show();
            //    objfrm.MdiParent = this.MdiParent;

            //}
            //else
            //{
            //    frmCommissionConfig objfrm = (frmCommissionConfig)Application.OpenForms["frmCommissionConfig"];
            //    objfrm.strFormName = "Commission Config";
            //    objfrm.lngFormPriv = 57;
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}
        }
    }
}
