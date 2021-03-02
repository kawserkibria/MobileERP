using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Win32;
using JA.Modulecontrolar;
using Dutility;
using System.IO;
using System.Drawing.Imaging;
using System.Linq;
using Microsoft.VisualBasic;
using JA.Modulecontrolar.JACCMS;
using JA.Modulecontrolar.JINVMS;


namespace JA.Modulecontrolar.UI.Tools.Forms
{
    public partial class frmChartOfAccount : Form
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
        private ListBox lstCurrency = new ListBox();
        private ListBox lstuserControl = new ListBox();
        private ListBox lstBusinessType = new ListBox();
        private ListBox lstMultipleBranch = new ListBox();
        private ListBox lstCopyChartOfAcc = new ListBox();
        private string strComID { get; set; }
        public int intCallType;
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public frmChartOfAccount()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.txtCompanyName.GotFocus += new System.EventHandler(this.txtCompanyName_GotFocus);
            this.txtAddress1.GotFocus += new System.EventHandler(this.txtAddress1_GotFocus);
            this.txtAddress2.GotFocus += new System.EventHandler(this.txtAddress2_GotFocus);
            this.txtCountry.GotFocus += new System.EventHandler(this.txtCountry_GotFocus);
            this.txtFax.GotFocus += new System.EventHandler(this.txtFax_GotFocus);
            this.txtPhone.GotFocus += new System.EventHandler(this.txtPhone_GotFocus);
            this.txtCopyChartOfAccount.GotFocus += new System.EventHandler(this.txtCopyChartOfAccount_GotFocus);
            this.txtBusinessType.GotFocus += new System.EventHandler(this.txtBusinessType_GotFocus);
            this.dtefinancialform.GotFocus += new System.EventHandler(this.dtefinancialform_GotFocus);
            this.dteFinanicalTo.GotFocus += new System.EventHandler(this.dteFinanicalTo_GotFocus);
            this.txtMultipleBranch.GotFocus += new System.EventHandler(this.txtMultipleBranch_GotFocus);
            this.txtUserControl.GotFocus += new System.EventHandler(this.txtUserControl_GotFocus);
            this.txtComments.GotFocus += new System.EventHandler(this.txtComments_GotFocus);
            this.txtCompanyID.GotFocus += new System.EventHandler(this.txtCompanyID_GotFocus);
            this.txtBranchId.GotFocus += new System.EventHandler(this.txtBranchId_GotFocus);

