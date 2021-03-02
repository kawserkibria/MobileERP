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
using JA.Modulecontrolar.UI.DReport.Accms.Viewer;
using JA.Modulecontrolar.UI.DReport.Accms;
using Microsoft.Win32;

namespace JA.Modulecontrolar.UI.Tools.Forms
{
    public partial class frmStatictics : JA.Shared.UI.frmSmartFormStandard
    {
      public string strReportName { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        private string strComID { get; set; }
        public frmStatictics()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.dtpFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dtpFromDate_KeyPress);
            //this.dteFromDate.GotFocus += new System.EventHandler(this.dteFromDate_GotFocus);

            this.dtpToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dtpToDate_KeyPress);


        }

        private void dtpFromDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                dtpToDate.Focus();

            }
        }

        private void dtpToDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                btnSave.Focus();

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.Statistics;
                frmviewer.strFdate = dtpFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dtpToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.Show();

        }
    }


}

