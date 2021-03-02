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
using JA.Modulecontrolar.UI.Forms;
using JA.Modulecontrolar.UI.Accms.Forms;
using JA.Modulecontrolar.UI.DReport.Sales.ParameterForms;
using JA.Modulecontrolar.UI.DReport.Purchase.ParameterForms;
using Microsoft.Win32;
using JA.Modulecontrolar.UI.DReport.Accms.ParameterForms;



namespace JA.Modulecontrolar.UI.Sales.Forms
{
    public partial class frmSalesMenu : Form
    {
        private string strComID { get; set; }
        public frmSalesMenu()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSalesMenu_KeyDown);
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 2))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
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

        private void btnSalesInvoice_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 18))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmSalesInvoice"] as frmSalesInvoice == null)
            {
                frmSalesInvoice objfrm = new frmSalesInvoice();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.intVtype = (int)Utility.VOUCHER_TYPE.vtSALES_INVOICE;
                objfrm.lngLedgeras = (int)Utility.GR_GROUP_TYPE.grCUSTOMER;
                objfrm.lngFormPriv = 18;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;
                objfrm.Focus();
            }
            else
            {
                frmSalesInvoice objfrm = (frmSalesInvoice)Application.OpenForms["frmSalesInvoice"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
           
        }

        private void btnSalesRep_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 4))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
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

        private void btnPriceLevel_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 6))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
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
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
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

        private void btnGiftItem_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 8))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmGift"] as frmGift == null)
            {
                frmGift objfrm = new frmGift();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.lngFormPriv = 8;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmGift objfrm = (frmGift)Application.OpenForms["frmGift"];
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

        private void btnSalesSample_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 21))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmSample"] as frmSample == null)
            {
                frmSample objfrm = new frmSample();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.vtype = (int)Utility.VOUCHER_TYPE.vt_SALESSAMPLE;
                objfrm.lngFormPriv = 21;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmSample objfrm = (frmSample)Application.OpenForms["frmSample"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
           
        }

        private void btnSalesOrder_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 158))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            //if (System.Windows.Forms.Application.OpenForms["frmSalesOrderNew"] as frmSalesOrderNew == null)
            //{
            //    frmSalesOrderNew objfrm = new frmSalesOrderNew();
            //    objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            //    objfrm.intVtype = (int)Utility.VOUCHER_TYPE.vtSALES_ORDER;
            //    objfrm.lngFormPriv = 158;
            //    objfrm.Show();
            //    objfrm.MdiParent = this.MdiParent;

            //}
            //else
            //{
            //    frmSalesOrderNew objfrm = (frmSalesOrderNew)Application.OpenForms["frmSalesOrderNew"];
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}
            //mClear();
            frmSalesOrdeNewList objfrm = new frmSalesOrdeNewList();
            objfrm.mintVType = (int)Utility.VOUCHER_TYPE.vtSALES_ORDER;
            objfrm.lngFormPriv = 158;
            objfrm.strFormName = "Sales Order";
            //objfrm.strPreserveSQl = strMysql;
            objfrm.onAddAllButtonClicked = new frmSalesOrdeNewList.AddAllClick(DisplayVoucherList);
            objfrm.MdiParent = MdiParent;
            objfrm.Show();

        }
        private void DisplayVoucherList(List<AccountsVoucher> tests, object sender, EventArgs e)
        {
           
        }
        private void btnSalesChallan_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 19))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            //if (System.Windows.Forms.Application.OpenForms["frmSalesChallan"] as frmSalesChallan == null)
            //{
            //    frmSalesChallan objfrm = new frmSalesChallan();
            //    objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            //    objfrm.intVtype = (int)Utility.VOUCHER_TYPE.vtSALES_CHALLAN;
            //    objfrm.lngFormPriv = 19;
            //    objfrm.Show();
            //    objfrm.MdiParent = this.MdiParent;

            //}
            //else
            //{
            //    frmSalesChallan objfrm = (frmSalesChallan)Application.OpenForms["frmSalesChallan"];
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}
            if (System.Windows.Forms.Application.OpenForms["frmSalesChallanAutoProcess"] as frmSalesChallanAutoProcess == null)
            {
                frmSalesChallanAutoProcess objfrm = new frmSalesChallanAutoProcess();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.intVtype = (int)Utility.VOUCHER_TYPE.vtSALES_CHALLAN;
                objfrm.lngFormPriv = 19;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmSalesChallanAutoProcess objfrm = (frmSalesChallanAutoProcess)Application.OpenForms["frmSalesChallanAutoProcess"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
           
        }

        private void btnVoucherTypes_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName,5))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
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

        private void btnSalesReturn_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName,20))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmSalesReturn"] as frmSalesReturn == null)
            {
                frmSalesReturn objfrm = new frmSalesReturn();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.intVtype = (int)Utility.VOUCHER_TYPE.vtSALES_RETURN;
                objfrm.lngLedgeras = (int)Utility.GR_GROUP_TYPE.grCUSTOMER;
                objfrm.lngFormPriv = 20;
                objfrm.strFormName = "Sales Return";
                objfrm.intModuletype = (int)Utility.MODULE_TYPE.mtSALES;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmSalesReturn objfrm = (frmSalesReturn)Application.OpenForms["frmSalesReturn"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
           
        }



        private void btnDeisgnCategory_Click(object sender, EventArgs e)
        {
            //frmDesignationCategory objfrm = new frmDesignationCategory();
            //objfrm.intVtype = (int)Utility.GR_GROUP_TYPE.grSALES_REP;
            //objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            //objfrm.Show();
            //objfrm.MdiParent = this.MdiParent;
        }

      

        private void btnTransport_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 10))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmTransport"] as frmTransport == null)
            {
                frmTransport objfrm = new frmTransport();
                objfrm.intVtype = (int)Utility.GR_GROUP_TYPE.grSALES_REP;
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.lngFormPriv = 10;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmTransport objfrm = (frmTransport)Application.OpenForms["frmTransport"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
           
        }

        private void btnDesign_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 11))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmDestination"] as frmDestination == null)
            {
                frmDestination objfrm = new frmDestination();
                objfrm.intVtype = (int)Utility.GR_GROUP_TYPE.grSALES_REP;
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.lngFormPriv = 11;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmDestination objfrm = (frmDestination)Application.OpenForms["frmDestination"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
           
        }

        private void btnSampleClass_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 12))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmSampleClass"] as frmSampleClass == null)
            {
                frmSampleClass objfrm = new frmSampleClass();
                objfrm.intVtype = (int)Utility.GR_GROUP_TYPE.grSALES_REP;
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.lngFormPriv = 12;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmSampleClass objfrm = (frmSampleClass)Application.OpenForms["frmSampleClass"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
           
        }

        private void btnSalesTarget_Click(object sender, EventArgs e)
        {
            //frmSalesTarget objfrm = new frmSalesTarget();
            //objfrm.intVtype = (int)Utility.GR_GROUP_TYPE.grSALES_REP;
            //objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            //objfrm.Show();
            //objfrm.MdiParent = this.MdiParent;
        }

        private void btnCollecCommit_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["frmCollectionCommitement"] as frmCollectionCommitement == null)
            {
                frmCollectionCommitement objfrm = new frmCollectionCommitement();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.strSelection = "SC";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmCollectionCommitement objfrm = (frmCollectionCommitement)Application.OpenForms["frmCollectionCommitement"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
           
        }

        private void btnTargetAchieve_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 13))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmCollectionCommitement"] as frmCollectionCommitement == null)
            {
                frmCollectionCommitement objfrm = new frmCollectionCommitement();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.strSelection = "TA";
                objfrm.lngFormPriv = 13;
                objfrm.strtFormName = "Sales Target";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmCollectionCommitement objfrm = (frmCollectionCommitement)Application.OpenForms["frmCollectionCommitement"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
            
        }

        private void btnMonthlyCredit_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 15))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmCollectionCommitement"] as frmCollectionCommitement == null)
            {
                frmCollectionCommitement objfrm = new frmCollectionCommitement();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.strSelection = "MC";
                objfrm.lngFormPriv = 15;
                objfrm.strtFormName = "Credit Limt";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmCollectionCommitement objfrm = (frmCollectionCommitement)Application.OpenForms["frmCollectionCommitement"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
          
        }

       

        private void btnGroup_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 1))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
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

        private void btnReceiptVoucher_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["frmAccountsVoucher"] as frmAccountsVoucher == null)
            {
                frmAccountsVoucher objfrm = new frmAccountsVoucher();
                objfrm.intvtype = (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER;
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmAccountsVoucher objfrm = (frmAccountsVoucher)Application.OpenForms["frmAccountsVoucher"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
           
        }

        private void btnSalesStattement_Click(object sender, EventArgs e)
        {


            if (System.Windows.Forms.Application.OpenForms["frmStatement"] as frmStatement == null)
            {
                frmStatement objfrm = new frmStatement();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmStatement objfrm = (frmStatement)Application.OpenForms["frmStatement"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnTeritorry_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 3))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
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

        private void frmSalesMenu_Load(object sender, EventArgs e)
        {
          
        }

        private void btnCollTarget_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 17))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmCollectionCommitement"] as frmCollectionCommitement == null)
            {
              
                frmCollectionCommitement objfrm = new frmCollectionCommitement();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.strSelection = "CT";
                objfrm.lngFormPriv = 17;
                objfrm.strtFormName = "Collection Target";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmCollectionCommitement objfrm = (frmCollectionCommitement)Application.OpenForms["frmCollectionCommitement"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
          

        }

    

        private void btnSalesPriceList_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 23))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptSalesPriceList"] as frmRptSalesPriceList == null)
            {
                frmRptSalesPriceList objfrm = new frmRptSalesPriceList();
                objfrm.Show();
                objfrm.MdiParent = MdiParent;

            }
            else
            {
                frmRptSalesPriceList objfrm = (frmRptSalesPriceList)Application.OpenForms["frmRptSalesPriceList"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
           
        }

        private void btnProductSalesStatment_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 26))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptProductSalesStatement"] as frmRptProductSalesStatement == null)
            {
                frmRptProductSalesStatement objfrm = new frmRptProductSalesStatement();
                objfrm.Show();
                objfrm.MdiParent = MdiParent;

            }
            else
            {
                frmRptProductSalesStatement objfrm = (frmRptProductSalesStatement)Application.OpenForms["frmRptProductSalesStatement"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
           
        }

        private void btnDesignationCategory_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 27))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptDesignationCategory"] as frmRptDesignationCategory == null)
            {
                frmRptDesignationCategory objfrm = new frmRptDesignationCategory();
                objfrm.Show();
                objfrm.MdiParent = MdiParent;

            }
            else
            {
                frmRptDesignationCategory objfrm = (frmRptDesignationCategory)Application.OpenForms["frmRptDesignationCategory"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
            
        }

        private void btnPartyWiseSalesStatement_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 28))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptPartywiseSalesStatement"] as frmRptPartywiseSalesStatement == null)
            {
                frmRptPartywiseSalesStatement objfrm = new frmRptPartywiseSalesStatement();
                objfrm.Show();
                objfrm.MdiParent = MdiParent;

            }
            else
            {
                frmRptPartywiseSalesStatement objfrm = (frmRptPartywiseSalesStatement)Application.OpenForms["frmRptPartywiseSalesStatement"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
           
        }

     
      

        private void btnTargetSalesStatment_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 31))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptSalesTargetStatement"] as frmRptSalesTargetStatement == null)
            {
                frmRptSalesTargetStatement objfrm = new frmRptSalesTargetStatement();
                objfrm.Show();
                objfrm.MdiParent = MdiParent;

            }
            else
            {
                frmRptSalesTargetStatement objfrm = (frmRptSalesTargetStatement)Application.OpenForms["frmRptSalesTargetStatement"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
            
        }

        private void btnTargetSalesStaYearly_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 32))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptTargeSalesStatYearly"] as frmRptTargeSalesStatYearly == null)
            {
                frmRptTargeSalesStatYearly objfrm = new frmRptTargeSalesStatYearly();
                objfrm.Show();
                objfrm.MdiParent = MdiParent;

            }
            else
            {
                frmRptTargeSalesStatYearly objfrm = (frmRptTargeSalesStatYearly)Application.OpenForms["frmRptTargeSalesStatYearly"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }

           
        }

        private void btnRptSalesInvoice_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 33))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptSalesInvoice"] as frmRptSalesInvoice == null)
            {
                frmRptSalesInvoice objfrm = new frmRptSalesInvoice();
                objfrm.Show();
                objfrm.MdiParent = MdiParent;

            }
            else
            {
                frmRptSalesInvoice objfrm = (frmRptSalesInvoice)Application.OpenForms["frmRptSalesInvoice"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
            
        }

        private void btnSalesStatIndividual_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 34))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptSalesStatementIndividual"] as frmRptSalesStatementIndividual == null)
            {
                frmRptSalesStatementIndividual objfrm = new frmRptSalesStatementIndividual();
                objfrm.MdiParent = MdiParent;
                objfrm.Show();
                

            }
            else
            {
                frmRptSalesStatementIndividual objfrm = (frmRptSalesStatementIndividual)Application.OpenForms["frmRptSalesStatementIndividual"];
                objfrm.MdiParent = this.MdiParent;
                objfrm.Focus();
               
            }
           
        }

        private void btnSalesStaPackSize_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 35))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptSalesStatePackSize"] as frmRptSalesStatePackSize == null)
            {
                frmRptSalesStatePackSize objfrm = new frmRptSalesStatePackSize();
                objfrm.Show();
                objfrm.MdiParent = MdiParent;

            }
            else
            {
                frmRptSalesStatePackSize objfrm = (frmRptSalesStatePackSize)Application.OpenForms["frmRptSalesStatePackSize"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
          
        }

        private void btnStatisticalProductSales_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 36))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptStatisticalProductSales"] as frmRptStatisticalProductSales == null)
            {
                frmRptStatisticalProductSales objfrm = new frmRptStatisticalProductSales();
                objfrm.Show();
                objfrm.MdiParent = MdiParent;

            }
            else
            {
                frmRptStatisticalProductSales objfrm = (frmRptStatisticalProductSales)Application.OpenForms["frmRptStatisticalProductSales"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
            
        }


      

        private void btnVoucherReports_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID,Utility.gstrUserName, 39))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptVoucherReport"] as frmRptVoucherReport == null)
            {
                frmRptVoucherReport objfrm = new frmRptVoucherReport();
                //objfrm.strReportName = "Manufacturing";
                objfrm.strSelection = "Sales";
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

       

        private void btnProductWiseAnalysis_Click(object sender, EventArgs e)
        {

            if (System.Windows.Forms.Application.OpenForms["frmRptProductAnalysis"] as frmRptProductAnalysis == null)
            {
                frmRptProductAnalysis objfrm = new frmRptProductAnalysis();
                objfrm.strSelection = "Prodcut Analysis";
                objfrm.Show();
                objfrm.MdiParent = MdiParent;

            }
            else
            {
                frmRptProductAnalysis objfrm = (frmRptProductAnalysis)Application.OpenForms["frmRptProductAnalysis"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
           
        }

        private void btnRptSalesChallan_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 140))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptSalesChalan"] as frmRptSalesChalan == null)
            {
                frmRptSalesChalan objfrm = new frmRptSalesChalan();
                objfrm.Show();
                objfrm.MdiParent = MdiParent;

            }
            else
            {
                frmRptSalesChalan objfrm = (frmRptSalesChalan)Application.OpenForms["frmRptSalesChalan"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
           
        }

        private void btnRptChallanPending_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 141))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptSalesChalan_Pending"] as frmRptSalesChalan_Pending == null)
            {
                frmRptSalesChalan_Pending objfrm = new frmRptSalesChalan_Pending();
                objfrm.Show();
                objfrm.MdiParent = MdiParent;

            }
            else
            {
                frmRptSalesChalan_Pending objfrm = (frmRptSalesChalan_Pending)Application.OpenForms["frmRptSalesChalan_Pending"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
           
        }

      

        private void frmSalesMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                var strResponse = MessageBox.Show("                    Quit                    ", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponse == DialogResult.Yes)
                {
                    this.Dispose();
                }
            }
             if (e.KeyCode == Keys.G && e.Modifiers == Keys.Control)
             {
                 btnGroup_Click(sender,e);
             }
             else if (e.KeyCode == Keys.T && e.Modifiers == Keys.Control)
             {
                 btnTeritorry_Click(sender, e);
             }
             else if (e.KeyCode == Keys.M && e.Modifiers == Keys.Control)
             {
                 btnCustomer_Click(sender, e);
             }
             else if (e.KeyCode == Keys.D && e.Modifiers == Keys.Control)
             {
                 btnSalesRep_Click(sender, e);
             }
             else if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
             {
                 btnVoucherTypes_Click(sender, e);
             }
             else if (e.KeyCode == Keys.P && e.Modifiers == Keys.Control)
             {
                 btnPriceLevel_Click(sender, e);
             }
             else if (e.KeyCode == Keys.R && e.Modifiers == Keys.Control)
             {
                 btnSalesPriceConfig_Click(sender, e);
             }
             else if (e.KeyCode == Keys.F && e.Modifiers == Keys.Control)
             {
                 btnGiftItem_Click(sender, e);
             }
             else if (e.KeyCode == Keys.B && e.Modifiers == Keys.Control)
             {
                 btnBonus_Click(sender, e);
             }
             else if (e.KeyCode == Keys.N && e.Modifiers == Keys.Control)
             {
                 btnTransport_Click(sender, e);
             }
             else if (e.KeyCode == Keys.E && e.Modifiers == Keys.Control)
             {
                 btnDesign_Click(sender, e);
             }
             //else if (e.KeyCode == Keys.E && e.Modifiers == Keys.Control)
             //{
             //    btnSampleClass_Click(sender, e);
             //}
             else if (e.KeyCode == Keys.A && e.Modifiers == Keys.Control)
             {
                 //btnTargetAchieve_Click(sender, e);
             }
             else if (e.KeyCode == Keys.G && e.Modifiers == Keys.Control)
             {
                 btnCollTarget_Click(sender, e);
             }
             else if (e.KeyCode == Keys.L && e.Modifiers == Keys.Control)
             {
                 btnMonthlyCredit_Click(sender, e);
             }
             else if (e.KeyCode == Keys.O && e.Modifiers == Keys.Control)
             {
                 btnSalesOrder_Click(sender, e);
             }
             else if (e.KeyCode == Keys.X  && e.Modifiers == Keys.Control)
             {
                 //this.SendToBack();
                 btnSalesInvoice_Click(sender, e);
                
             }
             else if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
             {
                 btnSalesChallan_Click(sender, e);
             }
             else if (e.KeyCode == Keys.R && e.Modifiers == Keys.Control)
             {
                 btnSalesReturn_Click(sender, e);
             }
             else if (e.KeyCode == Keys.K && e.Modifiers == Keys.Control)
             {
                 btnSalesSample_Click(sender, e);
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

        private void btnSpecialProduct_Click(object sender, EventArgs e)
        {
            //if (Utility.gblnAccessControl)
            //{
            //    if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 159))
            //    {
            //        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }
            //}

            if (System.Windows.Forms.Application.OpenForms["frmRptSpecialPartyReport"] as frmRptSpecialPartyReport == null)
            {
                frmRptSpecialPartyReport objfrm = new frmRptSpecialPartyReport();
                objfrm.strSelection = "Special Party Report";
                objfrm.Show();
                objfrm.MdiParent = MdiParent;

            }
            else
            {
                frmRptSpecialPartyReport objfrm = (frmRptSpecialPartyReport)Application.OpenForms["frmRptSpecialPartyReport"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnSpProductTarget_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["frmRptSpecialProductSales12Main"] as frmRptSpecialProductSales12Main == null)
            {
                frmRptSpecialProductSales12Main objfrm = new frmRptSpecialProductSales12Main();
                objfrm.strSelection = "Special Product Target";
                objfrm.Show();
                objfrm.MdiParent = MdiParent;

            }
            else
            {
                frmRptSpecialProductSales12Main objfrm = (frmRptSpecialProductSales12Main)Application.OpenForms["frmRptSpecialProductSales12Main"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnProductShort_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["frmRptProductShortMultiple"] as frmRptProductShortMultiple == null)
            {
                frmRptProductShortMultiple objfrm = new frmRptProductShortMultiple();
                objfrm.strSelection = "Product Short Report";
                objfrm.Show();
                objfrm.MdiParent = MdiParent;

            }
            else
            {
                frmRptProductShortMultiple objfrm = (frmRptProductShortMultiple)Application.OpenForms["frmRptProductShortMultiple"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnCreditLimit_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 168))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptCreditLimit"] as frmRptCreditLimit == null)
            {
                frmRptCreditLimit objfrm = new frmRptCreditLimit();
                objfrm.strReportName = "Credit Limit";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptCreditLimit objfrm = (frmRptCreditLimit)Application.OpenForms["frmRptCreditLimit"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnMPOLedger_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 169))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptAccountsLedger"] as frmRptAccountsLedger == null)
            {
                frmRptAccountsLedger objfrm = new frmRptAccountsLedger();
                objfrm.strMpo = "1";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptAccountsLedger objfrm = (frmRptAccountsLedger)Application.OpenForms["frmRptAccountsLedger"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnCollectionCommNew_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["frmCreditLimitMaster"] as frmCreditLimitMaster == null)
            {
                frmCreditLimitMaster objfrm = new frmCreditLimitMaster();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmCreditLimitMaster objfrm = (frmCreditLimitMaster)Application.OpenForms["frmCreditLimitMaster"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnHalt_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 184))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmMPOHalt"] as frmMPOHalt == null)
            {
                frmMPOHalt objfrm = new frmMPOHalt();
                objfrm.lngFormPriv = 184;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;
            }
            else
            {
                frmMPOHalt objfrm = (frmMPOHalt)Application.OpenForms["frmMPOHalt"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnDocMpo_Click(object sender, EventArgs e)
        {

            if (System.Windows.Forms.Application.OpenForms["frmRptMpoDoctor"] as frmRptSuppliersList == null)
            {
                frmRptMpoDoctor objfrm = new frmRptMpoDoctor();
                objfrm.strSelection = "MPO/Customer List";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptMpoDoctor objfrm = (frmRptMpoDoctor)Application.OpenForms["frmRptMpoDoctor"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnRptSalesColl_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 185))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptSalesCollectionPerformance"] as frmRptSalesCollectionPerformance == null)
            {
                frmRptSalesCollectionPerformance objfrm = new frmRptSalesCollectionPerformance();
                //objfrm.strSelection = "Sales/Collection Performance";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptSalesCollectionPerformance objfrm = (frmRptSalesCollectionPerformance)Application.OpenForms["frmRptSalesCollectionPerformance"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
            
        }

        private void btnrptSalesOrder_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 188))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptSalesOrder"] as frmRptSalesOrder == null)
            {
                frmRptSalesOrder objfrm = new frmRptSalesOrder();
                //objfrm.strSelection = "Sales/Collection Performance";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptSalesOrder objfrm = (frmRptSalesOrder)Application.OpenForms["frmRptSalesOrder"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void cmdRptYearComparative_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 189))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptYearCompare"] as frmRptYearCompare == null)
            {
                frmRptYearCompare objfrm = new frmRptYearCompare();
                //objfrm.strSelection = "Sales/Collection Performance";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptYearCompare objfrm = (frmRptYearCompare)Application.OpenForms["frmRptYearCompare"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnRouteConfiguration_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 216))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmDeliveryRoute"] as frmDeliveryRoute == null)
            {
                frmDeliveryRoute objfrm = new frmDeliveryRoute();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.lngFormPriv = 216;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmDeliveryRoute objfrm = (frmDeliveryRoute)Application.OpenForms["frmDeliveryRoute"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnRptSalesTarget_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 220))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            frmCollectionCommitementList objfrm = new frmCollectionCommitementList();
            objfrm.strForm = "ACTUAL";
            objfrm.strFormName = "Sales Target";
            objfrm.Show();
            objfrm.MdiParent = this.MdiParent;



        }

        private void btnrptCollectionTarget_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 219))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            frmCollectionCommitementList objfrm = new frmCollectionCommitementList();
            objfrm.strForm = "CTN";
            objfrm.strFormName = "Collection Target";
            objfrm.Show();
            objfrm.MdiParent = this.MdiParent;

        }

        
       

     
     

      
       

      

       

        
       

    }
}
