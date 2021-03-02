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
    public partial class frmRptYearCompare : JA.Shared.UI.frmSmartFormStandard
    {
       
        public string strSelection { get; set; }
        private string strComID { get; set; }
        public frmRptYearCompare()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

        }




        private void frmRptYearCompare_Load(object sender, EventArgs e)
        {
            frmLabel.Text = "Yearly Compare";
        }

        private void btnRptCPSPYearCompare_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 189))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptYearlyCPSPAnalysis"] as frmRptYearlyCPSPAnalysis == null)
            {
                frmRptYearlyCPSPAnalysis objfrm = new frmRptYearlyCPSPAnalysis();
                objfrm.strReportName = "Yealy CP/SP Analysis";
                objfrm.Show();
                objfrm.MdiParent = MdiParent;

            }
            else
            {
                frmRptYearlyCPSPAnalysis objfrm = (frmRptYearlyCPSPAnalysis)Application.OpenForms["frmRptYearlyCPSPAnalysis"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        //private void btnSalesTarget_Click(object sender, EventArgs e)
        //{
        //    if (Utility.gblnAccessControl)
        //    {
        //        if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 24))
        //        {
        //            MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }
        //    }
        //    if (System.Windows.Forms.Application.OpenForms["frmRptProductwiseAnalysis"] as frmRptProductwiseAnalysis == null)
        //    {
        //        frmRptProductwiseAnalysis objfrm = new frmRptProductwiseAnalysis();
        //        objfrm.strReportName = "Sales";
        //        objfrm.Show();
        //        objfrm.MdiParent = MdiParent;

        //    }
        //    else
        //    {
        //        frmRptProductwiseAnalysis objfrm = (frmRptProductwiseAnalysis)Application.OpenForms["frmRptProductwiseAnalysis"];
        //        objfrm.Focus();
        //        objfrm.MdiParent = this.MdiParent;
        //    }
        //}

       

        
    }
}
