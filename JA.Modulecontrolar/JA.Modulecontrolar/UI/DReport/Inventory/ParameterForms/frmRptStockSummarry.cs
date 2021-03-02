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
    public partial class frmRptStockSummarry : JA.Shared.UI.frmSmartFormStandard
    {

        JACCMS.SWJAGClient accms = new SWJAGClient();
        private ListBox lstBranch = new ListBox();
        public string strReportName { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public string strName { get; set; }
        private string strComID { get; set; }
       
        public frmRptStockSummarry()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.dteFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteFromDate_KeyPress);
            this.dteFromDate.GotFocus += new System.EventHandler(this.dteFromDate_GotFocus);
            this.dteToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteToDate_KeyPress);
            this.dteToDate.GotFocus += new System.EventHandler(this.dteToDate_GotFocus);

            this.uctxtBranchName.KeyDown += new KeyEventHandler(uctxtBranchName_KeyDown);
            this.uctxtBranchName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranchName_KeyPress);
            this.uctxtBranchName.TextChanged += new System.EventHandler(this.uctxtBranchName_TextChanged);
            this.lstBranch.DoubleClick += new System.EventHandler(this.lstBranch_DoubleClick);
            this.uctxtBranchName.GotFocus += new System.EventHandler(this.uctxtBranchName_GotFocus);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
           
            this.lstLeft.DoubleClick += new System.EventHandler(this.lstLeft_DoubleClick);
            this.lstLeft.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstLeft_KeyPress);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            this.txtSearch.KeyDown += new KeyEventHandler(txtSearch_KeyDown);
            //Utility.CreateListBox(lstLevelName, pnlMain, txtLevelName);
            Utility.CreateListBox(lstBranch, pnlMain, uctxtBranchName);

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
        #region "User Deifne"
        private void dteFromDate_GotFocus(object sender, System.EventArgs e)
        {

            lstBranch.Visible = false;

        }
        private void dteToDate_GotFocus(object sender, System.EventArgs e)
        {
            lstBranch.Visible = false;


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
        private void uctxtBranchName_TextChanged(object sender, EventArgs e)
        {
            lstBranch.SelectedIndex = lstBranch.FindString(uctxtBranchName.Text);
        }

        private void lstBranch_DoubleClick(object sender, EventArgs e)
        {
            uctxtBranchName.Text = lstBranch.Text;
            lstBranch.Visible = false;
            dteFromDate.Focus();


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
                dteFromDate.Focus();


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



        

     
        


        #endregion
        private void mLaodItem()
        {

        }
        private void radIndividual_Click(object sender, EventArgs e)
        {

        }
        private void radAll_Click(object sender, EventArgs e)
        {
            dteFromDate.Focus();
        }
        private void frmRptStoreLedger_Load(object sender, EventArgs e)
        {
            uctxtBranchName.Select();
            //dteFromDate.Text = Utility.gdteFinancialYearFrom;
            //dteToDate.Text = Utility.gdteFinancialYearTo;
            dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");
            if (strName=="I")
            {
                cboGroupName.Visible = true;
                cboGroupName.ValueMember = "strItemGroup";
                cboGroupName.DisplayMember = "strItemGroup";
                cboGroupName.DataSource = invms.mGetStockGroup(strComID,1).ToList();
                grpSelction.Visible = false;
                frmLabel.Text = "Stock Summarry Inward  Price";
            }
            else if (strName == "S")
            {
                grpSelction.Visible = true;
                frmLabel.Text = "Stock Statement";
            }
            else if (strName == "Su")
            {
                grpSelction.Visible = true;
                frmLabel.Text = "Stock Statement Summarry";
            }
            else if (strName == "P")
            {
                cboGroupName.Visible = true;
                cboGroupName.ValueMember = "strItemGroup";
                cboGroupName.DisplayMember = "strItemGroup";
                cboGroupName.DataSource = invms.mGetStockGroup(strComID,1).ToList();
                grpSelction.Visible = false;
                frmLabel.Text = "Stock Summarry Purchase  Price";
            }
            lstBranch.ValueMember = "BranchID";
            lstBranch.DisplayMember = "BranchName";
            lstBranch.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
            mLoad();

        }
        private void btnPrint_Click(object sender, EventArgs e)
        {

            string strBranchId = "", strString = "";
            int inttype = 1,intAlias=0;
            if (radItem.Checked ==true)
            {
                intAlias = 0;
            }
            else
            {
                intAlias = 1;
            }
            if (uctxtBranchName.Text == "")
            {
                MessageBox.Show("Branch Name Cannot be Empty");
                uctxtBranchName.Focus();
                return;
            }
            if (lstRight.Items.Count == 0)
            {
                for (int i = 0; i < lstLeft.Items.Count; i++)
                {
                    strString = strString + "'" + lstLeft.Items[i].ToString() + "',";
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
            strBranchId = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);
            if (strName == "I")
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.StockIPrice;
                frmviewer.strString = strString;
                frmviewer.strBranchID = strBranchId;
                frmviewer.strFdate = dteFromDate.Text;
                frmviewer.strTdate = dteToDate.Text;
                frmviewer.strSelction = "I";
                frmviewer.strGroup = cboGroupName.Text;
                frmviewer.intSorting = intAlias;
                frmviewer.Show();
            }
            else if (strName =="S" || strName =="Su")
            {
                if (radProductWise.Checked==true)
                {
                    inttype = 1;
                }
                else if (radPackSize.Checked==true)
                {
                    inttype = 2;
                }
                else
                {
                    inttype = 3;
                }
                if (strString =="")
                {
                    MessageBox.Show("Select the Item First");
                    return;
                }
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.StockStatement;
                frmviewer.strString = strString;
                frmviewer.strBranchID = strBranchId;
                frmviewer.strFdate = dteFromDate.Text;
                frmviewer.strTdate = dteToDate.Text;
                frmviewer.intype = inttype;
                frmviewer.strSelction=strName;
                frmviewer.intSorting = intAlias;
                frmviewer.Show();
            }
            else if (strName == "P")
            {

                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.StockIPrice;
                frmviewer.strString = strString;
                frmviewer.strBranchID = strBranchId;
                frmviewer.strFdate = dteFromDate.Text;
                frmviewer.strTdate = dteToDate.Text;
                frmviewer.strSelction = "O";
                frmviewer.intSorting = intAlias;
                frmviewer.Show();
            }

        }

        private void radCategoryWise_Click(object sender, EventArgs e)
        {
            uctxtBranchName.Visible = true;
            lblCategory.Visible = true;
           
            //mLoad();
            uctxtBranchName.Text = "";
            uctxtBranchName.Focus();
        }
        private void radStockGroupWise_Click(object sender, EventArgs e)
        {
            uctxtBranchName.Text = "";
            uctxtBranchName.Visible = true;
            lblCategory.Visible = true;
            //mLoad();
            uctxtBranchName.Focus();
          
           
        }
        private void mLoad()
        {
            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            List<StockItem> oogrp;
            if (strName == "S")
            {
                oogrp = invms.gLoadStockGroup(strComID, Utility.gblnAccessControl, Utility.gstrUserName,"Y",cboGroupName.Text).ToList();
            }
            else if (strName == "Su")
            {
                oogrp = invms.gLoadStockGroup(strComID, Utility.gblnAccessControl, Utility.gstrUserName, "Y","").ToList();
            }
            else
            {
                oogrp = invms.gLoadStockGroup(strComID, Utility.gblnAccessControl, Utility.gstrUserName, "K", cboGroupName.Text).ToList();
                 //oogrp = invms.gLoadStockGroup(strComID, Utility.gblnAccessControl, Utility.gstrUserName,"P").ToList();
            }
            if (oogrp.Count > 0)
            {
                foreach (StockItem ostk in oogrp)
                {
                    lstLeft.Items.Add(ostk.strItemGroup);
                }
            }

        }
        private void radLevelWise_Click(object sender, EventArgs e)
        {
            uctxtBranchName.Text = "";
            uctxtBranchName.Visible = false;
            lblCategory.Visible = false;
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            lstLeft.SelectedIndex = lstLeft.FindString(txtSearch.Text);
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtSearch.Text != "")
                {
                    lstRight.Items.Add(lstLeft.Text.ToString());
                    lstLeft.Items.Remove(lstLeft.Text.ToString());
                    txtSearch.Text = "";
                    txtSearch.Focus(); ;
                }
                else
                {
                    btnPrint.Focus();
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

        private void cboGroupName_SelectedIndexChanged(object sender, EventArgs e)
        {
            mLoad();
        }



    }
}
