using Dutility;
using JA.Modulecontrolar.JACCMS;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace JA.Modulecontrolar.UI.Accms.Forms
{
    public partial class frmBankReconcilation : JA.Shared.UI.frmSmartFormStandard
    {
        JA.Modulecontrolar.JACCMS.SWJAGClient accms = new SWJAGClient();
        private string strComID { get; set; }
        private ListBox lstLedgerName = new ListBox();
        public frmBankReconcilation()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            #region "Ini"
            this.uctxtLedgerName.KeyDown += new KeyEventHandler(uctxtLedgerName_KeyDown);
            this.uctxtLedgerName.TextChanged += new System.EventHandler(this.uctxtLedgerName_TextChanged);
            this.uctxtLedgerName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uctxtLedgerName_KeyPress);
            this.uctxtLedgerName.GotFocus += new System.EventHandler(this.uctxtLedgerName_GotFocus);
            this.lstLedgerName.DoubleClick += new System.EventHandler(this.lstLedgerName_DoubleClick);
            
            this.dteFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dteFromDate_KeyPress);
            this.dteToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dteToDate_KeyPress);
            this.dteFromDate.GotFocus += new System.EventHandler(this.dteFromDate_GotFocus);
            this.dteToDate.GotFocus += new System.EventHandler(this.dteToDate_GotFocus);


            Utility.CreateListBoxHeight(lstLedgerName, pnlMain, uctxtLedgerName, 0, 200);
            #endregion
        }
        #region "User Define Event"
        private void dteToDate_GotFocus(object sender, System.EventArgs e)
        {

            lstLedgerName.Visible = false;

        }
        private void dteFromDate_GotFocus(object sender, System.EventArgs e)
        {

            lstLedgerName.Visible = false;
          
        }
        private void lstLedgerName_DoubleClick(object sender, EventArgs e)
        {

            uctxtLedgerName.Text = lstLedgerName.Text;
            lstLedgerName.Visible = false;
            dteFromDate.Focus();
        }
        private void uctxtLedgerName_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtLedgerName.Text = lstLedgerName.Text;
                dteFromDate.Focus();
            }
        }
        private void uctxtLedgerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstLedgerName.SelectedItem != null)
                {
                    lstLedgerName.SelectedIndex = lstLedgerName.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstLedgerName.Items.Count - 1 > lstLedgerName.SelectedIndex)
                {
                    lstLedgerName.SelectedIndex = lstLedgerName.SelectedIndex + 1;
                }
            }

        }
        private void uctxtLedgerName_GotFocus(object sender, System.EventArgs e)
        {

            lstLedgerName.Visible = true;
            lstLedgerName.SelectedIndex = lstLedgerName.FindString(uctxtLedgerName.Text);
        }
        private void uctxtLedgerName_TextChanged(object sender, EventArgs e)
        {
            lstLedgerName.SelectedIndex = lstLedgerName.FindString(uctxtLedgerName.Text);
        }
        #endregion
        #region "Grid"
        private DataGridViewTextBoxColumn Create_Grid_Column(string pname, string htext, int cwidth, Boolean true_false, DataGridViewContentAlignment Align,
                                                            Boolean read_only)
        {
            DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
            col0.DataPropertyName = pname;
            col0.HeaderText = htext;
            col0.DefaultCellStyle.ForeColor = Color.Black;
            col0.DefaultCellStyle.BackColor = Color.White;
            col0.Visible = true_false;
            col0.DefaultCellStyle.Alignment = Align;
            col0.Width = cwidth;
            col0.ReadOnly = read_only;
            return col0;
        }
        private void GetLedgerInformation(string strControl)
        {
            lstLedgerName.ValueMember = "strLedgerName";
            lstLedgerName.DisplayMember = "strLedgerName";
            lstLedgerName.DataSource = accms.mGetBankLedger(strComID).ToList();
        }
        private void grid_column()
        {
            DG.Columns.Add(Create_Grid_Column("VoucherKey", "VoucherKey", 0, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Create_Grid_Column("Date", "Date", 100, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Create_Grid_Column("Ref. NO", "Ref. NO", 0, false, DataGridViewContentAlignment.TopLeft, false));
            DG.Columns.Add(Create_Grid_Column("Particulars", "Particulars", 210, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Create_Grid_Column("To & by", "To & by", 90, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Create_Grid_Column("Voucher Type", "Voucher Type", 0, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Create_Grid_Column("Voucher Name", "Voucher Name", 100, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Create_Grid_Column("Checque No", "Checque No", 100, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Create_Grid_Column("Checque Date", "Checque Date", 100, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Create_Grid_Column("Bank Date", "Bank Date", 100, true, DataGridViewContentAlignment.TopLeft, false));
            DG.Columns.Add(Create_Grid_Column("Deposit", "Deposit", 115, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Create_Grid_Column("Withdrawl", "Withdrawl", 115, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Create_Grid_Column("Bank Charge(%)", "Bank Charge(%)", 110, true, DataGridViewContentAlignment.TopCenter,false));
            DG.Columns.Add(Create_Grid_Column("Bank Charge Amount", "Bank Charge Amount", 130, true, DataGridViewContentAlignment.TopCenter, true));
        }
        private void frmBankReconcilation_Load(object sender, EventArgs e)
        {
            uctxtLedgerName.Focus();
            uctxtLedgerName.Select();
            grid_column();
            GetLedgerInformation("Ledger");
        }
        #endregion
        #region "Rfresh"
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            int i = 0;
            double dblNotReflectCredit = 0, dblTotalDebit = 0, dblNotReflectDebit = 0, dblTotalCredit = 0, dblCompanyBalanceDebit = 0, dblCompanyBalanceCredit=0;
            try
            {
                DG.Rows.Clear();
                uctxtNotBankDebit.Text = "0";
                uctxtCreditTotal.Text = "0";
                lblBankCharge.Text = "0";
                uctxtNotBankDebit.Text = "0";
                uctxtNotBankCredit.Text = "0";
                List<AccountsVoucher> objbank = accms.mDisplayBankReconcilation(strComID, lstLedgerName.SelectedValue.ToString(), dteFromDate.Text, dteToDate.Text).ToList();
                if (objbank.Count > 0)
                {
                    
                    foreach (AccountsVoucher oobjBank in objbank)
                    {
                        DG.Rows.Add();
                        DG.Rows[i].Cells[0].Value = oobjBank.strMerzeName.ToString();
                        DG.Rows[i].Cells[1].Value = oobjBank.strTranDate.ToString();
                        DG.Rows[i].Cells[2].Value = oobjBank.strVoucherNo.ToString();
                        DG.Rows[i].Cells[3].Value = oobjBank.strLedgerName.ToString();
                        DG.Rows[i].Cells[4].Value = oobjBank.strToby;
                        DG.Rows[i].Cells[5].Value = oobjBank.intvoucherPos;
                        if (oobjBank.intvoucherPos == 1)
                        {
                            DG.Rows[i].Cells[6].Value = "Payment";
                        }
                        else if (oobjBank.intvoucherPos == 2)
                        {
                            DG.Rows[i].Cells[6].Value = "Receipt";
                        }
                        else if (oobjBank.intvoucherPos == 3)
                        {
                            DG.Rows[i].Cells[6].Value = "Jounal";
                        }
                        else if (oobjBank.intvoucherPos == 4)
                        {
                            DG.Rows[i].Cells[6].Value = "Contra";
                        }

                        DG.Rows[i].Cells[7].Value = oobjBank.strChequeNo ;
                        DG.Rows[i].Cells[8].Value = oobjBank.strChequeDate ;
                        DG.Rows[i].Cells[9].Value = oobjBank.strBankdate;
                        DG.Rows[i].Cells[10].Value = oobjBank.dblDebitAmount ;
                        dblTotalDebit = dblTotalDebit + oobjBank.dblDebitAmount;
                        DG.Rows[i].Cells[11].Value = oobjBank.dblCreditAmount;
                        dblTotalCredit = dblTotalCredit + oobjBank.dblCreditAmount;
                        dblNotReflectDebit = dblNotReflectDebit + Convert.ToDouble(oobjBank.dblDebitAmount);
                        dblNotReflectCredit = dblNotReflectCredit + Convert.ToDouble(oobjBank.dblCreditAmount);

                        DG.Rows[i].Cells[12].Value = oobjBank.strBankPer ;
                        DG.Rows[i].Cells[13].Value = oobjBank.dblBankChargeAmnt;
                        if (oobjBank.strStatus.Trim().ToUpper() =="Y")
                        {
                            chkPosted.Checked = true;
                        }
                        //if ((DG.Rows[i].Cells[12].Value.ToString() !="" || DG.Rows[i].Cells[12].Value.ToString()  != "0"))
                        //{
                        //    DG.Rows[i].Cells[13].Value = Math.Round(Convert.ToDouble(objBank.DebitAmount) * Convert.ToDouble(DG.Rows[i].Cells[12].Value) / 100, 2);
                        //}

                        
                        i = i + 1;
                    }

                    if (dblTotalDebit > dblTotalCredit)
                    {
                        dblCompanyBalanceDebit = dblTotalDebit - dblTotalCredit;
                        uctxtDebitTotal.Text = dblCompanyBalanceDebit.ToString();
                    }
                    if (dblTotalCredit > dblTotalDebit)
                    {
                        dblCompanyBalanceCredit = dblTotalCredit - dblTotalDebit;
                        uctxtCreditTotal.Text = dblCompanyBalanceCredit.ToString();
                    }
                    if (dblNotReflectDebit > 0)
                    {
                        uctxtNotBankDebit.Text = dblNotReflectDebit.ToString();
                    }
                    if (dblNotReflectCredit > 0)
                    {
                        uctxtNotBankCredit.Text = dblNotReflectCredit.ToString();
                    }
                    DG.Rows[1].Cells[12].Selected = true;

                }
            }

            catch (System.ServiceModel.CommunicationException commp)
            {
                //MessageBox.Show(Utility.CommunicationErrorMsg, Utility.MessageCaptionMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show(commp.ToString());
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }
        #endregion
        #region "Keypress"
        private void cboLedgerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==(char) Keys.Return)
            {
                dteFromDate.Focus();
            }
        }
        private void dteFromDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==(char) Keys.Return)
            {
                dteToDate.Focus();
            }
        }
        private void dteToDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==(char) Keys.Return)
            {
                btnRefresh.Focus();
            }
        }
        #endregion
        #region "Save"
        private void btnSave_Click(object sender, EventArgs e)
        {

            string strRefNo = "", strRefKey = "", strBankDate = "", strSave = "";
            double dblBankChargePer = 0, dblBankcharge = 0, dblBankchargeAmount = 0, dblChildAmount = 0;
            if (uctxtLedgerName.Text == "")
            {
                MessageBox.Show("LedgerName Cannot be Empty");
                uctxtLedgerName.Focus();
                return;
            }
           
            for (int intRow = 0; intRow < DG.Rows.Count - 1; intRow++)
            {
                if (DG.Rows[intRow].Cells[12].Value.ToString() != null)
                {
                    dblBankChargePer = Convert.ToDouble(DG.Rows[intRow].Cells[12].Value.ToString());
                    if (DG.Rows[intRow].Cells[13].Value.ToString() == null)
                    {
                        MessageBox.Show("Bank Charge Amount Mismatch");
                        return;
                    }
                }
            }


            var strResponse = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (strResponse == DialogResult.Yes)
            {
       
                for (int intRow = 0; intRow < DG.Rows.Count - 1; intRow++)
                {

                    strRefKey = DG.Rows[intRow].Cells[0].Value.ToString();
                    strRefNo = DG.Rows[intRow].Cells[1].Value.ToString();
                    strBankDate = DG.Rows[intRow].Cells[1].Value.ToString();

                    if (DG.Rows[intRow].Cells[12].Value.ToString() != null)
                    {
                        dblBankChargePer = Convert.ToDouble(DG.Rows[intRow].Cells[12].Value.ToString());
                    }
                    else
                    {
                        dblBankChargePer = 0;
                    }

                    dblBankcharge = Convert.ToDouble(DG.Rows[intRow].Cells[13].Value);
                    dblBankchargeAmount = dblChildAmount - dblBankcharge;

                    strSave = accms.mUpdateBankReconcilation(strComID, strRefKey, strRefNo, strBankDate, dblBankChargePer.ToString(), dblBankchargeAmount);
                    if (strSave !="1")
                    {
                        MessageBox.Show(strSave);
                        return;
                    }
                }

                MessageBox.Show("Inserted Successfully...");
                //else if (i > 0)
                //{
                //    if (Convert.ToDouble(lblBankCharge.Text) > 0 || chkPosted.Checked == true)
                //    {
                //        string strPostDate = "";
                //        strPostDate = DateTime.Now.ToString("dd/MM/yyyy");
                //        k = accmSc.InsertIntegretedBr(strRefNo.ToString(), Convert.ToDouble(lblBankCharge.Text), 1, strPostDate,
                //                strBrLCode, "0000266", "", 7, objBank);// Integredted with Accounts  s
                //    }

                btnNew.PerformClick();
                lstLedgerName.Focus();
                DG.Rows.Clear();
                uctxtDebitTotal.Text = "0";
                uctxtNotBankDebit.Text = "0";
                uctxtCreditTotal.Text = "0";
                uctxtNotBankCredit.Text = "0";
                lblBankCharge.Text = "0";
                chkPosted.Checked = false;
            }
        }
        #endregion
        #region "Cell End Edit"
        private void DG_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            double dblNetBankCharges = 0;
            try
            {
                for (int i = 0; i < DG.Rows.Count - 1; i++)
                {
                    if ((DG.Rows[i].Cells[12].Value.ToString() != "" || DG.Rows[i].Cells[12].Value.ToString() != "0"))
                    {

                        DG.Rows[i].Cells[13].Value = Math.Round(Convert.ToDouble(DG.Rows[i].Cells[10].Value.ToString()) * Convert.ToDouble(DG.Rows[i].Cells[12].Value.ToString()) / 100, 2);
                        dblNetBankCharges = dblNetBankCharges + Convert.ToDouble(DG.Rows[i].Cells[13].Value);
                    }
                    else
                    {
                        DG.Rows[i].Cells[13].Value = 0;
                    }

                }


                lblBankCharge.Text = Math.Round(dblNetBankCharges, 2).ToString();
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.ToString());
            }

        }
        #endregion
    }
}
