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
using JA.Modulecontrolar.UI.DReport.Accms;
using JA.Modulecontrolar.UI.Inventory;
using JA.Modulecontrolar.JACCMS;
using JA.Modulecontrolar.UI.Accms.Forms;
using Microsoft.Win32;

namespace JA.Modulecontrolar.UI.Sales.Forms
{
    public partial class frmChartOfAccount : JA.Shared.UI.frmSmartFormStandard
    {
        public string strReportName { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        private ListBox lstmultiBranch = new ListBox();
        private ListBox lstBuesinestype= new ListBox();
        private ListBox lstCopyChartOfAcc = new ListBox();
        private ListBox lstUserAccessControl = new ListBox();
        private string strComID { get; set; }
        public frmChartOfAccount()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.dtpFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dtpFromDate_KeyPress);
            //this.dteFromDate.GotFocus += new System.EventHandler(this.dteFromDate_GotFocus);

            this.dtpToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dtpToDate_KeyPress);
            this.txtCompanyID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtCompanyID_KeyPress);
   
            this.txtBranchID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtBranchID_KeyPress);

            this.txtCompanyName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtCompanyName_KeyPress);

            this.txtAddres1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtAddres1_KeyPress);

            this.txtAddress2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtAddress2_KeyPress);

            this.txtCountry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtCountry_KeyPress);
 
            this.txtTelephone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtTelephone_KeyPress);

            this.txtFax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtFax_KeyPress);

            this.txtComments.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtComments_KeyPress);

            this.txtCopyChartOfAccount.KeyDown += new KeyEventHandler(txtCopyChartOfAccount_KeyDown);
            this.txtCopyChartOfAccount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtCopyChartOfAccount_KeyPress);
            this.txtCopyChartOfAccount.TextChanged += new System.EventHandler(this.txtCopyChartOfAccount_TextChanged);
            this.lstCopyChartOfAcc.DoubleClick += new System.EventHandler(this.lstCopyChartOfAcc_DoubleClick);
            this.txtCopyChartOfAccount.GotFocus += new System.EventHandler(this.txtCopyChartOfAccount_GotFocus);

            this.txtBusinessType.KeyDown += new KeyEventHandler(txtBusinessType_KeyDown);
            this.txtBusinessType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtBusinessType_KeyPress);
            this.txtBusinessType.TextChanged += new System.EventHandler(this.txtBusinessType_TextChanged);
            this.lstBuesinestype.DoubleClick += new System.EventHandler(this.lstBuesinestype_DoubleClick);
            this.txtBusinessType.GotFocus += new System.EventHandler(this.txtBusinessType_GotFocus);

            this.txtMultipleBranch.KeyDown += new KeyEventHandler(txtMultipleBranch_KeyDown);
            this.txtMultipleBranch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtMultipleBranch_KeyPress);
            this.txtMultipleBranch.TextChanged += new System.EventHandler(this.txtMultipleBranch_TextChanged);
            this.lstmultiBranch.DoubleClick += new System.EventHandler(this.lstmultiBranch_DoubleClick);
            this.txtMultipleBranch.GotFocus += new System.EventHandler(this.txtMultipleBranch_GotFocus);

            this.txtUserAccessControl.KeyDown += new KeyEventHandler(txtUserAccessControl_KeyDown);
            this.txtUserAccessControl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtUserAccessControl_KeyPress);
            this.txtUserAccessControl.TextChanged += new System.EventHandler(this.txtUserAccessControl_TextChanged);
            this.lstUserAccessControl.DoubleClick += new System.EventHandler(this.lstUserAccessControl_DoubleClick);
            this.txtUserAccessControl.GotFocus += new System.EventHandler(this.txtUserAccessControl_GotFocus);

            Utility.CreateListBox(lstmultiBranch, pnlMain, txtCompanyID);
            Utility.CreateListBox(lstBuesinestype, pnlMain, txtCompanyID);
            Utility.CreateListBox(lstCopyChartOfAcc, pnlMain, txtCompanyID);
            Utility.CreateListBox(lstUserAccessControl, pnlMain, txtCompanyID);
            lstmultiBranch.Height = 70;
            lstUserAccessControl.Height = 70;
            lstCopyChartOfAcc.Height = 70;

        }
        #region User Define code
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
        private void txtUserAccessControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstUserAccessControl.Items.Count > 0)
                {
                    txtCompanyID.Text = lstUserAccessControl.Text;

                }
                lstUserAccessControl.Visible = false;
                txtComments.Focus();
                
            }
        }
        private void txtUserAccessControl_KeyDown(object sender, KeyEventArgs e)
        {
            lstUserAccessControl.Visible = true;
            if (e.KeyCode == Keys.Up)
            {
                if (lstUserAccessControl.SelectedItem != null)
                {
                    lstUserAccessControl.SelectedIndex = lstUserAccessControl.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstUserAccessControl.Items.Count - 1 > lstUserAccessControl.SelectedIndex)
                {
                    lstUserAccessControl.SelectedIndex = lstUserAccessControl.SelectedIndex + 1;
                }
            }


        }
        private void txtUserAccessControl_GotFocus(object sender, System.EventArgs e)
        {
            lstmultiBranch.Visible = false;
            lstBuesinestype.Visible = false;
            lstCopyChartOfAcc.Visible = false;
            lstUserAccessControl.Visible = true;
            lstUserAccessControl.Top = 483;
            lstUserAccessControl.SelectedIndex = lstUserAccessControl.FindString(txtCompanyID.Text);

        }
        private void txtUserAccessControl_TextChanged(object sender, EventArgs e)
        {

            lstUserAccessControl.Visible = true;
            lstUserAccessControl.SelectedIndex = lstUserAccessControl.FindString(txtCompanyID.Text);
        }
        private void lstUserAccessControl_DoubleClick(object sender, EventArgs e)
        {
            txtCompanyID.Text = lstUserAccessControl.Text;
            lstUserAccessControl.Visible = false;
            dtpFromDate.Focus();
        }
        private void txtMultipleBranch_KeyPress(object sender, KeyPressEventArgs e)
        {
            lstmultiBranch.Visible = true;
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstmultiBranch.Items.Count > 0)
                {
                    txtCompanyID.Text = lstmultiBranch.Text;

                }
                lstmultiBranch.Visible = false;
                txtUserAccessControl.Focus();
                
            }
        }
        private void txtMultipleBranch_KeyDown(object sender, KeyEventArgs e)
        {
            lstmultiBranch.Visible = true;
            if (e.KeyCode == Keys.Up)
            {
                if (lstmultiBranch.SelectedItem != null)
                {
                    lstmultiBranch.SelectedIndex = lstmultiBranch.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstmultiBranch.Items.Count - 1 > lstmultiBranch.SelectedIndex)
                {
                    lstmultiBranch.SelectedIndex = lstmultiBranch.SelectedIndex + 1;
                }
            }


        }
        private void txtMultipleBranch_GotFocus(object sender, System.EventArgs e)
        {
            lstBuesinestype.Visible = false;
            lstCopyChartOfAcc.Visible = false;
            lstUserAccessControl.Visible = false;
            lstmultiBranch.Visible = true;
            lstmultiBranch.Top = 460;
            lstmultiBranch.SelectedIndex = lstmultiBranch.FindString(txtCompanyID.Text);

        }
        private void txtMultipleBranch_TextChanged(object sender, EventArgs e)
        {

            lstmultiBranch.Visible = true;
            lstmultiBranch.SelectedIndex = lstmultiBranch.FindString(txtCompanyID.Text);
        }
        private void lstmultiBranch_DoubleClick(object sender, EventArgs e)
        {
            lstmultiBranch.Text = lstmultiBranch.Text;
            lstmultiBranch.Visible = false;
            dtpFromDate.Focus();
        }
        private void txtBusinessType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBuesinestype.Items.Count > 0)
                {
                    txtCompanyID.Text = lstBuesinestype.Text;

                }
                lstBuesinestype.Visible = false;
                dtpFromDate.Focus();
            }
        }
        private void txtBusinessType_KeyDown(object sender, KeyEventArgs e)
        {
            lstBuesinestype.Visible = true;
            if (e.KeyCode == Keys.Up)
            {
                if (lstBuesinestype.SelectedItem != null)
                {
                    lstBuesinestype.SelectedIndex = lstBuesinestype.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstBuesinestype.Items.Count - 1 > lstBuesinestype.SelectedIndex)
                {
                    lstBuesinestype.SelectedIndex = lstBuesinestype.SelectedIndex + 1;
                }
            }


        }
        private void txtBusinessType_GotFocus(object sender, System.EventArgs e)
        {
            lstmultiBranch.Visible = false;
            lstCopyChartOfAcc.Visible = false;
            lstUserAccessControl.Visible = false;
            lstBuesinestype.Visible = true;
            lstBuesinestype.Top = 388;
            lstBuesinestype.SelectedIndex = lstBuesinestype.FindString(txtCompanyID.Text);

        }
        private void txtBusinessType_TextChanged(object sender, EventArgs e)
        {

            lstBuesinestype.Visible = true;
            lstBuesinestype.SelectedIndex = lstBuesinestype.FindString(txtCompanyID.Text);
        }
        private void lstBuesinestype_DoubleClick(object sender, EventArgs e)
        {
            txtCompanyID.Text = lstBuesinestype.Text;
            lstBuesinestype.Visible = false;
            dtpFromDate.Focus();
        }
        private void txtCopyChartOfAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstCopyChartOfAcc.Items.Count > 0)
                {
                    txtCompanyID.Text = lstCopyChartOfAcc.Text;

                }
                lstCopyChartOfAcc.Visible = false;
                txtBusinessType.Focus();
            }
        }
        private void txtCopyChartOfAccount_KeyDown(object sender, KeyEventArgs e)
        {
            lstCopyChartOfAcc.Visible = true;
            if (e.KeyCode == Keys.Up)
            {
                if (lstCopyChartOfAcc.SelectedItem != null)
                {
                    lstCopyChartOfAcc.SelectedIndex = lstCopyChartOfAcc.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstCopyChartOfAcc.Items.Count - 1 > lstCopyChartOfAcc.SelectedIndex)
                {
                    lstCopyChartOfAcc.SelectedIndex = lstCopyChartOfAcc.SelectedIndex + 1;
                }
            }


        }
        private void txtCopyChartOfAccount_GotFocus(object sender, System.EventArgs e)
        {
            lstmultiBranch.Visible = false;
            lstBuesinestype.Visible = false;
            lstUserAccessControl.Visible = false;
            lstCopyChartOfAcc.Visible = true;
            lstCopyChartOfAcc.Top = 365;
            lstCopyChartOfAcc.SelectedIndex = lstCopyChartOfAcc.FindString(txtCompanyID.Text);

        }
        private void txtCopyChartOfAccount_TextChanged(object sender, EventArgs e)
        {

            lstCopyChartOfAcc.Visible = true;
            lstCopyChartOfAcc.SelectedIndex = lstCopyChartOfAcc.FindString(txtCompanyID.Text);
        }
        private void lstCopyChartOfAcc_DoubleClick(object sender, EventArgs e)
        {
            txtCompanyID.Text = lstCopyChartOfAcc.Text;
            lstCopyChartOfAcc.Visible = false;
            dtpFromDate.Focus();
        }
        private void txtFax_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtCopyChartOfAccount.Focus();
        }
        private void txtTelephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtFax.Focus();
        }
        private void txtAddress2_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtCountry.Focus();
        }    
        private void txtAddres1_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtAddress2.Focus();
        }         
        private void txtCompanyID_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtBranchID.Focus();
        }      
        private void txtBranchID_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtCompanyName.Focus();
        }
        private void txtCountry_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtTelephone.Focus();
            
        }
        private void txtCompanyName_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtAddres1.Focus();
        }
        private void txtComments_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnSave.Focus();
        }
        #endregion

        private void dtpFromDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dtpToDate.Focus();
            }
        }

        private void dtpToDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                txtMultipleBranch.Focus();

            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void frmChartOfAccount_Load(object sender, EventArgs e)
        {
            string strCompanyName="";
            
            lstmultiBranch.Visible = false ;
            lstBuesinestype.Visible =false ;
            lstCopyChartOfAcc.Visible =false ;
            lstUserAccessControl.Visible =false ;
            txtCompanyID.Text = strComID;
            Utility.gstrCompanyID = txtCompanyID.Text.Trim();
            Utility.gstrBranchID = txtBranchID.Text.Trim();
            Utility.gstrCompanyName = txtCompanyName.Text.Trim();
            Utility.gdteFinancialYearFrom = Utility.DateFormat(dtpFromDate.Value);
            Utility.gdteFinancialYearTo = Utility.DateFormat(dtpToDate.Value);
            //Utility.gstrFinicialYearFrom = Utility.gstrDateToStr(dtefinancialform.Text);
            //Utility.gstrFinicialYearTo = Utility.gstrDateToStr(dteFinanicalTo.Text);
            //Utility.gstrBusinessType = txtBusinessType.Text;
            //mstrCurSymbol = txtCurrency.Text.Replace("'", "''");
            //mstrCurFormallName = txtCurrency.Text.Replace("'", "''");

        }

      
       
    }


}

