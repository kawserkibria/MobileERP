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
    public partial class frmRptProductShortMultiple : JA.Shared.UI.frmSmartFormStandard
    {
       
        public string strSelection { get; set; }
        private string strComID { get; set; }
        public frmRptProductShortMultiple()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

        }




        private void frmRptProductShortMultiple_Load(object sender, EventArgs e)
        {
            frmLabel.Text = strSelection;
        }

        private void btnSalesTarget_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 29))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptProductShort"] as frmRptProductShort == null)
            {
                frmRptProductShort objfrm = new frmRptProductShort();
                objfrm.Show();
                objfrm.MdiParent = MdiParent;

            }
            else
            {
                frmRptProductShort objfrm = (frmRptProductShort)Application.OpenForms["frmRptProductShort"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnProduct12Month_Click(object sender, EventArgs e)
        {
            //if (Utility.gblnAccessControl)
            //{
            //    if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 30))
            //    {
            //        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }
            //}
            if (System.Windows.Forms.Application.OpenForms["frmRptProductShortDetails"] as frmRptProductShortDetails == null)
            {
                frmRptProductShortDetails objfrm = new frmRptProductShortDetails();
                objfrm.strSelection = "B";
                objfrm.Show();
                objfrm.MdiParent = MdiParent;

            }
            else
            {
                frmRptProductShortDetails objfrm = (frmRptProductShortDetails)Application.OpenForms["frmRptProductShortDetails"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }

        }

        private void btnProductSales_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 30))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptProductShortDetails"] as frmRptProductShortDetails == null)
            {
                frmRptProductShortDetails objfrm = new frmRptProductShortDetails();
                objfrm.strSelection = "A";
                objfrm.Show();
                objfrm.MdiParent = MdiParent;

            }
            else
            {
                frmRptProductShortDetails objfrm = (frmRptProductShortDetails)Application.OpenForms["frmRptProductShortDetails"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

    }
}
