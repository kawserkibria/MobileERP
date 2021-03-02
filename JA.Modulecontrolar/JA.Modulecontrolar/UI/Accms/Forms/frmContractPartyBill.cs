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

namespace JA.Modulecontrolar.UI.Accms.Forms
{
    public partial class frmContractPartyBill : JA.Shared.UI.frmSmartFormStandard
    {
        private string strComID { get; set; }
        public frmContractPartyBill()
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

        private void btnContractPartyBill0_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 129))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptDailyCollection"] as frmRptDailyCollection == null)
            {
                frmRptDailyCollection objfrm = new frmRptDailyCollection();
                objfrm.strReportName = "Contract Bill";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptDailyCollection objfrm = (frmRptDailyCollection)Application.OpenForms["frmRptDailyCollection"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnContractPartyBill1_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 133))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptDailyCollection"] as frmRptDailyCollection == null)
            {
                frmRptDailyCollection objfrm = new frmRptDailyCollection();
                objfrm.strReportName = "Contract Party Bill";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptDailyCollection objfrm = (frmRptDailyCollection)Application.OpenForms["frmRptDailyCollection"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

       

       
       

     
    }
}
