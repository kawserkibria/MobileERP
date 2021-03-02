using Dutility;
using JA.Modulecontrolar.JACCMS;
using JA.Modulecontrolar.UI.DReport.Accms.ParameterForms;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
//using Mayhedi.Office.Excel.Reader;
using System.Runtime.InteropServices;



namespace JA.Modulecontrolar.UI.Accms.Forms
{
    public partial class frmAutoBkash : JA.Shared.UI.frmSmartFormStandard
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
        SPWOIS objWois = new SPWOIS();
        private ListBox lstLedgerList = new ListBox();
        private string strComID { get; set; }
        public int intvtype { get; set; }
        public frmAutoBkash()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.uctxtLedgerName.GotFocus += new System.EventHandler(this.uctxtLedgerName_GotFocus);
            this.lstLedgerList.DoubleClick += new System.EventHandler(this.lstLedgerList_DoubleClick);
            this.uctxtLedgerName.KeyDown += new KeyEventHandler(uctxtLedgerName_KeyDown);
            this.uctxtLedgerName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtLedgerName_KeyPress);
            this.uctxtLedgerName.TextChanged += new System.EventHandler(this.uctxtLedgerName_TextChanged);

            Utility.CreateListBox(lstLedgerList, pnlMain, uctxtLedgerName);
        }
        #region "User Define"
        private void uctxtLedgerName_TextChanged(object sender, EventArgs e)
        {
            lstLedgerList.SelectedIndex = lstLedgerList.FindString(uctxtLedgerName.Text);
        }

        private void lstLedgerList_DoubleClick(object sender, EventArgs e)
        {
            uctxtLedgerName.Text = lstLedgerList.Text;
            lstLedgerList.Visible = false;
            btnImport.Focus();
        }
        private void uctxtLedgerName_GotFocus(object sender, System.EventArgs e)
        {
            lstLedgerList.Visible = true;
          

        }
        private void uctxtLedgerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstLedgerList.SelectedItem != null)
                {
                    lstLedgerList.SelectedIndex = lstLedgerList.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstLedgerList.Items.Count - 1 > lstLedgerList.SelectedIndex)
                {
                    lstLedgerList.SelectedIndex = lstLedgerList.SelectedIndex + 1;
                }
            }

        }
        private void uctxtLedgerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstLedgerList.Items.Count > 0)
                {
                    uctxtLedgerName.Text = lstLedgerList.Text;
                }
                lstLedgerList.Visible = false;
                btnImport.Focus();

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
        private void cboGeneral_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtLedgerName.Focus();
            }
        }

        #endregion
        #region "Click"
        private void btnReplacement_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["frmAutoReplacement"] as frmAutoReplacement == null)
            {
                frmAutoReplacement objfrm = new frmAutoReplacement();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;


            }
            else
            {
                frmAutoReplacement objfrm = (frmAutoReplacement)Application.OpenForms["frmAutoReplacement"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string strBranchID = "", strRefNumber = "", strSQL = "", strMainLegder = "", strLedger1 = "", strLedger2 = "",
                strMonthID, vstrNarration = "", strReverseLedger = "", strBillWiseRef = "", strTcCode = "",strSalesLedger="";
            string strDate = "",strTransactionID="";
            int intLoanTransfer = 2, intvoucherPosition = 1;
            double dblAmount = 0, dblCreditAmount = 0, dblDebitAmount = 0, dblcharge = 0;
            if (uctxtLedgerName.Text =="")
            {
                MessageBox.Show("Bank Ledger Cannot be Empty");
                uctxtLedgerName.Focus();
                return;
            }
           
            strSalesLedger = uctxtLedgerName.Text;

            if (cboGeneral.Text == "General")
            {
                intLoanTransfer = 1;
            }
            else
            {
                intLoanTransfer = 2;
            }
              var strResponse = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
              if (strResponse == DialogResult.Yes)
              {
                  string connstring = Utility.SQLConnstringComSwitch(strComID);
                  progressBar1.Value = 0;
                  strBranchID = "0001";
                  try
                  {

                      for (int i = 1; i < dataGridView1.Rows.Count; i++)
                      {
                          if (dataGridView1.Rows[i].Cells[1].Value != null)
                          {
                              if (dataGridView1.Rows[i].Cells[3].Value != null)
                              {
                                  strTcCode = dataGridView1.Rows[i].Cells[3].Value.ToString().PadLeft(3, '0');
                                  string strt = dataGridView1.Rows[i].Cells[2].Value.ToString();
                                  dblAmount = Convert.ToDouble(Utility.Val(dataGridView1.Rows[i].Cells[4].Value.ToString()));
                                  strTransactionID = Utility.checkBkashTransactionID(strComID, dataGridView1.Rows[i].Cells[2].Value.ToString());
                                  if (strTransactionID != "")
                                  {
                                      MessageBox.Show(strTransactionID);
                                      return;
                                  }
                              }
                              else
                              {
                                  strTcCode = "";
                              }

                              strMainLegder = Utility.GetLedgerNameFromTeritorryCode(strComID, strTcCode);
                              if (strMainLegder == "")
                              {
                                  MessageBox.Show("Sorry! TC Not found " + strTcCode + "Transaction ID: " + dataGridView1.Rows[i].Cells[3].Value);
                                  return;
                              }
                              if (dblAmount == 0)
                              {
                                  MessageBox.Show("Sorry! Amount Not found TC Code: " + strTcCode + "Transaction ID: " + dataGridView1.Rows[i].Cells[3].Value);
                                  return;
                              }
                          }
                      }



                      progressBar1.Maximum = dataGridView1.Rows.Count;
                      for (int i = 1; i < dataGridView1.Rows.Count; i++)
                      {
                          if (dataGridView1.Rows[i].Cells[3].Value != null)
                          {
                              double smsDate = Convert.ToDouble(dataGridView1.Rows[i].Cells[0].Value);
                              dblAmount = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                              vstrNarration = dataGridView1.Rows[i].Cells[1].Value + "-" + dataGridView1.Rows[i].Cells[2].Value;
                              strTcCode = dataGridView1.Rows[i].Cells[3].Value.ToString().PadLeft(3, '0');
                              strMonthID = DateTime.FromOADate(smsDate).ToString("MMMyy");
                              strDate = DateTime.FromOADate(smsDate).ToString("dd-MM-yyyy");

                              strMainLegder = Utility.GetLedgerNameFromTeritorryCode(strComID, strTcCode);
                              strRefNumber = gobjVoucherName.VoucherName.GetVoucherString(intvtype) + strBranchID + Utility.gstrLastNumber(strComID, intvtype);
                              //Bkash Charge (L)
                              using (SqlConnection gcnMain = new SqlConnection(connstring))
                              {
                                  if (gcnMain.State == ConnectionState.Open)
                                  {
                                      gcnMain.Close();
                                  }

                                  gcnMain.Open();

                                  SqlCommand cmdInsert = new SqlCommand();
                                  SqlTransaction myTrans;
                                  myTrans = gcnMain.BeginTransaction();
                                  cmdInsert.Connection = gcnMain;
                                  cmdInsert.Transaction = myTrans;
                                  if (intLoanTransfer == 2)
                                  {
                                      //if (Utility.gbcheckBkashLedger(strComID, strMainLegder))
                                      if (Utility.gbcheckBkashEffec(strComID, intvtype))
                                      {
                                          if (Utility.gbcheckBkashLedger(strComID, strMainLegder))
                                          {
                                              dblCreditAmount = Math.Round(dblAmount, 2);
                                              dblcharge = Math.Round((dblCreditAmount * 1.5) / 100, 2);
                                              dblDebitAmount = Math.Round(dblCreditAmount, 2);
                                              strSQL = "INSERT INTO ACC_COMPANY_VOUCHER(";
                                              strSQL = strSQL + "COMP_REF_NO,BRANCH_ID,LEDGER_NAME,COMP_VOUCHER_TYPE,COMP_VOUCHER_DATE,COMP_VOUCHER_DUE_DATE,COMP_VOUCHER_MONTH_ID ";
                                              strSQL = strSQL + ",COMP_VOUCHER_AMOUNT,COMP_VOUCHER_NET_AMOUNT,COMP_VOUCHER_NARRATION)";
                                              strSQL = strSQL + "VALUES(";
                                              strSQL = strSQL + "'" + strRefNumber + "' ";
                                              strSQL = strSQL + ",'" + strBranchID.Replace("'", "''") + "' ";
                                              strSQL = strSQL + ",'" + strMainLegder.Replace("'", "''") + "' ";
                                              strSQL = strSQL + "," + intvtype + " ";
                                              strSQL = strSQL + "," + Utility.cvtSQLDateString(strDate) + " ";
                                              strSQL = strSQL + "," + Utility.cvtSQLDateString(strDate) + " ";
                                              strSQL = strSQL + ",'" + strMonthID.Replace("'", "''") + "' ";
                                              strSQL = strSQL + "," + dblDebitAmount + " ";
                                              strSQL = strSQL + "," + dblDebitAmount + " ";
                                              strSQL = strSQL + ",'" + vstrNarration.Replace("'", "''") + "' ";
                                              strSQL = strSQL + ")";
                                              cmdInsert.CommandText = strSQL;
                                              cmdInsert.ExecuteNonQuery();
                                              strReverseLedger = "As Per Details";
                                              strBillWiseRef = strRefNumber + intvoucherPosition.ToString("0000");
                                              dblCreditAmount = Math.Round(dblCreditAmount - dblcharge, 2);
                                              strSQL = "INSERT INTO ACC_VOUCHER";
                                              strSQL = strSQL + "(COMP_REF_NO,BRANCH_ID,VOUCHER_REF_KEY,COMP_VOUCHER_TYPE,";
                                              strSQL = strSQL + "COMP_VOUCHER_POSITION,COMP_VOUCHER_DATE,LEDGER_NAME,";
                                              strSQL = strSQL + "VOUCHER_DEBIT_AMOUNT,VOUCHER_CREDIT_AMOUNT,";
                                              strSQL = strSQL + "VOUCHER_TOBY,VOUCHER_REVERSE_LEDGER,TRANSFER_TYPE,VOUCHER_CASHFLOW ";
                                              strSQL = strSQL + ") VALUES(";
                                              strSQL = strSQL + "'" + strRefNumber + "'";
                                              strSQL = strSQL + ",'" + strBranchID.Replace("'", "''") + "' ";
                                              strSQL = strSQL + ",'" + strBillWiseRef + "' ";
                                              strSQL = strSQL + "," + intvtype + "";
                                              strSQL = strSQL + "," + intvoucherPosition + "";
                                              strSQL = strSQL + "," + Utility.cvtSQLDateString(strDate) + "";
                                              strSQL = strSQL + ",'" + strMainLegder.Replace("'", "''") + "' ";
                                              strSQL = strSQL + ",0 ";
                                              strSQL = strSQL + "," + dblCreditAmount + " ";
                                              strSQL = strSQL + ",'Cr'";
                                              strSQL = strSQL + ",'" + strReverseLedger.Replace("'", "''") + "' ";
                                              strSQL = strSQL + ",2";
                                              strSQL = strSQL + ",1";
                                              strSQL = strSQL + ")";
                                              cmdInsert.CommandText = strSQL;
                                              cmdInsert.ExecuteNonQuery();
                                              intvoucherPosition += 1;
                                              strBillWiseRef = strRefNumber + intvoucherPosition.ToString("0000");
                                              strLedger1 = "Bkash Charge (L)";
                                              strSQL = "INSERT INTO ACC_VOUCHER";
                                              strSQL = strSQL + "(COMP_REF_NO,BRANCH_ID,VOUCHER_REF_KEY,COMP_VOUCHER_TYPE,";
                                              strSQL = strSQL + "COMP_VOUCHER_POSITION,COMP_VOUCHER_DATE,LEDGER_NAME,";
                                              strSQL = strSQL + "VOUCHER_DEBIT_AMOUNT,VOUCHER_CREDIT_AMOUNT,";
                                              strSQL = strSQL + "VOUCHER_TOBY,VOUCHER_REVERSE_LEDGER,TRANSFER_TYPE,VOUCHER_CASHFLOW ";
                                              strSQL = strSQL + ") VALUES(";
                                              strSQL = strSQL + "'" + strRefNumber + "'";
                                              strSQL = strSQL + ",'" + strBranchID.Replace("'", "''") + "' ";
                                              strSQL = strSQL + ",'" + strBillWiseRef + "' ";
                                              strSQL = strSQL + "," + intvtype + "";
                                              strSQL = strSQL + "," + intvoucherPosition + "";
                                              strSQL = strSQL + "," + Utility.cvtSQLDateString(strDate) + "";
                                              strSQL = strSQL + ",'" + strLedger1.Replace("'", "''") + "' ";
                                              strSQL = strSQL + ",0 ";
                                              strSQL = strSQL + "," + dblcharge + " ";
                                              strSQL = strSQL + ",'Cr'";
                                              strSQL = strSQL + ",'" + strReverseLedger.Replace("'", "''") + "' ";
                                              strSQL = strSQL + ",2";
                                              strSQL = strSQL + ",1";
                                              strSQL = strSQL + ")";
                                              cmdInsert.CommandText = strSQL;
                                              cmdInsert.ExecuteNonQuery();
                                              intvoucherPosition += 1;
                                              strBillWiseRef = strRefNumber + intvoucherPosition.ToString("0000");
                                              strLedger2 = strSalesLedger;
                                              strSQL = "INSERT INTO ACC_VOUCHER";
                                              strSQL = strSQL + "(COMP_REF_NO,BRANCH_ID,VOUCHER_REF_KEY,COMP_VOUCHER_TYPE,";
                                              strSQL = strSQL + "COMP_VOUCHER_POSITION,COMP_VOUCHER_DATE,LEDGER_NAME,";
                                              strSQL = strSQL + "VOUCHER_DEBIT_AMOUNT,VOUCHER_CREDIT_AMOUNT,";
                                              strSQL = strSQL + "VOUCHER_TOBY,VOUCHER_REVERSE_LEDGER,TRANSFER_TYPE ";
                                              strSQL = strSQL + ") VALUES(";
                                              strSQL = strSQL + "'" + strRefNumber + "'";
                                              strSQL = strSQL + ",'" + strBranchID.Replace("'", "''") + "' ";
                                              strSQL = strSQL + ",'" + strBillWiseRef + "' ";
                                              strSQL = strSQL + "," + intvtype + "";
                                              strSQL = strSQL + "," + intvoucherPosition + "";
                                              strSQL = strSQL + "," + Utility.cvtSQLDateString(strDate) + "";
                                              strSQL = strSQL + ",'" + strLedger2.Replace("'", "''") + "' ";
                                              strSQL = strSQL + "," + dblDebitAmount + " ";
                                              strSQL = strSQL + ",0 ";
                                              strSQL = strSQL + ",'Dr'";
                                              strSQL = strSQL + ",'" + strReverseLedger.Replace("'", "''") + "' ";
                                              strSQL = strSQL + ",2";
                                              strSQL = strSQL + ")";
                                              cmdInsert.CommandText = strSQL;
                                              cmdInsert.ExecuteNonQuery();
                                              strSQL = "UPDATE ACC_VOUCHER_TYPE ";
                                              strSQL = strSQL + "SET VOUCHER_TYPE_TOTAL_VOUCHER = VOUCHER_TYPE_TOTAL_VOUCHER + 1 ";
                                              strSQL = strSQL + "WHERE VOUCHER_TYPE_VALUE = " + intvtype + " ";
                                              cmdInsert.CommandText = strSQL;
                                              cmdInsert.ExecuteNonQuery();
                                          }
                                          else
                                          {

                                              dblDebitAmount = Math.Round(dblAmount, 2);
                                              dblcharge = Math.Round((dblDebitAmount * 1.5) / 100, 2);
                                              dblCreditAmount = Math.Round(dblDebitAmount, 2);
                                              strSQL = "INSERT INTO ACC_COMPANY_VOUCHER(";
                                              strSQL = strSQL + "COMP_REF_NO,BRANCH_ID,LEDGER_NAME,COMP_VOUCHER_TYPE,COMP_VOUCHER_DATE,COMP_VOUCHER_DUE_DATE,COMP_VOUCHER_MONTH_ID ";
                                              strSQL = strSQL + ",COMP_VOUCHER_AMOUNT,COMP_VOUCHER_NET_AMOUNT,COMP_VOUCHER_NARRATION)";
                                              strSQL = strSQL + "VALUES(";
                                              strSQL = strSQL + "'" + strRefNumber + "' ";
                                              strSQL = strSQL + ",'" + strBranchID.Replace("'", "''") + "' ";
                                              strSQL = strSQL + ",'" + strMainLegder.Replace("'", "''") + "' ";
                                              strSQL = strSQL + "," + intvtype + " ";
                                              strSQL = strSQL + "," + Utility.cvtSQLDateString(strDate) + " ";
                                              strSQL = strSQL + "," + Utility.cvtSQLDateString(strDate) + " ";
                                              strSQL = strSQL + ",'" + strMonthID.Replace("'", "''") + "' ";
                                              strSQL = strSQL + "," + dblCreditAmount + " ";
                                              strSQL = strSQL + "," + dblCreditAmount + " ";
                                              strSQL = strSQL + ",'" + vstrNarration.Replace("'", "''") + "' ";
                                              strSQL = strSQL + ")";
                                              cmdInsert.CommandText = strSQL;
                                              cmdInsert.ExecuteNonQuery();
                                              strReverseLedger = "As Per Details";
                                              strBillWiseRef = strRefNumber + intvoucherPosition.ToString("0000");
                                              strSQL = "INSERT INTO ACC_VOUCHER";
                                              strSQL = strSQL + "(COMP_REF_NO,BRANCH_ID,VOUCHER_REF_KEY,COMP_VOUCHER_TYPE,";
                                              strSQL = strSQL + "COMP_VOUCHER_POSITION,COMP_VOUCHER_DATE,LEDGER_NAME,";
                                              strSQL = strSQL + "VOUCHER_DEBIT_AMOUNT,VOUCHER_CREDIT_AMOUNT,";
                                              strSQL = strSQL + "VOUCHER_TOBY,VOUCHER_REVERSE_LEDGER,TRANSFER_TYPE,VOUCHER_CASHFLOW";
                                              strSQL = strSQL + ") VALUES(";
                                              strSQL = strSQL + "'" + strRefNumber + "'";
                                              strSQL = strSQL + ",'" + strBranchID.Replace("'", "''") + "' ";
                                              strSQL = strSQL + ",'" + strBillWiseRef + "' ";
                                              strSQL = strSQL + "," + intvtype + "";
                                              strSQL = strSQL + "," + intvoucherPosition + "";
                                              strSQL = strSQL + "," + Utility.cvtSQLDateString(strDate) + "";
                                              strSQL = strSQL + ",'" + strMainLegder.Replace("'", "''") + "' ";
                                              strSQL = strSQL + ",0 ";
                                              strSQL = strSQL + "," + dblCreditAmount + " ";
                                              strSQL = strSQL + ",'Cr'";
                                              strSQL = strSQL + ",'" + strReverseLedger.Replace("'", "''") + "' ";
                                              strSQL = strSQL + ",2";
                                              strSQL = strSQL + ",1";
                                              strSQL = strSQL + ")";
                                              cmdInsert.CommandText = strSQL;
                                              cmdInsert.ExecuteNonQuery();
                                              intvoucherPosition += 1;
                                              strBillWiseRef = strRefNumber + intvoucherPosition.ToString("0000");
                                              strLedger1 = "Bkash Charge (Exp.)";
                                              strSQL = "INSERT INTO ACC_VOUCHER";
                                              strSQL = strSQL + "(COMP_REF_NO,BRANCH_ID,VOUCHER_REF_KEY,COMP_VOUCHER_TYPE,";
                                              strSQL = strSQL + "COMP_VOUCHER_POSITION,COMP_VOUCHER_DATE,LEDGER_NAME,";
                                              strSQL = strSQL + "VOUCHER_DEBIT_AMOUNT,VOUCHER_CREDIT_AMOUNT,";
                                              strSQL = strSQL + "VOUCHER_TOBY,VOUCHER_REVERSE_LEDGER,TRANSFER_TYPE ";
                                              strSQL = strSQL + ") VALUES(";
                                              strSQL = strSQL + "'" + strRefNumber + "'";
                                              strSQL = strSQL + ",'" + strBranchID.Replace("'", "''") + "' ";
                                              strSQL = strSQL + ",'" + strBillWiseRef + "' ";
                                              strSQL = strSQL + "," + intvtype + "";
                                              strSQL = strSQL + "," + intvoucherPosition + "";
                                              strSQL = strSQL + "," + Utility.cvtSQLDateString(strDate) + "";
                                              strSQL = strSQL + ",'" + strLedger1.Replace("'", "''") + "' ";
                                              strSQL = strSQL + "," + dblcharge + " ";
                                              strSQL = strSQL + ",0 ";
                                              strSQL = strSQL + ",'Dr'";
                                              strSQL = strSQL + ",'" + strReverseLedger.Replace("'", "''") + "' ";
                                              strSQL = strSQL + ",2";
                                              strSQL = strSQL + ")";
                                              cmdInsert.CommandText = strSQL;
                                              cmdInsert.ExecuteNonQuery();
                                              intvoucherPosition += 1;
                                              strBillWiseRef = strRefNumber + intvoucherPosition.ToString("0000");
                                              strLedger2 = strSalesLedger;
                                              dblDebitAmount = Math.Round(dblDebitAmount - dblcharge, 2);
                                              strSQL = "INSERT INTO ACC_VOUCHER";
                                              strSQL = strSQL + "(COMP_REF_NO,BRANCH_ID,VOUCHER_REF_KEY,COMP_VOUCHER_TYPE,";
                                              strSQL = strSQL + "COMP_VOUCHER_POSITION,COMP_VOUCHER_DATE,LEDGER_NAME,";
                                              strSQL = strSQL + "VOUCHER_DEBIT_AMOUNT,VOUCHER_CREDIT_AMOUNT,";
                                              strSQL = strSQL + "VOUCHER_TOBY,VOUCHER_REVERSE_LEDGER,TRANSFER_TYPE ";
                                              strSQL = strSQL + ") VALUES(";
                                              strSQL = strSQL + "'" + strRefNumber + "'";
                                              strSQL = strSQL + ",'" + strBranchID.Replace("'", "''") + "' ";
                                              strSQL = strSQL + ",'" + strBillWiseRef + "' ";
                                              strSQL = strSQL + "," + intvtype + "";
                                              strSQL = strSQL + "," + intvoucherPosition + "";
                                              strSQL = strSQL + "," + Utility.cvtSQLDateString(strDate) + "";
                                              strSQL = strSQL + ",'" + strLedger2.Replace("'", "''") + "' ";
                                              strSQL = strSQL + "," + dblDebitAmount + " ";
                                              strSQL = strSQL + ",0 ";
                                              strSQL = strSQL + ",'Dr'";
                                              strSQL = strSQL + ",'" + strReverseLedger.Replace("'", "''") + "' ";
                                              strSQL = strSQL + ",2";
                                              strSQL = strSQL + ")";
                                              cmdInsert.CommandText = strSQL;
                                              cmdInsert.ExecuteNonQuery();
                                              strSQL = "UPDATE ACC_VOUCHER_TYPE ";
                                              strSQL = strSQL + "SET VOUCHER_TYPE_TOTAL_VOUCHER = VOUCHER_TYPE_TOTAL_VOUCHER + 1 ";
                                              strSQL = strSQL + "WHERE VOUCHER_TYPE_VALUE = " + intvtype + " ";
                                              cmdInsert.CommandText = strSQL;
                                              cmdInsert.ExecuteNonQuery();
                                          }

                                      }

                                      else
                                      {
                                          dblDebitAmount = Math.Round(dblAmount, 2);
                                          dblCreditAmount = Math.Round(dblAmount, 2);
                                          strSQL = "INSERT INTO ACC_COMPANY_VOUCHER(";
                                          strSQL = strSQL + "COMP_REF_NO,BRANCH_ID,LEDGER_NAME,COMP_VOUCHER_TYPE,COMP_VOUCHER_DATE,COMP_VOUCHER_DUE_DATE,COMP_VOUCHER_MONTH_ID ";
                                          strSQL = strSQL + ",COMP_VOUCHER_AMOUNT,COMP_VOUCHER_NET_AMOUNT,COMP_VOUCHER_NARRATION)";
                                          strSQL = strSQL + "VALUES(";
                                          strSQL = strSQL + "'" + strRefNumber + "' ";
                                          strSQL = strSQL + ",'" + strBranchID.Replace("'", "''") + "' ";
                                          strSQL = strSQL + ",'" + strMainLegder.Replace("'", "''") + "' ";
                                          strSQL = strSQL + "," + intvtype + " ";
                                          strSQL = strSQL + "," + Utility.cvtSQLDateString(strDate) + " ";
                                          strSQL = strSQL + "," + Utility.cvtSQLDateString(strDate) + " ";
                                          strSQL = strSQL + ",'" + strMonthID.Replace("'", "''") + "' ";
                                          strSQL = strSQL + "," + dblDebitAmount + " ";
                                          strSQL = strSQL + "," + dblDebitAmount + " ";
                                          strSQL = strSQL + ",'" + vstrNarration.Replace("'", "''") + "' ";
                                          strSQL = strSQL + ")";
                                          cmdInsert.CommandText = strSQL;
                                          cmdInsert.ExecuteNonQuery();
                                          strReverseLedger = uctxtLedgerName.Text;
                                          strBillWiseRef = strRefNumber + intvoucherPosition.ToString("0000");
                                          strSQL = "INSERT INTO ACC_VOUCHER";
                                          strSQL = strSQL + "(COMP_REF_NO,BRANCH_ID,VOUCHER_REF_KEY,COMP_VOUCHER_TYPE,";
                                          strSQL = strSQL + "COMP_VOUCHER_POSITION,COMP_VOUCHER_DATE,LEDGER_NAME,";
                                          strSQL = strSQL + "VOUCHER_DEBIT_AMOUNT,VOUCHER_CREDIT_AMOUNT,";
                                          strSQL = strSQL + "VOUCHER_TOBY,VOUCHER_REVERSE_LEDGER,TRANSFER_TYPE ";
                                          strSQL = strSQL + ") VALUES(";
                                          strSQL = strSQL + "'" + strRefNumber + "'";
                                          strSQL = strSQL + ",'" + strBranchID.Replace("'", "''") + "' ";
                                          strSQL = strSQL + ",'" + strBillWiseRef + "' ";
                                          strSQL = strSQL + "," + intvtype + "";
                                          strSQL = strSQL + "," + intvoucherPosition + "";
                                          strSQL = strSQL + "," + Utility.cvtSQLDateString(strDate) + "";
                                          strSQL = strSQL + ",'" + strMainLegder.Replace("'", "''") + "' ";
                                          strSQL = strSQL + ",0 ";
                                          strSQL = strSQL + "," + dblCreditAmount + " ";
                                          strSQL = strSQL + ",'Cr'";
                                          strSQL = strSQL + ",'" + strReverseLedger.Replace("'", "''") + "' ";
                                          strSQL = strSQL + ",1";
                                          strSQL = strSQL + ")";
                                          cmdInsert.CommandText = strSQL;
                                          cmdInsert.ExecuteNonQuery();
                                          intvoucherPosition += 1;
                                          strBillWiseRef = strRefNumber + intvoucherPosition.ToString("0000");
                                          //strMainLegder = strReverseLedger;
                                          //strReverseLedger = uctxtLedgerName.Text;

                                          strSQL = "INSERT INTO ACC_VOUCHER";
                                          strSQL = strSQL + "(COMP_REF_NO,BRANCH_ID,VOUCHER_REF_KEY,COMP_VOUCHER_TYPE,";
                                          strSQL = strSQL + "COMP_VOUCHER_POSITION,COMP_VOUCHER_DATE,LEDGER_NAME,";
                                          strSQL = strSQL + "VOUCHER_DEBIT_AMOUNT,VOUCHER_CREDIT_AMOUNT,";
                                          strSQL = strSQL + "VOUCHER_TOBY,VOUCHER_REVERSE_LEDGER,TRANSFER_TYPE,VOUCHER_CASHFLOW ";
                                          strSQL = strSQL + ") VALUES(";
                                          strSQL = strSQL + "'" + strRefNumber + "'";
                                          strSQL = strSQL + ",'" + strBranchID.Replace("'", "''") + "' ";
                                          strSQL = strSQL + ",'" + strBillWiseRef + "' ";
                                          strSQL = strSQL + "," + intvtype + "";
                                          strSQL = strSQL + "," + intvoucherPosition + "";
                                          strSQL = strSQL + "," + Utility.cvtSQLDateString(strDate) + "";
                                          strSQL = strSQL + ",'" + strReverseLedger.Replace("'", "''") + "' ";
                                          strSQL = strSQL + "," + dblDebitAmount + " ";
                                          strSQL = strSQL + ",0 ";
                                          strSQL = strSQL + ",'Dr'";
                                          strSQL = strSQL + ",'" + strMainLegder.Replace("'", "''") + "' ";
                                          strSQL = strSQL + ",1";
                                          strSQL = strSQL + ",1";
                                          strSQL = strSQL + ")";
                                          cmdInsert.CommandText = strSQL;
                                          cmdInsert.ExecuteNonQuery();
                                          strSQL = "UPDATE ACC_VOUCHER_TYPE ";
                                          strSQL = strSQL + "SET VOUCHER_TYPE_TOTAL_VOUCHER = VOUCHER_TYPE_TOTAL_VOUCHER + 1 ";
                                          strSQL = strSQL + "WHERE VOUCHER_TYPE_VALUE = " + intvtype + " ";
                                          cmdInsert.CommandText = strSQL;
                                          cmdInsert.ExecuteNonQuery();
                                      }
                                  }
                                  else
                                  {
                                      dblDebitAmount = Math.Round(dblAmount, 2);
                                      dblCreditAmount = Math.Round(dblAmount, 2);
                                      strSQL = "INSERT INTO ACC_COMPANY_VOUCHER(";
                                      strSQL = strSQL + "COMP_REF_NO,BRANCH_ID,LEDGER_NAME,COMP_VOUCHER_TYPE,COMP_VOUCHER_DATE,COMP_VOUCHER_DUE_DATE,COMP_VOUCHER_MONTH_ID ";
                                      strSQL = strSQL + ",COMP_VOUCHER_AMOUNT,COMP_VOUCHER_NET_AMOUNT,COMP_VOUCHER_NARRATION)";
                                      strSQL = strSQL + "VALUES(";
                                      strSQL = strSQL + "'" + strRefNumber + "' ";
                                      strSQL = strSQL + ",'" + strBranchID.Replace("'", "''") + "' ";
                                      strSQL = strSQL + ",'" + strMainLegder.Replace("'", "''") + "' ";
                                      strSQL = strSQL + "," + intvtype + " ";
                                      strSQL = strSQL + "," + Utility.cvtSQLDateString(strDate) + " ";
                                      strSQL = strSQL + "," + Utility.cvtSQLDateString(strDate) + " ";
                                      strSQL = strSQL + ",'" + strMonthID.Replace("'", "''") + "' ";
                                      strSQL = strSQL + "," + dblDebitAmount + " ";
                                      strSQL = strSQL + "," + dblDebitAmount + " ";
                                      strSQL = strSQL + ",'" + vstrNarration.Replace("'", "''") + "' ";
                                      strSQL = strSQL + ")";
                                      cmdInsert.CommandText = strSQL;
                                      cmdInsert.ExecuteNonQuery();
                                      strReverseLedger = uctxtLedgerName.Text;
                                      strBillWiseRef = strRefNumber + intvoucherPosition.ToString("0000");
                                      strSQL = "INSERT INTO ACC_VOUCHER";
                                      strSQL = strSQL + "(COMP_REF_NO,BRANCH_ID,VOUCHER_REF_KEY,COMP_VOUCHER_TYPE,";
                                      strSQL = strSQL + "COMP_VOUCHER_POSITION,COMP_VOUCHER_DATE,LEDGER_NAME,";
                                      strSQL = strSQL + "VOUCHER_DEBIT_AMOUNT,VOUCHER_CREDIT_AMOUNT,";
                                      strSQL = strSQL + "VOUCHER_TOBY,VOUCHER_REVERSE_LEDGER,TRANSFER_TYPE ";
                                      strSQL = strSQL + ") VALUES(";
                                      strSQL = strSQL + "'" + strRefNumber + "'";
                                      strSQL = strSQL + ",'" + strBranchID.Replace("'", "''") + "' ";
                                      strSQL = strSQL + ",'" + strBillWiseRef + "' ";
                                      strSQL = strSQL + "," + intvtype + "";
                                      strSQL = strSQL + "," + intvoucherPosition + "";
                                      strSQL = strSQL + "," + Utility.cvtSQLDateString(strDate) + "";
                                      strSQL = strSQL + ",'" + strMainLegder.Replace("'", "''") + "' ";
                                      strSQL = strSQL + ",0 ";
                                      strSQL = strSQL + "," + dblCreditAmount + " ";
                                      strSQL = strSQL + ",'Cr'";
                                      strSQL = strSQL + ",'" + strReverseLedger.Replace("'", "''") + "' ";
                                      strSQL = strSQL + ",1";
                                      strSQL = strSQL + ")";
                                      cmdInsert.CommandText = strSQL;
                                      cmdInsert.ExecuteNonQuery();
                                      intvoucherPosition += 1;
                                      strBillWiseRef = strRefNumber + intvoucherPosition.ToString("0000");
                                      //strMainLegder = strReverseLedger;
                                      //strReverseLedger = uctxtLedgerName.Text;

                                      strSQL = "INSERT INTO ACC_VOUCHER";
                                      strSQL = strSQL + "(COMP_REF_NO,BRANCH_ID,VOUCHER_REF_KEY,COMP_VOUCHER_TYPE,";
                                      strSQL = strSQL + "COMP_VOUCHER_POSITION,COMP_VOUCHER_DATE,LEDGER_NAME,";
                                      strSQL = strSQL + "VOUCHER_DEBIT_AMOUNT,VOUCHER_CREDIT_AMOUNT,";
                                      strSQL = strSQL + "VOUCHER_TOBY,VOUCHER_REVERSE_LEDGER,TRANSFER_TYPE,VOUCHER_CASHFLOW ";
                                      strSQL = strSQL + ") VALUES(";
                                      strSQL = strSQL + "'" + strRefNumber + "'";
                                      strSQL = strSQL + ",'" + strBranchID.Replace("'", "''") + "' ";
                                      strSQL = strSQL + ",'" + strBillWiseRef + "' ";
                                      strSQL = strSQL + "," + intvtype + "";
                                      strSQL = strSQL + "," + intvoucherPosition + "";
                                      strSQL = strSQL + "," + Utility.cvtSQLDateString(strDate) + "";
                                      strSQL = strSQL + ",'" + strReverseLedger.Replace("'", "''") + "' ";
                                      strSQL = strSQL + "," + dblDebitAmount + " ";
                                      strSQL = strSQL + ",0 ";
                                      strSQL = strSQL + ",'Dr'";
                                      strSQL = strSQL + ",'" + strMainLegder.Replace("'", "''") + "' ";
                                      strSQL = strSQL + ",1";
                                      strSQL = strSQL + ",1";
                                      strSQL = strSQL + ")";
                                      cmdInsert.CommandText = strSQL;
                                      cmdInsert.ExecuteNonQuery();
                                      strSQL = "UPDATE ACC_VOUCHER_TYPE ";
                                      strSQL = strSQL + "SET VOUCHER_TYPE_TOTAL_VOUCHER = VOUCHER_TYPE_TOTAL_VOUCHER + 1 ";
                                      strSQL = strSQL + "WHERE VOUCHER_TYPE_VALUE = " + intvtype + " ";
                                      cmdInsert.CommandText = strSQL;
                                      cmdInsert.ExecuteNonQuery();
                                  }
                                  cmdInsert.Transaction.Commit();
                              }

                              intvoucherPosition = 1;
                              strTcCode = "";
                              dblDebitAmount = 0;
                              dblCreditAmount = 0;
                              dblAmount = 0;
                          }
                          int percent = (int)(((double)(progressBar1.Value - progressBar1.Minimum) / (double)(progressBar1.Maximum - progressBar1.Minimum)) * 100);
                          progressBar1.Refresh();
                          using (Graphics gr = progressBar1.CreateGraphics())
                          {
                              gr.DrawString(percent.ToString() + "%", SystemFonts.DefaultFont, Brushes.Red, new PointF(progressBar1.Width / 2 - (gr.MeasureString(percent.ToString() + "%",
                                      SystemFonts.DefaultFont).Width / 2.0F), progressBar1.Height / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Height / 2.0F)));

                          }
                          progressBar1.Value += 1;
                      }
                      if (progressBar1.Value < 100)
                      {
                          progressBar1.Value += 1;
                      }
                      if (Utility.Val(lblTotal.Text) > 0)
                      {
                          if (Utility.gblnAccessControl)
                          {
                              string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, strDate, "Auto Bkash", "",
                                                                      1, Utility.Val(lblTotal.Text), (int)Utility.MODULE_TYPE.mtACCOUNT, "0001");
                          }
                      }
                      MessageBox.Show("Saved Successfully...");
                      dataGridView1.Rows.Clear();
                      progressBar1.Value = 0;
                      uctxtLedgerName.Text = "";
                      lblFileName.Text = "";
                      lblTotal.Text = "";
                      cboGeneral.Focus();
                  }

                  catch (Exception ex)
                  {
                      MessageBox.Show(strTcCode + "" + strDate + "" + strMainLegder + "" + ex.ToString());
                  }
              }



        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            string fname = "",strLedgerName="";
            strLedgerName = uctxtLedgerName.Text;
            OpenFileDialog fdlg = new OpenFileDialog();
            lblTotal.Text = "";
            fdlg.Title = "Excel File Dialog";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                fname = fdlg.FileName;
                lblFileName.Text = fname.ToString();
            }

            try
            {
                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(fname);
                Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                // dt.Column = colCount;  
                dataGridView1.ColumnCount = colCount;
                dataGridView1.RowCount = rowCount;
                progressBar1.Value = 0;
                progressBar1.Maximum = rowCount;
                for (int i = 1; i <= rowCount; i++)
                {
                    for (int j = 1; j <= colCount; j++)
                    {


                        //write the value to the Grid  


                        if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                        {
                           
                                dataGridView1.Rows[i - 1].Cells[j - 1].Value = xlRange.Cells[i, j].Value2.ToString();
                           
                        }
                        // Console.Write(xlRange.Cells[i, j].Value2.ToString() + "\t");  

                        //add useful things here!     
                    }
                    progressBar1.Value += 1;
                }

                //cleanup  
                GC.Collect();
                GC.WaitForPendingFinalizers();

                //rule of thumb for releasing com objects:  
                //  never use two dots, all COM objects must be referenced and released individually  
                //  ex: [somthing].[something].[something] is bad  

                //release com objects to fully kill excel process from running in the background  
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release  
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release  
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
                uctxtLedgerName.Text = strLedgerName;
                dataGridView1.AllowUserToAddRows = false;
                calculateTotal();
                MessageBox.Show("Import Done Without Error,You Can Save");
            }
            catch (Exception ex)
            {

            }
        }
        #region "Calculatetotal
        private void calculateTotal()
        {
            double dbltotal = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[3].Value != null)
                {
                    dbltotal = dbltotal + Convert.ToDouble(Utility.Val(dataGridView1.Rows[i].Cells[4].Value.ToString()));
                }
            }


            lblTotal.Text = "Total Amount: " + dbltotal.ToString();
            
        }
        #endregion
        #endregion
        #region "Load"
        private void frmAutoBkash_Load(object sender, EventArgs e)
        {

            dataGridView1.AllowUserToAddRows = false;
            SortedDictionary<string, int> userCache = new SortedDictionary<string, int>
            {
              {"General", 1},
              {"With Bkash Account", 2}
            };

            cboGeneral.DisplayMember = "Key";
            cboGeneral.ValueMember = "Value";
            cboGeneral.DataSource = new BindingSource(userCache, null);

            //lstLedgerList.DisplayMember = "strLedgerName";
            //lstLedgerList.ValueMember = "strLedgerName";
            //lstLedgerList.DataSource = accms.mFillLedgerNew(strComID, (long)Utility.GR_GROUP_TYPE.grBANKACCOUNTS).ToList();
            lstLedgerList.Visible = false;
            cboGeneral.Focus();
        }

        #endregion

        private void cboGeneral_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGeneral.Text.ToString() != "General")
            {
                uctxtLedgerName.Text = "BKash Account";
                lstLedgerList.DisplayMember = "strLedgerName";
                lstLedgerList.ValueMember = "strLedgerName";
                lstLedgerList.DataSource = accms.mFillLedgerNew(strComID, 999).ToList();
            }
            else
            {
                uctxtLedgerName.Text = "";
                lstLedgerList.DisplayMember = "strLedgerName";
                lstLedgerList.ValueMember = "strLedgerName";
                lstLedgerList.DataSource = accms.mFillLedgerNew(strComID, (long)Utility.GR_GROUP_TYPE.grBANKACCOUNTS).ToList();
                lstLedgerList.Visible = false;
            }
        }










    }
}
