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
    public partial class frmRptSpecialPartyReport : JA.Shared.UI.frmSmartFormStandard
    {
        public string strSelection { get; set; }
        private string strComID { get; set; }
        public frmRptSpecialPartyReport()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

        }

        private void frmRptSpecialPartyReport_Load(object sender, EventArgs e)
        {
            frmLabel.Text = strSelection;
            
        }

        private void btnSalesStatementAmount_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 162))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (System.Windows.Forms.Application.OpenForms["frmRptSpecialparty"] as frmRptSpecialparty == null)
            {
                frmRptSpecialparty objfrm = new frmRptSpecialparty();
                //objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.strSelection = "Sales Statement Report (Amount)";
                objfrm.strFromshow = "Amount";
                objfrm.Show();
                objfrm.MdiParent = MdiParent;

            }
            else
            {
                frmRptSpecialparty objfrm = (frmRptSpecialparty)Application.OpenForms["frmRptSpecialparty"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnSalesStatementProduct_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 163))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (System.Windows.Forms.Application.OpenForms["frmRptSpecialparty"] as frmRptSpecialparty == null)
            {
                frmRptSpecialparty objfrm = new frmRptSpecialparty();
                //objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.strSelection = "Sales Statement Report (Product)";
                objfrm.strFromshow = "Product";
                objfrm.Show();
                objfrm.MdiParent = MdiParent;

            }
            else
            {
                frmRptSpecialparty objfrm = (frmRptSpecialparty)Application.OpenForms["frmRptSpecialparty"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnFinalStatement_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 164))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (System.Windows.Forms.Application.OpenForms["frmRptSpecialparty"] as frmRptSpecialparty == null)
            {
                frmRptSpecialparty objfrm = new frmRptSpecialparty();
                //objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.strSelection = "Final Statement Report ";
                objfrm.strFromshow = "FinalStatement";
                objfrm.Show();
                objfrm.MdiParent = MdiParent;

            }
            else
            {
                frmRptSpecialparty objfrm = (frmRptSpecialparty)Application.OpenForms["frmRptSpecialparty"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

    }
}
