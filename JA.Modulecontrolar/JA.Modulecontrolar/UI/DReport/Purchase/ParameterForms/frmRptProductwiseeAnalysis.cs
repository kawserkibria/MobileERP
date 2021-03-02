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
using JA.Modulecontrolar.UI.DReport.Purchase.Viewer;
using Microsoft.Win32;
namespace JA.Modulecontrolar.UI.DReport.Purchase.ParameterForms
{
    public partial class frmRptProductwiseeAnalysis : JA.Shared.UI.frmSmartFormStandard
    {
        //private ListBox lstLocation = new ListBox();
        //private ListBox lstItem = new ListBox();
        //JACCMS.SWJAGClient accms = new SWJAGClient();
        private string strComID { get; set; }
        public string strReportName { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public frmRptProductwiseeAnalysis()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.dteFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteFromDate_KeyPress);
            //this.dteFromDate.GotFocus += new System.EventHandler(this.dteFromDate_GotFocus);

            this.dteToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteToDate_KeyPress);
            //this.dteToDate.GotFocus += new System.EventHandler(this.dteToDate_GotFocus);


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
        //private void dteFromDate_GotFocus(object sender, System.EventArgs e)
        //{
        //    lstItem.Visible = false;
        //    lstLocation.Visible = false;

        //}
        //private void dteToDate_GotFocus(object sender, System.EventArgs e)
        //{
        //    lstItem.Visible = false;
        //    lstLocation.Visible = false;

        //}
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
        private void mLaodItem()
        {
            //lstItem.ValueMember = "strItemName";
            //lstItem.DisplayMember = "strItemName";
            //lstItem.DataSource = invms.gFillStockItem("", "", false).ToList();
         
        }

        private void radIndividual_Click(object sender, EventArgs e)
        {
           
            //txtLocationName.Enabled = true;
            //txtLocationName.Focus();
        }

        private void radAll_Click(object sender, EventArgs e)
        {
            dteFromDate.Focus();
            //txtLocationName.Enabled = false;
        }

        private void frmRptStoreLedger_Load(object sender, EventArgs e)
        {
            btnSelectProduct.Visible = false;
            btnParty.Visible = false;
            panel4.Visible = false;
            groupBox6.Top =333;
            groupBox6.Left = 75;
            btnPrint.Top = 360;
            btnClose.Top = 360;
            pnlMain.Height = 500;
            groupBox1.Top = 200;
            this.Height = 510;
            rbtnProductWise.Checked = false;
            rbtn2.Checked = false;

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if ((radPartyWise.Checked == true) && (rbtn1.Checked == true) && (rbtnAll.Checked == true))
            {
                string strBrachID = "";

                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.PartyWiseItemwiseSummAllIndiviPurInv;
                frmviewer.strFdate = dteToDate.Text;
                frmviewer.strTdate = dteToDate.Text;
                //frmviewer.strLedgerName = uctxtMedicalRep.Text;
                //frmviewer.strSelction = "BalanceSheet";

                frmviewer.Show();
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void rbtnSelection_Click(object sender, EventArgs e)
        {
            //603, 701

            btnSelectProduct.Visible = true;
            btnParty.Visible = true;
            panel4.Visible = true;
            groupBox6.Top = 561;
            groupBox6.Left = 75;
            btnPrint.Top = 597;
            btnClose.Top = 597;
            pnlMain.Height = 677;
            groupBox1.Top = 200;
            this.Height = 701;
        }

        private void rbtnAll_Click(object sender, EventArgs e)
        {
            btnSelectProduct.Visible = false;
            btnParty.Visible = false;
            panel4.Visible = false;
            groupBox6.Top = 333;
            groupBox6.Left = 75;
            btnPrint.Top = 360;
            btnClose.Top = 360;
            pnlMain.Height = 500;
            groupBox1.Top = 200;
            this.Height = 510;
        }

        private void radPartyWise_Click(object sender, EventArgs e)
        {

            if (radPartyWise.Checked == true )
            {
                rbtn1.Text = "ItemWise Summary";
                rbtn2.Text = "ItemWise Details";
                btnParty.Text = "Select Party";
                btnSelectProduct.Text = "Select Products";
                label4.Text = "Parties";
                label6.Text = "Products";
            }

            if ((radPartyWise.Checked == true) && (rbtn1.Checked == true))
            {

                chkboxSupressparyTotal.Enabled = true;

            }

            if ((radPartyWise.Checked == true) && (rbtn2.Checked == true))
            {

                chkboxSupressProductTotal.Enabled = true;

            }

            
        }

        private void rbtnProductWise_Click(object sender, EventArgs e)
        {
            if (rbtnProductWise.Checked == true)
            {
                rbtn1.Text = "Party Summary";
                rbtn2.Text = "Party Details";
                btnParty.Text = "Select Products";
                btnSelectProduct.Text = "Select Party";
                label4.Text = "Products";
                label6.Text = "Parties";
            }

            if ((rbtnProductWise.Checked == true) && (rbtn2.Checked == true))
            {
                chkboxSupressProductTotal.Enabled = true;
            
            }
            
        }

        private void rbtn1_Click(object sender, EventArgs e)
        {
            if ((radPartyWise.Checked == true) && (rbtn1.Checked == true))
            {

                chkboxSupressparyTotal.Enabled = true;
               

               chkboxSupressProductTotal.Enabled = false;

               
            }


        }

        private void rbtn2_Click(object sender, EventArgs e)
        {
            if ((radPartyWise.Checked == true) && (rbtn2.Checked == true))
            {

                chkboxSupressProductTotal.Enabled = true;

            }

            if ((rbtnProductWise.Checked == true) && (rbtn2.Checked == true))
            {
                chkboxSupressProductTotal.Enabled = true;

            }
        }

        private void rbtnProductWise_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbtnProductWise_Click_1(object sender, EventArgs e)
        {
            radPartyWise.Checked = false;
            rbtn1.Text = "Party Summary";
            rbtn2.Text = "Party Details";
            btnParty.Text = "Select Product";
            btnSelectProduct.Text = "Select Party";
            label4.Text = "Products";
            label6.Text = "Parties";
        }

        private void radPartyWise_Click_1(object sender, EventArgs e)
        {
            rbtnProductWise.Checked = false;
            rbtn1.Text = "ItemWise Summary";
            rbtn2.Text = "ItemWise Details";
            btnParty.Text = "Select Party";
            btnSelectProduct.Text = "Select Product";
            label4.Text = "Parties";
            label6.Text = "Products";
        }

        private void rbtn1_Click_1(object sender, EventArgs e)
        {
            rbtn2.Checked = false;
        }

        private void rbtn2_Click_1(object sender, EventArgs e)
        {
            rbtn1.Checked = false;
        }
    }
}
