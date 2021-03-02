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
using JA.Modulecontrolar.JINVMS;
using Microsoft.Win32;
namespace JA.Modulecontrolar.UI.Accms.Forms
{
    public partial class frmAccountsVoucherMR : JA.Shared.UI.frmSmartFormStandard
    {
        private ListBox lstCashBankLedger = new ListBox();
        private ListBox lstOthersLedger = new ListBox();
        private ListBox lstBranch = new ListBox();
        private ListBox lstMedicalRep = new ListBox();
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public long lngFormPriv { get; set; }
        public int lngLedgeras { get; set; }
        private bool mblnNumbMethod { get; set; }
        public int intvtype { get; set; }
        public int m_action { get; set; }
        public int intsp { get; set; }
        List<Invoice> ooPartyName;
        List<Invoice> ooCustomer;
        private string strComID { get; set; }
        public frmAccountsVoucherMR()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.uctxtVoucherNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtVoucherNo_KeyPress);
            this.dteVoucherDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteVoucherDate_KeyPress);
            this.dteVoucherDate.GotFocus += new System.EventHandler(this.dteVoucherDate_GotFocus);

            this.uctxtOtherLedger.KeyDown += new KeyEventHandler(uctxtOtherLedger_KeyDown);
            this.uctxtOtherLedger.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtOtherLedger_KeyPress);
            this.lstOthersLedger.DoubleClick += new System.EventHandler(this.lstOthersLedger_DoubleClick);
            this.uctxtOtherLedger.GotFocus += new System.EventHandler(this.uctxtOtherLedger_GotFocus);

            this.uctxtBranch.KeyDown += new KeyEventHandler(uctxtBranch_KeyDown);
            this.uctxtBranch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranch_KeyPress);
            this.uctxtBranch.TextChanged += new System.EventHandler(this.uctxtBranch_TextChanged);
            this.lstBranch.DoubleClick += new System.EventHandler(this.lstBranch_DoubleClick);
            this.uctxtBranch.GotFocus += new System.EventHandler(this.uctxtBranch_GotFocus);

            this.uctxtCashBankLedger.KeyDown += new KeyEventHandler(uctxtCashBankLedger_KeyDown);
            this.uctxtCashBankLedger.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtCashBankLedger_KeyPress);
            this.uctxtCashBankLedger.TextChanged += new System.EventHandler(this.uctxtCashBankLedger_TextChanged);
            this.lstCashBankLedger.DoubleClick += new System.EventHandler(this.lstCashBankLedger_DoubleClick);
            this.uctxtCashBankLedger.GotFocus += new System.EventHandler(this.uctxtCashBankLedger_GotFocus);
            
            this.uctxtMedicalRep.KeyDown += new KeyEventHandler(uctxtMedicalRep_KeyDown);
            this.uctxtMedicalRep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtMedicalRep_KeyPress);
            
            this.uctxtDebitAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtDebitAmount_KeyPress);
            this.uctxtDebitAmount.GotFocus += new System.EventHandler(this.uctxtDebitAmount_GotFocus);

            this.uctxtMedicalRep.GotFocus += new System.EventHandler(this.uctxtMedicalRep_GotFocus);
            this.uctxtMedicalRep.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uctxtMedicalRep_KeyUp);
            
            this.DGMr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(DGMr_KeyPress);
            this.DGMr.DoubleClick += new System.EventHandler(this.DGMr_DoubleClick);

            this.uctxtBranch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranch_KeyPress);
            this.txtNarr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtNarr_KeyPress);
            this.DG.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DG_KeyDown);

            this.uctxtCustomer.KeyDown += new KeyEventHandler(uctxtCustomer_KeyDown);
            this.uctxtCustomer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtCustomer_KeyPress);
            this.uctxtCustomer.TextChanged += new System.EventHandler(this.uctxtCustomer_TextChanged);
            
            this.uctxtCustomer.GotFocus += new System.EventHandler(this.uctxtCustomer_GotFocus);
            this.DGcustomer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(DGcustomer_KeyPress);
            this.DGcustomer.DoubleClick += new System.EventHandler(this.DGcustomer_DoubleClick);

            this.uctxCustomerAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxCustomerAmount_KeyPress);
            this.uctxCustomerAmount.GotFocus += new System.EventHandler(this.uctxCustomerAmount_GotFocus);

            this.uctxtOtherAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtOtherAmount_KeyPress);
            this.uctxtOtherAmount.GotFocus += new System.EventHandler(this.uctxtOtherAmount_GotFocus);

            this.DGMr.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGMr_CellFormatting);
            this.DGcustomer.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGcustomer_CellFormatting);

            Utility.CreateListBox(lstBranch, pnlMain, uctxtBranch);
            Utility.CreateListBox(lstCashBankLedger, pnlMain, uctxtCashBankLedger);
            Utility.CreateListBox(lstOthersLedger, pnlMain, uctxtOtherLedger);
        }
        #region "User define"
        private void DG_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double dblAmnt = 0, dblAmount1 = 0;
            if (e.ColumnIndex == 2)
            {
                if (DG[1, e.RowIndex].Value != null)
                {
                    dblAmnt = Convert.ToDouble(DG[1, e.RowIndex].Value.ToString());
                }
                else
                {
                    dblAmnt = dblAmnt;
                }
                if (DG[2, e.RowIndex].Value != null)
                {
                    dblAmount1 = Convert.ToDouble(DG[2, e.RowIndex].Value.ToString());
                }
                else
                {
                    dblAmount1 = dblAmount1;
                }
                if (dblAmnt > 0)
                {
                    DG[2, e.RowIndex].Value = DG[4, e.RowIndex].Value;

                }
                else
                {
                    DG[3, e.RowIndex].Value = dblAmount1;
                    DG[4, e.RowIndex].Value = dblAmount1;
                }

            }
            calculateTotal();

        }
        private void dteVoucherDate_GotFocus(object sender, System.EventArgs e)
        {
            lstOthersLedger.Visible = false;
            lstBranch.Visible = false;
            DGMr.Visible = false;
        }

        private void txtNarr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnSave.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(txtNarr, uctxtMedicalRep);
            }
        }

        private void uctxtMedicalRep_TextChanged(object sender, EventArgs e)
        {
            //lstMedicalRep.SelectedIndex = lstMedicalRep.FindString(uctxtMedicalRep.Text);
        }
        private void uctxtMedicalRep_GotFocus(object sender, System.EventArgs e)
        {
            lstBranch.Visible = false;
            DGcustomer.Visible = false;



        }
        private void lstMedicalRep_DoubleClick(object sender, EventArgs e)
        {
            uctxtMedicalRep.Text = lstMedicalRep.Text;
            lstMedicalRep.Visible = false;
            uctxtDebitAmount.Focus();
        }
        private void uctxtMedicalRep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtMedicalRep.Text == "")
                {
                    uctxtDebitAmount.Focus();
                    DGMr.Visible = false;

                    return;
                }


                if (uctxtMedicalRep.Text != "")
                {
                    DGMr.Focus();
                    if (DGMr.Rows.Count > 0)
                    {
                        int i = 0;
                        uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                        uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                        uctxtMedicalRep.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                        DGMr.Visible = false;
                        uctxtDebitAmount.Focus();
                    }
                }
                else
                {
                    int i = 0;

                    uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                    uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                    uctxtMedicalRep.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                    DGMr.Visible = false;
                    uctxtDebitAmount.Focus();
                }
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtMedicalRep, uctxtBranch);
            }


        }
        private void uctxtMedicalRep_KeyDown(object sender, KeyEventArgs e)
        {
            DGMr.Visible = true;
            if (e.KeyCode == Keys.Up)
            {
                DGMr.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                DGMr.Focus();
            }

            DGMr.Top = uctxtMedicalRep.Top + 25;
            DGMr.Left = uctxtMedicalRep.Left;
            DGMr.Width = uctxtMedicalRep.Width;
            DGMr.Height = 240;
            DGMr.BringToFront();
            DGMr.AllowUserToAddRows = false;
            return;

        }



        private void dteVoucherDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtBranch.Focus();
            }
        }
        private void uctxtVoucherNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dteVoucherDate.Focus();
            }
        }
        private void uctxtBranch_TextChanged(object sender, EventArgs e)
        {
            lstBranch.SelectedIndex = lstBranch.FindString(uctxtBranch.Text);
        }

        private void lstBranch_DoubleClick(object sender, EventArgs e)
        {
            uctxtBranch.Text = lstBranch.Text;
            uctxtMedicalRep.Focus();
            if (uctxtBranch.Text != "")
            {
                mloadParty(lstBranch.SelectedValue.ToString());
            }
            lstBranch.Visible = false;
        }

        private void uctxtBranch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBranch.Items.Count > 0)
                {
                    uctxtBranch.Text = lstBranch.Text;
                    uctxtMedicalRep.Focus();
                    lstBranch.Visible = false;
                    if (uctxtBranch.Text != "")
                    {
                        mloadParty(lstBranch.SelectedValue.ToString());
                    }
                }

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtBranch, sender, e);
            }


        }
        private void uctxtBranch_KeyDown(object sender, KeyEventArgs e)
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

        private void uctxtBranch_GotFocus(object sender, System.EventArgs e)
        {
            lstBranch.Visible = true;
            //lstUnder.Visible = false;

            lstBranch.SelectedIndex = lstBranch.FindString(uctxtBranch.Text);
        }
       
        private void DGMr_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DGMr.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Yellow;
            DGMr.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            DGMr.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("verdana", 9);
        }
        private void DGcustomer_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DGcustomer.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Yellow;
            DGcustomer.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            DGcustomer.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("verdana", 9);
        }
        private void uctxtDebitAmount_GotFocus(object sender, System.EventArgs e)
        {
             
            lstBranch.Visible = false;
            lstMedicalRep.Visible = false;
            lstCashBankLedger.Visible = false;
            lstOthersLedger.Visible = false;
            DGcustomer.Visible = false;
            DGMr.Visible = false;

        }
        private void uctxtOtherAmount_GotFocus(object sender, System.EventArgs e)
        {
            lstBranch.Visible = false;
            lstMedicalRep.Visible = false;
            lstCashBankLedger.Visible = false;
            lstOthersLedger.Visible = false;
            DGcustomer.Visible = false;
            DGMr.Visible = false;
          
        }
        private void uctxtOtherAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                mAdditemLedgerBill("", uctxtOtherLedger.Text, "", Utility.Val(uctxtOtherAmount.Text));
                uctxtCustomer.Text = "";
                txtCustomerCode.Text = "";
                txtHomoeoHall.Text = "";
                uctxtOtherAmount.Text = "";
                uctxtOtherLedger.Text = "";
                calculateTotal();
                if (Utility.Val(txtDebitTotal.Text) == Utility.Val(uctxtGridTotal.Text))
                {
                    txtCreditTotal.Text = txtDebitTotal.Text;
                    uctxtCashBankLedger.Focus();
                }
                else
                {
                    uctxtCustomer.Focus();
                }
            }
        }
        private void lstOthersLedger_DoubleClick(object sender, EventArgs e)
        {
            lstOthersLedger.SelectedIndex = lstBranch.FindString(uctxtOtherLedger.Text);
        }


        private void uctxtOtherLedger_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstOthersLedger.SelectedItem != null)
                {
                    lstOthersLedger.SelectedIndex = lstOthersLedger.SelectedIndex - 1;
                    uctxtOtherLedger.Text = lstOthersLedger.Text;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstOthersLedger.Items.Count - 1 > lstOthersLedger.SelectedIndex)
                {
                    lstOthersLedger.SelectedIndex = lstOthersLedger.SelectedIndex + 1;
                    uctxtOtherLedger.Text = lstOthersLedger.Text;
                }
            }

        }
        private void uctxCustomerAmount_GotFocus(object sender, System.EventArgs e)
        {
             
            lstOthersLedger.Visible = false ;
            
            lstBranch.Visible = false;
            lstCashBankLedger.Visible = false;
            lstMedicalRep.Visible = false;
            DGcustomer.Visible = false;
            DGMr.Visible = false;
            
        }
        private void uctxtOtherLedger_GotFocus(object sender, System.EventArgs e)
        {
            lstOthersLedger.Visible = true;
            lstBranch.Visible = false;
            lstCashBankLedger.Visible = false;
            lstMedicalRep.Visible = false;
            DGcustomer.Visible = false;
            DGMr.Visible = false;
        }
        private void uctxtOtherLedger_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtOtherLedger.Text != "")
                {
                    if (lstOthersLedger.Items.Count > 0)
                    {
                        uctxtOtherLedger.Text = lstOthersLedger.Text;
                    }
                }
                uctxtOtherAmount.Focus();
            }
        }
        private void lstCashBankLedger_DoubleClick(object sender, EventArgs e)
        {
            uctxtCashBankLedger.Text = lstCashBankLedger.Text;
            lstBranch.SelectedIndex = lstBranch.FindString(uctxtBranch.Text);
        }

        private void uctxtCashBankLedger_TextChanged(object sender, EventArgs e)
        {
            lstCashBankLedger.SelectedIndex = lstCashBankLedger.FindString(uctxtCashBankLedger.Text);
           
        }

        private void uctxtCashBankLedger_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstCashBankLedger.Items.Count > 0)
                {
                    uctxtCashBankLedger.Text = lstCashBankLedger.Text;
                    txtNarr.Focus();
                    lstCashBankLedger.Visible = false;
                  
                }

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtBranch, sender, e);
            }


        }
        private void uctxtCashBankLedger_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstCashBankLedger.SelectedItem != null)
                {
                    lstCashBankLedger.SelectedIndex = lstCashBankLedger.SelectedIndex - 1;
                    uctxtCashBankLedger.Text = lstCashBankLedger.Text;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstCashBankLedger.Items.Count - 1 > lstCashBankLedger.SelectedIndex)
                {
                    lstCashBankLedger.SelectedIndex = lstCashBankLedger.SelectedIndex + 1;
                    uctxtCashBankLedger.Text = lstCashBankLedger.Text;
                }
            }

        }

        private void uctxtCashBankLedger_GotFocus(object sender, System.EventArgs e)
        {
            lstBranch.Visible = false;
            lstMedicalRep.Visible = false;
            lstCashBankLedger.Visible = true;
            lstOthersLedger.Visible = false;
            DGcustomer.Visible = false;
            DGMr.Visible = false;
            lstCashBankLedger.SelectedIndex = lstCashBankLedger.FindString(uctxtCashBankLedger.Text);
        }
        private void uctxCustomerAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                mAdditemLedgerBill(txtCustomerCode.Text, uctxtCustomer.Text, txtHomoeoHall.Text, Utility.Val(uctxCustomerAmount.Text));
                uctxtCustomer.Text = "";
                txtCustomerCode.Text = "";
                txtHomoeoHall.Text = "";
                uctxCustomerAmount.Text = "";
                calculateTotal();
                uctxtOtherLedger.Focus();
            }
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
        private void DGcustomer_DoubleClick(object sender, EventArgs e)
        {
            //DateTime firstDay = Convert.ToDateTime(DateTime.Parse(month + ", 1 " + year, CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"));
            //DateTime lastDay = Convert.ToDateTime(firstDay.AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy"));
            //int LastDay = lastDay.Day;


            if (DGMr.SelectedRows.Count > 0)
            {
                int i = Convert.ToInt16(DGcustomer.CurrentRow.Index.ToString());
                txtCustomerCode.Text = DGcustomer.Rows[i].Cells[0].Value.ToString();
                uctxtCustomer.Text = DGcustomer.Rows[i].Cells[1].Value.ToString();
                txtHomoeoHall.Text = DGcustomer.Rows[i].Cells[2].Value.ToString();

                DGcustomer.Visible = false;
                uctxCustomerAmount.Focus();


            }
        }
        private void DGcustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                //uctxtPartyName.Text = Utility.GetDgValue(DGMr, uctxtPartyName, 0);
                int i = Convert.ToInt16(DGcustomer.CurrentRow.Index.ToString());
                txtCustomerCode.Text = DGcustomer.Rows[i].Cells[0].Value.ToString();
                uctxtCustomer.Text = DGcustomer.Rows[i].Cells[1].Value.ToString();
                txtHomoeoHall.Text = DGcustomer.Rows[i].Cells[2].Value.ToString();

                DGcustomer.Visible = false;
                uctxCustomerAmount.Focus();
            }
        }
        private void uctxtCustomer_TextChanged(object sender, EventArgs e)
        {
            if (uctxtCustomer.Text == "")
            {
                txtCustomerCode.Text = "";
                txtHomoeoHall.Text = "";
            }
        }
        private void uctxtCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtCustomer.Text == "" || uctxtCustomer.Text == Utility.gcEND_OF_LIST)
                {
                    uctxtCustomer.Text = "";
                    DGcustomer.Visible = false;
                    uctxCustomerAmount.Focus();
                    return;
                }


                if (uctxtCustomer.Text != "")
                {
                    DGcustomer.Focus();
                    if (DGcustomer.Rows.Count > 0)
                    {
                        int i = 0;
                        txtCustomerCode.Text = DGcustomer.Rows[i].Cells[0].Value.ToString();
                        uctxtCustomer.Text = DGcustomer.Rows[i].Cells[1].Value.ToString();
                        txtHomoeoHall.Text = DGcustomer.Rows[i].Cells[2].Value.ToString();
                        DGcustomer.Visible = false;
                        uctxCustomerAmount.Focus();
                    }
                }
                else
                {
                    if (DGcustomer.Rows.Count > 0)
                    {
                        int i = 0;

                        txtCustomerCode.Text = DGcustomer.Rows[i].Cells[0].Value.ToString();
                        uctxtCustomer.Text = DGcustomer.Rows[i].Cells[1].Value.ToString();
                        txtHomoeoHall.Text = DGcustomer.Rows[i].Cells[2].Value.ToString();
                        DGcustomer.Visible = false;
                    }
                    else
                    {
                        txtCustomerCode.Text = "";
                        uctxtCustomer.Text = "End of List";
                        txtHomoeoHall.Text = "";
                    }
                    uctxCustomerAmount.Focus();
                }
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtCustomer, sender, e);
            }
        }
        private void uctxtCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            DGcustomer.Visible = true;
            if (e.KeyCode == Keys.Up)
            {
                DGcustomer.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                DGcustomer.Focus();
            }

            DGcustomer.Top = uctxtCustomer.Top + 25;
            DGcustomer.Left = uctxtCustomer.Left;
            DGcustomer.Width = uctxtCustomer.Width;
            DGcustomer.Height = 200;
            DGcustomer.BringToFront();
            DGcustomer.AllowUserToAddRows = false;
            return;


        }
        private void uctxtDebitAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxCustomerAmount.Text = uctxtDebitAmount.Text;
                uctxtCustomer.Focus();
            }
        }
        private void uctxtCustomer_GotFocus(object sender, System.EventArgs e)
        {
            lstBranch.Visible = false;
            DGMr.Visible = false;
            DGcustomer.Visible = false;
            if (uctxtMedicalRep.Text != "")
            {
                mloadCustomer();
            }
        }
        private void DG_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                e.SuppressKeyPress = true;
                int iColumn = DG.CurrentCell.ColumnIndex;
                int iRow = DG.CurrentCell.RowIndex;
                if (iRow == DG.Rows.Count - 1)
                    txtNarr.Focus();
                else
                    DG.CurrentCell = DG[iColumn, iRow+1];


            }
        }
        private void mloadParty(string strBranchName)
        {
            int introw = 0;
            string strBranchID = "";
            strBranchID = lstBranch.SelectedValue.ToString();
            DGMr.Rows.Clear();

            ooPartyName = invms.mfillPartyNameNew(strComID, "", Utility.gblnAccessControl, Utility.gstrUserName, 0, "","").ToList();

            if (ooPartyName.Count > 0)
            {

                foreach (Invoice ogrp in ooPartyName)
                {
                    DGMr.Rows.Add();
                    DGMr.Columns[1].Visible = true;
                    DGMr.Columns[0].Visible = true;
                    DGMr[0, introw].Value = ogrp.strTeritorryCode;
                    DGMr[1, introw].Value = ogrp.strTeritorryName;
                    DGMr[2, introw].Value = ogrp.strLedgerName;
                    DGMr[3, introw].Value = ogrp.strMereString;
                    //if (introw % 2 == 0)
                    //{
                    //    DGMr.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    DGMr.Rows[introw].DefaultCellStyle.BackColor = Color.White;
                    //}
                    introw += 1;
                }

                DGMr.AllowUserToAddRows = false;
            }
        }

        #endregion
        #region "Getconfig"
        private void DGMr_DoubleClick(object sender, EventArgs e)
        {

            if (DGMr.SelectedRows.Count > 0)
            {
                int i = Convert.ToInt16(DGMr.CurrentRow.Index.ToString());
                uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                uctxtMedicalRep.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                DGMr.Visible = false;
                //if (btnCommission.Enabled)
                //{
                uctxtDebitAmount.Focus();
                //}


            }
        }
        private void DGMr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                int i = Convert.ToInt16(DGMr.CurrentRow.Index.ToString());
                uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                uctxtMedicalRep.Text = DGMr.Rows[i].Cells[2].Value.ToString();

                DGMr.Visible = false;
                //if (btnCommission.Enabled)
                //{
                uctxtDebitAmount.Focus();
                //}
            }
        }
        private void uctxtMedicalRep_KeyUp(object sender, KeyEventArgs e)
        {
           
                SearchListViewPartyName(ooPartyName, uctxtMedicalRep.Text);
           
        }

        private void SearchListViewPartyName(IEnumerable<Invoice> tests, string searchString = "")
        {
            IEnumerable<Invoice> query;
            query = tests;
            if (searchString != "")
            {
                query = tests.Where(x => x.strMereString.ToLower().Trim().Contains(searchString.ToLower().Trim()));
            }

            DGMr.Rows.Clear();
            int i = 0;
            try
            {
                foreach (Invoice tran in query)
                {
                    DGMr.Rows.Add();
                    DGMr[0, i].Value = tran.strTeritorryCode;
                    DGMr[1, i].Value = tran.strTeritorryName;
                    DGMr[2, i].Value = tran.strLedgerName;
                    DGMr[3, i].Value = tran.strMereString;
                    //if (i % 2 == 0)
                    //{
                    //    DGMr.Rows[i].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    DGMr.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    //}
                    i += 1;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void mGetConfig()
        {
            List<VoucherTypes> ooVtype = accms.mGetConfig(strComID, 1).ToList();
            if (ooVtype.Count > 0)
            {
                if (ooVtype[0].intVoucherNoMethod == 0)
                {
                    mblnNumbMethod = true;
                }
                else
                {
                    mblnNumbMethod = false;
                }
                // mintIsPrin = ooVtype[0].intVoucherNoMethod;
            }

        }
        #endregion
        #region "Load"
        private void frmCommission_Load(object sender, EventArgs e)
        {
            DG.AllowUserToAddRows = false;
            mGetConfig();
            mClear();
            DG.Columns.Clear();
            DG.Columns.Add(Utility.Create_Grid_Column("CP Code", "CP Code", 150, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Doctor/Customer Name", "Doctor/Customer Name", 300, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("CP Name", "CP Name", 250, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Net Amount", "Net Amount", 110, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));
        

            lstBranch.ValueMember = "BranchID";
            lstBranch.DisplayMember = "BranchName";
            lstBranch.DataSource = accms.mFillBranch(strComID,Utility.gblnAccessControl, Utility.gstrUserName).ToList();

            lstCashBankLedger.DisplayMember = "strLedgerName";
            lstCashBankLedger.ValueMember = "strLedgerName";
            lstCashBankLedger.DataSource = accms.mFillLedger(strComID, 1, "", "Dr",Utility.gstrUserName).ToList();

            lstOthersLedger.ValueMember = "strLedgerName";
            lstOthersLedger.DisplayMember = "strLedgerName";
            lstOthersLedger.DataSource = accms.mFillLedger(strComID, 2, "", "Dr", Utility.gstrUserName).ToList();

            lstBranch.Visible = false;
            lstMedicalRep.Visible = false;
            lstOthersLedger.Visible = false;
            lstCashBankLedger.Visible = false;
            //mloadParty();
            dteVoucherDate.Select();
            dteVoucherDate.Focus();
            
        }
        #endregion
        #region "PriorSetFocus"
        private void PriorSetFocusText(TextBox txtbox, object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Back)
            {
                if (txtbox.SelectionLength > 0)
                {
                    txtbox.SelectionLength = 0;

                    this.SelectNextControl((Control)sender, false, true, true, true);
                }
                else
                {
                    if ((e.KeyChar == (char)Keys.Back) & (((Control)sender).Text.Length == 0))
                    {

                        this.SelectNextControl((Control)sender, false, true, true, true);
                    }
                }
            }


        }
        #endregion
        #region "Additem"
        private void mAdditemLedgerBill(string strcustomercode, string strcustomerName, string strHomeoHall, double dblnetamount)
        {
            int selRaw;

            string strDown = "";
            Boolean blngCheck = false;
            try
            {
                if (strcustomerName == "")
                {
                    return;
                }
                for (int j = 0; j < DG.RowCount; j++)
                {
                    if (DG[0, j].Value != null)
                    {
                        strDown = DG[0, j].Value.ToString();
                    }
                    if (strcustomerName == DG.ToString())
                    {
                        blngCheck = true;
                    }

                }
                if (blngCheck == false)
                {

                    DG.AllowUserToAddRows = true;
                    selRaw = Convert.ToInt16(DG.RowCount.ToString());
                    selRaw = selRaw - 1;
                    DG.Rows.Add();


                    DG[0, selRaw].Value = strcustomercode;
                    DG[1, selRaw].Value = strcustomerName;
                    DG[2, selRaw].Value = strHomeoHall;
                    DG[3, selRaw].Value = dblnetamount;
                    DG[4, selRaw].Value = "Delete";
                    DG.AllowUserToAddRows = false;



                }

                calculateTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion
        #region "Load Cistomer"
        private void mloadCustomer()
        {
            int introw = 0;
            DGcustomer.Rows.Clear();

            ooCustomer = invms.mFillSalesRepFromMPoNew1(strComID, (long)Utility.GR_GROUP_TYPE.grSALES_REP, uctxtMedicalRep.Text).ToList();

            if (ooCustomer.Count > 0)
            {

                foreach (Invoice ogrp in ooCustomer)
                {
                    DGcustomer.Rows.Add();
                    DGcustomer[0, introw].Value = ogrp.strTeritorryCode;
                    DGcustomer[1, introw].Value = ogrp.strLedgerName;
                    DGcustomer[2, introw].Value = ogrp.strTeritorryName;

                    DGcustomer[3, introw].Value = ogrp.strMereString;
                    //if (introw % 2 == 0)
                    //{
                    //    DGcustomer.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    DGcustomer.Rows[introw].DefaultCellStyle.BackColor = Color.White;
                    //}
                    introw += 1;
                }

                DGcustomer.AllowUserToAddRows = false;
            }
        }
        #endregion
      
        #region "Display Voucher"
        private void DisplayVoucherList(List<AccountsVoucher> tests, object sender, EventArgs e)
        {
            try
            {
                int introw = 0;
                string strteritorryCode = "";
                m_action = (int)Utility.ACTION_MODE_ENUM.EDIT_MODE;
                DG.Rows.Clear();
                uctxtOldNo.Text = tests[0].strVoucherNo;
                List<AccountsVoucher> ooaccVou = accms.DisplayCompVoucherList(strComID, tests[0].strVoucherNo, intvtype).ToList();
                if (ooaccVou.Count > 0)
                {
                    foreach (AccountsVoucher oCom in ooaccVou)
                    {
                        uctxtVoucherNo.Text = Utility.Mid(oCom.strVoucherNo, 6, oCom.strVoucherNo.Length - 6);
                        dteVoucherDate.Text = oCom.strTranDate;
                        uctxtBranch.Text = Utility.gstrGetBranchName(strComID, oCom.strBranchID);
                        txtNarr.Text = oCom.strNarration;
                        uctxtMedicalRep.Text =oCom.strLedgerName;
                        strteritorryCode = Utility.GetTeritorryCodeFromLedgerName(strComID, oCom.strLedgerName);
                        uctxtTerritoryCode.Text = strteritorryCode;
                        uctxtTeritorryName.Text = Utility.GetTeritorryName(strComID, strteritorryCode);
                        uctxtDebitAmount.Text = oCom.dblNetAmount.ToString();
                        txtCreditTotal.Text = oCom.dblNetAmount.ToString();
                        uctxtCashBankLedger.Text = Utility.GetstrReverseLegder(strComID, tests[0].strVoucherNo);
                        txtCashDrcr.Text = "Dr";
                        List<VectorCategory> ooVouList = accms.DisplayVectorList(strComID, tests[0].strVoucherNo).ToList();
                        if (ooVouList.Count > 0)
                        {

                            foreach (VectorCategory oacc in ooVouList)
                            {
                                DG.Rows.Add();
                                DG[0, introw].Value = Utility.GetCPCodeFromLedgerName(strComID, oacc.accountsLedger.strLedgerName);
                                DG[1, introw].Value = oacc.accountsLedger.strLedgerName;
                                DG[2, introw].Value = Utility.GetCPNameFromLedgerName(strComID, oacc.accountsLedger.strLedgerName);
                                DG[3, introw].Value = oacc.dblAmount;
                                DG[4, introw].Value = "Delete";
                                introw += 1;
                            }
                            DG.AllowUserToAddRows = false;
                            
                        }
                        introw = 0;
                       
                        calculateTotal();

                    }
                }


            }
                
            catch (Exception ex)
            {

            }
        }
        #endregion
        #region "Calculatetotal
        private void calculateTotal()
        {
            double dblTotalAmount = 0;

            for (int i = 0; i < DG.Rows.Count; i++)
            {
                if (DG.Rows[i].Cells[3].Value != null)
                {
                    
                    dblTotalAmount = dblTotalAmount + Utility.Val(DG.Rows[i].Cells[3].Value.ToString());
                }
            }

            uctxtGridTotal.Text = dblTotalAmount.ToString();
            txtDebitTotal.Text = uctxtDebitAmount.Text.ToString();
            //txtCreditTotal.Text = dblTotalAmount.ToString();
            uctxCustomerAmount.Text =(Utility.Val(uctxtDebitAmount.Text) - dblTotalAmount).ToString();
            uctxtOtherAmount.Text = (Utility.Val(uctxtDebitAmount.Text) - dblTotalAmount).ToString();

        }
        #endregion
        #region "Clear"
        private void mClear()
        {
            DG.Rows.Clear();
            txtDrCr.Text = "Cr";
            txtCashDrcr.Text = "Dr";
            uctxtCashBankLedger.Text = "";
            uctxtGridTotal.Text = "";
            txtCreditTotal.Text = "";
            uctxtMedicalRep.Text = "";
            txtNarr.Text = "";
            uctxtTeritorryName.Text = "";
            uctxtTerritoryCode.Text = "";
            txtDebitTotal.Text = "";
            if (mblnNumbMethod)
            {
                uctxtVoucherNo.ReadOnly = true;
                uctxtVoucherNo.Text = Utility.gstrLastNumber(strComID, intvtype);
            }
            else
            {
                uctxtVoucherNo.ReadOnly = false;
                uctxtVoucherNo.Text = Utility.gobjNextNumber(uctxtVoucherNo.Text);
            }
            if (uctxtVoucherNo.ReadOnly==false)
            {
                uctxtVoucherNo.Focus();
            }
            else
            {
                dteVoucherDate.Focus();
            }
        }
        #endregion
        #region "Populate Grid"
        private string PopulatedGrid(string vstrRefNumber)
        {
            string  strDrCr = "", strLedgerName = "",  strVoucherGrid = "";
            double dbldebitAmount = 0;
            for (int intvrow = 0; intvrow < DG.Rows.Count; intvrow++)
            {
                try
                {
                    if (DG.Rows[intvrow].Cells[2].Value != null)
                    {
                        strDrCr = "Cr";
                        strLedgerName = DG[1, intvrow].Value.ToString();

                        dbldebitAmount = Convert.ToDouble(DG[3, intvrow].Value.ToString());

                        strVoucherGrid = strVoucherGrid + strDrCr + "|" + strLedgerName
                                                      + "|" + dbldebitAmount + "~";



                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            return strVoucherGrid;
        }
        #endregion
        #region "Save/Update"
        private string mSave()
        {
            string  strDGvoucher, strRefNumber = "", strBranchID = "", strNarration = "", strReverseLedger = "",  strLedgerName = "", strVdate, strMonthID;
            int intLedgerCount;
           
            strBranchID = Utility.gstrGetBranchID(strComID, uctxtBranch.Text);
            strNarration = txtNarr.Text.Replace("'", "''");

            if (mblnNumbMethod == false)
            {
                strRefNumber = gobjVoucherName.VoucherName.GetVoucherString(intvtype) + strBranchID + uctxtVoucherNo.Text;
            }
            else
            {
                strRefNumber = gobjVoucherName.VoucherName.GetVoucherString(intvtype) + strBranchID + Utility.gstrLastNumber(strComID, intvtype);
            }

            strVdate = dteVoucherDate.Text;
            strMonthID = dteVoucherDate.Value.ToString("MMMyy").ToUpper();
            intLedgerCount = DG.Rows.Count;
            strLedgerName = uctxtMedicalRep.Text;
            strReverseLedger = uctxtCashBankLedger.Text;
            strDGvoucher = PopulatedGrid(strRefNumber);
            string i = accms.SaveReceiptVoucherCustomer(strComID, "Cr", strRefNumber, intvtype, strVdate, strMonthID, strVdate, strLedgerName, strReverseLedger, 1,
                                                    Convert.ToDouble(txtDebitTotal.Text), "", "", "", Convert.ToDouble(txtDebitTotal.Text), 
                                                    Convert.ToDouble(txtCreditTotal.Text), txtNarr.Text,strBranchID , strDGvoucher, mblnNumbMethod,intsp);

             return i;
           


           
        }
        private string mUpdate()
        {
            string strRefNumber = "", strBranchID = "", strNarration = "", strReverseLedger = "",  strLedgerName = "", strVdate, strMonthID, strDGvoucher;
            int intLedgerCount;
           
            strBranchID = Utility.gstrGetBranchID(strComID, uctxtBranch.Text);
            strNarration = txtNarr.Text.Replace("'", "''");

            strVdate = dteVoucherDate.Text;
            strMonthID = dteVoucherDate.Value.ToString("MMMyy").ToUpper();
            intLedgerCount = DG.Rows.Count;
            strLedgerName = uctxtMedicalRep.Text;
            strReverseLedger = uctxtCashBankLedger.Text;
            strDGvoucher = PopulatedGrid(strRefNumber);
            string i = accms.UpdateReceiptVoucherCustomer(strComID, "Cr", uctxtOldNo.Text, intvtype, strVdate, strMonthID, strVdate, strLedgerName, strReverseLedger, 1,
                                                     Convert.ToDouble(txtDebitTotal.Text), "", "", "", Convert.ToDouble(txtDebitTotal.Text),
                                                     Convert.ToDouble(txtCreditTotal.Text), txtNarr.Text, strBranchID, strDGvoucher, mblnNumbMethod, intsp);

            return i;
            
        }
        #endregion
        #region "Click"
        private void btnNew_Click(object sender, EventArgs e)
        {
            mClear();
            frmAccountsVoucherList objfrm = new frmAccountsVoucherList();
            objfrm.mintVType = intvtype;
            objfrm.mintSp = intsp;
            objfrm.onAddAllButtonClicked = new frmAccountsVoucherList.AddAllClick(DisplayVoucherList);
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.Show();
            objfrm.MdiParent = this.MdiParent;
            dteVoucherDate.Focus();

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Utility.Val(txtDebitTotal.Text) != Utility.Val(txtCreditTotal.Text))
            {
                MessageBox.Show("Amount is Mismatch");
                uctxtDebitAmount.Focus();
                return;
            }


            if (uctxtMedicalRep.Text == "")
            {
                MessageBox.Show("Cannot be empty");
                uctxtMedicalRep.Focus();
                return;
            }
            if (uctxtBranch.Text == "")
            {
                MessageBox.Show("Cannot be empty");
                uctxtBranch.Focus();
                return;
            }
            if (Utility.gblnAccessControl)
            {
                if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, m_action))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            string strbranchID = Utility.gstrGetBranchID(strComID, uctxtBranch.Text);
            if (m_action ==(int)Utility.ACTION_MODE_ENUM.ADD_MODE)
            {
                string s = mSave();
                if (s=="1")
                {
                    if (Utility.gblnAccessControl)
                    {
                        
                        string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, dteVoucherDate.Text, "Commission Configuration", uctxtVoucherNo.Text,
                                                                1, 0, (int)Utility.MODULE_TYPE.mtACCOUNT, strbranchID);
                    } 
                    mClear();
                }
            }
            else
            {
                string k = mUpdate();
                if (k == "1")
                {
                    if (Utility.gblnAccessControl)
                    {
                        string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, dteVoucherDate.Text, "Commission Configuration", uctxtVoucherNo.Text,
                                                                2, 0, (int)Utility.MODULE_TYPE.mtACCOUNT, strbranchID);
                    } 
                    mClear();
                }
            }
          

        }

        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==4)
            {
                DG.Rows.RemoveAt(e.RowIndex);
                calculateTotal();
            }
        }
        #endregion
        #region "Keyup"
        private void uctxtCustomer_KeyUp(object sender, KeyEventArgs e)
        {
            SearchListViewCustomerName(ooCustomer, uctxtCustomer.Text);

        }
        #endregion
        private void SearchListViewCustomerName(IEnumerable<Invoice> tests, string searchString = "")
        {
            IEnumerable<Invoice> query;
            if (tests == null)
            {
                return;
            }
            query = tests;

            if (searchString != "")
            {
                query = tests.Where(x => x.strMereString.ToLower().Trim().Contains(searchString.ToLower().Trim()));
            }
            DGcustomer.Rows.Clear();
            int i = 0;
            try
            {
                foreach (Invoice tran in query)
                {
                    DGcustomer.Rows.Add();
                    DGcustomer[0, i].Value = tran.strTeritorryCode;
                    DGcustomer[2, i].Value = tran.strTeritorryName;
                    DGcustomer[1, i].Value = tran.strLedgerName;
                    DGcustomer[3, i].Value = tran.strMereString;
                    //if (i % 2 == 0)
                    //{
                    //    DGcustomer.Rows[i].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    DGcustomer.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    //}
                    i += 1;
                }


            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
       





    }



}