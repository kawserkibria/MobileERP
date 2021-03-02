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

namespace JA.Modulecontrolar.UI.Accms.Forms
{
    public partial class frmFinalAccounts : JA.Shared.UI.frmSmartFormStandard
    {
        private string strComID { get; set; }
        public frmFinalAccounts()
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

        private void btnBalanceSheet_Click(object sender, EventArgs e)
        {
          
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 122))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptAccounts"] as frmRptAccounts == null)
            {
                frmRptAccounts objfrm = new frmRptAccounts();
                objfrm.strReportName = "Balance sheet";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptAccounts objfrm = (frmRptAccounts)Application.OpenForms["frmRptAccounts"];
                objfrm.strReportName = "Balance sheet";
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnProfitLoss_Click(object sender, EventArgs e)
        {

            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 121))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptAccounts"] as frmRptAccounts == null)
            {
                frmRptAccounts objfrm = new frmRptAccounts();
                objfrm.strReportName = "Profit && Loss";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptAccounts objfrm = (frmRptAccounts)Application.OpenForms["frmRptAccounts"];
                objfrm.strReportName = "Profit && Loss";
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
            
           
        }

        private void btnTrading_Click(object sender, EventArgs e)
        {
            

            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 120))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptAccounts"] as frmRptAccounts == null)
            {
                frmRptAccounts objfrm = new frmRptAccounts();
                objfrm.strReportName = "Trading";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptAccounts objfrm = (frmRptAccounts)Application.OpenForms["frmRptAccounts"];
                objfrm.strReportName = "Trading";
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnCashFlow_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 119))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptStatistics"] as frmRptStatistics == null)
            {
                frmRptStatistics objfrm = new frmRptStatistics();
                objfrm.strReportName = "Cash Flow";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptStatistics objfrm = (frmRptStatistics)Application.OpenForms["frmRptStatistics"];
                objfrm.strReportName = "Cash Flow";
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
            
            
            
        }

       
    }
}
