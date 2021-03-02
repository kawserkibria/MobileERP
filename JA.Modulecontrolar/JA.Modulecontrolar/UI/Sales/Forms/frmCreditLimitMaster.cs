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

namespace JA.Modulecontrolar.UI.Sales.Forms
{
    public partial class frmCreditLimitMaster : JA.Shared.UI.frmSmartFormStandard
    {
        private string strComID { get; set; }
        public frmCreditLimitMaster()
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
            //if (Utility.gblnAccessControl)
            //{
            //    if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 15))
            //    {
            //        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }
            //}
            //if (System.Windows.Forms.Application.OpenForms["frmCollectionCommitementNew"] as frmCollectionCommitementNew == null)
            //{
            //    frmCollectionCommitementNew objfrm = new frmCollectionCommitementNew();
            //    objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            //    objfrm.strSelection = "MC";
            //    objfrm.lngFormPriv = 15;
            //    objfrm.strtFormName = "Credit Limt";
            //    objfrm.Show();
            //    objfrm.MdiParent = this.MdiParent;

            //}
            //else
            //{
            //    frmCollectionCommitementNew objfrm = (frmCollectionCommitementNew)Application.OpenForms["frmCollectionCommitementNew"];
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 15))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmCollectionCommitement"] as frmCollectionCommitement == null)
            {
                frmCollectionCommitement objfrm = new frmCollectionCommitement();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.strSelection = "MC";
                objfrm.lngFormPriv = 15;
                objfrm.strtFormName = "Credit Limt";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmCollectionCommitement objfrm = (frmCollectionCommitement)Application.OpenForms["frmCollectionCommitement"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnCollectionMonth_Click(object sender, EventArgs e)
        {
            //if (Utility.gblnAccessControl)
            //{
            //    if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 17))
            //    {
            //        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }
            //}
            if (System.Windows.Forms.Application.OpenForms["frmCollectionTargetMonth"] as frmCollectionTargetMonth == null)
            {
                frmCollectionTargetMonth objfrm = new frmCollectionTargetMonth();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                //objfrm.strSelection = "CT";
                objfrm.lngFormPriv = 17;
                //objfrm.strtFormName = "Collection Target";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmCollectionTargetMonth objfrm = (frmCollectionTargetMonth)Application.OpenForms["frmCollectionTargetMonth"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

      
       

     
    }
}
