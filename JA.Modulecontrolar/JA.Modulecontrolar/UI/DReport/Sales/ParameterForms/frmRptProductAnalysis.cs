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
    public partial class frmRptProductAnalysis : JA.Shared.UI.frmSmartFormStandard
    {
       
        public string strSelection { get; set; }
        private string strComID { get; set; }
        public frmRptProductAnalysis()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

        }




        private void frmRptProductAnalysis_Load(object sender, EventArgs e)
        {
            frmLabel.Text = strSelection;
        }

        private void btnSalesTarget_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 24))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptProductwiseAnalysis"] as frmRptProductwiseAnalysis == null)
            {
                frmRptProductwiseAnalysis objfrm = new frmRptProductwiseAnalysis();
                objfrm.strReportName = "Sales";
                objfrm.Show();
                objfrm.MdiParent = MdiParent;

            }
            else
            {
                frmRptProductwiseAnalysis objfrm = (frmRptProductwiseAnalysis)Application.OpenForms["frmRptProductwiseAnalysis"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnProductSalesAnalysis_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 170))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptProductwiseAnalysis"] as frmRptProductwiseAnalysis == null)
            {
                frmRptMpoProductWiseSalesSatQty objfrm = new frmRptMpoProductWiseSalesSatQty();
                objfrm.strReportName = "Sales";
                objfrm.Show();
                objfrm.MdiParent = MdiParent;

            }
            else
            {
                frmRptMpoProductWiseSalesSatQty objfrm = (frmRptMpoProductWiseSalesSatQty)Application.OpenForms["frmRptMpoProductWiseSalesSatQty"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnYearlyProductSales_Click(object sender, EventArgs e)
        {
            //if (Utility.gblnAccessControl)
            //{
            //    if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 170))
            //    {
            //        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }
            //}
            if (System.Windows.Forms.Application.OpenForms["frmRptProductWiseSalesSatQty12month"] as frmRptProductWiseSalesSatQty12month == null)
            {
                frmRptProductWiseSalesSatQty12month objfrm = new frmRptProductWiseSalesSatQty12month();
                objfrm.strReportName = "Yearly Product Sales";
                objfrm.Show();
                objfrm.MdiParent = MdiParent;

            }
            else
            {
                frmRptProductWiseSalesSatQty12month objfrm = (frmRptProductWiseSalesSatQty12month)Application.OpenForms["frmRptProductWiseSalesSatQty12month"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        
    }
}
