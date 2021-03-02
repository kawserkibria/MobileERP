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
using JA.Modulecontrolar.JRPT;

namespace JA.Modulecontrolar.UI.DReport.Inventory.ParameterForms
{
    public partial class frmRptProduction : JA.Shared.UI.frmJagoronFromSearch
    {
        JRPT.SWRPTClient orptCnn = new SWRPTClient();
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        List<StockItem> oogrp;
        string GoupLoadOption = "";
        public string strType { get; set; }
        private string strComID { get; set; }
        public frmRptProduction()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.lstLeft.DoubleClick += new System.EventHandler(this.lstLeft_DoubleClick);
            this.lstLeft.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstLeft_KeyPress);

            this.txtSerchGroup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSerchGroup_KeyPress);
            this.txtSerchGroup.TextChanged += new System.EventHandler(this.txtSerchGroup_TextChanged);
            this.lstLeftNew.DoubleClick += new System.EventHandler(this.lstLeftNew_DoubleClick);
            this.lstLeftNew.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstLeftNew_KeyPress);
            this.cboGroupName.SelectedIndexChanged += new System.EventHandler(this.cboGroupName_SelectedIndexChanged);

            this.txtSearchPower.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchPower_KeyPress);
            this.txtSearchPower.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchPower_KeyDown);
            this.lstLeftPowet.DoubleClick += new System.EventHandler(this.lstLeftPowet_DoubleClick);
            this.lstLeftPowet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstLeftPowet_KeyPress);
        }
        private void txtSearchPower_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstLeftPowet.SelectedItem != null)
                {
                    lstLeftPowet.SelectedIndex = lstLeftPowet.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstLeftPowet.Items.Count - 1 > lstLeftPowet.SelectedIndex)
                {
                    lstLeftPowet.SelectedIndex = lstLeftPowet.SelectedIndex + 1;
                }
            }
        }
        private void lstLeftPowet_DoubleClick(object sender, EventArgs e)
        {
            btnRightPower.PerformClick();
            lstLeftPowet.SetSelected(0, true);
        }

        private void lstLeftPowet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                btnRightPower.PerformClick();
                lstLeftPowet.SetSelected(0, true);
                txtSerchGroup.Text = "";
                txtSerchGroup.Focus();

            }
        }
        private void txtSearchPower_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                btnRightPower.PerformClick();
                lstLeftPowet.SetSelected(0, true);
                txtSerchGroup.Text = "";
                txtSerchGroup.Focus();
            }
        }

        private void btnRightPower_Click(object sender, EventArgs e)
        {
            if (lstLeftPowet.SelectedItems.Count > 0)
            {
                lstRightPower.Items.Add(lstLeftPowet.SelectedItem.ToString());
                lstLeftPowet.Items.Remove(lstLeftPowet.SelectedItem.ToString());
                lstLeftPowet.SetSelected(0, true);
            }
        }

        private void btnRightAllPower_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstLeftPowet.Items.Count; i++)
            {
                string strItem = lstLeftPowet.Items[i].ToString().TrimStart();
                lstRightPower.Items.Add(strItem);
            }

            lstLeftPowet.Items.Clear();
        }

        private void btnLeftPower_Click(object sender, EventArgs e)
        {
            if (lstRightPower.SelectedItems.Count > 0)
            {
                lstLeftPowet.Items.Add(lstRightPower.SelectedItem.ToString());
                lstRightPower.Items.Remove(lstRightPower.SelectedItem.ToString());
            }
        }

        private void btnLeftAllPower_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstRightPower.Items.Count; i++)
            {
                string strItem = lstRightPower.Items[i].ToString().TrimStart();
                lstLeftPowet.Items.Add(strItem);
            }
            lstRightPower.Items.Clear();

         
        }

        private void mLaodPower()
        {
            lstLeftPowet.Items.Clear();
            lstRightPower.Items.Clear();
            List<RoMonthlyProduction> oogrp = orptCnn.mGetloadPowerClass(strComID).ToList();
            if (oogrp.Count > 0)
            {
                foreach (RoMonthlyProduction ostk in oogrp)
                {
                    lstLeftPowet.Items.Add(ostk.strPowerClass);
                }
            }
        }
        private void mLaodPackSize()
        {
            lstLeftPowet.Items.Clear();
            lstRightPower.Items.Clear();
            //List<RoMonthlyProduction> oogrp = orptCnn.mGetloadPowerClass(strComID).ToList();
            List<StockCategory> oogrp = invms.mFillStockCategory(strComID).ToList();
            if (oogrp.Count > 0)
            {
                foreach (StockCategory ostk in oogrp)
                {
                    lstLeftPowet.Items.Add(ostk.CategoryName);
                }
            }
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
            //lstLeftNew.SetSelected(0, true);
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
        private void mLaodItem()
        {
            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            List<StockItem> oogrp = invms.gFillStockItemAllWithoutGodown(strComID, Utility.gblnAccessControl, Utility.gstrUserName,"").ToList();
            if (oogrp.Count > 0)
            {
                foreach (StockItem ostk in oogrp)
                {
                    lstLeft.Items.Add(ostk.strItemName);
                }
            }
        }
        private void mLoadStockGroupNew()
        {
            lstLeftNew.Items.Clear();
            lstRightNew.Items.Clear();
            List<StockItem> oogrp = invms.gLoadStockGroup(strComID, Utility.gblnAccessControl, Utility.gstrUserName, "N", cboGroupName.Text,"").ToList();
            if (oogrp.Count > 0)
            {
                foreach (StockItem ostk in oogrp)
                {
                    lstLeftNew.Items.Add(ostk.strItemGroup);
                }
            }
        }

        private void mLoadStockGroup()
        {
            lstLeft.Items.Clear();
            lstRight.Items.Clear();

            if (GoupLoadOption == "FG")
            {
                oogrp = invms.gLoadStockGroup(strComID, Utility.gblnAccessControl, Utility.gstrUserName, "N", "Finished Goods","").ToList();
            }
            else
            {
                oogrp = invms.gLoadStockGroup(strComID, Utility.gblnAccessControl, Utility.gstrUserName, "N", cboGroupName.Text,"").ToList();
            }
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
            lstLeftNew.Items.Clear();
            lstLeftNew.Items.Clear();
            List<Location> oogrp = invms.mLoadLocation(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
            if (oogrp.Count > 0)
            {
                foreach (Location ostk in oogrp)
                {
                    lstLeftNew.Items.Add(ostk.strLocation);
                }
            }
        }
        private void btnRightSingle_Click(object sender, EventArgs e)
        {
            if (lstLeft.SelectedItems.Count > 0)
            {
                lstRight.Items.Add(lstLeft.SelectedItem.ToString());
                lstLeft.Items.Remove(lstLeft.SelectedItem.ToString());
                lstLeft.SetSelected(0, true);
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
            lstLeftPowet.Items.Clear();
            lstRightPower.Items.Clear();
            groupBox4.Enabled = false;
            if (rbtnClassPower.Checked== true)
            {
                lstLeftPowet.Items.Clear();
                lstRightPower.Items.Clear();
                groupBox4.Enabled = true;
                mLaodPower();
            }
            if (rbtnPacksize.Checked == true)
            {
                lstLeftPowet.Items.Clear();
                lstRightPower.Items.Clear();
                groupBox4.Enabled = true;
                mLaodPackSize();
            }
           

            grpGroup.Enabled = true;
            groupBox7.Enabled = true;

            txtSearch.Focus();
            groupBox7.Enabled = true;
            lstRightNew.Items.Clear();
            lstRightNew.Items.Clear();

            mLoadStockGroup();
            //mLoadStockGroupNew();
            mLoadLocation();

        }

        private void radAllItem_Click(object sender, EventArgs e)
        {

            groupBox7.Enabled = false;
            grpGroup.Enabled = false;
            groupBox4.Enabled = false;
            lstRight.Items.Clear();
            lstRightNew.Items.Clear();
            lstLeftNew.Items.Clear();
            lstRightNew.Items.Clear();
            lstLeftPowet.Items.Clear();
            lstRightPower.Items.Clear();
            mLoadLocation();
            if (rbtnClassPower.Checked == true)
            {
               
                mLaodPower();
            }
            if (rbtnPacksize.Checked == true)
            {

                mLaodPackSize();
            }
          
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            lstLeft.SelectedIndex = lstLeft.FindString(txtSearch.Text);
        }

        private void radItemWise_Click(object sender, EventArgs e)
        {
            strType = "C";

            label6.Visible = false;
            cboGroupName.Visible = false;

            mLaodItem();
        }

        private void radCategory_Click(object sender, EventArgs e)
        {

            strType = "C";

            mLoadStockCategory();
        }

        private void radLocationwise_Click(object sender, EventArgs e)
        {
            strType = "C";
            label6.Visible = false;
            cboGroupName.Visible = false;


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
            strType = "C";
        }
        private void radGroupwise_Click(object sender, EventArgs e)
        {
            strType = "C";
            mLoadStockGroup();
        }
        private void radGroupwise_CheckedChanged(object sender, EventArgs e)
        {
            strType = "C";
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
                lstLeft.SetSelected(0, true);
                txtSearch.Text = "";
                txtSearch.Focus();
                // dteFromDate.Focus();

            }
        }

        private void radItemWise_CheckedChanged(object sender, EventArgs e)
        {
            strType = "C";
        }
        private void radValueSupp_Click(object sender, EventArgs e)
        {

        }

        private void radNoSuppress_Click(object sender, EventArgs e)
        {

        }
        private void radSuppressZero_Click(object sender, EventArgs e)
        {

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
            }
        }

        private void btnRightNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstLeftNew.SelectedItems.Count > 0)
                {

                    lstRightNew.Items.Add(lstLeftNew.SelectedItem.ToString());
                    lstLeftNew.Items.Remove(lstLeftNew.SelectedItem.ToString());
                    if (lstLeftNew.Items.Count > 0)
                    {
                        lstLeftNew.SetSelected(0, true);
                    }
                }

            }
            catch (Exception ex)
            {

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

        private void radLocationGroup_CheckedChanged(object sender, EventArgs e)
        {
            strType = "L";
        }

        private void radLocationGroup_Click(object sender, EventArgs e)
        {
            cboGroupName.Visible = true;
            cboGroupName.Visible = true;
            cboGroupName.ValueMember = "strItemGroup";
            cboGroupName.DisplayMember = "strItemGroup";
            cboGroupName.DataSource = invms.mGetStockGroup(strComID,1).ToList();
            strType = "L";
            grpGroup.Visible = true;
            mLoadStockGroupNew();
            mLoadLocation();
        }
        private void cboGroupName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (strType == "L")
            {
                mLoadStockGroupNew();
            }
            else
            {
                mLoadStockGroup();
            }

        }

        private void radCategory_CheckedChanged(object sender, EventArgs e)
        {
            strType = "C";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string strString = "", struserString = "", strString1 = "", strString3 = "", strDiulotion="";
            int intCount = 0;
            //strDiulotion = lstRight.Items[0].ToString();

            intCount = lstRight.Items.Count;


            for (int i = 0; i < lstRight.Items.Count; i++)
            {
                strString = strString + "'" + lstRight.Items[i].ToString() + "',";
            }

            if (strString != "")
            {
                strString = Utility.Mid(strString, 0, strString.Length - 1);
            }
            if (strString == "")
            {
                strString = struserString;
            }
            if (rbtnFG.Checked == true)
            {
                strString1 = "'Main Location',";
            }
            for (int i = 0; i < lstRightNew.Items.Count; i++)
            {
                strString1 = strString1 + "'" + lstRightNew.Items[i].ToString() + "',";
            }
            if (strString1 != "")
            {
                strString1 = Utility.Mid(strString1, 0, strString1.Length - 1);
            }
            if (strString1 == "")
            {
                strString1 = struserString;
            }

            for (int i = 0; i < lstRightPower.Items.Count; i++)
            {
                strString3 = strString3 + "'" + lstRightPower.Items[i].ToString() + "',";
            }
            if (strString3 != "")
            {
                strString3 = Utility.Mid(strString3, 0, strString3.Length - 1);
            }
            if (strString3 == "")
            {
                strString3 = struserString;
            }


            if (rbtnPackingRawStock.Checked == true)
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.PackingRawMaterialsStock;
                if (radSelection.Checked == true)
                {
                    frmviewer.strString5 = strString;
                    frmviewer.strString6 = strString1;
                }
                frmviewer.strSelction = "";
                frmviewer.strFdate = dteFromDate.Text;
                frmviewer.strTdate = dteToDate.Text;
                frmviewer.Show();
            }

            if (rbtnConsumption.Checked == true)
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.Production_Convertion;
                if (radSelection.Checked == true)
                {
                    frmviewer.strString5 = strString;
                    frmviewer.strString6 = strString1;
                }
                frmviewer.strSelction = "";
                frmviewer.strFdate = dteFromDate.Text;
                frmviewer.strTdate = dteToDate.Text;
                frmviewer.Show();
            }

            if (rbtnFG.Checked == true)
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.MonthlyProduction;
                if (radSelection.Checked == true)
                {
                    frmviewer.strString5 = strString;
                    frmviewer.strString6 = strString1;
                }
                frmviewer.strSelction = "";
                frmviewer.strFdate = dteFromDate.Text;
                frmviewer.strTdate = dteToDate.Text;
                frmviewer.Show();
            }
            if (rbtnClassPower.Checked == true)
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.MonthlyProduction_Class_Power;
                if (radSelection.Checked == true)
                {
                    frmviewer.strString5 = strString;
                    frmviewer.strString6 = strString1;
                    frmviewer.strString7 = strString3;
                    //frmviewer.str = strDiulotion;
                    frmviewer.intype = intCount;

                }
                frmviewer.strFdate = dteFromDate.Text;
                frmviewer.strTdate = dteToDate.Text;
                frmviewer.Show();
            }
            if (rbtnPacksize.Checked == true)
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.MonthlyProduction_Class_Power;
                if (radSelection.Checked == true)
                {
                    frmviewer.strString5 = strString;
                    frmviewer.strString6 = strString1;
                    frmviewer.strString7 = "";
                    frmviewer.strString3 = strString3;
                    frmviewer.intype = intCount;

                }
                frmviewer.strFdate = dteFromDate.Text;
                frmviewer.strTdate = dteToDate.Text;
                frmviewer.Show();
            }
        }
        private void frmRptProduction_Load(object sender, EventArgs e)
        {
           
            GoupLoadOption = "FG";
            label6.Visible = false;
            groupBox4.Enabled = false;
            cboGroupName.Visible = true;
            cboGroupName.ValueMember = "strItemGroup";
            cboGroupName.DisplayMember = "strItemGroup";
            cboGroupName.DataSource = invms.mGetStockGroup(strComID,2).ToList();
            frmLabel.Text = "Production Statement";
            mLoadLocation();
            dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");
            cboGroupName.Visible = false;
            mLoadStockGroup();
            mLoadLocation();
            mLaodPower();
        }

        private void rbtnClassPower_Click(object sender, EventArgs e)
        {
            if (radSelection.Checked == true)
            {
                lstLeftPowet.Items.Clear();
                lstRightPower.Items.Clear();
                groupBox4.Enabled = true;
                GoupLoadOption = "FG";
                mLaodPower();
                mLoadStockGroup();
                cboGroupName.Visible = false;
                label6.Visible = false;
            }
            else
            {
                lstLeftPowet.Items.Clear();
                lstRightPower.Items.Clear();
                groupBox4.Enabled = false;
                GoupLoadOption = "FG";
                mLaodPower();
                mLoadStockGroup();
                cboGroupName.Visible = false;
                label6.Visible = false;
            }
           
        }

        private void rbtnFG_Click(object sender, EventArgs e)
        {
            lstLeftPowet.Items.Clear();
            lstRightPower.Items.Clear();
            groupBox4.Enabled = false;
            cboGroupName.Visible = false;
            label6.Visible = false;
            GoupLoadOption = "FG";
            mLoadStockGroup();
        }

        private void rbtnConsumption_Click(object sender, EventArgs e)
        {
            lstLeftPowet.Items.Clear();
            lstRightPower.Items.Clear();
            groupBox4.Enabled = false;
            cboGroupName.Visible = false;
            label6.Visible = false;
            GoupLoadOption = "FG";
            mLoadStockGroup();
          
        }

        private void rbtnPackingRawStock_Click(object sender, EventArgs e)
        {
            lstLeftPowet.Items.Clear();
            lstRightPower.Items.Clear();
            groupBox4.Enabled = false;
            cboGroupName.Visible = true;
            label6.Visible = true;
            label6.Visible = false;
            GoupLoadOption = "RMPM";
            mLoadStockGroup();
        }
        private void rbtnPacksize_Click(object sender, EventArgs e)
        {
            if (radSelection.Checked == true)
            {
                lstLeftPowet.Items.Clear();
                lstRightPower.Items.Clear();
                groupBox4.Enabled = true;
                GoupLoadOption = "FG";
                mLaodPackSize();
                mLoadStockGroup();
                cboGroupName.Visible = false;
                label6.Visible = false;
            }
            else
            {
                lstLeftPowet.Items.Clear();
                lstRightPower.Items.Clear();
                groupBox4.Enabled = false;
                GoupLoadOption = "FG";
                mLaodPackSize();
                mLoadStockGroup();
                cboGroupName.Visible = false;
                label6.Visible = false;
            }
         
        }
        private void rbtnPackingRawStock_ClientSizeChanged(object sender, EventArgs e)
        {

        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rbtnConsumption_CheckedChanged(object sender, EventArgs e)
        {

        }

      

    }
}
