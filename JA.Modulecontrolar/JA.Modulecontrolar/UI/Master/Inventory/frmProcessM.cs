using Dutility;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JA.Modulecontrolar.UI.Inventory
{
    public partial class frmProcessM : JA.Shared.UI.frmSmartFormStandard
    {
        private string strComID { get; set; }
        public frmProcessM()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
        }

        private void btnProcessInformation_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 64))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmProcessInformation"] as frmProcessInformation == null)
            {
                frmProcessInformation objfrm = new frmProcessInformation();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.lngFormPriv = 64;
                objfrm.strFormName = "Process Information";
                objfrm.intConvert = 0;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmProcessInformation objfrm = (frmProcessInformation)Application.OpenForms["frmProcessInformation"];
                objfrm.strFormName = "Process Information";
                objfrm.lngFormPriv = 64;
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnFgtoFg_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 65))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmProcessInformation"] as frmProcessInformation == null)
            {
                frmProcessInformation objfrm = new frmProcessInformation();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.lngFormPriv = 65;
                objfrm.strFormName = "FG to FG Conversion";
                objfrm.intConvert = 1;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmProcessInformation objfrm = (frmProcessInformation)Application.OpenForms["frmProcessInformation"];
                objfrm.strFormName = "FG to FG Conversion";
                objfrm.lngFormPriv = 65;
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        

      
    }
}
