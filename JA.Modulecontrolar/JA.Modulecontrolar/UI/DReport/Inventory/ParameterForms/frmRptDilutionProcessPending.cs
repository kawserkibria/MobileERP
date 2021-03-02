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
using JA.Modulecontrolar.UI.DReport.Inventory.Viewer;
using Microsoft.Win32;
namespace JA.Modulecontrolar.UI.DReport.Inventory.ParameterForms
{
    public partial class frmRptDilutionProcessPending : JA.Shared.UI.frmSmartFormStandard
    {
       
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        SPWOIS objswp = new SPWOIS();
        private ListBox lstFgLocation = new ListBox();
        public string strName { get; set; }
        private string strComID { get; set; }
        int intmode = 1;
        public frmRptDilutionProcessPending()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.dteFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteFromDate_KeyPress);
            this.dteFromDate.GotFocus += new System.EventHandler(this.dteFromDate_GotFocus);
            this.dteToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteToDate_KeyPress);
            this.dteToDate.GotFocus += new System.EventHandler(this.dteToDate_GotFocus);
         
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

        #region "User Deifne"

        private void dteFromDate_GotFocus(object sender, System.EventArgs e)
        {
            lstFgLocation.Visible = false;
        }
        private void dteToDate_GotFocus(object sender, System.EventArgs e)
        {
            lstFgLocation.Visible = false;

        }
        private void dteFromDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
               
                dteToDate.Focus();

            }
        }

        private void dteToDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnPrint.Focus();

            }
        }
       

        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {

            frmReportViewer frmviewer = new frmReportViewer();
            frmviewer.selector = ViewerSelector.DilutionProPen;
            frmviewer.strFdate = dteFromDate.Text;
            frmviewer.strTdate = dteToDate.Text;
            frmviewer.Show();


        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmRptDilutionProcessPending_Load(object sender, EventArgs e)
        {

        }
   
    }
}
