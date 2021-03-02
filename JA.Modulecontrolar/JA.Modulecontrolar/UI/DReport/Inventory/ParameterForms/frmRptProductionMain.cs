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
using JA.Modulecontrolar.UI.DReport.Inventory.Viewer;
using Microsoft.Win32;
namespace JA.Modulecontrolar.UI.DReport.Inventory.ParameterForms
{
    public partial class frmRptProductionMain : JA.Shared.UI.frmSmartFormStandard
    {
       
       
        private string strComID { get; set; }
        public frmRptProductionMain()
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
     

        private void btnRptMonthlyProduction_Click(object sender, EventArgs e)
        {
            //if (Utility.gblnAccessControl)
            //{
            //    if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 93))
            //    {
            //        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }
            //}
            if (System.Windows.Forms.Application.OpenForms["frmRptProduction"] as frmRptProduction == null)
            {
                frmRptProduction objfrm = new frmRptProduction();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;
            }
            else
            {
                frmRptProduction objfrm = (frmRptProduction)Application.OpenForms["frmRptProduction"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnLocationWiseConsumtion_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 80))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptLocationConsumtion"] as frmRptLocationConsumtion == null)
            {
                frmRptLocationConsumtion objfrm = new frmRptLocationConsumtion();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptLocationConsumtion objfrm = (frmRptLocationConsumtion)Application.OpenForms["frmRptLocationConsumtion"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }

        }
    }
}
