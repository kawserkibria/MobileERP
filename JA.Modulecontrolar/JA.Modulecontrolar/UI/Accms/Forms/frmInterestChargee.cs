using Dutility;
using JA.Modulecontrolar.JACCMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using JA.Modulecontrolar.UI.Forms;
using JA.Modulecontrolar.UI.Accms.Forms;
using Microsoft.Win32;

namespace JA.Modulecontrolar.UI.Accms.Forms
{
    public partial class frmInterestChargee : JA.Shared.UI.frmJagoronFromSearch
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
        private ListBox lsLedger = new ListBox();
        public long lngFormPriv { get; set; }
        public int m_action { get; set; }
        private long mlngSLNo {get;set;}
        private string  mstrOldLedger { get; set; }
        private string strComID { get; set; }
        private ListBox lstLedger = new ListBox();
        public frmInterestChargee()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.txtCreditLedger.KeyDown += new KeyEventHandler(txtCreditLedger_KeyDown);
            this.txtCreditLedger.TextChanged += new System.EventHandler(this.txtCreditLedger_TextChanged);
            this.txtCreditLedger.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCreditLedger_KeyPress);
            this.txtCreditLedger.GotFocus += new System.EventHandler(this.txtCreditLedger_GotFocus);
            //this.lsLedger.DoubleClick += new System.EventHandler(this.lsLedger_DoubleClick);
            this.lstLedger.DoubleClick += new System.EventHandler(this.lsLedger_DoubleClick);

            this.txtInterestR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInterestR_KeyPress);
            this.dteToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dteToDate_KeyPress);
            this.dteEffectform.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dteEffectform_KeyPress);

            Utility.CreateListBox(lstLedger, pnlFixedAssets, txtCreditLedger);
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

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
      
        private void frmInterestChargee_Load(object sender, EventArgs e)
        {
            lstLedger.Visible = false;
            lstLedger.ValueMember = "strLedgerName";
            lstLedger.DisplayMember = "strLedgerName";
            lstLedger.DataSource = accms.mFillLedgerList(strComID, 215).ToList();


        }
        #region "User Define"
        private void txtInterestR_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Return)
            {

                btnSave.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                //Utility.PriorSetFocusText(uctxtUnder, uctxtLedgerName);
            }
        }
        private void dteToDate_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Return)
            {

                txtInterestR.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                //Utility.PriorSetFocusText(uctxtUnder, uctxtLedgerName);
            }
        }
        private void dteEffectform_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Return)
            {
              
                dteToDate.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                //Utility.PriorSetFocusText(uctxtUnder, uctxtLedgerName);
            }
        }
        private void txtCreditLedger_TextChanged(object sender, EventArgs e)
        {
            lstLedger.Visible = true;
            lstLedger.SelectedIndex = lstLedger.FindString(txtCreditLedger.Text);
        }
        private void txtCreditLedger_GotFocus(object sender, System.EventArgs e)
        {

           
        }
        private void lsLedger_DoubleClick(object sender, EventArgs e)
        {
            txtCreditLedger.Text = lstLedger.Text;
            lstLedger.Visible = false;
            dteEffectform.Focus();
        }

        private void txtCreditLedger_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (e.KeyChar == (char)Keys.Return)
            {
                txtCreditLedger.Text = lstLedger.Text;
                lstLedger.Visible = false;
                dteEffectform.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                //Utility.PriorSetFocusText(uctxtUnder, uctxtLedgerName);
            }
        }
        private void txtCreditLedger_KeyDown(object sender, KeyEventArgs e)
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
     
        #endregion

        //private void lstLedgerNew_DoubleClick(object sender, EventArgs e)
        //{

        //}

      
     
    }
}
