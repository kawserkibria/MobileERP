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
    public partial class frmRptGroupCommission : JA.Shared.UI.frmSmartFormStandard
    {
       
        //JACCMS.SWJAGClient accms = new SWJAGClient();
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        private string strComID { get; set; }
        public string strName { get; set; }
        private ListBox lstBranch = new ListBox();
        public frmRptGroupCommission()
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
            Utility.CreateListBox(lstBranch, pnlMain, uctxtBranchName);
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
       

        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string strbranchID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);

            if (chkGroup.Checked == true)
            {
                string strString = "";
                for (int i = 0; i < lstRight.Items.Count; i++)
                {
                    strString = strString + "'" + lstRight.Items[i].ToString() + "',";
                }
                if (strString != "")
                {
                    strString = Utility.Mid(strString, 0, strString.Length - 1);
                }

                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.GroupCommissionWithSalesValue;
                frmviewer.strFdate = dteFromDate.Text;
                frmviewer.strTdate = dteToDate.Text;
                frmviewer.strString = strString;
                frmviewer.strSelction = "";
                frmviewer.strBranchID = strbranchID;
                frmviewer.Show();
            }
            else
            {
                string strString = "";
                for (int i = 0; i < lstRight.Items.Count; i++)
                {
                    strString = strString + "'" + lstRight.Items[i].ToString() + "',";
                }
                if (strString != "")
                {
                    strString = Utility.Mid(strString, 0, strString.Length - 1);
                }

                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.GroupCommission;
                frmviewer.strFdate = dteFromDate.Text;
                frmviewer.strTdate = dteToDate.Text;
                frmviewer.strString = strString;
                frmviewer.strSelction = "";
                frmviewer.strBranchID = strbranchID;
                frmviewer.Show();
            }

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

        private void radAll_Click(object sender, EventArgs e)
        {
            grpSelction.Enabled = false;
            lstLeft.Items.Clear();
            lstRight.Items.Clear();
        }

        private void radIndividual_Click(object sender, EventArgs e)
        {
            grpSelction.Enabled = true ;
            mLoad();
        }
        private void mLoad()
        {
            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            List<StockGroup> oogrp = invms.mFillStockGroupconfig(strComID).ToList();
            if (oogrp.Count > 0)
            {
                foreach (StockGroup ogrp in oogrp)
                {
                    lstLeft.Items.Add(ogrp.GroupName);
                }
            }
        }
        private void frmRptGroupCommission_Load(object sender, EventArgs e)
        {
            //dteFromDate.Text = Utility.gdteFinancialYearFrom;
            //dteToDate.Text = Utility.gdteFinancialYearTo;
            dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");
            lstBranch.ValueMember = "BranchID";
            lstBranch.DisplayMember = "BranchName";
            lstBranch.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
           

        }

      
    }
}
