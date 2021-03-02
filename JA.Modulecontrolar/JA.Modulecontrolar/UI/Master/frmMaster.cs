using Dutility;
using JA.Modulecontrolar.UI.Accms.Forms;
//using JA.Modulecontrolar.UI.DReport.Inventory;
using JA.Modulecontrolar.UI.DReport.Inventory.ParameterForms;
using JA.Modulecontrolar.UI.DReport.Sales.ParameterForms;
using JA.Modulecontrolar.UI.Master;
using JA.Modulecontrolar.UI.Master.Sales;
using JA.Modulecontrolar.UI.Sales.Forms;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JA.Modulecontrolar.UI.Master
{
    public partial class frmMaster : Form
    {
        private string strComID { get; set; }
        public frmMaster()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMaster_KeyDown);
        }

        private void frmMaster_KeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

 

        private void btnCategory_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 56))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }

            if (System.Windows.Forms.Application.OpenForms["frmStockCategory"] as frmStockCategory == null)
            {
                frmStockCategory objfrm = new frmStockCategory();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.lngFormPriv = 56;
                objfrm.strFormName = "Pack Size";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmStockCategory objfrm = (frmStockCategory)Application.OpenForms["frmStockCategory"];
                objfrm.strFormName = "Pack Size";
                objfrm.lngFormPriv = 56;
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }

           
        }

        private void btnUnitMeasurement_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 60))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmMeasurementUnit"] as frmMeasurementUnit == null)
            {
                frmMeasurementUnit objfrm = new frmMeasurementUnit();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.lngFormPriv = 60;
                objfrm.strFormName = "Measurement Unit";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmMeasurementUnit objfrm = (frmMeasurementUnit)Application.OpenForms["frmMeasurementUnit"];
                objfrm.strFormName = "Measurement Unit";
                objfrm.lngFormPriv = 60;
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
          
        }

        private void btnLocation_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 58))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmLocation"] as frmLocation == null)
            {
                frmLocation objfrm = new frmLocation();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.lngFormPriv = 58;
                objfrm.strFormName = "Location";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmLocation objfrm = (frmLocation)Application.OpenForms["frmLocation"];
                objfrm.strFormName = "Location";
                objfrm.lngFormPriv = 58;
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }

         
        }

        private void btnProcessInformation_Click(object sender, EventArgs e)
        {

            if (System.Windows.Forms.Application.OpenForms["frmProcessM"] as frmProcessM == null)
            {
                frmProcessM objfrm = new frmProcessM();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmProcessM objfrm = (frmProcessM)Application.OpenForms["frmProcessM"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }

         
        }

        private void btnVoucherTypes_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 63))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }

            if (System.Windows.Forms.Application.OpenForms["frmVoucherTypesList"] as frmVoucherTypesList == null)
            {
                frmVoucherTypesList objfrm = new frmVoucherTypesList();
                objfrm.MdiParent = this.MdiParent;
                objfrm.lngMtype = (long)Utility.MODULE_TYPE.mtSTOCK;
                objfrm.lngFormPriv = 63;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmVoucherTypesList objfrm = (frmVoucherTypesList)Application.OpenForms["frmVoucherTypesList"];
                objfrm.lngFormPriv = 63;
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
            

           
        }
        private void btnBatch_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName,62))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmBatchconfig"] as frmBatchconfig == null)
            {
                frmBatchconfig objfrm = new frmBatchconfig();
                objfrm.MdiParent = this.MdiParent;
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.lngFormPriv = 62;
                objfrm.strFormName = "Batch Configuration";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmBatchconfig objfrm = (frmBatchconfig)Application.OpenForms["frmBatchconfig"];
                objfrm.strFormName = "Batch Configuration";
                objfrm.lngFormPriv = 62;
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
              
          
        }

        private void btnOthersCategory_Click(object sender, EventArgs e)
        {
            //if (System.Windows.Forms.Application.OpenForms["frmStockOthersCategory"] as frmStockOthersCategory == null)
            //{
            //    frmStockOthersCategory objfrm = new frmStockOthersCategory();
            //    objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            //    objfrm.Show();
            //    objfrm.MdiParent = this.MdiParent;

            //}
            //else
            //{
            //    frmStockOthersCategory objfrm = (frmStockOthersCategory)Application.OpenForms["frmStockOthersCategory"];
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}
            
        }

        private void btnStockInformation_Click(object sender, EventArgs e)
        {
            //if (System.Windows.Forms.Application.OpenForms["frmRptStockInformation"] as frmRptStockInformation == null)
            //{
            //    frmRptStockInformation objfrm = new frmRptStockInformation();
            //    objfrm.Show();
            //    objfrm.MdiParent = this.MdiParent;

            //}
            //else
            //{
            //    frmRptStockInformation objfrm = (frmRptStockInformation)Application.OpenForms["frmRptStockInformation"];
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}
           
        }

        private void btnStockDamage_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 70))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmStockProduction"] as frmStockProduction == null)
            {
                frmStockProduction objfrm = new frmStockProduction();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.mintVtype = (int)Utility.VOUCHER_TYPE.vtSTOCK_DAMAGE;
                objfrm.lngFormPriv = 70;
                objfrm.strFormName = "Stock Damage";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmStockProduction objfrm = (frmStockProduction)Application.OpenForms["frmStockProduction"];
                objfrm.strFormName = "Stock Damage";
                objfrm.lngFormPriv = 70;
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
           
        }

        private void btnStoreLedger_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 77))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptStoreLedger"] as frmRptStoreLedger == null)
            {
                frmRptStoreLedger objfrm = new frmRptStoreLedger();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptStoreLedger objfrm = (frmRptStoreLedger)Application.OpenForms["frmRptStoreLedger"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
           
        }

        private void btnVoucherReports_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 78))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptVoucherReports"] as frmRptVoucherReports == null)
            {
                frmRptVoucherReports objfrm = new frmRptVoucherReports();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptVoucherReports objfrm = (frmRptVoucherReports)Application.OpenForms["frmRptVoucherReports"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
           
        }

        private void btnGroupConfiguration_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["frmCommissionM"] as frmCommissionM == null)
            {
                frmCommissionM objfrm = new frmCommissionM();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmCommissionM objfrm = (frmCommissionM)Application.OpenForms["frmCommissionM"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
            

           
        }

        private void btnCommissionConfig_Click(object sender, EventArgs e)
        {
          

          
        }

        private void btnSection_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["frmSection"] as frmSection == null)
            {
                frmSection objfrm = new frmSection();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmSection objfrm = (frmSection)Application.OpenForms["frmSection"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
           
        }

        private void btnMaterialType_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 59))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmMaterialType"] as frmMaterialType == null)
            {
                frmMaterialType objfrm = new frmMaterialType();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.lngFormPriv = 59;
                objfrm.strFormName = "Material Type";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmMaterialType objfrm = (frmMaterialType)Application.OpenForms["frmMaterialType"];
                objfrm.strFormName = "Material Type";
                objfrm.lngFormPriv = 59;
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
            
        }

        private void btnConsumption_Click(object sender, EventArgs e)
        {
            //if (Utility.gblnAccessControl)
            //{
            //    if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 66))
            //    {
            //         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
            //        return;
            //    }
            //}
            //if (System.Windows.Forms.Application.OpenForms["frmMFGStockProduction"] as frmMFGStockProduction == null)
            //{
            //    frmMFGStockProduction objfrm = new frmMFGStockProduction();
            //    objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            //    objfrm.intvType = (int)Utility.VOUCHER_TYPE.vtSTOCK_MFG_CONSUMPTION;
            //    objfrm.lngFormPriv = 66;
            //    objfrm.strFormName = "Consumption";
            //    objfrm.Show();
            //    objfrm.MdiParent = this.MdiParent;

            //}
            //else
            //{
            //    frmMFGStockProduction objfrm = (frmMFGStockProduction)Application.OpenForms["frmMFGStockProduction"];
            //    objfrm.strFormName = "Consumption";
            //    objfrm.lngFormPriv = 66;
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}
            
        }

        private void btnPhysicalStock_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 71))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmStockProduction"] as frmStockProduction == null)
            {
                frmStockProduction objfrm = new frmStockProduction();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.mintVtype = (int)Utility.VOUCHER_TYPE.vtSTOCK_PHYSICAL;
                objfrm.lngFormPriv = 71;
                objfrm.strFormName = "Physical Stock";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmStockProduction objfrm = (frmStockProduction)Application.OpenForms["frmStockProduction"];
                objfrm.strFormName = "Physical Stock";
                objfrm.lngFormPriv = 71;
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
           
        }

        //private void btnStockTransfer_Click(object sender, EventArgs e)
        //{
        //    if (Utility.gblnAccessControl)
        //    {
        //        if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 72))
        //        {
        //             MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
        //            return;
        //        }
        //    }
        //    if (System.Windows.Forms.Application.OpenForms["frmStockTransfer"] as frmStockTransfer == null)
        //    {
        //        frmStockTransfer objfrm = new frmStockTransfer();
        //        objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
        //        objfrm.mintVtype = (int)Utility.VOUCHER_TYPE.vtSTOCK_TRANSFER;
        //        objfrm.lngFormPriv = 72;
        //        objfrm.strFormName = "Stock Transfer";
        //        objfrm.Show();
        //        objfrm.MdiParent = this.MdiParent;

        //    }
        //    else
        //    {
        //        frmStockTransfer objfrm = (frmStockTransfer)Application.OpenForms["frmStockTransfer"];
        //        objfrm.strFormName = "Stock Transfer";
        //        objfrm.lngFormPriv = 72;
        //        objfrm.Focus();
        //        objfrm.MdiParent = this.MdiParent;
        //    }
           
        //}

        private void btnStockItem_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 61))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmStockItem"] as frmStockItem == null)
            {
                frmStockItem objfrm = new frmStockItem();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.lngFormPriv = 61;
                objfrm.strFormName = "Stock Item";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmStockItem objfrm = (frmStockItem)Application.OpenForms["frmStockItem"];
                objfrm.strFormName = "Stock Item";
                objfrm.lngFormPriv = 61;
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
          
    
        }

        private void btnComversionFG_Click(object sender, EventArgs e)
        {
            //if (Utility.gblnAccessControl)
            //{
            //    if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 69))
            //    {
            //         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
            //        return;
            //    }
            //}
            //if (System.Windows.Forms.Application.OpenForms["frmMFGVoucherConversion"] as frmMFGVoucherConversion == null)
            //{
            //    frmMFGVoucherConversion objfrm = new frmMFGVoucherConversion();
            //    objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            //    objfrm.intvType = (int)Utility.VOUCHER_TYPE.vtSTOCK_MFG_VOUCHER;
            //    objfrm.lngFormPriv = 69;
            //    objfrm.strFormName = "Conversion FG";
            //    objfrm.Show();
            //    objfrm.MdiParent = this.MdiParent;

            //}
            //else
            //{
            //    frmMFGVoucherConversion objfrm = (frmMFGVoucherConversion)Application.OpenForms["frmMFGVoucherConversion"];
            //    objfrm.strFormName = "Conversion FG";
            //    objfrm.lngFormPriv = 69;
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}

           
        }

        private void btnProfitability_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 79))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptProfitability"] as frmRptProfitability == null)
            {
                frmRptProfitability objfrm = new frmRptProfitability();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptProfitability objfrm = (frmRptProfitability)Application.OpenForms["frmRptProfitability"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
          
        }

        private void btnFgtoFg_Click(object sender, EventArgs e)
        {
            
           
        }

        private void btnStockSummCPrice_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 73))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            //if (System.Windows.Forms.Application.OpenForms["frmRptStockInformation"] as frmRptStockInformation == null)
            //{
            //    frmRptStockInformation objfrm = new frmRptStockInformation();
            //    objfrm.strType = "C";
            //    objfrm.Show();
            //    objfrm.MdiParent = this.MdiParent;

            //}
            //else
            //{
            //    frmRptStockInformation objfrm = (frmRptStockInformation)Application.OpenForms["frmRptStockInformation"];
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}
            if (System.Windows.Forms.Application.OpenForms["frmRptStockInformation_N"] as frmRptStockInformation_N == null)
            {
                frmRptStockInformation_N objfrm = new frmRptStockInformation_N();
                objfrm.strType = "C";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptStockInformation_N objfrm = (frmRptStockInformation_N)Application.OpenForms["frmRptStockInformation_N"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
          
        }

        private void btnStockSummSPrice_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 74))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptStockSummSPrice"] as frmRptStockSummSPrice == null)
            {
                frmRptStockSummSPrice objfrm = new frmRptStockSummSPrice();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptStockSummSPrice objfrm = (frmRptStockSummSPrice)Application.OpenForms["frmRptStockSummSPrice"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
         
        }

        private void btnStockSummIPrice_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 75))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptStockSummarry"] as frmRptStockSummarry == null)
            {
                frmRptStockSummarry objfrm = new frmRptStockSummarry();
                objfrm.strName = "I";
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

       

        private void btnLocationWiseConsumtion_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 80))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
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

        private void btnStockStatement_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 81))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
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

        private void btnLocationSumm_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 76))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptStockInformation"] as frmRptStockInformation == null)
            {
                frmRptStockInformation objfrm = new frmRptStockInformation();
                objfrm.strType = "L";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptStockInformation objfrm = (frmRptStockInformation)Application.OpenForms["frmRptStockInformation"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
           
        }

        private void btnStockStatementSumm_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 82))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
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

        private void btnProductTopSheet_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 83))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptProduct"] as frmRptProduct == null)
            {
                frmRptProduct objfrm = new frmRptProduct();
                objfrm.strName = "T";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptProduct objfrm = (frmRptProduct)Application.OpenForms["frmRptProduct"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
          
        }

        private void btnProductStatement_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 84))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptProduct"] as frmRptProduct == null)
            {
                frmRptProduct objfrm = new frmRptProduct();
                objfrm.strName = "PS";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptProduct objfrm = (frmRptProduct)Application.OpenForms["frmRptProduct"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
           
        }

        private void btnGroupCommission_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 85))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptGroupCommission"] as frmRptGroupCommission == null)
            {
                frmRptGroupCommission objfrm = new frmRptGroupCommission();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptGroupCommission objfrm = (frmRptGroupCommission)Application.OpenForms["frmRptGroupCommission"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
           
        }

        private void btnStockRegister_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 87))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptStockRegister"] as frmRptStockRegister == null)
            {
                frmRptStockRegister objfrm = new frmRptStockRegister();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptStockRegister objfrm = (frmRptStockRegister)Application.OpenForms["frmRptStockRegister"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
           
        }

        private void btnTopSheetSalesPrice_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 88))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptProductN"] as frmRptProductN == null)
            {
                frmRptProductN objfrm = new frmRptProductN();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptProductN objfrm = (frmRptProductN)Application.OpenForms["frmRptProductN"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        
        }

        private void btnProcessReport_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 89))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptMFGProcess"] as frmRptMFGProcess == null)
            {
                frmRptMFGProcess objfrm = new frmRptMFGProcess();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptMFGProcess objfrm = (frmRptMFGProcess)Application.OpenForms["frmRptMFGProcess"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
          
        }

        private void btnSlowFastMoving_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 86))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptSlowFastMoving"] as frmRptSlowFastMoving == null)
            {
                frmRptSlowFastMoving objfrm = new frmRptSlowFastMoving();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptSlowFastMoving objfrm = (frmRptSlowFastMoving)Application.OpenForms["frmRptSlowFastMoving"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
           
        }

        private void btnStockSummPValue_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 90))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptStockSummarry"] as frmRptStockSummarry == null)
            {
                frmRptStockSummarry objfrm = new frmRptStockSummarry();
                objfrm.strName = "P";
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

        private void btnBOmRegister_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 91))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptStockSummarry"] as frmRptBOMList == null)
            {
                frmRptBOMList objfrm = new frmRptBOMList();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;
            }
            else
            {
                frmRptBOMList objfrm = (frmRptBOMList)Application.OpenForms["frmRptBOMList"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
          
        }

        private void btnNetegivestock_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 92))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptNegetive"] as frmRptNegetive == null)
            {
                frmRptNegetive objfrm = new frmRptNegetive();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;
            }
            else
            {
                frmRptNegetive objfrm = (frmRptNegetive)Application.OpenForms["frmRptNegetive"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
          
        }

        private void btnItemWiseLocationQty_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 93))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptLocationWiseQty"] as frmRptLocationWiseQty == null)
            {
                frmRptLocationWiseQty objfrm = new frmRptLocationWiseQty();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;
            }
            else
            {
                frmRptLocationWiseQty objfrm = (frmRptLocationWiseQty)Application.OpenForms["frmRptLocationWiseQty"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
           
        }
        private void btnRptProduction_Click(object sender, EventArgs e)
        {
            //if (Utility.gblnAccessControl)
            //{
            //    if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 192))
            //    {
            //        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }
            //}
            if (System.Windows.Forms.Application.OpenForms["frmRptProductionMain"] as frmRptProductionMain == null)
            {
                frmRptProductionMain objfrm = new frmRptProductionMain();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;
            }
            else
            {
                frmRptProductionMain objfrm = (frmRptProductionMain)Application.OpenForms["frmRptProductionMain"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnProduction_Click(object sender, EventArgs e)
        {
            //if (Utility.gblnAccessControl)
            //{
            //    if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 66))
            //    {
            //        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }
            //}
            if (System.Windows.Forms.Application.OpenForms["frmProductionMain"] as frmProductionMain == null)
            {
                frmProductionMain objfrm = new frmProductionMain();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmProductionMain objfrm = (frmProductionMain)Application.OpenForms["frmProductionMain"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

       
        private void btnGroup_Click(object sender, EventArgs e)
        {

            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 1))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmGroupConfiguration"] as frmGroupConfiguration == null)
            {
                frmGroupConfiguration objfrm = new frmGroupConfiguration();
                objfrm.inttype = (int)Utility.GR_GROUP_TYPE.grCUSTOMER;
                objfrm.lngFormPriv = 1;
                objfrm.intModuleType = (int)Utility.MODULE_TYPE.mtSALES;
                objfrm.strFoemName = "MPO Group";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }

            else
            {
                frmGroupConfiguration objfrm = (frmGroupConfiguration)Application.OpenForms["frmGroupConfiguration"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void frmMaster_Load(object sender, EventArgs e)
        {
            //if (e.KeyCode == Keys.Escape)
            //{
            //    var strResponse = MessageBox.Show("                    Quit                    ", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (strResponse == DialogResult.Yes)
            //    {
            //        this.Dispose();
            //    }
            //}
            //else if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            //{
            //    btnGroupConfiguration_Click(sender, e);
            //}
            //else if (e.KeyCode == Keys.G && e.Modifiers == Keys.Control)
            //{
            //    btnCustomer_Click(sender, e);
            //}
            //else if (e.KeyCode == Keys.L && e.Modifiers == Keys.Control)
            //{
            //    btnLocation_Click(sender, e);
            //}
            //else if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
            //{
            //    btnStockItem_Click(sender, e);
            //}
            //else if (e.KeyCode == Keys.F && e.Modifiers == Keys.Control)
            //{
            //    btnFinishedGoods_Click(sender, e);
            //}
            //else if (e.KeyCode == Keys.M && e.Modifiers == Keys.Control)
            //{
            //    btnMFGVoucher_Click(sender, e);
            //}
            //else if (e.KeyCode == Keys.O && e.Modifiers == Keys.Control)
            //{
            //    btnComversionFG_Click(sender, e);
            //}
            //else if (e.KeyCode == Keys.T && e.Modifiers == Keys.Control)
            //{
            //    //btnStockTransfer_Click(sender, e);
            //}
            //else if (e.KeyCode == Keys.P && e.Modifiers == Keys.Control)
            //{
            //    btnPhysicalStock_Click(sender, e);
            //}
            //else if (e.KeyCode == Keys.D && e.Modifiers == Keys.Control)
            //{
            //    btnStockDamage_Click(sender, e);
            //}
        }

        private void btnTeritorry_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 3))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmTeritorry"] as frmTeritorry == null)
            {
               JA.Modulecontrolar.UI.Master.Sales.frmTeritorry objfrm = new frmTeritorry();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.lngFormPriv = 3;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmTeritorry objfrm = (frmTeritorry)Application.OpenForms["frmTeritorry"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnSalesRep_Click(object sender, EventArgs e)
        {

            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 4))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmSalesRepresentive"] as frmSalesRepresentive == null)
            {
                frmSalesRepresentive objfrm = new frmSalesRepresentive();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.lngFormPriv = 4;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmSalesRepresentive objfrm = (frmSalesRepresentive)Application.OpenForms["frmSalesRepresentive"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnStockGroup_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 55))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (System.Windows.Forms.Application.OpenForms["frmStockGroup"] as frmStockGroup == null)
            {
                frmStockGroup objfrm = new frmStockGroup();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.lngFormPriv = 55;
                objfrm.strFormName = "Stock Group";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmStockGroup objfrm = (frmStockGroup)Application.OpenForms["frmStockGroup"];
                objfrm.strFormName = "Stock Group";
                objfrm.lngFormPriv = 55;
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }

        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 2))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmCustomer"] as frmCustomer == null)
            {
                frmCustomer objfrm = new frmCustomer();
                objfrm.m_acction = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.intvtype = (int)Utility.GR_GROUP_TYPE.grCUSTOMER;
                objfrm.lngFormPriv = 2;
                objfrm.intModuleType = (int)Utility.MODULE_TYPE.mtSALES;
                objfrm.strFormname = "Medical Representative";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmCustomer objfrm = (frmCustomer)Application.OpenForms["frmCustomer"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnVoucherTypesS_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 5))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmVoucherTypesList"] as frmVoucherTypesList == null)
            {
                frmVoucherTypesList objfrm = new frmVoucherTypesList();
                objfrm.lngMtype = (long)Utility.MODULE_TYPE.mtSALES;
                objfrm.lngFormPriv = 5;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmVoucherTypesList objfrm = (frmVoucherTypesList)Application.OpenForms["frmVoucherTypesList"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
          
        }

        private void btnPriceLevel_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 6))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmPriceLevel"] as frmPriceLevel == null)
            {
                frmPriceLevel objfrm = new frmPriceLevel();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.lngFormPriv = 6;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmPriceLevel objfrm = (frmPriceLevel)Application.OpenForms["frmPriceLevel"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnSalesPriceConfig_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 7))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmPriceConfig"] as frmPriceConfig == null)
            {
                frmPriceConfig objfrm = new frmPriceConfig();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.lngFormPriv = 7;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmPriceConfig objfrm = (frmPriceConfig)Application.OpenForms["frmPriceConfig"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnBonus_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 9))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmBonus"] as frmBonus == null)
            {
                frmBonus objfrm = new frmBonus();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.lngFormPriv = 9;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmBonus objfrm = (frmBonus)Application.OpenForms["frmBonus"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnItemWiseTarget_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 159))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (System.Windows.Forms.Application.OpenForms["frmItem_PowerClassWiseTarget"] as frmRptProductShortDetails == null)
            {
                frmItem_PowerClassWiseTarget objfrm = new frmItem_PowerClassWiseTarget();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.strSelection = "Item/Pack Size Wise Target";
                objfrm.lngFormPriv = 159;
                objfrm.Show();
                objfrm.MdiParent = MdiParent;

            }
            else
            {
                frmItem_PowerClassWiseTarget objfrm = (frmItem_PowerClassWiseTarget)Application.OpenForms["frmItem_PowerClassWiseTarget"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnBranch_Click(object sender, EventArgs e)
        {

        }

  

    
       

        

        

     
    

     
      
    }
}
