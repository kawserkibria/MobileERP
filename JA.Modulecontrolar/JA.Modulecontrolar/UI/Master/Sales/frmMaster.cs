using Dutility;
using JA.Modulecontrolar.UI.Master.Accounts;
using JA.Modulecontrolar.UI.Master.Inventory;
using JA.Modulecontrolar.UI.Master.Sales;
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

namespace JA.Modulecontrolar.UI.Master.Sales
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
                //}
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
                frmTeritorry objfrm = new frmTeritorry();
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
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 9))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
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

            if (System.Windows.Forms.Application.OpenForms["frmItem_PowerClassWiseTarget"] as frmItem_PowerClassWiseTarget == null)
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

        private void btnCategory_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 56))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnLocation_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 58))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnUnitMeasurement_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 60))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnStockItem_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 61))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnBatch_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 62))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnVoucherTypes_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 63))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnBranch_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 94))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmBranch"] as frmBranch == null)
            {
                frmBranch objfrm = new frmBranch();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.lngFormPriv = 94;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;


            }
            else
            {
                frmBranch objfrm = (frmBranch)Application.OpenForms["frmBranch"];
                objfrm.lngFormPriv = 94;
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnGroups_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 95))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmGroupConfiguration"] as frmGroupConfiguration == null)
            {
                frmGroupConfiguration objfrm = new frmGroupConfiguration();
                objfrm.lngFormPriv = 95;
                objfrm.intModuleType = (int)Utility.MODULE_TYPE.mtACCOUNT;
                objfrm.strFoemName = "Group";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmGroupConfiguration objfrm = (frmGroupConfiguration)Application.OpenForms["frmGroupConfiguration"];
                objfrm.strFoemName = "Group";
                objfrm.lngFormPriv = 95;
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnLedger_Click(object sender, EventArgs e)
        {


            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 96))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmAccountsLedger"] as frmAccountsLedger == null)
            {
                frmAccountsLedger objfrm = new frmAccountsLedger();
                objfrm.m_acction = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.lngFormPriv = 96;
                objfrm.Show();
                objfrm.BringToFront();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmAccountsLedger objfrm = (frmAccountsLedger)Application.OpenForms["frmAccountsLedger"];
                objfrm.lngFormPriv = 96;
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnCostCenter_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 98))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmCostCenter"] as frmCostCenter == null)
            {
                frmCostCenter objfrm = new frmCostCenter();
                objfrm.lngFormPriv = 98;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmCostCenter objfrm = (frmCostCenter)Application.OpenForms["frmCostCenter"];
                objfrm.lngFormPriv = 98;
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnCostCategory_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 97))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmCostCategory"] as frmCostCategory == null)
            {
                frmCostCategory objfrm = new frmCostCategory();
                objfrm.lngFormPriv = 97;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmCostCategory objfrm = (frmCostCategory)Application.OpenForms["frmCostCategory"];
                objfrm.lngFormPriv = 97;
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void colorButton3_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 99))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmVoucherTypesList"] as frmVoucherTypesList == null)
            {
                frmVoucherTypesList objfrm = new frmVoucherTypesList();
                objfrm.lngMtype = (long)Utility.MODULE_TYPE.mtACCOUNT;
                objfrm.lngFormPriv = 99;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmVoucherTypesList objfrm = (frmVoucherTypesList)Application.OpenForms["frmVoucherTypesList"];
                objfrm.lngFormPriv = 99;
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnFixedAssets_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 100))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmFixedAssets"] as frmFixedAssets == null)
            {
                frmFixedAssets objfrm = new frmFixedAssets();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.lngFormPriv = 100;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmFixedAssets objfrm = (frmFixedAssets)Application.OpenForms["frmFixedAssets"];
                objfrm.lngFormPriv = 100;
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }

        }

        private void btnMpoConfig_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["frmMPOCommission"] as frmMPOCommission == null)
            {
                frmMPOCommission objfrm = new frmMPOCommission();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmMPOCommission objfrm = (frmMPOCommission)Application.OpenForms["frmMPOCommission"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }
      
    }
}
