using Dutility;
using JA.Modulecontrolar.UI.DReport.Accms.ParameterForms;
using JA.Modulecontrolar.UI.Forms;
//using JA.Modulecontrolar.UI.Sales.Forms;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JA.Modulecontrolar.UI.Accms.Forms
{
    public partial class frmAccountsMain : Form
    {
        private string strComID { get; set; }
        public frmAccountsMain()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAccountsMain_KeyDown);

            this.btnBankReconcilation.Click += new System.EventHandler(this.btnBankReconcilation_Click);
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 103))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmAccountsVoucher"] as frmAccountsVoucher == null)
            {
                frmAccountsVoucher objfrm = new frmAccountsVoucher();
                objfrm.intvtype = (int)Utility.VOUCHER_TYPE.vtPAYMENT_VOUCHER;
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.lngFormPriv = 103;
                objfrm.strFormName = "Payment";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmAccountsVoucher objfrm = (frmAccountsVoucher)Application.OpenForms["frmAccountsVoucher"];
                objfrm.lngFormPriv = 103;
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }

        }

        private void btnReceipt_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 104))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmAccountsVoucher"] as frmAccountsVoucher == null)
            {
                frmAccountsVoucher objfrm = new frmAccountsVoucher();
                objfrm.intvtype = (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER;
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.strFormName = "Receipt";
                objfrm.lngFormPriv = 104;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmAccountsVoucher objfrm = (frmAccountsVoucher)Application.OpenForms["frmAccountsVoucher"];
                objfrm.lngFormPriv = 104;
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }

        }

        private void btnContra_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 106))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmAccountsVoucher"] as frmAccountsVoucher == null)
            {
                frmAccountsVoucher objfrm = new frmAccountsVoucher();
                objfrm.intvtype = (int)Utility.VOUCHER_TYPE.vtCONTRA_VOUCHER;
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.lngFormPriv = 106;
                objfrm.strFormName = "Contra";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmAccountsVoucher objfrm = (frmAccountsVoucher)Application.OpenForms["frmAccountsVoucher"];
                objfrm.lngFormPriv = 106;
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }

        }

        private void btnJournal_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 105))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmAccountsVoucher"] as frmAccountsVoucher == null)
            {
                frmAccountsVoucher objfrm = new frmAccountsVoucher();
                objfrm.intvtype = (int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER;
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.lngFormPriv = 105;
                objfrm.strFormName = "Journal";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmAccountsVoucher objfrm = (frmAccountsVoucher)Application.OpenForms["frmAccountsVoucher"];
                objfrm.lngFormPriv = 105;
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }


        }

        private void btnVoucherTypes_Click(object sender, EventArgs e)
        {
            //if (Utility.gblnAccessControl)
            //{
            //    if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 99))
            //    {
            //         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
            //        return;
            //    }
            //}
            //if (System.Windows.Forms.Application.OpenForms["frmVoucherTypesList"] as frmVoucherTypesList == null)
            //{
            //    frmVoucherTypesList objfrm = new frmVoucherTypesList();
            //    objfrm.lngMtype = (long)Utility.MODULE_TYPE.mtACCOUNT;
            //    objfrm.lngFormPriv = 99;
            //    objfrm.Show();
            //    objfrm.MdiParent = this.MdiParent;

            //}
            //else
            //{
            //    frmVoucherTypesList objfrm = (frmVoucherTypesList)Application.OpenForms["frmVoucherTypesList"];
            //    objfrm.lngFormPriv = 99;
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}

        }

        private void btnBranch_Click(object sender, EventArgs e)
        {
            //if (Utility.gblnAccessControl)
            //{
            //    if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 94))
            //    {
            //         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
            //        return;
            //    }
            //}
            //if (System.Windows.Forms.Application.OpenForms["frmBranch"] as frmBranch == null)
            //{
            //    frmBranch objfrm = new frmBranch();
            //    objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            //    objfrm.lngFormPriv = 94;
            //    objfrm.Show();
            //    objfrm.MdiParent = this.MdiParent;
               

            //}
            //else
            //{
            //    frmBranch objfrm = (frmBranch)Application.OpenForms["frmBranch"];
            //    objfrm.lngFormPriv = 94;
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}

        }

        private void btnCostCenter_Click(object sender, EventArgs e)
        {
            //if (Utility.gblnAccessControl)
            //{
            //    if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 98))
            //    {
            //         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
            //        return;
            //    }
            //}
            //if (System.Windows.Forms.Application.OpenForms["frmCostCenter"] as frmCostCenter == null)
            //{
            //    frmCostCenter objfrm = new frmCostCenter();
            //    objfrm.lngFormPriv = 98;
            //    objfrm.Show();
            //    objfrm.MdiParent = this.MdiParent;

            //}
            //else
            //{
            //    frmCostCenter objfrm = (frmCostCenter)Application.OpenForms["frmCostCenter"];
            //    objfrm.lngFormPriv = 98;
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}

        }

        private void btnCostCategory_Click(object sender, EventArgs e)
        {
            //if (Utility.gblnAccessControl)
            //{
            //    if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 97))
            //    {
            //         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
            //        return;
            //    }
            //}
            //if (System.Windows.Forms.Application.OpenForms["frmCostCategory"] as frmCostCategory == null)
            //{
            //    frmCostCategory objfrm = new frmCostCategory();
            //    objfrm.lngFormPriv = 97;
            //    objfrm.Show();
            //    objfrm.MdiParent = this.MdiParent;

            //}
            //else
            //{
            //    frmCostCategory objfrm = (frmCostCategory)Application.OpenForms["frmCostCategory"];
            //    objfrm.lngFormPriv = 97;
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}

        }

        private void btnLedger_Click(object sender, EventArgs e)
        {
            //if (Utility.gblnAccessControl)
            //{
            //    if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 96))
            //    {
            //         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
            //        return;
            //    }
            //}
            //if (System.Windows.Forms.Application.OpenForms["frmAccountsLedger"] as frmAccountsLedger == null)
            //{
            //    frmAccountsLedger objfrm = new frmAccountsLedger();
            //    objfrm.m_acction = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            //    objfrm.lngFormPriv = 96;
            //    objfrm.Show();
            //    objfrm.BringToFront();
            //    objfrm.MdiParent = this.MdiParent;

            //}
            //else
            //{
            //    frmAccountsLedger objfrm = (frmAccountsLedger)Application.OpenForms["frmAccountsLedger"];
            //    objfrm.lngFormPriv = 96;
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}

        }

        private void btnGroups_Click(object sender, EventArgs e)
        {
            //if (Utility.gblnAccessControl)
            //{
            //    if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 95))
            //    {
            //         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
            //        return;
            //    }
            //}
            //if (System.Windows.Forms.Application.OpenForms["frmGroupConfiguration"] as frmGroupConfiguration == null)
            //{
            //    frmGroupConfiguration objfrm = new frmGroupConfiguration();
            //    objfrm.lngFormPriv = 95;
            //    objfrm.intModuleType = (int)Utility.MODULE_TYPE.mtACCOUNT;
            //    objfrm.strFoemName = "Group";
            //    objfrm.Show();
            //    objfrm.MdiParent = this.MdiParent;

            //}
            //else
            //{
            //    frmGroupConfiguration objfrm = (frmGroupConfiguration)Application.OpenForms["frmGroupConfiguration"];
            //    objfrm.strFoemName = "Group";
            //    objfrm.lngFormPriv = 95;
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}

        }


        private void btnTrailBalance_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 116))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptTrailBalance"] as frmRptTrailBalance == null)
            {
                frmRptTrailBalance objfrm = new frmRptTrailBalance();
                objfrm.strReportName = "Trail Balance";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptTrailBalance objfrm = (frmRptTrailBalance)Application.OpenForms["frmRptTrailBalance"];
                objfrm.strReportName = "Trail Balance";
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }

        }



        private void btnAccountBooks_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 110))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmAccountBooks"] as frmAccountBooks == null)
            {
                frmAccountBooks objfrm = new frmAccountBooks();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmAccountBooks objfrm = (frmAccountBooks)Application.OpenForms["frmAccountBooks"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }

        }

        private void btnFinalAccounts_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 118))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmFinalAccounts"] as frmFinalAccounts == null)
            {
                frmFinalAccounts objfrm = new frmFinalAccounts();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmFinalAccounts objfrm = (frmFinalAccounts)Application.OpenForms["frmFinalAccounts"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }

        }

        private void btnRptCostCenter_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 123))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            //if (System.Windows.Forms.Application.OpenForms["frmCostCenterMain"] as frmCostCenterMain == null)
            //{
            //    frmCostCenterMain objfrm = new frmCostCenterMain();
            //    objfrm.Show();
            //    objfrm.MdiParent = this.MdiParent;

            //}
            //else
            //{
            //    frmCostCenterMain objfrm = (frmCostCenterMain)Application.OpenForms["frmCostCenterMain"];
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}

        }

        private void btnReceiptPayment_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 117))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptAccounts"] as frmRptAccounts == null)
            {
                frmRptAccounts objfrm = new frmRptAccounts();
                objfrm.strReportName = "Receipt && Payment";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptAccounts objfrm = (frmRptAccounts)Application.OpenForms["frmRptAccounts"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }

        }

        private void btnManufacturing_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 127))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptStatistics"] as frmRptStatistics == null)
            {
                frmRptStatistics objfrm = new frmRptStatistics();
                objfrm.strReportName = "Manufacturing";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptStatistics objfrm = (frmRptStatistics)Application.OpenForms["frmRptStatistics"];
                objfrm.strReportName = "Manufacturing";
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }

        }

        private void btnDailyCollection_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 128))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptDailyCollection"] as frmRptDailyCollection == null)
            {
                frmRptDailyCollection objfrm = new frmRptDailyCollection();
                objfrm.strReportName = "Daily Collection";
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

       

        private void btnFinalStatement_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 130))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptFinalStatement"] as frmRptFinalStatement == null)
            {
                frmRptFinalStatement objfrm = new frmRptFinalStatement();
                objfrm.strReportName = "Final Settlement";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptFinalStatement objfrm = (frmRptFinalStatement)Application.OpenForms["frmRptFinalStatement"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }

        }

        private void btnLedgerConfiguration_Click(object sender, EventArgs e)
        {
           

        }

        private void btnMpoCommission_Click(object sender, EventArgs e)
        {
            

        }

        private void btnInterestCharge_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 108))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmInterestChargee"] as frmInterestChargee == null)
            {
                frmInterestChargee objfrm = new frmInterestChargee();
                objfrm.lngFormPriv = 108;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmInterestChargee objfrm = (frmInterestChargee)Application.OpenForms["frmInterestChargee"];
                objfrm.lngFormPriv = 108;
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }

        }

        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 109))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmDashBoard"] as frmDashBoard == null)
            {
                frmDashBoard objfrm = new frmDashBoard();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmDashBoard objfrm = (frmDashBoard)Application.OpenForms["frmDashBoard"];
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
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            //if (System.Windows.Forms.Application.OpenForms["frmFixedAssets"] as frmFixedAssets == null)
            //{
            //    frmFixedAssets objfrm = new frmFixedAssets();
            //    objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            //    objfrm.lngFormPriv = 100;
            //    objfrm.Show();
            //    objfrm.MdiParent = this.MdiParent;

            //}
            //else
            //{
            //    frmFixedAssets objfrm = (frmFixedAssets)Application.OpenForms["frmFixedAssets"];
            //    objfrm.lngFormPriv = 100;
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}

        }

        private void btnMarketMonitoringSheet_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 131))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptFinalStatement"] as frmRptFinalStatement == null)
            {
                frmRptFinalStatement objfrm = new frmRptFinalStatement();
                objfrm.strReportName = "Market Monitoring Sheet";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptFinalStatement objfrm = (frmRptFinalStatement)Application.OpenForms["frmRptFinalStatement"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }

        }



        private void frmAccountsMain_Load(object sender, EventArgs e)
        {

        }

        private void btnBudget_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 101))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmBudget"] as frmBudget == null)
            {
                frmBudget objfrm = new frmBudget();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.lngFormPriv = 101;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmBudget objfrm = (frmBudget)Application.OpenForms["frmBudget"];
                objfrm.lngFormPriv = 101;
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnChequePayment_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 138))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptStatistics"] as frmRptStatistics == null)
            {
                frmRptStatistics objfrm = new frmRptStatistics();
                objfrm.strReportName = "Cheque Payment";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptStatistics objfrm = (frmRptStatistics)Application.OpenForms["frmRptStatistics"];
                objfrm.strReportName = "Cheque Payment";
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }

        }

        private void btnSPCommission_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 136))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptStatisticsNew"] as frmRptStatisticsNew == null)
            {
                frmRptStatisticsNew objfrm = new frmRptStatisticsNew();
                objfrm.strReportName = "Special Commission";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptStatisticsNew objfrm = (frmRptStatisticsNew)Application.OpenForms["frmRptStatisticsNew"];
                objfrm.strReportName = "Special Commission";
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }

        }

        private void btnRptFixedAssets_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 134))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptFixetAsset"] as frmRptFixetAsset == null)
            {
                frmRptFixetAsset objfrm = new frmRptFixetAsset();
                objfrm.strReportName = "Fixed Assets";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptFixetAsset objfrm = (frmRptFixetAsset)Application.OpenForms["frmRptFixetAsset"];
                objfrm.strReportName = "Fixed Assets";
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }

        }

      

        private void btnRptPDC_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 135))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptPostDatedCheque"] as frmRptPostDatedCheque == null)
            {
                frmRptPostDatedCheque objfrm = new frmRptPostDatedCheque();
                objfrm.strReportName = "Post Dated Cheque";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptPostDatedCheque objfrm = (frmRptPostDatedCheque)Application.OpenForms["frmRptPostDatedCheque"];
                objfrm.strReportName = "Post Dated Cheque";
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }

        }

        private void btnSalesCollectionAchieve_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 137))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptTargetAchievment"] as frmRptTargetAchievment == null)
            {
                frmRptTargetAchievment objfrm = new frmRptTargetAchievment();
                objfrm.strReportName = "Target and Achievement";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptTargetAchievment objfrm = (frmRptTargetAchievment)Application.OpenForms["frmRptTargetAchievment"];
                objfrm.strReportName = "Target and Achievement";
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }

        }

        private void btnChequePrint_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 139))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptChequePrint"] as frmRptChequePrint == null)
            {
                frmRptChequePrint objfrm = new frmRptChequePrint();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptChequePrint objfrm = (frmRptChequePrint)Application.OpenForms["frmRptChequePrint"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }

        }

        private void btnExpenseSummary_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 132))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptStatistics"] as frmRptStatistics == null)
            {
                frmRptStatistics objfrm = new frmRptStatistics();
                objfrm.strReportName = "Payment Summary";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptStatistics objfrm = (frmRptStatistics)Application.OpenForms["frmRptStatistics"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }

        }

        private void frmAccountsMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                var strResponse = MessageBox.Show("                    Quit                    ", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponse == DialogResult.Yes)
                {
                    this.Dispose();
                }
            }
            else if (e.KeyCode == Keys.B && e.Modifiers == Keys.Control)
            {
                btnBranch_Click(sender, e);
            }
            else if (e.KeyCode == Keys.G && e.Modifiers == Keys.Control)
            {
                btnGroups_Click(sender, e);
            }
            else if (e.KeyCode == Keys.L && e.Modifiers == Keys.Control)
            {
                btnLedger_Click(sender, e);
            }
            else if (e.KeyCode == Keys.P && e.Modifiers == Keys.Control)
            {
                btnPayment_Click(sender, e);
            }
            else if (e.KeyCode == Keys.R && e.Modifiers == Keys.Control)
            {
                btnReceipt_Click(sender, e);
            }
            else if (e.KeyCode == Keys.J && e.Modifiers == Keys.Control)
            {
                btnJournal_Click(sender, e);
            }
            else if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {
                btnContra_Click(sender, e);
            }
            else if (e.KeyCode == Keys.D && e.Modifiers == Keys.Control)
            {
                btnCommissionTran_Click(sender, e);
            }
            else if (e.KeyCode == Keys.M && e.Modifiers == Keys.Control)
            {
                btnMpoCommission_Click(sender, e);
            }
            else if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
            {
                btnDashBoard_Click(sender, e);
            }
        }

        private void btnBudgetVariance_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 157))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptBudget"] as frmRptBudget == null)
            {
                frmRptBudget objfrm = new frmRptBudget();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptBudget objfrm = (frmRptBudget)Application.OpenForms["frmRptBudget"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnCommissionTran_Click(object sender, EventArgs e)
        {
            //if (System.Windows.Forms.Application.OpenForms["frmMPOCommissionTran"] as frmMPOCommissionTran == null)
            //{
            //    frmMPOCommissionTran objfrm = new frmMPOCommissionTran();
            //    objfrm.Show();
            //    objfrm.MdiParent = this.MdiParent;

            //}
            //else
            //{
            //    frmMPOCommissionTran objfrm = (frmMPOCommissionTran)Application.OpenForms["frmMPOCommissionTran"];
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}
        }

      

        private void btnCollectionMonth_Click(object sender, EventArgs e)
        {
           
        }

        private void btnBankReceiptPayment_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 172))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptRP"] as frmRptRP == null)
            {
                frmRptRP objfrm = new frmRptRP();
                objfrm.Show();
                objfrm.MdiParent = MdiParent;

            }
            else
            {
                frmRptRP objfrm = (frmRptRP)Application.OpenForms["frmRptRP"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }

        }

        private void btnBankReconcilation_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 171))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmBankReconcilation"] as frmBankReconcilation == null)
            {
                frmBankReconcilation objfrm = new frmBankReconcilation();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmBankReconcilation objfrm = (frmBankReconcilation)Application.OpenForms["frmBankReconcilation"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnBankReconcilation_Click_1(object sender, EventArgs e)
        {

        }

        private void btnAddCommssionBill_Click(object sender, EventArgs e)
        {
            
        }

        private void btnMpoConfig_Click(object sender, EventArgs e)
        {
            //if (System.Windows.Forms.Application.OpenForms["frmMPOCommission"] as frmMPOCommission == null)
            //{
            //    frmMPOCommission objfrm = new frmMPOCommission();
            //    objfrm.Show();
            //    objfrm.MdiParent = this.MdiParent;

            //}
            //else
            //{
            //    frmMPOCommission objfrm = (frmMPOCommission)Application.OpenForms["frmMPOCommission"];
            //    objfrm.Focus();
            //    objfrm.MdiParent = this.MdiParent;
            //}
        }

        private void btnContractParty_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["frmContractPartyBill"] as frmContractPartyBill == null)
            {
                frmContractPartyBill objfrm = new frmContractPartyBill();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmContractPartyBill objfrm = (frmContractPartyBill)Application.OpenForms["frmContractPartyBill"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnLoan_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 173))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (System.Windows.Forms.Application.OpenForms["frmLoanSchedule"] as frmLoanSchedule == null)
            {
                frmLoanSchedule objfrm = new frmLoanSchedule();
                objfrm.lngFormPriv = 173;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmLoanSchedule objfrm = (frmLoanSchedule)Application.OpenForms["frmLoanSchedule"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnRptHondLoan_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 175))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (System.Windows.Forms.Application.OpenForms["frmRptHondaLoan"] as frmRptHondaLoan == null)
            {
                frmRptHondaLoan objfrm = new frmRptHondaLoan();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptHondaLoan objfrm = (frmRptHondaLoan)Application.OpenForms["frmRptHondaLoan"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnAutoPFHL_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, 193, 1))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (System.Windows.Forms.Application.OpenForms["frmAutoJV"] as frmAutoJV == null)
            {
                frmAutoJV objfrm = new frmAutoJV();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmAutoJV objfrm = (frmAutoJV)Application.OpenForms["frmAutoJV"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        
       
      

        
       

       













    }
}
