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

namespace JA.Modulecontrolar.UI.Accms.Forms
{
    public partial class frmSearch : JA.Shared.UI.frmJagoronFromSearch
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public delegate void AddAllClick(List<AccountsLedger> items, object sender, EventArgs e);
        public AddAllClick onAddAllButtonClicked;
        public int mintGrouptype { get; set; }
        public string  mstrdrcr { get; set; }
        public frmSearch()
        {
            InitializeComponent();
            this.txtSerach.KeyDown += new KeyEventHandler(txtSerach_KeyDown);
            this.txtSerach.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtSerach_KeyPress);
            this.txtSerach.TextChanged += new System.EventHandler(this.txtSerach_TextChanged);
            this.lstLedger.DoubleClick += new System.EventHandler(this.lstLedger_DoubleClick);
            this.txtSerach.GotFocus += new System.EventHandler(this.txtSerach_GotFocus);
           
           
        }
        private void txtSerach_GotFocus(object sender, System.EventArgs e)
        {
            lstLedger.ValueMember = "strLedgerName";
            lstLedger.DisplayMember = "strLedgerName";
            lstLedger.DataSource = accms.mFillLedger(mintGrouptype, "", mstrdrcr).ToList();
            lstLedger.SelectedIndex = lstLedger.FindString(txtSerach.Text);
        }
        private void txtSerach_TextChanged(object sender, EventArgs e)
        {
            lstLedger.SelectedIndex = lstLedger.FindString(txtSerach.Text);
        }

        private void lstLedger_DoubleClick(object sender, EventArgs e)
        {
            txtSerach.Text = lstLedger.Text;
           // txtCashFlowType.Focus();
        }

        private void txtSerach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstLedger.Items.Count > 0)
                {
                    txtSerach.Text = lstLedger.Text;
                }
                if (onAddAllButtonClicked != null)
                    onAddAllButtonClicked(GetSelectedItem(), sender, e);
                this.Dispose();

            }
        }
        private List<AccountsLedger> GetSelectedItem()
        {
            List<AccountsLedger> items = new List<AccountsLedger>();
            AccountsLedger itm = new AccountsLedger();
            itm.strLedgerName = txtSerach.Text.ToString();
            items.Add(itm);
            return items;
        }
        private void txtSerach_KeyDown(object sender, KeyEventArgs e)
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

            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {
                frmAccountsLedger objfrm = new frmAccountsLedger();
                objfrm.m_acction = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.mSingleEntry = 1;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }


        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            txtSerach.Focus();
            txtSerach.Select();
            
        }
    }
}
