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

namespace JA.Modulecontrolar.UI.Master.Accounts
{
    public partial class frmCostCenterMain : JA.Shared.UI.frmSmartFormStandard
    {
        private string strComID { get; set; }
        public frmCostCenterMain()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
        }

        private void btnRptLedgerWise_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 124))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptCostCenter"] as frmRptCostCenter == null)
            {
                frmRptCostCenter objfrm = new frmRptCostCenter();
                objfrm.strReportName = "Ledger";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptCostCenter objfrm = (frmRptCostCenter)Application.OpenForms["frmRptCostCenter"];
                objfrm.strReportName = "Ledger";
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
          
        }

        private void btnRptCostCategoryWise_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 125))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptCostCenter"] as frmRptCostCenter == null)
            {
                frmRptCostCenter objfrm = new frmRptCostCenter();
                objfrm.strReportName = "Category";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptCostCenter objfrm = (frmRptCostCenter)Application.OpenForms["frmRptCostCenter"];
                objfrm.strReportName = "Category";
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
          
        }

        private void btnRptCostCenterWise_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 126))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptCostCenter"] as frmRptCostCenter == null)
            {
                frmRptCostCenter objfrm = new frmRptCostCenter();
                objfrm.strReportName = "Cost Center";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptCostCenter objfrm = (frmRptCostCenter)Application.OpenForms["frmRptCostCenter"];
                objfrm.strReportName = "Cost Center";
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
          
        }
       
    }
}
