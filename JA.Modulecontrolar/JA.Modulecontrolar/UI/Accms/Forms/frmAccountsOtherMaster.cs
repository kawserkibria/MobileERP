using Dutility;
using JA.Modulecontrolar.UI.DReport.Accms.ParameterForms;
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
    public partial class frmAccountsOtherMaster : JA.Shared.UI.frmSmartFormStandard
    {
        private string strComID { get; set; }
        public frmAccountsOtherMaster()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.btnBankReconcilation.Click += new System.EventHandler(this.btnBankReconcilation_Click);
            this.btnAutoPFHL.Click += new System.EventHandler(this.btnAutoPFHL_Click);
            this.btnOverHead.Click += new System.EventHandler(this.btnOverHead_Click);
            this.btnInterestCharge.Click += new System.EventHandler(this.btnInterestCharge_Click);
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
        private void btnBankReconcilation_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 171))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmBankReconcilation"] as frmBankReconcilation == null)
            {
                frmBankReconcilation objfrm = new frmBankReconcilation();
                objfrm.MdiParent = this.MdiParent;
                objfrm.Show();

            }
            else
            {
                frmBankReconcilation objfrm = (frmBankReconcilation)Application.OpenForms["frmBankReconcilation"];
                objfrm.MdiParent = this.MdiParent;
                objfrm.Focus();
            }
        }
        private void btnAutoPFHL_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, 193, 1))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (System.Windows.Forms.Application.OpenForms["frmAutoJV"] as frmAutoJV == null)
            {
                frmAutoJV objfrm = new frmAutoJV();
                objfrm.MdiParent = this.MdiParent;
                objfrm.Show();
            }
            else
            {
                frmAutoJV objfrm = (frmAutoJV)Application.OpenForms["frmAutoJV"];
                objfrm.MdiParent = this.MdiParent;
                objfrm.Focus();
            }
        }

        private void btnOverHead_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["frmScriptOverheadValue"] as frmScriptOverheadValue == null)
            {
                frmScriptOverheadValue objfrm = new frmScriptOverheadValue();
                objfrm.MdiParent = this.MdiParent;
                objfrm.Show();

            }
            else
            {
                frmScriptOverheadValue objfrm = (frmScriptOverheadValue)Application.OpenForms["frmScriptOverheadValue"];
                objfrm.MdiParent = this.MdiParent;
                objfrm.Focus();
            }
        }

        private void btnInterestCharge_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 108))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmInterestChargee"] as frmInterestChargee == null)
            {
                frmInterestChargee objfrm = new frmInterestChargee();
                objfrm.lngFormPriv = 108;
                objfrm.MdiParent = this.MdiParent;
                objfrm.Show();

            }
            else
            {
                frmInterestChargee objfrm = (frmInterestChargee)Application.OpenForms["frmInterestChargee"];
                objfrm.lngFormPriv = 108;
                objfrm.MdiParent = this.MdiParent;
                objfrm.Focus();
            }

        }

        private void cmdIncentiveGeneration_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 214))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (System.Windows.Forms.Application.OpenForms["frmIncentiveGenerate"] as frmIncentiveGenerate == null)
            {
                frmIncentiveGenerate objfrm = new frmIncentiveGenerate();
                objfrm.lngFormPriv = 214;
                objfrm.MdiParent = this.MdiParent;
                objfrm.Show();
            }
            else
            {
                frmIncentiveGenerate objfrm = (frmIncentiveGenerate)Application.OpenForms["frmIncentiveGenerate"];
                objfrm.Focus();

            }
        }

        private void btnOverHead_Click_1(object sender, EventArgs e)
        {

        }

        private void btnMpoCommissionAuto_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 218))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmCommissionAuto"] as frmCommissionAuto == null)
            {
                frmCommissionAuto objfrm = new frmCommissionAuto();
                objfrm.MdiParent = this.MdiParent;
                objfrm.Show();

            }
            else
            {
                frmCommissionAuto objfrm = (frmCommissionAuto)Application.OpenForms["frmCommissionAuto"];
                objfrm.MdiParent = this.MdiParent;
                objfrm.Focus();
            }
        }

    

        

      
       

     
    }
}
