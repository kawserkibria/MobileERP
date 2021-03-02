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
    public partial class frmStockMain : JA.Shared.UI.frmSmartFormStandard
    {
        private string strComID { get; set; }
        public frmStockMain()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmProductionMain_KeyDown);
        }
        private void frmProductionMain_KeyDown(object sender, KeyEventArgs e)
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
 
        private void btnStockStatement_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 81))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptStockSummarry"] as frmRptStockSummarry == null)
            {
                frmRptStockSummarry objfrm = new frmRptStockSummarry();
                objfrm.strName = "S";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptStockSummarry objfrm = (frmRptStockSummarry)Application.OpenForms["frmRptStockSummarry"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }

        }

        private void btnStockStatementSumm_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 82))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptStockSummarry"] as frmRptStockSummarry == null)
            {
                frmRptStockSummarry objfrm = new frmRptStockSummarry();
                objfrm.strName = "Su";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptStockSummarry objfrm = (frmRptStockSummarry)Application.OpenForms["frmRptStockSummarry"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }

        }
       
    }
}
