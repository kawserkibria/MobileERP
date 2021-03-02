using Dutility;
using JA.Modulecontrolar.UI.DReport.Purchase.ParameterForms;
using JA.Modulecontrolar.UI.DReport.Sales.ParameterForms;
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
    public partial class frmStatement : JA.Shared.UI.frmSmartFormStandard
    {
        private string strComID { get; set; }
        public frmStatement()
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

        private void btnRptSalesStatement_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 25))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptSalesStatement"] as frmRptSalesStatement == null)
            {
                frmRptSalesStatement objfrm = new frmRptSalesStatement();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptSalesStatement objfrm = (frmRptSalesStatement)Application.OpenForms["frmRptSalesStatement"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnCollectionStatement_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 196))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptCollStatement"] as frmRptCollStatement == null)
            {
                frmRptCollStatement objfrm = new frmRptCollStatement();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptCollStatement objfrm = (frmRptCollStatement)Application.OpenForms["frmRptCollStatement"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnrptCollectionStat_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 195))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptTCSales_Collection"] as frmRptTCSales_Collection == null)
            {
                frmRptTCSales_Collection objfrm = new frmRptTCSales_Collection();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptTCSales_Collection objfrm = (frmRptTCSales_Collection)Application.OpenForms["frmRptTCSales_Collection"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnSalesRegister_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 37))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptPurchaseRegister"] as frmRptPurchaseRegister == null)
            {
                frmRptPurchaseRegister objfrm = new frmRptPurchaseRegister();
                objfrm.strReportName = "Manufacturing";
                objfrm.strSelection = "SalesReg";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptPurchaseRegister objfrm = (frmRptPurchaseRegister)Application.OpenForms["frmRptPurchaseRegister"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnReturnRegister_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 38))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptPurchaseRegister"] as frmRptPurchaseRegister == null)
            {
                frmRptPurchaseRegister objfrm = new frmRptPurchaseRegister();
                //objfrm.strReportName = "Manufacturing";
                objfrm.strSelection = "ReturnReg";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptPurchaseRegister objfrm = (frmRptPurchaseRegister)Application.OpenForms["frmRptPurchaseRegister"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }



    }
}
