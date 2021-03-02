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
using System.Runtime.InteropServices;

namespace JA.Modulecontrolar.UI.DReport.Inventory.ParameterForms
{
    public partial class frmRptStockInformation_N : JA.Shared.UI.frmJagoronFromSearch
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        JRPT.ISWRPT jrpt = new JRPT.SWRPTClient();
        private ListBox lstLevelname = new ListBox();
        private ListBox lstCategoryGroup = new ListBox();
        private ListBox lstBranch = new ListBox();
          List<StockItem> oogrp;
          private ListBox lstLocation = new ListBox();
          private ListBox lstItem = new ListBox();
        public string strType { get; set; }
        private string strComID { get; set; }
        private string strName= "";
        public frmRptStockInformation_N()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            #region "User Define"
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

            this.uctxtName.KeyDown += new KeyEventHandler(uctxtName_KeyDown);
            this.uctxtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtName_KeyPress);
            this.uctxtName.TextChanged += new System.EventHandler(this.uctxtName_TextChanged);
            this.lstCategoryGroup.DoubleClick += new System.EventHandler(this.lstCategoryGroup_DoubleClick);
            this.uctxtName.GotFocus += new System.EventHandler(this.uctxtName_GotFocus);


            this.uctxtLevelName.KeyDown += new KeyEventHandler(uctxtLevelName_KeyDown);
            this.uctxtLevelName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtLevelName_KeyPress);
            this.uctxtLevelName.TextChanged += new System.EventHandler(this.uctxtLevelName_TextChanged);
            this.lstLevelname.DoubleClick += new System.EventHandler(this.lstLevelname_DoubleClick);
            this.uctxtLevelName.GotFocus += new System.EventHandler(this.uctxtLevelName_GotFocus);

            ///Invoice Price
            this.uctxtBranchName.KeyDown += new KeyEventHandler(uctxtBranchName_KeyDown);
            this.uctxtBranchName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranchName_KeyPress);
            this.uctxtBranchName.TextChanged += new System.EventHandler(this.uctxtBranchName_TextChanged);
            this.lstBranch.DoubleClick += new System.EventHandler(this.lstBranch_DoubleClick);
            this.uctxtBranchName.GotFocus += new System.EventHandler(this.uctxtBranchName_GotFocus);

            this.txtLocationName.KeyDown += new KeyEventHandler(txtLocationName_KeyDown);
            this.txtLocationName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtLocationName_KeyPress);
            this.txtLocationName.TextChanged += new System.EventHandler(this.txtLocationName_TextChanged);
            this.lstLocation.DoubleClick += new System.EventHandler(this.lstLocation_DoubleClick);
            this.txtLocationName.GotFocus += new System.EventHandler(this.txtLocationName_GotFocus);
            Utility.CreateListBox(lstLocation, pnlMain, txtLocationName);
           
            Utility.CreateListBox(lstLevelname, pnlMain, uctxtLevelName);
            Utility.CreateListBox(lstCategoryGroup, pnlMain, uctxtName);
            Utility.CreateListBox(lstBranch, pnlMain, uctxtBranchName);
            #endregion

        }
        #region "User Deifne Sales Price"
        private void txtLocationName_TextChanged(object sender, EventArgs e)
        {
            lstLocation.SelectedIndex = lstLocation.FindString(txtLocationName.Text);
         
        }

        private void lstLocation_DoubleClick(object sender, EventArgs e)
        {
        
            txtLocationName.Text = lstLocation.Text;
            lstLocation.Visible = false;
            dteFromDate.Focus();

        }

        private void txtLocationName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstLocation.Items.Count > 0)
                {
                    txtLocationName.Text = lstLocation.Text;
                }
                lstLocation.Visible = false;
                dteFromDate.Focus();
            }
        }
        private void txtLocationName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstLocation.SelectedItem != null)
                {
                    lstLocation.SelectedIndex = lstLocation.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstLocation.Items.Count - 1 > lstLocation.SelectedIndex)
                {
                    lstLocation.SelectedIndex = lstLocation.SelectedIndex + 1;
                }
            }

        }

        private void txtLocationName_GotFocus(object sender, System.EventArgs e)
        {
            lstBranch.Visible = false;
            lstLocation.Visible = true;
            
            mLoadLocationName();
            lstLocation.SelectedIndex = lstLocation.FindString(txtLocationName.Text);

        }
        private void uctxtBranchName_TextChanged(object sender, EventArgs e)
        {
            lstBranch.SelectedIndex = lstBranch.FindString(uctxtBranchName.Text);
        }

        private void lstBranch_DoubleClick(object sender, EventArgs e)
        {
            txtLocationName.Text = "";
            uctxtBranchName.Text = lstBranch.Text;
            lstBranch.Visible = false;
            txtLocationName.Focus();


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
                txtLocationName.Text = "";
                txtLocationName.Focus();


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
            lstLocation.Visible = false;
            lstBranch.SelectedIndex = lstBranch.FindString(uctxtBranchName.Text);

        }


        private void uctxtName_TextChanged(object sender, EventArgs e)
        {
            lstCategoryGroup.SelectedIndex = lstCategoryGroup.FindString(uctxtName.Text);
        }

        private void lstCategoryGroup_DoubleClick(object sender, EventArgs e)
        {
            uctxtName.Text = lstCategoryGroup.Text;
            uctxtLevelName.Focus();
            lstCategoryGroup.Visible = false;
            lstLevelname.Visible = true;
        }

        private void uctxtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstCategoryGroup.Items.Count > 0)
                {
                    uctxtName.Text = lstCategoryGroup.Text;
                }
                lstCategoryGroup.Visible = false;
                lstLevelname.Visible = true;
                uctxtLevelName.Focus();

            }
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
        private void uctxtName_GotFocus(object sender, System.EventArgs e)
        {
            lstCategoryGroup.Visible = true;
            lstLevelname.Visible = false;
            lstCategoryGroup.SelectedIndex = lstCategoryGroup.FindString(uctxtName.Text);

        }
        private void uctxtLevelName_TextChanged(object sender, EventArgs e)
        {
            lstCategoryGroup.Visible = false;
            lstLevelname.SelectedIndex = lstLevelname.FindString(uctxtLevelName.Text);
        }

        private void lstLevelname_DoubleClick(object sender, EventArgs e)
        {
            uctxtLevelName.Text = lstLevelname.Text;
            lstLevelname.Visible = false;
            lstCategoryGroup.Visible = false;
            btnPrint.Focus();
        }

        private void uctxtLevelName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstLevelname.Items.Count > 0)
                {
                    uctxtLevelName.Text = lstLevelname.Text;
                }
                lstCategoryGroup.Visible = false;
                lstLevelname.Visible = false;
                btnPrint.Focus();
            }
        }
        private void uctxtLevelName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstLevelname.SelectedItem != null)
                {
                    lstLevelname.SelectedIndex = lstLevelname.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstLevelname.Items.Count - 1 > lstLevelname.SelectedIndex)
                {
                    lstLevelname.SelectedIndex = lstLevelname.SelectedIndex + 1;
                }
            }

        }

        private void uctxtLevelName_GotFocus(object sender, System.EventArgs e)
        {
            lstCategoryGroup.Visible = false;
            lstLevelname.Visible = true;
            lstLevelname.SelectedIndex = lstLevelname.FindString(uctxtLevelName.Text);

        }

        #endregion
        #region "Keypress"
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
            string strLocation = "";
            if (txtLocationName.Text == "")
            {
                strLocation = "";
            }
            else
            {
                strLocation = txtLocationName.Text;
            }

            string strString = "",struserString="",strString1="",strBranchID="";
            int intSuppress;
            strBranchID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);
            if (Utility.gblnAccessControl)
            {
                if (radGroupwise.Checked)
                {
                    struserString = Utility.mLoadStockGroupSecurity(strComID, Utility.gstrUserName);
                }
                else if (radItemWise.Checked)
                {
                    struserString = Utility.mLoadStockItemSecurity(strComID, Utility.gstrUserName);
                }
            }
            if (radSuppressZero.Checked == true)
            {
                intSuppress = 1;
            }
            else if (radValueSupp.Checked == true)
            {
                intSuppress = 2;
            }
            else
            {
                intSuppress = 0;
            }
            if (chkboxWithoutOH.Checked == false)
            {
                #region "With OverHead"


                if (lstRight.Items.Count == 0)
                {
                    MessageBox.Show("Cannot be Empty");
                    uctxtName.Focus();
                    return;
                }



                for (int i = 0; i < lstRight.Items.Count; i++)
                {
                    strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                }

                if (strString != "")
                {
                    strString = Utility.Mid(strString, 0, strString.Length - 1);
                }
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.withoverhead;
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strString = strString;
                frmviewer.strBranchID = strBranchID;
                frmviewer.strSelction = "G";
                frmviewer.strString7 = strLocation;
                frmviewer.intSuppress = intSuppress;
                frmviewer.Show();
                return;

                #endregion

            }
            else
            {
                #region "Cost Price"
                #region StocInformationGroupwise

                if (radGroupwise.Checked == true)
                {
                    if ((cboxOpening.Checked == true) && (cboxbInward.Checked == true) && (cboxOutward.Checked == true) && (cboxClosing.Checked == true) && (radGroupwise.Checked == true))
                    {
                        if (radAllItem.Checked)
                        {
                            //for (int i = 0; i < lstLeft.Items.Count; i++)
                            //{
                            //    strString = strString + "'" + lstLeft.Items[i].ToString().Replace("'","''") + "',";
                            //}
                            //if (lstLeft.Items.Count==0)
                            //{
                            //strString = "'NONE',";
                            //}
                        }
                        else
                        {
                            for (int i = 0; i < lstRight.Items.Count; i++)
                            {
                                strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                            }
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.GroupoptionWiseOpnInwOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strString7 = strLocation;
                        frmviewer.strSelction = "G";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }
                    if ((cboxOpening.Checked == true) && (cboxbInward.Checked == true) && (cboxOutward.Checked == true) && (radGroupwise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.GroupoptionWiseOpnInwOutw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "G";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }
                    if ((cboxOpening.Checked == true) && (cboxbInward.Checked == true) && (cboxClosing.Checked == true) && (radGroupwise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.GroupoptionWiseOpnInwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "G";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }
                    if ((cboxOpening.Checked == true) && (cboxOutward.Checked == true) && (cboxClosing.Checked == true) && (radGroupwise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.GroupoptionWiseOpnOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "G";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }

                    if ((cboxbInward.Checked == true) && (cboxOutward.Checked == true) && (cboxClosing.Checked == true) && (radGroupwise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.GroupoptionWiseInwOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "G";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }
                    if ((radAllItem.Checked == true) && (radGroupwise.Checked == true) && (radValueSupp.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.GroupoptionWiseOpnInwOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "G";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intype = 1;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }
                    if ((radGroupwise.Checked == true) && (radSelection.Checked == true) && (radValueSupp.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.GroupoptionWiseOpnInwOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "G";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intype = 1;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }

                    if ((cboxOpening.Checked == true) && (cboxbInward.Checked == true) && (radGroupwise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.GroupoptionWiseOpnInw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "G";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }

                    if ((cboxOpening.Checked == true) && (cboxOutward.Checked == true) && (radGroupwise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.GroupoptionWiseOpnOutw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "G";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }

                    if ((cboxOpening.Checked == true) && (cboxClosing.Checked == true) && (radGroupwise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.GroupoptionWiseOpnCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "G";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }

                    if ((cboxbInward.Checked == true) && (cboxOutward.Checked == true) && (radGroupwise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.GroupoptionWiseInwOotw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "G";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }

                    if ((cboxbInward.Checked == true) && (cboxClosing.Checked == true) && (radGroupwise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.GroupoptionWiseInwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "G";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }


                    if ((cboxOutward.Checked == true) && (cboxClosing.Checked == true) && (radGroupwise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.GroupoptionWiseOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "G";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }
                    if ((radAllItem.Checked == true) && (radGroupwise.Checked == true) && (radValueSupp.Checked == true))
                    {

                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.GroupWiseValueSup;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "G";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intype = 1;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }


                    if ((cboxOpening.Checked == true) && (radGroupwise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.GroupoptionWiseOpn;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "G";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }


                    if ((cboxbInward.Checked == true) && (radGroupwise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.GroupoptionWiseINW;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "G";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }

                    if ((cboxOutward.Checked == true) && (radGroupwise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.GroupoptionWiseOUTW;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "G";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }


                    if ((cboxClosing.Checked == true) && (radGroupwise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.GroupoptionWiseClos;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "G";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }



                    if (radAll.Checked == true)
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.GroupoptionWiseOpnInwOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "G";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }



                }
                #endregion
                #region StoctInformaitonCategorewise

                if (radCategory.Checked == true)
                {
                    if ((cboxOpening.Checked == true) && (cboxbInward.Checked == true) && (cboxOutward.Checked == true) && (cboxClosing.Checked == true) && (radCategory.Checked == true))
                    {
                        if (radAllItem.Checked)
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
                        frmviewer.selector = ViewerSelector.StockinfoCatWiseOpnInwOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "C";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }

                    if ((cboxbInward.Checked == true) && (cboxOutward.Checked == true) && (cboxClosing.Checked == true) && (radCategory.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoCatWiseInwOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "C";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }



                    if ((cboxOpening.Checked == true) && (cboxbInward.Checked == true) && (cboxClosing.Checked == true) && (radCategory.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoCatWiseOpnInwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "C";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }


                    if ((cboxOpening.Checked == true) && (cboxbInward.Checked == true) && (cboxOutward.Checked == true) && (radCategory.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoCatWiseOpnInwOutw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "C";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }


                    if ((cboxOpening.Checked == true) && (cboxOutward.Checked == true) && (cboxClosing.Checked == true) && (radCategory.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoCatWiseOpnOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "C";
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.Show();
                        return;

                    }

                    if ((cboxbInward.Checked == true) && (cboxClosing.Checked == true) && (radCategory.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoCatWiseInwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "C";
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.Show();
                        return;

                    }


                    if ((cboxbInward.Checked == true) && (cboxOutward.Checked == true) && (radCategory.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoCatWiseInwOutw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "C";
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.Show();
                        return;

                    }

                    if ((cboxOpening.Checked == true) && (cboxOutward.Checked == true) && (radCategory.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoCatWiseOpnOutw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "C";
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.Show();
                        return;

                    }


                    if ((cboxClosing.Checked == true) && (cboxOutward.Checked == true) && (radCategory.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoCatWiseOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy"); ;
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "C";
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.Show();
                        return;
                    }
                    if ((cboxOpening.Checked == true) && (cboxClosing.Checked == true) && (radCategory.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoCatWiseOpnCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "C";
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.Show();
                        return;

                    }

                    if ((cboxOpening.Checked == true) && (cboxbInward.Checked == true) && (radCategory.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoCatWiseOpnInw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "C";
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.Show();
                        return;

                    }

                    if ((cboxOutward.Checked == true) && (cboxClosing.Checked == true) && (radCategory.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoCatWiseOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "C";
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.Show();
                        return;

                    }

                    if ((cboxClosing.Checked == true) && (radCategory.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoCatWiseCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "C";
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.Show();
                        return;

                    }


                    if ((cboxbInward.Checked == true) && (radCategory.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoCatWiseInw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "C";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;


                    }



                    if ((cboxOpening.Checked == true) && (radCategory.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoCatWiseOpn;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "C";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;


                    }


                    if ((cboxOutward.Checked == true) && (radCategory.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }



                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoCatWiseOutw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "C";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }
                    if ((radCategory.Checked == true) && (radValueSupp.Checked == true))
                    {

                        if (radAllItem.Checked)
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
                        frmviewer.selector = ViewerSelector.StockinfoCatWiseOpnInwOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "C";
                        frmviewer.intype = 1;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }
                }

                #endregion
                #region StoctInformaitonItemwise

                if (radItemWise.Checked == true)
                {


                    if ((cboxOpening.Checked == true) && (cboxbInward.Checked == true) && (cboxOutward.Checked == true) && (cboxClosing.Checked == true) && (radItemWise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        if (strString == "")
                        {
                            strString = struserString;
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoItemWiseOpnInwOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "I";
                        if (strType == "L")
                        {
                            frmviewer.strSelction = "L";
                            frmviewer.strString3 = "S";
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;


                    }

                    if ((cboxbInward.Checked == true) && (cboxOutward.Checked == true) && (cboxClosing.Checked == true) && (radItemWise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        if (strString == "")
                        {
                            strString = struserString;
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoItemWiseInwOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "I";
                        if (strType == "L")
                        {
                            frmviewer.strSelction = "L";
                            frmviewer.strString3 = "S";
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }



                    if ((cboxOpening.Checked == true) && (cboxbInward.Checked == true) && (cboxClosing.Checked == true) && (radItemWise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        if (strString == "")
                        {
                            strString = struserString;
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoItemWiseOpnInwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "I";
                        if (strType == "L")
                        {
                            frmviewer.strSelction = "L";
                            frmviewer.strString3 = "S";
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }


                    if ((cboxOpening.Checked == true) && (cboxbInward.Checked == true) && (cboxOutward.Checked == true) && (radItemWise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        if (strString == "")
                        {
                            strString = struserString;
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoItemWiseOpnInwOutw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "I";
                        if (strType == "L")
                        {
                            frmviewer.strSelction = "L";
                            frmviewer.strString3 = "S";
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }

                    if ((cboxOpening.Checked == true) && (cboxOutward.Checked == true) && (cboxClosing.Checked == true) && (radItemWise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        if (strString == "")
                        {
                            strString = struserString;
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoItemWiseOpnOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "I";
                        if (strType == "L")
                        {
                            frmviewer.strSelction = "L";
                            frmviewer.strString3 = "S";
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }

                    if ((cboxbInward.Checked == true) && (cboxClosing.Checked == true) && (radItemWise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        if (strString == "")
                        {
                            strString = struserString;
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoItemWiseInwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "I";
                        if (strType == "L")
                        {
                            frmviewer.strSelction = "L";
                            frmviewer.strString3 = "S";
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }

                    if ((cboxbInward.Checked == true) && (cboxOutward.Checked == true) && (radItemWise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        if (strString == "")
                        {
                            strString = struserString;
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoItemWiseInwOutw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "I";
                        if (strType == "L")
                        {
                            frmviewer.strSelction = "L";
                            frmviewer.strString3 = "S";
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }

                    if ((cboxOpening.Checked == true) && (cboxOutward.Checked == true) && (radItemWise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        if (strString == "")
                        {
                            strString = struserString;
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoItemWiseOpnOutw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "I";
                        if (strType == "L")
                        {
                            frmviewer.strSelction = "L";
                            frmviewer.strString3 = "S";
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }
                    if ((cboxClosing.Checked == true) && (cboxOutward.Checked == true) && (radItemWise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        if (strString == "")
                        {
                            strString = struserString;
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoItemWiseOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "I";
                        if (strType == "L")
                        {
                            frmviewer.strSelction = "L";
                            frmviewer.strString3 = "S";
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }
                    if ((cboxOpening.Checked == true) && (cboxClosing.Checked == true) && (radItemWise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        if (strString == "")
                        {
                            strString = struserString;
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoItemWiseOpnCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "I";
                        if (strType == "L")
                        {
                            frmviewer.strSelction = "L";
                            frmviewer.strString3 = "S";
                            frmviewer.intype = 2; ;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }

                    if ((cboxOpening.Checked == true) && (cboxbInward.Checked == true) && (radItemWise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        if (strString == "")
                        {
                            strString = struserString;
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoItemWiseOpnInw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "I";
                        if (strType == "L")
                        {
                            frmviewer.strSelction = "L";
                            frmviewer.strString3 = "S";
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }

                    if ((cboxOutward.Checked == true) && (cboxClosing.Checked == true) && (radItemWise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        if (strString == "")
                        {
                            strString = struserString;
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoItemWiseOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "I";
                        if (strType == "L")
                        {
                            frmviewer.strSelction = "L";
                            frmviewer.strString3 = "S";
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }

                    if ((cboxClosing.Checked == true) && (radItemWise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        if (strString == "")
                        {
                            strString = struserString;
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoItemWiseCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "I";
                        if (strType == "L")
                        {
                            frmviewer.strSelction = "L";
                            frmviewer.strString3 = "S";
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }


                    if ((cboxbInward.Checked == true) && (radItemWise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        if (strString == "")
                        {
                            strString = struserString;
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoItemWiseInw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "I";
                        if (strType == "L")
                        {
                            frmviewer.strSelction = "L";
                            frmviewer.strString3 = "S";
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }

                    if ((cboxOpening.Checked == true) && (radItemWise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        if (strString == "")
                        {
                            strString = struserString;
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoItemWiseOpn;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "I";
                        if (strType == "L")
                        {
                            frmviewer.strSelction = "L";
                            frmviewer.strString3 = "S";
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }


                    if ((cboxOutward.Checked == true) && (radItemWise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        if (strString == "")
                        {
                            strString = struserString;
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoItemWiseOutw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "I";
                        if (strType == "L")
                        {
                            frmviewer.strSelction = "L";
                            frmviewer.strString3 = "S";
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }

                    if ((radItemWise.Checked == true) && (radValueSupp.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        if (strString == "")
                        {
                            strString = struserString;
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoItemWiseOpnInwOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "I";
                        if (strType == "L")
                        {
                            frmviewer.strSelction = "L";
                            frmviewer.strString3 = "S";
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intype = 1;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;


                    }


                }

                #endregion
                #region StoctInformaitonLocationewise



                if (radLocationwise.Checked == true)
                {


                    if ((cboxOpening.Checked == true) && (cboxbInward.Checked == true) && (cboxOutward.Checked == true) && (cboxClosing.Checked == true) && (radLocationwise.Checked == true))
                    {
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOpnInwOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }

                    if ((cboxbInward.Checked == true) && (cboxOutward.Checked == true) && (cboxClosing.Checked == true) && (radLocationwise.Checked == true))
                    {
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseInwOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }



                    if ((cboxOpening.Checked == true) && (cboxbInward.Checked == true) && (cboxClosing.Checked == true) && (radLocationwise.Checked == true))
                    {
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOpnInwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;


                    }


                    if ((cboxOpening.Checked == true) && (cboxbInward.Checked == true) && (cboxOutward.Checked == true) && (radLocationwise.Checked == true))
                    {
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOpnInwOutw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }

                    if ((cboxOpening.Checked == true) && (cboxOutward.Checked == true) && (cboxClosing.Checked == true) && (radLocationwise.Checked == true))
                    {
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOpnOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }

                    if ((cboxbInward.Checked == true) && (cboxClosing.Checked == true) && (radLocationwise.Checked == true))
                    {
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseInwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }


                    if ((cboxbInward.Checked == true) && (cboxOutward.Checked == true) && (radLocationwise.Checked == true))
                    {
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseInwOutw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }

                    if ((cboxOpening.Checked == true) && (cboxOutward.Checked == true) && (radLocationwise.Checked == true))
                    {
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOpnOutw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }


                    if ((cboxClosing.Checked == true) && (cboxOutward.Checked == true) && (radLocationwise.Checked == true))
                    {
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;


                    }

                    if ((cboxOpening.Checked == true) && (cboxClosing.Checked == true) && (radLocationwise.Checked == true))
                    {
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOpnCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }



                    if ((cboxOpening.Checked == true) && (cboxbInward.Checked == true) && (radLocationwise.Checked == true))
                    {
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOpnInw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;


                    }


                    if ((cboxOutward.Checked == true) && (cboxClosing.Checked == true) && (radLocationwise.Checked == true))
                    {
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }
                    if ((cboxOutward.Checked == true) && (radLocationwise.Checked == true) && (chkbHorizontal.Checked == true))
                    {
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOutwHorizontal;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }


                    if ((cboxClosing.Checked == true) && (radLocationwise.Checked == true))
                    {
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }


                    if ((cboxbInward.Checked == true) && (radLocationwise.Checked == true))
                    {
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseInw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }

                    if ((cboxOpening.Checked == true) && (radLocationwise.Checked == true))
                    {
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOpn;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }

                    if ((cboxOutward.Checked == true) && (radLocationwise.Checked == true))
                    {
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOutw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }

                    if ((radLocationwise.Checked == true) && (radValueSupp.Checked == true))
                    {
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOpnInwOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        frmviewer.intype = 1;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strString7 = strLocation;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.Show();
                        return;

                    }


                }

                #endregion
                #region StoctInformaitonLocationGroupewise
                if (radLocationGroup.Checked == true)
                {
                    if ((cboxOpening.Checked == true) && (cboxbInward.Checked == true) && (cboxOutward.Checked == true) && (cboxClosing.Checked == true) && (radLocationGroup.Checked == true))
                    {
                        //Location
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString() + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        //if (strString == "")
                        //{
                        //    strString = struserString;
                        //}
                        //*******Group
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOpnInwOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strStringNew = strString1;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.intSorting = 1;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.Show();
                        return;

                    }

                    if ((cboxbInward.Checked == true) && (cboxOutward.Checked == true) && (cboxClosing.Checked == true) && (radLocationGroup.Checked == true))
                    {
                        //Location
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString() + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        //if (strString == "")
                        //{
                        //    strString = struserString;
                        //}
                        //*******Group
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseInwOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strStringNew = strString1;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.Show();
                        return;

                    }



                    if ((cboxOpening.Checked == true) && (cboxbInward.Checked == true) && (cboxClosing.Checked == true) && (radLocationGroup.Checked == true))
                    {
                        //Location
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString() + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        //if (strString == "")
                        //{
                        //    strString = struserString;
                        //}
                        //*******Group
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOpnInwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strStringNew = strString1;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.Show();
                        return;
                    }


                    if ((cboxOpening.Checked == true) && (cboxbInward.Checked == true) && (cboxOutward.Checked == true) && (radLocationGroup.Checked == true))
                    {
                        //Location
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString() + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        //if (strString == "")
                        //{
                        //    strString = struserString;
                        //}
                        //*******Group
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOpnInwOutw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strStringNew = strString1;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.Show();
                        return;

                    }

                    if ((cboxOpening.Checked == true) && (cboxOutward.Checked == true) && (cboxClosing.Checked == true) && (radLocationGroup.Checked == true))
                    {
                        //Location
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString() + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        //if (strString == "")
                        //{
                        //    strString = struserString;
                        //}
                        //*******Group
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOpnOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strStringNew = strString1;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.Show();
                        return;

                    }

                    if ((cboxbInward.Checked == true) && (cboxClosing.Checked == true) && (radLocationGroup.Checked == true))
                    {
                        //Location
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString() + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        //if (strString == "")
                        //{
                        //    strString = struserString;
                        //}
                        //*******Group
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseInwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strStringNew = strString1;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.Show();
                        return;

                    }


                    if ((cboxbInward.Checked == true) && (cboxOutward.Checked == true) && (radLocationGroup.Checked == true))
                    {
                        //Location
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString() + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        //if (strString == "")
                        //{
                        //    strString = struserString;
                        //}
                        //*******Group
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseInwOutw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strStringNew = strString1;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.Show();
                        return;
                    }

                    if ((cboxOpening.Checked == true) && (cboxOutward.Checked == true) && (radLocationGroup.Checked == true))
                    {
                        //Location
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString() + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        //if (strString == "")
                        //{
                        //    strString = struserString;
                        //}
                        //*******Group
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOpnOutw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strStringNew = strString1;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.Show();
                        return;

                    }


                    if ((cboxClosing.Checked == true) && (cboxOutward.Checked == true) && (radLocationGroup.Checked == true))
                    {
                        //Location
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString() + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        //if (strString == "")
                        //{
                        //    strString = struserString;
                        //}
                        //*******Group
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strStringNew = strString1;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }

                    if ((cboxOpening.Checked == true) && (cboxClosing.Checked == true) && (radLocationGroup.Checked == true))
                    {
                        //Location
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString() + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        //if (strString == "")
                        //{
                        //    strString = struserString;
                        //}
                        //*******Group
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOpnCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strStringNew = strString1;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.Show();
                        return;

                    }



                    if ((cboxOpening.Checked == true) && (cboxbInward.Checked == true) && (radLocationGroup.Checked == true))
                    {
                        //Location
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString() + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        //if (strString == "")
                        //{
                        //    strString = struserString;
                        //}
                        //*******Group
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOpnInw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strStringNew = strString1;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.Show();
                        return;
                    }


                    if ((cboxOutward.Checked == true) && (cboxClosing.Checked == true) && (radLocationGroup.Checked == true))
                    {
                        //Location
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString() + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        //if (strString == "")
                        //{
                        //    strString = struserString;
                        //}
                        //*******Group
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strStringNew = strString1;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.Show();
                        return;

                    }

                    if ((cboxClosing.Checked == true) && (radLocationGroup.Checked == true))
                    {
                        //Location
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString() + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        //if (strString == "")
                        //{
                        //    strString = struserString;
                        //}
                        //*******Group
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strStringNew = strString1;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.Show();
                        return;

                    }


                    if ((cboxbInward.Checked == true) && (radLocationGroup.Checked == true))
                    {
                        //Location
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString() + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        //if (strString == "")
                        //{
                        //    strString = struserString;
                        //}
                        //*******Group
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseInw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strStringNew = strString1;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.Show();
                        return;
                    }

                    if ((cboxOpening.Checked == true) && (radLocationGroup.Checked == true))
                    {
                        //Location
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString() + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        //if (strString == "")
                        //{
                        //    strString = struserString;
                        //}
                        //*******Group
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOpn;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strStringNew = strString1;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.Show();
                        return;

                    }

                    if ((cboxOutward.Checked == true) && (radLocationGroup.Checked == true))
                    {
                        //Location
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString() + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        //if (strString == "")
                        //{
                        //    strString = struserString;
                        //}
                        //*******Group
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOutw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strStringNew = strString1;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }

                    if ((radLocationGroup.Checked == true) && (radValueSupp.Checked == true))
                    {
                        //Location
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString() + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        //if (strString == "")
                        //{
                        //    strString = struserString;
                        //}
                        //*******Group
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOpnInwOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strStringNew = strString1;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intype = 1;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }


                }

                #endregion
                #endregion
                #region StocInformationGroupwise
                #region StoctInformaitonCategorewise

                if (radCategory.Checked == true)
                {
                    if ((cboxOpening.Checked == true) && (cboxbInward.Checked == true) && (cboxOutward.Checked == true) && (cboxClosing.Checked == true) && (radCategory.Checked == true))
                    {
                        if (radAllItem.Checked)
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
                        frmviewer.selector = ViewerSelector.StockinfoCatWiseOpnInwOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "C";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }

                    if ((cboxbInward.Checked == true) && (cboxOutward.Checked == true) && (cboxClosing.Checked == true) && (radCategory.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoCatWiseInwOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "C";
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.Show();
                        return;

                    }



                    if ((cboxOpening.Checked == true) && (cboxbInward.Checked == true) && (cboxClosing.Checked == true) && (radCategory.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoCatWiseOpnInwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "C";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }


                    if ((cboxOpening.Checked == true) && (cboxbInward.Checked == true) && (cboxOutward.Checked == true) && (radCategory.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoCatWiseOpnInwOutw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "C";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }


                    if ((cboxOpening.Checked == true) && (cboxOutward.Checked == true) && (cboxClosing.Checked == true) && (radCategory.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoCatWiseOpnOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "C";
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.Show();
                        return;

                    }

                    if ((cboxbInward.Checked == true) && (cboxClosing.Checked == true) && (radCategory.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoCatWiseInwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "C";
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.Show();
                        return;

                    }


                    if ((cboxbInward.Checked == true) && (cboxOutward.Checked == true) && (radCategory.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoCatWiseInwOutw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "C";
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.Show();
                        return;

                    }

                    if ((cboxOpening.Checked == true) && (cboxOutward.Checked == true) && (radCategory.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoCatWiseOpnOutw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "C";
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.Show();
                        return;

                    }


                    if ((cboxClosing.Checked == true) && (cboxOutward.Checked == true) && (radCategory.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoCatWiseOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy"); ;
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "C";
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.Show();
                        return;
                    }
                    if ((cboxOpening.Checked == true) && (cboxClosing.Checked == true) && (radCategory.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoCatWiseOpnCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "C";
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.Show();
                        return;

                    }

                    if ((cboxOpening.Checked == true) && (cboxbInward.Checked == true) && (radCategory.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoCatWiseOpnInw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "C";
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.Show();
                        return;

                    }

                    if ((cboxOutward.Checked == true) && (cboxClosing.Checked == true) && (radCategory.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoCatWiseOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "C";
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.Show();
                        return;

                    }

                    if ((cboxClosing.Checked == true) && (radCategory.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoCatWiseCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "C";
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.Show();
                        return;

                    }


                    if ((cboxbInward.Checked == true) && (radCategory.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoCatWiseInw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "C";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;


                    }



                    if ((cboxOpening.Checked == true) && (radCategory.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoCatWiseOpn;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "C";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;


                    }


                    if ((cboxOutward.Checked == true) && (radCategory.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoCatWiseOutw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "C";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }
                    if ((radCategory.Checked == true) && (radValueSupp.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoCatWiseOpnInwOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strSelction = "C";
                        frmviewer.intype = 1;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.Show();
                        return;

                    }
                }

                #endregion
                #region StoctInformaitonItemwise

                if (radItemWise.Checked == true)
                {


                    if ((cboxOpening.Checked == true) && (cboxbInward.Checked == true) && (cboxOutward.Checked == true) && (cboxClosing.Checked == true) && (radItemWise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        if (strString == "")
                        {
                            strString = struserString;
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoItemWiseOpnInwOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "I";
                        if (strType == "L")
                        {
                            frmviewer.strSelction = "L";
                            frmviewer.strString3 = "S";
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;


                    }

                    if ((cboxbInward.Checked == true) && (cboxOutward.Checked == true) && (cboxClosing.Checked == true) && (radItemWise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        if (strString == "")
                        {
                            strString = struserString;
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoItemWiseInwOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "I";
                        if (strType == "L")
                        {
                            frmviewer.strSelction = "L";
                            frmviewer.strString3 = "S";
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }



                    if ((cboxOpening.Checked == true) && (cboxbInward.Checked == true) && (cboxClosing.Checked == true) && (radItemWise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        if (strString == "")
                        {
                            strString = struserString;
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoItemWiseOpnInwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "I";
                        if (strType == "L")
                        {
                            frmviewer.strSelction = "L";
                            frmviewer.strString3 = "S";
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }


                    if ((cboxOpening.Checked == true) && (cboxbInward.Checked == true) && (cboxOutward.Checked == true) && (radItemWise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        if (strString == "")
                        {
                            strString = struserString;
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoItemWiseOpnInwOutw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "I";
                        if (strType == "L")
                        {
                            frmviewer.strSelction = "L";
                            frmviewer.strString3 = "S";
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }

                    if ((cboxOpening.Checked == true) && (cboxOutward.Checked == true) && (cboxClosing.Checked == true) && (radItemWise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        if (strString == "")
                        {
                            strString = struserString;
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoItemWiseOpnOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "I";
                        if (strType == "L")
                        {
                            frmviewer.strSelction = "L";
                            frmviewer.strString3 = "S";
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }

                    if ((cboxbInward.Checked == true) && (cboxClosing.Checked == true) && (radItemWise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        if (strString == "")
                        {
                            strString = struserString;
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoItemWiseInwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "I";
                        if (strType == "L")
                        {
                            frmviewer.strSelction = "L";
                            frmviewer.strString3 = "S";
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }

                    if ((cboxbInward.Checked == true) && (cboxOutward.Checked == true) && (radItemWise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        if (strString == "")
                        {
                            strString = struserString;
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoItemWiseInwOutw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "I";
                        if (strType == "L")
                        {
                            frmviewer.strSelction = "L";
                            frmviewer.strString3 = "S";
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }

                    if ((cboxOpening.Checked == true) && (cboxOutward.Checked == true) && (radItemWise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        if (strString == "")
                        {
                            strString = struserString;
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoItemWiseOpnOutw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "I";
                        if (strType == "L")
                        {
                            frmviewer.strSelction = "L";
                            frmviewer.strString3 = "S";
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }
                    if ((cboxClosing.Checked == true) && (cboxOutward.Checked == true) && (radItemWise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        if (strString == "")
                        {
                            strString = struserString;
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoItemWiseOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "I";
                        if (strType == "L")
                        {
                            frmviewer.strSelction = "L";
                            frmviewer.strString3 = "S";
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }
                    if ((cboxOpening.Checked == true) && (cboxClosing.Checked == true) && (radItemWise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        if (strString == "")
                        {
                            strString = struserString;
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoItemWiseOpnCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "I";
                        if (strType == "L")
                        {
                            frmviewer.strSelction = "L";
                            frmviewer.strString3 = "S";
                            frmviewer.intype = 2; ;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }

                    if ((cboxOpening.Checked == true) && (cboxbInward.Checked == true) && (radItemWise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        if (strString == "")
                        {
                            strString = struserString;
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoItemWiseOpnInw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "I";
                        if (strType == "L")
                        {
                            frmviewer.strSelction = "L";
                            frmviewer.strString3 = "S";
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }

                    if ((cboxOutward.Checked == true) && (cboxClosing.Checked == true) && (radItemWise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        if (strString == "")
                        {
                            strString = struserString;
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoItemWiseOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "I";
                        if (strType == "L")
                        {
                            frmviewer.strSelction = "L";
                            frmviewer.strString3 = "S";
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }

                    if ((cboxClosing.Checked == true) && (radItemWise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        if (strString == "")
                        {
                            strString = struserString;
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoItemWiseCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "I";
                        if (strType == "L")
                        {
                            frmviewer.strSelction = "L";
                            frmviewer.strString3 = "S";
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }


                    if ((cboxbInward.Checked == true) && (radItemWise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        if (strString == "")
                        {
                            strString = struserString;
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoItemWiseInw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "I";
                        if (strType == "L")
                        {
                            frmviewer.strSelction = "L";
                            frmviewer.strString3 = "S";
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }

                    if ((cboxOpening.Checked == true) && (radItemWise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        if (strString == "")
                        {
                            strString = struserString;
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoItemWiseOpn;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "I";
                        if (strType == "L")
                        {
                            frmviewer.strSelction = "L";
                            frmviewer.strString3 = "S";
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }


                    if ((cboxOutward.Checked == true) && (radItemWise.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        if (strString == "")
                        {
                            strString = struserString;
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoItemWiseOutw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "I";
                        if (strType == "L")
                        {
                            frmviewer.strSelction = "L";
                            frmviewer.strString3 = "S";
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }

                    if ((radItemWise.Checked == true) && (radValueSupp.Checked == true))
                    {
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        if (strString == "")
                        {
                            strString = struserString;
                        }
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoItemWiseOpnInwOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "I";
                        if (strType == "L")
                        {
                            frmviewer.strSelction = "L";
                            frmviewer.strString3 = "S";
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intype = 1;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;


                    }


                }

                #endregion
                #region StoctInformaitonLocationewise



                if (radLocationwise.Checked == true)
                {


                    if ((cboxOpening.Checked == true) && (cboxbInward.Checked == true) && (cboxOutward.Checked == true) && (cboxClosing.Checked == true) && (radLocationwise.Checked == true))
                    {
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOpnInwOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }

                    if ((cboxbInward.Checked == true) && (cboxOutward.Checked == true) && (cboxClosing.Checked == true) && (radLocationwise.Checked == true))
                    {
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseInwOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }



                    if ((cboxOpening.Checked == true) && (cboxbInward.Checked == true) && (cboxClosing.Checked == true) && (radLocationwise.Checked == true))
                    {
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOpnInwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;


                    }


                    if ((cboxOpening.Checked == true) && (cboxbInward.Checked == true) && (cboxOutward.Checked == true) && (radLocationwise.Checked == true))
                    {
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOpnInwOutw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }

                    if ((cboxOpening.Checked == true) && (cboxOutward.Checked == true) && (cboxClosing.Checked == true) && (radLocationwise.Checked == true))
                    {
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOpnOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }

                    if ((cboxbInward.Checked == true) && (cboxClosing.Checked == true) && (radLocationwise.Checked == true))
                    {
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseInwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }


                    if ((cboxbInward.Checked == true) && (cboxOutward.Checked == true) && (radLocationwise.Checked == true))
                    {
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseInwOutw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }

                    if ((cboxOpening.Checked == true) && (cboxOutward.Checked == true) && (radLocationwise.Checked == true))
                    {
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOpnOutw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }


                    if ((cboxClosing.Checked == true) && (cboxOutward.Checked == true) && (radLocationwise.Checked == true))
                    {
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;


                    }

                    if ((cboxOpening.Checked == true) && (cboxClosing.Checked == true) && (radLocationwise.Checked == true))
                    {
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOpnCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }



                    if ((cboxOpening.Checked == true) && (cboxbInward.Checked == true) && (radLocationwise.Checked == true))
                    {
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOpnInw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;


                    }


                    if ((cboxOutward.Checked == true) && (cboxClosing.Checked == true) && (radLocationwise.Checked == true))
                    {
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.Show();
                        return;

                    }
                    if ((cboxOutward.Checked == true) && (radLocationwise.Checked == true) && (chkbHorizontal.Checked == true))
                    {
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOutwHorizontal;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.Show();
                        return;

                    }


                    if ((cboxClosing.Checked == true) && (radLocationwise.Checked == true))
                    {
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.Show();
                        return;

                    }


                    if ((cboxbInward.Checked == true) && (radLocationwise.Checked == true))
                    {
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseInw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.Show();
                        return;
                    }

                    if ((cboxOpening.Checked == true) && (radLocationwise.Checked == true))
                    {
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOpn;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.Show();
                        return;

                    }

                    if ((cboxOutward.Checked == true) && (radLocationwise.Checked == true))
                    {
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOutw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.Show();
                        return;

                    }

                    if ((radLocationwise.Checked == true) && (radValueSupp.Checked == true))
                    {
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOpnInwOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        frmviewer.intype = 1;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.Show();
                        return;

                    }


                }

                #endregion
                #region StoctInformaitonLocationGroupewise
                if (radLocationGroup.Checked == true)
                {
                    if ((cboxOpening.Checked == true) && (cboxbInward.Checked == true) && (cboxOutward.Checked == true) && (cboxClosing.Checked == true) && (radLocationGroup.Checked == true))
                    {
                        //Location
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString() + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        //if (strString == "")
                        //{
                        //    strString = struserString;
                        //}
                        //*******Group
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOpnInwOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strStringNew = strString1;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.Show();
                        return;

                    }

                    if ((cboxbInward.Checked == true) && (cboxOutward.Checked == true) && (cboxClosing.Checked == true) && (radLocationGroup.Checked == true))
                    {
                        //Location
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString() + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        //if (strString == "")
                        //{
                        //    strString = struserString;
                        //}
                        //*******Group
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseInwOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strStringNew = strString1;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }



                    if ((cboxOpening.Checked == true) && (cboxbInward.Checked == true) && (cboxClosing.Checked == true) && (radLocationGroup.Checked == true))
                    {
                        //Location
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString() + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        //if (strString == "")
                        //{
                        //    strString = struserString;
                        //}
                        //*******Group
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOpnInwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strStringNew = strString1;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }


                    if ((cboxOpening.Checked == true) && (cboxbInward.Checked == true) && (cboxOutward.Checked == true) && (radLocationGroup.Checked == true))
                    {
                        //Location
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString() + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        //if (strString == "")
                        //{
                        //    strString = struserString;
                        //}
                        //*******Group
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOpnInwOutw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strStringNew = strString1;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }

                    if ((cboxOpening.Checked == true) && (cboxOutward.Checked == true) && (cboxClosing.Checked == true) && (radLocationGroup.Checked == true))
                    {
                        //Location
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString() + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        //if (strString == "")
                        //{
                        //    strString = struserString;
                        //}
                        //*******Group
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOpnOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strStringNew = strString1;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }

                    if ((cboxbInward.Checked == true) && (cboxClosing.Checked == true) && (radLocationGroup.Checked == true))
                    {
                        //Location
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString() + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        //if (strString == "")
                        //{
                        //    strString = struserString;
                        //}
                        //*******Group
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseInwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strStringNew = strString1;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }


                    if ((cboxbInward.Checked == true) && (cboxOutward.Checked == true) && (radLocationGroup.Checked == true))
                    {
                        //Location
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString() + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        //if (strString == "")
                        //{
                        //    strString = struserString;
                        //}
                        //*******Group
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseInwOutw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strStringNew = strString1;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }

                    if ((cboxOpening.Checked == true) && (cboxOutward.Checked == true) && (radLocationGroup.Checked == true))
                    {
                        //Location
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString() + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        //if (strString == "")
                        //{
                        //    strString = struserString;
                        //}
                        //*******Group
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOpnOutw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strStringNew = strString1;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }


                    if ((cboxClosing.Checked == true) && (cboxOutward.Checked == true) && (radLocationGroup.Checked == true))
                    {
                        //Location
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString() + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        //if (strString == "")
                        //{
                        //    strString = struserString;
                        //}
                        //*******Group
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strStringNew = strString1;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.strSelction = "L";
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }

                    if ((cboxOpening.Checked == true) && (cboxClosing.Checked == true) && (radLocationGroup.Checked == true))
                    {
                        //Location
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString() + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        //if (strString == "")
                        //{
                        //    strString = struserString;
                        //}
                        //*******Group
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOpnCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strStringNew = strString1;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }



                    if ((cboxOpening.Checked == true) && (cboxbInward.Checked == true) && (radLocationGroup.Checked == true))
                    {
                        //Location
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString() + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        //if (strString == "")
                        //{
                        //    strString = struserString;
                        //}
                        //*******Group
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOpnInw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strStringNew = strString1;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }


                    if ((cboxOutward.Checked == true) && (cboxClosing.Checked == true) && (radLocationGroup.Checked == true))
                    {
                        //Location
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString() + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        //if (strString == "")
                        //{
                        //    strString = struserString;
                        //}
                        //*******Group
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strStringNew = strString1;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }

                    if ((cboxClosing.Checked == true) && (radLocationGroup.Checked == true))
                    {
                        //Location
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString() + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        //if (strString == "")
                        //{
                        //    strString = struserString;
                        //}
                        //*******Group
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strStringNew = strString1;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }


                    if ((cboxbInward.Checked == true) && (radLocationGroup.Checked == true))
                    {
                        //Location
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString() + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        //if (strString == "")
                        //{
                        //    strString = struserString;
                        //}
                        //*******Group
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseInw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strStringNew = strString1;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }

                    if ((cboxOpening.Checked == true) && (radLocationGroup.Checked == true))
                    {
                        //Location
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString() + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        //if (strString == "")
                        //{
                        //    strString = struserString;
                        //}
                        //*******Group
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOpn;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strStringNew = strString1;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }

                    if ((cboxOutward.Checked == true) && (radLocationGroup.Checked == true))
                    {
                        //Location
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString() + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        //if (strString == "")
                        //{
                        //    strString = struserString;
                        //}
                        //*******Group
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOutw;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strStringNew = strString1;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        if (strType == "L")
                        {
                            frmviewer.intype = 2;
                        }
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;
                    }

                    if ((radLocationGroup.Checked == true) && (radValueSupp.Checked == true))
                    {
                        //Location
                        for (int i = 0; i < lstRight.Items.Count; i++)
                        {
                            strString = strString + "'" + lstRight.Items[i].ToString() + "',";
                        }
                        if (strString != "")
                        {
                            strString = Utility.Mid(strString, 0, strString.Length - 1);
                        }
                        //if (strString == "")
                        //{
                        //    strString = struserString;
                        //}
                        //*******Group
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
                        frmReportViewer frmviewer = new frmReportViewer();
                        frmviewer.selector = ViewerSelector.StockinfoLctWiseOpnInwOutwCls;
                        frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                        frmviewer.strString = strString;
                        frmviewer.strStringNew = strString1;
                        frmviewer.strUserSecurity = struserString;
                        frmviewer.strSelction = "L";
                        frmviewer.strBranchID = strBranchID;
                        frmviewer.strString7 = strLocation;
                        frmviewer.intype = 1;
                        frmviewer.intSuppress = intSuppress;
                        frmviewer.Show();
                        return;

                    }


                }

                #endregion
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
            if (lstLeftNew.SelectedItems.Count > 0)
            {
                lstRightNew.Items.Add(lstLeftNew.SelectedItem.ToString());
                lstLeftNew.Items.Remove(lstLeftNew.SelectedItem.ToString());
                lstLeftNew.SetSelected(0, true);
            }
        }
        private void radLocationGroup_CheckedChanged(object sender, EventArgs e)
        {
            strType = "L";
        }
        private void cboGroupName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkboxWithoutOH.Checked == true)
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
            else
            {
                mLoad();

            }


        }
        #endregion
        #region "Load"
        private void mLaodItem()
        {
            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            List<StockItem> oogrp = invms.gFillStockItemAllWithoutGodown(strComID, Utility.gblnAccessControl, Utility.gstrUserName, "").ToList();
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
            if (chkboxWithoutOH.Checked == true)
            {
                cboGroupName.Visible = true;
                label6.Visible = true;
                oogrp = invms.gLoadStockGroup(strComID, Utility.gblnAccessControl, Utility.gstrUserName, "N", cboGroupName.Text,"").ToList();
            }
            else
            {
                cboGroupName.Visible = false;
                label6.Visible = false;
                oogrp = invms.gLoadStockGroup(strComID, Utility.gblnAccessControl, Utility.gstrUserName, "K", "Finished Goods","").ToList();
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
        private void frmRptStockInformation_N_Load(object sender, EventArgs e)
        {
            mGetConjumptionClosing("", "", "");
            lstLocation.Visible = false;
            mGetConjumptionClosing("", "", "","AA");
            rtpOptionEnable();
            gboxcost.Enabled = true;
            label9.Visible = false;
            label8.Visible = false;
            uctxtLevelName.Visible = false;
            uctxtName.Visible = false;
            progressBar1.Visible = false;
            Selection.Enabled = false;
            grpGroup.Visible = false;
            lstLevelname.Visible = false;
            lstCategoryGroup.Visible = false;

            label6.Visible = true;
            cboGroupName.Visible = true;
            StockGroupLoad();

            frmLabel.Text = "Stock Summary (Cost Rate)";
            mLoadStockGroup();

            dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");

            groupBox7.Enabled = true;
            grpReportOption.Enabled = true;

            lstBranch.ValueMember = "BranchID";
            lstBranch.DisplayMember = "BranchName";
            lstBranch.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
         
            groupBox7.Visible = false;
            lstBranch.Visible = false;
            uctxtBranchName.Text = lstBranch.Text;
            mLoadLocationName();
            btnPrint.Select();
            btnPrint.Focus();
         
        }
        void mGetConjumptionClosing(string strDeComID, string strBranchID, string strFdate, [Optional]string optionalVar)
        {

        }
        private void mLoadLocationName()
        {
            //lstLocation.ValueMember = "strLocation";
            //lstLocation.DisplayMember = "strLocation";
            //lstLocation.DataSource = invms.mLoadLocation(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
            if (lstBranch.SelectedValue != null)
            {
                lstLocation.ValueMember = "strLocation";
                lstLocation.DisplayMember = "strLocation";
                lstLocation.DataSource = invms.gLoadLocation(strComID, lstBranch.SelectedValue.ToString(), Utility.gblnAccessControl, Utility.gstrUserName, 0).ToList();
            }

            lstBranch.SelectedIndex = lstBranch.FindString(uctxtBranchName.Text);
        }
        private void StockGroupLoad()
        {

            cboGroupName.ValueMember = "strItemGroup";
            cboGroupName.DisplayMember = "strItemGroup";
            cboGroupName.DataSource = invms.mGetStockGroup(strComID, 1).ToList();

        }

        private void rtpOptionEnable()
        {
            if (chkboxWithoutOH.Checked == true)
            {
                mLoadStockGroup();
                gboxcost.Visible = true;
            }
            else
            {
                groupBox7.Visible = true;
                mLoadStockGroup();
                gboxcost.Visible = false;
                grpGroup.Visible = false;
                groupBox7.Enabled = true;
            }
        }
        private void mLoad()
        {
            groupBox7.Enabled = true;
            lstLeft.Items.Clear();
            lstRight.Items.Clear();
 
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
                    lstLeft.Items.Add(ostk.strItemGroup);
                }
            }

        }
        #endregion
        #region "Change"
        private void radCategory_CheckedChanged(object sender, EventArgs e)
        {
            strType = "C";
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion
        #region "Click"
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
        private void rbtnPurchase_MouseClick(object sender, MouseEventArgs e)
        {
            gboxcost.Enabled = false;
       

            groupBox7.Visible = true;
            lblCategory.Visible = true;
            uctxtBranchName.Visible = true;
            lstBranch.Visible = true;
            label9.Visible = false;
            label8.Visible = false;
            uctxtLevelName.Visible = false;
            uctxtName.Visible = false;
            progressBar1.Visible = false;
            grpGroup.Visible = false;
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
            gboxcost.Enabled = false;
       
            grpGroup.Visible = false;
            groupBox7.Visible = false;
      
            //lblCategory.Visible = false;
            uctxtBranchName.Visible = false;
            lstBranch.Visible = false;
            label9.Visible = false;
            label8.Visible = true;
            uctxtLevelName.Visible = true;
            uctxtName.Visible = true;
            progressBar1.Visible = true;
           
            //load
            lstCategoryGroup.Visible = false;
            uctxtName.Visible = false;
            label3.Visible = false;
            lstLevelname.ValueMember = "strSalesPriceLevel";
            lstLevelname.DisplayMember = "strSalesPriceLevel";
            lstLevelname.DataSource = invms.mGetPriceLevel(strComID).ToList();
            lstLevelname.Visible = true;
            label6.Visible = false;
            cboGroupName.Visible = false;
            frmLabel.Text = "Stock Summary Sales Price";

          
            
           
        }
        private void rbtnInvoiceP_MouseClick(object sender, MouseEventArgs e)
        {
            gboxcost.Enabled = false;
       
            grpGroup.Visible = false;

            groupBox7.Visible = true;
            lblCategory.Visible = true;
            uctxtBranchName.Visible = true;
            lstBranch.Visible = true;
            label9.Visible = false;
            label8.Visible = false;
            uctxtLevelName.Visible = false;
            uctxtName.Visible = false;
            progressBar1.Visible = false;
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
        private void rbtnCostP_MouseClick(object sender, MouseEventArgs e)
        {
            gboxcost.Enabled = true;
       
            grpGroup.Visible = false;
        
            groupBox7.Visible = true;
            //lblCategory.Visible = false;
            uctxtBranchName.Visible = false;
            lstBranch.Visible = false;
            label9.Visible = false;
            label8.Visible = false;
            uctxtLevelName.Visible = false;
            uctxtName.Visible = false;
            progressBar1.Visible = false;
            lstLevelname.Visible = false;
            lstCategoryGroup.Visible = false;
            label6.Visible = true;
            cboGroupName.Visible = true;
            StockGroupLoad();
            frmLabel.Text = "Stock Summary Cost Price";
        }

        private void rbtCategory_MouseClick(object sender, MouseEventArgs e)
        {
            uctxtName.Text = "";
            uctxtName.Visible = true;
            label3.Visible = true;
            label9.Visible = true;
            lstLevelname.Visible = false;
            lstCategoryGroup.Visible = true;
            uctxtName.Focus();

            lstCategoryGroup.ValueMember = "strGroupName";
            lstCategoryGroup.DisplayMember = "strGroupName";
            lstCategoryGroup.DataSource = jrpt.mloadCategoryGroup(strComID, 2).ToList();
        }

        private void radGroup_Click(object sender, EventArgs e)
        {

            lstRight.Items.Clear();
            uctxtName.Text = "";
            uctxtName.Visible = true;
            label3.Visible = true;
            label9.Visible = true;
            lstLevelname.Visible = false;
            lstCategoryGroup.Visible = true;
            lstCategoryGroup.ValueMember = "strGroupName";
            lstCategoryGroup.DisplayMember = "strGroupName";
            lstCategoryGroup.DataSource = jrpt.mloadCategoryGroup(strComID, 3).ToList();
            uctxtName.Focus();
        }

        private void rbtnallSP_Click(object sender, EventArgs e)
        {
            lstCategoryGroup.Visible = false;
            label3.Visible = false;
            label9.Visible = false;
            uctxtName.Visible = false;
            lstLevelname.ValueMember = "strSalesPriceLevel";
            lstLevelname.DisplayMember = "strSalesPriceLevel";
            lstLevelname.DataSource = invms.mGetPriceLevel(strComID).ToList();
            //lstLevelname.Top = 270;
            uctxtLevelName.Focus(); 
        }

        private void radSelection_Click(object sender, EventArgs e)
        {
            grpReportOption.Enabled = true;
            radGroupwise.Enabled = true;
            //mLoadStockGroup();
            groupBox7.Enabled = true;
            grpGroup.Enabled = true;
            txtSearch.Focus();
            grpOption.Enabled = true;
            cboxOpening.Checked = true;
            cboxClosing.Checked = true;
            cboxbInward.Checked = true;
            cboxOutward.Checked = true;
            groupBox7.Visible = true;
            if (radValueSupp.Checked == true)
            {
                groupBox7.Enabled = true;
                grpOption.Enabled = false;
                cboxOpening.Checked = false;
                cboxClosing.Checked = false;
                cboxbInward.Checked = false;
                cboxOutward.Checked = false;
                lstRight.Items.Clear();
                lstRightNew.Items.Clear();
            }
            else
            {
                groupBox7.Enabled = true;
                grpOption.Enabled = true;
                cboxOpening.Checked = true;
                cboxClosing.Checked = true;
                cboxbInward.Checked = true;
                cboxOutward.Checked = true;
                lstRight.Items.Clear();
                lstRightNew.Items.Clear();
            }
        }

        private void radAllItem_Click(object sender, EventArgs e)
        {
            if (radValueSupp.Checked == true)
            {
                groupBox7.Enabled = false;
                grpOption.Enabled = false;
                cboxOpening.Checked = false;
                cboxClosing.Checked = false;
                cboxbInward.Checked = false;
                cboxOutward.Checked = false;

                lstRight.Items.Clear();
                lstRightNew.Items.Clear();
            }
            else
            {
                groupBox7.Enabled = false;
                grpOption.Enabled = true;
                cboxOpening.Checked = true;
                cboxClosing.Checked = true;
                cboxbInward.Checked = true;
                cboxOutward.Checked = true;

                lstRight.Items.Clear();
                lstRightNew.Items.Clear();
            }
            groupBox7.Visible = false;
            grpGroup.Visible = false;
        }

        private void radGroupwise_Click(object sender, EventArgs e)
        {
            locationshow();
            Selection.Enabled = false;
            chkbHorizontal.Checked = false;
            strType = "C";
            grpGroup.Visible = false;
            cboGroupName.Visible = true;
            lblName.Text = "Stock Group";
            mLoadStockGroup();
        }
        private void locationshow()
        {
            if (radLocationwise.Checked)
            {
                label10.Visible = false;
                txtLocationName.Text = "";
                txtLocationName.Visible = false;
            }
            else if (radLocationGroup.Checked)
            {
                label10.Visible = false;
                txtLocationName.Text = "";
                txtLocationName.Visible = false;
            }
            else
            {
                label10.Visible = true;
                txtLocationName.Text = "";
                txtLocationName.Visible = true;
            }
        }
        private void radLocationwise_Click(object sender, EventArgs e)
        {
            locationshow();
            strType = "C";
            label6.Visible = false;
            cboGroupName.Visible = false;
            Selection.Enabled = true;
            grpGroup.Visible = false;
            mLoadLocation();
            lblName.Text = "Location";
            Selection.Visible = false;
        }

        private void radItemWise_Click(object sender, EventArgs e)
        {
            locationshow();
            strType = "C";
            chkbHorizontal.Checked = false;
            Selection.Enabled = false;
            label6.Visible = false;
            cboGroupName.Visible = false;
            grpGroup.Visible = false;
            lblName.Text = "Stock Item";
            mLaodItem();
        }

        private void rbtCategory_Click(object sender, EventArgs e)
        {
            locationshow();
            Selection.Enabled = false;
            chkbHorizontal.Checked = false;
            strType = "C";
            grpGroup.Visible = false;
            mLoadStockCategory();
        }

        private void radLocationGroup_Click(object sender, EventArgs e)
        {
            locationshow();
            Selection.Enabled = false;
            chkbHorizontal.Checked = false;
            label6.Visible = true;
            cboGroupName.Visible = true;
            cboGroupName.Visible = true;
            cboGroupName.ValueMember = "strItemGroup";
            cboGroupName.DisplayMember = "strItemGroup";
            cboGroupName.DataSource = invms.mGetStockGroup(strComID,1).ToList();
            strType = "L";
            if (radAllItem.Checked == true)
            {
                lstRightNew.Items.Clear();
                grpGroup.Visible = false;
            }
            else
            {
                grpGroup.Visible = true;
            }
            lblName.Text = "Location";
            lblName1.Text = "Stock Group";
            mLoadStockGroupNew();
            mLoadLocation();
        }

        private void radSuppressZero_Click(object sender, EventArgs e)
        {
            grpOption.Enabled = true;
            cboxOpening.Checked = true;
            cboxClosing.Checked = true;
            cboxbInward.Checked = true;
            cboxOutward.Checked = true;
        }

        private void radNoSuppress_Click(object sender, EventArgs e)
        {
            grpOption.Enabled = true;
            cboxOpening.Checked = true;
            cboxClosing.Checked = true;
            cboxbInward.Checked = true;
            cboxOutward.Checked = true;
        }

        private void radValueSupp_Click(object sender, EventArgs e)
        {
            grpOption.Enabled = false;
            cboxOpening.Checked = false;
            cboxClosing.Checked = false;
            cboxbInward.Checked = false;
            cboxOutward.Checked = false;
        }

        private void radCategory_Click(object sender, EventArgs e)
        {
            locationshow();
            Selection.Enabled = false;
            chkbHorizontal.Checked = false;
            strType = "C";
            grpGroup.Visible = false;
            lblName.Text = "Pack Size";
            mLoadStockCategory();
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
        private void chkboxWithoutOH_Click(object sender, EventArgs e)
        {
            rtpOptionEnable();
        }
        #endregion

        

    


    }
}
