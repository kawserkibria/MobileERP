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
    public partial class frmAccountBooks : JA.Shared.UI.frmSmartFormStandard
    {
        private string strComID { get; set; }
        public frmAccountBooks()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
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
        private void btnVoucherReports_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 111))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptAccountsVoucher"] as frmRptAccountsVoucher == null)
            {
                frmRptAccountsVoucher objfrm = new frmRptAccountsVoucher();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptAccountsVoucher objfrm = (frmRptAccountsVoucher)Application.OpenForms["frmRptAccountsVoucher"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
            
        }

        private void btnLedger_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 112))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptAccountsLedger"] as frmRptAccountsLedger == null)
            {
                frmRptAccountsLedger objfrm = new frmRptAccountsLedger();
                objfrm.strMpo = "";
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

        private void btnDayBook_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 113))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptAccountsDayBook"] as frmRptAccountsDayBook == null)
            {
                frmRptAccountsDayBook objfrm = new frmRptAccountsDayBook();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptAccountsDayBook objfrm = (frmRptAccountsDayBook)Application.OpenForms["frmRptAccountsDayBook"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }

          
        }

        private void btnCashBankBook_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 114))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptCashbank"] as frmRptCashbank == null)
            {
                frmRptCashbank objfrm = new frmRptCashbank();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptCashbank objfrm = (frmRptCashbank)Application.OpenForms["frmRptCashbank"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
         
        }

        private void btnGroupSummary_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 115))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptGroupSummary"] as frmRptGroupSummary == null)
            {
                frmRptGroupSummary objfrm = new frmRptGroupSummary();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptGroupSummary objfrm = (frmRptGroupSummary)Application.OpenForms["frmRptGroupSummary"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
           
        
        }

        private void btnRptHLPFStatement_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 194))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptPF_HL"] as frmRptPF_HL == null)
            {
                frmRptPF_HL objfrm = new frmRptPF_HL();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptPF_HL objfrm = (frmRptPF_HL)Application.OpenForms["frmRptPF_HL"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

     
    }
}
