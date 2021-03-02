using System;
using Dutility;
using JA.Modulecontrolar.JACCMS;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

using JA.Modulecontrolar.UI.Sales.Forms;


using JA.Modulecontrolar.UI.DReport.Purchase.ParameterForms;
using JA.Modulecontrolar.UI.DReport.Sales.ParameterForms;
using Microsoft.Win32;

namespace JA.Modulecontrolar.UI.Purchase.Forms
{
    public partial class frmPurchaseMenu : Form
    {
        private string strComID { get; set; }
        public frmPurchaseMenu()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPurchaseMenu_KeyDown);
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 42))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmSupplier"] as frmSupplier == null)
            {
                frmSupplier objfrm = new frmSupplier();
                objfrm.m_acction = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.intvtype = (int)Utility.GR_GROUP_TYPE.grSUPPLIER;
                objfrm.intModuleType = (int)Utility.MODULE_TYPE.mtPURCHASE;
                objfrm.lngFormPriv = 42;
                objfrm.strFormName = "Supplier";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmSupplier objfrm = (frmSupplier)Application.OpenForms["frmSupplier"];
                objfrm.lngFormPriv = 42;
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
           
        }

        private void frmPurchaseMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnPurchaseOrder_Click(object sender, EventArgs e)
        {
            //frmSalesOrder objfrm = new frmSalesOrder();
            //objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            //objfrm.mlngvtype = (long)Utility.VOUCHER_TYPE.vtPURCHASE_ORDER;
            //objfrm.Show();
            //objfrm.MdiParent = this.MdiParent;
        }

        private void btnPurchaseInvoice_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 44))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmPurchaseInvoice"] as frmPurchaseInvoice == null)
            {
                frmPurchaseInvoice objfrm = new frmPurchaseInvoice();
                objfrm.intVtype = (int)Utility.VOUCHER_TYPE.vtPURCHASE_INVOICE;
                objfrm.lngLedgeras = (int)Utility.GR_GROUP_TYPE.grSUPPLIER;
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.strFormName = "Purchase Invoice";
                objfrm.intModuleType = (int)Utility.MODULE_TYPE.mtPURCHASE;
                objfrm.lngFormPriv = 44;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmPurchaseInvoice objfrm = (frmPurchaseInvoice)Application.OpenForms["frmPurchaseInvoice"];
                objfrm.lngFormPriv = 44;
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
            
           
        }

        private void btnVoucherTypes_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 43))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            //if (System.Windows.Forms.Application.OpenForms["frmVoucherTypesList"] as frmVoucherTypesList == null)
            //{
            //    frmVoucherTypesList objfrm = new frmVoucherTypesList();
            //    objfrm.lngMtype = (long)Utility.MODULE_TYPE.mtPURCHASE;
            //    objfrm.lngFormPriv = 43;
            //    objfrm.Show();
            //    objfrm.MdiParent = this.MdiParent;

            //}
            //else
            //{
            //    frmVoucherTypesList objfrm = (frmVoucherTypesList)Application.OpenForms["frmVoucherTypesList"];
            //    objfrm.lngFormPriv = 43;
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}
           
        }

        private void btnPurchaseReturn_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 45))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            //if (System.Windows.Forms.Application.OpenForms["frmVoucherTypesList"] as frmVoucherTypesList == null)
            //{
            //    frmSalesReturn objfrm = new frmSalesReturn();
            //    objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            //    objfrm.intVtype = (int)Utility.VOUCHER_TYPE.vtPURCHASE_RETURN;
            //    objfrm.lngLedgeras = (int)Utility.GR_GROUP_TYPE.grSUPPLIER;
            //    objfrm.lngFormPriv = 45;
            //    objfrm.strFormName = "Purchase Return";
            //    objfrm.intModuletype = (int)Utility.MODULE_TYPE.mtPURCHASE;
            //    objfrm.Show();
            //    objfrm.MdiParent = this.MdiParent;

            //}
            //else
            //{
            //    frmVoucherTypesList objfrm = (frmVoucherTypesList)Application.OpenForms["frmVoucherTypesList"];
            //    objfrm.lngFormPriv = 45;
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}
           
        }

        private void btnGroups_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 41))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            //if (System.Windows.Forms.Application.OpenForms["frmGroupConfiguration"] as frmGroupConfiguration == null)
            //{
            //    frmGroupConfiguration objfrm = new frmGroupConfiguration();
            //    objfrm.inttype = (int)Utility.GR_GROUP_TYPE.grSUPPLIER;
            //    objfrm.lngFormPriv = 41;
            //    objfrm.strFoemName = "Group";
            //    objfrm.intModuleType = (int)Utility.MODULE_TYPE.mtPURCHASE;
            //    objfrm.Show();
            //    objfrm.MdiParent = this.MdiParent;

            //}
            //else
            //{
            //    frmGroupConfiguration objfrm = (frmGroupConfiguration)Application.OpenForms["frmGroupConfiguration"];
            //    objfrm.lngFormPriv = 41;
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}
           
        }

        private void btnSupplierslist_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 46))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptSuppliersList"] as frmRptSuppliersList == null)
            {
                frmRptSuppliersList objfrm = new frmRptSuppliersList();
                objfrm.strReportName = "Manufacturing";
                objfrm.strSelection = "Purchase";
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

        private void btnVoucherRPT_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 47))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptVoucherReport"] as frmRptVoucherReport == null)
            {
                frmRptVoucherReport objfrm = new frmRptVoucherReport();
                objfrm.strReportName = "Manufacturing";
                //objfrm.strSelection = "Sales";
                objfrm.strSelection = "Purchase";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptVoucherReport objfrm = (frmRptVoucherReport)Application.OpenForms["frmRptVoucherReport"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
           
        }

        private void btnPayables_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["frmRptPayables"] as frmRptPayables == null)
            {
                frmRptPayables objfrm = new frmRptPayables();
                objfrm.strReportName = "Manufacturing";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptPayables objfrm = (frmRptPayables)Application.OpenForms["frmRptPayables"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
           
        }

        private void btnPurchaseReports_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 48))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptPurchaseRegister"] as frmRptPurchaseRegister == null)
            {
                frmRptPurchaseRegister objfrm = new frmRptPurchaseRegister();
                objfrm.strReportName = "Manufacturing";
                //objfrm.strSelection = "SalesReg";
                objfrm.strSelection = "PurchaseReg";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptPurchaseRegister objfrm = (frmRptPurchaseRegister)Application.OpenForms["frmRptPurchaseRegister"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
            
            
        }

        private void btnReturnRegister_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 49))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptPurchaseRegister"] as frmRptPurchaseRegister == null)
            {
                frmRptPurchaseRegister objfrm = new frmRptPurchaseRegister();
                objfrm.strReportName = "Manufacturing";
                objfrm.strSelection = "PurchaseReturn";
                //objfrm.strSelection = "SalesReturn";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptPurchaseRegister objfrm = (frmRptPurchaseRegister)Application.OpenForms["frmRptPurchaseRegister"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
           
        }

        private void btnComponentPriceList_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["frmRptComponentPriceList"] as frmRptComponentPriceList == null)
            {
                frmRptComponentPriceList objfrm = new frmRptComponentPriceList();
                objfrm.strReportName = "Manufacturing";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptComponentPriceList objfrm = (frmRptComponentPriceList)Application.OpenForms["frmRptComponentPriceList"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
           
        }

        private void btnProductwiseAnalysis_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 50))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptProductwiseAnalysis"] as frmRptProductwiseAnalysis == null)
            {
                frmRptProductwiseAnalysis objfrm = new frmRptProductwiseAnalysis();
                objfrm.strReportName = "Purchase";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptProductwiseAnalysis objfrm = (frmRptProductwiseAnalysis)Application.OpenForms["frmRptProductwiseAnalysis"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
           
        }

        private void btnBranchwiseReport_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["frmRptBranchWiseReport"] as frmRptBranchWiseReport == null)
            {
                frmRptBranchWiseReport objfrm = new frmRptBranchWiseReport();
                objfrm.strReportName = "Manufacturing";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptBranchWiseReport objfrm = (frmRptBranchWiseReport)Application.OpenForms["frmRptBranchWiseReport"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
           
        }

      

        private void frmPurchaseMenu_KeyDown(object sender, KeyEventArgs e)
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

             

       

       

     
    }
}
