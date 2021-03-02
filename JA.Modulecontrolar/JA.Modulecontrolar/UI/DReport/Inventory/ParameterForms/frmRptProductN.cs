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
using JA.Modulecontrolar.JACCMS;

namespace JA.Modulecontrolar.UI.DReport.Inventory.ParameterForms
{
    public partial class frmRptProductN : JA.Shared.UI.frmJagoronFromSearch
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        JRPT.ISWRPT jrpt = new JRPT.SWRPTClient();
        private ListBox lstLevelname = new ListBox();
        private ListBox lstCategoryGroup = new ListBox();
        private ListBox lstBranch = new ListBox();
          List<StockItem> oogrp;
        public string strType { get; set; }
        private string strComID { get; set; }
        private string strName= "";
        public frmRptProductN()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.lstLeft.DoubleClick += new System.EventHandler(this.lstLeft_DoubleClick);
            this.lstLeft.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstLeft_KeyPress);

            //this.txtSerchGroup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSerchGroup_KeyPress);
            //this.txtSerchGroup.TextChanged += new System.EventHandler(this.txtSerchGroup_TextChanged);
            //this.lstLeftNew.DoubleClick += new System.EventHandler(this.lstLeftNew_DoubleClick);
            //this.lstLeftNew.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstLeftNew_KeyPress);
            this.cboGroupName.SelectedIndexChanged += new System.EventHandler(this.cboGroupName_SelectedIndexChanged);


            ///sales Price
            ///
            //this.uctxtName.KeyDown += new KeyEventHandler(uctxtName_KeyDown);
            //this.uctxtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtName_KeyPress);
            //this.uctxtName.TextChanged += new System.EventHandler(this.uctxtName_TextChanged);
            //this.lstCategoryGroup.DoubleClick += new System.EventHandler(this.lstCategoryGroup_DoubleClick);
            //this.uctxtName.GotFocus += new System.EventHandler(this.uctxtName_GotFocus);


            //this.uctxtLevelName.KeyDown += new KeyEventHandler(uctxtLevelName_KeyDown);
            //this.uctxtLevelName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtLevelName_KeyPress);
            //this.uctxtLevelName.TextChanged += new System.EventHandler(this.uctxtLevelName_TextChanged);
            //this.lstLevelname.DoubleClick += new System.EventHandler(this.lstLevelname_DoubleClick);
            //this.uctxtLevelName.GotFocus += new System.EventHandler(this.uctxtLevelName_GotFocus);

            ///Invoice Price
            this.uctxtBranchName.KeyDown += new KeyEventHandler(uctxtBranchName_KeyDown);
            this.uctxtBranchName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranchName_KeyPress);
            this.uctxtBranchName.TextChanged += new System.EventHandler(this.uctxtBranchName_TextChanged);
            this.lstBranch.DoubleClick += new System.EventHandler(this.lstBranch_DoubleClick);
            this.uctxtBranchName.GotFocus += new System.EventHandler(this.uctxtBranchName_GotFocus);
     
            //Utility.CreateListBox(lstLevelname, pnlMain, uctxtLevelName);
            //Utility.CreateListBox(lstCategoryGroup, pnlMain, uctxtName);
            Utility.CreateListBox(lstBranch, pnlMain, uctxtBranchName);
            

        }
        #region "User Deifne Sales Price"

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


     

        private void lstCategoryGroup_DoubleClick(object sender, EventArgs e)
        {
          
            lstCategoryGroup.Visible = false;
            lstLevelname.Visible = true;
        }


        private void uctxtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstCategoryGroup.SelectedItem != null)
                {
                    lstCategoryGroup.SelectedIndex = lstCategoryGroup.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstCategoryGroup.Items.Count - 1 > lstCategoryGroup.SelectedIndex)
                {
                    lstCategoryGroup.SelectedIndex = lstCategoryGroup.SelectedIndex + 1;
                }
            }

        }
        //private void mLoadLocation()
        //{
        //    lstLevelname.ValueMember = "strLocation";
        //    lstLevelname.DisplayMember = "strLocation";
        //    lstLevelname.DataSource = invms.mLoadLocation(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
        //}
 


        #endregion
        //private void txtSerchGroup_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Return)
        //    {

        //        btnRightNew.PerformClick();
        //        lstLeftNew.SetSelected(0, true);
        //        txtSerchGroup.Text = "";
        //        txtSerchGroup.Focus();
        //        // dteFromDate.Focus();

        //    }
        //}
        //private void lstLeftNew_DoubleClick(object sender, EventArgs e)
        //{
        //    btnRightNew.PerformClick();
        //    lstLeftNew.SetSelected(0, true);
        //}

        //private void lstLeftNew_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Return)
        //    {

        //        btnRightNew.PerformClick();
        //        lstLeftNew.SetSelected(0, true);
        //        txtSerchGroup.Text = "";
        //        txtSerchGroup.Focus();
        //        // dteFromDate.Focus();

        //    }
        //}
        //private void txtSerchGroup_TextChanged(object sender, EventArgs e)
        //{
        //    lstLeftNew.SelectedIndex = lstLeftNew.FindString(txtSerchGroup.Text);
        //}
        private void mLaodItem()
        {
            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            List<StockItem> oogrp = invms.gFillStockItemAllWithoutGodown(strComID,Utility.gblnAccessControl,Utility.gstrUserName,"" ).ToList();
            if (oogrp.Count > 0)
            {
                foreach (StockItem ostk in oogrp)
                {
                    lstLeft.Items.Add(ostk.strItemName);
                }
            }
        }
        //private void mLoadStockGroupNew()
        //{
        //    lstLeftNew.Items.Clear();
        // 
        //    List<StockItem> oogrp = invms.gLoadStockGroup(strComID, Utility.gblnAccessControl, Utility.gstrUserName, "N",cboGroupName.Text).ToList();
        //    if (oogrp.Count > 0)
        //    {
        //        foreach (StockItem ostk in oogrp)
        //        {
        //            lstLeftNew.Items.Add(ostk.strItemGroup);
        //        }
        //    }
        //}

        private void mLoadStockGroup()
        {
            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            List<StockItem> oogrp = invms.gLoadStockGroup(strComID,Utility.gblnAccessControl, Utility.gstrUserName,"N",cboGroupName.Text).ToList();
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
 
 

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            lstLeft.SelectedIndex = lstLeft.FindString(txtSearch.Text);
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
           
            string strString = "",struserString="",strString1="";
            int intSuppress;
            
            if (rbtntopSheet.Checked == true)
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.ProductTopSheetSalesPrice;
                frmviewer.strFdate = dteFromDate.Text;
                frmviewer.strTdate = dteToDate.Text;
                //frmviewer.strString = strGroupName;
                frmviewer.strSelction = "";
                frmviewer.Show();
            }
            else if (rbtnInvoiceP.Checked == true)
            {
                #region"Sales price"
                string strBranchId = "";
                int inttype = 1, intAlias = 0;
                if (radItem.Checked == true)
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
                else if (strName == "S" || strName == "Su")
                {
                   
                    if (strString == "")
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
                    frmviewer.strSelction = strName;
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
             
            #endregion
            }
            else
            {
                #region"Purchase price"
                string strBranchId = "";
                int inttype = 1, intAlias = 0;
                if (radItem.Checked == true)
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
                else if (strName == "S" || strName == "Su")
                {
                    
                    if (strString == "")
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
                    frmviewer.strSelction = strName;
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
                #endregion
            }


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
                // dteFromDate.Focus();

            }
        }

        private void btnRightNew_Click(object sender, EventArgs e)
        {
        
        }

        private void btnRightAllNew_Click(object sender, EventArgs e)
        {
          
        }

        private void btnLeftNew_Click(object sender, EventArgs e)
        {
         
        }

        private void btnLeftAllNew_Click(object sender, EventArgs e)
        {
           
        }

        private void radLocationGroup_CheckedChanged(object sender, EventArgs e)
        {
            strType = "L";
        }

   
        private void cboGroupName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtntopSheet.Checked == true)
            {
                if (strType == "L")
                {
                    //mLoadStockGroupNew();
                }
                else
                {
                    mLoadStockGroup();
                }
            }
            else
            {
                mLoad();

            }


        }

        private void mLoad()
        {
            groupBox7.Enabled = true;
            lstLeft.Items.Clear();
            lstRight.Items.Clear();
 
            if (strName == "S")
            {
                oogrp = invms.gLoadStockGroup(strComID, Utility.gblnAccessControl, Utility.gstrUserName, "Y", cboGroupName.Text).ToList();
            }
            else if (strName == "Su")
            {
                oogrp = invms.gLoadStockGroup(strComID, Utility.gblnAccessControl, Utility.gstrUserName, "Y", "").ToList();
            }
            else if (strName == "I")
            {
                oogrp = invms.gLoadStockGroup(strComID, Utility.gblnAccessControl, Utility.gstrUserName, "K", "Finished Goods").ToList();
            }
            else
            {
                oogrp = invms.gLoadStockGroup(strComID, Utility.gblnAccessControl, Utility.gstrUserName, "K", cboGroupName.Text).ToList();
            }
            if (oogrp.Count > 0)
            {
                foreach (StockItem ostk in oogrp)
                {
                    lstLeft.Items.Add(ostk.strItemGroup);
                }
            }

        }

        private void radCategory_CheckedChanged(object sender, EventArgs e)
        {
            strType = "C";
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rbtnPurchase_MouseClick(object sender, MouseEventArgs e)
        {
          
            gboxInwardPurchase.Enabled = true;
            groupBox7.Visible = true;
            lblCategory.Visible = true;
            uctxtBranchName.Visible = true;
            lstBranch.Visible = true;
         
          
            lstLevelname.Visible = false;
            lstCategoryGroup.Visible = false;
            strName = "P";
            label6.Visible = true;
            cboGroupName.Visible = true;
            lstBranch.ValueMember = "BranchID";
            lstBranch.DisplayMember = "BranchName";
            lstBranch.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();

            cboGroupName.Visible = true;
            StockGroupLoad();
            mLoad();

            frmLabel.Text = "Stock Summary Purchase Price";


        }

        private void rbtnSalesP_MouseClick(object sender, MouseEventArgs e)
        {
   
          
            groupBox7.Visible = false;
            gboxInwardPurchase.Enabled = false;
            lblCategory.Visible = false;
            uctxtBranchName.Visible = false;
            lstBranch.Visible = false;
           
           
            //load
            lstCategoryGroup.Visible = false;
         
            label3.Visible = false;
            lstLevelname.ValueMember = "strSalesPriceLevel";
            lstLevelname.DisplayMember = "strSalesPriceLevel";
            lstLevelname.DataSource = invms.mGetPriceLevel(strComID).ToList();
            lstLevelname.Visible = true;
            label6.Visible = false;
            cboGroupName.Visible = false;
            frmLabel.Text = "Stock Summary Sales Price";

          
            
           
        }

        private void btninvoice()
        {

            gboxInwardPurchase.Enabled = true;
            groupBox7.Visible = true;
            lblCategory.Visible = true;
            uctxtBranchName.Visible = true;
            lstBranch.Visible = true;

            lstLevelname.Visible = false;
            lstCategoryGroup.Visible = false;
            strName = "I";
            label6.Visible = false;
            cboGroupName.Visible = false;
          
            lstBranch.ValueMember = "BranchID";
            lstBranch.DisplayMember = "BranchName";
            lstBranch.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();

            mLoad();
            frmLabel.Text = "Stock Summary Invoice Price";
            
        }
        private void rbtnInvoiceP_MouseClick(object sender, MouseEventArgs e)
        {

            btninvoice();
        }

       

        private void rbtnCostP_MouseClick(object sender, MouseEventArgs e)
        {

          
            gboxInwardPurchase.Enabled = false;
            groupBox7.Visible = true;
            lblCategory.Visible = false;
            uctxtBranchName.Visible = false;
            lstBranch.Visible = false;
      
       
            lstLevelname.Visible = false;
            lstCategoryGroup.Visible = false;
            label6.Visible = true;
            cboGroupName.Visible = true;
            //StockGroupLoad();
            btninvoice();
            frmLabel.Text = "Stock Summary Top Sheet";
        }

        private void groupBox9_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void pnlTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rbtCategory_MouseClick(object sender, MouseEventArgs e)
        {
  
            label3.Visible = true;
  
            lstLevelname.Visible = false;
            lstCategoryGroup.Visible = true;
           

            lstCategoryGroup.ValueMember = "strGroupName";
            lstCategoryGroup.DisplayMember = "strGroupName";
            lstCategoryGroup.DataSource = jrpt.mloadCategoryGroup(strComID, 2).ToList();
        }

        private void radGroup_Click(object sender, EventArgs e)
        {

            lstRight.Items.Clear();
      
            label3.Visible = true;
    
            lstLevelname.Visible = false;
            lstCategoryGroup.Visible = true;
            lstCategoryGroup.ValueMember = "strGroupName";
            lstCategoryGroup.DisplayMember = "strGroupName";
            lstCategoryGroup.DataSource = jrpt.mloadCategoryGroup(strComID, 3).ToList();
     
        }

        private void rbtnallSP_Click(object sender, EventArgs e)
        {
            lstCategoryGroup.Visible = false;
            label3.Visible = false;
      
            lstLevelname.ValueMember = "strSalesPriceLevel";
            lstLevelname.DisplayMember = "strSalesPriceLevel";
            lstLevelname.DataSource = invms.mGetPriceLevel(strComID).ToList();
            //lstLevelname.Top = 270;
         
        }

        private void radSelection_Click(object sender, EventArgs e)
        {
   
        
            groupBox7.Enabled = true;
            
            txtSearch.Focus();
         
        
           
           
      
                groupBox7.Enabled = true;
             
            
               
               
              
                lstRight.Items.Clear();
             
         
        }

        private void radAllItem_Click(object sender, EventArgs e)
        {
            //if (radValueSupp.Checked == true)
            //{
            //    groupBox7.Enabled = false;
               
             
             
                
               

            //    lstRight.Items.Clear();
             
            //}
            //else
            //{
            //    groupBox7.Enabled = false;
             
            
               
               
              

            //    lstRight.Items.Clear();
             
            //}
            
        }

        private void radGroupwise_Click(object sender, EventArgs e)
        {
           
        
            strType = "C";
          
            cboGroupName.Visible = true;
            mLoadStockGroup();
        }

        private void radLocationwise_Click(object sender, EventArgs e)
        {
            strType = "C";
            label6.Visible = false;
            cboGroupName.Visible = false;
            mLoadLocation();
        }

        private void radItemWise_Click(object sender, EventArgs e)
        {
            strType = "C";
           label6.Visible = false;
            cboGroupName.Visible = false;
          
            mLaodItem();
        }

        private void rbtCategory_Click(object sender, EventArgs e)
        {
          
            strType = "C";
            mLoadStockCategory();
        }

        private void radLocationGroup_Click(object sender, EventArgs e)
        {
            label6.Visible = true;
            cboGroupName.Visible = true;
            cboGroupName.Visible = true;
            cboGroupName.ValueMember = "strItemGroup";
            cboGroupName.DisplayMember = "strItemGroup";
            cboGroupName.DataSource = invms.mGetStockGroup(strComID,1).ToList();
            strType = "L";
            mLoadLocation();
        }


        private void btnRightSingle_Click(object sender, EventArgs e)
        {
            if (lstLeft.SelectedItems.Count > 0)
            {
                lstRight.Items.Add(lstLeft.SelectedItem.ToString());
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

        private void frmRptProductN_Load(object sender, EventArgs e)
        {
         
            gboxInwardPurchase.Enabled = false;
            lblCategory.Visible = false;
            uctxtBranchName.Visible = false;
            lstBranch.Visible = false;
            lstLevelname.Visible = false;
            lstCategoryGroup.Visible = false;
            
            label6.Visible = true;
            cboGroupName.Visible = true;
            StockGroupLoad();

            frmLabel.Text = "Top Sheet Sales Price";
            mLoadStockGroup();

            dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");
           
            groupBox7.Enabled = false;
            btninvoice();
      
        }
        private void StockGroupLoad()
        {
            if (rbtnPurchase.Checked == true)
            {
                cboGroupName.ValueMember = "strItemGroup";
                cboGroupName.DisplayMember = "strItemGroup";
                cboGroupName.DataSource = invms.mGetStockGroup(strComID, 2).ToList();
            }
            else
            {
                cboGroupName.ValueMember = "strItemGroup";
                cboGroupName.DisplayMember = "strItemGroup";
                cboGroupName.DataSource = invms.mGetStockGroup(strComID, 1).ToList();
            }
        }


    }
}
