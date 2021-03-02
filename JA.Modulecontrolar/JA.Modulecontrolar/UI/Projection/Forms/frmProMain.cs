
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dutility;
using JA.Modulecontrolar.UI.Projection.Reports.RProjection.ParameterForms;
using Microsoft.Win32;

namespace JA.Modulecontrolar.UI.Projection.Forms
{
    public partial class frmProMain : Form
    {
        private string strComID { get; set; }
        public frmProMain()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
        }

      
        private void btnProjectionMonth_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 176))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmMonthSetUp"] as frmMonthSetUp == null)
            {
                frmMonthSetUp objfrm = new frmMonthSetUp();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.lngFormPriv = 176;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmMonthSetUp objfrm = (frmMonthSetUp)Application.OpenForms["frmMonthSetUp"];
                objfrm.lngFormPriv = 176;
                objfrm.Focus();

            }
        }

        private void btnProjection_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 177))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            
            if (System.Windows.Forms.Application.OpenForms["frmProjectionSetup"] as frmProjectionSetup == null)
            {
                frmProjectionSetup objfrm = new frmProjectionSetup();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.lngFormPriv = 177;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmProjectionSetup objfrm = (frmProjectionSetup)Application.OpenForms["frmProjectionSetup"];
                objfrm.lngFormPriv = 177;
                objfrm.Focus();

            }
        }

        private void btnPerformance_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 180))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            
            if (System.Windows.Forms.Application.OpenForms["frmRptPerfoemance"] as frmRptPerfoemance == null)
            {
                frmRptPerfoemance objfrm = new frmRptPerfoemance();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmRptPerfoemance objfrm = (frmRptPerfoemance)Application.OpenForms["frmRptPerfoemance"];
                objfrm.Focus();
             
            }
        }

        private void btnMonthWiseProjection_Click(object sender, EventArgs e)
        {

            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 178))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmMonthlyProjection"] as frmMonthlyProjection == null)
            {
                frmMonthlyProjection objfrm = new frmMonthlyProjection();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.lngFormPriv = 178;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmMonthlyProjection objfrm = (frmMonthlyProjection)Application.OpenForms["frmMonthlyProjection"];
                objfrm.lngFormPriv = 178;
                objfrm.Focus();

            }
        }

        private void btnWeeklyProjection_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 179))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            
            if (System.Windows.Forms.Application.OpenForms["frmWeeklyProjection"] as frmWeeklyProjection == null)
            {
                frmWeeklyProjection objfrm = new frmWeeklyProjection();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.lngFormPriv = 179;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;
            }
            else
            {
                frmWeeklyProjection objfrm = (frmWeeklyProjection)Application.OpenForms["frmWeeklyProjection"];
                objfrm.lngFormPriv = 179;
                objfrm.Focus();
            }
        }

        private void btnrptProjection_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 181))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            
            if (System.Windows.Forms.Application.OpenForms["frmRptProjection"] as frmRptProjection == null)
            {
                frmRptProjection objfrm = new frmRptProjection();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;
            }
            else
            {
                frmRptProjection objfrm = (frmRptProjection)Application.OpenForms["frmRptProjection"];
                objfrm.Focus();

            }
        }

        private void btnrptCollectionComparision_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 182))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            
            if (System.Windows.Forms.Application.OpenForms["frmRptCollComparision"] as frmRptCollComparision == null)
            {
                frmRptCollComparision objfrm = new frmRptCollComparision();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;
            }
            else
            {
                frmRptCollComparision objfrm = (frmRptCollComparision)Application.OpenForms["frmRptCollComparision"];
                objfrm.Focus();

            }
        }

        private void btnProjectionQuickView_Click(object sender, EventArgs e)
        {
            //if (Utility.gblnAccessControl)
            //{
            //    if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 182))
            //    {
            //        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }
            //}

            if (System.Windows.Forms.Application.OpenForms["frmRptCollComparision"] as frmRptCollComparision == null)
            {
                frmRptProjectionQuickView objfrm = new frmRptProjectionQuickView();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;
            }
            else
            {
                frmRptProjectionQuickView objfrm = (frmRptProjectionQuickView)Application.OpenForms["frmRptProjectionQuickView"];
                objfrm.Focus();

            }
        }

     







    }
}
