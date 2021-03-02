using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using Dutility;
using System.Drawing.Drawing2D;
using JA.Modulecontrolar.JSAPUR;
using JA.Modulecontrolar.JINVMS;
using JA.Modulecontrolar.JACCMS;
using JA.Modulecontrolar.EXTRA;

using JA.Modulecontrolar.UI.DReport.Sales.Viewer;

namespace JA.Modulecontrolar.UI.DReport.Sales.ParameterForms

{
    public partial class frmRptYearlyCPSPAnalysis : JA.Shared.UI.frmSmartFormStandard 
    {
      
        public string strMontNameYY = "";
        public string strMontName = "";

        public string strThisMonth = "";
        public string strLastMonth= "";

       

        JACCMS.SWJAGClient accms = new JACCMS.SWJAGClient();
        JSAPUR.WSalesPurchaseClient orpt = new WSalesPurchaseClient();
        EXTRA.SWPRJClient objExtra = new EXTRA.SWPRJClient();
     
     
        private string strComID { get; set; }
       
      
        public string strReportName { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        private ListBox lstBranch = new ListBox();
        public frmRptYearlyCPSPAnalysis()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.uctxtBranch.GotFocus += new System.EventHandler(this.uctxtBranch_GotFocus);
            this.uctxtBranch.KeyDown += new KeyEventHandler(uctxtBranch_KeyDown);
            this.uctxtBranch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranch_KeyPress);
            this.lstBranch.DoubleClick += new System.EventHandler(this.lstBranch_DoubleClick);
            this.uctxtBranch.TextChanged += new System.EventHandler(this.uctxtBranch_TextChanged);

