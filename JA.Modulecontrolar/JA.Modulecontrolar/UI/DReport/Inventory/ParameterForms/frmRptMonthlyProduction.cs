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
    public partial class frmRptMonthlyProduction : JA.Shared.UI.frmSmartFormStandard
    {
        JRPT.SWRPTClient orptCnn = new SWRPTClient();
        //JACCMS.SWJAGClient accms = new SWJAGClient();
        private ListBox lstProcess = new ListBox();
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public string strName { get; set; }
        private string strComID { get; set; }
        public frmRptMonthlyProduction()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.cboGroupName.SelectedIndexChanged += new System.EventHandler(this.cboGroupName_SelectedIndexChanged);
       
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


        private void cboGroupName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (strType == "L")
            //{
                mLoadStockGroupNew();
            //}
            //else
            //{
                //mLoadStockGroup();
            //}

        }
        private void uctxtName_GotFocus(object sender, System.EventArgs e)
        {
            
            

        }

       

        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {
          string  strinvrefNoumber="", strItemName="";



          if (rbtnPackingRawStock.Checked == true)
          {
              frmReportViewer frmviewer = new frmReportViewer();
              frmviewer.selector = ViewerSelector.PackingRawMaterialsStock;
              frmviewer.strString = "";
              frmviewer.strSelction = "";
              frmviewer.strFdate = dteFromDate.Text;
              frmviewer.strTdate = dteToDate.Text;
              frmviewer.Show();
          }

            if (rbtnConsumption.Checked == true)
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.Production_Convertion;
                frmviewer.strString = "";
                frmviewer.strSelction = "";
                frmviewer.strFdate = dteFromDate.Text;
                frmviewer.strTdate = dteToDate.Text;
                frmviewer.Show();
            }

            if (rbtnFG.Checked == true)
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.MonthlyProduction;
                frmviewer.strString = "";
                frmviewer.strSelction = "";
                frmviewer.strFdate = dteFromDate.Text;
                frmviewer.strTdate = dteToDate.Text;
                frmviewer.Show();
            }
            if (rbtnClassPower.Checked == true)
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.MonthlyProduction_Class_Power;
                if (radClass.Checked == true)
                {
                    frmviewer.strString = "Class";
                }
                else
                {
                    frmviewer.strString = "Power";
                }
                frmviewer.strSelction = "";
                frmviewer.strFdate = dteFromDate.Text;
                frmviewer.strTdate = dteToDate.Text;
                frmviewer.Show();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void frmRptNegetive_Load(object sender, EventArgs e)
        {

            cboGroupName.Visible = true;
            cboGroupName.Visible = true;
            cboGroupName.ValueMember = "strItemGroup";
            cboGroupName.DisplayMember = "strItemGroup";
            cboGroupName.DataSource = invms.mGetStockGroup(strComID,1).ToList();
        }
        private void mLoadStockGroupNew()
        {
            lstLeft.Items.Clear();
            lstLeft.Items.Clear();
            List<StockItem> oogrp = invms.gLoadStockGroup(strComID, Utility.gblnAccessControl, Utility.gstrUserName, "N", cboGroupName.Text,"").ToList();
            if (oogrp.Count > 0)
            {
                foreach (StockItem ostk in oogrp)
                {
                    lstLeft.Items.Add(ostk.strItemGroup);
                }
            }
        }

        private void mLoadStockGroup()
        {
            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            List<StockItem> oogrp = invms.gLoadStockGroup(strComID, Utility.gblnAccessControl, Utility.gstrUserName, "N", cboGroupName.Text,"").ToList();
            if (oogrp.Count > 0)
            {
                foreach (StockItem ostk in oogrp)
                {
                    lstLeft.Items.Add(ostk.strItemGroup);
                }
            }
        }

    }
}
