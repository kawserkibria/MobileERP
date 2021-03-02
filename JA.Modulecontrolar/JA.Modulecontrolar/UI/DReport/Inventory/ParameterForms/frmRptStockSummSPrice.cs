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
    public partial class frmRptStockSummSPrice : JA.Shared.UI.frmSmartFormStandard
    {
        private ListBox lstLevelname = new ListBox();
        private ListBox lstCategoryGroup = new ListBox();
        //private ListBox lstGroup = new ListBox();
        //JACCMS.SWJAGClient accms = new SWJAGClient();
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JRPT.ISWRPT jrpt = new JRPT.SWRPTClient();
        private string strComID { get; set; }
        public frmRptStockSummSPrice()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.uctxtLevelName.KeyDown += new KeyEventHandler(uctxtLevelName_KeyDown);
            this.uctxtLevelName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtLevelName_KeyPress);
            this.uctxtLevelName.TextChanged += new System.EventHandler(this.uctxtLevelName_TextChanged);
            this.lstLevelname.DoubleClick += new System.EventHandler(this.lstLevelname_DoubleClick);
            this.uctxtLevelName.GotFocus += new System.EventHandler(this.uctxtLevelName_GotFocus);


            this.uctxtName.KeyDown += new KeyEventHandler(uctxtName_KeyDown);
            this.uctxtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtName_KeyPress);
            this.uctxtName.TextChanged += new System.EventHandler(this.uctxtName_TextChanged);
            this.lstCategoryGroup.DoubleClick += new System.EventHandler(this.lstCategoryGroup_DoubleClick);
            this.uctxtName.GotFocus += new System.EventHandler(this.uctxtName_GotFocus);
            Utility.CreateListBox(lstLevelname, pnlMain, uctxtName);
            Utility.CreateListBox(lstCategoryGroup, pnlMain, uctxtName);
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



        private void uctxtName_TextChanged(object sender, EventArgs e)
        {
            lstCategoryGroup.SelectedIndex = lstCategoryGroup.FindString(uctxtName.Text);
        }

        private void lstCategoryGroup_DoubleClick(object sender, EventArgs e)
        {
            uctxtName.Text = lstCategoryGroup.Text;
            uctxtLevelName.Focus();
            lstCategoryGroup.Visible = false;
            
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
        private void mLoadLocation()
        {
            lstLevelname.ValueMember = "strLocation";
            lstLevelname.DisplayMember = "strLocation";
            lstLevelname.DataSource = invms.mLoadLocation(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
        }
        private void uctxtName_GotFocus(object sender, System.EventArgs e)
        {
            lstCategoryGroup.Visible = true;
            lstLevelname.Visible = false; 
            lstCategoryGroup.SelectedIndex = lstCategoryGroup.FindString(uctxtName.Text);
           
        }
        private void uctxtLevelName_TextChanged(object sender, EventArgs e)
        {
            lstLevelname.SelectedIndex = lstLevelname.FindString(uctxtLevelName.Text);
        }

        private void lstLevelname_DoubleClick(object sender, EventArgs e)
        {
            uctxtLevelName.Text = lstLevelname.Text;
            lstLevelname.Visible = false;
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
            lstLevelname.Visible = true;

            lstLevelname.SelectedIndex = lstLevelname.FindString(uctxtLevelName.Text);
            
        }

        #endregion
        private void mLaodItem()
        {
            //lstItem.ValueMember = "strItemGroup";
            //lstItem.DisplayMember = "strItemGroup";
            //lstItem.DataSource = invms.gLoadStockGroup(strComID, Utility.gblnAccessControl, Utility.gstrUserName,"N").ToList();
         
        }


        private void frmRptStoreLedger_Load(object sender, EventArgs e)
        {
        //    lstLevelname.Visible = false;
            lstCategoryGroup.Visible = false;
            uctxtName.Visible = false;
            label3.Visible = false;
            //mLoadLocation();
            //mLaodItem();

            lstLevelname.ValueMember = "strSalesPriceLevel";
            lstLevelname.DisplayMember = "strSalesPriceLevel";
            lstLevelname.DataSource = invms.mGetPriceLevel(strComID).ToList();
            lstLevelname.Top = 270;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string strGroupName = "", strCategory = "";
            if (uctxtLevelName.Text == "")
            {
                MessageBox.Show("Level Name Cannot be Empty");
                uctxtLevelName.Focus();
                return;
            }
            if (radGroup.Checked == true)
            {
                strGroupName = uctxtName.Text;
            }
            else if (rbtCategory.Checked == true)
            {
                strCategory = uctxtName.Text;
            }
            List<RStockInformation> objcon = jrpt.mGetSalesPriceItem(strComID, strGroupName, strCategory).ToList();
            if (objcon.Count > 0)
            {

                progressBar1.Value = 0;
                progressBar1.Maximum = objcon.Count;
                foreach (RStockInformation objstock in objcon)
                {
                    string i = jrpt.mInsertTempSaleaPrcice(strComID, objstock.strItemName, uctxtLevelName.Text);
                    lblCount.Text = progressBar1.Value + "/" + objcon.Count;
                    progressBar1.Value += 1;
                }
            }

            if ((radAll.Checked == true))
            {

                if (uctxtLevelName.Text == "")
                {
                    strGroupName = "";
                }
                else
                {
                    strGroupName = uctxtLevelName.Text;
                }

                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.StockSummSPrice;
                frmviewer.strString = "";
                frmviewer.intype = 1;
                frmviewer.Show();
            }

            if ((rbtCategory.Checked == true))
            {

                if (uctxtName.Text == "")
                {
                    strGroupName = "";
                }
                else
                {
                    strGroupName = uctxtName.Text;
                }

                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.StockSummSPrice;
                frmviewer.strString = strGroupName;
                frmviewer.intype = 2;
                frmviewer.Show();
            }
            if ((radGroup.Checked == true))
            {

                if (uctxtName.Text == "")
                {
                    strGroupName = "";
                }
                else
                {
                    strGroupName = uctxtName.Text;
                }



                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.StockSummSPrice;
                frmviewer.strString = strGroupName;
                frmviewer.intype = 3;
                frmviewer.Show();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void rbtCategory_Click(object sender, EventArgs e)
        {
            uctxtName.Text = "";
            uctxtName.Visible = true;
            label3.Visible = true;
            lstLevelname.Visible = false;
            lstCategoryGroup.Visible = true;
            uctxtName.Focus();

            lstCategoryGroup.ValueMember = "strGroupName";
            lstCategoryGroup.DisplayMember = "strGroupName";
            lstCategoryGroup.DataSource = jrpt.mloadCategoryGroup(strComID, 2).ToList();
        }

        private void radGroup_Click(object sender, EventArgs e)
        {
            uctxtName.Text = "";
            uctxtName.Visible = true;
            label3.Visible = true;
            lstLevelname.Visible = false;
            lstCategoryGroup.Visible = true;
            uctxtName.Focus();
            lstCategoryGroup.ValueMember = "strGroupName";
            lstCategoryGroup.DisplayMember = "strGroupName";
            lstCategoryGroup.DataSource = jrpt.mloadCategoryGroup(strComID, 3).ToList();
        }

        private void radAll_Click(object sender, EventArgs e)
        {
            lstCategoryGroup.Visible = false;
            label3.Visible = false;
            uctxtName.Visible = false;
            lstLevelname.ValueMember = "strSalesPriceLevel";
            lstLevelname.DisplayMember = "strSalesPriceLevel";
            lstLevelname.DataSource = invms.mGetPriceLevel(strComID).ToList();
            lstLevelname.Top = 270;
            uctxtLevelName.Focus(); 
        }
    }
}
