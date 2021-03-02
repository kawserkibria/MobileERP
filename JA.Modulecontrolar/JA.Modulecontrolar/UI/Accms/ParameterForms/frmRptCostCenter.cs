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
using JA.Modulecontrolar.UI.DReport.Accms.Viewer;
using JA.Modulecontrolar.JACCMS;
using JA.Modulecontrolar.JRPT;
using Microsoft.Win32;
namespace JA.Modulecontrolar.UI.DReport.Accms.ParameterForms
{
    public partial class frmRptCostCenter : JA.Shared.UI.frmSmartFormStandard
    {
        private ListBox lstLedger = new ListBox();
        private ListBox lstBranch = new ListBox();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        private string strComID { get; set; }
        public string strReportName { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public frmRptCostCenter()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.dteFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteFromDate_KeyPress);
            this.dteFromDate.GotFocus += new System.EventHandler(this.dteFromDate_GotFocus);

            this.dteToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteToDate_KeyPress);
            this.dteToDate.GotFocus += new System.EventHandler(this.dteToDate_GotFocus);

            this.uctxtBranchName.GotFocus += new System.EventHandler(this.uctxtBranchName_GotFocus);
            this.lstBranch.DoubleClick += new System.EventHandler(this.lstBranch_DoubleClick);
            this.uctxtBranchName.KeyDown += new KeyEventHandler(uctxtBranchName_KeyDown);
            this.uctxtBranchName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranchName_KeyPress);
            this.uctxtBranchName.TextChanged += new System.EventHandler(this.uctxtBranchName_TextChanged);

            this.uctxtCostCenterName.GotFocus += new System.EventHandler(this.uctxtCostCenterName_GotFocus);
            this.lstLedger.DoubleClick += new System.EventHandler(this.lstLedger_DoubleClick);
            this.uctxtCostCenterName.KeyDown += new KeyEventHandler(uctxtCostCenterName_KeyDown);
            this.uctxtCostCenterName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtCostCenterName_KeyPress);
            this.uctxtCostCenterName.TextChanged += new System.EventHandler(this.uctxtCostCenterName_TextChanged);
            Utility.CreateListBox(lstLedger, pnlMain, uctxtCostCenterName);
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

        private void uctxtCostCenterName_TextChanged(object sender, EventArgs e)
        {
            lstLedger.SelectedIndex = lstLedger.FindString(uctxtCostCenterName.Text);
        }

        private void lstLedger_DoubleClick(object sender, EventArgs e)
        {
            uctxtCostCenterName.Text = lstLedger.Text;
            dteFromDate.Focus();
        }
        private void uctxtCostCenterName_GotFocus(object sender, System.EventArgs e)
        {
            lstLedger.Visible = true;
            lstBranch.Visible = false;

        }

        private void uctxtCostCenterName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstLedger.Items.Count > 0)
                {
                    uctxtCostCenterName.Text = lstLedger.Text;
                }
                dteFromDate.Focus();

            }
        }

        private void uctxtCostCenterName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstLedger.SelectedItem != null)
                {
                    lstLedger.SelectedIndex = lstLedger.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstLedger.Items.Count - 1 > lstLedger.SelectedIndex)
                {
                    lstLedger.SelectedIndex = lstLedger.SelectedIndex + 1;
                }
            }

        }


        private void uctxtBranchName_TextChanged(object sender, EventArgs e)
        {
            lstBranch.SelectedIndex = lstBranch.FindString(uctxtBranchName.Text);
        }

        private void lstBranch_DoubleClick(object sender, EventArgs e)
        {
            uctxtBranchName.Text = lstBranch.Text;
            dteFromDate.Focus();
        }
        private void uctxtBranchName_GotFocus(object sender, System.EventArgs e)
        {
            lstBranch.Visible = true;
            lstLedger.Visible = false;

        }

        private void uctxtBranchName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBranch.Items.Count > 0)
                {
                    uctxtBranchName.Text = lstBranch.Text;
                }
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
        private void dteFromDate_GotFocus(object sender, System.EventArgs e)
        {
            lstBranch.Visible = false;
            lstLedger.Visible = false;

        }
        private void dteToDate_GotFocus(object sender, System.EventArgs e)
        {
            lstBranch.Visible = false;
            lstLedger.Visible = false;

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
        private void mLaodItem()
        {
            //lstItem.ValueMember = "strItemName";
            //lstItem.DisplayMember = "strItemName";
            //lstItem.DataSource = invms.gFillStockItem("", "", false).ToList();
         
        }

        private void radIndividual_Click(object sender, EventArgs e)
        {

            uctxtCostCenterName.Visible = true ;
            lblCostCenterName.Visible = true;
            lblVoucherName.Visible = true;
            uctxtReportHeading.Focus();
        }

        private void radAll_Click(object sender, EventArgs e)
        {
            uctxtCostCenterName.Visible =false;
            lblCostCenterName.Visible = false;
            lblVoucherName.Visible = false;
            dteFromDate.Focus();
            //txtLocationName.Enabled = false;
        }

        private void frmRptStoreLedger_Load(object sender, EventArgs e)
        {
            dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");

            lstBranch.ValueMember = "BranchID";
            lstBranch.DisplayMember = "BranchName";
            lstBranch.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();

            if (strReportName=="Category")
            {
                lblCostCenterName.Text = "Category Name:";
                grpDetails.Visible = false;
                frmSelection.Visible = true;
                uctxtCostCenterName.Visible = false;
                lblCostCenterName.Visible = false;
                uctxtReportHeading.Text = "Cost Category Report (All)";

                lstLedger.ValueMember = "strVectorcategory";
                lstLedger.DisplayMember = "strVectorcategory";
                lstLedger.DataSource = accms.mFillVectorCategory(strComID).ToList();
            }
            if (strReportName == "Cost Center")
            {
                frmSelection.Visible = true;
                grpDetails.Visible = true;
                lblCostCenterName.Text = "Cost Center";
                uctxtCostCenterName.Visible = false;
                lblCostCenterName.Visible = false;
                uctxtReportHeading.Text = "Cost Center Report(All)";

                lstLedger.ValueMember = "strCostCenter";
                lstLedger.DisplayMember = "strCostCenter";
                lstLedger.DataSource = accms.mFillCostCenter(strComID).ToList();
               
            }
            if (strReportName == "Ledger")
            {
                uctxtReportHeading.Text = "Ledger wise Cost Center Report";
                lblCostCenterName.Text = "Ledger Name:";
                frmSelection.Visible = false;
                grpDetails.Visible = false;
                uctxtCostCenterName.Visible = true;
                lblCostCenterName.Visible = true;

                lstLedger.ValueMember = "strVectorcategory";
                lstLedger.DisplayMember = "strVectorcategory";
                lstLedger.DataSource = accms.mFillLedgerNameVector(strComID).ToList();
            }
            frmLabel.Text = strReportName;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string strBranchID = "";
            if (uctxtBranchName.Text !="")
            {
                strBranchID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);
            }

            if (strReportName == "Ledger")
            {
                if (uctxtCostCenterName.Text == "")
                {
                    MessageBox.Show("Cost Center Name Cannot be Empty");
                    uctxtCostCenterName.Focus();
                    return;
                }
            }
            if (strReportName == "Category")
            {
                if (radIndividual.Checked == true)
                {
                    if (uctxtCostCenterName.Text == "")
                    {
                        MessageBox.Show("Cost Catagory Name Cannot be Empty");
                        uctxtCostCenterName.Focus();
                        return;
                    }
                }
            }
            if (strReportName == "Cost Center")
            {
                if (radIndividual.Checked == true)
                {
                    if (uctxtCostCenterName.Text == "")
                    {
                        MessageBox.Show("Cost Catagory Name Cannot be Empty");
                        uctxtCostCenterName.Focus();
                        return;
                    }
                }
            }
            if (strReportName == "Ledger")
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.CostCenterLedger;
                frmviewer.strFdate  = dteFromDate.Text;
                frmviewer.strTdate  = dteToDate.Text;;
                frmviewer.strString = uctxtCostCenterName.Text;
                frmviewer.strBranchID = strBranchID;
                frmviewer.strHeading = uctxtReportHeading.Text;
                frmviewer.mstrBranchName = uctxtBranchName.Text;
                frmviewer.Show();
            }
            else if (strReportName == "Category")
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.CostCategory;
                frmviewer.strFdate = dteFromDate.Text;
                frmviewer.strTdate = dteToDate.Text; ;
                frmviewer.strString = uctxtCostCenterName.Text;
                frmviewer.strBranchID = strBranchID;
                frmviewer.strSelction = "Category";
                frmviewer.strHeading = uctxtReportHeading.Text;
                frmviewer.mstrBranchName = uctxtBranchName.Text;
                frmviewer.Show();
            }

            else if (strReportName == "Cost Center")
            {
                int intSummDetails = 0;
                if (radSummary.Checked==true)
                {
                    intSummDetails = 1;
                }
                else
                {
                    intSummDetails = 0;
                }

                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.CostCenter ;
                frmviewer.strFdate = dteFromDate.Text;
                frmviewer.strTdate = dteToDate.Text; ;
                frmviewer.strString = uctxtCostCenterName.Text;
                frmviewer.strBranchID = strBranchID;
                frmviewer.strSelction = "Category";
                frmviewer.strHeading = uctxtReportHeading.Text;
                frmviewer.mstrBranchName = uctxtBranchName.Text;
                frmviewer.intSummDetails = intSummDetails;
                frmviewer.Show();
            }
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void radAll_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
              
        }

        

       
    }
}
