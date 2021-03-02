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
using Microsoft.VisualBasic;
using JA.Modulecontrolar.JACCMS;
using System.Reflection;


namespace JA.Modulecontrolar.UI.Tools.Forms
{
    public partial class frmScript : Form
    {
        string strComID { get; set; }
        public string strFormType { get; set; }

        public frmScript()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

       
        private void upDateSIVoucher()
        {
            string strSQL = "", strString = "", strCompRefNo, strKey, strDate, strPartyname = "",strSymbol="";
            double dblNetAmount=0, dblRoundOff=0;
             int lngloop = 0;
            string connstring = Utility.SQLConnstringComSwitch(strComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                try
                {
                    gcnMain.Open();
                    SqlDataReader dr;
                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    Prog.Value = 0;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;
                  
                    strSQL = "SELECT COMP_REF_NO,VOUCHER_REF_KEY,COMP_VOUCHER_DATE,LEDGER_NAME FROM  ACC_VOUCHER WHERE COMP_VOUCHER_TYPE =16 and LEDGER_NAME ='Sales Accounts' and VOUCHER_TOBY ='Dr' ";
                    //strSQL = strSQL + " AND COMP_REF_NO ='SI0001D-64141'";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    while (dr.Read())
                    {
                        strString = strString + dr["COMP_REF_NO"].ToString() + "~" + dr["VOUCHER_REF_KEY"].ToString() + "~" + dr["COMP_VOUCHER_DATE"].ToString() + "~" + dr["LEDGER_NAME"].ToString() + "|";
                        lngloop+=1;
                    }
                    dr.Close();
                    if (strString != "")
                    {
                        Prog.Value = 0;
                        string[] words = strString.Split('|');
                        Prog.Maximum = lngloop;
                        foreach (string strBill in words)
                        {
                            string[] ooCost = strBill.Split('~');
                            if (ooCost[0] != "")
                            {

                                strCompRefNo = ooCost[0].ToString();
                                strKey = ooCost[1].ToString();
                                strDate = Convert.ToDateTime (ooCost[2]).ToString("dd-MM-yyyy");
                                //strLedgerName = ooCost[3].ToString();
                                //dblNetAmount = Convert.ToDouble(words[4].ToString());
                                strSQL = "SELECT LEDGER_NAME ,VOUCHER_CREDIT_AMOUNT  from ACC_VOUCHER WHERE COMP_VOUCHER_TYPE =16 and COMP_REF_NO ='" + strCompRefNo + "' and VOUCHER_TOBY ='Cr' ";
                                cmdInsert.CommandText = strSQL;
                                dr = cmdInsert.ExecuteReader();
                                if (dr.Read())
                                {
                                    strPartyname = dr["LEDGER_NAME"].ToString();
                                    dblNetAmount = Convert.ToDouble(dr["VOUCHER_CREDIT_AMOUNT"].ToString());
                                }
                                dr.Close();
                                strSQL = "SELECT VOUCHER_DEBIT_AMOUNT,VOUCHER_TOBY from ACC_VOUCHER WHERE COMP_VOUCHER_TYPE =16 and COMP_REF_NO ='" + strCompRefNo + "' and LEDGER_NAME ='Round Off'";
                                cmdInsert.CommandText = strSQL;
                                dr = cmdInsert.ExecuteReader();
                                if (dr.Read())
                                {

                                    dblRoundOff = Convert.ToDouble(dr["VOUCHER_DEBIT_AMOUNT"].ToString());
                                    strSymbol = dr["VOUCHER_TOBY"].ToString();
                                    if (strSymbol=="Dr")
                                    {
                                        dblRoundOff = dblRoundOff * -1;
                                    }
                                    
                                }
                                dr.Close();
                                strSQL = "DELETE FROM ACC_VOUCHER WHERE COMP_REF_NO='" + strCompRefNo + "' ";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                if (dblRoundOff < 0)
                                {
                                    //dblCredit = dblCredit - ((Math.Abs(dblRoundOff) + Math.Abs(dblAddAmount)) - Math.Abs(dblLessAmount));
                                    strSQL = VoucherSW.gInsertSalesVoucher(strCompRefNo, strDate, 1, strPartyname, "Dr", dblNetAmount, 16, "As per Details", "0001", 0, "", "", "", "");
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();

                                    strSQL = VoucherSW.gInsertSalesVoucher(strCompRefNo, strDate, 2, "Sales Accounts", "Cr", dblNetAmount + Math.Abs(dblRoundOff), 16, "As per Details", "0001", 2, "", "", "", "", "", "");
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                    strSQL = VoucherSW.gInsertSalesVoucher(strCompRefNo, strDate, 3, "Round Off", "Dr", Math.Abs(dblRoundOff), 16, "As per Details", "0001", 2, "-", "", "", "", "", "");
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();

                                }
                                else if (dblRoundOff > 0)
                                {
                                    //dblCredit = dblCredit - ((Math.Abs(dblRoundOff) + Math.Abs(dblAddAmount)) - Math.Abs(dblLessAmount));
                                    strSQL = VoucherSW.gInsertSalesVoucher(strCompRefNo, strDate, 2, "Sales Accounts", "Cr", dblNetAmount - Math.Abs(dblRoundOff), 16, "As per Details", "0001", 2, "", "", "", "", "", "");
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();

                                    strSQL = VoucherSW.gInsertSalesVoucher(strCompRefNo, strDate, 1, strPartyname, "Dr", dblNetAmount, 16, "As per Details", "0001", 0, "", "", "", "");
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();

                                    strSQL = VoucherSW.gInsertSalesVoucher(strCompRefNo, strDate, 3, "Round Off", "Cr", Math.Abs(dblRoundOff), 16, "As per Details", "0001", 2, "+", "", "", "", "", "");
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                }
                                Prog.Value += 1;
                            }

                        }
                    }

                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    cmdInsert.Dispose();
                    MessageBox.Show("Ok");
                    this.Dispose();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private void updateAccVoucher()
        {
            string strSQL = "", strString = "", strCompRefNo, strKey, strDate="",strLedgerName="", strPartyname = "", strSymbol = "";
            double dblNetAmount = 0, dblDebitAmount = 0, dblCreditAmount = 0,dblLoose=0;
            int lngloop = 0;
            string connstring = Utility.SQLConnstringComSwitch(strComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                try
                {
                    gcnMain.Open();
                    SqlDataReader dr;
                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    Prog.Value = 0;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;
                   
                    strSQL = "select COMP_REF_NO,sum(VOUCHER_DEBIT_AMOUNT),sum(VOUCHER_CREDIT_AMOUNT)  from ACC_VOUCHER ";
                    strSQL = strSQL + "WHERE COMP_VOUCHER_TYPE =16 ";
                    strSQL=strSQL + "group by COMP_REF_NO having sum(VOUCHER_DEBIT_AMOUNT) <> sum(VOUCHER_CREDIT_AMOUNT) ";
                    //strSQL = strSQL + "AND COMP_REF_NO ='SI0001D-65569'";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    while (dr.Read())
                    {
                        strString = strString + dr["COMP_REF_NO"].ToString() + "|";
                        lngloop += 1;
                    }
                    dr.Close();
                    if (strString != "")
                    {
                        Prog.Value = 0;
                        string[] words = strString.Split('|');
                        Prog.Maximum = lngloop;
                        foreach (string strBill in words)
                        {
                            string[] ooCost = strBill.Split('~');
                            if (ooCost[0] != "")
                            {

                                strCompRefNo = ooCost[0].ToString();
                                //strKey = ooCost[1].ToString();
                                //strDate = Convert.ToDateTime(ooCost[2]).ToString("dd-MM-yyyy");
                                //strLedgerName = ooCost[3].ToString();
                                //dblNetAmount = Convert.ToDouble(words[4].ToString());
                                strSQL = "SELECT LEDGER_NAME ,COMP_VOUCHER_DATE,VOUCHER_DEBIT_AMOUNT  from ACC_VOUCHER WHERE COMP_VOUCHER_TYPE =16 and COMP_REF_NO ='" + strCompRefNo + "' and  LEDGER_NAME  <> 'Sales Accounts'  AND  LEDGER_NAME  <> 'Loose Medicine Sale' ";
                                cmdInsert.CommandText = strSQL;
                                dr = cmdInsert.ExecuteReader();
                                if (dr.Read())
                                {
                                    strPartyname = dr["LEDGER_NAME"].ToString();
                                    strDate = Convert.ToDateTime(dr["COMP_VOUCHER_DATE"]).ToString("dd-MM-yyyy");
                                    dblDebitAmount = Convert.ToDouble(dr["VOUCHER_DEBIT_AMOUNT"].ToString());
                                }
                                dr.Close();
                                strSQL = "SELECT LEDGER_NAME,VOUCHER_CREDIT_AMOUNT from ACC_VOUCHER WHERE COMP_VOUCHER_TYPE =16 and COMP_REF_NO ='" + strCompRefNo + "' and LEDGER_NAME ='Sales Accounts' ";
                                cmdInsert.CommandText = strSQL;
                                dr = cmdInsert.ExecuteReader();
                                if (dr.Read())
                                {
                                    strLedgerName = dr["LEDGER_NAME"].ToString();
                                    dblCreditAmount = Convert.ToDouble(dr["VOUCHER_CREDIT_AMOUNT"].ToString());

                                }
                                dr.Close();
                                strSQL = "SELECT VOUCHER_CREDIT_AMOUNT from ACC_VOUCHER WHERE COMP_VOUCHER_TYPE =16 and COMP_REF_NO ='" + strCompRefNo + "' and LEDGER_NAME ='Loose Medicine Sale'";
                                cmdInsert.CommandText = strSQL;
                                dr = cmdInsert.ExecuteReader();
                                if (dr.Read())
                                {

                                    dblLoose = Convert.ToDouble(dr["VOUCHER_CREDIT_AMOUNT"].ToString());
                                }
                                dr.Close();
                                strSQL = "DELETE FROM ACC_VOUCHER WHERE COMP_REF_NO='" + strCompRefNo + "' ";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();

                                //dblCredit = dblCredit - ((Math.Abs(dblRoundOff) + Math.Abs(dblAddAmount)) - Math.Abs(dblLessAmount));
                                strSQL = VoucherSW.gInsertSalesVoucher(strCompRefNo, strDate, 1, strPartyname, "Dr", dblCreditAmount + dblLoose, 16, "As per Details", "0001", 0, "", "", "", "");
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();

                                strSQL = VoucherSW.gInsertSalesVoucher(strCompRefNo, strDate, 2, "Sales Accounts", "Cr", dblCreditAmount, 16, "As per Details", "0001", 2, "", "", "", "", "", "");
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                strSQL = VoucherSW.gInsertSalesVoucher(strCompRefNo, strDate, 3, "Loose Medicine Sale", "Cr", dblLoose, 16, "As per Details", "0001", 2, "-", "", "", "", "", "");
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                double dblTotalAmnt = (dblCreditAmount + dblLoose);
                                strSQL = "UPDATE ACC_COMPANY_VOUCHER SET COMP_VOUCHER_AMOUNT =" + dblCreditAmount + " ";
                                strSQL = strSQL + ",COMP_VOUCHER_ADD_AMOUNT=" + dblLoose + " ";
                                strSQL = strSQL + ",COMP_VOUCHER_NET_AMOUNT=" + dblTotalAmnt + " ";
                                strSQL = strSQL + "  WHERE COMP_REF_NO='" + strCompRefNo + "' ";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();

                                Prog.Value += 1;
                            }

                        }
                    }

                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    cmdInsert.Dispose();
                    MessageBox.Show("Ok");
                    this.Dispose();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private void updateAG()
        {
            string strSQL = "", strString = "", strGroupName = "",strGrParent="",strGrOneDown="",strprimary="";
            double dblLedgerOpn = 0, dblGroupDrAmount = 0, dblDr = 0,dblCr=0;;
            int lngloop = 0;
            string connstring = Utility.SQLConnstringComSwitch(strComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                try
                {
                    gcnMain.Open();
                    SqlDataReader dr;
                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    Prog.Value = 0;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;

                    strSQL = "SELECT GR_NAME,GR_PARENT ";
                    strSQL = strSQL + "FROM ACC_LEDGERGROUP ";
                    //strSQL = strSQL + "WHERE GR_PARENT = '" + vstrGroupName + "'";
                    // strSQL = strSQL + "AND GR_GROUP <> 401 ";
                    //strSQL = strSQL + "WHERE GR_PARENT='Advance Deposit & Prepayment' ";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    while (dr.Read())
                    {
                        strString = strString + dr["GR_NAME"].ToString() + "|";
                        lngloop += 1;
                    }
                    dr.Close();
                    if (strString != "")
                    {
                        Prog.Value = 0;
                        string[] words = strString.Split('|');
                        Prog.Maximum = lngloop;
                        foreach (string strBill in words)
                        {
                            string[] ooCost = strBill.Split('~');
                            if (ooCost[0] != "")
                            {

                                strGroupName = ooCost[0].ToString();
                                //if (strGroupName == "Advance Deposit & Prepayment")
                                //{
                                //    MessageBox.Show("");
                                //}
                                strSQL = "select isnull(sum(LEDGER_OPENING_BALANCE),0) amnt from ACC_LEDGER_Z_D_A_GROUP_OPN  ";
                                strSQL = strSQL + "WHERE  ZONE='" + ooCost[0] + "' or division ='" + ooCost[0] + "' or Area ='" + ooCost[0] + "'";
                                cmdInsert.CommandText = strSQL;
                                dr = cmdInsert.ExecuteReader();
                                if (dr.Read())
                                {

                                    dblGroupDrAmount = Convert.ToDouble(dr["amnt"]);
                                    dr.Close();
                                   
                                    if (dblGroupDrAmount > 0)
                                    {
                                        dblCr = dblGroupDrAmount;
                                        dblDr = 0;
                                    }
                                    else
                                    {
                                        dblDr = 0;
                                        dblDr = dblGroupDrAmount;
                                    }

                                    dr.Close();


                                    if (dblGroupDrAmount != 0)
                                    {

                                        strSQL = "UPDATE ACC_LEDGERGROUP SET GR_OPENING_DEBIT=" + dblDr + ",";
                                        strSQL = strSQL + "GR_OPENING_CREDIT =" + dblCr + " ";
                                        strSQL = strSQL + " WHERE GR_NAME='" + ooCost[0] + "' ";
                                        cmdInsert.CommandText = strSQL;
                                        cmdInsert.ExecuteNonQuery();
                                    }
                                    else
                                    {


                                        strSQL = "SELECT isnull(SUM(GR_OPENING_DEBIT),0) amnt FROM ACC_LEDGERGROUP WHERE GR_PARENT = '" + ooCost[0].ToString() + "' ";
                                        cmdInsert.CommandText = strSQL;
                                        dr = cmdInsert.ExecuteReader();
                                        if (dr.Read())
                                        {
                                            dblGroupDrAmount = Convert.ToDouble(dr["amnt"]);
                                            if (dblGroupDrAmount > 0)
                                            {
                                                dblCr = dblGroupDrAmount;
                                                dblDr = 0;
                                            }
                                            else
                                            {
                                                dblCr = 0;
                                                dblDr = dblGroupDrAmount;
                                            }
                                            dr.Close();
                                            if (dblGroupDrAmount != 0)
                                            {
                                                strSQL = "UPDATE ACC_LEDGERGROUP SET GR_OPENING_DEBIT=" + dblDr + ",";
                                                strSQL = strSQL + "GR_OPENING_CREDIT =" + dblCr + " ";
                                                strSQL = strSQL + " WHERE GR_NAME='" + ooCost[0] + "' ";
                                                cmdInsert.CommandText = strSQL;
                                                cmdInsert.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                }

                                dr.Close();

                                dblGroupDrAmount = 0;
                                dblDr = 0;
                                dblCr = 0;
                                Prog.Value += 1;
                            }

                        }
                    }

                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    cmdInsert.Dispose();
                    MessageBox.Show("Ok");
                    this.Dispose();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
      


        private void btnOk_Click(object sender, EventArgs e)
        {
            if (strFormType == "SI")
            {
                upDateSIVoucher();
            }
            else if (strFormType == "AC")
            {
                updateAccVoucher();
            }
            else if (strFormType == "AG")
            {
                updateAG();
            }
        }

        private void frmScript_Load(object sender, EventArgs e)
        {
            this.Text = "Update Script";
        }

       

      

       
    
       
    }
}