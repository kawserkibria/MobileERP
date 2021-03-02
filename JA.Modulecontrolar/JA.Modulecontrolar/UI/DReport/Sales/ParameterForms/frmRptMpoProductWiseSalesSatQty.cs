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
    public partial class frmRptMpoProductWiseSalesSatQty : JA.Shared.UI.frmSmartFormStandard
    {
        public string frname = "";
        private ListBox lstBranch = new ListBox();
        private ListBox lstMrName = new ListBox();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public int led = 0;
        public int Item = 0;
        public string strReportName { get; set; }
        public string strMpo = "";
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();

        List<AccountdGroup> oogrp;
        List<RProductSales> ooPartyGroup;

        JSAPUR.WSalesPurchaseClient orpt = new WSalesPurchaseClient();

        private string strComID { get; set; }


        List<Invoice> ooPartyName;




        public frmRptMpoProductWiseSalesSatQty()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

         
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
                txtSearch.Focus();
            }
        }
        #endregion


        private void btnPrint_Click(object sender, EventArgs e)
        {

            string strReporType = "", strProductGroup = "";
            int suppressProducttotal = 0;
            int intMode = 0;
            if (radall.Checked == true)
            {
                if (rbtnvertical.Checked == true)
                {
                    strReporType = "V";
                }
            }
            strProductGroup = "";
            if (rbtnStockGroup.Checked == true)
            {
                strProductGroup = "G";
            }
            if (rbtnProductLoad.Checked == true)
            {
                strProductGroup = "P";
            }
            if (rbtnZONE.Checked==true)
            {
                intMode = 1;
            }
            if (rbtnDSMRSM.Checked == true)
            {
                intMode = 2;
            }
            if (rbtnAMFM.Checked == true)
            {
                intMode = 3;
            }
            if (rbtnMPO.Checked == true)
            {
                intMode = 4;
            }
            if (radall.Checked == true)
            {
                intMode = 5;
            }


            string strString = "";

           
            {
                for (int i = 0; i < lstLeft2.Items.Count; i++)
                {
                    strString = strString + "'" + lstLeft2.Items[i].ToString().Replace("'", "''") + "',";
                }
                if (strString != "")
                {
                    strString = Utility.Mid(strString, 0, strString.Length - 1);
                }
            }

            string strString2 = "";
           
            if (radIndividual.Checked == true)
            {
                if (lstLeft2.Items.Count <= 0)
                {
                    MessageBox.Show("Data Not Found.");
                    return;
                }
            }
            if (radIndividual.Checked == true)
            {
                if (lstRight2.Items.Count <= 0)
                {
                    MessageBox.Show("Data Not Found.");
                    return;
                }
            }
            //if (lstRight2.Items.Count > 7)
            //{
            //    MessageBox.Show("You Add Maximum Seven Product .");
            //    return;
            //}
            {
                for (int i = 0; i < lstRight2.Items.Count; i++)
                {
                    strString2 = strString2 + "'" + lstRight2.Items[i].ToString().Replace("'", "''") + "',";
                }
                if (strString2 != "")
                {
                    strString2 = Utility.Mid(strString2, 0, strString2.Length - 1);
                }
            }

        
            frmReportViewer frmviewer = new frmReportViewer();
            frmviewer.selector = ViewerSelector.MpoProductWiseSalesStatementQty ;
            frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
            frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
            frmviewer.strSelction = textBox3.Text;
            if (radIndividual.Checked == true)
            {
               
                if (rbtnStockGroup.Checked == true)
                {
                    frmviewer.strSelction2 = "G";
                }
                else 
                {
                    frmviewer.strSelction2 = "P";
                }
            }
         
            else
            {
                frmviewer.strSelction2 = strReporType;
            }
            frmviewer.strString = strString;
            frmviewer.strString2 = strString2;
            frmviewer.intMode = intMode;
            frmviewer.intSuppress2 = suppressProducttotal;
            frmviewer.reportTitle2 = "A";
            frmviewer.Show();
            return;



        }

        private void radSelection_Click(object sender, EventArgs e)
        {
            groupSelection.Enabled = true;
            groupBox2.Enabled = false;
            panel2.Enabled = true;
            panel3.Enabled = true;
            dteFromDate.Focus();

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



            string strString = "";


            {
                for (int i = 0; i < lstLeft2.Items.Count; i++)
                {
                    strString = strString + "'" + lstLeft2.Items[i].ToString().Replace("'", "''") + "',";
                }
                if (strString != "")
                {
                    strString = Utility.Mid(strString, 0, strString.Length - 1);
                }
            }

            int intmodeProdctSelection = 0;

            if (rbtnZONE.Checked == true)
            {
                intmodeProdctSelection = 1;
            }
            if (rbtnDSMRSM.Checked == true)
            {
                intmodeProdctSelection = 2;
            }
            if (rbtnAMFM.Checked == true)
            {
                intmodeProdctSelection = 3;
            }
            if (rbtnMPO.Checked == true)
            {
                intmodeProdctSelection = 4;
            }


            List<RProductSales> orptt = orpt.mGetPRoductLoad(strComID, strString, dteFromDate.Text, dteToDate.Text, intmodeProdctSelection, "I").ToList();
            if (orptt.Count > 0)
            {
                foreach (RProductSales ostk in orptt)
                {

                    lstLeft.Items.Add(ostk.strStockItemName);

                }
            }

        }
        private void mLoadLedgerName()
        {
            lstLeft.Items.Clear();
            string strSelction = "";

            if (rbtnMPO.Checked == true)
            {
                strSelction = "Sales";
                List<RSalesPurchase> orptt = orpt.mGetMpoGroupLoad(strComID, 4, strSelction, dteFromDate.Text, dteToDate.Text,Utility.gstrUserName ).ToList();
                if (orptt.Count > 0)
                {
                    foreach (RSalesPurchase ostk in orptt)
                    {
                        lstLeft.Items.Add(ostk.strGRName);
                    }
                }
            }
            if (rbtnAMFM.Checked == true)
            {
                strSelction = "Sales";

                List<RSalesPurchase> orptt = orpt.mGetMpoGroupLoad(strComID, 3, strSelction, dteFromDate.Text, dteToDate.Text, Utility.gstrUserName).ToList();
                if (orptt.Count > 0)
                {
                    foreach (RSalesPurchase ostk in orptt)
                    {
                        lstLeft.Items.Add(ostk.strGRName);
                    }
                }
            }
            if (rbtnDSMRSM.Checked == true)
            {

                strSelction = "Sales";

                List<RSalesPurchase> orptt = orpt.mGetMpoGroupLoad(strComID, 2, strSelction, dteFromDate.Text, dteToDate.Text, Utility.gstrUserName).ToList();
                if (orptt.Count > 0)
                {
                    foreach (RSalesPurchase ostk in orptt)
                    {
                        lstLeft.Items.Add(ostk.strGRName);
                    }
                }
            }
            if (rbtnZONE.Checked == true)
            {

                strSelction = "Sales";

                List<RSalesPurchase> orptt = orpt.mGetMpoGroupLoad(strComID, 1, strSelction, dteFromDate.Text, dteToDate.Text, Utility.gstrUserName).ToList();
                if (orptt.Count > 0)
                {
                    foreach (RSalesPurchase ostk in orptt)
                    {
                        lstLeft.Items.Add(ostk.strGRName);
                    }
                }
            }

        }


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

        }

        private void mLoadStockGroup()
        {
            string strString = "";
            lstLeft.Items.Clear();
            lstRight.Items.Clear();

            lstLeft.Items.Clear();
            lstRight.Items.Clear();


            {
                for (int i = 0; i < lstLeft2.Items.Count; i++)
                {
                    strString = strString + "'" + lstLeft2.Items[i].ToString().Replace("'", "''") + "',";
                }
                if (strString != "")
                {
                    strString = Utility.Mid(strString, 0, strString.Length - 1);
                }
            }

            int intmodeProdctSelection = 0;

            if (rbtnZONE.Checked == true)
            {
                intmodeProdctSelection = 1;
            }
            if (rbtnDSMRSM.Checked == true)
            {
                intmodeProdctSelection = 2;
            }
            if (rbtnAMFM.Checked == true)
            {
                intmodeProdctSelection = 3;
            }
            if (rbtnMPO.Checked == true)
            {
                intmodeProdctSelection = 4;
            }
            List<RProductSales> orptt = orpt.mGetPRoductLoad(strComID, strString, dteFromDate.Text, dteToDate.Text, intmodeProdctSelection, "G").ToList();
            if (orptt.Count > 0)
            {
                foreach (RProductSales ostk in orptt)
                {

                    lstLeft.Items.Add(ostk.strStockItemName);

                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //lstRight
            //lstLeft2
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

        private void btncancel_Click(object sender, EventArgs e)
        {
            lstLeft2.Items.Clear();
            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            lstRight2.Items.Clear();
            //txtSearch.Text = "";
            //if (textBox2.Text == "1")
            //{
            //    lstLeft2.Items.Clear();
            //    for (int i = 0; i < lstRight.Items.Count; i++)
            //    {
            //        string strItem = lstRight.Items[i].ToString().TrimStart();
            //        lstLeft2.Items.Add(strItem);
            //    }
            //    //lstRight.Items.Clear();
            //}
            //else
            //{
            //    lstRight2.Items.Clear();
            //    for (int i = 0; i < lstRight.Items.Count; i++)
            //    {
            //        string strItem = lstRight.Items[i].ToString().TrimStart();
            //        lstRight2.Items.Add(strItem);
            //    }
            //    //lstRight.Items.Clear();
            //}
            //lstLeft.Visible = false;
            //lstRight.Visible = false;
            //lstLeft2.Visible = true;
            //lstRight2.Visible = true;
            //txtSearch.Visible = false;
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

        private void frmRptMpoProductWiseSalesSatQty_Load(object sender, EventArgs e)
        {
            dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");
            btnOK.Visible = true;
            groupBox2.Enabled = true;
            btncancel.Visible = true;
            txtSearch.Visible = true;
            lstLeft2.Visible = false;
            lstRight2.Visible = false;
            groupSelection.Enabled = true;
            panel2.Enabled = false;
            panel3.Enabled = false;
            frmLabel.Text = "";

            frmLabel.Text = "Product Sales Analysis";


        }

        private void radall_Click(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;
            panel2.Enabled = false;
            groupSelection.Enabled = true;
            rbtnMPO.PerformClick();
            rbtnAMFM.PerformClick();
            rbtnDSMRSM.PerformClick();
            rbtnZONE.PerformClick();
            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            lstLeft2.Items.Clear();
            lstRight2.Items.Clear();
            txtSearch.Text = "";
            panel3.Enabled = false;
            radall.Visible = true;
            dteFromDate.Focus();

        }

        private void mLoadMpoLedgerGroup()
        {


            lstLeft.Items.Clear();
            lstRight.Items.Clear();


            txtSearch.Visible = true;
            int Item = 2;
            groupSelection.Enabled = true;

            lstLeft.Enabled = true;

            List<AccountdGroup> orptt = accms.GetGroupList(strComID, 202, false, Utility.gstrUserName).ToList();
            if (orptt.Count > 0)
            {
                foreach (AccountdGroup ostk in orptt)
                {

                    lstLeft.Items.Add(ostk.GroupName);

                }
            }

        }

  
        private void MpoLoad()
        {
            lstLeft.Visible = true;
            lstRight.Visible = true;
            lstLeft2.Visible = false;
            lstRight2.Visible = false;
            txtSearch.Visible = true;
            btnOK.Visible = true;
            btncancel.Visible = true;
            lstRight2.Items.Clear();
            lstLeft2.Items.Clear();
            textBox2.Text = "1";
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




        private void rbtnMPO_Click(object sender, EventArgs e)
        {
            MpoLoad();
        }

        private void rbtnAMFM_Click(object sender, EventArgs e)
        {
            MpoLoad();
        }

        private void rbtnDSMRSM_Click(object sender, EventArgs e)
        {
            MpoLoad();
        }

     
        private void radIndividual_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbtnProductLoad_Click(object sender, EventArgs e)
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

        private void rbtnStockGroup_Click(object sender, EventArgs e)
        {
            lstLeft.Visible = true;
            lstRight.Visible = true;
            lstLeft2.Visible = false;
            lstRight2.Visible = false;
            txtSearch.Visible = true;
            btnOK.Visible = true;
            btncancel.Visible = true;
            textBox3.Text = "G";
            textBox2.Text = "2";
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
            mLoadStockGroup();
        }

        private void rbtnZONE_Click(object sender, EventArgs e)
        {
            MpoLoad();
        }



    }
}