            this.txtCopyChartOfAccount.KeyDown += new KeyEventHandler(txtCopyChartOfAccount_KeyDown);
            this.txtCopyChartOfAccount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtCopyChartOfAccount_KeyPress);

            this.txtUserControl.KeyDown += new KeyEventHandler(txtUserControl_KeyDown);
            this.txtUserControl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtUserControl_KeyPress);

            this.txtMultipleBranch.KeyDown += new KeyEventHandler(txtMultipleBranch_KeyDown);
            this.txtMultipleBranch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtMultipleBranch_KeyPress);

            this.txtBusinessType.KeyDown += new KeyEventHandler(txtBusinessType_KeyDown);
            this.txtBusinessType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtBusinessType_KeyPress);
            this.txtCompanyID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtCompanyID_KeyPress);
            
            this.lstCurrency.DoubleClick += new System.EventHandler(this.lstCurrency_DoubleClick);
            this.lstMultipleBranch.DoubleClick += new System.EventHandler(this.lstMultipleBranch_DoubleClick);
            this.lstuserControl.DoubleClick += new System.EventHandler(this.lstuserControl_DoubleClick);
            this.lstBusinessType.DoubleClick += new System.EventHandler(this.lstBusinessType_DoubleClick);
            this.lstCopyChartOfAcc.DoubleClick += new System.EventHandler(this.lstCopyChartOfAcc_DoubleClick);

            this.txtMultipleBranch.TextChanged += new System.EventHandler(this.txtMultipleBranch_TextChanged);
            this.txtUserControl.TextChanged += new System.EventHandler(this.txtUserControl_TextChanged);
            this.txtBusinessType.TextChanged += new System.EventHandler(this.txtBusinessType_TextChanged);

            this.uctxtAdministrator.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtAdministrator_KeyPress);
            this.uctxtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtPassword_KeyPress);
            this.uctxtRetypePassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtRetypePassword_KeyPress);

            //this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
       
            Utility.CreateListBox(lstCurrency, panel1, txtCopyChartOfAccount);
            Utility.CreateListBox(lstBusinessType, panel1, txtBusinessType);
            Utility.CreateListBox(lstuserControl, panel1, txtUserControl);
            Utility.CreateListBox(lstMultipleBranch, panel1, txtMultipleBranch);
            Utility.CreateListBox(lstCopyChartOfAcc, panel1, txtMultipleBranch);

            TabChange();
        }


        #region "User Define Event"
        private void txtCompanyID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                txtCompanyName.Focus();

            }
        }
        private void uctxtAdministrator_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                uctxtPassword.Focus();

            }
        }
        private void uctxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
              
                uctxtRetypePassword.Focus();

            }
        }
        private void uctxtRetypePassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                panelAcessControl.Visible = false;
                txtComments.Focus();

            }
        }
        private void txtBusinessType_TextChanged(object sender, EventArgs e)
        {
            lstBusinessType.SelectedIndex = lstBusinessType.FindString(txtBusinessType.Text);
        }
        private void txtMultipleBranch_TextChanged(object sender, EventArgs e)
        {
            lstMultipleBranch.SelectedIndex = lstMultipleBranch.FindString(txtMultipleBranch.Text);
        }
        private void txtUserControl_TextChanged(object sender, EventArgs e)
        {
            lstuserControl.SelectedIndex = lstuserControl.FindString(txtUserControl.Text);
        }
        private void txtCopyChartOfAccount_TextChanged(object sender, EventArgs e)
        {
            lstCurrency.SelectedIndex = lstCurrency.FindString(txtCopyChartOfAccount.Text);
        }

        private void lstBusinessType_DoubleClick(object sender, EventArgs e)
        {
            txtBusinessType.Text = lstBusinessType.Text;
            dtefinancialform.Focus();
        }
        private void lstCurrency_DoubleClick(object sender, EventArgs e)
        {
            txtCopyChartOfAccount.Text = lstCurrency.Text;
            txtBusinessType.Focus();
        }
        private void lstMultipleBranch_DoubleClick(object sender, EventArgs e)
        {
            txtMultipleBranch.Text = lstMultipleBranch.Text;
            txtUserControl.Focus();
        }

        private void lstuserControl_DoubleClick(object sender, EventArgs e)
        {
            txtUserControl.Text = lstuserControl.Text;
            if (txtUserControl.Text.ToUpper() == "YES")
            {
                panelAcessControl.Visible = true;

                panelAcessControl.Size = new Size(346, 220);
                panelAcessControl.Top = txtAddress2.Top + 10;
                panelAcessControl.Left = txtAddress2.Left + 5;
                uctxtAdministrator.Focus();
            }
            else
            {
                panelAcessControl.Visible = false;
                txtComments.Focus();
            }
           
        }
        private void lstCopyChartOfAcc_DoubleClick(object sender, EventArgs e)
        {
            txtCopyChartOfAccount.Text = lstCopyChartOfAcc.Text;
            if (txtCopyChartOfAccount.Text.ToUpper() == "YES")
            {
                panelAcessControl.Visible = true;

                panelAcessControl.Size = new Size(346, 220);
                panelAcessControl.Top = txtAddress2.Top + 10;
                panelAcessControl.Left = txtAddress2.Left + 5;
                txtBusinessType.Focus();
            }
            else
            {
                panelAcessControl.Visible = false;
                txtBusinessType.Focus();
            }

        }
        private void txtBusinessType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBusinessType.Items.Count >0 )
                {
                    txtBusinessType.Text = lstBusinessType.Text;
                }
                dtefinancialform.Focus();

            }
        }

        private void txtBusinessType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstBusinessType.SelectedItem != null)
                {
                    lstBusinessType.SelectedIndex = lstBusinessType.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstBusinessType.Items.Count - 1 > lstBusinessType.SelectedIndex)
                {
                    lstBusinessType.SelectedIndex = lstBusinessType.SelectedIndex + 1;
                }
            }

        }

        private void txtMultipleBranch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstMultipleBranch.Items.Count >0)
                {
                    txtMultipleBranch.Text = lstMultipleBranch.Text;
                }
                txtUserControl.Focus();
            }
        }

        private void txtMultipleBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstMultipleBranch.SelectedItem != null)
                {
                    lstMultipleBranch.SelectedIndex = lstMultipleBranch.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstMultipleBranch.Items.Count - 1 > lstMultipleBranch.SelectedIndex)
                {
                    lstMultipleBranch.SelectedIndex = lstMultipleBranch.SelectedIndex + 1;
                }
            }

        }
        private void txtUserControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstuserControl.Items.Count>0)
                {
                    txtUserControl.Text = lstuserControl.Text;
                }
                if (txtUserControl.Text.ToUpper()=="YES")
                {
                    panelAcessControl.Visible = true;
                    
                    panelAcessControl.Size = new Size(346, 220);
                    panelAcessControl.Top = txtAddress2.Top + 10;
                    panelAcessControl.Left = txtAddress2.Left + 5;
                    uctxtAdministrator.Focus();
                }
                else
                {
                    panelAcessControl.Visible = false;
                    txtComments.Focus();
                }
                

            }
        }

        private void txtUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstuserControl.SelectedItem != null)
                {
                    lstuserControl.SelectedIndex = lstuserControl.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstuserControl.Items.Count - 1 > lstuserControl.SelectedIndex)
                {
                    lstuserControl.SelectedIndex = lstuserControl.SelectedIndex + 1;
                }
            }
            
        }

        private void txtCopyChartOfAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstCurrency.Items.Count>0)
                {
                    txtCopyChartOfAccount.Text = lstCurrency.Text;
                }
                txtBusinessType.Focus();
                lstCopyChartOfAcc.Visible = false;
            }
        }
        private void txtCopyChartOfAccount_KeyDown(object sender, KeyEventArgs e)
        {
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


        private void txtCompanyID_GotFocus(object sender, System.EventArgs e)
        {
            lstCurrency.Visible = false;
            lstBusinessType.Visible = false;
            lstuserControl.Visible = false;
            lstMultipleBranch.Visible = false;
            lstCopyChartOfAcc.Visible = false;
        }
        private void txtBranchId_GotFocus(object sender, System.EventArgs e)
        {
            lstCurrency.Visible = false;
            lstBusinessType.Visible = false;
            lstuserControl.Visible = false;
            lstMultipleBranch.Visible = false;
            lstCopyChartOfAcc.Visible = false;

        }
        private void txtCopyChartOfAccount_GotFocus(object sender, System.EventArgs e)
        {
            lstCurrency.Visible = false;
            lstBusinessType.Visible = false;
            lstuserControl.Visible = false;
            lstMultipleBranch.Visible = false;
            lstCopyChartOfAcc.Visible = true;

            lstCopyChartOfAcc.Top = 245;
            //lstCurrency.SelectedIndex = lstCurrency.FindString(txtCopyChartOfAccount.Text);
        }
        private void txtBusinessType_GotFocus(object sender, System.EventArgs e)
        {
            lstCurrency.Visible = false;
            lstMultipleBranch.Visible = false;
            lstuserControl.Visible = false;
            lstBusinessType.Visible = true;
            lstCopyChartOfAcc.Visible = false;
            lstBusinessType.SelectedIndex = lstBusinessType.FindString(txtBusinessType.Text);
        }
        private void txtMultipleBranch_GotFocus(object sender, System.EventArgs e)
        {
            lstCurrency.Visible = false;
            lstMultipleBranch.Visible = true;
            lstuserControl.Visible = false;
            lstBusinessType.Visible = false;
            lstCopyChartOfAcc.Visible = false;
            lstMultipleBranch.SelectedIndex = lstMultipleBranch.FindString(txtMultipleBranch.Text);
        }
        protected void txtComments_GotFocus(object sender, EventArgs e)
        {
            lstCurrency.Visible = false;
            lstMultipleBranch.Visible = false;
            lstuserControl.Visible = false;
            lstBusinessType.Visible = false;
            lstCopyChartOfAcc.Visible = false;
        }
        protected void txtUserControl_GotFocus(object sender, EventArgs e)
        {
            lstCurrency.Visible = false;
            lstMultipleBranch.Visible = false;
            lstuserControl.Visible = true;
            lstBusinessType.Visible = false;
            lstCopyChartOfAcc.Visible = false;
            lstuserControl.SelectedIndex = lstuserControl.FindString(txtUserControl.Text);
        }
        protected void dtefinancialform_GotFocus(object sender, EventArgs e)
        {
            lstCurrency.Visible = false;
            lstMultipleBranch.Visible = false;
            lstuserControl.Visible = false;
            lstBusinessType.Visible = false;
            lstCopyChartOfAcc.Visible = false;
        }
        protected void dteFinanicalTo_GotFocus(object sender, EventArgs e)
        {
            lstCurrency.Visible = false;
            lstMultipleBranch.Visible = false;
            lstuserControl.Visible = false;
            lstBusinessType.Visible = false;
            lstCopyChartOfAcc.Visible = false;

        }
        protected void txtPhone_GotFocus(object sender, EventArgs e)
        {
            lstCurrency.Visible = false;
            lstMultipleBranch.Visible = false;
            lstuserControl.Visible = false;
            lstBusinessType.Visible = false;
            lstCopyChartOfAcc.Visible = false;

        }
        protected void txtFax_GotFocus(object sender, EventArgs e)
        {
            lstCurrency.Visible = false;
            lstMultipleBranch.Visible = false;
            lstuserControl.Visible = false;
            lstBusinessType.Visible = false;
            lstCopyChartOfAcc.Visible = false;
        }

        protected void txtCountry_GotFocus(object sender, EventArgs e)
        {
            lstCurrency.Visible = false;
            lstMultipleBranch.Visible = false;
            lstuserControl.Visible = false;
            lstBusinessType.Visible = false;
            lstCopyChartOfAcc.Visible = false;

        }

        protected void txtAddress2_GotFocus(object sender, EventArgs e)
        {
            lstCurrency.Visible = false;
            lstMultipleBranch.Visible = false;
            lstuserControl.Visible = false;
            lstBusinessType.Visible = false;
            lstCopyChartOfAcc.Visible = false;
        }

        protected void txtAddress1_GotFocus(object sender, EventArgs e)
        {
            lstCurrency.Visible = false;
            lstMultipleBranch.Visible = false;
            lstuserControl.Visible = false;
            lstBusinessType.Visible = false;
            lstCopyChartOfAcc.Visible = false;
        }

        protected void txtCompanyName_GotFocus(object sender, EventArgs e)
        {
            lstCurrency.Visible = false;
            lstMultipleBranch.Visible = false;
            lstuserControl.Visible = false;
            lstBusinessType.Visible = false;
            lstCopyChartOfAcc.Visible = false;
        }
        #endregion
        #region Load
        private void mloadCurrecncy()
        {

            SortedDictionary<string, int> userCache = new SortedDictionary<string, int>
            {
              {"BDT", 1},
              {"$", 2},
              {"€", 3},
              {"£", 4},
              {"¥", 5},
              {"Rs", 6},
           
            };

            lstCurrency.DisplayMember = "Key";
            lstCurrency.ValueMember = "Value";
            lstCurrency.DataSource = new BindingSource(userCache, null);

        }
        private void mloadCopyChatOfAcc()
        {

            SortedDictionary<string, int> userCache = new SortedDictionary<string, int>
            {
               { Utility.gstrCompanyName + " - " + Convert.ToDateTime(Utility.gdteFinancialYearFrom).ToString("yyyy"),1},
              {"End of List", 2},        
            };
            lstCopyChartOfAcc.DisplayMember = "Key";
            lstCopyChartOfAcc.ValueMember = "Value";
            lstCopyChartOfAcc.DataSource = new BindingSource(userCache, null);


              
            
        }
        private void mloadBusinessType()
        {
            SortedDictionary<string, int> userCache = new SortedDictionary<string, int>
            {
              {"Trading Company", 1},
              {"Real Estate", 2},
              {"Educational Institution", 3},
              {"Manufacturing Company", 4},
              {"Non-Profit Company", 5},
              {"Hospital", 6},
              {"Hotel Management", 7},
              {"Co-Operative Society", 8},
            };


            lstBusinessType.DisplayMember = "Key";
            lstBusinessType.ValueMember = "Value";
            lstBusinessType.DataSource = new BindingSource(userCache, null);

        }
        private void mloadMultipleBranch()
        {
            SortedDictionary<string, int> userCache = new SortedDictionary<string, int>
            {
              {"No", 1},
              {"Yes", 2},
            };

            lstMultipleBranch.DisplayMember = "Key";
            lstMultipleBranch.ValueMember = "Value";
            lstMultipleBranch.DataSource = new BindingSource(userCache, null);

        }
        private void mloadUserControl()
        {
            SortedDictionary<string, int> userCache = new SortedDictionary<string, int>
            {
              {"No", 1},
              {"Yes", 2},
            };

            lstuserControl.DisplayMember = "Key";
            lstuserControl.ValueMember = "Value";
            lstuserControl.DataSource = new BindingSource(userCache, null);

        }
        #endregion
        #region "Tab change
        private void TabChange()
        {

            txtCompanyName.Focus();
            txtCompanyName.AllToNextTab(txtAddress1);
            txtAddress1.AllToNextTab(txtAddress2);
            txtAddress2.AllToNextTab(txtCountry);
            txtCountry.AllToNextTab(txtFax);
            txtFax.AllToNextTab(txtPhone);
            txtPhone.AllToNextTab(txtCopyChartOfAccount);
            txtCopyChartOfAccount.AllToNextTab(txtBusinessType);
            txtBusinessType.AllToNextTab(dtefinancialform);
            dtefinancialform.AllToNextTab(dteFinanicalTo);
            dteFinanicalTo.AllToNextTab(txtMultipleBranch);
            txtMultipleBranch.AllToNextTab(txtUserControl);
            txtUserControl.AllToNextTab(txtComments);
            txtComments.AllToNextTab(btnInstall);

        }
        #endregion
     
     
       
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }



      

        private void frmChartOfAccount_Load(object sender, EventArgs e)
        {
           // List<DatabaseCompany> oodc = invms.mloadDatabaseCompnay(strComID).ToList();
            lstCopyChartOfAcc.DisplayMember = "strComName";
            lstCopyChartOfAcc.ValueMember = "strComID";
            lstCopyChartOfAcc.DataSource  = invms.mloadDatabaseCompnay(strComID).ToList();
        }

       

       

      

       
    
       
    }
}