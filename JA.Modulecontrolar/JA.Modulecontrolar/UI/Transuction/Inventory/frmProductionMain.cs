using Dutility;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JA.Modulecontrolar.UI.Transuction.Inventory
{
    public partial class frmProductionMain : JA.Shared.UI.frmSmartFormStandard
    {
        private string strComID { get; set; }
        public frmProductionMain()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmProductionMain_KeyDown);
        }
        private void frmProductionMain_KeyDown(object sender, KeyEventArgs e)
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
        private void frmMFGVoucherProcess_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 68))
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
                objfrm.lngFormPriv = 68;
                objfrm.strFormName = "MFG Voucher";
                objfrm.intconvert = 0;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmMFGVoucher objfrm = (frmMFGVoucher)Application.OpenForms["frmMFGVoucher"];
                objfrm.strFormName = "MFG Voucher";
                objfrm.lngFormPriv = 68;
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

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

        private void btnConsumption_Click(object sender, EventArgs e)
        {
            //if (Utility.gblnAccessControl)
            //{
            //    if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 69))
            //    {
            //        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }
            //}
            if (System.Windows.Forms.Application.OpenForms["frmMFGVoucherManual"] as frmMFGVoucherManual == null)
            {
                frmMFGVoucherManual objfrm = new frmMFGVoucherManual();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.intvType = (int)Utility.VOUCHER_TYPE.vtSTOCK_MFG_CONSUMPTION;
                objfrm.lngFormPriv = 69;
                objfrm.strFormName = "Conversion FG";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmMFGVoucherManual objfrm = (frmMFGVoucherManual)Application.OpenForms["frmMFGVoucherManual"];
                objfrm.strFormName = "Conversion FG";
                objfrm.lngFormPriv = 69;
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
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
                objfrm.strFormName = "Consumption";
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmMFGStockConsumDilution objfrm = (frmMFGStockConsumDilution)Application.OpenForms["frmMFGStockConsumDilution"];
                objfrm.strFormName = "Consumption";
                objfrm.lngFormPriv = 66;
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

       
    }
}
