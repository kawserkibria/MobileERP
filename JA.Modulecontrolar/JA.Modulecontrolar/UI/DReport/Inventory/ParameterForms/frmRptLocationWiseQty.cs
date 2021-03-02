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
    public partial class frmRptLocationWiseQty : JA.Shared.UI.frmJagoronFromSearch
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public string strType { get; set; }
        private string strComID { get; set; }
        public frmRptLocationWiseQty()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.lstLeft.DoubleClick += new System.EventHandler(this.lstLeft_DoubleClick);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            this.lstLeftNew.DoubleClick += new System.EventHandler(this.lstLeftNew_DoubleClick);
            this.lstLeftNew.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstLeftNew_KeyPress);
            this.txtSerchGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSerchGroup_KeyDown);
            this.txtSerchGroup.TextChanged += new System.EventHandler(this.txtSerchGroup_TextChanged);
            this.txtSerchGroup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSerchGroup_KeyPress);
        }
        private void txtSerchGroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                btnRightNew.PerformClick();
                lstLeftNew.SetSelected(0, true);
                txtSerchGroup.Text = "";
                txtSerchGroup.Focus();
                // dteFromDate.Focus();

            }
        }
        private void lstLeftNew_DoubleClick(object sender, EventArgs e)
        {
            btnRightNew.PerformClick();
            lstLeftNew.SetSelected(0, true);
        }
        private void txtSerchGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstLeftNew.SelectedItem != null)
                {
                    lstLeftNew.SelectedIndex = lstLeftNew.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstLeftNew.Items.Count - 1 > lstLeftNew.SelectedIndex)
                {
                    lstLeftNew.SelectedIndex = lstLeftNew.SelectedIndex + 1;
                }
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
        }
        private void lstLeftNew_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                btnRightNew.PerformClick();
                lstLeftNew.SetSelected(0, true);
                txtSerchGroup.Text = "";
                txtSerchGroup.Focus();
                // dteFromDate.Focus();

            }
        }
        private void txtSerchGroup_TextChanged(object sender, EventArgs e)
        {
            lstLeftNew.SelectedIndex = lstLeftNew.FindString(txtSerchGroup.Text);
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
        private void mLoadLocation2()
        {
            lstLeftNew.Items.Clear();
            lstRightNew.Items.Clear();
            List<Location> oogrp = invms.mLoadLocation(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
            if (oogrp.Count > 0)
            {
                foreach (Location ostk in oogrp)
                {
                    lstLeftNew.Items.Add(ostk.strLocation);
                }
            }
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
            mLoadLocation2();
        }
        private void frmRptLocationWiseQty_Load(object sender, EventArgs e)
        {
            dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");

            //dteFromDate.Text = Utility.gdteFinancialYearFrom;
            //dteToDate.Text = Utility.gdteFinancialYearTo;
            mLoadLocation();
            mLoadStockGroupNew();
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
            mLoadLocation();
            mLoadStockGroupNew();
            groupBox7.Enabled = true;
            txtSearch.Focus();
        }

        private void radAllItem_Click(object sender, EventArgs e)
        {
            //grpOption.Enabled = false;
            grpReportOption.Enabled = false;
            radGroupwise.Checked = true;
            mLoadLocation();
            lstRight.Items.Clear();


        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            lstLeft.SelectedIndex = lstLeft.FindString(txtSearch.Text);
        }

        private void radItemWise_Click(object sender, EventArgs e)
        {
            //mLaodItem();
        }

        private void radCategory_Click(object sender, EventArgs e)
        {
           // mLoadStockCategory();
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
            string strString = "", strSelection = "",strStringNew="";
            int intSelection = 0;
            

            if (radItem.Checked == true)
            {
                strSelection = "LC";
            }
            else
            {
                strSelection = "L";
            }
            if (radSelection.Checked == true)
            {
                intSelection = 2;
            }
            else
            {
                intSelection = 3;
            }

            if (radAllItem.Checked==true)
            {
                for (int i = 0; i < lstLeft.Items.Count; i++)
                {
                    strString = strString + "'" + lstLeft.Items[i].ToString().Replace("'","''") + "',";
                }
                if (lstLeft.Items.Count == 0)
                {
                    strString = "'NONE',";
                }

                if (strString != "")
                {
                    strString = Utility.Mid(strString, 0, strString.Length - 1);
                }
                //Group
                for (int i = 0; i < lstLeftNew.Items.Count; i++)
                {
                    strStringNew = strStringNew + "'" + lstLeftNew.Items[i].ToString().Replace("'", "''") + "',";
                }
                if (lstLeftNew.Items.Count == 0)
                {
                    strStringNew = "'NONE',";
                }

                if (strStringNew != "")
                {
                    strStringNew = Utility.Mid(strStringNew, 0, strStringNew.Length - 1);
                }
            }
            else
            {
                for (int i = 0; i < lstRight.Items.Count; i++)
                {
                    strString = strString + "'" + lstRight.Items[i].ToString().Replace("'","''") + "',";
                }
                if (strString != "")
                {
                    strString = Utility.Mid(strString, 0, strString.Length - 1);
                }
                //Group
                for (int i = 0; i < lstRightNew.Items.Count; i++)
                {
                    strStringNew = strStringNew + "'" + lstRightNew.Items[i].ToString().Replace("'", "''") + "',";
                }

                if (strStringNew != "")
                {
                    strStringNew = Utility.Mid(strStringNew, 0, strStringNew.Length - 1);
                }
            }

          


            frmReportViewer frmviewer = new frmReportViewer();
            frmviewer.selector = ViewerSelector.LocationWiseQty;
            frmviewer.strFdate = dteFromDate.Text;
            frmviewer.strTdate = dteToDate.Text;
            frmviewer.dtetdate = dteToDate.Value;
            frmviewer.strString = strString;
            frmviewer.strStringNew = strStringNew;
            frmviewer.strSelction = strSelection;
            frmviewer.intSuppress = intSelection;
            frmviewer.Show();
          
        }

        private void radGroupwise_Click(object sender, EventArgs e)
        {
            //mLoadStockGroup();
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
                    //txtSearch.Focus();
                }
                else
                {
                    //dteFromDate.Focus();
                }
            }
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radItem_Click(object sender, EventArgs e)
        {
            mLaodItem();
        }

        private void lstLeft_DoubleClick(object sender, EventArgs e)
        {
            btnRightSingle_Click(sender, e);
        }

        private void btnRightNew_Click(object sender, EventArgs e)
        {
            if (lstLeftNew.SelectedItems.Count > 0)
            {
                lstRightNew.Items.Add(lstLeftNew.SelectedItem.ToString());
                lstLeftNew.Items.Remove(lstLeftNew.SelectedItem.ToString());
                lstLeftNew.SetSelected(0, true);
            }
        }

        private void btnRightAllNew_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstLeftNew.Items.Count; i++)
            {
                string strItem = lstLeftNew.Items[i].ToString().TrimStart();
                lstRightNew.Items.Add(strItem);
            }

            lstLeftNew.Items.Clear();
        }

        private void btnLeftNew_Click(object sender, EventArgs e)
        {
            if (lstRightNew.SelectedItems.Count > 0)
            {
                lstLeftNew.Items.Add(lstRightNew.SelectedItem.ToString());
                lstRightNew.Items.Remove(lstRightNew.SelectedItem.ToString());
            }
        }

        private void btnLeftAllNew_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstRightNew.Items.Count; i++)
            {
                string strItem = lstRightNew.Items[i].ToString().TrimStart();
                lstLeftNew.Items.Add(strItem);
            }
            lstRightNew.Items.Clear();
        }


        private void mLoadStockGroupNew()
        {
            lstLeftNew.Items.Clear();
            lstRightNew.Items.Clear();
            List<StockItem> oogrp = invms.gLoadStockGroup(strComID, Utility.gblnAccessControl, Utility.gstrUserName, "N","","").ToList();
            if (oogrp.Count > 0)
            {
                foreach (StockItem ostk in oogrp)
                {
                    lstLeftNew.Items.Add(ostk.strItemGroup);
                }
            }
        }
    }
}
