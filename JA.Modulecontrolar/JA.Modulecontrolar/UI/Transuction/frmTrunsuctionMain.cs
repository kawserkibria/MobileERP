using Dutility;

//using JA.Modulecontrolar.UI.DReport.Inventory;
using JA.Modulecontrolar.UI.DReport.Inventory.ParameterForms;
using JA.Modulecontrolar.UI.DReport.Sales.ParameterForms;
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
using JA.Modulecontrolar.UI.Transuction.Inventory;

namespace JA.Modulecontrolar.UI.Transuction
{
    public partial class frmTrunsuctionMain : Form
    {
        private string strComID { get; set; }
        public frmTrunsuctionMain()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmInventoryMain_KeyDown);
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 55))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }

            //if (System.Windows.Forms.Application.OpenForms["frmStockGroup"] as frmStockGroup == null)
            //{
            //    frmStockGroup objfrm = new frmStockGroup();
            //    objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            //    objfrm.lngFormPriv = 55;
            //    objfrm.strFormName = "Stock Group";
            //    objfrm.MdiParent = this.MdiParent;
            //    objfrm.Show();

            //}
            //else
            //{
            //    frmStockGroup objfrm = (frmStockGroup)Application.OpenForms["frmStockGroup"];
            //    objfrm.strFormName = "Stock Group";
            //    objfrm.lngFormPriv = 55;
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}

          
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

            //if (System.Windows.Forms.Application.OpenForms["frmStockCategory"] as frmStockCategory == null)
            //{
            //    frmStockCategory objfrm = new frmStockCategory();
            //    objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            //    objfrm.lngFormPriv = 56;
            //    objfrm.strFormName = "Pack Size";
            //    objfrm.MdiParent = this.MdiParent;
            //    objfrm.Show();

            //}
            //else
            //{
            //    frmStockCategory objfrm = (frmStockCategory)Application.OpenForms["frmStockCategory"];
            //    objfrm.strFormName = "Pack Size";
            //    objfrm.lngFormPriv = 56;
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}

           
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
            //if (System.Windows.Forms.Application.OpenForms["frmMeasurementUnit"] as frmMeasurementUnit == null)
            //{
            //    frmMeasurementUnit objfrm = new frmMeasurementUnit();
            //    objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            //    objfrm.lngFormPriv = 60;
            //    objfrm.strFormName = "Measurement Unit";
            //    objfrm.MdiParent = this.MdiParent;
            //    objfrm.Show();

            //}
            //else
            //{
            //    frmMeasurementUnit objfrm = (frmMeasurementUnit)Application.OpenForms["frmMeasurementUnit"];
            //    objfrm.strFormName = "Measurement Unit";
            //    objfrm.lngFormPriv = 60;
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}
          
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
            //if (System.Windows.Forms.Application.OpenForms["frmLocation"] as frmLocation == null)
            //{
            //    frmLocation objfrm = new frmLocation();
            //    objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            //    objfrm.lngFormPriv = 58;
            //    objfrm.strFormName = "Location";
            //    objfrm.MdiParent = this.MdiParent;
            //    objfrm.Show();

            //}
            //else
            //{
            //    frmLocation objfrm = (frmLocation)Application.OpenForms["frmLocation"];
            //    objfrm.strFormName = "Location";
            //    objfrm.lngFormPriv = 58;
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}

         
        }

        private void btnProcessInformation_Click(object sender, EventArgs e)
        {

            //if (System.Windows.Forms.Application.OpenForms["frmProcessM"] as frmProcessM == null)
            //{
            //    frmProcessM objfrm = new frmProcessM();
            //    objfrm.MdiParent = this.MdiParent;
            //    objfrm.Show();

            //}
            //else
            //{
            //    frmProcessM objfrm = (frmProcessM)Application.OpenForms["frmProcessM"];
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}

         
        }

        private void btnMFGVoucher_Click(object sender, EventArgs e)
        {
            //if (Utility.gblnAccessControl)
            //{
            //    if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 68))
            //    {
            //         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
            //        return;
            //    }
            //}
            //if (System.Windows.Forms.Application.OpenForms["frmMFGVoucher"] as frmMFGVoucher == null)
            //{
            //    frmMFGVoucher objfrm = new frmMFGVoucher();
            //    objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            //    objfrm.intvType = (int)Utility.VOUCHER_TYPE.vtSTOCK_MFG_VOUCHER;
            //    objfrm.lngFormPriv = 68;
            //    objfrm.strFormName = "MFG Voucher";
            //    objfrm.intconvert = 0;
            //    objfrm.Show();
            //    objfrm.MdiParent = this.MdiParent;

            //}
            //else
            //{
            //    frmMFGVoucher objfrm = (frmMFGVoucher)Application.OpenForms["frmMFGVoucher"];
            //    objfrm.strFormName = "MFG Voucher";
            //    objfrm.lngFormPriv = 68;
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}

           
        }

        private void btnFinishedGoods_Click(object sender, EventArgs e)
        {
            //if (Utility.gblnAccessControl)
            //{
            //    if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 67))
            //    {
            //         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
            //        return;
            //    }
            //}
            //if (System.Windows.Forms.Application.OpenForms["frmMFGStockProduction"] as frmMFGStockProduction == null)
            //{
            //    frmMFGStockProduction objfrm = new frmMFGStockProduction();
            //    objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            //    objfrm.intvType = (int)Utility.VOUCHER_TYPE.vtSTOCK_MFG_FINISHED_GOODS;
            //    objfrm.lngFormPriv = 67;
            //    objfrm.strFormName = "Finished Goods";
            //    objfrm.Show();
            //    objfrm.MdiParent = this.MdiParent;

            //}
            //else
            //{
            //    frmMFGStockProduction objfrm = (frmMFGStockProduction)Application.OpenForms["frmMFGStockProduction"];
            //    objfrm.strFormName = "Finished Goods";
            //    objfrm.lngFormPriv = 67;
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}
            
           
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

            //if (System.Windows.Forms.Application.OpenForms["frmVoucherTypesList"] as frmVoucherTypesList == null)
            //{
            //    frmVoucherTypesList objfrm = new frmVoucherTypesList();
            //    objfrm.MdiParent = this.MdiParent;
            //    objfrm.lngMtype = (long)Utility.MODULE_TYPE.mtSTOCK;
            //    objfrm.lngFormPriv = 63;
            //    objfrm.MdiParent = this.MdiParent;
            //    objfrm.Show();

            //}
            //else
            //{
            //    frmVoucherTypesList objfrm = (frmVoucherTypesList)Application.OpenForms["frmVoucherTypesList"];
            //    objfrm.lngFormPriv = 63;
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}
            

           
        }

        private void frmInventoryMain_Load(object sender, EventArgs e)
        {

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
            //if (System.Windows.Forms.Application.OpenForms["frmBatchconfig"] as frmBatchconfig == null)
            //{
            //    frmBatchconfig objfrm = new frmBatchconfig();
            //    objfrm.MdiParent = this.MdiParent;
            //    objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            //    objfrm.lngFormPriv = 62;
            //    objfrm.strFormName = "Batch Configuration";
            //    objfrm.MdiParent = this.MdiParent;
            //    objfrm.Show();

            //}
            //else
            //{
            //    frmBatchconfig objfrm = (frmBatchconfig)Application.OpenForms["frmBatchconfig"];
            //    objfrm.strFormName = "Batch Configuration";
            //    objfrm.lngFormPriv = 62;
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}
              
          
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
                objfrm.MdiParent = this.MdiParent;
                objfrm.Show();

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
                objfrm.MdiParent = this.MdiParent;
                objfrm.Show();

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
                objfrm.MdiParent = this.MdiParent;
                objfrm.Show();

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
            //if (System.Windows.Forms.Application.OpenForms["frmCommissionM"] as frmCommissionM == null)
            //{
            //    frmCommissionM objfrm = new frmCommissionM();
            //    objfrm.MdiParent = this.MdiParent;
            //    objfrm.Show();

            //}
            //else
            //{
            //    frmCommissionM objfrm = (frmCommissionM)Application.OpenForms["frmCommissionM"];
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}
            

           
        }

        private void btnCommissionConfig_Click(object sender, EventArgs e)
        {
          

          
        }

        private void btnSection_Click(object sender, EventArgs e)
        {
            //if (System.Windows.Forms.Application.OpenForms["frmSection"] as frmSection == null)
            //{
            //    frmSection objfrm = new frmSection();
            //    objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            //    objfrm.MdiParent = this.MdiParent;
            //    objfrm.Show();

            //}
            //else
            //{
            //    frmSection objfrm = (frmSection)Application.OpenForms["frmSection"];
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}
           
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
            //if (System.Windows.Forms.Application.OpenForms["frmMaterialType"] as frmMaterialType == null)
            //{
            //    frmMaterialType objfrm = new frmMaterialType();
            //    objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            //    objfrm.lngFormPriv = 59;
            //    objfrm.strFormName = "Material Type";
            //    objfrm.MdiParent = this.MdiParent;
            //    objfrm.Show();

            //}
            //else
            //{
            //    frmMaterialType objfrm = (frmMaterialType)Application.OpenForms["frmMaterialType"];
            //    objfrm.strFormName = "Material Type";
            //    objfrm.lngFormPriv = 59;
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}
            
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
                objfrm.MdiParent = this.MdiParent;
                objfrm.Show();

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
            //if (System.Windows.Forms.Application.OpenForms["frmStockItem"] as frmStockItem == null)
            //{
            //    frmStockItem objfrm = new frmStockItem();
            //    objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            //    objfrm.lngFormPriv = 61;
            //    objfrm.strFormName = "Stock Item";
            //    objfrm.MdiParent = this.MdiParent;
            //    objfrm.Show();

            //}
            //else
            //{
            //    frmStockItem objfrm = (frmStockItem)Application.OpenForms["frmStockItem"];
            //    objfrm.strFormName = "Stock Item";
            //    objfrm.lngFormPriv = 61;
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}
          
    
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
                objfrm.MdiParent = this.MdiParent;
                objfrm.Show();

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
         
            if (System.Windows.Forms.Application.OpenForms["frmRptStockInformation_N"] as frmRptStockInformation_N == null)
            {
                frmRptStockInformation_N objfrm = new frmRptStockInformation_N();
                objfrm.strType = "C";
                objfrm.MdiParent = this.MdiParent;
                objfrm.Show();

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
                objfrm.MdiParent = this.MdiParent;
                objfrm.Show();

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
                objfrm.MdiParent = this.MdiParent;
                objfrm.Show();

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
                objfrm.MdiParent = this.MdiParent;
                objfrm.Show();

            }
            else
            {
                frmRptStockInformation objfrm = (frmRptStockInformation)Application.OpenForms["frmRptStockInformation"];
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
                objfrm.MdiParent = this.MdiParent;
                objfrm.Show();

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
                objfrm.MdiParent = this.MdiParent;
                objfrm.Show();

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
                objfrm.MdiParent = this.MdiParent;
                objfrm.Show();

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
                objfrm.MdiParent = this.MdiParent;
                objfrm.Show();

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
                objfrm.MdiParent = this.MdiParent;
                objfrm.Show();

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
                objfrm.MdiParent = this.MdiParent;
                objfrm.Show();

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
                objfrm.MdiParent = this.MdiParent;
                objfrm.Show();

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
                objfrm.MdiParent = this.MdiParent;
                objfrm.Show();

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
                objfrm.MdiParent = this.MdiParent;
                objfrm.Show();
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
                objfrm.MdiParent = this.MdiParent;
                objfrm.Show();
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
                objfrm.MdiParent = this.MdiParent;
                objfrm.Show();
            }
            else
            {
                frmRptLocationWiseQty objfrm = (frmRptLocationWiseQty)Application.OpenForms["frmRptLocationWiseQty"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
           
        }

        private void frmInventoryMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                var strResponse = MessageBox.Show("                    Quit                    ", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponse == DialogResult.Yes)
                {
                    this.Dispose();
                }
            }
            else if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {
                btnGroupConfiguration_Click(sender,e);
            }
            else if (e.KeyCode == Keys.G && e.Modifiers == Keys.Control)
            {
                btnCustomer_Click(sender, e);
            }
            else if (e.KeyCode == Keys.L && e.Modifiers == Keys.Control)
            {
                btnLocation_Click(sender, e);
            }
            else if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
            {
                btnStockItem_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F && e.Modifiers == Keys.Control)
            {
                btnFinishedGoods_Click(sender, e);
            }
            else if (e.KeyCode == Keys.M && e.Modifiers == Keys.Control)
            {
                btnMFGVoucher_Click(sender, e);
            }
            else if (e.KeyCode == Keys.O && e.Modifiers == Keys.Control)
            {
                btnComversionFG_Click(sender, e);
            }
            else if (e.KeyCode == Keys.T && e.Modifiers == Keys.Control)
            {
                //btnStockTransfer_Click(sender, e);
            }
            else if (e.KeyCode == Keys.P && e.Modifiers == Keys.Control)
            {
                btnPhysicalStock_Click(sender, e);
            }
            else if (e.KeyCode == Keys.D && e.Modifiers == Keys.Control)
            {
                btnStockDamage_Click(sender, e);
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
                objfrm.MdiParent = this.MdiParent;
                objfrm.Show();
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
            //if (System.Windows.Forms.Application.OpenForms["frmProductionMain"] as frmProductionMain == null)
            //{
            //    frmProductionMain objfrm = new frmProductionMain();
            //    objfrm.MdiParent = this.MdiParent;
            //    objfrm.Show();

            //}
            //else
            //{
            //    frmProductionMain objfrm = (frmProductionMain)Application.OpenForms["frmProductionMain"];
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}
        }

        private void btnStockTransferOut_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 201))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            //if (System.Windows.Forms.Application.OpenForms["frmStockTransferOut"] as frmStockTransferOut == null)
            //{
            //    frmStockTransferOut objfrm = new frmStockTransferOut();
            //    objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            //    objfrm.mintVtype = (int)Utility.VOUCHER_TYPE.vtSTOCK_TRANSFER;
            //    objfrm.lngFormPriv = 201;
            //    objfrm.strFormName = "Stock Transfer";
            //    objfrm.MdiParent = this.MdiParent;
            //    objfrm.Show();

            //}
            //else
            //{
            //    frmStockTransferOut objfrm = (frmStockTransferOut)Application.OpenForms["frmStockTransferOut"];
            //    objfrm.strFormName = "Stock Transfer(Out)";
            //    objfrm.lngFormPriv = 201;
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}


          
        }

        private void btnStockTransferIN_Click(object sender, EventArgs e)
        {
          
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 197))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            //if (System.Windows.Forms.Application.OpenForms["frmStockTransferIN"] as frmStockTransferIN == null)
            //{
            //    frmStockTransferIN objfrm = new frmStockTransferIN();
            //    objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            //    objfrm.mintVtype = (int)Utility.VOUCHER_TYPE.vtSTOCK_TRANFERIN;
            //    objfrm.lngFormPriv = 197;
            //    objfrm.strFormName = "Stock Transfer(IN)";
            //    objfrm.MdiParent = this.MdiParent;
            //    objfrm.Show();
               

            //}
            //else
            //{
            //    frmStockTransferIN objfrm = (frmStockTransferIN)Application.OpenForms["frmStockTransferIN"];
            //    objfrm.strFormName = "Stock Transfer(IN)";
            //    objfrm.lngFormPriv = 197;
            //    objfrm.MdiParent = this.MdiParent;
            //    objfrm.Focus();
                
            //}

        }

        private void btnStockRequition_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 190))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            //if (System.Windows.Forms.Application.OpenForms["frmStockRequisition"] as frmStockRequisition == null)
            //{
            //    frmStockRequisition objfrm = new frmStockRequisition();
            //    objfrm.mintVtype = (int)Utility.VOUCHER_TYPE.vtSTOCK_REQUISITION;
            //    objfrm.lngFormPriv = 190;
            //    objfrm.MdiParent = this.MdiParent;
            //    objfrm.Show();

            //}
            //else
            //{
            //    frmStockRequisition objfrm = (frmStockRequisition)Application.OpenForms["frmStockRequisition"];
            //    objfrm.lngFormPriv = 190;
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}
        }

        private void brnFGApproved_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 191))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            //frmMFGVoucherList objfrm = new frmMFGVoucherList();
            //objfrm.lngFormPriv = 191;
            //objfrm.strFormName = "FG Approved";
            //objfrm.intConvert = 5;
            //objfrm.strFlag = "F";
            //objfrm.MdiParent = this.MdiParent;
            //objfrm.Show();
        }

        private void btnStationaryConsumtion_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 200))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            
            //if (System.Windows.Forms.Application.OpenForms["frmStockStationary"] as frmStockStationary == null)
            //{
            //    frmStockStationary objfrm = new frmStockStationary();
            //    objfrm.mintVtype = (int)Utility.VOUCHER_TYPE.vtSTATIONARY;
            //    objfrm.strFormName = "Stationary Item";
            //    objfrm.lngFormPriv = 200;
            //    objfrm.MdiParent = this.MdiParent;
            //    objfrm.Show();

            //}
            //else
            //{
            //    frmStockStationary objfrm = (frmStockStationary)Application.OpenForms["frmStockStationary"];
            //    objfrm.lngFormPriv = 200;
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}
        }

        private void btnStockStatment_Click(object sender, EventArgs e)
        {
            //if (System.Windows.Forms.Application.OpenForms["frmStockMain"] as frmStockMain == null)
            //{
            //    frmStockMain objfrm = new frmStockMain();
            //    objfrm.MdiParent = this.MdiParent;
            //    objfrm.Show();

            //}
            //else
            //{
            //    frmStockMain objfrm = (frmStockMain)Application.OpenForms["frmStockMain"];
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}
        }

        private void btnSrockEstimation_Click(object sender, EventArgs e)
        {
            //if (System.Windows.Forms.Application.OpenForms["frmStockEstimationMain"] as frmStockEstimationMain == null)
            //{
            //    frmStockEstimationMain objfrm = new frmStockEstimationMain();
            //    objfrm.MdiParent = this.MdiParent;
            //    objfrm.Show();

            //}
            //else
            //{
            //    frmStockEstimationMain objfrm = (frmStockEstimationMain)Application.OpenForms["frmStockEstimationMain"];
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}
        }

        private void btnstockConsumtion_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 66))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmMFGStockConsumDilution"] as frmMFGStockConsumDilution == null)
            {
                frmMFGStockConsumDilution objfrm = new frmMFGStockConsumDilution();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.intvType = (int)Utility.VOUCHER_TYPE.vtSTOCK_MFG_CONSUMPTION;
                objfrm.lngFormPriv = 66;
                objfrm.intType = 0;
                objfrm.strFormName = "Consumption";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmMFGStockConsumDilution objfrm = (frmMFGStockConsumDilution)Application.OpenForms["frmMFGStockConsumDilution"];
                objfrm.strFormName = "Consumption";
                objfrm.lngFormPriv = 66;
                objfrm.intType = 3;
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void colorButton1_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 198))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmMFGVoucherManual"] as frmMFGVoucherManual == null)
            {
                frmMFGVoucherManual objfrm = new frmMFGVoucherManual();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.intvType = (int)Utility.VOUCHER_TYPE.vtSTOCK_MFG_CONSUMPTION;
                objfrm.lngFormPriv = 198;
                objfrm.intType = 4;
                objfrm.strFormName = "MFG Voucher";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmMFGVoucherManual objfrm = (frmMFGVoucherManual)Application.OpenForms["frmMFGVoucherManual"];
                objfrm.strFormName = "MFG Voucher";
                objfrm.lngFormPriv = 198;
                objfrm.intType = 4;
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void frmMFGVoucherProcess_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 199))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmMFGVoucher"] as frmMFGVoucher == null)
            {
                frmMFGVoucher objfrm = new frmMFGVoucher();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.intvType = (int)Utility.VOUCHER_TYPE.vtSTOCK_MFG_VOUCHER;
                objfrm.lngFormPriv = 199;
                objfrm.strFormName = "MFG Voucher";
                objfrm.intconvert = 0;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmMFGVoucher objfrm = (frmMFGVoucher)Application.OpenForms["frmMFGVoucher"];
                objfrm.strFormName = "MFG Voucher";
                objfrm.lngFormPriv = 199;
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnConversionFG_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 69))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmMFGVoucherConversion"] as frmMFGVoucherConversion == null)
            {
                frmMFGVoucherConversion objfrm = new frmMFGVoucherConversion();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.intvType = (int)Utility.VOUCHER_TYPE.vtSTOCK_MFG_VOUCHER;
                objfrm.lngFormPriv = 69;
                objfrm.strFormName = "Conversion FG";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmMFGVoucherConversion objfrm = (frmMFGVoucherConversion)Application.OpenForms["frmMFGVoucherConversion"];
                objfrm.strFormName = "Conversion FG";
                objfrm.lngFormPriv = 69;
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnRndConsumption_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 205))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmMFGStockConsumDilution"] as frmMFGStockConsumDilution == null)
            {
                frmMFGStockConsumDilution objfrm = new frmMFGStockConsumDilution();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.intvType = (int)Utility.VOUCHER_TYPE.vtSTOCK_MFG_CONSUMPTION;
                objfrm.lngFormPriv = 205;
                objfrm.intType = 7;
                objfrm.strFormName = "R && D Consumption";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmMFGStockConsumDilution objfrm = (frmMFGStockConsumDilution)Application.OpenForms["frmMFGStockConsumDilution"];
                objfrm.strFormName = "R & D Consumption";
                objfrm.lngFormPriv = 66;
                objfrm.intType = 3;
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

       

        

        

     
    

     
      
    }
}
