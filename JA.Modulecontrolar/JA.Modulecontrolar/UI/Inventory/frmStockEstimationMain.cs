using Dutility;
using JA.Modulecontrolar.UI.DReport.Inventory.ParameterForms;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JA.Modulecontrolar.UI.Inventory
{
    public partial class frmStockEstimationMain : JA.Shared.UI.frmSmartFormStandard
    {
        private string strComID { get; set; }
        public frmStockEstimationMain()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmStockEstimationMain_KeyDown);
        }
        private void frmStockEstimationMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                var strResponse = MessageBox.Show("                    Quit                    ", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponse == DialogResult.Yes)
                {
                    this.Dispose();
                }
            }
           
        }

        private void btnConsumption_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 209))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptChemical_Consumption"] as frmRptChemical_Consumption == null)
            {
                frmRptChemical_Consumption objfrm = new frmRptChemical_Consumption();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptChemical_Consumption objfrm = (frmRptChemical_Consumption)Application.OpenForms["frmRptChemical_Consumption"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }

        }

        private void btnMonthlyConsumption_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 208))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptConjumptionMonthly"] as frmRptConjumptionMonthly == null)
            {
                frmRptConjumptionMonthly objfrm = new frmRptConjumptionMonthly();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptConjumptionMonthly objfrm = (frmRptConjumptionMonthly)Application.OpenForms["frmRptConjumptionMonthly"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }

        }
       
    }
}
