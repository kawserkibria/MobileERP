using Dutility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JA.Modulecontrolar.JACCMS;
using Microsoft.Win32;

namespace JA.Modulecontrolar.UI.Forms
{
    public partial class frmGroup : Form
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();

        private ListBox lstAccountType = new ListBox();
        private ListBox lstUnder = new ListBox();
        private ListBox lstCashFlowType = new ListBox();
        private string strComID { get; set; }
        public frmGroup()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.txtGroupName.GotFocus += new System.EventHandler(this.txtGroupName_GotFocus);
            this.txtUnder.GotFocus += new System.EventHandler(this.txtUnder_GotFocus);
            this.txtAccountsType.GotFocus += new System.EventHandler(this.txtAccountsType_GotFocus);
            this.txtCashFlowType.GotFocus += new System.EventHandler(this.txtCashFlowType_GotFocus);

            this.txtUnder.KeyDown += new KeyEventHandler(txtUnder_KeyDown);
            this.txtUnder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtUnder_KeyPress);

            this.txtAccountsType.KeyDown += new KeyEventHandler(txtAccountsType_KeyDown);
            this.txtAccountsType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtAccountsType_KeyPress);

            this.txtCashFlowType.KeyDown += new KeyEventHandler(txtCashFlowType_KeyDown);
            this.txtCashFlowType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtCashFlowType_KeyPress);

            this.lstUnder.DoubleClick += new System.EventHandler(this.lstUnder_DoubleClick);
            this.lstAccountType.DoubleClick += new System.EventHandler(this.lstAccountType_DoubleClick);
            this.lstCashFlowType.DoubleClick += new System.EventHandler(this.lstCashFlowType_DoubleClick);

            this.txtUnder.TextChanged += new System.EventHandler(this.txtBusinessType_TextChanged);
            this.txtAccountsType.TextChanged += new System.EventHandler(this.txtAccountsType_TextChanged);
            this.txtCashFlowType.TextChanged += new System.EventHandler(this.txtCashFlowType_TextChanged);

            Utility.CreateListBox(lstAccountType, panel1, txtAccountsType);
            Utility.CreateListBox(lstUnder, panel1, txtUnder);
            Utility.CreateListBox(lstCashFlowType, panel1, txtCashFlowType);
            TabChange();
        }
        #region "Tab change
        private void TabChange()
        {
            txtGroupName.Focus();
            txtGroupName.AllToNextTab(txtUnder);
            txtUnder.AllToNextTab(txtAccountsType);
            txtAccountsType.AllToNextTab(txtCashFlowType);
            txtCashFlowType.AllToNextTab(btnSave);

        }
        #endregion
        #region User DefineEvent
        private void txtCashFlowType_TextChanged(object sender, EventArgs e)
        {
            lstCashFlowType.SelectedIndex = lstCashFlowType.FindString(txtCashFlowType.Text);
        }
        private void txtAccountsType_TextChanged(object sender, EventArgs e)
        {
            lstAccountType.SelectedIndex = lstAccountType.FindString(txtAccountsType.Text);
        }
        private void txtBusinessType_TextChanged(object sender, EventArgs e)
        {
            lstUnder.SelectedIndex = lstUnder.FindString(txtUnder.Text);
        }
        private void lstCashFlowType_DoubleClick(object sender, EventArgs e)
        {
            txtCashFlowType.Text = lstCashFlowType.Text;
            lstCashFlowType.Visible = false;
            btnSave.Focus();
        }
        private void lstAccountType_DoubleClick(object sender, EventArgs e)
        {
            txtAccountsType.Text = lstAccountType.Text;
            txtCashFlowType.Focus();
        }
        private void lstUnder_DoubleClick(object sender, EventArgs e)
        {
            txtUnder.Text = lstUnder.Text;
            txtAccountsType.Focus();
        }
        private void txtCashFlowType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstCashFlowType.Items.Count > 0)
                {
                    txtCashFlowType.Text = lstCashFlowType.Text;
                }
                lstCashFlowType.Visible = false;
                btnSave.Focus();

            }
        }
        private void txtCashFlowType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstCashFlowType.SelectedItem != null)
                {
                    lstCashFlowType.SelectedIndex = lstCashFlowType.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstCashFlowType.Items.Count - 1 > lstCashFlowType.SelectedIndex)
                {
                    lstCashFlowType.SelectedIndex = lstCashFlowType.SelectedIndex + 1;
                }
            }

        }
        private void txtAccountsType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstAccountType.Items.Count > 0)
                {
                    txtAccountsType.Text = lstAccountType.Text;
                }
                txtCashFlowType.Focus();

            }
        }
        private void txtAccountsType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstAccountType.SelectedItem != null)
                {
                    lstAccountType.SelectedIndex = lstAccountType.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstAccountType.Items.Count - 1 > lstAccountType.SelectedIndex)
                {
                    lstAccountType.SelectedIndex = lstAccountType.SelectedIndex + 1;
                }
            }

        }
        private void txtUnder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstUnder.Items.Count > 0)
                {
                    txtUnder.Text = lstUnder.Text;
                }
                txtAccountsType.Focus();

            }
        }
        private void txtUnder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstUnder.SelectedItem != null)
                {
                    lstUnder.SelectedIndex = lstUnder.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstUnder.Items.Count - 1 > lstUnder.SelectedIndex)
                {
                    lstUnder.SelectedIndex = lstUnder.SelectedIndex + 1;
                }
            }

        }
        private void txtGroupName_GotFocus(object sender, System.EventArgs e)
        {
            lstAccountType.Visible = false;
            lstCashFlowType.Visible = false;
            lstUnder.Visible = false;
        }
        private void txtUnder_GotFocus(object sender, System.EventArgs e)
        {
            lstAccountType.Visible = false  ;
            lstCashFlowType.Visible = false;
            lstUnder.Visible = true;
        }
        private void txtAccountsType_GotFocus(object sender, System.EventArgs e)
        {
            lstAccountType.Visible = true;
            lstCashFlowType.Visible = false;
            lstUnder.Visible = false;
        }
        private void txtCashFlowType_GotFocus(object sender, System.EventArgs e)
        {
            lstAccountType.Visible = false;
            lstCashFlowType.Visible = true;
            lstUnder.Visible = false;
        }
        #endregion
        private void frmGroup_Load(object sender, EventArgs e)
        {
            lstAccountType.Visible = false;
            lstCashFlowType.Visible = false;
            lstUnder.Visible = false;

            lstUnder.DisplayMember = "value";
            lstUnder.ValueMember = "Key";
            lstUnder.DataSource = new BindingSource(accms.GetAccountsGroup(strComID), null);
            mAccountType();
            mCashFlow();

            

        }

        private void mAccountType()
        {

            SortedDictionary<string, int> userCache = new SortedDictionary<string, int>
            {
              {"Assets", 1},
              {"Liabilities", 2},
              {"Income", 3},
              {"Expenses", 4}
            };

            lstAccountType.DisplayMember = "Key";
            lstAccountType.ValueMember = "Value";
            lstAccountType.DataSource = new BindingSource(userCache, null);

        }
        private void mCashFlow()
        {
          

            SortedDictionary<string, int> userCache = new SortedDictionary<string, int>
            {
              {"End of List", 1},
              {"Operating Activities", 2},
              {"Investing Activities", 3},
              {"Financing Activities", 4}
            };

            lstCashFlowType.DisplayMember = "Key";
            lstCashFlowType.ValueMember = "Value";
            lstCashFlowType.DataSource = new BindingSource(userCache, null);

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }


        




    }
}
