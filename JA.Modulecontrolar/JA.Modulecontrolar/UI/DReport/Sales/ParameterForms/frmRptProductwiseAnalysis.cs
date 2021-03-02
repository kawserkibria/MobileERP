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
using JA.Modulecontrolar.JACCMS;
using JA.Modulecontrolar.JSAPUR;
using JA.Modulecontrolar.UI.DReport.Sales.Viewer;
using Microsoft.Win32;
namespace JA.Modulecontrolar.UI.DReport.Sales.ParameterForms
{
    public partial class frmRptProductwiseAnalysis : JA.Shared.UI.frmSmartFormStandard 
    {
        public string frname = "";
        private ListBox lstBranch = new ListBox();
        private ListBox lstMrName = new ListBox();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public int led = 0;
        public int Item = 0;
        public string strReportName { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        private string strComID { get; set; }


        List<Invoice> ooPartyName;
        List<AccountdGroup> oogrp;

        JSAPUR.WSalesPurchaseClient orpt = new WSalesPurchaseClient();

        public frmRptProductwiseAnalysis()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.cmbTranType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(cmbTranType_KeyPress);
            this.dteFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteFromDate_KeyPress);
            //this.dteFromDate.GotFocus += new System.EventHandler(this.dteFromDate_GotFocus);
            this.dteToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteToDate_KeyPress);


