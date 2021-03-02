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
using JA.Modulecontrolar.UI.DReport.Inventory.Viewer;
using Microsoft.Win32;
using JA.Modulecontrolar.UI.Inventory;


namespace JA.Modulecontrolar.UI.DReport.Inventory.ParameterForms
{
    public partial class frmRptConjumptionMonthly : JA.Shared.UI.frmJagoronFromSearch
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        private ListBox lstBranch = new ListBox();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        List<StockGroup> ooggrop;
        public string strType { get; set; }
        private string strComID { get; set; }
        string strName = "";
        List<StockItem> oogrp;
        public frmRptConjumptionMonthly()
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
            this.cboGroupName.SelectedIndexChanged += new System.EventHandler(this.cboGroupName_SelectedIndexChanged);

            this.uctxtBranchName.KeyDown += new KeyEventHandler(uctxtBranchName_KeyDown);
            this.uctxtBranchName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranchName_KeyPress);
            this.uctxtBranchName.TextChanged += new System.EventHandler(this.uctxtBranchName_TextChanged);
            this.lstBranch.DoubleClick += new System.EventHandler(this.lstBranch_DoubleClick);
            this.uctxtBranchName.GotFocus += new System.EventHandler(this.uctxtBranchName_GotFocus);
            Utility.CreateListBox(lstBranch, pnlMain, uctxtBranchName);
        }


        private void uctxtBranchName_TextChanged(object sender, EventArgs e)
        {
            lstBranch.SelectedIndex = lstBranch.FindString(uctxtBranchName.Text);
        }

        private void lstBranch_DoubleClick(object sender, EventArgs e)
        {
            uctxtBranchName.Text = lstBranch.Text;
            lstBranch.Visible = false;
            txtSearch.Focus();


        }

        private void uctxtBranchName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                if (lstBranch.Items.Count > 0)
                {
                    uctxtBranchName.Text = lstBranch.Text;
                }
                lstBranch.Visible = false;
                txtSearch.Focus();


            }
        }
        private void uctxtBranchName_KeyDown(object sender, KeyEventArgs e)
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

        private void uctxtBranchName_GotFocus(object sender, System.EventArgs e)
        {
            lstBranch.Visible = true;
            lstBranch.SelectedIndex = lstBranch.FindString(uctxtBranchName.Text);

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
        private void cboGroupName_SelectedIndexChanged(object sender, EventArgs e)
        {

            mLoad();




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


        private void mLoadLocation(string strValue)
        {
            lstLeft.Items.Clear();
            lstRight.Items.Clear();

            if (strValue != "")
            {
                //oogrp = invms.mLoadLocation(strComID, Utility.gblnAccessControl,"Only").ToList();
                lstLeft.Items.Add("Main Location");
            }
            else
            {
                List<Location> oogrp = invms.mLoadLocation(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
                if (oogrp.Count > 0)
                {
                    foreach (Location ostk in oogrp)
                    {
                        lstLeft.Items.Add(ostk.strLocation);
                    }
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
        private void frmRptConjumptionMonthly_Load(object sender, EventArgs e)
        {
            dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");

            lstBranch.ValueMember = "BranchID";
            lstBranch.DisplayMember = "BranchName";
            lstBranch.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
            uctxtBranchName.Focus();
            uctxtBranchName.Select();
            mLoadLocation("");
            mLoadStockGroupNew();
            StockGroupLoad();
         
           
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
        private void StockGroupLoad()
        {
            if (radRMPM.Checked == true)
            {
                cboGroupName.ValueMember = "Key";
                cboGroupName.DisplayMember = "value";
                cboGroupName.DataSource = invms.mGetStockGroupNew(strComID, 2).ToList();
            }
            else
            {
                //cboGroupName.ValueMember = "strItemGroup";
                //cboGroupName.DisplayMember = "strItemGroup";
                //cboGroupName.DataSource = invms.mGetStockGroup(strComID, 1).ToList();
                //if (rbtnconsumption.Checked == true)
                //{
                //    lstLeftNew.Items.Clear();
                //    lstRightNew.Items.Clear();
                //    lstLeftNew.Items.Add("Chemicals");
                //    lstLeftNew.Items.Add("Packing");
                //    lstLeftNew.Items.Add("Herbs");
                //}
                //else
                //{
                    mLoad();
                //}
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

        private void radFG_Click(object sender, EventArgs e)
        {
            strName = "I";
            grpOption.Enabled = true;
            grpReportOption.Enabled = true;
            radGroupwise.Checked = true;
            mLoadLocation("Only");
            mLoadStockGroupNew();
            groupBox7.Enabled = true;
            cboGroupName.Text = "";
            cboGroupName.Visible = false;
            label6.Visible = false; 
            txtSearch.Focus();
        }

        private void radAllItem_Click(object sender, EventArgs e)
        {
            //grpOption.Enabled = false;
            grpReportOption.Enabled = false;
            radGroupwise.Checked = true;
            mLoadLocation("");
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
            mLoadLocation("");
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
            string strString = "", strSelection = "", strStringNew = "", FGPackSize = "", strOption = "", strDetails = "";

            if (uctxtBranchName.Text == "")
            {
                MessageBox.Show("Select Branch");
                uctxtBranchName.Focus();
                return;

            }
            string strbranchID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);
            if (radRMPM.Checked == true)
            {
                strSelection = "RM";
                FGPackSize = "RM";
            }
            else
            {
                strSelection = "L";
                if (radFG.Checked == true)
                {
                    FGPackSize = "FG";
                }
                else
                {
                    FGPackSize = "PackPower";
                }
            }

            if (rbtnProductionCosting.Checked == true)
            {
                strOption = "Production";
            }
            if (rbtnconsumption.Checked == true)
            {
                strOption = "Conjumption";
                strDetails = "Details";
            }
            if (rbtnSumm.Checked == true)
            {
                strOption = "Conjumption";
                strDetails = "Summary";
            }

            if (radAllItem.Checked == true)
            {
                for (int i = 0; i < lstLeft.Items.Count; i++)
                {
                    strString = strString + "'" + lstLeft.Items[i].ToString().Replace("'", "''") + "',";
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
                    strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
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
            if (rbtnPackSizePower.Checked == true)
            {
                frmviewer.selector = ViewerSelector.ConjumptionFGPower;
            }
            else if (radRMPM.Checked == true)
            {
                frmviewer.selector = ViewerSelector.ConjumptionRMPM;
            }
            else if (radFG.Checked == true)
            {
                frmviewer.selector = ViewerSelector.ConjumptionRMPM;
            }
            else if (rbtnProductionCosting.Checked == true)
            {
                frmviewer.selector = ViewerSelector.mGetProductionCosting;
            }

            else if (rbtnconsumption.Checked == true)
            {
                frmviewer.selector = ViewerSelector.conProduction_jumptionDetails;
            }

            else
            {
                frmviewer.selector = ViewerSelector.conjumptionsummary;
            }


            frmviewer.strFdate = dteFromDate.Text;
            frmviewer.strTdate = dteToDate.Text;
            frmviewer.dtetdate = dteToDate.Value;
            frmviewer.strString = strString;
            frmviewer.strStringNew = strStringNew;
            frmviewer.strString7 = strSelection;
            frmviewer.strString5 = FGPackSize;
            frmviewer.strString6 = strOption;

            string vstrFdate = "01-01-" + Convert.ToDateTime(Utility.gdteFinancialYearFrom).ToString("yyyy");
            string vstrTdate = "31-12-" + Convert.ToDateTime(Utility.gdteFinancialYearFrom).ToString("yyyy");
            frmviewer.strFinYearFdate = vstrFdate;
            frmviewer.strFinYearTdate = vstrTdate;


            frmviewer.strString3 = strDetails;
            frmviewer.strBranchID = strbranchID;
            frmviewer.strFromLocation = uctxtBranchName.Text;
            frmviewer.Show();

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

     

        private void lstLeft_DoubleClick(object sender, EventArgs e)
        {
            btnRightSingle_Click(sender, e);
        }

        private void btnRightNew_Click(object sender, EventArgs e)
        {
            if (rbtnProductionCosting.Checked == true)
            {
                if (lstLeftNew.SelectedItems.Count > 0)
                {
                    if (lstRightNew.Items.Count < 6)
                    {
                        lstRightNew.Items.Add(lstLeftNew.SelectedItem.ToString());
                        lstLeftNew.Items.Remove(lstLeftNew.SelectedItem.ToString());
                        lstLeftNew.SetSelected(0, true);
                    }
                }
            }
            else
            {
                if (lstLeftNew.SelectedItems.Count > 0)
                {
                    lstRightNew.Items.Add(lstLeftNew.SelectedItem.ToString());
                    lstLeftNew.Items.Remove(lstLeftNew.SelectedItem.ToString());
                    lstLeftNew.SetSelected(0, true);
                }
            }
        }

        private void btnRightAllNew_Click(object sender, EventArgs e)
        {
            //if (rbtnProductionCosting.Checked)
            //{
          
            //}
            //else
            //{
                if (rbtnProductionCosting.Checked == true)
                {

                    for (int i = 0; i < lstLeftNew.Items.Count; i++)
                    {
                        //if (lstRightNew.Items.Count < 6)
                        //{
                            string strItem = lstLeftNew.Items[i].ToString().TrimStart();
                            lstRightNew.Items.Add(strItem);
                        //}
                    }
                }
                else
                {
                    for (int i = 0; i < lstLeftNew.Items.Count; i++)
                    {
                        string strItem = lstLeftNew.Items[i].ToString().TrimStart();
                        lstRightNew.Items.Add(strItem);
                    }
                }

                lstLeftNew.Items.Clear();
            //}
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
            mLoad();
          
        }

        private void mLoad()
        {
            //groupBox7.Enabled = true;
            lstLeftNew.Items.Clear();
            lstRightNew.Items.Clear();

            if (strName == "S")
            {
                oogrp = invms.gLoadStockGroup(strComID, Utility.gblnAccessControl, Utility.gstrUserName, "Y", cboGroupName.Text,"").ToList();
            }
            else if (strName == "Su")
            {
                oogrp = invms.gLoadStockGroup(strComID, Utility.gblnAccessControl, Utility.gstrUserName, "Y", "","").ToList();
            }
            else if (strName == "I")
            {
                oogrp = invms.gLoadStockGroup(strComID, Utility.gblnAccessControl, Utility.gstrUserName, "K", "Finished Goods","").ToList();
            }
            else
            {
                oogrp = invms.gLoadStockGroup(strComID, Utility.gblnAccessControl, Utility.gstrUserName, "K", cboGroupName.Text,"").ToList();
            }
            if (oogrp.Count > 0)
            {
                foreach (StockItem ostk in oogrp)
                {
                    lstLeftNew.Items.Add(ostk.strItemGroup);
                }
            }

        }

    

        private void rbtnPackSizePower_Click(object sender, EventArgs e)
        {
            strName = "I";
            grpOption.Enabled = true;
            grpReportOption.Enabled = true;
            radGroupwise.Checked = true;
            mLoadLocation("Only");
            mLoadStockGroupNew();
            groupBox7.Enabled = true;
            cboGroupName.Text = "";
            cboGroupName.Visible = false;
            label6.Visible = false;
            txtSearch.Focus();
        }

        private void rbtnProductionCosting_Click(object sender, EventArgs e)
        {
            strName = "I";
            grpOption.Enabled = true;
            grpReportOption.Enabled = true;
            radGroupwise.Checked = true;
            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            //mLoadLocation("");
            mLoadLocation("Only");
            mLoadStockGroupNew();
            groupBox7.Enabled = true;
            cboGroupName.Text = "";
            cboGroupName.Visible = false;
            label6.Visible = false;
            txtSearch.Focus();
        }

        private void radRMPM_Click(object sender, EventArgs e)
        {
    
            cboGroupName.Text = "";
            strName = "P";
            cboGroupName.Visible = true;
            label6.Visible = true;
            mLoadLocation("");
            StockGroupLoad();
        }

        private void rbtnconsumption_Click(object sender, EventArgs e)
        {
            cboGroupName.Text = "";
            strName = "P";
            cboGroupName.Visible = true;
            label6.Visible = true;
            mLoadLocation("");
            mapingStockGroup();


        }

        private void btnNew_Click(object sender, EventArgs e)
        {
           
        }

   


        private void mapingStockGroup()
        {
            lstLeftNew.Items.Clear();
            lstRightNew.Items.Clear();
            ooggrop = invms.mLoadMappingStockGroup(strComID, "").ToList();
            if (ooggrop.Count > 0)
            {
                foreach (StockGroup ostk in ooggrop)
                {
                    lstLeftNew.Items.Add(ostk.GroupName);
                }
            }
        }

        private void rbtnSumm_Click(object sender, EventArgs e)
        {
            mLoadLocation("");
            mapingStockGroup();
        }

        private void radFG_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnMapping_Click(object sender, EventArgs e)
        {

            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 221))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            
            if (System.Windows.Forms.Application.OpenForms["frmStockGroupMapping"] as frmStockGroupMapping == null)
            {
                frmStockGroupMapping objfrm = new frmStockGroupMapping();
                objfrm.MdiParent = this.MdiParent;
                objfrm.Show();

            }
            else
            {
                frmStockGroupMapping objfrm = (frmStockGroupMapping)Application.OpenForms["frmStockGroupMapping"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

     
    }
}
