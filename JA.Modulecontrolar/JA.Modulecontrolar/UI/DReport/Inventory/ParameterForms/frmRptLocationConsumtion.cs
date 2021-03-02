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
using JA.Modulecontrolar.JACCMS;
using Microsoft.Win32;
//using JA.Modulecontrolar.JACCMS;

namespace JA.Modulecontrolar.UI.DReport.Inventory.ParameterForms
{
    public partial class frmRptLocationConsumtion : JA.Shared.UI.frmSmartFormStandard
    {

        JACCMS.SWJAGClient accms = new SWJAGClient();
        //private ListBox lstBranch = new ListBox();
        public string strReportName { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        private string strComID { get; set; }


        public frmRptLocationConsumtion()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.dteFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteFromDate_KeyPress);
            this.dteFromDate.GotFocus += new System.EventHandler(this.dteFromDate_GotFocus);
            this.dteToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteToDate_KeyPress);
            this.dteToDate.GotFocus += new System.EventHandler(this.dteToDate_GotFocus);
            this.lstLeft.DoubleClick += new System.EventHandler(this.lstLeft_DoubleClick);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

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

           

        }
        private void dteToDate_GotFocus(object sender, System.EventArgs e)
        {
         


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
        private void mLaodItem()
        {

        }
        
        private void radAll_Click(object sender, EventArgs e)
        {
            lstLeft.Enabled = false;
            lstRight.Enabled = false;
            lstRight.Items.Clear();
            dteFromDate.Focus();
        }
        private void frmRptStoreLedger_Load(object sender, EventArgs e)
        {
            dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");
            mLoad();

        }
        private void btnPrint_Click(object sender, EventArgs e)
        {

            string strBranchId = "", strString = "";
            int intType;
            //if (Utility.gblnAccessControl)
            //{
            //    if (lstRight.Items.Count == 0)
            //    {
            //        MessageBox.Show("Insuficient Privileges");
            //        return;
            //    }
            //}

            if (radSummarry.Checked == true)
            {
                intType = 1;
            }
            else
            {
                intType = 2;
            }
            if (lstRight.Items.Count == 0)
            {
                for (int i = 0; i < lstLeft.Items.Count; i++)
                {
                    strString = strString + "'" + lstLeft.Items[i].ToString() + "',";
                }
                if (lstLeft.Items.Count==0)
                {
                    strString = "'NONE',";
                }
                if (strString != "")
                {
                    strString = Utility.Mid(strString, 0, strString.Length - 1);
                }
            }
            else
            {
                for (int i = 0; i < lstRight.Items.Count; i++)
                {
                    strString = strString + "'" + lstRight.Items[i].ToString() + "',";
                }
                if (strString != "")
                {
                    strString = Utility.Mid(strString, 0, strString.Length - 1);
                }
            }

            frmReportViewer frmviewer = new frmReportViewer();
            frmviewer.selector = ViewerSelector.LocationConsum;
            frmviewer.strString = strString;
            frmviewer.strString = strString;
            frmviewer.strFdate = dteFromDate.Text;
            frmviewer.strTdate = dteToDate.Text;
            frmviewer.intype = intType;
            frmviewer.Show();

        }

        private void radCategoryWise_Click(object sender, EventArgs e)
        {
           
        }
        private void radStockGroupWise_Click(object sender, EventArgs e)
        {
         
          
           
        }
        private void mLoad()
        {
            //lstLeft.Items.Clear();
            //List<StockItem> oogrp = invms.gLoadStockGroup(strComID, Utility.gblnAccessControl, Utility.gstrUserName,"Y").ToList();
            //if (oogrp.Count > 0)
            //{
            //    foreach (StockItem ostk in oogrp)
            //    {
            //        lstLeft.Items.Add(ostk.strItemGroup);
            //    }
            //}
            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            List<Location> oogrp = invms.mLoadLocation(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
            if (oogrp.Count > 0)
            {
                foreach (Location ostk in oogrp)
                {
                    lstLeft.Items.Add(ostk.strLocation);
                }
            }

        }
        private void radLevelWise_Click(object sender, EventArgs e)
        {
          
        }
        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRightSingle_Click(object sender, EventArgs e)
        {
            if (lstLeft.SelectedItems.Count > 0)
            {
                lstRight.Items.Add(lstLeft.SelectedItem.ToString());
                lstLeft.Items.Remove(lstLeft.SelectedItem.ToString());
            }
        }

        private void btnLeftSingle_Click(object sender, EventArgs e)
        {
            if (lstRight.SelectedItems.Count > 0)
            {
                lstLeft.Items.Add(lstRight.SelectedItem.ToString());
                lstRight.Items.Remove(lstRight.SelectedItem.ToString());
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

        private void btnLeftAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstRight.Items.Count; i++)
            {
                string strItem = lstRight.Items[i].ToString().TrimStart();
                lstLeft.Items.Add(strItem);
            }
            lstRight.Items.Clear();
        }

        private void radIndividual_Click(object sender, EventArgs e)
        {
            lstLeft.Enabled = true;
            lstRight.Enabled = true;
            lstRight.Items.Clear();
        }

        private void lstLeft_DoubleClick(object sender, EventArgs e)
        {
            btnRightSingle.PerformClick();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            lstLeft.SelectedIndex= lstLeft.FindString(txtSearch.Text);

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
            if (e.KeyChar ==(char)Keys.Return)
            {
                btnRightSingle.PerformClick();
            }
        }

     

      




    }
}