            this.txtSearch.KeyDown += new KeyEventHandler(txtSearch_KeyDown);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtSearch_KeyPress);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            
            this.dteFPreviousYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dteFPreviousYear_KeyPress);
            this.dteTPreviousYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dteTPreviousYear_KeyPress);
            this.dteFCurrentYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dteFCurrentYear_KeyPress);
            this.dteTCurrentYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dteTCurrentYear_KeyPress);
            this.lstLeft.DoubleClick += new System.EventHandler(this.lstLeft_DoubleClick);

            this.btnRightAll.Click += new System.EventHandler(this.btnRightAll_Click);
            this.btnRightSingle.Click += new System.EventHandler(this.btnRightSingle_Click);
            this.btnLeftSingle.Click += new System.EventHandler(this.btnLeftSingle_Click);
            this.btnLeftAll.Click += new System.EventHandler(this.btnLeftAll_Click);
            Utility.CreateListBox(lstBranch, pnlMain, uctxtBranch, 0);
           
      
           
        }

        private void uctxtBranch_TextChanged(object sender, EventArgs e)
        {
            lstBranch.SelectedIndex = lstBranch.FindString(uctxtBranch.Text);
        }
        private void uctxtBranch_GotFocus(object sender, System.EventArgs e)
        {
            lstBranch.Visible = true;
            lstBranch.SelectedIndex = lstBranch.FindString(uctxtBranch.Text);
        }
        private void lstBranch_DoubleClick(object sender, EventArgs e)
        {
            uctxtBranch.Text = lstBranch.Text;
            lstBranch.Visible = false;
            dteFPreviousYear .Focus();
        }
        private void uctxtBranch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBranch.Items.Count > 0)
                {
                    uctxtBranch.Text = lstBranch.Text;
                    dteFPreviousYear.Focus();
                    lstBranch.Visible = false;
                }

               
            }
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

      
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            lstLeft.SelectedIndex = lstLeft.FindString(txtSearch.Text);
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

    
        private void lstLeft_DoubleClick(object sender, EventArgs e)
        {
            if (lstLeft.SelectedItems.Count > 0)
            {
                lstRight.Items.Add(lstLeft.SelectedItem.ToString());
                lstRight.SelectedValue = lstLeft.SelectedValue;
                lstLeft.Items.Remove(lstLeft.SelectedItem.ToString());
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

   


        private void mLoadLedgerName()
        {
            int Intmode = 0;
            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            groupSelection.Enabled = true;
   
            if (rbtnMPO.Checked == true)
            {
                Intmode = 4;
            }
            if (rbtnAMFM.Checked == true)
            {
                Intmode = 3;
            }
            if (rbtnDSMRSM.Checked == true)
            {
                Intmode = 2;
            }
            if (rbtnZONE.Checked == true)
            {
                Intmode = 1;
            }


            List<Mprojection> orptt = objExtra.mGetLedgerGroupLoad(strComID, Intmode, Utility.gstrUserName, 0, "").ToList();
            if (orptt.Count > 0)
            {


                foreach (Mprojection ostk in orptt)
                {
                    lstLeft.Items.Add(ostk.strGRName);
                }
            }

            txtSearch.Focus();
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
      

        private void dateset()
        {
            string strMonth = "";
            int intMonth = 0, intYY = 0;

            //strMonth = txtMonthID.Text.Substring(0, 3).ToUpper();

            //intYY = Convert.ToInt32(txtMonthID.Text.Substring(3, 2));
            intYY = Convert.ToInt32("20" + intYY);
            if (strMonth == "JAN")
            {
                intMonth = 1;
            }
            else if (strMonth == "FEB")
            {
                intMonth = 2;
            }
            else if (strMonth == "MAR")
            {
                intMonth = 3;
            }

            else if (strMonth == "APR")
            {
                intMonth = 4;
            }

            else if (strMonth == "MAY")
            {
                intMonth = 5;
            }

            else if (strMonth == "JUN")
            {
                intMonth = 6;
            }

            else if (strMonth == "JUL")
            {
                intMonth = 7;
            }

            else if (strMonth == "AUG")
            {
                intMonth = 8;
            }

            else if (strMonth == "SEP")
            {
                intMonth = 9;
            }

            else if (strMonth == "OCT")
            {
                intMonth = 10;
            }
            else if (strMonth == "NOV")
            {
                intMonth = 11;
            }
            else if (strMonth == "DEC")
            {
                intMonth = 12;
            }
            else
            {
                return;
            }

        

        }

        private void frmRptYearlyCPSPAnalysis_Load(object sender, EventArgs e)
        {
            
            groupSelection.Enabled = false;
            dteFCurrentYear.Text = DateTime.Now.ToString();
            dteTCurrentYear.Text = DateTime.Now.ToString();
            lstBranch.ValueMember = "BranchID";
            lstBranch.DisplayMember = "BranchName";
            lstBranch.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
          
            
          
        }

   
        private void rbtnMPO_Click(object sender, EventArgs e)
        {

            mLoadLedgerName();
          

        }

        private void rbtnAMFM_Click(object sender, EventArgs e)
        {
            mLoadLedgerName();
        }

        private void rbtnDSMRSM_Click(object sender, EventArgs e)
        {
            mLoadLedgerName();
        }

        private void rbtnZONE_Click(object sender, EventArgs e)
        {
            mLoadLedgerName();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string strBranchId = "", strString2 = "";
            int intmode = 0, intSalesCollAch = 0;
          
                intSalesCollAch = 1;
            

            if (rbtnAll.Checked == true)
            {
                intmode = 5;
            }
            if (rbtnMPO.Checked == true)
            {
                intmode = 4;
            }
            if (rbtnAMFM.Checked == true)
            {
                intmode = 3;
            }
            if (rbtnDSMRSM.Checked == true)
            {
                intmode = 2;
            }
            if (rbtnZONE.Checked == true)
            {
                intmode = 1;
            }

            if (uctxtBranch.Text == "")
            {
                MessageBox.Show("Please Select Branch Name.");
                return;
            }
            else
            {
                strBranchId = Utility.gstrGetBranchID(strComID, uctxtBranch.Text);
            }
          

            if (rbtnAll.Checked != true)
            {

                if (lstRight.Items.Count <= 0)
                {
                    MessageBox.Show("Data Not Found.");
                    return;
                }
            }


            for (int i = 0; i < lstRight.Items.Count; i++)
            {
                strString2 = strString2 + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
            }
            if (strString2 != "")
            {
                strString2 = Utility.Mid(strString2, 0, strString2.Length - 1);
            }

            frmReportViewer frmviewer = new frmReportViewer();
            frmviewer.selector = ViewerSelector.CPSPSalescollPer;
            frmviewer.intMode = intmode;
            frmviewer.strString2 = strString2;
            frmviewer.strFdate = dteFCurrentYear.Text;
            frmviewer.strTdate = dteTCurrentYear.Text;
            frmviewer.strFPreviousdate = dteFPreviousYear .Text;
            frmviewer.strTPreviousdate  = dteTPreviousYear.Text;
            frmviewer.strOldComID = txtOldcomID.Text;
            frmviewer.strBranchId = strBranchId;
            frmviewer.intMode = intmode;
            frmviewer.intStatus = intSalesCollAch;
            frmviewer.secondParameter1 = uctxtBranch.Text;
            frmviewer.reportTitle2 = "A";
            frmviewer.Show();

        }

        private void rbtnAll_Click(object sender, EventArgs e)
        {
            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            groupSelection.Enabled = false;

        }

        private void dteFPreviousYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dteTPreviousYear.Focus();
            }
        }

        private void dteTPreviousYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dteFCurrentYear.Focus();
            }
        }
        private void dteFCurrentYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dteTCurrentYear.Focus();
            }
        }
        private void dteTCurrentYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnPrint.Focus();
            }
        }

     

       
       

    
    }
}
