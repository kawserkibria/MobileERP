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
    public partial class frmAccountsvoucherMaster : JA.Shared.UI.frmSmartFormStandard
    {
        private string strComID { get; set; }
        public frmAccountsvoucherMaster()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.btnReceipt.Click += new System.EventHandler(this.btnReceipt_Click);
            this.btnJournal.Click += new System.EventHandler(this.btnJournal_Click);
            this.btnContra.Click += new System.EventHandler(this.btnContra_Click);
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);

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

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 103))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

    

        

       
        

     
    }
}
