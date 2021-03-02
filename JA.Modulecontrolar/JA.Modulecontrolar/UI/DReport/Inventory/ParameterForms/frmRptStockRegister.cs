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
    public partial class frmRptStockRegister : JA.Shared.UI.frmSmartFormStandard
    {
       
        //JACCMS.SWJAGClient accms = new SWJAGClient();
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        SPWOIS objswp = new SPWOIS();
        private ListBox lstFgLocation = new ListBox();
        public string strName { get; set; }
        private string strComID { get; set; }
        int intmode = 1;
        public frmRptStockRegister()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.dteFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteFromDate_KeyPress);
            this.dteFromDate.GotFocus += new System.EventHandler(this.dteFromDate_GotFocus);

            this.dteToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteToDate_KeyPress);
            this.dteToDate.GotFocus += new System.EventHandler(this.dteToDate_GotFocus);

            this.txtFgLocation.KeyDown += new KeyEventHandler(txtFgLocation_KeyDown);
            this.txtFgLocation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtFgLocation_KeyPress);
            this.txtFgLocation.TextChanged += new System.EventHandler(this.txtFgLocation_TextChanged);
            this.lstFgLocation.DoubleClick += new System.EventHandler(this.lstFgLocation_DoubleClick);
            this.txtFgLocation.GotFocus += new System.EventHandler(this.txtFgLocation_GotFocus);


            Utility.CreateListBox(lstFgLocation, pnlMain, txtFgLocation);

         
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
        private void txtFgLocation_TextChanged(object sender, EventArgs e)
        {
            lstFgLocation.SelectedIndex = lstFgLocation.FindString(txtFgLocation.Text);
        }

        private void lstFgLocation_DoubleClick(object sender, EventArgs e)
        {
            txtFgLocation.Text = lstFgLocation.Text;
            lstFgLocation.Visible = false;
            dteFromDate.Focus();
        }

        private void txtFgLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstFgLocation.Items.Count > 0)
                {
                    txtFgLocation.Text = lstFgLocation.Text;
                }
                lstFgLocation.Visible = false;
                dteFromDate.Focus();
            }
            

        }
        private void txtFgLocation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstFgLocation.SelectedItem != null)
                {
                    lstFgLocation.SelectedIndex = lstFgLocation.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstFgLocation.Items.Count - 1 > lstFgLocation.SelectedIndex)
                {
                    lstFgLocation.SelectedIndex = lstFgLocation.SelectedIndex + 1;
                }
            }

        }


        private void txtFgLocation_GotFocus(object sender, System.EventArgs e)
        {

            lstFgLocation.Visible = true;
            lstFgLocation.SelectedIndex = lstFgLocation.FindString(txtFgLocation.Text);
           
        }



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
            int intoutint = 0, intallIndiv=0 ,intfromtolocation=0 ;


            if (rbtnTransferOut.Checked== true)
            {
                intoutint = 1;
            }
            else
            {
                intoutint = 2;
            }
            if (radAll.Checked == true)
            {
                intallIndiv = 1;
            }
            else
            {
                intallIndiv = 2;
            }
            if (radFromLocation.Checked == true)
            {
                intfromtolocation = 1;
            }
            else
            {
                intfromtolocation = 2;
            }

            frmReportViewer frmviewer = new frmReportViewer();
            frmviewer.selector = ViewerSelector.StockRegister;
            frmviewer.strFdate = dteFromDate.Text;
            frmviewer.strTdate = dteToDate.Text;
            frmviewer.intSorting = intoutint;
            frmviewer.intSuppress = intallIndiv;
            frmviewer.intype = intfromtolocation;
            if (radIndividual.Checked)
            {
                if (radFromLocation.Checked)
                {
                    frmviewer.strFromLocation = txtFgLocation.Text;
                    frmviewer.strToLocation = "";
                }
                else
                {
                    frmviewer.strToLocation = txtFgLocation.Text;
                    frmviewer.strFromLocation = "";
                }
            }
            else
            {
                frmviewer.strFromLocation = "";
                frmviewer.strToLocation = "";
            }
            frmviewer.Show();


        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void frmRptProduct_Load(object sender, EventArgs e)
        {
            dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");
            LocationLoad();
        }

        private void LocationLoad()
        {
            lstFgLocation.Visible = true;
            lstFgLocation.ValueMember = "strLocation";
            lstFgLocation.DisplayMember = "strLocation";
            lstFgLocation.DataSource = invms.mLoadLocation(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList(); 
            //List<Location> oogrp = invms.mLoadLocation(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();

        }
        private void radAll_Click(object sender, EventArgs e)
        {
            pnlIndividual.Visible = false;
            txtFgLocation.Enabled = false;
            txtFgLocation.Text = "";
            dteFromDate.Focus();
        }

        private void radIndividual_Click(object sender, EventArgs e)
        {
            pnlIndividual.Visible = true;
            txtFgLocation.Enabled = true;
            lstFgLocation.Visible = true;
            txtFgLocation.Text = "";
            txtFgLocation.Focus();
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radFromLocation_Click(object sender, EventArgs e)
        {
            intmode = 1;
            LocationLoad();
        }

        private void radToLocation_Click(object sender, EventArgs e)
        {
            intmode = 0;
            LocationLoad();
        }
    }
}
