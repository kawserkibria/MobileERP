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
using JA.Modulecontrolar.UI.DReport.Sales.Viewer;
using Microsoft.Win32;
namespace JA.Modulecontrolar.UI.DReport.Sales.ParameterForms
{
    public partial class frmRptSalesPriceList : JA.Shared.UI.frmSmartFormStandard 
    {
  
        JACCMS.SWJAGClient accms = new SWJAGClient();
        private ListBox lstBranch = new ListBox();
        public string strReportName { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();

         //JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        private ListBox lstLevelName = new ListBox();
        private ListBox lstGroupConfig = new ListBox();
        private ListBox lstGroup = new ListBox();
        private string strComID { get; set; }
        public frmRptSalesPriceList()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.dteFromDate1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteFromDate1_KeyPress);
            //this.dteFromDate.GotFocus += new System.EventHandler(this.dteFromDate_GotFocus);

            this.dtpToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dtpToDate_KeyPress);

            this.txtLevelName.KeyDown += new KeyEventHandler(txtLevelName_KeyDown);
            this.txtLevelName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtLevelName_KeyPress);
            this.txtLevelName.TextChanged += new System.EventHandler(this.txtLevelName_TextChanged);
            this.lstLevelName.DoubleClick += new System.EventHandler(this.lstLevelName_DoubleClick);
            this.lstGroup.DoubleClick += new System.EventHandler(this.lstGroup_DoubleClick);
            this.lstGroupConfig.DoubleClick += new System.EventHandler(this.lstGroupConfig_DoubleClick);
            this.txtLevelName.GotFocus += new System.EventHandler(this.txtLevelName_GotFocus);

            //this.txtLevelName.KeyDown += new KeyEventHandler(txtLevelName_KeyDown);
            //this.txtLevelName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtLevelName_KeyPress);
            //this.txtLevelName.TextChanged += new System.EventHandler(this.txtLevelName_TextChanged);
            //this.lstLevelName.DoubleClick += new System.EventHandler(this.lstLevelName_DoubleClick);
            //this.txtLevelName.GotFocus += new System.EventHandler(this.txtLevelName_GotFocus);

            
            Utility.CreateListBox(lstLevelName, pnlMain, txtLevelName);
            Utility.CreateListBox(lstGroupConfig, pnlMain, txtLevelName);
            Utility.CreateListBox(lstGroup, pnlMain, txtLevelName);
        }

        #region "User Deifne"
      

        private void txtLevelName_TextChanged(object sender, EventArgs e)
        {



            if (radLevelWise.Checked == true)
            {
                lstLevelName.SelectedIndex = lstLevelName.FindString(txtLevelName.Text);
            }

            if (radItemWise.Checked == true)
            {
                lstGroup.SelectedIndex = lstGroup.FindString(txtLevelName.Text);
            }

          if (radStockGroupWise.Checked == true)
          {
              lstGroupConfig.SelectedIndex = lstGroupConfig.FindString(txtLevelName.Text);
          }
        }

        private void lstLevelName_DoubleClick(object sender, EventArgs e)
        {

          

                txtLevelName.Text = lstLevelName.Text;
                dteFromDate1.Focus();
                lstLevelName.Visible = false;
            
        }
        private void lstGroup_DoubleClick(object sender, EventArgs e)
        {
           
                txtLevelName.Text = lstGroup.Text;
                dteFromDate1.Focus();
                lstGroup.Visible = false;
            

        }

        private void lstGroupConfig_DoubleClick(object sender, EventArgs e)
         {
          
                 txtLevelName.Text = lstGroupConfig.Text;
                 dteFromDate1.Focus();
                 lstGroupConfig.Visible = false;
             
         }
           
       
        

        private void txtLevelName_KeyPress(object sender, KeyPressEventArgs e)
        {

         

            if (radLevelWise.Checked == true)
            {



                if (e.KeyChar == (char)Keys.Return)
                {
                    if (lstLevelName.Items.Count > 0)
                    {
                        txtLevelName.Text = lstLevelName.Text;
                        lstLevelName.Visible = false;
                    }
                    dteFromDate1.Focus();

                }
            }

            if (radItemWise.Checked == true)
            {



                if (e.KeyChar == (char)Keys.Return)
                {
                    if (lstGroup.Items.Count > 0)
                    {
                        txtLevelName.Text = lstGroup.Text;
                        lstGroup.Visible = false;
                    }
                    dteFromDate1.Focus();

                }
            }

            if (radStockGroupWise.Checked == true)
            {



                if (e.KeyChar == (char)Keys.Return)
                {
                    if (lstGroupConfig.Items.Count > 0)
                    {
                        txtLevelName.Text = lstGroupConfig.Text;
                        lstGroupConfig.Visible = false;
                    }
                    dteFromDate1.Focus();

                }
            }

      
        }
        private void txtLevelName_KeyDown(object sender, KeyEventArgs e)
        {

            if (radLevelWise.Checked == true)
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


            if (radItemWise.Checked == true)
            {

                if (e.KeyCode == Keys.Up)
                {
                    if (lstGroup.SelectedItem != null)
                    {
                        lstGroup.SelectedIndex = lstGroup.SelectedIndex - 1;
                    }
                }
                if (e.KeyCode == Keys.Down)
                {
                    if (lstGroup.Items.Count - 1 > lstGroup.SelectedIndex)
                    {
                        lstGroup.SelectedIndex = lstGroup.SelectedIndex + 1;
                    }
                }
            }


            if (radStockGroupWise.Checked == true)
            {

                if (e.KeyCode == Keys.Up)
                {
                    if (lstGroupConfig.SelectedItem != null)
                    {
                        lstGroupConfig.SelectedIndex = lstGroupConfig.SelectedIndex - 1;
                    }
                }
                if (e.KeyCode == Keys.Down)
                {
                    if (lstGroupConfig.Items.Count - 1 > lstGroupConfig.SelectedIndex)
                    {
                        lstGroupConfig.SelectedIndex = lstGroupConfig.SelectedIndex + 1;
                    }
                }
            }

        }

        private void txtLevelName_GotFocus(object sender, System.EventArgs e)
        {
         

            if (radLevelWise.Checked == true)
            {
                lstLevelName.Visible = true;
            }

            if (radItemWise.Checked == true)
            {
                lstGroup.Visible = true;
            }

            if (radStockGroupWise.Checked == true)
            {
                lstGroupConfig.Visible = true;
            }
           
        }


        private void dteFromDate1_GotFocus(object sender, System.EventArgs e)
        {
            
            lstGroupConfig.Visible = false;
           
            lstGroup.Visible = false;
            lstLevelName.Visible = false;

        }

        private void dteFromDate1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (radLevelWise.Checked == true)
                {

                    btnPrint.Focus();
                }
                else
                {
                    dtpToDate.Focus();
                }

            }
        }

        private void dtpToDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {               
                    btnPrint.Focus();          
                
            }
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
            //txtLocationName.Enabled = false;
        }
        private void frmRptStoreLedger_Load(object sender, EventArgs e)
        {
            dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");
            lstGroupConfig.Text = "";
            lstGroupConfig.Visible = false;
            lstGroup.Text = "";
            lstGroup.Visible = false;
            if (radLevelWise.Checked == true)
            {
                label4.Text = "Effective Date :";
            }
            
            label3.Text = "Level Name";

            lstLevelName.ValueMember = "strSalesPriceLevel";
            lstLevelName.DisplayMember = "strSalesPriceLevel";
            lstLevelName.DataSource = invms.mGetPriceLevel(strComID).ToList();
            dtpToDate.Visible = false;
            label6.Visible = false;

            //int year = DateTime.Now.Year;
            //int Month = DateTime.Now.Month;
            //int Day = DateTime.Now.Day;
            //DateTime firstDay = new DateTime(year, Month, 1);
            //dteFromDate1.Text = Utility.gdteFinancialYearFrom;
            //dtpToDate.Text = Utility.gdteFinancialYearTo;           
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            int intItemGroup = 0;
            string strBranchId = "";

            if (txtLevelName.Text == "")
            {
                MessageBox.Show("Please Select Item Name.");
                return;
            }
            else
            {
                strBranchId = Utility.gstrGetBranchID(strComID, txtLevelName.Text);
            }
            if (radLevelWise.Checked == true)
            {
                //level=1,Item=2,Group=3
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.LevelWise;
                frmviewer.strFdate = dteFromDate1.Value.ToString("dd-MM-yyyy");
                frmviewer.strString = txtLevelName.Text;
                frmviewer.intMode = 1;
                frmviewer.reportTitle2 = "A";
                frmviewer.Show();
            }
            if (radItemWise.Checked == true)
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.ItemwiseSales;
                frmviewer.strFdate = dteFromDate1.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dtpToDate.Value.ToString("dd-MM-yyyy");             
                frmviewer.strString = txtLevelName.Text;
                frmviewer.intMode = 2;
                frmviewer.Show();
            }
            if (radStockGroupWise.Checked == true)
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.StockGroupSales;
                frmviewer.strFdate = dteFromDate1.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dtpToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strString = txtLevelName.Text;
                frmviewer.reportTitle2 = "A";
                if (txtLevelName.Text == "Finished Goods")
                {
                    frmviewer.intMode = 3;
                }
                else
                {
                    frmviewer.intMode = 4;
                }
                
                frmviewer.reportTitle2 = "A";
                frmviewer.Show();
            }
        }

        private void radItemWise_Click(object sender, EventArgs e)
        {
            dtpToDate.Visible = true;
            label6.Visible = true;
            txtLevelName.Focus();
            txtLevelName.Text = "";
            label3.Text = "Item Name";
            lstGroupConfig.Text = "";
            lstGroupConfig.Visible = false;
            lstLevelName.Text = "";
            lstLevelName.Visible = false;
            lstGroup.DisplayMember = "strItemName";
            lstGroup.ValueMember = "strItemName";
            lstGroup.DataSource = invms.mloadStockItemNotInGroup(strComID, "PRICE").ToList();
            if (radItemWise.Checked == true)
            {
                label4.Text = "From Date :";
            }
        }
        private void radStockGroupWise_Click(object sender, EventArgs e)
        {
            dtpToDate.Visible =true  ;
            label6.Visible = true;
            txtLevelName.Focus();
            txtLevelName.Text = "";
            label3.Text = "Stock Group";
            lstGroup.Text = "";
            lstGroup.Visible = false;
            lstLevelName.Text = "";
            lstLevelName.Visible = false;
            lstGroupConfig.DisplayMember = "strItemGroup";
            lstGroupConfig.ValueMember = "strItemGroup";
            lstGroupConfig.DataSource = invms.mFillStockTreeGroupLevel2(strComID).ToList();
            if (radStockGroupWise.Checked == true)
            {
                label4.Text = "From Date :";
            }
        }

        private void radLevelWise_Click(object sender, EventArgs e)
        {
            txtLevelName.Focus();
            txtLevelName.Text = "";
            lstGroupConfig.Text = "";
            lstGroupConfig.Visible = false;
            lstGroup.Text = "";
            lstGroup.Visible = false;
            dtpToDate.Visible = false;
            label3.Text = "Level Name";
            label6.Visible = false;
            if (radLevelWise.Checked == true )
            {
                label4.Text = "Effective Date :";
            }
        
            lstLevelName.ValueMember = "strSalesPriceLevel";
            lstLevelName.DisplayMember = "strSalesPriceLevel";
            lstLevelName.DataSource = invms.mGetPriceLevel(strComID).ToList();
        }
        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
