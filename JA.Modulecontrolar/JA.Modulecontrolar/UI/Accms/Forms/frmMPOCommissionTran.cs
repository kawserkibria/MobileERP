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
    public partial class frmMPOCommissionTran : JA.Shared.UI.frmSmartFormStandard
    {
        private string strComID { get; set; }
        public frmMPOCommissionTran()
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

        private void btnMpoCommission_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 107))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (System.Windows.Forms.Application.OpenForms["frmCommission"] as frmCommission == null)
            {
                frmCommission objfrm = new frmCommission();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.lngFormPriv = 107;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmCommission objfrm = (frmCommission)Application.OpenForms["frmCommission"];
                objfrm.lngFormPriv = 107;
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
            
            
        }

        private void btnReceiptDoctor_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 160))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmAccountsVoucherMR"] as frmAccountsVoucherMR == null)
            {
                frmAccountsVoucherMR objfrm = new frmAccountsVoucherMR();
                objfrm.intvtype = (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER;
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.intsp = 2;
                objfrm.lngFormPriv = 160;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmAccountsVoucherMR objfrm = (frmAccountsVoucherMR)Application.OpenForms["frmAccountsVoucherMR"];
                objfrm.lngFormPriv = 160;
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

       
       

     
    }
}
