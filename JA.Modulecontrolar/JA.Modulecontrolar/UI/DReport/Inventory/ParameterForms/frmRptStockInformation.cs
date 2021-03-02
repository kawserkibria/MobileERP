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
    public partial class frmRptStockInformation : JA.Shared.UI.frmJagoronFromSearch
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public string strType { get; set; }
        private string strComID { get; set; }
        public frmRptStockInformation()
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
            List<StockItem> oogrp = invms.gFillStockItemAllWithoutGodown(strComID,Utility.gblnAccessControl,Utility.gstrUserName ,"").ToList();
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
            List<StockItem> oogrp = invms.gLoadStockGroup(strComID, Utility.gblnAccessControl, Utility.gstrUserName, "N",cboGroupName.Text,"").ToList();
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
            List<StockItem> oogrp = invms.gLoadStockGroup(strComID,Utility.gblnAccessControl, Utility.gstrUserName,"N",cboGroupName.Text,"").ToList();
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
            Selection.Enabled = false;
            if (strType == "C")
            {
                label6.Visible = true;
                cboGroupName.Visible = true;
                cboGroupName.ValueMember = "strItemGroup";
                cboGroupName.DisplayMember = "strItemGroup";
                cboGroupName.DataSource = invms.mGetStockGroup(strComID,0).ToList();
                frmLabel.Text = "Stock Summarry Cost Price";
                mLoadStockGroup();
            }
            else if (strType == "L")
            {
                label6.Visible = false;
                cboGroupName.Visible = false;

                frmLabel.Text = "Location Summary";
                radGroupwise.Visible = false;
                radCategory.Visible = false;
                //radItemWise.Visible = false;
                grpSuppressSelection.Visible = true; 
                radItemWise.Text = "ItemWise Location";
                radLocationwise.Checked = true;
                mLoadLocation();
            }
            else
            {
                label6.Visible = false;
                cboGroupName.Visible = false;
                frmLabel.Text = "Location Summary";
                mLoadLocation();
            }

            //dteFromDate.Text = Utility.gdteFinancialYearFrom;
            //dteToDate.Text = Utility.gdteFinancialYearTo;
            dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");
            //groupBox7.Enabled = false;
            grpReportOption.Enabled = true;
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
            if (radValueSupp .Checked == true )
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
            

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            lstLeft.SelectedIndex = lstLeft.FindString(txtSearch.Text);
        }

        private void radItemWise_Click(object sender, EventArgs e)
        {
            strType = "C";
            chkbHorizontal.Checked = false;
            Selection.Enabled = false;
            label6.Visible = false;
            cboGroupName.Visible = false;
            grpGroup.Visible = false;
            mLaodItem();
        }

        private void radCategory_Click(object sender, EventArgs e)
        {
            Selection.Enabled = false;
            chkbHorizontal.Checked = false;
            strType = "C";
            grpGroup.Visible = false;
            mLoadStockCategory();
        }

        private void radLocationwise_Click(object sender, EventArgs e)
        {
            strType = "C";
            label6.Visible = false ;
            cboGroupName.Visible = false;
            Selection.Enabled = true;
            grpGroup.Visible = false;
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string strString = "",struserString="",strString1="";
            int intSuppress;
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
            else
            {
                intSuppress = 0;
            }
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
                    frmviewer.strSelction = "G";
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
                    frmviewer.intype = 1;
                    frmviewer.intSuppress = intSuppress;
                    frmviewer.Show();
                    return;
                }
                if ( (radGroupwise.Checked == true) && (radSelection.Checked == true) && (radValueSupp.Checked == true))
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
                    if (strString =="")
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
                    if (strString =="")
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
                    if (strString =="")
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
                    frmviewer.intype = 1;
                    frmviewer.intSuppress = intSuppress;
                    frmviewer.Show();
                    return;

                }


            }

            #endregion



        }

        private void radGroupwise_Click(object sender, EventArgs e)
        {
            Selection.Enabled = false;
            chkbHorizontal.Checked = false;
            strType = "C";
            grpGroup.Visible = false;
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
            grpOption.Enabled = false;
            cboxOpening.Checked = false;
            cboxClosing.Checked = false;
            cboxbInward.Checked = false;
            cboxOutward.Checked = false;
        }

        private void radNoSuppress_Click(object sender, EventArgs e)
        {
            grpOption.Enabled = true;
            cboxOpening.Checked = true;
            cboxClosing.Checked = true;
            cboxbInward.Checked = true;
            cboxOutward.Checked = true;
        }

        private void radSuppressZero_Click(object sender, EventArgs e)
        {
            grpOption.Enabled = true;
            cboxOpening.Checked = true;
            cboxClosing.Checked = true;
            cboxbInward.Checked = true;
            cboxOutward.Checked = true;
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
            Selection.Enabled = false;
            chkbHorizontal.Checked = false;
            label6.Visible = true;
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

       



    }
}