            this.txtSearch.KeyDown += new KeyEventHandler(txtSearch_KeyDown);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtSearch_KeyPress);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.lstLeft.DoubleClick += new System.EventHandler(this.lstLeft_DoubleClick);
            //this.lstRight2.DoubleClick += new System.EventHandler(this.lstRight2_DoubleClick);
        }

        #region "User Deifne"    
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            lstLeft.SelectedIndex = lstLeft.FindString(txtSearch.Text);
        }

        private void lstLeft_DoubleClick(object sender, EventArgs e)
        {
            if (lstLeft.SelectedItems.Count > 0)
            {
                lstRight.Items.Add(lstLeft.SelectedItem.ToString());
                lstRight.SelectedValue = lstLeft.SelectedValue;
                lstLeft.Items.Remove(lstLeft.SelectedItem.ToString());
            }

        }


       
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                //txtSearch.Text = "";

                if (lstLeft.SelectedItems.Count > 0)
                {
                    lstRight.Items.Add(lstLeft.SelectedItem.ToString());
                    lstRight.SelectedValue = lstLeft.SelectedValue;
                    lstLeft.Items.Remove(lstLeft.SelectedItem.ToString());
                    txtSearch.Text = "";
                    txtSearch.Focus();
                }
                //btnPrint.Focus();       
            }

        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstLeft.SelectedItem != null)
                {
                    lstLeft.SelectedIndex = lstLeft.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstLeft.Items.Count - 1 > lstLeft.SelectedIndex)
                {
                    lstLeft.SelectedIndex = lstLeft.SelectedIndex + 1;
                }
            }
            //if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            //{
            //    frmAccountsLedger objfrm = new frmAccountsLedger();
            //    objfrm.m_acction = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            //    objfrm.mSingleEntry = 1;
            //    objfrm.Show();

            //}

        }

        private void uctxtBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstBranch.SelectedItem != null)
                {
                    lstBranch.SelectedIndex = lstBranch.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstBranch.Items.Count - 1 > lstBranch.SelectedIndex)
                {
                    lstBranch.SelectedIndex = lstBranch.SelectedIndex + 1;
                }
            }

        }    
        private void dteFromDate_GotFocus(object sender, System.EventArgs e)
        {
            lstBranch.Visible = false;       
        }

        private void cmbTranType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnPrint.Focus();
            }
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
                cmbTranType.Focus();
            }
        }      
        #endregion
        private void radAll_Click(object sender, EventArgs e)
        {
            dteFromDate.Focus();
        }
        private void frmRptStoreLedger_Load(object sender, EventArgs e)
        {
            dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");
            btnOK.Visible = false;
            btncancel.Visible = false;
            txtSearch.Visible = false;
            lstLeft2.Visible = false;
            lstRight2.Visible = false;
            groupSelection.Enabled = false;
            btn1.Enabled = false;
            btn2.Enabled = false;
            frmLabel.Text = "";
            cmbTranType.Text = "";
            ChkboxProdkuctTotal.Visible  = true  ;

            //cheSupPartyT.Enabled = false;
            if (strReportName =="Purchase")
            {
                frmLabel.Text = "Productwise/Partywise Analysis";
                cmbTranType.Text = "Purchase Invoice";
                cmbTranType.Items.Add ("Purchase Invoice");              
                cmbTranType.Items.Add ("Purchase Return");
                cmbTranType.Items.Add("Receive Inventory");
                btn1.Text = "Select Party";
                btn2.Text = "Select Product";
                radPartyW.Text = "Party Wise";
                cheSupPartyT.Text = "Supress Party Total";
            }
            else
            {
                frmLabel.Text = "Productwise/MPOwise Analysis";
                cmbTranType.Text = "Sales Invoice";
                cmbTranType.Items.Add("Sales Invoice");
                cmbTranType.Items.Add("Sales Chalan");
                cmbTranType.Items.Add("Sales Return");
                btn1.Text = "Select MPO";
                btn2.Text = "Select Product";
                cheSupPartyT.Text = "Supress MPO Total";
            }
        }
        private void trueFales()
        {

            //cheSupPartyT.Checked = false;
            //ChkboxProdkuctTotal.Checked = false;
            //cheSupPartyT.Enabled = false;
            //ChkboxProdkuctTotal.Enabled = false;
            //if ((radPartyW.Checked == true) && (radItemwiseSum.Checked == true))
            //{
            //    cheSupPartyT.Enabled = true;
            //    ChkboxProdkuctTotal.Enabled = false;
            //}
            //if ((radPartyW.Checked == true) && (radItemWDet.Checked == true))
            //{
            //    cheSupPartyT.Enabled = true;
            //    ChkboxProdkuctTotal.Enabled = true;
            //}
            //if ((radProductW.Checked == true) && (radItemwiseSum.Checked == true))
            //{
            //    cheSupPartyT.Enabled = false;
            //    ChkboxProdkuctTotal.Enabled = false;
            //}
            //if ((radProductW.Checked == true) && (radItemWDet.Checked == true))
            //{
            //    cheSupPartyT.Enabled = true;
            //    ChkboxProdkuctTotal.Enabled = false;
            //}     
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {    
            string VouMode = "";
            string  VouType ="";
            string LedgerePurchase = "";
            int suppressProducttotal = 0;
            int suppressPartytotal = 0;
            if  (cheSupPartyT.Checked == true)
            {
                suppressPartytotal = 1;
            }
            if (cheSupPartyT.Enabled  == false)
            {
                suppressPartytotal = 1;
            }
            if (ChkboxProdkuctTotal.Checked == true)
            {
                suppressProducttotal = 2;
            }
            if (ChkboxProdkuctTotal.Enabled  == false)
            {
                suppressProducttotal = 2;
            }

            if (strReportName == "Purchase")
            {
                LedgerePurchase = "Purchase";
                if (cmbTranType.Text == "Purchase Invoice")
                {
                    VouType = "33";
                }
                else if (cmbTranType.Text == "Purchase Return")
                {
                    VouType = "32";
                }
                else if (cmbTranType.Text == "Receive Inventory")
                {
                    VouType = "12";
                }
            }
            if (strReportName == "Sales")
            {
                LedgerePurchase = "Sales";
                if (cmbTranType.Text == "Sales Invoice")
                {
                    VouType = "16";
                }
                else if (cmbTranType.Text == "Sales Chalan")
                {
                    VouType = "15";
                }
                else if (cmbTranType.Text == "Sales Return")
                {
                    VouType = "13";
                }
            }
            string strString = "";
            if (radSelection.Checked == true)
                if (lstLeft2.Items.Count <= 0)
                {
                    MessageBox.Show("Data Not Found.");
                    return;
                }
            {
                for (int i = 0; i < lstLeft2.Items.Count; i++)
                {
                    strString = strString + "'" + lstLeft2.Items[i].ToString().Replace("'","''") + "',";
                }
                if (strString != "")
                {
                    strString = Utility.Mid(strString, 0, strString.Length - 1);
                }
            }
            
            string strString2 = "";
            if (radSelection.Checked == true)
                if (lstRight2.Items.Count <= 0)
                {
                    MessageBox.Show("Data Not Found.");
                    return;
                }
            {
                for (int i = 0; i < lstRight2.Items.Count; i++)
                {
                    strString2 = strString2 + "'" + lstRight2.Items[i].ToString().Replace("'","''") + "',";
                }
                if (strString2 != "")
                {
                    strString2 = Utility.Mid(strString2, 0, strString2.Length - 1);
                }
            }
            if ((radPartyW.Checked == true) && (radItemwiseSum.Checked == true) && (radall.Checked == true) && (cheSupPartyT.Checked == true))
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.PartyWiseProductWise;
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strSelction = VouType;
                frmviewer.strString2 = LedgerePurchase;
                frmviewer.strString = strString;
                frmviewer.intSuppress = suppressPartytotal;
                frmviewer.intSuppress2 = suppressProducttotal;
                frmviewer.intMode = 2;
                frmviewer.reportTitle2 = "A";
                frmviewer.Show();
                return;
            }

            if ((radPartyW.Checked == true) && (radItemWDet.Checked == true) && (radSelection.Checked == true) && (ChkboxProdkuctTotal.Checked == true) && (cheSupPartyT.Checked == true))
            {

                frmReportViewer frmviewer = new frmReportViewer();

                frmviewer.selector = ViewerSelector.PartyWiseProductWise;

                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strSelction = VouType;
                frmviewer.strString2 = LedgerePurchase;
                frmviewer.strString = strString;
                frmviewer.intMode = 3;
                frmviewer.intSuppress = 10;
                frmviewer.strString3 = strString2;
                frmviewer.reportTitle2 = "A";
                frmviewer.Show();
                return;
            }
            if ((radPartyW.Checked == true) && (radItemWDet.Checked == true) && (radSelection.Checked == true) && (cheSupPartyT.Checked == true))
            {
                frmReportViewer frmviewer = new frmReportViewer();
                if (textBox1.Text == "Led")
                {
                    frmviewer.selector = ViewerSelector.PartyWiseProductWise;
                }
                if (textBox1.Text == "Item")
                {
                    frmviewer.selector = ViewerSelector.PartyWiseProductWise2;
                }
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strSelction = VouType;
                frmviewer.strString2 = LedgerePurchase;
                frmviewer.strString = strString;
                frmviewer.strString3 = strString2;
                frmviewer.intSuppress = 8;
                frmviewer.reportTitle2 = "A";
                frmviewer.intMode = 3;
                frmviewer.Show();
                return;
            }
            if ((radPartyW.Checked == true) && (radItemWDet.Checked == true) && (radSelection.Checked == true) && (ChkboxProdkuctTotal.Checked == true))
            {

                frmReportViewer frmviewer = new frmReportViewer();

                frmviewer.selector = ViewerSelector.PartyWiseProductWise;

                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strSelction = VouType;
                frmviewer.strString2 = LedgerePurchase;
                frmviewer.strString = strString;
                frmviewer.intMode = 3;
                frmviewer.intSuppress = 9;
                //frmviewer.intMode = suppress2;
                frmviewer.strString3 = strString2;
                frmviewer.reportTitle2 = "A";
                frmviewer.Show();
                return;
            }
            if ((radPartyW.Checked == true) && (radItemwiseSum.Checked == true) && (radSelection.Checked == true))
            {

                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.PartyWiseProductWise;
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strSelction = VouType;
                frmviewer.strString2 = LedgerePurchase;
                frmviewer.strString = strString;
                frmviewer.intSuppress = suppressPartytotal;
                frmviewer.intSuppress2 = suppressProducttotal;
                frmviewer.strString3 = strString2;
                frmviewer.intMode = 2;              
                frmviewer.reportTitle2 = "A";
                frmviewer.Show();
                return;
            }
            if ((radProductW.Checked == true) && (radItemWDet.Checked == true) && (radSelection.Checked == true) && (cheSupPartyT.Checked == true))
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.PartyWiseProductWise;
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strSelction = VouType;
                frmviewer.strString2 = LedgerePurchase;
                frmviewer.strString = strString;
                frmviewer.intSuppress = suppressPartytotal;
                frmviewer.intSuppress2 = suppressProducttotal;
                frmviewer.strString3 = strString2;
                frmviewer.reportTitle2 = "A";
                frmviewer.intMode = 6;
                frmviewer.Show();
                return;
            }
            if ((radProductW.Checked == true) && (radItemwiseSum.Checked == true) && (radSelection.Checked == true))
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.PartyWiseProductWise;
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strSelction = VouType;
                frmviewer.strString2 = LedgerePurchase;
                frmviewer.strString = strString;
                frmviewer.intSuppress = suppressPartytotal;
                frmviewer.intSuppress2 = suppressProducttotal;
                frmviewer.strString3 = strString2;
                frmviewer.reportTitle2 = "A";
                frmviewer.intMode = 4;
                frmviewer.Show();
                return;
            }

            if ((radProductW.Checked == true) && (radItemWDet.Checked == true) && (radSelection.Checked == true))
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.PartyWiseProductWise;
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strSelction = VouType;
                frmviewer.strString2 = LedgerePurchase;
                frmviewer.strString = strString;
                frmviewer.intSuppress = suppressPartytotal;
                frmviewer.intSuppress2 = suppressProducttotal;
                frmviewer.strString3 = strString2;
                frmviewer.reportTitle2 = "A";
                frmviewer.intMode = 6;
                frmviewer.Show();
                return;
            }

           
            if ((radPartyW.Checked == true) && (radItemWDet.Checked == true) && (ChkboxProdkuctTotal.Checked == true) && (cheSupPartyT.Checked == true))
            {

                frmReportViewer frmviewer = new frmReportViewer();

                frmviewer.selector = ViewerSelector.PartyWiseProductWise;

                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strSelction = VouType;
                frmviewer.strString2 = LedgerePurchase;
                frmviewer.strString = strString;
                frmviewer.intMode = 3;
                frmviewer.intSuppress = 10;
                //frmviewer.intMode = suppress2;
                frmviewer.reportTitle2 = "A";
                frmviewer.Show();
                return;
            }

            if ((radPartyW.Checked == true) && (radItemWDet.Checked == true) && (cheSupPartyT.Checked == true))
            {
   
                frmReportViewer frmviewer = new frmReportViewer();

                frmviewer.selector = ViewerSelector.PartyWiseProductWise;
  
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strSelction = VouType;
                frmviewer.strString2 = LedgerePurchase;
                frmviewer.strString = strString;
                frmviewer.strString3 = strString2;
                frmviewer.intMode = 3;
                frmviewer.intSuppress = 8;
                //frmviewer.intMode = suppress2;
                frmviewer.reportTitle2 = "A";
                frmviewer.Show();
                return;
            }
            if ((radPartyW.Checked == true) && (radItemWDet.Checked == true) && (ChkboxProdkuctTotal.Checked == true))
            {

                frmReportViewer frmviewer = new frmReportViewer();

                frmviewer.selector = ViewerSelector.PartyWiseProductWise;

                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strSelction = VouType;
                frmviewer.strString2 = LedgerePurchase;
                frmviewer.strString = strString;
                frmviewer.intMode = 3;
                frmviewer.intSuppress = 9;
                //frmviewer.intMode = suppress2;
                frmviewer.reportTitle2 = "A";
                frmviewer.Show();
                return;
            }

            if ((radPartyW.Checked == true) && (radItemWDet.Checked == true) && (radall.Checked == true))
            {

                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.PartyWiseProductWise;
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strSelction = VouType;
                frmviewer.strString2 = LedgerePurchase;
                frmviewer.strString = strString;
                frmviewer.intMode = 3;
                //frmviewer.intSuppress = suppress;
                //frmviewer.intMode = suppress2;
                frmviewer.reportTitle2 = "A";
                frmviewer.Show();
                return;
            }
         

            if ((radPartyW.Checked == true) && (radItemWDet.Checked == true) && (radSelection.Checked == true) )
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.PartyWiseProductWise;
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strSelction = VouType;
                frmviewer.strString2 = LedgerePurchase;
                frmviewer.strString = strString;
                frmviewer.strString3 = strString2;
                frmviewer.intMode = 3;
                //frmviewer.intSuppress = suppress;
                //frmviewer.intMode = suppress2;
                frmviewer.reportTitle2 = "A";
                frmviewer.Show();
                return;
            }
          
            //if ((radProductW.Checked == true) && (radItemWDet.Checked == true) && (radSelection.Checked == true))
            //{
            //    frmReportViewer frmviewer = new frmReportViewer();
            //    if (textBox1.Text == "Led")
            //    {
            //        frmviewer.selector = ViewerSelector.PartyWiseProductWise;
            //    }
            //    if (textBox1.Text == "Item")
            //    {
            //        frmviewer.selector = ViewerSelector.PartyWiseProductWise2;
            //    }
            //    frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
            //    frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
            //    frmviewer.strSelction = VouType;
            //    frmviewer.strString2 = LedgerePurchase;
            //    frmviewer.strString = strString;
            //    frmviewer.intSuppress = suppress;
            //    frmviewer.reportTitle2 = "A";
            //    frmviewer.intMode = 3;
            //    frmviewer.Show();
            //    return;
            //}
            if ((radPartyW.Checked == true) && (radItemWDet.Checked == true) && (radall.Checked == true))
            {
                frmReportViewer frmviewer = new frmReportViewer();
                if (textBox1.Text == "Led")
                {
                    frmviewer.selector = ViewerSelector.PartyWiseProductWise;
                }
                if (textBox1.Text == "Item")
                {
                    frmviewer.selector = ViewerSelector.PartyWiseProductWise2;
                }
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strSelction = VouType;
                frmviewer.strString2 = LedgerePurchase;
                frmviewer.strString = strString;
                frmviewer.intSuppress = suppressPartytotal;
                frmviewer.intSuppress2 = suppressProducttotal;
                frmviewer.reportTitle2 = "A";
                frmviewer.intMode = 3;
                frmviewer.Show();
                return;
            }
            //cheSupPartyT
      
        

            if ((radPartyW.Checked == true) && (radItemWDet.Checked == true) && (radall.Checked == true))
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.PartyWiseProductWise;
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                //frmviewer.intSuppress = suppress;
                frmviewer.strSelction = VouType;
                frmviewer.strString2 = LedgerePurchase;
                frmviewer.strString = strString;
                frmviewer.intSuppress = suppressPartytotal;
                frmviewer.intSuppress2 = suppressProducttotal;
                frmviewer.reportTitle2 = "A";
                frmviewer.intMode = 1;
                frmviewer.Show();
                return;
            }
            if ((radPartyW.Checked == true) && (radItemwiseSum.Checked == true) && (radall.Checked == true) )
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.PartyWiseProductWise;
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strSelction = VouType;
                frmviewer.strString2 = LedgerePurchase;
                frmviewer.strString = strString;
                frmviewer.intSuppress = suppressPartytotal;
                frmviewer.intSuppress2 = suppressProducttotal;
                frmviewer.intMode = 2;
                frmviewer.reportTitle2 = "A";
                frmviewer.Show();
                return;
            }

            if ((radPartyW.Checked == true) && (radItemwiseSum.Checked == true) && (radall.Checked == true))
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.PartyWiseProductWise;
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strSelction = VouType;
                frmviewer.strString2 = LedgerePurchase;
                frmviewer.strString = strString;
                frmviewer.intSuppress = suppressPartytotal;
                frmviewer.intSuppress2 = suppressProducttotal;
                frmviewer.reportTitle2 = "A";
                frmviewer.intMode = 2;
                frmviewer.Show();
                return;
            }
            if ((radProductW.Checked == true) && (radItemWDet.Checked == true) && (radall.Checked == true))
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.PartyWiseProductWise;
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strSelction = VouType;
                frmviewer.strString2 = LedgerePurchase;
                frmviewer.strString = strString;
                frmviewer.intSuppress = suppressPartytotal;
                frmviewer.intSuppress2 = suppressProducttotal;
                frmviewer.reportTitle2 = "A";
                frmviewer.intMode = 6;
                frmviewer.Show();
                return;
            }
            if ((radProductW.Checked == true) && (radItemwiseSum.Checked == true) && (radall.Checked == true))
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.PartyWiseProductWise;
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strSelction = VouType;
                frmviewer.strString2 = LedgerePurchase;
                frmviewer.strString = strString;
                frmviewer.intSuppress = suppressPartytotal;
                frmviewer.intSuppress2 = suppressProducttotal;
                frmviewer.reportTitle2 = "A";
                frmviewer.intMode = 4;
                frmviewer.Show();
                return;
            }
        }

        public void radProductW_Click(object sender, EventArgs e)
        {

            cheSupPartyT.Checked = false;
            ChkboxProdkuctTotal.Checked = false;
            cheSupPartyT.Enabled = false;
            ChkboxProdkuctTotal.Enabled = false;
            radPartyW.Checked = false;
            if ((radProductW.Checked == true) && (radItemWDet.Checked == true))
            {
                cheSupPartyT.Enabled = true;
                ChkboxProdkuctTotal.Enabled = false;
            }
            if ((radPartyW.Checked == true) && (radItemWDet.Checked == true))
            {
                cheSupPartyT.Enabled = true;
                ChkboxProdkuctTotal.Enabled = false;
            }
            if ((radProductW.Checked == true) && (radItemwiseSum.Checked == true))
            {
                cheSupPartyT.Enabled = false;
                ChkboxProdkuctTotal.Enabled = false;
            }          

            if (strReportName == "Purchase")
            { 

            }
            else
            {
                radItemwiseSum.Text = "MPO Summary";
                radItemWDet.Text = "MPO Details";
            }
        }

        public void radPartyW_Click(object sender, EventArgs e)
        {
            cheSupPartyT.Checked = false;
            ChkboxProdkuctTotal.Checked = false;
            cheSupPartyT.Enabled = false;
            ChkboxProdkuctTotal.Enabled = false;
            radProductW.Checked = false;
            if ((radPartyW.Checked == true) && (radItemWDet.Checked == true))
            {
                cheSupPartyT.Enabled = true;
                ChkboxProdkuctTotal.Enabled = true;
            }
            if ((radPartyW.Checked == true) && (radItemwiseSum.Checked == true))
            {
                cheSupPartyT.Enabled = true;
                ChkboxProdkuctTotal.Enabled = false;
            }
            radProductW.Checked = false;
            if (strReportName == "Purchase")
            {

            }
            else
            {
                radItemwiseSum.Text = "Itemwise Summary";
                radItemWDet.Text = "Itemwise Details";
            }

        }

        public void radItemwiseSum_Click(object sender, EventArgs e)
        {
            //trueFales();
            radItemWDet.Checked = false;
            cheSupPartyT.Checked = false;
            ChkboxProdkuctTotal.Checked = false;
            cheSupPartyT.Enabled = false;
            ChkboxProdkuctTotal.Enabled = false;
            if ((radPartyW.Checked == true) && (radItemwiseSum.Checked == true))
            {
                cheSupPartyT.Enabled = true;
                ChkboxProdkuctTotal.Enabled = false;
            }
            if ((radProductW.Checked == true) && (radItemwiseSum.Checked == true))
            {
                cheSupPartyT.Enabled = false;
                ChkboxProdkuctTotal.Enabled = false;
            }
        
        }
        public void radItemWDet_Click(object sender, EventArgs e)
        {
            cheSupPartyT.Checked = false;
            ChkboxProdkuctTotal.Checked = false;
            cheSupPartyT.Enabled = false;
            ChkboxProdkuctTotal.Enabled = false;
            if ((radPartyW.Checked == true) && (radItemWDet.Checked == true))
            {
                cheSupPartyT.Enabled = true;
                ChkboxProdkuctTotal.Enabled = true;
            }
            if ((radProductW.Checked == true) && (radItemWDet.Checked == true))
            {
                cheSupPartyT.Enabled = true;
                ChkboxProdkuctTotal.Enabled = false;
            }
            radItemwiseSum.Checked = false;
        }
        public void radioButton2_Click(object sender, EventArgs e)
        {
            groupSelection.Enabled  = false;
            btn1.Enabled = false;
            btn2.Enabled = false;
            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            lstLeft2.Items.Clear();
            lstRight2.Items.Clear();
            txtSearch.Text = "";
        }
        private void radSelection_Click(object sender, EventArgs e)
        {
            groupSelection.Enabled = true;
            btn1.Enabled = true;
            btn2.Enabled = true;
            if (strReportName == "Purchase")
            {
                btn1.Text = "Select Party";
                btn2.Text = "Select Product";
            }
            else
            {
                btn1.Text = "Select MPO";
                btn2.Text = "Select Product";
            }           
        }
        private void mLoadItemname()
        {
            lstLeft.Items.Clear();
            lstRight.Items.Clear();

            string strBranchId = "";
            string strSelction = "";

            //lstLeft.Items.Clear();
            //lstRight.Items.Clear();
            //int intmode = 1;
            int Item = 2;
            if (strReportName == "Purchase")
            {
                {
                    strSelction = "Purchase";
                    List<RProductSales> orptt = orpt.mGetLedgerlistnew(strComID, "", strSelction,3).ToList();
                    if (orptt.Count > 0)
                    {
                        foreach (RProductSales ostk in orptt)
                        {

                            lstLeft.Items.Add(ostk.strLedgername);

                        }
                    }

                }
            }
            else
            {

                strSelction = "Sales";
                List<RProductSales> orptt = orpt.mGetLedgerlistnew(strComID, "", strSelction, 4).ToList();
                if (orptt.Count > 0)
                {
                    foreach (RProductSales ostk in orptt)
                    {

                        lstLeft.Items.Add(ostk.strLedgername);

                    }
                }
            }
        }
        private void mLoadLedgerName()
        {
            lstLeft.Items.Clear();
            //lstRight.Items.Clear();

            string strBranchId = "";
            string strSelction = "";
           
            //lstLeft.Items.Clear();
            //lstRight.Items.Clear();
            int intmode = 0;
            if (strReportName == "Purchase")
            {
                {
                    strSelction = "Purchase";
                    List<RProductSales> orptt = orpt.mGetLedgerlistnew(strComID, "", strSelction, 1).ToList();
                    if (orptt.Count > 0)
                    {
                        foreach (RProductSales ostk in orptt)
                        {

                            lstLeft.Items.Add(ostk.strLedgername);

                        }
                    }
                }
            }
            else
            {

                strSelction = "Sales";
                List<RProductSales> orptt = orpt.mGetLedgerlistnew(strComID, "", strSelction, 2).ToList();
                if (orptt.Count > 0)
                {
                    foreach (RProductSales ostk in orptt)
                    {
                        lstLeft.Items.Add(ostk.strLedgername);
                    }
                }
               
            }


        }

        public void btn1_Click(object sender, EventArgs e)
        {
            lstLeft.Visible = true;
            lstRight.Visible = true;
            lstLeft2.Visible = false;
            lstRight2.Visible = false;
            txtSearch.Visible = true;
            btnOK.Visible = true;
            btncancel.Visible = true;

             textBox2.Text  = "1";
            textBox1.Text = "Led";
            lstRight.Items.Clear();

            if (textBox2.Text == "1")
            {
                for (int i = 0; i < lstLeft2.Items.Count; i++)
                {
                    string strItem = lstLeft2.Items[i].ToString().TrimStart();
                    lstRight.Items.Add(strItem);
                }
               
            }
            else
            {
                for (int i = 0; i < lstLeft2.Items.Count; i++)
                {
                    string strItem = lstLeft2.Items[i].ToString().TrimStart();
                    lstRight.Items.Add(strItem);
                }
                //lstRight.Items.Clear();
            }
            txtSearch.Focus();
            mLoadLedgerName();
        }
        //private void txtSearch_TextChanged(object sender, EventArgs e)
        //{
        //    lstLeft.SelectedIndex = lstLeft.FindString(txtSearch.Text);
        //}

        //private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Return)
        //    {
        //        btnRightSingle.PerformClick();
        //        if (txtSearch.Text != "")
        //        {
        //            txtSearch.Text = "";
        //            txtSearch.Focus();
        //        }
        //        else
        //        {
        //            dteFromDate.Focus();
        //        }
        //    }
        //}
        private void btnRightSingle_Click(object sender, EventArgs e)
        {
            if (lstLeft.SelectedItems.Count > 0)
            {
                lstRight.Items.Add(lstLeft.SelectedItem.ToString());
                lstRight.SelectedValue = lstLeft.SelectedValue;
                lstLeft.Items.Remove(lstLeft.SelectedItem.ToString());
            }
        }

        private void btnRightAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstLeft.Items.Count; i++)
            {
                string strItem = lstLeft.Items[i].ToString().TrimStart();
                lstRight.Items.Add(strItem);
            }
            lstLeft.Items.Clear();
        }
        private void btnLeftSingle_Click(object sender, EventArgs e)
        {
            if (lstRight.SelectedItems.Count > 0)
            {
                lstLeft.Items.Add(lstRight.SelectedItem.ToString());
                lstRight.Items.Remove(lstRight.SelectedItem.ToString());
            }
        }

        private void btnLeftAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstRight.Items.Count; i++)
            {
                string strItem = lstRight.Items[i].ToString().TrimStart();
                lstLeft.Items.Add(strItem);
            }
            lstRight.Items.Clear();
        }
        private void btn2_Click(object sender, EventArgs e)
        {

            lstLeft.Visible = true;
            lstRight.Visible = true;
            lstLeft2.Visible = false;
            lstRight2.Visible = false;
            txtSearch.Visible = true;
            btnOK.Visible = true;
            btncancel.Visible = true;
            txtSearch.Text = "";
            textBox2.Text = "2";
            textBox1.Text = "Item"; 
            //lstRight.Items.Clear();
            mLoadItemname();
            if (textBox2.Text == "1")
            {
                for (int i = 0; i < lstRight2.Items.Count; i++)
                {
                    string strItem = lstRight2.Items[i].ToString().TrimStart();
                    lstRight.Items.Add(strItem);
                }

            }
            else
            {
                for (int i = 0; i < lstRight2.Items.Count; i++)
                {
                    string strItem = lstRight2.Items[i].ToString().TrimStart();
                    lstRight.Items.Add(strItem);
                }
                //lstRight.Items.Clear();
            }
            txtSearch.Focus();
           
        }

        private void cheSupPartyT_Click(object sender, EventArgs e)
        {
            //if (cheSupPartyT.Checked == true)
            //{
            //    ChkboxProdkuctTotal.Checked = false;
            //    cheSupPartyT.Checked = true;
            //}
            //else
            //{
            //    ChkboxProdkuctTotal.Checked = false;
            //    cheSupPartyT.Checked = false;
            //} 
           
        }

        private void ChkboxProdkuctTotal_Click(object sender, EventArgs e)
        {
            //if (ChkboxProdkuctTotal.Checked == true)
            //{
            //    ChkboxProdkuctTotal.Checked = true;
            //    cheSupPartyT.Checked = false;
            //}
            //else
            //{
            //    ChkboxProdkuctTotal.Checked = false;
            //    cheSupPartyT.Checked = false;
            //}     
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //lstRight
            //lstLeft2
            txtSearch.Text = "";
            if (textBox2.Text  == "1")
            {
                lstLeft2.Items.Clear();
                for (int i = 0; i < lstRight.Items.Count; i++)
                {
                    string strItem = lstRight.Items[i].ToString().TrimStart();
                    lstLeft2.Items.Add(strItem);
                }
                //lstRight.Items.Clear();
            }
            else 
            {
                lstRight2.Items.Clear();
                for (int i = 0; i < lstRight.Items.Count; i++)
                {
                    string strItem = lstRight.Items[i].ToString().TrimStart();
                    lstRight2.Items.Add(strItem);
                }
                //lstRight.Items.Clear();
            }
            lstLeft.Visible = false;
            lstRight.Visible = false;
            lstLeft2.Visible = true;
            lstRight2.Visible = true;
            txtSearch.Visible = false;


        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            if (textBox2.Text == "1")
            {
                lstLeft2.Items.Clear();
                for (int i = 0; i < lstRight.Items.Count; i++)
                {
                    string strItem = lstRight.Items[i].ToString().TrimStart();
                    lstLeft2.Items.Add(strItem);
                }
                //lstRight.Items.Clear();
            }
            else
            {
                lstRight2.Items.Clear();
                for (int i = 0; i < lstRight.Items.Count; i++)
                {
                    string strItem = lstRight.Items[i].ToString().TrimStart();
                    lstRight2.Items.Add(strItem);
                }
                //lstRight.Items.Clear();
            }
            lstLeft.Visible = false;
            lstRight.Visible = false;
            lstLeft2.Visible = true;
            lstRight2.Visible = true;
            txtSearch.Visible = false;
        }

        private void lstRight2_DoubleClick(object sender, EventArgs e)
        {
            if (lstRight2.SelectedItems.Count > 0)
            {
                lstLeft.Items.Add(lstRight2.SelectedItem.ToString());
                lstLeft.SelectedValue = lstRight2.SelectedValue;
                lstRight2.Items.Remove(lstRight2.SelectedItem.ToString());
            }
        }

        

    }
}
