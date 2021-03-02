using Dutility;
using JA.Modulecontrolar.JINVMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using JA.Modulecontrolar.JACCMS;
using Microsoft.Win32;


namespace JA.Modulecontrolar.UI.Inventory
{
    public partial class frmCodeGenerate : JA.Shared.UI.frmSmartFormStandard
    {
        private ListBox lstGrorupname = new ListBox();


        public long lngFormPriv { get; set; }
        public string strFormName { get; set; }
        public int m_action { get; set; }
        private string mstrOldLocation { get; set; }
        private string strComID { get; set; }
        public frmCodeGenerate()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.txtGroupName.KeyDown += new KeyEventHandler(txtGroupName_KeyDown);
            this.txtGroupName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtGroupName_KeyPress);
            this.txtGroupName.TextChanged += new System.EventHandler(this.txtGroupName_TextChanged);
            this.lstGrorupname.DoubleClick += new System.EventHandler(this.lstGrorupname_DoubleClick);
            this.txtGroupName.GotFocus += new System.EventHandler(this.txtGroupName_GotFocus);

            Utility.CreateListBox(lstGrorupname, pnlMain, txtGroupName);
      
        }

   
        #region "User Define"


        private void txtGroupName_TextChanged(object sender, EventArgs e)
        {
            lstGrorupname.SelectedIndex = lstGrorupname.FindString(txtGroupName.Text);
        }

        private void lstGrorupname_DoubleClick(object sender, EventArgs e)
        {
            txtGroupName.Text = lstGrorupname.Text;
            btnSave.Focus();
            lstGrorupname.Visible = false;
        }

        private void txtGroupName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstGrorupname.Items.Count > 0)
                {
                    txtGroupName.Text = lstGrorupname.Text;
                }
                lstGrorupname.Visible = false;
            }

        }
        private void txtGroupName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstGrorupname.SelectedItem != null)
                {
                    lstGrorupname.SelectedIndex = lstGrorupname.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstGrorupname.Items.Count - 1 > lstGrorupname.SelectedIndex)
                {
                    lstGrorupname.SelectedIndex = lstGrorupname.SelectedIndex + 1;
                }
            }

        }

        private void txtGroupName_GotFocus(object sender, System.EventArgs e)
        {

            lstGrorupname.SelectedIndex = lstGrorupname.FindString(txtGroupName.Text);
            lstGrorupname.Visible = true;
        }

        #endregion
        #region "Load"
        private void frmCodeGenerate_Load(object sender, EventArgs e)
        {

            LoadDefaultValue();
        }


        #endregion
        #region "DefaultValue"
        private void LoadDefaultValue()
        {
            SortedDictionary<string, int> userCache = new SortedDictionary<string, int>
            {
              {"Direct Raw Materials", 1},
              {"Indirect Raw Materials", 2},
              {"Finished Goods", 3}
              
            };

            lstGrorupname.DisplayMember = "Key";
            lstGrorupname.ValueMember = "Value";
            lstGrorupname.DataSource = new BindingSource(userCache, null);

           

        }
        #endregion

        private void btngenerate_Click(object sender, EventArgs e)
        {

        }

     

    }
}
