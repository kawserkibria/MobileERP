using ExtraReports.Projection.Forms;
using ExtraReports.Projection.Reports.RProjection.ParameterForms;
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

namespace ExtraReports.Projection.Forms
{
    public partial class frmProMain : Form
    {
        public frmProMain()
        {
            InitializeComponent();
        }

      
        private void btnProjectionMonth_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["frmMonthSetUp"] as frmMonthSetUp == null)
            {
                frmMonthSetUp objfrm = new frmMonthSetUp();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmMonthSetUp objfrm = (frmMonthSetUp)Application.OpenForms["frmMonthSetUp"];
                objfrm.Focus();

            }
        }

        private void btnProjection_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["frmProjectionSetup"] as frmProjectionSetup == null)
            {
                frmProjectionSetup objfrm = new frmProjectionSetup();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmProjectionSetup objfrm = (frmProjectionSetup)Application.OpenForms["frmProjectionSetup"];
                objfrm.Focus();

            }
        }

        private void btnPerformance_Click(object sender, EventArgs e)
        {
            //if (Utility.gblnAccessControl)
            //{
            //    if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 110))
            //    {
            //        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }
            //}
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
            if (System.Windows.Forms.Application.OpenForms["frmMonthlyProjection"] as frmMonthlyProjection == null)
            {
                frmMonthlyProjection objfrm = new frmMonthlyProjection();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmMonthlyProjection objfrm = (frmMonthlyProjection)Application.OpenForms["frmMonthlyProjection"];
                objfrm.Focus();

            }
        }

        private void btnWeeklyProjection_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["frmWeeklyProjection"] as frmWeeklyProjection == null)
            {
                frmWeeklyProjection objfrm = new frmWeeklyProjection();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;
            }
            else
            {
                frmWeeklyProjection objfrm = (frmWeeklyProjection)Application.OpenForms["frmWeeklyProjection"];
                objfrm.Focus();
            }
        }

        private void btnrptProjection_Click(object sender, EventArgs e)
        {
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







    }
}
