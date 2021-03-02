using Dutility;
using JA.Modulecontrolar.UI.DReport.Accms.ParameterForms;
using JA.Modulecontrolar.UI.Sales.Forms;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JA.Modulecontrolar.UI.Accms.Forms
{
    public partial class frmMPOCommission : JA.Shared.UI.frmSmartFormStandard
    {
        private string strComID { get; set; }
        public frmMPOCommission()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
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

        private void btnLedgerConfiguration_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 102))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmLedgerConfiguration"] as frmLedgerConfiguration == null)
            {
                frmLedgerConfiguration objfrm = new frmLedgerConfiguration();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.lngFormPriv = 102;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmLedgerConfiguration objfrm = (frmLedgerConfiguration)Application.OpenForms["frmLedgerConfiguration"];
                objfrm.lngFormPriv = 102;
                objfrm.MdiParent = this.MdiParent;
                objfrm.Focus();
            }
        }

        private void btnCollectionMonth_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 16))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmCollectionMonthSetup"] as frmCollectionMonthSetup == null)
            {
                frmCollectionMonthSetup objfrm = new frmCollectionMonthSetup();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.lngFormPriv = 16;
                objfrm.MdiParent = MdiParent;
                objfrm.Show();

            }
            else
            {
                frmCollectionMonthSetup objfrm = (frmCollectionMonthSetup)Application.OpenForms["frmCollectionMonthSetup"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnAddCommssionBill_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 174))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (System.Windows.Forms.Application.OpenForms["frmMpoCommManual"] as frmMpoCommManual == null)
            {
                frmMpoCommManual objfrm = new frmMpoCommManual();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.lngFormPriv = 174;
                objfrm.MdiParent = this.MdiParent;
                objfrm.Show();

            }
            else
            {
                frmMpoCommManual objfrm = (frmMpoCommManual)Application.OpenForms["frmMpoCommManual"];
                objfrm.lngFormPriv = 107;
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnIncentiveConfiguration_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 213))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            
            if (System.Windows.Forms.Application.OpenForms["frmIncentiveCalculation"] as frmIncentiveCalculation == null)
            {
                frmIncentiveCalculation objfrm = new frmIncentiveCalculation();
                objfrm.lngFormPriv = 213;
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.MdiParent = this.MdiParent;
                objfrm.Show();
            }
            else
            {
                frmIncentiveCalculation objfrm = (frmIncentiveCalculation)Application.OpenForms["frmIncentiveCalculation"];
                objfrm.Focus();

            }
        }    
       

     
    }
}
