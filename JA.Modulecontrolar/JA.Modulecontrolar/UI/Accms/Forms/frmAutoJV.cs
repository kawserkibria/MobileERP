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

namespace JA.Modulecontrolar.UI.Accms.Forms
{
    public partial class frmAutoJV : JA.Shared.UI.frmSmartFormStandard
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
        SPWOIS objWois = new SPWOIS();
        private string strComID { get; set; }
        public frmAutoJV()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
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

        private void btnNew_Click(object sender, EventArgs e)
        {

            string strMainLegder = "",strMerzename="", strPFLedger = "", strHLLedger = "", strSQL = "", strBranchID = "",
                strRefNumber = "", vdteDate = "", vstrMonthID = "", vstrNarration = "", 
                strReverseLedger="",strBillWiseRef="",strPrefix="",strFromDate="",strToDate="",
                strDefaultMonthID="",strDefaultermsg="";
            double dblLedgerCls = 0,dblAmount=0,dblpfAmnt=0,dblHlamnt=0;
            int vlngVoucherType = 3, intvoucherPosition = 1, incount = 0, inDefault = 0;

            if (Utility.gblnAccessControl)
            {
                if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, 193, 1))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            var strResponseInsert = MessageBox.Show("Do You Want to Generate this auto Voucher?", "Journal Voucher", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (strResponseInsert == DialogResult.No)
            {
                return;
            }
            DateTime dteChckdate = Convert.ToDateTime("25-07-2020");
            DateTime dtesystemdate = DateTime.Now;

            if (dteImportDate.Value > dtesystemdate)
            {
                MessageBox.Show("Cannot Generate Advance Date");
                return;
            }
            if (dteImportDate.Value < dteChckdate)
            {
                MessageBox.Show("Cannot Generate Back Lock Date");
                return;
            }



         
           
            textBox1.Text = "";
            vdteDate = dteImportDate.Text;
            vstrMonthID = dteImportDate.Value.ToString("MMMyy").ToUpper();
            strFromDate = Utility.FirstDayOfMonth(dteImportDate.Value).ToString("dd-MM-yyyy");
            strToDate = Utility.LastDayOfMonth(dteImportDate.Value).ToString("dd-MM-yyyy");
            var objheck = objWois.gsterGecheckProcess(strComID, vstrMonthID);
            if (objheck !="")
            {
                MessageBox.Show(objheck);
                return;
            }

            List<AccountsLedger> ledger = accms.GetCustomerLedger(strComID).ToList();
            if (ledger.Count>0)
            {
                progressBar1.Value = 0;
                progressBar1.Maximum = ledger.Count;
                foreach (AccountsLedger objLegder in ledger)
                {
                    strMainLegder = objLegder.strRepName;
                    strMerzename = objLegder.strParentGroup;
                    strPFLedger = accms.GetPFLegder(strComID, strMainLegder);
                    strHLLedger = accms.GetHLLegder(strComID, strMainLegder);

                    dblLedgerCls = Utility.dblLedgerCollectionforMonth(strComID, strFromDate, strToDate, strMainLegder, "0001");
                    dblpfAmnt = objWois.dblGetPFAmount(strComID, strPFLedger);
                    
                    string connstring = Utility.SQLConnstringComSwitch(strComID);
                    DataTable dtdefaulter = objWois.GetDefalterData(strComID, strMainLegder, dteImportDate.Text);
                    //*************Default Statement
                    using (SqlConnection gcnMain = new SqlConnection(connstring))
                    {
                        if (gcnMain.State == ConnectionState.Open)
                        {
                            gcnMain.Close();
                        }

                        gcnMain.Open();
                       
                       
                        if (dtdefaulter.Rows.Count > 0)
                        {
                            

                            foreach (DataRow rowdefault in dtdefaulter.Rows)
                            {
                                DataTable dtnew = objWois.GetTemplateData(strComID, strHLLedger);
                                if (dtnew.Rows.Count > 0)
                                {
                                    foreach (DataRow dr in dtnew.Rows)
                                    {
                                        dblHlamnt = Utility.Val(dr["MONTHLY_AMOUNT"].ToString());
                                    }
                                }
                                strBranchID = "0001";
                                if (dblLedgerCls != 0)
                                {
                                    dblAmount = dblpfAmnt + dblHlamnt;
                                }
                                else
                                {
                                    dblpfAmnt = 0;
                                    dblAmount = 0;
                                    dblHlamnt = 0;
                                    vstrNarration = "Not Sufficient Balance";
                                }
                                strDefaultMonthID = Convert.ToDateTime(rowdefault["COMP_VOUCHER_DATE"]).ToString("MMMyy").ToUpper();
                                strRefNumber = gobjVoucherName.VoucherName.GetVoucherString(vlngVoucherType) + strBranchID + Utility.gstrLastNumber(strComID, vlngVoucherType);
                                string strDuplicate = objWois.gCheckJV(strComID, strRefNumber);
                                if (dblAmount > 0)
                                {
                                    if (dblLedgerCls >= dblAmount)
                                    {
                                        SqlCommand cmdInsert = new SqlCommand();
                                        SqlTransaction myTrans;
                                        myTrans = gcnMain.BeginTransaction();
                                        cmdInsert.Connection = gcnMain;
                                        cmdInsert.Transaction = myTrans;
                                       
                                        if (strDuplicate != "")
                                        {
                                            strSQL = "UPDATE ACC_VOUCHER_TYPE ";
                                            strSQL = strSQL + "SET VOUCHER_TYPE_TOTAL_VOUCHER = VOUCHER_TYPE_TOTAL_VOUCHER + 1 ";
                                            strSQL = strSQL + "WHERE VOUCHER_TYPE_VALUE = " + vlngVoucherType + " ";
                                            cmdInsert.CommandText = strSQL;
                                            cmdInsert.ExecuteNonQuery();
                                        }
                                        strSQL = "INSERT INTO ACC_COMPANY_VOUCHER(";
                                        strSQL = strSQL + "COMP_REF_NO,BRANCH_ID,LEDGER_NAME,COMP_VOUCHER_TYPE,COMP_VOUCHER_DATE,COMP_VOUCHER_DUE_DATE,COMP_VOUCHER_MONTH_ID ";
                                        strSQL = strSQL + ",COMP_VOUCHER_AMOUNT,COMP_VOUCHER_NET_AMOUNT,COMP_VOUCHER_NARRATION,AUTOJV)";
                                        strSQL = strSQL + "VALUES(";
                                        strSQL = strSQL + "'" + strRefNumber + "' ";
                                        strSQL = strSQL + ",'" + strBranchID.Replace("'", "''") + "' ";
                                        strSQL = strSQL + ",'" + strMainLegder.Replace("'", "''") + "' ";
                                        strSQL = strSQL + "," + vlngVoucherType + " ";
                                        strSQL = strSQL + "," + Utility.cvtSQLDateString(rowdefault["COMP_VOUCHER_DATE"].ToString()) + " ";
                                        strSQL = strSQL + "," + Utility.cvtSQLDateString(rowdefault["COMP_VOUCHER_DATE"].ToString()) + " ";
                                        strSQL = strSQL + ",'" + strDefaultMonthID.Replace("'", "''") + "' ";
                                        strSQL = strSQL + "," + dblAmount + " ";
                                        strSQL = strSQL + "," + dblAmount + " ";
                                        strSQL = strSQL + ",'" + vstrNarration.Replace("'", "''") + "' ";
                                        strSQL = strSQL + ",1";
                                        strSQL = strSQL + ")";
                                        cmdInsert.CommandText = strSQL;
                                        cmdInsert.ExecuteNonQuery();

                                        if (dblpfAmnt > 0 && dblHlamnt > 0)
                                        {
                                            strReverseLedger = "As Per Details";
                                        }
                                        else if (dblpfAmnt > 0)
                                        {
                                            strReverseLedger = strPFLedger;
                                            strPrefix = "PF";
                                        }
                                        else if (dblHlamnt > 0)
                                        {
                                            strReverseLedger = strHLLedger;
                                            strPrefix = "HL";
                                        }

                                        if (strReverseLedger == "As Per Details")
                                        {
                                            strBillWiseRef = strRefNumber + intvoucherPosition.ToString("0000");
                                            strSQL = "INSERT INTO ACC_VOUCHER";
                                            strSQL = strSQL + "(COMP_REF_NO,BRANCH_ID,VOUCHER_REF_KEY,COMP_VOUCHER_TYPE,";
                                            strSQL = strSQL + "COMP_VOUCHER_POSITION,COMP_VOUCHER_DATE,LEDGER_NAME,";
                                            strSQL = strSQL + "VOUCHER_DEBIT_AMOUNT,VOUCHER_CREDIT_AMOUNT,";
                                            strSQL = strSQL + "VOUCHER_TOBY,VOUCHER_REVERSE_LEDGER,AUTOJV,REVERSE_LEDGER1,TRANSFER_TYPE ";
                                            strSQL = strSQL + ") VALUES(";
                                            strSQL = strSQL + "'" + strRefNumber + "'";
                                            strSQL = strSQL + ",'" + strBranchID.Replace("'", "''") + "' ";
                                            strSQL = strSQL + ",'" + strBillWiseRef + "' ";
                                            strSQL = strSQL + "," + vlngVoucherType + "";
                                            strSQL = strSQL + "," + intvoucherPosition + "";
                                            strSQL = strSQL + "," + Utility.cvtSQLDateString(rowdefault["COMP_VOUCHER_DATE"].ToString()) + "";
                                            strSQL = strSQL + ",'" + strMainLegder.Replace("'", "''") + "' ";
                                            strSQL = strSQL + "," + dblAmount + " ";
                                            strSQL = strSQL + ",0 ";
                                            strSQL = strSQL + ",'Dr'";
                                            strSQL = strSQL + ",'" + strReverseLedger.Replace("'", "''") + "' ";
                                            strSQL = strSQL + ",1";
                                            strSQL = strSQL + ",'" + strReverseLedger.Replace("'", "''") + "' ";
                                            strSQL = strSQL + ",1";
                                            strSQL = strSQL + ")";
                                            cmdInsert.CommandText = strSQL;
                                            cmdInsert.ExecuteNonQuery();
                                            intvoucherPosition += 1;
                                            strBillWiseRef = strRefNumber + intvoucherPosition.ToString("0000");
                                            strSQL = "INSERT INTO ACC_VOUCHER";
                                            strSQL = strSQL + "(COMP_REF_NO,BRANCH_ID,VOUCHER_REF_KEY,COMP_VOUCHER_TYPE,";
                                            strSQL = strSQL + "COMP_VOUCHER_POSITION,COMP_VOUCHER_DATE,LEDGER_NAME,";
                                            strSQL = strSQL + "VOUCHER_DEBIT_AMOUNT,VOUCHER_CREDIT_AMOUNT,";
                                            strSQL = strSQL + "VOUCHER_TOBY,VOUCHER_REVERSE_LEDGER,AUTOJV,REVERSE_LEDGER1,LEDG_PREFIX,TRANSFER_TYPE ";
                                            strSQL = strSQL + ") VALUES(";
                                            strSQL = strSQL + "'" + strRefNumber + "'";
                                            strSQL = strSQL + ",'" + strBranchID.Replace("'", "''") + "' ";
                                            strSQL = strSQL + ",'" + strBillWiseRef + "' ";
                                            strSQL = strSQL + "," + vlngVoucherType + "";
                                            strSQL = strSQL + "," + intvoucherPosition + "";
                                            strSQL = strSQL + "," + Utility.cvtSQLDateString(rowdefault["COMP_VOUCHER_DATE"].ToString()) + "";
                                            strSQL = strSQL + ",'" + strPFLedger.Replace("'", "''") + "' ";
                                            strSQL = strSQL + ",0 ";
                                            strSQL = strSQL + "," + dblpfAmnt + " ";
                                            strSQL = strSQL + ",'Cr'";
                                            strSQL = strSQL + ",'" + strReverseLedger.Replace("'", "''") + "' ";
                                            strSQL = strSQL + ",1";
                                            strSQL = strSQL + ",'" + strMainLegder.Replace("'", "''") + "' ";
                                            strSQL = strSQL + ",'PF' ";
                                            strSQL = strSQL + ",1";
                                            strSQL = strSQL + ")";
                                            cmdInsert.CommandText = strSQL;
                                            cmdInsert.ExecuteNonQuery();
                                            intvoucherPosition += 1;
                                            strBillWiseRef = strRefNumber + intvoucherPosition.ToString("0000");
                                            strSQL = "INSERT INTO ACC_VOUCHER";
                                            strSQL = strSQL + "(COMP_REF_NO,BRANCH_ID,VOUCHER_REF_KEY,COMP_VOUCHER_TYPE,";
                                            strSQL = strSQL + "COMP_VOUCHER_POSITION,COMP_VOUCHER_DATE,LEDGER_NAME,";
                                            strSQL = strSQL + "VOUCHER_DEBIT_AMOUNT,VOUCHER_CREDIT_AMOUNT,";
                                            strSQL = strSQL + "VOUCHER_TOBY,VOUCHER_REVERSE_LEDGER,AUTOJV,REVERSE_LEDGER1,LEDG_PREFIX,TRANSFER_TYPE ";
                                            strSQL = strSQL + ") VALUES(";
                                            strSQL = strSQL + "'" + strRefNumber + "'";
                                            strSQL = strSQL + ",'" + strBranchID.Replace("'", "''") + "' ";
                                            strSQL = strSQL + ",'" + strBillWiseRef + "' ";
                                            strSQL = strSQL + "," + vlngVoucherType + "";
                                            strSQL = strSQL + "," + intvoucherPosition + "";
                                            strSQL = strSQL + "," + Utility.cvtSQLDateString(rowdefault["COMP_VOUCHER_DATE"].ToString()) + "";
                                            strSQL = strSQL + ",'" + strHLLedger.Replace("'", "''") + "' ";
                                            strSQL = strSQL + ",0 ";
                                            strSQL = strSQL + "," + dblHlamnt + " ";
                                            strSQL = strSQL + ",'Cr'";
                                            strSQL = strSQL + ",'" + strReverseLedger.Replace("'", "''") + "' ";
                                            strSQL = strSQL + ",1";
                                            strSQL = strSQL + ",'" + strMainLegder.Replace("'", "''") + "' ";
                                            strSQL = strSQL + ",'HL' ";
                                            strSQL = strSQL + ",1";
                                            strSQL = strSQL + ")";
                                            cmdInsert.CommandText = strSQL;
                                            cmdInsert.ExecuteNonQuery();
                                            if (dblAmount > 0)
                                            {
                                                if (dtnew.Rows.Count > 0)
                                                {
                                                    foreach (DataRow dr in dtnew.Rows)
                                                    {
                                                        strSQL = "INSERT INTO ACC_PAYMENT_SCHEDULE";
                                                        strSQL = strSQL + "(COMP_REF_NO,LEDGER_NAME,TEMPLATE_NAME,INSTALLMET_NAME,DUE_DATE,RECEIVE_DATE ,MONTHLY_AMOUNT,RECEIVED_AMOUNT,INSTALL_STATUS,TO_BY";
                                                        strSQL = strSQL + ") VALUES(";
                                                        strSQL = strSQL + "'" + strRefNumber.Replace("'", "''") + "'";
                                                        strSQL = strSQL + ",'" + dr["LEDGER_NAME"].ToString().Replace("'", "''") + "'";
                                                        strSQL = strSQL + ",'" + dr["TEMPLATE_NAME"].ToString().Replace("'", "''") + "' ";
                                                        strSQL = strSQL + ",'" + dr["INSTALLMET_NAME"].ToString().Replace("'", "''") + "' ";
                                                        strSQL = strSQL + "," + Utility.cvtSQLDateString(dr["DUE_DATE"].ToString()) + " ";
                                                        strSQL = strSQL + "," + Utility.cvtSQLDateString(dr["DUE_DATE"].ToString()) + " ";
                                                        strSQL = strSQL + "," + Utility.Val(dr["MONTHLY_AMOUNT"].ToString()) * -1 + " ";
                                                        strSQL = strSQL + "," + Utility.Val(dr["MONTHLY_AMOUNT"].ToString()) * -1 + " ";
                                                        strSQL = strSQL + ",1";
                                                        strSQL = strSQL + ",'Cr'";
                                                        strSQL = strSQL + ")";
                                                        cmdInsert.CommandText = strSQL;
                                                        cmdInsert.ExecuteNonQuery();
                                                        strSQL = "UPDATE ACC_PAYMENT_SCHEDULE SET INSTALL_STATUS=1 ";
                                                        strSQL = strSQL + "WHERE LEDGER_NAME='" + dr["LEDGER_NAME"].ToString().Replace("'", "''") + "'";
                                                        strSQL = strSQL + "AND INSTALLMET_NAME='" + dr["INSTALLMET_NAME"].ToString().Replace("'", "''") + "'";
                                                        cmdInsert.CommandText = strSQL;
                                                        cmdInsert.ExecuteNonQuery();

                                                    }
                                                }
                                            }

                                        }
                                        else
                                        {
                                            strBillWiseRef = strRefNumber + intvoucherPosition.ToString("0000");
                                            strSQL = "INSERT INTO ACC_VOUCHER";
                                            strSQL = strSQL + "(COMP_REF_NO,BRANCH_ID,VOUCHER_REF_KEY,COMP_VOUCHER_TYPE,";
                                            strSQL = strSQL + "COMP_VOUCHER_POSITION,COMP_VOUCHER_DATE,LEDGER_NAME,";
                                            strSQL = strSQL + "VOUCHER_DEBIT_AMOUNT,VOUCHER_CREDIT_AMOUNT,";
                                            strSQL = strSQL + "VOUCHER_TOBY,VOUCHER_REVERSE_LEDGER,AUTOJV,REVERSE_LEDGER1,LEDG_PREFIX,TRANSFER_TYPE  ";
                                            strSQL = strSQL + ") VALUES(";
                                            strSQL = strSQL + "'" + strRefNumber + "'";
                                            strSQL = strSQL + ",'" + strBranchID.Replace("'", "''") + "' ";
                                            strSQL = strSQL + ",'" + strBillWiseRef + "' ";
                                            strSQL = strSQL + "," + vlngVoucherType + "";
                                            strSQL = strSQL + "," + intvoucherPosition + "";
                                            strSQL = strSQL + "," + Utility.cvtSQLDateString(rowdefault["COMP_VOUCHER_DATE"].ToString()) + "";
                                            strSQL = strSQL + ",'" + strMainLegder.Replace("'", "''") + "' ";
                                            strSQL = strSQL + "," + dblAmount + " ";
                                            strSQL = strSQL + ",0 ";
                                            strSQL = strSQL + ",'Dr'";
                                            strSQL = strSQL + ",'" + strReverseLedger.Replace("'", "''") + "' ";
                                            strSQL = strSQL + ",1";
                                            strSQL = strSQL + ",'" + strReverseLedger.Replace("'", "''") + "' ";
                                            strSQL = strSQL + ",'" + strPrefix.Replace("'", "''") + "' ";
                                            strSQL = strSQL + ",1";
                                            strSQL = strSQL + ")";
                                            cmdInsert.CommandText = strSQL;
                                            cmdInsert.ExecuteNonQuery();
                                            intvoucherPosition += 1;
                                            strBillWiseRef = strRefNumber + intvoucherPosition.ToString("0000");
                                            strSQL = "INSERT INTO ACC_VOUCHER";
                                            strSQL = strSQL + "(COMP_REF_NO,BRANCH_ID,VOUCHER_REF_KEY,COMP_VOUCHER_TYPE,";
                                            strSQL = strSQL + "COMP_VOUCHER_POSITION,COMP_VOUCHER_DATE,LEDGER_NAME,";
                                            strSQL = strSQL + "VOUCHER_DEBIT_AMOUNT,VOUCHER_CREDIT_AMOUNT,";
                                            strSQL = strSQL + "VOUCHER_TOBY,VOUCHER_REVERSE_LEDGER,AUTOJV,REVERSE_LEDGER1,LEDG_PREFIX,TRANSFER_TYPE ";
                                            strSQL = strSQL + ") VALUES(";
                                            strSQL = strSQL + "'" + strRefNumber + "'";
                                            strSQL = strSQL + ",'" + strBranchID.Replace("'", "''") + "' ";
                                            strSQL = strSQL + ",'" + strBillWiseRef + "' ";
                                            strSQL = strSQL + "," + vlngVoucherType + "";
                                            strSQL = strSQL + "," + intvoucherPosition + "";
                                            strSQL = strSQL + "," + Utility.cvtSQLDateString(rowdefault["COMP_VOUCHER_DATE"].ToString()) + "";
                                            strSQL = strSQL + ",'" + strReverseLedger.Replace("'", "''") + "' ";
                                            strSQL = strSQL + ",0 ";
                                            strSQL = strSQL + "," + dblAmount + " ";
                                            strSQL = strSQL + ",'Cr'";
                                            strSQL = strSQL + ",'" + strMainLegder.Replace("'", "''") + "' ";
                                            strSQL = strSQL + ",1";
                                            strSQL = strSQL + ",'" + strMainLegder.Replace("'", "''") + "' ";
                                            strSQL = strSQL + ",'" + strPrefix.Replace("'", "''") + "' ";
                                            strSQL = strSQL + ",1";
                                            strSQL = strSQL + ")";
                                            cmdInsert.CommandText = strSQL;
                                            cmdInsert.ExecuteNonQuery();
                                            if (dblAmount > 0)
                                            {
                                                if (dblHlamnt > 0)
                                                {
                                                    if (dtnew.Rows.Count > 0)
                                                    {
                                                        foreach (DataRow dr in dtnew.Rows)
                                                        {
                                                            strSQL = "INSERT INTO ACC_PAYMENT_SCHEDULE";
                                                            strSQL = strSQL + "(COMP_REF_NO,LEDGER_NAME,TEMPLATE_NAME,INSTALLMET_NAME,DUE_DATE,RECEIVE_DATE ,MONTHLY_AMOUNT,RECEIVED_AMOUNT,INSTALL_STATUS,TO_BY";
                                                            strSQL = strSQL + ") VALUES(";
                                                            strSQL = strSQL + "'" + strRefNumber.Replace("'", "''") + "'";
                                                            strSQL = strSQL + ",'" + dr["LEDGER_NAME"].ToString().Replace("'", "''") + "'";
                                                            strSQL = strSQL + ",'" + dr["TEMPLATE_NAME"].ToString().Replace("'", "''") + "' ";
                                                            strSQL = strSQL + ",'" + dr["INSTALLMET_NAME"].ToString().Replace("'", "''") + "' ";
                                                            strSQL = strSQL + "," + Utility.cvtSQLDateString(dr["DUE_DATE"].ToString()) + " ";
                                                            strSQL = strSQL + "," + Utility.cvtSQLDateString(dr["DUE_DATE"].ToString()) + " ";
                                                            strSQL = strSQL + "," + Utility.Val(dr["MONTHLY_AMOUNT"].ToString()) * -1 + " ";
                                                            strSQL = strSQL + "," + Utility.Val(dr["MONTHLY_AMOUNT"].ToString()) * -1 + " ";
                                                            strSQL = strSQL + ",1";
                                                            strSQL = strSQL + ",'Cr'";
                                                            strSQL = strSQL + ")";
                                                            cmdInsert.CommandText = strSQL;
                                                            cmdInsert.ExecuteNonQuery();
                                                            strSQL = "UPDATE ACC_PAYMENT_SCHEDULE SET INSTALL_STATUS=1 ";
                                                            strSQL = strSQL + "WHERE LEDGER_NAME='" + dr["LEDGER_NAME"].ToString().Replace("'", "''") + "'";
                                                            strSQL = strSQL + "AND INSTALLMET_NAME='" + dr["INSTALLMET_NAME"].ToString().Replace("'", "''") + "'";
                                                            cmdInsert.CommandText = strSQL;
                                                            cmdInsert.ExecuteNonQuery();
                                                        }
                                                    }
                                                }
                                            }
                                        }



                                        strSQL = "UPDATE ACC_VOUCHER_TYPE ";
                                        strSQL = strSQL + "SET VOUCHER_TYPE_TOTAL_VOUCHER = VOUCHER_TYPE_TOTAL_VOUCHER + 1 ";
                                        strSQL = strSQL + "WHERE VOUCHER_TYPE_VALUE = " + vlngVoucherType + " ";
                                        cmdInsert.CommandText = strSQL;
                                        cmdInsert.ExecuteNonQuery();

                                        strSQL = "UPDATE ACC_DEFAULTER_LEDGER ";
                                        strSQL = strSQL + "SET DEF_STATUS =  1 ";
                                        strSQL = strSQL + "WHERE MONTH_ID = '" + strDefaultMonthID + "' ";
                                        cmdInsert.CommandText = strSQL;
                                        cmdInsert.ExecuteNonQuery();
                                        dblLedgerCls = dblLedgerCls - dblAmount;
                                        cmdInsert.Transaction.Commit();
                                        inDefault += 1;
                                        dtnew.Rows.Clear();

                                    }
                                }
                            }

                        }
                    
                        gcnMain.Close();
                    }
                    
                    //************************************
                    DataTable dt = objWois.GetTemplateData(strComID, strHLLedger);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            dblHlamnt = Utility.Val(dr["MONTHLY_AMOUNT"].ToString());
                        }
                    }

                   
                    //*******************
                   
                    try
                    {
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

                            strBranchID = "0001";
                            if (dblLedgerCls != 0)
                            {
                                dblAmount = dblpfAmnt + dblHlamnt;
                            }
                            else
                            {
                                dblpfAmnt = 0;
                                dblAmount = 0;
                                dblHlamnt = 0;
                                vstrNarration = "Not Sufficient Balance";
                            }
                            
                          
                            strRefNumber = gobjVoucherName.VoucherName.GetVoucherString(vlngVoucherType) + strBranchID + Utility.gstrLastNumber(strComID, vlngVoucherType);

                            string strDuplicate = objWois.gCheckJV(strComID, strRefNumber);
                            if (strDuplicate !="")
                            {
                                strSQL = "UPDATE ACC_VOUCHER_TYPE ";
                                strSQL = strSQL + "SET VOUCHER_TYPE_TOTAL_VOUCHER = VOUCHER_TYPE_TOTAL_VOUCHER + 1 ";
                                strSQL = strSQL + "WHERE VOUCHER_TYPE_VALUE = " + vlngVoucherType + " ";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                            }

                            if (dblAmount > 0)
                            {
                                if (dblLedgerCls >= dblAmount)
                                {
                                    strSQL = "INSERT INTO ACC_COMPANY_VOUCHER(";
                                    strSQL = strSQL + "COMP_REF_NO,BRANCH_ID,LEDGER_NAME,COMP_VOUCHER_TYPE,COMP_VOUCHER_DATE,COMP_VOUCHER_DUE_DATE,COMP_VOUCHER_MONTH_ID ";
                                    strSQL = strSQL + ",COMP_VOUCHER_AMOUNT,COMP_VOUCHER_NET_AMOUNT,COMP_VOUCHER_NARRATION,AUTOJV)";
                                    strSQL = strSQL + "VALUES(";
                                    strSQL = strSQL + "'" + strRefNumber + "' ";
                                    strSQL = strSQL + ",'" + strBranchID.Replace("'", "''") + "' ";
                                    strSQL = strSQL + ",'" + strMainLegder.Replace("'", "''") + "' ";
                                    strSQL = strSQL + "," + vlngVoucherType + " ";
                                    strSQL = strSQL + "," + Utility.cvtSQLDateString(vdteDate) + " ";
                                    strSQL = strSQL + "," + Utility.cvtSQLDateString(vdteDate) + " ";
                                    strSQL = strSQL + ",'" + vstrMonthID.Replace("'", "''") + "' ";
                                    strSQL = strSQL + "," + dblAmount + " ";
                                    strSQL = strSQL + "," + dblAmount + " ";
                                    strSQL = strSQL + ",'" + vstrNarration.Replace("'", "''") + "' ";
                                    strSQL = strSQL + ",1";
                                    strSQL = strSQL + ")";
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();

                                    if (dblpfAmnt > 0 && dblHlamnt > 0)
                                    {
                                        strReverseLedger = "As Per Details";
                                    }
                                    else if (dblpfAmnt > 0)
                                    {
                                        strReverseLedger = strPFLedger;
                                        strPrefix = "PF";
                                    }
                                    else if (dblHlamnt > 0)
                                    {
                                        strReverseLedger = strHLLedger;
                                        strPrefix = "HL";
                                    }

                                    if (strReverseLedger == "As Per Details")
                                    {
                                        strBillWiseRef = strRefNumber + intvoucherPosition.ToString("0000");
                                        strSQL = "INSERT INTO ACC_VOUCHER";
                                        strSQL = strSQL + "(COMP_REF_NO,BRANCH_ID,VOUCHER_REF_KEY,COMP_VOUCHER_TYPE,";
                                        strSQL = strSQL + "COMP_VOUCHER_POSITION,COMP_VOUCHER_DATE,LEDGER_NAME,";
                                        strSQL = strSQL + "VOUCHER_DEBIT_AMOUNT,VOUCHER_CREDIT_AMOUNT,";
                                        strSQL = strSQL + "VOUCHER_TOBY,VOUCHER_REVERSE_LEDGER,AUTOJV,REVERSE_LEDGER1,TRANSFER_TYPE ";
                                        strSQL = strSQL + ") VALUES(";
                                        strSQL = strSQL + "'" + strRefNumber + "'";
                                        strSQL = strSQL + ",'" + strBranchID.Replace("'", "''") + "' ";
                                        strSQL = strSQL + ",'" + strBillWiseRef + "' ";
                                        strSQL = strSQL + "," + vlngVoucherType + "";
                                        strSQL = strSQL + "," + intvoucherPosition + "";
                                        strSQL = strSQL + "," + Utility.cvtSQLDateString(vdteDate) + "";
                                        strSQL = strSQL + ",'" + strMainLegder.Replace("'", "''") + "' ";
                                        strSQL = strSQL + "," + dblAmount + " ";
                                        strSQL = strSQL + ",0 ";
                                        strSQL = strSQL + ",'Dr'";
                                        strSQL = strSQL + ",'" + strReverseLedger.Replace("'", "''") + "' ";
                                        strSQL = strSQL + ",1";
                                        strSQL = strSQL + ",'" + strReverseLedger.Replace("'", "''") + "' ";
                                        strSQL = strSQL + ",1";
                                        strSQL = strSQL + ")";
                                        cmdInsert.CommandText = strSQL;
                                        cmdInsert.ExecuteNonQuery();
                                        intvoucherPosition += 1;
                                        strBillWiseRef = strRefNumber + intvoucherPosition.ToString("0000");
                                        strSQL = "INSERT INTO ACC_VOUCHER";
                                        strSQL = strSQL + "(COMP_REF_NO,BRANCH_ID,VOUCHER_REF_KEY,COMP_VOUCHER_TYPE,";
                                        strSQL = strSQL + "COMP_VOUCHER_POSITION,COMP_VOUCHER_DATE,LEDGER_NAME,";
                                        strSQL = strSQL + "VOUCHER_DEBIT_AMOUNT,VOUCHER_CREDIT_AMOUNT,";
                                        strSQL = strSQL + "VOUCHER_TOBY,VOUCHER_REVERSE_LEDGER,AUTOJV,REVERSE_LEDGER1,LEDG_PREFIX,TRANSFER_TYPE ";
                                        strSQL = strSQL + ") VALUES(";
                                        strSQL = strSQL + "'" + strRefNumber + "'";
                                        strSQL = strSQL + ",'" + strBranchID.Replace("'", "''") + "' ";
                                        strSQL = strSQL + ",'" + strBillWiseRef + "' ";
                                        strSQL = strSQL + "," + vlngVoucherType + "";
                                        strSQL = strSQL + "," + intvoucherPosition + "";
                                        strSQL = strSQL + "," + Utility.cvtSQLDateString(vdteDate) + "";
                                        strSQL = strSQL + ",'" + strPFLedger.Replace("'", "''") + "' ";
                                        strSQL = strSQL + ",0 ";
                                        strSQL = strSQL + "," + dblpfAmnt + " ";
                                        strSQL = strSQL + ",'Cr'";
                                        strSQL = strSQL + ",'" + strReverseLedger.Replace("'", "''") + "' ";
                                        strSQL = strSQL + ",1";
                                        strSQL = strSQL + ",'" + strMainLegder.Replace("'", "''") + "' ";
                                        strSQL = strSQL + ",'PF' ";
                                        strSQL = strSQL + ",1";
                                        strSQL = strSQL + ")";
                                        cmdInsert.CommandText = strSQL;
                                        cmdInsert.ExecuteNonQuery();
                                        intvoucherPosition += 1;
                                        strBillWiseRef = strRefNumber + intvoucherPosition.ToString("0000");
                                        strSQL = "INSERT INTO ACC_VOUCHER";
                                        strSQL = strSQL + "(COMP_REF_NO,BRANCH_ID,VOUCHER_REF_KEY,COMP_VOUCHER_TYPE,";
                                        strSQL = strSQL + "COMP_VOUCHER_POSITION,COMP_VOUCHER_DATE,LEDGER_NAME,";
                                        strSQL = strSQL + "VOUCHER_DEBIT_AMOUNT,VOUCHER_CREDIT_AMOUNT,";
                                        strSQL = strSQL + "VOUCHER_TOBY,VOUCHER_REVERSE_LEDGER,AUTOJV,REVERSE_LEDGER1,LEDG_PREFIX,TRANSFER_TYPE ";
                                        strSQL = strSQL + ") VALUES(";
                                        strSQL = strSQL + "'" + strRefNumber + "'";
                                        strSQL = strSQL + ",'" + strBranchID.Replace("'", "''") + "' ";
                                        strSQL = strSQL + ",'" + strBillWiseRef + "' ";
                                        strSQL = strSQL + "," + vlngVoucherType + "";
                                        strSQL = strSQL + "," + intvoucherPosition + "";
                                        strSQL = strSQL + "," + Utility.cvtSQLDateString(vdteDate) + "";
                                        strSQL = strSQL + ",'" + strHLLedger.Replace("'", "''") + "' ";
                                        strSQL = strSQL + ",0 ";
                                        strSQL = strSQL + "," + dblHlamnt + " ";
                                        strSQL = strSQL + ",'Cr'";
                                        strSQL = strSQL + ",'" + strReverseLedger.Replace("'", "''") + "' ";
                                        strSQL = strSQL + ",1";
                                        strSQL = strSQL + ",'" + strMainLegder.Replace("'", "''") + "' ";
                                        strSQL = strSQL + ",'HL' ";
                                        strSQL = strSQL + ",1";
                                        strSQL = strSQL + ")";
                                        cmdInsert.CommandText = strSQL;
                                        cmdInsert.ExecuteNonQuery();
                                        if (dblAmount > 0)
                                        {
                                            if (dt.Rows.Count > 0)
                                            {
                                                foreach (DataRow dr in dt.Rows)
                                                {
                                                    strSQL = "INSERT INTO ACC_PAYMENT_SCHEDULE";
                                                    strSQL = strSQL + "(COMP_REF_NO,LEDGER_NAME,TEMPLATE_NAME,INSTALLMET_NAME,DUE_DATE,RECEIVE_DATE ,MONTHLY_AMOUNT,RECEIVED_AMOUNT,INSTALL_STATUS,TO_BY";
                                                    strSQL = strSQL + ") VALUES(";
                                                    strSQL = strSQL + "'" + strRefNumber.Replace("'", "''") + "'";
                                                    strSQL = strSQL + ",'" + dr["LEDGER_NAME"].ToString().Replace("'", "''") + "'";
                                                    strSQL = strSQL + ",'" + dr["TEMPLATE_NAME"].ToString().Replace("'", "''") + "' ";
                                                    strSQL = strSQL + ",'" + dr["INSTALLMET_NAME"].ToString().Replace("'", "''") + "' ";
                                                    strSQL = strSQL + "," + Utility.cvtSQLDateString(dr["DUE_DATE"].ToString()) + " ";
                                                    strSQL = strSQL + "," + Utility.cvtSQLDateString(dr["DUE_DATE"].ToString()) + " ";
                                                    strSQL = strSQL + "," + Utility.Val(dr["MONTHLY_AMOUNT"].ToString()) * -1 + " ";
                                                    strSQL = strSQL + "," + Utility.Val(dr["MONTHLY_AMOUNT"].ToString()) * -1 + " ";
                                                    strSQL = strSQL + ",1";
                                                    strSQL = strSQL + ",'Cr'";
                                                    strSQL = strSQL + ")";
                                                    cmdInsert.CommandText = strSQL;
                                                    cmdInsert.ExecuteNonQuery();
                                                    strSQL = "UPDATE ACC_PAYMENT_SCHEDULE SET INSTALL_STATUS=1 ";
                                                    strSQL = strSQL + "WHERE LEDGER_NAME='" + dr["LEDGER_NAME"].ToString().Replace("'", "''") + "'";
                                                    strSQL = strSQL + "AND INSTALLMET_NAME='" + dr["INSTALLMET_NAME"].ToString().Replace("'", "''") + "'";
                                                    cmdInsert.CommandText = strSQL;
                                                    cmdInsert.ExecuteNonQuery();

                                                }
                                            }
                                        }

                                    }
                                    else
                                    {
                                        strBillWiseRef = strRefNumber + intvoucherPosition.ToString("0000");
                                        strSQL = "INSERT INTO ACC_VOUCHER";
                                        strSQL = strSQL + "(COMP_REF_NO,BRANCH_ID,VOUCHER_REF_KEY,COMP_VOUCHER_TYPE,";
                                        strSQL = strSQL + "COMP_VOUCHER_POSITION,COMP_VOUCHER_DATE,LEDGER_NAME,";
                                        strSQL = strSQL + "VOUCHER_DEBIT_AMOUNT,VOUCHER_CREDIT_AMOUNT,";
                                        strSQL = strSQL + "VOUCHER_TOBY,VOUCHER_REVERSE_LEDGER,AUTOJV,REVERSE_LEDGER1,LEDG_PREFIX,TRANSFER_TYPE  ";
                                        strSQL = strSQL + ") VALUES(";
                                        strSQL = strSQL + "'" + strRefNumber + "'";
                                        strSQL = strSQL + ",'" + strBranchID.Replace("'", "''") + "' ";
                                        strSQL = strSQL + ",'" + strBillWiseRef + "' ";
                                        strSQL = strSQL + "," + vlngVoucherType + "";
                                        strSQL = strSQL + "," + intvoucherPosition + "";
                                        strSQL = strSQL + "," + Utility.cvtSQLDateString(vdteDate) + "";
                                        strSQL = strSQL + ",'" + strMainLegder.Replace("'", "''") + "' ";
                                        strSQL = strSQL + "," + dblAmount + " ";
                                        strSQL = strSQL + ",0 ";
                                        strSQL = strSQL + ",'Dr'";
                                        strSQL = strSQL + ",'" + strReverseLedger.Replace("'", "''") + "' ";
                                        strSQL = strSQL + ",1";
                                        strSQL = strSQL + ",'" + strReverseLedger.Replace("'", "''") + "' ";
                                        strSQL = strSQL + ",'" + strPrefix.Replace("'", "''") + "' ";
                                        strSQL = strSQL + ",1";
                                        strSQL = strSQL + ")";
                                        cmdInsert.CommandText = strSQL;
                                        cmdInsert.ExecuteNonQuery();
                                        intvoucherPosition += 1;
                                        strBillWiseRef = strRefNumber + intvoucherPosition.ToString("0000");
                                        strSQL = "INSERT INTO ACC_VOUCHER";
                                        strSQL = strSQL + "(COMP_REF_NO,BRANCH_ID,VOUCHER_REF_KEY,COMP_VOUCHER_TYPE,";
                                        strSQL = strSQL + "COMP_VOUCHER_POSITION,COMP_VOUCHER_DATE,LEDGER_NAME,";
                                        strSQL = strSQL + "VOUCHER_DEBIT_AMOUNT,VOUCHER_CREDIT_AMOUNT,";
                                        strSQL = strSQL + "VOUCHER_TOBY,VOUCHER_REVERSE_LEDGER,AUTOJV,REVERSE_LEDGER1,LEDG_PREFIX,TRANSFER_TYPE ";
                                        strSQL = strSQL + ") VALUES(";
                                        strSQL = strSQL + "'" + strRefNumber + "'";
                                        strSQL = strSQL + ",'" + strBranchID.Replace("'", "''") + "' ";
                                        strSQL = strSQL + ",'" + strBillWiseRef + "' ";
                                        strSQL = strSQL + "," + vlngVoucherType + "";
                                        strSQL = strSQL + "," + intvoucherPosition + "";
                                        strSQL = strSQL + "," + Utility.cvtSQLDateString(vdteDate) + "";
                                        strSQL = strSQL + ",'" + strReverseLedger.Replace("'", "''") + "' ";
                                        strSQL = strSQL + ",0 ";
                                        strSQL = strSQL + "," + dblAmount + " ";
                                        strSQL = strSQL + ",'Cr'";
                                        strSQL = strSQL + ",'" + strMainLegder.Replace("'", "''") + "' ";
                                        strSQL = strSQL + ",1";
                                        strSQL = strSQL + ",'" + strMainLegder.Replace("'", "''") + "' ";
                                        strSQL = strSQL + ",'" + strPrefix.Replace("'", "''") + "' ";
                                        strSQL = strSQL + ",1";
                                        strSQL = strSQL + ")";
                                        cmdInsert.CommandText = strSQL;
                                        cmdInsert.ExecuteNonQuery();
                                        if (dblAmount > 0)
                                        {
                                            if (dblHlamnt > 0)
                                            {
                                                if (dt.Rows.Count > 0)
                                                {
                                                    foreach (DataRow dr in dt.Rows)
                                                    {
                                                        strSQL = "INSERT INTO ACC_PAYMENT_SCHEDULE";
                                                        strSQL = strSQL + "(COMP_REF_NO,LEDGER_NAME,TEMPLATE_NAME,INSTALLMET_NAME,DUE_DATE,RECEIVE_DATE ,MONTHLY_AMOUNT,RECEIVED_AMOUNT,INSTALL_STATUS,TO_BY";
                                                        strSQL = strSQL + ") VALUES(";
                                                        strSQL = strSQL + "'" + strRefNumber.Replace("'", "''") + "'";
                                                        strSQL = strSQL + ",'" + dr["LEDGER_NAME"].ToString().Replace("'", "''") + "'";
                                                        strSQL = strSQL + ",'" + dr["TEMPLATE_NAME"].ToString().Replace("'", "''") + "' ";
                                                        strSQL = strSQL + ",'" + dr["INSTALLMET_NAME"].ToString().Replace("'", "''") + "' ";
                                                        strSQL = strSQL + "," + Utility.cvtSQLDateString(dr["DUE_DATE"].ToString()) + " ";
                                                        strSQL = strSQL + "," + Utility.cvtSQLDateString(dr["DUE_DATE"].ToString()) + " ";
                                                        strSQL = strSQL + "," + Utility.Val(dr["MONTHLY_AMOUNT"].ToString()) * -1 + " ";
                                                        strSQL = strSQL + "," + Utility.Val(dr["MONTHLY_AMOUNT"].ToString()) * -1 + " ";
                                                        strSQL = strSQL + ",1";
                                                        strSQL = strSQL + ",'Cr'";
                                                        strSQL = strSQL + ")";
                                                        cmdInsert.CommandText = strSQL;
                                                        cmdInsert.ExecuteNonQuery();
                                                        strSQL = "UPDATE ACC_PAYMENT_SCHEDULE SET INSTALL_STATUS=1 ";
                                                        strSQL = strSQL + "WHERE LEDGER_NAME='" + dr["LEDGER_NAME"].ToString().Replace("'", "''") + "'";
                                                        strSQL = strSQL + "AND INSTALLMET_NAME='" + dr["INSTALLMET_NAME"].ToString().Replace("'", "''") + "'";
                                                        cmdInsert.CommandText = strSQL;
                                                        cmdInsert.ExecuteNonQuery();
                                                    }
                                                }
                                            }
                                        }
                                    }



                                    strSQL = "UPDATE ACC_VOUCHER_TYPE ";
                                    strSQL = strSQL + "SET VOUCHER_TYPE_TOTAL_VOUCHER = VOUCHER_TYPE_TOTAL_VOUCHER + 1 ";
                                    strSQL = strSQL + "WHERE VOUCHER_TYPE_VALUE = " + vlngVoucherType + " ";
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                    incount += 1;
                                }
                            }
                            else
                            {
                                strSQL = "INSERT INTO ACC_DEFAULTER_LEDGER(LEDGER_NAME,BRANCH_ID,COMP_VOUCHER_DATE,MONTH_ID)";
                                strSQL = strSQL + "VALUES(";
                                strSQL = strSQL + "'" + strMainLegder.Replace("'", "''") + "' ";
                                strSQL = strSQL + ",'" + strBranchID.Replace("'", "''") + "' ";
                                strSQL = strSQL + "," + Utility.cvtSQLDateString(vdteDate) + "";
                                strSQL = strSQL + ",'" + vstrMonthID.Replace("'", "''") + "' ";
                                strSQL = strSQL + ")";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();

                                strDefaultermsg = strDefaultermsg + Environment.NewLine + strMerzename;
                            }
                            cmdInsert.Transaction.Commit();
                            dblAmount = 0;
                            dblpfAmnt = 0;
                            dblHlamnt = 0;
                            dblLedgerCls = 0;
                            strPFLedger = "";
                            strHLLedger = "";
                            dt.Rows.Clear();
                            dtdefaulter.Rows.Clear();
                            vstrNarration = "";
                            strDefaultMonthID = "";
                            strDuplicate = "";
                            //******************
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
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        return;
                    }
                }
               
            }

            MessageBox.Show(incount + " Records Generate Successfully.." + Environment.NewLine + inDefault + " Due Bill Generate successfully");

            textBox1.Text = "Defaulter List: " +Environment.NewLine + strDefaultermsg;

           
        }

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

      

       



     

     
    }
}
