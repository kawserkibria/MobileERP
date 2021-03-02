using Dutility;
using EX.Projection.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX.Projection.Dal
{
    public class JProjection
    {
        public string connstring;

        #region "Perfarmance"
        public string mDeletePerformanve(string strcomId)
        {
            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strcomId);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = gcnMain;
                strSQL = "DELETE FROM SALES_PERFORMANCE ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                return "1";
            }
        }
        public string mInsertMpoPerformance(string strDeComID, string strLedgerName, string strFdate, string strTdate, int intmode,int intSelection)
        {
            string strSQL = null, strCurrentDate = "", strPYearSales = "", strPYearColl = "", strCompare = "", strCYearSalesBud = "",
                                    strCYearSalesAch = "", strCollAc = "", strCollBud = "",strPyearFdate="",strPYearTDate="";
            double dblbudget = 0, dblAcheive = 0, dblPrevious = 0, dblacPreColl = 0, dblPercentage = 0,
                      dblColbudget = 0, dblColAcheive = 0, dblColPrevious = 0, dbMonthVoucher = 0,
                      dblTotalcoll = 0, dblColPercentage = 0, dblUpdateSales = 0, dblUptodateSalesAch = 0,
                      dblUptodateSaesPer = 0, dblUpdateCollBud = 0, dblUptodateCollAcc = 0, dblUptodateCollPer = 0, dblUptodatePrevious = 0, dblBalance = 0;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlDataReader dr;
                strCurrentDate = Utility.LastDayOfMonth(DateTime.Now.AddMonths(-1)).ToString("dd-MM-yyyy");
                strPYearSales = "Sales " + Convert.ToDateTime(strFdate).AddYears(-1).ToString("yy");
                strPYearColl = "Coll " + Convert.ToDateTime(strFdate).AddYears(-1).ToString("yy");
                strPyearFdate = "01" + "/"  + "01" +"/" + Convert.ToDateTime(strFdate).AddYears(-1).ToString("yyyy");
                strPYearTDate = "31" + "/" + "12" + "/" + Convert.ToDateTime(strFdate).AddYears(-1).ToString("yyyy");

                strCompare = "Comp" + Convert.ToDateTime(strFdate).AddYears(-1).ToString("yy") + "/" + Utility.Right(strTdate, 2);

                strCYearSalesBud = "Sales B " + Convert.ToDateTime(strFdate).ToString("yy");
                strCYearSalesAch = "Sales A " + Convert.ToDateTime(strFdate).ToString("yy");


                strCollAc = "Coll A " + Convert.ToDateTime(strFdate).ToString("yy");
                strCollBud = "Coll B " + Convert.ToDateTime(strFdate).ToString("yy");
                List<Mprojection> ooPer = new List<Mprojection>();
                SqlCommand cmdInsert = new SqlCommand();
                SqlTransaction myTrans;
                myTrans = gcnMain.BeginTransaction();
                cmdInsert.Connection = gcnMain;
                cmdInsert.Transaction = myTrans;
                if (intSelection == 0)
                {
                    //strSQL = "DELETE FROM SALES_PERFORMANCE ";
                    ////cmdInsert.CommandText = strSQL;
                    ////cmdInsert.ExecuteNonQuery();
                }
                //Previous Sales******************************
                if (intSelection == 0) //Mpo
                {
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + " SELECT 0,'" + strPYearSales + "', ACC_LEDGER.LEDGER_NAME ,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) MM, ISNULL(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT -ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0) AMNT ";
                    strSQL = strSQL + " ,1 FROM SMART0002.DBO.ACC_LEDGER ,SMART0002.DBO.ACC_VOUCHER WHERE ACC_LEDGER.LEDGER_NAME =ACC_VOUCHER.LEDGER_NAME AND ACC_LEDGER.LEDGER_GROUP =202 ";
                    //strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE < (" + Utility.cvtSQLDateString(strFdate) + ")  ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strPyearFdate) + " ";
                    strSQL = strSQL + "AND " + Utility.cvtSQLDateString(strPYearTDate) + " ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE =16 ";
                    strSQL = strSQL + " AND ACC_LEDGER.LEDGER_STATUS IN  (0,1) ";
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID='0001' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER.LEDGER_NAME='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER.LEDGER_NAME,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    strSQL = strSQL + "ORDER BY MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE)  ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    //Sales Budget
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 0,'" + strCYearSalesBud + "', LEDGER_NAME ,MONTH(TARGET_ACHIEVE_FROM_DATE) MM,ISNULL(SUM(TARGET_ACHIEVE_AMOUNT),0) AMNT,2 ";
                    strSQL = strSQL + "FROM SALES_TARGET_ACHIEVEMENT  WHERE  ";
                    strSQL = strSQL + "TARGET_ACHIEVE_FROM_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                    }

                    strSQL = strSQL + "GROUP BY LEDGER_NAME,MONTH(TARGET_ACHIEVE_FROM_DATE)  ";
                    strSQL = strSQL + "ORDER BY MONTH(TARGET_ACHIEVE_FROM_DATE)  ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,UP_TO_DATE_AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 0,'" + strCYearSalesBud + "', LEDGER_NAME ,MONTH(TARGET_ACHIEVE_FROM_DATE) MM,ISNULL(SUM(TARGET_ACHIEVE_AMOUNT),0) AMNT,2 ";
                    strSQL = strSQL + "FROM SALES_TARGET_ACHIEVEMENT  WHERE  ";
                    strSQL = strSQL + "TARGET_ACHIEVE_FROM_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY LEDGER_NAME,MONTH(TARGET_ACHIEVE_FROM_DATE)  ";
                    strSQL = strSQL + "ORDER BY MONTH(TARGET_ACHIEVE_FROM_DATE)  ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    // Sales Achieve
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 0,'" + strCYearSalesAch + "', ACC_LEDGER.LEDGER_NAME ,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) MM, ISNULL(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT -ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0) AMNT,3 ";
                    strSQL = strSQL + "FROM ACC_LEDGER ,ACC_VOUCHER WHERE ACC_LEDGER.LEDGER_NAME =ACC_VOUCHER.LEDGER_NAME AND ACC_LEDGER.LEDGER_GROUP =202 ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE =16 ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER.LEDGER_NAME='" + strLedgerName + "'";
                    }

                    strSQL = strSQL + "GROUP BY ACC_LEDGER.LEDGER_NAME,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE)  ";
                    strSQL = strSQL + "ORDER BY MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE)  ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,UP_TO_DATE_AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 0,'" + strCYearSalesAch + "', ACC_LEDGER.LEDGER_NAME ,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) MM, ISNULL(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT -ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0) AMNT,3 ";
                    strSQL = strSQL + "FROM ACC_LEDGER ,ACC_VOUCHER WHERE ACC_LEDGER.LEDGER_NAME =ACC_VOUCHER.LEDGER_NAME AND ACC_LEDGER.LEDGER_GROUP =202 ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE =16 ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER.LEDGER_NAME='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER.LEDGER_NAME,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE)  ";
                    strSQL = strSQL + "ORDER BY MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE)  ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    //Previous Coll
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'" + strPYearColl + "', ACC_LEDGER.LEDGER_NAME ,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) MM, abs(ISNULL(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT -ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0)) AMNT ";
                    strSQL = strSQL + ",6 FROM SMART0002.DBO.ACC_LEDGER ,SMART0002.DBO.ACC_VOUCHER WHERE ACC_LEDGER.LEDGER_NAME =ACC_VOUCHER.LEDGER_NAME AND ACC_LEDGER.LEDGER_GROUP =202 ";
                    //strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE < (" + Utility.cvtSQLDateString(strFdate) + ")  ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strPyearFdate) + " ";
                    strSQL = strSQL + "AND " + Utility.cvtSQLDateString(strPYearTDate) + " ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE =1 ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER.LEDGER_NAME='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + " AND ACC_LEDGER.LEDGER_STATUS =0 ";
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID='0001' ";
                    strSQL = strSQL + "GROUP BY ACC_LEDGER.LEDGER_NAME,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE)  ";
                    strSQL = strSQL + "ORDER BY MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    ///hlpf************
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'" + strPYearColl + "', ACC_LEDGER.LEDGER_NAME ,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) MM, abs(ISNULL(SUM(ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0)) *-1 AMNT ";
                    strSQL = strSQL + ",6 FROM SMART0002.DBO.ACC_LEDGER ,SMART0002.DBO.ACC_VOUCHER WHERE ACC_LEDGER.LEDGER_NAME =ACC_VOUCHER.REVERSE_LEDGER1 AND ACC_LEDGER.LEDGER_GROUP =202 ";
                    //strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE < (" + Utility.cvtSQLDateString(strFdate) + ")  ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strPyearFdate) + " ";
                    strSQL = strSQL + "AND " + Utility.cvtSQLDateString(strPYearTDate) + " ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE =3 AND ACC_VOUCHER.AUTOJV=1 ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER.LEDGER_NAME='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + " AND ACC_LEDGER.LEDGER_STATUS =0 ";
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID='0001' ";
                    strSQL = strSQL + "GROUP BY ACC_LEDGER.LEDGER_NAME,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE)  ";
                    strSQL = strSQL + "ORDER BY MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    /////****

                    //Coll Budget
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'" + strCollBud + "', LEDGER_NAME ,MONTH(COLL_TARGET_FROM_DATE) MM,abs(ISNULL(SUM(COLL_TARGET_COLL_AMT),0)) AMNT ";
                    strSQL = strSQL + ",7 FROM SALES_COLL_TARGET_TRAN  WHERE  ";
                    strSQL = strSQL + "COLL_TARGET_FROM_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY LEDGER_NAME,MONTH(COLL_TARGET_FROM_DATE) ";
                    strSQL = strSQL + "ORDER BY MONTH(COLL_TARGET_FROM_DATE) ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,UP_TO_DATE_AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'" + strPYearColl + "', LEDGER_NAME ,MONTH(COLL_TARGET_FROM_DATE) MM,abs(ISNULL(SUM(COLL_TARGET_COLL_AMT),0)) AMNT ";
                    strSQL = strSQL + ",7 FROM SALES_COLL_TARGET_TRAN  WHERE  ";
                    strSQL = strSQL + "COLL_TARGET_FROM_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY LEDGER_NAME,MONTH(COLL_TARGET_FROM_DATE) ";
                    strSQL = strSQL + "ORDER BY MONTH(COLL_TARGET_FROM_DATE) ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    //Coll Achieve
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'" + strCollAc + "', ACC_LEDGER.LEDGER_NAME ,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE), abs(ISNULL(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT -ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0)) AMNT ";
                    strSQL = strSQL + ",8 FROM ACC_LEDGER ,ACC_VOUCHER WHERE ACC_LEDGER.LEDGER_NAME =ACC_VOUCHER.LEDGER_NAME AND ACC_LEDGER.LEDGER_GROUP =202 ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE =1 ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER.LEDGER_NAME='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + " AND ACC_LEDGER.LEDGER_STATUS =0 ";
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID='0001' ";
                    strSQL = strSQL + "GROUP BY ACC_LEDGER.LEDGER_NAME,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    strSQL = strSQL + "ORDER BY MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    //hl_pf***********************************************
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'" + strCollAc + "', ACC_LEDGER.LEDGER_NAME ,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE), abs(ISNULL(SUM(ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0)) *-1 AMNT ";
                    strSQL = strSQL + ",8 FROM ACC_LEDGER ,ACC_VOUCHER WHERE ACC_LEDGER.LEDGER_NAME =ACC_VOUCHER.REVERSE_LEDGER1 AND ACC_LEDGER.LEDGER_GROUP =202 ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE =3 AND  ACC_VOUCHER.AUTOJV=1 ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER.LEDGER_NAME='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + " AND ACC_LEDGER.LEDGER_STATUS IN  (0,1) ";
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID='0001' ";
                    strSQL = strSQL + "GROUP BY ACC_LEDGER.LEDGER_NAME,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    strSQL = strSQL + "ORDER BY MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    //****


                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,UP_TO_DATE_AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'" + strCollAc + "', ACC_LEDGER.LEDGER_NAME ,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE), abs(ISNULL(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT -ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0)) AMNT ";
                    strSQL = strSQL + ",8 FROM ACC_LEDGER ,ACC_VOUCHER WHERE ACC_LEDGER.LEDGER_NAME =ACC_VOUCHER.LEDGER_NAME AND ACC_LEDGER.LEDGER_GROUP =202 ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE =1 ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER.LEDGER_NAME='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER.LEDGER_NAME,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    strSQL = strSQL + "ORDER BY MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    //Voucher
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'Voucher', ACC_LEDGER.LEDGER_NAME ,1, ";
                    strSQL = strSQL + "0 ,10 FROM ACC_LEDGER  ";
                    strSQL = strSQL + "WHERE  LEDGER_GROUP =202 ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY LEDGER_NAME ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'Voucher', ACC_LEDGER.LEDGER_NAME ,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE), ISNULL(SUM(ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT-ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT),0) AMNT ";
                    strSQL = strSQL + ",10 FROM ACC_LEDGER ,ACC_VOUCHER,ACC_COMPANY_VOUCHER WHERE ACC_COMPANY_VOUCHER.COMP_REF_NO =ACC_VOUCHER.COMP_REF_NO AND  ACC_LEDGER.LEDGER_NAME =ACC_VOUCHER.LEDGER_NAME AND ACC_LEDGER.LEDGER_GROUP =202 ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE =3 ";
                    strSQL = strSQL + "and ACC_COMPANY_VOUCHER.SP_JOURNAL =1 ";
                    //strSQL = strSQL + " AND ACC_LEDGER.LEDGER_STATUS =0 ";
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID='0001' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER.LEDGER_NAME='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER.LEDGER_NAME, MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    strSQL = strSQL + "ORDER BY MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'Others', ACC_LEDGER.LEDGER_NAME ,1, ";
                    strSQL = strSQL + "0 ,15 FROM ACC_LEDGER  ";
                    strSQL = strSQL + "WHERE  LEDGER_GROUP =202 ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY LEDGER_NAME ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'Others', ACC_LEDGER.LEDGER_NAME ,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE), ISNULL(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT-ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0) AMNT ";
                    strSQL = strSQL + ",15 FROM ACC_LEDGER ,ACC_VOUCHER WHERE ACC_LEDGER.LEDGER_NAME =ACC_VOUCHER.LEDGER_NAME AND ACC_LEDGER.LEDGER_GROUP =202 ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE =3 ";
                    strSQL = strSQL + "AND ACC_VOUCHER.TRANSFER_TYPE =5 ";
                    //strSQL = strSQL + " AND ACC_LEDGER.LEDGER_STATUS =0 ";
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID='0001' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER.LEDGER_NAME='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER.LEDGER_NAME, MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    strSQL = strSQL + "ORDER BY MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();




                    for (int i = 1; i <= 12; i++)
                    {
                        
                        //Sales
                        strSQL = "SELECT AMNT FROM SALES_PERFORMANCE WHERE MONTH_NO=" + i + " ";
                        strSQL = strSQL + "AND PARTICULARS='" + strCYearSalesBud + "'";
                        if (strLedgerName != "")
                        {
                            strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                        }
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {
                            dblbudget = Math.Abs(Convert.ToDouble(dr["AMNT"]));
                        }
                        dr.Close();
                        strSQL = "SELECT AMNT FROM SALES_PERFORMANCE WHERE MONTH_NO=" + i + " ";
                        strSQL = strSQL + "AND PARTICULARS='" + strCYearSalesAch + "'";
                        if (strLedgerName != "")
                        {
                            strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                        }
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {
                            dblAcheive = Math.Abs(Convert.ToDouble(dr["AMNT"]));
                        }
                        dr.Close();

                        strSQL = "SELECT AMNT FROM SALES_PERFORMANCE WHERE MONTH_NO=" + i + " ";
                        strSQL = strSQL + "AND PARTICULARS='" + strPYearSales + "' ";
                        if (strLedgerName != "")
                        {
                            strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                        }
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {
                            dblPrevious = Math.Abs(Convert.ToDouble(dr["AMNT"]));
                        }
                        dr.Close();
                        if (dblAcheive != 0 && dblbudget != 0)
                        {
                            dblPercentage = Math.Round(dblAcheive / dblbudget, 2) * 100;
                        }
                        else
                        {
                            dblPercentage = 0;
                        }

                        dblacPreColl = dblAcheive - dblPrevious;
                        strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                        strSQL = strSQL + "SELECT 0,'Sales Ach(%)','" + strLedgerName + "'," + i + "," + dblPercentage + ",4";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                        strSQL = strSQL + "SELECT 0,'" + strCompare + "','" + strLedgerName + "'," + i + "," + dblacPreColl + ",5";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        //Collection
                        strSQL = "SELECT AMNT FROM SALES_PERFORMANCE WHERE MONTH_NO=" + i + " ";
                        strSQL = strSQL + "AND PARTICULARS='Voucher' ";
                        if (strLedgerName != "")
                        {
                            strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                        }
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {
                            dbMonthVoucher = Math.Abs(Convert.ToDouble(dr["AMNT"]));
                        }
                        dr.Close();
                        strSQL = "SELECT AMNT FROM SALES_PERFORMANCE WHERE MONTH_NO=" + i + " ";
                        strSQL = strSQL + "AND PARTICULARS='" + strCollBud + "' ";
                        if (strLedgerName != "")
                        {
                            strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                        }
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {
                            dblColbudget = Math.Abs(Convert.ToDouble(dr["AMNT"]));
                        }
                        dr.Close();
                        strSQL = "SELECT AMNT FROM SALES_PERFORMANCE WHERE MONTH_NO=" + i + " ";
                        strSQL = strSQL + "AND PARTICULARS='" + strCollAc + "' ";
                        if (strLedgerName != "")
                        {
                            strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                        }
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {
                            dblColAcheive = Math.Abs(Convert.ToDouble(dr["AMNT"]));
                        }
                        dr.Close();

                        strSQL = "SELECT AMNT FROM SALES_PERFORMANCE WHERE MONTH_NO=" + i + " ";
                        strSQL = strSQL + "AND PARTICULARS='" + strPYearColl + "'";
                        if (strLedgerName != "")
                        {
                            strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                        }
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {
                            dblColPrevious = Convert.ToDouble(dr["AMNT"]);
                        }
                        dr.Close();
                        if (dblColbudget != 0 && dblColAcheive != 0)
                        {
                            dblColPercentage = Math.Round(dblColAcheive / dblColbudget, 2) * 100;
                        }
                        else
                        {
                            dblColPercentage = 0;
                        }
                        dblacPreColl = 0;
                        dblTotalcoll = dblColAcheive + dbMonthVoucher;
                        dblacPreColl = dblColAcheive - dblColPrevious;
                        strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                        strSQL = strSQL + "SELECT 1,'Coll Ach(%)','" + strLedgerName + "'," + i + "," + dblColPercentage + ",9";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                        strSQL = strSQL + "SELECT 1,'Total Coll','" + strLedgerName + "'," + i + "," + dblTotalcoll + ",11";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                        strSQL = strSQL + "SELECT 1,'" + strCompare + "','" + strLedgerName + "'," + i + "," + dblacPreColl + ",20";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        dblColPercentage = 0;
                        dblTotalcoll = 0;
                        dblColAcheive = 0;
                        dblColbudget = 0;

                        dblPercentage = 0;
                        dblacPreColl = 0;
                        dblPrevious = 0;
                        dblAcheive = 0;
                        dblbudget = 0;
                    }

                    //UptoDate

                    strSQL = "SELECT ISNULL(SUM(UP_TO_DATE_AMNT),0) UP_TO_DATE_AMNT  FROM SALES_PERFORMANCE ";
                    strSQL = strSQL + "WHERE PARTICULARS='" + strCYearSalesBud + "'";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                    }
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        dblUpdateSales = Math.Abs(Convert.ToDouble(dr["UP_TO_DATE_AMNT"]));
                    }
                    dr.Close();
                    strSQL = "SELECT ISNULL(SUM(UP_TO_DATE_AMNT),0) UP_TO_DATE_AMNT FROM SALES_PERFORMANCE  ";
                    strSQL = strSQL + "WHERE PARTICULARS='" + strCYearSalesAch + "' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                    }
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        dblUptodateSalesAch = Math.Abs(Convert.ToDouble(dr["UP_TO_DATE_AMNT"]));
                    }
                    dr.Close();

                    dblBalance = 0;
                    dblBalance = Math.Round(dblUpdateSales - dblUptodateSalesAch);
                    
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,BALANCE,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 0,'Sales Ach(%)','" + strLedgerName + "',1," + dblBalance + ",4";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    //strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,BALANCE,SORTING_TYPE) ";
                    //strSQL = strSQL + "SELECT 0,'Sales Ach(%)','" + strLedgerName + "',1," + dblTotal + ",4";
                    //cmdInsert.CommandText = strSQL;
                    //cmdInsert.ExecuteNonQuery();

                    strSQL = "SELECT ISNULL(SUM(UP_TO_DATE_AMNT),0) UP_TO_DATE_AMNT FROM SALES_PERFORMANCE ";
                    strSQL = strSQL + "WHERE PARTICULARS='" + strPYearSales + "' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                    }
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        dblUptodatePrevious = Math.Abs(Convert.ToDouble(dr["UP_TO_DATE_AMNT"]));
                    }
                    dr.Close();
                    dblacPreColl = 0;
                    dblacPreColl = dblUptodateSalesAch - dblUptodatePrevious;

                    if (dblUpdateSales != 0 && dblUptodateSalesAch != 0)
                    {
                        dblUptodateSaesPer = Math.Round(dblUptodateSalesAch / dblUpdateSales, 2) * 100;
                    }
                    else
                    {
                        dblUptodateSaesPer = 0;
                    }


                    strSQL = "SELECT ISNULL(SUM(AMNT),0) UP_TO_DATE_AMNT FROM SALES_PERFORMANCE ";
                    strSQL = strSQL + "WHERE PARTICULARS='" + strCollBud + "' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                    }
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        dblUpdateCollBud = Math.Abs(Convert.ToDouble(dr["UP_TO_DATE_AMNT"]));
                    }
                    dr.Close();
                    strSQL = "SELECT ISNULL(SUM(AMNT),0) UP_TO_DATE_AMNT FROM SALES_PERFORMANCE ";
                    strSQL = strSQL + "WHERE PARTICULARS='" + strCollAc + "' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                    }
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        dblUptodateCollAcc = Math.Abs(Convert.ToDouble(dr["UP_TO_DATE_AMNT"]));
                    }
                    dr.Close();
                    if (dblUpdateCollBud != 0 && dblUptodateCollAcc != 0)
                    {
                        dblUptodateCollPer = Math.Round(dblUptodateCollAcc / dblUpdateCollBud, 2) * 100;
                    }
                    else
                    {
                        dblUptodateCollPer = 0;
                    }
                    dblBalance = 0;
                    dblBalance = Math.Round(dblUpdateCollBud - dblUptodateCollAcc);

                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,TOTAL_PERCENT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 0,'Sales Ach(%)','" + strLedgerName + "',1," + dblUptodateSaesPer + ",4";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,TOTAL_PERCENT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'Coll Ach(%)','" + strLedgerName + "',1," + dblUptodateCollPer + ",9";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,UP_TO_DATE_AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 0,'" + strCompare + "','" + strLedgerName + "',1," + dblacPreColl + ",5";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,BALANCE,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'Coll Ach(%)','" + strLedgerName + "',1," + dblBalance + ",9";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    dr.Close();
                }
                else if (intSelection == 1)//Area
                {
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + " SELECT 0,'" + strPYearSales + "', ACC_LEDGER_Z_D_A.AREA ,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) MM, ISNULL(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT -ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0) AMNT ";
                    strSQL = strSQL + " ,1 FROM SMART0002.DBO.ACC_LEDGER_Z_D_A ,SMART0002.DBO.ACC_VOUCHER WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME =ACC_VOUCHER.LEDGER_NAME ";
                    //strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE < (" + Utility.cvtSQLDateString(strFdate) + ")  ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strPyearFdate) + " ";
                    strSQL = strSQL + "AND " + Utility.cvtSQLDateString(strPYearTDate) + " ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE =16 ";
                    strSQL = strSQL + " AND ACC_LEDGER_Z_D_A.LEDGER_STATUS IN (0,1) ";
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID='0001' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.AREA='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.AREA,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    strSQL = strSQL + "ORDER BY MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE)  ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();


                    //Sales Budget
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 0,'" + strCYearSalesBud + "', ACC_LEDGER_Z_D_A.AREA ,MONTH(SALES_TARGET_ACHIEVEMENT.TARGET_ACHIEVE_FROM_DATE) MM,ISNULL(SUM(SALES_TARGET_ACHIEVEMENT.TARGET_ACHIEVE_AMOUNT),0) AMNT,2 ";
                    strSQL = strSQL + "FROM SALES_TARGET_ACHIEVEMENT,ACC_LEDGER_Z_D_A  WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME=SALES_TARGET_ACHIEVEMENT.LEDGER_NAME ";
                    strSQL = strSQL + "AND SALES_TARGET_ACHIEVEMENT.TARGET_ACHIEVE_FROM_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.LEDGER_STATUS IN (0,1) ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.AREA='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.AREA,MONTH(SALES_TARGET_ACHIEVEMENT.TARGET_ACHIEVE_FROM_DATE)  ";
                    strSQL = strSQL + "ORDER BY MONTH(SALES_TARGET_ACHIEVEMENT.TARGET_ACHIEVE_FROM_DATE)  ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,UP_TO_DATE_AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 0,'" + strCYearSalesBud + "', ACC_LEDGER_Z_D_A.AREA ,MONTH(SALES_TARGET_ACHIEVEMENT.TARGET_ACHIEVE_FROM_DATE) MM,ISNULL(SUM(SALES_TARGET_ACHIEVEMENT.TARGET_ACHIEVE_AMOUNT),0) AMNT,2 ";
                    strSQL = strSQL + "FROM SALES_TARGET_ACHIEVEMENT,ACC_LEDGER_Z_D_A  WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME=SALES_TARGET_ACHIEVEMENT.LEDGER_NAME ";
                    strSQL = strSQL + "AND SALES_TARGET_ACHIEVEMENT.TARGET_ACHIEVE_FROM_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    strSQL = strSQL + " AND ACC_LEDGER_Z_D_A.LEDGER_STATUS IN (0,1) ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.AREA='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.AREA,MONTH(SALES_TARGET_ACHIEVEMENT.TARGET_ACHIEVE_FROM_DATE)  ";
                    strSQL = strSQL + "ORDER BY MONTH(SALES_TARGET_ACHIEVEMENT.TARGET_ACHIEVE_FROM_DATE)  ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    // Sales Achieve
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 0,'" + strCYearSalesAch + "', ACC_LEDGER_Z_D_A.AREA ,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) MM, ISNULL(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT -ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0) AMNT,3 ";
                    strSQL = strSQL + "FROM ACC_LEDGER_Z_D_A ,ACC_VOUCHER WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME =ACC_VOUCHER.LEDGER_NAME  ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE =16 ";
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID='0001' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.AREA='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.AREA,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE)  ";
                    strSQL = strSQL + "ORDER BY MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE)  ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,UP_TO_DATE_AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 0,'" + strCYearSalesAch + "', ACC_LEDGER_Z_D_A.AREA ,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) MM, ISNULL(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT -ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0) AMNT,3 ";
                    strSQL = strSQL + "FROM ACC_LEDGER_Z_D_A ,ACC_VOUCHER WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME =ACC_VOUCHER.LEDGER_NAME ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE =16 ";
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID='0001' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.AREA='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.AREA,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE)  ";
                    strSQL = strSQL + "ORDER BY MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE)  ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    //Previous Coll
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'" + strPYearColl + "', ACC_LEDGER_Z_D_A.AREA ,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) MM, abs(ISNULL(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT -ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0)) AMNT ";
                    strSQL = strSQL + ",6 FROM SMART0002.DBO.ACC_LEDGER_Z_D_A ,SMART0002.DBO.ACC_VOUCHER WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME =ACC_VOUCHER.LEDGER_NAME  ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strPyearFdate) + " ";
                    strSQL = strSQL + "AND " + Utility.cvtSQLDateString(strPYearTDate) + " ";
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID='0001' ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE =1 ";
                    strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.LEDGER_STATUS IN (0,1) ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.AREA='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.AREA,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE)  ";
                    strSQL = strSQL + "ORDER BY MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    //hl
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'" + strPYearColl + "', ACC_LEDGER_Z_D_A.AREA ,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) MM, abs(ISNULL(SUM(ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0)) *-1 AMNT ";
                    strSQL = strSQL + ",6 FROM SMART0002.DBO.ACC_LEDGER_Z_D_A ,SMART0002.DBO.ACC_VOUCHER WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME =ACC_VOUCHER.REVERSE_LEDGER1  ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strPyearFdate) + " ";
                    strSQL = strSQL + "AND " + Utility.cvtSQLDateString(strPYearTDate) + " ";
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID='0001' ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE =3 and ACC_VOUCHER.AUTOJV=1  ";
                    strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.LEDGER_STATUS IN (0,1) ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.AREA='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.AREA,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE)  ";
                    strSQL = strSQL + "ORDER BY MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();


                    //Coll Budget
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'" + strCollBud + "', ACC_LEDGER_Z_D_A.AREA ,MONTH(COLL_TARGET_FROM_DATE) MM,abs(ISNULL(SUM(COLL_TARGET_COLL_AMT),0)) AMNT ";
                    strSQL = strSQL + ",7 FROM SALES_COLL_TARGET_TRAN,ACC_LEDGER_Z_D_A  WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME=SALES_COLL_TARGET_TRAN.LEDGER_NAME ";
                    strSQL = strSQL + " AND SALES_COLL_TARGET_TRAN.COLL_TARGET_FROM_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.AREA='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.AREA,MONTH(SALES_COLL_TARGET_TRAN.COLL_TARGET_FROM_DATE) ";
                    strSQL = strSQL + "ORDER BY MONTH(SALES_COLL_TARGET_TRAN.COLL_TARGET_FROM_DATE) ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,UP_TO_DATE_AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'" + strPYearColl + "', ACC_LEDGER_Z_D_A.AREA ,MONTH(SALES_COLL_TARGET_TRAN.COLL_TARGET_FROM_DATE) MM,abs(ISNULL(SUM(SALES_COLL_TARGET_TRAN.COLL_TARGET_COLL_AMT),0)) AMNT ";
                    strSQL = strSQL + ",7 FROM SALES_COLL_TARGET_TRAN,ACC_LEDGER_Z_D_A  WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME=SALES_COLL_TARGET_TRAN.LEDGER_NAME   AND  ";
                    strSQL = strSQL + " SALES_COLL_TARGET_TRAN.COLL_TARGET_FROM_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.AREA='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.AREA,MONTH(SALES_COLL_TARGET_TRAN.COLL_TARGET_FROM_DATE) ";
                    strSQL = strSQL + "ORDER BY MONTH(SALES_COLL_TARGET_TRAN.COLL_TARGET_FROM_DATE) ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    //Coll Achieve
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'" + strCollAc + "', ACC_LEDGER_Z_D_A.AREA ,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE), abs(ISNULL(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT -ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0)) AMNT ";
                    strSQL = strSQL + ",8 FROM ACC_LEDGER_Z_D_A ,ACC_VOUCHER WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME =ACC_VOUCHER.LEDGER_NAME ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE =1 ";
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID='0001' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.AREA='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.AREA,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    strSQL = strSQL + "ORDER BY MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    //HL
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'" + strCollAc + "', ACC_LEDGER_Z_D_A.AREA ,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE), abs(ISNULL(SUM(ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0)) *-1 AMNT ";
                    strSQL = strSQL + ",8 FROM ACC_LEDGER_Z_D_A ,ACC_VOUCHER WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME =ACC_VOUCHER.REVERSE_LEDGER1 ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE =3 AND ACC_VOUCHER.AUTOJV=1 ";
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID='0001' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.AREA='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.AREA,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    strSQL = strSQL + "ORDER BY MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    //***

                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,UP_TO_DATE_AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'" + strCollAc + "', ACC_LEDGER_Z_D_A.AREA ,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE), abs(ISNULL(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT -ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0)) AMNT ";
                    strSQL = strSQL + ",8 FROM ACC_LEDGER_Z_D_A ,ACC_VOUCHER WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME =ACC_VOUCHER.LEDGER_NAME  ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE =1 ";
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID='0001' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.AREA='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.AREA,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    strSQL = strSQL + "ORDER BY MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    //Voucher
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'Voucher', '" + strLedgerName + "',1, ";
                    strSQL = strSQL + "0 ,10 ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'Voucher', ACC_LEDGER_Z_D_A.AREA ,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE), ISNULL(SUM(ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT-ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT),0) AMNT ";
                    strSQL = strSQL + ",10 FROM ACC_LEDGER_Z_D_A ,ACC_VOUCHER,ACC_COMPANY_VOUCHER WHERE ACC_COMPANY_VOUCHER.COMP_REF_NO =ACC_VOUCHER.COMP_REF_NO AND  ACC_LEDGER_Z_D_A.LEDGER_NAME =ACC_VOUCHER.LEDGER_NAME ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE =3 ";
                    strSQL = strSQL + "and ACC_COMPANY_VOUCHER.SP_JOURNAL =1 ";
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID='0001' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.AREA='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.AREA, MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    strSQL = strSQL + "ORDER BY MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'Others', '" + strLedgerName + "',1, ";
                    strSQL = strSQL + "0 ,15 ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'Others', ACC_LEDGER_Z_D_A.AREA ,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE), ISNULL(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT-ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0) AMNT ";
                    strSQL = strSQL + ",15 FROM ACC_LEDGER_Z_D_A ,ACC_VOUCHER WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME =ACC_VOUCHER.LEDGER_NAME  ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE =3 ";
                    strSQL = strSQL + "AND ACC_VOUCHER.TRANSFER_TYPE =5 ";
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID='0001' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.AREA='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.AREA, MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    strSQL = strSQL + "ORDER BY MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();




                    for (int i = 1; i <= 12; i++)
                    {

                        //Sales
                        strSQL = "SELECT AMNT FROM SALES_PERFORMANCE WHERE MONTH_NO=" + i + " ";
                        strSQL = strSQL + "AND PARTICULARS='" + strCYearSalesBud + "'";
                        if (strLedgerName != "")
                        {
                            strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                        }
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {
                            dblbudget = Math.Abs(Convert.ToDouble(dr["AMNT"]));
                        }
                        dr.Close();
                        strSQL = "SELECT AMNT FROM SALES_PERFORMANCE WHERE MONTH_NO=" + i + " ";
                        strSQL = strSQL + "AND PARTICULARS='" + strCYearSalesAch + "'";
                        if (strLedgerName != "")
                        {
                            strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                        }
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {
                            dblAcheive = Math.Abs(Convert.ToDouble(dr["AMNT"]));
                        }
                        dr.Close();

                        strSQL = "SELECT AMNT FROM SALES_PERFORMANCE WHERE MONTH_NO=" + i + " ";
                        strSQL = strSQL + "AND PARTICULARS='" + strPYearSales + "' ";
                        if (strLedgerName != "")
                        {
                            strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                        }
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {
                            dblPrevious = Math.Abs(Convert.ToDouble(dr["AMNT"]));
                        }
                        dr.Close();
                        if (dblAcheive != 0 && dblbudget != 0)
                        {
                            dblPercentage = Math.Round(dblAcheive / dblbudget, 2) * 100;
                        }
                        else
                        {
                            dblPercentage = 0;
                        }

                        dblacPreColl = dblAcheive - dblPrevious;
                        strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                        strSQL = strSQL + "SELECT 0,'Sales Ach(%)','" + strLedgerName + "'," + i + "," + dblPercentage + ",4";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                        strSQL = strSQL + "SELECT 0,'" + strCompare + "','" + strLedgerName + "'," + i + "," + dblacPreColl + ",5";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        //Collection
                        strSQL = "SELECT AMNT FROM SALES_PERFORMANCE WHERE MONTH_NO=" + i + " ";
                        strSQL = strSQL + "AND PARTICULARS='Voucher' ";
                        if (strLedgerName != "")
                        {
                            strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                        }
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {
                            dbMonthVoucher = Math.Abs(Convert.ToDouble(dr["AMNT"]));
                        }
                        dr.Close();
                        strSQL = "SELECT AMNT FROM SALES_PERFORMANCE WHERE MONTH_NO=" + i + " ";
                        strSQL = strSQL + "AND PARTICULARS='" + strCollBud + "' ";
                        if (strLedgerName != "")
                        {
                            strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                        }
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {
                            dblColbudget = Math.Abs(Convert.ToDouble(dr["AMNT"]));
                        }
                        dr.Close();
                        strSQL = "SELECT AMNT FROM SALES_PERFORMANCE WHERE MONTH_NO=" + i + " ";
                        strSQL = strSQL + "AND PARTICULARS='" + strCollAc + "' ";
                        if (strLedgerName != "")
                        {
                            strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                        }
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {
                            dblColAcheive = Math.Abs(Convert.ToDouble(dr["AMNT"]));
                        }
                        dr.Close();

                        strSQL = "SELECT AMNT FROM SALES_PERFORMANCE WHERE MONTH_NO=" + i + " ";
                        strSQL = strSQL + "AND PARTICULARS='" + strPYearColl + "'";
                        if (strLedgerName != "")
                        {
                            strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                        }
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {
                            dblColPrevious = Convert.ToDouble(dr["AMNT"]);
                        }
                        dr.Close();
                        if (dblColbudget != 0 && dblColAcheive != 0)
                        {
                            dblColPercentage = Math.Round(dblColAcheive / dblColbudget, 2) * 100;
                        }
                        else
                        {
                            dblColPercentage = 0;
                        }
                        dblacPreColl = 0;
                        dblTotalcoll = dblColAcheive + dbMonthVoucher;
                        dblacPreColl = dblColAcheive - dblColPrevious;
                        strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                        strSQL = strSQL + "SELECT 1,'Coll Ach(%)','" + strLedgerName + "'," + i + "," + dblColPercentage + ",9";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                        strSQL = strSQL + "SELECT 1,'Total Coll','" + strLedgerName + "'," + i + "," + dblTotalcoll + ",11";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                        strSQL = strSQL + "SELECT 1,'" + strCompare + "','" + strLedgerName + "'," + i + "," + dblacPreColl + ",20";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        dblColPercentage = 0;
                        dblTotalcoll = 0;
                        dblColAcheive = 0;
                        dblColbudget = 0;

                        dblPercentage = 0;
                        dblacPreColl = 0;
                        dblPrevious = 0;
                        dblAcheive = 0;
                        dblbudget = 0;
                        dr.Close();
                    }

                    //UptoDate

                    strSQL = "SELECT ISNULL(SUM(UP_TO_DATE_AMNT),0) UP_TO_DATE_AMNT  FROM SALES_PERFORMANCE ";
                    strSQL = strSQL + "WHERE PARTICULARS='" + strCYearSalesBud + "'";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                    }
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        dblUpdateSales = Math.Abs(Convert.ToDouble(dr["UP_TO_DATE_AMNT"]));
                    }
                    dr.Close();
                    strSQL = "SELECT ISNULL(SUM(UP_TO_DATE_AMNT),0) UP_TO_DATE_AMNT FROM SALES_PERFORMANCE  ";
                    strSQL = strSQL + "WHERE PARTICULARS='" + strCYearSalesAch + "' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                    }
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        dblUptodateSalesAch = Math.Abs(Convert.ToDouble(dr["UP_TO_DATE_AMNT"]));
                    }
                    dr.Close();

                    dblBalance = Math.Round(dblUpdateSales - dblUptodateSalesAch);

                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,BALANCE,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 0,'Sales Ach(%)','" + strLedgerName + "',1," + dblBalance + ",4";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "SELECT ISNULL(SUM(UP_TO_DATE_AMNT),0) UP_TO_DATE_AMNT FROM SALES_PERFORMANCE ";
                    strSQL = strSQL + "WHERE PARTICULARS='" + strPYearSales + "' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                    }
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        dblUptodatePrevious = Math.Abs(Convert.ToDouble(dr["UP_TO_DATE_AMNT"]));
                    }
                    dr.Close();
                    dblacPreColl = 0;
                    dblacPreColl = dblUptodateSalesAch - dblUptodatePrevious;

                    if (dblUpdateSales != 0 && dblUptodateSalesAch != 0)
                    {
                        dblUptodateSaesPer = Math.Round(dblUptodateSalesAch / dblUpdateSales, 2) * 100;
                    }
                    else
                    {
                        dblUptodateSaesPer = 0;
                    }


                    strSQL = "SELECT ISNULL(SUM(AMNT),0) UP_TO_DATE_AMNT FROM SALES_PERFORMANCE ";
                    strSQL = strSQL + "WHERE PARTICULARS='" + strCollBud + "' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                    }
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        dblUpdateCollBud = Math.Abs(Convert.ToDouble(dr["UP_TO_DATE_AMNT"]));
                    }
                    dr.Close();
                    strSQL = "SELECT ISNULL(SUM(AMNT),0) UP_TO_DATE_AMNT FROM SALES_PERFORMANCE ";
                    strSQL = strSQL + "WHERE PARTICULARS='" + strCollAc + "' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                    }
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        dblUptodateCollAcc = Math.Abs(Convert.ToDouble(dr["UP_TO_DATE_AMNT"]));
                    }
                    dr.Close();
                    if (dblUpdateCollBud != 0 && dblUptodateCollAcc != 0)
                    {
                        dblUptodateCollPer = Math.Round(dblUptodateCollAcc / dblUpdateCollBud, 2) * 100;
                    }
                    else
                    {
                        dblUptodateCollPer = 0;
                    }
                    dblBalance = 0;
                    dblBalance = Math.Round(dblUpdateCollBud - dblUptodateCollAcc);

                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,TOTAL_PERCENT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 0,'Sales Ach(%)','" + strLedgerName + "',1," + dblUptodateSaesPer + ",4";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,TOTAL_PERCENT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'Coll Ach(%)','" + strLedgerName + "',1," + dblUptodateCollPer + ",9";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,UP_TO_DATE_AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 0,'" + strCompare + "','" + strLedgerName + "',1," + dblacPreColl + ",5";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,BALANCE,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'Coll Ach(%)','" + strLedgerName + "',1," + dblBalance + ",9";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    dr.Close();

                }
                else if (intSelection == 2)//Division
                {
                    

                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + " SELECT 0,'" + strPYearSales + "', ACC_LEDGER_Z_D_A.DIVISION ,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) MM, ISNULL(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT -ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0) AMNT ";
                    strSQL = strSQL + " ,1 FROM SMART0002.DBO.ACC_LEDGER_Z_D_A ,SMART0002.DBO.ACC_VOUCHER WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME =ACC_VOUCHER.LEDGER_NAME ";
                    //strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE < (" + Utility.cvtSQLDateString(strFdate) + ")  ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strPyearFdate) + " ";
                    strSQL = strSQL + "AND " + Utility.cvtSQLDateString(strPYearTDate) + " ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE =16 ";
                    strSQL = strSQL + " AND ACC_LEDGER_Z_D_A.LEDGER_STATUS IN (0,1) ";
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID='0001' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.DIVISION='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.DIVISION,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    strSQL = strSQL + "ORDER BY MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE)  ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

               

                    //Sales Budget
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 0,'" + strCYearSalesBud + "', ACC_LEDGER_Z_D_A.DIVISION ,MONTH(SALES_TARGET_ACHIEVEMENT.TARGET_ACHIEVE_FROM_DATE) MM,ISNULL(SUM(SALES_TARGET_ACHIEVEMENT.TARGET_ACHIEVE_AMOUNT),0) AMNT,2 ";
                    strSQL = strSQL + "FROM SALES_TARGET_ACHIEVEMENT,ACC_LEDGER_Z_D_A  WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME=SALES_TARGET_ACHIEVEMENT.LEDGER_NAME ";
                    strSQL = strSQL + "AND SALES_TARGET_ACHIEVEMENT.TARGET_ACHIEVE_FROM_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.DIVISION='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.DIVISION,MONTH(SALES_TARGET_ACHIEVEMENT.TARGET_ACHIEVE_FROM_DATE)  ";
                    strSQL = strSQL + "ORDER BY MONTH(SALES_TARGET_ACHIEVEMENT.TARGET_ACHIEVE_FROM_DATE)  ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,UP_TO_DATE_AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 0,'" + strCYearSalesBud + "', ACC_LEDGER_Z_D_A.DIVISION ,MONTH(SALES_TARGET_ACHIEVEMENT.TARGET_ACHIEVE_FROM_DATE) MM,ISNULL(SUM(SALES_TARGET_ACHIEVEMENT.TARGET_ACHIEVE_AMOUNT),0) AMNT,2 ";
                    strSQL = strSQL + "FROM SALES_TARGET_ACHIEVEMENT,ACC_LEDGER_Z_D_A  WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME=SALES_TARGET_ACHIEVEMENT.LEDGER_NAME ";
                    strSQL = strSQL + "AND SALES_TARGET_ACHIEVEMENT.TARGET_ACHIEVE_FROM_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.DIVISION='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.DIVISION,MONTH(SALES_TARGET_ACHIEVEMENT.TARGET_ACHIEVE_FROM_DATE)  ";
                    strSQL = strSQL + "ORDER BY MONTH(SALES_TARGET_ACHIEVEMENT.TARGET_ACHIEVE_FROM_DATE)  ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    // Sales Achieve
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 0,'" + strCYearSalesAch + "', ACC_LEDGER_Z_D_A.DIVISION ,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) MM, ISNULL(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT -ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0) AMNT,3 ";
                    strSQL = strSQL + "FROM ACC_LEDGER_Z_D_A ,ACC_VOUCHER WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME =ACC_VOUCHER.LEDGER_NAME  ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE =16 ";
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID='0001' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.DIVISION='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.DIVISION,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE)  ";
                    strSQL = strSQL + "ORDER BY MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE)  ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,UP_TO_DATE_AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 0,'" + strCYearSalesAch + "', ACC_LEDGER_Z_D_A.DIVISION ,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) MM, ISNULL(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT -ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0) AMNT,3 ";
                    strSQL = strSQL + "FROM ACC_LEDGER_Z_D_A ,ACC_VOUCHER WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME =ACC_VOUCHER.LEDGER_NAME ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE =16 ";
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID='0001' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.DIVISION='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.DIVISION,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE)  ";
                    strSQL = strSQL + "ORDER BY MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE)  ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    //Previous Coll
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'" + strPYearColl + "', ACC_LEDGER_Z_D_A.DIVISION ,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) MM, abs(ISNULL(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT -ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0)) AMNT ";
                    strSQL = strSQL + ",6 FROM SMART0002.DBO.ACC_LEDGER_Z_D_A ,SMART0002.DBO.ACC_VOUCHER WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME =ACC_VOUCHER.LEDGER_NAME  ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strPyearFdate) + " ";
                    strSQL = strSQL + "AND " + Utility.cvtSQLDateString(strPYearTDate) + " ";
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID='0001' ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE =1 ";
                    strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.LEDGER_STATUS IN (0,1)";

                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.DIVISION='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.DIVISION,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE)  ";
                    strSQL = strSQL + "ORDER BY MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    //hl
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'" + strPYearColl + "', ACC_LEDGER_Z_D_A.DIVISION ,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) MM, abs(ISNULL(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT -ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0)) AMNT ";
                    strSQL = strSQL + ",6 FROM SMART0002.DBO.ACC_LEDGER_Z_D_A ,SMART0002.DBO.ACC_VOUCHER WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME =ACC_VOUCHER.REVERSE_LEDGER1  ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strPyearFdate) + " ";
                    strSQL = strSQL + "AND " + Utility.cvtSQLDateString(strPYearTDate) + " ";
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID='0001' ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE =3 AND ACC_VOUCHER.AUTOJV=1 ";
                    strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.LEDGER_STATUS IN (0,1) ";

                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.DIVISION='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.DIVISION,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE)  ";
                    strSQL = strSQL + "ORDER BY MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

          
                    //Coll Budget
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'" + strCollBud + "', ACC_LEDGER_Z_D_A.DIVISION ,MONTH(COLL_TARGET_FROM_DATE) MM,abs(ISNULL(SUM(COLL_TARGET_COLL_AMT),0)) AMNT ";
                    strSQL = strSQL + ",7 FROM SALES_COLL_TARGET_TRAN,ACC_LEDGER_Z_D_A  WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME=SALES_COLL_TARGET_TRAN.LEDGER_NAME ";
                    strSQL = strSQL + " AND SALES_COLL_TARGET_TRAN.COLL_TARGET_FROM_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.DIVISION='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.DIVISION,MONTH(SALES_COLL_TARGET_TRAN.COLL_TARGET_FROM_DATE) ";
                    strSQL = strSQL + "ORDER BY MONTH(SALES_COLL_TARGET_TRAN.COLL_TARGET_FROM_DATE) ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,UP_TO_DATE_AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'" + strPYearColl + "', ACC_LEDGER_Z_D_A.DIVISION ,MONTH(SALES_COLL_TARGET_TRAN.COLL_TARGET_FROM_DATE) MM,abs(ISNULL(SUM(SALES_COLL_TARGET_TRAN.COLL_TARGET_COLL_AMT),0)) AMNT ";
                    strSQL = strSQL + ",7 FROM SALES_COLL_TARGET_TRAN,ACC_LEDGER_Z_D_A  WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME=SALES_COLL_TARGET_TRAN.LEDGER_NAME   AND  ";
                    strSQL = strSQL + " SALES_COLL_TARGET_TRAN.COLL_TARGET_FROM_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.DIVISION='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.DIVISION,MONTH(SALES_COLL_TARGET_TRAN.COLL_TARGET_FROM_DATE) ";
                    strSQL = strSQL + "ORDER BY MONTH(SALES_COLL_TARGET_TRAN.COLL_TARGET_FROM_DATE) ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    //Coll Achieve
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'" + strCollAc + "', ACC_LEDGER_Z_D_A.DIVISION ,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE), abs(ISNULL(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT -ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0)) AMNT ";
                    strSQL = strSQL + ",8 FROM ACC_LEDGER_Z_D_A ,ACC_VOUCHER WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME =ACC_VOUCHER.LEDGER_NAME ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE =1 ";
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID='0001' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.DIVISION='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.DIVISION,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    strSQL = strSQL + "ORDER BY MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    //HL
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'" + strCollAc + "', ACC_LEDGER_Z_D_A.DIVISION ,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE), abs(ISNULL(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT -ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0)) AMNT ";
                    strSQL = strSQL + ",8 FROM ACC_LEDGER_Z_D_A ,ACC_VOUCHER WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME =ACC_VOUCHER.REVERSE_LEDGER1 ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE =3 AND ACC_VOUCHER.AUTOJV=1 ";
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID='0001' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.DIVISION='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.DIVISION,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    strSQL = strSQL + "ORDER BY MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,UP_TO_DATE_AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'" + strCollAc + "', ACC_LEDGER_Z_D_A.DIVISION ,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE), abs(ISNULL(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT -ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0)) AMNT ";
                    strSQL = strSQL + ",8 FROM ACC_LEDGER_Z_D_A ,ACC_VOUCHER WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME =ACC_VOUCHER.LEDGER_NAME  ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE =1 ";
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID='0001' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.DIVISION='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.DIVISION,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    strSQL = strSQL + "ORDER BY MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    //Voucher
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'Voucher','" + strLedgerName + "' ,1, ";
                    strSQL = strSQL + "0 ,10  ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'Voucher', ACC_LEDGER_Z_D_A.DIVISION ,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE), ISNULL(SUM(ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT-ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT),0) AMNT ";
                    strSQL = strSQL + ",10 FROM ACC_LEDGER_Z_D_A ,ACC_VOUCHER,ACC_COMPANY_VOUCHER WHERE ACC_COMPANY_VOUCHER.COMP_REF_NO =ACC_VOUCHER.COMP_REF_NO AND  ACC_LEDGER_Z_D_A.LEDGER_NAME =ACC_VOUCHER.LEDGER_NAME ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE =3 ";
                    strSQL = strSQL + "and ACC_COMPANY_VOUCHER.SP_JOURNAL =1 ";
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID='0001' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.DIVISION='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.DIVISION, MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    strSQL = strSQL + "ORDER BY MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'Others', DIVISION ,1, ";
                    strSQL = strSQL + "0 ,15 FROM ACC_LEDGER_Z_D_A  ";
                    //strSQL = strSQL + "WHERE  LEDGER_GROUP =202 ";
                    //if (strLedgerName != "")
                    //{
                    strSQL = strSQL + "WHERE DIVISION='" + strLedgerName + "'";
                    //}
                    strSQL = strSQL + "GROUP BY DIVISION ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();


                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'Others', ACC_LEDGER_Z_D_A.DIVISION ,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE), ISNULL(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT-ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0) AMNT ";
                    strSQL = strSQL + ",15 FROM ACC_LEDGER_Z_D_A ,ACC_VOUCHER WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME =ACC_VOUCHER.LEDGER_NAME  ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE =3 ";
                    strSQL = strSQL + "AND ACC_VOUCHER.TRANSFER_TYPE =5 ";
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID='0001' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.DIVISION='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.DIVISION, MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    strSQL = strSQL + "ORDER BY MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();



                    for (int i = 1; i <= 12; i++)
                    {

                        //Sales
                        strSQL = "SELECT AMNT FROM SALES_PERFORMANCE WHERE MONTH_NO=" + i + " ";
                        strSQL = strSQL + "AND PARTICULARS='" + strCYearSalesBud + "'";
                        if (strLedgerName != "")
                        {
                            strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                        }
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {
                            dblbudget = Math.Abs(Convert.ToDouble(dr["AMNT"]));
                        }
                        dr.Close();
                        strSQL = "SELECT AMNT FROM SALES_PERFORMANCE WHERE MONTH_NO=" + i + " ";
                        strSQL = strSQL + "AND PARTICULARS='" + strCYearSalesAch + "'";
                        if (strLedgerName != "")
                        {
                            strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                        }
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {
                            dblAcheive = Math.Abs(Convert.ToDouble(dr["AMNT"]));
                        }
                        dr.Close();

                        strSQL = "SELECT AMNT FROM SALES_PERFORMANCE WHERE MONTH_NO=" + i + " ";
                        strSQL = strSQL + "AND PARTICULARS='" + strPYearSales + "' ";
                        if (strLedgerName != "")
                        {
                            strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                        }
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {
                            dblPrevious = Math.Abs(Convert.ToDouble(dr["AMNT"]));
                        }
                        dr.Close();
                        if (dblAcheive != 0 && dblbudget != 0)
                        {
                            dblPercentage = Math.Round(dblAcheive / dblbudget, 2) * 100;
                        }
                        else
                        {
                            dblPercentage = 0;
                        }

                        dblacPreColl = dblAcheive - dblPrevious;
                        strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                        strSQL = strSQL + "SELECT 0,'Sales Ach(%)','" + strLedgerName + "'," + i + "," + dblPercentage + ",4";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                        strSQL = strSQL + "SELECT 0,'" + strCompare + "','" + strLedgerName + "'," + i + "," + dblacPreColl + ",5";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        //Collection
                        strSQL = "SELECT AMNT FROM SALES_PERFORMANCE WHERE MONTH_NO=" + i + " ";
                        strSQL = strSQL + "AND PARTICULARS='Voucher' ";
                        if (strLedgerName != "")
                        {
                            strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                        }
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {
                            dbMonthVoucher = Math.Abs(Convert.ToDouble(dr["AMNT"]));
                        }
                        dr.Close();
                        strSQL = "SELECT AMNT FROM SALES_PERFORMANCE WHERE MONTH_NO=" + i + " ";
                        strSQL = strSQL + "AND PARTICULARS='" + strCollBud + "' ";
                        if (strLedgerName != "")
                        {
                            strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                        }
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {
                            dblColbudget = Math.Abs(Convert.ToDouble(dr["AMNT"]));
                        }
                        dr.Close();
                        strSQL = "SELECT AMNT FROM SALES_PERFORMANCE WHERE MONTH_NO=" + i + " ";
                        strSQL = strSQL + "AND PARTICULARS='" + strCollAc + "' ";
                        if (strLedgerName != "")
                        {
                            strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                        }
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {
                            dblColAcheive = Math.Abs(Convert.ToDouble(dr["AMNT"]));
                        }
                        dr.Close();

                        strSQL = "SELECT AMNT FROM SALES_PERFORMANCE WHERE MONTH_NO=" + i + " ";
                        strSQL = strSQL + "AND PARTICULARS='" + strPYearColl + "'";
                        if (strLedgerName != "")
                        {
                            strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                        }
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {
                            dblColPrevious = Convert.ToDouble(dr["AMNT"]);
                        }
                        dr.Close();
                        if (dblColbudget != 0 && dblColAcheive != 0)
                        {
                            dblColPercentage = Math.Round(dblColAcheive / dblColbudget, 2) * 100;
                        }
                        else
                        {
                            dblColPercentage = 0;
                        }
                        dblacPreColl = 0;
                        dblTotalcoll = dblColAcheive + dbMonthVoucher;
                        dblacPreColl = dblColAcheive - dblColPrevious;
                        strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                        strSQL = strSQL + "SELECT 1,'Coll Ach(%)','" + strLedgerName + "'," + i + "," + dblColPercentage + ",9";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                        strSQL = strSQL + "SELECT 1,'Total Coll','" + strLedgerName + "'," + i + "," + dblTotalcoll + ",11";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                        strSQL = strSQL + "SELECT 1,'" + strCompare + "','" + strLedgerName + "'," + i + "," + dblacPreColl + ",20";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        dblColPercentage = 0;
                        dblTotalcoll = 0;
                        dblColAcheive = 0;
                        dblColbudget = 0;

                        dblPercentage = 0;
                        dblacPreColl = 0;
                        dblPrevious = 0;
                        dblAcheive = 0;
                        dblbudget = 0;
                        dr.Close();
                    }

                    //UptoDate

                    strSQL = "SELECT ISNULL(SUM(UP_TO_DATE_AMNT),0) UP_TO_DATE_AMNT  FROM SALES_PERFORMANCE ";
                    strSQL = strSQL + "WHERE PARTICULARS='" + strCYearSalesBud + "'";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                    }
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        dblUpdateSales = Math.Abs(Convert.ToDouble(dr["UP_TO_DATE_AMNT"]));
                    }
                    dr.Close();
                    strSQL = "SELECT ISNULL(SUM(UP_TO_DATE_AMNT),0) UP_TO_DATE_AMNT FROM SALES_PERFORMANCE  ";
                    strSQL = strSQL + "WHERE PARTICULARS='" + strCYearSalesAch + "' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                    }
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        dblUptodateSalesAch = Math.Abs(Convert.ToDouble(dr["UP_TO_DATE_AMNT"]));
                    }
                    dr.Close();

                    dblBalance = Math.Round(dblUpdateSales - dblUptodateSalesAch);

                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,BALANCE,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 0,'Sales Ach(%)','" + strLedgerName + "',1," + dblBalance + ",4";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "SELECT ISNULL(SUM(UP_TO_DATE_AMNT),0) UP_TO_DATE_AMNT FROM SALES_PERFORMANCE ";
                    strSQL = strSQL + "WHERE PARTICULARS='" + strPYearSales + "' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                    }
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        dblUptodatePrevious = Math.Abs(Convert.ToDouble(dr["UP_TO_DATE_AMNT"]));
                    }
                    dr.Close();
                    dblacPreColl = 0;
                    dblacPreColl = dblUptodateSalesAch - dblUptodatePrevious;

                    if (dblUpdateSales != 0 && dblUptodateSalesAch != 0)
                    {
                        dblUptodateSaesPer = Math.Round(dblUptodateSalesAch / dblUpdateSales, 2) * 100;
                    }
                    else
                    {
                        dblUptodateSaesPer = 0;
                    }


                    strSQL = "SELECT ISNULL(SUM(AMNT),0) UP_TO_DATE_AMNT FROM SALES_PERFORMANCE ";
                    strSQL = strSQL + "WHERE PARTICULARS='" + strCollBud + "' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                    }
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        dblUpdateCollBud = Math.Abs(Convert.ToDouble(dr["UP_TO_DATE_AMNT"]));
                    }
                    dr.Close();
                    strSQL = "SELECT ISNULL(SUM(AMNT),0) UP_TO_DATE_AMNT FROM SALES_PERFORMANCE ";
                    strSQL = strSQL + "WHERE PARTICULARS='" + strCollAc + "' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                    }
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        dblUptodateCollAcc = Math.Abs(Convert.ToDouble(dr["UP_TO_DATE_AMNT"]));
                    }
                    dr.Close();
                    if (dblUpdateCollBud != 0 && dblUptodateCollAcc != 0)
                    {
                        dblUptodateCollPer = Math.Round(dblUptodateCollAcc / dblUpdateCollBud, 2) * 100;
                    }
                    else
                    {
                        dblUptodateCollPer = 0;
                    }
                    dblBalance = 0;
                    dblBalance = Math.Round(dblUpdateCollBud - dblUptodateCollAcc);

                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,TOTAL_PERCENT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 0,'Sales Ach(%)','" + strLedgerName + "',1," + dblUptodateSaesPer + ",4";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,TOTAL_PERCENT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'Coll Ach(%)','" + strLedgerName + "',1," + dblUptodateCollPer + ",9";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,UP_TO_DATE_AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 0,'" + strCompare + "','" + strLedgerName + "',1," + dblacPreColl + ",5";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,BALANCE,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'Coll Ach(%)','" + strLedgerName + "',1," + dblBalance + ",9";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    dr.Close();

                }
                else if (intSelection == 3)//zONE
                {
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + " SELECT 0,'" + strPYearSales + "', ACC_LEDGER_Z_D_A.ZONE ,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) MM, ISNULL(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT -ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0) AMNT ";
                    strSQL = strSQL + " ,1 FROM SMART0002.DBO.ACC_LEDGER_Z_D_A ,SMART0002.DBO.ACC_VOUCHER WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME =ACC_VOUCHER.LEDGER_NAME ";
                    //strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE < (" + Utility.cvtSQLDateString(strFdate) + ")  ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strPyearFdate) + " ";
                    strSQL = strSQL + "AND " + Utility.cvtSQLDateString(strPYearTDate) + " ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE =16 ";
                    strSQL = strSQL + " AND ACC_LEDGER_Z_D_A.LEDGER_STATUS IN (0,1) ";
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID='0001' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.ZONE='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.ZONE,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    strSQL = strSQL + "ORDER BY MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE)  ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

              
                    //Sales Budget
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 0,'" + strCYearSalesBud + "', ACC_LEDGER_Z_D_A.ZONE ,MONTH(SALES_TARGET_ACHIEVEMENT.TARGET_ACHIEVE_FROM_DATE) MM,ISNULL(SUM(SALES_TARGET_ACHIEVEMENT.TARGET_ACHIEVE_AMOUNT),0) AMNT,2 ";
                    strSQL = strSQL + "FROM SALES_TARGET_ACHIEVEMENT,ACC_LEDGER_Z_D_A  WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME=SALES_TARGET_ACHIEVEMENT.LEDGER_NAME ";
                    strSQL = strSQL + "AND SALES_TARGET_ACHIEVEMENT.TARGET_ACHIEVE_FROM_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.ZONE='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.ZONE,MONTH(SALES_TARGET_ACHIEVEMENT.TARGET_ACHIEVE_FROM_DATE)  ";
                    strSQL = strSQL + "ORDER BY MONTH(SALES_TARGET_ACHIEVEMENT.TARGET_ACHIEVE_FROM_DATE)  ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,UP_TO_DATE_AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 0,'" + strCYearSalesBud + "', ACC_LEDGER_Z_D_A.ZONE ,MONTH(SALES_TARGET_ACHIEVEMENT.TARGET_ACHIEVE_FROM_DATE) MM,ISNULL(SUM(SALES_TARGET_ACHIEVEMENT.TARGET_ACHIEVE_AMOUNT),0) AMNT,2 ";
                    strSQL = strSQL + "FROM SALES_TARGET_ACHIEVEMENT,ACC_LEDGER_Z_D_A  WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME=SALES_TARGET_ACHIEVEMENT.LEDGER_NAME ";
                    strSQL = strSQL + "AND SALES_TARGET_ACHIEVEMENT.TARGET_ACHIEVE_FROM_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.ZONE='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.ZONE,MONTH(SALES_TARGET_ACHIEVEMENT.TARGET_ACHIEVE_FROM_DATE)  ";
                    strSQL = strSQL + "ORDER BY MONTH(SALES_TARGET_ACHIEVEMENT.TARGET_ACHIEVE_FROM_DATE)  ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    // Sales Achieve
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 0,'" + strCYearSalesAch + "', ACC_LEDGER_Z_D_A.ZONE ,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) MM, ISNULL(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT -ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0) AMNT,3 ";
                    strSQL = strSQL + "FROM ACC_LEDGER_Z_D_A ,ACC_VOUCHER WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME =ACC_VOUCHER.LEDGER_NAME  ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE =16 ";
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID='0001' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.ZONE='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.ZONE,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE)  ";
                    strSQL = strSQL + "ORDER BY MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE)  ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,UP_TO_DATE_AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 0,'" + strCYearSalesAch + "', ACC_LEDGER_Z_D_A.ZONE ,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) MM, ISNULL(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT -ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0) AMNT,3 ";
                    strSQL = strSQL + "FROM ACC_LEDGER_Z_D_A ,ACC_VOUCHER WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME =ACC_VOUCHER.LEDGER_NAME ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE =16 ";
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID='0001' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.ZONE='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.ZONE,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE)  ";
                    strSQL = strSQL + "ORDER BY MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE)  ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    //Previous Coll
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'" + strPYearColl + "', ACC_LEDGER_Z_D_A.ZONE ,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) MM, abs(ISNULL(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT -ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0)) AMNT ";
                    strSQL = strSQL + ",6 FROM SMART0002.DBO.ACC_LEDGER_Z_D_A ,SMART0002.DBO.ACC_VOUCHER WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME =ACC_VOUCHER.LEDGER_NAME  ";
                    //strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE < (" + Utility.cvtSQLDateString(strFdate) + ")  ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strPyearFdate) + " ";
                    strSQL = strSQL + "AND " + Utility.cvtSQLDateString(strPYearTDate) + " ";
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID='0001' ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE =1 ";
                    strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.LEDGER_STATUS =0 ";

                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.ZONE='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.ZONE,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE)  ";
                    strSQL = strSQL + "ORDER BY MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    ///HL-PF
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'" + strPYearColl + "', ACC_LEDGER_Z_D_A.ZONE ,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) MM, abs(ISNULL(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT -ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0)) AMNT ";
                    strSQL = strSQL + ",6 FROM SMART0002.DBO.ACC_LEDGER_Z_D_A ,SMART0002.DBO.ACC_VOUCHER WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME =ACC_VOUCHER.REVERSE_LEDGER1  ";
                    //strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE < (" + Utility.cvtSQLDateString(strFdate) + ")  ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strPyearFdate) + " ";
                    strSQL = strSQL + "AND " + Utility.cvtSQLDateString(strPYearTDate) + " ";
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID='0001' ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE =3 AND ACC_VOUCHER.AUTOJV=1 ";
                    strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.LEDGER_STATUS IN (0,1) ";

                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.ZONE='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.ZONE,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE)  ";
                    strSQL = strSQL + "ORDER BY MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    /////

             
                    //Coll Budget
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'" + strCollBud + "', ACC_LEDGER_Z_D_A.ZONE ,MONTH(COLL_TARGET_FROM_DATE) MM,abs(ISNULL(SUM(COLL_TARGET_COLL_AMT),0)) AMNT ";
                    strSQL = strSQL + ",7 FROM SALES_COLL_TARGET_TRAN,ACC_LEDGER_Z_D_A  WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME=SALES_COLL_TARGET_TRAN.LEDGER_NAME ";
                    strSQL = strSQL + " AND SALES_COLL_TARGET_TRAN.COLL_TARGET_FROM_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.ZONE='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.ZONE,MONTH(SALES_COLL_TARGET_TRAN.COLL_TARGET_FROM_DATE) ";
                    strSQL = strSQL + "ORDER BY MONTH(SALES_COLL_TARGET_TRAN.COLL_TARGET_FROM_DATE) ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,UP_TO_DATE_AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'" + strPYearColl + "', ACC_LEDGER_Z_D_A.ZONE ,MONTH(SALES_COLL_TARGET_TRAN.COLL_TARGET_FROM_DATE) MM,abs(ISNULL(SUM(SALES_COLL_TARGET_TRAN.COLL_TARGET_COLL_AMT),0)) AMNT ";
                    strSQL = strSQL + ",7 FROM SALES_COLL_TARGET_TRAN,ACC_LEDGER_Z_D_A  WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME=SALES_COLL_TARGET_TRAN.LEDGER_NAME   AND  ";
                    strSQL = strSQL + " SALES_COLL_TARGET_TRAN.COLL_TARGET_FROM_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.ZONE='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.ZONE,MONTH(SALES_COLL_TARGET_TRAN.COLL_TARGET_FROM_DATE) ";
                    strSQL = strSQL + "ORDER BY MONTH(SALES_COLL_TARGET_TRAN.COLL_TARGET_FROM_DATE) ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    //Coll Achieve
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'" + strCollAc + "', ACC_LEDGER_Z_D_A.ZONE ,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE), abs(ISNULL(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT -ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0)) AMNT ";
                    strSQL = strSQL + ",8 FROM ACC_LEDGER_Z_D_A ,ACC_VOUCHER WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME =ACC_VOUCHER.LEDGER_NAME ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE =1 ";
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID='0001' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.ZONE='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.ZONE,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    strSQL = strSQL + "ORDER BY MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    //HL
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'" + strCollAc + "', ACC_LEDGER_Z_D_A.ZONE ,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE), abs(ISNULL(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT -ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0)) AMNT ";
                    strSQL = strSQL + ",8 FROM ACC_LEDGER_Z_D_A ,ACC_VOUCHER WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME =ACC_VOUCHER.REVERSE_LEDGER1 ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE =3 AND ACC_VOUCHER.AUTOJV=1 ";
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID='0001' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.ZONE='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.ZONE,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    strSQL = strSQL + "ORDER BY MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    //

                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,UP_TO_DATE_AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'" + strCollAc + "', ACC_LEDGER_Z_D_A.ZONE ,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE), abs(ISNULL(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT -ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0)) AMNT ";
                    strSQL = strSQL + ",8 FROM ACC_LEDGER_Z_D_A ,ACC_VOUCHER WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME =ACC_VOUCHER.LEDGER_NAME  ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE =1 ";
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID='0001' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.ZONE='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.ZONE,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    strSQL = strSQL + "ORDER BY MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    //Voucher
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'Voucher', ZONE ,1, ";
                    strSQL = strSQL + "0 ,10 FROM ACC_LEDGER_Z_D_A  ";
                    //strSQL = strSQL + "WHERE  LEDGER_GROUP =202 ";
                    //if (strLedgerName != "")
                    //{
                    strSQL = strSQL + "WHERE ZONE='" + strLedgerName + "'";
                    //}
                    strSQL = strSQL + "GROUP BY ZONE ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'Voucher', ACC_LEDGER_Z_D_A.ZONE ,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE), ISNULL(SUM(ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT-ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT),0) AMNT ";
                    strSQL = strSQL + ",10 FROM ACC_LEDGER_Z_D_A ,ACC_VOUCHER,ACC_COMPANY_VOUCHER WHERE ACC_COMPANY_VOUCHER.COMP_REF_NO =ACC_VOUCHER.COMP_REF_NO AND  ACC_LEDGER_Z_D_A.LEDGER_NAME =ACC_VOUCHER.LEDGER_NAME ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE =3 ";
                    strSQL = strSQL + "and ACC_COMPANY_VOUCHER.SP_JOURNAL =1 ";
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID='0001' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.ZONE='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.ZONE, MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    strSQL = strSQL + "ORDER BY MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'Others', ZONE ,1, ";
                    strSQL = strSQL + "0 ,15 FROM ACC_LEDGER_Z_D_A  ";
                    //strSQL = strSQL + "WHERE  LEDGER_GROUP =202 ";
                    //if (strLedgerName != "")
                    //{
                    strSQL = strSQL + "WHERE ZONE='" + strLedgerName + "'";
                    //}
                    strSQL = strSQL + "GROUP BY ZONE ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'Others', ACC_LEDGER_Z_D_A.ZONE ,MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE), ISNULL(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT-ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0) AMNT ";
                    strSQL = strSQL + ",15 FROM ACC_LEDGER_Z_D_A ,ACC_VOUCHER WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME =ACC_VOUCHER.LEDGER_NAME  ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ") ";
                    strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE =3 ";
                    strSQL = strSQL + "AND ACC_VOUCHER.TRANSFER_TYPE =5 ";
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID='0001' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.ZONE='" + strLedgerName + "'";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.ZONE, MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    strSQL = strSQL + "ORDER BY MONTH(ACC_VOUCHER.COMP_VOUCHER_DATE) ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();



                    for (int i = 1; i <= 12; i++)
                    {

                        //Sales
                        strSQL = "SELECT AMNT FROM SALES_PERFORMANCE WHERE MONTH_NO=" + i + " ";
                        strSQL = strSQL + "AND PARTICULARS='" + strCYearSalesBud + "'";
                        if (strLedgerName != "")
                        {
                            strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                        }
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {
                            dblbudget = Math.Abs(Convert.ToDouble(dr["AMNT"]));
                        }
                        dr.Close();
                        strSQL = "SELECT AMNT FROM SALES_PERFORMANCE WHERE MONTH_NO=" + i + " ";
                        strSQL = strSQL + "AND PARTICULARS='" + strCYearSalesAch + "'";
                        if (strLedgerName != "")
                        {
                            strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                        }
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {
                            dblAcheive = Math.Abs(Convert.ToDouble(dr["AMNT"]));
                        }
                        dr.Close();

                        strSQL = "SELECT AMNT FROM SALES_PERFORMANCE WHERE MONTH_NO=" + i + " ";
                        strSQL = strSQL + "AND PARTICULARS='" + strPYearSales + "' ";
                        if (strLedgerName != "")
                        {
                            strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                        }
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {
                            dblPrevious = Math.Abs(Convert.ToDouble(dr["AMNT"]));
                        }
                        dr.Close();
                        if (dblAcheive != 0 && dblbudget != 0)
                        {
                            dblPercentage = Math.Round(dblAcheive / dblbudget, 2) * 100;
                        }
                        else
                        {
                            dblPercentage = 0;
                        }

                        dblacPreColl = dblAcheive - dblPrevious;
                        strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                        strSQL = strSQL + "SELECT 0,'Sales Ach(%)','" + strLedgerName + "'," + i + "," + dblPercentage + ",4";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                        strSQL = strSQL + "SELECT 0,'" + strCompare + "','" + strLedgerName + "'," + i + "," + dblacPreColl + ",5";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        //Collection
                        strSQL = "SELECT AMNT FROM SALES_PERFORMANCE WHERE MONTH_NO=" + i + " ";
                        strSQL = strSQL + "AND PARTICULARS='Voucher' ";
                        if (strLedgerName != "")
                        {
                            strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                        }
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {
                            dbMonthVoucher = Math.Abs(Convert.ToDouble(dr["AMNT"]));
                        }
                        dr.Close();
                        strSQL = "SELECT AMNT FROM SALES_PERFORMANCE WHERE MONTH_NO=" + i + " ";
                        strSQL = strSQL + "AND PARTICULARS='" + strCollBud + "' ";
                        if (strLedgerName != "")
                        {
                            strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                        }
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {
                            dblColbudget = Math.Abs(Convert.ToDouble(dr["AMNT"]));
                        }
                        dr.Close();
                        strSQL = "SELECT AMNT FROM SALES_PERFORMANCE WHERE MONTH_NO=" + i + " ";
                        strSQL = strSQL + "AND PARTICULARS='" + strCollAc + "' ";
                        if (strLedgerName != "")
                        {
                            strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                        }
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {
                            dblColAcheive = Math.Abs(Convert.ToDouble(dr["AMNT"]));
                        }
                        dr.Close();

                        strSQL = "SELECT AMNT FROM SALES_PERFORMANCE WHERE MONTH_NO=" + i + " ";
                        strSQL = strSQL + "AND PARTICULARS='" + strPYearColl + "'";
                        if (strLedgerName != "")
                        {
                            strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                        }
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {
                            dblColPrevious = Convert.ToDouble(dr["AMNT"]);
                        }
                        dr.Close();
                        if (dblColbudget != 0 && dblColAcheive != 0)
                        {
                            dblColPercentage = Math.Round(dblColAcheive / dblColbudget, 2) * 100;
                        }
                        else
                        {
                            dblColPercentage = 0;
                        }
                        dblacPreColl = 0;
                        dblTotalcoll = dblColAcheive + dbMonthVoucher;
                        dblacPreColl = dblColAcheive - dblColPrevious;
                        strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                        strSQL = strSQL + "SELECT 1,'Coll Ach(%)','" + strLedgerName + "'," + i + "," + dblColPercentage + ",9";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                        strSQL = strSQL + "SELECT 1,'Total Coll','" + strLedgerName + "'," + i + "," + dblTotalcoll + ",11";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                        strSQL = strSQL + "SELECT 1,'" + strCompare + "','" + strLedgerName + "'," + i + "," + dblacPreColl + ",20";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        dblColPercentage = 0;
                        dblTotalcoll = 0;
                        dblColAcheive = 0;
                        dblColbudget = 0;

                        dblPercentage = 0;
                        dblacPreColl = 0;
                        dblPrevious = 0;
                        dblAcheive = 0;
                        dblbudget = 0;
                        dr.Close();
                    }

                    //UptoDate

                    strSQL = "SELECT ISNULL(SUM(UP_TO_DATE_AMNT),0) UP_TO_DATE_AMNT  FROM SALES_PERFORMANCE ";
                    strSQL = strSQL + "WHERE PARTICULARS='" + strCYearSalesBud + "'";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                    }
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        dblUpdateSales = Math.Abs(Convert.ToDouble(dr["UP_TO_DATE_AMNT"]));
                    }
                    dr.Close();
                    strSQL = "SELECT ISNULL(SUM(UP_TO_DATE_AMNT),0) UP_TO_DATE_AMNT FROM SALES_PERFORMANCE  ";
                    strSQL = strSQL + "WHERE PARTICULARS='" + strCYearSalesAch + "' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                    }
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        dblUptodateSalesAch = Math.Abs(Convert.ToDouble(dr["UP_TO_DATE_AMNT"]));
                    }
                    dr.Close();

                    dblBalance = Math.Round(dblUpdateSales - dblUptodateSalesAch);

                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,BALANCE,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 0,'Sales Ach(%)','" + strLedgerName + "',1," + dblBalance + ",4";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "SELECT ISNULL(SUM(UP_TO_DATE_AMNT),0) UP_TO_DATE_AMNT FROM SALES_PERFORMANCE ";
                    strSQL = strSQL + "WHERE PARTICULARS='" + strPYearSales + "' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                    }
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        dblUptodatePrevious = Math.Abs(Convert.ToDouble(dr["UP_TO_DATE_AMNT"]));
                    }
                    dr.Close();
                    dblacPreColl = 0;
                    dblacPreColl = dblUptodateSalesAch - dblUptodatePrevious;

                    if (dblUpdateSales != 0 && dblUptodateSalesAch != 0)
                    {
                        dblUptodateSaesPer = Math.Round(dblUptodateSalesAch / dblUpdateSales, 2) * 100;
                    }
                    else
                    {
                        dblUptodateSaesPer = 0;
                    }


                    strSQL = "SELECT ISNULL(SUM(AMNT),0) UP_TO_DATE_AMNT FROM SALES_PERFORMANCE ";
                    strSQL = strSQL + "WHERE PARTICULARS='" + strCollBud + "' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                    }
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        dblUpdateCollBud = Math.Abs(Convert.ToDouble(dr["UP_TO_DATE_AMNT"]));
                    }
                    dr.Close();
                    strSQL = "SELECT ISNULL(SUM(AMNT),0) UP_TO_DATE_AMNT FROM SALES_PERFORMANCE ";
                    strSQL = strSQL + "WHERE PARTICULARS='" + strCollAc + "' ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "'";
                    }
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        dblUptodateCollAcc = Math.Abs(Convert.ToDouble(dr["UP_TO_DATE_AMNT"]));
                    }
                    dr.Close();
                    if (dblUpdateCollBud != 0 && dblUptodateCollAcc != 0)
                    {
                        dblUptodateCollPer = Math.Round(dblUptodateCollAcc / dblUpdateCollBud, 2) * 100;
                    }
                    else
                    {
                        dblUptodateCollPer = 0;
                    }
                    dblBalance = 0;
                    dblBalance = Math.Round(dblUpdateCollBud - dblUptodateCollAcc);

                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,TOTAL_PERCENT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 0,'Sales Ach(%)','" + strLedgerName + "',1," + dblUptodateSaesPer + ",4";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,TOTAL_PERCENT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'Coll Ach(%)','" + strLedgerName + "',1," + dblUptodateCollPer + ",9";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,UP_TO_DATE_AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 0,'" + strCompare + "','" + strLedgerName + "',1," + dblacPreColl + ",5";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,BALANCE,SORTING_TYPE) ";
                    strSQL = strSQL + "SELECT 1,'Coll Ach(%)','" + strLedgerName + "',1," + dblBalance + ",9";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    dr.Close();

                }

                cmdInsert.Transaction.Commit();
                gcnMain.Close();
                return "1";
            }
        }
        public List<Mprojection> mQueryPerformance(string strDeComID, int intMode)
        {
            string strSQL = null;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlDataReader dr;
                SqlCommand cmdAlter = new SqlCommand();
                cmdAlter.Connection = gcnMain;
                List<Mprojection> ooPer = new List<Mprojection>();
                if (intMode == 0)
                {
                    strSQL = "SELECT  L.ZONE,L.DIVISION,L.AREA ,E.SEL_MODE,E.SORTING_TYPE , E.PARTICULARS,L.LEDGER_NAME_MERZE ,SUM(E.JAN)JAN,SUM(E.FEB)FEB,SUM(E.MAR)MAR,SUM(E.APR)APR,SUM(E.MAY)MAY,SUM(E.JUN)JUN,SUM(E.JUL)JUL, ";
                    strSQL = strSQL + " SUM(E.AUG)AUG,SUM(E.SEP)SEP,SUM(E.OCT)OCT, ";
                    strSQL = strSQL + "SUM(E.NOV)NOV,SUM(E.DEC)DEC,SUM(E.UP_TO_DATE_AMNT) UP_TO_DATE_AMNT,SUM(E.BALANCE) BALANCE,SUM(E.TOTAL_PERCENT) TOTAL_PERCENT ";
                    strSQL = strSQL + "FROM SALES_EVALUATION_VIEW E,ACC_LEDGER_Z_D_A L WHERE L.LEDGER_NAME=E.LEDGER_NAME  ";
                    strSQL = strSQL + "GROUP BY E.SORTING_TYPE ,L.ZONE,L.DIVISION,L.AREA,E.SEL_MODE,E.PARTICULARS,L.LEDGER_NAME_MERZE ORDER BY  L.ZONE,L.DIVISION,L.AREA,L.LEDGER_NAME_MERZE,E.SORTING_TYPE  ";
                }
                else if (intMode == 1)
                {
                    strSQL = "ALTER VIEW SALES_EVALUATION_VIEW1 AS ";
                    strSQL = strSQL + "SELECT  E.LEDGER_NAME ZONE,E.LEDGER_NAME DIVISION,E.LEDGER_NAME AREA ,E.SEL_MODE,E.SORTING_TYPE , E.PARTICULARS,E.LEDGER_NAME LEDGER_NAME_MERZE ,SUM(E.JAN)JAN,SUM(E.FEB)FEB,SUM(E.MAR)MAR,SUM(E.APR)APR,SUM(E.MAY)MAY,SUM(E.JUN)JUN,SUM(E.JUL)JUL, ";
                    strSQL = strSQL + " SUM(E.AUG)AUG,SUM(E.SEP)SEP,SUM(E.OCT)OCT, ";
                    strSQL = strSQL + "SUM(E.NOV)NOV,SUM(E.DEC)DEC,SUM(E.UP_TO_DATE_AMNT) UP_TO_DATE_AMNT,SUM(E.BALANCE) BALANCE,SUM(E.TOTAL_PERCENT) TOTAL_PERCENT ";
                    strSQL = strSQL + "FROM SALES_EVALUATION_VIEW E ";
                    strSQL = strSQL + "WHERE E.PARTICULARS NOT IN ('Sales Ach(%)','Coll Ach(%)') ";
                    strSQL = strSQL + "GROUP BY E.SORTING_TYPE ,E.LEDGER_NAME,E.SEL_MODE,E.PARTICULARS ";
                    strSQL = strSQL + "UNION ALL ";
                    strSQL = strSQL + "SELECT  E.LEDGER_NAME ZONE,E.LEDGER_NAME DIVISION,E.LEDGER_NAME AREA ,E.SEL_MODE,E.SORTING_TYPE , E.PARTICULARS,E.LEDGER_NAME LEDGER_NAME_MERZE ,MAX(E.JAN)JAN,MAX(E.FEB)FEB,MAX(E.MAR)MAR,MAX(E.APR)APR,MAX(E.MAY)MAY,MAX(E.JUN)JUN,MAX(E.JUL)JUL, ";
                    strSQL = strSQL + " MAX(E.AUG)AUG,MAX(E.SEP)SEP,MAX(E.OCT)OCT, ";
                    strSQL = strSQL + "MAX(E.NOV)NOV,MAX(E.DEC)DEC,SUM(E.UP_TO_DATE_AMNT) UP_TO_DATE_AMNT,SUM(E.BALANCE) BALANCE,MAX(E.TOTAL_PERCENT) TOTAL_PERCENT ";
                    strSQL = strSQL + "FROM SALES_EVALUATION_VIEW E  ";
                    strSQL = strSQL + "WHERE E.PARTICULARS IN ('Sales Ach(%)','Coll Ach(%)') ";
                    strSQL = strSQL + "GROUP BY E.SORTING_TYPE ,E.LEDGER_NAME,E.SEL_MODE,E.PARTICULARS ";
                    cmdAlter.CommandText = strSQL;
                    cmdAlter.ExecuteNonQuery();
                    strSQL = "SELECT ZONE,DIVISION,AREA ,SEL_MODE,SORTING_TYPE , PARTICULARS,AREA LEDGER_NAME_MERZE ,";
                    strSQL = strSQL + "JAN,FEB,MAR,APR,MAY,JUN,JUL,  AUG,SEP,OCT, NOV,";
                    strSQL = strSQL + "DEC,UP_TO_DATE_AMNT,BALANCE,TOTAL_PERCENT  FROM SALES_EVALUATION_VIEW1  ";
                    strSQL = strSQL + "ORDER BY ZONE,DIVISION,AREA,LEDGER_NAME_MERZE,SORTING_TYPE";

                }
                else if (intMode == 2)
                {
                    //strSQL = "SELECT  L.ZONE,L.DIVISION,L.AREA ,E.SEL_MODE,E.SORTING_TYPE , E.PARTICULARS,L.DIVISION LEDGER_NAME_MERZE ,SUM(E.JAN)JAN,SUM(E.FEB)FEB,SUM(E.MAR)MAR,SUM(E.APR)APR,SUM(E.MAY)MAY,SUM(E.JUN)JUN,SUM(E.JUL)JUL, ";
                    //strSQL = strSQL + " SUM(E.AUG)AUG,SUM(E.SEP)SEP,SUM(E.OCT)OCT, ";
                    //strSQL = strSQL + "SUM(E.NOV)NOV,SUM(E.DEC)DEC,SUM(E.UP_TO_DATE_AMNT) UP_TO_DATE_AMNT,SUM(E.BALANCE) BALANCE,SUM(E.TOTAL_PERCENT) TOTAL_PERCENT ";
                    //strSQL = strSQL + "FROM SALES_EVALUATION_VIEW E,ACC_LEDGER_Z_D_A L WHERE L.DIVISION=E.LEDGER_NAME  ";
                    //strSQL = strSQL + "GROUP BY E.SORTING_TYPE ,L.ZONE,L.DIVISION,L.AREA,E.SEL_MODE,E.PARTICULARS ORDER BY  L.ZONE,L.DIVISION,L.AREA,E.SORTING_TYPE  ";
                    strSQL = "ALTER VIEW SALES_EVALUATION_VIEW1 AS ";
                    strSQL = strSQL + "SELECT  E.LEDGER_NAME ZONE,E.LEDGER_NAME DIVISION,E.LEDGER_NAME AREA ,E.SEL_MODE,E.SORTING_TYPE , E.PARTICULARS,E.LEDGER_NAME LEDGER_NAME_MERZE ,SUM(E.JAN)JAN,SUM(E.FEB)FEB,SUM(E.MAR)MAR,SUM(E.APR)APR,SUM(E.MAY)MAY,SUM(E.JUN)JUN,SUM(E.JUL)JUL, ";
                    strSQL = strSQL + " SUM(E.AUG)AUG,SUM(E.SEP)SEP,SUM(E.OCT)OCT, ";
                    strSQL = strSQL + "SUM(E.NOV)NOV,SUM(E.DEC)DEC,SUM(E.UP_TO_DATE_AMNT) UP_TO_DATE_AMNT,SUM(E.BALANCE) BALANCE,SUM(E.TOTAL_PERCENT) TOTAL_PERCENT ";
                    strSQL = strSQL + "FROM SALES_EVALUATION_VIEW E ";
                    strSQL = strSQL + "WHERE E.PARTICULARS NOT IN ('Sales Ach(%)','Coll Ach(%)') ";
                    strSQL = strSQL + "GROUP BY E.SORTING_TYPE ,E.LEDGER_NAME,E.SEL_MODE,E.PARTICULARS ";
                    strSQL = strSQL + "UNION ALL ";
                    strSQL = strSQL + "SELECT  E.LEDGER_NAME ZONE,E.LEDGER_NAME DIVISION,E.LEDGER_NAME AREA ,E.SEL_MODE,E.SORTING_TYPE , E.PARTICULARS,E.LEDGER_NAME LEDGER_NAME_MERZE ,MAX(E.JAN)JAN,MAX(E.FEB)FEB,MAX(E.MAR)MAR,MAX(E.APR)APR,MAX(E.MAY)MAY,MAX(E.JUN)JUN,MAX(E.JUL)JUL, ";
                    strSQL = strSQL + " MAX(E.AUG)AUG,MAX(E.SEP)SEP,MAX(E.OCT)OCT, ";
                    strSQL = strSQL + "MAX(E.NOV)NOV,MAX(E.DEC)DEC,SUM(E.UP_TO_DATE_AMNT) UP_TO_DATE_AMNT,SUM(E.BALANCE) BALANCE,MAX(E.TOTAL_PERCENT) TOTAL_PERCENT ";
                    strSQL = strSQL + "FROM SALES_EVALUATION_VIEW E  ";
                    strSQL = strSQL + "WHERE E.PARTICULARS IN ('Sales Ach(%)','Coll Ach(%)') ";
                    strSQL = strSQL + "GROUP BY E.SORTING_TYPE ,E.LEDGER_NAME,E.SEL_MODE,E.PARTICULARS ";
                
                    cmdAlter.CommandText = strSQL;
                    cmdAlter.ExecuteNonQuery();
                    strSQL = "SELECT ZONE, DIVISION, DIVISION AREA ,SEL_MODE,SORTING_TYPE , PARTICULARS,DIVISION LEDGER_NAME_MERZE ,";
                    strSQL = strSQL + "JAN,FEB,MAR,APR,MAY,JUN,JUL,  AUG,SEP,OCT, NOV,";
                    strSQL = strSQL + "DEC,UP_TO_DATE_AMNT,BALANCE,TOTAL_PERCENT  FROM SALES_EVALUATION_VIEW1  ";
                    strSQL = strSQL + "ORDER BY ZONE,DIVISION,AREA,LEDGER_NAME_MERZE,SORTING_TYPE";

                }
                else if (intMode == 3)
                {
                    //strSQL = "SELECT  L.ZONE,'' DIVISION,'' AREA ,E.SEL_MODE,E.SORTING_TYPE , E.PARTICULARS,L.ZONE LEDGER_NAME_MERZE ,SUM(E.JAN)JAN,SUM(E.FEB)FEB,SUM(E.MAR)MAR,SUM(E.APR)APR,SUM(E.MAY)MAY,SUM(E.JUN)JUN,SUM(E.JUL)JUL, ";
                    //strSQL = strSQL + " SUM(E.AUG)AUG,SUM(E.SEP)SEP,SUM(E.OCT)OCT, ";
                    //strSQL = strSQL + "SUM(E.NOV)NOV,SUM(E.DEC)DEC,SUM(E.UP_TO_DATE_AMNT) UP_TO_DATE_AMNT,SUM(E.BALANCE) BALANCE,SUM(E.TOTAL_PERCENT) TOTAL_PERCENT ";
                    //strSQL = strSQL + "FROM SALES_EVALUATION_VIEW E,ACC_LEDGER_Z_D_A L WHERE L.ZONE=E.LEDGER_NAME  ";
                    //strSQL = strSQL + "GROUP BY E.SORTING_TYPE ,L.ZONE,E.SEL_MODE,E.PARTICULARS ORDER BY  L.ZONE,E.SORTING_TYPE  ";
                    strSQL = "ALTER VIEW SALES_EVALUATION_VIEW1 AS ";
                    strSQL = strSQL + "SELECT  E.LEDGER_NAME ZONE,E.LEDGER_NAME DIVISION,E.LEDGER_NAME AREA ,E.SEL_MODE,E.SORTING_TYPE , E.PARTICULARS,E.LEDGER_NAME LEDGER_NAME_MERZE ,SUM(E.JAN)JAN,SUM(E.FEB)FEB,SUM(E.MAR)MAR,SUM(E.APR)APR,SUM(E.MAY)MAY,SUM(E.JUN)JUN,SUM(E.JUL)JUL, ";
                    strSQL = strSQL + " SUM(E.AUG)AUG,SUM(E.SEP)SEP,SUM(E.OCT)OCT, ";
                    strSQL = strSQL + "SUM(E.NOV)NOV,SUM(E.DEC)DEC,SUM(E.UP_TO_DATE_AMNT) UP_TO_DATE_AMNT,SUM(E.BALANCE) BALANCE,SUM(E.TOTAL_PERCENT) TOTAL_PERCENT ";
                    strSQL = strSQL + "FROM SALES_EVALUATION_VIEW E  ";
                    strSQL = strSQL + "WHERE E.PARTICULARS NOT IN ('Sales Ach(%)','Coll Ach(%)') ";
                    strSQL = strSQL + "GROUP BY E.SORTING_TYPE ,E.LEDGER_NAME,E.SEL_MODE,E.PARTICULARS ";
                    strSQL = strSQL + "UNION ALL ";
                    strSQL = strSQL + "SELECT  E.LEDGER_NAME ZONE,E.LEDGER_NAME DIVISION,E.LEDGER_NAME AREA ,E.SEL_MODE,E.SORTING_TYPE , E.PARTICULARS,E.LEDGER_NAME LEDGER_NAME_MERZE ,MAX(E.JAN)JAN,MAX(E.FEB)FEB,MAX(E.MAR)MAR,MAX(E.APR)APR,MAX(E.MAY)MAY,MAX(E.JUN)JUN,MAX(E.JUL)JUL, ";
                    strSQL = strSQL + " MAX(E.AUG)AUG,MAX(E.SEP)SEP,MAX(E.OCT)OCT, ";
                    strSQL = strSQL + "MAX(E.NOV)NOV,MAX(E.DEC)DEC,SUM(E.UP_TO_DATE_AMNT) UP_TO_DATE_AMNT,SUM(E.BALANCE) BALANCE,MAX(E.TOTAL_PERCENT) TOTAL_PERCENT ";
                    strSQL = strSQL + "FROM SALES_EVALUATION_VIEW E ";
                    strSQL = strSQL + "WHERE E.PARTICULARS IN ('Sales Ach(%)','Coll Ach(%)') ";
                    strSQL = strSQL + "GROUP BY E.SORTING_TYPE ,E.LEDGER_NAME,E.SEL_MODE,E.PARTICULARS ";
                    cmdAlter.CommandText = strSQL;
                    cmdAlter.ExecuteNonQuery();

                    strSQL = "SELECT ZONE,DIVISION,AREA ,SEL_MODE,SORTING_TYPE , PARTICULARS,AREA LEDGER_NAME_MERZE ,";
                    strSQL = strSQL + "JAN,FEB,MAR,APR,MAY,JUN,JUL,  AUG,SEP,OCT, NOV,";
                    strSQL = strSQL + "DEC,UP_TO_DATE_AMNT,BALANCE,TOTAL_PERCENT  FROM SALES_EVALUATION_VIEW1  ";
                    strSQL = strSQL + "ORDER BY ZONE,DIVISION,AREA,LEDGER_NAME_MERZE,SORTING_TYPE";
                }
                else
                {
                    strSQL = "ALTER VIEW SALES_EVALUATION_VIEW1 AS ";
                    strSQL = strSQL + "SELECT  L.ZONE,L.ZONE DIVISION,L.ZONE AREA ,E.SEL_MODE,E.SORTING_TYPE , E.PARTICULARS,L.ZONE LEDGER_NAME_MERZE ,SUM(E.JAN)JAN,SUM(E.FEB)FEB,SUM(E.MAR)MAR,SUM(E.APR)APR,SUM(E.MAY)MAY,SUM(E.JUN)JUN,SUM(E.JUL)JUL, ";
                    strSQL = strSQL + " SUM(E.AUG)AUG,SUM(E.SEP)SEP,SUM(E.OCT)OCT, ";
                    strSQL = strSQL + "SUM(E.NOV)NOV,SUM(E.DEC)DEC,SUM(E.UP_TO_DATE_AMNT) UP_TO_DATE_AMNT,SUM(E.BALANCE) BALANCE,SUM(E.TOTAL_PERCENT) TOTAL_PERCENT ";
                    strSQL = strSQL + "FROM SALES_EVALUATION_VIEW E,ACC_LEDGER_Z_D_A L WHERE L.ZONE=E.LEDGER_NAME  ";
                    strSQL = strSQL + "AND E.PARTICULARS NOT IN ('Sales Ach(%)','Coll Ach(%)') ";
                    strSQL = strSQL + "GROUP BY E.SORTING_TYPE ,L.ZONE,E.SEL_MODE,E.PARTICULARS ";
                    strSQL = strSQL + "UNION ALL ";
                    strSQL = strSQL + "SELECT  L.ZONE,L.ZONE DIVISION,L.ZONE AREA ,E.SEL_MODE,E.SORTING_TYPE , E.PARTICULARS,L.ZONE LEDGER_NAME_MERZE ,MAX(E.JAN)JAN,MAX(E.FEB)FEB,MAX(E.MAR)MAR,MAX(E.APR)APR,MAX(E.MAY)MAY,MAX(E.JUN)JUN,MAX(E.JUL)JUL, ";
                    strSQL = strSQL + " MAX(E.AUG)AUG,MAX(E.SEP)SEP,MAX(E.OCT)OCT, ";
                    strSQL = strSQL + "MAX(E.NOV)NOV,MAX(E.DEC)DEC,SUM(E.UP_TO_DATE_AMNT) UP_TO_DATE_AMNT,SUM(E.BALANCE) BALANCE,MAX(E.TOTAL_PERCENT) TOTAL_PERCENT ";
                    strSQL = strSQL + "FROM SALES_EVALUATION_VIEW E,ACC_LEDGER_Z_D_A L WHERE L.ZONE=E.LEDGER_NAME  ";
                    strSQL = strSQL + "AND E.PARTICULARS IN ('Sales Ach(%)','Coll Ach(%)') ";
                    strSQL = strSQL + "GROUP BY E.SORTING_TYPE ,L.ZONE,E.SEL_MODE,E.PARTICULARS ";
                    cmdAlter.CommandText = strSQL;
                    cmdAlter.ExecuteNonQuery();

                    strSQL = "SELECT ZONE,DIVISION,AREA ,SEL_MODE,SORTING_TYPE , PARTICULARS,AREA LEDGER_NAME_MERZE ,";
                    strSQL = strSQL + "JAN,FEB,MAR,APR,MAY,JUN,JUL,  AUG,SEP,OCT, NOV,";
                    strSQL = strSQL + "DEC,UP_TO_DATE_AMNT,BALANCE,TOTAL_PERCENT  FROM SALES_EVALUATION_VIEW1  ";
                    strSQL = strSQL + "ORDER BY ZONE,DIVISION,AREA,LEDGER_NAME_MERZE,SORTING_TYPE";
                }
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Mprojection oLedg = new Mprojection();
                    oLedg.strParticulars = dr["PARTICULARS"].ToString();
                    oLedg.intMode = Convert.ToInt32(dr["SEL_MODE"].ToString());
                    oLedg.strLedgerNameMerze = dr["LEDGER_NAME_MERZE"].ToString();
                    oLedg.strDivision = dr["DIVISION"].ToString();
                    oLedg.strZone = dr["ZONE"].ToString();
                    oLedg.strArea = dr["AREA"].ToString();
                    oLedg.JAN = Convert.ToDouble(dr["JAN"].ToString());
                    oLedg.FRB = Convert.ToDouble(dr["FEB"].ToString());
                    oLedg.MAR = Convert.ToDouble(dr["MAR"].ToString());
                    oLedg.APR = Convert.ToDouble(dr["APR"].ToString());
                    oLedg.MAY = Convert.ToDouble(dr["MAY"].ToString());
                    oLedg.JUN = Convert.ToDouble(dr["JUN"].ToString());
                    oLedg.JUL = Convert.ToDouble(dr["JUL"].ToString());
                    oLedg.AUG = Convert.ToDouble(dr["AUG"].ToString());
                    oLedg.SEP = Convert.ToDouble(dr["SEP"].ToString());
                    oLedg.OCT = Convert.ToDouble(dr["OCT"].ToString());
                    oLedg.NOV = Convert.ToDouble(dr["NOV"].ToString());
                    oLedg.DEC = Convert.ToDouble(dr["DEC"].ToString());
                    oLedg.dblBalance = Convert.ToDouble(dr["BALANCE"].ToString());
                    oLedg.dblUp_toDate_amnt = Convert.ToDouble(dr["UP_TO_DATE_AMNT"].ToString());
                    oLedg.dblTotalPer = Convert.ToDouble(dr["TOTAL_PERCENT"].ToString());

                    ooPer.Add(oLedg);
                }

                if (!dr.HasRows)
                {
                    Mprojection oLedg = new Mprojection();
                    oLedg.strLedgerNameMerze = "";
                    oLedg.strDivision = "";
                    oLedg.strZone = "";
                    oLedg.strArea = "";
                    oLedg.JAN = 0;
                    oLedg.FRB = 0;
                    oLedg.MAR = 0;
                    oLedg.APR = 0;
                    oLedg.MAY = 0;
                    oLedg.JUN = 0;
                    oLedg.JUL = 0;
                    oLedg.AUG = 0;
                    oLedg.SEP = 0;
                    oLedg.OCT = 0;
                    oLedg.NOV = 0;
                    oLedg.DEC = 0;
                    oLedg.dblUp_toDate_amnt = 0;
                    oLedg.dblTotalPer = 0;
                    ooPer.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return ooPer;
            }
        }
        #endregion
        #region "GetLedgerGroup"
        public List<Mprojection> mGetLedgerGroupLoad(string strDeComID, int intMode, string struserName)
        {
            string strSQL = null;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlDataReader dr;

                List<Mprojection> ooAccLedger = new List<Mprojection>();
                if (intMode == 1)
                {
                    strSQL = "  select Distinct LG.ZONE  AS FieldForce  from ACC_LEDGER_Z_D_A LG, ACC_LEDGER L ";
                    strSQL = strSQL + "where LG.LEDGER_NAME= L.LEDGER_NAME and l.LEDGER_STATUS=0 ";
                    strSQL = strSQL + "AND LG.DIVISION in( select LEDGER_GROUP_NAME from USER_PRIVILEGES_COLOR WHERE USER_LOGIN_NAME ='" + struserName + "') ";
                    strSQL = strSQL + "order by LG.ZONE ";
                }
                if (intMode == 2)
                {
                    strSQL = "  select Distinct LG.DIVISION  AS FieldForce  from ACC_LEDGER_Z_D_A LG, ACC_LEDGER L ";
                    strSQL = strSQL + "where LG.LEDGER_NAME= L.LEDGER_NAME and l.LEDGER_STATUS=0 ";
                    strSQL = strSQL + "AND LG.DIVISION in( select LEDGER_GROUP_NAME from USER_PRIVILEGES_COLOR WHERE USER_LOGIN_NAME ='" + struserName + "') ";
                    strSQL = strSQL + "order by LG.DIVISION ";
                }
                if (intMode == 3)
                {
                    strSQL = "  select Distinct LG.AREA AS FieldForce  from ACC_LEDGER_Z_D_A LG, ACC_LEDGER L ";
                    strSQL = strSQL + "where LG.LEDGER_NAME= L.LEDGER_NAME and l.LEDGER_STATUS=0 ";
                    strSQL = strSQL + "AND LG.DIVISION in( select LEDGER_GROUP_NAME from USER_PRIVILEGES_COLOR WHERE USER_LOGIN_NAME ='" + struserName + "') ";
                    strSQL = strSQL + "order by LG.AREA ";
                }
                if (intMode == 4)
                {
                    strSQL = "select L.LEDGER_NAME_MERZE AS FieldForce from ACC_LEDGER_Z_D_A LG, ACC_LEDGER L ";
                    strSQL = strSQL + "where LG.LEDGER_NAME= L.LEDGER_NAME and l.LEDGER_STATUS=0 ";
                    strSQL = strSQL + "AND LG.DIVISION in( select LEDGER_GROUP_NAME from USER_PRIVILEGES_COLOR WHERE USER_LOGIN_NAME ='" + struserName + "') ";
                    strSQL = strSQL + "order by  L.LEDGER_NAME_MERZE ";
                }
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Mprojection oLedg = new Mprojection();
                    oLedg.strGRName = dr["FieldForce"].ToString();
                    ooAccLedger.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return ooAccLedger;
            }
        }
        public List<Mprojection> mGetDivisionFromZone(string strDeComID, string strZone,int intHalt)
        {
            string strSQL = null;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlDataReader dr;

                List<Mprojection> ooAccLedger = new List<Mprojection>();

                strSQL = "SELECT LEDGER_NAME_MERZE FROM ACC_LEDGER_Z_D_A WHERE LEDGER_STATUS=0 ";
                strSQL = strSQL + "AND ZONE='" + strZone + "' ";
                strSQL = strSQL + "AND HALT_MPO=" + intHalt + " ";
                strSQL = strSQL + "ORDER by LEDGER_NAME_MERZE ";
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Mprojection oLedg = new Mprojection();
                    oLedg.strLedgerNameMerze = dr["LEDGER_NAME_MERZE"].ToString();
                    ooAccLedger.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return ooAccLedger;
            }
        }
        #endregion
        #region "Projection"
        public string mInsertProjectionSetup(string strDeComID, string strMonthID, string DgGrid)
        {


            string strSQL, strProjectionKey = "", strProjectionName = "", strProjectionDate = "", strProjectionStartDate = "", strProjectionEndDate = "";
          
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                try
                {
                    gcnMain.Open();

                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;

                    string[] words = DgGrid.Split('~');
                    foreach (string ooObj in words)
                    {
                        string[] ooItem = ooObj.Split('|');
                        if (ooItem[0] != "")
                        {
                            strProjectionKey = ooItem[0].ToString().Replace("'", "''");
                            strProjectionName = ooItem[1].ToString().Replace("'", "''");
                            strProjectionDate = ooItem[2].ToString().Replace("'", "''");
                            strProjectionStartDate = ooItem[3].ToString().Replace("'", "''");
                            strProjectionEndDate = ooItem[4].ToString().Replace("'", "''");

                            strSQL = "INSERT INTO  PROJECTION_SETUP (";
                            strSQL = strSQL + "PROJECTION_KEY, MONTH_ID,PROJECTION_NAME, PROJECTION_DATE, PROJECTION_START_DATE, PROJECTION_END_DATE ";
                            strSQL = strSQL + ") ";
                            strSQL = strSQL + "VALUES (";
                            strSQL = strSQL + "'" + strProjectionKey + "',";
                            strSQL = strSQL + "'" + strMonthID + "',";
                            strSQL = strSQL + "'" + strProjectionName + "',";
                            strSQL = strSQL + "" + Utility.cvtSQLDateString(strProjectionDate) + ",";
                            strSQL = strSQL + "" + Utility.cvtSQLDateString(strProjectionStartDate) + ",";
                            strSQL = strSQL + "" + Utility.cvtSQLDateString(strProjectionEndDate) + "";
                            strSQL = strSQL + ")";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }

                    }
                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "1";
                }
                catch (SqlException ex)
                {
                    return ex.Message.ToString();
                }
                finally
                {
                    gcnMain.Dispose();

                }
            }
        }
        public string mUpdateProjectionSetup(string strDeComID, string strMonthID, string DgGrid, string strProjectionKey)
        {
            string strSQL, strProjectionName = "", strProjectionDate = "", strProjectionStartDate = "", strProjectionEndDate = "";
          
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                try
                {
                    gcnMain.Open();

                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;

                    string[] words = DgGrid.Split('~');
                    foreach (string ooObj in words)
                    {
                        string[] ooItem = ooObj.Split('|');
                        if (ooItem[0] != "")
                        {
                            strProjectionKey = ooItem[0].ToString().Replace("'", "''");
                            strProjectionName = ooItem[1].ToString().Replace("'", "''");
                            strProjectionDate = ooItem[2].ToString().Replace("'", "''");
                            strProjectionStartDate = ooItem[3].ToString().Replace("'", "''");
                            strProjectionEndDate = ooItem[4].ToString().Replace("'", "''");

                            strSQL = "UPDATE   PROJECTION_SETUP SET ";
                            strSQL = strSQL + "MONTH_ID='" + strMonthID + "',";
                            strSQL = strSQL + "PROJECTION_NAME='" + strProjectionName + "',";
                            strSQL = strSQL + "PROJECTION_DATE=" + Utility.cvtSQLDateString(strProjectionDate) + ",";
                            strSQL = strSQL + "PROJECTION_START_DATE=" + Utility.cvtSQLDateString(strProjectionStartDate) + ",";
                            strSQL = strSQL + "PROJECTION_END_DATE=" + Utility.cvtSQLDateString(strProjectionEndDate) + "";
                            strSQL = strSQL + "WHERE PROJECTION_KEY='" + strProjectionKey + "' ";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }

                    }
                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "1";
                }
                catch (SqlException ex)
                {
                    return ex.Message.ToString();
                }
                finally
                {
                    gcnMain.Dispose();

                }
            }

        }

        public string DeletetProjectionSetUp(string strDeComID, string strProjectionkey)
        {

            string strresponse = "", strSQL = "";
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
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
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;

                    strSQL = "SELECT MONTH_ID FROM PRO_MONTHLY_PROJECTION_CHILD ";
                    strSQL = strSQL + "WHERE MONTH_ID='" + strProjectionkey.Substring(0, 5) + "' ";

                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        return "Transaction Found Cannot Delete";
                    }
                    dr.Close();

                    strSQL = "DELETE FROM PROJECTION_SETUP WHERE PROJECTION_KEY = '" + strProjectionkey + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.Transaction.Commit();
                    strresponse = "Delete Successfull";
                    return strresponse;
                }

                catch (SqlException ex)
                {
                    return ex.Message.ToString();
                }
                finally
                {
                    gcnMain.Dispose();

                }
            }
        }
        #endregion
        #region "Projection List"
        public List<ProjectionSet> mFillPojictionConfig(string strDeComID, string strMonthID)
        {

            string strSQL = null;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            SqlDataReader dr;
            List<ProjectionSet> ooVector = new List<ProjectionSet>();
            strSQL = "SELECT  PROJECTION_KEY, MONTH_ID, PROJECTION_NAME, PROJECTION_DATE, PROJECTION_START_DATE, PROJECTION_END_DATE ";
            strSQL = strSQL + "FROM PROJECTION_SETUP  ";
            if (strMonthID != "")
            {
                strSQL = strSQL + " WHERE MONTH_ID='" + strMonthID + "' ";
            }
            strSQL = strSQL + "Order by MONTH_ID ";
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    ProjectionSet ovector = new ProjectionSet();
                    ovector.strProjectionKey = dr["PROJECTION_KEY"].ToString();
                    ovector.strMonthID = dr["MONTH_ID"].ToString();
                    ovector.strProjectionName = dr["PROJECTION_NAME"].ToString();
                    ovector.strProjectionDate = Convert.ToDateTime(dr["PROJECTION_DATE"]).ToString("dddd, MMMM d, yyyy");
                    ovector.strStartDate = Convert.ToDateTime(dr["PROJECTION_START_DATE"]).ToString("dddd, MMMM d, yyyy");
                    ovector.strEndDate = Convert.ToDateTime(dr["PROJECTION_END_DATE"]).ToString("dddd, MMMM d, yyyy");

                    ooVector.Add(ovector);
                }
                return ooVector;
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
            }

        }

        #endregion
        #region "Month Config"
        public string mInsertMonthConfig(string strDeComID, string strMonthID, string strMonthFromDate, string strMonthToDate, int intStatus)
        {
            string strSQL = "";
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                try
                {
                    gcnMain.Open();

                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;

                    if (intStatus == 1)
                    {
                        strSQL = "UPDATE  PRO_MONTH_CONFIG SET ";
                        strSQL = strSQL + "STATUS =0 ";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }
                    strSQL = "INSERT INTO  PRO_MONTH_CONFIG (";
                    strSQL = strSQL + " MONTH_ID, FROM_DATE, TO_DATE, STATUS ";
                    strSQL = strSQL + ") ";
                    strSQL = strSQL + "VALUES (";
                    strSQL = strSQL + "'" + strMonthID + "',";
                    strSQL = strSQL + " " + Utility.cvtSQLDateString(strMonthFromDate) + ",";
                    strSQL = strSQL + "" + Utility.cvtSQLDateString(strMonthToDate) + ",";
                    strSQL = strSQL + "" + intStatus + "";
                    strSQL = strSQL + ")";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.Transaction.Commit();
                    return "1";
                }
                catch (SqlException ex)
                {
                    return ex.Message.ToString();
                }
                finally
                {
                    gcnMain.Dispose();

                }
            }

        }

        public string mUpdateMonthConfigpublic(string strDeComID, string strMonthID, string strFromDate, string strToDate, int intStatus, int intSerialKey)
        {
            string strSQL = "";
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                try
                {
                    gcnMain.Open();


                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;

                    if (intStatus == 1)
                    {
                        strSQL = "UPDATE  PRO_MONTH_CONFIG SET ";
                        strSQL = strSQL + "STATUS =0 ";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }

                    strSQL = "UPDATE  PRO_MONTH_CONFIG SET ";
                    strSQL = strSQL + "MONTH_ID='" + strMonthID + "',";
                    strSQL = strSQL + "FROM_DATE=" + Utility.cvtSQLDateString(strFromDate) + ",";
                    strSQL = strSQL + "TO_DATE=" + Utility.cvtSQLDateString(strToDate) + ",";
                    strSQL = strSQL + "STATUS =" + intStatus + " ";
                    strSQL = strSQL + "WHERE MONTH_SERIAL=" + intSerialKey + " ";

                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.Transaction.Commit();


                    return "1";
                }
                catch (SqlException ex)
                {
                    return ex.Message.ToString();
                }
                finally
                {
                    gcnMain.Dispose();

                }
            }

        }

        public string DeletetMonthConfig(string strDeComID, int intSerialkey)
        {

            string strresponse = "", strSQL = "";
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                try
                {
                    gcnMain.Open();

                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;

                    strSQL = "DELETE FROM PRO_MONTH_CONFIG WHERE MONTH_SERIAL = " + intSerialkey + "";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.Transaction.Commit();
                    strresponse = "Delete Successfull";
                    return strresponse;
                }

                catch (SqlException ex)
                {
                    return "Transaction Found Cannot Delete";
                }
                finally
                {
                    gcnMain.Dispose();

                }
            }
        }
        #endregion
        #region "Month List"
        public List<ProjectonMonthConfig> mFillMonthConfig(string strDeComID, int intStaus)
        {

            string strSQL = null;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            SqlDataReader dr;
            List<ProjectonMonthConfig> ooVector = new List<ProjectonMonthConfig>();
            strSQL = "SELECT MONTH_SERIAL,MONTH_ID, FROM_DATE, TO_DATE, STATUS ";
            strSQL = strSQL + "FROM PRO_MONTH_CONFIG  ";
            if (intStaus == 1)
            {
                strSQL = strSQL + " WHERE STATUS=" + intStaus + " ";
            }
            strSQL = strSQL + "Order by MONTH_SERIAL ";
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    ProjectonMonthConfig ovector = new ProjectonMonthConfig();
                    ovector.intSerial = Convert.ToInt16(dr["MONTH_SERIAL"].ToString());
                    ovector.strMonthID = dr["MONTH_ID"].ToString();
                    ovector.strFromDate = Convert.ToDateTime(dr["FROM_DATE"]).ToString("dd-MM-yyyy");
                    ovector.strToDate = Convert.ToDateTime(dr["TO_DATE"]).ToString("dd-MM-yyyy");
                    ovector.intStatus = Convert.ToInt16(dr["STATUS"].ToString());

                    ooVector.Add(ovector);
                }
                return ooVector;
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
            }

        }
        public string gCheckProjectionActive(string strDeComID, string strDate)
        {

            string strSQL = null, strName = "";
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            SqlDataReader dr;
            List<ProjectonMonthConfig> ooVector = new List<ProjectonMonthConfig>();
            strSQL = "SELECT PROJECTION_NAME  FROM PROJECTION_SETUP ";
            strSQL = strSQL + "WHERE " + Utility.cvtSQLDateString(strDate) + " BETWEEN PROJECTION_DATE AND PROJECTION_END_DATE   ";

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strName = dr["PROJECTION_NAME"].ToString();

                }
                return strName;
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
            }

        }
        public List<ProjectonMonthConfig> getZoneFromDivsion(string strDeComID, string strDivision)
        {

            string strSQL = null;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            SqlDataReader dr;
            List<ProjectonMonthConfig> ooVector = new List<ProjectonMonthConfig>();

            strSQL = "select  COUNT (DISTINCT ACC_LEDGER_Z_D_A.AREA) AREA,COUNT(DISTINCT ACC_LEDGER_Z_D_A.LEDGER_NAME) LEDGER_NAME, ZONE  from ACC_LEDGER_Z_D_A,ACC_LEDGER ";
            strSQL = strSQL + "WHERE ACC_LEDGER.LEDGER_NAME =ACC_LEDGER_Z_D_A.LEDGER_NAME  ";
            strSQL = strSQL + "and  ACC_LEDGER_Z_D_A.DIVISION='" + strDivision.Replace("'", "''") + "' ";
            strSQL = strSQL + " AND ACC_LEDGER.LEDGER_STATUS =0 ";
            strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.ZONE ";



            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    ProjectonMonthConfig ovector = new ProjectonMonthConfig();
                    ovector.lngTotalArea = Convert.ToInt64(dr["AREA"]);
                    ovector.lngTotalLedger = Convert.ToInt64(dr["LEDGER_NAME"].ToString());
                    ovector.strZone = dr["ZONE"].ToString();
                    ooVector.Add(ovector);
                }
                return ooVector;
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
            }

        }
        #endregion
        #region " Projection Report"
        public List<PCollectionCopmarison> mGetMontlyLadgerProjection(string strDeComID, string strThisMonth, string strledger)
        {
            string strSQL = null;
            
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlDataReader dr;
                List<PCollectionCopmarison> oooChequePrint = new List<PCollectionCopmarison>();
                strSQL = "select distinct L.LEDGER_NAME  from PRO_MONTHLY_PROJECTION_CHILD P ,  ACC_LEDGER_Z_D_A L ";
                strSQL = strSQL + " where P.LEDGER_NAME= L.LEDGER_NAME   and P.MONTH_ID ='" + strThisMonth + "'  ";

                if (strledger != "")
                {
                    strSQL = strSQL + "AND (L.DIVISION  IN (" + strledger + ") ";
                    strSQL = strSQL + " or L.AREA  IN (" + strledger + ") ";
                    strSQL = strSQL + " or L.LEDGER_NAME_MERZE  IN (" + strledger + ") ";
                    strSQL = strSQL + " or L.ZONE  IN (" + strledger + ")) ";
                }
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    PCollectionCopmarison ogrp = new PCollectionCopmarison();
                    ogrp.strLedgerName = dr["LEDGER_NAME"].ToString();
                    oooChequePrint.Add(ogrp);
                }

                if (!dr.HasRows)
                {
                    PCollectionCopmarison oLedg = new PCollectionCopmarison();
                    oLedg.strstrDate = "";
                    oLedg.strEndDate = "";
                    oooChequePrint.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return oooChequePrint;
            }
        }

      
        public List<PCollectionCopmarison> mGetProjectionReport(string strDeComID, string strProjectionName, string strFromMonthID, string strEndMonthID, 
                                                                int intmode, string strLedgerName, string strProjectionNamee)
        {
            string strSQL = "", strLedger = "", strProjectionN, strThisMonthNamee = "", strLastMonthName = "", strFdate = "", strTdate = "", strMonthName = "", strLastFdate = "", strLastTdate = "";
            double dblTotalProjecton = 0, dblTotalCollection = 0, dblProjectonValue = 0, dblWrittenValue = 0, dblColl = 0, dblPending = 0,dblTotalWritten=0,dblTotalPending=0;
            SqlDataReader dr;

            connstring = Utility.SQLConnstringComSwitch(strDeComID);
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

                List<PCollectionCopmarison> ooLed = new List<PCollectionCopmarison>();
                if (intmode == 0)
                {
                    strSQL = "DELETE FROM PROJECTION_TEMP ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                }
                //string dddd = strProjectionName.ToString().Replace("'", "''");

                //////Total Projection Value  ////////////    
                //if (strInsertT == "Y")
                //{
                    strThisMonthNamee = "1-Total Proj";
                    strSQL = "select sum( P.AMOUNT) RecAmt  ";
                    strSQL = strSQL + "from   PRO_WEEKLY_PROJECTION P  ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "where P.LEDGER_NAME ='" + strLedgerName + "'  ";

                    }
                    strSQL = strSQL + "and MONTH_ID='" + strFromMonthID + "' and P.PROJECTION_NAME !='Written' ";
                    strSQL = strSQL + "and P.PROJECTION_NAME in('" + strProjectionName + "')";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        strLedger = strLedgerName;
                        strProjectionN = strProjectionName;
                        if (dr["RecAmt"].ToString() != "")
                        {
                            dblTotalProjecton = Convert.ToDouble(dr["RecAmt"].ToString());
                        }
                        else
                        {
                            dblTotalProjecton = 0;
                        }

                    }
                    else
                    {
                        strLedger = strLedgerName;
                        strProjectionN = strProjectionName;
                        dblTotalProjecton = 0;
                    }

                    dr.Close();

                                
               
                    //////Collection////////////    
                    strSQL = "SELECT min(PROJECTION_START_DATE) as ProjStartDate, max(PROJECTION_END_DATE) as ProjEndDate ";
                    strSQL = strSQL + "FROM  PROJECTION_SETUP ";
                    strSQL = strSQL + "WHERE  (MONTH_ID = '" + strFromMonthID + "') ";
                    strSQL = strSQL + "and PROJECTION_NAME in('" + strProjectionName + "')";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    while (dr.Read())
                    {
                        strFdate = Convert.ToDateTime(dr["ProjStartDate"]).ToString("dd-MM-yyyy");
                        strTdate = Convert.ToDateTime(dr["ProjEndDate"]).ToString("dd-MM-yyyy");
                    }
                    dr.Close();

                    strSQL = "select '" + strLedgerName + "','" + strProjectionName + "','" + strMonthName + "', sum( V.VOUCHER_CREDIT_AMOUNT) RecAmt  ";
                    strSQL = strSQL + "from ACC_VOUCHER V  ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "where V.LEDGER_NAME ='" + strLedgerName + "'  ";
                    }
                    if (strFdate != "")
                    {
                        strSQL = strSQL + "and (V.COMP_VOUCHER_DATE >= " + Utility.cvtSQLDateString(strFdate) + ") and (V.COMP_VOUCHER_DATE <= " + Utility.cvtSQLDateString(strTdate) + ")  ";
                    }

                    strSQL = strSQL + "and V.COMP_VOUCHER_TYPE=1 and V.VOUCHER_TOBY='Cr' Group by V.LEDGER_NAME  ";

                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {

                        strLedger = strLedgerName;
                        strProjectionN = strProjectionName;
                        dblTotalCollection = Convert.ToDouble(dr["RecAmt"].ToString());

                    }
                    else
                    {
                        strLedger = strLedgerName;
                        strProjectionN = strProjectionName;
                        dblTotalCollection = 0;
                    }

                    dr.Close();

                    
                    strSQL = "select sum( P.AMOUNT) RecAmt  ";
                    strSQL = strSQL + "from   PRO_WEEKLY_PROJECTION P  ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "where P.LEDGER_NAME ='" + strLedgerName + "'  ";

                    }
                    strSQL = strSQL + "and MONTH_ID='" + strFromMonthID + "' and P.PROJECTION_NAME ='Written' ";
                    strSQL = strSQL + "and P.COMM_PROJECTON_NAME in('" + strProjectionName + "')";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        strLedger = strLedgerName;
                        strProjectionN = strProjectionName;
                        if (dr["RecAmt"].ToString() != "")
                        {
                            dblTotalWritten = Convert.ToDouble(dr["RecAmt"].ToString());
                        }
                        else
                        {
                            dblTotalWritten = 0;
                        }

                    }
                    else
                    {
                        strLedger = strLedgerName;
                        strProjectionN = strProjectionName;
                        dblTotalWritten = 0;
                    }

                    dr.Close();



                    dblTotalPending = Math.Round(dblTotalWritten - dblTotalCollection, 2);

                    strSQL = "INSERT INTO PROJECTION_TEMP(LEDGER_NAME, PROJECTION_NAME, MONTH_NAME, AMOUNT) ";
                    strSQL = strSQL + "(Select '" + strLedger + "','99-Total Projection','" + strThisMonthNamee + "', " + dblTotalProjecton + ")  ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "INSERT INTO PROJECTION_TEMP(LEDGER_NAME, PROJECTION_NAME, MONTH_NAME, AMOUNT) ";
                    strSQL = strSQL + "(Select '" + strLedger + "','99-Total Projection','2-Total Written', " + dblTotalWritten + ")  ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();




                    strSQL = "INSERT INTO PROJECTION_TEMP(LEDGER_NAME, PROJECTION_NAME, MONTH_NAME, AMOUNT) ";
                    strSQL = strSQL + "(Select '" + strLedger + "','99-Total Projection','4-Total Pending', " + dblTotalPending + ")  ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO PROJECTION_TEMP(LEDGER_NAME, PROJECTION_NAME, MONTH_NAME, AMOUNT) ";
                    strSQL = strSQL + "(Select '" + strLedger + "','99-Total Projection','3-Total Coll', " + dblTotalCollection + ")  ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    //////Achv(%)////////////  
                    double dblAchIP = 0;
                    if (dblTotalProjecton != 0)
                    {
                        dblAchIP = (dblTotalCollection / dblTotalProjecton);
                        //dblAchIP = dblTotalCollection + dblTotalProjecton;
                    }

                    //strSQL = "INSERT INTO PROJECTION_TEMP(LEDGER_NAME, PROJECTION_NAME, MONTH_NAME, AMOUNT) ";
                    //strSQL = strSQL + "(Select '" + strLedger + "','99-Total Projection','5-Achv.(%)', " + dblAchIP + ")  ";
                    //cmdInsert.CommandText = strSQL;
                    //cmdInsert.ExecuteNonQuery();
       
                //////Projection Value////////////   
                //////Projtion Wise Collection////////////    

                strThisMonthNamee = "03Coll";
                strSQL = "SELECT MONTH_ID, PROJECTION_NAME ,PROJECTION_START_DATE, PROJECTION_END_DATE ";
                strSQL = strSQL + "FROM  PROJECTION_SETUP ";
                strSQL = strSQL + "WHERE  (MONTH_ID = '" + strFromMonthID + "') AND PROJECTION_NAME='" + strProjectionName + "'";
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                while (dr.Read())
                {
                    strFdate = Convert.ToDateTime(dr["PROJECTION_START_DATE"]).ToString("dd-MM-yyyy");
                    strTdate = Convert.ToDateTime(dr["PROJECTION_END_DATE"]).ToString("dd-MM-yyyy");
                }
                dr.Close();

                strSQL = "select '" + strLedgerName + "','" + strProjectionName + "','" + strMonthName + "', sum( V.VOUCHER_CREDIT_AMOUNT) RecAmt  ";
                strSQL = strSQL + "from ACC_VOUCHER V  ";
                if (strLedgerName != "")
                {
                    strSQL = strSQL + "where V.LEDGER_NAME ='" + strLedgerName + "'  ";
                }
                if (strFdate != "")
                {
                    strSQL = strSQL + "and (V.COMP_VOUCHER_DATE >= " + Utility.cvtSQLDateString(strFdate) + ") and (V.COMP_VOUCHER_DATE <= " + Utility.cvtSQLDateString(strTdate) + ")  ";
                }

                strSQL = strSQL + "and V.COMP_VOUCHER_TYPE=1 and V.VOUCHER_TOBY='Cr' Group by V.LEDGER_NAME  ";

                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    strLedger = strLedgerName;
                    strProjectionN = strProjectionName;
                    dblColl = Convert.ToDouble(dr["RecAmt"].ToString());
                }
                else
                {
                    strLedger = strLedgerName;
                    strProjectionN = strProjectionName;
                    dblColl = 0;
                }

                dr.Close();


                strSQL = "INSERT INTO PROJECTION_TEMP(LEDGER_NAME, PROJECTION_NAME, MONTH_NAME, AMOUNT) ";
                strSQL = strSQL + "(Select '" + strLedger + "','" + strProjectionN + "','" + strThisMonthNamee + "', " + dblColl + ")  ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                //////End Collection////////////   

                strThisMonthNamee = "01Projection Value";
                strSQL = "select sum( P.AMOUNT) RecAmt  ";
                strSQL = strSQL + "from   PRO_WEEKLY_PROJECTION P  ";
                if (strLedgerName != "")
                {
                    strSQL = strSQL + "where P.LEDGER_NAME ='" + strLedgerName + "' and P.PROJECTION_NAME='" + strProjectionName + "' and MONTH_ID='" + strFromMonthID + "'";
                }

                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {

                    strLedger = strLedgerName;
                    strProjectionN = strProjectionName;
                    if (dr["RecAmt"].ToString() != "")
                    {
                        dblProjectonValue = Convert.ToDouble(dr["RecAmt"].ToString());
                    }
                    else
                    {
                        dblProjectonValue = 0;
                    }

                }
                else
                {
                    strLedger = strLedgerName;
                    strProjectionN = strProjectionName;
                    dblProjectonValue = 0;
                }

                dr.Close();


                strSQL = "INSERT INTO PROJECTION_TEMP(LEDGER_NAME, PROJECTION_NAME, MONTH_NAME, AMOUNT) ";
                strSQL = strSQL + "(Select '" + strLedger + "','" + strProjectionN + "','" + strThisMonthNamee + "', " + dblProjectonValue + ")  ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                //////End Projection Value////////////   



                //////Written//////////// 


                strLastMonthName = "02Written";
                strSQL = "SELECT MONTH_ID, PROJECTION_NAME ,PROJECTION_START_DATE, PROJECTION_END_DATE ";
                strSQL = strSQL + "FROM  PROJECTION_SETUP ";
                strSQL = strSQL + "WHERE  (MONTH_ID = '" + strFromMonthID + "') AND PROJECTION_NAME='" + strProjectionName + "'";
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();

                while (dr.Read())
                {
                    strLastFdate = Convert.ToDateTime(dr["PROJECTION_START_DATE"]).ToString("dd-MM-yyyy");
                    strLastTdate = Convert.ToDateTime(dr["PROJECTION_END_DATE"]).ToString("dd-MM-yyyy");
                }
                dr.Close();
                if (strLastFdate != "")
                {
                    strSQL = "select sum( P.AMOUNT) RecAmt  ";
                    strSQL = strSQL + "from   PRO_WEEKLY_PROJECTION P  ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "where P.LEDGER_NAME ='" + strLedgerName + "' and P.PROJECTION_NAME='Written' and MONTH_ID='" + strFromMonthID + "' AND P.COMM_PROJECTON_NAME='" + strProjectionName + "'";
                    }


                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {

                        strLedger = strLedgerName;
                        strProjectionN = strProjectionName;
                        if (dr["RecAmt"].ToString() != "")
                        {
                            dblWrittenValue = Convert.ToDouble(dr["RecAmt"].ToString());
                        }
                        else
                        {
                            dblWrittenValue = 0;
                        }

                    }
                    else
                    {
                        strLedger = strLedgerName;
                        strProjectionN = strProjectionName;
                        dblWrittenValue = 0;
                    }

                    dr.Close();
                }
                else
                {
                    strLedger = strLedgerName;
                    strProjectionN = strProjectionName;
                    dblWrittenValue = 0;

                }


                strSQL = "INSERT INTO PROJECTION_TEMP(LEDGER_NAME, PROJECTION_NAME, MONTH_NAME, AMOUNT) ";
                strSQL = strSQL + "(Select '" + strLedger + "','" + strProjectionN + "','" + strLastMonthName + "', " + dblWrittenValue + ")  ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                dblPending = dblWrittenValue - dblColl;
                strSQL = "INSERT INTO PROJECTION_TEMP(LEDGER_NAME, PROJECTION_NAME, MONTH_NAME, AMOUNT) ";
                strSQL = strSQL + "(Select '" + strLedger + "','" + strProjectionN + "','04Pending', " + dblPending + ")  ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                cmdInsert.Transaction.Commit();
                //////End Written////////////   
                return ooLed;

            }
        }


        public List<PCollectionCopmarison> mGetProjectionStarEndDate(string strDeComID, string strThisMonth, string strLastMont,string strProIndividual)
        {
            string strSQL = null;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlDataReader dr;

                List<PCollectionCopmarison> oooChequePrint = new List<PCollectionCopmarison>();

                strSQL = "SELECT MONTH_ID, PROJECTION_NAME ,PROJECTION_START_DATE, PROJECTION_END_DATE ";
                strSQL = strSQL + "FROM  PROJECTION_SETUP ";
                strSQL = strSQL + "WHERE  (MONTH_ID = '" + strThisMonth + "') ";
                ////strSQL = strSQL + "AND  (PROJECTION_NAME IN (" + strProIndividual + ")) ";
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    PCollectionCopmarison oLedg = new PCollectionCopmarison();
                    oLedg.strstrDate = Convert.ToDateTime(dr["PROJECTION_START_DATE"]).ToString("dd-MM-yyyy");
                    oLedg.strEndDate = Convert.ToDateTime(dr["PROJECTION_END_DATE"]).ToString("dd-MM-yyyy");
                    oLedg.strMonthID = dr["MONTH_ID"].ToString();
                    oLedg.strProjectionName = dr["PROJECTION_NAME"].ToString();
                    oooChequePrint.Add(oLedg);
                }

                if (!dr.HasRows)
                {
                    PCollectionCopmarison oLedg = new PCollectionCopmarison();
                    oLedg.strstrDate = "";
                    oLedg.strEndDate = "";
                    oooChequePrint.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return oooChequePrint;
            }
        }
        #endregion
        #region "Collection Comparision Report"
        public List<PCollectionCopmarison> mGetCollectionComparisionReport(string strDeComID, string strProjectionName, string strFromMonthID, string strEndMonthID, int intmode, string strLedgerName, string strProjectionNamee)
        {
            string strSQL = "", strLedger = "", strProjectionN, strThisMonthNamee = "", strLastMonthName = "", strFdate = "", strTdate = "", strMonthName = "", strLastFdate = "", strLastTdate = "";
            double dblThisMonthAmt = 0, dblLastMonthAmt = 0, dblGAPcal = 0, dblGrowthPer = 0;
            double dblGrowrtTotal = 0, dblGrwthPer = 0;
            SqlDataReader dr;

            connstring = Utility.SQLConnstringComSwitch(strDeComID);
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

                List<PCollectionCopmarison> ooLed = new List<PCollectionCopmarison>();
                if (intmode == 0)
                {
                    strSQL = "DELETE FROM PROJECTION_TEMP ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                }

                string dddd = strProjectionName.ToString().Replace("'", "''");
                //////Total Projection  This Month ////////////    
                if (strProjectionName == "01st")
                {
                    strThisMonthNamee = "01This Month";
                    strSQL = "SELECT min(PROJECTION_START_DATE) as MinStartdate , max(PROJECTION_END_DATE ) as maxEndDate ";
                    strSQL = strSQL + "FROM  PROJECTION_SETUP ";
                    strSQL = strSQL + "WHERE  (MONTH_ID = '" + strFromMonthID + "') ";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    while (dr.Read())
                    {
                        strFdate = Convert.ToDateTime(dr["MinStartdate"]).ToString("dd-MM-yyyy");
                        strTdate = Convert.ToDateTime(dr["maxEndDate"]).ToString("dd-MM-yyyy");
                    }
                    dr.Close();

                    strSQL = "select '" + strLedgerName + "','" + strProjectionName + "','" + strMonthName + "', sum( V.VOUCHER_CREDIT_AMOUNT) RecAmt  ";
                    strSQL = strSQL + "from ACC_VOUCHER V  ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "where V.LEDGER_NAME ='" + strLedgerName + "'  ";
                    }
                    if (strFdate != "")
                    {
                        strSQL = strSQL + "and (V.COMP_VOUCHER_DATE >= " + Utility.cvtSQLDateString(strFdate) + ") and (V.COMP_VOUCHER_DATE <= " + Utility.cvtSQLDateString(strTdate) + ")  ";
                    }

                    strSQL = strSQL + "and V.COMP_VOUCHER_TYPE=1 and V.VOUCHER_TOBY='Cr' Group by V.LEDGER_NAME  ";

                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {

                        strLedger = strLedgerName;
                        strProjectionN = strProjectionName;
                        dblThisMonthAmt = Convert.ToDouble(dr["RecAmt"].ToString());

                    }
                    else
                    {
                        strLedger = strLedgerName;
                        strProjectionN = strProjectionName;
                        dblThisMonthAmt = 0;
                    }

                    dr.Close();


                    strSQL = "INSERT INTO PROJECTION_TEMP(LEDGER_NAME, PROJECTION_NAME, MONTH_NAME, AMOUNT) ";
                    strSQL = strSQL + "(Select '" + strLedger + "','0.1Total Projection','" + strThisMonthNamee + "', " + dblThisMonthAmt + ")  ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                }

                //////End ////////////   
                //////Total Projection  Last Month ////////////    
                if (strProjectionName == "01st")
                {
                    strThisMonthNamee = "02Last Month";
                    strSQL = "SELECT min(PROJECTION_START_DATE) as MinStartdate , max(PROJECTION_END_DATE ) as maxEndDate ";
                    strSQL = strSQL + "FROM  PROJECTION_SETUP ";
                    strSQL = strSQL + "WHERE  (MONTH_ID = '" + strEndMonthID + "') ";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();

                    while (dr.Read())
                    {
                        strFdate = "";
                        strTdate = "";

                        if (dr["MinStartdate"].ToString() != "")
                        {
                            strFdate = Convert.ToDateTime(dr["MinStartdate"]).ToString("dd-MM-yyyy");
                        }
                        if (dr["maxEndDate"].ToString() != "")
                        {
                            strTdate = Convert.ToDateTime(dr["maxEndDate"]).ToString("dd-MM-yyyy");
                        }
                    }
                    dr.Close();

                    if (strFdate != "")
                    {
                        strSQL = "select '" + strLedgerName + "','" + strProjectionName + "','" + strMonthName + "', sum( V.VOUCHER_CREDIT_AMOUNT) RecAmt  ";
                        strSQL = strSQL + "from ACC_VOUCHER V  ";
                        if (strLedgerName != "")
                        {
                            strSQL = strSQL + "where V.LEDGER_NAME ='" + strLedgerName + "'  ";
                        }

                        strSQL = strSQL + "and (V.COMP_VOUCHER_DATE >= " + Utility.cvtSQLDateString(strFdate) + ") and (V.COMP_VOUCHER_DATE <= " + Utility.cvtSQLDateString(strTdate) + ")  ";


                        strSQL = strSQL + "and V.COMP_VOUCHER_TYPE=1 and V.VOUCHER_TOBY='Cr' Group by V.LEDGER_NAME  ";


                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {

                            strLedger = strLedgerName;
                            strProjectionN = strProjectionName;
                            dblLastMonthAmt = Convert.ToDouble(dr["RecAmt"].ToString());

                        }
                    }
                    else
                    {
                        strLedger = strLedgerName;
                        strProjectionN = strProjectionName;
                        dblLastMonthAmt = 0;
                    }

                    dr.Close();


                    strSQL = "INSERT INTO PROJECTION_TEMP(LEDGER_NAME, PROJECTION_NAME, MONTH_NAME, AMOUNT) ";
                    strSQL = strSQL + "(Select '" + strLedger + "','0.1Total Projection','" + strThisMonthNamee + "', " + dblLastMonthAmt + ")  ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                }
                //Growth
                if (strProjectionName == "01st")
                {



                    dblGrowrtTotal = dblThisMonthAmt - dblLastMonthAmt;
                    if (dblLastMonthAmt != 0)
                    {
                        dblGrwthPer = Math.Round((dblGrowrtTotal / dblLastMonthAmt) * 100, 2);
                    }

                    strSQL = "INSERT INTO PROJECTION_TEMP(LEDGER_NAME, PROJECTION_NAME, MONTH_NAME, AMOUNT) ";
                    strSQL = strSQL + "(Select '" + strLedger + "','0.1Total Projection','03Growth', " + dblGrowrtTotal + ")  ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO PROJECTION_TEMP(LEDGER_NAME, PROJECTION_NAME, MONTH_NAME, AMOUNT) ";
                    strSQL = strSQL + "(Select '" + strLedger + "','0.1Total Projection','04Growth Per', " + dblGrwthPer + ")  ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                }


                dblLastMonthAmt = 0;


                //////End ////////////   

                //////This Month////////////    

                strThisMonthNamee = "01This Month";
                strSQL = "SELECT MONTH_ID, PROJECTION_NAME ,PROJECTION_START_DATE, PROJECTION_END_DATE ";
                strSQL = strSQL + "FROM  PROJECTION_SETUP ";
                strSQL = strSQL + "WHERE  (MONTH_ID = '" + strFromMonthID + "') AND PROJECTION_NAME='" + strProjectionName + "'";
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                while (dr.Read())
                {
                    strFdate = Convert.ToDateTime(dr["PROJECTION_START_DATE"]).ToString("dd-MM-yyyy");
                    strTdate = Convert.ToDateTime(dr["PROJECTION_END_DATE"]).ToString("dd-MM-yyyy");
                }
                dr.Close();

                strSQL = "select '" + strLedgerName + "','" + strProjectionName + "','" + strMonthName + "', sum( V.VOUCHER_CREDIT_AMOUNT) RecAmt  ";
                strSQL = strSQL + "from ACC_VOUCHER V  ";
                if (strLedgerName != "")
                {
                    strSQL = strSQL + "where V.LEDGER_NAME ='" + strLedgerName + "'  ";
                }
                if (strFdate != "")
                {
                    strSQL = strSQL + "and (V.COMP_VOUCHER_DATE >= " + Utility.cvtSQLDateString(strFdate) + ") and (V.COMP_VOUCHER_DATE <= " + Utility.cvtSQLDateString(strTdate) + ")  ";
                }

                strSQL = strSQL + "and V.COMP_VOUCHER_TYPE=1 and V.VOUCHER_TOBY='Cr' Group by V.LEDGER_NAME  ";

                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {

                    strLedger = strLedgerName;
                    strProjectionN = strProjectionName;
                    dblThisMonthAmt = Convert.ToDouble(dr["RecAmt"].ToString());

                }
                else
                {
                    strLedger = strLedgerName;
                    strProjectionN = strProjectionName;
                    dblThisMonthAmt = 0;
                }

                dr.Close();


                strSQL = "INSERT INTO PROJECTION_TEMP(LEDGER_NAME, PROJECTION_NAME, MONTH_NAME, AMOUNT) ";
                strSQL = strSQL + "(Select '" + strLedger + "','" + strProjectionN + "','" + strThisMonthNamee + "', " + dblThisMonthAmt + ")  ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                //////End This Month////////////   



                //////Last Month//////////// 


                strLastMonthName = "02Last Month";
                strSQL = "SELECT MONTH_ID, PROJECTION_NAME ,PROJECTION_START_DATE, PROJECTION_END_DATE ";
                strSQL = strSQL + "FROM  PROJECTION_SETUP ";
                strSQL = strSQL + "WHERE  (MONTH_ID = '" + strEndMonthID + "') AND PROJECTION_NAME='" + strProjectionName + "'";
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();

                while (dr.Read())
                {
                    strLastFdate = Convert.ToDateTime(dr["PROJECTION_START_DATE"]).ToString("dd-MM-yyyy");
                    strLastTdate = Convert.ToDateTime(dr["PROJECTION_END_DATE"]).ToString("dd-MM-yyyy");
                }
                dr.Close();
                if (strLastFdate != "")
                {
                    strSQL = "select '" + strLedgerName + "','" + strProjectionName + "','" + strMonthName + "', sum( V.VOUCHER_CREDIT_AMOUNT) RecAmt  ";
                    strSQL = strSQL + "from ACC_VOUCHER V  ";
                    if (strLedgerName != "")
                    {
                        strSQL = strSQL + "where V.LEDGER_NAME ='" + strLedgerName + "'  ";
                    }
                    if (strFdate != "")
                    {
                        strSQL = strSQL + "AND (V.COMP_VOUCHER_DATE >= " + Utility.cvtSQLDateString(strLastFdate) + ") and (V.COMP_VOUCHER_DATE <= " + Utility.cvtSQLDateString(strLastTdate) + ")  ";
                    }

                    strSQL = strSQL + "and V.COMP_VOUCHER_TYPE=1 and V.VOUCHER_TOBY='Cr' Group by V.LEDGER_NAME  ";

                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {

                        strLedger = strLedgerName;
                        strProjectionN = strProjectionName;
                        dblLastMonthAmt = Convert.ToDouble(dr["RecAmt"].ToString());

                    }
                    else
                    {
                        strLedger = strLedgerName;
                        strProjectionN = strProjectionName;
                        dblLastMonthAmt = 0;
                    }

                    dr.Close();
                }
                else
                {
                    strLedger = strLedgerName;
                    strProjectionN = strProjectionName;
                    dblLastMonthAmt = 0;

                }


                strSQL = "INSERT INTO PROJECTION_TEMP(LEDGER_NAME, PROJECTION_NAME, MONTH_NAME, AMOUNT) ";
                strSQL = strSQL + "(Select '" + strLedger + "','" + strProjectionN + "','" + strLastMonthName + "', " + dblLastMonthAmt + ")  ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                dblGAPcal = dblThisMonthAmt - dblLastMonthAmt;
                strSQL = "INSERT INTO PROJECTION_TEMP(LEDGER_NAME, PROJECTION_NAME, MONTH_NAME, AMOUNT) ";
                strSQL = strSQL + "(Select '" + strLedger + "','" + strProjectionN + "','03Growth', " + dblGAPcal + ")  ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                if (dblThisMonthAmt != 0)
                {
                    if (dblLastMonthAmt != 0)
                    {
                        dblGrowthPer = ((dblThisMonthAmt - dblLastMonthAmt) / dblLastMonthAmt) * 100;
                    }
                    else
                    {
                        dblGrowthPer = 0;
                    }
                }
                else
                {
                    dblGrowthPer = 0;
                }
                strSQL = "INSERT INTO PROJECTION_TEMP(LEDGER_NAME, PROJECTION_NAME, MONTH_NAME, AMOUNT) ";
                strSQL = strSQL + "(Select '" + strLedger + "','" + strProjectionN + "','04Growth(%)', " + dblGrowthPer + ")  ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                cmdInsert.Transaction.Commit();
                //////End Last Month////////////   

                return ooLed;

            }
        }

        //public List<PCollectionCopmarison> mGetCollectionComparisionReport(string strDeComID, string strProjectionName, string strFromMonthID, string strEndMonthID, int intmode, string strLedgerName, string strProjectionNamee)
        //{
        //    string strSQL = "", strLedger = "", strProjectionN, strThisMonthNamee = "", strLastMonthName = "", strFdate = "", strTdate = "", strMonthName = "", strLastFdate = "", strLastTdate = "";
        //    double dblThisMonthAmt = 0, dblLastMonthAmt = 0, dblGAPcal = 0, dblGrowthPer = 0;
        //    SqlDataReader dr;

        //    connstring = Utility.SQLConnstringComSwitch(strDeComID);
        //    using (SqlConnection gcnMain = new SqlConnection(connstring))
        //    {
        //        if (gcnMain.State == ConnectionState.Open)
        //        {
        //            gcnMain.Close();
        //        }
        //        gcnMain.Open();

        //        SqlCommand cmdInsert = new SqlCommand();
        //        SqlTransaction myTrans;
        //        myTrans = gcnMain.BeginTransaction();
        //        cmdInsert.Connection = gcnMain;
        //        cmdInsert.Transaction = myTrans;

        //        List<PCollectionCopmarison> ooLed = new List<PCollectionCopmarison>();
        //        if (intmode == 0)
        //        {
        //            strSQL = "DELETE FROM PROJECTION_TEMP ";
        //            cmdInsert.CommandText = strSQL;
        //            cmdInsert.ExecuteNonQuery();
        //        }


        //        //////Total Projection  This Month ////////////    
        //        if (strProjectionName == "01st")
        //        {
        //            strThisMonthNamee = "01This Month";
        //            strSQL = "SELECT min(PROJECTION_START_DATE) as MinStartdate , max(PROJECTION_END_DATE ) as maxEndDate ";
        //            strSQL = strSQL + "FROM  PROJECTION_SETUP ";
        //            //strSQL = strSQL + "WHERE  (MONTH_ID = '" + strFromMonthID + "') ";
        //            strSQL = strSQL + " WHERE  PROJECTION_NAME IN('" + strProjectionName + "') ";
        //            cmdInsert.CommandText = strSQL;
        //            dr = cmdInsert.ExecuteReader();
        //            while (dr.Read())
        //            {
        //                strFdate = Convert.ToDateTime(dr["MinStartdate"]).ToString("dd-MM-yyyy");
        //                strTdate = Convert.ToDateTime(dr["maxEndDate"]).ToString("dd-MM-yyyy");
        //            }
        //            dr.Close();

        //            strSQL = "select '" + strLedgerName + "','" + strProjectionName + "','" + strMonthName + "', sum( V.VOUCHER_CREDIT_AMOUNT) RecAmt  ";
        //            strSQL = strSQL + "from ACC_VOUCHER V  ";
        //            if (strLedgerName != "")
        //            {
        //                strSQL = strSQL + "where V.LEDGER_NAME ='" + strLedgerName + "'  ";
        //            }
        //            if (strFdate != "")
        //            {
        //                strSQL = strSQL + "and (V.COMP_VOUCHER_DATE >= " + Utility.cvtSQLDateString(strFdate) + ") and (V.COMP_VOUCHER_DATE <= " + Utility.cvtSQLDateString(strTdate) + ")  ";
        //            }

        //            strSQL = strSQL + "and V.COMP_VOUCHER_TYPE=1 and V.VOUCHER_TOBY='Cr' Group by V.LEDGER_NAME  ";

        //            cmdInsert.CommandText = strSQL;
        //            dr = cmdInsert.ExecuteReader();
        //            if (dr.Read())
        //            {

        //                strLedger = strLedgerName;
        //                strProjectionN = strProjectionName;
        //                dblThisMonthAmt = Convert.ToDouble(dr["RecAmt"].ToString());

        //            }
        //            else
        //            {
        //                strLedger = strLedgerName;
        //                strProjectionN = strProjectionName;
        //                dblThisMonthAmt = 0;
        //            }

        //            dr.Close();

                    
        //            strSQL = "INSERT INTO PROJECTION_TEMP(LEDGER_NAME, PROJECTION_NAME, MONTH_NAME, AMOUNT) ";
        //            strSQL = strSQL + "(Select '" + strLedger + "','99-Total Projection','" + strThisMonthNamee + "', " + dblThisMonthAmt + ")  ";
        //            cmdInsert.CommandText = strSQL;
        //            cmdInsert.ExecuteNonQuery();
        //        }

        //        //////End ////////////   
        //        //////Total Projection  Last Month ////////////    
        //        if (strProjectionName == "01st")
        //        {
        //            strThisMonthNamee = "02Last Month";
        //            strSQL = "SELECT min(PROJECTION_START_DATE) as MinStartdate , max(PROJECTION_END_DATE ) as maxEndDate ";
        //            strSQL = strSQL + "FROM  PROJECTION_SETUP ";
        //            strSQL = strSQL + " WHERE  PROJECTION_NAME IN('" + strProjectionName + "') ";
        //            cmdInsert.CommandText = strSQL;
        //            dr = cmdInsert.ExecuteReader();

        //            while (dr.Read())
        //            {
        //                strFdate = "";
        //                strTdate = "";

        //                if (dr["MinStartdate"].ToString() != "")
        //                {
        //                    strFdate = Convert.ToDateTime(dr["MinStartdate"]).ToString("dd-MM-yyyy");
        //                }
        //                if (dr["maxEndDate"].ToString() != "")
        //                {
        //                    strTdate = Convert.ToDateTime(dr["maxEndDate"]).ToString("dd-MM-yyyy");
        //                }
        //            }
        //            dr.Close();

        //            if (strFdate != "")
        //            {
        //                strSQL = "select '" + strLedgerName + "','" + strProjectionName + "','" + strMonthName + "', sum( V.VOUCHER_CREDIT_AMOUNT) RecAmt  ";
        //                strSQL = strSQL + "from ACC_VOUCHER V  ";
        //                if (strLedgerName != "")
        //                {
        //                    strSQL = strSQL + "where V.LEDGER_NAME ='" + strLedgerName + "'  ";
        //                }

        //                strSQL = strSQL + "and (V.COMP_VOUCHER_DATE >= " + Utility.cvtSQLDateString(strFdate) + ") and (V.COMP_VOUCHER_DATE <= " + Utility.cvtSQLDateString(strTdate) + ")  ";


        //                strSQL = strSQL + "and V.COMP_VOUCHER_TYPE=1 and V.VOUCHER_TOBY='Cr' Group by V.LEDGER_NAME  ";


        //                cmdInsert.CommandText = strSQL;
        //                dr = cmdInsert.ExecuteReader();
        //                if (dr.Read())
        //                {

        //                    strLedger = strLedgerName;
        //                    strProjectionN = strProjectionName;
        //                    dblThisMonthAmt = Convert.ToDouble(dr["RecAmt"].ToString());

        //                }
        //            }
        //            else
        //            {
        //                strLedger = strLedgerName;
        //                strProjectionN = strProjectionName;
        //                dblThisMonthAmt = 0;
        //            }

        //            dr.Close();


        //            strSQL = "INSERT INTO PROJECTION_TEMP(LEDGER_NAME, PROJECTION_NAME, MONTH_NAME, AMOUNT) ";
        //            strSQL = strSQL + "(Select '" + strLedger + "','99-Total Projection','" + strThisMonthNamee + "', " + dblThisMonthAmt + ")  ";
        //            cmdInsert.CommandText = strSQL;
        //            cmdInsert.ExecuteNonQuery();
        //        }

        //        //////End ////////////   

        //        //////This Month////////////    

        //        strThisMonthNamee = "01This Month";
        //        strSQL = "SELECT MONTH_ID, PROJECTION_NAME ,PROJECTION_START_DATE, PROJECTION_END_DATE ";
        //        strSQL = strSQL + "FROM  PROJECTION_SETUP ";
        //        strSQL = strSQL + "WHERE  (MONTH_ID = '" + strFromMonthID + "') AND PROJECTION_NAME='" + strProjectionName + "'";
        //        cmdInsert.CommandText = strSQL;
        //        dr = cmdInsert.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            strFdate = Convert.ToDateTime(dr["PROJECTION_START_DATE"]).ToString("dd-MM-yyyy");
        //            strTdate = Convert.ToDateTime(dr["PROJECTION_END_DATE"]).ToString("dd-MM-yyyy");
        //        }
        //        dr.Close();

        //        strSQL = "select '" + strLedgerName + "','" + strProjectionName + "','" + strMonthName + "', sum( V.VOUCHER_CREDIT_AMOUNT) RecAmt  ";
        //        strSQL = strSQL + "from ACC_VOUCHER V  ";
        //        if (strLedgerName != "")
        //        {
        //            strSQL = strSQL + "where V.LEDGER_NAME ='" + strLedgerName + "'  ";
        //        }
        //        if (strFdate != "")
        //        {
        //            strSQL = strSQL + "and (V.COMP_VOUCHER_DATE >= " + Utility.cvtSQLDateString(strFdate) + ") and (V.COMP_VOUCHER_DATE <= " + Utility.cvtSQLDateString(strTdate) + ")  ";
        //        }

        //        strSQL = strSQL + "and V.COMP_VOUCHER_TYPE=1 and V.VOUCHER_TOBY='Cr' Group by V.LEDGER_NAME  ";

        //        cmdInsert.CommandText = strSQL;
        //        dr = cmdInsert.ExecuteReader();
        //        if (dr.Read())
        //        {

        //            strLedger = strLedgerName;
        //            strProjectionN = strProjectionName;
        //            dblThisMonthAmt = Convert.ToDouble(dr["RecAmt"].ToString());

        //        }
        //        else
        //        {
        //            strLedger = strLedgerName;
        //            strProjectionN = strProjectionName;
        //            dblThisMonthAmt = 0;
        //        }

        //        dr.Close();


        //        strSQL = "INSERT INTO PROJECTION_TEMP(LEDGER_NAME, PROJECTION_NAME, MONTH_NAME, AMOUNT) ";
        //        strSQL = strSQL + "(Select '" + strLedger + "','" + strProjectionN + "','" + strProjectionName + "', " + dblThisMonthAmt + ")  ";
        //        cmdInsert.CommandText = strSQL;
        //        cmdInsert.ExecuteNonQuery();


        //        //////End This Month////////////   



        //        //////Last Month//////////// 


        //        strLastMonthName = "02Last Month";
        //        strSQL = "SELECT MONTH_ID, PROJECTION_NAME ,PROJECTION_START_DATE, PROJECTION_END_DATE ";
        //        strSQL = strSQL + "FROM  PROJECTION_SETUP ";
        //        strSQL = strSQL + "WHERE  (MONTH_ID = '" + strEndMonthID + "') AND PROJECTION_NAME='" + strProjectionName + "'";
        //        cmdInsert.CommandText = strSQL;
        //        dr = cmdInsert.ExecuteReader();

        //        while (dr.Read())
        //        {
        //            strLastFdate = Convert.ToDateTime(dr["PROJECTION_START_DATE"]).ToString("dd-MM-yyyy");
        //            strLastTdate = Convert.ToDateTime(dr["PROJECTION_END_DATE"]).ToString("dd-MM-yyyy");
        //        }
        //        dr.Close();
        //        if (strLastFdate != "")
        //        {
        //            strSQL = "select '" + strLedgerName + "','" + strProjectionName + "','" + strMonthName + "', sum( V.VOUCHER_CREDIT_AMOUNT) RecAmt  ";
        //            strSQL = strSQL + "from ACC_VOUCHER V  ";
        //            if (strLedgerName != "")
        //            {
        //                strSQL = strSQL + "where V.LEDGER_NAME ='" + strLedgerName + "'  ";
        //            }
        //            if (strFdate != "")
        //            {
        //                strSQL = strSQL + "AND (V.COMP_VOUCHER_DATE >= " + Utility.cvtSQLDateString(strLastFdate) + ") and (V.COMP_VOUCHER_DATE <= " + Utility.cvtSQLDateString(strLastTdate) + ")  ";
        //            }

        //            strSQL = strSQL + "and V.COMP_VOUCHER_TYPE=1 and V.VOUCHER_TOBY='Cr' Group by V.LEDGER_NAME  ";

        //            cmdInsert.CommandText = strSQL;
        //            dr = cmdInsert.ExecuteReader();
        //            if (dr.Read())
        //            {

        //                strLedger = strLedgerName;
        //                strProjectionN = strProjectionName;
        //                dblLastMonthAmt = Convert.ToDouble(dr["RecAmt"].ToString());

        //            }
        //            else
        //            {
        //                strLedger = strLedgerName;
        //                strProjectionN = strProjectionName;
        //                dblLastMonthAmt = 0;
        //            }

        //            dr.Close();
        //        }
        //        else
        //        {
        //            strLedger = strLedgerName;
        //            strProjectionN = strProjectionName;
        //            dblLastMonthAmt = 0;

        //        }


        //        strSQL = "INSERT INTO PROJECTION_TEMP(LEDGER_NAME, PROJECTION_NAME, MONTH_NAME, AMOUNT) ";
        //        strSQL = strSQL + "(Select '" + strLedger + "','" + strProjectionN + "','" + strLastMonthName + "', " + dblLastMonthAmt + ")  ";
        //        cmdInsert.CommandText = strSQL;
        //        cmdInsert.ExecuteNonQuery();


        //        dblGAPcal = dblThisMonthAmt - dblLastMonthAmt;
        //        strSQL = "INSERT INTO PROJECTION_TEMP(LEDGER_NAME, PROJECTION_NAME, MONTH_NAME, AMOUNT) ";
        //        strSQL = strSQL + "(Select '" + strLedger + "','" + strProjectionN + "','03Growth', " + dblGAPcal + ")  ";
        //        cmdInsert.CommandText = strSQL;
        //        cmdInsert.ExecuteNonQuery();
        //        if (dblThisMonthAmt != 0)
        //        {
        //            if (dblLastMonthAmt != 0)
        //            {
        //                dblGrowthPer = ((dblThisMonthAmt - dblLastMonthAmt) / dblLastMonthAmt) * 100;
        //            }
        //            else
        //            {
        //                dblGrowthPer = 0;
        //            }
        //        }
        //        else
        //        {
        //            dblGrowthPer = 0;
        //        }
        //        strSQL = "INSERT INTO PROJECTION_TEMP(LEDGER_NAME, PROJECTION_NAME, MONTH_NAME, AMOUNT) ";
        //        strSQL = strSQL + "(Select '" + strLedger + "','" + strProjectionN + "','04Growth(%)', " + dblGrowthPer + ")  ";
        //        cmdInsert.CommandText = strSQL;
        //        cmdInsert.ExecuteNonQuery();

        //        cmdInsert.Transaction.Commit();
        //        //////End Last Month////////////   

        //        return ooLed;

        //    }
        //}
        public List<PCollectionCopmarison> mGetMontlyLadger(string strDeComID, string strThisMonth, string strledger)
        {
            string strSQL = null;
            int intMode = 0;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlDataReader dr;
                if (strledger != "")
                {
                    if (Utility.Left(strledger, 2).ToUpper() == "DS" || Utility.Left(strledger, 2).ToUpper() == "RS")
                    {
                        intMode = 2;
                    }
                    else if (Utility.Left(strledger, 2).ToUpper() == "AM" || Utility.Left(strledger, 2).ToUpper() == "FM" || Utility.Left(strledger, 2).ToUpper() == "AH")
                    {
                        intMode = 5;
                    }

                    else if (strledger.Contains("ZONE") == true)
                    {
                        intMode = 4;
                    }
                    else if (strledger == "Sundry Debtors")
                    {
                        intMode = 0;
                    }
                    else
                    {
                        intMode = 6;
                    }
                }


                List<PCollectionCopmarison> oooChequePrint = new List<PCollectionCopmarison>();

                strSQL = "select distinct v.LEDGER_NAME  from ACC_VOUCHER V ,  ACC_LEDGER_Z_D_A L ";
                strSQL = strSQL + " where V.LEDGER_NAME= L.LEDGER_NAME   and format( V.COMP_VOUCHER_DATE,'MMMyy')='" + strThisMonth + "'  ";
                strSQL = strSQL + "and V.COMP_VOUCHER_TYPE=1 and V.VOUCHER_TOBY='Cr' ";

                if (strledger != "")
                {
                    if (intMode == 2)
                    {
                        strSQL = strSQL + "AND (L.DIVISION  = '" + strledger + "') ";
                    }
                    else if (intMode == 1)
                    {
                        //strSQL = strSQL + "AND (ACC_LEDGER.LEDGER_PARENT_GROUP = '" + strledger + "') ";
                    }
                    else if (intMode == 5)
                    {
                        strSQL = strSQL + "AND (L.AREA  = '" + strledger + "') ";
                    }
                    else if (intMode == 6)
                    {
                        strSQL = strSQL + "AND (V.LEDGER_NAME   = '" + strledger + "') ";
                    }
                    else if (intMode == 3)
                    {
                        strSQL = strSQL + "AND (V.LEDGER_NAME   = '" + strledger + "') ";
                    }
                    else if (intMode == 4)
                    {

                        strSQL = strSQL + "AND (L.ZONE = '" + strledger + "') ";
                    }

                    //strSQL = strSQL + "AND (ACC_LEDGER_Z_D_A.GR_NAME = '" + strString + "') ";
                }
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    PCollectionCopmarison ogrp = new PCollectionCopmarison();
                    ogrp.strLedgerName = dr["LEDGER_NAME"].ToString();
                    oooChequePrint.Add(ogrp);
                }

                if (!dr.HasRows)
                {
                    PCollectionCopmarison oLedg = new PCollectionCopmarison();
                    oLedg.strstrDate = "";
                    oLedg.strEndDate = "";
                    oooChequePrint.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return oooChequePrint;
            }
        }

        public List<PCollectionCopmarison> mGetCollectionComparision(string strDeComID, string strThisMonth, string strLastMont, string vstrUserName, int IntMode)
        {
            string strSQL = null;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlDataReader dr;

                List<PCollectionCopmarison> oooChequePrint = new List<PCollectionCopmarison>();
                if (IntMode == 1)
                {
                    strSQL = "SELECT T.PROJECTION_NAME, T.MONTH_NAME, sum(T.AMOUNT) as AMOUNT ,V.ZONE FROM   ";
                    strSQL = strSQL + "PROJECTION_TEMP T , ACC_LEDGER_Z_D_A V where T.LEDGER_NAME= V.LEDGER_NAME AND V.DIVISION in ";
                    strSQL = strSQL + "( select LEDGER_GROUP_NAME from USER_PRIVILEGES_COLOR WHERE USER_LOGIN_NAME ='" + vstrUserName + "')  ";
                    strSQL = strSQL + "GROUP By T.PROJECTION_NAME, T.MONTH_NAME,V.ZONE ";
                }

                else if (IntMode == 2)
                {
                    strSQL = "SELECT T.PROJECTION_NAME,V.DIVISION, T.MONTH_NAME, sum(T.AMOUNT) as AMOUNT ,V.ZONE FROM   ";
                    strSQL = strSQL + "PROJECTION_TEMP T , ACC_LEDGER_Z_D_A V where T.LEDGER_NAME= V.LEDGER_NAME AND V.DIVISION in ";
                    strSQL = strSQL + "( select LEDGER_GROUP_NAME from USER_PRIVILEGES_COLOR WHERE USER_LOGIN_NAME ='" + vstrUserName + "')  ";
                    strSQL = strSQL + "GROUP By T.PROJECTION_NAME,V.DIVISION, T.MONTH_NAME,V.ZONE ";
                }
                else if (IntMode == 3)
                {
                    strSQL = "SELECT  T.PROJECTION_NAME, T.MONTH_NAME, T.AMOUNT ,V.AREA,V.DIVISION,V.ZONE ";
                    strSQL = strSQL + "FROM  PROJECTION_TEMP T , ACC_LEDGER_Z_D_A V ";
                    strSQL = strSQL + "where T.LEDGER_NAME= V.LEDGER_NAME ";
                    strSQL = strSQL + "AND V.DIVISION in( select LEDGER_GROUP_NAME from USER_PRIVILEGES_COLOR WHERE USER_LOGIN_NAME ='" + vstrUserName + "') ";
                    strSQL = strSQL + "Order by T.PROJECTION_NAME,T.MONTH_NAME  ";
                }
                else
                {
                    strSQL = "SELECT V.LEDGER_NAME_MERZE, T.PROJECTION_NAME, T.MONTH_NAME, T.AMOUNT ,V.AREA,V.DIVISION,V.ZONE ";
                    strSQL = strSQL + "FROM  PROJECTION_TEMP T , ACC_LEDGER_Z_D_A V ";
                    strSQL = strSQL + "where T.LEDGER_NAME= V.LEDGER_NAME ";
                    strSQL = strSQL + "AND V.DIVISION in( select LEDGER_GROUP_NAME from USER_PRIVILEGES_COLOR WHERE USER_LOGIN_NAME ='" + vstrUserName + "') ";
                    strSQL = strSQL + "Order by T.LEDGER_NAME,T.PROJECTION_NAME,T.MONTH_NAME  ";
                }


                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (IntMode == 1)
                    {

                        PCollectionCopmarison ogrp = new PCollectionCopmarison();
                        ogrp.strZone = dr["ZONE"].ToString();
                        ogrp.strProjectionName = dr["PROJECTION_NAME"].ToString();
                        ogrp.strMonthNamee = dr["MONTH_NAME"].ToString();
                        ogrp.dblAmount = Convert.ToDouble(dr["AMOUNT"].ToString());
                        oooChequePrint.Add(ogrp);
                    }
                    else if (IntMode == 2)
                    {
                        PCollectionCopmarison ogrp = new PCollectionCopmarison();
                        ogrp.strZone = dr["ZONE"].ToString();
                        ogrp.strDivision = dr["DIVISION"].ToString();
                        ogrp.strProjectionName = dr["PROJECTION_NAME"].ToString();
                        ogrp.strMonthNamee = dr["MONTH_NAME"].ToString();
                        ogrp.dblAmount = Convert.ToDouble(dr["AMOUNT"].ToString());
                        oooChequePrint.Add(ogrp);
                    }
                    else if (IntMode == 3)
                    {
                        PCollectionCopmarison ogrp = new PCollectionCopmarison();
                        ogrp.strZone = dr["ZONE"].ToString();
                        ogrp.strDivision = dr["DIVISION"].ToString();
                        ogrp.strArea = dr["AREA"].ToString();
                        ogrp.strProjectionName = dr["PROJECTION_NAME"].ToString();
                        ogrp.strMonthNamee = dr["MONTH_NAME"].ToString();
                        ogrp.dblAmount = Convert.ToDouble(dr["AMOUNT"].ToString());
                        oooChequePrint.Add(ogrp);
                    }
                    else
                    {
                        PCollectionCopmarison ogrp = new PCollectionCopmarison();
                        ogrp.strZone = dr["ZONE"].ToString();
                        ogrp.strDivision = dr["DIVISION"].ToString();
                        ogrp.strArea = dr["AREA"].ToString();
                        ogrp.strLedgerName = dr["LEDGER_NAME_MERZE"].ToString();
                        ogrp.strProjectionName = dr["PROJECTION_NAME"].ToString();
                        ogrp.strMonthNamee = dr["MONTH_NAME"].ToString();
                        ogrp.dblAmount = Convert.ToDouble(dr["AMOUNT"].ToString());
                        oooChequePrint.Add(ogrp);
                    }

                }

                if (!dr.HasRows)
                {
                    PCollectionCopmarison oLedg = new PCollectionCopmarison();
                    oLedg.strstrDate = "";
                    oLedg.strEndDate = "";
                    oooChequePrint.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return oooChequePrint;
            }
        }

        #endregion
        #region "Monthly Projection"
        public string mDeleteMonthlyProjection(string strDeComID, string strKey, string strDivision)
        {
            string strSQL;
            int intmode = 1;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();


                SqlDataReader DR;
                SqlCommand cmdInsert = new SqlCommand();
                SqlTransaction myTrans;
                myTrans = gcnMain.BeginTransaction();
                cmdInsert.Connection = gcnMain;
                cmdInsert.Transaction = myTrans;



                strSQL = "DELETE FROM PRO_MONTHLY_PROJECTION_CHILD ";
                strSQL = strSQL + " WHERE ";
                strSQL = strSQL + "  MONTHLY_PROJECTION_KEY ='" + strKey.Replace("'", "''") + "' ";
                //strSQL = strSQL + "AND  DIVISION_NAME ='" + strDivision.Replace("'", "''") + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                cmdInsert.Transaction.Commit();
                gcnMain.Dispose();
                return "1";

            }
        }
        public string mInsertMonthlyProjection(string strDeComID, string strKey, string strMonthID, string strDivision, string strArea, string strLedgerName,
                                                    string strHeadName, double dblAmount, int intDel, int intCols, int intRow)
        {
            string strSQL;

            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();


                SqlDataReader DR;
                SqlCommand cmdInsert = new SqlCommand();
                SqlTransaction myTrans;
                myTrans = gcnMain.BeginTransaction();
                cmdInsert.Connection = gcnMain;
                cmdInsert.Transaction = myTrans;
                if (intDel == 1)
                {
                    strSQL = "DELETE FROM PRO_MONTHLY_PROJECTION_CHILD ";
                    strSQL = strSQL + " WHERE ";
                    strSQL = strSQL + " MONTHLY_PROJECTION_KEY ='" + strKey.Replace("'", "''") + "' ";
                    //strSQL = strSQL + "AND  DIVISION_NAME ='" + strDivision.Replace("'", "''") + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                }
                strSQL = "INSERT INTO PRO_MONTHLY_PROJECTION_CHILD(MONTH_ID,MONTHLY_PROJECTION_KEY, ";
                if (strLedgerName != "")
                {
                    strSQL = strSQL + "LEDGER_NAME,";
                }
                strSQL=strSQL +"PROJECTION_NAME,AMOUNT,COLS,ROWPOS)";
                strSQL = strSQL + "VALUES(";
                //strSQL = strSQL + "'" + strDivision.Replace("'", "''") + "' ";
                strSQL = strSQL + "'" + strMonthID.Replace("'", "''") + "' ";
                strSQL = strSQL + ",'" + strKey.Replace("'", "''") + "' ";
                //strSQL = strSQL + ",'" + strArea.Replace("'", "''") + "' ";
                if (strLedgerName != "")
                {
                    strSQL = strSQL + ",'" + strLedgerName.Replace("'", "''") + "' ";
                }
                strSQL = strSQL + ",'" + strHeadName.Replace("'", "''") + "' ";
                strSQL = strSQL + "," + dblAmount + " ";
                strSQL = strSQL + "," + intCols + " ";
                strSQL = strSQL + "," + intRow + " ";
                strSQL = strSQL + ")";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                cmdInsert.Transaction.Commit();
                gcnMain.Dispose();
                return "1";

            }
        }
        public List<ProjectionSet> mFillMonthlyProjection(string strDeComID, string strProjectionMonth)
        {

            string strSQL = null;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            SqlDataReader dr;
            List<ProjectionSet> ooVector = new List<ProjectionSet>();
            strSQL = "select  P.PROJECTION_NAME from  PROJECTION_SETUP P  ";
            if (strProjectionMonth != "")
            {
                strSQL = strSQL + " WHERE P.MONTH_ID='" + strProjectionMonth + "' ";
            }
            strSQL = strSQL + "Order by  P.PROJECTION_NAME ";
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    ProjectionSet ovector = new ProjectionSet();
                    ovector.strProjectionName = dr["PROJECTION_NAME"].ToString();
                    ooVector.Add(ovector);
                }
                return ooVector;
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
            }

        }

        public List<ProjectionSet> mFillMonthlyProjectionLedger(string strDeComID, string strLedgerGroup, string strMonthID, int intmode)
        {

            string strSQL = null;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            SqlDataReader dr;
            List<ProjectionSet> ooVector = new List<ProjectionSet>();
            if (intmode == 1)
            {

                strSQL = "SELECT  distinct V.AREA as AREA_NAME,V.LEDGER_NAME,V.LEDGER_NAME_MERZE  FROM PRO_MONTHLY_PROJECTION_CHILD M , ACC_LEDGER_Z_D_A V ";
                strSQL = strSQL + "WHERE M.LEDGER_NAME=V.LEDGER_NAME ";

                if (strLedgerGroup != "")
                {
                    strSQL = strSQL + "AND  V.DIVISION='" + strLedgerGroup + "' ";
                }
                if (strMonthID != "")
                {
                    strSQL = strSQL + "AND  M.MONTH_ID='" + strMonthID + "' ";
                }
                strSQL = strSQL + "order by V.AREA ,v.LEDGER_NAME_MERZE   ";

            }
            else
            {
                strSQL = "Select distinct V.AREA as AREA_NAME,V.LEDGER_NAME, L.LEDGER_NAME_MERZE FROM  ACC_LEDGER_Z_D_A V, ACC_LEDGER L  ";
                strSQL = strSQL + "WHERE V.LEDGER_NAME= L.LEDGER_NAME AND L.LEDGER_STATUS=0  ";
                if (strLedgerGroup != "")
                {
                    strSQL = strSQL + "AND V.DIVISION='" + strLedgerGroup + "' ";
                }
                strSQL = strSQL + "order by V.AREA ,L.LEDGER_NAME_MERZE   ";

            }
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    ProjectionSet ovector = new ProjectionSet();
                    ovector.strAMFM = dr["AREA_NAME"].ToString();
                    ovector.strMpoName = dr["LEDGER_NAME"].ToString();
                    if (dr["LEDGER_NAME_MERZE"].ToString() != "")
                    {
                        ovector.strMerzeName = dr["LEDGER_NAME_MERZE"].ToString();
                    }
                    else
                    {
                        ovector.strMerzeName = "";
                    }
                   
                    ooVector.Add(ovector);
                }
                return ooVector;
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
            }

        }
        public List<ProjectionSet> mFillMonthlyProjectionValue(string strDeComID, string strMonthID, string strLedgerName,string strProjectionName)
        {

            string strSQL = null;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            SqlDataReader dr;
            List<ProjectionSet> ooVector = new List<ProjectionSet>();
           
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                strSQL = "SELECT   PROJECTION_NAME,AMOUNT,COLS,ROWPOS FROM PRO_MONTHLY_PROJECTION_CHILD ";
                strSQL = strSQL + "WHERE MONTH_ID='" + strMonthID + "' ";
                strSQL = strSQL + "AND  LEDGER_NAME='" + strLedgerName  + "' ";
                strSQL = strSQL + "AND  PROJECTION_NAME='" + strProjectionName + "' ";

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    ProjectionSet ovector = new ProjectionSet();
                    ovector.strProjectionName = dr["PROJECTION_NAME"].ToString();
                    ovector.intCol = Convert.ToInt32 (dr["COLS"].ToString());
                    ovector.intRow = Convert.ToInt32 (dr["ROWPOS"].ToString());
                    ovector.dblToAmt = Convert.ToDouble(dr["AMOUNT"].ToString());
                    ooVector.Add(ovector);
                }
                return ooVector;
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
            }

        }
        public List<ProjectionSet> mFillMonthlyProjectionList(string strDeComID, string VstruserName)
        {

            string strSQL = null,strMonthID="";
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            SqlDataReader dr;
           
           
            List<ProjectionSet> ooVector = new List<ProjectionSet>();

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = gcnMain;
                
                strSQL = "SELECT MONTH_ID  from PRO_MONTH_CONFIG WHERE STATUS =1 ";
                cmd.CommandText = strSQL;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strMonthID = dr["MONTH_ID"].ToString();
                }
                dr.Close();
                strSQL = "SELECT DISTINCT PRO_MONTHLY_PROJECTION_CHILD.MONTHLY_PROJECTION_KEY,  ACC_LEDGER_Z_D_A.DIVISION ,PRO_MONTHLY_PROJECTION_CHILD.MONTH_ID ";
                strSQL = strSQL + "FROM PRO_MONTHLY_PROJECTION_CHILD,ACC_LEDGER_Z_D_A WHERE PRO_MONTHLY_PROJECTION_CHILD.LEDGER_NAME =ACC_LEDGER_Z_D_A.LEDGER_NAME  ";
                strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.DIVISION in( select LEDGER_GROUP_NAME from USER_PRIVILEGES_COLOR WHERE USER_LOGIN_NAME ='" + VstruserName + "') ";
                strSQL = strSQL + "AND PRO_MONTHLY_PROJECTION_CHILD.MONTH_ID='" + strMonthID + "' ";
                strSQL = strSQL + "ORDER BY PRO_MONTHLY_PROJECTION_CHILD.MONTH_ID ";
                cmd.CommandText = strSQL;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    ProjectionSet ovector = new ProjectionSet();
                    ovector.strProjectionKey = dr["MONTHLY_PROJECTION_KEY"].ToString();
                    ovector.strMonthID = dr["MONTH_ID"].ToString();
                    ovector.strDivision = dr["DIVISION"].ToString();
                    ooVector.Add(ovector);
                }
                return ooVector;
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
            }

        }
        public List<ProjectionSet> mFillDisplayLedgerName(string strDeComID, string strKey, string strDivision)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<ProjectionSet> ooLed = new List<ProjectionSet>();
            strSQL = "SELECT DISTINCT  ACC_LEDGER_Z_D_A.AREA, PRO_MONTHLY_PROJECTION_CHILD.LEDGER_NAME,PRO_MONTHLY_PROJECTION_CHILD.MONTH_ID ";
            strSQL = strSQL + ",ACC_LEDGER_Z_D_A.LEDGER_NAME_MERZE FROM PRO_MONTHLY_PROJECTION_CHILD ,ACC_LEDGER_Z_D_A ";
            strSQL = strSQL + " WHERE PRO_MONTHLY_PROJECTION_CHILD.LEDGER_NAME =ACC_LEDGER_Z_D_A.LEDGER_NAME  ";
            strSQL = strSQL + "and PRO_MONTHLY_PROJECTION_CHILD.MONTHLY_PROJECTION_KEY ='" + strKey + "' ";
            strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.DIVISION ='" + strDivision + "' ";
            strSQL = strSQL + "ORDER BY ACC_LEDGER_Z_D_A.AREA, ACC_LEDGER_Z_D_A.LEDGER_NAME_MERZE ASC ";

            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                drGetGroup = cmd.ExecuteReader();
                while (drGetGroup.Read())
                {
                    ProjectionSet ogrp = new ProjectionSet();
                    //ogrp.strDivision = drGetGroup["AREA"].ToString();
                    ogrp.strMonthID = drGetGroup["MONTH_ID"].ToString();
                    ogrp.strAMFM = drGetGroup["AREA"].ToString();
                    ogrp.strMpoName = drGetGroup["LEDGER_NAME"].ToString();
                    ogrp.strMerzeName = drGetGroup["LEDGER_NAME_MERZE"].ToString();
                    ooLed.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return ooLed;

            }
        }

        public List<ProjectionSet> mFillDisplayMonthlyProjection(string strDeComID, string strMonthID, string strDivision,string strprojectionKey)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<ProjectionSet> ooLed = new List<ProjectionSet>();

            strSQL = "SELECT PRO_MONTHLY_PROJECTION_CHILD.MONTHLY_PROJECTION_KEY, PRO_MONTHLY_PROJECTION_CHILD.MONTH_ID, ACC_LEDGER_Z_D_A.AREA,ACC_LEDGER_Z_D_A.LEDGER_NAME_MERZE, PRO_MONTHLY_PROJECTION_CHILD.LEDGER_NAME,";
            strSQL = strSQL + "PRO_MONTHLY_PROJECTION_CHILD.PROJECTION_NAME, PRO_MONTHLY_PROJECTION_CHILD.AMOUNT, PRO_MONTHLY_PROJECTION_CHILD.COLS, PRO_MONTHLY_PROJECTION_CHILD.ROWPOS ";
            strSQL = strSQL + "FROM PRO_MONTHLY_PROJECTION_CHILD,ACC_LEDGER_Z_D_A  ";
            strSQL = strSQL + "WHERE PRO_MONTHLY_PROJECTION_CHILD.LEDGER_NAME =ACC_LEDGER_Z_D_A.LEDGER_NAME  ";
            strSQL = strSQL + "AND PRO_MONTHLY_PROJECTION_CHILD.MONTH_ID ='" + strMonthID + "' ";
            //strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.DIVISION ='" + strDivision + "'";
            strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.LEDGER_NAME ='" + strDivision + "' ";
            strSQL = strSQL + "and PRO_MONTHLY_PROJECTION_CHILD.MONTHLY_PROJECTION_KEY ='" + strprojectionKey + "' ";
            strSQL = strSQL + "ORDER BY PRO_MONTHLY_PROJECTION_CHILD.ROWPOS,ACC_LEDGER_Z_D_A.AREA, PRO_MONTHLY_PROJECTION_CHILD.LEDGER_NAME ASC  ";

            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                drGetGroup = cmd.ExecuteReader();
                while (drGetGroup.Read())
                {
                    ProjectionSet ogrp = new ProjectionSet();
                    ogrp.strProjectionKey = drGetGroup["MONTHLY_PROJECTION_KEY"].ToString();
                    ogrp.strMonthID = drGetGroup["MONTH_ID"].ToString();
                    ogrp.strAMFM = drGetGroup["AREA"].ToString();
                    ogrp.strMpoName = drGetGroup["LEDGER_NAME"].ToString();
                    ogrp.strMerzeName = drGetGroup["LEDGER_NAME_MERZE"].ToString();
                    ogrp.strProjectionName = drGetGroup["PROJECTION_NAME"].ToString();
                    ogrp.dblToAmt = Convert.ToDouble(drGetGroup["AMOUNT"].ToString());
                    ogrp.intCol = Convert.ToInt32(drGetGroup["COLS"].ToString());
                    ogrp.intRow = Convert.ToInt32(drGetGroup["ROWPOS"].ToString());

                    ooLed.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return ooLed;

            }
        }

        #endregion
        #region "Weekly Projection"
        public List<ProjectionSet> mFillDisplayLedgerNameWeekly(string strDeComID, string strKey, string strDivision)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<ProjectionSet> ooLed = new List<ProjectionSet>();
            strSQL = "SELECT DISTINCT  ACC_LEDGER_Z_D_A.AREA, PRO_WEEKLY_PROJECTION.LEDGER_NAME,PRO_WEEKLY_PROJECTION.MONTH_ID ";
            strSQL = strSQL + ",ACC_LEDGER_Z_D_A.LEDGER_NAME_MERZE FROM PRO_WEEKLY_PROJECTION ,ACC_LEDGER_Z_D_A ";
            strSQL = strSQL + " WHERE PRO_WEEKLY_PROJECTION.LEDGER_NAME =ACC_LEDGER_Z_D_A.LEDGER_NAME  ";
            strSQL = strSQL + "and PRO_WEEKLY_PROJECTION.WEEKLY_PROJECTION_KEY ='" + strKey + "' ";
            strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.DIVISION ='" + strDivision + "' ";
            strSQL = strSQL + "ORDER BY ACC_LEDGER_Z_D_A.AREA, ACC_LEDGER_Z_D_A.LEDGER_NAME_MERZE ASC ";

            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                drGetGroup = cmd.ExecuteReader();
                while (drGetGroup.Read())
                {
                    ProjectionSet ogrp = new ProjectionSet();
                    //ogrp.strDivision = drGetGroup["AREA"].ToString();
                    ogrp.strMonthID = drGetGroup["MONTH_ID"].ToString();
                    ogrp.strAMFM = drGetGroup["AREA"].ToString();
                    ogrp.strMpoName = drGetGroup["LEDGER_NAME"].ToString();
                    ogrp.strMerzeName = drGetGroup["LEDGER_NAME_MERZE"].ToString();
                    ooLed.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return ooLed;

            }
        }

        public List<ProjectionSet> mFillWeeklyProjectionList(string strDeComID, string VstruserName)
        {

            string strSQL = null, strMonthID="";
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            SqlDataReader dr;
            List<ProjectionSet> ooVector = new List<ProjectionSet>();

           
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = gcnMain;
                gcnMain.Open();

                strSQL = "SELECT MONTH_ID  from PRO_MONTH_CONFIG WHERE STATUS =1 ";
                cmd.CommandText = strSQL;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strMonthID = dr["MONTH_ID"].ToString();
                }
                dr.Close();

                strSQL = "SELECT DISTINCT PRO_WEEKLY_PROJECTION.WEEKLY_PROJECTION_KEY,  ACC_LEDGER_Z_D_A.DIVISION ,PRO_WEEKLY_PROJECTION.MONTH_ID  ";
                strSQL = strSQL + "FROM PRO_WEEKLY_PROJECTION,ACC_LEDGER_Z_D_A WHERE PRO_WEEKLY_PROJECTION.LEDGER_NAME =ACC_LEDGER_Z_D_A.LEDGER_NAME   ";
                strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.DIVISION in( select LEDGER_GROUP_NAME from USER_PRIVILEGES_COLOR WHERE USER_LOGIN_NAME ='" + VstruserName + "') ";
                strSQL = strSQL + "AND PRO_WEEKLY_PROJECTION.MONTH_ID='" + strMonthID + "' ";
                strSQL = strSQL + "ORDER BY PRO_WEEKLY_PROJECTION.MONTH_ID  ";

                cmd.CommandText = strSQL;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    ProjectionSet ovector = new ProjectionSet();
                    ovector.strProjectionKey = dr["WEEKLY_PROJECTION_KEY"].ToString();
                    ovector.strMonthID = dr["MONTH_ID"].ToString();
                    ovector.strDivision = dr["DIVISION"].ToString();
                    ooVector.Add(ovector);
                }
                return ooVector;
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
            }

        }
        public string mInsertWeeklyProjectionSet(string strDeComID, string strKey, string strMonthID, string strDivision, string strArea, string strLedgerName,
                                            string strHeadName, double dblAmount, double dblWrittenAmount, int intDel, int intCols, int intRow, string strCommProjectionName)
        {
            string strSQL;

            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();


                SqlDataReader DR;
                SqlCommand cmdInsert = new SqlCommand();
                SqlTransaction myTrans;
                myTrans = gcnMain.BeginTransaction();
                cmdInsert.Connection = gcnMain;
                cmdInsert.Transaction = myTrans;
                if (intDel == 1)
                {
                    strSQL = "DELETE FROM  PRO_WEEKLY_PROJECTION ";
                    strSQL = strSQL + " WHERE ";
                    strSQL = strSQL + " WEEKLY_PROJECTION_KEY ='" + strKey.Replace("'", "''") + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                }
                strSQL = "INSERT INTO  PRO_WEEKLY_PROJECTION(WEEKLY_PROJECTION_KEY,MONTH_ID, LEDGER_NAME, PROJECTION_NAME, AMOUNT, COLS, ROWPOS,COMM_PROJECTON_NAME)";
                strSQL = strSQL + "VALUES(";
                strSQL = strSQL + "'" + strKey.Replace("'", "''") + "' ";
                strSQL = strSQL + ",'" + strMonthID.Replace("'", "''") + "' ";
                strSQL = strSQL + ",'" + strLedgerName.Replace("'", "''") + "' ";
                strSQL = strSQL + ",'" + strHeadName.Replace("'", "''") + "' ";
                strSQL = strSQL + "," + dblAmount + " ";
                strSQL = strSQL + "," + intCols + " ";
                strSQL = strSQL + "," + intRow + " ";
                strSQL = strSQL + ",'" + strCommProjectionName.Replace("'", "''") + "' ";
                strSQL = strSQL + ")";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                cmdInsert.Transaction.Commit();
                gcnMain.Dispose();
                return "1";

            }
        }
        public string mDeleteWeeklyProjection(string strDeComID, string strKey)
        {
            string strSQL;
            int intmode = 1;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();


                SqlDataReader DR;
                SqlCommand cmdInsert = new SqlCommand();
                SqlTransaction myTrans;
                myTrans = gcnMain.BeginTransaction();
                cmdInsert.Connection = gcnMain;
                cmdInsert.Transaction = myTrans;



                strSQL = "DELETE FROM PRO_WEEKLY_PROJECTION ";
                strSQL = strSQL + " WHERE ";
                strSQL = strSQL + "  WEEKLY_PROJECTION_KEY ='" + strKey.Replace("'", "''") + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                cmdInsert.Transaction.Commit();
                gcnMain.Dispose();
                return "1";

            }
        }


        public List<ProjectionSet> mFillDisplayWeeklyProjection(string strDeComID, string strMonthID, string strDivision)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<ProjectionSet> ooLed = new List<ProjectionSet>();

            strSQL = "SELECT PRO_WEEKLY_PROJECTION.WEEKLY_PROJECTION_KEY, PRO_WEEKLY_PROJECTION.MONTH_ID, ACC_LEDGER_Z_D_A.AREA,ACC_LEDGER_Z_D_A.LEDGER_NAME_MERZE, PRO_WEEKLY_PROJECTION.LEDGER_NAME,";
            strSQL = strSQL + "PRO_WEEKLY_PROJECTION.PROJECTION_NAME, PRO_WEEKLY_PROJECTION.AMOUNT, PRO_WEEKLY_PROJECTION.COLS, PRO_WEEKLY_PROJECTION.ROWPOS ";
            strSQL = strSQL + "FROM PRO_WEEKLY_PROJECTION,ACC_LEDGER_Z_D_A  ";
            strSQL = strSQL + "WHERE PRO_WEEKLY_PROJECTION.LEDGER_NAME =ACC_LEDGER_Z_D_A.LEDGER_NAME  ";
            strSQL = strSQL + "AND PRO_WEEKLY_PROJECTION.MONTH_ID ='" + strMonthID + "' ";
            //strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.DIVISION ='" + strDivision + "'";
            strSQL = strSQL + "AND PRO_WEEKLY_PROJECTION.WEEKLY_PROJECTION_KEY ='" + strDivision + "'";
            strSQL = strSQL + "ORDER BY ACC_LEDGER_Z_D_A.AREA, ACC_LEDGER_Z_D_A.LEDGER_NAME_MERZE ASC  ";

            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                drGetGroup = cmd.ExecuteReader();
                while (drGetGroup.Read())
                {
                    ProjectionSet ogrp = new ProjectionSet();
                    ogrp.strProjectionKey = drGetGroup["WEEKLY_PROJECTION_KEY"].ToString();
                    ogrp.strMonthID = drGetGroup["MONTH_ID"].ToString();
                    ogrp.strAMFM = drGetGroup["AREA"].ToString();
                    ogrp.strMpoName = drGetGroup["LEDGER_NAME"].ToString();
                    ogrp.strMerzeName = drGetGroup["LEDGER_NAME_MERZE"].ToString();
                    ogrp.strProjectionName = drGetGroup["PROJECTION_NAME"].ToString();
                    ogrp.dblToAmt = Convert.ToDouble(drGetGroup["AMOUNT"].ToString());
                    ogrp.intCol = Convert.ToInt32(drGetGroup["COLS"].ToString());
                    ogrp.intRow = Convert.ToInt32(drGetGroup["ROWPOS"].ToString());

                    ooLed.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return ooLed;

            }
        }
        public List<ProjectionSet> mFillDisplayMonthlyProjectionchild(string strDeComID, string strMonthID, string strKey, string strLedgerName, string strProjection)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<ProjectionSet> ooLed = new List<ProjectionSet>();

            strSQL = "SELECT AMOUNT FROM PRO_MONTHLY_PROJECTION_CHILD ";
            strSQL = strSQL + "WHERE MONTHLY_PROJECTION_KEY='" + strKey.Replace("'","''") + "' ";
            strSQL = strSQL + "AND MONTH_ID ='" + strMonthID + "' ";
            strSQL = strSQL + "AND LEDGER_NAME ='" + strLedgerName + "'";
            strSQL = strSQL + "AND PROJECTION_NAME ='" + strProjection + "'";
            strSQL = strSQL + "ORDER BY LEDGER_NAME ASC  ";

            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                drGetGroup = cmd.ExecuteReader();
                while (drGetGroup.Read())
                {
                    ProjectionSet ogrp = new ProjectionSet();
                    ogrp.dblToAmt = Convert.ToDouble(drGetGroup["AMOUNT"].ToString());

                    ooLed.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return ooLed;

            }
        }

        #endregion
        #region "displayLedgerWeekly"
        public List<ProjectionSet> mFillDisplayLedgerNameWeeklyReport(string strDeComID, string strKey, string strDivision, int Intmode, string vstrUserName,string strZone)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<ProjectionSet> ooLed = new List<ProjectionSet>();
            if (Intmode == 1)
            {
                strSQL = "SELECT DISTINCT ";
                strSQL = strSQL + "ACC_LEDGER_Z_D_A.LEDGER_NAME_MERZE as Lname FROM PRO_WEEKLY_PROJECTION ,ACC_LEDGER_Z_D_A ";
                strSQL = strSQL + " WHERE PRO_WEEKLY_PROJECTION.LEDGER_NAME =ACC_LEDGER_Z_D_A.LEDGER_NAME  ";
                //strSQL = strSQL + "and PRO_WEEKLY_PROJECTION.WEEKLY_PROJECTION_KEY ='" + strKey + "' ";
                strSQL = strSQL + "and PRO_WEEKLY_PROJECTION.MONTH_ID='" + strKey + "'";
                //strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.DIVISION ='" + strDivision + "' ";
                strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.DIVISION in( select LEDGER_GROUP_NAME from USER_PRIVILEGES_COLOR WHERE USER_LOGIN_NAME ='" + vstrUserName + "') ";
                strSQL = strSQL + "ORDER BY  ACC_LEDGER_Z_D_A.LEDGER_NAME_MERZE ASC ";
            }
            else if (Intmode == 2)
            {
                strSQL = "SELECT DISTINCT  ACC_LEDGER_Z_D_A.AREA  as Lname ";
                strSQL = strSQL + "FROM PRO_WEEKLY_PROJECTION ,ACC_LEDGER_Z_D_A ";
                strSQL = strSQL + " WHERE PRO_WEEKLY_PROJECTION.LEDGER_NAME =ACC_LEDGER_Z_D_A.LEDGER_NAME  ";
                strSQL = strSQL + "and PRO_WEEKLY_PROJECTION.MONTH_ID='" + strKey + "'";
                strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.DIVISION in( select LEDGER_GROUP_NAME from USER_PRIVILEGES_COLOR WHERE USER_LOGIN_NAME ='" + vstrUserName + "') ";
                strSQL = strSQL + "ORDER BY ACC_LEDGER_Z_D_A.AREA ASC ";
            }
            else if (Intmode == 3)
            {
                strSQL = "SELECT DISTINCT  ACC_LEDGER_Z_D_A.DIVISION  as Lname ";
                strSQL = strSQL + "FROM PRO_WEEKLY_PROJECTION ,ACC_LEDGER_Z_D_A ";
                strSQL = strSQL + " WHERE PRO_WEEKLY_PROJECTION.LEDGER_NAME =ACC_LEDGER_Z_D_A.LEDGER_NAME  ";
                strSQL = strSQL + "and PRO_WEEKLY_PROJECTION.MONTH_ID='" + strKey + "'";
                if (strZone != "")
                {
                    strSQL = strSQL + "and ACC_LEDGER_Z_D_A.ZONE='" + strZone.Replace("'","''") + "'";
                }
                strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.DIVISION in( select LEDGER_GROUP_NAME from USER_PRIVILEGES_COLOR WHERE USER_LOGIN_NAME ='" + vstrUserName + "') ";
                strSQL = strSQL + "ORDER BY ACC_LEDGER_Z_D_A.DIVISION ASC ";
            }
            else
            {
                strSQL = "SELECT DISTINCT  ACC_LEDGER_Z_D_A.ZONE  as Lname ";
                strSQL = strSQL + "FROM PRO_WEEKLY_PROJECTION ,ACC_LEDGER_Z_D_A ";
                strSQL = strSQL + " WHERE PRO_WEEKLY_PROJECTION.LEDGER_NAME =ACC_LEDGER_Z_D_A.LEDGER_NAME  ";
                strSQL = strSQL + "and PRO_WEEKLY_PROJECTION.MONTH_ID='" + strKey + "'";
                strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.DIVISION in( select LEDGER_GROUP_NAME from USER_PRIVILEGES_COLOR WHERE USER_LOGIN_NAME ='" + vstrUserName + "') ";
                strSQL = strSQL + "ORDER BY ACC_LEDGER_Z_D_A.ZONE ASC ";
            }


            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                drGetGroup = cmd.ExecuteReader();
                while (drGetGroup.Read())
                {
                    ProjectionSet ogrp = new ProjectionSet();
                    ogrp.strMerzeName = drGetGroup["Lname"].ToString();
                    ooLed.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return ooLed;

            }
        }
        #endregion
        #region "Report Monthly Projection"
        public List<ProjectionSet> mrptFillDisplayMonthlyProjection(string strDeComID, string strMonthID, string strDivision, int intmode)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<ProjectionSet> ooLed = new List<ProjectionSet>();


            strSQL = "SELECT P.MONTHLY_PROJECTION_KEY, P.MONTH_ID, P.LEDGER_NAME,P.PROJECTION_NAME, V.ZONE,V.DIVISION, ";
            strSQL = strSQL + "V.AREA,V.LEDGER_NAME_MERZE, P.LEDGER_NAME,P.PROJECTION_NAME, ";
            strSQL = strSQL + "P.AMOUNT, P.COLS, P.ROWPOS ,  ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='01st'  then P.AMOUNT end )as  one, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='02nd'  then P.AMOUNT end )as  two, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='03rd'  then P.AMOUNT end )as  three, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='04th'  then P.AMOUNT end )as  four, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='05th'  then P.AMOUNT end )as  five, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='06th'  then P.AMOUNT end )as  sixe, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='07th'  then P.AMOUNT end )as  Seven, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='08th'  then P.AMOUNT end )as  eight, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='09th'  then P.AMOUNT end )as  nine, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='10th'  then P.AMOUNT end )as  ten, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='11th'  then P.AMOUNT end )as  eleven, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='12th'  then P.AMOUNT end )as  twelve, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='13th'  then P.AMOUNT end )as  tharty, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='14th'  then P.AMOUNT end )as  Foruty, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='14th'  then P.AMOUNT end )as  Fivty ";
            strSQL = strSQL + "FROM PRO_MONTHLY_PROJECTION_CHILD P,ACC_LEDGER_Z_D_A V ";
            strSQL = strSQL + "WHERE V.LEDGER_NAME=P.LEDGER_NAME ";

            //strSQL = strSQL + " AND V.AREA in ('AH-AM-Jahid Hossain-Chakaria','AH-FM-Rakib Hossen-Ctg. Sadar') ";

            if (strMonthID != "")
            {
                strSQL = strSQL + "AND P.MONTH_ID ='" + strMonthID + "' ";
            }
            if (strDivision != "")
            {
                if (intmode == 1)
                {
                    strSQL = strSQL + "AND V.DIVISION IN (" + strDivision + ") ";
                }
                else
                {
                    strSQL = strSQL + "AND V.DIVISION ='" + strDivision + "' ";
                }

            }

            strSQL = strSQL + "ORDER BY V.AREA,V.LEDGER_NAME_MERZE ASC  ";



            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                drGetGroup = cmd.ExecuteReader();
                while (drGetGroup.Read())
                {
                    ProjectionSet ogrp = new ProjectionSet();
                    ogrp.strProjectionKey = drGetGroup["MONTHLY_PROJECTION_KEY"].ToString();
                    ogrp.strMonthID = drGetGroup["MONTH_ID"].ToString();
                    ogrp.strZone = drGetGroup["ZONE"].ToString();
                    ogrp.strDivision = drGetGroup["DIVISION"].ToString();
                    ogrp.strAMFM = drGetGroup["AREA"].ToString();
                    ogrp.strMpoName = drGetGroup["LEDGER_NAME"].ToString();
                    ogrp.strMerzeName = drGetGroup["LEDGER_NAME_MERZE"].ToString();
                    ogrp.strProjectionName = drGetGroup["PROJECTION_NAME"].ToString();
                    ogrp.dblToAmt = Convert.ToDouble(drGetGroup["AMOUNT"].ToString());
                    ogrp.intCol = Convert.ToInt32(drGetGroup["COLS"].ToString());
                    ogrp.intRow = Convert.ToInt32(drGetGroup["ROWPOS"].ToString());

                    if (drGetGroup["one"].ToString() != "")
                    {
                        ogrp.dbl1 = Convert.ToDouble(drGetGroup["one"].ToString());
                    }
                    if (drGetGroup["two"].ToString() != "")
                    {
                        ogrp.dbl2 = Convert.ToDouble(drGetGroup["two"].ToString());
                    }

                    if (drGetGroup["three"].ToString() != "")
                    {
                        ogrp.dbl3 = Convert.ToDouble(drGetGroup["three"].ToString());
                    }

                    if (drGetGroup["four"].ToString() != "")
                    {
                        ogrp.dbl4 = Convert.ToDouble(drGetGroup["four"].ToString());
                    }

                    if (drGetGroup["five"].ToString() != "")
                    {
                        ogrp.dbl5 = Convert.ToDouble(drGetGroup["five"].ToString());
                    }
                    if (drGetGroup["sixe"].ToString() != "")
                    {
                        ogrp.dbl6 = Convert.ToDouble(drGetGroup["sixe"].ToString());
                    }
                    if (drGetGroup["Seven"].ToString() != "")
                    {
                        ogrp.dbl7 = Convert.ToDouble(drGetGroup["Seven"].ToString());
                    }

                    if (drGetGroup["eight"].ToString() != "")
                    {
                        ogrp.dbl8 = Convert.ToDouble(drGetGroup["eight"].ToString());
                    }

                    if (drGetGroup["nine"].ToString() != "")
                    {
                        ogrp.dbl9 = Convert.ToDouble(drGetGroup["nine"].ToString());
                    }

                    if (drGetGroup["ten"].ToString() != "")
                    {
                        ogrp.dbl10 = Convert.ToDouble(drGetGroup["ten"].ToString());
                    }
                    if (drGetGroup["eleven"].ToString() != "")
                    {
                        ogrp.dbl11 = Convert.ToDouble(drGetGroup["eleven"].ToString());
                    }
                    if (drGetGroup["twelve"].ToString() != "")
                    {
                        ogrp.dbl12 = Convert.ToDouble(drGetGroup["twelve"].ToString());
                    }

                    if (drGetGroup["tharty"].ToString() != "")
                    {
                        ogrp.dbl13 = Convert.ToDouble(drGetGroup["tharty"].ToString());
                    }

                    if (drGetGroup["Foruty"].ToString() != "")
                    {
                        ogrp.dbl14 = Convert.ToDouble(drGetGroup["Foruty"].ToString());
                    }
                    if (drGetGroup["Fivty"].ToString() != "")
                    {
                        ogrp.dbl15 = Convert.ToDouble(drGetGroup["Fivty"].ToString());
                    }

                    ooLed.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return ooLed;

            }
        }
        #endregion
        #region "Report Weekly Projection"
        public List<ProjectionSet> mFillWeeklyProjectionReport(string strDeComID, string strMonthID, string strDivision, int intmode)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<ProjectionSet> ooLed = new List<ProjectionSet>();


            strSQL = "SELECT P.WEEKLY_PROJECTION_KEY, P.MONTH_ID,V.ZONE,V.DIVISION, V.AREA,V.LEDGER_NAME_MERZE, ";
            strSQL = strSQL + "P.LEDGER_NAME,P.PROJECTION_NAME, P.AMOUNT, P.COLS,  ";
            strSQL = strSQL + "P.ROWPOS, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='01st'  then P.AMOUNT end )as  one, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='02nd'  then P.AMOUNT end )as  two, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='03rd'  then P.AMOUNT end )as  three, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='04th'  then P.AMOUNT end )as  four, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='05th'  then P.AMOUNT end )as  five, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='06th'  then P.AMOUNT end )as  sixe, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='07th'  then P.AMOUNT end )as  Seven, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='08th'  then P.AMOUNT end )as  eight, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='09th'  then P.AMOUNT end )as  nine, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='10th'  then P.AMOUNT end )as  ten, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='11th'  then P.AMOUNT end )as  eleven, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='12th'  then P.AMOUNT end )as  twelve, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='13th'  then P.AMOUNT end )as  tharty, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='14th'  then P.AMOUNT end )as  Foruty, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='15th'  then P.AMOUNT end )as  fivty, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='Written' and P.COMM_PROJECTON_NAME ='01st'  then P.AMOUNT end )as  oneW, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='Written' and P.COMM_PROJECTON_NAME ='02nd'  then P.AMOUNT end )as  twoW, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='Written' and P.COMM_PROJECTON_NAME ='03rd'  then P.AMOUNT end )as  ThreeW, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='Written' and P.COMM_PROJECTON_NAME ='04th'  then P.AMOUNT end )as  fourW, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='Written' and P.COMM_PROJECTON_NAME ='05th'  then P.AMOUNT end )as  FiveW, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='Written' and P.COMM_PROJECTON_NAME ='06th'  then P.AMOUNT end )as  sixW, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='Written' and P.COMM_PROJECTON_NAME ='07th'  then P.AMOUNT end )as  SevenW, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='Written' and P.COMM_PROJECTON_NAME ='08th'  then P.AMOUNT end )as  eightW, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='Written' and P.COMM_PROJECTON_NAME ='09th'  then P.AMOUNT end )as  nineW, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='Written' and P.COMM_PROJECTON_NAME ='10th'  then P.AMOUNT end )as  tenW, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='Written' and P.COMM_PROJECTON_NAME ='11th'  then P.AMOUNT end )as  elevenW, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='Written' and P.COMM_PROJECTON_NAME ='12th'  then P.AMOUNT end )as  twelveW, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='Written' and P.COMM_PROJECTON_NAME ='13th'  then P.AMOUNT end )as  thartinW, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='Written' and P.COMM_PROJECTON_NAME ='14th'  then P.AMOUNT end )as  ForutinW, ";
            strSQL = strSQL + "(case when P.PROJECTION_NAME ='Written' and P.COMM_PROJECTON_NAME ='15th'  then P.AMOUNT end )as  FivtinW ";
            strSQL = strSQL + "FROM PRO_WEEKLY_PROJECTION P,ACC_LEDGER_Z_D_A V WHERE P.LEDGER_NAME =V.LEDGER_NAME  ";
            if (strMonthID != "")
            {
                strSQL = strSQL + "AND P.MONTH_ID ='" + strMonthID + "'  ";
            }
            if (strDivision != "")
            {
                if (intmode == 1)
                {
                    strSQL = strSQL + "AND V.DIVISION IN(" + strDivision + ")  ";
                }
                else
                {
                    strSQL = strSQL + "AND V.DIVISION ='" + strDivision + "' ";
                }
            }
            strSQL = strSQL + "ORDER BY V.ZONE,V.DIVISION, V.AREA,V.LEDGER_NAME_MERZE ASC  ";

            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                drGetGroup = cmd.ExecuteReader();
                while (drGetGroup.Read())
                {
                    ProjectionSet ogrp = new ProjectionSet();
                    ogrp.strProjectionKey = drGetGroup["WEEKLY_PROJECTION_KEY"].ToString();
                    ogrp.strMonthID = drGetGroup["MONTH_ID"].ToString();
                    ogrp.strZone = drGetGroup["ZONE"].ToString();
                    ogrp.strDivision = drGetGroup["DIVISION"].ToString();
                    ogrp.strAMFM = drGetGroup["AREA"].ToString();
                    ogrp.strMpoName = drGetGroup["LEDGER_NAME"].ToString();
                    ogrp.strMerzeName = drGetGroup["LEDGER_NAME_MERZE"].ToString();
                    ogrp.strProjectionName = drGetGroup["PROJECTION_NAME"].ToString();
                    ogrp.dblToAmt = Convert.ToDouble(drGetGroup["AMOUNT"].ToString());
                    ogrp.intCol = Convert.ToInt32(drGetGroup["COLS"].ToString());
                    ogrp.intRow = Convert.ToInt32(drGetGroup["ROWPOS"].ToString());


                    if (drGetGroup["one"].ToString() != "")
                    {
                        ogrp.dbl1 = Convert.ToDouble(drGetGroup["one"].ToString());
                    }
                    else
                    {
                        ogrp.dbl1 = 0;
                    }
                    if (drGetGroup["two"].ToString() != "")
                    {
                        ogrp.dbl2 = Convert.ToDouble(drGetGroup["two"].ToString());
                    }
                    else
                    {
                        ogrp.dbl2 = 0;
                    }

                    if (drGetGroup["three"].ToString() != "")
                    {
                        ogrp.dbl3 = Convert.ToDouble(drGetGroup["three"].ToString());
                    }
                    else
                    {
                        ogrp.dbl3 = 0;
                    }

                    if (drGetGroup["four"].ToString() != "")
                    {
                        ogrp.dbl4 = Convert.ToDouble(drGetGroup["four"].ToString());
                    }
                    else
                    {
                        ogrp.dbl4 = 0;
                    }

                    if (drGetGroup["five"].ToString() != "")
                    {
                        ogrp.dbl5 = Convert.ToDouble(drGetGroup["five"].ToString());
                    }
                    else
                    {
                        ogrp.dbl5 = 0;
                    }
                    if (drGetGroup["sixe"].ToString() != "")
                    {
                        ogrp.dbl6 = Convert.ToDouble(drGetGroup["sixe"].ToString());
                    }
                    else
                    {
                        ogrp.dbl6 = 0;
                    }
                    if (drGetGroup["Seven"].ToString() != "")
                    {
                        ogrp.dbl7 = Convert.ToDouble(drGetGroup["Seven"].ToString());
                    }
                    else
                    {
                        ogrp.dbl7 = 0;
                    }
                    if (drGetGroup["eight"].ToString() != "")
                    {
                        ogrp.dbl8 = Convert.ToDouble(drGetGroup["eight"].ToString());
                    }
                    else
                    {
                        ogrp.dbl8 = 0;
                    }
                    if (drGetGroup["nine"].ToString() != "")
                    {
                        ogrp.dbl9 = Convert.ToDouble(drGetGroup["nine"].ToString());
                    }
                    else
                    {
                        ogrp.dbl9 = 0;
                    }
                    if (drGetGroup["ten"].ToString() != "")
                    {
                        ogrp.dbl10 = Convert.ToDouble(drGetGroup["ten"].ToString());
                    }
                    else
                    {
                        ogrp.dbl9 = 0;
                    }
                    if (drGetGroup["eleven"].ToString() != "")
                    {
                        ogrp.dbl11 = Convert.ToDouble(drGetGroup["eleven"].ToString());
                    }
                    else
                    {
                        ogrp.dbl10 = 0;
                    }
                    if (drGetGroup["twelve"].ToString() != "")
                    {
                        ogrp.dbl12 = Convert.ToDouble(drGetGroup["twelve"].ToString());
                    }
                    else
                    {
                        ogrp.dbl11 = 0;
                    }
                    if (drGetGroup["tharty"].ToString() != "")
                    {
                        ogrp.dbl13 = Convert.ToDouble(drGetGroup["tharty"].ToString());
                    }
                    else
                    {
                        ogrp.dbl13 = 0;
                    }
                    if (drGetGroup["Foruty"].ToString() != "")
                    {
                        ogrp.dbl14 = Convert.ToDouble(drGetGroup["Foruty"].ToString());
                    }
                    else
                    {
                        ogrp.dbl14 = 0;
                    }
                    if (drGetGroup["fivty"].ToString() != "")
                    {
                        ogrp.dbl15 = Convert.ToDouble(drGetGroup["fivty"].ToString());
                    }
                    else
                    {
                        ogrp.dbl15 = 0;
                    }



                    if (drGetGroup["oneW"].ToString() != "")
                    {
                        ogrp.dblW1 = Convert.ToDouble(drGetGroup["oneW"].ToString());
                    }
                    if (drGetGroup["twoW"].ToString() != "")
                    {
                        ogrp.dblW2 = Convert.ToDouble(drGetGroup["twoW"].ToString());
                    }

                    if (drGetGroup["threeW"].ToString() != "")
                    {
                        ogrp.dblW3 = Convert.ToDouble(drGetGroup["threeW"].ToString());
                    }

                    if (drGetGroup["fourW"].ToString() != "")
                    {
                        ogrp.dblW4 = Convert.ToDouble(drGetGroup["fourW"].ToString());
                    }

                    if (drGetGroup["fiveW"].ToString() != "")
                    {
                        ogrp.dblW5 = Convert.ToDouble(drGetGroup["fiveW"].ToString());
                    }
                    if (drGetGroup["sixW"].ToString() != "")
                    {
                        ogrp.dblW6 = Convert.ToDouble(drGetGroup["sixW"].ToString());
                    }
                    if (drGetGroup["SevenW"].ToString() != "")
                    {
                        ogrp.dblW7 = Convert.ToDouble(drGetGroup["SevenW"].ToString());
                    }

                    if (drGetGroup["eightW"].ToString() != "")
                    {
                        ogrp.dblW8 = Convert.ToDouble(drGetGroup["eightW"].ToString());
                    }

                    if (drGetGroup["nineW"].ToString() != "")
                    {
                        ogrp.dblW9 = Convert.ToDouble(drGetGroup["nineW"].ToString());
                    }

                    if (drGetGroup["tenW"].ToString() != "")
                    {
                        ogrp.dblW10 = Convert.ToDouble(drGetGroup["tenW"].ToString());
                    }
                    if (drGetGroup["elevenW"].ToString() != "")
                    {
                        ogrp.dblW11 = Convert.ToDouble(drGetGroup["elevenW"].ToString());
                    }
                    if (drGetGroup["twelveW"].ToString() != "")
                    {
                        ogrp.dblW12 = Convert.ToDouble(drGetGroup["twelveW"].ToString());
                    }

                    if (drGetGroup["thartinW"].ToString() != "")
                    {
                        ogrp.dblW13 = Convert.ToDouble(drGetGroup["thartinW"].ToString());
                    }

                    if (drGetGroup["ForutinW"].ToString() != "")
                    {
                        ogrp.dblW14 = Convert.ToDouble(drGetGroup["ForutinW"].ToString());
                    }
                    if (drGetGroup["FivtinW"].ToString() != "")
                    {
                        ogrp.dblW15 = Convert.ToDouble(drGetGroup["FivtinW"].ToString());
                    }




                    ooLed.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return ooLed;

            }
        }
        #endregion
    }
}
