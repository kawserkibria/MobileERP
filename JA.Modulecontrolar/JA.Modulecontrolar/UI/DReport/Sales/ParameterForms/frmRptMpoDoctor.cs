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
using JA.Modulecontrolar.UI.DReport.Purchase.ParameterForms;
namespace JA.Modulecontrolar.UI.DReport.Sales.ParameterForms
{
    public partial class frmRptMpoDoctor : JA.Shared.UI.frmSmartFormStandard
    {
       
        public string strSelection { get; set; }
        private string strComID { get; set; }
        public frmRptMpoDoctor()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

        }

        private void btnMpoList_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 22))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptMpolist"] as frmRptMpolist == null)
            {
                frmRptMpolist objfrm = new frmRptMpolist();
                objfrm.Show();
                objfrm.MdiParent = MdiParent;

            }
            else
            {
                frmRptMpolist objfrm = (frmRptMpolist)Application.OpenForms["frmRptMpolist"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnCustomerList_Click(object sender, EventArgs e)
        {

            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 40))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptSuppliersList"] as frmRptSuppliersList == null)
            {
                frmRptSuppliersList objfrm = new frmRptSuppliersList();
                objfrm.strSelection = "Sales";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptSuppliersList objfrm = (frmRptSuppliersList)Application.OpenForms["frmRptSuppliersList"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void frmRptMpoDoctor_Load(object sender, EventArgs e)
        {
            this.Text = strSelection;
            frmLabel.Text = strSelection;
        }




        

       

        
    }
}
