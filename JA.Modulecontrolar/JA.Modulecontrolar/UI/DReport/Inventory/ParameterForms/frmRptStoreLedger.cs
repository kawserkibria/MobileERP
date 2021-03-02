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
    public partial class frmRptStoreLedger : JA.Shared.UI.frmSmartFormStandard
    {
        private ListBox lstLocation = new ListBox();
        private ListBox lstItem = new ListBox();
        //JACCMS.SWJAGClient accms = new SWJAGClient();
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        private string strComID { get; set; }
        public frmRptStoreLedger()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.dteFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteFromDate_KeyPress);
            this.dteFromDate.GotFocus += new System.EventHandler(this.dteFromDate_GotFocus);

            this.dteToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteToDate_KeyPress);
            this.dteToDate.GotFocus += new System.EventHandler(this.dteToDate_GotFocus);


            this.txtLocationName.KeyDown += new KeyEventHandler(txtLocationName_KeyDown);
            this.txtLocationName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtLocationName_KeyPress);
            this.txtLocationName.TextChanged += new System.EventHandler(this.txtLocationName_TextChanged);
            this.lstLocation.DoubleClick += new System.EventHandler(this.lstLocation_DoubleClick);
            this.txtLocationName.GotFocus += new System.EventHandler(this.txtLocationName_GotFocus);


            this.uctxtItemName.KeyDown += new KeyEventHandler(uctxtItemName_KeyDown);
            this.uctxtItemName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtItemName_KeyPress);
            this.uctxtItemName.TextChanged += new System.EventHandler(this.uctxtItemName_TextChanged);
            this.lstItem.DoubleClick += new System.EventHandler(this.lstItem_DoubleClick);
            this.uctxtItemName.GotFocus += new System.EventHandler(this.uctxtItemName_GotFocus);
            Utility.CreateListBox(lstLocation, pnlMain, txtLocationName);
            Utility.CreateListBox(lstItem, pnlMain, uctxtItemName);
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
            lstItem.Visible = false;
            lstLocation.Visible = false;

        }
        private void dteToDate_GotFocus(object sender, System.EventArgs e)
        {
            lstItem.Visible = false;
            lstLocation.Visible = false;

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
                uctxtItemName.Focus();

            }
        }
        private void uctxtItemName_TextChanged(object sender, EventArgs e)
        {
            lstItem.SelectedIndex = lstItem.FindString(uctxtItemName.Text);
        }

        private void lstItem_DoubleClick(object sender, EventArgs e)
        {
            uctxtItemName.Text = lstItem.Text;
            btnPrint.Focus();
            lstItem.Visible = false;
        }

        private void uctxtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstItem.Items.Count > 0)
                {
                    uctxtItemName.Text = lstItem.Text;
                }
                lstItem.Visible = false;
                btnPrint.Focus();

            }
        }
        private void uctxtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstItem.SelectedItem != null)
                {
                    lstItem.SelectedIndex = lstItem.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstItem.Items.Count - 1 > lstItem.SelectedIndex)
                {
                    lstItem.SelectedIndex = lstItem.SelectedIndex + 1;
                }
            }

        }
        private void mLoadLocation()
        {
            lstLocation.ValueMember = "strLocation";
            lstLocation.DisplayMember = "strLocation";
            lstLocation.DataSource = invms.mLoadLocation(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
        }
        private void uctxtItemName_GotFocus(object sender, System.EventArgs e)
        {
            lstItem.Visible = true;
            lstLocation.Visible = false;
          
            lstItem.SelectedIndex = lstItem.FindString(uctxtItemName.Text);
           
        }
        private void txtLocationName_TextChanged(object sender, EventArgs e)
        {
            lstLocation.SelectedIndex = lstLocation.FindString(txtLocationName.Text);
        }

        private void lstLocation_DoubleClick(object sender, EventArgs e)
        {
            txtLocationName.Text = lstLocation.Text;
            dteFromDate.Focus();
        }

        private void txtLocationName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstLocation.Items.Count > 0)
                {
                    txtLocationName.Text = lstLocation.Text;
                }
                dteFromDate.Focus();

            }
        }
        private void txtLocationName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstLocation.SelectedItem != null)
                {
                    lstLocation.SelectedIndex = lstLocation.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstLocation.Items.Count - 1 > lstLocation.SelectedIndex)
                {
                    lstLocation.SelectedIndex = lstLocation.SelectedIndex + 1;
                }
            }

        }

        private void txtLocationName_GotFocus(object sender, System.EventArgs e)
        {
            lstLocation.Visible = true;
            lstItem.Visible = false;
           
            lstLocation.SelectedIndex = lstLocation.FindString(txtLocationName.Text);
            
        }

        #endregion
        private void mLaodItem()
        {
            lstItem.ValueMember = "strItemName";
            lstItem.DisplayMember = "strItemName";
            lstItem.DataSource = invms.gFillStockItemAllWithoutGodown(strComID, Utility.gblnAccessControl, Utility.gstrUserName,"").ToList();
         
        }

        private void radIndividual_Click(object sender, EventArgs e)
        {
           
            txtLocationName.Enabled = true;
            txtLocationName.Text = "";
            txtLocationName.Focus();
        }

        private void radAll_Click(object sender, EventArgs e)
        {
            dteFromDate.Focus();
            txtLocationName.Text = "";
            uctxtItemName.Text = "";
            txtLocationName.Enabled = false;
        }

        private void frmRptStoreLedger_Load(object sender, EventArgs e)
        {
            
            lstLocation.Visible = false;
            lstItem.Visible = false;
            mLoadLocation();
            mLaodItem();
            //dteFromDate.Text = Utility.gdteFinancialYearFrom;
            //dteToDate.Text = Utility.gdteFinancialYearTo;
            dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            if (radAll.Checked == true)
            {

                string strLocation = "";
                if (txtLocationName.Text == "")
                {
                    strLocation = "";
                }
                else
                {
                    strLocation = txtLocationName.Text;
                }

                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.storeLedger;
                frmviewer.strFdate = dteFromDate.Text;
                frmviewer.strTdate = dteToDate.Text;
                frmviewer.strString2 = uctxtItemName.Text;
                frmviewer.strSelction = strLocation;
                frmviewer.Show();
            }




            if (radIndividual.Checked == true)
            {

                string strLocation = "";
                if (txtLocationName.Text == "")
                {
                    strLocation = "";
                }
                else
                {
                    strLocation = txtLocationName.Text;
                }

                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.storeLedgerIndividual;
                frmviewer.strFdate = dteFromDate.Text;
                frmviewer.strTdate = dteToDate.Text;
                //frmviewer.strString2 = "Location Nmae: " +strLocation + " & Item Name: "+ uctxtItemName.Text;
                frmviewer.strString2 = uctxtItemName.Text;
                frmviewer.strSelction = strLocation;
                frmviewer.Show();
            }

        }

    }
}
