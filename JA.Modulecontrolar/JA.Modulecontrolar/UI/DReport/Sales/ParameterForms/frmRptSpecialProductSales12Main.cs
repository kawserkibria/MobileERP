using Dutility;
using JA.Modulecontrolar.JINVMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;
namespace JA.Modulecontrolar.UI.DReport.Sales.ParameterForms
{
    public partial class frmRptSpecialProductSales12Main : JA.Shared.UI.frmSmartFormStandard
    {
       
        public string strSelection { get; set; }
        private string strComID { get; set; }
        public frmRptSpecialProductSales12Main()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

        }

  


        private void frmRptSpecialProductSales12Main_Load(object sender, EventArgs e)
        {
            frmLabel.Text = strSelection;
        }

        private void btnSalesTarget_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 165))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptSpecialPartyReport"] as frmRptSpecialPartyReport == null)
            {
                frmRptSpecialProduct objfrm = new frmRptSpecialProduct();
                objfrm.strSelection = "Special Product Target";
                objfrm.strFromshow = "SpecialProductTarget";
                objfrm.Show();
                objfrm.MdiParent = MdiParent;

            }
            else
            {
                frmRptSpecialProduct objfrm = (frmRptSpecialProduct)Application.OpenForms["frmRptSpecialProduct"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnProduct12Month_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 167))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (System.Windows.Forms.Application.OpenForms["frmRptSpecialProduct"] as frmRptSpecialProduct == null)
            {
                frmRptSpecialProduct objfrm = new frmRptSpecialProduct();
                //objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.strSelection = "Product Wise Sales Summary ";
                objfrm.strFromshow = "12MonthSales";
                objfrm.Show();
                objfrm.MdiParent = MdiParent;

            }
            else
            {
                frmRptSpecialProduct objfrm = (frmRptSpecialProduct)Application.OpenForms["frmRptSpecialProduct"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }

        }

        private void btnProductSales_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 166))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (System.Windows.Forms.Application.OpenForms["frmRptSpecialProduct"] as frmRptSpecialProduct == null)
            {
                frmRptSpecialProduct objfrm = new frmRptSpecialProduct();
                //objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.strSelection = "Special Product Sales";
                objfrm.strFromshow = "PackSise";
                objfrm.Show();
                objfrm.MdiParent = MdiParent;

            }
            else
            {
                frmRptSpecialProduct objfrm = (frmRptSpecialProduct)Application.OpenForms["frmRptSpecialProduct"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

    }
}
