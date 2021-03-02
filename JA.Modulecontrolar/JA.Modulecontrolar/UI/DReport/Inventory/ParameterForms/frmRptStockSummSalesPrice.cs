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
//using JA.Modulecontrolar.JACCMS;

namespace JA.Modulecontrolar.UI.DReport.Inventory.ParameterForms
{
    public partial class frmRptStockSummSalesPrice : JA.Shared.UI.frmSmartFormStandard
    {

        //JACCMS.SWJAGClient accms = new SWJAGClient();
        private ListBox lstBranch = new ListBox();
        public string strReportName { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();

        private ListBox lstLevelName = new ListBox();
        private ListBox lstCategory = new ListBox();
        private string strComID { get; set; }
        public frmRptStockSummSalesPrice()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.txtLevelName.KeyDown += new KeyEventHandler(txtLevelName_KeyDown);
            this.txtLevelName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtLevelName_KeyPress);
            this.txtLevelName.TextChanged += new System.EventHandler(this.txtLevelName_TextChanged);
            this.lstLevelName.DoubleClick += new System.EventHandler(this.lstLevelName_DoubleClick);
            this.txtLevelName.GotFocus += new System.EventHandler(this.txtLevelName_GotFocus);



            this.uctxtCategory.KeyDown += new KeyEventHandler(uctxtCategory_KeyDown);
            this.uctxtCategory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtCategory_KeyPress);
            this.uctxtCategory.TextChanged += new System.EventHandler(this.uctxtCategory_TextChanged);
            this.lstCategory.DoubleClick += new System.EventHandler(this.lstCategory_DoubleClick);
            this.uctxtCategory.GotFocus += new System.EventHandler(this.uctxtCategory_GotFocus);


            Utility.CreateListBox(lstLevelName, pnlMain, txtLevelName);
            Utility.CreateListBox(lstCategory, pnlMain, uctxtCategory);

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
        private void uctxtCategory_TextChanged(object sender, EventArgs e)
        {
            lstCategory.SelectedIndex = lstCategory.FindString(uctxtCategory.Text);
        }

        private void lstCategory_DoubleClick(object sender, EventArgs e)
        {
            uctxtCategory.Text = lstCategory.Text;
            txtLevelName.Focus();


        }

        private void uctxtCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                if (lstCategory.Items.Count > 0)
                {
                    uctxtCategory.Text = lstCategory.Text;
                }
                txtLevelName.Focus();


            }
        }
        private void uctxtCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstCategory.SelectedItem != null)
                {
                    lstCategory.SelectedIndex = lstCategory.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstCategory.Items.Count - 1 > lstCategory.SelectedIndex)
                {
                    lstCategory.SelectedIndex = lstCategory.SelectedIndex + 1;
                }
            }

        }

        private void uctxtCategory_GotFocus(object sender, System.EventArgs e)
        {
            lstCategory.Visible = true;
            lstLevelName.Visible = false;
            lstCategory.SelectedIndex = lstCategory.FindString(uctxtCategory.Text);

        }



        private void txtLevelName_TextChanged(object sender, EventArgs e)
        {
            lstLevelName.SelectedIndex = lstLevelName.FindString(txtLevelName.Text);
        }

        private void lstLevelName_DoubleClick(object sender, EventArgs e)
        {
            txtLevelName.Text = lstLevelName.Text;
            lstLevelName.Visible = false;
            btnPrint.Focus();
        }
        private void txtLevelName_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstLevelName.Items.Count > 0)
                {
                    txtLevelName.Text = lstLevelName.Text;
                    lstLevelName.Visible = false;
                }
                btnPrint.Focus();
            }
        }
        private void txtLevelName_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Up)
            {
                if (lstLevelName.SelectedItem != null)
                {
                    lstLevelName.SelectedIndex = lstLevelName.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstLevelName.Items.Count - 1 > lstLevelName.SelectedIndex)
                {
                    lstLevelName.SelectedIndex = lstLevelName.SelectedIndex + 1;
                }
            }
        }


        private void txtLevelName_GotFocus(object sender, System.EventArgs e)
        {
            lstCategory.Visible = false;
            lstLevelName.Visible = true;
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
            lstCategory.Visible = false;
            lstLevelName.Visible = false;
            lstLevelName.ValueMember = "strSalesPriceLevel";
            lstLevelName.DisplayMember = "strSalesPriceLevel";
            lstLevelName.DataSource = invms.mGetPriceLevel(strComID).ToList();

        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            int intCat = 0;
            string strBranchId = "";

            if (txtLevelName.Text == "")
            {
                MessageBox.Show("Please Select Item Name.");
                return;
            }

            if (radCategoryWise.Checked == true)
            {
                intCat = 1;
            }
            else if (radLevelWise.Checked == true)
            {
                intCat = 2;
            }
            else
            {
                intCat = 3;
            }
            //level=1,cat=2,Group=3

            frmReportViewer frmviewer = new frmReportViewer();
            frmviewer.selector = ViewerSelector.StockLevel;
            frmviewer.strString = txtLevelName.Text;
            if (intCat == 1)
            {
                frmviewer.strSelction = uctxtCategory.Text;
            }
            else if (intCat == 3)
            {
                frmviewer.strSelction = uctxtCategory.Text;
            }
            else
            {
                frmviewer.strSelction = "";
            }
            frmviewer.intype = intCat;
            frmviewer.Show();
            
        }

        private void radCategoryWise_Click(object sender, EventArgs e)
        {
            uctxtCategory.Visible = true;
            lblCategory.Visible = true;
            txtLevelName.Text = "";
            mLoad();
            uctxtCategory.Text = "";
            uctxtCategory.Focus();
        }
        private void radStockGroupWise_Click(object sender, EventArgs e)
        {
            uctxtCategory.Text = "";
            uctxtCategory.Visible = true;
            lblCategory.Visible = true;
            mLoad();
            uctxtCategory.Focus();
            txtLevelName.Text = "";
           
        }
        private void mLoad()
        {
            lstCategory.Items.Clear();
            if (radCategoryWise.Checked==true)
            {
                List<StockCategory> oogrp = invms.mFillStockCategory(strComID).ToList();
                if (oogrp.Count > 0)
                {
                    foreach (StockCategory ostk in oogrp)
                    {
                        lstCategory.Items.Add(ostk.CategoryName);
                    }
                }
            }
            else
            {
                List<StockItem> oogrp = invms.gLoadStockGroup(strComID, Utility.gblnAccessControl, Utility.gstrUserName,"N").ToList();
                if (oogrp.Count > 0)
                {
                    foreach (StockItem ostk in oogrp)
                    {
                        lstCategory.Items.Add(ostk.strItemGroup);
                    }
                }
            }
        }
        private void radLevelWise_Click(object sender, EventArgs e)
        {
            txtLevelName.Text = "";
            uctxtCategory.Text = "";
            uctxtCategory.Visible = false;
            lblCategory.Visible = false;
            txtLevelName.Focus();
        }
        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }




    }
}
