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
    public partial class frmRptSlowFastMoving : JA.Shared.UI.frmJagoronFromSearch
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public string strType { get; set; }
        private string strComID { get; set; }
        public frmRptSlowFastMoving()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.lstLeft.DoubleClick += new System.EventHandler(this.lstLeft_DoubleClick);
            this.lstLeft.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstLeft_KeyPress);
        }
        private void lstLeft_DoubleClick(object sender, EventArgs e)
        {
            btnRightSingle.PerformClick();
            lstLeft.SetSelected(0, true);
        }

        private void lstLeft_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                btnRightSingle.PerformClick();
                lstLeft.SetSelected(0, true);
                txtSearch.Text = "";
                txtSearch.Focus();
                // dteFromDate.Focus();

            }
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
        private void mLaodItem()
        {
            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            List<StockItem> oogrp = invms.gFillStockItemAllWithoutGodown(strComID, false, Utility.gstrUserName,"").ToList();
            if (oogrp.Count > 0)
            {
                foreach (StockItem ostk in oogrp)
                {
                    lstLeft.Items.Add(ostk.strItemName);
                }
            }
        }

        private void mLoadStockGroup()
        {
            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            List<StockItem> oogrp = invms.gLoadStockGroup(strComID, Utility.gblnAccessControl, Utility.gstrUserName,"N","").ToList();
            if (oogrp.Count > 0)
            {
                foreach (StockItem ostk in oogrp)
                {
                    lstLeft.Items.Add(ostk.strItemGroup);
                }
            }
        }

        private void mLoadStockCategory()
        {
            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            List<StockCategory> oogrp = invms.mFillStockCategory(strComID).ToList();
            if (oogrp.Count > 0)
            {
                foreach (StockCategory ostk in oogrp)
                {
                    lstLeft.Items.Add(ostk.CategoryName);
                }
            }
        }
        private void mLoadLocation()
        {
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
        private void frmRptStockInformation_Load(object sender, EventArgs e)
        {
            grpReportOption.Enabled = false;
            //grpOption.Enabled = true;
            //dteFromDate.Text = Utility.gdteFinancialYearFrom;
            //dteToDate.Text = Utility.gdteFinancialYearTo;
            dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");
            mLoadStockGroup();
            //groupBox7.Enabled = false;
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

        private void radSelection_Click(object sender, EventArgs e)
        {
            grpOption.Enabled = true;
            grpReportOption.Enabled = true;
            radGroupwise.Checked = true;
            //mLoadStockGroup();
            groupBox7.Enabled = true;
            txtSearch.Focus();
        }

        private void radAllItem_Click(object sender, EventArgs e)
        {
            //grpOption.Enabled = false;
            grpReportOption.Enabled = false;
            radGroupwise.Checked = true;
            //lstLeft.Items.Clear();
            lstRight.Items.Clear();


        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            lstLeft.SelectedIndex = lstLeft.FindString(txtSearch.Text);
        }

        private void radItemWise_Click(object sender, EventArgs e)
        {
            mLaodItem();
        }

        private void radCategory_Click(object sender, EventArgs e)
        {
            mLoadStockCategory();
        }

        private void radLocationwise_Click(object sender, EventArgs e)
        {
            mLoadLocation();
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

        private void radLocationwise_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string strString = "", strSlow_fast_Zero = "", strSelection = "";

            //if (Utility.gblnAccessControl)
            //{
            //    if (lstRight.Items.Count == 0)
            //    {
            //        MessageBox.Show("Insuficient Privileges");
            //        return;
            //    }
            //}

            if (radSlowMoving.Checked)
            {
                strSlow_fast_Zero = "S";
            }
            else if (radFastMoving.Checked)
            {
                strSlow_fast_Zero = "F";
            }
            else
            {
                strSlow_fast_Zero = "Z";
            }
            if (radGroupwise.Checked == true)
            {
                strSelection = "G";
            }
            else if (radItemWise.Checked == true)
            {
                strSelection = "I";
            }
            else
            {
                strSelection = "C";
            }

            if (radAllItem.Checked == true)
            {
                for (int i = 0; i < lstLeft.Items.Count; i++)
                {
                    strString = strString + "'" + lstLeft.Items[i].ToString().Replace("'","''") + "',";
                }
                if (lstLeft.Items.Count==0)
                {
                    strString = "'None',";
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
                    strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                }
                if (strString != "")
                {
                    strString = Utility.Mid(strString, 0, strString.Length - 1);
                }
            }


            frmReportViewer frmviewer = new frmReportViewer();
            frmviewer.selector = ViewerSelector.SlowFastMoving;
            frmviewer.strFdate = dteFromDate.Text;
            frmviewer.strTdate = dteToDate.Text;
            frmviewer.dtetdate = dteToDate.Value;
            frmviewer.str_S_F_Z = strSlow_fast_Zero;
            frmviewer.strString = strString;
            frmviewer.strSelction = strSelection;
            frmviewer.Show();

        }

        private void radGroupwise_Click(object sender, EventArgs e)
        {
            mLoadStockGroup();
        }

        private void radGroupwise_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radAll_CheckedChanged(object sender, EventArgs e)
        {
            groupBox7.Enabled = false;
        }

        private void radAllItem_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnRightSingle.PerformClick();
                if (txtSearch.Text != "")
                {
                    txtSearch.Text = "";
                    txtSearch.Focus();
                }
                else
                {
                    dteFromDate.Focus();
                }
            }
        }



    }
}
